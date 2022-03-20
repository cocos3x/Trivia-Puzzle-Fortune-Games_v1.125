using UnityEngine;
public class TournamentsEconomy : MonoBehaviour
{
    // Fields
    public static int TournamentUnlockLevel;
    public static int TournamentLengthHours;
    public static int TopPromotionsCount;
    public static int BottomDemotionsCount;
    public static int PlayersInTournament;
    public static string[] TierNames;
    public static System.Collections.Generic.List<string> TierTextHexColors;
    private static System.Collections.Generic.Dictionary<int, int> TierToHexColorIndex;
    public static int[] rewardIndexByRank;
    public static int[] promotionByRankGroup;
    public static string[] rankGroupStrings;
    public static int[][] coinRewardsByTier;
    private static int[][] gemRewardsByTier;
    private static int[][] petFoodRewardsByTier;
    public static int[][] giftRewardsByTier;
    
    // Properties
    public static int[][] gemOrPetFoodRewardsByTier { get; }
    
    // Methods
    public static string GetLocalizedTierNameForTierName(string tierName)
    {
        var val_5 = mem[public static T[] System.Array::Empty<System.Char>().__il2cppRuntimeField_30 + 302];
        val_5 = public static T[] System.Array::Empty<System.Char>().__il2cppRuntimeField_30 + 302;
        val_5 = mem[public static T[] System.Array::Empty<System.Char>().__il2cppRuntimeField_30 + 302];
        val_5 = public static T[] System.Array::Empty<System.Char>().__il2cppRuntimeField_30 + 302;
        string val_5 = tierName.Split(separator:  public static T[] System.Array::Empty<System.Char>().__il2cppRuntimeField_30 + 184)[0];
        return tierName.Replace(oldValue:  val_5, newValue:  Localization.Localize(key:  val_5.ToLower() + "_upper", defaultValue:  val_5, useSingularKey:  false));
    }
    public static int[][] get_gemOrPetFoodRewardsByTier()
    {
        var val_1;
        var val_2;
        var val_3;
        var val_4;
        var val_5;
        val_1 = null;
        val_1 = null;
        val_2 = null;
        if(App.game == 17)
        {
                val_3 = null;
            val_4 = 1152921504900833360;
            return (System.Int32[][])val_4;
        }
        
        val_5 = null;
        val_4 = 1152921504900833368;
        return (System.Int32[][])val_4;
    }
    public static string GetHexColorForTier(int tierIndex)
    {
        null = null;
        int val_1 = TournamentsEconomy.TierToHexColorIndex.Item[tierIndex];
        if((TournamentsEconomy.TierTextHexColors + 24) <= val_1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_2 = TournamentsEconomy.TierTextHexColors + 16;
        val_2 = val_2 + (val_1 << 3);
        return (string)(TournamentsEconomy.TierTextHexColors + 16 + (val_1) << 3) + 32;
    }
    public static string GetFormattedColorizedTierName(int tierIndex)
    {
        System.String[] val_4 = TournamentsEconomy.TierNames;
        val_4 = val_4 + (tierIndex << 3);
        return System.String.Format(format:  "<color=#{0}>{1}</color>", arg0:  TournamentsEconomy.GetHexColorForTier(tierIndex:  tierIndex), arg1:  TournamentsEconomy.GetLocalizedTierNameForTierName(tierName:  (TournamentsEconomy.TierNames + (tierIndex) << 3) + 32).ToUpper());
    }
    public static bool RankIndexIsPromotion(int rankIndex)
    {
        null = null;
        return (bool)(TournamentsEconomy.TopPromotionsCount > rankIndex) ? 1 : 0;
    }
    public static bool RankIndexIsDemotion(int rankIndex)
    {
        null = null;
        int val_2 = TournamentsEconomy.PlayersInTournament;
        val_2 = val_2 - TournamentsEconomy.BottomDemotionsCount;
        return (bool)(val_2 <= rankIndex) ? 1 : 0;
    }
    public static bool TierIndexCanPromote(int tierIndex)
    {
        return (bool)(tierIndex != 0) ? 1 : 0;
    }
    public static bool TierIndexCanDemote(int tierIndex)
    {
        null = null;
        int val_2 = TournamentsEconomy.TierNames.Length;
        val_2 = val_2 - 1;
        return (bool)(val_2 > tierIndex) ? 1 : 0;
    }
    public TournamentsEconomy()
    {
    
    }
    private static TournamentsEconomy()
    {
        var val_92;
        int val_93;
        int val_94;
        val_92 = 20;
        TournamentsEconomy.TournamentUnlockLevel = 50;
        TournamentsEconomy.TournamentLengthHours = 48;
        TournamentsEconomy.TopPromotionsCount = 10;
        TournamentsEconomy.BottomDemotionsCount = 20;
        TournamentsEconomy.PlayersInTournament = 50;
        string[] val_1 = new string[20];
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_93 = val_1.Length;
        if(val_93 == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_1[0] = "Master";
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_93 = val_1.Length;
        if(val_93 <= 1)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_1[1] = "Diamond I";
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_93 = val_1.Length;
        if(val_93 <= 2)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_1[2] = "Diamond II";
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_93 = val_1.Length;
        if(val_93 <= 3)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_1[3] = "Platinum I";
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_93 = val_1.Length;
        if(val_93 <= 4)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_1[4] = "Platinum II";
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_93 = val_1.Length;
        if(val_93 <= 5)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_1[5] = "Gold I";
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_93 = val_1.Length;
        if(val_93 <= 6)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_1[6] = "Gold II";
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_93 = val_1.Length;
        if(val_93 <= 7)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_1[7] = "Gold III";
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_93 = val_1.Length;
        if(val_93 <= 8)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_1[8] = "Silver I";
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_93 = val_1.Length;
        if(val_93 <= 9)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_1[9] = "Silver II";
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_93 = val_1.Length;
        if(val_93 <= 10)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_1[10] = "Silver III";
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_93 = val_1.Length;
        if(val_93 <= 11)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_1[11] = "Silver IV";
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_93 = val_1.Length;
        if(val_93 <= 12)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_1[12] = "Silver V";
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_93 = val_1.Length;
        if(val_93 <= 13)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_1[13] = "Bronze I";
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_93 = val_1.Length;
        if(val_93 <= 14)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_1[14] = "Bronze II";
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_93 = val_1.Length;
        if(val_93 <= 15)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_1[15] = "Bronze III";
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_93 = val_1.Length;
        if(val_93 <= 16)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_1[16] = "Bronze IV";
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_93 = val_1.Length;
        if(val_93 <= 17)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_1[17] = "Bronze V";
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_93 = val_1.Length;
        if(val_93 <= 18)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_1[18] = "Bronze VI";
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_93 = val_1.Length;
        if(val_93 <= 19)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_1[19] = "Bronze VII";
        TournamentsEconomy.TierNames = val_1;
        System.Collections.Generic.List<System.String> val_2 = null;
        val_92 = public System.Void System.Collections.Generic.List<System.String>::.ctor();
        val_2 = new System.Collections.Generic.List<System.String>();
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        val_2.Add(item:  "FFDA58");
        val_2.Add(item:  "BCEBF7");
        val_2.Add(item:  "B8B5D1");
        val_2.Add(item:  "F5DA45");
        val_2.Add(item:  "C4C1C1");
        val_2.Add(item:  "F67C3A");
        TournamentsEconomy.TierTextHexColors = val_2;
        System.Collections.Generic.Dictionary<System.Int32, System.Int32> val_3 = null;
        val_92 = public System.Void System.Collections.Generic.Dictionary<System.Int32, System.Int32>::.ctor();
        val_3 = new System.Collections.Generic.Dictionary<System.Int32, System.Int32>();
        if(val_3 == null)
        {
                throw new NullReferenceException();
        }
        
        val_3.Add(key:  0, value:  0);
        val_3.Add(key:  1, value:  1);
        val_3.Add(key:  2, value:  1);
        val_3.Add(key:  3, value:  2);
        val_3.Add(key:  4, value:  2);
        val_3.Add(key:  5, value:  3);
        val_3.Add(key:  6, value:  3);
        val_3.Add(key:  7, value:  3);
        val_3.Add(key:  8, value:  3);
        val_3.Add(key:  9, value:  4);
        val_3.Add(key:  10, value:  4);
        val_3.Add(key:  11, value:  4);
        val_3.Add(key:  12, value:  4);
        val_3.Add(key:  13, value:  5);
        val_3.Add(key:  14, value:  5);
        val_3.Add(key:  15, value:  5);
        val_3.Add(key:  16, value:  5);
        val_3.Add(key:  17, value:  5);
        val_3.Add(key:  18, value:  5);
        val_3.Add(key:  19, value:  5);
        TournamentsEconomy.TierToHexColorIndex = val_3;
        TournamentsEconomy.rewardIndexByRank = new int[51] {0, 0, 1, 2, 3, 3, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7};
        val_92 = 8;
        TournamentsEconomy.promotionByRankGroup = new int[8] {1, 1, 1, 1, 1, 0, 0, -1};
        string[] val_6 = new string[8];
        if(val_6 == null)
        {
                throw new NullReferenceException();
        }
        
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_94 = val_6.Length;
        if(val_94 == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_6[0] = "1";
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_94 = val_6.Length;
        if(val_94 <= 1)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_6[1] = "2";
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_94 = val_6.Length;
        if(val_94 <= 2)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_6[2] = "3";
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_94 = val_6.Length;
        if(val_94 <= 3)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_6[3] = "4-5";
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_94 = val_6.Length;
        if(val_94 <= 4)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_6[4] = "6-10";
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_94 = val_6.Length;
        if(val_94 <= 5)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_6[5] = "11-20";
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_94 = val_6.Length;
        if(val_94 <= 6)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_6[6] = "21-30";
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        val_94 = val_6.Length;
        if(val_94 <= 7)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_6[7] = "31-50";
        TournamentsEconomy.rankGroupStrings = val_6;
        System.Int32[][] val_7 = new System.Int32[][20];
        int[] val_8 = new int[8] {500, 250, 125, 50, 25, 10, 0, 0};
        val_92 = System.Byte[];
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_8 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_7.Length == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_7[0] = val_8;
        int[] val_9 = new int[8] {250, 125, 80, 40, 20, 5, 0, 0};
        if(val_9 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_7.Length <= 1)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_7[1] = val_9;
        int[] val_10 = new int[8] {200, 100, 50, 25, 15, 5, 0, 0};
        if(val_10 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_7.Length <= 2)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_7[2] = val_10;
        int[] val_11 = new int[8] {120, 60, 30, 20, 10, 5, 0, 0};
        if(val_11 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_7.Length <= 3)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_7[3] = val_11;
        int[] val_12 = new int[8] {120, 60, 30, 20, 10, 5, 0, 0};
        if(val_12 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_7.Length <= 4)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_7[4] = val_12;
        int[] val_13 = new int[8] {100, 50, 25, 20, 10, 5, 0, 0};
        if(val_13 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_7.Length <= 5)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_7[5] = val_13;
        int[] val_14 = new int[8] {100, 50, 25, 20, 10, 5, 0, 0};
        if(val_14 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_7.Length <= 6)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_7[6] = val_14;
        int[] val_15 = new int[8] {100, 50, 25, 20, 10, 5, 0, 0};
        if(val_15 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_7.Length <= 7)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_7[7] = val_15;
        int[] val_16 = new int[8] {50, 25, 15, 7, 5, 0, 0, 0};
        if(val_16 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_7.Length <= 8)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_7[8] = val_16;
        int[] val_17 = new int[8] {50, 25, 15, 7, 5, 0, 0, 0};
        if(val_17 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_7.Length <= 9)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_7[9] = val_17;
        int[] val_18 = new int[8] {50, 25, 15, 7, 5, 0, 0, 0};
        if(val_18 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_7.Length <= 10)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_7[10] = val_18;
        int[] val_19 = new int[8] {25, 15, 10, 5, 3, 0, 0, 0};
        if(val_19 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_7.Length <= 11)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_7[11] = val_19;
        int[] val_20 = new int[8] {25, 15, 10, 5, 3, 0, 0, 0};
        if(val_20 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_7.Length <= 12)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_7[12] = val_20;
        int[] val_21 = new int[8] {15, 10, 5, 3, 0, 0, 0, 0};
        if(val_21 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_7.Length <= 13)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_7[13] = val_21;
        int[] val_22 = new int[8] {15, 10, 5, 3, 0, 0, 0, 0};
        if(val_22 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_7.Length <= 14)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_7[14] = val_22;
        int[] val_23 = new int[8] {15, 10, 5, 3, 0, 0, 0, 0};
        if(val_23 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_7.Length <= 15)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_7[15] = val_23;
        int[] val_24 = new int[8] {10, 5, 3, 1, 0, 0, 0, 0};
        if(val_24 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_7.Length <= 16)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_7[16] = val_24;
        int[] val_25 = new int[8] {10, 5, 3, 1, 0, 0, 0, 0};
        if(val_25 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_7.Length <= 17)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_7[17] = val_25;
        val_92 = 8;
        int[] val_26 = new int[8];
        if(val_26 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_26.Length == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_26[0] = 10;
        if(val_26.Length == 1)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_26[0] = 5;
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        if(val_7.Length <= 18)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_7[18] = val_26;
        val_92 = 8;
        int[] val_27 = new int[8];
        if(val_27 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_27.Length == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_27[0] = 10;
        if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        if(val_7.Length <= 19)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_7[19] = val_27;
        TournamentsEconomy.coinRewardsByTier = val_7;
        System.Int32[][] val_28 = new System.Int32[][20];
        int[] val_29 = new int[8] {250, 125, 75, 35, 25, 15, 0, 0};
        val_92 = System.Byte[];
        if(val_28 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_29 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_28.Length == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_28[0] = val_29;
        int[] val_30 = new int[8] {200, 100, 50, 25, 10, 5, 0, 0};
        if(val_30 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_28.Length <= 1)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_28[1] = val_30;
        int[] val_31 = new int[8] {200, 100, 50, 25, 10, 5, 0, 0};
        if(val_31 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_28.Length <= 2)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_28[2] = val_31;
        int[] val_32 = new int[8] {150, 75, 35, 15, 10, 5, 0, 0};
        if(val_32 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_28.Length <= 3)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_28[3] = val_32;
        int[] val_33 = new int[8] {150, 75, 35, 15, 10, 5, 0, 0};
        if(val_33 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_28.Length <= 4)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_28[4] = val_33;
        int[] val_34 = new int[8] {100, 50, 25, 15, 10, 5, 0, 0};
        if(val_34 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_28.Length <= 5)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_28[5] = val_34;
        int[] val_35 = new int[8] {100, 50, 25, 15, 10, 5, 0, 0};
        if(val_35 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_28.Length <= 6)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_28[6] = val_35;
        int[] val_36 = new int[8] {100, 50, 25, 15, 10, 5, 0, 0};
        if(val_36 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_28.Length <= 7)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_28[7] = val_36;
        int[] val_37 = new int[8] {50, 25, 15, 10, 5, 3, 0, 0};
        if(val_37 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_28.Length <= 8)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_28[8] = val_37;
        int[] val_38 = new int[8] {50, 25, 15, 10, 5, 3, 0, 0};
        if(val_38 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_28.Length <= 9)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_28[9] = val_38;
        int[] val_39 = new int[8] {50, 25, 15, 10, 5, 3, 0, 0};
        if(val_39 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_28.Length <= 10)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_28[10] = val_39;
        int[] val_40 = new int[8] {25, 15, 10, 5, 3, 1, 0, 0};
        if(val_40 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_28.Length <= 11)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_28[11] = val_40;
        int[] val_41 = new int[8] {25, 15, 10, 5, 3, 1, 0, 0};
        if(val_41 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_28.Length <= 12)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_28[12] = val_41;
        int[] val_42 = new int[8] {15, 10, 5, 3, 1, 0, 0, 0};
        if(val_42 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_28.Length <= 13)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_28[13] = val_42;
        int[] val_43 = new int[8] {15, 10, 5, 3, 1, 0, 0, 0};
        if(val_43 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_28.Length <= 14)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_28[14] = val_43;
        int[] val_44 = new int[8] {15, 10, 5, 3, 1, 0, 0, 0};
        if(val_44 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_28.Length <= 15)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_28[15] = val_44;
        int[] val_45 = new int[8] {5, 3, 2, 1, 0, 0, 0, 0};
        if(val_45 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_28.Length <= 16)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_28[16] = val_45;
        int[] val_46 = new int[8] {5, 3, 2, 1, 0, 0, 0, 0};
        if(val_46 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_28.Length <= 17)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_28[17] = val_46;
        int[] val_47 = new int[8] {5, 3, 2, 1, 0, 0, 0, 0};
        if(val_47 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_28.Length <= 18)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_28[18] = val_47;
        int[] val_48 = new int[8] {5, 3, 2, 1, 0, 0, 0, 0};
        if(val_48 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_28.Length <= 19)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_28[19] = val_48;
        TournamentsEconomy.gemRewardsByTier = val_28;
        System.Int32[][] val_49 = new System.Int32[][20];
        int[] val_50 = new int[8] {5, 4, 3, 2, 1, 0, 0, 0};
        val_92 = System.Byte[];
        if(val_49 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_50 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_49.Length == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_49[0] = val_50;
        val_49[1] = new int[8] {3, 2, 1, 1, 0, 0, 0, 0};
        val_49[2] = new int[8] {3, 2, 1, 1, 0, 0, 0, 0};
        val_49[3] = new int[8] {3, 2, 1, 1, 0, 0, 0, 0};
        val_49[4] = new int[8] {3, 2, 1, 1, 0, 0, 0, 0};
        val_49[5] = new int[8] {2, 1, 1, 0, 0, 0, 0, 0};
        val_49[6] = new int[8] {2, 1, 1, 0, 0, 0, 0, 0};
        val_49[7] = new int[8] {2, 1, 1, 0, 0, 0, 0, 0};
        int[] val_58 = new int[8];
        val_58[0] = 1;
        val_49[8] = val_58;
        int[] val_59 = new int[8];
        val_59[0] = 1;
        val_49[9] = val_59;
        int[] val_60 = new int[8];
        val_60[0] = 1;
        val_49[10] = val_60;
        int[] val_61 = new int[8];
        val_61[0] = 1;
        val_49[11] = val_61;
        int[] val_62 = new int[8];
        val_62[0] = 1;
        val_49[12] = val_62;
        val_49[13] = new int[8];
        val_49[14] = new int[8];
        val_49[15] = new int[8];
        val_49[16] = new int[8];
        val_49[17] = new int[8];
        val_49[18] = new int[8];
        val_49[19] = new int[8];
        TournamentsEconomy.petFoodRewardsByTier = val_49;
        System.Int32[][] val_70 = new System.Int32[][20];
        val_70[0] = new int[8] {8, 7, 6, 0, 0, 0, 0, 0};
        val_70[1] = new int[8] {7, 6, 5, 0, 0, 0, 0, 0};
        val_70[2] = new int[8] {7, 6, 5, 0, 0, 0, 0, 0};
        val_70[3] = new int[8] {6, 5, 4, 0, 0, 0, 0, 0};
        val_70[4] = new int[8] {6, 5, 4, 0, 0, 0, 0, 0};
        val_70[5] = new int[8] {5, 4, 3, 0, 0, 0, 0, 0};
        val_70[6] = new int[8] {5, 4, 3, 0, 0, 0, 0, 0};
        val_70[7] = new int[8] {5, 4, 3, 0, 0, 0, 0, 0};
        val_70[8] = new int[8] {4, 3, 2, 0, 0, 0, 0, 0};
        val_70[9] = new int[8] {4, 3, 2, 0, 0, 0, 0, 0};
        val_70[10] = new int[8] {4, 3, 2, 0, 0, 0, 0, 0};
        val_70[11] = new int[8] {4, 3, 2, 0, 0, 0, 0, 0};
        val_70[12] = new int[8] {4, 3, 2, 0, 0, 0, 0, 0};
        val_70[13] = new int[8] {3, 2, 1, 0, 0, 0, 0, 0};
        val_70[14] = new int[8] {3, 2, 1, 0, 0, 0, 0, 0};
        val_70[15] = new int[8] {3, 2, 1, 0, 0, 0, 0, 0};
        val_70[16] = new int[8] {3, 2, 1, 0, 0, 0, 0, 0};
        val_70[17] = new int[8] {3, 2, 1, 0, 0, 0, 0, 0};
        val_70[18] = new int[8] {3, 2, 1, 0, 0, 0, 0, 0};
        val_70[19] = new int[8] {3, 2, 1, 0, 0, 0, 0, 0};
        TournamentsEconomy.giftRewardsByTier = val_70;
    }

}
