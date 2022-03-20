using UnityEngine;
public class BWYHackBehavior : HackBehavior
{
    // Methods
    public override SROptions GetGameSpecificSROptions()
    {
        return SuperLuckySROptionsParent<SROptions_BestBlocks>.Instance;
    }
    public override void Hack_CompleteLevelBehavior()
    {
        var val_7;
        object val_8;
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) != 2)
        {
            goto label_5;
        }
        
        val_7 = 1152921504893161472;
        if(((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance.CurrentGameMode) != 2) || (BestBlocksPlayer.Instance.IsFTUXGameLevels() == false))
        {
            goto label_11;
        }
        
        val_8 = "Hack usable only after completing FTUX levels.";
        goto label_14;
        label_5:
        val_8 = "Option works only in-game.";
        label_14:
        UnityEngine.Debug.Log(message:  val_8);
        return;
        label_11:
        MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance.HackGameOver(success:  true);
    }
    public override void Hack_CompleteChapterBehavior()
    {
        object val_12;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) != 2) || ((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance.CurrentGameMode) != 2))
        {
            goto label_9;
        }
        
        if(BestBlocksPlayer.Instance.IsFTUXGameLevels() == false)
        {
            goto label_11;
        }
        
        val_12 = "Hack usable only after completing FTUX levels.";
        goto label_14;
        label_9:
        val_12 = "Option works only in-game for Challenge Mode.";
        label_14:
        UnityEngine.Debug.Log(message:  val_12);
        return;
        label_11:
        GameBehavior val_6 = App.getBehavior;
        int val_7 = BlockPuzzleMagic.LevelManager.GetChapterIdFromPlayerLevel(playerLevel:  val_6.<metaGameBehavior>k__BackingField);
        val_7 = val_7 + 1;
        GameBehavior val_9 = App.getBehavior;
        int val_10 = (BlockPuzzleMagic.LevelManager.GetLevelIdFromChapterId(chapterNum:  val_7)) - 1;
        MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance.HackRefreshCurrentLevel();
        goto typeof(BWYHackBehavior).__il2cppRuntimeField_190;
    }
    public override void Hack_RestartLevel()
    {
        GameBehavior val_1 = App.getBehavior;
        if((val_1.<metaGameBehavior>k__BackingField) == 2)
        {
                MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance.Restart();
            return;
        }
        
        UnityEngine.Debug.Log(message:  "Option works only in-game.");
    }
    public override void AppendGameLevelInfo(ref System.Text.StringBuilder builder)
    {
        var val_44;
        var val_45;
        System.Predicate<BlockPuzzleMagic.LevelRef> val_47;
        var val_48;
        var val_49;
        var val_50;
        Player val_2 = App.Player;
        float val_44 = (float)App.getGameEcon;
        float val_45 = (float)W22;
        val_44 = S8 * val_44;
        val_45 = val_44 + val_45;
        int val_3 = UnityEngine.Mathf.RoundToInt(f:  val_45);
        System.Collections.Generic.List<System.Int32> val_5 = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Collections.Generic.List<System.Int32>>(value:  UnityEngine.PlayerPrefs.GetString(key:  "bbl_prev_tm", defaultValue:  "[]"));
        GameBehavior val_7 = App.getBehavior;
        BlockPuzzleMagic.LevelManager val_8 = MonoSingletonSelfGenerating<BlockPuzzleMagic.LevelManager>.Instance;
        System.Text.StringBuilder val_9 = builder.AppendFormat(format:  "<b>Level Generation Info [Level <b>{0}</b> | Chapter <b>{1}</b>]</b>\n", arg0:  val_7.<metaGameBehavior>k__BackingField, arg1:  val_8.currentChapter.chapterId);
        System.Text.StringBuilder val_11 = builder.AppendFormat(format:  "Chapter\'s Theme Mechanic is <b>{0}</b>\n", arg0:  (Newtonsoft.Json.JsonConvert.__il2cppRuntimeField_cctor_finished + 177728412) + 32.ToString());
        System.Text.StringBuilder val_15 = builder.AppendFormat(format:  "Easy mode is <b>{0}</b>\n", arg0:  BlockPuzzleMagic.BestBlocksGameEcon.Instance.IsEasyMode());
        val_44 = null;
        val_44 = null;
        System.Text.StringBuilder val_16 = builder.AppendFormat(format:  "Fails for this level: <b>{0}</b>\n", arg0:  BlockPuzzleMagic.GamePlay.currentLevelFailCount);
        BlockPuzzleMagic.LevelManager val_17 = MonoSingletonSelfGenerating<BlockPuzzleMagic.LevelManager>.Instance;
        val_45 = null;
        val_45 = null;
        val_47 = BWYHackBehavior.<>c.<>9__4_0;
        if(val_47 == null)
        {
                System.Predicate<BlockPuzzleMagic.LevelRef> val_18 = null;
            val_47 = val_18;
            val_18 = new System.Predicate<BlockPuzzleMagic.LevelRef>(object:  BWYHackBehavior.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean BWYHackBehavior.<>c::<AppendGameLevelInfo>b__4_0(BlockPuzzleMagic.LevelRef obj));
            BWYHackBehavior.<>c.<>9__4_0 = val_47;
        }
        
        if((val_17.currentChapter.levels.Find(match:  val_18)) != null)
        {
                val_48 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_48 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_48 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_48 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            System.Text.StringBuilder val_20 = builder.AppendFormat(format:  "<color=#FFDC00><b>Level is constructed using these IDs</b></color>\n", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            System.Text.StringBuilder val_21 = builder.AppendFormat(format:  " > Normal Base Layout: {0} \n > Stone Layout: {1} \n\n", arg0:  val_19.layoutId, arg1:  val_19.stoneLayoutId);
        }
        
        System.Text.StringBuilder val_22 = builder.AppendLine();
        val_49 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_49 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_49 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_49 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        System.Text.StringBuilder val_23 = builder.AppendFormat(format:  "<color=#FFDC00><b>Hardcoded/Predefined Levels</b></color>\n", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        System.Text.StringBuilder val_26 = builder.AppendFormat(format:  "<b>Crate intro:</b> {0} - {1}\n", arg0:  BlockPuzzleMagic.LevelManager.PredefinedInitialLevelStart, arg1:  BlockPuzzleMagic.LevelManager.PredefinedInitialLevelEnd);
        System.Text.StringBuilder val_29 = builder.AppendFormat(format:  "<b>Stone intro:</b> {0} - {1}\n", arg0:  BlockPuzzleMagic.LevelManager.PredefinedStoneIntroLevelStart, arg1:  BlockPuzzleMagic.LevelManager.PredefinedStoneIntroLevelEnd);
        System.Text.StringBuilder val_32 = builder.AppendFormat(format:  "<b>Metal intro:</b> {0} - {1}\n", arg0:  BlockPuzzleMagic.LevelManager.PredefinedMetalIntroLevelStart, arg1:  BlockPuzzleMagic.LevelManager.PredefinedMetalIntroLevelEnd);
        System.Text.StringBuilder val_33 = builder.AppendLine();
        val_50 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_50 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_50 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_50 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        System.Text.StringBuilder val_34 = builder.AppendFormat(format:  "<color=#FFDC00><b>Powerup Unlock Level / Tutorial Level</b></color>\n", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        System.Text.StringBuilder val_37 = builder.AppendFormat(format:  "<b>Trash:</b> {0}\n", arg0:  BlockPuzzleMagic.BestBlocksGameEcon.Instance.GetPowerupTutorialLevel(powerupType:  0));
        System.Text.StringBuilder val_40 = builder.AppendFormat(format:  "<b>1x1 Block (Rainbow):</b> {0}\n", arg0:  BlockPuzzleMagic.BestBlocksGameEcon.Instance.GetPowerupTutorialLevel(powerupType:  2));
        System.Text.StringBuilder val_43 = builder.AppendFormat(format:  "<b>Bomb:</b> {0}\n", arg0:  BlockPuzzleMagic.BestBlocksGameEcon.Instance.GetPowerupTutorialLevel(powerupType:  1));
    }
    public BWYHackBehavior()
    {
    
    }

}
