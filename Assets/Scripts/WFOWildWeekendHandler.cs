using UnityEngine;
public class WFOWildWeekendHandler : WildWeekendHandler
{
    // Properties
    public override bool IsAvailable { get; }
    
    // Methods
    public override bool get_IsAvailable()
    {
        var val_8;
        var val_9;
        val_8 = this;
        if((true != 0) && ((this.HasCollected() != true) && (true != 0)))
        {
                System.DateTime val_3 = DateTimeCheat.UtcNow;
            if(41.ToOADate() > val_3.dateData.ToOADate())
        {
                val_8 = App.Player;
            WordForest.WFOGameEcon val_6 = WordForest.WFOGameEcon.Instance;
            var val_7 = (val_8 >= val_6.wordForestUnlockLevel) ? 1 : 0;
            return (bool)val_9;
        }
        
        }
        
        val_9 = 0;
        return (bool)val_9;
    }
    public override string GetMainMenuButtonText()
    {
        var val_9;
        if(this.CheckComplete() != false)
        {
                string val_2 = Localization.Localize(key:  "result_upper", defaultValue:  "RESULT", useSingularKey:  false);
            return (string)val_9;
        }
        
        if(this.GetLevelsComplete() != 0)
        {
                string val_8 = System.String.Format(format:  "{0}/{1}", arg0:  this.GetLevelsComplete().ToString(), arg1:  this.GetLevelsTotal().ToString());
            return (string)val_9;
        }
        
        val_9 = "WILD WORDS";
        return (string)val_9;
    }
    public override bool ShowEventUI(EventButtonPanel.LayoutType layoutType, EventButtonPanel.DisplayContext context)
    {
        var val_1;
        if(layoutType == 1)
        {
                val_1 = 0;
            return true;
        }
        
        val_1 = 1152921516376043153;
        return true;
    }
    public void ShowWildWordProgressInGamePopup()
    {
        GameBehavior val_1 = App.getBehavior;
        val_1.<metaGameBehavior>k__BackingField.SetUp(handler:  this, onCLoseCallback:  0);
    }
    public WFOWildWeekendHandler()
    {
    
    }

}
