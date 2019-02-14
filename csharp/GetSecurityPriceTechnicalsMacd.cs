using System;
using System.Collections.Generic;
using System.Diagnostics;
using Intrinio.SDK.Api;
using Intrinio.SDK.Client;
using Intrinio.SDK.Model;

namespace Example
{
  public class GetSecurityPriceTechnicalsMacdExample
  {
    public static void Main()
    {
      Configuration.Default.AddApiKey("api_key", "YOUR_API_KEY");

      var securityApi = new SecurityApi();
      var identifier = "AAPL";  // string | A Security identifier (Ticker, FIGI, ISIN, CUSIP, Intrinio ID)
      var fastPeriod = 12;  // int? | The number of observations, per period, to calculate the fast moving Exponential Moving Average for Moving Average Convergence Divergence (optional)  (default to 12)
      var slowPeriod = 26;  // int? | The number of observations, per period, to calculate the slow moving Exponential Moving Average for Moving Average Convergence Divergence (optional)  (default to 26)
      var signalPeriod = 9;  // int? | The number of observations, per period, to calculate the signal line for Moving Average Convergence Divergence (optional)  (default to 9)
      String priceKey = null;  // string | The Stock Price field to use when calculating Moving Average Convergence Divergence (optional)  (default to close)
      String startDate = null;  // string | Return technical indicator values on or after the date (optional) 
      String startTime = null;  // string | Return prices at or after this time (24-hour) (optional) 
      String endDate = null;  // string | Return technical indicator values on or before the date (optional) 
      String endTime = null;  // string | Return prices at or before this time (24-hour) (optional) 
      String timezone = null;  // string | Returns technical indicators in this timezone (optional)  (default to UTC)
      var pageSize = 100;  // int? | The number of results to return (optional)  (default to 100)
      String nextPage = null;  // string | gets the next page of data from an already-executed API call (optional) 

      try
      {
        ApiResponseSecurityMovingAverageConvergenceDivergence result = securityApi.GetSecurityPriceTechnicalsMacd(identifier, fastPeriod, slowPeriod, signalPeriod, priceKey, startDate, startTime, endDate, endTime, timezone, pageSize, nextPage);
        TechnicalIndicator indicator = result.Indicator;
        SecuritySummary security = result.Security;
        List<MovingAverageConvergenceDivergenceTechnicalValue> technicals = result.Technicals;

        Console.WriteLine("Technicals for " + security.Ticker);
        Console.WriteLine(technicals.Count + " values for " + indicator.Name + " returned!");
        Console.WriteLine();

        technicals.ForEach(delegate (MovingAverageConvergenceDivergenceTechnicalValue technical)
        {
          Console.WriteLine("DateTime:       " + technical.DateTime);
          Console.WriteLine("MACD Histogram: " + technical.MacdHistogram);
          Console.WriteLine("MACD Line:      " + technical.MacdLine);
          Console.WriteLine("Signal Line:    " + technical.SignalLine);
          Console.WriteLine("---------------------------------------------------");
        });
      }
      catch (Exception e)
      {
        Debug.Print("Exception when calling SecurityApi.GetSecurityPriceTechnicalsMacd: " + e.Message);
      }
    }
  }
}
