using HousePriceModel.Models;
using Microsoft.ML;

var mlContext = new MLContext();

// Load data
var data = mlContext.Data.LoadFromTextFile<HouseData>("house-data.csv", hasHeader: true, separatorChar: ',');

// Build pipeline
var pipeline = mlContext.Transforms.Concatenate("Features", "Size", "Bedrooms", "Bathrooms")
    .Append(mlContext.Regression.Trainers.Sdca());

// Train
var model = pipeline.Fit(data);

// Save
mlContext.Model.Save(model, data.Schema, "HousePriceModel.zip");

Console.WriteLine("Model trained and saved.");

// Predict (optional test)
var predictionEngine = mlContext.Model.CreatePredictionEngine<HouseData, HousePrediction>(model);

var testSample = new HouseData { Size = 1800, Bedrooms = 3, Bathrooms = 2 };
var prediction = predictionEngine.Predict(testSample);

Console.WriteLine($"Predicted Price: {prediction.PredictedPrice}");
