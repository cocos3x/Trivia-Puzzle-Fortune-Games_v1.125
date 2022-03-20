using UnityEngine;
public class AdsUIController_Gameplay : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject incentivizedButton;
    private UnityEngine.GameObject petIcon;
    private UnityEngine.GameObject incentivizedButtonOpposer;
    private UnityEngine.GameObject incentivizedPlaceholderWGL;
    private UnityEngine.GameObject removeAdsButton;
    private UnityEngine.GameObject removeAdsButtonOpposer;
    private UnityEngine.GameObject howToPlayButton;
    private UnityEngine.GameObject hintButtonGroup;
    private UnityEngine.GameObject megaHintButtonGroup;
    private UnityEngine.GameObject pickerHintButtonGroup;
    private UnityEngine.GameObject freeHintButtonGroup;
    private UnityEngine.GameObject shuffleButtonGroup;
    
    // Properties
    public UnityEngine.GameObject HintButtonGroup { get; }
    public UnityEngine.GameObject MegaHintButtonGroup { get; }
    public UnityEngine.GameObject PickerHintButtonGroup { get; }
    public UnityEngine.GameObject FreeHintButtonGroup { get; }
    public UnityEngine.GameObject ShuffleButtonGroup { get; }
    
    // Methods
    public UnityEngine.GameObject get_HintButtonGroup()
    {
        return (UnityEngine.GameObject)this.hintButtonGroup;
    }
    public UnityEngine.GameObject get_MegaHintButtonGroup()
    {
        return (UnityEngine.GameObject)this.megaHintButtonGroup;
    }
    public UnityEngine.GameObject get_PickerHintButtonGroup()
    {
        return (UnityEngine.GameObject)this.pickerHintButtonGroup;
    }
    public UnityEngine.GameObject get_FreeHintButtonGroup()
    {
        return (UnityEngine.GameObject)this.incentivizedButton;
    }
    public UnityEngine.GameObject get_ShuffleButtonGroup()
    {
        return (UnityEngine.GameObject)this.shuffleButtonGroup;
    }
    public void ToggleIncentivizedButton()
    {
        UnityEngine.GameObject val_29;
        var val_30;
        var val_31;
        var val_32;
        bool val_33;
        bool val_34;
        var val_35;
        val_29 = 1152921504765632512;
        if(0 == this.incentivizedButton)
        {
            goto label_60;
        }
        
        val_30 = null;
        val_30 = null;
        if(App.game == 1)
        {
            goto label_15;
        }
        
        val_31 = null;
        val_31 = null;
        if(App.game == 18)
        {
            goto label_15;
        }
        
        val_32 = null;
        val_32 = null;
        if(App.game != 4)
        {
            goto label_21;
        }
        
        label_15:
        label_79:
        this.incentivizedButton.gameObject.SetActive(value:  false);
        label_60:
        if(0 == this.removeAdsButton)
        {
                return;
        }
        
        val_33 = 0;
        if((AdsManager.ShowAdsControlButtons(fromSettings:  false)) == false)
        {
            goto label_29;
        }
        
        val_29 = this.removeAdsButtonOpposer;
        if(val_29 != 0)
        {
            goto label_32;
        }
        
        val_33 = 1;
        if(this.removeAdsButton != null)
        {
            goto label_33;
        }
        
        return;
        label_32:
        val_33 = this.removeAdsButtonOpposer.activeSelf ^ 1;
        label_29:
        label_33:
        this.removeAdsButton.SetActive(value:  val_33);
        return;
        label_21:
        if(this.howToPlayButton == 0)
        {
            goto label_39;
        }
        
        if(App.Player >= 2)
        {
            goto label_43;
        }
        
        val_34 = 0;
        if(this.howToPlayButton != null)
        {
            goto label_44;
        }
        
        label_43:
        val_34 = (~(MonoSingleton<AdsUIController>.Instance.VideoAdsAllowed)) & 1;
        label_44:
        this.howToPlayButton.SetActive(value:  val_34);
        label_39:
        this.incentivizedButton.SetActive(value:  MonoSingleton<AdsUIController>.Instance.VideoAdsAllowed);
        if(this.incentivizedPlaceholderWGL != 0)
        {
                this.incentivizedPlaceholderWGL.SetActive(value:  false);
        }
        
        if(this.petIcon == 0)
        {
            goto label_60;
        }
        
        GameBehavior val_17 = App.getBehavior;
        if(((((val_17.<metaGameBehavior>k__BackingField) & 1) == 0) || ((MonoSingleton<AdsUIController>.Instance.VideoAdsAllowed) == false)) || ((WADPetsManager.GetPetByAbility(ability:  4).IsActive()) == false))
        {
            goto label_71;
        }
        
        if((MonoSingleton<WGDailyChallengeManager>.Instance) != 0)
        {
            goto label_76;
        }
        
        val_35 = 1;
        goto label_83;
        label_71:
        val_35 = 0;
        label_83:
        var val_24 = val_35 & 1;
        goto label_79;
        label_76:
        bool val_27 = (MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) ^ 1;
        goto label_83;
    }
    public AdsUIController_Gameplay()
    {
    
    }

}
