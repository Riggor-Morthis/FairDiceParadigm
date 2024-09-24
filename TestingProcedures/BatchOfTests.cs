public static class BatchOfTests
{
    public static bool Run(List<int> results, int numberOfFaces, double marginOfError)
    {
        double average;
        double standardDeviation;
        double[] probabilites;

        CalculateProbabilites(numberOfFaces, results, out probabilites);
        CalculateAverage(probabilites, out average);
        CalculateStandardDeviation(results, average, out standardDeviation);

        if (!TestProbabilites(probabilites, numberOfFaces, marginOfError))
        {
            return false;
        }
        if (!TestAverage(average, numberOfFaces, marginOfError))
        {
            return false;
        }
        if (!TestStandardDeviation(standardDeviation, numberOfFaces, marginOfError))
        {
            return false;
        }
        return true;
    }

    private static void CalculateProbabilites(int numberOfFaces, List<int> results, out double[] probabilites)
    {
        probabilites = new double[numberOfFaces];

        foreach (int result in results)
        {

            probabilites[result - 1]++;

        }
        for (int i = 0; i < probabilites.Length; i++)
        {
            probabilites[i] /= results.Count;
        }
    }

    private static void CalculateAverage(double[] probabilites, out double average)
    {
        average = 0;
        for (int i = 0; i < probabilites.Length; i++)
        {
            average += (i + 1) * probabilites[i];
        }
    }

    private static void CalculateStandardDeviation(List<int> results, double average, out double standardDeviation)
    {
        double variance = 0;
        foreach (int result in results)
        {
            variance += Math.Pow(result - average, 2);
        }
        variance /= results.Count;
        standardDeviation = Math.Sqrt(variance);
    }

    private static bool TestProbabilites(double[] probabilites, int numberOfFaces, double marginOfError)
    {
        double idealProbability = 1d / numberOfFaces;
        double minimumProbability = idealProbability * CreateMinValue(marginOfError);
        double maximumProbability = idealProbability * CreateMaxValue(marginOfError);

        foreach (double probability in probabilites)
        {
            if (probability > maximumProbability || probability < minimumProbability)
            {
                return false;
            }
        }

        return true;
    }

    private static bool TestAverage(double average, int numberOfFaces, double marginOfError)
    {
        double idealAverage = (numberOfFaces + 1d) / 2d;
        double minimumAverage = idealAverage * CreateMinValue(marginOfError);
        double maximumAverage = idealAverage * CreateMaxValue(marginOfError);

        if (average > maximumAverage || average < minimumAverage)
        {
            return false;
        }

        return true;
    }

    private static bool TestStandardDeviation(double standardDeviation, int numberOfFaces, double marginOfError)
    {
        double idealStandardDeviation = CreateIdealStandardDeviation(numberOfFaces);
        double minimumStandardDeviation = idealStandardDeviation * CreateMinValue(marginOfError);
        double maximumStandardDeviation = idealStandardDeviation * CreateMaxValue(marginOfError);

        if (standardDeviation > maximumStandardDeviation || standardDeviation < minimumStandardDeviation)
        {
            return false;
        }

        return true;
    }

    private static double CreateMinValue(double marginOfError)
    {
        return 1d - marginOfError;
    }

    private static double CreateMaxValue(double marginOfError)
    {
        return 1d + marginOfError;
    }

    private static double CreateIdealStandardDeviation(int numberOfFaces)
    {
        double average = (numberOfFaces + 1d) / 2d;
        double variance = 0;

        for (int i = 1; i <= numberOfFaces; i++)
        {
            variance += Math.Pow(i - average, 2);
        }
        variance /= numberOfFaces;

        return Math.Sqrt(variance);
    }
}