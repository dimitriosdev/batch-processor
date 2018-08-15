using System.Collections.Generic;
using TradeProcessor.Models;

namespace TradeProcessor.Contracts
{
    public interface ITradeStorage
    {
        void Persist(IEnumerable<TradeRecord> tradeData);
    }
}
