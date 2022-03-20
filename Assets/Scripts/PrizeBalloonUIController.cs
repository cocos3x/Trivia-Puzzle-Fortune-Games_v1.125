using UnityEngine;
public class PrizeBalloonUIController : MonoSingleton<PrizeBalloonUIController>
{
    // Fields
    private UnityEngine.UI.Button balloon;
    private UnityEngine.Transform start;
    private UnityEngine.Transform end;
    private int coinReward;
    private DG.Tweening.Tweener balloonTweener;
    private UnityEngine.Coroutine balloonShowingCoroutine;
    private System.Action onClose;
    
    // Methods
    public override void InitMonoSingleton()
    {
        this.HideBalloon();
        this.balloon.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void PrizeBalloonUIController::OnBalloonTapped()));
    }
    public void Setup(int amount, System.Action onClose)
    {
        if(this.balloonShowingCoroutine != null)
        {
                return;
        }
        
        this.coinReward = amount;
        this.onClose = onClose;
        this.balloonShowingCoroutine = this.StartCoroutine(routine:  this.StartShowingBalloon());
    }
    private System.Collections.IEnumerator StartShowingBalloon()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new PrizeBalloonUIController.<StartShowingBalloon>d__9();
    }
    private void OnBalloonTapped()
    {
        this.balloon.interactable = false;
        if(this.balloonTweener != null)
        {
                DG.Tweening.TweenExtensions.Kill(t:  this.balloonTweener, complete:  false);
        }
        
        this.StopCoroutine(routine:  this.balloonShowingCoroutine);
        MonoSingleton<WGPrizeBalloonManager>.Instance.CollectReward(amount:  this.coinReward);
        UnityEngine.Coroutine val_3 = this.StartCoroutine(routine:  this.HideBalloonCoroutine());
        MainController val_4 = MainController.instance;
        Player val_5 = App.Player;
        decimal val_6 = System.Decimal.op_Implicit(value:  this.coinReward);
        decimal val_7 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_5._credits, hi = val_5._credits, lo = X21, mid = X21}, d2:  new System.Decimal() {flags = val_6.flags, hi = val_6.hi, lo = val_6.lo, mid = val_6.mid});
        decimal val_9 = System.Decimal.op_Implicit(value:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid}));
        Player val_10 = App.Player;
        val_4.coin_stat_view_anim.Play(startCoins:  new System.Decimal() {flags = val_9.flags, hi = val_9.hi, lo = val_9.lo, mid = val_9.mid}, finalCoins:  new System.Decimal() {flags = val_10._credits, hi = val_10._credits, lo = this.coinReward, mid = this.coinReward}, particleStart:  this.balloon.transform, forceTextTween:  true);
    }
    private System.Collections.IEnumerator HideBalloonCoroutine()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new PrizeBalloonUIController.<HideBalloonCoroutine>d__11();
    }
    private void HideBalloon()
    {
        this.balloon.interactable = true;
        this.balloon.gameObject.SetActive(value:  false);
        if(this.balloonShowingCoroutine != null)
        {
                this.StopCoroutine(routine:  this.balloonShowingCoroutine);
            this.balloonShowingCoroutine = 0;
        }
        
        if(this.onClose == null)
        {
                return;
        }
        
        this.onClose.Invoke();
        this.onClose = 0;
    }
    public PrizeBalloonUIController()
    {
    
    }

}
