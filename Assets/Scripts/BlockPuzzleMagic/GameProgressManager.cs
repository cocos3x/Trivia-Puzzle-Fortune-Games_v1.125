using UnityEngine;

namespace BlockPuzzleMagic
{
    public class GameProgressManager : MonoSingleton<BlockPuzzleMagic.GameProgressManager>
    {
        // Fields
        private const string PREFKEY_SAVEDGAMELEVEL_ZEN = "bbl_savedlevel_zen";
        private const string PREFKEY_SAVEDGAMELEVEL_CHALLENGE = "bbl_savedlevel";
        
        // Methods
        public override void InitMonoSingleton()
        {
            UnityEngine.SceneManagement.SceneManager.add_activeSceneChanged(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.Scene>(object:  this, method:  System.Void BlockPuzzleMagic.GameProgressManager::OnScreenSwitched(UnityEngine.SceneManagement.Scene outgoingScene, UnityEngine.SceneManagement.Scene incomingScene)));
            this.InitMonoSingleton();
        }
        private void OnScreenSwitched(UnityEngine.SceneManagement.Scene outgoingScene, UnityEngine.SceneManagement.Scene incomingScene)
        {
            System.Action<System.Boolean> val_16;
            var val_17;
            var val_18;
            GameBehavior val_1 = App.getBehavior;
            val_16 = 1152921504893161472;
            if((val_1.<metaGameBehavior>k__BackingField) != 2)
            {
                goto label_5;
            }
            
            BlockPuzzleMagic.GamePlay val_2 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            System.Delegate val_4 = System.Delegate.Combine(a:  val_2.OnLevelDataInitialized, b:  new System.Action<BlockPuzzleMagic.Level>(object:  this, method:  System.Void BlockPuzzleMagic.GameProgressManager::OnLevelDataInitialized(BlockPuzzleMagic.Level asd)));
            if(val_4 != null)
            {
                    if(null != null)
            {
                goto label_26;
            }
            
            }
            
            val_2.OnLevelDataInitialized = val_4;
            val_16 = val_5.OnGameOver;
            val_17 = 1152921504614248448;
            val_18 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            if((System.Delegate.Combine(a:  val_16, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void BlockPuzzleMagic.GameProgressManager::OnGameOver(bool success)))) != null)
            {
                goto label_12;
            }
            
            goto label_25;
            label_5:
            val_17 = 1152921513393502304;
            if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance) == 0)
            {
                    return;
            }
            
            BlockPuzzleMagic.GamePlay val_10 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            System.Delegate val_12 = System.Delegate.Remove(source:  val_10.OnLevelDataInitialized, value:  new System.Action<BlockPuzzleMagic.Level>(object:  this, method:  System.Void BlockPuzzleMagic.GameProgressManager::OnLevelDataInitialized(BlockPuzzleMagic.Level asd)));
            if(val_12 != null)
            {
                    if(null != null)
            {
                goto label_26;
            }
            
            }
            
            val_10.OnLevelDataInitialized = val_12;
            val_16 = val_13.OnGameOver;
            val_17 = 1152921504614248448;
            val_18 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            System.Delegate val_15 = System.Delegate.Remove(source:  val_16, value:  new System.Action<System.Boolean>(object:  this, method:  System.Void BlockPuzzleMagic.GameProgressManager::OnGameOver(bool success)));
            if(val_15 == null)
            {
                goto label_25;
            }
            
            label_12:
            if(null != val_17)
            {
                goto label_26;
            }
            
            label_25:
            val_13.OnGameOver = val_15;
            return;
            label_26:
        }
        private string GetPrefKeyForMode(BlockPuzzleMagic.GameMode mode)
        {
            var val_2;
            if(mode != 1)
            {
                    return (string)(mode == 2) ? "bbl_savedlevel" : 0;
            }
            
            val_2 = "bbl_savedlevel_zen";
            return (string)(mode == 2) ? "bbl_savedlevel" : 0;
        }
        public bool HasSavedGame(BlockPuzzleMagic.GameMode gameMode)
        {
            var val_2;
            if(gameMode != 1)
            {
                    return UnityEngine.PlayerPrefs.HasKey(key:  (gameMode == 2) ? "bbl_savedlevel" : 0);
            }
            
            val_2 = "bbl_savedlevel_zen";
            return UnityEngine.PlayerPrefs.HasKey(key:  (gameMode == 2) ? "bbl_savedlevel" : 0);
        }
        public BlockPuzzleMagic.Level LoadSavedGame(BlockPuzzleMagic.GameMode gameMode)
        {
            var val_4;
            if(gameMode == 1)
            {
                    val_4 = "bbl_savedlevel_zen";
            }
            
            string val_2 = UnityEngine.PlayerPrefs.GetString(key:  (gameMode == 2) ? "bbl_savedlevel" : 0, defaultValue:  0);
            if((System.String.IsNullOrEmpty(value:  val_2)) == false)
            {
                    return BlockPuzzleMagic.Level.Parse(_jsonString:  val_2);
            }
            
            return 0;
        }
        private void OnApplicationPause(bool pause)
        {
            if(pause == false)
            {
                    return;
            }
            
            this.SaveGame();
        }
        public void SaveGame()
        {
            UnityEngine.Object val_12;
            BlockPuzzleMagic.GameMode val_13;
            if(BestBlocksPlayer.Instance.IsFTUXGameLevels() != false)
            {
                    if(CompanyDevices.Instance.CompanyDevice() == false)
            {
                    return;
            }
            
                UnityEngine.Debug.LogError(message:  "Skipping save (Reason: FTUX Levels)");
                return;
            }
            
            val_12 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            if(val_12 != 0)
            {
                    BlockPuzzleMagic.GamePlay val_7 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
                if((val_7.currentLevel != null) && (val_7.currentLevel.gameMode != 0))
            {
                    BlockPuzzleMagic.GamePlay val_8 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
                if(val_8.currentLevel != null)
            {
                    val_13 = val_8.currentLevel.gameMode;
            }
            else
            {
                    val_13 = 0;
            }
            
                if(val_13 == 1)
            {
                    val_12 = "bbl_savedlevel_zen";
            }
            
                BlockPuzzleMagic.GamePlay val_10 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
                UnityEngine.PlayerPrefs.SetString(key:  (val_13 == 2) ? "bbl_savedlevel" : 0, value:  val_10.currentLevel);
            }
            
            }
            
            App.Player.SaveState();
        }
        public void ClearProgress(BlockPuzzleMagic.GameMode gameMode)
        {
            var val_5;
            BestBlocksPlayer val_1 = BestBlocksPlayer.Instance;
            val_1.levelPowerupUsed.Clear();
            BestBlocksPlayer val_2 = BestBlocksPlayer.Instance;
            val_2.levelPowerupFreeUsed = 0;
            if(gameMode == 1)
            {
                    val_5 = "bbl_savedlevel_zen";
            }
            
            UnityEngine.PlayerPrefs.DeleteKey(key:  (gameMode == 2) ? "bbl_savedlevel" : 0);
            App.Player.SaveState();
        }
        private void OnLevelDataInitialized(BlockPuzzleMagic.Level asd)
        {
            this.TrackLevelStart();
        }
        private void OnGameOver(bool success)
        {
            BlockPuzzleMagic.GameMode val_4;
            BlockPuzzleMagic.GamePlay val_1 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            if(val_1.currentLevel.gameMode == 1)
            {
                goto label_5;
            }
            
            if(val_1.currentLevel.gameMode != 2)
            {
                    return;
            }
            
            if(success == false)
            {
                goto label_7;
            }
            
            Player val_2 = App.Player;
            mem2[0] = 0;
            val_2.TrackLevelComplete(gameMode:  2, isSuccess:  true);
            val_2.AdvanceLevelLogic();
            val_4 = 2;
            goto label_13;
            label_5:
            val_4 = 1;
            label_13:
            this.ClearProgress(gameMode:  val_4);
            return;
            label_7:
            mem2[0] = ((Player.__il2cppRuntimeField_typeHierarchy + (BestBlocksPlayer.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8 + 1);
            App.Player.TrackLevelComplete(gameMode:  2, isSuccess:  false);
            this.SaveGame();
        }
        private void AdvanceLevelLogic()
        {
            MetaGameBehavior val_14;
            var val_15;
            var val_16;
            var val_17;
            var val_18;
            if(BestBlocksPlayer.Instance.IsFTUXGameLevels() == false)
            {
                goto label_2;
            }
            
            val_14 = 1152921505046675456;
            val_15 = null;
            val_15 = null;
            if(BlockPuzzleMagic.BBLFtuxData.PlayerFtuxLevel >= BlockPuzzleMagic.BBLFtuxData.MaxFtuxLevel)
            {
                goto label_5;
            }
            
            val_16 = null;
            val_16 = null;
            int val_14 = BlockPuzzleMagic.BBLFtuxData.PlayerFtuxLevel;
            val_14 = val_14 + 1;
            BlockPuzzleMagic.BBLFtuxData.PlayerFtuxLevel = val_14;
            return;
            label_2:
            GameBehavior val_4 = App.getBehavior;
            val_14 = val_4.<metaGameBehavior>k__BackingField;
            MetaGameBehavior val_5 = val_14 + 1;
            GameBehavior val_6 = App.getBehavior;
            if((val_6.<metaGameBehavior>k__BackingField) >= 10)
            {
                    GameBehavior val_7 = App.getBehavior;
                if(0 != 0)
            {
                    return;
            }
            
            }
            
            val_17 = null;
            val_17 = null;
            val_18 = null;
            val_14 = App.trackerManager;
            val_18 = null;
            GameBehavior val_8 = App.getBehavior;
            val_14.track(eventName:  Events.LEVEL_REACHED + "_" + val_8.<metaGameBehavior>k__BackingField.ToString()(val_8.<metaGameBehavior>k__BackingField.ToString()));
            return;
            label_5:
            BestBlocksPlayer.Instance.SetFtuxStatus(ftuxId:  1, completed:  true);
            BestBlocksPlayer.Instance.SetFtuxStatus(ftuxId:  2, completed:  true);
            BestBlocksPlayer.Instance.SetFtuxStatus(ftuxId:  3, completed:  true);
        }
        private void TrackLevelComplete(BlockPuzzleMagic.GameMode gameMode, bool isSuccess)
        {
            object val_20;
            string val_21;
            var val_22;
            var val_23;
            var val_24;
            BestBlocksPlayer val_1 = BestBlocksPlayer.Instance;
            BlockPuzzleMagic.GamePlay val_3 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_4 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            if(isSuccess != false)
            {
                    val_20 = true;
                val_21 = "Level Success";
                val_22 = public System.Void System.Collections.Generic.Dictionary<System.String, System.Object>::Add(System.String key, System.Object value);
            }
            else
            {
                    val_21 = "Level Failed";
                val_20 = "Out of Moves";
                val_22 = public System.Void System.Collections.Generic.Dictionary<System.String, System.Object>::Add(System.String key, System.Object value);
            }
            
            val_4.Add(key:  val_21, value:  val_20);
            val_4.Add(key:  "Current Lvl", value:  System.String.Format(format:  "{0}-{1}", arg0:  BlockPuzzleMagic.LevelManager.GetChapterIdFromPlayerLevel(playerLevel:  val_3.currentLevel.levelId), arg1:  val_3.currentLevel.levelId));
            val_4.Add(key:  "Free Powerup Used", value:  (val_1.levelPowerupFreeUsed > 0) ? 1 : 0.ToString());
            val_4.Add(key:  "Mode", value:  (BlockPuzzleMagic.BestBlocksGameEcon.Instance.IsEasyMode() != true) ? "Easy" : "Default");
            val_4.Add(key:  "Powerup Trash Used", value:  val_1.GetPowerupAmountUsedThisLevel(powerupType:  0));
            val_4.Add(key:  "Powerup Bomb Used", value:  val_1.GetPowerupAmountUsedThisLevel(powerupType:  1));
            val_4.Add(key:  "Powerup 1x1 Used", value:  val_1.GetPowerupAmountUsedThisLevel(powerupType:  2));
            val_4.Add(key:  "Earthquake Powerup Used", value:  val_1.GetPowerupAmountUsedThisLevel(powerupType:  3));
            val_4.Add(key:  "Rotations Used", value:  EnumerableExtentions.GetOrDefault<BlockPuzzleMagic.GameMode, System.Int32>(dic:  val_1.currentRotationsUsed, key:  gameMode, defaultValue:  0));
            val_4.Add(key:  "Rotation Prompt", value:  EnumerableExtentions.GetOrDefault<BlockPuzzleMagic.GameMode, System.Boolean>(dic:  val_1.rotationPrompted, key:  gameMode, defaultValue:  false));
            val_23 = null;
            val_23 = null;
            if(App.game == 16)
            {
                    if(BestBlocksPlayer.Instance.IsFTUXGameLevels() != false)
            {
                    val_4.Add(key:  "FTUX", value:  val_3.currentLevel.levelId);
            }
            
            }
            
            val_24 = null;
            val_24 = null;
            App.trackerManager.track(eventName:  "Level Complete", data:  val_4);
        }
        private void TrackLevelStart()
        {
            var val_8;
            var val_9;
            BlockPuzzleMagic.GamePlay val_1 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_2.Add(key:  "Current Lvl", value:  System.String.Format(format:  "{0}-{1}", arg0:  BlockPuzzleMagic.LevelManager.GetChapterIdFromPlayerLevel(playerLevel:  val_1.currentLevel.levelId), arg1:  val_1.currentLevel.levelId));
            Player val_5 = App.Player;
            val_2.Add(key:  "Coin Balance", value:  val_5._credits);
            val_8 = null;
            val_8 = null;
            if(App.game == 16)
            {
                    if(BestBlocksPlayer.Instance.IsFTUXGameLevels() != false)
            {
                    val_2.Add(key:  "FTUX", value:  val_1.currentLevel.levelId);
            }
            
            }
            
            val_9 = null;
            val_9 = null;
            App.trackerManager.track(eventName:  "Level Start", data:  val_2);
        }
        public void OnLevelClearClosed()
        {
            AdsUIController val_1 = MonoSingleton<AdsUIController>.Instance;
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            bool val_2 = val_1.ShowInterstitial(context:  2);
            GameBehavior val_3 = App.getBehavior;
            goto typeof(MetaGameBehavior).__il2cppRuntimeField_3D0;
        }
        public void OnChapterClearClosed()
        {
            AdsUIController val_1 = MonoSingleton<AdsUIController>.Instance;
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            bool val_2 = val_1.ShowInterstitial(context:  2);
            GameBehavior val_3 = App.getBehavior;
            goto typeof(MetaGameBehavior).__il2cppRuntimeField_3D0;
        }
        public GameProgressManager()
        {
        
        }
    
    }

}
