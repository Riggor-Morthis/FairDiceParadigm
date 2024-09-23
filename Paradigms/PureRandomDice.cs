public class PureRandomDice : IDice
{
    private int numberOfFaces;
    private Random random;

    public PureRandomDice(int numberOfFaces)
    {
        this.numberOfFaces = numberOfFaces;
        random = new();
    }

    public int Roll()
    {
        return random.Next(numberOfFaces) + 1;
    }
}