public class NonRepeatingDeterministicDice : IDice
{
    private int numberOfFaces;
    private Random random;
    private int[] plannedRolls;
    private int currentPlannedIndex;

    public NonRepeatingDeterministicDice(int numberOfFaces)
    {
        this.numberOfFaces = numberOfFaces;
        random = new();
        GeneratePlannedRollsArray();
    }

    private void CreatePlannedRolls()
    {
        plannedRolls = new int[10 * numberOfFaces];

        for (int i = 0; i < plannedRolls.Length; i++)
        {
            plannedRolls[i] = (i / 10) + 1;
        }
    }

    private void GeneratePlannedRollsArray()
    {
        bool isFullyScrambled;
        int randomIndex;
        int swapBuffer;

        CreatePlannedRolls();
        currentPlannedIndex = 0;

        do
        {
            isFullyScrambled = true;

            for (int i = 0; i < plannedRolls.Length - 1; i++)
            {
                if (plannedRolls[i] == plannedRolls[i + 1])
                {
                    if (isFullyScrambled)
                    {
                        isFullyScrambled = false;
                    }

                    do
                    {
                        randomIndex = random.Next(plannedRolls.Length);
                    } while (randomIndex == i || randomIndex == i + 1);
                    swapBuffer = plannedRolls[i];
                    plannedRolls[i] = plannedRolls[randomIndex];
                    plannedRolls[randomIndex] = swapBuffer;
                }
            }
        } while (!isFullyScrambled);

    }

    public int Roll()
    {
        if (currentPlannedIndex == plannedRolls.Length)
        {
            GeneratePlannedRollsArray();
        }

        int returnValue = plannedRolls[currentPlannedIndex];
        currentPlannedIndex++;

        return returnValue;
    }
}