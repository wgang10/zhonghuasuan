using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
using System.Collections;
using System.Text.RegularExpressions;
namespace zhonghuasuan
{
    public partial class Form1 : Form
    {
        private static Encoding PageEncoding = Encoding.GetEncoding("gb2312");
        private string zhsurl = "http://list.zhonghuasuan.com/new/price-asc/";
        private const string CategoryPageXPath = "//html[1]/body[1]/div";
        private const string CategoryPageNumXPath = "//span[2]";
        private const string CategoryListXPath = "//html[1]/body[1]/div";
        private const string CategoryNameXPath = "h2[1]";
        private const string CategoryUrlXPath = "div[1]/a[1]";
        private const string CategoryImgUrlXPath = "div[1]/a[1]/img[1]";
        private const string CategoryPrice1XPath = "div[1]/p[1]/span[1]/em[1]";
        private const string CategoryPrice2XPath = "div[1]/p[2]/span[1]/em[1]";
        private const string CategoryAllXPath = "div[1]/p[1]span[2]/em[2]";
        private const string CategoryLeftXPath = "div[1]p[1]/span[2]/em[1]";
        List<Category> list;
        private int pageNum = 0;
        public Form1()
        {
            InitializeComponent();
            string zhsurl = "";
        }

        private void loaddata()
        {
            listBox1.Items.Clear();
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            string html = HttpGet(zhsurl);
            //string html = GetHttpData(zhsurl);
            document.LoadHtml(html);
            //document.Load("1.html", PageEncoding);
            HtmlNode rootNode = document.DocumentNode;
            HtmlNodeCollection spanNodeList = rootNode.SelectNodes("//span[@class='paging-total']");
            this.Text = spanNodeList[1].InnerText;
            pageNum = Int32.Parse(this.Text.Replace("共", "").Replace("页", "").Trim());
            HtmlNodeCollection DivNodeList = rootNode.SelectNodes("//div[@class='goodsList']");
            //HtmlNodeCollection pageNodeList=rootNode.SelectNodes(CategoryPageXPath);
            //HtmlNode pageNode = HtmlNode.CreateNode(pageNodeList[1].OuterHtml);
            ;
            HtmlNode temp = null;
            Category category = null;
            list = new List<Category>();
            //ShowMessage(pageNode.InnerText);
            //foreach (HtmlNode DivNode in DivNodeList)
            //{
            //    if (DivNode.Attributes.Contains("class") && DivNode.Attributes["class"].Value == "main w1000")
            //    {
            //HtmlNodeCollection categoryNodeList = DivNode.SelectNodes("div[1]/ul[1]/li");
            HtmlNodeCollection categoryNodeList = DivNodeList[0].SelectNodes("ul[1]/li");

            CategoryPicture cp;
            foreach (HtmlNode categoryNode in categoryNodeList)
            {
                category = new Category();
                category.Name = categoryNode.SelectSingleNode(CategoryNameXPath).InnerText;
                category.Name = category.Name.Trim().Replace("\r\n", "").Replace("【包邮】", "");
                category.url = categoryNode.SelectSingleNode(CategoryUrlXPath).Attributes["href"].Value;
                category.imgurl = categoryNode.SelectSingleNode(CategoryImgUrlXPath).Attributes["src"].Value;
                category.price1 = categoryNode.SelectSingleNode(CategoryPrice1XPath).InnerText;
                category.price2 = categoryNode.SelectSingleNode(CategoryPrice2XPath).InnerText;
                category.state = categoryNode.SelectSingleNode("div[1]/p[2]/a[1]").InnerText;
                //category.all = categoryNode.SelectSingleNode(CategoryAllXPath).InnerText;
                //category.left = categoryNode.SelectSingleNode(CategoryLeftXPath).InnerText; 
                //ShowMessage(category.all+"-"+category.left);
                cp = new CategoryPicture();
                cp.Title = category.Name;
                cp.Url = category.url;
                cp.Pic = category.imgurl;
                cp.Price = category.price1 + "-" + category.price2;
                cp.State = category.state;
                flowLayoutPanel1.Controls.Add(cp);
            }
            for (int i = 2; i <= pageNum; i++)
            {
                html = HttpGet(string.Format("http://list.zhonghuasuan.com/new/price-asc/{0}.html",i.ToString()));
                document.LoadHtml(html);
                rootNode = document.DocumentNode;
                DivNodeList = rootNode.SelectNodes("//div[@class='goodsList']");
                categoryNodeList = DivNodeList[0].SelectNodes("ul[1]/li");
                if (categoryNodeList == null) return;
                foreach (HtmlNode categoryNode in categoryNodeList)
                {
                    category = new Category();
                    category.Name = categoryNode.SelectSingleNode(CategoryNameXPath).InnerText;
                    category.Name = category.Name.Trim().Replace("\r\n", "").Replace("【包邮】", "");
                    category.url = categoryNode.SelectSingleNode(CategoryUrlXPath).Attributes["href"].Value;
                    category.imgurl = categoryNode.SelectSingleNode(CategoryImgUrlXPath).Attributes["src"].Value;
                    category.price1 = categoryNode.SelectSingleNode(CategoryPrice1XPath).InnerText;
                    category.price2 = categoryNode.SelectSingleNode(CategoryPrice2XPath).InnerText;
                    category.state = categoryNode.SelectSingleNode("div[1]/p[2]/a[1]").InnerText;
                    //category.all = categoryNode.SelectSingleNode(CategoryAllXPath).InnerText;
                    //category.left = categoryNode.SelectSingleNode(CategoryLeftXPath).InnerText; 
                    //ShowMessage(category.all+"-"+category.left);
                    cp = new CategoryPicture();
                    cp.Title = category.Name;
                    cp.Url = category.url;
                    cp.Pic = category.imgurl;
                    cp.Price = category.price1 + "-" + category.price2;
                    cp.State = category.state;
                    flowLayoutPanel1.Controls.Add(cp);
                }
            }
        }

        public string GetHttpData(string Url)
        {
            string sException = null;
            string sRslt = null;
            WebResponse oWebRps = null;
            WebRequest oWebRqst = WebRequest.Create(Url);
            oWebRqst.Timeout = 10000;
            try
            {
                oWebRps = oWebRqst.GetResponse();
            }
            catch (WebException e)
            {
                sException = e.Message.ToString();
                ShowMessage(sException);
            }
            catch (Exception e)
            {
                sException = e.ToString();
                ShowMessage(sException);
            }
            finally
            {
                if (oWebRps != null)
                {
                    StreamReader oStreamRd = new StreamReader(oWebRps.GetResponseStream(), Encoding.Default);//Encoding.GetEncoding("gb2312")   Encoding.GetEncoding("GBK")
                    sRslt = oStreamRd.ReadToEnd();
                    oStreamRd.Close();
                }                
                oWebRps.Close();
            }
            return sRslt;
        }

        public string HttpGet(string url)
        {
            string responsestr = "";
            HttpWebRequest req = HttpWebRequest.Create(url) as HttpWebRequest;
            req.Accept = "*/*";
            req.Method = "GET";
            req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.1 (KHTML, like Gecko) Chrome/21.0.1180.89 Safari/537.1";
            using (HttpWebResponse response = req.GetResponse() as HttpWebResponse)
            {
                Stream stream;
                if (response.ContentEncoding.ToLower().Contains("gzip"))
                {
                    stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress);
                }
                else if (response.ContentEncoding.ToLower().Contains("deflate"))
                {
                    stream = new DeflateStream(response.GetResponseStream(), CompressionMode.Decompress);
                }
                else
                {
                    stream = response.GetResponseStream();
                }
                using (StreamReader reader = new StreamReader(stream, GetEncoding(response.CharacterSet)))
                {
                    responsestr = reader.ReadToEnd();
                    stream.Dispose();
                }
            }
            return responsestr;
        }

        public Encoding GetEncoding(string VharacterSet)
        {
            switch (VharacterSet)
            {
                case "gb2312": return Encoding.GetEncoding("gb2312");
                case "utf-8": return Encoding.UTF8;
                default: return Encoding.Default;
            }
        }

        private void ShowMessage(string msg)
        {
            listBox1.Items.Add(msg);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loaddata();
        }
       
    }
}
