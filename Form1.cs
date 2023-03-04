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
using System.Diagnostics;

namespace Music_Story_Rota
{
    public partial class Form1 : Form
    {
        private HTTPClient Client = new HTTPClient("http://api.music-story.com");
        public Form1()
        {
            InitializeComponent();

        }
        private void button1_Click(object sender, EventArgs e)
        {

            string ConsumerKey = "a406b97e8c4536f215d8610e5aed3e36c0825cca";
            string ConsumerSecret = "d4558644cdb6e8db2287627751bfa7e9eea577ed";
            string AccessToken = "1afcbd4add8503ab72afa2068957cfab4df2bbbc";
            string TokenSecret = "4e42f541ce1a634e26ca8590ccc778d75d281b7e";
            OAuth1Authenticator sign = OAuth1Authenticator.ForProtectedResource(ConsumerKey, ConsumerSecret, AccessToken, TokenSecret);

            /*HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("http://api.music-story.com");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Authorization=new AuthenticationHeaderValue("Bearer", AccessToken);

            client.DefaultRequestHeaders.Add("oauth_consumer_key", ConsumerKey);
            client.DefaultRequestHeaders.Add("oauth_consumer_key", sign.);

            HttpResponseMessage response = await client.GetAsync("/artist/search?name=Bob%20Marley");
            MessageBox.Show(response.StatusCode + "");
            MessageBox.Show(response.Content.ToString());*/

            var client = new RestClient("http://api.music-story.com/artist/search?name=Bob%20Marley")
            {
                Authenticator = OAuth1Authenticator.ForProtectedResource(ConsumerKey, ConsumerSecret, AccessToken, TokenSecret)
            };

            var request = new RestRequest("http://api.music-story.com/artist/search?name=Bob%20Marley",Method.Get);
            RestResponse response = client.Execute(request);
            MessageBox.Show(response.Content);


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
        /*public async Task Read()
        {
  
            RestRequest request = new RestRequest("http://api.music-story.com/artist/search?name=Bob%20Marley", Method.Get);

            RestResponse<root> response = http.Execute<root>(request);

            if (response.IsSuccessful)
            {
                MessageBox.Show(response.Content);
            }
            else
            {
                MessageBox.Show(response.ErrorMessage);
            }

            Console.WriteLine();

        }*/

        /*public async Task Read2()
        {

            var request = new RestRequest("http://api.music-story.com/artist/search?name=Bob%20Marley", Method.Get);
            request.AddHeader("Content-Type", "text/xml");

            /*
                        http.BaseAddress = new Uri(URL);
                        http.DefaultRequestHeaders.Accept.Clear();
                        http.DefaultRequestHeaders.Accept.Add(
                            new MediaTypeWithQualityHeaderValue("text/xml"));
                        
            http.Authenticator = sign;
            RestResponse response = await http.ExecuteAsync(request);
            MessageBox.Show(response.StatusCode + "");

            if (response.IsSuccessStatusCode)
            {
                artist = response.Content;
                Debug.Write(artist);
            }
            else
            {
                Debug.Write(response.StatusCode);
            }

        }*/

        private async Task<string> ReadResource(RestRequest request)
        {
            string artist = "";
            http.Authenticator = sign;
            RestResponse response = await http.ExecuteAsync(request);
            MessageBox.Show(response.StatusCode+"");

            if (response.IsSuccessStatusCode)
            {
                artist = response.Content;
                Debug.Write(artist);
            }
            else
            {
                Debug.Write(response.StatusCode);
            }
            return artist;
        }
        
        
    }


    // NOTA: con il codice generato potrebbe essere richiesto almeno .NET Framework 4.5 o .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class root
    {

        private decimal versionField;

        private byte codeField;

        private byte countField;

        private byte pageCountField;

        private byte currentPageField;

        private rootItem[] dataField;

        /// <remarks/>
        public decimal version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }

        /// <remarks/>
        public byte code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
            }
        }

        /// <remarks/>
        public byte count
        {
            get
            {
                return this.countField;
            }
            set
            {
                this.countField = value;
            }
        }

        /// <remarks/>
        public byte pageCount
        {
            get
            {
                return this.pageCountField;
            }
            set
            {
                this.pageCountField = value;
            }
        }

        /// <remarks/>
        public byte currentPage
        {
            get
            {
                return this.currentPageField;
            }
            set
            {
                this.currentPageField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("item", IsNullable = false)]
        public rootItem[] data
        {
            get
            {
                return this.dataField;
            }
            set
            {
                this.dataField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class rootItem
    {

        private uint idField;

        private string nameField;

        private object ipiField;

        private string typeField;

        private string urlField;

        private string firstnameField;

        private string lastnameField;

        private byte coeff_actuField;

        private string update_dateField;

        private string creation_dateField;

        private rootItemSearch_scores search_scoresField;

        /// <remarks/>
        public uint id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public object ipi
        {
            get
            {
                return this.ipiField;
            }
            set
            {
                this.ipiField = value;
            }
        }

        /// <remarks/>
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        public string url
        {
            get
            {
                return this.urlField;
            }
            set
            {
                this.urlField = value;
            }
        }

        /// <remarks/>
        public string firstname
        {
            get
            {
                return this.firstnameField;
            }
            set
            {
                this.firstnameField = value;
            }
        }

        /// <remarks/>
        public string lastname
        {
            get
            {
                return this.lastnameField;
            }
            set
            {
                this.lastnameField = value;
            }
        }

        /// <remarks/>
        public byte coeff_actu
        {
            get
            {
                return this.coeff_actuField;
            }
            set
            {
                this.coeff_actuField = value;
            }
        }

        /// <remarks/>
        public string update_date
        {
            get
            {
                return this.update_dateField;
            }
            set
            {
                this.update_dateField = value;
            }
        }

        /// <remarks/>
        public string creation_date
        {
            get
            {
                return this.creation_dateField;
            }
            set
            {
                this.creation_dateField = value;
            }
        }

        /// <remarks/>
        public rootItemSearch_scores search_scores
        {
            get
            {
                return this.search_scoresField;
            }
            set
            {
                this.search_scoresField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class rootItemSearch_scores
    {

        private byte nameField;

        /// <remarks/>
        public byte name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }



}
