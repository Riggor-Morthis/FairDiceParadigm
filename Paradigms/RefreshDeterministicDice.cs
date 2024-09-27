public class RefreshDeterministicDice : IDice
{
    private int numberOfFaces;
    private Random random;
    private int[] resultsArray;
    private int resultsIndex;
    private int refreshPoint;

    public RefreshDeterministicDice(int numberOfFaces)
    {
        this.numberOfFaces = numberOfFaces;
        CreateResultsList();
        ScrambleResultsArray();
    }

    private void CreateResultsList()
    {
        random = new();
        resultsArray = new int[numberOfFaces];
        refreshPoint = (int)(numberOfFaces * .75f) - 1;

        for (int i = 0; i < resultsArray.Length; i++)
        {
            resultsArray[i] = i + 1;
        }
    }

    private void ScrambleResultsArray()
    {
        resultsIndex = 0;

        int resultBuffer;
        int randomIndex;

        for (int i = 0; i < resultsArray.Length; i++)
        {
            do
            {
                randomIndex = random.Next(0, resultsArray.Length);
            } while (randomIndex == i);

            resultBuffer = resultsArray[randomIndex];
            resultsArray[randomIndex] = resultsArray[i];
            resultsArray[i] = resultBuffer;
        }
    }

    public int Roll()
    {
        int returnValue;
        if (resultsIndex == refreshPoint)
        {
            ScrambleResultsArray();
        }

        returnValue = resultsArray[resultsIndex];
        resultsIndex++;

        return returnValue;
    }
}