using TradeProcessor.Contracts;

namespace TradeProcessor.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ITradeDataProvider dataProvider = Dependancies.TradeDataProvider;
            ITradeParser tradeParser = Dependancies.TradeParser;
            ITradeStorage tradeStorage = Dependancies.TradeStorage;

            var batchProcessor = new TradeProcessor(dataProvider, tradeParser, tradeStorage);
            batchProcessor.ProcessTrades();
        }
        
    }
}
