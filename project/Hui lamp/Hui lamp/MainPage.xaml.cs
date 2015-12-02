﻿using System;
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
        bool isConnected = false;
        bool selectAll = false;
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if((bool)checkBox_Simulator.IsChecked)
            test = new NetworkHandler("localhost", textBox_Poort.Text, "martijn"); 
            else
            test = new NetworkHandler(textBox_URL.Text, textBox_Poort.Text, "martijn");
            isConnected = true;
            for(int i = 0; i < test.lamps; i++ )
            {
                comboBox_Lamps.Items.Add(i+1+"");
            }
            comboBox_Lamps.Items.Add("All Lamps");
            textBox_URL.Text = "" + test.lamps;
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (isConnected)
            {
                if (selectAll)
                {
                    for (int i = 1; i <= test.lamps; i++)
                    {
                        test.selectedLamp = "" + i;
                        test.PutCommand("{\"on\": \"false\"}");
                    }
                }
                else
                test.PutCommand("{\"on\": \"false\"}");
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (isConnected)
            {

                if (selectAll)
                {
                    for (int i = 1; i <= test.lamps; i++)
                    {
                        test.selectedLamp = "" + i;
                        test.PutCommand("{\"on\": \"true\"}");
                    }
                }
                else
                test.PutCommand("{\"on\": \"true\"}");
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (isConnected)
            {
                if (selectAll)
                {
                    for (int i = 1; i <= test.lamps; i++)
                    {
                        test.selectedLamp = "" + i;
                        test.PutCommand("{\"bri\":\"" + slider.Value + "\"}");
                    }
                }
                else
                test.PutCommand("{\"bri\":\"" + slider.Value + "\"}");
            }
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            if (isConnected)
            {

                if (selectAll)
                {
                    for (int i = 1; i <= test.lamps; i++)
                    {
                        test.selectedLamp = "" + i;
                        test.PutCommand("{\"hue\":\"" + ColorSlider.Value + "\"}");
                    }
                }
                else
                test.PutCommand("{\"hue\":\"" + ColorSlider.Value + "\"}");
            }
        }

        private void SaturationButton_Click(object sender, RoutedEventArgs e)
        {
            if (isConnected)
            {
                if (selectAll)
                {
                    for (int i = 1; i <= test.lamps; i++)
                    {
                        test.selectedLamp = "" + i;
                        test.PutCommand("{\"sat\":\"" + SaturationSlider.Value + "\"}");
                    }
                }
                else
                test.PutCommand("{\"sat\":\"" + SaturationSlider.Value + "\"}");
            }
        }

        private void button_SendAll_Click(object sender, RoutedEventArgs e)
        {
            if (isConnected)
            {
                if(selectAll)
                {
                    for(int i=1;i <= test.lamps;i++)
                    {
                        test.selectedLamp = "" + i;
                        test.PutCommand(@"{""on"":" + checkBox_ligthsOn.IsChecked + @",""bri"":" + slider.Value + @",""hue"":" + ColorSlider.Value + @",""sat"":" + SaturationSlider.Value + "}");
                    }
                }
                else
                test.PutCommand(@"{""on"":" + checkBox_ligthsOn.IsChecked + @",""bri"":" + slider.Value + @",""hue"":" + ColorSlider.Value + @",""sat"":" + SaturationSlider.Value + "}");
                //@"{""on"":" + checkBox_ligthsOn.IsChecked + @",""bri"":" + slider.Value + @",""hue"":" + ColorSlider.Value + @",""sat"":" + SaturationSlider.Value + "}"
            }

        }

        private void comboBox_Lamps_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if((string)comboBox_Lamps.SelectedItem !="All Lamps")
            {
                selectAll = false;
                test.selectedLamp = (string)comboBox_Lamps.SelectedItem;
            }
            else
            {
                selectAll = true;
            }

        }

        private void button_update_Click(object sender, RoutedEventArgs e)
        {
            comboBox_Lamps.Items.Clear();
            for (int i = 0; i < test.lamps; i++)
            {
                comboBox_Lamps.Items.Add(i + 1 + "");
            }
            comboBox_Lamps.Items.Add("All Lamps");
            textBox_URL.Text = "" + test.lamps;
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
