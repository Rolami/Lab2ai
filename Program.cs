using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.Models;
using Microsoft.Extensions.Configuration;
using ImageUrl = Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.Models.ImageUrl;

internal class Program
{
    public static CustomVisionPredictionClient cvClient;

    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the image classifier\n\n\n");

        // Load configuration settings from appsettings.json
        IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
        IConfigurationRoot config = builder.Build();
        string predictionEndpoint = config["PredictionEndpoint"];
        string customVisionKey = config["CustomVisionKey"];
        string predictionModelName = config["ProjectModelName"];
        string predictionKey = config["PredictionKey"];
        string predictionProjectId = config["PredictionProjectId"];

        // Authenticate and assign the client
        cvClient = AuthenticatePrediction(predictionEndpoint, customVisionKey);

        Guid projectId = new Guid(predictionProjectId);

        string userInput = null; // Remove the nullable type ('?')

        while (string.IsNullOrEmpty(userInput)) // Check for empty string instead of null
        {
            Console.WriteLine("Enter the URL of the image to process:");
            userInput = Console.ReadLine();
        }
        
        var result = cvClient.ClassifyImageUrl(projectId, predictionModelName, new ImageUrl(userInput));

        foreach (var c in result.Predictions)
        {
            Console.WriteLine($"\t{c.TagName}: {c.Probability:P1}");
        }
    }

    //auth
    static CustomVisionPredictionClient AuthenticatePrediction(string predictionEndpoint, string predictionKey)
    {
        // Create a prediction endpoint, passing in the obtained prediction key
        CustomVisionPredictionClient predictionApi = new CustomVisionPredictionClient(new Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.ApiKeyServiceClientCredentials(predictionKey))
        {
            Endpoint = predictionEndpoint
        };
        return predictionApi;
    }
}

// internal class Program
// {
//  public static CustomVisionPredictionClient cvClient;
//     private static void Main(string[] args)
//     {
//         Console.WriteLine("Welcome to the image classifier\n\n\n");
        
//     // auth
//     static CustomVisionPredictionClient AuthenticatePrediction(string predictionEndpoint, string predictionKey)
//     {
//         // Create a prediction endpoint, passing in the obtained prediction key
//         CustomVisionPredictionClient predictionApi = new CustomVisionPredictionClient(new Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.ApiKeyServiceClientCredentials(predictionKey))
//         {
//             Endpoint = predictionEndpoint
//         };
//         return predictionApi;
//     }



//         // Load configuration settings from appsettings.json
//         IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
//         IConfigurationRoot config = builder.Build();
//         string predictionEndpoint = config["PredictionEndpoint"];
//         string customVisionKey = config["CustomVisionKey"];
//         string predictionModelName = config["ProjectModelName"];
//         string predictionKey = config["PredictionKey"];
//         string predictionProjectId = config["PredictionProjectId"];
//         AuthenticatePrediction(predictionEndpoint, predictionKey);
//         // await ImageDownloader(imageUrl);
//         // Initialize clients
//         cvClient = new CustomVisionPredictionClient(new ApiKeyServiceClientCredentials(predictionKey)) { Endpoint = predictionEndpoint };
//         Guid projectId = new Guid(predictionProjectId);

//         string userInput = null; // Remove the nullable type ('?')

//         while (string.IsNullOrEmpty(userInput)) // Check for empty string instead of null
//         {
//             Console.WriteLine("Enter the URL of the image to process:");
//             userInput = Console.ReadLine();
//         }
//         var result = cvClient.ClassifyImageUrl(projectId, predictionModelName, new ImageUrl(userInput));

//         foreach (var c in result.Predictions)
//         {
//             Console.WriteLine($"\t{c.TagName}: {c.Probability:P1}");
//         }
//     }
//     }
