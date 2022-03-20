using UnityEngine;
public class RestaurantMasterEconDataHelper
{
    // Methods
    public static RestaurantMasterRewardData ParseCSV()
    {
        null = null;
        if(App.game != 18)
        {
                return RestaurantMasterEconDataHelper.ParseCSV_RRV();
        }
        
        return RestaurantMasterEconDataHelper.ParseCSV_WFO();
    }
    private static RestaurantMasterRewardData ParseCSV_RRV()
    {
        int val_21;
        System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<RESEventRewardData>> val_22;
        RESEventRewardData val_23;
        string val_24;
        var val_25;
        var val_26;
        var val_27;
        var val_28;
        val_21 = public static UnityEngine.TextAsset WGResources::Load<UnityEngine.TextAsset>(string fileName, string extension, bool errorLog);
        char[] val_3 = new char[1];
        val_3[0] = '
        ';
        System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<RESEventRewardData>> val_6 = null;
        val_22 = val_6;
        val_6 = new System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<RESEventRewardData>>();
        .rewardList = val_22;
        int val_23 = val_4.Length;
        if(val_23 < 7)
        {
                return (RestaurantMasterRewardData)new RestaurantMasterRewardData();
        }
        
        val_23 = val_23 & 4294967295;
        do
        {
            val_23 = 6;
            val_22 = WGResources.Load<UnityEngine.TextAsset>(fileName:  "GameEvents/RestaurantMaster/RestaurantMasterEcon", extension:  ".txt", errorLog:  true).text.Split(separator:  val_3)[6];
            if((System.String.IsNullOrEmpty(value:  val_22)) != true)
        {
                char[] val_8 = new char[1];
            val_8[0] = '	';
            System.String[] val_9 = val_22.Split(separator:  val_8);
            System.Collections.Generic.List<RESEventRewardData> val_10 = null;
            val_22 = val_10;
            val_10 = new System.Collections.Generic.List<RESEventRewardData>();
            int val_13 = 0;
            int val_24 = val_4.Length;
            val_24 = val_9[0];
            val_24 = val_24 - 1;
            if(val_23 == val_24)
        {
                val_21 = 0;
        }
        
            bool val_14 = System.Int32.TryParse(s:  val_24.Substring(startIndex:  0, length:  val_9[0].m_stringLength - 1), result: out  val_13);
            val_25 = null;
            val_25 = null;
            if((System.Decimal.TryParse(s:  val_9[1], result: out  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.MinusOne, mid = System.Decimal.MinusOne})) != false)
        {
                RESEventRewardData val_16 = null;
            val_21 = System.Decimal.MinusOne;
            val_23 = val_16;
            val_16 = new RESEventRewardData(rewType:  1, rewQty:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = val_21, mid = val_21}, ptsReq:  0, mData:  0);
            val_10.Add(item:  val_16);
        }
        
            val_26 = null;
            val_26 = null;
            if((System.Decimal.TryParse(s:  val_9[2], result: out  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.MinusOne, mid = System.Decimal.MinusOne})) != false)
        {
                val_23 = System.Decimal.MinusOne;
            RESEventRewardData val_18 = null;
            val_21 = System.Decimal.MinusOne;
            val_18 = new RESEventRewardData(rewType:  2, rewQty:  new System.Decimal() {flags = val_23, hi = val_23, lo = val_21, mid = val_21}, ptsReq:  0, mData:  0);
            val_10.Add(item:  val_18);
        }
        
            if(val_13 != 1)
        {
                val_27 = null;
            val_23 = System.Decimal.MinusOne;
            val_27 = null;
            if((System.Decimal.op_Inequality(d1:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = val_23, mid = val_23}, d2:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_30>>32&0x0})) != false)
        {
                val_28 = null;
            val_23 = System.Decimal.MinusOne;
            val_28 = null;
            if((System.Decimal.op_Inequality(d1:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = val_23, mid = val_23}, d2:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_30>>32&0x0})) != false)
        {
                (RestaurantMasterRewardData)[1152921517107454832].rewardList.Add(key:  0, value:  val_10);
        }
        
        }
        
        }
        
        }
        
            var val_22 = 10 + 1;
        }
        while((10 - 3) < (val_4.Length << ));
        
        return (RestaurantMasterRewardData)new RestaurantMasterRewardData();
    }
    private static RestaurantMasterRewardData ParseCSV_WFO()
    {
        int val_21;
        System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<RESEventRewardData>> val_22;
        RESEventRewardData val_23;
        string val_24;
        var val_25;
        var val_26;
        var val_27;
        var val_28;
        val_21 = public static UnityEngine.TextAsset WGResources::Load<UnityEngine.TextAsset>(string fileName, string extension, bool errorLog);
        char[] val_3 = new char[1];
        val_3[0] = '
        ';
        System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<RESEventRewardData>> val_6 = null;
        val_22 = val_6;
        val_6 = new System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<RESEventRewardData>>();
        .rewardList = val_22;
        int val_23 = val_4.Length;
        if(val_23 < 7)
        {
                return (RestaurantMasterRewardData)new RestaurantMasterRewardData();
        }
        
        val_23 = val_23 & 4294967295;
        do
        {
            val_23 = 6;
            val_22 = WGResources.Load<UnityEngine.TextAsset>(fileName:  "GameEvents/ForestMaster/ForestMasterEcon", extension:  ".txt", errorLog:  true).text.Split(separator:  val_3)[6];
            if((System.String.IsNullOrEmpty(value:  val_22)) != true)
        {
                char[] val_8 = new char[1];
            val_8[0] = '	';
            System.String[] val_9 = val_22.Split(separator:  val_8);
            System.Collections.Generic.List<RESEventRewardData> val_10 = null;
            val_22 = val_10;
            val_10 = new System.Collections.Generic.List<RESEventRewardData>();
            int val_13 = 0;
            int val_24 = val_4.Length;
            val_24 = val_9[0];
            val_24 = val_24 - 1;
            if(val_23 == val_24)
        {
                val_21 = 0;
        }
        
            bool val_14 = System.Int32.TryParse(s:  val_24.Substring(startIndex:  0, length:  val_9[0].m_stringLength - 1), result: out  val_13);
            val_25 = null;
            val_25 = null;
            if((System.Decimal.TryParse(s:  val_9[1], result: out  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.MinusOne, mid = System.Decimal.MinusOne})) != false)
        {
                RESEventRewardData val_16 = null;
            val_21 = System.Decimal.MinusOne;
            val_23 = val_16;
            val_16 = new RESEventRewardData(rewType:  3, rewQty:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = val_21, mid = val_21}, ptsReq:  0, mData:  0);
            val_10.Add(item:  val_16);
        }
        
            val_26 = null;
            val_26 = null;
            if((System.Decimal.TryParse(s:  val_9[2], result: out  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.MinusOne, mid = System.Decimal.MinusOne})) != false)
        {
                val_23 = System.Decimal.MinusOne;
            RESEventRewardData val_18 = null;
            val_21 = System.Decimal.MinusOne;
            val_18 = new RESEventRewardData(rewType:  1, rewQty:  new System.Decimal() {flags = val_23, hi = val_23, lo = val_21, mid = val_21}, ptsReq:  0, mData:  0);
            val_10.Add(item:  val_18);
        }
        
            if(val_13 != 1)
        {
                val_27 = null;
            val_23 = System.Decimal.MinusOne;
            val_27 = null;
            if((System.Decimal.op_Inequality(d1:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = val_23, mid = val_23}, d2:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_30>>32&0x0})) != false)
        {
                val_28 = null;
            val_23 = System.Decimal.MinusOne;
            val_28 = null;
            if((System.Decimal.op_Inequality(d1:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = val_23, mid = val_23}, d2:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_30>>32&0x0})) != false)
        {
                (RestaurantMasterRewardData)[1152921517107837392].rewardList.Add(key:  0, value:  val_10);
        }
        
        }
        
        }
        
        }
        
            var val_22 = 10 + 1;
        }
        while((10 - 3) < (val_4.Length << ));
        
        return (RestaurantMasterRewardData)new RestaurantMasterRewardData();
    }
    public RestaurantMasterEconDataHelper()
    {
    
    }

}
