using BRQ.Enums;
using BRQ.Interfaces;

namespace BRQ.Rules
{
    public class MediumRiskRule : ITradeCategoryRule
    {
        public TradeCategory CategoryName => TradeCategory.MEDIUMRISK;
        public bool IsMatch(ITrade trade) => trade.Value >= 1000000 && trade.ClientSector == "Public";
    }
}
