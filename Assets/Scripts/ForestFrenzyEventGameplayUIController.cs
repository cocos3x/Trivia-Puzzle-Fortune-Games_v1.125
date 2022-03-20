using UnityEngine;
public class ForestFrenzyEventGameplayUIController : MonoSingleton<ForestFrenzyEventGameplayUIController>
{
    // Fields
    private UnityEngine.GameObject eventButton;
    private UnityEngine.GameObject glowPrefab;
    private UnityEngine.GameObject currencyTextDisplayPrefab;
    private UnityEngine.GameObject gameSceneTextDisplayParent;
    private UnityEngine.ParticleSystem glowEffect;
    private UnityEngine.GameObject _CurrencyTextDisplayGroup;
    private TweenCoinsText _ShovelsTweenText;
    
    // Properties
    private bool IsFeaturedGameEvent { get; }
    private UnityEngine.GameObject CurrencyTextDisplayGroup { get; }
    private TweenCoinsText ShovelsTweenText { get; }
    
    // Methods
    private bool get_IsFeaturedGameEvent()
    {
        UnityEngine.Object val_9 = MonoSingleton<WordGameEventsController>.Instance;
        if(val_9 == 0)
        {
                return false;
        }
        
        val_9 = MonoSingleton<WordGameEventsController>.Instance;
        WGEventHandler val_7 = val_9.GetGameSceneOrderedEventHandler(dailyChallengeState:  MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge);
        if(val_7 == null)
        {
                return false;
        }
        
        return System.String.op_Equality(a:  val_7.EventType, b:  "ForestFrenzy");
    }
    private UnityEngine.GameObject get_CurrencyTextDisplayGroup()
    {
        UnityEngine.GameObject val_4;
        if(this._CurrencyTextDisplayGroup == 0)
        {
                this._CurrencyTextDisplayGroup = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.currencyTextDisplayPrefab, parent:  this.gameSceneTextDisplayParent.transform);
            return val_4;
        }
        
        val_4 = this._CurrencyTextDisplayGroup;
        return val_4;
    }
    private TweenCoinsText get_ShovelsTweenText()
    {
        TweenCoinsText val_4;
        if(this._ShovelsTweenText == 0)
        {
                this._ShovelsTweenText = this.CurrencyTextDisplayGroup.GetComponentInChildren<TweenCoinsText>();
            return val_4;
        }
        
        val_4 = this._ShovelsTweenText;
        return val_4;
    }
    private void Start()
    {
        var val_8;
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnForestFrenzyEventDataUpdate");
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnGameEventButtonUpdate");
        UnityEngine.GameObject val_3 = this.CurrencyTextDisplayGroup;
        val_3.SetActive(value:  val_3.IsFeaturedGameEvent);
        val_8 = null;
        val_8 = null;
        decimal val_7 = System.Decimal.op_Implicit(value:  ForestFrenzyEventProgress.accumulatedCurrency);
        this.ShovelsTweenText.Set(instantValue:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid});
    }
    public void UpdateCurrency(int from, int to)
    {
        bool val_1 = this.IsFeaturedGameEvent;
        this.CurrencyTextDisplayGroup.SetActive(value:  val_1);
        if(val_1 == false)
        {
                return;
        }
        
        TweenCoinsText val_4 = this.ShovelsTweenText;
        if(from < to)
        {
                decimal val_5 = System.Decimal.op_Implicit(value:  from);
            decimal val_6 = System.Decimal.op_Implicit(value:  to);
            val_4.Tween(startValue:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid}, endValue:  new System.Decimal() {flags = val_6.flags, hi = val_6.hi, lo = val_6.lo, mid = val_6.mid}, seconds:  0.5f);
            this.StartProgressHighlightingAnim();
            return;
        }
        
        decimal val_7 = System.Decimal.op_Implicit(value:  to);
        val_4.Set(instantValue:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid});
    }
    public void OnForestFrenzyEventDataUpdate()
    {
        this.RefreshUI();
    }
    public void OnGameEventButtonUpdate()
    {
        this.RefreshUI();
    }
    private void RefreshUI()
    {
        var val_12;
        var val_13;
        bool val_1 = this.IsFeaturedGameEvent;
        this.CurrencyTextDisplayGroup.SetActive(value:  val_1);
        if(val_1 == false)
        {
                return;
        }
        
        TweenCoinsText val_4 = this.ShovelsTweenText;
        val_12 = null;
        val_12 = null;
        decimal val_5 = System.Decimal.op_Implicit(value:  ForestFrenzyEventProgress.accumulatedCurrency);
        if((System.Decimal.op_LessThan(d1:  new System.Decimal() {flags = val_4.currentTextValue, hi = val_4.currentTextValue, lo = val_1, mid = val_1}, d2:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid})) == false)
        {
                return;
        }
        
        if(this.ShovelsTweenText.IsTweening != false)
        {
                return;
        }
        
        TweenCoinsText val_10 = this.ShovelsTweenText;
        val_13 = null;
        val_13 = null;
        decimal val_11 = System.Decimal.op_Implicit(value:  ForestFrenzyEventProgress.accumulatedCurrency);
        this.ShovelsTweenText.Tween(startValue:  new System.Decimal() {flags = val_10.currentTextValue, hi = val_10.currentTextValue, lo = val_4.currentTextValue, mid = val_4.currentTextValue}, endValue:  new System.Decimal() {flags = val_11.flags, hi = val_11.hi, lo = val_11.lo, mid = val_11.mid}, seconds:  0.5f);
        this.StartProgressHighlightingAnim();
    }
    private void StartProgressHighlightingAnim()
    {
        UnityEngine.ParticleSystem val_3 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.glowPrefab, parent:  this.eventButton.transform).GetComponent<UnityEngine.ParticleSystem>();
        this.glowEffect = val_3;
        UnityEngine.Vector3 val_5 = UnityEngine.Vector3.zero;
        val_3.transform.localPosition = new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z};
        this.glowEffect.Play();
        MainModule val_6 = this.glowEffect.main;
        this.Invoke(methodName:  "OnProgressHighlightingAnimFinished", time:  val_6.m_ParticleSystem.duration);
    }
    private void OnProgressHighlightingAnimFinished()
    {
        if(this.glowEffect == 0)
        {
                return;
        }
        
        if(this.glowEffect.gameObject == 0)
        {
                return;
        }
        
        UnityEngine.Object.Destroy(obj:  this.glowEffect.gameObject);
    }
    public ForestFrenzyEventGameplayUIController()
    {
    
    }

}
