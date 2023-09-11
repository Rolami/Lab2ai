// using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
// using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction;
// using Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.Models;
// using Microsoft.Extensions.Configuration;
// using ImageUrl = Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.Models.ImageUrl;

// class ToolBox
// {
//     public static CustomVisionPredictionClient cvClient;
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

//     public static void Bob()
//     {

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

//     // private static async Task ImageDownloader(string imageUrl)
//     // {
//     //     using (HttpClient client = new HttpClient())
//     //     {
//     //         try
//     //         {
//     //             HttpResponseMessage response = await client.GetAsync(imageUrl);
//     //             if (response.IsSuccessStatusCode)
//     //             {
//     //                 byte[] imageBytes = await response.Content.ReadAsByteArrayAsync();

//     //                 // Extract the filename from the URL
//     //                 string filename = Path.GetFileName(new Uri(imageUrl).AbsolutePath);

//     //                 // Specify the path where you want to save the file
//     //                 string imagePath = "./UserFiles/" + filename;

//     //                 // Save the image to the specified path
//     //                 File.WriteAllBytes(imagePath, imageBytes);

//     //                 Console.WriteLine("File saved as: " + imagePath);
//     //                 Console.WriteLine("\nStarting analyzing . . . ");


//     //                 // Get image analysis
//     //                 using (var imageData = File.OpenRead(imagePath))
//     //                     await Blender(imageData);
//     //             }
//     //             else
//     //             {
//     //                 Console.WriteLine("Failed to download the image.");
//     //             }
//     //         }
//     //         catch (Exception ex)
//     //         {
//     //             Console.WriteLine($"An error occurred: {ex.Message}");
//     //         }
//     //     }
//     // }


//     // static Task Blender(CustomVisionPredictionClient predictionApi, FileStream imageData)
//     // {

//     //     // Make a prediction against the new project
//     //     Console.WriteLine("Making a prediction:");
//     //     var result = predictionApi.ClassifyImage(project.Id, publishedModelName, imageData);

//     //     // Loop over each prediction and write out the results
//     //     foreach (var c in result.Predictions)
//     //     {
//     //         Console.WriteLine($"\t{c.TagName}: {c.Probability:P1}");
//     //     }
//     // }

// }




