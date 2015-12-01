using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Net;
using System.Text;
using System.Threading.Tasks;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Hui_lamp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        NetworkHandler test;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            test = new NetworkHandler("localhost", "8000", "martijn");
            
            //test.PutCommand("sfdsf");
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            test.PutCommand("{\"on\": \"false\"}");
        }

        //public async Task<string> LoginAsync()
        //{
        //    var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8531/api/");
        //    httpWebRequest.ContentType = "text/plain";
        //    httpWebRequest.Method = "POST";

        //    using(var stream = await Task.Factory.FromAsync<Stream>(request.BeginGetRequestStream, request.EndGetRequestStream, null))
        //    {
        //        string text = "{ \"devicetype\":\"MijnApp Martijn\"}";

        //    streamWriter.Write(text);
        //    }
        //}
    }
}
