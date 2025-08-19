using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousePriceModel.Models
{
    public class HouseData
    {
        [LoadColumn(0)] public float Size { get; set; }
        [LoadColumn(1)] public float Bedrooms { get; set; }
        [LoadColumn(2)] public float Bathrooms { get; set; }
        [LoadColumn(3), ColumnName("Label")]
        public float Price { get; set; }  // This is what we're predicting
    }

    public class HousePrediction
    {
        [ColumnName("Score")]
        public float PredictedPrice { get; set; }
    }
}
