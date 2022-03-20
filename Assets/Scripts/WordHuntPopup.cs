using UnityEngine;
public class WordHuntPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.RectTransform displayWordParent;
    private Cell cellPrefab;
    private LineWord lineWordPrefab;
    private float cellSizeSmall;
    private float cellSizeLarge;
    private UnityEngine.UI.Button closeButton;
    private UnityEngine.UI.Button playButton;
    private UnityEngine.UI.Button coinCollectButton;
    private UnityEngine.UI.Button continueButton;
    private UnityEngine.GameObject spinRewardGroup;
    private UnityEngine.GameObject wheelRewardGroup;
    private UnityEngine.GameObject timerGroup;
    private UnityEngine.UI.Text eventEndedText;
    private UnityEngine.UI.Text themeText;
    private UnityEngine.UI.Text rewardText;
    private UnityEngine.UI.Text collectCoinValueText;
    private UnityEngine.UI.Text timerText;
    private UnityEngine.UI.Text playButtonText;
    private GridCoinCollectAnimationInstantiator gcAi;
    private UnityEngine.ParticleSystem victoryEffect;
    private bool eventExpired;
    
    // Methods
    private void Start()
    {
        if(WordHuntEvent.CACHE_COLLECTED_WORDS_KEY != null)
        {
                this.Init();
            return;
        }
        
        this.gameObject.SetActive(value:  false);
    }
    private void Init()
    {
        this.victoryEffect.gameObject.SetActive(value:  false);
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordHuntPopup::<Init>b__22_0()));
        this.closeButton.gameObject.SetActive(value:  false);
        this.timerGroup.SetActive(value:  true);
        this.eventEndedText.gameObject.SetActive(value:  false);
        this.BuildUI();
        this.UpdateFeaturePoint();
        FrameSkipper val_6 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<FrameSkipper>(gameObject:  this.gameObject);
        val_6.updateLogic = new System.Action(object:  this, method:  System.Void WordHuntPopup::UpdateTimerText());
    }
    public void BuildUI()
    {
        object val_37;
        var val_66;
        System.Func<System.String, System.String> val_68;
        var val_69;
        System.Func<System.String, System.Int32> val_71;
        var val_72;
        UnityEngine.UI.Button val_73;
        float val_74;
        UnityEngine.Events.UnityAction val_75;
        UnityEngine.Events.UnityAction val_76;
        var val_77;
        object val_78;
        var val_79;
        if(this.displayWordParent == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.displayWordParent.childCount >= 1)
        {
                MethodExtensionForMonoBehaviourTransform.DestroyChildren(t:  this.displayWordParent);
        }
        
        if(this.coinCollectButton == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.coinCollectButton.m_OnClick == null)
        {
                throw new NullReferenceException();
        }
        
        this.coinCollectButton.m_OnClick.RemoveAllListeners();
        if(this.coinCollectButton == null)
        {
                throw new NullReferenceException();
        }
        
        this.coinCollectButton.interactable = true;
        if(this.playButton == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.playButton.m_OnClick == null)
        {
                throw new NullReferenceException();
        }
        
        this.playButton.m_OnClick.RemoveAllListeners();
        if(this.playButton == null)
        {
                throw new NullReferenceException();
        }
        
        this.playButton.interactable = true;
        if(WordHuntEvent.CACHE_COLLECTED_WORDS_KEY == null)
        {
                throw new NullReferenceException();
        }
        
        val_66 = null;
        val_66 = null;
        val_68 = WordHuntPopup.<>c.<>9__23_0;
        if(val_68 == null)
        {
                System.Func<System.String, System.String> val_2 = null;
            val_68 = val_2;
            val_2 = new System.Func<System.String, System.String>(object:  WordHuntPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.String WordHuntPopup.<>c::<BuildUI>b__23_0(string x));
            WordHuntPopup.<>c.<>9__23_0 = val_68;
        }
        
        val_69 = null;
        val_69 = null;
        val_71 = WordHuntPopup.<>c.<>9__23_1;
        if(val_71 == null)
        {
                System.Func<System.String, System.Int32> val_5 = null;
            val_71 = val_5;
            val_5 = new System.Func<System.String, System.Int32>(object:  WordHuntPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 WordHuntPopup.<>c::<BuildUI>b__23_1(string x));
            WordHuntPopup.<>c.<>9__23_1 = val_71;
        }
        
        System.Collections.Generic.List<TSource> val_8 = System.Linq.Enumerable.ToList<System.String>(source:  System.Linq.Enumerable.Reverse<System.String>(source:  System.Linq.Enumerable.OrderByDescending<System.String, System.Int32>(source:  System.Linq.Enumerable.Reverse<System.String>(source:  System.Linq.Enumerable.OrderBy<System.String, System.String>(source:  WordHuntEvent.CACHE_COLLECTED_WORDS_KEY + 40, keySelector:  val_2)), keySelector:  val_5)));
        if(WordHuntEvent.CACHE_COLLECTED_WORDS_KEY == null)
        {
                throw new NullReferenceException();
        }
        
        val_71 = this.themeText;
        string val_9 = WordHuntEvent.CACHE_COLLECTED_WORDS_KEY.eventTheme;
        if(val_71 == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.coinCollectButton == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_10 = this.coinCollectButton.gameObject;
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        val_10.SetActive(value:  false);
        if(this.playButton == null)
        {
                throw new NullReferenceException();
        }
        
        val_71 = this.playButton.gameObject;
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_12.<metaGameBehavior>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_71 == null)
        {
                throw new NullReferenceException();
        }
        
        val_71.SetActive(value:  ((val_12.<metaGameBehavior>k__BackingField) == 1) ? 1 : 0);
        val_71 = this.playButtonText;
        if(val_71 == 0)
        {
                UnityEngine.Debug.LogError(message:  "Play button text not set on Word Hunt Popup");
        }
        else
        {
                val_71 = this.playButtonText;
            Player val_16 = App.Player;
            if(val_16 == null)
        {
                throw new NullReferenceException();
        }
        
            string val_17 = System.String.Format(format:  Localization.Localize(key:  "level_#_upper", defaultValue:  "LEVEL {0}", useSingularKey:  false), arg0:  val_16);
            if(val_71 == null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        if(this.continueButton == null)
        {
                throw new NullReferenceException();
        }
        
        val_71 = this.continueButton.gameObject;
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_19.<metaGameBehavior>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_71 == null)
        {
                throw new NullReferenceException();
        }
        
        val_71.SetActive(value:  ((val_19.<metaGameBehavior>k__BackingField) != 1) ? 1 : 0);
        if(this.continueButton == null)
        {
                throw new NullReferenceException();
        }
        
        val_71 = this.continueButton.m_OnClick;
        UnityEngine.Events.UnityAction val_21 = null;
        val_72 = 1152921516829975152;
        val_21 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordHuntPopup::PlayButtonClick());
        if(val_71 == null)
        {
                throw new NullReferenceException();
        }
        
        val_71.AddListener(call:  val_21);
        System.Text.StringBuilder val_22 = null;
        val_71 = val_22;
        val_22 = new System.Text.StringBuilder();
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_23.<metaGameBehavior>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        if(WordHuntEvent.CACHE_COLLECTED_WORDS_KEY == null)
        {
                throw new NullReferenceException();
        }
        
        val_73 = mem[val_23.<metaGameBehavior>k__BackingField == 0x1 ? 1152921516830202304 : 1152921516830202320];
        val_73 = ((val_23.<metaGameBehavior>k__BackingField) == 1) ? (this.playButton) : (this.continueButton);
        val_74 = 0f;
        if((WordHuntEvent.CACHE_COLLECTED_WORDS_KEY + 56) == 1)
        {
                val_74 = this.cellSizeLarge;
            if((WordHuntEvent.CACHE_COLLECTED_WORDS_KEY & 1) != 0)
        {
                if(val_73 == 0)
        {
                throw new NullReferenceException();
        }
        
            UnityEngine.GameObject val_25 = val_73.gameObject;
            if(val_25 == null)
        {
                throw new NullReferenceException();
        }
        
            val_25.SetActive(value:  false);
            if(this.coinCollectButton == null)
        {
                throw new NullReferenceException();
        }
        
            UnityEngine.GameObject val_26 = this.coinCollectButton.gameObject;
            if(val_26 == null)
        {
                throw new NullReferenceException();
        }
        
            val_26.SetActive(value:  true);
            if(WordHuntEvent.CACHE_COLLECTED_WORDS_KEY == null)
        {
                throw new NullReferenceException();
        }
        
            val_73 = this.coinCollectButton;
            string val_27 = WordHuntEvent.CACHE_COLLECTED_WORDS_KEY + 60.ToString();
            if(this.collectCoinValueText == null)
        {
                throw new NullReferenceException();
        }
        
        }
        else
        {
                if(val_71 == null)
        {
                throw new NullReferenceException();
        }
        
            System.Text.StringBuilder val_28 = val_22.Append(value:  "Find every word while playing to earn ");
            if(WordHuntEvent.CACHE_COLLECTED_WORDS_KEY == null)
        {
                throw new NullReferenceException();
        }
        
            System.Text.StringBuilder val_29 = val_22.Append(value:  WordHuntEvent.CACHE_COLLECTED_WORDS_KEY + 60);
            System.Text.StringBuilder val_30 = val_22.Append(value:  " Coins");
        }
        
        }
        
        if(WordHuntEvent.CACHE_COLLECTED_WORDS_KEY == null)
        {
                throw new NullReferenceException();
        }
        
        if((WordHuntEvent.CACHE_COLLECTED_WORDS_KEY & 1) != 0)
        {
                if(val_71 == null)
        {
                throw new NullReferenceException();
        }
        
            System.Text.StringBuilder val_31 = val_22.Append(value:  "All words found!");
            if(val_73 == 0)
        {
                throw new NullReferenceException();
        }
        
            UnityEngine.Events.UnityAction val_32 = null;
            val_75 = val_32;
            val_32 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordHuntPopup::CollectButtonClick());
            if((val_23.<metaGameBehavior>k__BackingField == 0x1 ? 1152921516830202304 : 1152921516830202320 + 248) == 0)
        {
                throw new NullReferenceException();
        }
        
            val_23.<metaGameBehavior>k__BackingField == 0x1 ? 1152921516830202304 : 1152921516830202320 + 248.AddListener(call:  val_32);
            if(this.victoryEffect == null)
        {
                throw new NullReferenceException();
        }
        
            UnityEngine.GameObject val_33 = this.victoryEffect.gameObject;
            if(val_33 == null)
        {
                throw new NullReferenceException();
        }
        
            val_33.SetActive(value:  true);
            if(this.victoryEffect == null)
        {
                throw new NullReferenceException();
        }
        
            this.victoryEffect.Play();
            if(this.timerGroup == null)
        {
                throw new NullReferenceException();
        }
        
            val_76 = 0;
            this.timerGroup.SetActive(value:  false);
        }
        else
        {
                if(this.closeButton == null)
        {
                throw new NullReferenceException();
        }
        
            UnityEngine.GameObject val_34 = this.closeButton.gameObject;
            if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
            val_34.SetActive(value:  true);
            if(val_73 == 0)
        {
                throw new NullReferenceException();
        }
        
            UnityEngine.Events.UnityAction val_35 = null;
            val_75 = val_35;
            val_35 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordHuntPopup::PlayButtonClick());
            if((val_23.<metaGameBehavior>k__BackingField == 0x1 ? 1152921516830202304 : 1152921516830202320 + 248) == 0)
        {
                throw new NullReferenceException();
        }
        
            val_76 = val_75;
            val_23.<metaGameBehavior>k__BackingField == 0x1 ? 1152921516830202304 : 1152921516830202320 + 248.AddListener(call:  val_35);
            if(val_71 == null)
        {
                throw new NullReferenceException();
        }
        
        }
        
        if(this.rewardText == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.eventExpired != false)
        {
                this.EventExpiredIncompleteUI();
            return;
        }
        
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_36 = val_8.GetEnumerator();
        val_72 = 1152921515446279280;
        val_75 = 0;
        label_117:
        if(val_16.MoveNext() == false)
        {
            goto label_81;
        }
        
        val_71 = val_37;
        LineWord val_39 = UnityEngine.Object.Instantiate<LineWord>(original:  this.lineWordPrefab);
        if(val_71 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_39 == null)
        {
                throw new NullReferenceException();
        }
        
        val_39.answer = val_71.ToUpper();
        val_39.cellSize = val_74;
        val_39.SetLineWidth();
        UnityEngine.GameObject val_41 = val_39.gameObject;
        if(val_41 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_41.AddComponent<UnityEngine.UI.LayoutElement>()) == null)
        {
                throw new NullReferenceException();
        }
        
        val_39.Build(cellType:  this.cellPrefab, clickable:  true);
        if(WordHuntEvent.CACHE_COLLECTED_WORDS_KEY == null)
        {
                throw new NullReferenceException();
        }
        
        val_77 = mem[WordHuntEvent.CACHE_COLLECTED_WORDS_KEY + 48];
        val_77 = WordHuntEvent.CACHE_COLLECTED_WORDS_KEY + 48;
        if(val_77 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_78 = val_71;
        bool val_43 = val_77.Contains(item:  val_78);
        if(val_43 != false)
        {
                if(WordHuntEvent.CACHE_COLLECTED_WORDS_KEY == null)
        {
                throw new NullReferenceException();
        }
        
            if((System.Linq.Enumerable.Contains<System.String>(source:  val_43.CacheCollectedWords, value:  val_71)) != true)
        {
                System.Text.StringBuilder val_46 = null;
            val_79 = 0;
            val_46 = new System.Text.StringBuilder();
            if((val_37 + 16) >= 1)
        {
                do
        {
            char val_47 = val_71.Chars[0];
            if(val_46 == null)
        {
                throw new NullReferenceException();
        }
        
            System.Text.StringBuilder val_48 = val_46.Append(value:  1);
            val_79 = 1;
        }
        while(val_79 < (val_37 + 16));
        
        }
        
            val_39.SetProgress(progress:  val_46);
        }
        
        }
        
        if(val_39.cells == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_49 = val_39.cells.GetEnumerator();
        label_109:
        if(val_16.MoveNext() == false)
        {
            goto label_99;
        }
        
        if(WordHuntEvent.CACHE_COLLECTED_WORDS_KEY == null)
        {
                throw new NullReferenceException();
        }
        
        val_71 = val_37;
        string val_51 = WordHuntEvent.CACHE_COLLECTED_WORDS_KEY.currentColor;
        if(val_51 == null)
        {
                throw new NullReferenceException();
        }
        
        if((WordHuntEvent.CACHE_COLLECTED_WORDS_KEY + 80) == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Color32 val_53 = WordHuntEvent.CACHE_COLLECTED_WORDS_KEY + 80.Item[val_51.ToUpper()];
        if(val_71 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_71.SetNewBackgroundAndColor(bgColor:  new UnityEngine.Color32() {r = val_53.r & 4294967295, g = val_53.r & 4294967295, b = val_53.r & 4294967295, a = val_53.r & 4294967295}, bgAlpha:  1f);
        if((val_71.GetComponent<UnityEngine.UI.Button>()) == 0)
        {
            goto label_109;
        }
        
        if((val_71.GetComponent<UnityEngine.UI.Button>()) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_57.m_OnClick == null)
        {
                throw new NullReferenceException();
        }
        
        val_57.m_OnClick.RemoveAllListeners();
        goto label_109;
        label_99:
        val_71 = 0;
        val_75 = val_75 + 1;
        mem2[0] = 1069;
        val_16.Dispose();
        if(val_71 != 0)
        {
            goto label_110;
        }
        
        if(val_75 != 1)
        {
                var val_58 = ((-661558848 + ((val_75 + 1)) << 2) == 1069) ? 1 : 0;
            val_58 = ((val_75 >= 0) ? 1 : 0) & val_58;
            val_75 = val_75 - val_58;
        }
        
        UnityEngine.Transform val_60 = val_39.transform;
        if(val_60 == null)
        {
                throw new NullReferenceException();
        }
        
        val_60.SetParent(p:  this.displayWordParent);
        val_71 = val_39.transform;
        UnityEngine.Vector3 val_62 = UnityEngine.Vector3.one;
        if(val_71 == null)
        {
                throw new NullReferenceException();
        }
        
        val_71.localScale = new UnityEngine.Vector3() {x = val_62.x, y = val_62.y, z = val_62.z};
        UnityEngine.Transform val_63 = val_39.transform;
        UnityEngine.Vector3 val_64 = UnityEngine.Vector3.zero;
        if(val_63 == null)
        {
                throw new NullReferenceException();
        }
        
        val_63.localPosition = new UnityEngine.Vector3() {x = val_64.x, y = val_64.y, z = val_64.z};
        goto label_117;
        label_81:
        var val_65 = val_75 + 1;
        mem2[0] = 1149;
        val_16.Dispose();
        return;
        label_110:
        val_77 = val_71;
        val_78 = 0;
        throw val_77;
    }
    private void PlayButtonClick()
    {
        this.UpdateFeaturePoint();
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) != 2) && (this.eventExpired != true))
        {
                GameBehavior val_2 = App.getBehavior;
        }
        
        this.Close();
    }
    private void CollectButtonClick()
    {
        mem2[0] = 0;
        this.coinCollectButton.interactable = false;
        this.playButton.interactable = false;
        if((WordHuntEvent.CACHE_COLLECTED_WORDS_KEY + 56) == 1)
        {
                this.gcAi.OnCompleteCallback = new System.Action(object:  this, method:  public System.Void WordHuntPopup::Close());
            WordHuntEvent.CACHE_COLLECTED_WORDS_KEY.CollectReward();
            Player val_2 = App.Player;
            decimal val_3 = System.Decimal.op_Implicit(value:  WordHuntEvent.CACHE_COLLECTED_WORDS_KEY + 60);
            decimal val_4 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_2._credits, hi = val_2._credits, lo = -660871808, mid = 268435458}, d2:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid});
            Player val_5 = App.Player;
            this.gcAi.Play(fromValue:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid}, toValue:  new System.Decimal() {flags = val_5._credits, hi = val_5._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
            return;
        }
        
        this.Close();
    }
    private void UpdateTimerText()
    {
        if(this.eventExpired == true)
        {
                return;
        }
        
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = WordHuntEvent.CACHE_COLLECTED_WORDS_KEY.m_stringLength + 40}, d2:  new System.DateTime() {dateData = val_1.dateData});
        object[] val_3 = new object[4];
        val_3[0] = val_2._ticks.Days;
        val_3[1] = val_2._ticks.Hours;
        val_3[2] = val_2._ticks.Minutes;
        val_3[3] = val_2._ticks.Seconds;
        string val_8 = System.String.Format(format:  "{0}d {1:00}h {2:00}m {3:00}s", args:  val_3);
        if(val_2._ticks.TotalSeconds >= 0)
        {
                return;
        }
        
        this.eventExpired = true;
        this.EventExpiredIncompleteUI();
    }
    private void UpdateFeaturePoint()
    {
        var val_3;
        var val_4;
        var val_5;
        val_3 = 1152921504884269056;
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) == 1)
        {
                val_3 = 1152921504887996416;
            val_4 = null;
            val_4 = null;
            val_5 = 50;
        }
        else
        {
                GameBehavior val_2 = App.getBehavior;
            if((val_2.<metaGameBehavior>k__BackingField) != 2)
        {
                return;
        }
        
            val_3 = 1152921504887996416;
            val_4 = null;
            val_4 = null;
            val_5 = 51;
        }
        
        AmplitudePluginHelper.lastFeatureAccessPoint = 51;
    }
    private void EventExpiredIncompleteUI()
    {
        object val_15;
        UnityEngine.RectTransform val_51;
        object val_52;
        var val_53;
        System.Func<System.String, System.String> val_55;
        var val_56;
        System.Func<System.String, System.Int32> val_58;
        object val_59;
        var val_60;
        val_51 = this.displayWordParent;
        if(val_51 == null)
        {
                throw new NullReferenceException();
        }
        
        val_52 = 0;
        if(val_51.childCount >= 1)
        {
                val_52 = 0;
            MethodExtensionForMonoBehaviourTransform.DestroyChildren(t:  this.displayWordParent);
        }
        
        val_51 = this.timerGroup;
        if(val_51 == null)
        {
                throw new NullReferenceException();
        }
        
        val_52 = 0;
        val_51.SetActive(value:  false);
        val_51 = this.closeButton;
        if(val_51 == null)
        {
                throw new NullReferenceException();
        }
        
        val_52 = 0;
        UnityEngine.GameObject val_2 = val_51.gameObject;
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        val_52 = 0;
        val_2.SetActive(value:  false);
        val_51 = this.eventEndedText;
        if(val_51 == null)
        {
                throw new NullReferenceException();
        }
        
        val_52 = 0;
        UnityEngine.GameObject val_3 = val_51.gameObject;
        if(val_3 == null)
        {
                throw new NullReferenceException();
        }
        
        val_52 = 1;
        val_3.SetActive(value:  true);
        if(WordHuntEvent.CACHE_COLLECTED_WORDS_KEY == null)
        {
                throw new NullReferenceException();
        }
        
        if((WordHuntEvent.CACHE_COLLECTED_WORDS_KEY + 48) == 0)
        {
                throw new NullReferenceException();
        }
        
        if(WordHuntEvent.CACHE_COLLECTED_WORDS_KEY == null)
        {
                throw new NullReferenceException();
        }
        
        if((WordHuntEvent.CACHE_COLLECTED_WORDS_KEY + 40) == 0)
        {
                throw new NullReferenceException();
        }
        
        val_52 = WordHuntEvent.CACHE_COLLECTED_WORDS_KEY + 48 + 24;
        if(this.rewardText == null)
        {
                throw new NullReferenceException();
        }
        
        val_52 = System.String.Format(format:  "The Word Hunt has ended!\nYou\'ve found {0} out of {1} Words!", arg0:  WordHuntEvent.CACHE_COLLECTED_WORDS_KEY + 48 + 24, arg1:  WordHuntEvent.CACHE_COLLECTED_WORDS_KEY + 40 + 24);
        val_51 = this.playButton;
        if(val_51 == null)
        {
                throw new NullReferenceException();
        }
        
        val_52 = 0;
        UnityEngine.GameObject val_5 = val_51.gameObject;
        if(val_5 == null)
        {
                throw new NullReferenceException();
        }
        
        val_52 = 0;
        val_5.SetActive(value:  false);
        val_51 = this.continueButton;
        if(val_51 == null)
        {
                throw new NullReferenceException();
        }
        
        val_52 = 0;
        UnityEngine.GameObject val_6 = val_51.gameObject;
        if(val_6 == null)
        {
                throw new NullReferenceException();
        }
        
        val_52 = 1;
        val_6.SetActive(value:  true);
        if(WordHuntEvent.CACHE_COLLECTED_WORDS_KEY == null)
        {
                throw new NullReferenceException();
        }
        
        WordHuntEvent.CACHE_COLLECTED_WORDS_KEY.__unknownFiledOffset_80 = 1;
        if(WordHuntEvent.CACHE_COLLECTED_WORDS_KEY == null)
        {
                throw new NullReferenceException();
        }
        
        val_53 = null;
        val_53 = null;
        val_55 = WordHuntPopup.<>c.<>9__28_0;
        if(val_55 == null)
        {
                System.Func<System.String, System.String> val_7 = null;
            val_55 = val_7;
            val_7 = new System.Func<System.String, System.String>(object:  WordHuntPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.String WordHuntPopup.<>c::<EventExpiredIncompleteUI>b__28_0(string x));
            WordHuntPopup.<>c.<>9__28_0 = val_55;
        }
        
        val_56 = null;
        val_56 = null;
        val_58 = WordHuntPopup.<>c.<>9__28_1;
        if(val_58 == null)
        {
                System.Func<System.String, System.Int32> val_10 = null;
            val_58 = val_10;
            val_10 = new System.Func<System.String, System.Int32>(object:  WordHuntPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 WordHuntPopup.<>c::<EventExpiredIncompleteUI>b__28_1(string x));
            WordHuntPopup.<>c.<>9__28_1 = val_58;
        }
        
        val_52 = public static System.Collections.Generic.List<TSource> System.Linq.Enumerable::ToList<System.String>(System.Collections.Generic.IEnumerable<TSource> source);
        System.Collections.Generic.List<TSource> val_13 = System.Linq.Enumerable.ToList<System.String>(source:  System.Linq.Enumerable.Reverse<System.String>(source:  System.Linq.Enumerable.OrderByDescending<System.String, System.Int32>(source:  System.Linq.Enumerable.Reverse<System.String>(source:  System.Linq.Enumerable.OrderBy<System.String, System.String>(source:  WordHuntEvent.CACHE_COLLECTED_WORDS_KEY + 40, keySelector:  val_7)), keySelector:  val_10)));
        if(val_13 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_14 = val_13.GetEnumerator();
        label_77:
        if((WordHuntEvent.CACHE_COLLECTED_WORDS_KEY + 48 + 24.MoveNext()) == false)
        {
            goto label_30;
        }
        
        val_59 = val_15;
        val_52 = public static LineWord UnityEngine.Object::Instantiate<LineWord>(LineWord original);
        LineWord val_17 = UnityEngine.Object.Instantiate<LineWord>(original:  mem[1152921516831498792]);
        if(val_59 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_52 = 0;
        if(val_17 == null)
        {
                throw new NullReferenceException();
        }
        
        val_17.answer = val_59.ToUpper();
        val_17.cellSize = this.cellSizeLarge;
        val_17.SetLineWidth();
        val_52 = 0;
        UnityEngine.GameObject val_19 = val_17.gameObject;
        if(val_19 == null)
        {
                throw new NullReferenceException();
        }
        
        val_52 = public UnityEngine.UI.LayoutElement UnityEngine.GameObject::AddComponent<UnityEngine.UI.LayoutElement>();
        if((val_19.AddComponent<UnityEngine.UI.LayoutElement>()) == null)
        {
                throw new NullReferenceException();
        }
        
        val_17.Build(cellType:  mem[1152921516831498784], clickable:  true);
        System.Text.StringBuilder val_21 = null;
        val_60 = 0;
        val_21 = new System.Text.StringBuilder();
        if((val_15 + 16) >= 1)
        {
                var val_50 = 0;
            do
        {
            char val_22 = val_59.Chars[0];
            if(val_21 == null)
        {
                throw new NullReferenceException();
        }
        
            val_60 = 1;
            System.Text.StringBuilder val_23 = val_21.Append(value:  1);
            val_50 = val_50 + 1;
        }
        while(val_50 < (val_15 + 16));
        
        }
        
        val_52 = val_21;
        val_17.SetProgress(progress:  val_21);
        val_51 = val_17.cells;
        if(val_51 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_24 = val_51.GetEnumerator();
        label_68:
        if((WordHuntEvent.CACHE_COLLECTED_WORDS_KEY + 48 + 24.MoveNext()) == false)
        {
            goto label_43;
        }
        
        if(WordHuntEvent.CACHE_COLLECTED_WORDS_KEY == null)
        {
                throw new NullReferenceException();
        }
        
        if((WordHuntEvent.CACHE_COLLECTED_WORDS_KEY + 48) == 0)
        {
                throw new NullReferenceException();
        }
        
        bool val_26 = WordHuntEvent.CACHE_COLLECTED_WORDS_KEY + 48.Contains(item:  val_59);
        if(val_26 == false)
        {
            goto label_46;
        }
        
        if(WordHuntEvent.CACHE_COLLECTED_WORDS_KEY == null)
        {
                throw new NullReferenceException();
        }
        
        if((System.Linq.Enumerable.Contains<System.String>(source:  val_26.CacheCollectedWords, value:  val_59)) == false)
        {
            goto label_48;
        }
        
        label_46:
        if(WordHuntEvent.CACHE_COLLECTED_WORDS_KEY == null)
        {
                throw new NullReferenceException();
        }
        
        string val_29 = WordHuntEvent.CACHE_COLLECTED_WORDS_KEY.currentColor;
        if(val_29 == null)
        {
                throw new NullReferenceException();
        }
        
        if((WordHuntEvent.CACHE_COLLECTED_WORDS_KEY + 80) == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Color32 val_31 = WordHuntEvent.CACHE_COLLECTED_WORDS_KEY + 80.Item[val_29.ToUpper()];
        if(val_15 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_15.SetNewBackgroundAndColor(bgColor:  new UnityEngine.Color32() {r = val_31.r & 4294967295, g = val_31.r & 4294967295, b = val_31.r & 4294967295, a = val_31.r & 4294967295}, bgAlpha:  0.5f);
        if((val_15.GetComponent<UnityEngine.UI.Button>()) == 0)
        {
            goto label_68;
        }
        
        if((val_15.GetComponent<UnityEngine.UI.Button>()) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_35.m_OnClick == null)
        {
                throw new NullReferenceException();
        }
        
        val_35.m_OnClick.RemoveAllListeners();
        goto label_68;
        label_48:
        if(WordHuntEvent.CACHE_COLLECTED_WORDS_KEY == null)
        {
                throw new NullReferenceException();
        }
        
        string val_36 = WordHuntEvent.CACHE_COLLECTED_WORDS_KEY.currentColor;
        if(val_36 == null)
        {
                throw new NullReferenceException();
        }
        
        if((WordHuntEvent.CACHE_COLLECTED_WORDS_KEY + 80) == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Color32 val_38 = WordHuntEvent.CACHE_COLLECTED_WORDS_KEY + 80.Item[val_36.ToUpper()];
        if(val_15 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_15.SetNewBackgroundAndColor(bgColor:  new UnityEngine.Color32() {r = val_38.r & 4294967295, g = val_38.r & 4294967295, b = val_38.r & 4294967295, a = val_38.r & 4294967295}, bgAlpha:  1f);
        if((val_15.GetComponent<UnityEngine.UI.Button>()) == 0)
        {
            goto label_68;
        }
        
        if((val_15.GetComponent<UnityEngine.UI.Button>()) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_42.m_OnClick == null)
        {
                throw new NullReferenceException();
        }
        
        val_42.m_OnClick.RemoveAllListeners();
        goto label_68;
        label_43:
        var val_51 = 0;
        val_59 = 0;
        val_51 = val_51 + 1;
        mem2[0] = 676;
        WordHuntEvent.CACHE_COLLECTED_WORDS_KEY + 48 + 24.Dispose();
        var val_52 = val_51;
        if(val_59 != 0)
        {
            goto label_92;
        }
        
        if(val_52 != 1)
        {
                var val_43 = ((-660262368 + ((0 + 1)) << 2) == 676) ? 1 : 0;
            val_43 = ((val_52 >= 0) ? 1 : 0) & val_43;
            val_52 = val_52 - val_43;
        }
        
        val_52 = 0;
        UnityEngine.Transform val_45 = val_17.transform;
        if(val_45 == null)
        {
                throw new NullReferenceException();
        }
        
        val_45.SetParent(p:  val_51);
        val_52 = 0;
        UnityEngine.Transform val_46 = val_17.transform;
        val_51 = 0;
        UnityEngine.Vector3 val_47 = UnityEngine.Vector3.one;
        if(val_46 == null)
        {
                throw new NullReferenceException();
        }
        
        val_46.localScale = new UnityEngine.Vector3() {x = val_47.x, y = val_47.y, z = val_47.z};
        val_52 = 0;
        UnityEngine.Transform val_48 = val_17.transform;
        val_51 = 0;
        UnityEngine.Vector3 val_49 = UnityEngine.Vector3.zero;
        if(val_48 == null)
        {
                throw new NullReferenceException();
        }
        
        val_48.localPosition = new UnityEngine.Vector3() {x = val_49.x, y = val_49.y, z = val_49.z};
        goto label_77;
        label_30:
        WordHuntEvent.CACHE_COLLECTED_WORDS_KEY + 48 + 24.Dispose();
        return;
        label_92:
        val_51 = val_59;
        val_52 = 0;
        throw val_51;
    }
    public void Close()
    {
        this.gameObject.SetActive(value:  false);
    }
    public WordHuntPopup()
    {
        this.cellSizeSmall = 60f;
        this.cellSizeLarge = 70f;
    }
    private void <Init>b__22_0()
    {
        this.gameObject.SetActive(value:  false);
    }

}
