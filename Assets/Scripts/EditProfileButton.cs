using UnityEngine;
public class EditProfileButton : MonoBehaviour
{
    // Fields
    public UnityEngine.UI.Button button;
    
    // Methods
    private void Awake()
    {
        if(this.ProfileUnlocked() != true)
        {
                this.gameObject.SetActive(value:  false);
        }
        
        this.button.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void EditProfileButton::OnButtonClicked()));
    }
    private void OnButtonClicked()
    {
        GameBehavior val_1 = App.getBehavior;
        goto mem[(1152921504946249728 + (public EditProfileFlyout MetaGameBehavior::ShowUGUIFlyOut<EditProfileFlyout>().__il2cppRuntimeField_48) << 4) + 312];
    }
    private bool ProfileUnlocked()
    {
        int val_6;
        var val_7;
        var val_8;
        var val_9;
        val_6 = App.Player;
        GameEcon val_2 = App.getGameEcon;
        if((GameEcon.IsEnabledAndLevelMet(playerLevel:  val_6, knobValue:  val_2.leaguesUnlockLevel)) == true)
        {
            goto label_7;
        }
        
        GameBehavior val_4 = App.getBehavior;
        if(((val_4.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
            goto label_18;
        }
        
        val_6 = 1152921504900882432;
        val_7 = null;
        val_7 = null;
        if(TournamentsManager.pp_last_tournament == null)
        {
            goto label_18;
        }
        
        label_7:
        val_8 = 1;
        return (bool)(LeaderboardEventHandler.instance != 0) ? 1 : 0;
        label_18:
        val_6 = 1152921504976760832;
        val_9 = null;
        val_9 = null;
        return (bool)(LeaderboardEventHandler.instance != 0) ? 1 : 0;
    }
    public EditProfileButton()
    {
    
    }

}
