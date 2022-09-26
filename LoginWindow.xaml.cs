
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
       
        public static readonly string uri = "https://localhost:44359/api/Login";
        public LoginWindow()
        {
            InitializeComponent();
        }


        private async void txtbutton_Click(object sender, RoutedEventArgs e)
        {
           
            
            using(HttpClient client=new HttpClient())
            { 
                var login = new Login()
                {
                    Email = Email.Text,
                    Password = t2.Text
                };

                string errormessage = string.Empty;
                try
                {
                    HttpResponseMessage response = await client.PostAsJsonAsync($"{uri}", login);
                    response.EnsureSuccessStatusCode();
                    errormessage= await response.Content.ReadAsStringAsync();
                    
 
                }
                catch(Exception ex)
                {
                    errormessage = ex.Message;
                    
                }
                login = new Login();
                MessageBox.Show(errormessage);
                
            }
        }
    }
    
}
