using UnityEngine;
public class PiggyBankV2Econ
{
    // Fields
    private int[] packagePrices;
    private int[] goldCurrencyNeeded;
    private int[] minBankFund;
    private int[] maxBankFund;
    private string[] packageTierIDs;
    public const int playerSpendLow = 399;
    public const int playerSpendMid = 899;
    public const int playerSpendHigh = 1499;
    
    // Properties
    public int[] PackagePrices { get; }
    public int[] GoldCurrencyNeeded { get; }
    public int[] MinBankFund { get; }
    public int[] MaxBankFund { get; }
    public string[] PackageTierIDs { get; }
    
    // Methods
    public int[] get_PackagePrices()
    {
        return (System.Int32[])this.packagePrices;
    }
    public int[] get_GoldCurrencyNeeded()
    {
        return (System.Int32[])this.goldCurrencyNeeded;
    }
    public int[] get_MinBankFund()
    {
        return (System.Int32[])this.minBankFund;
    }
    public int[] get_MaxBankFund()
    {
        return (System.Int32[])this.maxBankFund;
    }
    public string[] get_PackageTierIDs()
    {
        return (System.String[])this.packageTierIDs;
    }
    public PiggyBankV2Econ()
    {
        int val_6;
        this.packagePrices = new int[6] {99, 299, 499, 999, 1999, 2499};
        this.goldCurrencyNeeded = new int[6] {285, 861, 1437, 2877, 5757, 7197};
        this.minBankFund = new int[6] {190, 574, 958, 1918, 3838, 4798};
        this.maxBankFund = new int[6] {475, 1435, 2395, 4795, 9595, 11995};
        string[] val_5 = new string[6];
        val_6 = val_5.Length;
        val_5[0] = "id_piggy_bank_tier0";
        val_6 = val_5.Length;
        val_5[1] = "id_piggy_bank_tier1";
        val_6 = val_5.Length;
        val_5[2] = "id_piggy_bank_tier2";
        val_6 = val_5.Length;
        val_5[3] = "id_piggy_bank_tier3";
        val_6 = val_5.Length;
        val_5[4] = "id_piggy_bank_tier4";
        val_6 = val_5.Length;
        val_5[5] = "id_piggy_bank_tier5";
        this.packageTierIDs = val_5;
    }

}
