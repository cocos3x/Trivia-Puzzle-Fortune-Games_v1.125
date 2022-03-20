using UnityEngine;
public class SeasonPassEcon : ScriptableObject
{
    // Fields
    public const int AWARDS_PER_TIER = 10;
    public const int TOTAL_CHEST_AWARDS = 3;
    public const int TOTAL_AWARDS = 30;
    public int TotalTiers;
    public int BronzeTierLevels;
    public int SilverTierLevels;
    public int GoldTierLevels;
    public int ChestCoins;
    public int ChestCards;
    public int ChestApples;
    public int PassHintDiscount;
    public int PassPickerHintDiscount;
    public System.Collections.Generic.List<SeasonPassEcon.Tier> tiers;
    
    // Methods
    public SeasonPassEcon()
    {
        this.TotalTiers = ;
        this.BronzeTierLevels = ;
        this.SilverTierLevels = 85899345932;
        this.GoldTierLevels = 20;
        this.ChestCoins = ;
        this.ChestCards = ;
        this.ChestApples = 21474836520;
        this.PassHintDiscount = 5;
        this.PassPickerHintDiscount = 25;
    }

}
