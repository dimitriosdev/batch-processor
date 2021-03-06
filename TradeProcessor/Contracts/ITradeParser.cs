﻿using System.Collections.Generic;
using TradeProcessor.Models;

namespace TradeProcessor.Contracts
{
    public interface ITradeParser
    {
        IEnumerable<TradeRecord> Parse(IEnumerable<string> tradeData);
    }
}
