using UnityEngine;
public class WGDailyChallengeV2Popup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button CloseBtn;
    private UnityEngine.UI.Button HelpBtn;
    private UnityEngine.UI.Button mainScreenBtn;
    private UnityEngine.GameObject InfoPopup;
    private WGZooTileRewardPopup zooTileRewardPopup;
    private WGDailyChallengeCalendarDisplay calendar;
    private DailyChallengeProgressUI weeklyProgressUI;
    private DailyChallengeProgressUI monthlyProgressUI;
    public static System.Action onMainScreenBtnClicked;
    public static ZooTile newZooTile;
    
    // Methods
    private void Awake()
    {
        this.zooTileRewardPopup.gameObject.SetActive(value:  false);
        this.InfoPopup.SetActive(value:  false);
        this.CloseBtn.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGDailyChallengeV2Popup::ClosePopup()));
        this.HelpBtn.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGDailyChallengeV2Popup::OpenDailyChallengeInfoPopup()));
        this.mainScreenBtn.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGDailyChallengeV2Popup::OnMainScreenButtonClicked()));
        this.DisableScreenButton();
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "EnableScreenButton");
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "DisableScreenButton");
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "HandleTooltipReadyToShow");
    }
    private void OnEnable()
    {
        var val_6;
        ZooTile val_7;
        MonoSingleton<ApplovinMaxPlugin>.Instance.HideBanner();
        val_6 = null;
        val_6 = null;
        val_7 = WGDailyChallengeV2Popup.newZooTile;
        if(val_7 != null)
        {
                val_7 = WGDailyChallengeV2Popup.newZooTile;
            this.OpenZooTileRewardPopup(tile:  val_7);
            WGDailyChallengeV2Popup.newZooTile = 0;
        }
        
        GameBehavior val_2 = App.getBehavior;
        if(((val_2.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                this.weeklyProgressUI.InitializeWeeklyProgress(starsToAnimate:  0);
            this.monthlyProgressUI.InitializeMonthlyProgress(starsToAnimate:  0);
        }
        
        WGDailyChallengeManager val_3 = MonoSingleton<WGDailyChallengeManager>.Instance;
        System.Delegate val_5 = System.Delegate.Combine(a:  val_3.OnWeeklyMonthlyRewardCollected, b:  new System.Action(object:  this, method:  System.Void WGDailyChallengeV2Popup::OnRewardCollected()));
        if(val_5 != null)
        {
                if(null != null)
        {
            goto label_20;
        }
        
        }
        
        val_3.OnWeeklyMonthlyRewardCollected = val_5;
        return;
        label_20:
    }
    private void OnDisable()
    {
        WGDailyChallengeManager val_1 = MonoSingleton<WGDailyChallengeManager>.Instance;
        System.Delegate val_3 = System.Delegate.Remove(source:  val_1.OnWeeklyMonthlyRewardCollected, value:  new System.Action(object:  this, method:  System.Void WGDailyChallengeV2Popup::OnRewardCollected()));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_5;
        }
        
        }
        
        val_1.OnWeeklyMonthlyRewardCollected = val_3;
        return;
        label_5:
    }
    public bool IsZooTileRewardPopupActive()
    {
        return this.zooTileRewardPopup.gameObject.activeInHierarchy;
    }
    private void HandleTooltipReadyToShow()
    {
        if((MonoSingleton<WGDailyChallengeManager>.Instance.IsTooltipReadyToShow()) == false)
        {
                return;
        }
        
        if(this.zooTileRewardPopup.gameObject.activeInHierarchy != false)
        {
                this.zooTileRewardPopup.OnZooTileRewardCollected = new System.Action(object:  this, method:  System.Void WGDailyChallengeV2Popup::HandleTooltipShowing());
            return;
        }
        
        this.calendar.HandleTooltipShowing();
    }
    private void HandleTooltipShowing()
    {
        if(this.calendar != null)
        {
                this.calendar.HandleTooltipShowing();
            return;
        }
        
        throw new NullReferenceException();
    }
    private void OnMainScreenButtonClicked()
    {
        var val_3;
        var val_4;
        System.Action val_5;
        val_3 = this;
        if(this.mainScreenBtn.gameObject.activeInHierarchy == false)
        {
                return;
        }
        
        val_3 = 1152921504988102656;
        val_4 = null;
        val_4 = null;
        val_5 = WGDailyChallengeV2Popup.onMainScreenBtnClicked;
        if(val_5 == null)
        {
                return;
        }
        
        val_5 = WGDailyChallengeV2Popup.onMainScreenBtnClicked;
        val_5.Invoke();
    }
    private void EnableScreenButton()
    {
        this.mainScreenBtn.gameObject.SetActive(value:  true);
    }
    private void DisableScreenButton()
    {
        this.mainScreenBtn.gameObject.SetActive(value:  false);
    }
    private void OpenDailyChallengeInfoPopup()
    {
        if(this.InfoPopup != null)
        {
                this.InfoPopup.SetActive(value:  true);
            return;
        }
        
        throw new NullReferenceException();
    }
    private void OpenZooTileRewardPopup(ZooTile tile)
    {
        null = null;
        if(App.game == 18)
        {
                GameBehavior val_1 = App.getBehavior;
            val_1.<metaGameBehavior>k__BackingField.Setup(rewardSource:  4);
            return;
        }
        
        this.zooTileRewardPopup.Setup(tile:  tile);
        this.zooTileRewardPopup.gameObject.SetActive(value:  true);
    }
    private void OnRewardCollected()
    {
        this.weeklyProgressUI.InitializeWeeklyProgress(starsToAnimate:  0);
        this.monthlyProgressUI.InitializeMonthlyProgress(starsToAnimate:  0);
    }
    private void ClosePopup()
    {
        UnityEngine.Object val_16;
        var val_17;
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  true, dontDestroyOnDisable:  true);
        val_16 = MonoSingleton<WGDailyChallengeManager>.Instance;
        if(val_16 != 0)
        {
                MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge = false;
        }
        
        val_17 = 1152921504884269056;
        GameBehavior val_5 = App.getBehavior;
        if((val_5.<metaGameBehavior>k__BackingField) != 2)
        {
                return;
        }
        
        val_16 = MonoSingleton<WGWindowManager>.Instance.IsWindowInQueue<LevelCompletePopup>();
        if(val_16 != 0)
        {
                return;
        }
        
        GameBehavior val_9 = App.getBehavior;
        val_16 = ???;
        val_17 = ???;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_3D0;
    }
    public WGDailyChallengeV2Popup()
    {
    
    }
    private static WGDailyChallengeV2Popup()
    {
    
    }

}
