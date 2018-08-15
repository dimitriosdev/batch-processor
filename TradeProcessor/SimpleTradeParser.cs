using System;
using System.Collections.Generic;
using TradeProcessor.Contracts;

namespace TradeProcessor
{
    public class SimpleTradeParser : ITradeParser
    {
        public IEnumerable<TradeRecord> Parse(IEnumerable<string> tradeData)
        {
            var trades = new List<TradeRecord>();
            var lineCount = 1;
            foreach (var line in tradeData)
            {
                var fields = line.Split(new char[] { ',' });

                if (!ValidateTradeData(fields, lineCount))
                {
                    continue;
                }

                var trade = MapTradeDataToTradeRecord(fields);
                trades.Add(trade);
                lineCount++;
            }
            return trades;
        }

        private TradeRecord MapTradeDataToTradeRecord(string[] fields)
        {
            var sourceCurrencyCode = fields[0].Substring(0, 3);
            var destinationCurrencyCode = fields[0].Substring(3, 3);
            var tradeAmount = int.Parse(fields[1]);
            var tradePrice = decimal.Parse(fields[2]);
            var tradeRecord = new TradeRecord
            {
                SourceCurrency = sourceCurrencyCode,
                DestinationCurrency = destinationCurrencyCode,
                Lots = tradeAmount / LotSize,
                Price = tradePrice
            };
            return tradeRecord;
        }

        private bool ValidateTradeData(string[] fields, int currentLine)
        {
            if (fields.Length != 3)
            {
                LogMessage("WARN: Line {0} malformed. Only {1} field(s) found.", currentLine,
                fields.Length);
                return false;
            }
            if (fields[0].Length != 6)
            {
                LogMessage("WARN: Trade currencies on line {0} malformed: '{1}'", currentLine,
                fields[0]);
                return false;
            }
            int tradeAmount;
            if (!int.TryParse(fields[1], out tradeAmount))
            {
                LogMessage("WARN: Trade amount on line {0} not a valid integer: '{1}'",
                currentLine, fields[1]);
                return false;
            }
            decimal tradePrice;
            if (!decimal.TryParse(fields[2], out tradePrice))
            {
                LogMessage("WARN: Trade price on line {0} not a valid decimal: '{1}'",
                currentLine, fields[2]);
                return false;
            }
            return true;

        }

        private void LogMessage(string message, params object[] args)
        {
            Console.WriteLine(message, args);
        }

        private static float LotSize = 100000f;
    }
}
