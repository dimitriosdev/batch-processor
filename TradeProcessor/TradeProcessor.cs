using TradeProcessor.Contracts;

namespace TradeProcessor
{
    /// <summary>
    ///1. Reads every line from a Stream parameter, storing each line in a list of strings.
    ///2. Parses out individual fields from each line and stores them in a more structured list of Trade‑Record instances.
    ///3. The parsing includes some validation and some logging to the console.
    ///4. Each TradeRecord is enumerated, and a stored procedure is called to insert the trades into a database.
    /// </summary>
    public class TradeProcessor
    {
        public TradeProcessor(ITradeDataProvider tradeDataProvider, ITradeParser tradeParser, ITradeStorage tradeStorage)
        {
            this.tradeDataProvider = tradeDataProvider;
            this.tradeParser = tradeParser;
            this.tradeStorage = tradeStorage;
        }
        
        public void ProcessTrades()
        {
            var lines = tradeDataProvider.GetTradeData();
            var trades = tradeParser.Parse(lines);
            tradeStorage.Persist(trades);

        }

        private readonly ITradeDataProvider tradeDataProvider;
        private readonly ITradeParser tradeParser;
        private readonly ITradeStorage tradeStorage;        
    }
}
