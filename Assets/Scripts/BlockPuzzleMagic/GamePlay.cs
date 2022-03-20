using UnityEngine;

namespace BlockPuzzleMagic
{
    public class GamePlay : MonoSingleton<BlockPuzzleMagic.GamePlay>
    {
        // Fields
        public System.Collections.Generic.List<BlockPuzzleMagic.GridCell> cellGrid;
        private UnityEngine.RectTransform floatingShapesLayer;
        private BlockPuzzleMagic.Level currentLevel;
        public System.Action<BlockPuzzleMagic.Level> OnLevelDataInitialized;
        public System.Action<BlockPuzzleMagic.ShapeInfo> OnShapePlaced;
        public System.Action<BlockPuzzleMagic.ShapeInfo> OnShapeRotated;
        public System.Action<bool> OnShapesChecked;
        public System.Action<System.Collections.Generic.List<System.Collections.Generic.List<BlockPuzzleMagic.GridCell>>> OnBlocksCleared;
        public System.Action OnGoalProgressUpdated;
        public System.Action<bool> OnPowerupMode;
        public System.Action<BlockPuzzleMagic.PowerUpType> OnPowerupUsed;
        public System.Action<bool> OnGameOver;
        private BlockPuzzleMagic.ShapeInfo currentShape;
        public static int currentLevelFailCount;
        private bool <GridCellsInteractable>k__BackingField;
        
        // Properties
        public UnityEngine.RectTransform FloatingShapesLayer { get; }
        public BlockPuzzleMagic.Level CurrentLevel { get; }
        public BlockPuzzleMagic.GameMode CurrentGameMode { get; }
        public bool GridCellsInteractable { get; set; }
        
        // Methods
        public UnityEngine.RectTransform get_FloatingShapesLayer()
        {
            return (UnityEngine.RectTransform)this.floatingShapesLayer;
        }
        public BlockPuzzleMagic.Level get_CurrentLevel()
        {
            return (BlockPuzzleMagic.Level)this.currentLevel;
        }
        public BlockPuzzleMagic.GameMode get_CurrentGameMode()
        {
            if(this.currentLevel == null)
            {
                    return 0;
            }
            
            return (BlockPuzzleMagic.GameMode)this.currentLevel.gameMode;
        }
        public bool get_GridCellsInteractable()
        {
            return (bool)this.<GridCellsInteractable>k__BackingField;
        }
        public void set_GridCellsInteractable(bool value)
        {
            this.<GridCellsInteractable>k__BackingField = value;
        }
        public void Init(BlockPuzzleMagic.GameMode gameMode)
        {
            BlockPuzzleMagic.GameMode val_14;
            var val_15;
            BlockPuzzleMagic.GameMode val_16;
            val_14 = gameMode;
            this.currentLevel = 0;
            BestBlocksPlayer val_1 = BestBlocksPlayer.Instance;
            if((MonoSingleton<BlockPuzzleMagic.GameProgressManager>.Instance.HasSavedGame(gameMode:  val_14)) != false)
            {
                    this.currentLevel = MonoSingleton<BlockPuzzleMagic.GameProgressManager>.Instance.LoadSavedGame(gameMode:  val_14);
            }
            
            if(val_14 == 1)
            {
                goto label_8;
            }
            
            if(val_14 != 2)
            {
                goto label_21;
            }
            
            if(this.currentLevel == null)
            {
                goto label_10;
            }
            
            val_14 = this.currentLevel.levelId;
            GameBehavior val_6 = App.getBehavior;
            if(val_14 == (val_6.<metaGameBehavior>k__BackingField))
            {
                goto label_21;
            }
            
            label_10:
            EnumerableExtentions.SetOrAdd<BlockPuzzleMagic.GameMode, System.Int32>(dic:  val_1.currentRotationsUsed, key:  2, newValue:  0);
            val_15 = 0;
            EnumerableExtentions.SetOrAdd<BlockPuzzleMagic.GameMode, System.Boolean>(dic:  val_1.rotationPrompted, key:  2, newValue:  false);
            BlockPuzzleMagic.LevelManager val_7 = MonoSingletonSelfGenerating<BlockPuzzleMagic.LevelManager>.Instance;
            val_16 = 2;
            goto label_20;
            label_8:
            if(this.currentLevel != null)
            {
                goto label_21;
            }
            
            val_1.zenModeScoreCurrent = 0;
            val_1.zenModePiecesPlacedCurrent = 0;
            EnumerableExtentions.SetOrAdd<BlockPuzzleMagic.GameMode, System.Int32>(dic:  val_1.currentRotationsUsed, key:  1, newValue:  0);
            val_15 = 0;
            EnumerableExtentions.SetOrAdd<BlockPuzzleMagic.GameMode, System.Boolean>(dic:  val_1.rotationPrompted, key:  1, newValue:  false);
            val_16 = 1;
            label_20:
            this.currentLevel = MonoSingletonSelfGenerating<BlockPuzzleMagic.LevelManager>.Instance.GetGameLevel(gameMode:  val_16);
            label_21:
            MonoSingleton<BlockPuzzleMagic.GameBoardGenerator>.Instance.GenerateBoard(_level:  this.currentLevel);
            if(BestBlocksPlayer.Instance.IsFTUXGameLevels() == false)
            {
                goto label_32;
            }
            
            var val_14 = 4;
            label_40:
            val_14 = val_14 - 4;
            if(val_14 >= 1152921513395531040)
            {
                goto label_32;
            }
            
            if(1152921513395531040 <= val_14)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            mem2[0] = 0;
            val_14 = val_14 + 1;
            if(this.cellGrid != null)
            {
                goto label_40;
            }
            
            label_32:
            MonoSingleton<BlockPuzzleMagic.BlockShapeSpawner>.Instance.Init(shapesData:  this.currentLevel.usableShapeIds, posweupShapesData:  this.currentLevel.usablePowerupIds);
            this.<GridCellsInteractable>k__BackingField = true;
            if(this.OnLevelDataInitialized == null)
            {
                    return;
            }
            
            this.OnLevelDataInitialized.Invoke(obj:  this.currentLevel);
        }
        public void Restart()
        {
            if(this.currentLevel == null)
            {
                    return;
            }
            
            if(this.currentLevel.gameMode == 0)
            {
                    return;
            }
            
            MonoSingleton<BlockPuzzleMagic.GameProgressManager>.Instance.ClearProgress(gameMode:  this.currentLevel.gameMode);
            this.Init(gameMode:  this.currentLevel.gameMode);
        }
        public void CheckBoardStatus()
        {
            var val_8;
            System.Collections.Generic.List<System.Collections.Generic.List<BlockPuzzleMagic.GridCell>> val_1 = new System.Collections.Generic.List<System.Collections.Generic.List<BlockPuzzleMagic.GridCell>>();
            System.Collections.Generic.List<System.Collections.Generic.List<BlockPuzzleMagic.GridCell>> val_2 = new System.Collections.Generic.List<System.Collections.Generic.List<BlockPuzzleMagic.GridCell>>();
            int val_3 = this.currentLevel.gridLayout.rowCount;
            if(val_3 >= 1)
            {
                    do
            {
                System.Collections.Generic.List<BlockPuzzleMagic.GridCell> val_4 = 0;
                if((this.IsRowCompletelyFilled(rowID:  0, rowList: out  val_4)) != false)
            {
                    val_1.Add(item:  val_4);
            }
            
                val_8 = 0 + 1;
            }
            while(val_8 < val_3);
            
            }
            
            if(W24 >= 1)
            {
                    val_8 = 1152921520157173760;
                var val_8 = 0;
                do
            {
                System.Collections.Generic.List<BlockPuzzleMagic.GridCell> val_6 = 0;
                if((this.IsColumnCompletelyFilled(columnID:  0, colList: out  val_6)) != false)
            {
                    val_2.Add(item:  val_6);
            }
            
                val_8 = val_8 + 1;
            }
            while(val_8 < W24);
            
            }
            
            this.BreakAllCompletedLines(breakingRows:  val_1, breakingColumns:  val_2);
        }
        private bool IsRowCompletelyFilled(int rowID, out System.Collections.Generic.List<BlockPuzzleMagic.GridCell> rowList)
        {
            GamePlay.<>c__DisplayClass27_0 val_7;
            var val_8;
            var val_9;
            GamePlay.<>c__DisplayClass27_0 val_1 = null;
            val_7 = val_1;
            val_1 = new GamePlay.<>c__DisplayClass27_0();
            .rowID = rowID;
            System.Collections.Generic.List<BlockPuzzleMagic.GridCell> val_2 = new System.Collections.Generic.List<BlockPuzzleMagic.GridCell>();
            .CS$<>8__locals1 = val_7;
            .columnIndex = 0;
            label_11:
            if(0 >= this.currentLevel.gridLayout)
            {
                goto label_5;
            }
            
            val_7 = this.cellGrid.Find(match:  new System.Predicate<BlockPuzzleMagic.GridCell>(object:  new GamePlay.<>c__DisplayClass27_1(), method:  System.Boolean GamePlay.<>c__DisplayClass27_1::<IsRowCompletelyFilled>b__0(BlockPuzzleMagic.GridCell o)));
            if((val_5.<isOn>k__BackingField) == false)
            {
                goto label_8;
            }
            
            if(val_7.isFilled == false)
            {
                goto label_9;
            }
            
            val_2.Add(item:  val_7);
            label_8:
            int val_7 = (GamePlay.<>c__DisplayClass27_1)[1152921520157423520].columnIndex;
            val_7 = val_7 + 1;
            .columnIndex = val_7;
            if(this.currentLevel != null)
            {
                goto label_11;
            }
            
            label_5:
            val_8 = 1152921520157411312;
            if(0 <= 0)
            {
                goto label_14;
            }
            
            val_9 = 1;
            rowList = val_2;
            return (bool)val_9;
            label_9:
            val_8 = 1152921520157411312;
            label_14:
            val_9 = 0;
            rowList = 0;
            return (bool)val_9;
        }
        private bool IsColumnCompletelyFilled(int columnID, out System.Collections.Generic.List<BlockPuzzleMagic.GridCell> colList)
        {
            BlockPuzzleMagic.GridCell val_9;
            var val_10;
            var val_11;
            .columnID = columnID;
            System.Collections.Generic.List<BlockPuzzleMagic.GridCell> val_2 = new System.Collections.Generic.List<BlockPuzzleMagic.GridCell>();
            .CS$<>8__locals1 = new GamePlay.<>c__DisplayClass28_0();
            .rowIndex = 0;
            val_9 = 0;
            label_11:
            if(val_9 >= this.currentLevel.gridLayout.rowCount)
            {
                goto label_5;
            }
            
            val_9 = this.cellGrid.Find(match:  new System.Predicate<BlockPuzzleMagic.GridCell>(object:  new GamePlay.<>c__DisplayClass28_1(), method:  System.Boolean GamePlay.<>c__DisplayClass28_1::<IsColumnCompletelyFilled>b__0(BlockPuzzleMagic.GridCell o)));
            if((val_6.<isOn>k__BackingField) == false)
            {
                goto label_8;
            }
            
            if(val_9.isFilled == false)
            {
                goto label_9;
            }
            
            val_2.Add(item:  val_9);
            label_8:
            .rowIndex = ((GamePlay.<>c__DisplayClass28_1)[1152921520157618304].rowIndex) + 1;
            if(this.currentLevel != null)
            {
                goto label_11;
            }
            
            label_5:
            val_10 = 1152921520157606096;
            if(this.currentLevel <= 0)
            {
                goto label_14;
            }
            
            val_11 = 1;
            colList = val_2;
            return (bool)val_11;
            label_9:
            val_10 = 1152921520157606096;
            label_14:
            val_11 = 0;
            colList = 0;
            return (bool)val_11;
        }
        private void BreakAllCompletedLines(System.Collections.Generic.List<System.Collections.Generic.List<BlockPuzzleMagic.GridCell>> breakingRows, System.Collections.Generic.List<System.Collections.Generic.List<BlockPuzzleMagic.GridCell>> breakingColumns)
        {
            System.Collections.Generic.List<BlockPuzzleMagic.GridCell> val_3;
            var val_4;
            System.Collections.Generic.List<BlockPuzzleMagic.Goal> val_12;
            var val_13;
            System.Collections.Generic.List<BlockPuzzleMagic.GridCell> val_14;
            val_12 = breakingRows;
            System.Collections.Generic.List<System.Collections.Generic.List<BlockPuzzleMagic.GridCell>> val_1 = new System.Collections.Generic.List<System.Collections.Generic.List<BlockPuzzleMagic.GridCell>>();
            if(val_12 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(1152921520157152256 < 1)
            {
                goto label_38;
            }
            
            List.Enumerator<T> val_2 = val_12.GetEnumerator();
            label_5:
            if(val_4.MoveNext() == false)
            {
                goto label_3;
            }
            
            val_13 = this;
            val_14 = val_3;
            this.BreakThisLine(breakingLine:  val_14, animationDelay:  0f);
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_1.Add(item:  val_3);
            goto label_5;
            label_3:
            val_4.Dispose();
            label_38:
            if(breakingColumns == null)
            {
                    throw new NullReferenceException();
            }
            
            if(1152921520117050464 < 1)
            {
                goto label_36;
            }
            
            List.Enumerator<T> val_6 = breakingColumns.GetEnumerator();
            label_11:
            val_14 = public System.Boolean List.Enumerator<System.Collections.Generic.List<BlockPuzzleMagic.GridCell>>::MoveNext();
            if(val_4.MoveNext() == false)
            {
                goto label_8;
            }
            
            if(this == null)
            {
                    throw new NullReferenceException();
            }
            
            this.BreakThisLine(breakingLine:  val_3, animationDelay:  (val_3 > 0) ? 0.15f : 0f);
            val_1.Add(item:  val_3);
            goto label_11;
            label_8:
            val_4.Dispose();
            label_36:
            if(this.OnBlocksCleared != null)
            {
                    this.OnBlocksCleared.Invoke(obj:  val_1);
            }
            
            if((this.currentLevel == null) || (this.currentLevel.gameMode != 2))
            {
                goto label_19;
            }
            
            var val_11 = 0;
            label_20:
            val_12 = this.currentLevel.goals;
            if(val_12 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_11 >= this.currentLevel)
            {
                goto label_16;
            }
            
            if(this.currentLevel <= val_11)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_11 = val_11 + 1;
            if(this.currentLevel != null)
            {
                goto label_20;
            }
            
            throw new NullReferenceException();
            label_19:
            BlockPuzzleMagic.BlockShapeSpawner val_9 = MonoSingleton<BlockPuzzleMagic.BlockShapeSpawner>.Instance;
            if(val_9 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_9.FillShapeContainer(skipAutosave:  true);
            BlockPuzzleMagic.GameProgressManager val_10 = MonoSingleton<BlockPuzzleMagic.GameProgressManager>.Instance;
            if(val_10 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_10.SaveGame();
            return;
            label_16:
            this.GameOver(success:  true);
        }
        private void BreakThisLine(System.Collections.Generic.List<BlockPuzzleMagic.GridCell> breakingLine, float animationDelay = 0)
        {
            bool val_1 = true;
            this.UpdateGoalProgress(clearedBlocks:  breakingLine, skipRowColumnCheck:  false);
            if(val_1 < 1)
            {
                    return;
            }
            
            var val_3 = 0;
            do
            {
                if(val_1 <= val_3)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_1 = val_1 + 0;
                float val_2 = 0f;
                val_2 = val_2 * 0.03f;
                val_2 = val_2 + animationDelay;
                (true + 0) + 32.ClearCell(doAnimation:  true, animationDelay:  val_2, ignoreBreaksRequired:  false);
                val_3 = val_3 + 1;
            }
            while(val_3 < val_1);
        
        }
        public void UpdateGoalProgress(System.Collections.Generic.List<BlockPuzzleMagic.GridCell> clearedBlocks, bool skipRowColumnCheck = False)
        {
            var val_7;
            var val_8;
            System.Collections.Generic.List<BlockPuzzleMagic.Goal> val_9;
            var val_11;
            var val_13;
            if(true < 1)
            {
                    return;
            }
            
            if(this.currentLevel.goals == null)
            {
                    return;
            }
            
            val_7 = 0;
            val_8 = 0;
            label_39:
            if(val_7 >= this.currentLevel.goals)
            {
                goto label_5;
            }
            
            GamePlay.<>c__DisplayClass31_0 val_1 = new GamePlay.<>c__DisplayClass31_0();
            val_9 = this.currentLevel.goals;
            if(this.currentLevel <= val_7)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            .currentGoal = BlockPuzzleMagic.Level.__il2cppRuntimeField_byval_arg;
            if(skipRowColumnCheck == true)
            {
                goto label_12;
            }
            
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_9 = mem[BlockPuzzleMagic.Level.__il2cppRuntimeField_byval_arg + 16 + 32 + 24];
            val_9 = BlockPuzzleMagic.Level.__il2cppRuntimeField_byval_arg + 16 + 32 + 24;
            var val_2 = W10 - 1;
            if(W10 == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_11 = mem[(BlockPuzzleMagic.Level.__il2cppRuntimeField_byval_arg + 16 + ((W10 - 1)) << 3) + 32 + 24];
            val_11 = (BlockPuzzleMagic.Level.__il2cppRuntimeField_byval_arg + 16 + ((W10 - 1)) << 3) + 32 + 24;
            goto label_17;
            label_12:
            if(skipRowColumnCheck == true)
            {
                goto label_19;
            }
            
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_9 = mem[BlockPuzzleMagic.Level.__il2cppRuntimeField_byval_arg + 16 + 32 + 28];
            val_9 = BlockPuzzleMagic.Level.__il2cppRuntimeField_byval_arg + 16 + 32 + 28;
            var val_3 = W10 - 1;
            if(W10 == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_11 = mem[(BlockPuzzleMagic.Level.__il2cppRuntimeField_byval_arg + 16 + ((W10 - 1)) << 3) + 32 + 28];
            val_11 = (BlockPuzzleMagic.Level.__il2cppRuntimeField_byval_arg + 16 + ((W10 - 1)) << 3) + 32 + 28;
            label_17:
            if(val_9 != val_11)
            {
                goto label_36;
            }
            
            int val_7 = (GamePlay.<>c__DisplayClass31_0)[1152921520158146816].currentGoal.currentValue;
            val_7 = val_7 + 1;
            (GamePlay.<>c__DisplayClass31_0)[1152921520158146816].currentGoal.currentValue = val_7;
            goto label_26;
            label_19:
            val_13 = null;
            val_13 = null;
            val_9 = GamePlay.<>c.<>9__31_0;
            if(val_9 == null)
            {
                    System.Predicate<BlockPuzzleMagic.GridCell> val_4 = null;
                val_9 = val_4;
                val_4 = new System.Predicate<BlockPuzzleMagic.GridCell>(object:  GamePlay.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean GamePlay.<>c::<UpdateGoalProgress>b__31_0(BlockPuzzleMagic.GridCell obj));
                GamePlay.<>c.<>9__31_0 = val_9;
            }
            
            System.Collections.Generic.List<T> val_6 = clearedBlocks.FindAll(match:  null);
            if( < 1)
            {
                goto label_36;
            }
            
             = ((GamePlay.<>c__DisplayClass31_0)[1152921520158146816].currentGoal.currentValue) + ;
            (GamePlay.<>c__DisplayClass31_0)[1152921520158146816].currentGoal.currentValue = ;
            label_26:
            val_8 = 1;
            label_36:
            val_7 = val_7 + 1;
            if(this.currentLevel.goals != null)
            {
                goto label_39;
            }
            
            throw new NullReferenceException();
            label_5:
            if((val_8 & 1) == 0)
            {
                    return;
            }
            
            if(this.OnGoalProgressUpdated == null)
            {
                    return;
            }
            
            this.OnGoalProgressUpdated.Invoke();
        }
        public bool CanPlaceShape(BlockPuzzleMagic.ShapeInfo blockShape, out System.Collections.Generic.List<BlockPuzzleMagic.GridCell> fittingBlocks)
        {
            bool val_5 = true;
            var val_6 = 0;
            label_9:
            if(val_6 >= val_5)
            {
                goto label_2;
            }
            
            if(val_5 <= val_6)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_5 = val_5 + 0;
            if(((true + 0) + 32 + 36) != 0)
            {
                    if((((true + 0) + 32.isFilled) != true) && (((true + 0) + 32 + 37) != 0))
            {
                    if((this.CheckShapeCanPlace(placingCell:  (true + 0) + 32, placingBlockShape:  blockShape, fittingBlocks: out  System.Collections.Generic.List<BlockPuzzleMagic.GridCell> val_2 = fittingBlocks)) == true)
            {
                    return false;
            }
            
            }
            
            }
            
            val_6 = val_6 + 1;
            if(this.cellGrid != null)
            {
                goto label_9;
            }
            
            throw new NullReferenceException();
            label_2:
            fittingBlocks = new System.Collections.Generic.List<BlockPuzzleMagic.GridCell>();
            return false;
        }
        private bool CheckShapeCanPlace(BlockPuzzleMagic.GridCell placingCell, BlockPuzzleMagic.ShapeInfo placingBlockShape, out System.Collections.Generic.List<BlockPuzzleMagic.GridCell> fittingBlocks)
        {
            System.Collections.Generic.List<BlockPuzzleMagic.GridCell> val_1 = new System.Collections.Generic.List<BlockPuzzleMagic.GridCell>();
            fittingBlocks = val_1;
            if((placingBlockShape == 0) || ((placingBlockShape.<ShapeBlocks>k__BackingField) == null))
            {
                    return true;
            }
            
            var val_11 = 0;
            label_33:
            if(val_11 >= (placingBlockShape.<ShapeBlocks>k__BackingField))
            {
                    return true;
            }
            
            if(1152921505045450752 <= val_11)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            bool val_4 = UnityEngine.Object.op_Inequality(x:  public System.Int64 System.Runtime.Serialization.ObjectIDGenerator::HasId(object obj, out bool firstTime).__il2cppRuntimeField_28, y:  0);
            .adjustedRowIdForBlock = ((public System.Int64 System.Runtime.Serialization.ObjectIDGenerator::HasId(object obj, out bool firstTime).__il2cppRuntimeField_30 + placingCell.rowId) - placingBlockShape.<FirstBlock>k__BackingField;
            .adjustedColIdForBlock = ((public System.Int64 System.Runtime.Serialization.ObjectIDGenerator::HasId(object obj, out bool firstTime).__il2cppRuntimeField_34 + placingCell.columnId) - placingBlockShape.<FirstBlock>k__BackingFi;
            BlockPuzzleMagic.GridCell val_8 = this.cellGrid.Find(match:  new System.Predicate<BlockPuzzleMagic.GridCell>(object:  new GamePlay.<>c__DisplayClass33_0(), method:  System.Boolean GamePlay.<>c__DisplayClass33_0::<CheckShapeCanPlace>b__0(BlockPuzzleMagic.GridCell o)));
            if(val_8 != 0)
            {
                goto label_22;
            }
            
            if(placingBlockShape.allowPartialFit == true)
            {
                goto label_23;
            }
            
            goto label_24;
            label_22:
            if((val_8.<isOn>k__BackingField) != false)
            {
                    if((val_8.isFilled != true) && (val_8.isInteractable != false))
            {
                    if(fittingBlocks != null)
            {
                goto label_29;
            }
            
            }
            
            }
            
            if(placingBlockShape.ignoreFilled == false)
            {
                goto label_32;
            }
            
            label_29:
            val_1.Add(item:  val_8);
            label_23:
            val_11 = val_11 + 1;
            if((placingBlockShape.<ShapeBlocks>k__BackingField) != null)
            {
                goto label_33;
            }
            
            return true;
            label_24:
            label_32:
            val_1.Clear();
            return true;
        }
        public void NotifyShapePlaced(BlockPuzzleMagic.ShapeInfo shape)
        {
            if((System.Type.op_Equality(left:  shape.GetType(), right:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()))) != false)
            {
                    int val_5 = this.currentLevel.movesMade;
                val_5 = val_5 + 1;
                this.currentLevel.movesMade = val_5;
            }
            
            if(this.OnShapePlaced != null)
            {
                    this.OnShapePlaced.Invoke(obj:  shape);
            }
            
            MonoExtensions.DelayedCallEndOfFrame(monoBehaviour:  this, callback:  new System.Action(object:  this, method:  public System.Void BlockPuzzleMagic.GamePlay::CheckBoardStatus()), count:  1);
        }
        public void NotifyShapeRotated(BlockPuzzleMagic.ShapeInfo shape)
        {
            MonoSingleton<BlockPuzzleMagic.BlockShapeSpawner>.Instance.CheckIfAvailableShapesArePlaceable();
            BestBlocksPlayer val_2 = BestBlocksPlayer.Instance;
            if(this.currentLevel == null)
            {
                goto label_4;
            }
            
            label_7:
            val_2.IncrementCurrentRotationsUsed(mode:  this.currentLevel.gameMode, stepAmt:  1);
            if(this.OnShapeRotated == null)
            {
                    return;
            }
            
            this.OnShapeRotated.Invoke(obj:  shape);
            return;
            label_4:
            if(val_2 != null)
            {
                goto label_7;
            }
            
            throw new NullReferenceException();
        }
        public bool CanUsePowerup(BlockPuzzleMagic.PowerUpType powerupType, bool showStoreIfOOC = False, float oocDelay = 0)
        {
            BlockPuzzleMagic.PowerUpType val_15;
            int val_16;
            var val_17;
            val_15 = powerupType;
            BestBlocksPlayer val_1 = BestBlocksPlayer.Instance;
            BlockPuzzleMagic.BestBlocksGameEcon val_3 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
            if(val_15 > 3)
            {
                goto label_5;
            }
            
            var val_14 = 32563400 + (powerupType) << 2;
            val_14 = val_14 + 32563400;
            goto (32563400 + (powerupType) << 2 + 32563400);
            label_5:
            val_16 = 0;
            decimal val_6 = BlockPuzzleMagic.BestBlocksGameEcon.Instance.GetPowerupCost(_type:  val_15);
            if((System.Decimal.op_GreaterThanOrEqual(d1:  new System.Decimal() {lo = X24, mid = X24}, d2:  new System.Decimal() {flags = val_6.flags, hi = val_6.hi, lo = val_6.lo, mid = val_6.mid})) != true)
            {
                    if((val_1.IsFreePowerupAvailable(powerupType:  val_15)) == false)
            {
                goto label_16;
            }
            
            }
            
            val_17 = 1;
            goto label_17;
            label_16:
            val_17 = BlockPuzzleMagic.BBLFtuxData.IsFreeTutorialPowerupAvailable(powerupType:  val_15);
            label_17:
            bool val_10 = val_17 & (GameEcon.IsEnabledAndLevelMet(playerLevel:  val_1.level, knobValue:  0));
            val_17 = showStoreIfOOC & (~val_10);
            if(val_17 == false)
            {
                    return val_10;
            }
            
            .originatingPowerup = val_15;
            DG.Tweening.TweenCallback val_12 = null;
            val_15 = val_12;
            val_12 = new DG.Tweening.TweenCallback(object:  new GamePlay.<>c__DisplayClass36_0(), method:  System.Void GamePlay.<>c__DisplayClass36_0::<CanUsePowerup>b__0());
            DG.Tweening.Tween val_13 = DG.Tweening.DOVirtual.DelayedCall(delay:  oocDelay, callback:  val_12, ignoreTimeScale:  true);
            return val_10;
        }
        public bool BuyPowerup(BlockPuzzleMagic.PowerUpType powerupType, bool freeUsage = False)
        {
            var val_7;
            var val_8;
            if(((BlockPuzzleMagic.BBLFtuxData.IsFreeTutorialPowerupAvailable(powerupType:  powerupType)) == true) || (freeUsage == true))
            {
                goto label_4;
            }
            
            if((BestBlocksPlayer.Instance.IsFreePowerupAvailable(powerupType:  powerupType)) == true)
            {
                goto label_6;
            }
            
            if(powerupType > 3)
            {
                goto label_7;
            }
            
            val_7 = mem[39724832 + (powerupType) << 3];
            val_7 = 39724832 + (powerupType) << 3;
            goto label_8;
            label_4:
            label_6:
            int val_7 = val_1.levelPowerupFreeUsed;
            val_8 = 1;
            val_7 = val_7 + 1;
            val_1.levelPowerupFreeUsed = val_7;
            return (bool)val_8;
            label_7:
            label_8:
            decimal val_5 = BlockPuzzleMagic.BestBlocksGameEcon.Instance.GetPowerupCost(_type:  powerupType);
            bool val_6 = CurrencyController.DebitBalance(value:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid}, source:  System.String.__il2cppRuntimeField_static_fields, externalParams:  0, animated:  false);
            val_8 = 0;
            return (bool)val_8;
        }
        public void UsePowerup(BlockPuzzleMagic.PowerUpType powerupType, bool freeUsage)
        {
            var val_6;
            BestBlocksPlayer val_1 = BestBlocksPlayer.Instance;
            int val_2 = EnumerableExtentions.GetOrDefault<BlockPuzzleMagic.PowerUpType, System.Int32>(dic:  val_1.levelPowerupUsed, key:  powerupType, defaultValue:  0);
            val_1.levelPowerupUsed.set_Item(key:  powerupType, value:  val_1.levelPowerupUsed.Item[powerupType] + 1);
            int val_6 = val_1.lifetimePowerupUsed;
            val_6 = val_6 + 1;
            val_1.lifetimePowerupUsed = val_6;
            val_6 = null;
            val_6 = null;
            App.trackerManager.track(eventName:  Events.HINT_USED);
            if(freeUsage != true)
            {
                    NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnHintUsed");
            }
            
            if(this.OnPowerupUsed == null)
            {
                    return;
            }
            
            this.OnPowerupUsed.Invoke(obj:  powerupType);
        }
        public void GameOver(bool success)
        {
            var val_1;
            var val_2;
            var val_3;
            val_1 = null;
            if(success != false)
            {
                    val_2 = null;
                BlockPuzzleMagic.GamePlay.currentLevelFailCount = 0;
            }
            else
            {
                    val_3 = null;
                BlockPuzzleMagic.GamePlay.currentLevelFailCount = 1;
            }
            
            if(this.OnGameOver == null)
            {
                    return;
            }
            
            success = success;
            this.OnGameOver.Invoke(obj:  success);
        }
        public void HackGameOver(bool success = True)
        {
            this.GameOver(success:  success);
        }
        public void HackRefreshCurrentLevel()
        {
            BlockPuzzleMagic.LevelManager val_1 = MonoSingletonSelfGenerating<BlockPuzzleMagic.LevelManager>.Instance;
            if(this.currentLevel == null)
            {
                goto label_3;
            }
            
            label_5:
            this.currentLevel = val_1.GetGameLevel(gameMode:  this.currentLevel.gameMode);
            return;
            label_3:
            if(val_1 != null)
            {
                goto label_5;
            }
            
            throw new NullReferenceException();
        }
        public void HackQuickGoNextLevel()
        {
            BlockPuzzleMagic.Level val_4;
            BlockPuzzleMagic.GameMode val_5;
            val_4 = this.currentLevel;
            if(val_4 == null)
            {
                goto label_7;
            }
            
            if(this.currentLevel.gameMode != 2)
            {
                goto label_2;
            }
            
            GameBehavior val_1 = App.getBehavior;
            MetaGameBehavior val_2 = (val_1.<metaGameBehavior>k__BackingField) + 1;
            val_4 = this.currentLevel;
            if(val_4 == null)
            {
                goto label_7;
            }
            
            label_2:
            val_5 = this.currentLevel.gameMode;
            goto label_8;
            label_7:
            val_5 = 0;
            label_8:
            MonoSingleton<BlockPuzzleMagic.GameProgressManager>.Instance.ClearProgress(gameMode:  val_5);
            this.Init(gameMode:  val_5);
        }
        public GamePlay()
        {
        
        }
        private static GamePlay()
        {
        
        }
    
    }

}
