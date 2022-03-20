using UnityEngine;
public class MysteryGiftFlyoutMessage : MonoSingleton<MysteryGiftFlyoutMessage>
{
    // Fields
    private UnityEngine.GameObject message_group;
    private UnityEngine.UI.Text message_text;
    private bool isMessageShowing;
    
    // Methods
    private void Start()
    {
        if(this.message_group != null)
        {
                this.message_group.SetActive(value:  false);
            return;
        }
        
        throw new NullReferenceException();
    }
    public bool ShowMessage(string message)
    {
        var val_3;
        if(this.isMessageShowing != false)
        {
                val_3 = 0;
            return (bool)val_3;
        }
        
        this.isMessageShowing = true;
        val_3 = 1;
        this.message_group.SetActive(value:  true);
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.AnimateMessage());
        return (bool)val_3;
    }
    private System.Collections.IEnumerator AnimateMessage()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new MysteryGiftFlyoutMessage.<AnimateMessage>d__5();
    }
    private void OnMessageHideComplete()
    {
        this.message_group.SetActive(value:  false);
        this.isMessageShowing = false;
    }
    public MysteryGiftFlyoutMessage()
    {
    
    }

}
