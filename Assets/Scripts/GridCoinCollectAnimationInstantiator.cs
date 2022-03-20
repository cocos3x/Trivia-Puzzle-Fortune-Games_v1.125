using UnityEngine;
public class GridCoinCollectAnimationInstantiator : StatViewInstantiatior
{
    // Fields
    private GridCoinCollectAnimationInstantiator.StoreButtonBehavior storeButtonStartBehavior;
    private bool disableWhenComplete;
    private UnityEngine.Transform animParentXfm;
    private int maxCoins;
    private float textTweenTime;
    private UnityEngine.Transform collectTarget;
    private float delayBeforeAnimationConclusion;
    private GridCoinCollectAnimation.BalanceCountOptions whenToCount;
    private PlayerCoinAddedBalance playerCoinAddedBalance;
    private UnityEngine.GameObject StatViewObjectOverride;
    private GridCoinCollectAnimation AnimObjectOverride;
    protected UnityEngine.Vector2 tweenPointBeforePlay;
    public System.Action OnCompleteCallback;
    private UnityEngine.GameObject animObject;
    private GridCoinCollectAnimation anim;
    private decimal startValue;
    private decimal finalValue;
    private bool firstCoinReached;
    private bool coinExpansionEnabled;
    private static System.Collections.Generic.List<GridCoinCollectAnimationInstantiator> gridCoinCollectAnimInstances;
    
    // Properties
    public UnityEngine.GameObject StatViewObject { get; }
    
    // Methods
    public UnityEngine.GameObject get_StatViewObject()
    {
        return (UnityEngine.GameObject)this;
    }
    protected override void SetupAnimatedElements()
    {
        UnityEngine.Transform val_20;
        GridCoinCollectAnimation val_21;
        UnityEngine.Transform val_22;
        CurrencyBalance val_1 = 13352.GetComponentInChildren<CurrencyBalance>();
        if((UnityEngine.Object.op_Implicit(exists:  val_1)) != false)
        {
                UnityEngine.Object.Destroy(obj:  val_1);
        }
        
        Player val_3 = App.Player;
        val_1.Set(instantValue:  new System.Decimal() {flags = val_3._credits, hi = val_3._credits});
        if(this.storeButtonStartBehavior != 0)
        {
                UnityEngine.UI.Button val_4 = val_1.GetComponentInChildren<UnityEngine.UI.Button>(includeInactive:  true);
            if(val_4 != 0)
        {
                if(this.storeButtonStartBehavior == 1)
        {
                val_4.gameObject.SetActive(value:  false);
        }
        else
        {
                val_4.interactable = false;
        }
        
        }
        
        }
        
        bool val_7 = UnityEngine.Object.op_Equality(x:  this.AnimObjectOverride, y:  0);
        if(val_7 == false)
        {
            goto label_22;
        }
        
        if(this.animParentXfm != 0)
        {
            goto label_26;
        }
        
        val_20 = this.transform;
        goto label_27;
        label_22:
        val_21 = this.anim;
        this.anim = this.AnimObjectOverride;
        if(this.AnimObjectOverride != null)
        {
            goto label_28;
        }
        
        label_26:
        val_20 = this.animParentXfm;
        label_27:
        UnityEngine.GameObject val_12 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  val_7.GetGridCoinCollectAnimationPrefab().gameObject, parent:  val_20);
        this.animObject = val_12;
        GridCoinCollectAnimation val_13 = val_12.GetComponent<GridCoinCollectAnimation>();
        val_21 = this;
        this.anim = val_13;
        label_28:
        val_13.SetMaxCoins(coins:  this.maxCoins);
        System.Delegate val_15 = System.Delegate.Combine(a:  this.anim.OnCoinDepositSpecialAction, b:  new System.Action<System.Boolean>(object:  this, method:  public System.Void GridCoinCollectAnimationInstantiator::OnCoinReachedBank(bool textTickerOnly)));
        if(val_15 != null)
        {
                if(null != null)
        {
            goto label_36;
        }
        
        }
        
        this.anim.OnCoinDepositSpecialAction = val_15;
        UnityEngine.Transform val_17 = val_15.transform.Find(n:  "coinFlyToPoint");
        this.collectTarget = val_17;
        if(val_17 != 0)
        {
            goto label_41;
        }
        
        UnityEngine.Transform val_19 = this.transform;
        if(this.anim != null)
        {
            goto label_42;
        }
        
        label_41:
        val_22 = this.collectTarget;
        label_42:
        this.anim.collectTarget = val_22;
        playerCoinAddedBalance = this.playerCoinAddedBalance;
        this.anim.whenToCount = this.whenToCount;
        GridCoinCollectAnimationInstantiator.AddToNotificationList(instance:  this);
        return;
        label_36:
    }
    private void OnDestroy()
    {
        GridCoinCollectAnimationInstantiator.RemoveFromNotificationList(instance:  this);
    }
    public static void AddToNotificationList(GridCoinCollectAnimationInstantiator instance)
    {
        var val_2;
        var val_3;
        val_2 = null;
        val_2 = null;
        if(GridCoinCollectAnimationInstantiator.gridCoinCollectAnimInstances == null)
        {
                System.Collections.Generic.List<GridCoinCollectAnimationInstantiator> val_1 = new System.Collections.Generic.List<GridCoinCollectAnimationInstantiator>();
            val_3 = null;
            val_3 = null;
            GridCoinCollectAnimationInstantiator.gridCoinCollectAnimInstances = val_1;
            val_2 = null;
        }
        
        val_2 = null;
        val_1.Add(item:  instance);
    }
    public static void RemoveFromNotificationList(GridCoinCollectAnimationInstantiator instance)
    {
        var val_2;
        System.Collections.Generic.List<GridCoinCollectAnimationInstantiator> val_3;
        val_2 = null;
        val_2 = null;
        val_3 = GridCoinCollectAnimationInstantiator.gridCoinCollectAnimInstances;
        if(val_3 == null)
        {
                return;
        }
        
        val_3 = GridCoinCollectAnimationInstantiator.gridCoinCollectAnimInstances;
        bool val_1 = val_3.Remove(item:  instance);
    }
    public void SetCoinStartPosition(UnityEngine.Vector3 pos)
    {
        this.animObject.transform.position = new UnityEngine.Vector3() {x = pos.x, y = pos.y, z = pos.z};
    }
    public void Set(decimal instantValue)
    {
        this.Create();
        this.Set(instantValue:  new System.Decimal() {flags = instantValue.flags, hi = instantValue.hi, lo = instantValue.lo, mid = instantValue.mid});
        this.SetActive(value:  true);
    }
    public void Play(decimal fromValue, decimal toValue, float textTickTime = -1, float delayBeforeComplete = -1)
    {
        System.Collections.Generic.List<T> val_11;
        var val_12;
        var val_13;
        System.Predicate<GridCoinCollectAnimationInstantiator> val_15;
        System.Collections.Generic.IEnumerable<T> val_16;
        var val_17;
        var val_18;
        var val_19;
        var val_20;
        var val_21;
        var val_22;
        val_12 = null;
        val_12 = null;
        val_13 = null;
        val_13 = null;
        val_15 = GridCoinCollectAnimationInstantiator.<>c.<>9__29_0;
        if(val_15 == null)
        {
                System.Predicate<GridCoinCollectAnimationInstantiator> val_1 = null;
            val_15 = val_1;
            val_1 = new System.Predicate<GridCoinCollectAnimationInstantiator>(object:  GridCoinCollectAnimationInstantiator.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean GridCoinCollectAnimationInstantiator.<>c::<Play>b__29_0(GridCoinCollectAnimationInstantiator x));
            GridCoinCollectAnimationInstantiator.<>c.<>9__29_0 = val_15;
        }
        
        val_16 = GridCoinCollectAnimationInstantiator.gridCoinCollectAnimInstances.FindAll(match:  val_1);
        val_17 = null;
        val_17 = null;
        GridCoinCollectAnimationInstantiator.gridCoinCollectAnimInstances = new System.Collections.Generic.List<GridCoinCollectAnimationInstantiator>(collection:  val_16);
        val_18 = null;
        if(mem[1152921515812531352] < 0)
        {
                return;
        }
        
        val_16 = mem[1152921515812531352] - 2;
        label_39:
        val_18 = null;
        var val_4 = val_16 + 1;
        if(mem[1152921515812531352] <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_10 = mem[1152921515812531344];
        val_10 = val_10 + (val_4 << 3);
        val_19 = null;
        if(((mem[1152921515812531344] + (((mem[1152921515812531352] - 2) + 1)) << 3) + 32.gameObject.activeInHierarchy) == false)
        {
            goto label_19;
        }
        
        val_20 = null;
        if(mem[1152921515812531352] <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_11 = mem[1152921515812531344];
        val_11 = val_11 + (((long)(int)(((mem[1152921515812531352] - 2) + 1))) << 3);
        val_21 = null;
        val_21 = null;
        val_11 = GridCoinCollectAnimationInstantiator.gridCoinCollectAnimInstances;
        if(mem[1152921515812531352] <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_12 = mem[1152921515812531344];
        val_12 = val_12 + (((long)(int)(((mem[1152921515812531352] - 2) + 1))) << 3);
        (mem[1152921515812531344] + ((long)(int)(((mem[1152921515812531352] - 2) + 1))) << 3) + 32.PlayCoinCollectAnimation(fromValue:  new System.Decimal() {flags = fromValue.flags, hi = fromValue.hi, lo = fromValue.lo, mid = fromValue.mid}, toValue:  new System.Decimal() {flags = toValue.flags, hi = toValue.hi, lo = toValue.lo, mid = toValue.mid}, textTickTime:  textTickTime, delayBeforeComplete:  delayBeforeComplete, doCoinTextTickerOnly:  (UnityEngine.Object.op_Equality(x:  (mem[1152921515812531344] + ((long)(int)(((mem[1152921515812531352] - 2) + 1))) << 3) + 32, y:  this)) ^ 1);
        if((val_16 & 2147483648) == 0)
        {
            goto label_31;
        }
        
        return;
        label_19:
        val_22 = null;
        if(mem[1152921515812531352] <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_13 = mem[1152921515812531344];
        val_13 = val_13 + (((long)(int)(((mem[1152921515812531352] - 2) + 1))) << 3);
        (mem[1152921515812531344] + ((long)(int)(((mem[1152921515812531352] - 2) + 1))) << 3) + 32.Set(instantValue:  new System.Decimal() {flags = toValue.flags, hi = toValue.hi, lo = toValue.lo, mid = toValue.mid});
        if((val_16 & 2147483648) != 0)
        {
                return;
        }
        
        label_31:
        val_16 = val_16 - 1;
        goto label_39;
    }
    private void PlayCoinCollectAnimation(decimal fromValue, decimal toValue, float textTickTime = -1, float delayBeforeComplete = -1, bool doCoinTextTickerOnly = False)
    {
        GridCoinCollectAnimationInstantiator.<>c__DisplayClass30_0 val_1 = new GridCoinCollectAnimationInstantiator.<>c__DisplayClass30_0();
        .<>4__this = this;
        .fromValue = fromValue;
        mem[1152921515812677152] = fromValue.lo;
        mem[1152921515812677156] = fromValue.mid;
        .toValue = toValue;
        mem[1152921515812677168] = toValue.lo;
        mem[1152921515812677172] = toValue.mid;
        .textTickTime = textTickTime;
        .delayBeforeComplete = delayBeforeComplete;
        .doCoinTextTickerOnly = doCoinTextTickerOnly;
        val_1.SetActive(value:  true);
        if(((GridCoinCollectAnimationInstantiator.<>c__DisplayClass30_0)[1152921515812677120].textTickTime) != (-1f))
        {
                this.textTweenTime = (GridCoinCollectAnimationInstantiator.<>c__DisplayClass30_0)[1152921515812677120].textTickTime;
        }
        
        if(((GridCoinCollectAnimationInstantiator.<>c__DisplayClass30_0)[1152921515812677120].delayBeforeComplete) != (-1f))
        {
                this.delayBeforeAnimationConclusion = (GridCoinCollectAnimationInstantiator.<>c__DisplayClass30_0)[1152921515812677120].delayBeforeComplete;
        }
        
        this.startValue = (GridCoinCollectAnimationInstantiator.<>c__DisplayClass30_0)[1152921515812677120].fromValue;
        this.finalValue = (GridCoinCollectAnimationInstantiator.<>c__DisplayClass30_0)[1152921515812677120].toValue;
        this.Set(instantValue:  new System.Decimal() {flags = (GridCoinCollectAnimationInstantiator.<>c__DisplayClass30_0)[1152921515812677120].fromValue, hi = (GridCoinCollectAnimationInstantiator.<>c__DisplayClass30_0)[1152921515812677120].fromValue});
        UnityEngine.Vector2 val_3 = UnityEngine.Vector2.zero;
        bool val_4 = UnityEngine.Vector2.op_Inequality(lhs:  new UnityEngine.Vector2() {x = this.tweenPointBeforePlay, y = delayBeforeComplete}, rhs:  new UnityEngine.Vector2() {x = val_3.x, y = val_3.y});
        if(val_4 != false)
        {
                UnityEngine.Transform val_5 = val_4.transform;
            UnityEngine.Vector3 val_6 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = this.tweenPointBeforePlay, y = delayBeforeComplete});
            val_5.localPosition = new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z};
            UnityEngine.Vector2 val_8 = UnityEngine.Vector2.zero;
            UnityEngine.Vector3 val_9 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = val_8.x, y = val_8.y});
            DG.Tweening.Tweener val_12 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOLocalMove(target:  val_5.transform, endValue:  new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z}, duration:  0.5f, snapping:  false), action:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void GridCoinCollectAnimationInstantiator.<>c__DisplayClass30_0::<PlayCoinCollectAnimation>b__0()));
            return;
        }
        
        this.ContinueCoinCollectAnimation(fromValue:  new System.Decimal() {flags = (GridCoinCollectAnimationInstantiator.<>c__DisplayClass30_0)[1152921515812677120].fromValue, hi = (GridCoinCollectAnimationInstantiator.<>c__DisplayClass30_0)[1152921515812677120].fromValue}, toValue:  new System.Decimal() {flags = (GridCoinCollectAnimationInstantiator.<>c__DisplayClass30_0)[1152921515812677120].toValue, hi = (GridCoinCollectAnimationInstantiator.<>c__DisplayClass30_0)[1152921515812677120].toValue, lo = toValue.lo, mid = toValue.mid}, textTickTime:  this.tweenPointBeforePlay, delayBeforeComplete:  delayBeforeComplete, doCoinTextTickerOnly:  (GridCoinCollectAnimationInstantiator.<>c__DisplayClass30_0)[1152921515812677120].doCoinTextTickerOnly);
    }
    private void ContinueCoinCollectAnimation(decimal fromValue, decimal toValue, float textTickTime = -1, float delayBeforeComplete = -1, bool doCoinTextTickerOnly = False)
    {
        decimal val_1 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = toValue.flags, hi = toValue.hi, lo = toValue.lo, mid = toValue.mid}, d2:  new System.Decimal() {flags = fromValue.flags, hi = fromValue.hi, lo = fromValue.lo, mid = fromValue.mid});
        this.firstCoinReached = false;
        if(doCoinTextTickerOnly != false)
        {
                this.OnCoinReachedBank(textTickerOnly:  true);
            return;
        }
        
        this.anim.coinExpansionEnabled = this.coinExpansionEnabled;
        this.anim.Play(coinsCount:  UnityEngine.Mathf.Min(a:  this.maxCoins, b:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid})));
    }
    private void OnEnable()
    {
        this.Create();
    }
    private void OnDisable()
    {
        if(W8 == 0)
        {
                return;
        }
        
        if(this.anim != null)
        {
                this.anim.Reset();
            return;
        }
        
        throw new NullReferenceException();
    }
    public void OnCoinReachedBank(bool textTickerOnly = False)
    {
        if(this.firstCoinReached != false)
        {
                return;
        }
        
        this.firstCoinReached = true;
        this.Tween(startValue:  new System.Decimal() {flags = this.startValue, hi = this.startValue}, endValue:  new System.Decimal() {flags = this.finalValue, hi = this.finalValue}, seconds:  this.textTweenTime);
        UnityEngine.Coroutine val_3 = this.StartCoroutine(routine:  this.ConcludeAnimationDelay(textTickerOnly:  textTickerOnly));
    }
    private System.Collections.IEnumerator ConcludeAnimationDelay(bool textTickerOnly = False)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .textTickerOnly = textTickerOnly;
        return (System.Collections.IEnumerator)new GridCoinCollectAnimationInstantiator.<ConcludeAnimationDelay>d__35();
    }
    private void ConcludeAnimation(bool textTickerOnly = False)
    {
        if((this.OnCompleteCallback != null) && (textTickerOnly != true))
        {
                this.OnCompleteCallback.Invoke();
        }
        
        if(this.disableWhenComplete != false)
        {
                UnityEngine.Vector2 val_1 = UnityEngine.Vector2.zero;
            if((UnityEngine.Vector2.op_Inequality(lhs:  new UnityEngine.Vector2() {x = this.tweenPointBeforePlay, y = V8.16B}, rhs:  new UnityEngine.Vector2() {x = val_1.x, y = val_1.y})) != false)
        {
                UnityEngine.Vector3 val_4 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = this.tweenPointBeforePlay, y = V8.16B});
            DG.Tweening.Tweener val_7 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOLocalMove(target:  UnityEngine.Vector2.__il2cppRuntimeField_cctor_finished.transform, endValue:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z}, duration:  0.5f, snapping:  false), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void GridCoinCollectAnimationInstantiator::<ConcludeAnimation>b__36_0()));
        }
        else
        {
                UnityEngine.Vector2.__il2cppRuntimeField_cctor_finished.SetActive(value:  false);
        }
        
        }
        
        CurrencyController.HandleBalanceChanged(type:  0);
    }
    protected override UnityEngine.GameObject GetPrefabFromTheme()
    {
        UnityEngine.Object val_15;
        UnityEngine.GameObject val_16;
        val_15 = this;
        if(this.StatViewObjectOverride != 0)
        {
                val_16 = this.StatViewObjectOverride;
            return val_16;
        }
        
        if(App.ThemesHandler != 0)
        {
                ThemesHandler val_4 = App.ThemesHandler;
            if(val_4.theme != 0)
        {
                ThemesHandler val_6 = App.ThemesHandler;
            if(val_6.theme.StatViewPrefab != 0)
        {
                ThemesHandler val_9 = App.ThemesHandler;
            return val_9.theme.StatViewPrefab;
        }
        
            ThemesHandler val_10 = App.ThemesHandler;
            val_15 = val_10.theme.StatViewPrefab_anchored;
            if(val_15 != 0)
        {
                ThemesHandler val_13 = App.ThemesHandler;
            return val_13.theme.StatViewPrefab_anchored;
        }
        
        }
        
        }
        
        GameSpecificUI val_14 = GameSpecificUI.currentGame;
        val_16 = val_14.statViewPrefab;
        return val_16;
    }
    private GridCoinCollectAnimation GetGridCoinCollectAnimationPrefab()
    {
        UnityEngine.Object val_10 = App.ThemesHandler;
        if(val_10 != 0)
        {
                ThemesHandler val_3 = App.ThemesHandler;
            val_10 = val_3.theme;
            if(val_10 != 0)
        {
                ThemesHandler val_5 = App.ThemesHandler;
            val_10 = val_5.theme.GridCoinCollectAnimation;
            if(val_10 != 0)
        {
                ThemesHandler val_8 = App.ThemesHandler;
            return val_8.theme.GridCoinCollectAnimation;
        }
        
        }
        
        }
        
        GameSpecificUI val_9 = GameSpecificUI.currentGame;
        return (GridCoinCollectAnimation)val_9.gridCoinCollectAnimation;
    }
    public void EnableCoinExpansion(bool enable)
    {
        this.coinExpansionEnabled = enable;
    }
    protected override void OverrideStatViewPostion(UnityEngine.RectTransform rectTransform)
    {
        GameBehavior val_1 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_9B0;
    }
    public GridCoinCollectAnimationInstantiator()
    {
        this.maxCoins = 10;
        this.textTweenTime = 2f;
        this.delayBeforeAnimationConclusion = 0.25f;
        UnityEngine.Vector2 val_1 = UnityEngine.Vector2.zero;
        this.tweenPointBeforePlay = val_1;
        mem[1152921515814238748] = val_1.y;
        decimal val_2 = new System.Decimal(value:  998);
        decimal val_3;
        this.startValue = val_2.flags;
        val_3 = new System.Decimal(value:  231);
        this.finalValue = val_3.flags;
        this.coinExpansionEnabled = true;
    }
    private static GridCoinCollectAnimationInstantiator()
    {
        GridCoinCollectAnimationInstantiator.gridCoinCollectAnimInstances = new System.Collections.Generic.List<GridCoinCollectAnimationInstantiator>();
    }
    private void <ConcludeAnimation>b__36_0()
    {
        if(this != null)
        {
                this.SetActive(value:  false);
            return;
        }
        
        throw new NullReferenceException();
    }

}
