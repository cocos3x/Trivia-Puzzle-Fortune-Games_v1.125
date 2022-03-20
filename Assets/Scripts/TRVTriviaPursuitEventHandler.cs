using UnityEngine;
public class TRVTriviaPursuitEventHandler : WGEventHandler
{
    // Fields
    public const string TRIVIA_PURSUIT_EVENT_ID = "TriviaPursuit";
    public const string EVENT_TRACKING_ID = "Trivia Pursuit";
    private const string TRIVIA_PURSUIT_NAME = "TRIVIA PURSUIT";
    private static TRVTriviaPursuitEventHandler <Instance>k__BackingField;
    private TriviaPursuitEventProgress eventProgress;
    
    // Properties
    public static TRVTriviaPursuitEventHandler Instance { get; set; }
    private TriviaPursuitEcon EventEcon { get; set; }
    public override bool IsEventValid { get; }
    
    // Methods
    public static TRVTriviaPursuitEventHandler get_Instance()
    {
        return (TRVTriviaPursuitEventHandler)TRVTriviaPursuitEventHandler.<Instance>k__BackingField;
    }
    private static void set_Instance(TRVTriviaPursuitEventHandler value)
    {
        TRVTriviaPursuitEventHandler.<Instance>k__BackingField = value;
    }
    private TriviaPursuitEcon get_EventEcon()
    {
        TRVEcon val_1 = App.GetGameSpecificEcon<TRVEcon>();
        return (TriviaPursuitEcon)val_1.TriviaPursuitEventEcon;
    }
    private void set_EventEcon(TriviaPursuitEcon value)
    {
        TRVEcon val_1 = App.GetGameSpecificEcon<TRVEcon>();
        val_1.TriviaPursuitEventEcon = value;
    }
    public override void Init(GameEventV2 eventV2)
    {
        mem[1152921517400740192] = eventV2;
        TRVTriviaPursuitEventHandler.<Instance>k__BackingField = this;
        this.RefreshEventData(data:  eventV2.eventData);
    }
    public override void OnDataUpdated(GameEventV2 eventV2)
    {
        if(eventV2 != null)
        {
                this.RefreshEventData(data:  eventV2.eventData);
            return;
        }
        
        throw new NullReferenceException();
    }
    public override bool get_IsEventValid()
    {
        GameBehavior val_1 = App.getBehavior;
        return System.String.op_Equality(a:  val_1.<metaGameBehavior>k__BackingField.GetCurrentLanguage(), b:  "en");
    }
    public override void OnEventEnded()
    {
        TRVTriviaPursuitEventHandler.<Instance>k__BackingField = 0;
        goto typeof(TriviaPursuitEventProgress).__il2cppRuntimeField_190;
    }
    public override void OnGameSceneBegan()
    {
        var val_1;
        if((this & 1) != 0)
        {
                return;
        }
        
        mem2[0] = 1;
        val_1 = null;
        val_1 = null;
        if(TRVMainController.noAnswerSelectedCharacter != null)
        {
                return;
        }
        
        this.ShowTriviaPursuitPopup(forceUpdate:  false, showFlyout:  false);
    }
    public override void OnCategoryComplete()
    {
        TRVMainController val_2 = MonoSingleton<TRVMainController>.Instance;
        .completedCategory = val_2.currentGame.quizCategory;
        TriviaPursuitCategory val_4 = this.eventProgress.SelectedCategories.Find(match:  new System.Predicate<TriviaPursuitCategory>(object:  new TRVTriviaPursuitEventHandler.<>c__DisplayClass17_0(), method:  System.Boolean TRVTriviaPursuitEventHandler.<>c__DisplayClass17_0::<OnCategoryComplete>b__0(TriviaPursuitCategory x)));
        if(val_4 == null)
        {
                return;
        }
        
        if(val_4.IsCompleted() != false)
        {
                return;
        }
        
        int val_6 = val_4.Progress;
        val_6 = val_6 + 1;
        val_4.Progress = val_6;
        this.CheckEventGoal();
    }
    public override System.Collections.Generic.List<TRVCategorySelectionInfo> GetEventsRegisteredCategories(System.Collections.Generic.List<TRVCategorySelectionInfo> categories)
    {
        System.Collections.Generic.List<TRVCategorySelectionInfo> val_21;
        var val_22;
        TriviaPursuitEventProgress val_23;
        int val_24;
        var val_25;
        System.Func<TriviaPursuitCategory, System.Boolean> val_27;
        val_21 = categories;
        .categories = val_21;
        if((this & 1) != 0)
        {
                return (System.Collections.Generic.List<TRVCategorySelectionInfo>)(TRVTriviaPursuitEventHandler.<>c__DisplayClass18_0)[1152921517401742384].categories;
        }
        
        .CS$<>8__locals1 = new TRVTriviaPursuitEventHandler.<>c__DisplayClass18_0();
        .i = 0;
        val_22 = 0;
        label_15:
        if(0 >= ((TRVTriviaPursuitEventHandler.<>c__DisplayClass18_0)[1152921517401742384].categories))
        {
            goto label_5;
        }
        
        TriviaPursuitCategory val_4 = this.eventProgress.SelectedCategories.Find(match:  new System.Predicate<TriviaPursuitCategory>(object:  new TRVTriviaPursuitEventHandler.<>c__DisplayClass18_1(), method:  System.Boolean TRVTriviaPursuitEventHandler.<>c__DisplayClass18_1::<GetEventsRegisteredCategories>b__0(TriviaPursuitCategory x)));
        if((val_4 != null) && (val_4.IsCompleted() != true))
        {
                TRVTriviaPursuitEventHandler.<>c__DisplayClass18_0 val_21 = (TRVTriviaPursuitEventHandler.<>c__DisplayClass18_1)[1152921517401746480].CS$<>8__locals1;
            if(val_21 <= ((TRVTriviaPursuitEventHandler.<>c__DisplayClass18_1)[1152921517401746480].i))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_21 = val_21 + (((TRVTriviaPursuitEventHandler.<>c__DisplayClass18_1)[1152921517401746480].i) << 3);
            0.Add(item:  this);
        }
        
        int val_22 = (TRVTriviaPursuitEventHandler.<>c__DisplayClass18_1)[1152921517401746480].i;
        val_22 = val_22 + 1;
        .i = val_22;
        if(((TRVTriviaPursuitEventHandler.<>c__DisplayClass18_1)[1152921517401746480].CS$<>8__locals1) != null)
        {
            goto label_15;
        }
        
        label_5:
        if((val_22 & 1) != 0)
        {
                val_23 = this.eventProgress;
            Player val_6 = App.Player;
            val_21 = val_6;
            TriviaPursuitEcon val_8 = val_6.EventEcon.EventEcon;
            int val_23 = val_8.maxInterval;
            val_23 = (UnityEngine.Random.Range(min:  val_7.minInterval, max:  val_23 + 1)) + val_21;
            this.eventProgress.NextTPLevel = val_23;
        }
        
        if(App.Player != this.eventProgress.NextTPLevel)
        {
                return (System.Collections.Generic.List<TRVCategorySelectionInfo>)(TRVTriviaPursuitEventHandler.<>c__DisplayClass18_0)[1152921517401742384].categories;
        }
        
        TRVTriviaPursuitEventHandler.<>c__DisplayClass18_2 val_12 = null;
        val_21 = val_12;
        val_12 = new TRVTriviaPursuitEventHandler.<>c__DisplayClass18_2();
        val_22 = 1152921504966270976;
        val_25 = null;
        val_25 = null;
        val_27 = TRVTriviaPursuitEventHandler.<>c.<>9__18_1;
        if(val_27 == null)
        {
                System.Func<TriviaPursuitCategory, System.Boolean> val_13 = null;
            val_27 = val_13;
            val_13 = new System.Func<TriviaPursuitCategory, System.Boolean>(object:  TRVTriviaPursuitEventHandler.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean TRVTriviaPursuitEventHandler.<>c::<GetEventsRegisteredCategories>b__18_1(TriviaPursuitCategory x));
            TRVTriviaPursuitEventHandler.<>c.<>9__18_1 = val_27;
        }
        
        var val_24 = 1152921517401632912;
        int val_16 = UnityEngine.Random.Range(min:  0, max:  -90115952);
        if(val_24 <= val_16)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_24 = val_24 + (val_16 << 3);
        .chosenUnfinishedCategory = (1152921517401632912 + (val_16) << 3) + 32;
        System.Predicate<TriviaPursuitCategory> val_17 = null;
        val_23 = val_17;
        val_17 = new System.Predicate<TriviaPursuitCategory>(object:  val_12, method:  System.Boolean TRVTriviaPursuitEventHandler.<>c__DisplayClass18_2::<GetEventsRegisteredCategories>b__2(TriviaPursuitCategory x));
        if((System.String.IsNullOrEmpty(value:  (TRVTriviaPursuitEventHandler.<>c__DisplayClass18_2)[1152921517401807920].chosenUnfinishedCategory.CategoryName)) != false)
        {
                val_24 = 0;
            UnityEngine.Debug.LogError(message:  "Trivia Pursuit is trying to inject an empty category into the category data");
            return (System.Collections.Generic.List<TRVCategorySelectionInfo>)(TRVTriviaPursuitEventHandler.<>c__DisplayClass18_0)[1152921517401742384].categories;
        }
        
        TRVCategorySelectionInfo val_20 = null;
        val_23 = val_20;
        val_20 = new TRVCategorySelectionInfo();
        .categoryName = (TRVTriviaPursuitEventHandler.<>c__DisplayClass18_2)[1152921517401807920].chosenUnfinishedCategory.CategoryName;
        (TRVCategorySelectionInfo)[1152921517401844784].associatedEvents.Add(item:  this);
        val_24 = System.Linq.Enumerable.ToList<TriviaPursuitCategory>(source:  System.Linq.Enumerable.Where<TriviaPursuitCategory>(source:  this.eventProgress.SelectedCategories, predicate:  val_13)).FindIndex(match:  val_17);
        (TRVTriviaPursuitEventHandler.<>c__DisplayClass18_0)[1152921517401742384].categories.set_Item(index:  val_24, value:  val_20);
        return (System.Collections.Generic.List<TRVCategorySelectionInfo>)(TRVTriviaPursuitEventHandler.<>c__DisplayClass18_0)[1152921517401742384].categories;
    }
    public override bool EventCompleted()
    {
        System.DateTime val_1 = DateTimeCheat.UtcNow;
        return System.DateTime.op_GreaterThanOrEqual(t1:  new System.DateTime() {dateData = val_1.dateData}, t2:  new System.DateTime() {dateData = DateTimeCheat.__il2cppRuntimeField_cctor_finished + 40});
    }
    public override bool IsChallengeCompleted()
    {
        goto typeof(TRVTriviaPursuitEventHandler).__il2cppRuntimeField_4F0;
    }
    public override void UpdateProgress()
    {
        mem2[0] = ServerHandler.UnixServerTime;
        this.UpdateProgress();
    }
    public override void OnMainMenuButtonPressed(bool connected)
    {
        if((this & 1) != 0)
        {
                return;
        }
        
        this.ShowTriviaPursuitPopup(forceUpdate:  false, showFlyout:  false);
    }
    public override void OnGameButtonPressed(bool connected)
    {
        if((this & 1) != 0)
        {
                return;
        }
        
        this.ShowTriviaPursuitPopup(forceUpdate:  false, showFlyout:  false);
    }
    public override string GetMainMenuButtonText()
    {
        return System.String.Format(format:  "{0}\n{1}", arg0:  "TRIVIA PURSUIT", arg1:  this.GetEventProgressText());
    }
    public override string GetGameButtonText()
    {
        return System.String.Format(format:  "{0}\n{1}", arg0:  "TRIVIA PURSUIT", arg1:  this.GetEventProgressText());
    }
    public override string GetEventDisplayName()
    {
        return "TRIVIA PURSUIT";
    }
    public override void LoadEventListItemContent(PrefabsFromFolder loader)
    {
        loader.LoadStrictlyTypeNamedPrefab<EventListItemContentTriviaPursuit>(allowMultiple:  false).SetupSlider(sliderText:  this.GetEventProgressText(), sliderValue:  this.GetEventProgressValue());
    }
    public override UnityEngine.Sprite GetEventIcon()
    {
        return MonoSingleton<TRVUtils>.Instance.GetEventIcon(eventHandler:  this);
    }
    public void RerollAnimateCategories()
    {
        TriviaPursuitEcon val_2 = App.Player.EventEcon;
        if(val_1._gems < val_2.rerollCost)
        {
                GameStoreManager.StoreCategoryFocus = Localization.Localize(key:  "gems_upper", defaultValue:  "GEMS", useSingularKey:  false);
            MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGStoreProxy>(showNext:  true).Init(outOfCredits:  true, onCloseAction:  new System.Action(object:  this, method:  System.Void TRVTriviaPursuitEventHandler::<RerollAnimateCategories>b__29_0()));
            SLCWindow.CloseWindow(window:  MonoSingleton<WGWindowManager>.Instance.GetWindow<TRVTriviaPursuitPopup>().gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
            return;
        }
        
        Player val_10 = App.Player;
        TriviaPursuitEcon val_11 = val_10.EventEcon;
        val_10.AddGems(amount:  -val_11.rerollCost, source:  "Trivia Pursuit Reroll", subsource:  0);
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "GemStatViewUpdate");
        this.RerollCategoriesData();
        this.ShowTriviaPursuitPopup(forceUpdate:  true, showFlyout:  false);
    }
    public void CollectReward()
    {
        Player val_1 = App.Player;
        TriviaPursuitEcon val_2 = val_1.EventEcon;
        val_1.AddGems(amount:  val_2.reward.rewardAmount, source:  "Trivia Pursuit reward", subsource:  0);
        Player val_3 = App.Player;
        TriviaPursuitEcon val_4 = val_3.EventEcon;
        val_3.TrackNonCoinReward(source:  "Trivia Pursuit Event", subSource:  0, rewardType:  "Gems", rewardAmount:  val_4.reward.rewardAmount.ToString(), additionalParams:  0);
    }
    private void RefreshEventData(System.Collections.Generic.Dictionary<string, object> data)
    {
        if((System.String.op_Inequality(a:  0, b:  "TriviaPursuit")) != false)
        {
                UnityEngine.Debug.LogError(message:  "Attempting to update Handler with non-matching event type: "("Attempting to update Handler with non-matching event type: ") + System.Void TRVMainController::<RerollCategory>b__69_0()(System.Void TRVMainController::<RerollCategory>b__69_0()));
            return;
        }
        
        if(this.IsEventNewCycle() != false)
        {
                this.ResetEventProgress();
            this.RerollCategoriesData();
        }
        
        this.ParseEcon(data:  data);
        goto typeof(TriviaPursuitEventProgress).__il2cppRuntimeField_180;
    }
    private void ParseEcon(System.Collections.Generic.Dictionary<string, object> data)
    {
        var val_26;
        if(data == null)
        {
                return;
        }
        
        if((data.ContainsKey(key:  "economy")) == false)
        {
                return;
        }
        
        object val_2 = data.Item["economy"];
        val_26 = 0;
        if((ContainsKey(key:  "req")) != false)
        {
                bool val_8 = System.Int32.TryParse(s:  Item["req"], result: out  (TriviaPursuitEcon)[1152921517403739952].requirement);
        }
        
        if((ContainsKey(key:  "reroll")) != false)
        {
                bool val_12 = System.Int32.TryParse(s:  Item["reroll"], result: out  (TriviaPursuitEcon)[1152921517403739952].rerollCost);
        }
        
        if((ContainsKey(key:  "rew")) != false)
        {
                TRVReward val_14 = new TRVReward();
            .rewardType = 4.94065645841247E-324;
            bool val_17 = System.Int32.TryParse(s:  Item["rew"], result: out  (TriviaPursuitEcon)[1152921517403739952].reward.rewardAmount);
        }
        
        if((ContainsKey(key:  "min")) != false)
        {
                bool val_21 = System.Int32.TryParse(s:  Item["min"], result: out  (TriviaPursuitEcon)[1152921517403739952].minInterval);
        }
        
        System.Int32.TryParse(s:  Item["max"], result: out  (TriviaPursuitEcon)[1152921517403739952].maxInterval).EventEcon = new TriviaPursuitEcon();
    }
    private void RerollCategoriesData()
    {
        System.Collections.Generic.List<TriviaPursuitCategory> val_4;
        TriviaPursuitCategory val_5;
        System.Collections.Generic.List<System.String> val_1 = this.GetNewCategories();
        System.Collections.Generic.List<TriviaPursuitCategory> val_2 = null;
        val_4 = val_2;
        val_5 = public System.Void System.Collections.Generic.List<TriviaPursuitCategory>::.ctor();
        val_2 = new System.Collections.Generic.List<TriviaPursuitCategory>();
        this.eventProgress.SelectedCategories = val_4;
        if(1152921517403841008 >= 1)
        {
                var val_4 = 0;
            do
        {
            TriviaPursuitCategory val_3 = null;
            val_4 = val_3;
            val_3 = new TriviaPursuitCategory();
            if(val_4 >= 1152921517403841008)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            .Progress = 0;
            .CategoryName = System.Void TRVLevelComplete.<>c__DisplayClass83_0::<MultiplierPicked>b__0();
            val_5 = val_4;
            this.eventProgress.SelectedCategories.Add(item:  val_3);
            val_4 = val_4 + 1;
        }
        while(val_4 < this.eventProgress);
        
        }
    
    }
    private System.Collections.Generic.List<string> GetNewCategories()
    {
        string val_7;
        var val_8;
        string val_35;
        System.Collections.Generic.Dictionary<TRVCategoryID, System.Int32> val_36;
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
        System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>> val_2 = null;
        val_35 = public System.Void System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>>::.ctor();
        val_2 = new System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>>();
        TRVDataParser val_3 = MonoSingleton<TRVDataParser>.Instance;
        if(val_3 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = 0;
        System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>> val_4 = val_3.getAvailableSubCategories;
        if(val_4 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = public Dictionary.KeyCollection<TKey, TValue> System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>>::get_Keys();
        Dictionary.KeyCollection<TKey, TValue> val_5 = val_4.Keys;
        if(val_5 == null)
        {
                throw new NullReferenceException();
        }
        
        Dictionary.KeyCollection.Enumerator<TKey, TValue> val_6 = val_5.GetEnumerator();
        label_12:
        val_35 = public System.Boolean Dictionary.KeyCollection.Enumerator<System.String, System.Collections.Generic.List<System.String>>::MoveNext();
        if(val_8.MoveNext() == false)
        {
            goto label_6;
        }
        
        TRVDataParser val_10 = MonoSingleton<TRVDataParser>.Instance;
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = 0;
        System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>> val_11 = val_10.getAvailableSubCategories;
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        val_2.Add(key:  val_7, value:  new System.Collections.Generic.List<System.String>(collection:  val_11.Item[val_7]));
        goto label_12;
        label_6:
        val_8.Dispose();
        var val_35 = 0;
        do
        {
            RandomSet val_14 = new RandomSet();
            if(2 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_35 = public System.String System.Enum::ToString();
            if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
            val_35 = 2.ToString();
            if(val_2.Item[val_35] == null)
        {
                throw new NullReferenceException();
        }
        
            if(16926284 >= 1)
        {
                if((App.GetGameSpecificEcon<TRVEcon>()) == null)
        {
                throw new NullReferenceException();
        }
        
            val_36 = val_17.primaryCategoryOdds;
            if(val_36 == null)
        {
                throw new NullReferenceException();
        }
        
            val_35 = 2;
            if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
            val_14.add(item:  2, weight:  (float)val_36.Item[val_35]);
        }
        
            if(1 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_35 = 1.ToString();
            if(val_2.Item[val_35] == null)
        {
                throw new NullReferenceException();
        }
        
            if(38161477 >= 1)
        {
                if((App.GetGameSpecificEcon<TRVEcon>()) == null)
        {
                throw new NullReferenceException();
        }
        
            val_36 = val_21.primaryCategoryOdds;
            if(val_36 == null)
        {
                throw new NullReferenceException();
        }
        
            val_35 = 1;
            if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
            val_14.add(item:  1, weight:  (float)val_36.Item[val_35]);
        }
        
            if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_35 = 0.ToString();
            if(val_2.Item[val_35] == null)
        {
                throw new NullReferenceException();
        }
        
            if(1179403647 >= 1)
        {
                if((App.GetGameSpecificEcon<TRVEcon>()) == null)
        {
                throw new NullReferenceException();
        }
        
            val_36 = val_25.primaryCategoryOdds;
            if(val_36 == null)
        {
                throw new NullReferenceException();
        }
        
            val_35 = 0;
            if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
            val_14.add(item:  0, weight:  (float)val_36.Item[val_35]);
        }
        else
        {
                if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
        }
        
            int val_27 = val_14.roll(unweighted:  false);
            if(val_27 == 0)
        {
                throw new NullReferenceException();
        }
        
            int val_34 = val_27;
            val_35 = val_27.ToString();
            if(val_2.Item[val_35] == null)
        {
                throw new NullReferenceException();
        }
        
            int val_30 = UnityEngine.Random.Range(min:  0, max:  val_35);
            if(val_34 <= val_30)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_34 = val_34 + (val_30 << 3);
            if(val_27 == 0)
        {
                throw new NullReferenceException();
        }
        
            val_35 = val_27.ToString();
            System.Collections.Generic.List<System.String> val_32 = val_2.Item[val_35];
            if(val_32 == null)
        {
                throw new NullReferenceException();
        }
        
            val_35 = (val_27 + (val_30) << 3) + 32;
            bool val_33 = val_32.Remove(item:  val_35);
            if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
            val_1.Add(item:  (val_27 + (val_30) << 3) + 32);
            val_35 = val_35 + 1;
        }
        while(val_35 < 2);
        
        return val_1;
    }
    private string GetEventProgressText()
    {
        var val_5;
        System.Func<TriviaPursuitCategory, System.Int32> val_7;
        val_5 = null;
        val_5 = null;
        val_7 = TRVTriviaPursuitEventHandler.<>c.<>9__35_0;
        if(val_7 == null)
        {
                System.Func<TriviaPursuitCategory, System.Int32> val_1 = null;
            val_7 = val_1;
            val_1 = new System.Func<TriviaPursuitCategory, System.Int32>(object:  TRVTriviaPursuitEventHandler.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 TRVTriviaPursuitEventHandler.<>c::<GetEventProgressText>b__35_0(TriviaPursuitCategory x));
            TRVTriviaPursuitEventHandler.<>c.<>9__35_0 = val_7;
        }
        
        int val_2 = System.Linq.Enumerable.Sum<TriviaPursuitCategory>(source:  this.eventProgress.SelectedCategories, selector:  val_1);
        TriviaPursuitEcon val_3 = val_2.EventEcon;
        int val_5 = val_3.requirement;
        val_5 = val_5 + (val_5 << 1);
        return (string)System.String.Format(format:  "{0}/{1}", arg0:  val_2, arg1:  val_5);
    }
    private float GetEventProgressValue()
    {
        var val_4;
        System.Func<TriviaPursuitCategory, System.Int32> val_6;
        val_4 = null;
        val_4 = null;
        val_6 = TRVTriviaPursuitEventHandler.<>c.<>9__36_0;
        if(val_6 == null)
        {
                System.Func<TriviaPursuitCategory, System.Int32> val_1 = null;
            val_6 = val_1;
            val_1 = new System.Func<TriviaPursuitCategory, System.Int32>(object:  TRVTriviaPursuitEventHandler.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 TRVTriviaPursuitEventHandler.<>c::<GetEventProgressValue>b__36_0(TriviaPursuitCategory x));
            TRVTriviaPursuitEventHandler.<>c.<>9__36_0 = val_6;
        }
        
        int val_2 = System.Linq.Enumerable.Sum<TriviaPursuitCategory>(source:  this.eventProgress.SelectedCategories, selector:  val_1);
        TriviaPursuitEcon val_3 = val_2.EventEcon;
        int val_4 = val_3.requirement;
        float val_5 = (float)val_2;
        val_4 = val_4 + (val_4 << 1);
        val_5 = val_5 / (float)val_4;
        return (float)val_5;
    }
    private bool IsEventNewCycle()
    {
        return (bool)(this.eventProgress != (X9 + 16)) ? 1 : 0;
    }
    private void ResetEventProgress()
    {
        this.eventProgress = new TriviaPursuitEventProgress();
        mem[1152921517404864576] = System.Void ShortcutExtensions.<>c__DisplayClass56_0::<DOScaleY>b__1(UnityEngine.Vector3 x);
    }
    private void CheckEventGoal()
    {
        if(this.GetEventProgressValue() < 0)
        {
                return;
        }
        
        this.ShowTriviaPursuitRewardPopup();
        this.ResetEventProgress();
        mem2[0] = 1;
        goto typeof(TriviaPursuitEventProgress).__il2cppRuntimeField_180;
    }
    private bool IsEligibleToReroll()
    {
        var val_4;
        System.Predicate<TriviaPursuitCategory> val_6;
        val_4 = null;
        val_4 = null;
        val_6 = TRVTriviaPursuitEventHandler.<>c.<>9__40_0;
        if(val_6 != null)
        {
                return (bool)((this.eventProgress.SelectedCategories.Find(match:  System.Predicate<TriviaPursuitCategory> val_1 = null)) == 0) ? 1 : 0;
        }
        
        val_6 = val_1;
        val_1 = new System.Predicate<TriviaPursuitCategory>(object:  TRVTriviaPursuitEventHandler.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean TRVTriviaPursuitEventHandler.<>c::<IsEligibleToReroll>b__40_0(TriviaPursuitCategory x));
        TRVTriviaPursuitEventHandler.<>c.<>9__40_0 = val_6;
        return (bool)((this.eventProgress.SelectedCategories.Find(match:  val_1)) == 0) ? 1 : 0;
    }
    private TRVTriviaPursuitEventPopupDisplayInfo GetCommonDisplayInfo()
    {
        var val_4;
        var val_5;
        System.Collections.Generic.List<TRVTriviaPursuitCategoryDisplayInfo> val_14;
        var val_15;
        .categories = new System.Collections.Generic.List<TRVTriviaPursuitCategoryDisplayInfo>();
        if(this.eventProgress.SelectedCategories == null)
        {
            goto label_26;
        }
        
        List.Enumerator<T> val_3 = this.eventProgress.SelectedCategories.GetEnumerator();
        label_11:
        if(val_5.MoveNext() == false)
        {
            goto label_4;
        }
        
        TRVTriviaPursuitCategoryDisplayInfo val_7 = null;
        val_15 = 0;
        val_7 = new TRVTriviaPursuitCategoryDisplayInfo();
        if(val_4 == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        .categoryName = val_4 + 16;
        TRVUtils val_8 = MonoSingleton<TRVUtils>.Instance;
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        .categoryIcon = val_8.GetCategoryIcon(category:  val_4 + 16);
        .progress = val_4.GetProgress();
        val_15 = 0;
        .progressText = val_4.GetProgressText();
        val_14 = (TRVTriviaPursuitEventPopupDisplayInfo)[1152921517405303984].categories;
        if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
        val_14.Add(item:  val_7);
        goto label_11;
        label_4:
        val_5.Dispose();
        label_26:
        TriviaPursuitEcon val_12 = val_5.EventEcon;
        .reward = val_12.reward.rewardAmount;
        return (TRVTriviaPursuitEventPopupDisplayInfo)new TRVTriviaPursuitEventPopupDisplayInfo();
    }
    private void ShowTriviaPursuitPopup(bool forceUpdate = False, bool showFlyout = False)
    {
        MetaGameBehavior val_14;
        TRVTriviaPursuitEventPopupDisplayInfo val_1 = this.GetCommonDisplayInfo();
        TRVTriviaPursuitPopupGeneralDisplayInfo val_2 = new TRVTriviaPursuitPopupGeneralDisplayInfo();
        mem[1152921517405520640] = val_1.categories;
        mem[1152921517405520656] = val_1.reward;
        mem[1152921517405520648] = "Complete Levels in select Categories to earn a big reward!";
        TriviaPursuitEcon val_3 = val_2.EventEcon;
        .rerollCost = val_3.rerollCost;
        .isEligibleToReroll = this.IsEligibleToReroll();
        bool val_6 = (this.eventProgress == 0) ? 1 : 0;
        val_6 = val_6 | forceUpdate;
        .shouldAnimateCategories = val_6;
        if(forceUpdate != false)
        {
                MonoSingleton<WGWindowManager>.Instance.GetWindow<TRVTriviaPursuitPopup>().ShowEventPopup(info:  val_2);
            return;
        }
        
        if(showFlyout == false)
        {
            goto label_10;
        }
        
        GameBehavior val_10 = App.getBehavior;
        val_14 = val_10.<metaGameBehavior>k__BackingField;
        if(val_14 != null)
        {
            goto label_15;
        }
        
        label_10:
        GameBehavior val_12 = App.getBehavior;
        val_14 = val_12.<metaGameBehavior>k__BackingField;
        label_15:
        val_14.ShowEventPopup(info:  val_2);
        if(null != null)
        {
                return;
        }
        
        mem2[0] = 1;
        goto typeof(TriviaPursuitEventProgress).__il2cppRuntimeField_180;
    }
    private void ShowTriviaPursuitRewardPopup()
    {
        TRVTriviaPursuitEventPopupDisplayInfo val_1 = this.GetCommonDisplayInfo();
        mem[1152921517405706512] = val_1.categories;
        mem[1152921517405706528] = val_1.reward;
        mem[1152921517405706520] = "Congratulations! Collect your reward!";
        GameBehavior val_3 = App.getBehavior;
        val_3.<metaGameBehavior>k__BackingField.ShowRewardPopup(info:  new TRVTriviaPursuitPopupRewardDisplayInfo());
    }
    public TRVTriviaPursuitEventHandler()
    {
        this.eventProgress = new TriviaPursuitEventProgress();
    }
    private void <RerollAnimateCategories>b__29_0()
    {
        this.ShowTriviaPursuitPopup(forceUpdate:  false, showFlyout:  false);
    }

}
