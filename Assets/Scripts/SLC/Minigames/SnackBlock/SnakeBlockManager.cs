using UnityEngine;

namespace SLC.Minigames.SnackBlock
{
    public class SnakeBlockManager : MonoSingleton<SLC.Minigames.SnackBlock.SnakeBlockManager>
    {
        // Fields
        private System.Collections.Generic.List<string[]> parsedWordData;
        private System.Collections.Generic.List<SLC.Minigames.SnackBlock.SnakeGridSpaceType[]> myLevelData;
        private System.Collections.Generic.Dictionary<int, int> currentWordRowIndexDict;
        private const string MINIGAME_NAME = "SnakeBlock";
        private bool <inMinigameFramework>k__BackingField;
        private int _snakePlayerLevel;
        private int _snakeObjectivesCount;
        private int _snakeObjectivesReq;
        private bool isPaused;
        private SLC.Minigames.SnackBlock.SnakeBlockLevelStreamer streamer;
        private SLC.Minigames.SnackBlock.SnakeBlockUIController uiCont;
        private float curLevelSpeed;
        private SLC.Minigames.SnackBlock.SnakeBlockController mySnake;
        private RandomSet randomSet;
        public bool hasFTUXCollided;
        public UnityEngine.GameObject avoidText;
        
        // Properties
        public System.Collections.Generic.List<SLC.Minigames.SnackBlock.SnakeGridSpaceType[]> LevelData { get; }
        public bool inMinigameFramework { get; set; }
        public bool IsPaused { get; }
        public SLC.Minigames.SnackBlock.SnakeBlockUIController GetUIController { get; }
        public float getSpeedForLevel { get; }
        
        // Methods
        public System.Collections.Generic.List<SLC.Minigames.SnackBlock.SnakeGridSpaceType[]> get_LevelData()
        {
            return (System.Collections.Generic.List<SLC.Minigames.SnackBlock.SnakeGridSpaceType[]>)this.myLevelData;
        }
        public bool get_inMinigameFramework()
        {
            return (bool)this.<inMinigameFramework>k__BackingField;
        }
        private void set_inMinigameFramework(bool value)
        {
            this.<inMinigameFramework>k__BackingField = value;
        }
        public bool get_IsPaused()
        {
            return (bool)this.isPaused;
        }
        public SLC.Minigames.SnackBlock.SnakeBlockUIController get_GetUIController()
        {
            return (SLC.Minigames.SnackBlock.SnakeBlockUIController)this.uiCont;
        }
        public float get_getSpeedForLevel()
        {
            float val_2;
            if((this.<inMinigameFramework>k__BackingField) != false)
            {
                    SLC.Minigames.MinigameManager val_1 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
                val_2 = (float)val_1.currentPlayerLevel;
            }
            else
            {
                    val_2 = 1f;
            }
            
            float val_2 = 0.99849f;
            val_2 = val_2 * 0.425f;
            return (float)val_2;
        }
        private void OnDestroy()
        {
            UnityEngine.Time.fixedDeltaTime = 0.02f;
        }
        private void Start()
        {
            string val_7;
            var val_8;
            object val_39;
            System.Collections.Generic.List<System.String[]> val_40;
            var val_42;
            System.String[] val_43;
            var val_44;
            var val_45;
            var val_46;
            var val_47;
            object val_48;
            val_39 = this;
            UnityEngine.Time.fixedDeltaTime = 0.01f;
            object val_3 = MiniJSON.Json.Deserialize(json:  UnityEngine.Resources.Load<UnityEngine.TextAsset>(path:  "minigames/snakeblock/word_data").text);
            System.Collections.Generic.List<System.String[]> val_4 = null;
            val_40 = val_4;
            val_4 = new System.Collections.Generic.List<System.String[]>();
            this.parsedWordData = val_40;
            List.Enumerator<T> val_6 = GetEnumerator();
            var val_40 = 0;
            label_21:
            if(val_8.MoveNext() == false)
            {
                goto label_7;
            }
            
            val_42 = val_7;
            System.Collections.Generic.List<System.String> val_10 = new System.Collections.Generic.List<System.String>();
            if(val_42 == 0)
            {
                    throw new NullReferenceException();
            }
            
            List.Enumerator<T> val_12 = GetEnumerator();
            label_16:
            if(val_8.MoveNext() == false)
            {
                goto label_13;
            }
            
            if(val_7 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(val_10 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_10.Add(item:  val_7);
            goto label_16;
            label_13:
            val_42 = 0;
            val_40 = val_40 + 1;
            mem2[0] = 125;
            val_43 = public System.Void List.Enumerator<System.Object>::Dispose();
            val_8.Dispose();
            if(val_42 != 0)
            {
                goto label_17;
            }
            
            if(val_40 != 1)
            {
                    var val_14 = ((1152921519904581872 + ((0 + 1)) << 2) == 125) ? 1 : 0;
                val_14 = ((val_40 >= 0) ? 1 : 0) & val_14;
                val_40 = val_40 - val_14;
            }
            
            if(val_10 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_43 = val_10.ToArray();
            if(this.parsedWordData == null)
            {
                    throw new NullReferenceException();
            }
            
            this.parsedWordData.Add(item:  val_43);
            goto label_21;
            label_7:
            var val_17 = val_40 + 1;
            mem2[0] = 167;
            val_8.Dispose();
            label_77:
            this.randomSet.addIntRange(lowest:  0, highest:  this.parsedWordData - 1);
            this.<inMinigameFramework>k__BackingField = true;
            val_47 = 1152921504893161472;
            if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance) != 0)
            {
                goto label_35;
            }
            
            val_48 = "Snake: No Minigame Manager";
            goto label_38;
            label_35:
            if((this.<inMinigameFramework>k__BackingField) == false)
            {
                goto label_64;
            }
            
            if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance.CurrentMinigameId.Equals(value:  "SnakeBlock")) == false)
            {
                goto label_44;
            }
            
            if((this.<inMinigameFramework>k__BackingField) == false)
            {
                goto label_64;
            }
            
            SLC.Minigames.MinigameManager val_24 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            this._snakePlayerLevel = val_24.currentPlayerLevel;
            SLC.Minigames.MinigameManager val_25 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            System.Action val_26 = null;
            val_39 = val_26;
            val_26 = new System.Action(object:  this, method:  System.Void SLC.Minigames.SnackBlock.SnakeBlockManager::OnRestartFromCheckpoint());
            System.Delegate val_27 = System.Delegate.Combine(a:  val_25.OnRestartMinigame, b:  val_26);
            if(val_27 != null)
            {
                    val_43 = null;
                if(null != val_43)
            {
                goto label_75;
            }
            
            }
            
            val_25.OnRestartMinigame = val_27;
            SLC.Minigames.MinigameManager val_28 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            System.Action val_29 = null;
            val_39 = val_29;
            val_29 = new System.Action(object:  this, method:  public System.Void SLC.Minigames.SnackBlock.SnakeBlockManager::OnContinue());
            System.Delegate val_30 = System.Delegate.Combine(a:  val_28.OnContinueMinigame, b:  val_29);
            if(val_30 != null)
            {
                    val_43 = null;
                if(null != val_43)
            {
                goto label_75;
            }
            
            }
            
            val_28.OnContinueMinigame = val_30;
            SLC.Minigames.MinigameManager val_31 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            System.Action val_32 = null;
            val_39 = val_32;
            val_32 = new System.Action(object:  this, method:  System.Void SLC.Minigames.SnackBlock.SnakeBlockManager::OnRankUpContinue());
            System.Delegate val_33 = System.Delegate.Combine(a:  val_31.OnCheckpointRankUpContinue, b:  val_32);
            if(val_33 != null)
            {
                    val_43 = null;
                if(null != val_43)
            {
                goto label_75;
            }
            
            }
            
            val_31.OnCheckpointRankUpContinue = val_33;
            SLC.Minigames.MinigameManager val_34 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            System.Action<System.Boolean> val_35 = null;
            val_39 = val_35;
            val_35 = new System.Action<System.Boolean>(object:  this, method:  System.Void SLC.Minigames.SnackBlock.SnakeBlockManager::TogglePopupWindow(bool showing));
            System.Delegate val_36 = System.Delegate.Combine(a:  val_34.TogglePopupWindow, b:  val_35);
            if(val_36 != null)
            {
                    val_43 = null;
                if(null != val_43)
            {
                goto label_75;
            }
            
            }
            
            val_34.TogglePopupWindow = val_36;
            SLC.Minigames.MinigameManager val_37 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            val_40 = val_37.OnInjectTracking;
            val_47 = 1152921504614248448;
            System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>> val_38 = null;
            val_39 = val_38;
            val_38 = new System.Action<System.Collections.Generic.Dictionary<System.String, System.Object>>(object:  this, method:  System.Void SLC.Minigames.SnackBlock.SnakeBlockManager::Instance_OnInjectTracking(System.Collections.Generic.Dictionary<string, object> obj));
            System.Delegate val_39 = System.Delegate.Combine(a:  val_40, b:  val_38);
            if(val_39 != null)
            {
                    val_43 = null;
                if(null != val_43)
            {
                goto label_75;
            }
            
            }
            
            val_37.OnInjectTracking = val_39;
            goto label_64;
            label_44:
            val_48 = "Snake: Minigame Mismatch";
            label_38:
            UnityEngine.Debug.LogError(message:  val_48, context:  this);
            this.<inMinigameFramework>k__BackingField = false;
            label_64:
            this.StartGame(reset:  true);
            return;
            label_17:
            val_44 = val_42;
            val_43 = 0;
            throw val_44;
            label_75:
            val_45 = val_43;
            val_46 = val_44;
            if(val_45 != 1)
            {
                goto label_76;
            }
            
            val_8.Dispose();
            if(val_46 == 0)
            {
                goto label_77;
            }
            
            throw val_46;
            label_76:
        }
        private void Instance_OnInjectTracking(System.Collections.Generic.Dictionary<string, object> obj)
        {
            obj.Add(key:  "Total Lives Used", value:  this.mySnake._livesUsed);
        }
        private void TogglePopupWindow(bool showing)
        {
            this.uiCont.HideUIForPopup(showingPopup:  showing);
            UnityEngine.Camera.main.cullingMask = (int)((~showing) >> 0) & 1;
        }
        private void AddToRandomWordRowIndexes(int row)
        {
            if(this.randomSet.remainingCount() == 0)
            {
                    this.randomSet.reset();
            }
            
            this.currentWordRowIndexDict.Add(key:  row, value:  this.randomSet.roll(unweighted:  false));
        }
        public string GetWordForRowColumnIndex(int row, int column)
        {
            var val_2 = 1152921515438572976;
            int val_1 = this.currentWordRowIndexDict.Item[row];
            if(val_2 <= val_1)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_2 = val_2 + (val_1 << 3);
            var val_3 = (1152921515438572976 + (val_1) << 3) + 32;
            val_3 = val_3 + (column << 3);
            return (string)((1152921515438572976 + (val_1) << 3) + 32 + (column) << 3) + 32;
        }
        private void OnRankUpContinue()
        {
            this.StartGame(reset:  false);
        }
        public void OnContinue()
        {
            this.mySnake.enabled = true;
            UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.mySnake.Continue());
            this.isPaused = false;
        }
        private void OnRestartFromCheckpoint()
        {
            this.StartGame(reset:  true);
        }
        private void StartGame(bool reset = True)
        {
            bool val_5;
            this.GenerateLevelData();
            if(this.myLevelData != null)
            {
                    this.streamer.Spawnlevel();
            }
            
            reset = reset;
            this.mySnake.Init(reset:  reset);
            if(this.streamer.getSnakeLevel == 0)
            {
                    UnityEngine.Debug.LogError(message:  "trying to start a snake game without a level?");
                return;
            }
            
            val_5 = this.<inMinigameFramework>k__BackingField;
            if(val_5 != false)
            {
                    SLC.Minigames.MinigameManager val_3 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
                if(val_3.currentPlayerLevel != 0)
            {
                    val_5 = 0;
            }
            else
            {
                    val_5 = this.<inMinigameFramework>k__BackingField;
                if(val_5 != false)
            {
                    this.uiCont.ShowFTUX();
                val_5 = true;
            }
            
            }
            
            }
            
            this.isPaused = val_5;
            MonoSingleton<SLC.Minigames.MinigamesCheckpointSlider>.Instance.UpdateUI();
        }
        private void GenerateLevelData()
        {
            var val_18;
            var val_19;
            System.Collections.Generic.List<SLC.Minigames.SnackBlock.SnakeGridSpaceType[]> val_20;
            var val_21;
            var val_22;
            var val_23;
            System.Collections.Generic.List<SLC.Minigames.SnackBlock.SnakeGridSpaceType[]> val_24;
            System.Collections.Generic.List<SLC.Minigames.SnackBlock.SnakeGridSpaceType[]> val_25;
            this.myLevelData = new System.Collections.Generic.List<SLC.Minigames.SnackBlock.SnakeGridSpaceType[]>();
            System.Collections.Generic.Dictionary<System.Int32, System.Int32> val_2 = new System.Collections.Generic.Dictionary<System.Int32, System.Int32>();
            mem[1152921519906004712] = val_2;
            if((this.<inMinigameFramework>k__BackingField) != false)
            {
                    int val_4 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance.GetLevelsToNextCheckpoint;
                SLC.Minigames.MinigameManager val_5 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
                val_18 = val_4 & (~(val_4 >> 31));
                var val_6 = (val_5.currentPlayerLevel == 0) ? 1 : 0;
            }
            else
            {
                    val_19 = 0;
                val_18 = 5;
            }
            
            var val_17 = 3;
            do
            {
                val_2.AppendBlankRow(level: ref  this.myLevelData);
                val_17 = val_17 - 1;
            }
            while();
            
            if(5 != 0)
            {
                    var val_18 = 0;
                do
            {
                this.AppendWordRowSection(level: ref  this.myLevelData, ftux:  val_19 & ((val_18 == 0) ? 1 : 0));
                val_18 = val_18 + 1;
            }
            while(5 != val_18);
            
            }
            
            this.AppendFinshLineRow(level: ref  this.myLevelData);
            System.Text.StringBuilder val_9 = new System.Text.StringBuilder();
            val_20 = this.myLevelData;
            val_21 = 0;
            label_28:
            val_22 = mem[1152921519906036696];
            if(val_21 >= val_22)
            {
                    return;
            }
            
            val_23 = 0;
            goto label_15;
            label_26:
            if(mem[1152921519906036696] <= val_21)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_19 = mem[1152921519906036688];
            val_19 = val_19 + 0;
            var val_10 = ((mem[1152921519906036688] + 0) + 32) + 32;
            var val_12 = ((mem[1152921519906036688] + 0) + 32) + 0;
            mem2[0] = val_10;
            System.Text.StringBuilder val_14 = val_9.Append(value:  val_10.ToString() + "\t");
            val_24 = this.myLevelData;
            val_22 = mem[1152921519906036696];
            val_23 = 1;
            label_15:
            if(val_22 <= val_21)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_20 = mem[1152921519906036688];
            val_20 = val_20 + 0;
            if(val_23 < ((mem[1152921519906036688] + 0) + 32 + 24))
            {
                goto label_26;
            }
            
            System.Text.StringBuilder val_16 = val_9.Append(value:  System.Environment.NewLine);
            val_25 = this.myLevelData;
            val_21 = val_21 + 1;
            if(val_25 != null)
            {
                goto label_28;
            }
            
            throw new NullReferenceException();
        }
        private void AppendWordRowSection(ref System.Collections.Generic.List<SLC.Minigames.SnackBlock.SnakeGridSpaceType[]> level, bool ftux)
        {
            var val_17;
            var val_18;
            var val_19;
            System.Collections.Generic.List<SLC.Minigames.SnackBlock.SnakeGridSpaceType[]> val_1 = new System.Collections.Generic.List<SLC.Minigames.SnackBlock.SnakeGridSpaceType[]>();
            int val_2 = UnityEngine.Random.Range(min:  7, max:  15);
            if()
            {
                    val_17 = 1152921519906145840;
                var val_17 = 0;
                do
            {
                val_1.Add(item:  new SLC.Minigames.SnackBlock.SnakeGridSpaceType[4]);
                val_17 = val_17 + 1;
            }
            while(val_17 < val_2);
            
            }
            
            float val_18 = (float)val_2 << 2;
            val_18 = val_18 * 0.2f;
            float val_19 = (float)val_2;
            val_19 = val_19 * 0.2f;
            float val_20 = 1.6f;
            val_20 = ((float)UnityEngine.Mathf.FloorToInt(f:  val_19)) * val_20;
            int val_8 = UnityEngine.Mathf.FloorToInt(f:  val_20);
            RandomSet val_9 = new RandomSet();
            val_9.addIntRange(lowest:  1, highest:  val_2 - 1);
            val_18 = 1152921504687730688;
            System.Collections.Generic.List<System.Int32> val_10 = null;
            val_19 = 1152921510062986752;
            val_10 = new System.Collections.Generic.List<System.Int32>();
            if(val_8 >= 1)
            {
                    val_17 = 1152921510479955696;
                var val_21 = 0;
                do
            {
                val_10.Add(item:  val_9.roll(unweighted:  false));
                val_21 = val_21 + 1;
            }
            while(val_21 < val_8);
            
            }
            
            System.Collections.Generic.List<System.Int32> val_13 = new System.Collections.Generic.List<System.Int32>();
            if(null >= 1)
            {
                    val_19 = 1152921510479955696;
                do
            {
                if((0 != 0) && (0 != 1152921504687730687))
            {
                    bool val_14 = val_10.Contains(item:  0);
                if(((UnityEngine.Mathf.FloorToInt(f:  val_18)) >= 1) && (val_14 != false))
            {
                    int val_15 = val_14.AppendBlockerRow(level: ref  val_1, index:  0);
            }
            else
            {
                    val_13.Add(item:  0);
            }
            
            }
            
                val_18 = 0 + 1;
            }
            while(val_18 < 1152921504687730687);
            
            }
            
            val_13.AppendFoodRow(level: ref  val_1, validRows:  val_13, foods:  UnityEngine.Random.Range(min:  0, max:  3));
            this.AppendWordRow(level: ref  val_1, ftux:  ftux);
            if(ftux != false)
            {
                    this.AppendFtuxMessageRow(level: ref  val_1);
            }
            
            level.AddRange(collection:  val_1);
        }
        private void AppendFtuxMessageRow(ref System.Collections.Generic.List<SLC.Minigames.SnackBlock.SnakeGridSpaceType[]> level)
        {
            SLC.Minigames.SnackBlock.SnakeGridSpaceType[] val_1 = new SLC.Minigames.SnackBlock.SnakeGridSpaceType[4];
            val_1[0] = 0;
            val_1[0] = 8;
            val_1[1] = 0;
            val_1[1] = 0;
            level.Add(item:  val_1);
        }
        private void AppendWordRow(ref System.Collections.Generic.List<SLC.Minigames.SnackBlock.SnakeGridSpaceType[]> level, bool ftux)
        {
            SLC.Minigames.SnackBlock.SnakeGridSpaceType[] val_1 = new SLC.Minigames.SnackBlock.SnakeGridSpaceType[4];
            int val_2 = UnityEngine.Random.Range(min:  0, max:  4);
            if((val_1.Length << 32) >= 1)
            {
                    var val_7 = 0;
                do
            {
                if(val_2 == val_7)
            {
                    mem2[0] = (ftux != true) ? 6 : 2;
            }
            else
            {
                    mem2[0] = (ftux != true) ? 7 : 3;
            }
            
                val_7 = val_7 + 1;
            }
            while(val_7 < (long)val_1.Length);
            
            }
            
            this.AddToRandomWordRowIndexes(row:  (mem[level + 24]) + this.myLevelData);
            level.Add(item:  val_1);
        }
        private void AppendBlankRow(ref System.Collections.Generic.List<SLC.Minigames.SnackBlock.SnakeGridSpaceType[]> level)
        {
            SLC.Minigames.SnackBlock.SnakeGridSpaceType[] val_1 = new SLC.Minigames.SnackBlock.SnakeGridSpaceType[4];
            if((val_1.Length << 32) >= 1)
            {
                    var val_3 = 0;
                do
            {
                mem2[0] = 0;
                val_3 = val_3 + 1;
            }
            while(val_3 < (long)val_1.Length);
            
            }
            
            level.Add(item:  val_1);
        }
        private void AppendFinshLineRow(ref System.Collections.Generic.List<SLC.Minigames.SnackBlock.SnakeGridSpaceType[]> level)
        {
            SLC.Minigames.SnackBlock.SnakeGridSpaceType[] val_1 = new SLC.Minigames.SnackBlock.SnakeGridSpaceType[4];
            if((val_1.Length << 32) >= 1)
            {
                    var val_3 = 0;
                do
            {
                mem2[0] = 5;
                val_3 = val_3 + 1;
            }
            while(val_3 < (long)val_1.Length);
            
            }
            
            level.Add(item:  val_1);
        }
        private int AppendBlockerRow(ref System.Collections.Generic.List<SLC.Minigames.SnackBlock.SnakeGridSpaceType[]> level, int index)
        {
            var val_7;
            var val_8;
            var val_9;
            var val_10;
            val_7 = index;
            int val_1 = val_7 - 1;
            if((mem[level + 24]) <= val_1)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_8 = mem[level + 16];
            val_8 = val_8 + (val_1 << 3);
            if(((mem[level + 16] + ((index - 1)) << 3) + 32 + 24) < 1)
            {
                goto label_4;
            }
            
            var val_9 = 0;
            label_7:
            var val_2 = ((mem[level + 16] + ((index - 1)) << 3) + 32) + 0;
            if((((mem[level + 16] + ((index - 1)) << 3) + 32 + 0) + 32) != 0)
            {
                goto label_6;
            }
            
            val_9 = val_9 + 1;
            if(val_9 < ((mem[level + 16] + ((index - 1)) << 3) + 32 + 24))
            {
                goto label_7;
            }
            
            label_4:
            val_8 = 0;
            val_9 = 0;
            val_10 = 1;
            label_19:
            if((mem[level + 24]) <= val_7)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_10 = mem[level + 16];
            val_10 = val_10 + (((long)(int)(index)) << 3);
            if(val_8 >= ((mem[level + 16] + ((long)(int)(index)) << 3) + 32 + 24))
            {
                goto label_24;
            }
            
            if((mem[level + 24]) <= val_7)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_11 = mem[level + 16];
            val_11 = val_11 + (((long)(int)(index)) << 3);
            var val_12 = (mem[level + 16] + ((long)(int)(index)) << 3) + 32;
            if((UnityEngine.Random.Range(min:  0, max:  6)) > 1)
            {
                    val_12 = val_12 + 0;
                val_9 = val_9 + 1;
                mem2[0] = val_10;
            }
            else
            {
                    val_12 = val_12 + 0;
                mem2[0] = 0;
            }
            
            val_8 = val_8 + 1;
            if(level != null)
            {
                goto label_19;
            }
            
            label_6:
            val_9 = 0;
            val_8 = (long)val_7;
            var val_16 = 8;
            val_10 = 1;
            label_37:
            if((mem[level + 24]) <= val_7)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_13 = mem[level + 16];
            val_13 = val_13 + (((long)(int)(index)) << 3);
            if((val_16 - 8) >= ((mem[level + 16] + ((long)(int)(index)) << 3) + 32 + 24))
            {
                goto label_24;
            }
            
            if(((UnityEngine.Random.Range(min:  0, max:  5)) >= 1) && (((mem[level + 16] + ((index - 1)) << 3) + 32 + 32) != 0))
            {
                    if((mem[level + 24]) <= val_7)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                var val_14 = mem[level + 16];
                val_14 = val_14 + (((long)(int)(index)) << 3);
                val_9 = val_9 + 1;
                mem2[0] = val_10;
            }
            else
            {
                    if((mem[level + 24]) <= val_7)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                var val_15 = mem[level + 16];
                val_15 = val_15 + (((long)(int)(index)) << 3);
                mem2[0] = 0;
            }
            
            val_16 = val_16 + 1;
            if(level != null)
            {
                goto label_37;
            }
            
            label_24:
            if(val_9 != 4)
            {
                    return (int)val_9;
            }
            
            if((mem[level + 24]) <= val_7)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_17 = mem[level + 16];
            val_17 = val_17 + (val_7 << 3);
            val_7 = mem[(mem[level + 16] + (index) << 3) + 32];
            val_7 = (mem[level + 16] + (index) << 3) + 32;
            var val_7 = val_7 + ((UnityEngine.Random.Range(min:  0, max:  4)) << 2);
            mem2[0] = 0;
            return (int)val_9;
        }
        private void AppendFoodRow(ref System.Collections.Generic.List<SLC.Minigames.SnackBlock.SnakeGridSpaceType[]> level, System.Collections.Generic.List<int> validRows, int foods)
        {
            bool val_4 = true;
            if(foods < 1)
            {
                    return;
            }
            
            var val_7 = 0;
            label_12:
            if(level == null)
            {
                goto label_3;
            }
            
            int val_1 = UnityEngine.Random.Range(min:  0, max:  -1879709664);
            if(val_4 <= val_1)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_4 = val_4 + (val_1 << 2);
            bool val_2 = validRows.Remove(item:  (true + (val_1) << 2) + 32);
            if((mem[level + 24]) <= ((long)(true + (val_1) << 2) + 32))
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_5 = mem[level + 16];
            val_5 = val_5 + (((long)(int)((true + (val_1) << 2) + 32)) << 3);
            if((mem[level + 24]) <= ((long)(true + (val_1) << 2) + 32))
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_6 = mem[level + 16];
            val_6 = val_6 + (((long)(int)((true + (val_1) << 2) + 32)) << 3);
            var val_8 = (mem[level + 16] + ((long)(int)((true + (val_1) << 2) + 32)) << 3) + 32;
            val_7 = val_7 + 1;
            val_8 = val_8 + ((UnityEngine.Random.Range(min:  0, max:  (mem[level + 16] + ((long)(int)((true + (val_1) << 2) + 32)) << 3) + 32 + 24)) << 2);
            mem2[0] = 4;
            if(val_7 < foods)
            {
                goto label_12;
            }
            
            return;
            label_3:
            UnityEngine.Debug.LogError(message:  "not enough valid rows to get a food row");
        }
        public void HandleFailed()
        {
            this.isPaused = true;
            if((this.<inMinigameFramework>k__BackingField) != false)
            {
                    bool val_2 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleLevelFailed();
                return;
            }
            
            int val_3 = this._snakePlayerLevel;
            val_3 = val_3 - 1;
            this._snakePlayerLevel = val_3;
            this.StartGame(reset:  true);
        }
        public void HandleComplete()
        {
            if((this.<inMinigameFramework>k__BackingField) == false)
            {
                    return;
            }
            
            if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleLevelComplete()) != false)
            {
                    this.isPaused = true;
            }
            else
            {
                    this = this.streamer;
                UnityEngine.Coroutine val_4 = this.StartCoroutine(routine:  this.SpawnNext());
            }
            
            MonoSingleton<SLC.Minigames.MinigamesCheckpointSlider>.Instance.UpdateUI();
        }
        public void HACK_InstantWin()
        {
            this.HandleComplete();
        }
        public void OnPauseInput()
        {
            bool val_2 = this.isPaused;
            val_2 = val_2 ^ 1;
            this.isPaused = val_2;
            MonoSingleton<SLC.Minigames.MinigamesCheckpointSlider>.Instance.UpdateUI();
        }
        public void DisableAvoidText()
        {
            if(this.avoidText != 0)
            {
                    this.avoidText.SetActive(value:  false);
            }
            
            this.hasFTUXCollided = true;
        }
        public SnakeBlockManager()
        {
            this._snakeObjectivesReq = 3;
            this.curLevelSpeed = 0.1f;
            this.randomSet = new RandomSet();
        }
    
    }

}
