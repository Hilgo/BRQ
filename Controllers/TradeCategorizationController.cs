using BRQ.Enums;
using BRQ.Interfaces;
using BRQ.Models;
using BRQ.Rules;
using Microsoft.AspNetCore.Mvc;

namespace BRQ.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TradeCategorizationController : ControllerBase
    {

        private readonly TradeCategoryClassifier _classifier;

        // Inject the TradeCategoryClassifier (constructor injection)
        public TradeCategorizationController(TradeCategoryClassifier classifier)
        {
            _classifier = classifier;
        }

        [HttpPost("categorize")] // Example POST endpoint
        public IActionResult CategorizeTrades([FromBody] List<Trade> trades)
        {
            if (trades == null || trades.Count == 0)
            {
                return BadRequest("Please provide a valid list of trades.");
            }

            // Use the classifier to get the categories
            List<string> categories = _classifier.CategorizeTrades(trades);

            // Return the results (you could use different return types)
            return Ok(categories);
        }
    }
}
