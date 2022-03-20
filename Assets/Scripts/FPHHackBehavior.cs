using UnityEngine;
public class FPHHackBehavior : HackBehavior
{
    // Methods
    public override SROptions GetGameSpecificSROptions()
    {
        return SuperLuckySROptionsParent<SROptions_FPH>.Instance;
    }
    public override void AppendGameLevelInfo(ref System.Text.StringBuilder builder)
    {
        if(FPHGameplayController.Instance != 0)
        {
                FPHGameplayController val_3 = FPHGameplayController.Instance;
            if(val_3.currentGame != null)
        {
                GameEcon val_4 = App.getGameEcon;
            FPHGameplayController val_6 = FPHGameplayController.Instance;
            System.Text.StringBuilder val_7 = builder.Append(value:  "<b>General Info</b>\n");
            System.Text.StringBuilder val_9 = builder.AppendFormat(format:  "Success %: <b>{0}</b>\n\n", arg0:  FPHPlayer.Instance.SuccessPercentageStandardModeString);
            GameBehavior val_10 = App.getBehavior;
            System.Text.StringBuilder val_11 = builder.AppendFormat(format:  "<b>Current Level Info [Level <b>{0}</b>]</b>\n", arg0:  val_10.<metaGameBehavior>k__BackingField);
            System.Text.StringBuilder val_12 = builder.AppendFormat(format:  "Id: <b>{0}</b>\n", arg0:  val_6.currentGame.<levelData>k__BackingField.<id>k__BackingField);
            System.Text.StringBuilder val_13 = builder.AppendFormat(format:  "Phrase: <b>{0}</b>\n", arg0:  val_6.currentGame.<levelData>k__BackingField.<phrase>k__BackingField);
            System.Text.StringBuilder val_14 = builder.AppendFormat(format:  "Clue: <b>{0}</b>\n", arg0:  val_6.currentGame.<levelData>k__BackingField.<clue>k__BackingField);
            System.Text.StringBuilder val_15 = builder.AppendFormat(format:  "Retries for this level: <b>{0}</b>\n", arg0:  val_6.currentGame.retryAttempts);
            return;
        }
        
        }
        
        System.Text.StringBuilder val_16 = builder.AppendLine(value:  "NO DATA WHILE NOT IN GAMEPLAY");
    }
    public override void Hack_CompleteLevelBehavior()
    {
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) == 2)
        {
                FPHGameplayController.Instance.Hack_CompleteLevel();
            var val_5 = 0;
            val_5 = val_5 + 1;
        }
        else
        {
                UnityEngine.Debug.Log(message:  "Option works only in-game.");
            return;
        }
        
        SRDebug.Instance.HideDebugPanel();
    }
    public override void Hack_CompleteChapterBehavior()
    {
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) == 2)
        {
                FPHGameplayController.Instance.Hack_CompleteChapter();
            var val_5 = 0;
            val_5 = val_5 + 1;
        }
        else
        {
                UnityEngine.Debug.Log(message:  "Option works only in-game.");
            return;
        }
        
        SRDebug.Instance.HideDebugPanel();
    }
    public FPHHackBehavior()
    {
    
    }

}
