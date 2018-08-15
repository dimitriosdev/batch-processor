using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TradeProcessor.Contracts;

namespace TradeProcessor
{
    public class AdoNetTradeStorage : ITradeStorage
    {
        public void Persist(IEnumerable<TradeRecord> trades)
        {
            using (var connection = new SqlConnection("Data Source = (local); Initial Catalog = TradeDatabase; Integrated Security = True"))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    foreach (var trade in trades)
                    {
                        var command = connection.CreateCommand();
                        command.Transaction = transaction;
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "dbo.insert_trade";
                        command.Parameters.AddWithValue("@sourceCurrency", trade.
                        SourceCurrency);
                        command.Parameters.AddWithValue("@destinationCurrency", trade.
                        DestinationCurrency);
                        command.Parameters.AddWithValue("@lots", trade.Lots);
                        command.Parameters.AddWithValue("@price", trade.Price);
                        command.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
                connection.Close();
            }
            Console.WriteLine("INFO: {0} trades processed", trades.Count());
        }
    }
}
