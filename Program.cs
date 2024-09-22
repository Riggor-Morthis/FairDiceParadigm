using System.Diagnostics;

public class Program
{
    public static List<TestingThread> runningThreads;


    public static void Main(string[] args)
    {
        int numberOfFaces = 6;
        int sizeOfBatch = 6;
        int numberOfTests = 100;
        double marginOfError = .01d;

        _ = new TestingThread(new NonRepeatingDice(numberOfFaces),
                              numberOfFaces,
                              sizeOfBatch,
                              numberOfTests,
                              marginOfError,
                              "Non Repeating Dice");
        _ = new TestingThread(new NonRepeatingSelfAdjustingDice(numberOfFaces),
                              numberOfFaces,
                              sizeOfBatch,
                              numberOfTests,
                              marginOfError,
                              "Non Repeating Self Adjusting Dice");
        _ = new TestingThread(new PureDeterministicDice(numberOfFaces),
                              numberOfFaces,
                              sizeOfBatch,
                              numberOfTests,
                              marginOfError,
                              "Pure Deterministic Dice");
        _ = new TestingThread(new PureRandomDice(numberOfFaces),
                              numberOfFaces,
                              sizeOfBatch,
                              numberOfTests,
                              marginOfError,
                              "Pure Random Dice");
        _ = new TestingThread(new SelfAdjustingDice(numberOfFaces),
                              numberOfFaces,
                              sizeOfBatch,
                              numberOfTests,
                              marginOfError,
                              "Self Adjusting Dice");
        _ = new TestingThread(new SquaredDeterministicDice(numberOfFaces),
                              numberOfFaces,
                              sizeOfBatch,
                              numberOfTests,
                              marginOfError,
                              "Squared Deterministic Dice");
        _ = new TestingThread(new SlowRefreshDeterministicDice(numberOfFaces),
                              numberOfFaces,
                              sizeOfBatch,
                              numberOfTests,
                              marginOfError,
                              "Fast Refresh Deterministic Dice");
    }

    /*     public static void StressTestThreads(int nbThreads)
        {
            int numberOfFaces = 6;
            int sizeOfBatch = 600;
            int numberOfTests = 10000 / nbThreads;
            double marginOfError = .01d;

            runningThreads = [];

            Stopwatch stopwatch = new();
            stopwatch.Start();
            for (int i = 0; i < nbThreads; i++)
            {
                runningThreads.Add(new TestingThread(new PureRandomDice(numberOfFaces),
                    numberOfFaces, sizeOfBatch, numberOfTests, marginOfError, "Pure Random Dice"));
            }
            do
            {
                Thread.Sleep(1000);
            } while (IsAtLeastOneThreadAlive());
            stopwatch.Stop();
            Console.WriteLine($"{nbThreads} threads require {stopwatch.Elapsed.TotalSeconds} seconds");
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
        } */
}