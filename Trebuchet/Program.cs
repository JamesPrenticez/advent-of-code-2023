using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Path to your text file
        string filePath = "./data.txt";
        int runningTotal = 0;

        try
        {
            // Open the text file using a StreamReader
            using (StreamReader sr = new StreamReader(filePath))
            {
                int lineCount = 0;
                string line;



                // Read the file line by line until the end of the file is reached
                while ((line = sr.ReadLine()) != null)
                {
                    // Increment the line count for each line read
                    lineCount++;

                    // Check if the line is not empty
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                      // Find the first and last digits in the line
                      char firstDigit = FindFirstDigit(line);
                      char lastDigit = FindLastDigit(line);

                      // char combo = (char)(firstDigit + lastDigit); // Concatenate first and last digit < NOT this
                      string combo = $"{firstDigit}{lastDigit}"; // Concatenate first and last digit as string
                      Console.WriteLine($"{combo}");
                      // Console.WriteLine($"Line {combo}");
                      int comboResult = int.Parse(combo.ToString()); // Parse to int

                      runningTotal += comboResult; // Add to running total
                      // Console.WriteLine($"Line {lineCount}: First Digit: {firstDigit} Last Digit: {lastDigit}");
                    }

                }

                Console.WriteLine($"Total number of lines: {lineCount}");
                Console.WriteLine($"Final Running Total: {runningTotal}");
            }
        }
        catch (Exception e)
        {
            // Display an error message if there's an exception while reading the file
            Console.WriteLine($"The file could not be read: {e.Message}");
        }
    }

    // Method to find the first digit in a string
    static char FindFirstDigit(string text) {
      foreach (char c in text) {
        if (char.IsDigit(c)) {
          return c;
        }
      }
      return '\0'; // Return null character if no digit is found
    }

    // Method to find the last digit in a string
    static char FindLastDigit(string text) {
      for (int i = text.Length - 1; i >= 0; i--) {
        if (char.IsDigit(text[i])) {
          return text[i];
        }
      }
      return '\0'; // Return null character if no digit is found
    }
    
}

