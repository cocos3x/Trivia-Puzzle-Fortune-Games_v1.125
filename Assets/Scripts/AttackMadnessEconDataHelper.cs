using UnityEngine;
public class AttackMadnessEconDataHelper
{
    // Methods
    public static AttackMadnessRewardData ParseCSV()
    {
        null = null;
        if(App.game != 18)
        {
                return AttackMadnessEconDataHelper.ParseCSV_RRV();
        }
        
        return AttackMadnessEconDataHelper.ParseCSV_WFO();
    }
    private static AttackMadnessRewardData ParseCSV_RRV()
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
        if((AttackMadnessRewardData)[1152921517100822320].rewardListTier != null)
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
        if((AttackMadnessRewardData)[1152921517100822320].coinValuesTiers != null)
        {
            goto label_20;
        }
        
        label_16:
        var val_27 = 0;
        label_26:
        val_8[0].Add(item:  new System.Collections.Generic.List<RESEventCoinValue>());
        val_27 = val_27 + 1;
        if(val_27 < 11)
        {
                if((AttackMadnessRewardData)[1152921517100822320].coinValuesTiers != null)
        {
            goto label_26;
        }
        
        }
        
        var val_29 = 0;
        do
        {
            (AttackMadnessRewardData)[1152921517100822320].coinValuesTiers[1].Add(item:  new System.Collections.Generic.List<RESEventCoinValue>());
            val_29 = val_29 + 1;
        }
        while(val_29 < 8);
        
        var val_31 = 0;
        do
        {
            System.Collections.Generic.List<RESEventCoinValue> val_12 = new System.Collections.Generic.List<RESEventCoinValue>();
            (AttackMadnessRewardData)[1152921517100822320].coinValuesTiers[2].Add(item:  val_12);
            val_31 = val_31 + 1;
        }
        while(val_31 < 7);
        
        int val_32 = val_4.Length;
        if(val_32 < 1)
        {
            goto label_37;
        }
        
        var val_33 = 0;
        val_32 = val_32 & 4294967295;
        goto label_62;
        label_50:
        RestaurantRivals.CommonEventEconDataHelper.ParseRewardTierList(rawLineStr:  val_12, pointsReqColIndex:  6, rewQtyColIndex:  7, rewTypeColIndex:  8, currRowIndex:  0, tierList: ref  (AttackMadnessRewardData)[1152921517100822320].rewardListTier[48]);
        goto label_53;
        label_62:
        if((System.String.IsNullOrEmpty(value:  1152921505059157200)) == true)
        {
            goto label_53;
        }
        
        var val_15 = val_33 - 10;
        if(val_15 > 22)
        {
            goto label_47;
        }
        
        RestaurantRivals.CommonEventEconDataHelper.ParseRewardTierList(rawLineStr:  1152921505059157200, pointsReqColIndex:  0, rewQtyColIndex:  1, rewTypeColIndex:  2, currRowIndex:  0, tierList: ref  (AttackMadnessRewardData)[1152921517100822320].rewardListTier[32]);
        if(val_15 > 16)
        {
            goto label_47;
        }
        
        RestaurantRivals.CommonEventEconDataHelper.ParseRewardTierList(rawLineStr:  1152921505059157200, pointsReqColIndex:  3, rewQtyColIndex:  4, rewTypeColIndex:  5, currRowIndex:  0, tierList: ref  (AttackMadnessRewardData)[1152921517100822320].rewardListTier[40]);
        if(val_15 <= 14)
        {
            goto label_50;
        }
        
        label_47:
        if((val_33 - 36) <= 17)
        {
            goto label_51;
        }
        
        if((val_33 - 57) <= 17)
        {
            goto label_52;
        }
        
        if((val_33 - 78) > 17)
        {
            goto label_53;
        }
        
        val_20 = 3;
        val_21 = 10;
        goto label_59;
        label_51:
        val_20 = 3;
        val_21 = 14;
        goto label_59;
        label_52:
        val_20 = 3;
        val_21 = 11;
        label_59:
        RestaurantRivals.CommonEventEconDataHelper.ParseCoinValueTierList(rawLineStr:  1152921505059157200, tierStartColumn:  3, tierLastColumn:  11, currRowIndex:  0, tierList: ref  (AttackMadnessRewardData)[1152921517100822320].coinValuesTiers[40]);
        label_53:
        val_33 = val_33 + 1;
        if(val_33 < (val_4.Length << ))
        {
            goto label_62;
        }
        
        label_37:
        val_22 = (AttackMadnessRewardData)[1152921517100822320].rewardListTier;
        var val_36 = 4;
        do
        {
            if((val_36 - 4) >= ((AttackMadnessRewardData)[1152921517100822320].rewardListTier.Length << ))
        {
                return (AttackMadnessRewardData)new AttackMadnessRewardData();
        }
        
            val_22[0] = RestaurantRivals.CommonEventEconDataHelper.GetDynamicEventRewardList(tierList:  val_22[0], coinList:  (AttackMadnessRewardData)[1152921517100822320].coinValuesTiers[0]);
            val_22 = (AttackMadnessRewardData)[1152921517100822320].rewardListTier;
            val_36 = val_36 + 1;
        }
        while(val_22 != null);
        
        throw new NullReferenceException();
    }
    private static AttackMadnessRewardData ParseCSV_WFO()
    {
        System.Collections.Generic.List<RESEventRewardData>[] val_15;
        char[] val_3 = new char[1];
        val_3[0] = '
        ';
        System.Collections.Generic.List<RESEventRewardData>[] val_6 = new System.Collections.Generic.List<RESEventRewardData>[1];
        .rewardListTier = val_6;
        var val_18 = 0;
        label_13:
        if(val_18 >= val_6.Length)
        {
            goto label_9;
        }
        
        val_6[val_18] = new System.Collections.Generic.List<RESEventRewardData>();
        val_18 = val_18 + 1;
        if((AttackMadnessRewardData)[1152921517101942064].rewardListTier != null)
        {
            goto label_13;
        }
        
        label_9:
        System.Collections.Generic.List<System.Collections.Generic.List<RESEventCoinValue>>[] val_8 = new System.Collections.Generic.List<System.Collections.Generic.List<RESEventCoinValue>>[1];
        .coinValuesTiers = val_8;
        var val_19 = 0;
        label_20:
        if(val_19 >= val_8.Length)
        {
            goto label_16;
        }
        
        val_8[val_19] = new System.Collections.Generic.List<System.Collections.Generic.List<RESEventCoinValue>>();
        val_19 = val_19 + 1;
        if((AttackMadnessRewardData)[1152921517101942064].coinValuesTiers != null)
        {
            goto label_20;
        }
        
        label_16:
        var val_21 = 0;
        label_26:
        val_8[0].Add(item:  new System.Collections.Generic.List<RESEventCoinValue>());
        val_21 = val_21 + 1;
        if(val_21 <= 7)
        {
                if((AttackMadnessRewardData)[1152921517101942064].coinValuesTiers != null)
        {
            goto label_26;
        }
        
        }
        
        int val_22 = val_4.Length;
        if(val_22 < 1)
        {
            goto label_29;
        }
        
        var val_23 = 0;
        val_22 = val_22 & 4294967295;
        label_39:
        if((System.String.IsNullOrEmpty(value:  1152921505059157200)) == true)
        {
            goto label_36;
        }
        
        if((val_23 - 10) <= 20)
        {
            goto label_32;
        }
        
        if((val_23 - 34) > 15)
        {
            goto label_36;
        }
        
        RestaurantRivals.CommonEventEconDataHelper.ParseCoinValueTierList(rawLineStr:  1152921505059157200, tierStartColumn:  3, tierLastColumn:  11, currRowIndex:  0, tierList: ref  (AttackMadnessRewardData)[1152921517101942064].coinValuesTiers[32]);
        goto label_36;
        label_32:
        RestaurantRivals.CommonEventEconDataHelper.ParseRewardTierList(rawLineStr:  1152921505059157200, pointsReqColIndex:  0, rewQtyColIndex:  1, rewTypeColIndex:  2, currRowIndex:  0, tierList: ref  (AttackMadnessRewardData)[1152921517101942064].rewardListTier[32]);
        label_36:
        val_23 = val_23 + 1;
        if(val_23 < (val_4.Length << ))
        {
            goto label_39;
        }
        
        label_29:
        val_15 = (AttackMadnessRewardData)[1152921517101942064].rewardListTier;
        var val_26 = 4;
        do
        {
            if((val_26 - 4) >= ((AttackMadnessRewardData)[1152921517101942064].rewardListTier.Length << ))
        {
                return (AttackMadnessRewardData)new AttackMadnessRewardData();
        }
        
            val_15[0] = RestaurantRivals.CommonEventEconDataHelper.GetDynamicEventRewardList(tierList:  val_15[0], coinList:  (AttackMadnessRewardData)[1152921517101942064].coinValuesTiers[0]);
            val_15 = (AttackMadnessRewardData)[1152921517101942064].rewardListTier;
            val_26 = val_26 + 1;
        }
        while(val_15 != null);
        
        throw new NullReferenceException();
    }
    public AttackMadnessEconDataHelper()
    {
    
    }

}
