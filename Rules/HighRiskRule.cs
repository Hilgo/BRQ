using BRQ.Enums;
using BRQ.Interfaces;

namespace BRQ.Rules
{
    public class HighRiskRule : ITradeCategoryRule
    {
        public TradeCategory CategoryName => TradeCategory.HIGHRISK;
        public bool IsMatch(ITrade trade) => trade.Value >= 1000000 && trade.ClientSector == "Private";
    }
}
