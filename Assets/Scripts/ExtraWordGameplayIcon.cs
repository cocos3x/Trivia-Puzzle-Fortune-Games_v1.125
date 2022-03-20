using UnityEngine;
public class ExtraWordGameplayIcon : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text wordCountLabel;
    private UnityEngine.UI.Text descriptionLabel;
    private bool isWordCountDisplayed;
    
    // Methods
    private void Start()
    {
        System.Delegate val_2 = System.Delegate.Combine(a:  ExtraWord.GAMETYPE_CATEGORY_LEVELS + 160, b:  new System.Action<System.Int32>(object:  this, method:  System.Void ExtraWordGameplayIcon::OnExtraWordAdded(int totalCount)));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_3;
        }
        
        }
        
        ExtraWord.GAMETYPE_CATEGORY_LEVELS.__unknownFiledOffset_A0 = val_2;
        this.OnExtraWordAdded(totalCount:  ExtraWord.GAMETYPE_CATEGORY_LEVELS + 32 + 24);
        return;
        label_3:
    }
    public void SetLabel(string str)
    {
        var val_2 = ((str.Equals(value:  "0")) != true) ? "" : str;
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void OnExtraWordAdded(int totalCount)
    {
        bool val_17;
        if(totalCount >= 1)
        {
                this.SetLabel(str:  totalCount.ToString());
            if(this.isWordCountDisplayed == true)
        {
                return;
        }
        
            DG.Tweening.Sequence val_2 = DG.Tweening.DOTween.Sequence();
            val_17 = true;
            DG.Tweening.Sequence val_5 = DG.Tweening.TweenSettingsExtensions.Insert(s:  val_2, atPosition:  0f, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.descriptionLabel, endValue:  0f, duration:  0.18f), ease:  1));
            DG.Tweening.Sequence val_8 = DG.Tweening.TweenSettingsExtensions.Insert(s:  val_2, atPosition:  0.27f, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.wordCountLabel, endValue:  1f, duration:  0.27f), ease:  1));
            DG.Tweening.Sequence val_12 = DG.Tweening.TweenSettingsExtensions.Insert(s:  val_2, atPosition:  0.36f, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.wordCountLabel.transform, endValue:  1f, duration:  0.18f), ease:  1));
            this.isWordCountDisplayed = val_17;
            return;
        }
        
        UnityEngine.Color val_13 = this.wordCountLabel.color;
        this.wordCountLabel.color = new UnityEngine.Color() {r = val_13.r, g = val_13.g, b = val_13.b, a = 0f};
        UnityEngine.Vector3 val_15 = new UnityEngine.Vector3(x:  0.1f, y:  0.1f, z:  1f);
        this.wordCountLabel.transform.localScale = new UnityEngine.Vector3() {x = val_15.x, y = val_15.y, z = val_15.z};
        UnityEngine.Color val_16 = this.descriptionLabel.color;
        this.descriptionLabel.color = new UnityEngine.Color() {r = val_16.r, g = val_16.g, b = val_16.b, a = 1f};
        this.isWordCountDisplayed = false;
    }
    public ExtraWordGameplayIcon()
    {
    
    }

}
