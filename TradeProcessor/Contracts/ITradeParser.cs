using System.Collections.Generic;

namespace TradeProcessor.Contracts
{
    public interface ITradeParser
    {
        IEnumerable<TradeRecord> Parse(IEnumerable<string> tradeData);
    }
}
