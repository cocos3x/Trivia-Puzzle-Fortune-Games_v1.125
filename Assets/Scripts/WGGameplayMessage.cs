using UnityEngine;
public class WGGameplayMessage : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject message_group;
    private UnityEngine.CanvasGroup message_canvas_group;
    private UnityEngine.UI.Text message_text;
    private UnityEngine.GameObject letterNoObj;
    private UnityEngine.UI.Text letterNoText;
    private bool <isMessageShowing>k__BackingField;
    
    // Properties
    public bool isMessageShowing { get; set; }
    
    // Methods
    public bool get_isMessageShowing()
    {
        return (bool)this.<isMessageShowing>k__BackingField;
    }
    private void set_isMessageShowing(bool value)
    {
        this.<isMessageShowing>k__BackingField = value;
    }
    private void Awake()
    {
        this.message_group.SetActive(value:  false);
        this.message_canvas_group.alpha = 0f;
    }
    public bool ShowMessage(string message, bool showLetterNo = False, int letterCount = -1)
    {
        DG.Tweening.TweenCallback val_8;
        var val_9;
        val_8 = message;
        if((this.<isMessageShowing>k__BackingField) != false)
        {
                val_9 = 0;
            return (bool)val_9;
        }
        
        this.<isMessageShowing>k__BackingField = true;
        if((UnityEngine.Object.op_Implicit(exists:  this.letterNoObj)) != false)
        {
                this.letterNoObj.SetActive(value:  showLetterNo);
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  this.letterNoText)) != false)
        {
                string val_4 = letterCount.ToString();
        }
        
        this.message_group.SetActive(value:  true);
        this.message_canvas_group.alpha = 0f;
        DG.Tweening.TweenCallback val_6 = null;
        val_8 = val_6;
        val_6 = new DG.Tweening.TweenCallback(object:  this, method:  System.Void WGGameplayMessage::OnMessageShowComplete());
        DG.Tweening.Tweener val_7 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.message_canvas_group, endValue:  1f, duration:  0.3f), action:  val_6);
        val_9 = 1;
        return (bool)val_9;
    }
    private void OnMessageShowComplete()
    {
        DG.Tweening.Tween val_2 = DG.Tweening.DOVirtual.DelayedCall(delay:  3.5f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WGGameplayMessage::<OnMessageShowComplete>b__11_0()), ignoreTimeScale:  true);
    }
    private void OnMessageHideComplete()
    {
        this.message_group.SetActive(value:  false);
        this.<isMessageShowing>k__BackingField = false;
    }
    public WGGameplayMessage()
    {
    
    }
    private void <OnMessageShowComplete>b__11_0()
    {
        DG.Tweening.Tweener val_3 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.message_canvas_group, endValue:  0f, duration:  0.3f), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WGGameplayMessage::OnMessageHideComplete()));
    }

}
