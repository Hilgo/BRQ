using BRQ.Enums;
using BRQ.Interfaces;

namespace BRQ.Rules
{
    public class LowRiskRule: ITradeCategoryRule
    {
        public TradeCategory CategoryName => TradeCategory.LOWRISK;

        public bool IsMatch(ITrade trade) => trade.Value < 1000000 && trade.ClientSector == "Public";
    }
}
