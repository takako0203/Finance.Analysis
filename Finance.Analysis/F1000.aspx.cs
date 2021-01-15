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
    public partial class F1000 : Page
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
            using (MemoryStream ms = new MemoryStream(client.DownloadData(Fiance.GetData())))
            {
                // 使用預設編碼讀入 HTML 
                HtmlDocument doc = new HtmlDocument();
                doc.Load(ms, Encoding.UTF8);

                // 裝載第一層查詢結果 
                HtmlDocument docStockContext = new HtmlDocument();
                docStockContext.LoadHtml(doc.DocumentNode.SelectSingleNode(Fiance.GetXPath).InnerHtml);

                int count = CountData(docStockContext.DocumentNode.InnerHtml,"<tr>");
                string pattern = string.Empty;
                string[] stockValues;

                DataTable dt = GetFinaceStructure();
                DataRow dr;

                for (int i=1; i< count;i++)
                {
                    pattern = string.Concat("./tr[", i, "]");

                    // 取得個股數值 
                    stockValues = docStockContext.DocumentNode
                        .SelectSingleNode(pattern)
                        .InnerText
                        .Trim().Split('\n');

                    stockValues = (from e in stockValues
                                   select e.Trim()).ToArray();

                    dr = dt.NewRow();

                    Fiance.ID= stockValues[0];
                    Fiance.COMPANY= stockValues[1];
                    Fiance.DIVIDEND= Convert.ToDouble(stockValues[2]);
                    Fiance.STOCKDIVIDEND= Convert.ToDouble(stockValues[4].ToString());
                    Fiance.STOCKPRICE= Convert.ToDouble(stockValues[6]);
                    Fiance.DECADEDIVIDENDFEQUENCE= Convert.ToInt32(string.IsNullOrEmpty(stockValues[16].ToString()) ? "0" : stockValues[16].ToString());
                    Fiance.DIVIDEND_YIELD= Convert.ToDouble(stockValues[9].Remove(stockValues[9].IndexOf('%'),1));
                    Fiance.LAST_EPS = Convert.ToDouble(stockValues[21]);

                    dr["ID"] = Fiance.ID;
                    dr["Company"] = Fiance.COMPANY;
                    dr["Dividend"] = Fiance.DIVIDEND;
                    dr["StockDividend"] = Fiance.STOCKDIVIDEND;
                    dr["StockPrice"] = Fiance.STOCKPRICE;
                    dr["DecadeDividendFequence"] = Fiance.DECADEDIVIDENDFEQUENCE;
                    dr["Dividend_Yield"] = Fiance.DIVIDEND_YIELD;
                    dr["LAST_EPS"] = Fiance.LAST_EPS;

                    dt.Rows.Add(dr);     
                }

                DataView dv = dt.AsDataView();
                dv.RowFilter = Fiance.GetFilter();
                dv.Sort = Fiance.GetSort();
                gv_Show.DataSource = dv.ToTable();
                gv_Show.DataBind();
            }
        }

        /// <summary>
        /// 取得DataTable結構
        /// </summary>
        /// <returns></returns>
        private DataTable GetFinaceStructure()
        {
            DataTable dt = new DataTable("dtFinace");

            dt.Columns.Add("ID", typeof(string));//代號
            dt.Columns.Add("Company", typeof(string));//公司
            dt.Columns.Add("Dividend", typeof(double));//股息
            dt.Columns.Add("StockDividend", typeof(double));           
            dt.Columns.Add("StockPrice", typeof(double));//股價
            dt.Columns.Add("DecadeDividendFequence", typeof(int));//配息次數
            dt.Columns.Add("Dividend_Yield", typeof(double));//殖利率
            dt.Columns.Add("LAST_EPS", typeof(double));//去年EPS
            return dt;
        }     

        /// <summary>
        /// 算出共幾筆資料
        /// </summary>
        /// <returns></returns>
        private int CountData(string parameter,string pattern)
        {
            string strReplace = parameter.Replace(pattern, string.Empty);            
            return ((parameter.Length - strReplace.Length) / pattern.Length);
        }

        private string GetAddress
        {
            get { return "https://stock.wespai.com/rate109"; }
        }     
    }
}