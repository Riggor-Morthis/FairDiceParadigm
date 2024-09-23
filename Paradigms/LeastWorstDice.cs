public class LeastWorstDice : IDice
{
    private int numberOfFaces;
    private Random random;
    private short[] occurences;

    public LeastWorstDice(int numberOfFaces)
    {
        this.numberOfFaces = numberOfFaces;
        random = new();
        occurences = new short[numberOfFaces];
    }

    public int Roll()
    {
        return GetLeastWorstRoll() + 1;
    }

    private int GetLeastWorstRoll()
    {
        int diceOne = random.Next(numberOfFaces);
        int diceTwo = random.Next(numberOfFaces);

        int diceOneOccurences = occurences[diceOne];
        int diceTwoOccurences = occurences[diceTwo];

        if (diceOneOccurences < diceTwoOccurences)
        {
            ResetOccurences(diceTwo);
            occurences[diceOne]++;
            return diceOne;
        }
        else
        {
            ResetOccurences(diceOne);
            occurences[diceTwo]++;
            return diceTwo;
        }
    }

    private void ResetOccurences(int index)
    {
        if (occurences[index] >= short.MaxValue / 2)
        {
            for (int i = 0; i < numberOfFaces; i++)
            {
                occurences[i] = (short)Math.Min(occurences[i] - short.MaxValue / 2, -short.MaxValue / 2);
            }
        }
    }
}