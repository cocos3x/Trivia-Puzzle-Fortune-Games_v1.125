using UnityEngine;
public class PiggyBankRaidHistoryItem : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Image profileImage;
    private UnityEngine.UI.Text messageText;
    
    // Methods
    public void InitialiseMessage(string senderName, decimal stoleAmount, UnityEngine.Sprite avatarSprite)
    {
        GameEcon val_1 = App.getGameEcon;
        string val_3 = System.String.Format(format:  "{0} stole {1} coins from you!", arg0:  senderName, arg1:  stoleAmount.flags.ToString(format:  val_1.numberFormatInt));
        this.profileImage.sprite = avatarSprite;
    }
    public PiggyBankRaidHistoryItem()
    {
    
    }

}
