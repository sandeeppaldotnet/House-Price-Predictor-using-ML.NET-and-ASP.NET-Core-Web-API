using Microsoft.ML.Data;

namespace HousePriceModelAPI.Models
{
    public class HouseData
    {
        public float Size { get; set; }
        public float Bedrooms { get; set; }
        public float Bathrooms { get; set; }
        //public float Price { get; set; }
    }

    public class HousePrediction
    {
        [ColumnName("Score")]
        public float PredictedPrice { get; set; }
    }
}
