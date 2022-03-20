using UnityEngine;
public class WFOWordHuntEvent : WordHuntEvent
{
    // Methods
    public override bool ShowEventUI(EventButtonPanel.LayoutType layoutType, EventButtonPanel.DisplayContext context)
    {
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == false)
        {
                return this.ShowEventUI(layoutType:  layoutType, context:  context);
        }
        
        return false;
    }
    public override bool ShouldShowInDailyChallenge(bool dailyChallengeState)
    {
        return (bool)(~dailyChallengeState) & 1;
    }
    public override void OnDailyChallengeInit()
    {
    
    }
    public override void OnGameSceneInit()
    {
        var val_6;
        var val_7;
        string val_16;
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return;
        }
        
        this.OnGameSceneInit();
        if(this.IsLevelContainEventWord() == false)
        {
                return;
        }
        
        List.Enumerator<T> val_5 = WordRegion.instance.GetEnumerator();
        label_16:
        if(val_7.MoveNext() == false)
        {
            goto label_10;
        }
        
        WFOWordHuntEvent.<>c__DisplayClass3_0 val_9 = null;
        val_16 = 0;
        val_9 = new WFOWordHuntEvent.<>c__DisplayClass3_0();
        if(val_6 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_16 = mem[val_6 + 24];
        val_16 = val_6 + 24;
        string val_10 = this.EventWordContainedInWord(wordFound:  val_16);
        if(val_9 == null)
        {
                throw new NullReferenceException();
        }
        
        .eventWord = val_10;
        if((System.String.IsNullOrEmpty(value:  val_10)) == true)
        {
            goto label_16;
        }
        
        System.Predicate<System.Object> val_12 = null;
        val_16 = val_9;
        val_12 = new System.Predicate<System.Object>(object:  val_9, method:  System.Boolean WFOWordHuntEvent.<>c__DisplayClass3_0::<OnGameSceneInit>b__0(object x));
        if(X22 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((X22.FindIndex(match:  val_12)) != 1)
        {
            goto label_16;
        }
        
        goto label_16;
        label_10:
        val_7.Dispose();
    }
    protected override void OnValidWordSubmission(string word, bool isExtraWord)
    {
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false)
        {
                return;
        }
        
        isExtraWord = isExtraWord;
        this.OnValidWordSubmission(word:  word, isExtraWord:  isExtraWord);
    }
    public override void OnHintIncompleteWord(string word, Cell hintedCell)
    {
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false)
        {
                return;
        }
        
        this.OnHintIncompleteWord(word:  word, hintedCell:  hintedCell);
    }
    public override string GetGameButtonText()
    {
        return (string)System.String.Format(format:  "{0}/{1}", arg0:  true, arg1:  38021);
    }
    public override string GetMainMenuButtonText()
    {
        if(W9 != 38021)
        {
                return (string)System.String.Format(format:  "{0}/{1}", arg0:  WFOWordHuntEvent.__il2cppRuntimeField_namespaze, arg1:  WFOWordHuntEvent.__il2cppRuntimeField_namespaze);
        }
        
        if((this & 1) != 0)
        {
                return Localization.Localize(key:  "reward_upper", defaultValue:  "REWARD", useSingularKey:  false);
        }
        
        return (string)System.String.Format(format:  "{0}/{1}", arg0:  WFOWordHuntEvent.__il2cppRuntimeField_namespaze, arg1:  WFOWordHuntEvent.__il2cppRuntimeField_namespaze);
    }
    protected override void ColorAllVisibleTiles(LineWord wordLine, string eventWord, bool doGameplayAnimation = True)
    {
        var val_7;
        var val_8;
        EventButtonPanel val_24;
        object val_25;
        var val_26;
        System.Predicate<Cell> val_28;
        if(MainController.instance == null)
        {
                throw new NullReferenceException();
        }
        
        val_24 = val_1.eventButtonPanel;
        if(val_24 == null)
        {
                throw new NullReferenceException();
        }
        
        System.Collections.Generic.List<UnityEngine.UI.Image> val_3 = null;
        val_25 = public System.Void System.Collections.Generic.List<UnityEngine.UI.Image>::.ctor();
        val_3 = new System.Collections.Generic.List<UnityEngine.UI.Image>();
        if(wordLine == null)
        {
                throw new NullReferenceException();
        }
        
        val_26 = null;
        val_26 = null;
        val_28 = WFOWordHuntEvent.<>c.<>9__8_0;
        if(val_28 == null)
        {
                System.Predicate<Cell> val_4 = null;
            val_25 = WFOWordHuntEvent.<>c.__il2cppRuntimeField_static_fields;
            val_28 = val_4;
            val_4 = new System.Predicate<Cell>(object:  val_25, method:  System.Boolean WFOWordHuntEvent.<>c::<ColorAllVisibleTiles>b__8_0(Cell c));
            WFOWordHuntEvent.<>c.<>9__8_0 = val_28;
        }
        
        if(wordLine.cells == null)
        {
                throw new NullReferenceException();
        }
        
        val_24 = wordLine.cells;
        val_25 = val_28;
        bool val_5 = val_24.TrueForAll(match:  val_4);
        if(wordLine.cells == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_6 = wordLine.cells.GetEnumerator();
        label_28:
        val_25 = public System.Boolean List.Enumerator<Cell>::MoveNext();
        if(val_8.MoveNext() == false)
        {
            goto label_13;
        }
        
        if(val_7 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_7 + 72) == 0)
        {
            goto label_28;
        }
        
        if(eventWord == null)
        {
                throw new NullReferenceException();
        }
        
        if((eventWord.Contains(value:  val_7 + 64)) == false)
        {
            goto label_28;
        }
        
        val_25 = 0;
        string val_11 = this.currentColor;
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        val_25 = val_11.ToUpper();
        if(val_28 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Color32 val_13 = val_4.Item[val_25];
        val_7.SetNewBackgroundAndColor(bgColor:  new UnityEngine.Color32() {r = val_13.r & 4294967295, g = val_13.r & 4294967295, b = val_13.r & 4294967295, a = val_13.r & 4294967295}, bgAlpha:  1f);
        val_7.HideDynamicImage();
        if(val_5 == false)
        {
            goto label_28;
        }
        
        val_25 = 0;
        UnityEngine.Transform val_15 = val_7.transform;
        if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
        val_25 = 0;
        UnityEngine.Vector3 val_16 = val_15.position;
        val_24 = mem[val_7 + 48];
        val_24 = val_7 + 48;
        if(val_24 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_25 = 0;
        UnityEngine.RectTransform val_17 = val_24.rectTransform;
        if(val_17 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Rect val_18 = val_17.rect;
        val_25 = 0;
        UnityEngine.Vector2 val_19 = val_18.m_XMin.size;
        WordRegion val_20 = WordRegion.instance;
        if(val_20 == null)
        {
                throw new NullReferenceException();
        }
        
        val_3.Add(item:  this.CreateIconObject(worldPos:  new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z}, size:  new UnityEngine.Vector2() {x = val_19.x, y = val_19.y}, parentTransform:  val_20.transform));
        goto label_28;
        label_13:
        val_25 = public System.Void List.Enumerator<Cell>::Dispose();
        val_8.Dispose();
        if(val_5 == false)
        {
                return;
        }
        
        if((val_24.GetEventButton(eventId:  "WordHunt")) == 0)
        {
                throw new NullReferenceException();
        }
        
        this.DoProgressGameplayAnimation(iconList:  val_3, targetFlyToImage:  val_2 + 32);
    }
    protected override void PostValidWordSubmission()
    {
        bool val_1 = this.eventComplete;
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "ShowWordHuntTooltip");
    }
    protected override void HighlightEventExtraWordFound(string word)
    {
        .<>4__this = this;
        MainController val_2 = MainController.instance;
        .progressUI = val_2.eventButtonPanel.GetEventButton(eventId:  "WordHunt");
        UnityEngine.Vector3 val_6 = "Invalid RecipientInfo".gameObject.transform.position;
        UnityEngine.Rect val_8 = (WFOWordHuntEvent.<>c__DisplayClass10_0)[1152921516807925888].progressUI.icon.rectTransform.rect;
        UnityEngine.Vector2 val_9 = val_8.m_XMin.size;
        UnityEngine.Vector2 val_10 = new UnityEngine.Vector2(x:  1.5f, y:  1.5f);
        UnityEngine.Vector2 val_11 = UnityEngine.Vector2.op_Multiply(a:  new UnityEngine.Vector2() {x = val_9.x, y = val_9.y}, b:  new UnityEngine.Vector2() {x = val_10.x, y = val_10.y});
        UnityEngine.UI.Image val_14 = this.CreateIconObject(worldPos:  new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z}, size:  new UnityEngine.Vector2() {x = val_11.x, y = val_11.y}, parentTransform:  MonoSingleton<ScreenOverlay>.Instance.transform);
        .icon = val_14;
        UnityEngine.Color val_15 = new UnityEngine.Color(r:  1f, g:  1f, b:  1f, a:  0f);
        val_14.color = new UnityEngine.Color() {r = val_15.r, g = val_15.g, b = val_15.b, a = val_15.a};
        DG.Tweening.Sequence val_16 = DG.Tweening.DOTween.Sequence();
        UnityEngine.Vector2 val_19 = (WFOWordHuntEvent.<>c__DisplayClass10_0)[1152921516807925888].icon.rectTransform.anchoredPosition;
        float val_28 = 120f;
        val_28 = val_19.y + val_28;
        DG.Tweening.Sequence val_22 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_16, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOAnchorPosY(target:  (WFOWordHuntEvent.<>c__DisplayClass10_0)[1152921516807925888].icon.rectTransform, endValue:  val_28, duration:  0.2f, snapping:  false), ease:  1));
        DG.Tweening.Sequence val_25 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_16, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  (WFOWordHuntEvent.<>c__DisplayClass10_0)[1152921516807925888].icon, endValue:  1f, duration:  0.1f), ease:  1));
        DG.Tweening.Sequence val_27 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_16, action:  new DG.Tweening.TweenCallback(object:  new WFOWordHuntEvent.<>c__DisplayClass10_0(), method:  System.Void WFOWordHuntEvent.<>c__DisplayClass10_0::<HighlightEventExtraWordFound>b__0()));
    }
    private void DoProgressGameplayAnimation(System.Collections.Generic.List<UnityEngine.UI.Image> iconList, UnityEngine.UI.Image targetFlyToImage)
    {
        UnityEngine.UI.Image val_37;
        var val_38;
        DG.Tweening.TweenCallback val_40;
        var val_42;
        DG.Tweening.TweenCallback val_44;
        var val_45;
        DG.Tweening.TweenCallback val_47;
        val_37 = targetFlyToImage;
        DG.Tweening.Sequence val_1 = DG.Tweening.DOTween.Sequence();
        val_38 = null;
        val_38 = null;
        val_40 = WFOWordHuntEvent.<>c.<>9__11_0;
        if(val_40 == null)
        {
                DG.Tweening.TweenCallback val_2 = null;
            val_40 = val_2;
            val_2 = new DG.Tweening.TweenCallback(object:  WFOWordHuntEvent.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WFOWordHuntEvent.<>c::<DoProgressGameplayAnimation>b__11_0());
            WFOWordHuntEvent.<>c.<>9__11_0 = val_40;
        }
        
        DG.Tweening.Sequence val_3 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_1, callback:  val_2);
        UnityEngine.Vector3 val_5 = val_37.transform.position;
        var val_39 = 0;
        do
        {
            WFOWordHuntEvent.<>c__DisplayClass11_0 val_6 = null;
            val_40 = val_6;
            val_6 = new WFOWordHuntEvent.<>c__DisplayClass11_0();
            if(val_39 >= 1152921504939274240)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            .icon = null;
            DG.Tweening.Sequence val_7 = DG.Tweening.DOTween.Sequence();
            if(val_39 != 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            UnityEngine.Vector3 val_10 = DG.Tweening.DOTween.__il2cppRuntimeField_cctor_finished + 32.transform.position;
            val_42 = null;
            val_42 = null;
            val_44 = WFOWordHuntEvent.<>c.<>9__11_3;
            if(val_44 == null)
        {
                DG.Tweening.TweenCallback val_13 = null;
            val_44 = val_13;
            val_13 = new DG.Tweening.TweenCallback(object:  WFOWordHuntEvent.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WFOWordHuntEvent.<>c::<DoProgressGameplayAnimation>b__11_3());
            val_37 = val_37;
            WFOWordHuntEvent.<>c.<>9__11_3 = val_44;
        }
        
            DG.Tweening.Sequence val_15 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_7, t:  DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOMove(target:  (WFOWordHuntEvent.<>c__DisplayClass11_0)[1152921516808333824].icon.transform, endValue:  new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z}, duration:  0.6f, snapping:  false), ease:  1), action:  val_13));
        }
        else
        {
                float val_37 = (float)val_5.x;
            val_37 = val_37 * 0.15f;
            val_37 = val_37 + 0.6f;
            DG.Tweening.Sequence val_16 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_7, interval:  val_37);
            val_45 = null;
            val_45 = null;
            val_47 = WFOWordHuntEvent.<>c.<>9__11_2;
            if(val_47 == null)
        {
                DG.Tweening.TweenCallback val_20 = null;
            val_47 = val_20;
            val_20 = new DG.Tweening.TweenCallback(object:  WFOWordHuntEvent.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WFOWordHuntEvent.<>c::<DoProgressGameplayAnimation>b__11_2());
            val_37 = val_37;
            WFOWordHuntEvent.<>c.<>9__11_2 = val_47;
        }
        
            DG.Tweening.Sequence val_22 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_7, t:  DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOMoveX(target:  (WFOWordHuntEvent.<>c__DisplayClass11_0)[1152921516808333824].icon.transform, endValue:  val_5.x, duration:  0.6f, snapping:  false), ease:  3), action:  val_20));
            DG.Tweening.Sequence val_26 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_7, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOMoveY(target:  (WFOWordHuntEvent.<>c__DisplayClass11_0)[1152921516808333824].icon.transform, endValue:  val_5.y, duration:  0.6f, snapping:  false), ease:  20));
            UnityEngine.Vector2 val_29 = val_37.rectTransform.sizeDelta;
            DG.Tweening.Sequence val_31 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_7, t:  DG.Tweening.ShortcutExtensions46.DOSizeDelta(target:  (WFOWordHuntEvent.<>c__DisplayClass11_0)[1152921516808333824].icon.rectTransform, endValue:  new UnityEngine.Vector2() {x = val_29.x, y = val_29.y}, duration:  0.6f, snapping:  false));
        }
        
            DG.Tweening.Sequence val_33 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_7, action:  new DG.Tweening.TweenCallback(object:  val_6, method:  System.Void WFOWordHuntEvent.<>c__DisplayClass11_0::<DoProgressGameplayAnimation>b__4()));
            float val_38 = 0f;
            val_38 = val_38 * 0.15f;
            DG.Tweening.Sequence val_34 = DG.Tweening.TweenSettingsExtensions.Insert(s:  val_1, atPosition:  val_38, t:  val_7);
            val_39 = val_39 + 1;
        }
        while(val_39 < 1152921513401904048);
        
        DG.Tweening.Sequence val_36 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_1, action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WFOWordHuntEvent::<DoProgressGameplayAnimation>b__11_1()));
    }
    public WFOWordHuntEvent()
    {
    
    }
    private void <DoProgressGameplayAnimation>b__11_1()
    {
        System.Collections.Generic.List<System.String> val_1 = this.GetEventWordsSolvedInLevel();
        mem[1152921516808665180] = true;
        goto typeof(WFOWordHuntEvent).__il2cppRuntimeField_2B0;
    }

}
