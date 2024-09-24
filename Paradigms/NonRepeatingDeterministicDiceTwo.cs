public class NonRepeatingDeterministicDiceTwo : ANonRepeatingDeterministicDice
{
    public NonRepeatingDeterministicDiceTwo(int numberOfFaces) : base(numberOfFaces)
    {
    }

    protected override void SetScaleFactor()
    {
        scaleFactor = numberOfFaces * numberOfFaces;
    }
}