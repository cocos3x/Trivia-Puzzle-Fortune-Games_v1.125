using UnityEngine;
[Serializable]
public class WGEventButton : MonoBehaviour
{
    // Fields
    public UGUINetworkedButton event_button;
    public UnityEngine.UI.Image button_prefix;
    public UnityEngine.UI.Text event_text;
    public UnityEngine.UI.Image event_icon;
    public UnityEngine.UI.Button LeftButton;
    public UnityEngine.UI.Button RightButton;
    public UnityEngine.GameObject opposingButton;
    public UnityEngine.GameObject eventsCointainer;
    public UnityEngine.UI.Text eventsCounter;
    public float defaultIconWidth;
    public float defaultTextWidth;
    public UnityEngine.Sprite lcMenuSprite;
    public UnityEngine.Sprite ecMenuSprite;
    public UnityEngine.Sprite wwMenuSprite;
    public UnityEngine.Sprite pcMenuSprite;
    public UnityEngine.Sprite ccCvCMenuSprite;
    public UnityEngine.Sprite apMenuSprite;
    public UnityEngine.Sprite pbMenuSprite;
    public UnityEngine.Sprite pb2MenuSprite;
    public UnityEngine.Sprite lbdMenuSprite;
    public UnityEngine.Sprite lwMenuSprite;
    public UnityEngine.Sprite wordHuntMenuSprite;
    public UnityEngine.Sprite superStreakMenuSprite;
    public UnityEngine.Sprite hotStreakMenuSprite;
    public UnityEngine.Sprite vipPartyMenuSprite;
    public UnityEngine.Sprite ggMenuSprite;
    public UnityEngine.Sprite lightningLevelsMenuSprite;
    public UnityEngine.Sprite hintManiaSprite;
    public UnityEngine.Sprite onTheTrailSprite;
    public UnityEngine.Sprite keyToRichesSprite;
    public UnityEngine.Sprite bingoSprite;
    public UnityEngine.Sprite bavSprite;
    public UnityEngine.Sprite superBundleSprite;
    public UnityEngine.Sprite piggyBankRaidMenuSprite;
    public UnityEngine.Sprite seasonPassSprite;
    public UnityEngine.Sprite snakesAndLaddersMenuSprite;
    public UnityEngine.Sprite islandParadiseSprite;
    public UnityEngine.Sprite spinKingMenuSprite;
    public UnityEngine.Sprite attackMadnessMenuSprite;
    public UnityEngine.Sprite raidMadnessMenuSprite;
    public UnityEngine.Sprite forestMasterMenuSprite;
    public UnityEngine.Sprite letterBankMenuSprite;
    public UnityEngine.Sprite forestFrenzySprite;
    public UnityEngine.Sprite prgressiveIAPSprite;
    protected int CurrentEventIndex;
    protected WGEventHandler currentEventHandler;
    protected bool showingAllEventsButton;
    
    // Methods
    protected virtual void Awake()
    {
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnGameEventControllerUpdate");
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnGameEventHandlerProgress");
        NotificationCenter val_3 = NotificationCenter.DefaultCenter;
        val_3.AddObserver(observer:  this, name:  "OnLocalize");
        val_3.RemoveAllListeners();
        System.Delegate val_5 = System.Delegate.Combine(a:  this.event_button.OnConnectionClick, b:  new System.Action<System.Boolean>(object:  this, method:  typeof(WGEventButton).__il2cppRuntimeField_1A8));
        if(val_5 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
        this.event_button.OnConnectionClick = val_5;
        if(this.LeftButton == 0)
        {
                return;
        }
        
        if(this.RightButton == 0)
        {
                return;
        }
        
        this.LeftButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  typeof(WGEventButton).__il2cppRuntimeField_188));
        this.RightButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  typeof(WGEventButton).__il2cppRuntimeField_198));
        return;
        label_10:
    }
    protected virtual void PrevEvent()
    {
        float val_5 = UnityEngine.Mathf.Repeat(t:  (float)this.CurrentEventIndex - 1, length:  (float)(MonoSingleton<WordGameEventsController>.Instance.GetCurrentEventsCount) + 1);
        val_5 = (val_5 == Infinityf) ? (-(double)val_5) : ((double)val_5);
        this.CurrentEventIndex = (int)val_5;
        this.showingAllEventsButton = ((MonoSingleton<WordGameEventsController>.Instance.GetCurrentEventsCount) == (int)val_5) ? 1 : 0;
        UnityEngine.Coroutine val_9 = this.StartCoroutine(routine:  this);
    }
    protected virtual void NextEvent()
    {
        float val_5 = UnityEngine.Mathf.Repeat(t:  (float)this.CurrentEventIndex + 1, length:  (float)(MonoSingleton<WordGameEventsController>.Instance.GetCurrentEventsCount) + 1);
        val_5 = (val_5 == Infinityf) ? (-(double)val_5) : ((double)val_5);
        this.CurrentEventIndex = (int)val_5;
        this.showingAllEventsButton = ((MonoSingleton<WordGameEventsController>.Instance.GetCurrentEventsCount) == (int)val_5) ? 1 : 0;
        UnityEngine.Coroutine val_9 = this.StartCoroutine(routine:  this);
    }
    private void OnEnable()
    {
        UnityEngine.Coroutine val_1 = this.StartCoroutine(routine:  this);
    }
    protected virtual void OnClick(bool result)
    {
        var val_6;
        if(this.showingAllEventsButton != false)
        {
                GameBehavior val_1 = App.getBehavior;
            val_6 = null;
            val_6 = null;
            AmplitudePluginHelper.lastFeatureAccessPoint = 47;
            return;
        }
        
        if((this.currentEventHandler != null) && ((this.currentEventHandler & 1) == 0))
        {
                if((this.currentEventHandler & 1) == 0)
        {
            goto label_14;
        }
        
        }
        
        UnityEngine.Coroutine val_3 = this.StartCoroutine(routine:  this);
        return;
        label_14:
        MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge = false;
        bool val_5 = result;
        goto typeof(WGEventHandler).__il2cppRuntimeField_250;
    }
    private void OnGameEventControllerUpdate()
    {
        UnityEngine.Coroutine val_1 = this.StartCoroutine(routine:  this);
    }
    private void OnGameEventHandlerProgress()
    {
        UnityEngine.Coroutine val_1 = this.StartCoroutine(routine:  this);
    }
    private void OnLocalize()
    {
        UnityEngine.Coroutine val_1 = this.StartCoroutine(routine:  this);
    }
    protected void UpdateDisplay()
    {
        UnityEngine.Coroutine val_1 = this.StartCoroutine(routine:  this);
    }
    protected virtual System.Collections.IEnumerator UpdateDisplayDelayed()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGEventButton.<UpdateDisplayDelayed>d__56();
    }
    protected void SetButtonContent(WGEventHandler evtHandler)
    {
        float val_80;
        var val_81;
        float val_85;
        float val_86;
        UnityEngine.Sprite val_87;
        var val_88;
        UnityEngine.Sprite val_89;
        UnityEngine.Sprite val_90;
        UnityEngine.Sprite val_91;
        float val_93;
        float val_95;
        float val_97;
        UnityEngine.Sprite val_98;
        if(this.event_text == null)
        {
                throw new NullReferenceException();
        }
        
        val_80 = 0.8f;
        this.event_text.lineSpacing = val_80;
        if(this.event_text == null)
        {
                throw new NullReferenceException();
        }
        
        this.event_text.fontSize = 0;
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_1.<metaGameBehavior>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        string val_2 = val_1.<metaGameBehavior>k__BackingField.GetCurrentLanguage();
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.event_text == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_2.Equals(value:  "en")) != false)
        {
                val_81 = 48;
        }
        else
        {
                val_81 = 40;
        }
        
        this.event_text.resizeTextMaxSize = 40;
        UnityEngine.Color val_4 = UnityEngine.Color.white;
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.color = new UnityEngine.Color() {r = val_4.r, g = val_4.g, b = val_4.b, a = val_4.a};
        if(evtHandler == null)
        {
                throw new NullReferenceException();
        }
        
        string val_5 = (evtHandler.myEvent == 0) ? "" : evtHandler.myEvent.type;
        uint val_6 = _PrivateImplementationDetails_.ComputeStringHash(s:  val_5);
        if(val_6 > 1592546639)
        {
            goto label_14;
        }
        
        if(val_6 > 701935430)
        {
            goto label_15;
        }
        
        if(val_6 > 264778422)
        {
            goto label_16;
        }
        
        if(val_6 > 145907821)
        {
            goto label_17;
        }
        
        if(val_6 == 54006602)
        {
            goto label_18;
        }
        
        if((val_6 != 145907821) || ((System.String.op_Equality(a:  val_5, b:  "IslandParadiseSymbol")) == false))
        {
            goto label_225;
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.sprite = this.islandParadiseSprite;
        this.button_prefix.preserveAspect = true;
        this.event_text.lineSpacing = 1f;
        UnityEngine.RectTransform val_8 = this.button_prefix.rectTransform;
        val_85 = 100f;
        goto label_91;
        label_14:
        if(val_6 > (-1129030916))
        {
            goto label_26;
        }
        
        if(val_6 > (-1531801635))
        {
            goto label_27;
        }
        
        if(val_6 > (-1694107091))
        {
            goto label_28;
        }
        
        if(val_6 == (-1957254795))
        {
            goto label_29;
        }
        
        if((val_6 != (-1694107091)) || ((System.String.op_Equality(a:  val_5, b:  "PiggyBankV2")) == false))
        {
            goto label_225;
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.sprite = this.pb2MenuSprite;
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.preserveAspect = true;
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.RectTransform val_10 = this.button_prefix.rectTransform;
        UnityEngine.Vector2 val_11 = new UnityEngine.Vector2(x:  105f, y:  105f);
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        val_86 = val_11.y;
        val_10.sizeDelta = new UnityEngine.Vector2() {x = val_11.x, y = val_86};
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_12 = this.button_prefix.gameObject;
        if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
        val_12.SetActive(value:  true);
        if(this.event_text == null)
        {
                throw new NullReferenceException();
        }
        
        val_80 = 1f;
        this.event_text.lineSpacing = val_80;
        goto label_233;
        label_15:
        if(val_6 > 1188660454)
        {
            goto label_40;
        }
        
        if(val_6 > 999457290)
        {
            goto label_41;
        }
        
        if(val_6 == 958660756)
        {
            goto label_42;
        }
        
        if((val_6 != 999457290) || ((System.String.op_Equality(a:  val_5, b:  "AttackMadness")) == false))
        {
            goto label_225;
        }
        
        val_87 = this.attackMadnessMenuSprite;
        goto label_46;
        label_26:
        if(val_6 > (-1019895860))
        {
            goto label_47;
        }
        
        if(val_6 > (-1050565114))
        {
            goto label_48;
        }
        
        if(val_6 == (-1101875113))
        {
            goto label_49;
        }
        
        if((val_6 != (-1050565114)) || ((System.String.op_Equality(a:  val_5, b:  "ForestMaster")) == false))
        {
            goto label_225;
        }
        
        this.button_prefix.sprite = this.forestMasterMenuSprite;
        this.button_prefix.preserveAspect = true;
        UnityEngine.Vector2 val_16 = new UnityEngine.Vector2(x:  115f, y:  115f);
        val_80 = val_16.x;
        val_86 = val_16.y;
        this.button_prefix.rectTransform.sizeDelta = new UnityEngine.Vector2() {x = val_80, y = val_86};
        this.button_prefix.gameObject.SetActive(value:  true);
        if(this.event_text != null)
        {
            goto label_58;
        }
        
        label_16:
        if(val_6 > 655166938)
        {
            goto label_60;
        }
        
        if(val_6 == 386644468)
        {
            goto label_61;
        }
        
        if((val_6 != 655166938) || ((System.String.op_Equality(a:  val_5, b:  "SpinKing")) == false))
        {
            goto label_225;
        }
        
        this.button_prefix.sprite = this.spinKingMenuSprite;
        this.button_prefix.preserveAspect = true;
        UnityEngine.Vector2 val_20 = new UnityEngine.Vector2(x:  95f, y:  95f);
        val_80 = val_20.x;
        val_86 = val_20.y;
        this.button_prefix.rectTransform.sizeDelta = new UnityEngine.Vector2() {x = val_80, y = val_86};
        this.button_prefix.gameObject.SetActive(value:  true);
        val_88 = 65;
        goto label_216;
        label_27:
        if(val_6 > (-1430120902))
        {
            goto label_72;
        }
        
        if(val_6 == (-1449662652))
        {
            goto label_73;
        }
        
        if((val_6 != (-1430120902)) || ((System.String.op_Equality(a:  val_5, b:  "HintMania")) == false))
        {
            goto label_225;
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        val_89 = this.hintManiaSprite;
        goto label_185;
        label_40:
        if(val_6 > 1399814793)
        {
            goto label_78;
        }
        
        if(val_6 == 1314484049)
        {
            goto label_79;
        }
        
        if((val_6 != 1399814793) || ((System.String.op_Equality(a:  val_5, b:  "PiggyBank")) == false))
        {
            goto label_225;
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        val_89 = this.pbMenuSprite;
        goto label_185;
        label_47:
        if(val_6 > (-623396922))
        {
            goto label_84;
        }
        
        if(val_6 == (-763592254))
        {
            goto label_85;
        }
        
        if((val_6 != (-623396922)) || ((System.String.op_Equality(a:  val_5, b:  "RaidMadness")) == false))
        {
            goto label_225;
        }
        
        val_87 = this.raidMadnessMenuSprite;
        label_46:
        this.button_prefix.sprite = val_87;
        this.button_prefix.preserveAspect = true;
        UnityEngine.RectTransform val_25 = this.button_prefix.rectTransform;
        val_85 = 90f;
        goto label_91;
        label_17:
        if(val_6 == 231953039)
        {
            goto label_92;
        }
        
        if((val_6 != 264778422) || ((System.String.op_Equality(a:  val_5, b:  "ExtraChapterRewards")) == false))
        {
            goto label_225;
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        val_89 = this.ecMenuSprite;
        goto label_185;
        label_28:
        if(val_6 == (-1630781543))
        {
            goto label_97;
        }
        
        if((val_6 != (-1531801635)) || ((System.String.op_Equality(a:  val_5, b:  "PiggyBankRaid")) == false))
        {
            goto label_225;
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        val_90 = this.piggyBankRaidMenuSprite;
        goto label_141;
        label_41:
        if(val_6 == 1054264077)
        {
            goto label_102;
        }
        
        if((val_6 != 1188660454) || ((System.String.op_Equality(a:  val_5, b:  "HotStreak")) == false))
        {
            goto label_225;
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        val_90 = this.hotStreakMenuSprite;
        goto label_141;
        label_48:
        if(val_6 == (-1043654426))
        {
            goto label_107;
        }
        
        if((val_6 != (-1019895860)) || ((System.String.op_Equality(a:  val_5, b:  "Leaderboard")) == false))
        {
            goto label_225;
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.sprite = this.lbdMenuSprite;
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_30 = this.button_prefix.gameObject;
        if(val_30 == null)
        {
                throw new NullReferenceException();
        }
        
        val_30.SetActive(value:  true);
        if(this.event_text == null)
        {
                throw new NullReferenceException();
        }
        
        this.event_text.fontSize = 48;
        goto label_233;
        label_60:
        if(val_6 == 697097638)
        {
            goto label_116;
        }
        
        if((val_6 != 701935430) || ((System.String.op_Equality(a:  val_5, b:  "LevelChallenge")) == false))
        {
            goto label_225;
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        val_89 = this.lcMenuSprite;
        goto label_185;
        label_72:
        if(val_6 == (-1392364358))
        {
            goto label_121;
        }
        
        if((val_6 != (-1129030916)) || ((System.String.op_Equality(a:  val_5, b:  "WordHunt")) == false))
        {
            goto label_225;
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        val_90 = this.wordHuntMenuSprite;
        goto label_141;
        label_78:
        if(val_6 == 1537055809)
        {
            goto label_126;
        }
        
        if((val_6 != 1592546639) || ((System.String.op_Equality(a:  val_5, b:  "BuyAVowel")) == false))
        {
            goto label_225;
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        val_91 = this.bavSprite;
        goto label_166;
        label_84:
        if(val_6 == (-530341297))
        {
            goto label_131;
        }
        
        if(val_6 == (-84738646))
        {
            goto label_132;
        }
        
        if((val_6 != (-53406543)) || ((System.String.op_Equality(a:  val_5, b:  "CrownClashCvC")) == false))
        {
            goto label_225;
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.sprite = this.ccCvCMenuSprite;
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.preserveAspect = true;
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.RectTransform val_35 = this.button_prefix.rectTransform;
        val_93 = 137f;
        goto label_209;
        label_18:
        if((System.String.op_Equality(a:  val_5, b:  "LightningWords")) == false)
        {
            goto label_225;
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        val_90 = this.lwMenuSprite;
        goto label_141;
        label_29:
        if((System.String.op_Equality(a:  val_5, b:  "CrownClashPvP")) == false)
        {
            goto label_225;
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        val_89 = this.apMenuSprite;
        goto label_185;
        label_42:
        if((System.String.op_Equality(a:  val_5, b:  "VipParty")) == false)
        {
            goto label_225;
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.sprite = this.vipPartyMenuSprite;
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.preserveAspect = true;
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.RectTransform val_39 = this.button_prefix.rectTransform;
        val_95 = 105f;
        goto label_149;
        label_49:
        if((System.String.op_Equality(a:  val_5, b:  "GoldenGala")) == false)
        {
            goto label_225;
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.sprite = this.ggMenuSprite;
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.preserveAspect = true;
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.RectTransform val_41 = this.button_prefix.rectTransform;
        val_97 = 125f;
        goto label_154;
        label_61:
        if((System.String.op_Equality(a:  val_5, b:  "WordBingo")) == false)
        {
            goto label_225;
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.sprite = this.bingoSprite;
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.preserveAspect = true;
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.RectTransform val_43 = this.button_prefix.rectTransform;
        val_95 = 90f;
        label_149:
        UnityEngine.Vector2 val_44 = new UnityEngine.Vector2(x:  val_95, y:  val_95);
        if(val_43 == null)
        {
                throw new NullReferenceException();
        }
        
        val_80 = val_44.x;
        val_86 = val_44.y;
        val_43.sizeDelta = new UnityEngine.Vector2() {x = val_80, y = val_86};
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_45 = this.button_prefix.gameObject;
        if(val_45 == null)
        {
                throw new NullReferenceException();
        }
        
        val_45.SetActive(value:  true);
        if(this.event_text == null)
        {
                throw new NullReferenceException();
        }
        
        val_88 = 72;
        goto label_216;
        label_73:
        if((System.String.op_Equality(a:  val_5, b:  "SuperBundle")) == false)
        {
            goto label_225;
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        val_91 = this.superBundleSprite;
        goto label_166;
        label_79:
        if((System.String.op_Equality(a:  val_5, b:  "SeasonPass")) == false)
        {
            goto label_225;
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.sprite = this.seasonPassSprite;
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.preserveAspect = true;
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.RectTransform val_48 = this.button_prefix.rectTransform;
        UnityEngine.Vector2 val_49 = new UnityEngine.Vector2(x:  110f, y:  110f);
        if(val_48 == null)
        {
                throw new NullReferenceException();
        }
        
        val_80 = val_49.x;
        val_86 = val_49.y;
        val_48.sizeDelta = new UnityEngine.Vector2() {x = val_80, y = val_86};
        if(this.event_text == null)
        {
                throw new NullReferenceException();
        }
        
        this.event_text.resizeTextMaxSize = 42;
        goto label_196;
        label_85:
        if((System.String.op_Equality(a:  val_5, b:  "SnakesAndLadders")) == false)
        {
            goto label_225;
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.sprite = this.snakesAndLaddersMenuSprite;
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.preserveAspect = true;
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.RectTransform val_51 = this.button_prefix.rectTransform;
        UnityEngine.Vector2 val_52 = new UnityEngine.Vector2(x:  95f, y:  95f);
        if(val_51 == null)
        {
                throw new NullReferenceException();
        }
        
        val_80 = val_52.x;
        val_86 = val_52.y;
        val_51.sizeDelta = new UnityEngine.Vector2() {x = val_80, y = val_86};
        goto label_179;
        label_92:
        if((System.String.op_Equality(a:  val_5, b:  "LetterBank")) == false)
        {
            goto label_225;
        }
        
        val_98 = this.letterBankMenuSprite;
        goto label_182;
        label_97:
        if((System.String.op_Equality(a:  val_5, b:  "PuzzleCollection")) == false)
        {
            goto label_225;
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        val_89 = this.pcMenuSprite;
        goto label_185;
        label_102:
        if((System.String.op_Equality(a:  val_5, b:  "ProgressiveIapSale")) == false)
        {
            goto label_225;
        }
        
        this.button_prefix.sprite = this.prgressiveIAPSprite;
        UnityEngine.Color val_56 = MetricSystem.HexToColor(hex:  "1BF7D5");
        this.button_prefix.color = new UnityEngine.Color() {r = val_56.r, g = val_56.g, b = val_56.b, a = val_56.a};
        if(this.button_prefix != null)
        {
            goto label_191;
        }
        
        label_107:
        if((System.String.op_Equality(a:  val_5, b:  "SuperStreak")) == false)
        {
            goto label_225;
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        val_89 = this.superStreakMenuSprite;
        label_185:
        this.button_prefix.sprite = val_89;
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        goto label_196;
        label_116:
        if((System.String.op_Equality(a:  val_5, b:  "ForestFrenzy")) == false)
        {
            goto label_225;
        }
        
        val_98 = this.forestFrenzySprite;
        label_182:
        this.button_prefix.sprite = val_98;
        label_191:
        this.button_prefix.preserveAspect = true;
        val_85 = 105f;
        label_91:
        UnityEngine.Vector2 val_60 = new UnityEngine.Vector2(x:  val_85, y:  val_85);
        val_80 = val_60.x;
        val_86 = val_60.y;
        this.button_prefix.rectTransform.sizeDelta = new UnityEngine.Vector2() {x = val_80, y = val_86};
        if(this.button_prefix.gameObject != null)
        {
            goto label_203;
        }
        
        label_121:
        if((System.String.op_Equality(a:  val_5, b:  "WildWordWeekend")) == false)
        {
            goto label_225;
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        val_91 = this.wwMenuSprite;
        label_166:
        this.button_prefix.sprite = val_91;
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.preserveAspect = true;
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.RectTransform val_63 = this.button_prefix.rectTransform;
        val_93 = 100f;
        goto label_209;
        label_126:
        if((System.String.op_Equality(a:  val_5, b:  "OnTheTrail")) == false)
        {
            goto label_225;
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.sprite = this.onTheTrailSprite;
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        label_179:
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_65 = this.button_prefix.gameObject;
        if(val_65 == null)
        {
                throw new NullReferenceException();
        }
        
        val_65.SetActive(value:  true);
        if(this.event_text == null)
        {
                throw new NullReferenceException();
        }
        
        label_58:
        val_88 = 42;
        goto label_216;
        label_131:
        if((System.String.op_Equality(a:  val_5, b:  "KeyToRiches")) == false)
        {
            goto label_225;
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        val_90 = this.keyToRichesSprite;
        label_141:
        this.button_prefix.sprite = val_90;
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.preserveAspect = true;
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.RectTransform val_67 = this.button_prefix.rectTransform;
        val_93 = 105f;
        label_209:
        UnityEngine.Vector2 val_68 = new UnityEngine.Vector2(x:  val_93, y:  val_93);
        if(val_67 == null)
        {
                throw new NullReferenceException();
        }
        
        val_80 = val_68.x;
        val_86 = val_68.y;
        val_67.sizeDelta = new UnityEngine.Vector2() {x = val_80, y = val_86};
        label_196:
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_69 = this.button_prefix.gameObject;
        if(val_69 == null)
        {
                throw new NullReferenceException();
        }
        
        label_203:
        val_69.SetActive(value:  true);
        goto label_233;
        label_132:
        if((System.String.op_Equality(a:  val_5, b:  "LightningLevels")) == false)
        {
            goto label_225;
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        this.button_prefix.sprite = this.lightningLevelsMenuSprite;
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.RectTransform val_71 = this.button_prefix.rectTransform;
        val_97 = 90f;
        label_154:
        UnityEngine.Vector2 val_72 = new UnityEngine.Vector2(x:  val_97, y:  val_97);
        if(val_71 == null)
        {
                throw new NullReferenceException();
        }
        
        val_80 = val_72.x;
        val_86 = val_72.y;
        val_71.sizeDelta = new UnityEngine.Vector2() {x = val_80, y = val_86};
        if(this.button_prefix == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_73 = this.button_prefix.gameObject;
        if(val_73 == null)
        {
                throw new NullReferenceException();
        }
        
        val_73.SetActive(value:  true);
        if(this.event_text == null)
        {
                throw new NullReferenceException();
        }
        
        val_88 = 52;
        label_216:
        this.event_text.resizeTextMaxSize = 52;
        goto label_233;
        label_225:
        UnityEngine.Debug.LogError(message:  "Default Event Type When Setting WGEventButton", context:  this);
        label_233:
        UnityEngine.Vector2 val_75 = this.event_text.rectTransform.sizeDelta;
        UnityEngine.Vector2 val_77 = this.button_prefix.rectTransform.sizeDelta;
        float val_80 = this.defaultIconWidth;
        val_80 = this.defaultTextWidth + val_80;
        val_80 = val_80 - val_77.x;
        UnityEngine.Vector2 val_79 = new UnityEngine.Vector2(x:  val_80, y:  val_75.y);
        this.event_text.rectTransform.sizeDelta = new UnityEngine.Vector2() {x = val_79.x, y = val_79.y};
    }
    public WGEventButton()
    {
        this.defaultIconWidth = 105f;
        this.defaultTextWidth = 400f;
    }

}
