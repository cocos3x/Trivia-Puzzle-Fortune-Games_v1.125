using UnityEngine;
public class FPHTokenDisplay : MonoBehaviour
{
    // Fields
    private const float textTweenDuration = 0.3;
    private UnityEngine.UI.Text tokenTitleText;
    private UnityEngine.UI.Text tokenText;
    private UnityEngine.UI.Text vowelText;
    private UnityEngine.UI.Text consonantText;
    private UnityEngine.CanvasGroup ootDisplayBanner;
    private UnityEngine.UI.Text ootBannerTextBody;
    private int tokenAmount;
    
    // Methods
    public void Setup(int initial)
    {
        string val_1 = initial.ToString();
        FPHEcon val_2 = App.GetGameSpecificEcon<FPHEcon>();
        string val_3 = Localization.Localize(key:  "vowel_upper", defaultValue:  "VOWEL", useSingularKey:  false);
        string val_6 = System.String.Format(format:  "{0} <color=#FFE640>{1}</color>", arg0:  val_3, arg1:  val_3.GetLetterCostDisplay(cost:  val_2.vowelCost)).ToUpper();
        string val_7 = Localization.Localize(key:  "consonant_upper", defaultValue:  "CONSONANT", useSingularKey:  false);
        string val_10 = System.String.Format(format:  "{0} <color=#FFE640>{1}</color>", arg0:  val_7, arg1:  val_7.GetLetterCostDisplay(cost:  val_2.consonantCost)).ToUpper();
        this.tokenAmount = initial;
    }
    public void UpdateState(FPHGameplayState state)
    {
        DG.Tweening.TweenCallback val_9;
        if(this.tokenAmount == (state.<tokensRemaining>k__BackingField))
        {
                return;
        }
        
        DG.Tweening.TweenCallback val_4 = null;
        val_9 = val_4;
        val_4 = new DG.Tweening.TweenCallback(object:  this, method:  System.Void FPHTokenDisplay::<UpdateState>b__9_2());
        DG.Tweening.Tweener val_5 = DG.Tweening.TweenSettingsExtensions.OnUpdate<DG.Tweening.Tweener>(t:  DG.Tweening.DOTween.To(getter:  new DG.Tweening.Core.DOGetter<System.Int32>(object:  this, method:  System.Int32 FPHTokenDisplay::<UpdateState>b__9_0()), setter:  new DG.Tweening.Core.DOSetter<System.Int32>(object:  this, method:  System.Void FPHTokenDisplay::<UpdateState>b__9_1(int x)), endValue:  state.<tokensRemaining>k__BackingField, duration:  0.3f), action:  val_4);
        this = this.tokenText.transform;
        UnityEngine.Vector3 val_7 = new UnityEngine.Vector3(x:  0.3f, y:  0.3f, z:  0.3f);
        DG.Tweening.Tweener val_8 = DG.Tweening.ShortcutExtensions.DOPunchScale(target:  this, punch:  new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z}, duration:  0.3f, vibrato:  0, elasticity:  0.5f);
    }
    public void ShowOutOfTokens()
    {
        var val_13;
        var val_14;
        DG.Tweening.Tweener val_1 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.tokenTitleText, endValue:  0f, duration:  0.15f);
        this.ootDisplayBanner.alpha = 0f;
        this.ootDisplayBanner.gameObject.SetActive(value:  true);
        DG.Tweening.Tweener val_3 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.ootDisplayBanner, endValue:  1f, duration:  0.15f);
        GameBehavior val_4 = App.getBehavior;
        FPHEcon val_5 = App.GetGameSpecificEcon<FPHEcon>();
        val_13 = "SOLVE THE PUZZLE!";
        val_14 = "fph_oot_v1";
        string val_8 = Localization.Localize(key:  ((val_4.<metaGameBehavior>k__BackingField) < val_5.powerupHintUnlockLevel) ? (val_14) : "fph_oot_v2", defaultValue:  ((val_4.<metaGameBehavior>k__BackingField) < val_5.powerupHintUnlockLevel) ? (val_13) : "USE A HINT OR SOLVE!", useSingularKey:  false);
        UnityEngine.Transform val_9 = this.ootDisplayBanner.transform;
        if(val_9 != null)
        {
                if(null != null)
        {
            goto label_15;
        }
        
        }
        
        UnityEngine.Vector2 val_10 = new UnityEngine.Vector2(x:  -1000f, y:  0f);
        val_9.anchoredPosition = new UnityEngine.Vector2() {x = val_10.x, y = val_10.y};
        DG.Tweening.Tweener val_12 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOAnchorPosX(target:  val_9, endValue:  0f, duration:  1f, snapping:  false), ease:  3);
        return;
        label_15:
    }
    private string GetLetterCostDisplay(int cost)
    {
        return (string)System.String.Format(format:  "<color=#FFE640>{0}</color>", arg0:  cost);
    }
    public FPHTokenDisplay()
    {
    
    }
    private int <UpdateState>b__9_0()
    {
        return (int)this.tokenAmount;
    }
    private void <UpdateState>b__9_1(int x)
    {
        this.tokenAmount = x;
    }
    private void <UpdateState>b__9_2()
    {
        string val_1 = this.tokenAmount.ToString();
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }

}
