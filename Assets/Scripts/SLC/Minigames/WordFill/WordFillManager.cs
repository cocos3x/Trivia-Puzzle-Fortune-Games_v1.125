using UnityEngine;

namespace SLC.Minigames.WordFill
{
    public class WordFillManager : MonoSingleton<SLC.Minigames.WordFill.WordFillManager>
    {
        // Fields
        private System.Collections.Generic.List<int> levelSizes;
        private System.Collections.Generic.List<float> levelTimers;
        private System.Collections.Generic.List<string> categoryNames;
        private System.Collections.Generic.Dictionary<string, SLC.Minigames.WordFill.WFCategory> categories;
        private System.Collections.Generic.Dictionary<string, SLC.Minigames.WordFill.WFLShapeDef> shapeDefs;
        private System.Collections.Generic.Dictionary<int, System.Collections.Generic.List<SLC.Minigames.WordFill.WFLComb>> levelConfigs;
        private bool init;
        private int <playerLevel>k__BackingField;
        private int <playerLevelSize>k__BackingField;
        private float <playerLevelTime>k__BackingField;
        private string <playerLevelCategory>k__BackingField;
        private int <playerLives>k__BackingField;
        private SLC.Minigames.WordFill.WordFillLevel currentLevel;
        private System.Collections.Generic.Queue<string> categoryHist;
        private System.Collections.Generic.HashSet<string> commonAndUncommonWords;
        
        // Properties
        public int playerLevel { get; set; }
        public int playerLevelSize { get; set; }
        public float playerLevelTime { get; set; }
        public string playerLevelCategory { get; set; }
        public int playerLives { get; set; }
        
        // Methods
        public int get_playerLevel()
        {
            return (int)this.<playerLevel>k__BackingField;
        }
        protected void set_playerLevel(int value)
        {
            this.<playerLevel>k__BackingField = value;
        }
        public int get_playerLevelSize()
        {
            return (int)this.<playerLevelSize>k__BackingField;
        }
        protected void set_playerLevelSize(int value)
        {
            this.<playerLevelSize>k__BackingField = value;
        }
        public float get_playerLevelTime()
        {
            return (float)this.<playerLevelTime>k__BackingField;
        }
        protected void set_playerLevelTime(float value)
        {
            this.<playerLevelTime>k__BackingField = value;
        }
        public string get_playerLevelCategory()
        {
            return (string)this.<playerLevelCategory>k__BackingField;
        }
        protected void set_playerLevelCategory(string value)
        {
            this.<playerLevelCategory>k__BackingField = value;
        }
        public int get_playerLives()
        {
            return (int)this.<playerLives>k__BackingField;
        }
        protected void set_playerLives(int value)
        {
            this.<playerLives>k__BackingField = value;
        }
        public override void InitMonoSingleton()
        {
            this.Initialize();
        }
        private void Initialize()
        {
            if(this.init == true)
            {
                    return;
            }
            
            this.LoadData();
            SLC.Minigames.MinigameManager val_1 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            val_1.OnRestartMinigame = new System.Action(object:  this, method:  System.Void SLC.Minigames.WordFill.WordFillManager::ResetLevel());
            SLC.Minigames.MinigameManager val_3 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            val_3.OnContinueMinigame = new System.Action(object:  this, method:  System.Void SLC.Minigames.WordFill.WordFillManager::ResetLevel());
            SLC.Minigames.MinigameManager val_5 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            val_5.OnCheckpointRankUpContinue = new System.Action(object:  this, method:  System.Void SLC.Minigames.WordFill.WordFillManager::ContinueToggleUI());
            this.init = true;
        }
        private void Start()
        {
            this.<playerLevelTime>k__BackingField = 30f;
            this.<playerLevel>k__BackingField = 0;
            this.<playerLevelSize>k__BackingField = 6;
            this.<playerLives>k__BackingField = 3;
            this.ResetLevel();
        }
        private void LoadData()
        {
            System.Collections.Generic.List<System.Object> val_12;
            var val_13;
            System.Collections.Generic.List<System.Object> val_45;
            System.Collections.Generic.List<System.Single> val_46;
            var val_47;
            var val_49;
            var val_50;
            string val_51;
            var val_52;
            if(this.levelSizes == null)
            {
                    throw new NullReferenceException();
            }
            
            val_45 = 1152921515441984688;
            this.levelSizes.Clear();
            if(this.levelTimers == null)
            {
                    throw new NullReferenceException();
            }
            
            this.levelTimers.Clear();
            val_45 = "minigames/WordFill/word_fill_levels";
            UnityEngine.TextAsset val_1 = UnityEngine.Resources.Load<UnityEngine.TextAsset>(path:  "minigames/WordFill/word_fill_levels");
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            if((MiniJSON.Json.Deserialize(json:  val_1.text)) == null)
            {
                    throw new NullReferenceException();
            }
            
            val_45 = null;
            if(1152921504687730687 >= 1)
            {
                    var val_48 = 1;
                do
            {
                val_46 = this.levelTimers;
                var val_4 = val_48 - 1;
                if(val_45 <= val_4)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                if(val_46 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_45 = val_45 + (val_4 << 3);
                if(((val_45 + ((1 - 1)) << 3) + 32) == 0)
            {
                    throw new NullReferenceException();
            }
            
                val_45 = mem[(val_45 + ((1 - 1)) << 3) + 32 + 64];
                val_45 = (val_45 + ((1 - 1)) << 3) + 32 + 64;
                val_46.Add(item:  (val_45 + ((1 - 1)) << 3) + 32);
                val_46 = this.levelSizes;
                val_4 = val_4 + 1;
                if(val_45 <= val_4)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                if(val_46 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_45 = val_45 + 8;
                if((((val_45 + ((1 - 1)) << 3) + 32 + 64 + 8) + 32) == 0)
            {
                    throw new NullReferenceException();
            }
            
                val_45 = mem[((val_45 + ((1 - 1)) << 3) + 32 + 64 + 8) + 32 + 64];
                val_45 = ((val_45 + ((1 - 1)) << 3) + 32 + 64 + 8) + 32 + 64;
                val_46.Add(item:  ((val_45 + ((1 - 1)) << 3) + 32 + 64 + 8) + 32);
                val_48 = val_48 + 2;
            }
            while((val_4 + 1) < (val_45 - 1));
            
            }
            
            if(this.categories == null)
            {
                    throw new NullReferenceException();
            }
            
            val_45 = 1152921519818584592;
            this.categories.Clear();
            if(this.categoryNames == null)
            {
                    throw new NullReferenceException();
            }
            
            this.categoryNames.Clear();
            val_45 = "minigames/WordFill/word_fill_categories";
            UnityEngine.TextAsset val_7 = UnityEngine.Resources.Load<UnityEngine.TextAsset>(path:  "minigames/WordFill/word_fill_categories");
            if(val_7 == null)
            {
                    throw new NullReferenceException();
            }
            
            if((MiniJSON.Json.Deserialize(json:  val_7.text)) == null)
            {
                    throw new NullReferenceException();
            }
            
            val_45 = null;
            List.Enumerator<T> val_11 = GetEnumerator();
            val_45 = val_12;
            label_32:
            if(val_13.MoveNext() == false)
            {
                goto label_25;
            }
            
            val_46 = val_45;
            if(val_46 != 0)
            {
                    val_45 = mem[val_12];
                val_45 = val_46;
                val_45 = (val_12 + 200 + (System.Collections.Generic.List<T>.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8;
                if(val_45 != null)
            {
                    throw new NullReferenceException();
            }
            
            }
            
            new SLC.Minigames.WordFill.WFCategory() = new SLC.Minigames.WordFill.WFCategory(data:  val_46);
            if(new SLC.Minigames.WordFill.WFCategory() == null)
            {
                    throw new NullReferenceException();
            }
            
            if(this.categories == null)
            {
                    throw new NullReferenceException();
            }
            
            this.categories.Add(key:  (SLC.Minigames.WordFill.WFCategory)[1152921519818831648].name, value:  new SLC.Minigames.WordFill.WFCategory());
            if(this.categoryNames == null)
            {
                    throw new NullReferenceException();
            }
            
            this.categoryNames.Add(item:  (SLC.Minigames.WordFill.WFCategory)[1152921519818831648].name);
            goto label_32;
            label_25:
            val_45 = 252;
            val_13.Dispose();
            if(this.shapeDefs == null)
            {
                    throw new NullReferenceException();
            }
            
            this.shapeDefs.Clear();
            val_45 = "minigames/WordFill/shape_def";
            UnityEngine.TextAsset val_16 = UnityEngine.Resources.Load<UnityEngine.TextAsset>(path:  "minigames/WordFill/shape_def");
            if(val_16 == null)
            {
                    throw new NullReferenceException();
            }
            
            if((MiniJSON.Json.Deserialize(json:  val_16.text)) == null)
            {
                    throw new NullReferenceException();
            }
            
            val_45 = null;
            List.Enumerator<T> val_20 = GetEnumerator();
            val_45 = val_12;
            label_45:
            if(val_13.MoveNext() == false)
            {
                goto label_40;
            }
            
            val_46 = val_45;
            if(val_46 != 0)
            {
                    val_47 = null;
                val_45 = mem[val_12];
                val_45 = val_46;
                if(val_45 != val_47)
            {
                goto label_114;
            }
            
            }
            
            new SLC.Minigames.WordFill.WFLShapeDef() = new SLC.Minigames.WordFill.WFLShapeDef(data:  val_46);
            if(new SLC.Minigames.WordFill.WFLShapeDef() == null)
            {
                    throw new NullReferenceException();
            }
            
            if(this.shapeDefs == null)
            {
                    throw new NullReferenceException();
            }
            
            this.shapeDefs.Add(key:  (SLC.Minigames.WordFill.WFLShapeDef)[1152921519818868512].id, value:  new SLC.Minigames.WordFill.WFLShapeDef());
            goto label_45;
            label_40:
            val_45 = 360;
            val_13.Dispose();
            label_121:
            if(this.levelConfigs == null)
            {
                    throw new NullReferenceException();
            }
            
            this.levelConfigs.Clear();
            val_45 = "minigames/WordFill/word_fill_configurations";
            UnityEngine.TextAsset val_23 = UnityEngine.Resources.Load<UnityEngine.TextAsset>(path:  "minigames/WordFill/word_fill_configurations");
            if(val_23 == null)
            {
                    throw new NullReferenceException();
            }
            
            object val_25 = MiniJSON.Json.Deserialize(json:  val_23.text);
            if(val_25 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_45 = null;
            val_45 = 1152921510214903248;
            Dictionary.KeyCollection<TKey, TValue> val_26 = val_25.Keys;
            if(val_26 == null)
            {
                    throw new NullReferenceException();
            }
            
            Dictionary.KeyCollection.Enumerator<TKey, TValue> val_27 = val_26.GetEnumerator();
            var val_50 = 0;
            label_68:
            if(val_13.MoveNext() == false)
            {
                goto label_52;
            }
            
            val_46 = val_12;
            val_45 = 1152921519818691536;
            this.levelConfigs.Add(key:  System.Int32.Parse(s:  val_46), value:  new System.Collections.Generic.List<SLC.Minigames.WordFill.WFLComb>());
            if(val_25.Item[val_46] == null)
            {
                    throw new NullReferenceException();
            }
            
            val_45 = null;
            List.Enumerator<T> val_33 = GetEnumerator();
            val_45 = val_12;
            label_64:
            if(val_13.MoveNext() == false)
            {
                goto label_59;
            }
            
            if(val_45 != 0)
            {
                    val_45 = mem[val_12];
                val_45 = val_45;
                if(val_45 != null)
            {
                    throw new NullReferenceException();
            }
            
            }
            
            if(this.levelConfigs == null)
            {
                    throw new NullReferenceException();
            }
            
            System.Collections.Generic.List<SLC.Minigames.WordFill.WFLComb> val_36 = this.levelConfigs.Item[System.Int32.Parse(s:  val_46)];
            if(val_36 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_36.Add(item:  new SLC.Minigames.WordFill.WFLComb(data:  val_45));
            goto label_64;
            label_59:
            val_46 = 0;
            var val_38 = val_50 + 1;
            mem2[0] = 534;
            val_45 = 1152921510348445696;
            val_13.Dispose();
            if(val_46 != 0)
            {
                goto label_65;
            }
            
            if((val_38 == 1) || ((-1967977904 + ((0 + 1)) << 2) != 534))
            {
                goto label_68;
            }
            
            var val_49 = 0;
            val_49 = val_49 ^ (val_38 >> 31);
            var val_39 = val_38 + val_49;
            goto label_68;
            label_52:
            val_50 = val_50 + 1;
            val_45 = 562;
            mem2[0] = 562;
            val_13.Dispose();
            val_46 = 1152921515835282704;
            if(val_50 != 1)
            {
                    var val_40 = ((-1967977904 + ((0 + 1)) << 2) == 562) ? 1 : 0;
                val_40 = ((val_50 >= 0) ? 1 : 0) & val_40;
                val_40 = val_50 - val_40;
                val_45 = val_40 + 1;
                val_50 = (long)val_45;
            }
            else
            {
                    val_50 = 0;
            }
            
            if(this.commonAndUncommonWords == null)
            {
                    throw new NullReferenceException();
            }
            
            this.commonAndUncommonWords.Clear();
            val_45 = "minigames/WordFill/word_fill_words";
            UnityEngine.TextAsset val_42 = UnityEngine.Resources.Load<UnityEngine.TextAsset>(path:  "minigames/WordFill/word_fill_words");
            if(val_42 == null)
            {
                    throw new NullReferenceException();
            }
            
            object val_44 = MiniJSON.Json.Deserialize(json:  val_42.text);
            if(val_44 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_45 = null;
            List.Enumerator<T> val_45 = val_44.GetEnumerator();
            val_45 = val_12;
            val_46 = 1152921515719925760;
            label_91:
            if(val_13.MoveNext() == false)
            {
                goto label_87;
            }
            
            val_51 = val_45;
            if(val_51 == 0)
            {
                goto label_88;
            }
            
            val_45 = null;
            if(val_51 != val_45)
            {
                goto label_89;
            }
            
            label_88:
            if(this.commonAndUncommonWords == null)
            {
                    throw new NullReferenceException();
            }
            
            bool val_47 = this.commonAndUncommonWords.Add(item:  val_51);
            goto label_91;
            label_87:
            val_13.Dispose();
            return;
            label_65:
            val_51 = 0;
            throw X21;
            label_89:
            val_47;
            label_114:
            val_49 = X21;
            if(val_47 != 1)
            {
                goto label_123;
            }
            
            val_52 = mem[X21];
            val_52 = val_49;
            val_13.Dispose();
            if(val_52 == 0)
            {
                goto label_121;
            }
            
            throw null;
            label_123:
        }
        private void ResetLevel()
        {
            SLC.Minigames.WordFill.WordFillUIController val_1 = MonoSingleton<SLC.Minigames.WordFill.WordFillUIController>.Instance;
            val_1.canvas.enabled = true;
            this.<playerLives>k__BackingField = 3;
            this.CreateLevel();
            MonoSingleton<WordFillFTUXManager>.Instance.SetLevel(lev:  this.<playerLevel>k__BackingField);
            MonoSingleton<SLC.Minigames.WordFill.WordFillUIController>.Instance.StartLevel(level:  this.currentLevel);
        }
        private void CreateLevel()
        {
            int val_25;
            SLC.Minigames.WordFill.WFCategory val_26;
            SLC.Minigames.MinigameManager val_1 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            this.<playerLevel>k__BackingField = val_1.currentPlayerLevel;
            if((MonoSingleton<WordFillFTUXManager>.Instance.IsFtuxLevel(lev:  this.<playerLevel>k__BackingField)) != false)
            {
                    this.<playerLevelSize>k__BackingField = MonoSingleton<WordFillFTUXManager>.Instance.GetFtuxLevelSize(lev:  this.<playerLevel>k__BackingField);
                this.<playerLevelTime>k__BackingField = MonoSingleton<WordFillFTUXManager>.Instance.GetFtuxLevelTime(lev:  this.<playerLevel>k__BackingField);
                this.currentLevel = MonoSingleton<WordFillFTUXManager>.Instance.GetFtuxLevel(lev:  this.<playerLevel>k__BackingField);
                string val_11 = MonoSingleton<WordFillFTUXManager>.Instance.GetFtuxLevelCategory(lev:  this.<playerLevel>k__BackingField);
                this.<playerLevelCategory>k__BackingField = val_11;
                this.categoryHist.Enqueue(item:  val_11);
                return;
            }
            
            val_25 = this.<playerLevel>k__BackingField;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_25 = this.<playerLevel>k__BackingField;
            this.<playerLevelSize>k__BackingField = (MonoSingleton<T>.__il2cppRuntimeField_cctor_finished + ((long)(int)(this.<playerLevel>k__BackingField)) << 2) + 32;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            this.<playerLevelTime>k__BackingField = ((MonoSingleton<T>.__il2cppRuntimeField_cctor_finished + ((long)(int)(this.<playerLevel>k__BackingField)) << 2) + 32 + (this.<playerLevel>k__BackingField) << 2) + 32;
            System.Collections.Generic.List<SLC.Minigames.WordFill.WFLComb> val_12 = this.levelConfigs.Item[this.<playerLevelSize>k__BackingField];
            System.Collections.Generic.List<System.Single> val_13 = this.levelTimers - 1;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_26 = 0;
            goto label_39;
            label_41:
            val_13 = (RandomSet.singleInRange(lowest:  0, highest:  val_13)) - 1;
            int val_15 = RandomSet.singleInRange(lowest:  0, highest:  val_13);
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            label_35:
            if((this.categoryHist.Contains(item:  0)) == false)
            {
                goto label_30;
            }
            
            int val_18 = RandomSet.singleInRange(lowest:  0, highest:  -1);
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            if(this.categoryHist != null)
            {
                goto label_35;
            }
            
            label_30:
            if(((RandomSet.__il2cppRuntimeField_cctor_finished + (val_14) << 3) + 32.CanSupport(cat:  this.categories.Item[0])) != false)
            {
                    val_26 = this.categories.Item[0];
            }
            
            label_39:
            if(val_26 == null)
            {
                goto label_41;
            }
            
            this.categoryHist.Enqueue(item:  val_22.name);
            if(1152921516430120400 >= 51)
            {
                    string val_23 = this.categoryHist.Dequeue();
            }
            
            this.currentLevel = (RandomSet.__il2cppRuntimeField_cctor_finished + (val_14) << 3) + 32.CreateLevel(cat:  val_26, shapeDefs:  this.shapeDefs);
            this.<playerLevelCategory>k__BackingField = val_22.name;
        }
        public void LostLife()
        {
            int val_4 = this.<playerLives>k__BackingField;
            val_4 = val_4 - 1;
            if()
            {
                    return;
            }
            
            this.<playerLives>k__BackingField = val_4;
            if(val_4 > 0)
            {
                    return;
            }
            
            bool val_2 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleLevelFailed();
            SLC.Minigames.WordFill.WordFillUIController val_3 = MonoSingleton<SLC.Minigames.WordFill.WordFillUIController>.Instance;
            val_3.overlay = true;
        }
        public void BeatLevel()
        {
            if((MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleLevelComplete()) != false)
            {
                    SLC.Minigames.WordFill.WordFillUIController val_3 = MonoSingleton<SLC.Minigames.WordFill.WordFillUIController>.Instance;
                val_3.overlay = true;
            }
            
            MonoSingleton<SLC.Minigames.MinigamesCheckpointSlider>.Instance.UpdateUI();
        }
        public void StartNextLevel()
        {
            UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.OnStartNextLevel());
        }
        private System.Collections.IEnumerator OnStartNextLevel()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new WordFillManager.<OnStartNextLevel>d__39();
        }
        public bool IsValidWord(string word)
        {
            return this.commonAndUncommonWords.Contains(item:  word);
        }
        private void ContinueToggleUI()
        {
            SLC.Minigames.WordFill.WordFillUIController val_1 = MonoSingleton<SLC.Minigames.WordFill.WordFillUIController>.Instance;
            val_1.overlay = false;
        }
        public WordFillManager()
        {
            this.levelSizes = new System.Collections.Generic.List<System.Int32>();
            this.levelTimers = new System.Collections.Generic.List<System.Single>();
            this.categoryNames = new System.Collections.Generic.List<System.String>();
            this.categories = new System.Collections.Generic.Dictionary<System.String, SLC.Minigames.WordFill.WFCategory>();
            this.shapeDefs = new System.Collections.Generic.Dictionary<System.String, SLC.Minigames.WordFill.WFLShapeDef>();
            this.levelConfigs = new System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<SLC.Minigames.WordFill.WFLComb>>();
            this.categoryHist = new System.Collections.Generic.Queue<System.String>();
            this.commonAndUncommonWords = new System.Collections.Generic.HashSet<System.String>();
        }
    
    }

}
