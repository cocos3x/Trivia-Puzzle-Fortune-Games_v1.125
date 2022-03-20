using UnityEngine;
public class WGLeaderboardPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text rank;
    private AvatarSlotUGUI avatar;
    private UnityEngine.UI.Text playerName;
    private UnityEngine.UI.Text apples;
    private UnityEngine.UI.Text leaderboardEndsText;
    private UnityEngine.UI.Text remainingTime;
    private UnityEngine.UI.Button closeButton;
    private UnityEngine.UI.Image leaders;
    private UnityEngine.UI.Toggle prizes;
    private UnityEngine.Sprite tab_disable_create;
    private FrameSkipper frameSkipper;
    
    // Methods
    private void Awake()
    {
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGLeaderboardPopup::Close()));
        this.frameSkipper = this.gameObject.AddComponent<FrameSkipper>();
        System.Delegate val_5 = System.Delegate.Combine(a:  val_3.updateLogic, b:  new System.Action(object:  this, method:  System.Void WGLeaderboardPopup::RefreshRemainingTime()));
        if(val_5 != null)
        {
                if(null != null)
        {
            goto label_6;
        }
        
        }
        
        val_3.updateLogic = val_5;
        if(this.prizes == 0)
        {
                return;
        }
        
        this.prizes.onValueChanged.AddListener(call:  new UnityEngine.Events.UnityAction<System.Boolean>(object:  this, method:  System.Void WGLeaderboardPopup::<Awake>b__11_0(bool <p0>)));
        return;
        label_6:
    }
    private void OnEnable()
    {
        var val_6;
        string val_7;
        var val_8;
        val_6 = null;
        val_6 = null;
        string val_3 = Localization.Localize(key:  (App.game == 17) ? "leaderboards_ends_upper" : "leaderboard_ends_upper", defaultValue:  (App.game == 17) ? "LEADERBOARDS ENDS" : "LEADERBOARD ENDS", useSingularKey:  false);
        val_7 = val_3;
        if((val_3.Contains(value:  ":")) != true)
        {
                val_7 = val_7 + ":"(":");
        }
        
        this.SetupPlayerInfo();
        val_8 = null;
        val_8 = null;
        typeof(LeaderboardEventPlayerInfo_Self).__il2cppRuntimeField_38 = 0;
    }
    private void OnDisable()
    {
        var val_3;
        System.Delegate val_2 = System.Delegate.Remove(source:  this.frameSkipper.updateLogic, value:  new System.Action(object:  this, method:  System.Void WGLeaderboardPopup::RefreshRemainingTime()));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_3;
        }
        
        }
        
        this.frameSkipper.updateLogic = val_2;
        val_3 = null;
        val_3 = null;
        LeaderboardEventHandler.instance.OnMyEventPopupClosed();
        return;
        label_3:
    }
    private void SetupPlayerInfo()
    {
        var val_7;
        LeaderboardEventPlayerInfo_Self val_8;
        var val_9;
        AvatarSlotUGUI val_11;
        var val_12;
        var val_13;
        LeaderboardEventPlayerInfo_Self val_14;
        var val_15;
        val_7 = null;
        val_7 = null;
        val_8 = mem[LeaderboardEventHandler.instance + 32];
        val_8 = LeaderboardEventHandler.instance.playerInfo;
        val_7 = null;
        val_7 = null;
        string val_1 = LeaderboardEventHandler.instance.GetCurrentRankText();
        val_9 = null;
        val_9 = null;
        if(App.game == 17)
        {
                string val_2 = val_8.ToString(format:  "#,##0");
        }
        else
        {
                decimal val_3 = System.Decimal.op_Implicit(value:  370180096);
            string val_4 = NumberAbbreviation.GetNumber(num:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid});
        }
        
        val_11 = this.avatar;
        val_12 = null;
        val_12 = null;
        SLC.Social.Profile val_5 = LeaderboardEventHandler.instance.GetPlayerProfile();
        val_13 = null;
        val_13 = null;
        val_14 = null;
        val_15 = val_8;
    }
    private void RefreshRemainingTime()
    {
        var val_7;
        var val_8;
        var val_9;
        val_7 = this;
        val_8 = null;
        val_8 = null;
        if(LeaderboardEventHandler.instance == null)
        {
                return;
        }
        
        val_9 = null;
        val_9 = null;
        string val_1 = LeaderboardEventHandler.instance.GetRemainingTime();
        val_7 = ???;
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void HandlePrizesTabValueChanged()
    {
        if(this.leaders != null)
        {
                this.leaders.sprite = this.tab_disable_create;
            return;
        }
        
        throw new NullReferenceException();
    }
    public WGLeaderboardPopup()
    {
    
    }
    private void <Awake>b__11_0(bool <p0>)
    {
        this.HandlePrizesTabValueChanged();
    }

}
