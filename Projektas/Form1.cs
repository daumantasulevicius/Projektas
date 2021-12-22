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

namespace Projektas
{
    
    public partial class Form1 : Form
    {
        private ListViewColumnSorter lvwColumnSorter;

        public Form1()
        {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;
            Shown += Form1_Shown;
        }

        private void Form1_Shown(Object sender, EventArgs e)
        {
            Categories();
            ShowProducts();
        }


        public void Categories()
        {
            List<Preke> prekes = AllProducts();
            int j = 1;
            comboBox1.Items.Insert(0, "Visos prekės");
            for (int i = 0; i < prekes.Count; i++)
            {
                if (!comboBox1.Items.Contains(prekes[i].Type))
                {
                    comboBox1.Items.Insert(j, prekes[i].Type);
                    j++;
                }
            }
        }

        public string _token = null;
        public string _cookie = null;


        public List<Preke> AllProducts()
        {
            List<Preke> prekes = new List<Preke>();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:8000/jsonapi/product?include=price");
            request.Method = "GET";
            HttpWebResponse responseH = (HttpWebResponse)request.GetResponse();

            string setCookieHeader = responseH.Headers[HttpResponseHeader.SetCookie];
            char[] separators = new char[] { ',', ';' };

            string XCSRF = setCookieHeader.Split(separators, StringSplitOptions.RemoveEmptyEntries)[0];
            string laravel = setCookieHeader.Split(separators, StringSplitOptions.RemoveEmptyEntries)[5];

            if (_cookie == null)
                _cookie = XCSRF + ";" + laravel + ";";


            var encoding = ASCIIEncoding.ASCII;
            var responseText = "";
            using (var reader = new System.IO.StreamReader(responseH.GetResponseStream(), encoding))
            {
                responseText = reader.ReadToEnd();
            }

            var s = JsonConvert.DeserializeObject(responseText);

            var meta = JObject.Parse(s.ToString()).SelectToken("meta");
            var csrf = meta.SelectToken("csrf");
            var value = csrf.Value<string>("value");

            if (_token == null)
                _token = value;

            var results = JObject.Parse(s.ToString()).SelectToken("data") as JArray;
            foreach (var result in results)
            {
                
                var attributeEntry = result.SelectToken("attributes");
                var id = attributeEntry.Value<int>("product.id");
                var label = attributeEntry.Value<string>("product.label");
                var type = attributeEntry.Value<string>("product.type");
                prekes.Add(new Preke(id, label, type, 0.0));
            }
            var included = JObject.Parse(s.ToString()).SelectToken("included") as JArray;
            int j = 0;
            foreach (var result in included)
            {

                var attributeEntry2 = result.SelectToken("attributes");
                var price = attributeEntry2.Value<double>("price.value");
                prekes[j].Price = price;
                j++;
            }
            responseH.Close();

            return prekes;
        }

        public List<Preke> SearchName(string name)
        {
            List<Preke> prekesSearch = new List<Preke>();
            string URL = WebUtility.UrlEncode("filter[~=][product.label]");
            HttpWebRequest requestSearch = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:8000/jsonapi/product?" + URL + "=" + name + "&include=price");
            requestSearch.Method = "GET";
            HttpWebResponse responseSearch = (HttpWebResponse)requestSearch.GetResponse();

            var encoding = ASCIIEncoding.ASCII;
            var responseSearchText = "";
            using (var reader = new System.IO.StreamReader(responseSearch.GetResponseStream(), encoding))
            {
                responseSearchText = reader.ReadToEnd();
            }

            var sSearch = JsonConvert.DeserializeObject(responseSearchText);

            Console.WriteLine(sSearch);

            var results = JObject.Parse(sSearch.ToString()).SelectToken("data") as JArray;
            foreach (var result in results)
            {
                var attributeEntry = result.SelectToken("attributes");
                var id = attributeEntry.Value<int>("product.id");
                var label = attributeEntry.Value<string>("product.label");
                var type = attributeEntry.Value<string>("product.type");
                prekesSearch.Add(new Preke(id, label, type, 0.0));
            }
            var included = JObject.Parse(sSearch.ToString()).SelectToken("included") as JArray;
            int j = 0;
            foreach (var result in included)
            {

                var attributeEntry2 = result.SelectToken("attributes");
                var price = attributeEntry2.Value<double>("price.value");
                prekesSearch[j].Price = price;
                j++;
            }
            responseSearch.Close();

            return prekesSearch;
        }

        public void ShowProducts(string category)
        {
            List<Preke> prekes = AllProducts();
            if (listView1.Items.Count != 0)
            {
                listView1.Items.Clear();
            }
            for (int i = 0; i < prekes.Count; i++)
            {
                if (prekes[i].Type == category)
                {
                    listView1.Items.Add(new ListViewItem(new string[] { prekes[i].Id.ToString(), prekes[i].Label, prekes[i].Price.ToString(), prekes[i].Type }));
                }
                
            }
        }

        public void ShowProductsByPrice(double min, double max)
        {
            List<Preke> prekes = AllProducts();
            if (listView1.Items.Count != 0)
            {
                listView1.Items.Clear();
            }
            for (int i = 0; i < prekes.Count; i++)
            {
                if (comboBox1.Text == "Visos prekės")
                {
                    if (prekes[i].Price >= min && prekes[i].Price <= max)
                        listView1.Items.Add(new ListViewItem(new string[] { prekes[i].Id.ToString(), prekes[i].Label, prekes[i].Price.ToString(), prekes[i].Type }));
                }
                else
                    if (prekes[i].Price >= min && prekes[i].Price <= max && prekes[i].Type == comboBox1.SelectedItem.ToString())
                    listView1.Items.Add(new ListViewItem(new string[] { prekes[i].Id.ToString(), prekes[i].Label, prekes[i].Price.ToString(), prekes[i].Type }));
            }
        }

        public void ShowProducts()
        {
            List<Preke> prekes = AllProducts();
            if (listView1.Items.Count != 0)
            {
                listView1.Items.Clear();
            }
            for (int i = 0; i < prekes.Count; i++)
                listView1.Items.Add(new ListViewItem(new string[] { prekes[i].Id.ToString(), prekes[i].Label, prekes[i].Price.ToString(), prekes[i].Type }));
        }


        private void SearchButton_Click(object sender, EventArgs e)
        {
            List<Preke> prekes = SearchName(SearchBar.Text);
            if (listView1.Items.Count != 0)
            {
                listView1.Items.Clear();
            }
            for (int i = 0; i < prekes.Count; i++)
            {
                listView1.Items.Add(new ListViewItem(new string[] { prekes[i].Id.ToString(), prekes[i].Label, prekes[i].Price.ToString(), prekes[i].Type }));

            }
        }


        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            ProductDetail product = new ProductDetail(listView1.SelectedItems[0].SubItems[0].Text, listView1.SelectedItems[0].SubItems[1].Text,
                                                        listView1.SelectedItems[0].SubItems[2].Text, _token, _cookie);
            product.Show();

        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Visos prekės")
            {
                ShowProducts();
            }
            else 
                ShowProducts(comboBox1.SelectedItem.ToString());
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listView1.Sort();
        }

        private void priceMin_ValueChanged(object sender, EventArgs e)
        {
            ShowProductsByPrice(Decimal.ToDouble(priceMin.Value), Decimal.ToDouble(priceMax.Value));
        }

        private void priceMax_ValueChanged_1(object sender, EventArgs e)
        {
            List<Preke> prekiuList = AllProducts();
            int max = 0;
            for (int i = 0; i < prekiuList.Count; i++)
            {
                if ((int)prekiuList[i].Price > max)
                {
                    max = (int)prekiuList[i].Price;
                }
            }
            priceMax.Value = max;
            ShowProductsByPrice(Decimal.ToDouble(priceMin.Value), Decimal.ToDouble(priceMax.Value));
        }

        private void Basket_Button_Click(object sender, EventArgs e)
        {
            Basket basket = new Basket(_token, _cookie);
            basket.Show();
        }

        private void Support_Button_Click(object sender, EventArgs e)
        {
            support_label.Text = "Parašykite paštu admin@projektas.com";
        }


    }
}
