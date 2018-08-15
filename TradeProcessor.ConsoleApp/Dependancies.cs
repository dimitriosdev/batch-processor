using System.IO;
using TradeProcessor.Concretes;
using TradeProcessor.Contracts;

namespace TradeProcessor.ConsoleApp
{
    public static class Dependancies
    {

        private static Stream stream = new FileStream("C:\\csharpfile.txt", FileMode.Create);

        private static ITradeDataProvider tradeDataProvider = new StreamTradeDataProvider(stream);
        public static ITradeDataProvider TradeDataProvider { get { return tradeDataProvider; } }

        private static ITradeParser tradeParser = new SimpleTradeParser();
        public static ITradeParser TradeParser { get { return tradeParser; } }

        private static ITradeStorage tradeStorage = new AdoNetTradeStorage();

        public static ITradeStorage TradeStorage { get { return tradeStorage; } }
        
    }
}
