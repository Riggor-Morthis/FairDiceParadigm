public class PureDeterministicDice : IDice
{
    private int numberOfFaces;
    private Random random;
    private int[] resultsArray;
    private int resultsIndex;

    public PureDeterministicDice(int numberOfFaces)
    {
        this.numberOfFaces = numberOfFaces;
        CreateResultsList();
        ScrambleResultsArray();
    }

    private void CreateResultsList()
    {
        random = new();
        resultsArray = new int[numberOfFaces];

        for (int i = 0; i < numberOfFaces; i++)
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
            randomIndex = random.Next(numberOfFaces);

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