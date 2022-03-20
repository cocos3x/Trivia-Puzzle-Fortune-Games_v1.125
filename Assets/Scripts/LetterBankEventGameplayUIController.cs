using UnityEngine;
public class LetterBankEventGameplayUIController : MonoSingleton<LetterBankEventGameplayUIController>
{
    // Fields
    private UnityEngine.GameObject eventButton;
    private UnityEngine.GameObject glowPrefab;
    private UnityEngine.GameObject currencyTextDisplayGroup;
    private TweenCoinsText tweenCoinsText;
    private UnityEngine.ParticleSystem glowEffect;
    
    // Properties
    private bool IsFeaturedGameEvent { get; }
    
    // Methods
    private bool get_IsFeaturedGameEvent()
    {
        UnityEngine.Object val_14 = MonoSingleton<WordGameEventsController>.Instance;
        if(val_14 == 0)
        {
                return false;
        }
        
        val_14 = MonoSingleton<WordGameEventsController>.Instance;
        if((val_14.GetGameSceneOrderedEventHandler(dailyChallengeState:  MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge)) == null)
        {
                return false;
        }
        
        return System.String.op_Equality(a:  MonoSingleton<WordGameEventsController>.Instance.GetGameSceneOrderedEventHandler(dailyChallengeState:  MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge).EventType, b:  "LetterBank");
    }
    private void Start()
    {
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnLetterBankEventDataUpdate");
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnGameEventButtonUpdate");
        this.RefreshUI();
    }
    public void UpdateCurrency(int from, int to)
    {
        if(this.IsFeaturedGameEvent == false)
        {
                return;
        }
        
        if(from < to)
        {
                decimal val_2 = System.Decimal.op_Implicit(value:  from);
            decimal val_3 = System.Decimal.op_Implicit(value:  to);
            this.tweenCoinsText.Tween(startValue:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid}, endValue:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid}, seconds:  0.5f);
            this.StartProgressHighlightingAnim();
            return;
        }
        
        decimal val_4 = System.Decimal.op_Implicit(value:  to);
        this.tweenCoinsText.Set(instantValue:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid});
    }
    public void OnLetterBankEventDataUpdate()
    {
        this.RefreshUI();
    }
    public void OnGameEventButtonUpdate()
    {
        this.RefreshUI();
    }
    public void SetEventButtonAndText(UnityEngine.GameObject evtBtn, TweenCoinsText twnCoinsText)
    {
        this.eventButton = evtBtn;
        this.tweenCoinsText = twnCoinsText;
    }
    private void RefreshUI()
    {
        var val_7;
        var val_8;
        if(this.tweenCoinsText == 0)
        {
                return;
        }
        
        val_7 = null;
        decimal val_3 = System.Decimal.op_Implicit(value:  LetterBankEventHandler.MyScore);
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = this.tweenCoinsText.currentTextValue, hi = this.tweenCoinsText.currentTextValue, lo = this.tweenCoinsText, mid = this.tweenCoinsText}, d2:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid})) != false)
        {
                return;
        }
        
        val_8 = null;
        decimal val_6 = System.Decimal.op_Implicit(value:  LetterBankEventHandler.MyScore);
        this.tweenCoinsText.Set(instantValue:  new System.Decimal() {flags = val_6.flags, hi = val_6.hi, lo = val_6.lo, mid = val_6.mid});
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
    public LetterBankEventGameplayUIController()
    {
    
    }

}
