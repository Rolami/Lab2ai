using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction;
using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.Models;
using Microsoft.Extensions.Configuration;
using ImageUrl = Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.Models.ImageUrl;

class Program
{
    public static CustomVisionPredictionClient cvClient;
    IConfigurationRoot config;
    string? customVisionKey;
    string? customVisionEndPoint;

    string? predictionModelName;
    string? predictionEndpoint;
    string? predictionKey;
    string? predictionProjectId;




    public Program()
    {
        // Load configuration settings from appsettings.json
        // IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
        string projectDir = Directory.GetCurrentDirectory();
        IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile(projectDir + "/appsettings.json", optional: false, reloadOnChange: true);

        config = builder.Build();
        
        customVisionKey = config["CustomVisionKey"];
        customVisionEndPoint = config["CustomVisionEndPoint"];
        
        predictionModelName = config["ProjectModelName"];
        predictionKey = config["PredictionKey"];
        predictionEndpoint = config["PredictionEndpoint"];
        predictionProjectId = config["PredictionProjectId"];
    }


    public async Task RunAsync()
    {
        Console.WriteLine("Welcome to the image classifier\n\n");
        // Authenticate and assign the client
        cvClient = new CustomVisionPredictionClient(new ApiKeyServiceClientCredentials(predictionKey)) { Endpoint = predictionEndpoint };
        Guid projectId = new Guid(predictionProjectId);
        string userInput = null; // Remove the nullable type ('?')



        while (string.IsNullOrEmpty(userInput)) // Check for empty string instead of null
        {
            Console.WriteLine("Enter the URL of the image to process:");
            userInput = Console.ReadLine();
        }

        var result = cvClient.ClassifyImageUrl(projectId, predictionModelName, new ImageUrl(userInput));
        Console.WriteLine("\nHere are your predictions:\n");

        foreach (var c in result.Predictions)
        {
            Console.WriteLine($"\t{c.TagName}: {c.Probability:P1}");
        }
    Console.ReadKey();
    }

        static async Task Main(string[] args)
        {
            var program = new Program();
            await program.RunAsync();
        }
}
