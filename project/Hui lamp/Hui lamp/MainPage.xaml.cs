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
using Windows.UI;

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
        Light1 light1;
        public MainPage()
        {
            this.InitializeComponent();
            SaturationSlider.IsEnabled = false;
            BrightnesSlider.IsEnabled = false;
            ColorSlider.IsEnabled = false;
            button1.IsEnabled = false;
            button2.IsEnabled = false;
            checkBox_ligthsOn.IsEnabled = false;
            comboBox_Lamps.IsEnabled = false;
            button_SendAll.IsEnabled = false;
            button_update.IsEnabled = false;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if((bool)checkBox_Simulator.IsChecked)
            test = new NetworkHandler("localhost", textBox_Poort.Text, "martijn"); 
            else
            test = new NetworkHandler(textBox_URL.Text, textBox_Poort.Text, "martijn");
            isConnected = true;
            light1 = new Light1(BrightnesSlider.Value,ColorSlider.Value,SaturationSlider.Value);
            Kleur.Fill = new SolidColorBrush(getColor());
            SaturationSlider.IsEnabled = true;
            BrightnesSlider.IsEnabled = true;
            ColorSlider.IsEnabled = true;
            button1.IsEnabled = true;
            button2.IsEnabled = true;
            checkBox_ligthsOn.IsEnabled = true;
            comboBox_Lamps.IsEnabled = true;
            button_SendAll.IsEnabled = true;
            button_update.IsEnabled = true;
            update();
        }

        public void updateColor()
        {
            light1.setColor(BrightnesSlider.Value, ColorSlider.Value, SaturationSlider.Value);
            Kleur.Fill = new SolidColorBrush(getColor());
        }

        public Color getColor()
        {
            return ColorUtil.getColor(light1);
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
                        test.PutCommand("{\"on\": false}");
                    }
                }
                else
                    test.PutCommand(@"{""on"":false}");


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
                        test.PutCommand("{\"on\": true}");
                    }
                }
                else
                test.PutCommand("{\"on\": true}");
            }
        }

        private void button_SendAll_Click(object sender, RoutedEventArgs e)
        {
            if (isConnected)
            {
                if (selectAll)
                {
                    for (int i = 1; i <= test.lamps; i++)
                    {
                        test.selectedLamp = "" + i;
                        test.PutCommand(@"{""on"":" + checkBox_ligthsOn.IsChecked.ToString().ToLower() + @",""bri"":" + BrightnesSlider.Value + @",""hue"":" + ColorSlider.Value + @",""sat"":" + SaturationSlider.Value + "}");
                    }
                }
                else
                    
                test.PutCommand(@"{""on"":" + checkBox_ligthsOn.IsChecked.ToString().ToLower() + @",""bri"":" + BrightnesSlider.Value + @",""hue"":" + ColorSlider.Value + @",""sat"":" + SaturationSlider.Value + "}");
                //@"{""on"":" + checkBox_ligthsOn.IsChecked + @",""bri"":" + slider.Value + @",""hue"":" + ColorSlider.Value + @",""sat"":" + SaturationSlider.Value + "}"
            }

        }

        private async void put()
        {
            string tests = @"{""on"":" + checkBox_ligthsOn.IsChecked.ToString().ToLower() + @",""bri"":" + BrightnesSlider.Value + @",""hue"":" + ColorSlider.Value + @",""sat"":" + SaturationSlider.Value + "}";
            string response = await test.PutCommand(tests);
            int i = 0;
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
            update();
            //textBox_Poort.Text = test.codedusername;
        }

        public void update()
        {
            comboBox_Lamps.Items.Clear();
            for (int i = 0; i < test.lamps; i++)
            {
                comboBox_Lamps.Items.Add(i + 1 + "");
            }
            comboBox_Lamps.Items.Add("All Lamps");
        }

        private void changeSat()
        {
            if (isConnected)
            {
                if (selectAll)
                {
                    for (int i = 1; i <= test.lamps; i++)
                    {
                        test.selectedLamp = "" + i;
                        test.PutCommand("{\"sat\":" + SaturationSlider.Value + "}");
                    }
                }
                else
                    test.PutCommand("{\"sat\":" + SaturationSlider.Value + "}");
            }
        }

        private void changeHue()
        {
            if (isConnected)
            {

                if (selectAll)
                {
                    for (int i = 1; i <= test.lamps; i++)
                    {
                        test.selectedLamp = "" + i;
                        test.PutCommand("{\"hue\":" + ColorSlider.Value + "}");
                    }
                }
                else
                    test.PutCommand("{\"hue\":" + ColorSlider.Value + "}");
            }
        }

        private void changeBri()
        {
            if (isConnected)
            {
                if (selectAll)
                {
                    for (int i = 1; i <= test.lamps; i++)
                    {
                        test.selectedLamp = "" + i;
                        test.PutCommand("{\"bri\":" + BrightnesSlider.Value + " }");
                    }
                }
                else
                    test.PutCommand("{\"bri\":" + BrightnesSlider.Value + "}");
            }
        }


        private void SaturationSlider_PointerCaptureLost(object sender, PointerRoutedEventArgs e)
        {
            changeSat();
        }

        private void BrightnesSlider_PointerCaptureLost(object sender, PointerRoutedEventArgs e)
        {
            changeBri();
        }

        private void ColorSlider_PointerCaptureLost(object sender, PointerRoutedEventArgs e)
        {
            changeHue();
        }

        private void SaturationSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            updateColor();
        }

        private void BrightnesSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            updateColor();
        }

        private void ColorSlider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            updateColor();
        }

        private void textBox_URL_TextChanged(object sender, TextChangedEventArgs e)
        {

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
