public class PureRandomDice : IDice
{
    private int numberOfFaces;
    private Random pureRandom;

    public PureRandomDice(int numberOfFaces)
    {
        this.numberOfFaces = numberOfFaces;
        pureRandom = new();
    }

    public int Roll()
    {
        return (int)(pureRandom.NextInt64(numberOfFaces) + 1);
    }
}