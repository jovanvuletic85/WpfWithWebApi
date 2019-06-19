using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Shapes;
using System.Net.Http;
using Newtonsoft.Json;

namespace WpfApi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HttpClient cl = new HttpClient();

        public MainWindow()
        {
            InitializeComponent();
            cl.BaseAddress = new Uri("http://localhost:53711/");
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Brand> listBrand = await retBrand();

            foreach (Brand b in listBrand)
            {
                listBox1.Items.Add(b);
            }
            listBox1.DisplayMemberPath = "BrandName";
        }

        private async Task<List<Brand>> retBrand()
        {
            
            try
            {
                string json = await cl.GetStringAsync("/api/brand");
                List<Brand> listBrand = JsonConvert.DeserializeObject<List<Brand>>(json);
                return listBrand;
            }
            catch (Exception)
            {

                return null;
            }
        }

        private async Task<List<Model>> retModel(int id)
        {
            try
            {
                string json = await cl.GetStringAsync("/api/model/" + id);
                List<Model> listModel = JsonConvert.DeserializeObject<List<Model>>(json);
                return listModel;
            }
            catch (Exception)
            {

                return null;
            }
        }

        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            Brand b = (Brand)listBox1.SelectedItem;

            List<Model> listModel = await retModel(b.BrandId);

            StringBuilder sb = new StringBuilder();

            foreach (Model m in listModel)
            {
                sb.AppendLine(m.ModelName + " " + m.Price + " " + m.Fuel);
            }

            textblock1.Text = sb.ToString();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            textblock1.Text = String.Empty;
        }
    }
}
