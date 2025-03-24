using System;
using System.IO;
using System.Text;

class Program
{
    static Random random = new Random();

    static void Main()
    {
        const int targetLines = 17; // Number of lines to generate
        // Docker Generated file size on the host machine
        long currentSize = 0;

        // Use the shared volume path Docker will manage it automatically 
        // from the Docker Container and than our service B can run from it
        string filePath = "/app/generatedData/generatedData.txt"; 
        string inputFilePath = "/app/output/generatedData.txt";
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            while (currentSize < targetLines)
            {
                // Generate and write containing types of objects
                string line = GenerateRandomObjects();
                using(StreamWriter localwriter=new StreamWriter(inputFilePath)){
                      writer.WriteLine(line);
                      localwriter.WriteLine(line);
                      currentSize += Encoding.UTF8.GetByteCount(line + "\n");
                }
            }
        }

        Console.WriteLine("Data generation completed.");
    }

    // Generate a line with objects
    static string GenerateRandomObjects()
    {
        string[] randomObjects = new string[4];
        for (int i = 0; i < 4; i++)
        {
            randomObjects[i] = GenerateRandomObject();
        }

        // Join the objects with commas
        return string.Join(",", randomObjects);
    }

    // Generate a object: string, real number, integer, or alphanumeric
    static string GenerateRandomObject()
    {
        int type = random.Next(4); // choose one type (0-3)
        return type switch
        {
            0 => GenerateRandomString(),        // string
            1 => GenerateRandomRealNumber(),    // real number
            2 => GenerateRandomInteger(),       // integer
            3 => GenerateRandomAlphanumeric(),  // alphanumeric with spaces
            _ => string.Empty
        };
    }

    // Generate a alphabetic string (lowercase)
    static string GenerateRandomString()
    {
        int length = random.Next(5, 15); // length between 5 and 15
        char[] chars = new char[length];
        for (int i = 0; i < length; i++){
            chars[i] = (char)random.Next('a', 'z' + 1); // char from 'a' to 'z'
        }
        return new string(chars);
    }

    // Generate a number Double
    static string GenerateRandomRealNumber() {
        double number = random.NextDouble() * random.Next(1, 1000); // real number
        return number.ToString("F2"); // Format as a string with 2 decimal places
    }

    // Generate a integer
    static string GenerateRandomInteger()
    {
        return random.Next(-1000, 1000).ToString(); // integer between -1000 and 1000
    }

    // Generate an alphanumeric string with spaces before and after
    static string GenerateRandomAlphanumeric()
    {
        string alphanumeric = GenerateRandomString();
        int spaceBefore = random.Next(0, 11);  // spaces before (0 to 10)
        int spaceAfter = random.Next(0, 11);   // spaces after (0 to 10)

        // Add spaces around the alphanumeric string
        return new string(' ', spaceBefore) + alphanumeric + new string(' ', spaceAfter);
    }
}
