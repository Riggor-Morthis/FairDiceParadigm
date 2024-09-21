public class NonRepeatingSelfAdjustingDice : IDice
{
    private int numberOfFaces;
    private Random pureRandom;
    private double[] faceProbabilities;

    public NonRepeatingSelfAdjustingDice(int numberOfFaces)
    {
        this.numberOfFaces = numberOfFaces;
        pureRandom = new();
        faceProbabilities = new double[numberOfFaces];
        for (int i = 0; i < faceProbabilities.Length; i++)
        {
            faceProbabilities[i] = 1d / numberOfFaces;
        }
    }

    public int Roll()
    {
        int rolledFAce = FindRolledFace();
        ReadjustProbabilites(rolledFAce);

        return (int)(pureRandom.NextInt64(numberOfFaces) + 1);
    }

    private int FindRolledFace()
    {
        double randomResult = pureRandom.NextDouble();
        for (int i = 0; i < faceProbabilities.Length; i++)
        {
            if (randomResult < faceProbabilities[i])
            {
                return i;
            }
            else
            {
                randomResult -= faceProbabilities[i];
            }
        }

        return 1;
    }

    private void ReadjustProbabilites(int rolledFace)
    {
        double previousRolledFaceProbability = faceProbabilities[rolledFace];
        faceProbabilities[rolledFace] = 0;

        for (int i = 0; i < faceProbabilities.Length; i++)
        {
            if(i != rolledFace){
                faceProbabilities[i] += previousRolledFaceProbability / (numberOfFaces - 1d);
            }
        }
    }
}