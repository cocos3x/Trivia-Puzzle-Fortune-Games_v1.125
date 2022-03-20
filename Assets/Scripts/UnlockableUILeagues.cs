using UnityEngine;
public class UnlockableUILeagues : WGUnlockableUIElement
{
    // Fields
    private UnityEngine.GameObject exclamationPoint;
    
    // Properties
    protected override bool FeatureHidden { get; }
    protected override int UnlockLevel { get; }
    
    // Methods
    private void Awake()
    {
        null = null;
        WordApp.DeferredGameUIReadyEvent.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void UnlockableUILeagues::WordAppStartedEvent()));
    }
    protected override bool get_FeatureHidden()
    {
        int val_8;
        var val_9;
        GameEcon val_1 = App.getGameEcon;
        if((val_1.leaguesButtonDisplayLevel & 2147483648) != 0)
        {
            goto label_4;
        }
        
        val_8 = App.Player;
        GameEcon val_3 = App.getGameEcon;
        if((GameEcon.IsEnabledAndLevelMet(playerLevel:  val_8, knobValue:  val_3.leaguesUnlockLevel)) == false)
        {
            goto label_11;
        }
        
        val_9 = 0;
        return (bool)(val_8 < val_6.leaguesButtonDisplayLevel) ? 1 : 0;
        label_4:
        val_9 = 1;
        return (bool)(val_8 < val_6.leaguesButtonDisplayLevel) ? 1 : 0;
        label_11:
        val_8 = App.Player;
        GameEcon val_6 = App.getGameEcon;
        return (bool)(val_8 < val_6.leaguesButtonDisplayLevel) ? 1 : 0;
    }
    protected override int get_UnlockLevel()
    {
        UnityEngine.GameObject val_6;
        UnityEngine.Object val_7;
        val_6 = this;
        val_7 = this.exclamationPoint;
        if(val_7 != 0)
        {
                val_6 = this.exclamationPoint;
            GameEcon val_3 = App.getGameEcon;
            val_7 = val_6;
            val_7.SetActive(value:  (App.Player >= val_3.leaguesUnlockLevel) ? 1 : 0);
        }
        
        GameEcon val_5 = App.getGameEcon;
        return (int)val_5.leaguesUnlockLevel;
    }
    private void WordAppStartedEvent()
    {
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        GameBehavior val_2 = App.getBehavior;
        if((val_2.<metaGameBehavior>k__BackingField) != 1)
        {
                return;
        }
        
        GameEcon val_4 = App.getGameEcon;
        if(App.Player < val_4.leaguesUnlockLevel)
        {
                return;
        }
        
        if((CPlayerPrefs.GetBool(key:  "TRVLeaguesUnlockShown", defaultValue:  false)) != false)
        {
                return;
        }
        
        UnityEngine.Coroutine val_7 = this.StartCoroutine(routine:  this.playUnlockAnimation());
    }
    private System.Collections.IEnumerator playUnlockAnimation()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new UnlockableUILeagues.<playUnlockAnimation>d__7();
    }
    public UnlockableUILeagues()
    {
    
    }

}
