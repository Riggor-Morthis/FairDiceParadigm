public class LeastWorstDice : IDice{
    private int numberOfFaces;
    private Random random;
    private int[] timesRolled;
    private int resetCounter;

    public LeastWorstDice(int numberOfFaces)
    {
        this.numberOfFaces = numberOfFaces;
        random = new();
    }

    private void CreateResultsList()
    {
        
        resultsArray = new int[2 * numberOfFaces];

        for (int i = 0; i < numberOfFaces; i++)
        {
            resultsArray[i] = i + 1;
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