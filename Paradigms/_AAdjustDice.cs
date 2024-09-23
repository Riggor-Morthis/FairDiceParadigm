public abstract class AAdjustDice : IDice
{
    protected int numberOfFaces;
    protected Random random;
    protected double[] faceProbabilities;

    public AAdjustDice(int numberOfFaces)
    {
        this.numberOfFaces = numberOfFaces;
        random = new();

        InitializeProbabilites();
    }

    protected void InitializeProbabilites()
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

    protected int FindRolledFace()
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

    protected abstract void ReadjustProbabilites(int rolledFace);
}