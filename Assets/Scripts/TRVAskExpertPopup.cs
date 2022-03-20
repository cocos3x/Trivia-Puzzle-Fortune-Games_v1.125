using UnityEngine;
public class TRVAskExpertPopup : MonoBehaviour
{
    // Fields
    private TRVAskExpertDisplay expertPrefab;
    private UnityEngine.UI.Button closeButton;
    private UnityEngine.RectTransform expertListParent;
    private UnityEngine.UI.Text timerText;
    public System.Action onCloseContinueAction;
    public System.Action onRefundAction;
    private bool <forceFree>k__BackingField;
    private UnityEngine.GameObject currentTT;
    
    // Properties
    public bool forceFree { get; set; }
    
    // Methods
    public bool get_forceFree()
    {
        return (bool)this.<forceFree>k__BackingField;
    }
    public void set_forceFree(bool value)
    {
        this.<forceFree>k__BackingField = value;
    }
    private void OnEnable()
    {
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVAskExpertPopup::RefundAndClose()));
        this.SetupPopup();
    }
    private void FixedUpdate()
    {
        TRVGameplayUI val_1 = MonoSingleton<TRVGameplayUI>.Instance;
        string val_2 = val_1.timer.TimeRemainingText();
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void SetupPopup()
    {
        TRVExpert val_21;
        var val_22;
        TRVAskExpertPopup.<>c__DisplayClass12_0 val_48;
        var val_49;
        System.Func<TRVExpert, System.Boolean> val_51;
        var val_52;
        System.Func<TRVExpert, System.Boolean> val_54;
        var val_55;
        System.Func<TRVExpert, System.Boolean> val_57;
        object val_58;
        System.Collections.Generic.Dictionary<System.String, TRVExpertProgressData> val_59;
        string val_60;
        var val_61;
        System.Func<TRVCategoryProficiencies, System.Boolean> val_62;
        TRVExpertProgressData val_63;
        TRVExpertProgressData val_64;
        TRVAskExpertPopup.<>c__DisplayClass12_0 val_1 = new TRVAskExpertPopup.<>c__DisplayClass12_0();
        .<>4__this = this;
        TRVMainController val_2 = MonoSingleton<TRVMainController>.Instance;
        .currentCat = val_2.currentGame.quizCategory;
        .currentCat = MonoSingleton<TRVExpertsController>.Instance.GetOverridenCategoryName(baseName:  (TRVAskExpertPopup.<>c__DisplayClass12_0)[1152921517137544928].currentCat);
        TRVGameplayUI val_5 = MonoSingleton<TRVGameplayUI>.Instance;
        string val_6 = val_5.timer.TimeRemainingText();
        System.Collections.Generic.List<TRVExpert> val_8 = MonoSingleton<TRVExpertsController>.Instance.GetExpertsWithProf(subcat:  (TRVAskExpertPopup.<>c__DisplayClass12_0)[1152921517137544928].currentCat);
        val_48 = 1152921504951042048;
        val_49 = null;
        val_49 = null;
        val_51 = TRVAskExpertPopup.<>c.<>9__12_0;
        if(val_51 == null)
        {
                System.Func<TRVExpert, System.Boolean> val_9 = null;
            val_51 = val_9;
            val_9 = new System.Func<TRVExpert, System.Boolean>(object:  TRVAskExpertPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean TRVAskExpertPopup.<>c::<SetupPopup>b__12_0(TRVExpert x));
            TRVAskExpertPopup.<>c.<>9__12_0 = val_51;
        }
        
        val_52 = null;
        val_52 = null;
        val_54 = TRVAskExpertPopup.<>c.<>9__12_1;
        if(val_54 == null)
        {
                System.Func<TRVExpert, System.Boolean> val_12 = null;
            val_54 = val_12;
            val_12 = new System.Func<TRVExpert, System.Boolean>(object:  TRVAskExpertPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean TRVAskExpertPopup.<>c::<SetupPopup>b__12_1(TRVExpert x));
            TRVAskExpertPopup.<>c.<>9__12_1 = val_54;
        }
        
        val_55 = null;
        val_55 = null;
        val_57 = TRVAskExpertPopup.<>c.<>9__12_3;
        if(val_57 == null)
        {
                System.Func<TRVExpert, System.Boolean> val_17 = null;
            val_57 = val_17;
            val_17 = new System.Func<TRVExpert, System.Boolean>(object:  TRVAskExpertPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean TRVAskExpertPopup.<>c::<SetupPopup>b__12_3(TRVExpert x));
            TRVAskExpertPopup.<>c.<>9__12_3 = val_57;
        }
        
        List.Enumerator<T> val_20 = System.Linq.Enumerable.ToList<TRVExpert>(source:  System.Linq.Enumerable.OrderBy<TRVExpert, System.Boolean>(source:  System.Linq.Enumerable.OrderByDescending<TRVExpert, System.Int32>(source:  System.Linq.Enumerable.ToList<TRVExpert>(source:  System.Linq.Enumerable.Where<TRVExpert>(source:  val_8, predicate:  val_12)), keySelector:  new System.Func<TRVExpert, System.Int32>(object:  val_1, method:  System.Int32 TRVAskExpertPopup.<>c__DisplayClass12_0::<SetupPopup>b__2(TRVExpert x))), keySelector:  val_17)).GetEnumerator();
        val_58 = 1152921504950829056;
        goto label_52;
        label_61:
        TRVAskExpertPopup.<>c__DisplayClass12_1 val_23 = null;
        val_60 = 0;
        val_23 = new TRVAskExpertPopup.<>c__DisplayClass12_1();
        if(val_23 == null)
        {
                throw new NullReferenceException();
        }
        
        .expert = val_21;
        .CS$<>8__locals1 = val_1;
        TRVAskExpertPopup.<>c__DisplayClass12_2 val_24 = null;
        val_60 = 0;
        val_24 = new TRVAskExpertPopup.<>c__DisplayClass12_2();
        if(val_24 == null)
        {
                throw new NullReferenceException();
        }
        
        .CS$<>8__locals2 = val_23;
        if((MonoSingleton<TRVExpertsController>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if(((TRVAskExpertPopup.<>c__DisplayClass12_2)[1152921517137651424].CS$<>8__locals2) == null)
        {
                throw new NullReferenceException();
        }
        
        if(((TRVAskExpertPopup.<>c__DisplayClass12_2)[1152921517137651424].CS$<>8__locals2.expert) == null)
        {
                throw new NullReferenceException();
        }
        
        val_59 = val_25.myExperts;
        if(val_59 == null)
        {
                throw new NullReferenceException();
        }
        
        val_60 = (TRVAskExpertPopup.<>c__DisplayClass12_2)[1152921517137651424].CS$<>8__locals2.expert.expertName;
        if((val_59.ContainsKey(key:  val_60)) == false)
        {
            goto label_40;
        }
        
        if((MonoSingleton<TRVExpertsController>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if(((TRVAskExpertPopup.<>c__DisplayClass12_2)[1152921517137651424].CS$<>8__locals2) == null)
        {
                throw new NullReferenceException();
        }
        
        if(((TRVAskExpertPopup.<>c__DisplayClass12_2)[1152921517137651424].CS$<>8__locals2.expert) == null)
        {
                throw new NullReferenceException();
        }
        
        val_59 = val_27.myExperts;
        if(val_59 == null)
        {
                throw new NullReferenceException();
        }
        
        val_60 = (TRVAskExpertPopup.<>c__DisplayClass12_2)[1152921517137651424].CS$<>8__locals2.expert.expertName;
        TRVExpertProgressData val_28 = val_59.Item[val_60];
        val_61 = val_28;
        if(val_28 == null)
        {
                throw new NullReferenceException();
        }
        
        if(((TRVAskExpertPopup.<>c__DisplayClass12_2)[1152921517137651424].CS$<>8__locals2) == null)
        {
                throw new NullReferenceException();
        }
        
        val_48 = (TRVAskExpertPopup.<>c__DisplayClass12_2)[1152921517137651424].CS$<>8__locals2.CS$<>8__locals1;
        if(val_48 == null)
        {
                throw new NullReferenceException();
        }
        
        val_62 = (TRVAskExpertPopup.<>c__DisplayClass12_2)[1152921517137651424].CS$<>8__locals2.CS$<>8__locals1.<>9__5;
        if(val_62 == null)
        {
                System.Func<TRVCategoryProficiencies, System.Boolean> val_29 = null;
            val_62 = val_29;
            val_29 = new System.Func<TRVCategoryProficiencies, System.Boolean>(object:  val_48, method:  System.Boolean TRVAskExpertPopup.<>c__DisplayClass12_0::<SetupPopup>b__5(TRVCategoryProficiencies x));
            (TRVAskExpertPopup.<>c__DisplayClass12_2)[1152921517137651424].CS$<>8__locals2.CS$<>8__locals1.<>9__5 = val_62;
        }
        
        val_60 = val_62;
        if((System.Linq.Enumerable.FirstOrDefault<TRVCategoryProficiencies>(source:  val_28.<proficiencies>k__BackingField, predicate:  val_29)) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_30.currentPotential == 0)
        {
            goto label_52;
        }
        
        goto label_53;
        label_40:
        val_63 = 0;
        label_53:
        val_60 = this.expertListParent;
        TRVAskExpertDisplay val_31 = UnityEngine.Object.Instantiate<TRVAskExpertDisplay>(original:  this.expertPrefab, parent:  val_60);
        .newExpert = val_31;
        if(((TRVAskExpertPopup.<>c__DisplayClass12_2)[1152921517137651424].CS$<>8__locals2) == null)
        {
                throw new NullReferenceException();
        }
        
        if(((TRVAskExpertPopup.<>c__DisplayClass12_2)[1152921517137651424].CS$<>8__locals2.CS$<>8__locals1) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_31 == null)
        {
                throw new NullReferenceException();
        }
        
        val_31.Init(expert:  (TRVAskExpertPopup.<>c__DisplayClass12_2)[1152921517137651424].CS$<>8__locals2.expert, progData:  val_63, profToDisplay:  (TRVAskExpertPopup.<>c__DisplayClass12_2)[1152921517137651424].CS$<>8__locals2.CS$<>8__locals1.currentCat);
        val_48 = (TRVAskExpertPopup.<>c__DisplayClass12_2)[1152921517137651424].newExpert;
        System.Action val_32 = null;
        val_60 = (TRVAskExpertPopup.<>c__DisplayClass12_2)[1152921517137651424].CS$<>8__locals2;
        val_32 = new System.Action(object:  val_60, method:  System.Void TRVAskExpertPopup.<>c__DisplayClass12_1::<SetupPopup>b__6());
        if(val_48 == null)
        {
                throw new NullReferenceException();
        }
        
        (TRVAskExpertPopup.<>c__DisplayClass12_2)[1152921517137651424].newExpert.onClickAction = val_32;
        System.Action val_33 = null;
        val_57 = val_33;
        val_60 = val_24;
        val_33 = new System.Action(object:  val_24, method:  System.Void TRVAskExpertPopup.<>c__DisplayClass12_2::<SetupPopup>b__7());
        if(((TRVAskExpertPopup.<>c__DisplayClass12_2)[1152921517137651424].newExpert) == null)
        {
                throw new NullReferenceException();
        }
        
        (TRVAskExpertPopup.<>c__DisplayClass12_2)[1152921517137651424].newExpert.onClickSpeedUp = val_57;
        label_52:
        if(val_22.MoveNext() == true)
        {
            goto label_61;
        }
        
        val_22.Dispose();
        List.Enumerator<T> val_35 = System.Linq.Enumerable.ToList<TRVExpert>(source:  System.Linq.Enumerable.Where<TRVExpert>(source:  val_8, predicate:  val_9)).GetEnumerator();
        goto label_84;
        label_93:
        TRVAskExpertPopup.<>c__DisplayClass12_3 val_36 = null;
        val_60 = 0;
        val_36 = new TRVAskExpertPopup.<>c__DisplayClass12_3();
        if(val_36 == null)
        {
                throw new NullReferenceException();
        }
        
        .expert = val_21;
        .CS$<>8__locals3 = val_1;
        TRVAskExpertPopup.<>c__DisplayClass12_4 val_37 = null;
        val_58 = val_37;
        val_60 = 0;
        val_37 = new TRVAskExpertPopup.<>c__DisplayClass12_4();
        if(val_58 == null)
        {
                throw new NullReferenceException();
        }
        
        .CS$<>8__locals4 = val_36;
        if((MonoSingleton<TRVExpertsController>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if(((TRVAskExpertPopup.<>c__DisplayClass12_4)[1152921517137778400].CS$<>8__locals4) == null)
        {
                throw new NullReferenceException();
        }
        
        if(((TRVAskExpertPopup.<>c__DisplayClass12_4)[1152921517137778400].CS$<>8__locals4.expert) == null)
        {
                throw new NullReferenceException();
        }
        
        val_59 = val_38.myExperts;
        if(val_59 == null)
        {
                throw new NullReferenceException();
        }
        
        val_60 = (TRVAskExpertPopup.<>c__DisplayClass12_4)[1152921517137778400].CS$<>8__locals4.expert.expertName;
        if((val_59.ContainsKey(key:  val_60)) == false)
        {
            goto label_72;
        }
        
        if((MonoSingleton<TRVExpertsController>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if(((TRVAskExpertPopup.<>c__DisplayClass12_4)[1152921517137778400].CS$<>8__locals4) == null)
        {
                throw new NullReferenceException();
        }
        
        if(((TRVAskExpertPopup.<>c__DisplayClass12_4)[1152921517137778400].CS$<>8__locals4.expert) == null)
        {
                throw new NullReferenceException();
        }
        
        val_59 = val_40.myExperts;
        if(val_59 == null)
        {
                throw new NullReferenceException();
        }
        
        val_60 = (TRVAskExpertPopup.<>c__DisplayClass12_4)[1152921517137778400].CS$<>8__locals4.expert.expertName;
        TRVExpertProgressData val_41 = val_59.Item[val_60];
        val_64 = val_41;
        if(val_41 == null)
        {
                throw new NullReferenceException();
        }
        
        if(((TRVAskExpertPopup.<>c__DisplayClass12_4)[1152921517137778400].CS$<>8__locals4) == null)
        {
                throw new NullReferenceException();
        }
        
        if(((TRVAskExpertPopup.<>c__DisplayClass12_4)[1152921517137778400].CS$<>8__locals4.CS$<>8__locals3) == null)
        {
                throw new NullReferenceException();
        }
        
        val_48 = (TRVAskExpertPopup.<>c__DisplayClass12_4)[1152921517137778400].CS$<>8__locals4.CS$<>8__locals3.<>9__8;
        val_57 = val_41.<proficiencies>k__BackingField;
        if(val_48 == null)
        {
                System.Func<TRVCategoryProficiencies, System.Boolean> val_42 = null;
            val_48 = val_42;
            val_42 = new System.Func<TRVCategoryProficiencies, System.Boolean>(object:  (TRVAskExpertPopup.<>c__DisplayClass12_4)[1152921517137778400].CS$<>8__locals4.CS$<>8__locals3, method:  System.Boolean TRVAskExpertPopup.<>c__DisplayClass12_0::<SetupPopup>b__8(TRVCategoryProficiencies x));
            (TRVAskExpertPopup.<>c__DisplayClass12_4)[1152921517137778400].CS$<>8__locals4.CS$<>8__locals3.<>9__8 = val_48;
        }
        
        val_60 = val_48;
        if((System.Linq.Enumerable.FirstOrDefault<TRVCategoryProficiencies>(source:  val_57, predicate:  val_42)) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_43.currentPotential == 0)
        {
            goto label_84;
        }
        
        goto label_85;
        label_72:
        val_64 = 0;
        label_85:
        val_60 = this.expertListParent;
        TRVAskExpertDisplay val_44 = UnityEngine.Object.Instantiate<TRVAskExpertDisplay>(original:  this.expertPrefab, parent:  val_60);
        .newExpert = val_44;
        if(((TRVAskExpertPopup.<>c__DisplayClass12_4)[1152921517137778400].CS$<>8__locals4) == null)
        {
                throw new NullReferenceException();
        }
        
        if(((TRVAskExpertPopup.<>c__DisplayClass12_4)[1152921517137778400].CS$<>8__locals4.CS$<>8__locals3) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_44 == null)
        {
                throw new NullReferenceException();
        }
        
        val_44.Init(expert:  (TRVAskExpertPopup.<>c__DisplayClass12_4)[1152921517137778400].CS$<>8__locals4.expert, progData:  val_64, profToDisplay:  (TRVAskExpertPopup.<>c__DisplayClass12_4)[1152921517137778400].CS$<>8__locals4.CS$<>8__locals3.currentCat);
        System.Action val_45 = null;
        val_60 = (TRVAskExpertPopup.<>c__DisplayClass12_4)[1152921517137778400].CS$<>8__locals4;
        val_45 = new System.Action(object:  val_60, method:  System.Void TRVAskExpertPopup.<>c__DisplayClass12_3::<SetupPopup>b__9());
        if(((TRVAskExpertPopup.<>c__DisplayClass12_4)[1152921517137778400].newExpert) == null)
        {
                throw new NullReferenceException();
        }
        
        (TRVAskExpertPopup.<>c__DisplayClass12_4)[1152921517137778400].newExpert.onClickAction = val_45;
        val_57 = (TRVAskExpertPopup.<>c__DisplayClass12_4)[1152921517137778400].newExpert;
        System.Action val_46 = null;
        val_60 = val_58;
        val_46 = new System.Action(object:  val_37, method:  System.Void TRVAskExpertPopup.<>c__DisplayClass12_4::<SetupPopup>b__10());
        if(val_57 == null)
        {
                throw new NullReferenceException();
        }
        
        (TRVAskExpertPopup.<>c__DisplayClass12_4)[1152921517137778400].newExpert.onClickSpeedUp = val_46;
        label_84:
        if(val_22.MoveNext() == true)
        {
            goto label_93;
        }
        
        val_22.Dispose();
    }
    private void OnClickExpert(TRVExpert exp)
    {
        string val_17;
        int val_18;
        TRVExpertOutcomes val_5 = 0;
        TRVMainController val_1 = MonoSingleton<TRVMainController>.Instance;
        val_17 = MonoSingleton<TRVExpertsController>.Instance.GetOverridenCategoryName(baseName:  val_1.currentGame.quizCategory);
        if((MonoSingleton<TRVExpertsController>.Instance.AskExpert(exp:  exp, subCat:  val_17, result: out  val_5)) == false)
        {
                return;
        }
        
        GameBehavior val_7 = App.getBehavior;
        val_17 = val_7.<metaGameBehavior>k__BackingField;
        TRVEcon val_10 = App.GetGameSpecificEcon<TRVEcon>();
        PowerupEcon val_11 = val_10.PowerupData.Item[2];
        if(App.Player >= val_11.freeLevelLimit)
        {
            goto label_18;
        }
        
        val_18 = 0;
        if(val_17 != null)
        {
            goto label_19;
        }
        
        label_18:
        TRVEcon val_12 = App.GetGameSpecificEcon<TRVEcon>();
        val_18 = val_12.askExpertGemCost;
        label_19:
        val_17.Init(exp:  exp, outcome:  val_5, wasFree:  (val_18 < 1) ? 1 : 0);
        mem2[0] = this.onCloseContinueAction;
        if((val_18 >= 1) && ((this.<forceFree>k__BackingField) != true))
        {
                App.Player.AddGems(amount:  -val_18, source:  "Ask Expert", subsource:  0);
            NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "GemStatViewUpdate");
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClickSpeedUp(TRVExpert exp, TRVAskExpertDisplay button)
    {
        Player val_1 = App.Player;
        TRVExpertsController val_2 = MonoSingleton<TRVExpertsController>.Instance;
        if(val_1._gems < val_2.myEcon.expertSpeedUpCost)
        {
                if(this.currentTT != 0)
        {
                return;
        }
        
            DynamicToolTip val_5 = MonoSingleton<UGUIDynamicPlacementManager>.Instance.PlaceGameObject<DynamicToolTip>(loc:  0);
            this.currentTT = val_5.gameObject;
            val_5.ShowToolTip(objToToolTip:  this.gameObject, text:  "Not enough Gems", topToolTip:  true, displayDuration:  3.5f, width:  0f, height:  0f, tooltipOffsetX:  0f, tooltipOffsetY:  0f, viewportSettings:  0, showGotItButton:  false, gotItCallback:  0, showPick:  true, maxFontSize:  0);
            return;
        }
        
        TRVExpertsController val_9 = MonoSingleton<TRVExpertsController>.Instance;
        App.Player.AddGems(amount:  -val_9.myEcon.expertSpeedUpCost, source:  "ExpertSpeedUp", subsource:  0);
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "GemStatViewUpdate");
        this.OnClickExpert(exp:  exp);
    }
    private void RefundAndClose()
    {
        if(this.onRefundAction != null)
        {
                this.onRefundAction.Invoke();
            this.onRefundAction = 0;
        }
        
        this.Close(resumeGame:  true);
    }
    private void Close(bool resumeGame)
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        if(resumeGame == false)
        {
                return;
        }
        
        if(this.onCloseContinueAction == null)
        {
                return;
        }
        
        this.onCloseContinueAction.Invoke();
    }
    public TRVAskExpertPopup()
    {
    
    }

}
