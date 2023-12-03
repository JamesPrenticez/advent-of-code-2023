using System;
using System.IO;

class Program {
  static void Main(){
    string filePath = "./data.txt";
    string data = File.ReadAllText(filePath);
    Console.WriteLine($"Task One: {TaskOne(filePath)}");
    Console.WriteLine($"========================================");
    Console.WriteLine($"Task One Improved: {TaskOneImproved(data)}");
    Console.WriteLine($"========================================");
    Console.WriteLine($"Task Two: {TaskTwo(data)}");
  }

  static string TaskOne(string filePath){
    int total = 0;

    try {
      // Open the text file using a StreamReader
      using (StreamReader sr = new StreamReader(filePath)) {
        int lineCount = 0;
        string line;

        // Read the file line by line until the end of the file is reached
        while ((line = sr.ReadLine()) != null) {
          // Increment the line count for each line read
          lineCount++;

          // Check if the line is not empty
          if (!string.IsNullOrWhiteSpace(line)) {
            // Find the first and last digits in the line
            char firstDigit = FindFirstDigit(line);
            char lastDigit = FindLastDigit(line);

            string combo = $"{firstDigit}{lastDigit}"; // Concatenate first and last digit as string
            int comboResult = int.Parse(combo.ToString()); // Parse to int

            // Console.WriteLine(comboResult.ToString());

            total += comboResult; // Add to running total

          }
        }
      Console.WriteLine($"Length: {lineCount}");
      }
    }
    catch (Exception e)
    {
      // Display an error message if there's an exception while reading the file
      Console.WriteLine($"The file could not be read: {e.Message}");
    }

    return total.ToString();
  }

  // Method to find the first digit in a string
  static char FindFirstDigit(string text){
    foreach (char c in text){
      if (char.IsDigit(c)){
        return c;
      }
    }
    return '\0'; // Return null character if no digit is found
  }

  // Method to find the last digit in a string
  static char FindLastDigit(string text){
    for (int i = text.Length - 1; i >= 0; i--){
      if (char.IsDigit(text[i])) {
        return text[i];
      }
    }
    return '\0'; // Return null character if no digit is found
  }

  static string TaskOneImproved(string data) {
    var lines = data.Split('\n');

    int totalNumber = 0;

    foreach (var line in lines){
      var numberCharacters = line.Where(char.IsDigit).ToList();
      if (numberCharacters.Count > 1){
        var stringNumber = $"{numberCharacters.First()}{numberCharacters.Last()}";
        totalNumber += int.Parse(stringNumber);
      } else {
        var stringNumber = $"{numberCharacters.First()}{numberCharacters.First()}";
        totalNumber += int.Parse(stringNumber);
      }
    }
    Console.WriteLine($"Length: {lines.Length}");
    return totalNumber.ToString();
  }

  static string TaskTwo(string data) {
    var lines = data.Split('\n');
    int totalNumber = 0;
    var numbersAsText = new[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
    var numbersList = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

    foreach (var line in lines){
      var firstNumber = FindFirst(numbersAsText, numbersList, line);
      var lastNumber = FindLast(numbersAsText, numbersList, line);
      var stringNumber = $"{firstNumber}{lastNumber}";
      totalNumber += int.Parse(stringNumber);
    }

    return totalNumber.ToString();
  }

  static int FindFirst(string[] numbersAsText, string[] numbersList, string line) {
    int lowestIteration = line.Length;
    string currentUsedValue = "";

    foreach (var currentNumber in numbersAsText.Concat(numbersList)){
      var firstIndex = line.IndexOf(currentNumber);
      if (firstIndex != -1 && firstIndex <= lowestIteration){
        lowestIteration = firstIndex;
        currentUsedValue = currentNumber;
      }
    }

    return ConvertToNumber(currentUsedValue);
  }

  static int FindLast(string[] numbersAsText, string[] numbersList, string line){
    int highestIteration = 0;
    string currentUsedValue = "";

    foreach (var currentNumber in numbersAsText.Concat(numbersList)){
      var lastIndex = line.LastIndexOf(currentNumber);
      if (lastIndex != -1 && lastIndex >= highestIteration)
      {
        highestIteration = lastIndex;
        currentUsedValue = currentNumber;
      }
    }

    return ConvertToNumber(currentUsedValue);
  }

  static int ConvertToNumber(string number) {
    return number switch {
      "one" => 1,
      "two" => 2,
      "three" => 3,
      "four" => 4,
      "five" => 5,
      "six" => 6,
      "seven" => 7,
      "eight" => 8,
      "nine" => 9,
      "1" => 1,
      "2" => 2,
      "3" => 3,
      "4" => 4,
      "5" => 5,
      "6" => 6,
      "7" => 7,
      "8" => 8,
      "9" => 9,
      _ => throw new Exception($"ERROR {number}")
    };
  }

}

