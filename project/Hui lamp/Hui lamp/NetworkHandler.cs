﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Windows.UI;

namespace Hui_lamp
{
    public class NetworkHandler
    {
        private string ip;
        private string port;
        private string username;
        public string codedusername = "3c48414519a1e3473964b7111b4f6c73";
        private string allInfo;
        public int lamps = 0;
        public string selectedLamp = "1";


        public NetworkHandler(string ip, string port, string username)
        {
            this.ip = ip;
            this.port = port;
            this.username = username;
            getUsername();  
                     

        }

        public string getAllinfo()
        {
            return allInfo;
        }


        private async void getUsername()
        {
           // string post = await PostCommand("api", "{\"devicetype\":\"MijnApp#{" + username + "}\"}");
           // string[] data = post.Split('\"');
          //  codedusername = data[5];
            allInfo = await GetCommand("api/" + codedusername);
            lamps = findAllLamps(allInfo.Split('\"'));
        }

        private int findAllLamps(string[] list)
        {
           
            int amount = 0;
            
            for(int i = 0; i<list.Length;i++)
            {
                if (list[i].Contains("LCT"))
                {
                    amount++;
                }
                
            }
            return amount;

        } 

        public async Task<string> GetCommand(string url)
        {
            url = "http://" + ip + ":" + port + "/" + url;
            using (HttpClient hc = new HttpClient())
            {
                var response = await hc.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync(); ;
            }
        }

        public async Task<string> PutCommand(string Data)
        {
            string url = "http://" + ip + ":" + port + "/" + "api/" + codedusername +"/" + "lights" +"/"+ selectedLamp + "/" +"state";
            HttpContent content = new StringContent(Data, Encoding.UTF8, "application/json");
            using (HttpClient hc = new HttpClient())
            {
                var response = await hc.PutAsync(url, content);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        public async Task<string> PutCommand1(string url, string Data)
        {
            url = "http://" + ip + ":" + port + "/" + url;
            HttpContent content = new StringContent(Data, Encoding.UTF8, "application/json");
            using (HttpClient hc = new HttpClient())
            {
                var response = await hc.PutAsync(url, content);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        public async Task<string> PostCommand(string url, string Data)
        {
            url = "http://" + ip + ":" + port + "/" + url;
            HttpContent content = new StringContent(Data, Encoding.UTF8, "application/json");
            using (HttpClient hc = new HttpClient())
            {
                var response = await hc.PostAsync(url, content);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}