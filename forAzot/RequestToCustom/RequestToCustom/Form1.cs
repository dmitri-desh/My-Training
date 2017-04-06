using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RequestToCustom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var url = @"http://www.customs.gov.by/ru/ybutie-ru/";
            var query = "?xhr=html&query=16457/030317/0003817&r=0.9823423423423";

           

            label1.Text = url + query;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            IWebProxy proxy = request.Proxy;
            if (proxy != null)
            {
                Console.WriteLine("Proxy: {0}", proxy.GetProxy(request.RequestUri));
            }
            else
            {
                Console.WriteLine("Proxy is null; no proxy will be used");
            }

            WebProxy myProxy = new WebProxy();
            Uri newUri = new Uri("http://tmg3.azot.com.by:8080");
            // Associate the newUri object to 'myProxy' object so that new myProxy settings can be set.
            myProxy.Address = newUri;
            // Create a NetworkCredential object and associate it with the 
            // Proxy property of request object.
            myProxy.Credentials = new NetworkCredential("14010", "ufhgbz87");
            request.Proxy = myProxy;



            using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate }))
            {
                client.BaseAddress = new Uri(url);
                HttpResponseMessage response = client.GetAsync(query).Result;
                response.EnsureSuccessStatusCode();
                string result = response.Content.ReadAsStringAsync().Result;
                //Console.WriteLine("Result: " + result);
                richTextBox1.Text = result;
            }
            

         
        }
    }
}
