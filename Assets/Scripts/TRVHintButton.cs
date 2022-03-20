using UnityEngine;
public class TRVHintButton : TRVPowerupButton
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
        .type = 0;
        TRVEcon val_2 = App.GetGameSpecificEcon<TRVEcon>();
        this._powerup.econ = val_2.PowerupData.Item[this._powerup.type];
        TRVEcon val_4 = App.GetGameSpecificEcon<TRVEcon>();
        float val_5 = val_4.quizDuration;
        val_5 = val_5 + (-1f);
        this._powerup.remainingTime = val_5;
        val_5 = this._powerup;
        return val_5;
    }
    private void Awake()
    {
        if(this._powerup != null)
        {
                return;
        }
        
        this._powerup = new TRVPowerup();
        .type = 0;
        TRVEcon val_2 = App.GetGameSpecificEcon<TRVEcon>();
        this._powerup.econ = val_2.PowerupData.Item[this._powerup.type];
        this = this._powerup;
        TRVEcon val_4 = App.GetGameSpecificEcon<TRVEcon>();
        float val_5 = val_4.quizDuration;
        val_5 = val_5 + (-1f);
        this._powerup.remainingTime = val_5;
    }
    protected override string get_pref_ftux_shown_key()
    {
        return "ftux_remove_incorrect_hint_shown";
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
        
        MonoSingleton<TRVMainController>.Instance.RemoveTwo(cost:  TRVHintButton.__il2cppRuntimeField_byval_arg, remainingTime:  null);
    }
    protected override string GetFtuxText()
    {
        return Localization.Localize(key:  "trv_5050_ftux", defaultValue:  "50 /50\nRemove 2 wrong answers.\nTry it now!", useSingularKey:  false);
    }
    protected override void SetupButtonUI()
    {
        if((MonoSingleton<TRVQuestionOfTheDayManager>.Instance.IsPlaying()) != false)
        {
                this.AdjustButtonPosition();
        }
        
        this.SetupButtonUI();
    }
    private void AdjustButtonPosition()
    {
        UnityEngine.Vector3 val_3 = UnityEngine.Vector3.zero;
        this.transform.GetComponent<UnityEngine.RectTransform>().localPosition = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
    }
    public TRVHintButton()
    {
    
    }

}
