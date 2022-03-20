using UnityEngine;
[Serializable]
public class GameCurrencyTheme : ScriptableObject
{
    // Fields
    private string mainCurrencyPrettyName;
    
    // Properties
    public string MainCurrencyPrettyName { get; }
    
    // Methods
    public string get_MainCurrencyPrettyName()
    {
        string val_2;
        if((System.String.IsNullOrEmpty(value:  this.mainCurrencyPrettyName)) != false)
        {
                val_2 = "Credits";
            this.mainCurrencyPrettyName = val_2;
            return val_2;
        }
        
        val_2 = this.mainCurrencyPrettyName;
        return val_2;
    }
    public GameCurrencyTheme()
    {
        this.mainCurrencyPrettyName = "";
    }

}
