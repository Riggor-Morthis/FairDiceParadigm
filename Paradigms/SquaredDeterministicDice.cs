public class SquaredDeterministicDice : IDice
{
    private int numberOfFaces;
    private Random random;
    private int[] resultsArray;
    private int resultsIndex;

    public SquaredDeterministicDice(int numberOfFaces)
    {
        this.numberOfFaces = numberOfFaces;
        CreateResultsList();
        ScrambleResultsArray();
    }

    private void CreateResultsList()
    {
        random = new();
        resultsArray = new int[numberOfFaces * numberOfFaces];

        for (int i = 0; i < numberOfFaces; i++)
        {
            for (int j = 0; j < numberOfFaces; j++)
            {
                resultsArray[i * numberOfFaces + j] = i + 1;
            }
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