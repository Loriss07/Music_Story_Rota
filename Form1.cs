using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net.Http.Json;
using OAuth;
using RestSharp;
using RestSharp.Authenticators;
using RestSharp.Authenticators.OAuth;
using System.Windows.Forms;

namespace Music_Story_Rota
{
    public partial class Form1 : Form
    {
        private HTTPClient Client = new HTTPClient("http://api.music-story.com/artist/search?name=Lady%20Gaga");
        public Form1()
        {
            InitializeComponent();
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Client.Read();
        }
    }
    public class HTTPClient
    {
        static RestClient http;
        private string URL;
        private string ConsumerKey;
        private string ConsumerSecret;
        private string AccessToken;
        private string TokenSecret;
        private OAuth1Authenticator sign;

        public HTTPClient(string URL)
        {
            http = new RestClient();
            this.URL = URL;
            ConsumerKey = "a406b97e8c4536f215d8610e5aed3e36c0825cca";
            ConsumerSecret = "d4558644cdb6e8db2287627751bfa7e9eea577ed";
            AccessToken = "1afcbd4add8503ab72afa2068957cfab4df2bbbc";
            TokenSecret = "4e42f541ce1a634e26ca8590ccc778d75d281b7e";
            sign = OAuth1Authenticator.ForProtectedResource(ConsumerKey, ConsumerSecret, AccessToken, TokenSecret);


        }
        private async Task<string> ReadResource(RestRequest request)
        {
            string artist = null;
            http.Authenticator = sign;
            RestResponse response = await http.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                artist = response.Content;
            }
            return artist;
        }
        
        public async Task Read()
        {
            
            var request = new RestRequest(URL, Method.Get);
            request.AddHeader("Content-Type", "text/xml");
          
/*
            http.BaseAddress = new Uri(URL);
            http.DefaultRequestHeaders.Accept.Clear();
            http.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("text/xml"));
            */
            string Album = await ReadResource(request);
            MessageBox.Show(Album.ToString());
        }
    }
    public class PhotoAlbum
    {
        public int album_ID { get; set; }
        public int photo_ID { get; set; }
        public string photo_title { get; set; }
        public string photo_URL { get; set; }
        public string thumb_URL { get; set; }

        override
        public string ToString()
        {
            return photo_title + " - Photo n° " + photo_ID + " from album " + album_ID;
        }
    }
}
