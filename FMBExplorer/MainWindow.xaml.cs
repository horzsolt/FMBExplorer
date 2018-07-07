using FMBExplorer.CodeGen;
using FMBExplorer.Common;
using FMBExplorer.FormsElement;
using FMBExplorer.PropertyGrid;
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

            genCodeBtn.IsEnabled = false;
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
                vm.selectedBlock = block;

                genCodeBtn.IsEnabled = true;

                CodeGenProperties codeGenProps = new CodeGenProperties();
                codeGenProps.BindingSource = vm.selectedBlock.Name;
                codeGenProps.Name = vm.selectedBlock.Name;
                codeGenProps.CollectionViewSourceName = vm.selectedBlock.Name + "_ViewSource";

                if (FormsUtility.IsGrid(vm.selectedBlock))
                {
                    codeGenProps.DataEntryStyle = CodeGenProperties.DataEntry.Grid;
                } else if (FormsUtility.IsForm(vm.selectedBlock))
                {
                    codeGenProps.DataEntryStyle = CodeGenProperties.DataEntry.Form;
                } else
                {
                    codeGenProps.DataEntryStyle = CodeGenProperties.DataEntry.Simple;
                }

                vm.CodeGenProperties = codeGenProps;
                PropertyGrid1.SelectedObject = vm.CodeGenProperties;

            } else
            {
                vm.GeneratedCode = "";
                genCodeBtn.IsEnabled = false;
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

        private void genCodeBtn_Click(object sender, RoutedEventArgs e)
        {

            XmlDocument xml_document = new XmlDocument();
            XmlDeclaration xmldecl = xml_document.CreateXmlDeclaration("1.0", "UTF-8", "yes");

            if (vm.CodeGenProperties.DataEntryStyle == CodeGenProperties.DataEntry.Form)
            {
                xml_document.LoadXml(GenerateDataForm.Generate(vm.selectedBlock, vm.CodeGenProperties));
            }
            else if (vm.CodeGenProperties.DataEntryStyle == CodeGenProperties.DataEntry.Grid)
            {
                xml_document.LoadXml(GenerateDataGrid.Generate(vm.selectedBlock, vm.CodeGenProperties));
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
        }
    }
}
