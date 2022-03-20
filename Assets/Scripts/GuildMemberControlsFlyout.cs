using UnityEngine;
public class GuildMemberControlsFlyout : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button button_kick;
    private UnityEngine.UI.Button button_promote;
    private UnityEngine.UI.Button button_demote;
    private SLC.Social.Profile currentProfile;
    
    // Properties
    private bool checkTouchedMe { get; }
    
    // Methods
    private bool get_checkTouchedMe()
    {
        var val_16;
        UnityEngine.Object val_17;
        if(UnityEngine.Input.touchCount <= 0)
        {
                val_16 = 0;
            if((UnityEngine.Input.GetMouseButtonDown(button:  0)) == false)
        {
                return (bool)val_16 & 1;
        }
        
        }
        
        UnityEngine.EventSystems.EventSystem val_3 = UnityEngine.EventSystems.EventSystem.current;
        val_17 = this.gameObject;
        if(val_3.m_CurrentSelected == val_17)
        {
            goto label_15;
        }
        
        UnityEngine.EventSystems.EventSystem val_6 = UnityEngine.EventSystems.EventSystem.current;
        val_17 = this.button_kick.gameObject;
        if(val_6.m_CurrentSelected == val_17)
        {
            goto label_15;
        }
        
        UnityEngine.EventSystems.EventSystem val_9 = UnityEngine.EventSystems.EventSystem.current;
        val_17 = this.button_promote.gameObject;
        if(val_9.m_CurrentSelected != val_17)
        {
            goto label_22;
        }
        
        label_15:
        val_16 = 0;
        return (bool)val_16 & 1;
        label_22:
        UnityEngine.EventSystems.EventSystem val_13 = UnityEngine.EventSystems.EventSystem.current;
        bool val_16 = (UnityEngine.Object.op_Equality(x:  val_13.m_CurrentSelected, y:  this.button_demote.gameObject)) ^ 1;
        return (bool)val_16 & 1;
    }
    private void Awake()
    {
        this.button_kick.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void GuildMemberControlsFlyout::OnClick_Kick()));
        this.button_promote.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void GuildMemberControlsFlyout::OnClick_Promote()));
        this.button_demote.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void GuildMemberControlsFlyout::OnClick_Demote()));
    }
    private void Update()
    {
        if(this.checkTouchedMe == false)
        {
                return;
        }
        
        this.enabled = false;
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public void SetupControls(UnityEngine.GameObject gridItem, SLC.Social.Profile profile, bool promoteButton, bool demoteButton)
    {
        UnityEngine.Vector3 val_6 = gridItem.GetComponentInChildren<UnityEngine.UI.Graphic>().canvas.transform.position;
        UnityEngine.Vector3 val_8 = this.GetComponentInChildren<UnityEngine.UI.Graphic>().canvas.transform.position;
        UnityEngine.Vector3 val_9 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z}, b:  new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z});
        UnityEngine.Vector3 val_12 = gridItem.transform.position;
        UnityEngine.Vector3 val_13 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z}, b:  new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z});
        this.transform.position = new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z};
        this.currentProfile = profile;
        this.button_promote.gameObject.SetActive(value:  promoteButton);
        this.button_demote.gameObject.SetActive(value:  demoteButton);
    }
    private void OnClick_Kick()
    {
        if(this.currentProfile != null)
        {
                SLC.Social.Leagues.Guild val_2 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            if(this.currentProfile.GuildServerId == val_2.ServerId)
        {
                SLC.Social.Leagues.LeaguesManager.DAO.RemoveGuildMember(toRemove:  this.currentProfile);
            this.currentProfile.GuildServerId = 0;
        }
        
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClick_Promote()
    {
        var val_14;
        var val_15;
        val_14 = 1152921505022660608;
        val_15 = SLC.Social.Leagues.LeaguesManager.DAO.IsMaster;
        if(SLC.Social.Leagues.LeaguesManager.DAO.IsOfficer == false)
        {
            goto label_5;
        }
        
        if(this.currentProfile.Officer == true)
        {
            goto label_8;
        }
        
        val_15 = val_15 | ((this.currentProfile.GuildMaster == false) ? 1 : 0);
        goto label_8;
        label_5:
        label_8:
        SLC.Social.Leagues.Guild val_7 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
        var val_8 = (this.currentProfile.GuildServerId != val_7.ServerId) ? 1 : 0;
        val_8 = val_8 | (~val_15);
        if((val_8 != true) && (this.currentProfile != null))
        {
                SLC.Social.Leagues.Guild val_10 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            if(this.currentProfile.GuildServerId == val_10.ServerId)
        {
                val_14 = SLC.Social.Leagues.LeaguesManager.DAO;
            val_14.PromoteMember(toPromote:  this.currentProfile, responseCallback:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void GuildMemberControlsFlyout::<OnClick_Promote>b__10_0(System.Collections.Generic.Dictionary<string, object> result)));
        }
        
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClick_Demote()
    {
        var val_14;
        var val_15;
        val_14 = 1152921505022660608;
        val_15 = SLC.Social.Leagues.LeaguesManager.DAO.IsMaster;
        if(SLC.Social.Leagues.LeaguesManager.DAO.IsOfficer == false)
        {
            goto label_5;
        }
        
        if(this.currentProfile.Officer == true)
        {
            goto label_8;
        }
        
        val_15 = val_15 | ((this.currentProfile.GuildMaster == false) ? 1 : 0);
        goto label_8;
        label_5:
        label_8:
        SLC.Social.Leagues.Guild val_7 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
        var val_8 = (this.currentProfile.GuildServerId != val_7.ServerId) ? 1 : 0;
        val_8 = val_8 | (~val_15);
        if(val_8 != true)
        {
                SLC.Social.Leagues.Guild val_10 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
            if(this.currentProfile.GuildServerId == val_10.ServerId)
        {
                val_14 = SLC.Social.Leagues.LeaguesManager.DAO;
            val_14.DemoteMember(toDemote:  this.currentProfile, responseCallback:  new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void GuildMemberControlsFlyout::<OnClick_Demote>b__11_0(System.Collections.Generic.Dictionary<string, object> result)));
        }
        
        }
        
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void CloseFlyout()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public GuildMemberControlsFlyout()
    {
    
    }
    private void <OnClick_Promote>b__10_0(System.Collections.Generic.Dictionary<string, object> result)
    {
        if((result.ContainsKey(key:  "success")) == false)
        {
                return;
        }
        
        GameBehavior val_2 = App.getBehavior;
        val_2.<metaGameBehavior>k__BackingField.SetupMessage(message:  System.String.Format(format:  Localization.Localize(key:  "member_promoted_co_leader", defaultValue:  "{0} promoted to Co-Leader!", useSingularKey:  false), arg0:  this.currentProfile.Name), displaySeconds:  3f, startAction:  0);
    }
    private void <OnClick_Demote>b__11_0(System.Collections.Generic.Dictionary<string, object> result)
    {
        UnityEngine.Debug.Log(message:  PrettyPrint.printJSON(obj:  result, types:  false, singleLineOutput:  false));
        if((result.ContainsKey(key:  "success")) == false)
        {
                return;
        }
        
        GameBehavior val_3 = App.getBehavior;
        val_3.<metaGameBehavior>k__BackingField.SetupMessage(message:  System.String.Format(format:  Localization.Localize(key:  "member_no_longer_co_leader", defaultValue:  "{0} is no longer a Co-Leader!", useSingularKey:  false), arg0:  this.currentProfile.Name), displaySeconds:  3f, startAction:  0);
    }

}
