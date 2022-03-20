using UnityEngine;
public class TweenCoinsText : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text coinText;
    public bool disableAfterTween;
    private DG.Tweening.Tweener tween;
    private decimal currentTextValue;
    private bool usingDecimal;
    
    // Properties
    public UnityEngine.UI.Text getCoinText { get; }
    public bool IsTweening { get; }
    public decimal CurrentTextValue { get; }
    
    // Methods
    public UnityEngine.UI.Text get_getCoinText()
    {
        return (UnityEngine.UI.Text)this.coinText;
    }
    public bool get_IsTweening()
    {
        if(this.tween == null)
        {
                return this.IsInvoking();
        }
        
        if((DG.Tweening.TweenExtensions.IsPlaying(t:  this.tween)) == false)
        {
                return this.IsInvoking();
        }
        
        return true;
    }
    public decimal get_CurrentTextValue()
    {
        return new System.Decimal() {flags = this.currentTextValue, hi = this.currentTextValue};
    }
    private void Start()
    {
        null = null;
        if(App.game == 15)
        {
                this.usingDecimal = true;
            return;
        }
        
        if(this.usingDecimal == true)
        {
                return;
        }
        
        if(this.coinText == 0)
        {
                return;
        }
        
        this.coinText.alignByGeometry = false;
    }
    public void Set(decimal instantValue)
    {
        this.usingDecimal = false;
        this.HaltImmediate();
        string val_1 = this.GetFormattedText(value:  new System.Decimal() {flags = instantValue.flags, hi = instantValue.hi, lo = instantValue.lo, mid = instantValue.mid});
        this.currentTextValue = instantValue;
        mem[1152921515534639464] = instantValue.lo;
        mem[1152921515534639468] = instantValue.mid;
    }
    public void Tween(decimal startValue, decimal endValue, float seconds)
    {
        int val_14;
        int val_15;
        val_14 = endValue.lo;
        val_15 = startValue.lo;
        TweenCoinsText.<>c__DisplayClass13_0 val_1 = new TweenCoinsText.<>c__DisplayClass13_0();
        .<>4__this = this;
        .endValue = endValue;
        mem[1152921515534831576] = val_14;
        mem[1152921515534831580] = endValue.mid;
        if((System.Decimal.op_Equality(d1:  new System.Decimal() {flags = endValue.flags, hi = endValue.hi, lo = val_14, mid = endValue.mid}, d2:  new System.Decimal() {flags = this.currentTextValue, hi = this.currentTextValue, lo = X25, mid = X25})) == true)
        {
                return;
        }
        
        this.HaltImmediate();
        .progress = System.Decimal.op_Explicit(value:  new System.Decimal() {flags = startValue.flags, hi = startValue.hi, lo = val_15, mid = startValue.mid});
        val_14 = 1152921504797261824;
        val_15 = DG.Tweening.TweenSettingsExtensions.OnUpdate<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.DOTween.To(setter:  new DG.Tweening.Core.DOSetter<System.Single>(object:  val_1, method:  System.Void TweenCoinsText.<>c__DisplayClass13_0::<Tween>b__0(float x)), startValue:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = startValue.flags, hi = startValue.hi, lo = val_15, mid = startValue.mid}), endValue:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = (TweenCoinsText.<>c__DisplayClass13_0)[1152921515534831536].endValue, hi = (TweenCoinsText.<>c__DisplayClass13_0)[1152921515534831536].endValue, lo = val_15, mid = startValue.mid}), duration:  seconds), ease:  1), action:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void TweenCoinsText.<>c__DisplayClass13_0::<Tween>b__1()));
        this.tween = DG.Tweening.TweenSettingsExtensions.SetAutoKill<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  val_15, action:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void TweenCoinsText.<>c__DisplayClass13_0::<Tween>b__2())), autoKillOnCompletion:  true);
    }
    public void CountUp(decimal endValue, float seconds)
    {
        int val_14;
        var val_15;
        val_14 = endValue.lo;
        TweenCoinsText.<>c__DisplayClass14_0 val_1 = new TweenCoinsText.<>c__DisplayClass14_0();
        .<>4__this = this;
        .endValue = endValue;
        mem[1152921515535020376] = val_14;
        mem[1152921515535020380] = endValue.mid;
        if((System.Decimal.op_Equality(d1:  new System.Decimal() {flags = endValue.flags, hi = endValue.hi, lo = val_14, mid = endValue.mid}, d2:  new System.Decimal() {flags = this.currentTextValue, hi = this.currentTextValue, lo = X23, mid = X23})) == true)
        {
                return;
        }
        
        this.HaltImmediate();
        .progress = System.Decimal.op_Explicit(value:  new System.Decimal() {flags = this.currentTextValue, hi = this.currentTextValue, lo = val_14, mid = endValue.mid});
        val_15 = 1152921504797261824;
        val_14 = DG.Tweening.TweenSettingsExtensions.OnUpdate<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.DOTween.To(setter:  new DG.Tweening.Core.DOSetter<System.Single>(object:  val_1, method:  System.Void TweenCoinsText.<>c__DisplayClass14_0::<CountUp>b__0(float x)), startValue:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = this.currentTextValue, hi = this.currentTextValue, lo = -1956728528, mid = 268435458}), endValue:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = (TweenCoinsText.<>c__DisplayClass14_0)[1152921515535020336].endValue, hi = (TweenCoinsText.<>c__DisplayClass14_0)[1152921515535020336].endValue, lo = -1956728528, mid = 268435458}), duration:  seconds), ease:  1), action:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void TweenCoinsText.<>c__DisplayClass14_0::<CountUp>b__1()));
        this.tween = DG.Tweening.TweenSettingsExtensions.SetAutoKill<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  val_14, action:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void TweenCoinsText.<>c__DisplayClass14_0::<CountUp>b__2())), autoKillOnCompletion:  true);
    }
    private void DisableAfter()
    {
        if(this.disableAfterTween == false)
        {
                return;
        }
        
        this.gameObject.SetActive(value:  false);
    }
    public void HaltImmediate()
    {
        if(this.tween != null)
        {
                DG.Tweening.TweenExtensions.Kill(t:  this.tween, complete:  false);
        }
        
        this.CancelInvoke();
    }
    private string GetFormattedText(decimal value)
    {
        var val_3;
        var val_4;
        string val_5;
        val_3 = this;
        if(this.usingDecimal != false)
        {
                val_3 = 1152921504972873728;
            val_4 = null;
            val_4 = null;
        }
        else
        {
                GameEcon val_1 = App.getGameEcon;
            val_5 = val_1.numberFormatInt;
        }
        
        return (string)value.flags.ToString(format:  mem[val_1.numberFormatInt]);
    }
    public TweenCoinsText()
    {
        this.disableAfterTween = true;
    }

}
