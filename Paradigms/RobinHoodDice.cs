public class RobinHoodDice : IDice
{
    private int numberOfFaces;
    private Random random;

    private double numberOfTransactions;
    private double[] individualAccounts;
    private double idealBalance;

    public RobinHoodDice(int numberOfFaces)
    {
        this.numberOfFaces = numberOfFaces;
        random = new();
        CreateAccounts();
    }

    private void CreateAccounts()
    {
        numberOfTransactions = numberOfFaces;
        individualAccounts = new double[numberOfFaces];

        for (int i = 0; i < numberOfFaces; i++)
        {
            individualAccounts[i] = 1;
        }

        idealBalance = 1d / numberOfFaces;
    }

    public int Roll()
    {
        return RollFromAccount();
    }

    private int RollFromAccount()
    {
        double[] rebalancedAccounts = GetRebalancedAccounts();
        double randomAccountNumber = random.NextDouble();

        for (int i = 0; i < rebalancedAccounts.Length; i++)
        {
            if (rebalancedAccounts[i] < randomAccountNumber)
            {
                randomAccountNumber -= rebalancedAccounts[i];
            }
            else
            {
                return Withdraw(i);
            }
        }

        return Withdraw(1);
    }

    private double[] GetRebalancedAccounts()
    {
        List<int> plebs = new();
        double[] newBankAccounts = new double[numberOfFaces];

        double robinHoodFund = 0;

        StealFromTheRich(ref newBankAccounts, ref plebs, ref robinHoodFund);

        return GiveToThePoor(robinHoodFund, plebs, newBankAccounts);
    }

    private void StealFromTheRich(ref double[] newBankAccounts, ref List<int> plebs, ref double robinHoodFund)
    {
        double currentBalance;

        for (int i = 0; i < numberOfFaces; i++)
        {
            currentBalance = individualAccounts[i] / numberOfTransactions;

            if (currentBalance < idealBalance)
            {
                plebs.Add(i);
            }
            else
            {
                newBankAccounts[i] = currentBalance - (idealBalance / 2);
                robinHoodFund += idealBalance / 2;
            }
        }
    }

    private double[] GiveToThePoor(double robinHoodFund, List<int> plebs, double[] newBankAccounts)
    {
        if (robinHoodFund > 0)
        {
            foreach (int pleb in plebs)
            {
                newBankAccounts[pleb] = idealBalance + (robinHoodFund / plebs.Count);
            }
        }

        return newBankAccounts;
    }

    private int Withdraw(int accountNumber)
    {
        numberOfTransactions++;
        individualAccounts[accountNumber]++;

        return accountNumber + 1;
    }
}