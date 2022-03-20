using UnityEngine;
public class WADWordHuntEvent : WordHuntEvent
{
    // Methods
    public override bool ShowEventUI(EventButtonPanel.LayoutType layoutType, EventButtonPanel.DisplayContext context)
    {
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return false;
        }
        
        if(CategoryPacksManager.IsPlaying == false)
        {
                return this.ShowEventUI(layoutType:  layoutType, context:  context);
        }
        
        return false;
    }
    public override void OnDailyChallengeInit()
    {
    
    }
    public override void OnGameSceneInit()
    {
        var val_7;
        var val_8;
        string val_17;
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
        {
                return;
        }
        
        if(CategoryPacksManager.IsPlaying == true)
        {
                return;
        }
        
        this.OnGameSceneInit();
        if(this.IsLevelContainEventWord() == false)
        {
                return;
        }
        
        List.Enumerator<T> val_6 = WordRegion.instance.GetEnumerator();
        label_19:
        if(val_8.MoveNext() == false)
        {
            goto label_13;
        }
        
        WADWordHuntEvent.<>c__DisplayClass2_0 val_10 = null;
        val_17 = 0;
        val_10 = new WADWordHuntEvent.<>c__DisplayClass2_0();
        if(val_7 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_17 = mem[val_7 + 24];
        val_17 = val_7 + 24;
        string val_11 = this.EventWordContainedInWord(wordFound:  val_17);
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        .eventWord = val_11;
        if((System.String.IsNullOrEmpty(value:  val_11)) == true)
        {
            goto label_19;
        }
        
        System.Predicate<System.Object> val_13 = null;
        val_17 = val_10;
        val_13 = new System.Predicate<System.Object>(object:  val_10, method:  System.Boolean WADWordHuntEvent.<>c__DisplayClass2_0::<OnGameSceneInit>b__0(object x));
        if(X22 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((X22.FindIndex(match:  val_13)) != 1)
        {
            goto label_19;
        }
        
        goto label_19;
        label_13:
        val_8.Dispose();
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
                return (string)System.String.Format(format:  "{0}/{1}", arg0:  WADWordHuntEvent.__il2cppRuntimeField_namespaze, arg1:  WADWordHuntEvent.__il2cppRuntimeField_namespaze);
        }
        
        if((this & 1) != 0)
        {
                return Localization.Localize(key:  "reward_upper", defaultValue:  "REWARD", useSingularKey:  false);
        }
        
        return (string)System.String.Format(format:  "{0}/{1}", arg0:  WADWordHuntEvent.__il2cppRuntimeField_namespaze, arg1:  WADWordHuntEvent.__il2cppRuntimeField_namespaze);
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
        
        System.Collections.Generic.List<Cell> val_23 = wordLine.cells;
        val_26 = null;
        val_26 = null;
        val_28 = WADWordHuntEvent.<>c.<>9__7_0;
        if(val_28 == null)
        {
                System.Predicate<Cell> val_4 = null;
            val_25 = WADWordHuntEvent.<>c.__il2cppRuntimeField_static_fields;
            val_28 = val_4;
            val_4 = new System.Predicate<Cell>(object:  val_25, method:  System.Boolean WADWordHuntEvent.<>c::<ColorAllVisibleTiles>b__7_0(Cell c));
            WADWordHuntEvent.<>c.<>9__7_0 = val_28;
        }
        
        if(val_23 == null)
        {
                throw new NullReferenceException();
        }
        
        val_24 = val_23;
        val_25 = val_28;
        if(wordLine.cells == null)
        {
                throw new NullReferenceException();
        }
        
        val_23 = (val_24.TrueForAll(match:  val_4)) & doGameplayAnimation;
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
        if(wordLine == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Color32 val_13 = wordLine.Item[val_25];
        val_7.SetNewBackgroundAndColor(bgColor:  new UnityEngine.Color32() {r = val_13.r & 4294967295, g = val_13.r & 4294967295, b = val_13.r & 4294967295, a = val_13.r & 4294967295}, bgAlpha:  1f);
        val_7.HideDynamicImage();
        if(val_23 == false)
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
        if(val_23 == false)
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
        UnityEngine.Vector3 val_6 = TextPreview.instance.gameObject.transform.position;
        UnityEngine.Rect val_8 = (WADWordHuntEvent.<>c__DisplayClass9_0)[1152921516804084288].progressUI.icon.rectTransform.rect;
        UnityEngine.Vector2 val_9 = val_8.m_XMin.size;
        UnityEngine.Vector2 val_10 = new UnityEngine.Vector2(x:  1.5f, y:  1.5f);
        UnityEngine.Vector2 val_11 = UnityEngine.Vector2.op_Multiply(a:  new UnityEngine.Vector2() {x = val_9.x, y = val_9.y}, b:  new UnityEngine.Vector2() {x = val_10.x, y = val_10.y});
        UnityEngine.UI.Image val_14 = this.CreateIconObject(worldPos:  new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z}, size:  new UnityEngine.Vector2() {x = val_11.x, y = val_11.y}, parentTransform:  MonoSingleton<ScreenOverlay>.Instance.transform);
        .icon = val_14;
        UnityEngine.Color val_15 = new UnityEngine.Color(r:  1f, g:  1f, b:  1f, a:  0f);
        val_14.color = new UnityEngine.Color() {r = val_15.r, g = val_15.g, b = val_15.b, a = val_15.a};
        DG.Tweening.Sequence val_16 = DG.Tweening.DOTween.Sequence();
        UnityEngine.Vector2 val_19 = (WADWordHuntEvent.<>c__DisplayClass9_0)[1152921516804084288].icon.rectTransform.anchoredPosition;
        float val_28 = 120f;
        val_28 = val_19.y + val_28;
        DG.Tweening.Sequence val_22 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_16, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOAnchorPosY(target:  (WADWordHuntEvent.<>c__DisplayClass9_0)[1152921516804084288].icon.rectTransform, endValue:  val_28, duration:  0.2f, snapping:  false), ease:  1));
        DG.Tweening.Sequence val_25 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_16, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  (WADWordHuntEvent.<>c__DisplayClass9_0)[1152921516804084288].icon, endValue:  1f, duration:  0.1f), ease:  1));
        DG.Tweening.Sequence val_27 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_16, action:  new DG.Tweening.TweenCallback(object:  new WADWordHuntEvent.<>c__DisplayClass9_0(), method:  System.Void WADWordHuntEvent.<>c__DisplayClass9_0::<HighlightEventExtraWordFound>b__0()));
    }
    private void DoProgressGameplayAnimation(System.Collections.Generic.List<UnityEngine.UI.Image> iconList, UnityEngine.UI.Image targetFlyToImage)
    {
        var val_35;
        UnityEngine.UI.Image val_36;
        var val_38;
        DG.Tweening.TweenCallback val_40;
        var val_41;
        DG.Tweening.TweenCallback val_43;
        val_36 = targetFlyToImage;
        DG.Tweening.Sequence val_1 = DG.Tweening.DOTween.Sequence();
        UnityEngine.Vector3 val_3 = val_36.transform.position;
        do
        {
            if(0 >= 1152921504939008000)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            .icon = "Mon";
            DG.Tweening.Sequence val_5 = DG.Tweening.DOTween.Sequence();
            if(0 != 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            UnityEngine.Vector3 val_8 = DG.Tweening.DOTween.__il2cppRuntimeField_cctor_finished + 32.transform.position;
            val_38 = null;
            val_38 = null;
            val_40 = WADWordHuntEvent.<>c.<>9__10_2;
            if(val_40 == null)
        {
                DG.Tweening.TweenCallback val_11 = null;
            val_40 = val_11;
            val_11 = new DG.Tweening.TweenCallback(object:  WADWordHuntEvent.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WADWordHuntEvent.<>c::<DoProgressGameplayAnimation>b__10_2());
            val_36 = val_36;
            WADWordHuntEvent.<>c.<>9__10_2 = val_40;
        }
        
            DG.Tweening.Sequence val_13 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_5, t:  DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOMove(target:  (WADWordHuntEvent.<>c__DisplayClass10_0)[1152921516804474896].icon.transform, endValue:  new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z}, duration:  0.6f, snapping:  false), ease:  1), action:  val_11));
        }
        else
        {
                float val_35 = (float)val_3.x;
            val_35 = val_35 * 0.15f;
            val_35 = val_35 + 0.6f;
            DG.Tweening.Sequence val_14 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_5, interval:  val_35);
            val_41 = null;
            val_41 = null;
            val_43 = WADWordHuntEvent.<>c.<>9__10_1;
            if(val_43 == null)
        {
                DG.Tweening.TweenCallback val_18 = null;
            val_43 = val_18;
            val_18 = new DG.Tweening.TweenCallback(object:  WADWordHuntEvent.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WADWordHuntEvent.<>c::<DoProgressGameplayAnimation>b__10_1());
            val_36 = val_36;
            WADWordHuntEvent.<>c.<>9__10_1 = val_43;
        }
        
            DG.Tweening.Sequence val_20 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_5, t:  DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOMoveX(target:  (WADWordHuntEvent.<>c__DisplayClass10_0)[1152921516804474896].icon.transform, endValue:  val_3.x, duration:  0.6f, snapping:  false), ease:  3), action:  val_18));
            DG.Tweening.Sequence val_24 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_5, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOMoveY(target:  (WADWordHuntEvent.<>c__DisplayClass10_0)[1152921516804474896].icon.transform, endValue:  val_3.y, duration:  0.6f, snapping:  false), ease:  20));
            UnityEngine.Vector2 val_27 = val_36.rectTransform.sizeDelta;
            DG.Tweening.Sequence val_29 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_5, t:  DG.Tweening.ShortcutExtensions46.DOSizeDelta(target:  (WADWordHuntEvent.<>c__DisplayClass10_0)[1152921516804474896].icon.rectTransform, endValue:  new UnityEngine.Vector2() {x = val_27.x, y = val_27.y}, duration:  0.6f, snapping:  false));
        }
        
            DG.Tweening.Sequence val_31 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_5, action:  new DG.Tweening.TweenCallback(object:  new WADWordHuntEvent.<>c__DisplayClass10_0(), method:  System.Void WADWordHuntEvent.<>c__DisplayClass10_0::<DoProgressGameplayAnimation>b__3()));
            float val_36 = 0f;
            val_36 = val_36 * 0.15f;
            DG.Tweening.Sequence val_32 = DG.Tweening.TweenSettingsExtensions.Insert(s:  val_1, atPosition:  val_36, t:  val_5);
            val_35 = 0 + 1;
        }
        while(val_35 < 1152921513401904048);
        
        DG.Tweening.Sequence val_34 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_1, action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WADWordHuntEvent::<DoProgressGameplayAnimation>b__10_0()));
    }
    public WADWordHuntEvent()
    {
    
    }
    private void <DoProgressGameplayAnimation>b__10_0()
    {
        MainController val_1 = MainController.instance;
        if(val_1.eventButtonPanel != 0)
        {
                MainController val_3 = MainController.instance;
            val_3.eventButtonPanel.GetEventButton(eventId:  "WordHunt").ShowToolTip();
        }
        
        System.Collections.Generic.List<System.String> val_5 = this.GetEventWordsSolvedInLevel();
        mem[1152921516804834924] = (WGEventButtonV2.__il2cppRuntimeField_typeHierarchy + (WGEventButtonProgressWordHunt.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8;
        WGAudioController val_6 = MonoSingleton<WGAudioController>.Instance;
        val_6.sound.PlayGeneralSound(type:  0, oneshot:  true, pitch:  1f, vol:  1f);
    }

}
