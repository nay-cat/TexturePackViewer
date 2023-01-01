using System.Windows;
using System.Windows.Controls;
using System.IO;

namespace ResourcePackViewer2
{

    public partial class MainWindow : Window
    {
        string path;
        string request;
        
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Results.Visibility = Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            path = Path.Text;
            if (Path.Text == "Example folder" || Path.Text == null)
            {
                MessageBox.Show("Invalid file");
                return;
            }
            try
            {
               StreamReader file = new StreamReader(path);
                while ((request = file.ReadLine()) != null)
                {
                    if (request.Contains("Resource packs"))
                    {
                        Results.Items.Add(request);
                    }
                }
                file.Close();
                MessageBox.Show("✔️");
            }
            catch
            {
                MessageBox.Show("Can't read this file");
            }
        }
    }
}
