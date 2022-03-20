using UnityEngine;
public class TRVRerollQuestionButton : TRVPowerupButton
{
    // Fields
    private TRVPowerup _powerup;
    
    // Properties
    public override TRVPowerup powerup { get; }
    protected override string pref_ftux_shown_key { get; }
    
    // Methods
    public override TRVPowerup get_powerup()
    {
        TRVPowerup val_5 = this._powerup;
        if(val_5 != null)
        {
                return val_5;
        }
        
        this._powerup = new TRVPowerup();
        .type = 1;
        TRVEcon val_2 = App.GetGameSpecificEcon<TRVEcon>();
        this._powerup.econ = val_2.PowerupData.Item[this._powerup.type];
        TRVEcon val_4 = App.GetGameSpecificEcon<TRVEcon>();
        float val_5 = val_4.quizDuration;
        val_5 = val_5 + (-1f);
        this._powerup.remainingTime = val_5;
        val_5 = this._powerup;
        return val_5;
    }
    protected override string get_pref_ftux_shown_key()
    {
        return "ftux_reroll_question_shown";
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
        var val_3;
        var val_4;
        val_3 = 0;
        if(this.IsFreeCost() != false)
        {
                val_4 = 0;
        }
        
        MonoSingleton<TRVMainController>.Instance.RerollQuestion(cost:  TRVRerollQuestionButton.__il2cppRuntimeField_byval_arg, remainingTime:  null);
    }
    protected override bool IsPowerupAvailable()
    {
        var val_5;
        if((MonoSingleton<TRVMainController>.Instance.IsPlayingChallenge) != false)
        {
                val_5 = 0;
            return (bool)(val_3.currentGame.currentGameplayState.rerollQuestionPowerupUsed == false) ? 1 : 0;
        }
        
        TRVMainController val_3 = MonoSingleton<TRVMainController>.Instance;
        return (bool)(val_3.currentGame.currentGameplayState.rerollQuestionPowerupUsed == false) ? 1 : 0;
    }
    protected override string GetFtuxText()
    {
        return Localization.Localize(key:  "trv_reroll_ftux", defaultValue:  "Reroll Question\nGet a new question.\nTry it now!", useSingularKey:  false);
    }
    public TRVRerollQuestionButton()
    {
    
    }

}
