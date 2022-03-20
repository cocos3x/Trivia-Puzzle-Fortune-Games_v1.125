using UnityEngine;
public class TRVAskExpertButton : TRVPowerupButton
{
    // Fields
    private TRVPowerup _powerup;
    
    // Properties
    public override TRVPowerup powerup { get; }
    
    // Methods
    public override TRVPowerup get_powerup()
    {
        TRVPowerup val_6 = this._powerup;
        if(val_6 != null)
        {
                return val_6;
        }
        
        this._powerup = new TRVPowerup();
        .type = 2;
        TRVEcon val_2 = App.GetGameSpecificEcon<TRVEcon>();
        this._powerup.econ = val_2.PowerupData.Item[this._powerup.type];
        TRVEcon val_4 = App.GetGameSpecificEcon<TRVEcon>();
        this._powerup.econ.cost = val_4.askExpertGemCost;
        TRVEcon val_5 = App.GetGameSpecificEcon<TRVEcon>();
        float val_6 = val_5.quizDuration;
        val_6 = val_6 + (-1f);
        this._powerup.remainingTime = val_6;
        val_6 = this._powerup;
        return val_6;
    }
    protected override bool IsEligibleToShowInQOTD()
    {
        return false;
    }
    protected override void OnPowerupFailed()
    {
        this.OnPowerupFailed();
    }
    protected override void OnPowerupSuccess()
    {
        GameBehavior val_1 = App.getBehavior;
        goto mem[(1152921504946249728 + (public TRVAskExpertPopup MetaGameBehavior::ShowUGUIFlyOut<TRVAskExpertPopup>().__il2cppRuntimeField_48) << 4) + 312];
    }
    protected override bool IsPowerupAvailable()
    {
        bool val_2 = MonoSingleton<TRVMainController>.Instance.IsPlayingChallenge;
        val_2 = (~val_2) & 1;
        return (bool)val_2;
    }
    protected override string GetFtuxText()
    {
        return Localization.Localize(key:  "experts_ftux_tooltip", defaultValue:  "Ask an Expert when you are not sure. Try for free!", useSingularKey:  false);
    }
    public TRVAskExpertButton()
    {
    
    }

}
