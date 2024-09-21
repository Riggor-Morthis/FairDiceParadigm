public class PureDeterministicDice : IDice
{
    private int numberOfFaces;
    private ulong seed;
    private List<int> resultsList = new();

    public PureDeterministicDice(int numberOfFaces)
    {
        this.numberOfFaces = numberOfFaces;
        CreateResultsList();
    }

    private void CreateResultsList()
    {
        int[] resultsArray;

        InitializeSeed();
        InitializeArray(out resultsArray);
        ScrambleResultsArray(ref resultsArray);

        resultsList = resultsArray.ToList<int>();
    }

    private void InitializeSeed()
    {
        TimeSpan longAssTime = DateTime.UtcNow - DateTime.Today;
        seed = (ulong)longAssTime.TotalSeconds;

        while (seed < Math.Pow(10, numberOfFaces))
        {
            seed *= seed;
        }
    }

    private void InitializeArray(out int[] resultsArray)
    {
        resultsArray = new int[numberOfFaces];
        for (int i = 0; i < numberOfFaces; i++)
        {
            resultsArray[i] = i + 1;
        }
    }

    private void ScrambleResultsArray(ref int[] resultsArray)
    {
        int resultBuffer;
        int index;

        for (int i = 0; i < resultsArray.Length; i++)
        {
            index = Math.Abs((int)seed) % numberOfFaces;
            resultBuffer = resultsArray[index];
            resultsArray[index] = resultsArray[i];
            resultsArray[i] = resultBuffer;

            seed /= 100;
        }
    }

    public int Roll()
    {
        if (resultsList.Count <= 0)
        {
            CreateResultsList();
        }

        int returnValue = resultsList[0];
        resultsList.RemoveAt(0);

        return returnValue;
    }
}