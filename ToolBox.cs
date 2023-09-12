


//Ignore this file, it has old code.



//     private static async Task ImageDownloader(string imageUrl)
//     {
//         using (HttpClient client = new HttpClient())
//         {
//             try
//             {
//                 HttpResponseMessage response = await client.GetAsync(imageUrl);
//                 if (response.IsSuccessStatusCode)
//                 {
//                     byte[] imageBytes = await response.Content.ReadAsByteArrayAsync();

//                     // Extract the filename from the URL
//                     string filename = Path.GetFileName(new Uri(imageUrl).AbsolutePath);

//                     // Specify the path where you want to save the file
//                     string imagePath = "./UserFiles/" + filename;

//                     // Save the image to the specified path
//                     File.WriteAllBytes(imagePath, imageBytes);

//                     Console.WriteLine("File saved as: " + imagePath);
//                     Console.WriteLine("\nStarting analyzing . . . ");


//                     // Get image analysis
//                     using (var imageData = File.OpenRead(imagePath))
//                         await Blender(imageData);
//                 }
//                 else
//                 {
//                     Console.WriteLine("Failed to download the image.");
//                 }
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine($"An error occurred: {ex.Message}");
//             }
//         }
//     }


//     static Task Blender(CustomVisionPredictionClient predictionApi, FileStream imageData)
//     {

//         // Make a prediction against the new project
//         Console.WriteLine("Making a prediction:");
//         var result = predictionApi.ClassifyImage(project.Id, publishedModelName, imageData);

//         // Loop over each prediction and write out the results
//         foreach (var c in result.Predictions)
//         {
//             Console.WriteLine($"\t{c.TagName}: {c.Probability:P1}");
//         }
//     }

// }




