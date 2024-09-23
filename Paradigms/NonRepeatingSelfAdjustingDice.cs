public class NonRepeatingSelfAdjustingDice : AAdjustDice
{
    public NonRepeatingSelfAdjustingDice(int numberOfFaces) : base(numberOfFaces)
    {
    }

    protected override void ReadjustProbabilites(int rolledFace)
    {
        double previousRolledFaceProbability = faceProbabilities[rolledFace];
        faceProbabilities[rolledFace] = 0;

        for (int i = 0; i < faceProbabilities.Length; i++)
        {
            if (i != rolledFace)
            {
                faceProbabilities[i] += previousRolledFaceProbability / (numberOfFaces - 1d);
            }
        }
    }
}