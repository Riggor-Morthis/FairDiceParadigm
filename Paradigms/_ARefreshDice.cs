public abstract class ARefreshDice : IDice
{
    protected int numberOfFaces;
    protected Random random;
    protected int[] resultsArray;
    protected int arrayLength;
    protected int resultsIndex;

    public ARefreshDice(int numberOfFaces)
    {
        this.numberOfFaces = numberOfFaces;
        arrayLength = GetArrayLength();
        CreateResultsList();
        ScrambleResultsArray();
    }

    protected abstract int GetArrayLength();

    protected void CreateResultsList()
    {
        random = new();
        resultsArray = new int[arrayLength];
        int scaleFactor = arrayLength / numberOfFaces;

        for (int i = 0; i < arrayLength; i++)
        {
            resultsArray[i] = (i / scaleFactor) + 1;
        }
    }

    protected void ScrambleResultsArray()
    {
        resultsIndex = 0;

        int resultBuffer;
        int randomIndex;

        for (int i = 0; i < arrayLength; i++)
        {
            do
            {
                randomIndex = random.Next(0, arrayLength);
            } while (randomIndex == i);

            resultBuffer = resultsArray[randomIndex];
            resultsArray[randomIndex] = resultsArray[i];
            resultsArray[i] = resultBuffer;
        }
    }

    public int Roll()
    {
        int returnValue;
        if (resultsIndex == arrayLength / 2)
        {
            ScrambleResultsArray();
        }

        returnValue = resultsArray[resultsIndex];
        resultsIndex++;

        return returnValue;
    }
}