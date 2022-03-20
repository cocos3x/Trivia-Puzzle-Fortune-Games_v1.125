using UnityEngine;
public class WADHackBehavior : HackBehavior
{
    // Methods
    public override void Hack_RestartLevel()
    {
        GameLevel val_2 = PlayingLevel.GetLevel(currentMode:  PlayingLevel.CurrentGameplayMode, parameters:  0);
        System.Collections.Generic.List<System.String> val_7 = val_2.levelProgress;
        var val_9 = 1;
        label_15:
        if(val_9 >= val_7)
        {
            goto label_5;
        }
        
        System.Text.StringBuilder val_3 = new System.Text.StringBuilder();
        var val_8 = 0;
        label_11:
        if(val_7 <= val_9)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_7 = val_7 + 8;
        val_8 = val_8 + 1;
        if(val_8 >= val_7)
        {
            goto label_9;
        }
        
        System.Text.StringBuilder val_4 = val_3.Append(value:  '0');
        if(val_2.levelProgress != null)
        {
            goto label_11;
        }
        
        label_9:
        val_2.levelProgress.set_Item(index:  1, value:  val_3);
        val_9 = val_9 + 1;
        if(val_2.levelProgress != null)
        {
            goto label_15;
        }
        
        label_5:
        var val_10 = 0;
        val_10 = val_10 + 1;
        SRDebug.Instance.HideDebugPanel();
        CUtils.ReloadScene(useScreenFader:  false);
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
        goto typeof(WADHackBehavior).__il2cppRuntimeField_190;
    }
    public override void AppendGameLevelInfo(ref System.Text.StringBuilder builder)
    {
        var val_28;
        GameLevel val_29;
        if(MainController.instance == 0)
        {
                val_28 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_28 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_28 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_28 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            System.Text.StringBuilder val_3 = builder.AppendFormat(format:  "MainController not present.", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            return;
        }
        
        MainController val_4 = MainController.instance;
        val_29 = val_4.gameLevel;
        if(CategoryPacksManager.IsPlaying != false)
        {
                val_29 = PlayingLevel.GetCategoryLevel(categoryPackId:  0);
            CategoryPacksManager val_8 = MonoSingleton<CategoryPacksManager>.Instance;
            string val_9 = MonoSingleton<CategoryPacksManager>.Instance.GetWordFromPack(packId:  val_8.<CurrentCategoryPackInfo>k__BackingField.packId);
        }
        
        System.Text.StringBuilder val_11 = builder.AppendFormat(format:  "Tracking Name: <b>{0}</b>\n", arg0:  val_4.gameLevel.word.Replace(oldValue:  "|", newValue:  ""));
        System.Text.StringBuilder val_12 = builder.AppendFormat(format:  "Level Name: <b>{0}</b>\n\n", arg0:  val_4.gameLevel.lvlName);
        System.Text.StringBuilder val_13 = builder.AppendFormat(format:  "Word: <color=#F2240D>{0}</color>\n", arg0:  val_4.gameLevel.word);
        System.Text.StringBuilder val_14 = builder.AppendFormat(format:  "Answers: <color=#D5CF01>{0}</color>\n", arg0:  val_4.gameLevel.answers);
        System.Text.StringBuilder val_15 = builder.AppendFormat(format:  "Extra: <color=#77BB66>{0}</color>\n\n", arg0:  val_4.gameLevel.extraWords);
        System.Text.StringBuilder val_17 = builder.AppendFormat(format:  "Initial: <color=#32A852>{0}</color>\n", arg0:  MiniJSON.Json.Serialize(obj:  val_4.gameLevel.rwdBase));
        System.Text.StringBuilder val_19 = builder.AppendFormat(format:  "Exp 1: <color=#9DA832>{0}</color>\n", arg0:  MiniJSON.Json.Serialize(obj:  val_4.gameLevel.rwdExp1));
        System.Text.StringBuilder val_21 = builder.AppendFormat(format:  "Exp 2: <color=#9DA832>{0}</color>\n", arg0:  MiniJSON.Json.Serialize(obj:  val_4.gameLevel.rwdExp2));
        System.Text.StringBuilder val_23 = builder.AppendFormat(format:  "Exp 3: <color=#9DA832>{0}</color>\n", arg0:  MiniJSON.Json.Serialize(obj:  val_4.gameLevel.rwdExp3));
        System.Text.StringBuilder val_25 = builder.AppendFormat(format:  "Exp 4: <color=#A87932>{0}</color>\n\n", arg0:  MiniJSON.Json.Serialize(obj:  val_4.gameLevel.rwdExp4));
        System.Text.StringBuilder val_26 = builder.AppendFormat(format:  "Av Completion Time: <color=#FFFF00>{0}</color>\n\n", arg0:  val_4.gameLevel.avgCompletionTime);
        System.Text.StringBuilder val_27 = builder.AppendFormat(format:  "is Challenging Level <color=#77BB66>{0}</color>\n\n", arg0:  val_4.gameLevel.isChallengingLevel);
    }
    public WADHackBehavior()
    {
    
    }

}
