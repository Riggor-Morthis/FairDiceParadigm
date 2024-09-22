using System.Diagnostics;

public class TestingThread
{
    public Thread Thread {get; private set;}

    private readonly int numberOfTests;
    private int numberOfTries;

    private readonly IDice dice;
    private readonly int numberOfFaces;
    private readonly int sizeOfBatch;
    private readonly double marginOfError;
    private List<int> results;
    private readonly string diceName;

    public TestingThread(IDice dice, int numberOfFaces, int sizeOfBatch, int numberOfTests, double marginOfError, string diceName)
    {
        this.dice = dice;
        this.numberOfFaces = numberOfFaces;
        this.sizeOfBatch = sizeOfBatch;
        this.numberOfTests = numberOfTests;
        this.marginOfError = marginOfError;
        this.diceName = diceName;

        numberOfTries = 0;
        results = [];

        Thread = new(Run);
        Thread.Start();
    }

    private void Run()
    {
        for (int i = 0; i < numberOfTests; i++)
        {
            numberOfTries += CalculateNumberOfTries();
        }
        double averageNumberOfTries = numberOfTries / numberOfTests;

        Console.WriteLine($"{diceName} requires {averageNumberOfTries} rolls");
    }

    private int CalculateNumberOfTries()
    {
        results = [];
        do
        {
            CreateBatchOfResults();
        } while (!BatchOfTests.Run(results, numberOfFaces, marginOfError));
        return results.Count;
    }

    private void CreateBatchOfResults()
    {
        for (int i = 0; i < sizeOfBatch; i++)
        {
            results.Add(dice.Roll());
        }
    }
}