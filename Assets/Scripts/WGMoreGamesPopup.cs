using UnityEngine;
public class WGMoreGamesPopup : FrameSkipper
{
    // Fields
    private UnityEngine.UI.Text text_description;
    private UnityEngine.UI.Text text_current_bonus;
    private UnityEngine.UI.Button collectButton;
    private UnityEngine.UI.Button button_close;
    private UnityEngine.GameObject object_bonus_reward_box;
    private UnityEngine.UI.Text text_countdown_timer;
    private UnityEngine.GameObject object_collect_text;
    private CurrencyCollectAnimationInstantiator coinsAnim;
    private UnityEngine.UI.ScrollRect scrollRect;
    private UnityEngine.Transform more_games_items_parent;
    private WGMoreGamesItem prefab_more_games_item;
    private System.Collections.Generic.List<WGMoreGamesItem> moreGamesItems;
    private decimal curr_reward;
    
    // Methods
    private void Start()
    {
        var val_5;
        this.button_close.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGMoreGamesPopup::<Start>b__13_0()));
        this.collectButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGMoreGamesPopup::onClick_CollectButton()));
        val_5 = null;
        val_5 = null;
        System.Delegate val_4 = System.Delegate.Combine(a:  WGMoreGamesManager.RefreshUI, b:  new System.Action(object:  this, method:  System.Void WGMoreGamesPopup::UpdateUI()));
        if(val_4 != null)
        {
                if(null != null)
        {
            goto label_8;
        }
        
        }
        
        WGMoreGamesManager.RefreshUI = val_4;
        return;
        label_8:
    }
    private void OnEnable()
    {
        this.InstantiateMoreGamesItems();
        this.UpdateUI();
    }
    private void InstantiateMoreGamesItems()
    {
        System.Collections.Generic.List<WGMoreGamesItem> val_6;
        var val_7;
        GameApp[] val_1 = twelvegigs.plugins.InstalledAppsPlugin.PackagesToCheck;
        val_6 = this.moreGamesItems;
        val_7 = 1;
        Add(item:  UnityEngine.Object.Instantiate<WGMoreGamesItem>(original:  this.prefab_more_games_item, parent:  this.more_games_items_parent));
        UnityEngine.Coroutine val_5 = this.StartCoroutine(routine:  this.ScrollToTop());
    }
    private System.Collections.IEnumerator ScrollToTop()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGMoreGamesPopup.<ScrollToTop>d__16();
    }
    private void UpdateUI()
    {
        var val_23;
        var val_24;
        var val_25;
        var val_26;
        GameApp val_27;
        val_23 = null;
        val_23 = null;
        decimal val_1 = System.Decimal.op_Implicit(value:  WGMoreGamesManager.totalBonus);
        this.curr_reward = val_1;
        mem[1152921517932875896] = val_1.lo;
        mem[1152921517932875900] = val_1.mid;
        bool val_2 = System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0});
        val_1.lo = val_2;
        this.object_bonus_reward_box.SetActive(value:  val_1.lo);
        bool val_3 = WGMoreGamesManager.CanCollect();
        bool val_4 = val_3;
        this.collectButton.interactable = val_4;
        this.object_collect_text.SetActive(value:  val_4);
        this.text_countdown_timer.gameObject.SetActive(value:  (~val_3) & 1);
        System.DateTime val_7 = WGMoreGamesManager.NextMoreGamesCollectTime;
        System.DateTime val_8 = DateTimeCheat.UtcNow;
        System.TimeSpan val_9 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_7.dateData}, d2:  new System.DateTime() {dateData = val_8.dateData});
        string val_10 = val_9._ticks.FormatTimeRemaining(timeSpan:  new System.TimeSpan() {_ticks = val_9._ticks});
        this.button_close.gameObject.SetActive(value:  (~(val_2 & val_3)) & 1);
        GameEcon val_14 = App.getGameEcon;
        string val_15 = this.curr_reward.ToString(format:  val_14.numberFormatInt);
        val_24 = null;
        val_24 = null;
        GameEcon val_17 = App.getGameEcon;
        string val_19 = System.String.Format(format:  Localization.Localize(key:  "", defaultValue:  "Earn {0} coins every day for each game installed", useSingularKey:  false), arg0:  WGMoreGamesManager.amountPerInstall.ToString(format:  val_17.numberFormatInt));
        val_25 = 0;
        var val_22 = 32;
        do
        {
            if(val_25 >= this.moreGamesItems)
        {
                return;
        }
        
            GameApp[] val_20 = twelvegigs.plugins.InstalledAppsPlugin.PackagesToCheck;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            if(val_25 < val_20.Length)
        {
                val_26 = 1;
        }
        else
        {
                val_27;
            val_26 = 0;
        }
        
            (twelvegigs.plugins.InstalledAppsPlugin.__il2cppRuntimeField_cctor_finished + 0) + 32.SetParams(state:  false, gameApp:  new GameApp() {isInstalled = false});
            val_25 = val_25 + 1;
            val_22 = val_22 + 32;
        }
        while(this.moreGamesItems != null);
        
        throw new NullReferenceException();
    }
    public string FormatTimeRemaining(System.TimeSpan timeSpan)
    {
        int val_6 = 24;
        val_6 = timeSpan._ticks.Hours + (timeSpan._ticks.Days * val_6);
        return (string)System.String.Format(format:  "{0:00}:{1:00}:{2:00}", arg0:  val_6, arg1:  timeSpan._ticks.Minutes, arg2:  timeSpan._ticks.Seconds);
    }
    protected override void UpdateLogic()
    {
        var val_14;
        this.UpdateLogic();
        val_14 = null;
        val_14 = null;
        bool val_1 = System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = this.curr_reward, hi = this.curr_reward, lo = 41963520}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0});
        this.object_bonus_reward_box.SetActive(value:  val_1);
        bool val_3 = WGMoreGamesManager.CanCollect();
        bool val_4 = val_3;
        this.collectButton.interactable = val_4;
        this.object_collect_text.SetActive(value:  val_4);
        this.text_countdown_timer.gameObject.SetActive(value:  (~val_3) & 1);
        System.DateTime val_7 = WGMoreGamesManager.NextMoreGamesCollectTime;
        System.DateTime val_8 = DateTimeCheat.UtcNow;
        System.TimeSpan val_9 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_7.dateData}, d2:  new System.DateTime() {dateData = val_8.dateData});
        string val_10 = val_9._ticks.FormatTimeRemaining(timeSpan:  new System.TimeSpan() {_ticks = val_9._ticks});
        this.button_close.gameObject.SetActive(value:  (~(val_1 & val_3)) & 1);
    }
    private void OnDisable()
    {
        null = null;
        System.Delegate val_2 = System.Delegate.Remove(source:  WGMoreGamesManager.RefreshUI, value:  new System.Action(object:  this, method:  System.Void WGMoreGamesPopup::UpdateUI()));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_4;
        }
        
        }
        
        WGMoreGamesManager.RefreshUI = val_2;
        WGMoreGamesManager.HandlePopupClosed();
        return;
        label_4:
    }
    private void onClick_CollectButton()
    {
        this.collectButton.interactable = false;
        App.Player.AddCredits(amount:  new System.Decimal() {flags = this.curr_reward, hi = this.curr_reward}, source:  "MoreGamesBonus", subSource:  0, externalParams:  0, doTrack:  true);
        WGMoreGamesManager.HandlePopupCollected();
        if(this.coinsAnim != 0)
        {
                this.coinsAnim.OnCompleteCallback = new System.Action(object:  this, method:  System.Void WGMoreGamesPopup::OnCoinsAnimFinished());
        }
        
        if(this.coinsAnim == 0)
        {
                return;
        }
        
        Player val_5 = App.Player;
        decimal val_6 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_5._credits, hi = val_5._credits, lo = 1152921504765632512}, d2:  new System.Decimal() {flags = this.curr_reward, hi = this.curr_reward, lo = 441899584, mid = 268435459});
        Player val_8 = App.Player;
        this.coinsAnim.Play(fromValue:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = val_6.flags, hi = val_6.hi, lo = val_6.lo, mid = val_6.mid}), toValue:  new System.Decimal() {flags = val_8._credits, hi = val_8._credits, lo = 441899584, mid = 268435459}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  0, originObject:  0);
    }
    private void OnCoinsAnimFinished()
    {
    
    }
    public WGMoreGamesPopup()
    {
        this.moreGamesItems = new System.Collections.Generic.List<WGMoreGamesItem>();
    }
    private void <Start>b__13_0()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }

}
