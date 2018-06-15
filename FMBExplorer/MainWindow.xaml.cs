using FMBExplorer.FormsTree;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Xml.Linq;

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

            MessageBox.Show(vm.SelectedFormModule.ToString());
            //vm.FormsTree = TreeBuilder.Build();
        }
    }
}
