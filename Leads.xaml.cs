using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_Demo
{
    /// <summary>
    /// Interaction logic for Leads.xaml
    /// </summary>
   
    public partial class Leads : Window
    {
        public static DataGrid DataGrid;

        public Leads()
        {
            InitializeComponent();
            Load();
            
         
        }
        private void Load()
        {
            DataGrid = grdEmployee; 
        }
        private async void Add()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44359");

            client.DefaultRequestHeaders.Accept.Add(
new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response =await client.GetAsync("api/Leads");
            Lead lead = new Lead();
           
         
            if (response.IsSuccessStatusCode)
            {
               IList<Lead> employees = await response.Content.ReadAsAsync<IList<Lead>>();
                grdEmployee.ItemsSource = employees;

            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);
            }

        }
        private void Window_Loaded(object sender,RoutedEventArgs e)
        {
            Add();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44359");

            client.DefaultRequestHeaders.Accept.Add(
new MediaTypeWithQualityHeaderValue("application/json"));
            var ID = (grdEmployee.SelectedItem as Lead).Lid;


            HttpResponseMessage response = await client.GetAsync($"api/Leads/{ID}");

            Lead lead=new Lead();
            if (response.IsSuccessStatusCode)

            {
               
                Popup popup = new Popup(grdEmployee.CurrentItem);
                popup.Show();

            }
            else
            {
                MessageBox.Show("Error Code" + response.StatusCode + " : Message - " + response.ReasonPhrase);

            }
            
           
             
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {

            var message = "";


           
            
            using (HttpClient client = new HttpClient())
            {

                var ID = (grdEmployee.SelectedItem as Lead).Lid;
                client.BaseAddress = new Uri("https://localhost:44359");

                client.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/json"));

                
                HttpResponseMessage response = await client.DeleteAsync(
                $"api/Leads/{ID}");
               

                try
                {
                    
                    response.EnsureSuccessStatusCode();
                    await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Deleted Successfully");
                  


                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }
               

               
            }

        }

    
    }
}
