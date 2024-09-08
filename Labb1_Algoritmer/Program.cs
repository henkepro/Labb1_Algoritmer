///Labb1 - Algoritmer
///av Henrik Vu .NET24

Console.WriteLine("Please enter an input\n");
string userInput = Console.ReadLine();
string loopString = string.Empty;
string holdString = string.Empty;
string redString = string.Empty;
long tempResult = 0;
long totalResult = 0;
int startIndex = 0;
int count = 0;

for (int i = 0; i < userInput.Length; i++)
{
    loopString = userInput[i].ToString();
    if (holdString == loopString && char.IsDigit(holdString[0]))
    {
        //Before text
        for (int j = 0; j < startIndex; j++)
        {
            Console.Write(userInput[j]);
        }

        //Red text
        Console.ForegroundColor = ConsoleColor.Red;
        for (int j = 0; j < count + 1; j++)
        {
            Console.Write(userInput[j + startIndex]);
            redString += userInput[j + startIndex].ToString();
        }

        //After text
        Console.ForegroundColor = ConsoleColor.White;
        for (int j = 1; j + count + startIndex < userInput.Length; j++)
        {
            Console.Write(userInput[j + count + startIndex]);
        }

        //redTextResult
        long.TryParse(redString, out tempResult);
        totalResult += tempResult;

        count = 0;
        tempResult = 0;
        startIndex++;
        i = startIndex;
        redString = string.Empty;
        Console.WriteLine();
    }
    else if (i == userInput.Length - 1 || char.IsLetter(userInput[i]) || userInput[i] == '+'
        || userInput[i] == '-' || userInput[i] == '/' || userInput[i] == '*')
    {
        count = 0;
        startIndex++;
        i = startIndex;
        loopString = string.Empty;
    }
    count++;
    holdString = userInput[startIndex].ToString();
}

Console.WriteLine($"\nTotal \"marked\" result: {totalResult}");