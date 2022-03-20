using UnityEngine;
public class WGBuyAVowelEventPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button closeButton;
    private WGBuyAVowelEventVowelButton aButton;
    private WGBuyAVowelEventVowelButton eButton;
    private WGBuyAVowelEventVowelButton iButton;
    private WGBuyAVowelEventVowelButton oButton;
    private WGBuyAVowelEventVowelButton uButton;
    private System.Collections.Generic.List<System.Tuple<LineWord, Cell>> aS;
    private System.Collections.Generic.List<System.Tuple<LineWord, Cell>> eS;
    private System.Collections.Generic.List<System.Tuple<LineWord, Cell>> iS;
    private System.Collections.Generic.List<System.Tuple<LineWord, Cell>> oS;
    private System.Collections.Generic.List<System.Tuple<LineWord, Cell>> uS;
    private UnityEngine.UI.Button coinStoreButton;
    
    // Methods
    private void Start()
    {
        ButtonClickedEvent val_41;
        var val_42;
        UnityEngine.UI.Button val_43;
        System.Func<LineWord, System.Boolean> val_44;
        var val_45;
        if(this.closeButton == null)
        {
                throw new NullReferenceException();
        }
        
        val_41 = this.closeButton.m_OnClick;
        if(val_41 == null)
        {
                throw new NullReferenceException();
        }
        
        val_41.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGBuyAVowelEventPopup::Close()));
        if(MainController.instance == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_2.coin_stat_view_anim == null)
        {
                throw new NullReferenceException();
        }
        
        val_42 = 1152921504765632512;
        val_41 = val_2.coin_stat_view_anim.GetComponent<CoinCurrencyStatView>();
        val_43 = 0;
        if(val_41 != 0)
        {
                if(val_41 == null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        this.coinStoreButton = val_43;
        if(val_43 != 0)
        {
                if(this.coinStoreButton == null)
        {
                throw new NullReferenceException();
        }
        
            val_41 = this.coinStoreButton.m_OnClick;
            if(val_41 == null)
        {
                throw new NullReferenceException();
        }
        
            val_41.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGBuyAVowelEventPopup::OnCoinStoreButtonClicked()));
        }
        
        val_41 = MonoSingleton<GameMaskOverlay>.Instance;
        GameMaskOverlay val_8 = MonoSingleton<GameMaskOverlay>.Instance;
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        val_8.BlockRaycasts = true;
        if(val_41 == null)
        {
                throw new NullReferenceException();
        }
        
        val_41.Interactable = true;
        val_41 = MonoSingleton<GameMaskOverlay>.Instance;
        UnityEngine.Color val_10 = new UnityEngine.Color(r:  0f, g:  0f, b:  0f, a:  0.745f);
        System.Nullable<UnityEngine.Color> val_11 = new System.Nullable<UnityEngine.Color>(value:  new UnityEngine.Color() {r = val_10.r, g = val_10.g, b = val_10.b, a = val_10.a});
        if(val_41 == null)
        {
                throw new NullReferenceException();
        }
        
        val_41.SetOptions(bgColor:  new System.Nullable<UnityEngine.Color>() {HasValue = true}, fadeInDuration:  0.25f, fadeOutDuration:  0.15f);
        val_41 = MonoSingleton<GameMaskOverlay>.Instance;
        UnityEngine.Transform[] val_13 = new UnityEngine.Transform[3];
        UnityEngine.GameObject val_14 = this.gameObject;
        if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_13 == null)
        {
                throw new NullReferenceException();
        }
        
        val_13[0] = val_14.transform;
        if(MainController.instance == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_16.coin_stat_view_anim == null)
        {
                throw new NullReferenceException();
        }
        
        val_13[1] = val_16.coin_stat_view_anim.transform;
        if(MainController.instance == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_18.coin_stat_view_plus == null)
        {
                throw new NullReferenceException();
        }
        
        val_13[2] = val_18.coin_stat_view_plus.transform;
        if(val_41 == null)
        {
                throw new NullReferenceException();
        }
        
        val_41.ShowOverlay(contentToOverlay:  val_13);
        val_44 = 1152921504879157248;
        val_41 = WordRegion.instance;
        if(val_41 == 0)
        {
                return;
        }
        
        if(WordRegion.instance == null)
        {
                throw new NullReferenceException();
        }
        
        val_42 = 1152921504909774848;
        val_45 = null;
        val_45 = null;
        val_44 = WGBuyAVowelEventPopup.<>c.<>9__12_0;
        if(val_44 == null)
        {
                System.Func<LineWord, System.Boolean> val_23 = null;
            val_44 = val_23;
            val_23 = new System.Func<LineWord, System.Boolean>(object:  WGBuyAVowelEventPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WGBuyAVowelEventPopup.<>c::<Start>b__12_0(LineWord x));
            WGBuyAVowelEventPopup.<>c.<>9__12_0 = val_44;
        }
        
        System.Collections.Generic.List<TSource> val_25 = System.Linq.Enumerable.ToList<LineWord>(source:  System.Linq.Enumerable.Where<LineWord>(source:  val_41, predicate:  val_23));
        if(val_25 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_26 = val_25.GetEnumerator();
        label_82:
        if(val_11.HasValue.MoveNext() == false)
        {
            goto label_53;
        }
        
        val_41 = 0;
        if(val_41 == 0)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_28 = 41868256.GetEnumerator();
        label_78:
        if(val_11.HasValue.MoveNext() == false)
        {
            goto label_56;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(0 != 0)
        {
            goto label_78;
        }
        
        if(1 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((1.Equals(value:  "A")) == false)
        {
            goto label_60;
        }
        
        if(this.aS == null)
        {
                throw new NullReferenceException();
        }
        
        this.aS.Add(item:  new System.Tuple<LineWord, Cell>(item1:  val_41, item2:  0));
        goto label_78;
        label_60:
        if(1 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((1.Equals(value:  "E")) == false)
        {
            goto label_64;
        }
        
        if(this.eS == null)
        {
                throw new NullReferenceException();
        }
        
        this.eS.Add(item:  new System.Tuple<LineWord, Cell>(item1:  val_41, item2:  0));
        goto label_78;
        label_64:
        if(1 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((1.Equals(value:  "I")) == false)
        {
            goto label_68;
        }
        
        if(this.iS == null)
        {
                throw new NullReferenceException();
        }
        
        this.iS.Add(item:  new System.Tuple<LineWord, Cell>(item1:  val_41, item2:  0));
        goto label_78;
        label_68:
        if(1 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((1.Equals(value:  "O")) == false)
        {
            goto label_72;
        }
        
        if(this.oS == null)
        {
                throw new NullReferenceException();
        }
        
        this.oS.Add(item:  new System.Tuple<LineWord, Cell>(item1:  val_41, item2:  0));
        goto label_78;
        label_72:
        if(1 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((1.Equals(value:  "U")) == false)
        {
            goto label_78;
        }
        
        if(this.uS == null)
        {
                throw new NullReferenceException();
        }
        
        this.uS.Add(item:  new System.Tuple<LineWord, Cell>(item1:  val_41, item2:  0));
        goto label_78;
        label_56:
        val_41 = 0;
        var val_40 = 0 + 1;
        mem2[0] = 602;
        val_11.HasValue.Dispose();
        if(val_41 != 0)
        {
                throw 41967616;
        }
        
        if((val_40 == 1) || ((-1383408864 + ((0 + 1)) << 2) != 602))
        {
            goto label_82;
        }
        
        var val_43 = 0;
        val_43 = val_43 ^ (val_40 >> 31);
        var val_41 = val_40 + val_43;
        goto label_82;
        label_53:
        var val_42 = 0 + 1;
        mem2[0] = 630;
        val_11.HasValue.Dispose();
        this.SetupButtons();
    }
    private System.Collections.IEnumerator AutoClose()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGBuyAVowelEventPopup.<AutoClose>d__13();
    }
    private void SetupButtons()
    {
        decimal val_1 = this.GetCostForVowel(vowel:  "A", cells:  this.aS);
        this.aButton.Setup(letter:  "A", cost:  new System.Decimal() {flags = val_1.flags, hi = val_1.hi, lo = val_1.lo, mid = val_1.mid}, callback:  new System.Action<System.String>(object:  this, method:  System.Void WGBuyAVowelEventPopup::OnVowelClicked(string vowel)));
        decimal val_3 = this.aButton.GetCostForVowel(vowel:  "E", cells:  this.eS);
        this.eButton.Setup(letter:  "E", cost:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid}, callback:  new System.Action<System.String>(object:  this, method:  System.Void WGBuyAVowelEventPopup::OnVowelClicked(string vowel)));
        decimal val_5 = this.eButton.GetCostForVowel(vowel:  "I", cells:  this.iS);
        this.iButton.Setup(letter:  "I", cost:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid}, callback:  new System.Action<System.String>(object:  this, method:  System.Void WGBuyAVowelEventPopup::OnVowelClicked(string vowel)));
        decimal val_7 = this.iButton.GetCostForVowel(vowel:  "O", cells:  this.oS);
        this.oButton.Setup(letter:  "O", cost:  new System.Decimal() {flags = val_7.flags, hi = val_7.hi, lo = val_7.lo, mid = val_7.mid}, callback:  new System.Action<System.String>(object:  this, method:  System.Void WGBuyAVowelEventPopup::OnVowelClicked(string vowel)));
        decimal val_9 = this.oButton.GetCostForVowel(vowel:  "U", cells:  this.uS);
        this.uButton.Setup(letter:  "U", cost:  new System.Decimal() {flags = val_9.flags, hi = val_9.hi, lo = val_9.lo, mid = val_9.mid}, callback:  new System.Action<System.String>(object:  this, method:  System.Void WGBuyAVowelEventPopup::OnVowelClicked(string vowel)));
        if(this.aS != null)
        {
                return;
        }
        
        if(this.eS != null)
        {
                return;
        }
        
        if(this.iS != null)
        {
                return;
        }
        
        if(this.oS != null)
        {
                return;
        }
        
        if(this.uS != null)
        {
                return;
        }
        
        UnityEngine.Coroutine val_12 = this.StartCoroutine(routine:  this.AutoClose());
    }
    private decimal GetCostForVowel(string vowel, System.Collections.Generic.List<System.Tuple<LineWord, Cell>> cells)
    {
        string val_12;
        .vowel = vowel;
        decimal val_2 = BuyAVowelEventHandler.<Instance>k__BackingField.GetVowelPrice;
        val_12 = "";
        if(CategoryPacksManager.IsPlaying != false)
        {
                GameLevel val_4 = PlayingLevel.GetCategoryLevel(categoryPackId:  0);
            val_12 = val_4.word;
        }
        
        if((PlayingLevel.GetLevelForPlayerLevel(levelIndex:  0, checkLevelSkip:  false)) != null)
        {
                GameLevel val_6 = PlayingLevel.GetLevelForPlayerLevel(levelIndex:  0, checkLevelSkip:  false);
            val_12 = val_6.word;
        }
        
        decimal val_11 = System.Decimal.op_Implicit(value:  System.Linq.Enumerable.Count<System.Char>(source:  val_12, predicate:  new System.Func<System.Char, System.Boolean>(object:  new WGBuyAVowelEventPopup.<>c__DisplayClass15_0(), method:  System.Boolean WGBuyAVowelEventPopup.<>c__DisplayClass15_0::<GetCostForVowel>b__0(char x))));
        return System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = (PlayingLevel.__il2cppRuntimeField_cctor_finished == 0) ? 0 : val_2.flags, hi = (PlayingLevel.__il2cppRuntimeField_cctor_finished == 0) ? 0 : val_2.flags, lo = (PlayingLevel.__il2cppRuntimeField_cctor_finished == 0) ? 0 : val_2.lo, mid = (PlayingLevel.__il2cppRuntimeField_cctor_finished == 0) ? 0 : val_2.lo}, d2:  new System.Decimal() {flags = val_11.flags, hi = val_11.hi, lo = val_11.lo, mid = val_11.mid});
    }
    private void OnVowelClicked(string vowel)
    {
        var val_18;
        var val_19;
        WGBuyAVowelEventPopup val_30;
        System.Collections.Generic.List<System.Tuple<LineWord, Cell>> val_31;
        var val_32;
        string val_33;
        int val_34;
        var val_35;
        decimal val_36;
        var val_37;
        var val_38;
        BuyAVowelEventHandler val_39;
        var val_40;
        var val_41;
        val_30 = this;
        System.Collections.Generic.List<System.Tuple<LineWord, Cell>> val_1 = null;
        val_31 = val_1;
        val_1 = new System.Collections.Generic.List<System.Tuple<LineWord, Cell>>();
        val_32 = this.gameObject.transform;
        if((System.String.op_Equality(a:  vowel, b:  "A")) == false)
        {
            goto label_2;
        }
        
        val_31 = this.aS;
        goto label_13;
        label_2:
        if((System.String.op_Equality(a:  vowel, b:  "E")) == false)
        {
            goto label_5;
        }
        
        val_31 = this.eS;
        goto label_13;
        label_5:
        if((System.String.op_Equality(a:  vowel, b:  "I")) == false)
        {
            goto label_8;
        }
        
        val_31 = this.iS;
        goto label_13;
        label_8:
        if((System.String.op_Equality(a:  vowel, b:  "O")) == false)
        {
            goto label_11;
        }
        
        val_31 = this.oS;
        goto label_13;
        label_11:
        val_33 = vowel;
        if((System.String.op_Equality(a:  val_33, b:  "U")) == false)
        {
            goto label_14;
        }
        
        val_31 = this.uS;
        label_13:
        UnityEngine.Transform val_10 = this.uButton.gameObject.transform;
        val_32 = val_10;
        label_14:
        decimal val_11 = val_10.GetCostForVowel(vowel:  vowel, cells:  val_31);
        decimal val_12 = CurrencyController.GetBalance();
        val_34 = val_12.flags;
        val_35 = null;
        val_35 = null;
        val_36 = System.Decimal.Zero;
        if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_11.flags, hi = val_11.hi, lo = val_11.lo, mid = val_11.mid}, d2:  new System.Decimal() {flags = val_36, hi = val_36, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) == false)
        {
            goto label_19;
        }
        
        if((System.Decimal.op_GreaterThanOrEqual(d1:  new System.Decimal() {flags = val_34, hi = val_12.hi, lo = val_12.lo, mid = val_12.mid}, d2:  new System.Decimal() {flags = val_11.flags, hi = val_11.hi, lo = val_11.lo, mid = val_11.mid})) == false)
        {
            goto label_22;
        }
        
        val_36 = System.String.Format(format:  "Vowel - {0}", arg0:  vowel);
        bool val_16 = CurrencyController.DebitBalance(value:  new System.Decimal() {flags = val_11.flags, hi = val_11.hi, lo = val_11.lo, mid = val_11.mid}, source:  val_36, externalParams:  0, animated:  true);
        label_19:
        List.Enumerator<T> val_17 = val_31.GetEnumerator();
        val_34 = 1152921516109265872;
        val_30 = 1152921504893161472;
        label_37:
        if(val_19.MoveNext() == false)
        {
            goto label_24;
        }
        
        if(val_18 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(WordRegion.instance == null)
        {
                throw new NullReferenceException();
        }
        
        GameMaskOverlay val_22 = MonoSingleton<GameMaskOverlay>.Instance;
        UnityEngine.Transform[] val_23 = new UnityEngine.Transform[1];
        val_37 = mem[val_18 + 24];
        val_37 = val_18 + 24;
        if(val_37 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_23 == null)
        {
                throw new NullReferenceException();
        }
        
        val_23[0] = val_37.transform;
        if(val_22 == null)
        {
                throw new NullReferenceException();
        }
        
        val_22.ShowOverlay(contentToOverlay:  val_23);
        goto label_37;
        label_24:
        val_19.Dispose();
        val_39 = BuyAVowelEventHandler.<Instance>k__BackingField;
        val_39.TrackBuyVowelOnLevel(level:  Player.GetLevelForTracking());
        val_31.Clear();
        this.SetupButtons();
        return;
        label_22:
        val_40 = null;
        val_40 = null;
        PurchaseProxy.currentPurchasePoint = 100;
        val_38 = 1152921504909774848;
        val_41 = null;
        val_41 = null;
        val_39 = WGBuyAVowelEventPopup.<>c.<>9__16_0;
        if(val_39 == null)
        {
                System.Action val_28 = null;
            val_39 = val_28;
            val_28 = new System.Action(object:  WGBuyAVowelEventPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGBuyAVowelEventPopup.<>c::<OnVowelClicked>b__16_0());
            WGBuyAVowelEventPopup.<>c.<>9__16_0 = val_39;
        }
        
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGStoreProxy>(showNext:  true).Init(outOfCredits:  true, onCloseAction:  val_28);
        this.Close();
    }
    private void OnCoinStoreButtonClicked()
    {
        var val_4;
        System.Action val_6;
        val_4 = null;
        val_4 = null;
        val_6 = WGBuyAVowelEventPopup.<>c.<>9__17_0;
        if(val_6 == null)
        {
                System.Action val_3 = null;
            val_6 = val_3;
            val_3 = new System.Action(object:  WGBuyAVowelEventPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGBuyAVowelEventPopup.<>c::<OnCoinStoreButtonClicked>b__17_0());
            WGBuyAVowelEventPopup.<>c.<>9__17_0 = val_6;
        }
        
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGStoreProxy>(showNext:  true).Init(outOfCredits:  true, onCloseAction:  val_3);
        this.Close();
    }
    private void Close()
    {
        if(this.coinStoreButton != 0)
        {
                this.coinStoreButton.m_OnClick.RemoveListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGBuyAVowelEventPopup::OnCoinStoreButtonClicked()));
        }
        
        this.StopCoroutine(routine:  this.AutoClose());
        MonoSingleton<GameMaskOverlay>.Instance.CloseOverlay(onClosed:  0);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public WGBuyAVowelEventPopup()
    {
        this.aS = new System.Collections.Generic.List<System.Tuple<LineWord, Cell>>();
        this.eS = new System.Collections.Generic.List<System.Tuple<LineWord, Cell>>();
        this.iS = new System.Collections.Generic.List<System.Tuple<LineWord, Cell>>();
        this.oS = new System.Collections.Generic.List<System.Tuple<LineWord, Cell>>();
        this.uS = new System.Collections.Generic.List<System.Tuple<LineWord, Cell>>();
    }

}
