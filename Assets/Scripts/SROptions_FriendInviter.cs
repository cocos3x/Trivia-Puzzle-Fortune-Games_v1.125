using UnityEngine;
public class SROptions_FriendInviter : SuperLuckySROptionsParent<SROptions_FriendInviter>, INotifyPropertyChanged
{
    // Properties
    public int InvitesCollected { get; }
    public int PendingInvitesCollected { get; }
    public string LastResponse { get; }
    public string Progression { get; }
    
    // Methods
    public static void NotifyPropertyChanged(string propertyName)
    {
        if((SuperLuckySROptionsParent<T>._Instance) == 0)
        {
                return;
        }
        
        propertyName = ???;
        goto typeof(T).__il2cppRuntimeField_190;
    }
    public void Back()
    {
        var val_5;
        var val_5 = 0;
        val_5 = val_5 + 1;
        val_5 = 18;
        SRDebug.Instance.ClearPinnedOptions();
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_5 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
        SuperLuckySROptionsController.OpenGameSpecificOptionsController();
    }
    public int get_InvitesCollected()
    {
        return MonoSingleton<WGInviteManager>.Instance.InvitesCollected;
    }
    public int get_PendingInvitesCollected()
    {
        return MonoSingleton<WGInviteManager>.Instance.PendingInvites;
    }
    public void AddInvite()
    {
        if((MonoSingleton<WGInviteManager>.Instance) == 0)
        {
                return;
        }
        
        MonoSingleton<WGInviteManager>.Instance.HACKAddFakeInvites(invites:  1);
        goto typeof(SROptions_FriendInviter).__il2cppRuntimeField_190;
    }
    public void AddInvite10()
    {
        if((MonoSingleton<WGInviteManager>.Instance) == 0)
        {
                return;
        }
        
        MonoSingleton<WGInviteManager>.Instance.HACKAddFakeInvites(invites:  10);
        goto typeof(SROptions_FriendInviter).__il2cppRuntimeField_190;
    }
    public string get_LastResponse()
    {
        return (string)WGInviteManager.<LastResponse>k__BackingField;
    }
    public string get_Progression()
    {
        if((UnityEngine.PlayerPrefs.HasKey(key:  "wfi_reward_progression")) == false)
        {
                return "";
        }
        
        return PrettyPrint.printJSON(obj:  MiniJSON.Json.Deserialize(json:  UnityEngine.PlayerPrefs.GetString(key:  "wfi_reward_progression", defaultValue:  "{}")), types:  false, singleLineOutput:  false);
    }
    public SROptions_FriendInviter()
    {
    
    }

}
