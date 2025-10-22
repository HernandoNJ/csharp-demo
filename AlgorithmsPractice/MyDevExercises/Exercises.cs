namespace AlgorithmsTest;

public class Exercises
{
    #region 2D Array

    /* Explanation
    i index for rows
    j index for columns
    index i = 0, index j = 0 ... A
    index i = 0, index j = 1 ... B
    index i = 0, index j = 2 ... C
    Next row
    index i = 1, index j = 0 ... D
    index i = 1, index j = 1 ... E
    index i = 1, index j = 2 ... F
    */

    char[,] letters = new char[2, 3]
    {
        { 'A', 'B', 'C' },
        { 'D', 'E', 'F' },
    };

    public void PrintLetters()
    {
        var height = letters.GetLength(0);
        var width = letters.GetLength(1);

        for (int i = 0; i < height; i++)
        {
            Console.WriteLine($"i is {i}");
            for (int j = 0; j < width; j++)
            {
                Console.WriteLine($"j is {j}");
                Console.WriteLine($"letter is {letters[i, j]}");
            }

            if (i == 0) Console.WriteLine("********* New row ***************");
        }
    }

    /* Exercise: Find Max value
     *Return the maxim value from the array.
     * If any of the array's dimensions is zero, it means the array is empty, and the method should return -1.
     */

    int FindMax(int[,] numbers)
    {
        var width = numbers.GetLength(0);
        var height = numbers.GetLength(1);

        if (width == 0 || height == 0) return -1;

        int max = numbers[0, 0];

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (numbers[i, j] > max) max = numbers[i, j];
            }
        }

        return max;
    }

    #endregion

    #region Foreach

    // Used to execute code on every item in a collection

    bool IsAnyWordLongerThan(int length, string[] words)
    {
        foreach (var w in words)
        {
            if (w.Length > length) return true;
        }

        return false;
    }

    #endregion

    #region PrintWords

    List<string> words = ["Uno", "Dos", "Tres", "Cuatro", "Cinco"];

    public void PrintWords()
    {
        foreach (var word in words) Console.WriteLine(word);
    }

    public void PrintNewWords()
    {
        Console.WriteLine("********* New Words **************");
        Console.WriteLine();
        words.AddRange(["Seis", "Siete"]);
        foreach (var word in words) Console.Write(word + " - ");
    }

    #endregion

    #region ArraySum

    public static int simpleArraySum(List<int> ar)
    {
        var sum = 0;
        foreach (var n in ar) sum += n;
        return sum;
    }

    public void PrintArraySumText()
    {
        Console.WriteLine("******* Array Sum ************");
        Console.WriteLine();
        Console.WriteLine("Enter numbers separated by spaces.");
        ConsoleReadText();
        //StreamWriterText();

        void ConsoleReadText()
        {
            var ar = Console.ReadLine()
                .TrimEnd()
                .Split(' ')
                .ToList()
                .Select(arTemp => Convert.ToInt32(arTemp)).ToList();

            var result = simpleArraySum(ar);
            Console.WriteLine(result);
        }

        void StreamWriterText()
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int arCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> ar = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arTemp => Convert.ToInt32(arTemp))
                .ToList();

            int result = simpleArraySum(ar);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }

    #endregion

    #region out keyword

    public void CheckIntArrayValues()
    {
        var numbersArray = new[] { 10, 4, 7, -18, -23, -8, 2, 12, -17 };
        //int positives;
        //int negatives;
        var onlyPositives = GetOnlyPositiveNumbers(numbersArray,
            out var positives,
            out var negatives);

        foreach (var number in onlyPositives) Console.WriteLine(number);

        Console.WriteLine($"positives count: {positives}");
        Console.WriteLine($"negatives count: {negatives}");
    }

    private List<int> GetOnlyPositiveNumbers(int[] numbers,
        out int positiveNumbersCount,
        out int negativeNumbersCount)
    {
        positiveNumbersCount = 0;
        negativeNumbersCount = 0;
        var result = new List<int>();

        foreach (var number in numbers)
        {
            if (number > 0)
            {
                result.Add(number);
                positiveNumbersCount++;
            }
            else negativeNumbersCount++;
        }

        return result;
    }

    #endregion

    #region TripletsSum

    // Receive 2 int arrays a,b
    // Create an int array r with size of 2
    // Compare a0,b0
    // if a0<b0, r0 +=1;
    // else if a0=b0, continue
    // else r1 +=1
    // repeat until array a length
    // Return r

    private static List<int> CompareTriplets(List<int> a, List<int> b)
    {
        var r = new List<int> { 0, 0 }; 
        for (int i = 0; i < a.Count; i++)
        {
            if (a[i] > b[i]) r[0]++;
            else if (a[i] < b[i]) r[1]++;
            // when equal, do nothing
        }
        return r;
    }

    public void TripletsCalculation()
    {
        var a = Console.ReadLine()
            .TrimEnd()
            .Split(' ')
            .ToList()
            .Select(aTemp => Convert.ToInt32(aTemp)).ToList();

        var b = Console.ReadLine()
            .TrimEnd()
            .Split(' ')
            .ToList()
            .Select(bTemp => Convert.ToInt32(bTemp)).ToList();
        
        var result = CompareTriplets(a, b);

        Console.WriteLine(String.Join(" ", result));
    }

    #endregion
    
    #region AVeryBigSum
    
    private long A_VeryBigSum(List<long> ar)
    {
        long result = 0;
        for(int i=0; i<ar.Count; i++){
            result += ar[i];
        }
        return result;
    }

    public void CalculateVeryBigSum()
    {
        Convert.ToInt32(Console.ReadLine().Trim());

        var ar = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arTemp => Convert.ToInt64(arTemp)).ToList();

        var result = A_VeryBigSum(ar);

        Console.WriteLine(result);
    }
    
    #endregion
}
    
