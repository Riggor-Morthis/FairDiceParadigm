public class Program
{
    public static List<TestingThread> runningThreads;


    public static void Main(string[] args)
    {
        int numberOfFaces = 4;
        int sizeOfBatch = 1;
        int numberOfTests = 1000000;
        double marginOfError = .1d;

        _ = new TestingThread(new NonRepeatingDeterministicDice(numberOfFaces), numberOfFaces, sizeOfBatch, numberOfTests, marginOfError, "Non Repeating Deterministic Dice");

        _ = new TestingThread(new RobinHoodDice(numberOfFaces), numberOfFaces, sizeOfBatch, numberOfTests, marginOfError, "Robin Hood Dice");

        _ = new TestingThread(new UpgradedLeastWorstDice(numberOfFaces), numberOfFaces, sizeOfBatch, numberOfTests, marginOfError, "Upgraded Least Worst Dice");

        numberOfFaces = 6;

        _ = new TestingThread(new NonRepeatingDeterministicDice(numberOfFaces), numberOfFaces, sizeOfBatch, numberOfTests, marginOfError, "Non Repeating Deterministic Dice");

        _ = new TestingThread(new RobinHoodDice(numberOfFaces), numberOfFaces, sizeOfBatch, numberOfTests, marginOfError, "Robin Hood Dice");

        _ = new TestingThread(new UpgradedLeastWorstDice(numberOfFaces), numberOfFaces, sizeOfBatch, numberOfTests, marginOfError, "Upgraded Least Worst Dice");

        numberOfFaces = 8;

        _ = new TestingThread(new NonRepeatingDeterministicDice(numberOfFaces), numberOfFaces, sizeOfBatch, numberOfTests, marginOfError, "Non Repeating Deterministic Dice");

        _ = new TestingThread(new RobinHoodDice(numberOfFaces), numberOfFaces, sizeOfBatch, numberOfTests, marginOfError, "Robin Hood Dice");

        _ = new TestingThread(new UpgradedLeastWorstDice(numberOfFaces), numberOfFaces, sizeOfBatch, numberOfTests, marginOfError, "Upgraded Least Worst Dice");

        numberOfFaces = 10;

        _ = new TestingThread(new NonRepeatingDeterministicDice(numberOfFaces), numberOfFaces, sizeOfBatch, numberOfTests, marginOfError, "Non Repeating Deterministic Dice");

        _ = new TestingThread(new RobinHoodDice(numberOfFaces), numberOfFaces, sizeOfBatch, numberOfTests, marginOfError, "Robin Hood Dice");

        _ = new TestingThread(new UpgradedLeastWorstDice(numberOfFaces), numberOfFaces, sizeOfBatch, numberOfTests, marginOfError, "Upgraded Least Worst Dice");

        numberOfFaces = 12;

        _ = new TestingThread(new NonRepeatingDeterministicDice(numberOfFaces), numberOfFaces, sizeOfBatch, numberOfTests, marginOfError, "Non Repeating Deterministic Dice");

        _ = new TestingThread(new RobinHoodDice(numberOfFaces), numberOfFaces, sizeOfBatch, numberOfTests, marginOfError, "Robin Hood Dice");

        _ = new TestingThread(new UpgradedLeastWorstDice(numberOfFaces), numberOfFaces, sizeOfBatch, numberOfTests, marginOfError, "Upgraded Least Worst Dice");

        numberOfFaces = 20;

        _ = new TestingThread(new NonRepeatingDeterministicDice(numberOfFaces), numberOfFaces, sizeOfBatch, numberOfTests, marginOfError, "Non Repeating Deterministic Dice");

        _ = new TestingThread(new RobinHoodDice(numberOfFaces), numberOfFaces, sizeOfBatch, numberOfTests, marginOfError, "Robin Hood Dice");

        _ = new TestingThread(new UpgradedLeastWorstDice(numberOfFaces), numberOfFaces, sizeOfBatch, numberOfTests, marginOfError, "Upgraded Least Worst Dice");
    }
}