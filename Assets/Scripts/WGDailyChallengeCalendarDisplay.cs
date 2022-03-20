using UnityEngine;
public class WGDailyChallengeCalendarDisplay : UGUICalendarDisplay
{
    // Fields
    private WGDailyChallengePhaseBtn morningButton;
    private WGDailyChallengePhaseBtn eveningButton;
    private UnityEngine.UI.Button tooltipButton;
    private WGDailyChallengeCalendarDayDisplay lastClickedDay;
    private UnityEngine.Coroutine showTooltipCoroutine;
    private UnityEngine.Coroutine closeTooltipCoroutine;
    private DynamicToolTip tooltip;
    
    // Methods
    private void Awake()
    {
        this.tooltipButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGDailyChallengeCalendarDisplay::OnCloseTooltip()));
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "RefreshDailyChallengeCalendar");
    }
    public override void Setup(int month, int year, bool selectToday = False)
    {
        DailyChallenge_DayProgress val_25;
        if(true != 0)
        {
                if(38021 > 0)
        {
            goto label_2;
        }
        
        }
        
        this.InstantiateDayPrefabs();
        label_2:
        System.DateTime val_1 = DateTimeCheat.Now;
        WGDailyChallengeManager val_2 = MonoSingleton<WGDailyChallengeManager>.Instance;
        val_2.<Status>k__BackingField.todayOnCalendar = val_1.dateData.Day;
        WGDailyChallengeManager val_4 = MonoSingleton<WGDailyChallengeManager>.Instance;
        val_4.<Status>k__BackingField.playingMonth = val_1.dateData.Month;
        System.Globalization.GregorianCalendar val_6 = new System.Globalization.GregorianCalendar();
        System.DateTime val_8 = new System.DateTime(year:  year, month:  month, day:  1);
        if(this.DaysInGrid < 1)
        {
            goto label_12;
        }
        
        var val_34 = 0;
        goto label_67;
        label_52:
        WGDailyChallengeManager val_12 = MonoSingleton<WGDailyChallengeManager>.Instance;
        if((val_12.<Status>k__BackingField.playingDay) != 1)
        {
            goto label_26;
        }
        
        if(val_34 >= 38021)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_26 = 16824064;
        val_26 = val_26 + 0;
        System.DateTime val_13 = DateTimeCheat.Now;
        if(((16824064 + 0) + 32 + 84) == val_13.dateData.Day)
        {
            goto label_24;
        }
        
        goto label_26;
        label_63:
        val_6.Invoke(arg1:  null, arg2:  false);
        goto label_26;
        label_67:
        if(val_34 >= (-1308312752))
        {
            goto label_27;
        }
        
        if(val_34 >= 38021)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_28 = 16824064;
        val_28 = val_28 + 0;
        goto label_31;
        label_27:
        if(val_34 >= ((long)val_6 + (val_6.GetDaysInMonth(year:  year, month:  month))))
        {
            goto label_32;
        }
        
        WGDailyChallengeManager val_16 = MonoSingleton<WGDailyChallengeManager>.Instance;
        DailyChallenge_DayProgress val_17 = null;
        val_25 = val_17;
        val_17 = new DailyChallenge_DayProgress();
        System.Globalization.GregorianCalendar val_18 = (-1152921516183436111) + val_34;
        if((val_16.monthHistory.progress.ContainsKey(key:  val_18.ToString())) != false)
        {
                val_25 = val_16.monthHistory.progress.Item[val_18.ToString()];
        }
        
        if(val_34 >= val_16.monthHistory.tile)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        int val_29 = val_16.monthHistory.stars;
        val_29 = val_29 + 0;
        (val_16.monthHistory.stars + 0) + 32.Setup(day:  val_18, month:  month, year:  year, selectCurrentDate:  selectToday, dayProgress:  val_25);
        if(val_34 >= val_16.monthHistory.tile)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        int val_30 = val_16.monthHistory.stars;
        val_30 = val_30 + 0;
        WGDailyChallengeManager val_23 = MonoSingleton<WGDailyChallengeManager>.Instance;
        if(((val_16.monthHistory.stars + 0) + 32 + 84) != (val_23.<Status>k__BackingField.playingDay))
        {
            goto label_52;
        }
        
        label_24:
        if(val_34 >= ((val_16.monthHistory.stars + 0) + 32 + 84 + 24))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_31 = (val_16.monthHistory.stars + 0) + 32 + 84 + 16;
        val_31 = val_31 + 0;
        if(val_34 >= ((val_16.monthHistory.stars + 0) + 32 + 84 + 24))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_32 = (val_16.monthHistory.stars + 0) + 32 + 84 + 16;
        val_32 = val_32 + 0;
        if((((val_16.monthHistory.stars + 0) + 32 + 84 + 16 + 0) + 32) == 0)
        {
            goto label_63;
        }
        
        goto label_63;
        label_32:
        if(val_34 >= 38021)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_33 = 16824064;
        val_33 = val_33 + 0;
        label_31:
        label_26:
        val_34 = val_34 + 1;
        if(val_34 < (this.DaysInGrid << ))
        {
            goto label_67;
        }
        
        label_12:
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "HandleTooltipReadyToShow");
    }
    public void HandleTooltipShowing()
    {
        this.StopTooltipCoroutines();
        this.DestroyTooltip();
        this.showTooltipCoroutine = this.StartCoroutine(routine:  this.ShowTooltipCoroutine());
    }
    private void OnDayClicked(WGDailyChallengeCalendarDayDisplay dayClicked, bool showingTooltip = False)
    {
        WGDailyChallengeManager val_1 = MonoSingleton<WGDailyChallengeManager>.Instance;
        if(dayClicked == 0)
        {
                return;
        }
        
        WGDailyChallengeManager val_3 = MonoSingleton<WGDailyChallengeManager>.Instance;
        val_3.<Status>k__BackingField.playingDay = UnityEngine.Object.__il2cppRuntimeField_12F;
        1152921515401808240 = Localization.Localize(key:  (val_3.<Status>k__BackingField + (UnityEngine.Object.__il2cppRuntimeField_12F) << 3).lastPlayedLevel, defaultValue:  (val_3.<Status>k__BackingField + (UnityEngine.Object.__il2cppRuntimeField_12F) << 3).lastPlayedLevel, useSingularKey:  false).ToUpper();
        string val_6 = System.String.Format(format:  "{0} {1}", arg0:  1152921515401808240, arg1:  (val_3.<Status>k__BackingField + (UnityEngine.Object.__il2cppRuntimeField_12F) << 3));
        if(this.lastClickedDay != 0)
        {
                if(this.lastClickedDay != dayClicked)
        {
                this.lastClickedDay.ResetUI();
        }
        
        }
        
        this.lastClickedDay = dayClicked;
        if(showingTooltip != true)
        {
                this.StopTooltipCoroutines();
            this.DestroyTooltip();
        }
        
        this.morningButton.UpdateUIForTodaysChallenge();
        this.eveningButton.UpdateUIForTodaysChallenge();
    }
    private void OnCloseTooltip()
    {
        var val_3;
        this.StopTooltipCoroutines();
        this.DestroyTooltip();
        this.tooltipButton.gameObject.SetActive(value:  false);
        val_3 = null;
        val_3 = null;
        WGDailyChallengeV2Popup.onMainScreenBtnClicked = 0;
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "DisableScreenButton");
    }
    private void StopTooltipCoroutines()
    {
        if(this.showTooltipCoroutine != null)
        {
                this.StopCoroutine(routine:  this.showTooltipCoroutine);
        }
        
        if(this.closeTooltipCoroutine == null)
        {
                return;
        }
        
        this.StopCoroutine(routine:  this.closeTooltipCoroutine);
    }
    private System.Collections.IEnumerator ShowTooltipCoroutine()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGDailyChallengeCalendarDisplay.<ShowTooltipCoroutine>d__13();
    }
    private System.Collections.IEnumerator CloseTooltipCoroutine()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGDailyChallengeCalendarDisplay.<CloseTooltipCoroutine>d__14();
    }
    private void DestroyTooltip()
    {
        if(this.tooltip == 0)
        {
                return;
        }
        
        UnityEngine.Object.Destroy(obj:  this.tooltip.gameObject);
    }
    private WGDailyChallengeCalendarDayDisplay ShowTooltip()
    {
        DynamicToolTip val_18;
        var val_19;
        System.Func<UGUICalendarDayDisplay, System.Boolean> val_21;
        var val_22;
        val_18 = this;
        int val_2 = MonoSingleton<WGDailyChallengeManager>.Instance.GetMatchingDayDistance();
        if(val_2 != 0)
        {
                val_19 = null;
            val_19 = null;
            val_21 = WGDailyChallengeCalendarDisplay.<>c.<>9__16_0;
            if(val_21 == null)
        {
                System.Func<UGUICalendarDayDisplay, System.Boolean> val_3 = null;
            val_21 = val_3;
            val_3 = new System.Func<UGUICalendarDayDisplay, System.Boolean>(object:  WGDailyChallengeCalendarDisplay.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WGDailyChallengeCalendarDisplay.<>c::<ShowTooltip>b__16_0(UGUICalendarDayDisplay x));
            WGDailyChallengeCalendarDisplay.<>c.<>9__16_0 = val_21;
        }
        
            UGUICalendarDayDisplay val_5 = System.Linq.Enumerable.First<UGUICalendarDayDisplay>(source:  System.Linq.Enumerable.Where<UGUICalendarDayDisplay>(source:  X21, predicate:  val_3));
            UnityEngine.Transform val_11 = val_5.transform.parent.GetChild(index:  val_5.transform.GetSiblingIndex() + val_2);
            this.tooltip = MonoSingleton<UGUIDynamicPlacementManager>.Instance.PlaceGameObject<DynamicToolTip>(loc:  0);
            .minX = ;
            .maxX = ;
            .minY = 0.025f;
            .maxY = 0.95f;
            val_18 = this.tooltip;
            val_18.ShowToolTip(objToToolTip:  val_11.gameObject, text:  Localization.Localize(key:  "tap_to_replay_previous_challenges", defaultValue:  "Tap to replay previous challenges!", useSingularKey:  false), topToolTip:  true, displayDuration:  5f, width:  1000f, height:  0f, tooltipOffsetX:  0f, tooltipOffsetY:  0f, viewportSettings:  new PopupViewportSettings(), showGotItButton:  false, gotItCallback:  0, showPick:  true, maxFontSize:  0);
            WGDailyChallengeCalendarDayDisplay val_17 = val_11.GetComponent<WGDailyChallengeCalendarDayDisplay>();
            return (WGDailyChallengeCalendarDayDisplay)val_22;
        }
        
        val_22 = 0;
        return (WGDailyChallengeCalendarDayDisplay)val_22;
    }
    private void InstantiateDayPrefabs()
    {
        if(this.DaysInGrid < 1)
        {
                return;
        }
        
        do
        {
            UnityEngine.GameObject val_2 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  X21, parent:  41963520);
            val_2.name = System.String.Format(format:  "{0}{1}", arg0:  0.ToString(format:  "00"), arg1:  "_instanced");
            System.Delegate val_7 = System.Delegate.Combine(a:  val_5.OnClicked, b:  new System.Action<WGDailyChallengeCalendarDayDisplay, System.Boolean>(object:  this, method:  System.Void WGDailyChallengeCalendarDisplay::OnDayClicked(WGDailyChallengeCalendarDayDisplay dayClicked, bool showingTooltip)));
            if(val_7 != null)
        {
                if(null != null)
        {
            goto label_7;
        }
        
        }
        
            val_5.OnClicked = val_7;
            val_7.Add(item:  val_2.GetComponent<WGDailyChallengeCalendarDayDisplay>());
        }
        while(1 < this.DaysInGrid);
        
        return;
        label_7:
    }
    private void RefreshDailyChallengeCalendar()
    {
        WGDailyChallengeManager val_1 = MonoSingleton<WGDailyChallengeManager>.Instance;
        val_1.HandleDayRollover();
        MethodExtensionForMonoBehaviourTransform.DestroyChildren(t:  val_1);
        mem[1152921516185034624] = new System.Collections.Generic.List<UGUICalendarDayDisplay>();
        System.DateTime val_3 = DateTimeCheat.Now;
        int val_4 = val_3.dateData.Month;
        int val_5 = val_3.dateData.Year;
    }
    public WGDailyChallengeCalendarDisplay()
    {
    
    }

}
