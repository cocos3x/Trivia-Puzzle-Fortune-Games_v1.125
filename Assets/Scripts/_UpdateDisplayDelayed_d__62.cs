using UnityEngine;
private sealed class WGEventButton_Game.<UpdateDisplayDelayed>d__62 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGEventButton_Game <>4__this;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public WGEventButton_Game.<UpdateDisplayDelayed>d__62(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        object val_102;
        int val_103;
        UnityEngine.Sprite val_104;
        UnityEngine.Sprite val_105;
        UnityEngine.Sprite val_106;
        var val_107;
        UnityEngine.Sprite val_108;
        var val_109;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        UnityEngine.WaitForSeconds val_1 = null;
        val_102 = val_1;
        val_1 = new UnityEngine.WaitForSeconds(seconds:  0.1f);
        val_103 = 1;
        this.<>2__current = val_102;
        this.<>1__state = val_103;
        return (bool)val_103;
        label_1:
        val_102 = this.<>4__this;
        this.<>1__state = 0;
        if(val_102 == null)
        {
                throw new NullReferenceException();
        }
        
        if((this.<>4__this.timerCoroutine) != null)
        {
                val_102.StopCoroutine(routine:  this.<>4__this.timerCoroutine);
            this.<>4__this.timerCoroutine = 0;
        }
        
        if(WordGameEventsController.EventsEnabled == false)
        {
            goto label_15;
        }
        
        WordGameEventsController val_3 = MonoSingleton<WordGameEventsController>.Instance;
        WGDailyChallengeManager val_4 = MonoSingleton<WGDailyChallengeManager>.Instance;
        if(val_4 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_3 == null)
        {
                throw new NullReferenceException();
        }
        
        WGEventHandler val_7 = val_3.GetGameSceneOrderedEventHandler(dailyChallengeState:  val_4.PlayingChallenge);
        this.<>4__this.currentEventHandler = val_7;
        if(val_7 == null)
        {
            goto label_15;
        }
        
        if((this.<>4__this.event_text) == null)
        {
                throw new NullReferenceException();
        }
        
        this.<>4__this.event_text.resizeTextForBestFit = true;
        if((this.<>4__this + 64) == 0)
        {
                throw new NullReferenceException();
        }
        
        this.<>4__this + 64.fontSize = 44;
        if((this.<>4__this + 64) == 0)
        {
                throw new NullReferenceException();
        }
        
        this.<>4__this + 64.resizeTextMaxSize = 48;
        if((this.<>4__this + 64) == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_8 = this.<>4__this + 64.gameObject;
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        val_8.SetActive(value:  false);
        if((this.<>4__this.event_text_bg) != 0)
        {
                if((this.<>4__this.event_text_bg) == null)
        {
                throw new NullReferenceException();
        }
        
            this.<>4__this.event_text_bg.SetActive(value:  false);
        }
        
        if((this.<>4__this + 64) == 0)
        {
                throw new NullReferenceException();
        }
        
        this.<>4__this + 64.lineSpacing = 0.7f;
        if((this.<>4__this.event_button) == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_10 = this.<>4__this.event_button.gameObject;
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        val_10.SetActive(value:  true);
        if((this.<>4__this.opposingButton) != 0)
        {
                if((this.<>4__this.opposingButton) == null)
        {
                throw new NullReferenceException();
        }
        
            this.<>4__this.opposingButton.SetActive(value:  false);
        }
        
        if((this.<>4__this.event_icon) == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_12 = this.<>4__this.event_icon.transform;
        UnityEngine.Vector3 val_13 = UnityEngine.Vector3.zero;
        if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
        val_12.localPosition = new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z};
        if((this.<>4__this.event_middle_root) != 0)
        {
                if((this.<>4__this.event_middle_root) == null)
        {
                throw new NullReferenceException();
        }
        
            UnityEngine.GameObject val_15 = this.<>4__this.event_middle_root.gameObject;
            if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
            val_15.SetActive(value:  false);
        }
        
        UnityEngine.Color val_16 = UnityEngine.Color.white;
        if((this.<>4__this + 80) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((this.<>4__this.currentEventHandler) == null)
        {
                throw new NullReferenceException();
        }
        
        string val_17 = ((this.<>4__this.currentEventHandler.myEvent) == 0) ? "" : this.<>4__this.currentEventHandler.myEvent.type;
        uint val_18 = _PrivateImplementationDetails_.ComputeStringHash(s:  val_17);
        if(val_18 > 1537055809)
        {
            goto label_44;
        }
        
        if(val_18 > 697097638)
        {
            goto label_45;
        }
        
        if(val_18 > 231953039)
        {
            goto label_46;
        }
        
        if(val_18 == 54006602)
        {
            goto label_47;
        }
        
        if(val_18 == 145907821)
        {
            goto label_48;
        }
        
        if((val_18 != 231953039) || ((System.String.op_Equality(a:  val_17, b:  "LetterBank")) == false))
        {
            goto label_287;
        }
        
        this.<>4__this + 80.sprite = this.<>4__this.letterBankGameSprite;
        this.<>4__this.event_icon.preserveAspect = true;
        this.<>4__this + 80.rectTransform.sizeDelta = new UnityEngine.Vector2() {x = this.<>4__this.icon_size, y = val_16.g};
        this.<>4__this.event_icon.gameObject.SetActive(value:  true);
        this.<>4__this + 64.fontSize = 40;
        goto label_141;
        label_15:
        if((this.<>4__this.event_button) == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_22 = this.<>4__this.event_button.gameObject;
        if(val_22 == null)
        {
                throw new NullReferenceException();
        }
        
        val_22.SetActive(value:  false);
        if(NotificationCenter.DefaultCenter != null)
        {
            goto label_63;
        }
        
        throw new NullReferenceException();
        label_44:
        if(val_18 > (-1392364358))
        {
            goto label_65;
        }
        
        if(val_18 > (-1630781543))
        {
            goto label_66;
        }
        
        if(val_18 == (-1957254795))
        {
            goto label_67;
        }
        
        if(val_18 == (-1694107091))
        {
            goto label_68;
        }
        
        if((val_18 != (-1630781543)) || ((System.String.op_Equality(a:  val_17, b:  "PuzzleCollection")) == false))
        {
            goto label_287;
        }
        
        if((this.<>4__this + 80) == 0)
        {
                throw new NullReferenceException();
        }
        
        val_104 = this.<>4__this.pcGameSprite;
        goto label_189;
        label_45:
        if(val_18 > 1054264077)
        {
            goto label_73;
        }
        
        if(val_18 == 701935430)
        {
            goto label_74;
        }
        
        if(val_18 == 958660756)
        {
            goto label_75;
        }
        
        if((val_18 != 1054264077) || ((System.String.op_Equality(a:  val_17, b:  "ProgressiveIapSale")) == false))
        {
            goto label_287;
        }
        
        this.<>4__this + 80.sprite = this.<>4__this.prgressiveIAPSprite;
        UnityEngine.Color val_26 = MetricSystem.HexToColor(hex:  "1BF7D5");
        this.<>4__this.event_icon.color = new UnityEngine.Color() {r = val_26.r, g = val_26.g, b = val_26.b, a = val_26.a};
        this.<>4__this + 80.preserveAspect = true;
        UnityEngine.Vector2 val_28 = new UnityEngine.Vector2(x:  105f, y:  105f);
        this.<>4__this + 80.rectTransform.sizeDelta = new UnityEngine.Vector2() {x = val_28.x, y = val_28.y};
        if((this.<>4__this + 80) != 0)
        {
            goto label_174;
        }
        
        label_65:
        if(val_18 > (-1019895860))
        {
            goto label_87;
        }
        
        if(val_18 > (-1101875113))
        {
            goto label_88;
        }
        
        if(val_18 == (-1129030916))
        {
            goto label_89;
        }
        
        if((val_18 != (-1101875113)) || ((System.String.op_Equality(a:  val_17, b:  "GoldenGala")) == false))
        {
            goto label_287;
        }
        
        if((this.<>4__this + 80) == 0)
        {
                throw new NullReferenceException();
        }
        
        val_105 = this.<>4__this.ggGameSprite;
        goto label_192;
        label_46:
        if(val_18 > 386644468)
        {
            goto label_94;
        }
        
        if(val_18 == 264778422)
        {
            goto label_95;
        }
        
        if((val_18 != 386644468) || ((System.String.op_Equality(a:  val_17, b:  "WordBingo")) == false))
        {
            goto label_287;
        }
        
        if((this.<>4__this + 80) == 0)
        {
                throw new NullReferenceException();
        }
        
        val_106 = this.<>4__this.bingoSprite;
        goto label_272;
        label_66:
        if(val_18 > (-1449662652))
        {
            goto label_100;
        }
        
        if(val_18 == (-1531801635))
        {
            goto label_101;
        }
        
        if((val_18 != (-1449662652)) || ((System.String.op_Equality(a:  val_17, b:  "SuperBundle")) == false))
        {
            goto label_287;
        }
        
        if((this.<>4__this + 80) == 0)
        {
                throw new NullReferenceException();
        }
        
        this.<>4__this + 80.sprite = this.<>4__this.superBundleSprite;
        if((this.<>4__this.event_icon) == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.RectTransform val_32 = this.<>4__this.event_icon.rectTransform;
        if(val_32 == null)
        {
                throw new NullReferenceException();
        }
        
        val_32.sizeDelta = new UnityEngine.Vector2() {x = this.<>4__this.icon_size, y = val_16.g};
        if((this.<>4__this.event_text) == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_33 = this.<>4__this.event_text.gameObject;
        if(val_33 == null)
        {
                throw new NullReferenceException();
        }
        
        val_33.SetActive(value:  true);
        this.<>4__this.timerCoroutine = val_102.StartCoroutine(routine:  val_102.UpdateButtonTextTimer(seconds:  5));
        goto label_287;
        label_73:
        if(val_18 > 1314484049)
        {
            goto label_110;
        }
        
        if(val_18 == 1188660454)
        {
            goto label_111;
        }
        
        if((val_18 != 1314484049) || ((System.String.op_Equality(a:  val_17, b:  "SeasonPass")) == false))
        {
            goto label_287;
        }
        
        if((this.<>4__this + 80) == 0)
        {
                throw new NullReferenceException();
        }
        
        this.<>4__this + 80.sprite = this.<>4__this.seasonPassSprite;
        if((this.<>4__this.event_icon) == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.RectTransform val_37 = this.<>4__this.event_icon.rectTransform;
        UnityEngine.Vector2 val_38 = new UnityEngine.Vector2(x:  126.3f, y:  126.3f);
        if(val_37 == null)
        {
                throw new NullReferenceException();
        }
        
        val_37.sizeDelta = new UnityEngine.Vector2() {x = val_38.x, y = val_38.y};
        goto label_212;
        label_87:
        if(val_18 > (-530341297))
        {
            goto label_118;
        }
        
        if(val_18 == (-763592254))
        {
            goto label_119;
        }
        
        if((val_18 != (-530341297)) || ((System.String.op_Equality(a:  val_17, b:  "KeyToRiches")) == false))
        {
            goto label_287;
        }
        
        if((this.<>4__this + 80) == 0)
        {
                throw new NullReferenceException();
        }
        
        val_106 = this.<>4__this.keyToRichesSprite;
        goto label_272;
        label_88:
        if(val_18 == (-1043654426))
        {
            goto label_124;
        }
        
        if((val_18 != (-1019895860)) || ((System.String.op_Equality(a:  val_17, b:  "Leaderboard")) == false))
        {
            goto label_287;
        }
        
        if((this.<>4__this + 80) == 0)
        {
                throw new NullReferenceException();
        }
        
        val_104 = this.<>4__this.lbdGameSprite;
        goto label_189;
        label_94:
        if(val_18 == 655166938)
        {
            goto label_129;
        }
        
        if((val_18 != 697097638) || ((System.String.op_Equality(a:  val_17, b:  "ForestFrenzy")) == false))
        {
            goto label_287;
        }
        
        this.<>4__this + 80.sprite = this.<>4__this.forestFrenzySprite;
        this.<>4__this.event_icon.preserveAspect = true;
        this.<>4__this + 80.rectTransform.sizeDelta = new UnityEngine.Vector2() {x = this.<>4__this.icon_size, y = val_16.g};
        this.<>4__this.event_icon.gameObject.SetActive(value:  true);
        this.<>4__this + 64.fontSize = 40;
        if((this.<>4__this.event_text_bg) != 0)
        {
                this.<>4__this.event_text_bg.SetActive(value:  false);
        }
        
        label_141:
        if((this.<>4__this + 64.gameObject) != null)
        {
            goto label_144;
        }
        
        label_100:
        if(val_18 == (-1430120902))
        {
            goto label_146;
        }
        
        if((val_18 != (-1392364358)) || ((System.String.op_Equality(a:  val_17, b:  "WildWordWeekend")) == false))
        {
            goto label_287;
        }
        
        if((this.<>4__this + 80) == 0)
        {
                throw new NullReferenceException();
        }
        
        val_104 = this.<>4__this.wwGameSprite;
        goto label_189;
        label_110:
        if(val_18 == 1399814793)
        {
            goto label_151;
        }
        
        if((val_18 != 1537055809) || ((System.String.op_Equality(a:  val_17, b:  "OnTheTrail")) == false))
        {
            goto label_287;
        }
        
        if((this.<>4__this + 80) == 0)
        {
                throw new NullReferenceException();
        }
        
        val_106 = this.<>4__this.onTheTrailGameSprite;
        goto label_272;
        label_118:
        if(val_18 == (-84738646))
        {
            goto label_156;
        }
        
        if((val_18 != (-53406543)) || ((System.String.op_Equality(a:  val_17, b:  "CrownClashCvC")) == false))
        {
            goto label_287;
        }
        
        if((this.<>4__this + 80) == 0)
        {
                throw new NullReferenceException();
        }
        
        this.<>4__this + 80.sprite = this.<>4__this.ccCvCGameSprite;
        if((this.<>4__this.event_icon) == null)
        {
                throw new NullReferenceException();
        }
        
        if((this.<>4__this + 80) == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.RectTransform val_49 = this.<>4__this + 80.rectTransform;
        if(val_49 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Vector3 val_50 = val_49.localPosition;
        UnityEngine.Vector3 val_51 = UnityEngine.Vector3.up;
        UnityEngine.Vector3 val_52 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_51.x, y = val_51.y, z = val_51.z}, d:  10f);
        UnityEngine.Vector3 val_53 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_50.x, y = val_50.y, z = val_50.z}, b:  new UnityEngine.Vector3() {x = val_52.x, y = val_52.y, z = val_52.z});
        val_49.localPosition = new UnityEngine.Vector3() {x = val_53.x, y = val_53.y, z = val_53.z};
        goto label_212;
        label_47:
        if((System.String.op_Equality(a:  val_17, b:  "LightningWords")) == false)
        {
            goto label_287;
        }
        
        if((this.<>4__this + 80) == 0)
        {
                throw new NullReferenceException();
        }
        
        val_106 = this.<>4__this.lwGameSprite;
        goto label_272;
        label_48:
        if((System.String.op_Equality(a:  val_17, b:  "IslandParadiseSymbol")) == false)
        {
            goto label_287;
        }
        
        this.<>4__this.button_prefix.sprite = this.<>4__this.islandParadiseSprite;
        this.<>4__this.button_prefix.preserveAspect = true;
        UnityEngine.Vector2 val_57 = new UnityEngine.Vector2(x:  105f, y:  105f);
        this.<>4__this.button_prefix.rectTransform.sizeDelta = new UnityEngine.Vector2() {x = val_57.x, y = val_57.y};
        if((this.<>4__this.button_prefix) != null)
        {
            goto label_174;
        }
        
        label_67:
        if((System.String.op_Equality(a:  val_17, b:  "CrownClashPvP")) == false)
        {
            goto label_287;
        }
        
        if((this.<>4__this + 80) == 0)
        {
                throw new NullReferenceException();
        }
        
        val_106 = this.<>4__this.apGameSprite;
        goto label_272;
        label_68:
        if((System.String.op_Equality(a:  val_17, b:  "PiggyBankV2")) == false)
        {
            goto label_287;
        }
        
        if((this.<>4__this + 80) == 0)
        {
                throw new NullReferenceException();
        }
        
        this.<>4__this + 80.sprite = this.<>4__this.pb2GameSprite;
        if((this.<>4__this.event_icon) == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.RectTransform val_60 = this.<>4__this.event_icon.rectTransform;
        UnityEngine.Vector2 val_61 = new UnityEngine.Vector2(x:  140f, y:  140f);
        if(val_60 == null)
        {
                throw new NullReferenceException();
        }
        
        val_60.sizeDelta = new UnityEngine.Vector2() {x = val_61.x, y = val_61.y};
        if((this.<>4__this + 64) == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_62 = this.<>4__this + 64.gameObject;
        if(val_62 == null)
        {
                throw new NullReferenceException();
        }
        
        val_62.SetActive(value:  true);
        if((this.<>4__this + 64) == 0)
        {
                throw new NullReferenceException();
        }
        
        this.<>4__this + 64.lineSpacing = 0.65f;
        goto label_287;
        label_74:
        if((System.String.op_Equality(a:  val_17, b:  "LevelChallenge")) == false)
        {
            goto label_287;
        }
        
        if((this.<>4__this + 80) == 0)
        {
                throw new NullReferenceException();
        }
        
        val_104 = this.<>4__this.lcGameSprite;
        goto label_189;
        label_75:
        if((System.String.op_Equality(a:  val_17, b:  "VipParty")) == false)
        {
            goto label_287;
        }
        
        if((this.<>4__this + 80) == 0)
        {
                throw new NullReferenceException();
        }
        
        val_105 = this.<>4__this.vipPartyGameSprite;
        goto label_192;
        label_89:
        if((System.String.op_Equality(a:  val_17, b:  "WordHunt")) == false)
        {
            goto label_287;
        }
        
        if((this.<>4__this + 80) == 0)
        {
                throw new NullReferenceException();
        }
        
        this.<>4__this + 80.sprite = this.<>4__this.wordHuntGameSprite;
        if((this.<>4__this.event_text) == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_66 = this.<>4__this.event_text.gameObject;
        if(val_66 == null)
        {
                throw new NullReferenceException();
        }
        
        val_66.SetActive(value:  true);
        goto label_197;
        label_95:
        if((System.String.op_Equality(a:  val_17, b:  "ExtraChapterRewards")) == false)
        {
            goto label_287;
        }
        
        if((this.<>4__this + 80) == 0)
        {
                throw new NullReferenceException();
        }
        
        val_104 = this.<>4__this.ecGameSprite;
        label_189:
        this.<>4__this + 80.sprite = val_104;
        if((this.<>4__this.event_icon) == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.RectTransform val_68 = this.<>4__this.event_icon.rectTransform;
        if(val_68 == null)
        {
                throw new NullReferenceException();
        }
        
        val_68.sizeDelta = new UnityEngine.Vector2() {x = this.<>4__this.icon_size, y = val_16.g};
        if((this.<>4__this.event_text) != null)
        {
            goto label_202;
        }
        
        throw new NullReferenceException();
        label_101:
        if((System.String.op_Equality(a:  val_17, b:  "PiggyBankRaid")) == false)
        {
            goto label_287;
        }
        
        if((this.<>4__this + 80) == 0)
        {
                throw new NullReferenceException();
        }
        
        this.<>4__this + 80.sprite = this.<>4__this.piggyBankRaidGameSprite;
        if((this.<>4__this.event_icon) == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.RectTransform val_70 = this.<>4__this.event_icon.rectTransform;
        UnityEngine.Vector2 val_71 = new UnityEngine.Vector2(x:  112f, y:  112f);
        if(val_70 == null)
        {
                throw new NullReferenceException();
        }
        
        val_70.sizeDelta = new UnityEngine.Vector2() {x = val_71.x, y = val_71.y};
        if((this.<>4__this + 80) == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.RectTransform val_72 = this.<>4__this + 80.rectTransform;
        UnityEngine.Vector2 val_73 = new UnityEngine.Vector2(x:  -7f, y:  -3f);
        if(val_72 == null)
        {
                throw new NullReferenceException();
        }
        
        val_72.anchoredPosition = new UnityEngine.Vector2() {x = val_73.x, y = val_73.y};
        if((this.<>4__this + 64) == 0)
        {
                throw new NullReferenceException();
        }
        
        this.<>4__this + 64.resizeTextForBestFit = false;
        if((this.<>4__this + 64) == 0)
        {
                throw new NullReferenceException();
        }
        
        this.<>4__this + 64.fontSize = 40;
        goto label_212;
        label_111:
        if((System.String.op_Equality(a:  val_17, b:  "HotStreak")) == false)
        {
            goto label_287;
        }
        
        if((this.<>4__this + 64) == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_75 = this.<>4__this + 64.gameObject;
        if(val_75 == null)
        {
                throw new NullReferenceException();
        }
        
        val_75.SetActive(value:  true);
        if(HotStreakEventHandler.HOT_STREAK_ID == null)
        {
                throw new NullReferenceException();
        }
        
        val_107 = mem[this.<>4__this + 80];
        val_107 = this.<>4__this + 80;
        if(HotStreakEventHandler.HOT_STREAK_ID.CanEngageWithEvent() == false)
        {
            goto label_218;
        }
        
        if(val_107 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_108 = this.<>4__this.hotStreakGameSprite;
        goto label_284;
        label_119:
        if((System.String.op_Equality(a:  val_17, b:  "SnakesAndLadders")) == false)
        {
            goto label_287;
        }
        
        if((this.<>4__this + 80) == 0)
        {
                throw new NullReferenceException();
        }
        
        this.<>4__this + 80.sprite = this.<>4__this.snakesAndLaddersGameSprite;
        if((this.<>4__this.event_icon) == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.RectTransform val_78 = this.<>4__this.event_icon.rectTransform;
        UnityEngine.Vector2 val_79 = new UnityEngine.Vector2(x:  95f, y:  95f);
        if(val_78 == null)
        {
                throw new NullReferenceException();
        }
        
        val_78.sizeDelta = new UnityEngine.Vector2() {x = val_79.x, y = val_79.y};
        if((this.<>4__this + 80) == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.RectTransform val_80 = this.<>4__this + 80.rectTransform;
        UnityEngine.Vector2 val_81 = new UnityEngine.Vector2(x:  0f, y:  4f);
        if(val_80 == null)
        {
                throw new NullReferenceException();
        }
        
        val_80.anchoredPosition = new UnityEngine.Vector2() {x = val_81.x, y = val_81.y};
        if((this.<>4__this + 64) == 0)
        {
                throw new NullReferenceException();
        }
        
        this.<>4__this + 64.fontSize = 38;
        if((this.<>4__this + 64) == 0)
        {
                throw new NullReferenceException();
        }
        
        this.<>4__this + 64.resizeTextMaxSize = 38;
        if((this.<>4__this + 64) == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_82 = this.<>4__this + 64.gameObject;
        if(val_82 == null)
        {
                throw new NullReferenceException();
        }
        
        val_82.SetActive(value:  true);
        if((this.<>4__this.event_text_bg) == 0)
        {
            goto label_287;
        }
        
        if((this.<>4__this.event_text_bg) != null)
        {
            goto label_262;
        }
        
        throw new NullReferenceException();
        label_124:
        if((System.String.op_Equality(a:  val_17, b:  "SuperStreak")) == false)
        {
            goto label_287;
        }
        
        if((this.<>4__this + 64) == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_85 = this.<>4__this + 64.gameObject;
        if(val_85 == null)
        {
                throw new NullReferenceException();
        }
        
        val_85.SetActive(value:  true);
        if(SuperStreakEventHandler.EVENT_DATAKEY_LAST_SECONDARY_GAME_MODE == null)
        {
                throw new NullReferenceException();
        }
        
        val_107 = mem[this.<>4__this + 80];
        val_107 = this.<>4__this + 80;
        if(SuperStreakEventHandler.EVENT_DATAKEY_LAST_SECONDARY_GAME_MODE.CanEngageWithEvent() == false)
        {
            goto label_241;
        }
        
        if(val_107 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_108 = this.<>4__this.superStreakGameSprite;
        goto label_284;
        label_129:
        if((System.String.op_Equality(a:  val_17, b:  "SpinKing")) == false)
        {
            goto label_287;
        }
        
        if((this.<>4__this + 80) == 0)
        {
                throw new NullReferenceException();
        }
        
        this.<>4__this + 80.sprite = this.<>4__this.spinKingMenuSprite;
        if((this.<>4__this.event_icon) == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.RectTransform val_88 = this.<>4__this.event_icon.rectTransform;
        UnityEngine.Vector2 val_89 = new UnityEngine.Vector2(x:  95f, y:  95f);
        if(val_88 == null)
        {
                throw new NullReferenceException();
        }
        
        val_88.sizeDelta = new UnityEngine.Vector2() {x = val_89.x, y = val_89.y};
        UnityEngine.Vector2 val_91 = new UnityEngine.Vector2(x:  4f, y:  4f);
        this.<>4__this + 80.rectTransform.anchoredPosition = new UnityEngine.Vector2() {x = val_91.x, y = val_91.y};
        this.<>4__this + 64.fontSize = 38;
        this.<>4__this + 64.resizeTextMaxSize = 38;
        this.<>4__this + 64.gameObject.SetActive(value:  true);
        if((this.<>4__this.event_text_bg) != 0)
        {
                this.<>4__this.event_text_bg.SetActive(value:  true);
        }
        
        if((this.<>4__this.event_middle_root) == 0)
        {
            goto label_287;
        }
        
        label_174:
        if((this.<>4__this.event_middle_root.gameObject) != null)
        {
            goto label_262;
        }
        
        label_146:
        if((System.String.op_Equality(a:  val_17, b:  "HintMania")) == false)
        {
            goto label_287;
        }
        
        if((this.<>4__this + 80) == 0)
        {
                throw new NullReferenceException();
        }
        
        val_105 = this.<>4__this.hintManiaGameSprite;
        label_192:
        this.<>4__this + 80.sprite = val_105;
        if((this.<>4__this.event_icon) == null)
        {
                throw new NullReferenceException();
        }
        
        if((this.<>4__this + 64) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((this.<>4__this + 64.gameObject) == null)
        {
                throw new NullReferenceException();
        }
        
        label_144:
        val_109 = 0;
        goto label_269;
        label_151:
        if((System.String.op_Equality(a:  val_17, b:  "PiggyBank")) == false)
        {
            goto label_287;
        }
        
        if((this.<>4__this + 80) == 0)
        {
                throw new NullReferenceException();
        }
        
        val_106 = this.<>4__this.pbGameSprite;
        goto label_272;
        label_156:
        if((System.String.op_Equality(a:  val_17, b:  "LightningLevels")) == false)
        {
            goto label_287;
        }
        
        if((this.<>4__this + 80) == 0)
        {
                throw new NullReferenceException();
        }
        
        val_106 = this.<>4__this.lightningLevelsGameSprite;
        label_272:
        this.<>4__this + 80.sprite = val_106;
        if((this.<>4__this.event_icon) == null)
        {
                throw new NullReferenceException();
        }
        
        label_212:
        if((this.<>4__this + 64) == 0)
        {
                throw new NullReferenceException();
        }
        
        label_202:
        UnityEngine.GameObject val_100 = this.<>4__this + 64.gameObject;
        if(val_100 == null)
        {
                throw new NullReferenceException();
        }
        
        label_262:
        val_109 = 1;
        label_269:
        val_100.SetActive(value:  true);
        label_287:
        label_63:
        NotificationCenter.DefaultCenter.PostNotification(aSender:  val_102, aName:  "OnGameEventButtonUpdate");
        label_2:
        val_103 = 0;
        return (bool)val_103;
        label_218:
        if(val_107 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_108 = this.<>4__this.hotStreakInactiveSprite;
        goto label_284;
        label_241:
        if(val_107 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_108 = this.<>4__this.superStreakInactiveSprite;
        label_284:
        val_107.sprite = val_108;
        label_197:
        if((this.<>4__this + 80) == 0)
        {
                throw new NullReferenceException();
        }
        
        goto label_287;
    }
    private object System.Collections.Generic.IEnumerator<System.Object>.get_Current()
    {
        return (object)this.<>2__current;
    }
    private void System.Collections.IEnumerator.Reset()
    {
        throw new System.NotSupportedException();
    }
    private object System.Collections.IEnumerator.get_Current()
    {
        return (object)this.<>2__current;
    }

}
