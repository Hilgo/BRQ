using BRQ.Enums;
using BRQ.Interfaces;
using BRQ.Models;

namespace BRQ.Rules
{
    public class TradeCategoryClassifier
    {
        private readonly List<ITradeCategoryRule> _rules = new List<ITradeCategoryRule>();

        public TradeCategoryClassifier()
        {
            // Initialize with default rules
            _rules.Add(new LowRiskRule());
            _rules.Add(new MediumRiskRule());
            _rules.Add(new HighRiskRule());
        }

        // Add a new rule dynamically
        public void AddRule(ITradeCategoryRule rule) => _rules.Add(rule);

        public List<string> CategorizeTrades(List<ITrade> portfolio)
        {
            var tradeCategories = new List<string>();

            foreach (var trade in portfolio)
            {
                var category = _rules.FirstOrDefault(rule => rule.IsMatch(trade))?.CategoryName;

                string categoryName = "UNKNOWN"; // Default to "UNKNOWN"
                if (category.HasValue)
                    categoryName = Enum.GetName(typeof(TradeCategory), category.Value) ?? categoryName;

                tradeCategories.Add(categoryName);
            }

            return tradeCategories;
        }
    }
}
