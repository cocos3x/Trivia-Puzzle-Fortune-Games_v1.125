using UnityEngine;
public class ForestMasterEcon
{
    // Fields
    public RestaurantMasterRewardData rewardData;
    public int unlockPlayerLevel;
    
    // Methods
    public ForestMasterEcon(System.Collections.Generic.Dictionary<string, object> eventDataDict)
    {
        var val_10;
        this.unlockPlayerLevel = 2;
        this.rewardData = RestaurantMasterEconDataHelper.ParseCSV();
        if(eventDataDict == null)
        {
                return;
        }
        
        if((eventDataDict.ContainsKey(key:  "economy")) == false)
        {
                return;
        }
        
        val_10 = 1152921510214912464;
        if(eventDataDict.Item["economy"] == null)
        {
                return;
        }
        
        object val_4 = eventDataDict.Item["economy"];
        if((val_4.ContainsKey(key:  "unlock_lvl")) == false)
        {
                return;
        }
        
        if(val_4.Item["unlock_lvl"] == null)
        {
                return;
        }
        
        if((System.Int32.TryParse(s:  val_4.Item["unlock_lvl"], result: out  0)) == false)
        {
                return;
        }
        
        this.unlockPlayerLevel = 0;
    }
    public System.Collections.Generic.List<RESEventRewardData> GetRewardsList(int playerLevel)
    {
        int val_8;
        System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<RESEventRewardData>> val_9;
        if(this.rewardData != null)
        {
                val_9 = this.rewardData.rewardList;
            if(val_9 == null)
        {
                return (System.Collections.Generic.List<RESEventRewardData>)val_9;
        }
        
            if((val_9.ContainsKey(key:  playerLevel)) != false)
        {
                if(this.rewardData.rewardList.Item[playerLevel] != null)
        {
                return (System.Collections.Generic.List<RESEventRewardData>)val_9;
        }
        
        }
        
            val_8 = System.Linq.Enumerable.Max(source:  this.rewardData.rewardList.Keys);
            int val_5 = UnityEngine.Mathf.Min(a:  playerLevel, b:  val_8);
            if((this.rewardData.rewardList.ContainsKey(key:  val_5)) != false)
        {
                System.Collections.Generic.List<RESEventRewardData> val_7 = this.rewardData.rewardList.Item[val_5];
            return (System.Collections.Generic.List<RESEventRewardData>)val_9;
        }
        
        }
        
        val_9 = 0;
        return (System.Collections.Generic.List<RESEventRewardData>)val_9;
    }

}
