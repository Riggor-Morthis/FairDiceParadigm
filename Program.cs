public class Program
{
    public static List<TestingThread> runningThreads;


    public static void Main(string[] args)
    {
        int numberOfFaces = 6;
        int sizeOfBatch = 1;
        int numberOfTests = 1000000;
        double marginOfError = .05d;

        TestEveryDice();

        /* _ = new TestingThread(new LeastWorstDice(numberOfFaces),
                              numberOfFaces,
                              sizeOfBatch,
                              numberOfTests,
                              marginOfError,
                              "Least Worst Dice");

        _ = new TestingThread(new NonRepeatingDeterministicDice(numberOfFaces),
                              numberOfFaces,
                              sizeOfBatch,
                              numberOfTests,
                              marginOfError,
                              "Non Repeating Deterministic Dice");

        _ = new TestingThread(new NonRepeatingSelfAdjustingDice(numberOfFaces),
                              numberOfFaces,
                              sizeOfBatch,
                              numberOfTests,
                              marginOfError,
                              "Non Repeating Self Adjusting Dice");

        _ = new TestingThread(new SelfAdjustingDice(numberOfFaces),
                              numberOfFaces,
                              sizeOfBatch,
                              numberOfTests,
                              marginOfError,
                              "Self Adjusting Dice"); */
    }

    private static void TestEveryDice()
    {
        int sizeOfBatch = 1;
        int numberOfTests = 100000;
        double marginOfError = .01d;

        _ = new TestingThread(new NonRepeatingDeterministicDice(4),
                              4,
                              sizeOfBatch,
                              numberOfTests,
                              marginOfError,
                              "Non Repeating Deterministic d4");

        _ = new TestingThread(new NonRepeatingDeterministicDice(6),
                              6,
                              sizeOfBatch,
                              numberOfTests,
                              marginOfError,
                              "Non Repeating Deterministic d6");

        _ = new TestingThread(new NonRepeatingDeterministicDice(8),
                              8,
                              sizeOfBatch,
                              numberOfTests,
                              marginOfError,
                              "Non Repeating Deterministic d8");

        _ = new TestingThread(new NonRepeatingDeterministicDice(10),
                              10,
                              sizeOfBatch,
                              numberOfTests,
                              marginOfError,
                              "Non Repeating Deterministic d10");

        _ = new TestingThread(new NonRepeatingDeterministicDice(12),
                              12,
                              sizeOfBatch,
                              numberOfTests,
                              marginOfError,
                              "Non Repeating Deterministic d12");

        _ = new TestingThread(new NonRepeatingDeterministicDice(20),
                              20,
                              sizeOfBatch,
                              numberOfTests,
                              marginOfError,
                              "Non Repeating Deterministic d20");
    }

    /*         _ = new TestingThread(new SlowRefreshDeterministicDice(numberOfFaces),
                                  numberOfFaces,
                                  sizeOfBatch,
                                  numberOfTests,
                                  marginOfError,
                                  "Slow Refresh Deterministic Dice"); */
    /*         _ = new TestingThread(new PureDeterministicDice(numberOfFaces),
                                  numberOfFaces,
                                  sizeOfBatch,
                                  numberOfTests,
                                  marginOfError,
                                  "Pure Deterministic Dice"); */
    /*         _ = new TestingThread(new NonRepeatingDice(numberOfFaces),
                                  numberOfFaces,
                                  sizeOfBatch,
                                  numberOfTests,
                                  marginOfError,
                                  "Non Repeating Dice"); */
    /*         _ = new TestingThread(new FastRefreshDeterministicDice(numberOfFaces),
                                  numberOfFaces,
                                  sizeOfBatch,
                                  numberOfTests,
                                  marginOfError,
                                  "Fast Refresh Deterministic Dice"); */
}