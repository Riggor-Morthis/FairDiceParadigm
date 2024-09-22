public class SlowRefreshDeterministicDice : IDice
{
    private int numberOfFaces;
    private Random random;
    private int[] resultsArray;
    private int resultsIndex;

    public SlowRefreshDeterministicDice(int numberOfFaces)
    {
        this.numberOfFaces = numberOfFaces;
        CreateResultsList();
        ScrambleResultsArray();
    }

    private void CreateResultsList()
    {
        random = new();
        resultsArray = new int[2 * numberOfFaces];

        for (int i = 0; i < 2 * numberOfFaces; i++)
        {
            resultsArray[i] = (i / 2) + 1;
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
                randomIndex = random.Next(0, numberOfFaces);
            } while (randomIndex == i);
            resultBuffer = resultsArray[randomIndex];
            resultsArray[randomIndex] = resultsArray[i];
            resultsArray[i] = resultBuffer;
        }
    }

    public int Roll()
    {
        int returnValue;
        if (resultsIndex == numberOfFaces)
        {
            ScrambleResultsArray();
        }

        returnValue = resultsArray[resultsIndex];
        resultsIndex++;

        return returnValue;
    }
}