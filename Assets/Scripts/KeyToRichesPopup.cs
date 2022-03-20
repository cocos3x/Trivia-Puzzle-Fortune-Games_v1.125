using UnityEngine;
public class KeyToRichesPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text keyBalance;
    private KeyToRichesChest treasureChestPrefab;
    private UnityEngine.Transform treasureChestParent;
    private UnityEngine.Transform keyPos;
    private UnityEngine.GameObject[] defaultModeObjects;
    private UnityEngine.UI.Text keyDesc;
    private UGUINetworkedButton purchaseButton;
    private UnityEngine.UI.Text keysAmount;
    private UnityEngine.UI.Text keysPrice;
    private UnityEngine.UI.Text timerText;
    private UnityEngine.GameObject[] rewardModeObjects;
    private GridCoinCollectAnimationInstantiator coinsAnimControl;
    private GoldenCurrencyCollectAnimationInstantiator goldenCurrencyAnimControl;
    private UnityEngine.GameObject prompt;
    private UGUINetworkedButton promptPurchaseButton;
    private UnityEngine.UI.Text promptKeysAmount;
    private UnityEngine.UI.Text promptKeysPrice;
    private UnityEngine.UI.Button promptCloseButton;
    private UnityEngine.GameObject messagePopup;
    private UnityEngine.UI.Text title;
    private UnityEngine.UI.Text message;
    private UnityEngine.UI.Button okayButton;
    private float delayBeforeReveal;
    private float delayAfterReveal;
    private float delayBeforePrompt;
    private UnityEngine.Sprite coin;
    private UnityEngine.Sprite apple;
    private UnityEngine.Sprite alph_common;
    private UnityEngine.Sprite alph_uncommon;
    private UnityEngine.Sprite alph_rare;
    private UnityEngine.Sprite alph_superRare;
    private KeyToRichesPopup.State state;
    private KeyToRichesChest[] chests;
    private System.Collections.Generic.List<KeyToRichesEventHandler.Reward> currentRewards;
    private System.Collections.Generic.HashSet<int> openedChests;
    private int keysToPurchase;
    
    // Properties
    public string RewardsContent { get; }
    
    // Methods
    public string get_RewardsContent()
    {
        if(this.currentRewards == null)
        {
                return "";
        }
        
        return Newtonsoft.Json.JsonConvert.SerializeObject(value:  this.currentRewards);
    }
    private void OnPurchase(bool connected)
    {
        var val_3;
        if(connected != false)
        {
                val_3 = null;
            val_3 = null;
            PurchaseProxy.currentPurchasePoint = 95;
            KeyToRichesEventHandler._Instance.PurchaseKeys(keysToPurchase:  this.keysToPurchase);
            return;
        }
        
        this.ShowMessage(titleText:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageText:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false));
    }
    private void OnPromptPurchase(bool connected)
    {
        var val_3;
        if(connected != false)
        {
                val_3 = null;
            val_3 = null;
            PurchaseProxy.currentPurchasePoint = 96;
            KeyToRichesEventHandler._Instance.PurchaseKeys(keysToPurchase:  this.keysToPurchase);
            return;
        }
        
        this.ShowMessage(titleText:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageText:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false));
    }
    private void OnPromptClose()
    {
        this.prompt.SetActive(value:  false);
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.CloseRewardSequence());
    }
    private void OnPurchaseCompleted(PurchaseModel purchase)
    {
        var val_3;
        decimal val_1 = purchase.Keys;
        val_3 = null;
        val_3 = null;
        if((System.Decimal.op_Equality(d1:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                return;
        }
        
        if(this.state != 0)
        {
                this.prompt.SetActive(value:  false);
            return;
        }
        
        this.state = 1;
        this.SetupReward(isPurchase:  true);
    }
    private void OnPurchaseFailure(PurchaseModel purchase)
    {
        var val_5;
        decimal val_1 = purchase.Keys;
        val_5 = null;
        val_5 = null;
        if((System.Decimal.op_Equality(d1:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
        {
                return;
        }
        
        this.ShowMessage(titleText:  Localization.Localize(key:  "purchase_failed_upper", defaultValue:  "PURCHASE FAILED", useSingularKey:  false), messageText:  Localization.Localize(key:  "purchase_failed_explanation", defaultValue:  "Something went wrong with your purchase.\n\nPlease try again!", useSingularKey:  false));
    }
    private void OnClickMessage()
    {
        if(this.messagePopup != null)
        {
                this.messagePopup.SetActive(value:  false);
            return;
        }
        
        throw new NullReferenceException();
    }
    private void Awake()
    {
        null = null;
        System.Delegate val_2 = System.Delegate.Combine(a:  PurchasesHandler.OnPurchaseCompleted, b:  new System.Action<PurchaseModel>(object:  this, method:  System.Void KeyToRichesPopup::OnPurchaseCompleted(PurchaseModel purchase)));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
        PurchasesHandler.OnPurchaseCompleted = val_2;
        System.Delegate val_4 = System.Delegate.Combine(a:  PurchasesHandler.OnPurchaseFailure, b:  new System.Action<PurchaseModel>(object:  this, method:  System.Void KeyToRichesPopup::OnPurchaseFailure(PurchaseModel purchase)));
        if(val_4 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
        PurchasesHandler.OnPurchaseFailure = val_4;
        System.Delegate val_6 = System.Delegate.Combine(a:  KeyToRichesEventHandler._Instance.OnKeyBalanceChanged, b:  new System.Action(object:  this, method:  System.Void KeyToRichesPopup::UpdateBalance()));
        if(val_6 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
        KeyToRichesEventHandler._Instance.OnKeyBalanceChanged = val_6;
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnToggleKTRChestContent");
        this.purchaseButton.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  System.Void KeyToRichesPopup::OnPurchase(bool connected));
        this.promptPurchaseButton.OnConnectionClick = new System.Action<System.Boolean>(object:  this, method:  System.Void KeyToRichesPopup::OnPromptPurchase(bool connected));
        this.promptCloseButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void KeyToRichesPopup::OnPromptClose()));
        this.okayButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void KeyToRichesPopup::OnClickMessage()));
        this.InitObjects();
        return;
        label_10:
    }
    private void Start()
    {
        if(((KeyToRichesEventHandler._Instance & 1) == 0) && (KeyToRichesEventHandler._Instance != null))
        {
                this.SetupUI();
            return;
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnDestroy()
    {
        null = null;
        System.Delegate val_2 = System.Delegate.Remove(source:  PurchasesHandler.OnPurchaseCompleted, value:  new System.Action<PurchaseModel>(object:  this, method:  System.Void KeyToRichesPopup::OnPurchaseCompleted(PurchaseModel purchase)));
        if(val_2 != null)
        {
                if(null != null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        PurchasesHandler.OnPurchaseCompleted = val_2;
        System.Delegate val_4 = System.Delegate.Remove(source:  PurchasesHandler.OnPurchaseFailure, value:  new System.Action<PurchaseModel>(object:  this, method:  System.Void KeyToRichesPopup::OnPurchaseFailure(PurchaseModel purchase)));
        if(val_4 != null)
        {
                if(null != null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        PurchasesHandler.OnPurchaseFailure = val_4;
        System.Delegate val_6 = System.Delegate.Remove(source:  KeyToRichesEventHandler._Instance.OnKeyBalanceChanged, value:  new System.Action(object:  this, method:  System.Void KeyToRichesPopup::UpdateBalance()));
        if(val_6 != null)
        {
                if(null != null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        KeyToRichesEventHandler._Instance.OnKeyBalanceChanged = val_6;
        NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  "OnToggleKTRChestContent");
    }
    public void OnCollect(int index)
    {
        bool val_1 = this.openedChests.Add(item:  index);
        if(KeyToRichesEventHandler._Instance.KeyCount != 0)
        {
                return;
        }
        
        if(this.openedChests <= 8)
        {
                this.SetupPrompt();
            return;
        }
        
        UnityEngine.Coroutine val_4 = this.StartCoroutine(routine:  this.CloseRewardSequence());
    }
    public void AnimateReward(int index)
    {
        int val_16;
        var val_17;
        string val_19;
        bool val_16 = true;
        if(val_16 <= index)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_16 = val_16 + (index << 3);
        if(((true + (index) << 3) + 32) == 0)
        {
                return;
        }
        
        if(((true + (index) << 3) + 32 + 16) != 1)
        {
                if(((true + (index) << 3) + 32 + 16) != 0)
        {
                return;
        }
        
            Player val_1 = App.Player;
            decimal val_2 = System.Decimal.op_Implicit(value:  (true + (index) << 3) + 32 + 20);
            decimal val_3 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_1._credits, hi = val_1._credits, lo = index, mid = index}, d2:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid});
            val_16 = val_3.lo;
            Player val_4 = App.Player;
            this.coinsAnimControl.Play(fromValue:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_16, mid = val_3.mid}, toValue:  new System.Decimal() {flags = val_4._credits, hi = val_4._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
            val_17 = NotificationCenter.DefaultCenter;
            WordGameEventsController val_6 = MonoSingleton<WordGameEventsController>.Instance;
            val_19 = "CoinsStatViewUpdate";
        }
        else
        {
                UnityEngine.Vector3 val_9 = this.chests[(long)index].transform.position;
            0.transform.position = new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z};
            Player val_10 = App.Player;
            val_16 = val_10._stars;
            Player val_11 = App.Player;
            decimal val_12 = System.Decimal.op_Implicit(value:  val_11._stars);
            this.goldenCurrencyAnimControl.Play(fromValue:  val_16 - ((true + (index) << 3) + 32 + 20), toValue:  new System.Decimal() {flags = val_12.flags, hi = val_12.hi, lo = val_12.lo, mid = val_12.mid}, textTickTime:  -1f, delayBeforeComplete:  -1f, destinationObject:  0, originObject:  0);
            val_17 = NotificationCenter.DefaultCenter;
            val_19 = "OnStarsUpdated";
        }
        
        val_17.PostNotification(aSender:  MonoSingleton<WordGameEventsController>.Instance, aName:  val_19);
    }
    public void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void UpdateTimerText()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = KeyToRichesEventHandler._Instance + 16 + 40}, d2:  new System.DateTime() {dateData = val_1.dateData});
        object[] val_3 = new object[4];
        val_3[0] = val_2._ticks.Days;
        val_3[1] = val_2._ticks.Hours;
        val_3[2] = val_2._ticks.Minutes;
        val_3[3] = val_2._ticks.Seconds;
        string val_8 = System.String.Format(format:  "{0}:{1:00}:{2:00}:{3:00}", args:  val_3);
        if(val_2._ticks.TotalSeconds >= 0)
        {
                return;
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void InitObjects()
    {
        this.chests = new KeyToRichesChest[9];
        var val_5 = 0;
        do
        {
            val_5 = val_5 + 1;
            this.chests[val_5] = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.treasureChestPrefab.gameObject, parent:  this.treasureChestParent).GetComponent<KeyToRichesChest>();
        }
        while(val_5 < 8);
    
    }
    private void SetupUI()
    {
        FrameSkipper val_2 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(gameObject:  this.gameObject);
        val_2.updateLogic = new System.Action(object:  this, method:  System.Void KeyToRichesPopup::UpdateTimerText());
        this.UpdateBalance();
        string val_6 = System.String.Format(format:  Localization.Localize(key:  "key_riches_event_text", defaultValue:  "Keys appear every {0} levels.\nCollect 3 Keys to open Chests!", useSingularKey:  false), arg0:  KeyToRichesEventHandler._Instance.LevelsPerKey);
        int val_7 = KeyToRichesEventHandler._Instance.KeyCount;
        this.state = (val_7 > 2) ? 1 : 0;
        if(val_7 <= 2)
        {
                this.SetupDefault();
            return;
        }
        
        this.SetupReward(isPurchase:  false);
    }
    private void SetupDefault()
    {
        int val_4 = this.defaultModeObjects.Length;
        if(val_4 >= 1)
        {
                var val_5 = 0;
            val_4 = val_4 & 4294967295;
            do
        {
            if((UnityEngine.Object.op_Implicit(exists:  1152921507149874848)) != false)
        {
                1152921507149874848.SetActive(value:  true);
        }
        
            val_5 = val_5 + 1;
        }
        while(val_5 < (this.defaultModeObjects.Length << ));
        
        }
        
        int val_6 = this.rewardModeObjects.Length;
        if(val_6 >= 1)
        {
                var val_7 = 0;
            val_6 = val_6 & 4294967295;
            do
        {
            if((UnityEngine.Object.op_Implicit(exists:  1152921507149874848)) != false)
        {
                1152921507149874848.SetActive(value:  false);
        }
        
            val_7 = val_7 + 1;
        }
        while(val_7 < (this.rewardModeObjects.Length << ));
        
        }
        
        var val_9 = 0;
        do
        {
            this.chests[val_9].SetupDefault();
            val_9 = val_9 + 1;
        }
        while((val_9 - 1) < 8);
        
        this.SetupPurchase();
    }
    private void SetupReward(bool isPurchase = False)
    {
        UnityEngine.Sprite val_6;
        System.Collections.Generic.List<Reward> val_7;
        this.openedChests.Clear();
        if(this.currentRewards == null)
        {
                this.currentRewards = KeyToRichesEventHandler._Instance.GenerateRewards(isPurchase:  isPurchase);
        }
        
        int val_8 = this.defaultModeObjects.Length;
        if(val_8 >= 1)
        {
                var val_9 = 0;
            val_8 = val_8 & 4294967295;
            do
        {
            if((UnityEngine.Object.op_Implicit(exists:  1152921507149874848)) != false)
        {
                1152921507149874848.SetActive(value:  false);
        }
        
            val_9 = val_9 + 1;
        }
        while(val_9 < (this.defaultModeObjects.Length << ));
        
        }
        
        int val_10 = this.rewardModeObjects.Length;
        if(val_10 >= 1)
        {
                var val_11 = 0;
            val_10 = val_10 & 4294967295;
            do
        {
            if((UnityEngine.Object.op_Implicit(exists:  1152921507149874848)) != false)
        {
                1152921507149874848.SetActive(value:  true);
        }
        
            val_11 = val_11 + 1;
        }
        while(val_11 < (this.rewardModeObjects.Length << ));
        
        }
        
        var val_15 = 4;
        goto label_39;
        label_30:
        val_6 = 0;
        goto label_22;
        label_39:
        int val_5 = val_15 - 4;
        val_7 = this.currentRewards;
        if(this.chests.Length <= val_5)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_7 = this.currentRewards;
        }
        
        if(this.chests.Length <= val_5)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(this.chests[0] > 5)
        {
            goto label_30;
        }
        
        var val_6 = (32555040 + (this.chests[0]) << 2) + 32555040;
        goto (32555040 + (this.chests[0]) << 2 + 32555040);
        label_22:
        if( <= val_5)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        this.chests[0].SetupReward(keyToRichesPopup:  this, i:  val_5, reward:  this.chests[0], rewardSprite:  null, rewardAmount:  mem[this.alph_superRare + 32] + 20, keyPos:  this.keyPos);
        val_15 = val_15 + 1;
        if((val_15 - 5) < 8)
        {
            goto label_39;
        }
    
    }
    private void SetupPurchase()
    {
        int val_1 = KeyToRichesEventHandler._Instance.KeyCount;
        var val_5 = 2;
        int val_6 = 3;
        val_5 = val_5 - val_1;
        val_6 = val_6 - val_1;
        this.keysToPurchase = val_6;
        if(val_5 >= 3)
        {
                UnityEngine.Debug.LogError(message:  "KeyTorichesPopup: cannot purchase more than 3 keys.");
            this.purchaseButton.gameObject.SetActive(value:  false);
            return;
        }
        
        string val_3 = this.keysToPurchase.ToString();
        string val_4 = KeyToRichesEventHandler._Instance.GetPackagePriceByKeyCount(keysToPurchase:  this.keysToPurchase);
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void SetupPrompt()
    {
        int val_2 = UnityEngine.Mathf.Min(a:  9 - 41967616, b:  3);
        this.keysToPurchase = val_2;
        if((val_2 - 1) >= 3)
        {
                UnityEngine.Debug.LogError(message:  "KeyTorichesPopup: cannot purchase more than 3 keys.");
            return;
        }
        
        string val_4 = this.keysToPurchase.ToString();
        string val_5 = KeyToRichesEventHandler._Instance.GetPackagePriceByKeyCount(keysToPurchase:  this.keysToPurchase);
        UnityEngine.Coroutine val_7 = this.StartCoroutine(routine:  this.OpenPromptSequence());
    }
    private void ShowMessage(string titleText, string messageText)
    {
        string val_3 = System.String.Format(format:  App.getGameEcon.titleFormat, arg0:  titleText);
        this.messagePopup.SetActive(value:  true);
    }
    private System.Collections.IEnumerator OpenPromptSequence()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new KeyToRichesPopup.<OpenPromptSequence>d__59();
    }
    private System.Collections.IEnumerator CloseRewardSequence()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new KeyToRichesPopup.<CloseRewardSequence>d__60();
    }
    private UnityEngine.Sprite GetSpriteByType(KeyToRichesEventHandler.RewardType rewardType)
    {
        if(rewardType > 5)
        {
                return 0;
        }
        
        var val_1 = 32555064 + (rewardType) << 2;
        val_1 = val_1 + 32555064;
        goto (32555064 + (rewardType) << 2 + 32555064);
    }
    private void UpdateBalance()
    {
        string val_2 = KeyToRichesEventHandler._Instance.KeyCount.ToString();
    }
    private void OnToggleKTRChestContent(Notification notification)
    {
        var val_2;
        if((notification.data & 1) != 0)
        {
                var val_1 = (null != 0) ? 1 : 0;
        }
        else
        {
                val_2 = 0;
        }
        
        this.ToggleChestContent(show:  false);
    }
    private void ToggleChestContent(bool show)
    {
        if(this.chests == null)
        {
                return;
        }
        
        if(this.chests.Length < 1)
        {
                return;
        }
        
        var val_2 = 0;
        do
        {
            1152921507333380560.ToggleChestContent(show:  show);
            val_2 = val_2 + 1;
        }
        while(val_2 < this.chests.Length);
    
    }
    public KeyToRichesPopup()
    {
        this.delayBeforeReveal = 3;
        this.delayBeforePrompt = 3f;
        this.openedChests = new System.Collections.Generic.HashSet<System.Int32>();
    }

}
