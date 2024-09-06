///Labb1 - Algoritmer
///av Henrik Vu .NET24

Console.WriteLine("Mata in en text!");
string userInput = Console.ReadLine();
Console.WriteLine("----------------");
string holdString = string.Empty;
string compareStrings = string.Empty;
string stringNumber = string.Empty;
string stringResult = string.Empty;
long totalResult = 0;
long tempoResult = 0;
int holdIndex = 0;
int firstTxIndex = 0;
int redTxIndex = 0;
int lastTxIndex = 0;
bool isTextRed = false;

for (int i = 0; i < userInput.Length; i++)
{
    compareStrings = userInput[i].ToString();
    if (holdString == compareStrings && char.IsDigit(holdString[0]))
    {
        holdIndex++;
        lastTxIndex++;
        isTextRed = true;
    }
    else if (i == userInput.Length - 1 || char.IsLetter(userInput[i]) || userInput[i] == '+'
        || userInput[i] == '-' || userInput[i] == '/' || userInput[i] == '*')
    {
        holdIndex++;
        i = holdIndex;
        lastTxIndex = i;
        firstTxIndex++;
        redTxIndex = 0;
        holdString = userInput[holdIndex].ToString();
    }
    if (isTextRed)
    {
        //First text before red text
        Console.ForegroundColor = ConsoleColor.Gray;
        for (int j = 0; j < firstTxIndex; j++)
        {
            Console.Write(userInput[j]);
        }

        //Red text
        Console.ForegroundColor = ConsoleColor.Red;
        for (int j = 0; j <= redTxIndex; j++)
        {
            stringNumber = userInput[j + firstTxIndex].ToString();
            stringResult += stringNumber;
            Console.Write(stringNumber);
        }

        //Last text after red text
        Console.ForegroundColor = ConsoleColor.Gray;
        for (int j = 0; j < userInput.Length - lastTxIndex; j++)
        {
            stringNumber = userInput[lastTxIndex + j].ToString();
            Console.Write(stringNumber);
        }

        //Adds the red text results together
        long.TryParse(stringResult, out tempoResult);
        totalResult += tempoResult;

        firstTxIndex++;
        i = firstTxIndex;
        lastTxIndex = i;
        redTxIndex = 0;
        stringResult = string.Empty;
        isTextRed = false;
        Console.WriteLine();
    }
    holdString = userInput[holdIndex].ToString();
    lastTxIndex++;
    redTxIndex++;
}

Console.WriteLine($"\nTotal \"marked\" result: {totalResult}");