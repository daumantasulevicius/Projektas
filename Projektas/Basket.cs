using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.IO;

namespace Projektas
{
    public partial class Basket : Form
    {
        public Basket()
        {
            InitializeComponent();
        }

        private string _token;
        private string _cookie;

        public Basket(string token, string cookie)
        {
            this._token = token;
            this._cookie = cookie;

            InitializeComponent();
            Shown += Basket_Shown;
        }

        private void Basket_Shown(Object sender, EventArgs e)
        {
            ShowProducts();
        }

        private void Basket_Load(object sender, EventArgs e)
        {

        }

        public List<KrepselioPreke> GetBasket()
        {
            List<KrepselioPreke> krepselis = new List<KrepselioPreke>();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:8000/jsonapi/basket?id=default&_token=" + _token);
            request.Method = "GET";
            request.Headers.Add("Cookie", _cookie);
            HttpWebResponse responseH = (HttpWebResponse)request.GetResponse();

            var encoding = ASCIIEncoding.ASCII;
            var responseText = "";
            using (var reader = new System.IO.StreamReader(responseH.GetResponseStream(), encoding))
            {
                responseText = reader.ReadToEnd();
            }

            var s = JsonConvert.DeserializeObject(responseText);

            var data = JObject.Parse(s.ToString()).SelectToken("data");
            var atributai = data.SelectToken("attributes");
            var krepselioKaina = atributai.Value<double>("order.base.price");
            textBox1.Text = krepselioKaina.ToString();

            var included = JObject.Parse(s.ToString()).SelectToken("included") as JArray;
            foreach (var result in included)
            {
                int temp;
                var idd = result.Value<string>("id");
                if (int.TryParse(idd, out temp))
                {

                    var attributeEntry2 = result.SelectToken("attributes");
                    var price = attributeEntry2.Value<double>("order.base.product.price");
                    var id = attributeEntry2.Value<int>("order.base.product.productid");
                    var quantity = attributeEntry2.Value<int>("order.base.product.quantity");
                    var label = attributeEntry2.Value<string>("order.base.product.name");
                    var type = attributeEntry2.Value<string>("order.base.product.type");

                    var links = result.SelectToken("links");
                    var self = links.SelectToken("self");
                    var href = self.Value<string>("href");

                    krepselis.Add(new KrepselioPreke(id, label, type, price, quantity, href));
                }

            }
            responseH.Close();

            return krepselis;
        }
        public List<KrepselioPreke> krepselis = new List<KrepselioPreke>();
        public void ShowProducts()
        {
            if (!(krepselis.Count == 0))
                krepselis.Clear();

            krepselis = GetBasket();
            if (listView1.Items.Count != 0)
            {
                listView1.Items.Clear();
            }
            for (int i = 0; i < krepselis.Count; i++)
                listView1.Items.Add(new ListViewItem(new string[] { krepselis[i].Id.ToString(), krepselis[i].Type, krepselis[i].Label, krepselis[i].Price.ToString(), krepselis[i].quantity.ToString() }));
        }
        public void DeleteRequest(string href)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(href + "&_token=" + _token);
            request.Method = "DELETE";
            request.Headers.Add("Cookie", _cookie);
            HttpWebResponse responseH = (HttpWebResponse)request.GetResponse();
        }
        public void ChangeRequest(string href, string quantity)
        {

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(href + "&_token=" + _token);
            httpWebRequest.Headers.Add("Cookie", _cookie);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PATCH";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{ \"data\":{ \"attributes\":{ \"quantity\":" + quantity + ",\"codes\":[] }}}";

                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            httpResponse.Close();

        }
        public void DeleteItem()
        {
            ListViewItem item = listView1.SelectedItems[0];
            string id = item.SubItems[0].Text;

            for (int i = 0; i < krepselis.Count; i++)
            {
                if (krepselis[i].Id == int.Parse(id))
                {
                    DeleteRequest(krepselis[i].href);
                    break;
                }
            }

        }
        public void ChangeItem()
        {
            ListViewItem item = listView1.SelectedItems[0];
            string id = item.SubItems[0].Text;

            for (int i = 0; i < krepselis.Count; i++)
            {
                if (krepselis[i].Id == int.Parse(id))
                {
                    ChangeRequest(krepselis[i].href, numericUpDown1.Value.ToString());
                    break;
                }
            }

        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            DeleteItem();
            ShowProducts();
        }

        private void Change_Quantity_Click(object sender, EventArgs e)
        {
            ChangeItem();
            ShowProducts();
        }
    }
}
