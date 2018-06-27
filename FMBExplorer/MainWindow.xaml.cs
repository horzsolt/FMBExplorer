using FMBExplorer.CodeGen;
using FMBExplorer.Common;
using FMBExplorer.FormsElement;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Xml;

namespace FMBExplorer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel vm = new MainViewModel();
        public MainWindow()
        {
            InitializeComponent();
            vm.CurrentFolder = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Resource");
            vm.IsGridCodeGen = false;
            DataContext = vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.SelectedPath = vm.CurrentFolder;

            System.Windows.Forms.DialogResult result = dialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                vm.CurrentFolder = dialog.SelectedPath;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string[] filePaths = Directory.GetFiles(vm.CurrentFolder, "*.xml");

            ProgressBar1.Maximum = filePaths.Length;

            try
            {
                vm.FmxList = new ObservableDictionary<string, FormsElement.FormModule>();

                filePaths.ToList<string>().ForEach(xmlFile =>
                {
                    vm.FmxList.Add(xmlFile, FMXParser.ProcessFormsXML(xmlFile));
                    ProgressBar1.Value++;
                }
                );
            } finally
            {
                ProgressBar1.Value = 0;
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vm.FormModule = vm.SelectedFormModule.Value;
            treeView.ItemsSource = vm.FormModule.Blocks;            
        }

        private void treeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue is Block)
            {
                Block block = e.NewValue as Block;

                XmlDocument xml_document = new XmlDocument();
                XmlDeclaration xmldecl = xml_document.CreateXmlDeclaration("1.0", "UTF-8", "yes");

                if (FormsUtility.IsGrid(block) == false)
                {
                    xml_document.LoadXml(GenerateDataForm.Generate(block));
                }
                else
                {
                    xml_document.LoadXml(GenerateDataGrid.Generate(block));
                }

                XmlElement root = xml_document.DocumentElement;
                xml_document.InsertBefore(xmldecl, root);

                StringWriter string_writer = new StringWriter();
                XmlTextWriter xml_text_writer = new XmlTextWriter(string_writer);
                xml_text_writer.Formatting = Formatting.Indented;
                xml_document.WriteTo(xml_text_writer);

                documentViewer.XmlDocument = xml_document;
                vm.GeneratedCode = string_writer.ToString();

                xml_text_writer.Close();
                string_writer.Close();

            } else
            {
                vm.GeneratedCode = "";
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(vm.GeneratedCode);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(vm.GeneratedCode))
            {
                Window previewWindow = (Window)XamlReader.Parse(vm.GeneratedCode);
                previewWindow.WindowState = WindowState.Maximized;
                previewWindow.ShowDialog();
            }
        }
    }
}
