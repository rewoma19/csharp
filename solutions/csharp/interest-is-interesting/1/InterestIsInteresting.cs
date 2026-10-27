static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        float intRate = 0.5f;

        if (balance < 0) {
            intRate = 3.213f;
        } else if (balance >= 1000 && balance < 5000) {
            intRate = 1.621f;
        } else if (balance >= 5000) {
            intRate = 2.475f;
        }

        return intRate;
    }

    public static decimal Interest(decimal balance)
    {
        decimal rate = (decimal)InterestRate(balance);
        decimal rateAsPercent = rate / 100m;
        return balance * rateAsPercent;
    }

    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        return balance + Interest(balance);
    }

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        int years = 0;

        while (balance < targetBalance) {
            balance = AnnualBalanceUpdate(balance);
            years++;
        }

        return years;
    }
}
