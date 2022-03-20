using UnityEngine;
public class DailyChallengeTutorialGameplayWindow : MonoBehaviour
{
    // Fields
    private UnityEngine.RectTransform[] maskActionStep1;
    private UnityEngine.RectTransform[] maskActionStep2;
    private System.Collections.Generic.List<UnityEngine.Transform> allowedPoints;
    private float padding;
    private DynamicToolTip TT;
    private string currentTargetWord;
    
    // Properties
    public static int state { get; set; }
    
    // Methods
    public static int get_state()
    {
        DailyChallengeTutorialManager val_1 = MonoSingleton<DailyChallengeTutorialManager>.Instance;
        return (int)val_1._GameplayTutorialStep;
    }
    public static void set_state(int value)
    {
        DailyChallengeTutorialManager val_1 = MonoSingleton<DailyChallengeTutorialManager>.Instance;
        val_1._GameplayTutorialStep = value;
    }
    private void OnEnable()
    {
        DailyChallengeTutorialGameplayWindow.state = 1;
        WordRegion.instance.addOnWordFoundAction(callback:  new System.Action<System.String>(object:  this, method:  System.Void DailyChallengeTutorialGameplayWindow::OnWordFound(string foundWord)));
        UnityEngine.Color val_4 = new UnityEngine.Color(r:  0f, g:  0f, b:  0f, a:  0.45f);
        System.Nullable<UnityEngine.Color> val_5 = new System.Nullable<UnityEngine.Color>(value:  new UnityEngine.Color() {r = val_4.r, g = val_4.g, b = val_4.b, a = val_4.a});
        MonoSingleton<GameMaskOverlay>.Instance.SetOptions(bgColor:  new System.Nullable<UnityEngine.Color>() {HasValue = true}, fadeInDuration:  0.5f, fadeOutDuration:  0.15f);
        UnityEngine.Coroutine val_7 = this.StartCoroutine(routine:  this.ProgressSoon());
    }
    private int LoadCurrentState()
    {
        return 1;
    }
    private void SaveCurrentState()
    {
    
    }
    private void OnWordFound(string foundWord)
    {
        System.Action val_11;
        int val_1 = DailyChallengeTutorialGameplayWindow.state;
        val_1 = val_1 + 1;
        DailyChallengeTutorialGameplayWindow.state = val_1;
        if((System.String.IsNullOrEmpty(value:  this.currentTargetWord)) != true)
        {
                if((System.String.op_Inequality(a:  foundWord, b:  this.currentTargetWord)) != false)
        {
                return;
        }
        
        }
        
        val_11 = 1152921504765632512;
        if((UnityEngine.Object.op_Implicit(exists:  this.TT)) != false)
        {
                this.TT.Dismiss();
        }
        
        if((MonoSingleton<GameMaskOverlay>.Instance) != 0)
        {
                System.Action val_8 = null;
            val_11 = val_8;
            val_8 = new System.Action(object:  this, method:  System.Void DailyChallengeTutorialGameplayWindow::OnOverlayClosed());
            MonoSingleton<GameMaskOverlay>.Instance.CloseOverlay(onClosed:  val_8);
        }
        
        this.StopAllCoroutines();
        UnityEngine.Coroutine val_10 = this.StartCoroutine(routine:  this.ProgressSoon());
    }
    private void OnGotItClicked()
    {
        int val_1 = DailyChallengeTutorialGameplayWindow.state;
        val_1 = val_1 + 1;
        DailyChallengeTutorialGameplayWindow.state = val_1;
        if((UnityEngine.Object.op_Implicit(exists:  this.TT)) != false)
        {
                this.TT.Dismiss();
        }
        
        MonoSingleton<GameMaskOverlay>.Instance.CloseOverlay(onClosed:  new System.Action(object:  this, method:  System.Void DailyChallengeTutorialGameplayWindow::OnOverlayClosed()));
        this.StopAllCoroutines();
        UnityEngine.Coroutine val_6 = this.StartCoroutine(routine:  this.ProgressSoon());
    }
    private System.Collections.IEnumerator ProgressSoon()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new DailyChallengeTutorialGameplayWindow.<ProgressSoon>d__14();
    }
    private void Progress()
    {
        UnityEngine.GameObject val_57;
        var val_58;
        var val_59;
        var val_60;
        string val_61;
        DynamicToolTip val_65;
        var val_66;
        string val_68;
        string val_69;
        var val_70;
        if(MainController.instance != 0)
        {
                MainController val_3 = MainController.instance;
            if(val_3.isGameComplete != false)
        {
                DailyChallengeTutorialGameplayWindow.state = 5;
        }
        
        }
        
        WordRegion val_4 = WordRegion.instance;
        val_57 = 0;
        val_58 = 1152921504893161472;
        GameMaskOverlay val_6 = MonoSingleton<GameMaskOverlay>.Instance;
        WGDailyChallengeMainController val_8 = MonoSingleton<DailyChallengeTutorialGameplayHelper>.Instance.DCMainController;
        int val_9 = DailyChallengeTutorialGameplayWindow.state;
        if(val_9 == 3)
        {
            goto label_22;
        }
        
        if(val_9 == 2)
        {
            goto label_23;
        }
        
        if(val_9 != 1)
        {
            goto label_24;
        }
        
        this.currentTargetWord = (WordRegion.__il2cppRuntimeField_typeHierarchy + (WGDailyChallengeWordRegion.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8 == null ? val_4 : 0 + 456 + 24;
        System.Collections.Generic.List<UnityEngine.Transform> val_10 = null;
        val_59 = val_10;
        val_10 = new System.Collections.Generic.List<UnityEngine.Transform>();
        val_60 = 1152921513396270672;
        val_10.Add(item:  (WordRegion.__il2cppRuntimeField_typeHierarchy + (WGDailyChallengeWordRegion.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8 == null ? val_4 : 0 + 456.transform);
        UnityEngine.RectTransform val_13 = this.GetMaskPan(stepNum:  DailyChallengeTutorialGameplayWindow.state);
        val_61 = 1152921504878731264;
        if((Pan.tappingAllowed + 88 + 24) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_10.Add(item:  Pan.tappingAllowed + 88 + 16 + 32.transform);
        if((Pan.tappingAllowed + 88 + 24) <= 1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_10.Add(item:  Pan.tappingAllowed + 88 + 16 + 40.transform);
        if((Pan.tappingAllowed + 88 + 24) <= 2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_10.Add(item:  Pan.tappingAllowed + 88 + 16 + 48.transform);
        if((Pan.tappingAllowed + 88 + 24) <= 3)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_10.Add(item:  Pan.tappingAllowed + 88 + 16 + 56.transform);
        val_10.Add(item:  val_13);
        UnityEngine.Vector3 val_19 = Pan.tappingAllowed.transform.position;
        val_13.position = new UnityEngine.Vector3() {x = val_19.x, y = val_19.y, z = val_19.z};
        DynamicToolTip val_21 = MonoSingleton<UGUIDynamicPlacementManager>.Instance.PlaceGameObject<DynamicToolTip>(loc:  0);
        this.TT = val_21;
        val_65 = this.TT;
        val_66 = val_21.gameObject;
        UnityEngine.GameObject val_23 = gameObject;
        val_68 = "dc_ftux_gameplay1";
        val_69 = "Play the word IN to collect the SUN or the MOON!";
        goto label_50;
        label_22:
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnEnableAllLetters");
        this.currentTargetWord = "";
        System.Collections.Generic.List<UnityEngine.Transform> val_25 = null;
        val_57 = val_25;
        val_25 = new System.Collections.Generic.List<UnityEngine.Transform>();
        val_25.Add(item:  (WordRegion.__il2cppRuntimeField_typeHierarchy + (WGDailyChallengeWordRegion.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8 == null ? val_4 : 0 + 456.transform);
        UnityEngine.RectTransform val_28 = this.GetMaskPan(stepNum:  DailyChallengeTutorialGameplayWindow.state);
        DynamicToolTip val_30 = MonoSingleton<UGUIDynamicPlacementManager>.Instance.PlaceGameObject<DynamicToolTip>(loc:  0);
        this.TT = val_30;
        val_65 = val_30.gameObject;
        val_61 = Localization.Localize(key:  "dc_ftux_gameplay3", defaultValue:  "Solve the word with the SUN or MOON first to gain more STARS!", useSingularKey:  false);
        this.TT.ShowToolTip(objToToolTip:  val_8.progress_bar_group, text:  val_61, topToolTip:  false, displayDuration:  -1f, width:  800f, height:  300f, tooltipOffsetX:  0f, tooltipOffsetY:  0f, viewportSettings:  0, showGotItButton:  true, gotItCallback:  new System.Action(object:  this, method:  System.Void DailyChallengeTutorialGameplayWindow::OnGotItClicked()), showPick:  false, maxFontSize:  60);
        val_25.Add(item:  val_8.progress_bar_group.transform);
        val_25.Add(item:  val_65.transform);
        val_6.BlockRaycasts = true;
        val_6.Interactable = true;
        val_70 = val_6;
        val_70.ShowOverlay(contentToOverlay:  val_25.ToArray());
        val_58 = 1152921504893161472;
        goto label_93;
        label_23:
        this.currentTargetWord = (WordRegion.__il2cppRuntimeField_typeHierarchy + (WGDailyChallengeWordRegion.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8 == null ? val_4 : 0 + 456 + 24;
        System.Collections.Generic.List<UnityEngine.Transform> val_37 = null;
        val_59 = val_37;
        val_37 = new System.Collections.Generic.List<UnityEngine.Transform>();
        val_60 = 1152921513396270672;
        val_37.Add(item:  (WordRegion.__il2cppRuntimeField_typeHierarchy + (WGDailyChallengeWordRegion.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8 == null ? val_4 : 0 + 456.transform);
        UnityEngine.RectTransform val_40 = this.GetMaskPan(stepNum:  DailyChallengeTutorialGameplayWindow.state);
        val_61 = 1152921504878731264;
        if((Pan.tappingAllowed + 88 + 24) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_37.Add(item:  Pan.tappingAllowed + 88 + 16 + 32.transform);
        if((Pan.tappingAllowed + 88 + 24) <= 1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_37.Add(item:  Pan.tappingAllowed + 88 + 16 + 40.transform);
        if((Pan.tappingAllowed + 88 + 24) <= 2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_37.Add(item:  Pan.tappingAllowed + 88 + 16 + 48.transform);
        if((Pan.tappingAllowed + 88 + 24) <= 3)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_37.Add(item:  Pan.tappingAllowed + 88 + 16 + 56.transform);
        val_37.Add(item:  val_40);
        UnityEngine.Vector3 val_46 = Pan.tappingAllowed.transform.position;
        val_40.position = new UnityEngine.Vector3() {x = val_46.x, y = val_46.y, z = val_46.z};
        DynamicToolTip val_48 = MonoSingleton<UGUIDynamicPlacementManager>.Instance.PlaceGameObject<DynamicToolTip>(loc:  0);
        this.TT = val_48;
        val_65 = this.TT;
        val_66 = val_48.gameObject;
        val_68 = "dc_ftux_gameplay2";
        val_69 = "Great! Now play the word TIN.";
        label_50:
        val_57 = gameObject;
        val_65.ShowToolTip(objToToolTip:  val_57, text:  Localization.Localize(key:  val_68, defaultValue:  val_69, useSingularKey:  false), topToolTip:  false, displayDuration:  -1f, width:  800f, height:  300f, tooltipOffsetX:  0f, tooltipOffsetY:  0f, viewportSettings:  0, showGotItButton:  false, gotItCallback:  0, showPick:  false, maxFontSize:  60);
        val_37.Add(item:  val_66.transform);
        val_70 = val_6;
        val_70.ShowOverlay(contentToOverlay:  val_37.ToArray());
        goto label_93;
        label_24:
        val_70 = this;
        this.CloseWindow();
        label_93:
        if(DailyChallengeTutorialGameplayWindow.state != 1)
        {
                if(DailyChallengeTutorialGameplayWindow.state != 2)
        {
                return;
        }
        
        }
        
        MonoSingleton<GameMaskOverlay>.Instance.BlockRaycasts = false;
    }
    private void CloseWindow()
    {
        this.TT.Dismiss();
        MonoSingleton<GameMaskOverlay>.Instance.CloseOverlay(forceImmediate:  true, onClosed:  new System.Action(object:  this, method:  System.Void DailyChallengeTutorialGameplayWindow::OnOverlayClosed()));
        MonoSingleton<DailyChallengeTutorialGameplayHelper>.Instance.HandleGameplayTutorialComplete();
        WordRegion.instance.removeOnWordFoundAction(callback:  new System.Action<System.String>(object:  this, method:  System.Void DailyChallengeTutorialGameplayWindow::OnWordFound(string foundWord)));
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnOverlayClosed()
    {
    
    }
    private UnityEngine.RectTransform GetMaskWordRegion(int stepNum)
    {
        UnityEngine.RectTransform val_1;
        if(stepNum == 2)
        {
            goto label_0;
        }
        
        if(stepNum != 1)
        {
            goto label_1;
        }
        
        label_5:
        val_1 = this.maskActionStep1[0];
        return (UnityEngine.RectTransform)val_1;
        label_0:
        if(this.maskActionStep2 != null)
        {
            goto label_5;
        }
        
        throw new NullReferenceException();
        label_1:
        val_1 = 0;
        return (UnityEngine.RectTransform)val_1;
    }
    private UnityEngine.RectTransform GetMaskPan(int stepNum)
    {
        UnityEngine.RectTransform val_1;
        if(stepNum == 2)
        {
            goto label_0;
        }
        
        if(stepNum != 1)
        {
            goto label_1;
        }
        
        label_5:
        val_1 = this.maskActionStep1[1];
        return (UnityEngine.RectTransform)val_1;
        label_0:
        if(this.maskActionStep2 != null)
        {
            goto label_5;
        }
        
        throw new NullReferenceException();
        label_1:
        val_1 = 0;
        return (UnityEngine.RectTransform)val_1;
    }
    public DailyChallengeTutorialGameplayWindow()
    {
        this.allowedPoints = new System.Collections.Generic.List<UnityEngine.Transform>();
        this.padding = 45f;
    }

}
