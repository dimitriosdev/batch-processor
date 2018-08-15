using System.Collections.Generic;

namespace TradeProcessor.Contracts
{
    public interface ITradeDataProvider
    {
        IEnumerable<string> GetTradeData();
    }
}
