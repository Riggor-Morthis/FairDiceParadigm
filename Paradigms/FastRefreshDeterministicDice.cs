public class FastRefreshDeterministicDice : ARefreshDice
{
    public FastRefreshDeterministicDice(int numberOfFaces) : base(numberOfFaces)
    {
    }

    protected override int GetArrayLength()
    {
        return 2 * numberOfFaces;
    }
}