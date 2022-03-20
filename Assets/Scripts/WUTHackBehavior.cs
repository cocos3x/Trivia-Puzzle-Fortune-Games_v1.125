using UnityEngine;
public class WUTHackBehavior : HackBehavior
{
    // Methods
    public override void Hack_RestartLevel()
    {
        CUtils.ReloadScene(useScreenFader:  false);
    }
    public override SROptions GetGameSpecificSROptions()
    {
        return SuperLuckySROptionsParent<SROptions_WordNut>.Instance;
    }
    public override void Hack_CompleteLevelBehavior()
    {
        UnityEngine.Object val_13 = WordRegion.instance;
        if(val_13 == 0)
        {
                return;
        }
        
        val_13 = MainController.instance;
        if(val_13 == 0)
        {
                return;
        }
        
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false)
        {
                WordRegion.instance.Hack_CompleteLevel();
        }
        else
        {
                WordRegion val_8 = WordRegion.instance;
            WordRegion.instance.ClearLevelProgress();
            MainController val_10 = MainController.instance;
        }
        
        var val_13 = 0;
        val_13 = val_13 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public override void Hack_CompleteChapterBehavior()
    {
        MainController.instance.Hack_SetLevelToLastLevelOfChapter();
        goto typeof(WUTHackBehavior).__il2cppRuntimeField_190;
    }
    public override void AppendGameLevelInfo(ref System.Text.StringBuilder builder)
    {
        var val_34;
        GameLevel val_35;
        if(MainController.instance == 0)
        {
                val_34 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_34 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_34 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_34 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            System.Text.StringBuilder val_3 = builder.AppendFormat(format:  "MainController not present.", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            return;
        }
        
        MainController val_4 = MainController.instance;
        val_35 = val_4.gameLevel;
        if(CategoryPacksManager.IsPlaying != false)
        {
                val_35 = PlayingLevel.GetCategoryLevel(categoryPackId:  0);
            CategoryPacksManager val_8 = MonoSingleton<CategoryPacksManager>.Instance;
            string val_9 = MonoSingleton<CategoryPacksManager>.Instance.GetWordFromPack(packId:  val_8.<CurrentCategoryPackInfo>k__BackingField.packId);
        }
        
        System.Text.StringBuilder val_11 = builder.AppendFormat(format:  "Tracking Name: <b>{0}</b>\n", arg0:  val_4.gameLevel.word.Replace(oldValue:  "|", newValue:  ""));
        System.Text.StringBuilder val_12 = builder.AppendFormat(format:  "Level Name: <b>{0}</b>\n\n", arg0:  val_4.gameLevel.lvlName);
        System.Text.StringBuilder val_13 = builder.AppendFormat(format:  "Word: <color=#F2240D>{0}</color>\n", arg0:  val_4.gameLevel.word);
        char[] val_14 = new char[1];
        val_14[0] = 124;
        System.Text.StringBuilder val_17 = builder.AppendFormat(format:  "Answers: <color=#D5CF01>{0}</color>\n", arg0:  MiniJSON.Json.Serialize(obj:  val_4.gameLevel.answers.Split(separator:  val_14)));
        char[] val_18 = new char[1];
        val_18[0] = 124;
        System.Text.StringBuilder val_21 = builder.AppendFormat(format:  "Coords: <color=#D5CF01>{0}</color>\n", arg0:  MiniJSON.Json.Serialize(obj:  val_4.gameLevel.coords.Split(separator:  val_18)));
        System.Text.StringBuilder val_22 = builder.AppendFormat(format:  "Grid Size: <color=#D5CF01>{0}</color>\n", arg0:  val_4.gameLevel.gridSize);
        System.Text.StringBuilder val_23 = builder.AppendFormat(format:  "Extra: <color=#77BB66>{0}</color>\n", arg0:  val_4.gameLevel.extraWords);
        System.Text.StringBuilder val_24 = builder.AppendFormat(format:  "Available Extra Req: <color=#77FF66>{0}</color>\n\n", arg0:  val_4.gameLevel.availExtraReq);
        System.Text.StringBuilder val_25 = builder.AppendFormat(format:  "Extra Words Needed: <color=#EB8F34>{0}</color>, Extra Words: <color=#EB8F34>{1}</color>\n\n", arg0:  val_4.gameLevel.extraWordsNeeded, arg1:  val_4.gameLevel.extraRequiredWords);
        System.Text.StringBuilder val_27 = builder.AppendFormat(format:  "CommonW: <color=#32A852>{0}</color>\n", arg0:  MiniJSON.Json.Serialize(obj:  val_4.gameLevel.commonW));
        System.Text.StringBuilder val_29 = builder.AppendFormat(format:  "UncommonW: <color=#9DA832>{0}</color>\n", arg0:  MiniJSON.Json.Serialize(obj:  val_4.gameLevel.uncommonW));
        System.Text.StringBuilder val_31 = builder.AppendFormat(format:  "RareW: <color=#A87932>{0}</color>\n\n", arg0:  MiniJSON.Json.Serialize(obj:  val_4.gameLevel.rareW));
        System.Text.StringBuilder val_32 = builder.AppendFormat(format:  "Av Completion Time: <color=#FFFF00>{0}</color>\n", arg0:  val_4.gameLevel.avgCompletionTime);
        System.Text.StringBuilder val_33 = builder.AppendFormat(format:  "is Challenging Level <color=#77BB66>{0}</color>\n\n", arg0:  val_4.gameLevel.isChallengingLevel);
    }
    public WUTHackBehavior()
    {
    
    }

}
