using UnityEngine;
public abstract class CurrencyStatView : MonoBehaviour
{
    // Fields
    private static readonly System.Collections.Hashtable animTrueHT;
    private static readonly System.Collections.Hashtable animFalseHT;
    private UnityEngine.UI.Button touchArea;
    protected TweenCoinsText text;
    protected UnityEngine.Transform currencyIcon;
    private float countUpTime;
    protected UnityEngine.UI.Button storeButton;
    protected bool autoUpdate;
    protected decimal artificalTargetBalance;
    private int loops;
    private DG.Tweening.Tweener punchSequence;
    public System.Action OnAnimateComplete;
    
    // Properties
    public UnityEngine.UI.Button getStoreButton { get; }
    public TweenCoinsText getText { get; }
    public UnityEngine.Transform AppleIcon { get; }
    public bool Interactable { get; set; }
    public bool SetAutoUpdate { set; }
    protected virtual CurrencyType getMyCurrency { get; }
    
    // Methods
    public static System.Collections.Hashtable GetAnimHT(bool shouldAnimate)
    {
        var val_1;
        var val_2;
        var val_3;
        var val_4;
        val_1 = null;
        if(shouldAnimate != false)
        {
                val_2 = null;
            return (System.Collections.Hashtable)val_3;
        }
        
        val_4 = null;
        val_3 = 1152921504969949192;
        return (System.Collections.Hashtable)val_3;
    }
    public UnityEngine.UI.Button get_getStoreButton()
    {
        return (UnityEngine.UI.Button)this.storeButton;
    }
    public TweenCoinsText get_getText()
    {
        return (TweenCoinsText)this.text;
    }
    public UnityEngine.Transform get_AppleIcon()
    {
        if(this.currencyIcon != 0)
        {
                return (UnityEngine.Transform)this.currencyIcon;
        }
        
        UnityEngine.Transform val_3 = new UnityEngine.GameObject(name:  "missing currencyIcon").transform;
        this.currencyIcon = val_3;
        val_3.transform.SetParent(parent:  this.gameObject.transform, worldPositionStays:  false);
        return (UnityEngine.Transform)this.currencyIcon;
    }
    public bool get_Interactable()
    {
        var val_3;
        if(this.touchArea != 0)
        {
                var val_2 = (this.touchArea != 0) ? 1 : 0;
            return (bool)val_3;
        }
        
        val_3 = 0;
        return (bool)val_3;
    }
    public void set_Interactable(bool value)
    {
        if(this.touchArea != 0)
        {
                this.touchArea.interactable = value;
        }
        
        if(this.storeButton == 0)
        {
                return;
        }
        
        this.storeButton.gameObject.SetActive(value:  value);
    }
    public void set_SetAutoUpdate(bool value)
    {
        this.autoUpdate = value;
    }
    private void Awake()
    {
        CurrencyController.AddCurrencyListener(onChangeAction:  new System.Action(object:  this, method:  System.Void CurrencyStatView::OnBalanceChanged()), type:  this);
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnServerSync");
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  this);
        if(this.touchArea == 0)
        {
                return;
        }
        
        this.touchArea.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  typeof(CurrencyStatView).__il2cppRuntimeField_198));
    }
    private void OnServerSync()
    {
        if(this.autoUpdate == false)
        {
                return;
        }
        
        goto typeof(CurrencyStatView).__il2cppRuntimeField_180;
    }
    protected virtual void OnEnable()
    {
        if(this.autoUpdate == false)
        {
                return;
        }
        
        goto typeof(CurrencyStatView).__il2cppRuntimeField_180;
    }
    private void OnDisable()
    {
        CurrencyController.RemoveCurrencyListener(onChangeAction:  new System.Action(object:  this, method:  System.Void CurrencyStatView::OnBalanceChanged()), type:  this);
    }
    public void SetTargetBalance(decimal targetBalance)
    {
        this.artificalTargetBalance = targetBalance;
        mem[1152921517464896892] = targetBalance.lo;
        mem[1152921517464896896] = targetBalance.mid;
    }
    public void SetBalanceNow(decimal newBalance)
    {
        if(this.text == 0)
        {
                return;
        }
        
        this.text.Set(instantValue:  new System.Decimal() {flags = newBalance.flags, hi = newBalance.hi, lo = newBalance.lo, mid = newBalance.mid});
    }
    protected virtual void UpdateBalance(bool instantly = False)
    {
        if(this.text == 0)
        {
                UnityEngine.Debug.LogError(message:  "text not set on " + this.gameObject.name);
            return;
        }
        
        if(instantly != false)
        {
                this.text.Set(instantValue:  new System.Decimal() {flags = -26569568, hi = 268435458, lo = typeof(CurrencyStatView).__il2cppRuntimeField_1B8, mid = typeof(CurrencyStatView).__il2cppRuntimeField_1B8});
            mem[1152921517465179372] = 0;
            this.artificalTargetBalance = 0m;
            return;
        }
        
        this.text.CountUp(endValue:  new System.Decimal() {flags = -26569568, hi = 268435458, lo = typeof(CurrencyStatView).__il2cppRuntimeField_1B8, mid = typeof(CurrencyStatView).__il2cppRuntimeField_1B8}, seconds:  this.countUpTime);
        if(this.punchSequence != null)
        {
                if((DG.Tweening.TweenExtensions.IsPlaying(t:  this.punchSequence)) != false)
        {
                int val_11 = this.loops;
            val_11 = val_11 + 1;
            this.loops = val_11;
            return;
        }
        
        }
        
        UnityEngine.Vector3 val_7 = new UnityEngine.Vector3(x:  0.15f, y:  0.15f, z:  0f);
        this.punchSequence = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOPunchScale(target:  this.AppleIcon, punch:  new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z}, duration:  0.35f, vibrato:  1, elasticity:  1f), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void CurrencyStatView::<UpdateBalance>b__30_0()));
    }
    private void PlayAnotherPunchTween()
    {
        if(this.loops >= 1)
        {
                UnityEngine.Vector3 val_2 = new UnityEngine.Vector3(x:  0.15f, y:  0.15f, z:  0f);
            this.punchSequence = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOPunchScale(target:  this.AppleIcon, punch:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z}, duration:  0.35f, vibrato:  1, elasticity:  1f), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void CurrencyStatView::<PlayAnotherPunchTween>b__31_0()));
            return;
        }
        
        if(this.OnAnimateComplete != null)
        {
                this.OnAnimateComplete.Invoke();
        }
        
        mem[1152921517465353836] = 0;
        this.artificalTargetBalance = 0m;
    }
    private void OnBalanceChanged()
    {
        if(this.autoUpdate == false)
        {
                return;
        }
        
        goto typeof(CurrencyStatView).__il2cppRuntimeField_180;
    }
    protected abstract void OnTouchAreaClicked(); // 0
    protected abstract string GetBalanceUpdateNotificationName(); // 0
    protected abstract decimal GetCountUpBalance(); // 0
    protected virtual CurrencyType get_getMyCurrency()
    {
        return 0;
    }
    protected CurrencyStatView()
    {
        this.countUpTime = 0.5f;
        this.autoUpdate = true;
    }
    private static CurrencyStatView()
    {
        CurrencyStatView.animTrueHT = new System.Collections.Hashtable();
        CurrencyStatView.animFalseHT = new System.Collections.Hashtable();
    }
    private void <UpdateBalance>b__30_0()
    {
        this.PlayAnotherPunchTween();
    }
    private void <PlayAnotherPunchTween>b__31_0()
    {
        this.PlayAnotherPunchTween();
        int val_1 = this.loops;
        val_1 = val_1 - 1;
        this.loops = val_1;
    }

}
