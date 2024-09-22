using System.Diagnostics;

public class Program
{
    public static List<TestingThread> runningThreads;

    public static void Main(string[] args)
    {
        int numberOfFaces = 6;
        int sizeOfBatch = 600;
        int numberOfTests = 1000000;
        double marginOfError = .01d;

        runningThreads =
        [
            new TestingThread(new PureRandomDice(numberOfFaces),
                numberOfFaces, sizeOfBatch, numberOfTests, marginOfError, "Pure Random Dice"),
            new TestingThread(new NonRepeatingDice(numberOfFaces),
                numberOfFaces, sizeOfBatch, numberOfTests, marginOfError, "Non Repeating Dice"),
            new TestingThread(new SelfAdjustingDice(numberOfFaces),
                numberOfFaces, sizeOfBatch, numberOfTests, marginOfError, "Self Adjusting Dice"),
            new TestingThread(new NonRepeatingSelfAdjustingDice(numberOfFaces),
                numberOfFaces, sizeOfBatch, numberOfTests, marginOfError, "Non Repeating Self Adjusting Dice"),
            new TestingThread(new PureDeterministicDice(numberOfFaces),
                numberOfFaces, sizeOfBatch, numberOfTests, marginOfError, "Pure Deterministic Dice")
        ];

        Stopwatch stopwatch = new();
        stopwatch.Start();

        do
        {
            Thread.Sleep(1);
        } while (IsAtLeastOneThreadAlive());

        stopwatch.Stop();
        Console.WriteLine($"{Math.Round(stopwatch.Elapsed.TotalSeconds)}s");
    }

    public static bool IsAtLeastOneThreadAlive()
    {
        foreach (TestingThread runningThread in runningThreads)
        {
            if (runningThread.Thread.IsAlive)
            {
                return true;
            }
        }
        return false;
    }
}