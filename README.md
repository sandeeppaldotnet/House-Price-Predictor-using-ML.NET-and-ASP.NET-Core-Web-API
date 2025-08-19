# House-Price-Predictor-using-ML.NET-and-ASP.NET-Core-Web-API
# 🏠 House Price Prediction API (ML.NET + ASP.NET Core)

This project demonstrates how to use **ML.NET** to build a machine learning model that predicts house prices based on input features like `size`, `bedrooms`, and `bathrooms`. The trained model is then integrated into an **ASP.NET Core Web API** to serve predictions.

---

## 📂 Project Structure

HousePricePredictor/
│
├── HousePriceModel/ # Console app (training)
│ └── Program.cs # Trains the model and saves it
│
├── HousePriceModelAPI/ # ASP.NET Core Web API
│ ├── Controllers/
│ │ └── HousePriceController.cs
│ ├── Models/
│ │ ├── HouseData.cs
│ │ └── HousePrediction.cs
│ ├── HousePriceModel.zip # Trained ML model (copied from console app)
│ └── Program.cs
│
├── README.md

yaml
Copy code

---

## 🚀 How It Works

1. Train a regression model using **ML.NET**.
2. Save the model as `HousePriceModel.zip`.
3. Load the model in an ASP.NET Core Web API.
4. Accept house feature input and return predicted price.

---

## 🧠 Model Input Features

- `Size` (float) - Total square footage
- `Bedrooms` (float) - Number of bedrooms
- `Bathrooms` (float) - Number of bathrooms

---

## 🧪 Step-by-Step Setup

### 🔹 Step 1: Train the Model (Console App)

1. Open `HousePriceModel/Program.cs`
2. Run the console app (`Ctrl+F5` or `dotnet run`)
3. After training, a model file named `HousePriceModel.zip` will be created in:
/HousePriceModel/bin/Debug/net6.0/HousePriceModel.zip

markdown
Copy code

4. **Copy `HousePriceModel.zip` into the Web API project root**:
/HousePriceModelAPI/HousePriceModel.zip

yaml
Copy code

---

### 🔹 Step 2: Run the Web API

1. Open the `HousePriceModelAPI` project
2. Run it using Visual Studio or terminal:

```bash
dotnet run
Navigate to Swagger or use Postman to test:

bash
Copy code
POST http://localhost:{port}/api/houseprice
📦 Sample Request
🔹 POST /api/houseprice
json
Copy code
{
  "size": 1800,
  "bedrooms": 3,
  "bathrooms": 2
}
🔹 Response
json
Copy code
{
  "size": 1800,
  "bedrooms": 3,
  "bathrooms": 2,
  "predictedPrice": 354800.52
}
🧪 Quick Test Endpoint
You can also test a sample prediction at:

bash
Copy code
GET /api/houseprice/test
🖼️ Screenshots
✅ Console Training Output

✅ Web API Response

❗ Troubleshooting
Issue	Fix
Model file not found	Make sure HousePriceModel.zip is copied to /HousePriceModelAPI
PredictedPrice = 0	Ensure your API's HouseData class has no Price property. It should match the model input schema
Could not find label column 'Label'	Add [ColumnName("Label")] to Price in training model
Console works but API doesn't	You're likely using mismatched classes or an outdated .zip in API

🙌 Credits
Built with:

.NET 6

ML.NET

ASP.NET Core Web API

📬 Contribute or Contact
Have feedback or want to contribute? Open an issue or PR!
