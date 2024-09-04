using BRQ.Enums;

namespace BRQ.Interfaces
{
    public interface ITradeCategoryRule
    {
        TradeCategory CategoryName { get; }
        bool IsMatch(ITrade trade);
    }
}
