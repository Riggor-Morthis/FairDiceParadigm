public class Program
{
    public static List<TestingThread> runningThreads;


    public static void Main(string[] args)
    {
        int numberOfFaces = 6;
        int sizeOfBatch = numberOfFaces;
        int numberOfTests = 1000000;
        double marginOfError = .1d;

        _ = new TestingThread(new LeastWorstDice(numberOfFaces), numberOfFaces, sizeOfBatch, numberOfTests, marginOfError, "Least Worst Dice");

        _ = new TestingThread(new NonRepeatingDeterministicDice(numberOfFaces), numberOfFaces, sizeOfBatch, numberOfTests, marginOfError, "Non Repeating Deterministic Dice");

        _ = new TestingThread(new NonRepeatingDice(numberOfFaces), numberOfFaces, sizeOfBatch, numberOfTests, marginOfError, "Non Repeating Dice");

        _ = new TestingThread(new PureDeterministicDice(numberOfFaces), numberOfFaces, sizeOfBatch, numberOfTests, marginOfError, "Pure Deterministic Dice");

        _ = new TestingThread(new PureRandomDice(numberOfFaces), numberOfFaces, sizeOfBatch, numberOfTests, marginOfError, "Pure Random Dice");

        _ = new TestingThread(new RefreshDeterministicDice(numberOfFaces), numberOfFaces, sizeOfBatch, numberOfTests, marginOfError, "Refresh Deterministic Dice");

        _ = new TestingThread(new RobinHoodDice(numberOfFaces), numberOfFaces, sizeOfBatch, numberOfTests, marginOfError, "Robin Hood Dice");

        _ = new TestingThread(new SelfAdjustingDice(numberOfFaces), numberOfFaces, sizeOfBatch, numberOfTests, marginOfError, "Self Adjusting Dice");

        _ = new TestingThread(new UpgradedLeastWorstDice(numberOfFaces), numberOfFaces, sizeOfBatch, numberOfTests, marginOfError, "Upgraded Least Worst Dice");
    }
}