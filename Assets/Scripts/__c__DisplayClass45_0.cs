using UnityEngine;
private sealed class RaidAttackManager.<>c__DisplayClass45_0
{
    // Fields
    public WordForest.RaidAttackManager <>4__this;
    public System.Action onInitialized;
    
    // Methods
    public RaidAttackManager.<>c__DisplayClass45_0()
    {
    
    }
    internal void <InitializeRaid>b__0(System.Collections.Generic.Dictionary<string, object> resp)
    {
        System.Collections.Generic.List<System.Int32> val_15;
        var val_16;
        val_15 = "raid";
        if((resp.ContainsKey(key:  "raid")) != false)
        {
                val_16 = 1152921510214912464;
            object val_2 = resp.Item["raid"];
            if((val_2.ContainsKey(key:  "id")) != false)
        {
                this.<>4__this.currentRaidId = val_2.Item["id"];
        }
        
            if((val_2.ContainsKey(key:  "receiver_forest")) != false)
        {
                this.<>4__this.dataController.AddOrUpdateServerProfileToCache(profile:  new WordForest.UserForestProfile());
        }
        
            val_15 = "chest_options";
            if((val_2.ContainsKey(key:  "chest_options")) != false)
        {
                char[] val_10 = new char[1];
            val_10[0] = 124;
            System.Collections.Generic.List<System.Int32> val_12 = null;
            val_15 = val_12;
            val_12 = new System.Collections.Generic.List<System.Int32>();
            int val_16 = val_11.Length;
            if(val_16 >= 1)
        {
                var val_17 = 0;
            val_16 = val_16 & 4294967295;
            do
        {
            if((System.Int32.TryParse(s:  null, result: out  0)) != false)
        {
                val_12.Add(item:  0);
        }
        
            val_17 = val_17 + 1;
        }
        while(val_17 < (val_11.Length << ));
        
        }
        
            this.<>4__this.<currentRaidPickerOptions>k__BackingField = val_15;
        }
        
        }
        
        if(this.onInitialized == null)
        {
                return;
        }
        
        this.onInitialized.Invoke();
    }

}
