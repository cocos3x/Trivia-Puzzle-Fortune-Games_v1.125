using UnityEngine;
public class TRVProgressiveIAPProgressPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text fillText;
    private UnityEngine.UI.Text freeText;
    private UnityEngine.UI.Image fillBar;
    private UnityEngine.RectTransform banner;
    private UnityEngine.RectTransform barParent;
    private UnityEngine.RectTransform giftClosed;
    private UnityEngine.RectTransform giftOpened;
    private UnityEngine.GameObject giftParticleSystem;
    private UnityEngine.UI.Button openGiftButton;
    private UnityEngine.UI.Slider sliderProgressBar;
    private System.Action onAwake;
    private bool hasGiftOpened;
    private TRVProgressiveIAPHandler handler;
    
    // Methods
    private void OnEnable()
    {
        if(this.onAwake != null)
        {
                this.onAwake.Invoke();
        }
        
        this.onAwake = 0;
    }
    public void Init()
    {
        if(this.gameObject.activeInHierarchy != false)
        {
                this.AnimateProgressBar();
            return;
        }
        
        this.onAwake = new System.Action(object:  this, method:  System.Void TRVProgressiveIAPProgressPopup::AnimateProgressBar());
    }
    private void AnimateProgressBar()
    {
        var val_8;
        this.handler = TRVProgressiveIAPHandler.BONUS_MULTIPLIER;
        int val_1 = (TRVProgressiveIAPHandler.BONUS_MULTIPLIER + 56) - 1;
        int val_2 = TRVProgressiveIAPHandler.BONUS_MULTIPLIER.GetCurrentTierProgress(calculatedProgress:  val_1);
        int val_3 = this.handler.GetCurrentTierRequirement(calculatedProgress:  val_1);
        var val_10 = 0;
        var val_9 = 0;
        label_9:
        if(val_10 >= this.handler.levelRq.Length)
        {
            goto label_6;
        }
        
        val_9 = this.handler.levelRq[val_10] + val_9;
        if((TRVProgressiveIAPHandler.BONUS_MULTIPLIER + 56) == val_9)
        {
            goto label_8;
        }
        
        val_10 = val_10 + 1;
        if(this.handler.levelRq != null)
        {
            goto label_9;
        }
        
        throw new NullReferenceException();
        label_6:
        val_8 = 0;
        goto label_10;
        label_8:
        val_8 = 1;
        label_10:
        string val_5 = System.String.Format(format:  "{0}/{1}", arg0:  val_2, arg1:  val_3);
        float val_11 = (float)val_2;
        val_11 = val_11 / (float)val_3;
        this.SetBarProgress(progressAmount:  val_11);
        float val_12 = (float)val_2 + 1;
        val_12 = val_12 / (float)val_3;
        UnityEngine.Coroutine val_7 = this.StartCoroutine(routine:  this.AnimateBarFill(targetFillAmount:  val_12, openPurchasePopup:  true, req:  val_3));
    }
    private System.Collections.IEnumerator AnimateBarFill(float targetFillAmount, bool openPurchasePopup, int req)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .targetFillAmount = targetFillAmount;
        .openPurchasePopup = openPurchasePopup;
        .req = req;
        return (System.Collections.IEnumerator)new TRVProgressiveIAPProgressPopup.<AnimateBarFill>d__16();
    }
    private System.Collections.IEnumerator AnimateGiftOpening()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new TRVProgressiveIAPProgressPopup.<AnimateGiftOpening>d__17();
    }
    private void SetBarProgress(float progressAmount)
    {
        if(this.fillBar != 0)
        {
                this.fillBar.fillAmount = progressAmount;
        }
        
        if(this.sliderProgressBar == 0)
        {
                return;
        }
        
        this = ???;
        goto typeof(UnityEngine.UI.Slider).__il2cppRuntimeField_420;
    }
    private void TweenProgressBar(float target, float duration)
    {
        if(this.fillBar != 0)
        {
                DG.Tweening.Tweener val_2 = DG.Tweening.ShortcutExtensions46.DOFillAmount(target:  this.fillBar, endValue:  target, duration:  duration);
        }
        
        if(this.sliderProgressBar == 0)
        {
                return;
        }
        
        DG.Tweening.Tweener val_4 = DG.Tweening.ShortcutExtensions46.DOValue(target:  this.sliderProgressBar, endValue:  target, duration:  duration, snapping:  false);
    }
    public TRVProgressiveIAPProgressPopup()
    {
    
    }
    private void <AnimateBarFill>b__16_0()
    {
        this.StopAllCoroutines();
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.AnimateGiftOpening());
    }

}
