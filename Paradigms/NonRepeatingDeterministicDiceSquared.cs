public class NonRepeatingDeterministicDiceSquared : ANonRepeatingDeterministicDice
{
    public NonRepeatingDeterministicDiceSquared(int numberOfFaces) : base(numberOfFaces)
    {
    }

    protected override void SetScaleFactor()
    {
        scaleFactor = 2;
    }
}