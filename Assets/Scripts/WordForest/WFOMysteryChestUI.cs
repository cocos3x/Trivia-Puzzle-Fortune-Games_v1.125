using UnityEngine;

namespace WordForest
{
    public class WFOMysteryChestUI : MonoSingleton<WordForest.WFOMysteryChestUI>
    {
        // Fields
        private UnityEngine.GameObject prefabMysteryChestTile;
        private UnityEngine.GameObject prefabMysteryChestDisplay;
        private DG.Tweening.Ease easeX;
        private System.Collections.Generic.List<UnityEngine.AnimationCurve> curveY;
        private WordForest.WFOMysteryChestManager mysteryChestManager;
        private WordRegion wordRegion;
        public System.Collections.Generic.List<WordForest.MysteryChest> mysteryChestTiles;
        private int currentAssociatedLevel;
        private static bool <isMysteryChestFlowActive>k__BackingField;
        
        // Properties
        public static bool isMysteryChestFlowActive { get; set; }
        public UnityEngine.GameObject PrefabMysteryChestDisplay { get; }
        private bool IsTileCurrentlyInPlay { get; }
        
        // Methods
        public static bool get_isMysteryChestFlowActive()
        {
            return (bool)WordForest.WFOMysteryChestUI.<isMysteryChestFlowActive>k__BackingField;
        }
        private static void set_isMysteryChestFlowActive(bool value)
        {
            WordForest.WFOMysteryChestUI.<isMysteryChestFlowActive>k__BackingField = value;
        }
        public UnityEngine.GameObject get_PrefabMysteryChestDisplay()
        {
            return (UnityEngine.GameObject)this.prefabMysteryChestDisplay;
        }
        public bool IsChestTileAvailable(int chestIndex)
        {
            var val_2;
            System.Collections.Generic.List<WordForest.MysteryChest> val_3;
            var val_4;
            val_2 = chestIndex;
            bool val_2 = true;
            val_3 = this.mysteryChestTiles;
            if(val_2 <= val_2)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_2 = val_2 + (val_2 << 3);
            var val_3 = (true + (chestIndex) << 3) + 32 + 24;
            if((val_3 & 2147483648) == 0)
            {
                    val_3 = (long)val_2;
                if(val_3 <= val_2)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_3 = val_3 + (((long)(int)(chestIndex)) << 3);
                var val_4 = ((true + (chestIndex) << 3) + 32 + 24 + ((long)(int)(chestIndex)) << 3) + 32 + 24;
                if(val_4 < this.wordRegion)
            {
                    if(val_4 <= val_2)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_4 = val_4 + (((long)(int)(chestIndex)) << 3);
                var val_5 = (((true + (chestIndex) << 3) + 32 + 24 + ((long)(int)(chestIndex)) << 3) + 32 + 24 + ((long)(int)(chestIndex)) << 3) + 32 + 28;
                if((val_5 & 2147483648) == 0)
            {
                    if(val_5 <= val_2)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_5 = val_5 + (((long)(int)(chestIndex)) << 3);
                var val_6 = ((((true + (chestIndex) << 3) + 32 + 24 + ((long)(int)(chestIndex)) << 3) + 32 + 24 + ((long)(int)(chestIndex)) << 3) + 32 + 28 + ((long)(int)(chestIndex)) << 3) + 32;
                if(W10 <= val_2)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_6 = val_6 + (((long)(int)(chestIndex)) << 3);
                var val_7 = (((((true + (chestIndex) << 3) + 32 + 24 + ((long)(int)(chestIndex)) << 3) + 32 + 24 + ((long)(int)(chestIndex)) << 3) + 32 + 28 + ((long)(int)(chestIndex)) << 3) + 32 + ((long)(int)(chestIndex)) << 3 + 32;
                val_2 = mem[(((((true + (chestIndex) << 3) + 32 + 24 + ((long)(int)(chestIndex)) << 3) + 32 + 24 + ((long)(int)(chestIndex)) << 3) + 32 + 28 + ((long)(int)(chestIndex)) << 3) + 32 + ((long)(int)(chestIndex)) << 3 + 32 + 24];
                val_2 = (((((true + (chestIndex) << 3) + 32 + 24 + ((long)(int)(chestIndex)) << 3) + 32 + 24 + ((long)(int)(chestIndex)) << 3) + 32 + 28 + ((long)(int)(chestIndex)) << 3) + 32 + ((long)(int)(chestIndex)) << 3 + 32 + 24;
                if(val_7 <= val_2)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_7 = val_7 + (((((((true + (chestIndex) << 3) + 32 + 24 + ((long)(int)(chestIndex)) << 3) + 32 + 24 + ((long)(int)(chestIndex)) << 3) + 32 + 28 + ((long)(int)(chestIndex)) << 3) + 32 + ((long)(int)(chestIndex)) << 3 + 32 + 24) << 3);
                var val_1 = ((((((true + (chestIndex) << 3) + 32 + 24 + ((long)(int)(chestIndex)) << 3) + 32 + 24 + ((long)(int)(chestIndex)) << 3) + 32 + 28 + ((long)(int)(chestIndex)) << 3) + 32 + 28) < (((((((true + (chestIndex) << 3) + 32 + 24 + ((long)(int)(chestIndex)) << 3) + 32 + 24 + ((long)(int)(chestIndex)) << 3) + 32 + 28 + ((long)(int)(chestIndex)) << 3) + 32 + ((long)(int)(chestIndex)) <<  + 32 + 40 + 24)) ? 1 : 0;
                return (bool)val_4;
            }
            
            }
            
            }
            
            val_4 = 0;
            return (bool)val_4;
        }
        private bool get_IsTileCurrentlyInPlay()
        {
            var val_4;
            var val_4 = 0;
            label_4:
            if(val_4 >= this.mysteryChestTiles)
            {
                goto label_2;
            }
            
            if((this.IsChestTileAvailable(chestIndex:  0)) == true)
            {
                goto label_3;
            }
            
            val_4 = val_4 + 1;
            if(this.mysteryChestTiles != null)
            {
                goto label_4;
            }
            
            throw new NullReferenceException();
            label_2:
            val_4 = 0;
            goto label_5;
            label_3:
            val_4 = 1;
            label_5:
            int val_2 = PlayingLevel.GetCurrentPlayerLevelNumber();
            val_2 = val_4 & ((this.currentAssociatedLevel == val_2) ? 1 : 0);
            return (bool)val_2;
        }
        private void Start()
        {
            this.mysteryChestManager = MonoSingleton<WordForest.WFOMysteryChestManager>.Instance;
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnBeforeLevelStart");
            SceneDictator val_3 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
            System.Delegate val_5 = System.Delegate.Combine(a:  val_3.OnSceneLoaded, b:  new System.Action<SceneType>(object:  this, method:  System.Void WordForest.WFOMysteryChestUI::OnSceneLoaded(SceneType obj)));
            if(val_5 != null)
            {
                    if(null != null)
            {
                goto label_10;
            }
            
            }
            
            val_3.OnSceneLoaded = val_5;
            return;
            label_10:
        }
        private void OnDestroy()
        {
            SceneDictator val_1 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
            System.Delegate val_3 = System.Delegate.Remove(source:  val_1.OnSceneLoaded, value:  new System.Action<SceneType>(object:  this, method:  System.Void WordForest.WFOMysteryChestUI::OnSceneLoaded(SceneType obj)));
            if(val_3 != null)
            {
                    if(null != null)
            {
                goto label_5;
            }
            
            }
            
            val_1.OnSceneLoaded = val_3;
            return;
            label_5:
        }
        private void OnSceneLoaded(SceneType obj)
        {
            if(WordForest.WFOMysteryChestManager.IsFeatureUnlocked == false)
            {
                    return;
            }
            
            if(obj != 2)
            {
                    return;
            }
            
            if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) == true)
            {
                    return;
            }
            
            if(WordRegion.instance == 0)
            {
                    return;
            }
            
            WordRegion val_6 = WordRegion.instance;
            this.wordRegion = val_6;
            val_6.addOnPreprocessPlayerTurnAction(callback:  new System.Action<System.Boolean, System.String, LineWord, Cell>(object:  this, method:  System.Void WordForest.WFOMysteryChestUI::OnWordRegionPreprocessPlayerTurn(bool hintUsage, string wordEntered, LineWord lineWord, Cell cell)));
            this.wordRegion.addOnWordFoundAction(callback:  new System.Action<System.String>(object:  this, method:  System.Void WordForest.WFOMysteryChestUI::OnWordRegionWordFound(string wordCompleted)));
            this.wordRegion.addOnHintUsedAtLocation(callback:  new System.Action<UnityEngine.Vector3>(object:  this, method:  System.Void WordForest.WFOMysteryChestUI::OnWordRegionHintUsed(UnityEngine.Vector3 location)));
            this.wordRegion.addOnBeforeLevelCompleteAction(callback:  new System.Action<GameLevel>(object:  this, method:  System.Void WordForest.WFOMysteryChestUI::CheckShowChestOnComplete(GameLevel level)));
        }
        private void OnBeforeLevelStart()
        {
            this.OnWordRegionLoaded();
        }
        private void ClearMysteryChest(int chestIndex)
        {
            bool val_4 = true;
            if(val_4 <= chestIndex)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_4 = val_4 + (chestIndex << 3);
            var val_5 = (true + (chestIndex) << 3) + 32;
            mem2[0] = 0;
            if(val_5 <= chestIndex)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_5 = val_5 + (((long)(int)(chestIndex)) << 3);
            mem2[0] = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            if(0 <= chestIndex)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            if(0 <= chestIndex)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            this.mysteryChestManager.SetCurrentChestLocData(mode:  PlayingLevel.CurrentGameplayMode, gameLevel:  this.currentAssociatedLevel, lineWordIndex:  (PlayingLevel.__il2cppRuntimeField_cctor_finished + ((long)(int)(chestIndex)) << 3) + 32 + 24, cellIndex:  ((PlayingLevel.__il2cppRuntimeField_cctor_finished + ((long)(int)(chestIndex)) << 3) + 32 + ((long)(int)(chestIndex)) << 3) + 32 + 28, collected:  (((PlayingLevel.__il2cppRuntimeField_cctor_finished + ((long)(int)(chestIndex)) << 3) + 32 + ((long)(int)(chestIndex)) << 3) + 32 + ((long)(int)(chestIndex)) << 3) + 32 + 32, chestIndex:  chestIndex);
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            var val_6 = null;
            UnityEngine.Object.Destroy(obj:  ((((PlayingLevel.__il2cppRuntimeField_cctor_finished + ((long)(int)(chestIndex)) << 3) + 32 + ((long)(int)(chestIndex)) << 3) + 32 + ((long)(int)(chestIndex)) << 3) + 32 + ((long)(int)(chestIndex)) << + 32 + 16.gameObject);
            if(val_6 <= chestIndex)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_6 = val_6 + (((long)(int)(chestIndex)) << 3);
            mem2[0] = 0;
            NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "UpdateMysteryChestStatView");
        }
        private void CollectMysteryChestIcon(int chestIndex)
        {
            int val_8 = chestIndex;
            var val_8 = 1152921505001521152;
            .<>4__this = this;
            .chestIndex = val_8;
            if(WordForest.WFOMysteryChestManager.IsFeatureUnlocked == false)
            {
                    return;
            }
            
            if(val_8 <= ((WFOMysteryChestUI.<>c__DisplayClass22_0)[1152921518105108816].chestIndex))
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_8 = val_8 + (((WFOMysteryChestUI.<>c__DisplayClass22_0)[1152921518105108816].chestIndex) << 3);
            var val_9 = (1152921505001521152 + ((WFOMysteryChestUI.<>c__DisplayClass22_0)[1152921518105108816].chestIndex) << 3) + 32;
            mem2[0] = 1;
            if(val_9 <= ((WFOMysteryChestUI.<>c__DisplayClass22_0)[1152921518105108816].chestIndex))
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_9 = val_9 + (((WFOMysteryChestUI.<>c__DisplayClass22_0)[1152921518105108816].chestIndex) << 3);
            UnityEngine.Vector3 val_4 = new UnityEngine.Vector3(x:  0f, y:  0f, z:  30f);
            DG.Tweening.TweenCallback val_6 = null;
            val_8 = val_6;
            val_6 = new DG.Tweening.TweenCallback(object:  new WFOMysteryChestUI.<>c__DisplayClass22_0(), method:  System.Void WFOMysteryChestUI.<>c__DisplayClass22_0::<CollectMysteryChestIcon>b__0());
            DG.Tweening.Tweener val_7 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOShakeRotation(target:  ((1152921505001521152 + ((WFOMysteryChestUI.<>c__DisplayClass22_0)[1152921518105108816].chestIndex) << 3) + 32 + ((WFOMysteryChestUI.<>c__DisplayClass22_0)[1152921518105108816].chestIndex) << 3) + 32 + 16.transform, duration:  0.5f, strength:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z}, vibrato:  20, randomness:  90f, fadeOut:  true), action:  val_6);
        }
        private void CollectMysteryChest()
        {
            if(WordForest.WFOMysteryChestManager.IsFeatureUnlocked == false)
            {
                    return;
            }
            
            if((WordForest.WFOMysteryChestUI.<isMysteryChestFlowActive>k__BackingField) != false)
            {
                    return;
            }
            
            WordForest.WFOMysteryChestUI.<isMysteryChestFlowActive>k__BackingField = true;
            this.Invoke(methodName:  "ShowChest", time:  1f);
        }
        private void ShowChest()
        {
            GameBehavior val_1 = App.getBehavior;
            val_1.<metaGameBehavior>k__BackingField.Setup(rarityType:  0, itemData:  0, collectedChestCount:  MonoSingleton<WordForest.WFOMysteryChestManager>.Instance.GetCollectedChestCount, totalChestCount:  MonoSingleton<WordForest.WFOMysteryChestManager>.Instance.GetChestCount, onComplete:  new System.Action(object:  this, method:  System.Void WordForest.WFOMysteryChestUI::OnMysteryChestOpenAnimComplete()));
            MonoSingleton<WordForest.WFOMysteryChestManager>.Instance.ClearChestLocData(mode:  PlayingLevel.CurrentGameplayMode);
        }
        protected void OnMysteryChestOpenAnimComplete()
        {
            WordForest.WFOMysteryChestUI.<isMysteryChestFlowActive>k__BackingField = false;
        }
        private void ShiftMysteryChest(int chestIndex)
        {
            WordForest.WFOMysteryChestUI val_11;
            LineWord val_12;
            int val_13;
            System.Collections.Generic.List<WordForest.MysteryChest> val_14;
            val_11 = this;
            .<>4__this = val_11;
            .chestIndex = chestIndex;
            WordRegion val_11 = this.wordRegion;
            if(W9 != 0)
            {
                    return;
            }
            
            if(W9 <= chestIndex)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_11 = val_11 + (chestIndex << 3);
            if((X22 + 24) <= chestIndex)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_12 = X22 + 16;
            val_12 = val_12 + ((chestIndex) << 3);
            val_12 = mem[(X22 + 16 + (chestIndex) << 3) + 32];
            val_12 = (X22 + 16 + (chestIndex) << 3) + 32;
            .lineWordObj = val_12;
            if(W9 <= ((WFOMysteryChestUI.<>c__DisplayClass26_0)[1152921518105736112].chestIndex))
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
                val_12 = (WFOMysteryChestUI.<>c__DisplayClass26_0)[1152921518105736112].lineWordObj;
            }
            
            var val_2 = X9 + (((WFOMysteryChestUI.<>c__DisplayClass26_0)[1152921518105736112].chestIndex) << 3);
            mem2[0] = (WFOMysteryChestUI.<>c__DisplayClass26_0)[1152921518105736112].lineWordObj.cells.FindIndex(match:  new System.Predicate<Cell>(object:  new WFOMysteryChestUI.<>c__DisplayClass26_0(), method:  System.Boolean WFOMysteryChestUI.<>c__DisplayClass26_0::<ShiftMysteryChest>b__0(Cell x)));
            val_13 = this.currentAssociatedLevel;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            if(1152921516026944992 <= ((WFOMysteryChestUI.<>c__DisplayClass26_0)[1152921518105736112].chestIndex))
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            if(1152921516026944992 <= ((WFOMysteryChestUI.<>c__DisplayClass26_0)[1152921518105736112].chestIndex))
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            this.mysteryChestManager.SetCurrentChestLocData(mode:  PlayingLevel.CurrentGameplayMode, gameLevel:  val_13, lineWordIndex:  (PlayingLevel.__il2cppRuntimeField_cctor_finished + ((WFOMysteryChestUI.<>c__DisplayClass26_0)[1152921518105736112].chestIndex) << 3) + 32 + 24, cellIndex:  ((PlayingLevel.__il2cppRuntimeField_cctor_finished + ((WFOMysteryChestUI.<>c__DisplayClass26_0)[1152921518105736112].chestIndex) << 3) + 32 + ((WFOMysteryChestUI.<>c__DisplayClass26_0)[115292151810573 + 32 + 28, collected:  (((PlayingLevel.__il2cppRuntimeField_cctor_finished + ((WFOMysteryChestUI.<>c__DisplayClass26_0)[1152921518105736112].chestIndex) << 3) + 32 + ((WFOMysteryChestUI.<>c__DisplayClass26_0)[11529215181057 + 32 + 32, chestIndex:  (WFOMysteryChestUI.<>c__DisplayClass26_0)[1152921518105736112].chestIndex);
            val_14 = this.mysteryChestTiles;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            LineWord val_13 = (WFOMysteryChestUI.<>c__DisplayClass26_0)[1152921518105736112].lineWordObj;
            val_14 = (((((PlayingLevel.__il2cppRuntimeField_cctor_finished + ((WFOMysteryChestUI.<>c__DisplayClass26_0)[1152921518105736112].chestIndex) << 3) + 32 + ((WFOMysteryChestUI.<>c__DisplayClass26_0)[115292151810 + 32 + 16.transform;
            if(1152921516026944992 <= ((WFOMysteryChestUI.<>c__DisplayClass26_0)[1152921518105736112].chestIndex))
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_13 = val_13 + (((WFOMysteryChestUI.<>c__DisplayClass26_0)[1152921518105736112].chestIndex) << 3);
            float val_14 = ((WFOMysteryChestUI.<>c__DisplayClass26_0)[1152921518105736112].lineWordObj + ((WFOMysteryChestUI.<>c__DisplayClass26_0)[1152921518105736112].chestIndex) << 3).cellSize;
            val_13 = mem[((WFOMysteryChestUI.<>c__DisplayClass26_0)[1152921518105736112].lineWordObj + ((WFOMysteryChestUI.<>c__DisplayClass26_0)[1152921518105736112].chestIndex) << 3).cellSize + 28];
            val_13 = ((WFOMysteryChestUI.<>c__DisplayClass26_0)[1152921518105736112].lineWordObj + ((WFOMysteryChestUI.<>c__DisplayClass26_0)[1152921518105736112].chestIndex) << 3).cellSize + 28;
            if(val_14 <= val_13)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_14 = val_14 + ((((WFOMysteryChestUI.<>c__DisplayClass26_0)[1152921518105736112].lineWordObj + ((WFOMysteryChestUI.<>c__DisplayClass26_0)[1152921518105736112].chestIndex) << 3).cellSize + 28) << 3);
            val_14.SetParent(p:  (((WFOMysteryChestUI.<>c__DisplayClass26_0)[1152921518105736112].lineWordObj + ((WFOMysteryChestUI.<>c__DisplayClass26_0)[1152921518105736112].chestIndex) << 3).cellSize + (((WFOMysteryChestUI.<>c__Di + 32.transform);
            if(val_14 <= ((WFOMysteryChestUI.<>c__DisplayClass26_0)[1152921518105736112].chestIndex))
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_14 = val_14 + (((WFOMysteryChestUI.<>c__DisplayClass26_0)[1152921518105736112].chestIndex) << 3);
            val_11 = ((((WFOMysteryChestUI.<>c__DisplayClass26_0)[1152921518105736112].lineWordObj + ((WFOMysteryChestUI.<>c__DisplayClass26_0)[1152921518105736112].chestIndex) << 3).cellSize + (((WFOMysteryChestUI.<>c__D + 32 + 16.transform;
            UnityEngine.Vector3 val_9 = UnityEngine.Vector3.zero;
            val_11.localPosition = new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z};
            App.Player.SaveState();
        }
        private void OnWordRegionLoaded()
        {
            int val_20;
            var val_21;
            var val_43;
            int val_44;
            int val_45;
            var val_46;
            UnityEngine.Transform val_47;
            var val_48;
            System.Predicate<LineWord> val_50;
            var val_51;
            if(WordForest.WFOMysteryChestManager.IsFeatureUnlocked == false)
            {
                    return;
            }
            
            val_43 = 1152921504975749120;
            System.Collections.Generic.List<WordForest.MysteryChest> val_4 = new System.Collections.Generic.List<WordForest.MysteryChest>();
            this.mysteryChestTiles = val_4;
            if(((this.mysteryChestManager.GetCurrentChestPlacementData(mode:  PlayingLevel.CurrentGameplayMode)) == null) || (val_3.GameLevel != PlayingLevel.GetCurrentPlayerLevelNumber()))
            {
                goto label_8;
            }
            
            val_44 = this;
            this.currentAssociatedLevel = val_3.GameLevel;
            if(val_3.ChestsData < 1)
            {
                goto label_24;
            }
            
            val_45 = 1152921518105903728;
            do
            {
                if(val_3.ChestsData <= 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                .LineWord = System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg + 16;
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
                .CellIndex = (System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg + 16 + 0) + 32 + 20;
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
                .collected = ((System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg + 16 + 0) + 32 + 20 + 0) + 32.Collected;
                this.mysteryChestTiles.Add(item:  new WordForest.MysteryChest());
                val_46 = 0 + 1;
            }
            while(val_46 < val_3.ChestsData);
            
            val_43 = 1152921504975749120;
            goto label_24;
            label_8:
            int val_9 = this.mysteryChestManager.GetRandomChestCount();
            val_44 = this.currentAssociatedLevel;
            var val_10 = (val_9 > this.wordRegion) ? this.wordRegion : (val_9);
            label_24:
            if(val_44 == PlayingLevel.GetCurrentPlayerLevelNumber())
            {
                goto label_30;
            }
            
            this.mysteryChestManager.ClearChestLocData(mode:  PlayingLevel.CurrentGameplayMode);
            mem2[0] = PlayingLevel.GetCurrentPlayerLevelNumber();
            if(val_10 < 1)
            {
                goto label_92;
            }
            
            var val_49 = 0;
            var val_43 = 0;
            label_91:
            val_48 = null;
            val_48 = null;
            val_50 = WFOMysteryChestUI.<>c.<>9__27_0;
            if(val_50 == null)
            {
                    System.Predicate<LineWord> val_14 = null;
                val_50 = val_14;
                val_14 = new System.Predicate<LineWord>(object:  WFOMysteryChestUI.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WFOMysteryChestUI.<>c::<OnWordRegionLoaded>b__27_0(LineWord x));
                WFOMysteryChestUI.<>c.<>9__27_0 = val_50;
            }
            
            if((val_4.Exists(match:  val_14)) == true)
            {
                    return;
            }
            
            System.Collections.Generic.List<System.Int32> val_16 = this.wordRegion.getAvailableLineIndices;
            if((public System.Boolean System.Collections.Generic.List<LineWord>::Exists(System.Predicate<T> match)) == 0)
            {
                    return;
            }
            
            RandomSet val_17 = new RandomSet();
            if(null == 0)
            {
                goto label_92;
            }
            
            List.Enumerator<T> val_19 = this.wordRegion.getAvailableLineIndices.GetEnumerator();
            label_51:
            if(val_21.MoveNext() == false)
            {
                goto label_49;
            }
            
            if(val_17 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_17.add(item:  val_20, weight:  1f);
            goto label_51;
            label_49:
            val_43 = val_43 + 1;
            val_21.Dispose();
            if(val_43 != 1)
            {
                    var val_44 = 0;
                val_44 = val_44 ^ (val_43 >> 31);
                val_43 = val_43 + val_44;
            }
            
            .CellIndex = 0;
            .collected = false;
            label_74:
            if(val_17.remainingCount() == 0)
            {
                goto label_55;
            }
            
            int val_28 = val_17.roll(unweighted:  false);
            .LineWord = val_28;
            label_65:
            if((X25 + 24) <= val_28)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_45 = X25 + 16;
            val_45 = val_45 + (val_28 << 3);
            if(((X25 + 16 + (val_28) << 3) + 32 + 40 + 24) <= (WordForest.MysteryChest)[1152921518106235184].CellIndex)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_46 = (X25 + 16 + (val_28) << 3) + 32 + 40 + 16;
            val_46 = val_46 + (((WordForest.MysteryChest)[1152921518106235184].CellIndex) << 3);
            if((((X25 + 16 + (val_28) << 3) + 32 + 40 + 16 + ((WordForest.MysteryChest)[1152921518106235184].CellIndex) << 3) + 32 + 72) == 0)
            {
                goto label_63;
            }
            
            int val_47 = (WordForest.MysteryChest)[1152921518106235184].CellIndex;
            val_47 = val_47 + 1;
            .CellIndex = val_47;
            if((WordForest.MysteryChest)[1152921518106235184].CellIndex != 0)
            {
                goto label_65;
            }
            
            label_63:
            if(((((val_10 == 1) ? 1 : 0) | ((val_49 == 0) ? 1 : 0)) & 1) != 0)
            {
                goto label_67;
            }
            
            val_45 = (WordForest.MysteryChest)[1152921518106235184].LineWord;
            if(((X25 + 16 + (val_28) << 3) + 32 + 40 + 24) <= val_45)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_48 = (X25 + 16 + (val_28) << 3) + 32 + 40 + 16;
            val_48 = val_48 + (((WordForest.MysteryChest)[1152921518106235184].LineWord) << 3);
            if((((X25 + 16 + (val_28) << 3) + 32 + 40 + 16 + ((WordForest.MysteryChest)[1152921518106235184].LineWord) << 3) + 32 + 48) >= this.wordRegion)
            {
                goto label_74;
            }
            
            label_67:
            if(((WordForest.MysteryChest)[1152921518106235184].LineWord == 1) || ((WordForest.MysteryChest)[1152921518106235184].CellIndex == 1))
            {
                goto label_90;
            }
            
            this.mysteryChestTiles.Add(item:  new WordForest.MysteryChest());
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            if(val_49 >= this.mysteryChestManager)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_45 = mem[((PlayingLevel.__il2cppRuntimeField_cctor_finished + 0) + 32 + 0) + 32 + 28];
            val_45 = ((PlayingLevel.__il2cppRuntimeField_cctor_finished + 0) + 32 + 0) + 32 + 28;
            if(val_49 >= this.mysteryChestManager)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            this.mysteryChestManager.SetCurrentChestLocData(mode:  PlayingLevel.CurrentGameplayMode, gameLevel:  this.currentAssociatedLevel, lineWordIndex:  (PlayingLevel.__il2cppRuntimeField_cctor_finished + 0) + 32 + 24, cellIndex:  val_45, collected:  (((PlayingLevel.__il2cppRuntimeField_cctor_finished + 0) + 32 + 0) + 32 + 0) + 32 + 32, chestIndex:  0);
            goto label_90;
            label_55:
            .LineWord = -1;
            .CellIndex = -1;
            label_90:
            val_43 = 1152921504975749120;
            val_49 = val_49 + 1;
            if(val_49 < (long)val_10)
            {
                goto label_91;
            }
            
            label_92:
            App.Player.SaveState();
            label_30:
            val_51 = 0;
            val_46 = 4;
            label_126:
            val_47 = val_46 - 4;
            if(val_47 >= this.mysteryChestTiles)
            {
                goto label_102;
            }
            
            if((val_44 == PlayingLevel.GetCurrentPlayerLevelNumber()) && ((this.IsChestTileAvailable(chestIndex:  val_46 - 4)) != false))
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
                if(val_47 >= X10)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                if(null <= this.mysteryChestTiles)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                var val_50 = public System.DateTime System.DateTime::AddTicks(long value);
                val_50 = val_50 + ((this.mysteryChestTiles) << 3);
                val_45 = this.mysteryChestTiles;
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
                if(((public System.DateTime System.DateTime::AddTicks(long value) + (this.mysteryChestTiles) << 3) + 32 + 40 + 24) <= ((public System.DateTime System.DateTime::AddTicks(long value) + (this.mysteryChestTiles) << 3) + 32 + 32 + 28))
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                var val_51 = (public System.DateTime System.DateTime::AddTicks(long value) + (this.mysteryChestTiles) << 3) + 32 + 40 + 16;
                val_51 = val_51 + (((public System.DateTime System.DateTime::AddTicks(long value) + (this.mysteryChestTiles) << 3) + 32 + 32 + 28) << 3);
                val_47 = ((public System.DateTime System.DateTime::AddTicks(long value) + (this.mysteryChestTiles) << 3) + 32 + 40 + 16 + ((public System.DateTime System.DateTime::AddTicks(long value) + (this.mysteryChestTile + 32.transform;
                val_51 = val_51 + 1;
                mem2[0] = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.prefabMysteryChestTile, parent:  val_47).GetComponent<WFOMysteryChestMovingObject>();
            }
            
            val_46 = val_46 + 1;
            if(this.mysteryChestTiles != null)
            {
                goto label_126;
            }
            
            throw new NullReferenceException();
            label_102:
            if(val_51 >= 1)
            {
                    val_47 = 1152921515420673872;
                if((MonoSingleton<WordForest.WFOMysteryChestManager>.Instance.IsFTUXCompleted()) != true)
            {
                    WGWindowManager val_40 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WordForest.WFOMysteryChestFTUXPopup>(showNext:  false);
                MonoSingleton<WordForest.WFOMysteryChestManager>.Instance.CompleteFTUX();
            }
            
            }
            
            NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "UpdateMysteryChestStatView");
        }
        private void OnWordRegionPreprocessPlayerTurn(bool hintUsage, string wordEntered, LineWord lineWord, Cell cell)
        {
            var val_4;
            bool val_4 = true;
            if(this.IsTileCurrentlyInPlay == false)
            {
                    return;
            }
            
            val_4 = 0;
            do
            {
                if(val_4 >= val_4)
            {
                    return;
            }
            
                if(val_4 <= val_4)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_4 = val_4 + 0;
                var val_5 = (true + 0) + 32 + 24;
                if((val_5 & 2147483648) == 0)
            {
                    if(val_5 <= val_4)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_5 = val_5 + 0;
                if((((true + 0) + 32 + 24 + 0) + 32 + 24) < this.wordRegion)
            {
                    if((System.String.IsNullOrEmpty(value:  wordEntered)) == false)
            {
                goto label_13;
            }
            
            }
            
            }
            
                val_4 = val_4 + 1;
            }
            while(this.mysteryChestTiles != null);
            
            label_13:
            if(this.wordRegion <= val_4)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_4 = mem[WordRegion.__il2cppRuntimeField_byval_arg + 24];
            val_4 = WordRegion.__il2cppRuntimeField_byval_arg + 24;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            if(((WordRegion.__il2cppRuntimeField_byval_arg + (WordRegion.__il2cppRuntimeField_byval_arg + 24) << 3) + 32 + 24.Equals(value:  wordEntered)) == false)
            {
                    return;
            }
            
            mem2[0] = 1;
        }
        private void OnWordRegionWordFound(string wordCompleted)
        {
            System.Collections.Generic.List<WordForest.MysteryChest> val_3;
            bool val_3 = true;
            if(this.IsTileCurrentlyInPlay == false)
            {
                    return;
            }
            
            val_3 = 0;
            label_20:
            if(val_3 >= val_3)
            {
                goto label_3;
            }
            
            if(val_3 <= val_3)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_3 = val_3 + 0;
            var val_4 = (true + 0) + 32 + 24;
            if((val_4 & 2147483648) != 0)
            {
                goto label_12;
            }
            
            if(val_4 <= val_3)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_4 = val_4 + 0;
            var val_5 = ((true + 0) + 32 + 24 + 0) + 32 + 24;
            if(val_5 >= this.wordRegion)
            {
                goto label_12;
            }
            
            if(val_5 <= val_3)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_5 = val_5 + 0;
            var val_6 = (((true + 0) + 32 + 24 + 0) + 32 + 24 + 0) + 32;
            if(val_6 <= ((((true + 0) + 32 + 24 + 0) + 32 + 24 + 0) + 32 + 24))
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_6 = val_6 + (((((true + 0) + 32 + 24 + 0) + 32 + 24 + 0) + 32 + 24) << 3);
            if((((((true + 0) + 32 + 24 + 0) + 32 + 24 + 0) + 32 + ((((true + 0) + 32 + 24 + 0) + 32 + 24 + 0) + 32 + 24) << 3) + 32 + 24.Equals(value:  wordCompleted)) == true)
            {
                goto label_19;
            }
            
            label_12:
            val_3 = val_3 + 1;
            if(this.mysteryChestTiles != null)
            {
                goto label_20;
            }
            
            label_3:
            if(val_3 < 1)
            {
                    return;
            }
            
            var val_8 = 0;
            do
            {
                if(val_3 <= val_8)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_3 = val_3 + 0;
                var val_7 = (true + 0) + 32 + 24;
                if((val_7 & 2147483648) == 0)
            {
                    val_3 = this.mysteryChestTiles;
                if(val_7 <= val_8)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_7 = val_7 + 0;
                if((((true + 0) + 32 + 24 + 0) + 32 + 24) < this.wordRegion)
            {
                    this.ShiftMysteryChest(chestIndex:  0);
            }
            
            }
            
                val_8 = val_8 + 1;
            }
            while(val_8 < (((true + 0) + 32 + 24 + 0) + 32 + 24));
            
            return;
            label_19:
            this.CollectMysteryChestIcon(chestIndex:  0);
        }
        private void OnWordRegionHintUsed(UnityEngine.Vector3 location)
        {
            System.Collections.Generic.List<WordForest.MysteryChest> val_8;
            var val_9;
            System.Predicate<Cell> val_11;
            if(this.IsTileCurrentlyInPlay == false)
            {
                    return;
            }
            
            val_8 = this.mysteryChestTiles;
            var val_10 = 4;
            do
            {
                int val_2 = val_10 - 4;
                if(val_2 >= true)
            {
                    return;
            }
            
                if(true <= val_2)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                if(((mem[-2305843009213693928]) & 2147483648) == 0)
            {
                    if((mem[-2305843009213693928]) <= val_2)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                if((mem[-2305843009213693928] + 32 + 24) < this.wordRegion)
            {
                    if((mem[-2305843009213693928] + 32 + 24) <= val_2)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                if((mem[-2305843009213693928] + 32 + 24 + 32 + 16) != 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
                UnityEngine.Vector3 val_5 = UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 32 + 16.transform.position;
                if((UnityEngine.Vector3.op_Equality(lhs:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z}, rhs:  new UnityEngine.Vector3() {x = location.x, y = location.y, z = location.z})) != false)
            {
                    WordRegion val_9 = this.wordRegion;
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
                if(val_9 <= this.mysteryChestTiles)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_9 = val_9 + ((this.mysteryChestTiles) << 3);
                val_9 = null;
                val_9 = null;
                val_11 = WFOMysteryChestUI.<>c.<>9__30_0;
                if(val_11 == null)
            {
                    System.Predicate<Cell> val_7 = null;
                val_11 = val_7;
                val_7 = new System.Predicate<Cell>(object:  WFOMysteryChestUI.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WFOMysteryChestUI.<>c::<OnWordRegionHintUsed>b__30_0(Cell x));
                WFOMysteryChestUI.<>c.<>9__30_0 = val_11;
            }
            
                if((this.mysteryChestTiles.Exists(match:  val_7)) == false)
            {
                    return;
            }
            
                this.ShiftMysteryChest(chestIndex:  val_2);
            }
            
            }
            
            }
            
            }
            
                val_8 = this.mysteryChestTiles;
                val_10 = val_10 + 1;
            }
            while(val_8 != null);
            
            throw new NullReferenceException();
        }
        private void CheckShowChestOnComplete(GameLevel level)
        {
            if((MonoSingleton<WordForest.WFOMysteryChestManager>.Instance.GetCollectedChestCount) < 1)
            {
                    return;
            }
            
            this.CollectMysteryChest();
            WordRegion.instance.AddLevelCompleteBlocker(blocker:  0);
        }
        public void Hack_CollectMysteryChest()
        {
            System.Collections.Generic.List<WordForest.MysteryChest> val_1;
            bool val_1 = true;
            val_1 = this.mysteryChestTiles;
            var val_3 = 0;
            label_12:
            if(val_3 >= val_1)
            {
                    return;
            }
            
            if(val_1 <= val_3)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_1 = val_1 + 0;
            var val_2 = (true + 0) + 32 + 24;
            if((val_2 & 2147483648) != 0)
            {
                goto label_5;
            }
            
            if(val_2 <= val_3)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_2 = val_2 + 0;
            if((((true + 0) + 32 + 24 + 0) + 32 + 24) < this.wordRegion)
            {
                goto label_11;
            }
            
            label_5:
            val_1 = this.mysteryChestTiles;
            val_3 = val_3 + 1;
            if(val_1 != null)
            {
                goto label_12;
            }
            
            throw new NullReferenceException();
            label_11:
            this.CollectMysteryChestIcon(chestIndex:  0);
        }
        public WFOMysteryChestUI()
        {
            this.mysteryChestTiles = new System.Collections.Generic.List<WordForest.MysteryChest>();
            this.currentAssociatedLevel = 0;
        }
    
    }

}
