﻿namespace TradeProcessor
{
    internal class TradeRecord
    {
        public string DestinationCurrency { get; set; }
        public float Lots { get; set; }
        public decimal Price { get; set; }
        public string SourceCurrency { get; set; }
    }
}