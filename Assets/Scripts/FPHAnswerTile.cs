using UnityEngine;
public class FPHAnswerTile : MonoBehaviour
{
    // Fields
    private const float textTweenDuration = 0.3;
    private UnityEngine.UI.Text myText;
    private UnityEngine.UI.Image highlightBg;
    private char <myChar>k__BackingField;
    private bool displayingLetter;
    private DG.Tweening.Tween myTextTween;
    
    // Properties
    public char myChar { get; set; }
    
    // Methods
    public char get_myChar()
    {
        return (char)this.<myChar>k__BackingField;
    }
    private void set_myChar(char value)
    {
        this.<myChar>k__BackingField = value;
    }
    public void Setup(char myLetter, bool revealed = False)
    {
        UnityEngine.UI.Text val_5;
        if((myLetter & 65535) == ' ')
        {
                MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(gameObject:  this.gameObject).alpha = 0f;
            return;
        }
        
        val_5 = this.myText;
        this.<myChar>k__BackingField = myLetter;
        if(revealed == false)
        {
                return;
        }
        
        string val_4 = myLetter.ToString();
        if(val_5 != null)
        {
                return;
        }
    
    }
    public void DisplayLetter()
    {
        if(this.displayingLetter == true)
        {
                return;
        }
        
        this.displayingLetter = true;
        if(this.myTextTween != null)
        {
                DG.Tweening.TweenExtensions.Kill(t:  this.myTextTween, complete:  false);
        }
        
        UnityEngine.Vector3 val_2 = UnityEngine.Vector3.zero;
        this.myText.transform.localScale = new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z};
        this.myTextTween = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.myText.transform, endValue:  1f, duration:  0.3f), ease:  27);
        string val_6 = this.<myChar>k__BackingField.ToString();
    }
    public void DisplayUnconfirmedLetter(char value)
    {
        if((System.String.op_Equality(a:  this.myText, b:  value.ToString())) == true)
        {
                return;
        }
        
        if(this.myTextTween != null)
        {
                DG.Tweening.TweenExtensions.Kill(t:  this.myTextTween, complete:  false);
        }
        
        UnityEngine.Vector3 val_4 = UnityEngine.Vector3.zero;
        this.myText.transform.localScale = new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z};
        this.myTextTween = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.myText.transform, endValue:  1f, duration:  0.3f), ease:  27);
        string val_8 = value.ToString();
    }
    public void RemoveLetter()
    {
        this.displayingLetter = false;
        if(this.myTextTween != null)
        {
                DG.Tweening.TweenExtensions.Kill(t:  this.myTextTween, complete:  false);
        }
        
        this.myTextTween = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.myText.transform, endValue:  0f, duration:  0.3f), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void FPHAnswerTile::<RemoveLetter>b__12_0()));
    }
    public void Highlight(bool isVisible)
    {
        this.highlightBg.gameObject.SetActive(value:  isVisible);
    }
    public FPHAnswerTile()
    {
    
    }
    private void <RemoveLetter>b__12_0()
    {
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }

}
