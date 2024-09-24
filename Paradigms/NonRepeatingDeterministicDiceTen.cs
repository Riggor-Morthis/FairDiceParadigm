public class NonRepeatingDeterministicDiceTen : ANonRepeatingDeterministicDice
{
    public NonRepeatingDeterministicDiceTen(int numberOfFaces) : base(numberOfFaces)
    {
    }

    protected override void SetScaleFactor()
    {
        scaleFactor = 10;
    }
}