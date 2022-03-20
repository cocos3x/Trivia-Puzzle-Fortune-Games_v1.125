using UnityEngine;
public class ToggleEnabledByPlayerLevel : MonoBehaviour
{
    // Fields
    public const string ON_REFRESH_NOTIFICATION = "OnRefreshNotification";
    private int unlockLevel;
    private bool enableAtLevel;
    private bool awake;
    private bool start;
    private bool enable;
    private UnityEngine.GameObject target;
    private bool ToggleInDailyChallenge;
    private bool hideInFTUX;
    private UnityEngine.UI.Button[] _childButtons;
    
    // Properties
    public int getLevelReq { get; }
    private UnityEngine.UI.Button[] GetChildButtons { get; }
    
    // Methods
    public int get_getLevelReq()
    {
        return (int)this.unlockLevel;
    }
    private UnityEngine.UI.Button[] get_GetChildButtons()
    {
        if(this._childButtons != null)
        {
                return (UnityEngine.UI.Button[])val_1;
        }
        
        T[] val_1 = this.target.GetComponentsInChildren<UnityEngine.UI.Button>(includeInactive:  true);
        this._childButtons = val_1;
        return (UnityEngine.UI.Button[])val_1;
    }
    private void Awake()
    {
        if(this.target == 0)
        {
                this.target = this.gameObject;
        }
        
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnRefreshNotification");
        if(this.awake == false)
        {
                return;
        }
        
        this.DoUnlockLogic();
    }
    private void Start()
    {
        if(this.start == false)
        {
                return;
        }
        
        this.DoUnlockLogic();
    }
    private void OnEnable()
    {
        if(this.enable == false)
        {
                return;
        }
        
        this.DoUnlockLogic();
    }
    private void DoUnlockLogic()
    {
        var val_17;
        var val_18;
        if(WGFTUXManager.IsShowing != true)
        {
                if(WGFTUXManager.CanShow == false)
        {
            goto label_3;
        }
        
        }
        
        if(this.hideInFTUX == false)
        {
            goto label_3;
        }
        
        label_17:
        val_17 = 0;
        goto label_5;
        label_3:
        if(this.ToggleInDailyChallenge == true)
        {
            goto label_6;
        }
        
        val_18 = 1152921504893161472;
        if((MonoSingleton<WGDailyChallengeManager>.Instance) != 0)
        {
                if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false)
        {
                if(this.target.gameObject != null)
        {
            goto label_17;
        }
        
        }
        
        }
        
        if(this.ToggleInDailyChallenge == false)
        {
            goto label_29;
        }
        
        label_6:
        if(this.hideInFTUX != false)
        {
                val_18 = 1152921504893161472;
            if((MonoSingleton<DailyChallengeTutorialManager>.Instance) != 0)
        {
                DailyChallengeTutorialManager val_10 = MonoSingleton<DailyChallengeTutorialManager>.Instance;
            if(val_10._TutorialActive != false)
        {
                DailyChallengeTutorialManager val_11 = MonoSingleton<DailyChallengeTutorialManager>.Instance;
            this.MakeChildButtonsInteractable(interactable:  (val_11._GameplayTutorialActive == false) ? 1 : 0);
        }
        
        }
        
        }
        
        label_29:
        if(this.enableAtLevel == false)
        {
            goto label_33;
        }
        
        GameBehavior val_13 = App.getBehavior;
        var val_14 = ((val_13.<metaGameBehavior>k__BackingField) >= this.unlockLevel) ? 1 : 0;
        if(this.target != null)
        {
            goto label_38;
        }
        
        label_33:
        GameBehavior val_15 = App.getBehavior;
        label_38:
        label_5:
        this.target.SetActive(value:  ((val_15.<metaGameBehavior>k__BackingField) < this.unlockLevel) ? 1 : 0);
    }
    public void SetLevelRequirement(int level)
    {
        this.unlockLevel = level;
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) < this.unlockLevel)
        {
            goto label_5;
        }
        
        if(this.enableAtLevel == false)
        {
            goto label_6;
        }
        
        GameBehavior val_2 = App.getBehavior;
        var val_3 = ((val_2.<metaGameBehavior>k__BackingField) >= this.unlockLevel) ? 1 : 0;
        if(this.target != null)
        {
            goto label_11;
        }
        
        label_6:
        GameBehavior val_4 = App.getBehavior;
        label_11:
        this.target.SetActive(value:  ((val_4.<metaGameBehavior>k__BackingField) < this.unlockLevel) ? 1 : 0);
        label_5:
        if(this.ToggleInDailyChallenge == true)
        {
                return;
        }
        
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == false)
        {
                return;
        }
        
        this.gameObject.SetActive(value:  false);
    }
    public void OnRefreshNotification()
    {
        this.DoUnlockLogic();
    }
    private void MakeChildButtonsInteractable(bool interactable)
    {
        UnityEngine.UI.Button[] val_1 = this.GetChildButtons;
        var val_6 = 0;
        do
        {
            if(val_6 >= val_1.Length)
        {
                return;
        }
        
            this.GetChildButtons[val_6].interactable = interactable;
            val_6 = val_6 + 1;
        }
        while(this.GetChildButtons != null);
        
        throw new NullReferenceException();
    }
    public ToggleEnabledByPlayerLevel()
    {
        this.unlockLevel = 1;
        this.enableAtLevel = 1;
        this.start = 1;
        this.ToggleInDailyChallenge = true;
        this.hideInFTUX = true;
    }

}
