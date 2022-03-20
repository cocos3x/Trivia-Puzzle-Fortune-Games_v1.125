using UnityEngine;
public class TRVHintReminderController : MonoSingleton<TRVHintReminderController>
{
    // Fields
    private const string numShownLookupKey = "hintReminderNum";
    
    // Properties
    private int lastLevelSeen { get; set; }
    private int numTimesSeen { get; set; }
    
    // Methods
    private int get_lastLevelSeen()
    {
        return CPlayerPrefs.GetInt(key:  "lastPowerupUsedLevel", defaultValue:  0);
    }
    private void set_lastLevelSeen(int value)
    {
        CPlayerPrefs.SetInt(key:  "lastPowerupUsedLevel", val:  value);
    }
    private int get_numTimesSeen()
    {
        return CPlayerPrefs.GetInt(key:  "hintReminderNum", defaultValue:  0);
    }
    private void set_numTimesSeen(int value)
    {
        CPlayerPrefs.SetInt(key:  "hintReminderNum", val:  value);
    }
    private void OnEnable()
    {
        TRVEcon val_1 = App.GetGameSpecificEcon<TRVEcon>();
        if(val_1.hintReminderEnabled == false)
        {
                return;
        }
        
        UnityEngine.SceneManagement.SceneManager.add_activeSceneChanged(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.Scene>(object:  this, method:  System.Void TRVHintReminderController::OnSceneChanged(UnityEngine.SceneManagement.Scene outgoingScene, UnityEngine.SceneManagement.Scene incomingScene)));
    }
    private void OnSceneChanged(UnityEngine.SceneManagement.Scene outgoingScene, UnityEngine.SceneManagement.Scene incomingScene)
    {
        System.Action<TRVQuizProgress> val_8;
        TRVEcon val_1 = App.GetGameSpecificEcon<TRVEcon>();
        if(val_1.hintReminderEnabled == false)
        {
                return;
        }
        
        GameBehavior val_2 = App.getBehavior;
        if((val_2.<metaGameBehavior>k__BackingField) != 2)
        {
                return;
        }
        
        val_8 = 1152921504893161472;
        if((MonoSingleton<TRVMainController>.Instance) == 0)
        {
                return;
        }
        
        TRVMainController val_5 = MonoSingleton<TRVMainController>.Instance;
        val_8 = val_5.OnQuestionBegin;
        System.Delegate val_7 = System.Delegate.Combine(a:  val_8, b:  new System.Action<TRVQuizProgress>(object:  this, method:  System.Void TRVHintReminderController::OnQuestionBegin(TRVQuizProgress prog)));
        if(val_7 != null)
        {
                if(null != null)
        {
            goto label_19;
        }
        
        }
        
        val_5.OnQuestionBegin = val_7;
        return;
        label_19:
    }
    private void OnQuestionBegin(TRVQuizProgress prog)
    {
        var val_12;
        TRVQuizProgress val_13;
        var val_14;
        val_13 = this;
        if(this.CheckValid() == false)
        {
                return;
        }
        
        val_12 = 1152921504960839680;
        val_14 = null;
        val_14 = null;
        if(TRVMainController.noAnswerSelectedCharacter != null)
        {
                return;
        }
        
        val_12 = 1152921517052171200;
        TRVEcon val_3 = App.GetGameSpecificEcon<TRVEcon>();
        if(numTimesSeen >= val_3.hintReminderMaxViews)
        {
                return;
        }
        
        Player val_4 = App.Player;
        val_12 = val_4.lastLevelSeen;
        TRVEcon val_6 = App.GetGameSpecificEcon<TRVEcon>();
        if((val_4 - val_12) < val_6.hintReminderLevelInterval)
        {
                return;
        }
        
        this.ShowPopup();
        TRVMainController val_8 = MonoSingleton<TRVMainController>.Instance;
        val_13 = val_8.currentGame;
        val_13.InjectTrackingInfo(key:  "Hint Reminder", value:  true);
        int val_9 = val_13.numTimesSeen;
        val_9.numTimesSeen = val_9 + 1;
        Player val_11 = App.Player;
        val_11.lastLevelSeen = val_11;
        CPlayerPrefs.Save();
    }
    private void ShowPopup()
    {
        TRVPowerupButton val_21;
        var val_22;
        var val_35;
        var val_36;
        TRVPowerupButton val_37;
        object val_38;
        if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                val_35 = 1152921504960839680;
            val_36 = null;
            val_36 = null;
            if(TRVMainController.QAHACK_HURRY == true)
        {
                return;
        }
        
        }
        
        GameBehavior val_3 = App.getBehavior;
        System.Collections.Generic.List<TRVPowerupButton> val_7 = MonoSingleton<TRVGameplayUI>.Instance.getPowerupButtons;
        if(null == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        UnityEngine.Vector3 val_9 = MonoSingleton<T>.__il2cppRuntimeField_byval_arg.transform.position;
        val_3.<metaGameBehavior>k__BackingField.transform.position = new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z};
        UnityEngine.Color val_11 = new UnityEngine.Color(r:  0f, g:  0f, b:  0f, a:  0.45f);
        System.Nullable<UnityEngine.Color> val_12 = new System.Nullable<UnityEngine.Color>(value:  new UnityEngine.Color() {r = val_11.r, g = val_11.g, b = val_11.b, a = val_11.a});
        MonoSingleton<GameMaskOverlay>.Instance.SetOptions(bgColor:  new System.Nullable<UnityEngine.Color>() {HasValue = true}, fadeInDuration:  0.25f, fadeOutDuration:  0.15f);
        MonoSingleton<GameMaskOverlay>.Instance.BlockRaycasts = true;
        MonoSingleton<GameMaskOverlay>.Instance.Interactable = true;
        System.Collections.Generic.List<UnityEngine.Transform> val_15 = new System.Collections.Generic.List<UnityEngine.Transform>();
        val_15.Add(item:  val_3.<metaGameBehavior>k__BackingField.gameObject.transform);
        List.Enumerator<T> val_20 = MonoSingleton<TRVGameplayUI>.Instance.getPowerupButtons.GetEnumerator();
        label_40:
        label_39:
        if(val_22.MoveNext() == false)
        {
            goto label_30;
        }
        
        TRVHintReminderController.<>c__DisplayClass10_0 val_24 = null;
        val_38 = 0;
        val_24 = new TRVHintReminderController.<>c__DisplayClass10_0();
        if(val_24 == null)
        {
                throw new NullReferenceException();
        }
        
        val_37 = val_21;
        .powerupButton = val_37;
        .<>4__this = this;
        if(val_37 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_38 = mem[val_21 + 400 + 8];
        val_38 = val_21 + 400 + 8;
        if(val_37 == 0)
        {
                throw new NullReferenceException();
        }
        
        mem2[0] = 1;
        val_37 = (TRVHintReminderController.<>c__DisplayClass10_0)[1152921517268585520].powerupButton;
        if(val_37 == null)
        {
                throw new NullReferenceException();
        }
        
        val_37.UpdateButton();
        System.Action val_25 = null;
        val_38 = val_24;
        val_25 = new System.Action(object:  val_24, method:  System.Void TRVHintReminderController.<>c__DisplayClass10_0::<ShowPopup>b__0());
        if(((TRVHintReminderController.<>c__DisplayClass10_0)[1152921517268585520].powerupButton) == null)
        {
                throw new NullReferenceException();
        }
        
        (TRVHintReminderController.<>c__DisplayClass10_0)[1152921517268585520].powerupButton.supplmentalOneTimeOnClickAction = val_25;
        val_37 = (TRVHintReminderController.<>c__DisplayClass10_0)[1152921517268585520].powerupButton;
        if(val_37 == null)
        {
                throw new NullReferenceException();
        }
        
        val_15.Add(item:  val_37.transform);
        if(((TRVHintReminderController.<>c__DisplayClass10_0)[1152921517268585520].powerupButton) == null)
        {
            goto label_39;
        }
        
        UnityEngine.Transform val_27 = (TRVHintReminderController.<>c__DisplayClass10_0)[1152921517268585520].powerupButton.transform;
        goto label_40;
        label_30:
        val_22.Dispose();
        MonoSingleton<GameMaskOverlay>.Instance.ShowOverlay(contentToOverlay:  val_15.ToArray());
        val_35 = val_3.<metaGameBehavior>k__BackingField.transform;
        UnityEngine.Vector3 val_32 = 0.transform.position;
        val_35.position = new UnityEngine.Vector3() {x = val_32.x, y = val_32.y, z = val_32.z};
        MonoSingleton<TRVGameplayUI>.Instance.StopTimer();
    }
    private void OnReminderHintUsed(TRVPowerupButton pressedButton)
    {
        UnityEngine.Object val_5;
        var val_6;
        var val_18;
        object val_19;
        System.Action val_20;
        TRVHintReminderController.<>c__DisplayClass11_0 val_1 = null;
        val_19 = 0;
        val_1 = new TRVHintReminderController.<>c__DisplayClass11_0();
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        .<>4__this = this;
        .pressedButton = pressedButton;
        TRVGameplayUI val_2 = MonoSingleton<TRVGameplayUI>.Instance;
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        val_19 = 0;
        System.Collections.Generic.List<TRVPowerupButton> val_3 = val_2.getPowerupButtons;
        if(val_3 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_4 = val_3.GetEnumerator();
        label_29:
        val_19 = public System.Boolean List.Enumerator<TRVPowerupButton>::MoveNext();
        if(val_6.MoveNext() == false)
        {
            goto label_6;
        }
        
        if(val_5 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19 = mem[val_5 + 400 + 8];
        val_19 = val_5 + 400 + 8;
        val_18 = val_5;
        if(val_18 == 0)
        {
                throw new NullReferenceException();
        }
        
        mem2[0] = 0;
        mem2[0] = 0;
        WGFlyoutManager val_8 = MonoSingleton<WGFlyoutManager>.Instance;
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        val_19 = public System.Boolean SLCWindowManager<WGFlyoutManager>::ShowingWindow<TRVAskExpertPopup>();
        if((val_8.ShowingWindow<TRVAskExpertPopup>()) != false)
        {
                WGFlyoutManager val_10 = MonoSingleton<WGFlyoutManager>.Instance;
            if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
            TRVAskExpertPopup val_11 = val_10.GetComponent<TRVAskExpertPopup>();
            if(val_11 != 0)
        {
                val_20 = (TRVHintReminderController.<>c__DisplayClass11_0)[1152921517268840880].<>9__1;
            if(val_20 == null)
        {
                System.Action val_13 = null;
            val_20 = val_13;
            val_19 = val_1;
            val_13 = new System.Action(object:  val_1, method:  System.Void TRVHintReminderController.<>c__DisplayClass11_0::<OnReminderHintUsed>b__1());
            .<>9__1 = val_20;
        }
        
            if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
            val_11.onRefundAction = val_20;
        }
        else
        {
                if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        }
        
            val_11.<forceFree>k__BackingField = true;
        }
        
        if(val_5 == ((TRVHintReminderController.<>c__DisplayClass11_0)[1152921517268840880].pressedButton))
        {
            goto label_29;
        }
        
        val_5.UpdateButton();
        goto label_29;
        label_6:
        val_6.Dispose();
        GameMaskOverlay val_15 = MonoSingleton<GameMaskOverlay>.Instance;
        System.Action val_16 = null;
        val_19 = val_1;
        val_16 = new System.Action(object:  val_1, method:  System.Void TRVHintReminderController.<>c__DisplayClass11_0::<OnReminderHintUsed>b__0());
        if(val_15 == null)
        {
                throw new NullReferenceException();
        }
        
        val_15.CloseOverlay(forceImmediate:  true, onClosed:  val_16);
    }
    private bool CheckValid()
    {
        int val_8;
        var val_9;
        TRVEcon val_1 = App.GetGameSpecificEcon<TRVEcon>();
        if(val_1.hintReminderEnabled != false)
        {
                val_8 = App.Player;
            TRVEcon val_3 = App.GetGameSpecificEcon<TRVEcon>();
            bool val_4 = GameEcon.IsEnabledAndLevelMet(playerLevel:  val_8, knobValue:  val_3.hintReminderUnlockLevel);
            if(val_4 != false)
        {
                val_8 = val_4.numTimesSeen;
            TRVEcon val_6 = App.GetGameSpecificEcon<TRVEcon>();
            var val_7 = (val_8 < val_6.hintReminderMaxViews) ? 1 : 0;
            return (bool)val_9;
        }
        
        }
        
        val_9 = 0;
        return (bool)val_9;
    }
    private void OnDestroy()
    {
        UnityEngine.SceneManagement.SceneManager.remove_activeSceneChanged(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.Scene>(object:  this, method:  System.Void TRVHintReminderController::OnSceneChanged(UnityEngine.SceneManagement.Scene outgoingScene, UnityEngine.SceneManagement.Scene incomingScene)));
    }
    public TRVHintReminderController()
    {
    
    }

}
