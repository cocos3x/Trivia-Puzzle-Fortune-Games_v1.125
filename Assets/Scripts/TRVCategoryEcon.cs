using UnityEngine;
public class TRVEcon.TRVCategoryEcon
{
    // Fields
    public string locale;
    public System.Collections.Generic.Dictionary<string, int> categoryUnlockLevels;
    
    // Methods
    public TRVEcon.TRVCategoryEcon(UnityEngine.TextAsset categoryEconData, string localeName)
    {
        string val_9 = val_2;
        this.categoryUnlockLevels = new System.Collections.Generic.Dictionary<System.String, System.Int32>();
        val_2 = new System.Object();
        this.locale = val_9;
        char[] val_4 = new char[1];
        val_4[0] = '
        ';
        if(val_5.Length < 1)
        {
                return;
        }
        
        var val_11 = 0;
        do
        {
            val_9 = categoryEconData.text.Split(separator:  val_4)[val_11];
            if(val_5[0x0][0].m_stringLength >= 2)
        {
                char[] val_6 = new char[1];
            val_6[0] = '	';
            System.String[] val_7 = val_9.Split(separator:  val_6);
            val_9 = this.categoryUnlockLevels;
            val_9.Add(key:  val_7[0], value:  System.Int32.Parse(s:  val_7[1]));
        }
        
            val_11 = val_11 + 1;
        }
        while(val_11 < val_5.Length);
    
    }

}
