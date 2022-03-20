using UnityEngine;
public class HotNSpicyEconDataHelper
{
    // Methods
    public static HotNSpicyRewardData ParseCSV()
    {
        return HotNSpicyEconDataHelper.ParseCSV_RRV();
    }
    private static HotNSpicyRewardData ParseCSV_RRV()
    {
        var val_20;
        var val_21;
        System.Collections.Generic.List<RESEventRewardData>[] val_22;
        char[] val_3 = new char[1];
        val_3[0] = '
        ';
        System.Collections.Generic.List<RESEventRewardData>[] val_6 = new System.Collections.Generic.List<RESEventRewardData>[3];
        .rewardListTier = val_6;
        var val_24 = 0;
        label_13:
        if(val_24 >= val_6.Length)
        {
            goto label_9;
        }
        
        val_6[val_24] = new System.Collections.Generic.List<RESEventRewardData>();
        val_24 = val_24 + 1;
        if((HotNSpicyRewardData)[1152921517103895104].rewardListTier != null)
        {
            goto label_13;
        }
        
        label_9:
        System.Collections.Generic.List<System.Collections.Generic.List<RESEventCoinValue>>[] val_8 = new System.Collections.Generic.List<System.Collections.Generic.List<RESEventCoinValue>>[3];
        .coinValuesTiers = val_8;
        var val_25 = 0;
        label_20:
        if(val_25 >= val_8.Length)
        {
            goto label_16;
        }
        
        val_8[val_25] = new System.Collections.Generic.List<System.Collections.Generic.List<RESEventCoinValue>>();
        val_25 = val_25 + 1;
        if((HotNSpicyRewardData)[1152921517103895104].coinValuesTiers != null)
        {
            goto label_20;
        }
        
        label_16:
        var val_27 = 0;
        label_26:
        val_8[0].Add(item:  new System.Collections.Generic.List<RESEventCoinValue>());
        val_27 = val_27 + 1;
        if(val_27 < 10)
        {
                if((HotNSpicyRewardData)[1152921517103895104].coinValuesTiers != null)
        {
            goto label_26;
        }
        
        }
        
        var val_29 = 0;
        do
        {
            (HotNSpicyRewardData)[1152921517103895104].coinValuesTiers[1].Add(item:  new System.Collections.Generic.List<RESEventCoinValue>());
            val_29 = val_29 + 1;
        }
        while(val_29 < 9);
        
        var val_31 = 0;
        do
        {
            System.Collections.Generic.List<RESEventCoinValue> val_12 = new System.Collections.Generic.List<RESEventCoinValue>();
            (HotNSpicyRewardData)[1152921517103895104].coinValuesTiers[2].Add(item:  val_12);
            val_31 = val_31 + 1;
        }
        while(val_31 < 8);
        
        int val_32 = val_4.Length;
        if(val_32 < 1)
        {
            goto label_37;
        }
        
        var val_33 = 0;
        val_32 = val_32 & 4294967295;
        goto label_62;
        label_50:
        RestaurantRivals.CommonEventEconDataHelper.ParseRewardTierList(rawLineStr:  val_12, pointsReqColIndex:  6, rewQtyColIndex:  7, rewTypeColIndex:  8, currRowIndex:  0, tierList: ref  (HotNSpicyRewardData)[1152921517103895104].rewardListTier[48]);
        goto label_53;
        label_62:
        if((System.String.IsNullOrEmpty(value:  1152921505059157200)) == true)
        {
            goto label_53;
        }
        
        var val_15 = val_33 - 14;
        if(val_15 > 23)
        {
            goto label_47;
        }
        
        RestaurantRivals.CommonEventEconDataHelper.ParseRewardTierList(rawLineStr:  1152921505059157200, pointsReqColIndex:  0, rewQtyColIndex:  1, rewTypeColIndex:  2, currRowIndex:  0, tierList: ref  (HotNSpicyRewardData)[1152921517103895104].rewardListTier[32]);
        if(val_15 > 21)
        {
            goto label_47;
        }
        
        RestaurantRivals.CommonEventEconDataHelper.ParseRewardTierList(rawLineStr:  1152921505059157200, pointsReqColIndex:  3, rewQtyColIndex:  4, rewTypeColIndex:  5, currRowIndex:  0, tierList: ref  (HotNSpicyRewardData)[1152921517103895104].rewardListTier[40]);
        if(val_15 <= 17)
        {
            goto label_50;
        }
        
        label_47:
        if((val_33 - 41) <= 17)
        {
            goto label_51;
        }
        
        if((val_33 - 62) <= 17)
        {
            goto label_52;
        }
        
        if((val_33 - 83) > 17)
        {
            goto label_53;
        }
        
        val_20 = 3;
        val_21 = 11;
        goto label_59;
        label_51:
        val_20 = 3;
        val_21 = 13;
        goto label_59;
        label_52:
        val_20 = 3;
        val_21 = 12;
        label_59:
        RestaurantRivals.CommonEventEconDataHelper.ParseCoinValueTierList(rawLineStr:  1152921505059157200, tierStartColumn:  3, tierLastColumn:  12, currRowIndex:  0, tierList: ref  (HotNSpicyRewardData)[1152921517103895104].coinValuesTiers[40]);
        label_53:
        val_33 = val_33 + 1;
        if(val_33 < (val_4.Length << ))
        {
            goto label_62;
        }
        
        label_37:
        val_22 = (HotNSpicyRewardData)[1152921517103895104].rewardListTier;
        var val_36 = 4;
        do
        {
            if((val_36 - 4) >= ((HotNSpicyRewardData)[1152921517103895104].rewardListTier.Length << ))
        {
                return (HotNSpicyRewardData)new HotNSpicyRewardData();
        }
        
            val_22[0] = RestaurantRivals.CommonEventEconDataHelper.GetDynamicEventRewardList(tierList:  val_22[0], coinList:  (HotNSpicyRewardData)[1152921517103895104].coinValuesTiers[0]);
            val_22 = (HotNSpicyRewardData)[1152921517103895104].rewardListTier;
            val_36 = val_36 + 1;
        }
        while(val_22 != null);
        
        throw new NullReferenceException();
    }
    public HotNSpicyEconDataHelper()
    {
    
    }

}
