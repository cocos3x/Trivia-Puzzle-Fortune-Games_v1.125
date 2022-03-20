using UnityEngine;
public class GiftRewardUI_Coins : MonoBehaviour
{
    // Fields
    protected UnityEngine.UI.Text rewardValue;
    
    // Methods
    public void Setup(decimal value)
    {
        var val_4 = null;
        if(App.game == 20)
        {
                GameEcon val_1 = App.getGameEcon;
            string val_2 = value.flags.ToString(format:  val_1.numberFormatInt);
            if(this.rewardValue != null)
        {
                return;
        }
        
            throw new NullReferenceException();
        }
        
        string val_3 = value.flags.ToString();
    }
    public GiftRewardUI_Coins()
    {
    
    }

}
