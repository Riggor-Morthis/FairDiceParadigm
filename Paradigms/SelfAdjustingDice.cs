public class SelfAdjustingDice : AAdjustDice
{
    public SelfAdjustingDice(int numberOfFaces) : base(numberOfFaces)
    {
    }

    protected override void ReadjustProbabilites(int rolledFace)
    {
        double previousRolledFaceProbability = faceProbabilities[rolledFace];
        faceProbabilities[rolledFace] = 0;

        for (int i = 0; i < faceProbabilities.Length; i++)
        {
            faceProbabilities[i] += previousRolledFaceProbability / numberOfFaces;
        }
    }
}