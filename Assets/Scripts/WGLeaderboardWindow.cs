using UnityEngine;
public class WGLeaderboardWindow : MonoBehaviour
{
    // Fields
    private LeaderboardMembersListView listMembers;
    private LeaderboardMemberGridItem playerInfo;
    private UnityEngine.UI.Button closeButton;
    private UnityEngine.UI.Text monthText;
    private UnityEngine.UI.Text totalValue;
    private UnityEngine.UI.Toggle monthTab;
    private UnityEngine.UI.Toggle allTimeTab;
    private UnityEngine.UI.Button countryButton;
    private UnityEngine.UI.Text countryText;
    private UnityEngine.UI.Button worldButton;
    private UnityEngine.GameObject spin;
    private UnityEngine.GameObject playerInfoSpin;
    private UnityEngine.Canvas canvas;
    
    // Properties
    private LeaderboardGeoType GeoType { get; }
    private LeaderboardInterval Interval { get; }
    
    // Methods
    private LeaderboardGeoType get_GeoType()
    {
        WGLeaderboardManager val_1 = MonoSingleton<WGLeaderboardManager>.Instance;
        return (LeaderboardGeoType)val_1.<GeoType>k__BackingField;
    }
    private LeaderboardInterval get_Interval()
    {
        WGLeaderboardManager val_1 = MonoSingleton<WGLeaderboardManager>.Instance;
        return (LeaderboardInterval)val_1.<Interval>k__BackingField;
    }
    private void Awake()
    {
        this.ShowLoadingState();
        this.monthTab.onValueChanged.AddListener(call:  new UnityEngine.Events.UnityAction<System.Boolean>(object:  this, method:  System.Void WGLeaderboardWindow::OnClick_CurrentMonth(bool isMonthSelected)));
        this.allTimeTab.onValueChanged.AddListener(call:  new UnityEngine.Events.UnityAction<System.Boolean>(object:  this, method:  System.Void WGLeaderboardWindow::OnClick_AllTime(bool isAllTimeSelected)));
        this.countryButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGLeaderboardWindow::OnClick_Country()));
        this.worldButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGLeaderboardWindow::OnClick_World()));
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGLeaderboardWindow::Close()));
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "RefreshLeaderboard");
        UnityEngine.UI.Button val_7 = this.playerInfo.GetComponent<UnityEngine.UI.Button>();
        val_7.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGLeaderboardWindow::OnClick_MyProfile()));
    }
    private void OnEnable()
    {
        WGLeaderboardManager val_1 = MonoSingleton<WGLeaderboardManager>.Instance;
        this.monthTab.onValueChanged.Invoke(arg0:  true);
        this.worldButton.m_OnClick.Invoke();
        LeaderboardGeoType val_2 = this.worldButton.m_OnClick.GeoType;
        this.UpdateLeaderboardList(type:  val_2, interval:  val_2.Interval);
        UnityEngine.Canvas val_4 = this.GetComponentInParent<UnityEngine.Canvas>();
        this.canvas = val_4;
        if(val_4 == 0)
        {
                return;
        }
        
        this.canvas.pixelPerfect = false;
    }
    private void RefreshLeaderboard(Notification notif)
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.RefreshLeaderboardOnLoaded());
    }
    private System.Collections.IEnumerator RefreshLeaderboardOnLoaded()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGLeaderboardWindow.<RefreshLeaderboardOnLoaded>d__20();
    }
    private System.Collections.IEnumerator RequestLeaderboardData(LeaderboardGeoType geoType, LeaderboardInterval interval)
    {
        .<>1__state = 0;
        .geoType = geoType;
        .interval = interval;
        return (System.Collections.IEnumerator)new WGLeaderboardWindow.<RequestLeaderboardData>d__21();
    }
    private void RefreshRankList()
    {
        this.listMembers.gameObject.SetActive(value:  true);
        this.listMembers.SetOnFinishedUISetup();
        this.listMembers.RefreshMembers();
        if((this.listMembers.GetComponentInChildren<UnityEngine.UI.Scrollbar>()) == 0)
        {
                return;
        }
        
        this.listMembers.GetComponentInChildren<UnityEngine.UI.Scrollbar>().value = 1f;
    }
    private System.Collections.IEnumerator WaitForAllMembersToSetup()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGLeaderboardWindow.<WaitForAllMembersToSetup>d__23();
    }
    private void RefreshPlayerInfo()
    {
        WGLeaderboardManager val_1 = MonoSingleton<WGLeaderboardManager>.Instance;
        this.playerInfo.UpdateUIFromMember(info:  val_1.playerInfo_Self);
        this.playerInfo.gameObject.SetActive(value:  true);
    }
    private void ShowLoadingState()
    {
        this.playerInfo.gameObject.SetActive(value:  false);
        this.spin.SetActive(value:  true);
        this.playerInfoSpin.SetActive(value:  true);
    }
    private void UpdateLeaderboardList(LeaderboardGeoType type, LeaderboardInterval interval)
    {
        this.listMembers.allMembersLoaded = false;
        this.ShowLoadingState();
        UnityEngine.Coroutine val_2 = this.listMembers.StartCoroutine(routine:  this.RequestLeaderboardData(geoType:  type, interval:  interval));
    }
    private void OnClick_CurrentMonth(bool isMonthSelected)
    {
        if(isMonthSelected == false)
        {
                return;
        }
        
        LeaderboardInterval val_1 = this.Interval;
        if(val_1 == 0)
        {
                return;
        }
        
        if(this.listMembers.allMembersLoaded == false)
        {
                return;
        }
        
        this.UpdateLeaderboardList(type:  val_1.GeoType, interval:  0);
    }
    private void OnClick_AllTime(bool isAllTimeSelected)
    {
        if(isAllTimeSelected == false)
        {
                return;
        }
        
        LeaderboardInterval val_1 = this.Interval;
        if(val_1 == 1)
        {
                return;
        }
        
        if(this.listMembers.allMembersLoaded == false)
        {
                return;
        }
        
        this.UpdateLeaderboardList(type:  val_1.GeoType, interval:  1);
    }
    private void OnClick_Country()
    {
        this.worldButton.interactable = true;
        this.countryButton.interactable = false;
        LeaderboardGeoType val_1 = this.countryButton.GeoType;
        if(val_1 == 1)
        {
                return;
        }
        
        this.UpdateLeaderboardList(type:  1, interval:  val_1.Interval);
    }
    private void OnClick_World()
    {
        this.worldButton.interactable = false;
        this.countryButton.interactable = true;
        LeaderboardGeoType val_1 = this.countryButton.GeoType;
        if(val_1 == 0)
        {
                return;
        }
        
        this.UpdateLeaderboardList(type:  0, interval:  val_1.Interval);
    }
    private void OnClick_MyProfile()
    {
        GameBehavior val_1 = App.getBehavior;
        SLCWindow val_3 = val_1.<metaGameBehavior>k__BackingField.GetComponent<SLCWindow>();
        System.Delegate val_5 = System.Delegate.Combine(a:  val_3.Action_OnClose, b:  new System.Action(object:  this, method:  System.Void WGLeaderboardWindow::<OnClick_MyProfile>b__31_0()));
        if(val_5 != null)
        {
                if(null != null)
        {
            goto label_8;
        }
        
        }
        
        val_3.Action_OnClose = val_5;
        return;
        label_8:
    }
    private void Close()
    {
        if(this.canvas != 0)
        {
                this.canvas.pixelPerfect = true;
        }
        
        WGLeaderboardManager val_2 = MonoSingleton<WGLeaderboardManager>.Instance;
        val_2.<GeoType>k__BackingField = 0;
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public WGLeaderboardWindow()
    {
    
    }
    private bool <WaitForAllMembersToSetup>b__23_0()
    {
        if(this.listMembers != null)
        {
                return (bool)this.listMembers.allMembersLoaded;
        }
        
        throw new NullReferenceException();
    }
    private void <OnClick_MyProfile>b__31_0()
    {
        LeaderboardGeoType val_1 = this.GeoType;
        this.UpdateLeaderboardList(type:  val_1, interval:  val_1.Interval);
    }

}
