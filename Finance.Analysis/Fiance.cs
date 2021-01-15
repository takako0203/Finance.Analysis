using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Finance.Analysis
{
    public class Fiance
    {
        public static string ID { get; set; }
        public static string COMPANY { get; set; }
        public static double DIVIDEND { get; set; }
        public static double STOCKDIVIDEND { get; set; }
        public static double STOCKPRICE { get; set; }
        public static int DECADEDIVIDENDFEQUENCE { get; set; }
        public static double DIVIDEND_YIELD { get; set; }
        public static double LAST_EPS { get; set; }

        public static string GetFilter()
        {
            return @" DecadeDividendFequence > 5 
                      AND StockPrice > 0 
                      AND StockDividend > 0
                      AND Dividend > 0.1
                      AND Dividend_Yield > 0.1
                      ";
        }

        public static string GetSort()
        {
            return "Dividend_Yield desc";
        }

        public static string GetData()
        {
            return @"D:\Finance.Analysis\Finance.Analysis\Data\stockanalysis.html";
        }

        public static string GetXPath
        {
            // 以 \" 表示雙引號
            get { return string.Concat("//*[@id=", string.Format("\"{0}\"", "example"), "]", "/tbody"); }            
        }
    }
}