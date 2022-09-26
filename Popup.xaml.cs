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
    /// Interaction logic for Popup.xaml
    /// </summary>
    public partial class Popup : Window
    {
       

        public Popup(object user)
        {
            InitializeComponent();
            DataContext = user;
           
            
        }

       

        private async void onclick_Click(object sender, RoutedEventArgs e)
        {
           
            using (HttpClient client = new HttpClient())
            {
                
                string errormessage = "";
               
                client.BaseAddress = new Uri("https://localhost:44359");
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

            
               
                Lead lead = new Lead();
                try
                {
                    var url = "api/Leads";


                    HttpResponseMessage response = await client.PutAsJsonAsync($"{url}",lead);
                    
                    response.EnsureSuccessStatusCode();
                    
                    errormessage = await response.Content.ReadAsStringAsync();


                }
                catch (Exception ex)
                {
                    errormessage = ex.Message;

                }
            }

        }

        
    }
}
