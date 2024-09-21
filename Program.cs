public class Program
{
    public static void Main(string[] args)
    {
        int numberOfFaces = 6;
        double marginOfError = .01d;
        int sizeOfBatch = 10;

        CalculateNumberOfTries(new PureRandomDice(numberOfFaces), numberOfFaces, sizeOfBatch, marginOfError);
        CalculateNumberOfTries(new NonRepeatingDice(numberOfFaces), numberOfFaces, sizeOfBatch, marginOfError);
        CalculateNumberOfTries(new SelfAdjustingDice(numberOfFaces), numberOfFaces, sizeOfBatch, marginOfError);
        CalculateNumberOfTries(new NonRepeatingSelfAdjustingDice(numberOfFaces), numberOfFaces, sizeOfBatch, marginOfError);
        CalculateNumberOfTries(new PureDeterministicDice(numberOfFaces), numberOfFaces, sizeOfBatch, marginOfError);
    }

    private static void CreateBatchOfResults(IDice diceToRoll, int sizeOfBatch, ref List<int> results)
    {
        for (int i = 0; i < sizeOfBatch; i++)
        {
            results.Add(diceToRoll.Roll());
        }
    }

    private static void CalculateNumberOfTries(IDice dice, int numberOfFaces, int sizeOfBatch, double marginOfError)
    {
        List<int> results = new();
        do
        {
            CreateBatchOfResults(dice, sizeOfBatch, ref results);
        } while (!BatchOfTests.Run(results, numberOfFaces, marginOfError));
        Console.WriteLine(results.Count);
    }
}