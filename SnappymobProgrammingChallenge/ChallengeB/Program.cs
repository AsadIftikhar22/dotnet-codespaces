using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string filePath = "/app/generatedData/generatedData.txt";  // Path to the generated data file in shared volume

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Error: File not found.");
            return;
        }

        try
        {
            // Read all lines from the file
            var lines = File.ReadAllLines(filePath);

            // Example operation: Print first 10 lines from the file
            Console.WriteLine("First 10 lines from the generated data:");
            for (int i = 0; i < Math.Min(10, lines.Length); i++)
            {
                Console.WriteLine(lines[i]);
            }

            // Example operation: Count and display number of rows
            Console.WriteLine($"\nTotal number of rows in the file: {lines.Length}");

            // Example operation: Find and print the first line containing an integer
            var firstIntegerLine = lines.FirstOrDefault(line => line.Split(',').Any(part => int.TryParse(part, out _)));
            if (firstIntegerLine != null)
            {
                Console.WriteLine($"\nFirst line containing an integer: {firstIntegerLine}");
            }
            else
            {
                Console.WriteLine("\nNo lines containing integers were found.");
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing the file: {ex.Message}");
        }
    }
}
