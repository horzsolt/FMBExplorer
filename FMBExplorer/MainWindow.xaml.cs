using FMBExplorer.CodeGen;
using FMBExplorer.FormsElement;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
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
                vm.FmxList = new Dictionary<string, FormsElement.FormModule>();

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
                vm.GeneratedCode = GenerateDataGrid.Generate(block);

                XmlDocument doc = new XmlDocument();
                doc.LoadXml(vm.GeneratedCode);
                doc.Normalize();

                documentViewer.XmlDocument = doc;
            } else
            {
                vm.GeneratedCode = "";
            }
        }
    }
}
