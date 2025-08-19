using HousePriceModelAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;

namespace HousePriceModelAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HousePriceController : ControllerBase
    {
        private static readonly Lazy<PredictionEngine<HouseData, HousePrediction>> _predictionEngine
    = new(() =>
    {
        var mlContext = new MLContext();
        var modelPath = Path.Combine(Directory.GetCurrentDirectory(), "HousePriceModel.zip");

        if (!System.IO.File.Exists(modelPath))
        {
            throw new FileNotFoundException("Model file not found: " + modelPath);
        }

        System.Diagnostics.Debug.WriteLine("Loading model from: " + modelPath);
        var model = mlContext.Model.Load(modelPath, out _);
        return mlContext.Model.CreatePredictionEngine<HouseData, HousePrediction>(model);
    });

        [HttpPost]
        public IActionResult Predict([FromBody] HouseData input)
        {
            var prediction = _predictionEngine.Value.Predict(input);
            return Ok(new { input.Size, input.Bedrooms, input.Bathrooms, prediction.PredictedPrice });
        }
        [HttpGet("test")]
        public IActionResult Test()
        {
            var input = new HouseData
            {
                Size = 1800,
                Bedrooms = 3,
                Bathrooms = 2
            };

            var prediction = _predictionEngine.Value.Predict(input);
            return Ok(new
            {
                input.Size,
                input.Bedrooms,
                input.Bathrooms,
                prediction.PredictedPrice
            });
        }
      

    }
}
