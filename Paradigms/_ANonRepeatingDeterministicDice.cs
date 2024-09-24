public abstract class ANonRepeatingDeterministicDice : IDice
{
    protected int numberOfFaces;
    protected Random random;
    protected int[] plannedRolls;
    protected int currentPlannedIndex;
    protected int scaleFactor;

    public ANonRepeatingDeterministicDice(int numberOfFaces)
    {
        this.numberOfFaces = numberOfFaces;
        random = new();
        SetScaleFactor();
        CreatePlannedRolls();
        GeneratePlannedRollsArray();
    }

    protected abstract void SetScaleFactor();

    protected void CreatePlannedRolls()
    {
        plannedRolls = new int[scaleFactor * numberOfFaces];

        for (int i = 0; i < plannedRolls.Length; i++)
        {
            plannedRolls[i] = (i / scaleFactor) + 1;
        }
    }

    protected void GeneratePlannedRollsArray()
    {
        bool isFullyScrambled;
        int randomIndex;
        int swapBuffer;

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