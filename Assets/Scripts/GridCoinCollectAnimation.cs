using UnityEngine;
public class GridCoinCollectAnimation : MonoBehaviour, CollectAnimation
{
    // Fields
    private UnityEngine.CanvasGroup canvasGroup;
    private UnityEngine.UI.GridLayoutGroup _rowsGrid;
    private UnityEngine.UI.GridLayoutGroup[] childGrids;
    private bool playOnEnable;
    private UnityEngine.TextAnchor verticalAlignment;
    private System.Collections.Generic.List<AnimatedCoin> coins;
    private DG.Tweening.Sequence showSequence;
    private DG.Tweening.Sequence middleSequence;
    private DG.Tweening.Sequence finalSequence;
    public System.Action<bool> OnCoinDepositSpecialAction;
    public UnityEngine.Transform collectTarget;
    public PlayerCoinAddedBalance playerCoinAddedBalance;
    public GridCoinCollectAnimation.BalanceCountOptions whenToCount;
    private int maxCoins;
    private int numberOfCoinsToShow;
    private int coinsPerRow;
    private UnityEngine.Vector2 coinSize;
    private float soundTimer;
    private float soundIntervalLimit;
    private float horizontalSpacing;
    private float verticalSpacing;
    private float jumpInterval;
    private float jumpDuration;
    private float flyToBalanceDuration;
    private AnimatedCoin AnimatedCoinPrefabOverride;
    private bool <isAnimating>k__BackingField;
    private bool initialized;
    private bool coinExpansionEnabled;
    
    // Properties
    private UnityEngine.UI.GridLayoutGroup rowsGrid { get; }
    private float coinsVerticalSpacing { get; set; }
    private float coinsHorizontalSpacing { get; set; }
    public bool isAnimating { get; set; }
    
    // Methods
    private UnityEngine.UI.GridLayoutGroup get_rowsGrid()
    {
        UnityEngine.UI.GridLayoutGroup val_4;
        if((UnityEngine.Object.op_Implicit(exists:  this._rowsGrid)) != false)
        {
                val_4 = this._rowsGrid;
            return val_3;
        }
        
        UnityEngine.UI.GridLayoutGroup val_3 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.UI.GridLayoutGroup>(gameObject:  this.gameObject);
        this._rowsGrid = val_3;
        return val_3;
    }
    private float get_coinsVerticalSpacing()
    {
        UnityEngine.UI.GridLayoutGroup val_1 = this.rowsGrid;
        return (float)S0;
    }
    private void set_coinsVerticalSpacing(float value)
    {
        UnityEngine.UI.GridLayoutGroup val_2 = this.rowsGrid;
        UnityEngine.Vector2 val_3 = new UnityEngine.Vector2(x:  val_2.m_Spacing, y:  value);
        this.rowsGrid.spacing = new UnityEngine.Vector2() {x = val_3.x, y = val_3.y};
    }
    private float get_coinsHorizontalSpacing()
    {
        UnityEngine.UI.GridLayoutGroup val_1 = this.childGrids[0];
        return (float)this.childGrids[0].m_Spacing;
    }
    private void set_coinsHorizontalSpacing(float value)
    {
        var val_3 = 0;
        do
        {
            if(val_3 >= this.childGrids.Length)
        {
                return;
        }
        
            UnityEngine.Vector2 val_1 = new UnityEngine.Vector2(x:  value, y:  null);
            this.childGrids[val_3].spacing = new UnityEngine.Vector2() {x = val_1.x, y = val_1.y};
            val_3 = val_3 + 1;
        }
        while(this.childGrids != null);
        
        throw new NullReferenceException();
    }
    public bool get_isAnimating()
    {
        return (bool)this.<isAnimating>k__BackingField;
    }
    private void set_isAnimating(bool value)
    {
        this.<isAnimating>k__BackingField = value;
    }
    private void Awake()
    {
    
    }
    private void Start()
    {
    
    }
    private void Initialize()
    {
        AnimatedCoin val_48;
        var val_49;
        UnityEngine.UI.GridLayoutGroup[] val_50;
        UnityEngine.Transform val_51;
        var val_52;
        if(this.initialized == true)
        {
                return;
        }
        
        this.initialized = true;
        float val_50 = (float)this.maxCoins;
        val_50 = val_50 / (float)this.coinsPerRow;
        val_50 = (val_50 == Infinityf) ? (-(double)val_50) : ((double)val_50);
        this.childGrids = new UnityEngine.UI.GridLayoutGroup[0];
        UnityEngine.RectTransform val_4 = GameSpecificUI.currentGame.AnimatedCoin.GetComponent<UnityEngine.RectTransform>();
        val_48 = val_4;
        UnityEngine.Rect val_5 = val_4.rect;
        UnityEngine.Rect val_7 = val_48.rect;
        UnityEngine.Vector2 val_9 = new UnityEngine.Vector2(x:  val_5.m_XMin.width, y:  val_7.m_XMin.height);
        this.coinSize = val_9.x;
        UnityEngine.Vector2 val_11 = new UnityEngine.Vector2(x:  0f, y:  0f);
        this.rowsGrid.spacing = new UnityEngine.Vector2() {x = val_11.x, y = val_11.y};
        UnityEngine.Rect val_13 = val_48.rect;
        UnityEngine.Rect val_15 = val_48.rect;
        UnityEngine.Vector2 val_17 = new UnityEngine.Vector2(x:  val_13.m_XMin.width, y:  val_15.m_XMin.height);
        this.rowsGrid.cellSize = new UnityEngine.Vector2() {x = val_17.x, y = val_17.y};
        this.rowsGrid.constraint = 1;
        this.rowsGrid.constraintCount = 1;
        this.rowsGrid.childAlignment = this.verticalAlignment;
        if((int)val_50 >= 1)
        {
                val_49 = 1152921518030819824;
            var val_56 = 4;
            do
        {
            UnityEngine.GameObject val_23 = new UnityEngine.GameObject(name:  "Coin Row " + val_56 - 4(val_56 - 4));
            val_23.transform.SetParent(p:  this.rowsGrid.transform);
            UnityEngine.Vector3 val_28 = UnityEngine.Vector3.zero;
            val_23.transform.localPosition = new UnityEngine.Vector3() {x = val_28.x, y = val_28.y, z = val_28.z};
            UnityEngine.Vector3 val_30 = UnityEngine.Vector3.one;
            val_23.transform.localScale = new UnityEngine.Vector3() {x = val_30.x, y = val_30.y, z = val_30.z};
            val_50 = this.childGrids;
            val_50[0] = val_23.AddComponent<UnityEngine.UI.GridLayoutGroup>();
            UnityEngine.Rect val_32 = val_48.rect;
            UnityEngine.Vector2 val_34 = new UnityEngine.Vector2(x:  val_32.m_XMin.width, y:  0f);
            this.childGrids[0].spacing = new UnityEngine.Vector2() {x = val_34.x, y = val_34.y};
            UnityEngine.Rect val_35 = val_48.rect;
            UnityEngine.Rect val_37 = val_48.rect;
            UnityEngine.Vector2 val_39 = new UnityEngine.Vector2(x:  val_35.m_XMin.width, y:  val_37.m_XMin.height);
            this.childGrids[0].cellSize = new UnityEngine.Vector2() {x = val_39.x, y = val_39.y};
            this.childGrids[0].constraint = 1;
            this.childGrids[0].constraintCount = this.coinsPerRow;
            this.childGrids[0].childAlignment = 4;
            val_56 = val_56 + 1;
        }
        while((val_56 - 4) < (int)val_50);
        
        }
        
        if(this.maxCoins < 1)
        {
                return;
        }
        
        val_50 = 1152921504765632512;
        val_49 = 1152921518031100496;
        var val_59 = 0;
        do
        {
            int val_41 = this.GetRowForCoin(i:  0);
            if(this.AnimatedCoinPrefabOverride == 0)
        {
                val_48 = GameSpecificUI.currentGame.AnimatedCoin;
            val_51 = this.childGrids[val_41].transform;
            if(this.coinExpansionEnabled != true)
        {
                val_51 = val_51.parent.parent;
        }
        
            val_52 = null;
        }
        else
        {
                val_48 = this.AnimatedCoinPrefabOverride;
            val_51 = this.childGrids[val_41].transform;
            val_52 = null;
        }
        
            this.coins.Add(item:  UnityEngine.Object.Instantiate<AnimatedCoin>(original:  val_48, parent:  val_51));
            val_59 = val_59 + 1;
        }
        while(val_59 < this.maxCoins);
    
    }
    private void OnEnable()
    {
        if(this.playOnEnable == false)
        {
                return;
        }
        
        this.Reset();
        this.Play(coinsCount:  0);
    }
    private void OnDisable()
    {
        DG.Tweening.TweenExtensions.Kill(t:  this.showSequence, complete:  false);
        DG.Tweening.TweenExtensions.Kill(t:  this.middleSequence, complete:  false);
        DG.Tweening.TweenExtensions.Kill(t:  this.finalSequence, complete:  false);
    }
    public void Play(int coinsCount = -1)
    {
        int val_2;
        if(this.initialized != true)
        {
                this.Initialize();
        }
        
        val_2 = this.maxCoins;
        if((coinsCount & 2147483648) == 0)
        {
                val_2 = UnityEngine.Mathf.Min(a:  coinsCount, b:  val_2);
        }
        
        this.numberOfCoinsToShow = val_2;
        if(val_2 != 0)
        {
                this.Reset();
            this.StartFirstSequence();
            return;
        }
        
        UnityEngine.Debug.LogError(message:  "GridCoinCollectAnimation: Wants to animate zero coins. Something went wrong.", context:  this);
        if(this.OnCoinDepositSpecialAction == null)
        {
                return;
        }
        
        this.OnCoinDepositSpecialAction.Invoke(obj:  false);
    }
    public void Reset()
    {
        var val_6;
        this.StopAllCoroutines();
        this.<isAnimating>k__BackingField = false;
        this.canvasGroup.alpha = 0f;
        this.coinsHorizontalSpacing = -this.coinSize;
        this.coinsVerticalSpacing = -(-this.coinSize);
        var val_7 = 4;
        label_10:
        var val_1 = val_7 - 4;
        if(val_1 >= true)
        {
            goto label_3;
        }
        
        if(true <= val_1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        0.Reset(grid:  this);
        if(true <= val_1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        0.gameObject.SetActive(value:  (val_1 < this.numberOfCoinsToShow) ? 1 : 0);
        val_7 = val_7 + 1;
        if(this.coins != null)
        {
            goto label_10;
        }
        
        label_3:
        val_6 = 0;
        label_17:
        if(val_6 >= this.childGrids.Length)
        {
            goto label_13;
        }
        
        this.childGrids[val_6].gameObject.SetActive(value:  (val_6 < (this.GetNumberOfRowsForCoinCount(coinCount:  this.numberOfCoinsToShow))) ? 1 : 0);
        val_6 = val_6 + 1;
        if(this.childGrids != null)
        {
            goto label_17;
        }
        
        throw new NullReferenceException();
        label_13:
        this.SetGridsEnabled(state:  true);
    }
    public void SetMaxCoins(int coins)
    {
        if(this.initialized != false)
        {
                UnityEngine.Debug.LogWarning(message:  "Cannot modify number of max coins after initalization...yet", context:  this.gameObject);
            return;
        }
        
        this.maxCoins = coins;
    }
    public void EnableCoinExpansion(bool enable)
    {
        this.coinExpansionEnabled = enable;
    }
    private void StartFirstSequence()
    {
        this.<isAnimating>k__BackingField = true;
        DG.Tweening.Sequence val_1 = DG.Tweening.DOTween.Sequence();
        this.showSequence = val_1;
        var val_6 = (this.coinExpansionEnabled == false) ? 1 : 0;
        var val_12 = (this.coinExpansionEnabled == false) ? 1 : 0;
        DG.Tweening.Sequence val_17 = DG.Tweening.TweenSettingsExtensions.Join(s:  DG.Tweening.TweenSettingsExtensions.Append(s:  DG.Tweening.TweenSettingsExtensions.Append(s:  val_1, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.canvasGroup, endValue:  1f, duration:  0.2f)), t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Core.TweenerCore<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>>(t:  DG.Tweening.DOTween.To(getter:  new DG.Tweening.Core.DOGetter<System.Single>(object:  this, method:  System.Single GridCoinCollectAnimation::<StartFirstSequence>b__49_0()), setter:  new DG.Tweening.Core.DOSetter<System.Single>(object:  this, method:  System.Void GridCoinCollectAnimation::<StartFirstSequence>b__49_1(float x)), endValue:  -this.verticalSpacing, duration:  32498036 + this.coinExpansionEnabled == false ? 1 : 0), ease:  6)), t:  DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Core.TweenerCore<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Core.TweenerCore<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>>(t:  DG.Tweening.DOTween.To(getter:  new DG.Tweening.Core.DOGetter<System.Single>(object:  this, method:  System.Single GridCoinCollectAnimation::<StartFirstSequence>b__49_2()), setter:  new DG.Tweening.Core.DOSetter<System.Single>(object:  this, method:  System.Void GridCoinCollectAnimation::<StartFirstSequence>b__49_3(float y)), endValue:  -this.horizontalSpacing, duration:  32498044 + this.coinExpansionEnabled == false ? 1 : 0), ease:  6), action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void GridCoinCollectAnimation::StartMiddleSequence())));
    }
    private void StartMiddleSequence()
    {
        DG.Tweening.Sequence val_15;
        this.SetGridsEnabled(state:  false);
        DG.Tweening.Sequence val_1 = DG.Tweening.DOTween.Sequence();
        val_15 = val_1;
        this.middleSequence = val_1;
        if(((this.jumpDuration == 0f) || (this.jumpInterval == 0f)) || (this.numberOfCoinsToShow < 1))
        {
            goto label_5;
        }
        
        var val_17 = 1;
        float val_2 = this.jumpInterval * 0f;
        label_22:
        var val_4 = val_17 - 1;
        if(32497664 <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_5 = 32497664 + (val_4 << 3);
        if(val_5 <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_5 = val_5 + (((long)(int)((1 - 1))) << 3);
        UnityEngine.Vector3 val_8 = ((32497664 + ((1 - 1)) << 3) + ((long)(int)((1 - 1))) << 3) + 32.transform.position;
        DG.Tweening.Sequence val_12 = DG.Tweening.TweenSettingsExtensions.Insert(s:  val_15, atPosition:  0f, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Sequence>(t:  DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Sequence>(t:  DG.Tweening.ShortcutExtensions.DOJump(target:  (32497664 + ((1 - 1)) << 3) + 32.transform, endValue:  new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z}, jumpPower:  0.2f, numJumps:  1, duration:  this.jumpDuration, snapping:  false), delay:  val_2), ease:  5));
        if(val_5 <= val_4)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_5 = val_5 + (((long)(int)((1 - 1))) << 3);
        val_2 = (this.jumpDuration * 0.36f) + val_2;
        (((32497664 + ((1 - 1)) << 3) + ((long)(int)((1 - 1))) << 3) + ((long)(int)((1 - 1))) << 3) + 32.PlaySparkle(delay:  val_2);
        if(((UnityEngine.Object.op_Implicit(exists:  this.playerCoinAddedBalance)) != false) && (this.whenToCount == 1))
        {
                this.playerCoinAddedBalance.Add(addAmount:  1, delay:  val_2);
        }
        
        if(val_17 >= this.numberOfCoinsToShow)
        {
            goto label_21;
        }
        
        float val_14 = this.jumpInterval * 1f;
        val_17 = val_17 + 1;
        if(this.coins != null)
        {
            goto label_22;
        }
        
        throw new NullReferenceException();
        label_21:
        val_15 = this.middleSequence;
        label_5:
        DG.Tweening.Sequence val_16 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_15, action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void GridCoinCollectAnimation::StartFinalSequence()));
    }
    private void StartFinalSequence()
    {
        DG.Tweening.Sequence val_15;
        DG.Tweening.Sequence val_1 = DG.Tweening.DOTween.Sequence();
        this.finalSequence = val_1;
        if(this.numberOfCoinsToShow >= 1)
        {
                var val_17 = 4;
            do
        {
            var val_2 = val_17 - 4;
            if(32497664 <= val_2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(32497664 <= val_2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            UnityEngine.Vector3 val_7 = this.collectTarget.position;
            if(1152921510472987776 <= val_2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            DG.Tweening.Sequence val_13 = DG.Tweening.TweenSettingsExtensions.Insert(s:  this.finalSequence, atPosition:  0f, t:  DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOMove(target:  static_value_01EFE020.transform, endValue:  new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z}, duration:  this.flyToBalanceDuration, snapping:  false), delay:  (float)static_value_01EFE020.transform.GetSiblingIndex() * 0.06f), ease:  5), action:  new DG.Tweening.TweenCallback(object:  public TransformPair System.Collections.Generic.List<TransformPair>::get_Item(int index), method:  public System.Void AnimatedCoin::HideCoin())));
            val_17 = val_17 + 1;
        }
        while((val_17 - 4) < this.numberOfCoinsToShow);
        
            val_15 = this.finalSequence;
        }
        else
        {
                val_15 = val_1;
        }
        
        DG.Tweening.Sequence val_16 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_15, action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void GridCoinCollectAnimation::FinishedAnimation()));
    }
    private void FinishedAnimation()
    {
        this.<isAnimating>k__BackingField = false;
    }
    public void OnCoinDeposited()
    {
        if(((UnityEngine.Object.op_Implicit(exists:  this.playerCoinAddedBalance)) != false) && (this.whenToCount == 0))
        {
                this.playerCoinAddedBalance.Add(addAmount:  1);
        }
        
        if(this.OnCoinDepositSpecialAction != null)
        {
                this.OnCoinDepositSpecialAction.Invoke(obj:  false);
        }
        
        if(this.AllowSound() != false)
        {
                if((MonoSingleton<WGAudioController>.Instance) != 0)
        {
                WGAudioController val_5 = MonoSingleton<WGAudioController>.Instance;
            val_5.sound.PlayGeneralSound(type:  2, oneshot:  true, pitch:  1f, vol:  1f);
            return;
        }
        
        }
        
        if((MonoSingleton<MinigameAudioController>.Instance) == 0)
        {
                return;
        }
        
        MonoSingleton<MinigameAudioController>.Instance.PlayCoinCollect();
    }
    public void OnSparkle()
    {
        if(this.AllowSound() == false)
        {
                return;
        }
        
        WGAudioController val_2 = MonoSingleton<WGAudioController>.Instance;
        val_2.sound.PlayGeneralSound(type:  3, oneshot:  true, pitch:  1f, vol:  1f);
    }
    private int GetRowForCoin(int i)
    {
        float val_1 = (float)i;
        val_1 = val_1 / (float)this.coinsPerRow;
        return UnityEngine.Mathf.FloorToInt(f:  val_1);
    }
    private int GetNumberOfRowsForCoinCount(int coinCount)
    {
        float val_1 = (float)coinCount;
        val_1 = val_1 / (float)this.coinsPerRow;
        val_1 = (val_1 == Infinityf) ? (-(double)val_1) : ((double)val_1);
        return (int)(int)val_1;
    }
    private void SetGridsEnabled(bool state)
    {
        state = state;
        this.rowsGrid.enabled = state;
        var val_4 = 0;
        do
        {
            if(val_4 >= this.childGrids.Length)
        {
                return;
        }
        
            this.childGrids[val_4].enabled = state;
            val_4 = val_4 + 1;
        }
        while(this.childGrids != null);
        
        throw new NullReferenceException();
    }
    private bool AllowSound()
    {
        var val_3;
        if(UnityEngine.Time.realtimeSinceStartup > this.soundTimer)
        {
                float val_2 = UnityEngine.Time.realtimeSinceStartup;
            val_3 = 1;
            val_2 = val_2 + this.soundIntervalLimit;
            this.soundTimer = val_2;
            return (bool)val_3;
        }
        
        val_3 = 0;
        return (bool)val_3;
    }
    public GridCoinCollectAnimation()
    {
        this.childGrids = new UnityEngine.UI.GridLayoutGroup[0];
        this.playOnEnable = true;
        this.verticalAlignment = 4;
        this.coinsPerRow = 10;
        this.maxCoins = 10;
        this.numberOfCoinsToShow = 0;
        this.coins = new System.Collections.Generic.List<AnimatedCoin>();
        UnityEngine.Vector2 val_3 = new UnityEngine.Vector2(x:  130f, y:  127f);
        this.jumpDuration = 0.33f;
        this.flyToBalanceDuration = 0.25f;
        this.coinSize = val_3.x;
        this.soundIntervalLimit = ;
        this.horizontalSpacing = ;
        this.verticalSpacing = 52f;
        this.jumpInterval = 0.1f;
        this.coinExpansionEnabled = true;
    }
    private float <StartFirstSequence>b__49_0()
    {
        UnityEngine.UI.GridLayoutGroup val_1 = this.rowsGrid;
        return (float)S0;
    }
    private void <StartFirstSequence>b__49_1(float x)
    {
        this.coinsVerticalSpacing = x;
    }
    private float <StartFirstSequence>b__49_2()
    {
        return this.coinsHorizontalSpacing;
    }
    private void <StartFirstSequence>b__49_3(float y)
    {
        this.coinsHorizontalSpacing = y;
    }

}
