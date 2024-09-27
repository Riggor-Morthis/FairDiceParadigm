public class SelfAdjustingDice : IDice
{
    private int numberOfFaces;
    private Random random;
    private double[] faceProbabilities;

    public SelfAdjustingDice(int numberOfFaces)
    {
        this.numberOfFaces = numberOfFaces;
        random = new();

        InitializeProbabilites();
    }

    private void InitializeProbabilites()
    {
        faceProbabilities = new double[numberOfFaces];

        for (int i = 0; i < faceProbabilities.Length; i++)
        {
            faceProbabilities[i] = 1d / numberOfFaces;
        }
    }

    public int Roll()
    {
        int rolledFace = FindRolledFace();
        ReadjustProbabilites(rolledFace);

        return rolledFace + 1;
    }

    private int FindRolledFace()
    {
        double randomResult = random.NextDouble();

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

        return 0;
    }

    private void ReadjustProbabilites(int rolledFace)
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