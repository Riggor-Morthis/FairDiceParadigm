public class UpgradedLeastWorstDice : IDice
{
    private int numberOfFaces;
    private Random random;
    private short[] occurences;
    private int bonusDice;

    public UpgradedLeastWorstDice(int numberOfFaces)
    {
        this.numberOfFaces = numberOfFaces;
        random = new();
        occurences = new short[numberOfFaces];
        bonusDice = Math.Min(numberOfFaces / 2 - 1, 8);
    }

    public int Roll()
    {
        return GetLeastWorstRoll() + 1;
    }

    private int GetLeastWorstRoll()
    {
        int currentDie = random.Next(numberOfFaces);
        int currentOccurence = occurences[currentDie];
        List<int> previousDice = [currentDie];

        int nextDie;
        int nextOccurences;

        for (int i = 0; i < bonusDice; i++)
        {
            do
            {
                nextDie = random.Next(numberOfFaces);
            } while (previousDice.Contains(nextDie));

            previousDice.Add(nextDie);
            nextOccurences = occurences[nextDie];

            if (nextOccurences < currentOccurence)
            {
                currentOccurence = nextOccurences;
                currentDie = nextDie;
            }
        }

        CheckOccurences(currentDie);
        return currentDie;
    }

    private void CheckOccurences(int chosenDie)
    {
        occurences[chosenDie]++;

        if (occurences[chosenDie] >= short.MaxValue / 2)
        {
            for (int i = 0; i < numberOfFaces; i++)
            {
                occurences[i] = (short)Math.Min(occurences[i] - short.MaxValue / 2, -short.MaxValue / 2);
            }
            return;
        }
    }
}