public class SlowRefreshDeterministicDice : ARefreshDice
{
    public SlowRefreshDeterministicDice(int numberOfFaces) : base(numberOfFaces)
    {
    }

    protected override int GetArrayLength()
    {
        return numberOfFaces * numberOfFaces;
    }
}