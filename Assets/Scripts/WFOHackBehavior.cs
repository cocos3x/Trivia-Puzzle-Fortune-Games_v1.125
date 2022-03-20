using UnityEngine;
public class WFOHackBehavior : HackBehavior
{
    // Methods
    public override SROptions GetGameSpecificSROptions()
    {
        return SuperLuckySROptionsParent<SROptions_WordForest>.Instance;
    }
    public override void Hack_RestartLevel()
    {
        string val_17;
        GameLevel val_2 = PlayingLevel.GetLevel(currentMode:  PlayingLevel.CurrentGameplayMode, parameters:  0);
        System.Collections.Generic.List<System.String> val_16 = val_2.levelProgress;
        var val_18 = 1;
        label_15:
        if(val_18 >= val_16)
        {
            goto label_5;
        }
        
        System.Text.StringBuilder val_3 = new System.Text.StringBuilder();
        var val_17 = 0;
        label_11:
        if(val_16 <= val_18)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_16 = val_16 + 8;
        val_17 = val_17 + 1;
        if(val_17 >= val_16)
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
        val_18 = val_18 + 1;
        if(val_2.levelProgress != null)
        {
            goto label_15;
        }
        
        label_5:
        if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == false)
        {
            goto label_20;
        }
        
        string[] val_7 = new string[0];
        val_17 = "dailychallenge";
        goto label_21;
        label_20:
        if(CategoryPacksManager.IsPlaying == false)
        {
            goto label_24;
        }
        
        val_17 = "categorylevels";
        label_21:
        Prefs.SetExtraWordsEvents(gameType:  val_17, extraWords:  new string[0]);
        goto label_25;
        label_24:
        Prefs.SetExtraWords(world:  Prefs.currentWorld, subWorld:  Prefs.currentChapter, level:  Prefs.currentLevel, extraWords:  new string[0]);
        label_25:
        var val_19 = 0;
        val_19 = val_19 + 1;
        SRDebug.Instance.HideDebugPanel();
        CUtils.ReloadScene(useScreenFader:  false);
    }
    public override void Hack_CompleteLevelBehavior()
    {
        UnityEngine.Object val_11 = WordRegion.instance;
        if(val_11 == 0)
        {
                return;
        }
        
        val_11 = MainController.instance;
        if(val_11 == 0)
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
        }
        
        var val_11 = 0;
        val_11 = val_11 + 1;
        SRDebug.Instance.HideDebugPanel();
    }
    public override void Hack_CompleteChapterBehavior()
    {
        MainController.instance.Hack_SetLevelToLastLevelOfChapter();
        goto typeof(WFOHackBehavior).__il2cppRuntimeField_190;
    }
    public override void AppendGameLevelInfo(ref System.Text.StringBuilder builder)
    {
        var val_19;
        if(MainController.instance == 0)
        {
                val_19 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_19 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_19 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_19 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            System.Text.StringBuilder val_3 = builder.AppendFormat(format:  "MainController not present.", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            return;
        }
        
        GameLevel val_4 = PlayingLevel.GetLevelForPlayerLevel(levelIndex:  0, checkLevelSkip:  false);
        System.Text.StringBuilder val_5 = builder.AppendFormat(format:  "Level Name: <b>{0}</b>\n\n", arg0:  val_4.lvlName);
        System.Text.StringBuilder val_6 = builder.AppendFormat(format:  "Word: <color=#F2240D>{0}</color>\n", arg0:  val_4.word);
        System.Text.StringBuilder val_7 = builder.AppendFormat(format:  "Answers: <color=#D5CF01>{0}</color>\n", arg0:  val_4.answers);
        System.Text.StringBuilder val_8 = builder.AppendFormat(format:  "Extra: <color=#77BB66>{0}</color>\n\n", arg0:  val_4.extraWords);
        System.Text.StringBuilder val_10 = builder.AppendFormat(format:  "Initial: <color=#32A852>{0}</color>\n", arg0:  MiniJSON.Json.Serialize(obj:  val_4.rwdBase));
        System.Text.StringBuilder val_12 = builder.AppendFormat(format:  "Exp 1: <color=#9DA832>{0}</color>\n", arg0:  MiniJSON.Json.Serialize(obj:  val_4.rwdExp1));
        System.Text.StringBuilder val_14 = builder.AppendFormat(format:  "Exp 2: <color=#9DA832>{0}</color>\n", arg0:  MiniJSON.Json.Serialize(obj:  val_4.rwdExp2));
        System.Text.StringBuilder val_16 = builder.AppendFormat(format:  "Exp 3: <color=#9DA832>{0}</color>\n", arg0:  MiniJSON.Json.Serialize(obj:  val_4.rwdExp3));
        System.Text.StringBuilder val_18 = builder.AppendFormat(format:  "Exp 4: <color=#A87932>{0}</color>\n", arg0:  MiniJSON.Json.Serialize(obj:  val_4.rwdExp4));
    }
    public override void ResetPlayer()
    {
        WordForest.RaidAttackManager val_1 = MonoSingleton<WordForest.RaidAttackManager>.Instance;
        val_1.serverController.ResetForest();
        WordForest.WFOPlayer val_2 = WordForest.WFOPlayer.Instance;
        val_2.shields = 0;
        val_2.currentForestID = 1;
        val_2.forestMapData = new WordForest.Map(initialAreaItems:  new System.Collections.Generic.List<WordForest.MapItem>());
        GameBehavior val_5 = App.getBehavior;
        val_2.acorns = val_5.<metaGameBehavior>k__BackingField;
        WordForest.RaidAttackManager val_6 = MonoSingleton<WordForest.RaidAttackManager>.Instance;
        System.Nullable<System.Int32> val_7 = new System.Nullable<System.Int32>(value:  val_2.currentForestID);
        System.Nullable<System.Int32> val_9 = new System.Nullable<System.Int32>(value:  val_2.acorns);
        System.Nullable<System.Int32> val_10 = new System.Nullable<System.Int32>(value:  val_2.shields);
        val_6.serverController.SetForestProfile(forestLevel:  new System.Nullable<System.Int32>() {HasValue = val_7.HasValue}, map:  val_2.forestMapData, acorns:  new System.Nullable<System.Int32>() {HasValue = val_9.HasValue}, shields:  new System.Nullable<System.Int32>() {HasValue = val_10.HasValue}, fbid:  0, responseCallback:  0);
        NotificationCenter.DefaultCenter.PostNotification(aSender:  0, aName:  "OnStarsUpdated");
        if(SLC.Social.Leagues.LeaguesManager.DAO == 0)
        {
                return;
        }
        
        SLC.Social.Leagues.LeaguesManager.DAO.UpdateLocalProfile();
    }
    public WFOHackBehavior()
    {
    
    }

}
