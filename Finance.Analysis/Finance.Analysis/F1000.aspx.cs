using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Text;
using System.Data;

using HtmlAgilityPack;


namespace Finance.Analysis
{
    public partial class F1000 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Show();
            }
        }

        private void Show()
        {
            string _content = string.Empty;

            using (WebClient client = new WebClient())
            using (MemoryStream ms = new MemoryStream(client.DownloadData(GetAddress)))
            {
                // 使用預設編碼讀入 HTML 
                HtmlDocument doc = new HtmlDocument();
                doc.Load(ms, Encoding.UTF8);

                // 裝載第一層查詢結果 
                HtmlDocument docStockContext = new HtmlDocument();
                docStockContext.LoadHtml(doc.DocumentNode.SelectSingleNode(GetXPath).InnerHtml);                               

                // 取得個股數值 
                string[] values = docStockContext.DocumentNode.SelectSingleNode("./tr[1]")
                    .InnerText.Trim()
                    .Split('\n');              

                DataTable dt = GetDT;              
                DataRow dr = dt.NewRow();
                dr["ID"] = values[0];
                dr["Company"] = values[1];
                dr["Price"] = values[6].ToString();
                dr["Allotment"] = values[2].ToString();
                dr["Dividend"] = values[4].ToString();
                dt.Rows.Add(dr);

                //rule
                DataRow[] rows = dt.Select("Price <= 30 AND Allotment > 0 AND Dividend > 0 ");

                dt.Rows.Add(rows);
                gv_Show.DataSource = dt;
                gv_Show.DataBind();
                //foreach (var item in values)
                //{                  
                //    //txt_Show.Text += item + Environment.NewLine;
                //    GetDT.Rows.Add(values.ToArray());
                //}
            }
        }

        private DataTable GetDT
        {
            get
            {
                DataTable dt = new DataTable("dtFinace");
                dt.Columns.Add("ID", typeof(string));
                dt.Columns.Add("Company", typeof(string));
                dt.Columns.Add("Price", typeof(float));
                dt.Columns.Add("Allotment", typeof(float));
                dt.Columns.Add("Dividend", typeof(float));
                return dt;
            }
        }

        private string GetAddress
        {
            get { return @"D:\Finance.Analysis\Finance.Analysis\Data\stock.html"; }
            //get { return "https://stock.wespai.com/rate109"; }
        }

        private string GetXPath
        {
            // 以 \" 表示雙引號
            get { return string.Concat("//*[@id=", string.Format("\"{0}\"", "example"), "]", "/tbody"); }
        }
    }
}