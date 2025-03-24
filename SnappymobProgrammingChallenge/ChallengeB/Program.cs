using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string filePath = "/app/generatedData/generatedData.txt";  // Path to the generated data file in shared volume
        string outputFilePath = "/app/output/processedData.txt";        // Path to store the processed output

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Error: File not found.");
            return;
        }

        try
        {
            // Read all lines from the file
            var lines = File.ReadAllLines(filePath);

            // Iterate through each line in the file
            Console.WriteLine("Objects and their types from the generated data:");
        using (StreamWriter writer = new StreamWriter(outputFilePath)){
            foreach (var line in lines){
                // Split the line into individual objects
                var objects = line.Split(',');

                foreach (var obj in objects){
                    // Trim spaces before and after the alphanumeric object
                    string trimmedObj = obj.Trim();
                    var objectType=GetObjectType(trimmedObj);
                    // Write the processed data to the output file
                    string outputLine = $"Object: {trimmedObj}, Type: {objectType}";
                    writer.WriteLine(outputLine);
                    // Print the object and its type
                    Console.WriteLine($"Object: {trimmedObj}, Type: {GetObjectType(objectType)}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing the file: {ex.Message}");
        }
    }

    // Determine the type of the object (string, real number, integer, or alphanumeric)
    static string GetObjectType(string obj)
    {
        if (double.TryParse(obj, out _))
        {
            return "Real Number";
        }
        else if (int.TryParse(obj, out _))
        {
            return "Integer";
        }
        else if (obj.All(char.IsLetter))
        {
            return "String";
        }
        else if (obj.Any(c => char.IsLetterOrDigit(c) || c == ' '))
        {
            return "Alphanumeric";
        }
        else
        {
            return "Unknown";
        }
    }
}
