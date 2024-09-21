public class NonRepeatingDice : IDice
{
    private int numberOfFaces;
    private Random pureRandom;
    private int previousFace;

    public NonRepeatingDice(int numberOfFaces)
    {
        this.numberOfFaces = numberOfFaces;
        pureRandom = new();
        previousFace = 0;
    }

    public int Roll()
    {
        int currentFace;

        do
        {
            currentFace = (int)(pureRandom.NextInt64(numberOfFaces) + 1);
        } while (currentFace == previousFace);

        return currentFace;
    }
}