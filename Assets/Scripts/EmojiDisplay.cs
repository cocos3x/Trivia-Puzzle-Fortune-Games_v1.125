using UnityEngine;
public class EmojiDisplay : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject existingEmoji;
    
    // Methods
    public void DisplayEmoji(string emojiID, bool addOutline = False)
    {
        UnityEngine.GameObject val_8;
        UnityEngine.GameObject val_9;
        val_8 = this.existingEmoji;
        if((UnityEngine.Object.op_Implicit(exists:  val_8)) != false)
        {
                val_8 = this.existingEmoji;
            UnityEngine.Object.Destroy(obj:  val_8);
        }
        
        UnityEngine.GameObject val_3 = MonoSingleton<EmojiManagerMinigames>.Instance.GetEmojiPrefab(key:  emojiID);
        if(val_3 != 0)
        {
                val_8 = this.transform;
            UnityEngine.GameObject val_6 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  val_3, parent:  val_8);
            val_9 = val_6;
            this.existingEmoji = val_6;
        }
        else
        {
                val_9 = this.existingEmoji;
        }
        
        bool val_7 = UnityEngine.Object.op_Implicit(exists:  val_9);
    }
    public EmojiDisplay()
    {
    
    }

}
