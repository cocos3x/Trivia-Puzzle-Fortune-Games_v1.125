using UnityEngine;
public class FreeHintTrialHandler : HintFeatureHandler
{
    // Properties
    public override bool freeHintEligable { get; }
    public override bool hasFreeHintsRemaining { get; }
    
    // Methods
    public override bool get_freeHintEligable()
    {
        UnityEngine.Object val_10;
        var val_11;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                val_10 = MonoSingleton<WGDailyChallengeManager>.Instance;
            if((val_10 != 0) && ((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != true))
        {
                GameEcon val_6 = App.getGameEcon;
            if((val_6.freeHintFinalLevel & 2147483648) == 0)
        {
                val_10 = App.Player;
            GameEcon val_8 = App.getGameEcon;
            var val_9 = (val_10 < val_8.freeHintFinalLevel) ? 1 : 0;
            return (bool)val_11;
        }
        
        }
        
        }
        
        val_11 = 0;
        return (bool)val_11;
    }
    public override void DoButtonStartBehavior(WGHintButton hButton)
    {
        UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.WaitThenShowPopup(hButton:  hButton));
    }
    private System.Collections.IEnumerator WaitThenShowPopup(WGHintButton hButton)
    {
        .<>1__state = 0;
        .hButton = hButton;
        return (System.Collections.IEnumerator)new FreeHintTrialHandler.<WaitThenShowPopup>d__3();
    }
    public override bool get_hasFreeHintsRemaining()
    {
        return true;
    }
    public override void OnMyFreeHintUsed()
    {
        MainController val_2 = MainController.instance + 1;
        goto typeof(MainController).__il2cppRuntimeField_220;
    }
    public override void OnHintUsed(bool freeHint)
    {
    
    }
    public FreeHintTrialHandler()
    {
    
    }

}
