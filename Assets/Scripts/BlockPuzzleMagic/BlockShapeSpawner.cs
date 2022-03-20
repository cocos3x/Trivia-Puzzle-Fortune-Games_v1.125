using UnityEngine;

namespace BlockPuzzleMagic
{
    public class BlockShapeSpawner : MonoSingleton<BlockPuzzleMagic.BlockShapeSpawner>
    {
        // Fields
        private const int RANDOM_PICKLIMIT_PER_SHAPE = 3;
        private UnityEngine.Transform[] ShapeContainers;
        private UnityEngine.UI.Image[] rotateShapeIcon;
        private UnityEngine.GameObject TrashTooltip;
        private BlockPuzzleMagic.ShapeInfo[] spawnedShapes;
        private BlockPuzzleMagic.ShapeInfo[] spawnedPowerupShapes;
        private DG.Tweening.Sequence[] rotationIconSeq;
        private System.Collections.Generic.Dictionary<int, int> shapeBlockPickCounter;
        private System.Collections.Generic.Dictionary<BlockPuzzleMagic.BlockColorType, int> shapeColorPickCounter;
        private BlockPuzzleMagic.ShapeBlockList activeShapeBlockModule;
        private System.Collections.Generic.List<int> shapeBlockRandomPool;
        private System.Collections.Generic.List<BlockPuzzleMagic.BlockColorType> shapeColorRandomPool;
        private System.Collections.Generic.HashSet<int> tempCachedShapeInfoIndexes;
        private RandomSet powerupAPChanceRandomSet;
        
        // Properties
        public UnityEngine.Transform[] getShapeContainers { get; }
        public BlockPuzzleMagic.ShapeInfo[] SpawnedShapes { get; }
        public BlockPuzzleMagic.ShapeInfo[] SpawnedPowerupShapes { get; }
        public bool Interactable { set; }
        
        // Methods
        public UnityEngine.Transform[] get_getShapeContainers()
        {
            return (UnityEngine.Transform[])this.ShapeContainers;
        }
        public BlockPuzzleMagic.ShapeInfo[] get_SpawnedShapes()
        {
            return (BlockPuzzleMagic.ShapeInfo[])this.spawnedShapes;
        }
        public BlockPuzzleMagic.ShapeInfo[] get_SpawnedPowerupShapes()
        {
            return (BlockPuzzleMagic.ShapeInfo[])this.spawnedPowerupShapes;
        }
        public void set_Interactable(bool value)
        {
            BlockPuzzleMagic.ShapeInfo val_7;
            var val_13 = 4;
            do
            {
                if((val_13 - 4) >= (this.spawnedShapes.Length << ))
            {
                    return;
            }
            
                if((this.spawnedShapes[0] != 0) && ((this.tempCachedShapeInfoIndexes.Contains(item:  val_13 - 4)) != true))
            {
                    if(this.spawnedPowerupShapes[0] == 0)
            {
                    this.spawnedShapes[0].Interactable = value;
            }
            
            }
            
                val_7 = this.spawnedPowerupShapes[0];
                if(val_7 != 0)
            {
                    this.spawnedPowerupShapes[0].Interactable = value;
            }
            
                val_13 = val_13 + 1;
            }
            while(this.spawnedShapes != null);
            
            throw new NullReferenceException();
        }
        public override void InitMonoSingleton()
        {
            var val_3 = 0;
            label_7:
            if(val_3 >= (this.spawnedShapes.Length << ))
            {
                goto label_2;
            }
            
            if(this.spawnedShapes[val_3] == 0)
            {
                    this.ToggleRotationIcon(iconIndex:  0, isVisible:  false);
            }
            
            val_3 = val_3 + 1;
            if(this.spawnedShapes != null)
            {
                goto label_7;
            }
            
            throw new NullReferenceException();
            label_2:
            this.TrashTooltip.SetActive(value:  false);
        }
        private void Start()
        {
            AdsUIController val_1 = MonoSingleton<AdsUIController>.Instance;
            val_1.onAdToggled.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void BlockPuzzleMagic.BlockShapeSpawner::OnCanvasResized()));
        }
        private void OnDestroy()
        {
            if((MonoSingleton<AdsUIController>.Instance) == 0)
            {
                    return;
            }
            
            AdsUIController val_3 = MonoSingleton<AdsUIController>.Instance;
            if(val_3.onAdToggled == null)
            {
                    return;
            }
            
            AdsUIController val_4 = MonoSingleton<AdsUIController>.Instance;
            val_4.onAdToggled.RemoveListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void BlockPuzzleMagic.BlockShapeSpawner::OnCanvasResized()));
        }
        private void OnCanvasResized()
        {
            UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.UpdateSpawnShapesPosition());
        }
        private System.Collections.IEnumerator UpdateSpawnShapesPosition()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new BlockShapeSpawner.<UpdateSpawnShapesPosition>d__26();
        }
        public void Init(System.Collections.Generic.List<BlockPuzzleMagic.ShapeInfoData> shapesData, System.Collections.Generic.List<BlockPuzzleMagic.ShapeInfoData> posweupShapesData)
        {
            int val_12;
            int val_13;
            IntPtr val_14;
            System.Action val_15;
            object val_16;
            BlockShapeSpawner.<>c__DisplayClass27_0 val_1 = new BlockShapeSpawner.<>c__DisplayClass27_0();
            .shapesData = shapesData;
            .<>4__this = this;
            .posweupShapesData = posweupShapesData;
            this.DestroyShapes();
            BlockPuzzleMagic.GameReferenceData val_2 = BlockPuzzleMagic.GameReferenceData.Instance;
            this.activeShapeBlockModule = val_2.shapeBlockList;
            this.ResetShapeBlockRandomPool();
            this.ResetShapeColorRandomPool();
            BlockPuzzleMagic.GamePlay val_3 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            BlockPuzzleMagic.BestBlocksGameEcon val_4 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
            this.powerupAPChanceRandomSet.clear();
            this.powerupAPChanceRandomSet.replacement = true;
            if(val_3.currentLevel.levelId < val_4.powerupBombTutorialLevel)
            {
                    val_12 = 0;
            }
            else
            {
                    float val_13 = val_4.bombBlockAPChance;
                val_13 = val_13 * 100f;
                val_13 = (val_13 == Infinityf) ? (-(double)val_13) : ((double)val_13);
                val_12 = (int)val_13;
            }
            
            if(val_3.currentLevel.levelId < val_4.powerupFillTutorialLevel)
            {
                    val_13 = 0;
            }
            else
            {
                    float val_14 = val_4.rainbowBlockAPChance;
                val_14 = val_14 * 100f;
                val_14 = (val_14 == Infinityf) ? (-(double)val_14) : ((double)val_14);
                val_13 = (int)val_14;
            }
            
            var val_5 = 10000 - val_12;
            this.powerupAPChanceRandomSet.add(item:  0, weight:  (float)UnityEngine.Mathf.Max(a:  0, b:  val_5 - val_13));
            this.powerupAPChanceRandomSet.add(item:  1, weight:  (float)val_12);
            this.powerupAPChanceRandomSet.add(item:  2, weight:  (float)val_13);
            if(((BlockShapeSpawner.<>c__DisplayClass27_0)[1152921520138619520].shapesData) == null)
            {
                goto label_29;
            }
            
            var val_15 = 4;
            label_30:
            var val_8 = val_15 - 4;
            if(val_8 >= val_5)
            {
                goto label_22;
            }
            
            if(val_5 <= val_8)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            if((((10000 - val_4.bombBlockAPChance == Infinityf ? (val_4.bombBlockAPChance * 100f) : (val_4.bombBlockAPChance * 100f)) + 32 + 16) & 2147483648) != 0)
            {
                goto label_25;
            }
            
            if(((10000 - val_4.bombBlockAPChance == Infinityf ? (val_4.bombBlockAPChance * 100f) : (val_4.bombBlockAPChance * 100f)) + 32 + 16) <= val_8)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            if((this.DoesShapeIdExists(shapeId:  (10000 - val_4.bombBlockAPChance == Infinityf ? (val_4.bombBlockAPChance * 100f) : (val_4.bombBlockAPChance * 100f)) + 32 + 16 + 32 + 16)) == false)
            {
                goto label_29;
            }
            
            label_25:
            val_15 = val_15 + 1;
            if(((BlockShapeSpawner.<>c__DisplayClass27_0)[1152921520138619520].shapesData) != null)
            {
                goto label_30;
            }
            
            throw new NullReferenceException();
            label_29:
            val_14 = 1152921520138534848;
            val_15 = new System.Action();
            val_16 = this;
            goto label_31;
            label_22:
            System.Action val_10 = null;
            val_14 = 1152921520138539968;
            val_15 = val_10;
            val_16 = val_1;
            label_31:
            val_10 = new System.Action(object:  val_1, method:  val_14);
            MonoExtensions.DelayedCallEndOfFrame(monoBehaviour:  this, callback:  val_10, count:  1);
            if(((BlockShapeSpawner.<>c__DisplayClass27_0)[1152921520138619520].posweupShapesData) != null)
            {
                    MonoExtensions.DelayedCallEndOfFrame(monoBehaviour:  this, callback:  new System.Action(object:  val_1, method:  System.Void BlockShapeSpawner.<>c__DisplayClass27_0::<Init>b__1()), count:  2);
            }
            
            MonoExtensions.DelayedCallEndOfFrame(monoBehaviour:  this, callback:  new System.Action(object:  val_1, method:  System.Void BlockShapeSpawner.<>c__DisplayClass27_0::<Init>b__2()), count:  3);
        }
        private void ResetShapeBlockRandomPool()
        {
            BlockPuzzleMagic.GameMode val_5;
            System.Collections.Generic.List<BlockPuzzleMagic.ShapeBlockSpawn> val_6;
            BlockPuzzleMagic.BestBlocksGameEcon val_1 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
            BlockPuzzleMagic.GamePlay val_2 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            if(val_2.currentLevel == null)
            {
                goto label_6;
            }
            
            val_5 = val_2.currentLevel.gameMode;
            if(val_1 != null)
            {
                goto label_7;
            }
            
            label_6:
            val_5 = 0;
            label_7:
            this.shapeBlockPickCounter.Clear();
            this.shapeBlockRandomPool.Clear();
            var val_6 = 4;
            label_29:
            val_6 = this.activeShapeBlockModule.ShapeBlocks;
            var val_4 = val_6 - 4;
            if(val_4 >= this.activeShapeBlockModule)
            {
                goto label_14;
            }
            
            if(this.activeShapeBlockModule <= val_4)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            if((val_1.GetAllowedShapeIdsForMode(gameMode:  val_5).Contains(item:  -2049764176)) != false)
            {
                    if(this.activeShapeBlockModule <= val_4)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                this.shapeBlockPickCounter.Add(key:  -2049764176, value:  0);
                val_6 = this.shapeBlockRandomPool;
                if(this.activeShapeBlockModule <= val_4)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_6.Add(item:  -2049764176);
            }
            
            val_6 = val_6 + 1;
            if(this.activeShapeBlockModule != null)
            {
                goto label_29;
            }
            
            throw new NullReferenceException();
            label_14:
            PluginExtension.Shuffle<System.Int32>(list:  this.shapeBlockRandomPool, seed:  new System.Nullable<System.Int32>() {HasValue = false});
        }
        private void ResetShapeColorRandomPool()
        {
            var val_1;
            var val_2;
            this.shapeColorPickCounter.Clear();
            this.shapeColorRandomPool.Clear();
            val_1 = 8;
            goto label_3;
            label_15:
            this.shapeColorPickCounter.Add(key:  BlockPuzzleMagic.BlockColor.STANDARD_REGULAR_COLORS + 32, value:  0);
            this.shapeColorRandomPool.Add(item:  BlockPuzzleMagic.BlockColor.STANDARD_REGULAR_COLORS + 32);
            val_1 = 9;
            label_3:
            val_2 = null;
            val_2 = null;
            if((val_1 - 8) < BlockPuzzleMagic.BlockColor.STANDARD_REGULAR_COLORS.Length)
            {
                goto label_15;
            }
            
            PluginExtension.Shuffle<BlockPuzzleMagic.BlockColorType>(list:  this.shapeColorRandomPool, seed:  new System.Nullable<System.Int32>() {HasValue = false});
        }
        public void RegenerateNewShapes()
        {
            this.DestroyShapes();
            DG.Tweening.Tween val_2 = DG.Tweening.DOVirtual.DelayedCall(delay:  0.1f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  public System.Void BlockPuzzleMagic.BlockShapeSpawner::FillShapeContainer()), ignoreTimeScale:  true);
        }
        public void DestroyShape(int containerIndex)
        {
            BlockPuzzleMagic.ShapeInfo val_3;
            val_3 = this.spawnedShapes[(long)containerIndex];
            if(val_3 != 0)
            {
                    val_3 = this.spawnedShapes[(long)containerIndex].gameObject;
                UnityEngine.Object.Destroy(obj:  val_3);
            }
            
            this.spawnedShapes[(long)containerIndex] = 0;
        }
        private void DestroyShapes()
        {
            var val_1 = 0;
            do
            {
                if(val_1 >= this.spawnedShapes.Length)
            {
                    return;
            }
            
                this.DestroyShape(containerIndex:  0);
                val_1 = val_1 + 1;
            }
            while(this.spawnedShapes != null);
            
            throw new NullReferenceException();
        }
        public void FillShapeContainer()
        {
            this.FillShapeContainer(skipAutosave:  false);
        }
        public void FillShapeContainer(bool skipAutosave)
        {
            UnityEngine.Object val_18;
            var val_19;
            var val_20;
            var val_21;
            int val_22;
            var val_23;
            BlockPuzzleMagic.BlockColorType val_24;
            var val_19 = 0;
            label_7:
            if(val_19 >= (this.spawnedShapes.Length << ))
            {
                goto label_2;
            }
            
            val_18 = this.spawnedShapes[val_19];
            if(val_18 != 0)
            {
                goto label_6;
            }
            
            val_19 = val_19 + 1;
            if(this.spawnedShapes != null)
            {
                goto label_7;
            }
            
            label_2:
            val_19 = 1;
            goto label_9;
            label_6:
            val_19 = 0;
            label_9:
            var val_21 = 0;
            label_16:
            if(val_21 >= (this.spawnedPowerupShapes.Length << ))
            {
                goto label_11;
            }
            
            if(this.spawnedPowerupShapes[val_21] != 0)
            {
                goto label_18;
            }
            
            val_21 = val_21 + 1;
            if(this.spawnedPowerupShapes != null)
            {
                goto label_16;
            }
            
            label_11:
            if(val_19 == 0)
            {
                goto label_18;
            }
            
            System.Collections.Generic.List<System.Int32> val_6 = this.GetRandomShapeIds(isEasyMode:  BlockPuzzleMagic.BestBlocksGameEcon.Instance.IsEasyMode(), qty:  this.ShapeContainers.Length);
            var val_28 = 0;
            label_47:
            if(val_28 >= (this.ShapeContainers.Length << ))
            {
                goto label_24;
            }
            
            if(val_28 >= this.ShapeContainers.Length)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            this.spawnedShapes[val_28] = this.CreateShapeWithID(shapeContainer:  this.ShapeContainers[val_28], shapeID:  this.ShapeContainers[val_28][0], shapeColor:  BlockPuzzleMagic.GameReferenceData.Instance.GetBlockColor(colorType:  2));
            if(this.spawnedPowerupShapes[val_28] != 0)
            {
                    this.spawnedShapes[val_28].Alpha = 0f;
                BlockPuzzleMagic.ShapeInfo val_26 = this.spawnedShapes[val_28];
                this.spawnedShapes[0x0][0].neutralAlpha = 0f;
                this.spawnedShapes[val_28].Interactable = false;
            }
            
            val_28 = val_28 + 1;
            if(this.ShapeContainers != null)
            {
                goto label_47;
            }
            
            label_18:
            val_20 = 1;
            goto label_49;
            label_24:
            val_20 = 0;
            label_49:
            val_21 = 0;
            label_69:
            if(val_21 >= (this.spawnedShapes.Length << ))
            {
                goto label_51;
            }
            
            if(this.spawnedShapes[val_21] == 0)
            {
                    BlockPuzzleMagic.GamePlay val_12 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
                val_22 = 0;
                val_23 = val_21;
                val_24 = 0;
            }
            else
            {
                    BlockPuzzleMagic.GamePlay val_13 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
                BlockPuzzleMagic.ShapeInfo val_30 = this.spawnedShapes[val_21];
                val_22 = this.spawnedShapes[0x0][0].shapeId;
                val_24 = this.spawnedShapes[0x0][0].colorData.blockColor;
                val_23 = val_21;
            }
            
            val_13.currentLevel.SetUsableShapeData(containerId:  0, shapeId:  val_22, shapeColor:  val_24);
            val_21 = val_21 + 1;
            if(this.spawnedShapes != null)
            {
                goto label_69;
            }
            
            throw new NullReferenceException();
            label_51:
            if((val_20 | skipAutosave) != true)
            {
                    MonoSingleton<BlockPuzzleMagic.GameProgressManager>.Instance.SaveGame();
            }
            
            DG.Tweening.Tween val_17 = DG.Tweening.DOVirtual.DelayedCall(delay:  0.2f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  public System.Void BlockPuzzleMagic.BlockShapeSpawner::CheckIfAvailableShapesArePlaceable()), ignoreTimeScale:  true);
        }
        private System.Collections.Generic.List<int> GetRandomShapeIds(bool isEasyMode, int qty = 3)
        {
            var val_36;
            var val_37;
            System.Collections.Generic.List<T> val_38;
            System.Collections.Generic.Dictionary<System.Int32, System.Int32> val_39;
            int val_40;
            var val_41;
            var val_42;
            var val_43;
            var val_44;
            var val_45;
            var val_46;
            var val_47;
            var val_48;
            var val_49;
            int val_50;
            var val_51;
            System.Collections.Generic.List<System.Int32> val_52;
            val_36 = isEasyMode;
            BlockPuzzleMagic.GamePlay val_1 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            val_37 = 1152921504687730688;
            System.Collections.Generic.List<System.Int32> val_2 = new System.Collections.Generic.List<System.Int32>(capacity:  3);
            System.Collections.Generic.List<BlockPuzzleMagic.GridCell> val_3 = null;
            val_38 = val_3;
            val_3 = new System.Collections.Generic.List<BlockPuzzleMagic.GridCell>();
            System.Collections.Generic.List<System.Int32> val_4 = null;
            val_39 = val_4;
            val_4 = new System.Collections.Generic.List<System.Int32>();
            if(1152921510062986752 >= 1)
            {
                    val_37 = 1152921510479955696;
                do
            {
                if(1152921510062986752 <= 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                if(isFilled != true)
            {
                    val_4.Add(item:  0);
            }
            
                val_40 = 0 + 1;
            }
            while(val_40 < 1);
            
            }
            
            if((val_36 == true) || (1152921510062986752 < 1))
            {
                goto label_16;
            }
            
            label_52:
            if(0 >= 1152921510062986752)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            int val_7 = BlockPuzzleMagic.GridLayout.GetCellIdTowardsDirection(cellId:  BlockPuzzleMagic.GridLayout.__il2cppRuntimeField_cctor_finished + 32, dir:  3);
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            int val_8 = BlockPuzzleMagic.GridLayout.GetCellIdTowardsDirection(cellId:  BlockPuzzleMagic.GridLayout.__il2cppRuntimeField_cctor_finished + 32, dir:  4);
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_40 = BlockPuzzleMagic.GridLayout.GetCellIdTowardsDirection(cellId:  BlockPuzzleMagic.GridLayout.__il2cppRuntimeField_cctor_finished + 32, dir:  2);
            if(((BlockPuzzleMagic.GridLayout.GetCellIdTowardsDirection(cellId:  30404608, dir:  1)) & 2147483648) != 0)
            {
                goto label_23;
            }
            
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_41 = mem[(BlockPuzzleMagic.GridLayout.__il2cppRuntimeField_cctor_finished + (val_6) << 3) + 32 + 36];
            val_41 = (BlockPuzzleMagic.GridLayout.__il2cppRuntimeField_cctor_finished + (val_6) << 3) + 32 + 36;
            if(((BlockPuzzleMagic.GridLayout.__il2cppRuntimeField_cctor_finished + (val_6) << 3) + 32.isFilled) == false)
            {
                goto label_27;
            }
            
            val_41 = 0;
            goto label_28;
            label_23:
            val_42 = 1;
            if((val_7 & 2147483648) == 0)
            {
                goto label_29;
            }
            
            label_33:
            val_43 = 1;
            if((val_8 & 2147483648) == 0)
            {
                goto label_30;
            }
            
            label_39:
            val_37 = 1;
            if((val_40 & 2147483648) == 0)
            {
                goto label_31;
            }
            
            label_45:
            val_44 = 1;
            goto label_32;
            label_27:
            var val_11 = (((BlockPuzzleMagic.GridLayout.__il2cppRuntimeField_cctor_finished + (val_6) << 3) + 32 + 37) != 0) ? 1 : 0;
            label_28:
            val_42 = val_11 ^ 1;
            if((val_7 & 2147483648) != 0)
            {
                goto label_33;
            }
            
            label_29:
            if(val_11 <= val_7)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_11 = val_11 + (val_7 << 3);
            val_45 = mem[((BlockPuzzleMagic.GridLayout.__il2cppRuntimeField_cctor_finished + (val_6) << 3) + 32 + 37 != 0x0 ? 1 : 0 + (val_7) << 3) + 32 + 36];
            val_45 = ((BlockPuzzleMagic.GridLayout.__il2cppRuntimeField_cctor_finished + (val_6) << 3) + 32 + 37 != 0x0 ? 1 : 0 + (val_7) << 3) + 32 + 36;
            if((((BlockPuzzleMagic.GridLayout.__il2cppRuntimeField_cctor_finished + (val_6) << 3) + 32 + 37 != 0x0 ? 1 : 0 + (val_7) << 3) + 32.isFilled) != false)
            {
                    val_45 = 0;
            }
            else
            {
                    var val_13 = ((((BlockPuzzleMagic.GridLayout.__il2cppRuntimeField_cctor_finished + (val_6) << 3) + 32 + 37 != 0x0 ? 1 : 0 + (val_7) << 3) + 32 + 37) != 0) ? 1 : 0;
            }
            
            val_43 = val_13 ^ 1;
            if((val_8 & 2147483648) != 0)
            {
                goto label_39;
            }
            
            label_30:
            if(val_13 <= val_8)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_13 = val_13 + (val_8 << 3);
            val_46 = mem[(((BlockPuzzleMagic.GridLayout.__il2cppRuntimeField_cctor_finished + (val_6) << 3) + 32 + 37 != 0x0 ? 1 : 0 + (val_7) << 3) + 32 + 37 != 0x0 ? 1 : 0 + (val_8) << 3) + 32 + 36];
            val_46 = (((BlockPuzzleMagic.GridLayout.__il2cppRuntimeField_cctor_finished + (val_6) << 3) + 32 + 37 != 0x0 ? 1 : 0 + (val_7) << 3) + 32 + 37 != 0x0 ? 1 : 0 + (val_8) << 3) + 32 + 36;
            if(((((BlockPuzzleMagic.GridLayout.__il2cppRuntimeField_cctor_finished + (val_6) << 3) + 32 + 37 != 0x0 ? 1 : 0 + (val_7) << 3) + 32 + 37 != 0x0 ? 1 : 0 + (val_8) << 3) + 32.isFilled) != false)
            {
                    val_46 = 0;
            }
            else
            {
                    var val_15 = (((((BlockPuzzleMagic.GridLayout.__il2cppRuntimeField_cctor_finished + (val_6) << 3) + 32 + 37 != 0x0 ? 1 : 0 + (val_7) << 3) + 32 + 37 != 0x0 ? 1 : 0 + (val_8) << 3) + 32 + 37) != 0) ? 1 : 0;
            }
            
            val_37 = val_15 ^ 1;
            if((val_40 & 2147483648) != 0)
            {
                goto label_45;
            }
            
            label_31:
            if(val_15 <= val_40)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_15 = val_15 + (val_40 << 3);
            val_40 = mem[((((BlockPuzzleMagic.GridLayout.__il2cppRuntimeField_cctor_finished + (val_6) << 3) + 32 + 37 != 0x0 ? 1 : 0 + (val_7) << 3) + 32 + 37 != 0x0 ? 1 : 0 + (val_8) << 3) + 32 + 37 != 0x0 ? 1 : 0 + (val_9) + 32];
            val_40 = ((((BlockPuzzleMagic.GridLayout.__il2cppRuntimeField_cctor_finished + (val_6) << 3) + 32 + 37 != 0x0 ? 1 : 0 + (val_7) << 3) + 32 + 37 != 0x0 ? 1 : 0 + (val_8) << 3) + 32 + 37 != 0x0 ? 1 : 0 + (val_9) + 32;
            val_47 = mem[((((BlockPuzzleMagic.GridLayout.__il2cppRuntimeField_cctor_finished + (val_6) << 3) + 32 + 37 != 0x0 ? 1 : 0 + (val_7) << 3) + 32 + 37 != 0x0 ? 1 : 0 + (val_8) << 3) + 32 + 37 != 0x0 ? 1 : 0 + (val_9) + 32 + 36];
            val_47 = ((((BlockPuzzleMagic.GridLayout.__il2cppRuntimeField_cctor_finished + (val_6) << 3) + 32 + 37 != 0x0 ? 1 : 0 + (val_7) << 3) + 32 + 37 != 0x0 ? 1 : 0 + (val_8) << 3) + 32 + 37 != 0x0 ? 1 : 0 + (val_9) + 32 + 36;
            if(val_40.isFilled != false)
            {
                    val_47 = 0;
            }
            
            val_44 = (((((((BlockPuzzleMagic.GridLayout.__il2cppRuntimeField_cctor_finished + (val_6) << 3) + 32 + 37 != 0x0 ? 1 : 0 + (val_7) << 3) + 32 + 37 != 0x0 ? 1 : 0 + (val_8) << 3) + 32 + 37 != 0x0 ? 1 : 0 + (val_9) + 32 + 37) != 0) ? 1 : 0) ^ 1;
            label_32:
            var val_18 = val_43 & val_42;
            val_18 = val_18 & val_37;
            if(val_18 != val_44)
            {
                goto label_98;
            }
            
            val_39 = val_39;
            val_38 = val_38;
            val_48 = 8 + 1;
            if((8 - 7) < val_44)
            {
                goto label_52;
            }
            
            label_16:
            label_98:
            PluginExtension.Shuffle<System.Int32>(list:  this.shapeBlockRandomPool, seed:  new System.Nullable<System.Int32>() {HasValue = false});
            if(qty < 1)
            {
                goto label_53;
            }
            
            val_48 = 1152921515438572976;
            label_92:
            val_49 = 0;
            .randomShapeId = 0;
            if(0 == 0)
            {
                goto label_58;
            }
            
            int val_21 = this.powerupAPChanceRandomSet.roll(unweighted:  false);
            if(val_21 == 2)
            {
                goto label_57;
            }
            
            val_49 = 0;
            if(val_21 != 1)
            {
                goto label_58;
            }
            
            val_50 = 99;
            goto label_59;
            label_57:
            val_50 = 100;
            label_59:
            .randomShapeId = val_50;
            val_49 = 1;
            label_58:
            val_51 = 0;
            goto label_82;
            label_90:
            val_52 = this.shapeBlockRandomPool;
            val_51 = 1;
            if(0 <= 0)
            {
                    this.ResetShapeBlockRandomPool();
                val_52 = this.shapeBlockRandomPool;
            }
            
            int val_23 = UnityEngine.Random.Range(min:  0, max:  0);
            val_40 = val_23;
            if(val_52 <= val_23)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_52 = val_52 + (val_40 << 2);
            .randomShapeId = this.shapeBlockRandomPool;
            val_39 = this.shapeBlockPickCounter;
            val_39.set_Item(key:  this.shapeBlockRandomPool, value:  val_39.Item[this.shapeBlockRandomPool] + 1);
            if((this.shapeBlockPickCounter.Item[(BlockShapeSpawner.<>c__DisplayClass35_0)[1152921520141612672].randomShapeId]) >= 3)
            {
                    this.shapeBlockRandomPool.RemoveAt(index:  val_40);
            }
            
            val_49 = 1;
            val_36 = 0;
            if((((val_51 < 100) ? 1 : 0) & val_36) != false)
            {
                    val_40 = (BlockShapeSpawner.<>c__DisplayClass35_0)[1152921520141612672].<>9__0;
                if(val_40 == null)
            {
                    System.Predicate<BlockPuzzleMagic.ShapeBlockSpawn> val_28 = null;
                val_40 = val_28;
                val_28 = new System.Predicate<BlockPuzzleMagic.ShapeBlockSpawn>(object:  new BlockShapeSpawner.<>c__DisplayClass35_0(), method:  System.Boolean BlockShapeSpawner.<>c__DisplayClass35_0::<GetRandomShapeIds>b__0(BlockPuzzleMagic.ShapeBlockSpawn o));
                .<>9__0 = val_40;
            }
            
                BlockPuzzleMagic.ShapeBlockSpawn val_29 = this.activeShapeBlockModule.ShapeBlocks.Find(match:  val_28);
                val_49 = 0;
                val_36 = 1;
                if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance.CanPlaceShape(blockShape:  val_29.shapeBlock.GetComponent<BlockPuzzleMagic.ShapeInfo>(), fittingBlocks: out  0)) != false)
            {
                    val_49 = 1;
                val_36 = 1;
                if(9733424 >= 1)
            {
                    val_51 = val_51 + 1;
                var val_35 = 0;
                do
            {
                if(9733424 <= val_35)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                var val_34 = 11993091;
                val_34 = val_34 + 0;
                mem2[0] = 0;
                if(9733424 <= val_35)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_3.Add(item:  mem[4306960419]);
                val_35 = val_35 + 1;
            }
            while(val_35 < 9733424);
            
                var val_36 = 0;
                val_36 = val_36 - val_35;
                val_49 = 1;
                val_36 = 1;
            }
            
            }
            
            }
            
            label_82:
            if((val_51 <= 99) && ((val_49 & 1) == 0))
            {
                    if(val_36 > 0)
            {
                goto label_90;
            }
            
            }
            
            val_2.Add(item:  (BlockShapeSpawner.<>c__DisplayClass35_0)[1152921520141612672].randomShapeId);
            val_38 = val_38;
            val_37 = 1;
            if(val_37 < qty)
            {
                goto label_92;
            }
            
            label_53:
            if(mem[1152921520141600408] < 1)
            {
                    return val_2;
            }
            
            do
            {
                if(mem[1152921520141600408] <= 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                var val_37 = mem[1152921520141600400];
                val_37 = val_37 + 0;
                mem2[0] = 1;
                val_37 = 0 + 1;
            }
            while(val_37 < mem[1152921520141600408]);
            
            return val_2;
        }
        private bool DoesShapeIdExists(int shapeId)
        {
            .shapeId = shapeId;
            return (bool)((this.activeShapeBlockModule.ShapeBlocks.Find(match:  new System.Predicate<BlockPuzzleMagic.ShapeBlockSpawn>(object:  new BlockShapeSpawner.<>c__DisplayClass36_0(), method:  System.Boolean BlockShapeSpawner.<>c__DisplayClass36_0::<DoesShapeIdExists>b__0(BlockPuzzleMagic.ShapeBlockSpawn o)))) != 0) ? 1 : 0;
        }
        public void SetShapeAtContainer(int containerId, int shapeId)
        {
            this.DestroyShape(containerIndex:  containerId);
            this.spawnedShapes[(long)containerId] = this.CreateShapeWithID(shapeContainer:  this.ShapeContainers[(long)containerId], shapeID:  shapeId, shapeColor:  BlockPuzzleMagic.GameReferenceData.Instance.GetBlockColor(colorType:  2));
            BlockPuzzleMagic.GamePlay val_4 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            BlockPuzzleMagic.ShapeInfo val_6 = this.spawnedShapes[(long)containerId];
            val_4.currentLevel.SetUsableShapeData(containerId:  containerId, shapeId:  this.spawnedShapes[(long)(int)(containerId)][0].shapeId, shapeColor:  this.spawnedShapes[(long)(int)(containerId)][0].colorData.blockColor);
        }
        private BlockPuzzleMagic.ShapeInfo CreateShapeWithID(UnityEngine.Transform shapeContainer, int shapeID, BlockPuzzleMagic.BlockColor shapeColor)
        {
            int val_19;
            var val_20;
            var val_21;
            val_19 = shapeID;
            .shapeID = val_19;
            if(val_19 == 101)
            {
                goto label_2;
            }
            
            if(val_19 == 1)
            {
                goto label_3;
            }
            
            if(val_19 != 100)
            {
                goto label_4;
            }
            
            BlockPuzzleMagic.GameReferenceData val_2 = BlockPuzzleMagic.GameReferenceData.Instance;
            UnityEngine.GameObject val_4 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  val_2.powerupBombShapeInfoPrefab.gameObject);
            val_20 = 1152921520142323776;
            goto label_10;
            label_3:
            val_21 = 0;
            return (BlockPuzzleMagic.ShapeInfo)val_21;
            label_2:
            BlockPuzzleMagic.GameReferenceData val_5 = BlockPuzzleMagic.GameReferenceData.Instance;
            val_20 = 1152921520142341184;
            label_10:
            val_21 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  val_5.powerupFillShapeInfoPrefab.gameObject).GetComponent<BlockPuzzleMagic.PowerupFillShapeInfo>();
            UnityEngine.Transform val_10 = this.gameObject.transform;
            UnityEngine.Vector3 val_11 = shapeContainer.position;
            return (BlockPuzzleMagic.ShapeInfo)val_21;
            label_4:
            val_19 = this.activeShapeBlockModule.ShapeBlocks;
            BlockPuzzleMagic.ShapeBlockSpawn val_13 = val_19.Find(match:  new System.Predicate<BlockPuzzleMagic.ShapeBlockSpawn>(object:  new BlockShapeSpawner.<>c__DisplayClass38_0(), method:  System.Boolean BlockShapeSpawner.<>c__DisplayClass38_0::<CreateShapeWithID>b__0(BlockPuzzleMagic.ShapeBlockSpawn o)));
            val_21 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  val_13.shapeBlock).GetComponent<BlockPuzzleMagic.FillShapeInfo>();
            UnityEngine.Transform val_17 = this.gameObject.transform;
            UnityEngine.Vector3 val_18 = shapeContainer.position;
            return (BlockPuzzleMagic.ShapeInfo)val_21;
        }
        public void CheckIfAvailableShapesArePlaceable()
        {
            var val_16;
            var val_17;
            bool val_18;
            BlockPuzzleMagic.ShapeInfo val_19;
            int val_20;
            System.Collections.Generic.List<BlockPuzzleMagic.GridCell> val_1 = new System.Collections.Generic.List<BlockPuzzleMagic.GridCell>();
            var val_23 = 0;
            val_16 = 0;
            label_39:
            if(val_23 >= (this.spawnedShapes.Length << ))
            {
                goto label_2;
            }
            
            if(this.spawnedShapes[val_23] != 0)
            {
                goto label_6;
            }
            
            val_17 = val_23;
            val_18 = 0;
            goto label_7;
            label_6:
            BlockPuzzleMagic.ShapeInfo val_17 = this.spawnedShapes[val_23];
            if(BlockPuzzleMagic.ShapeInfo.IsRotationAllowed == false)
            {
                goto label_11;
            }
            
            var val_19 = 0;
            label_21:
            val_19 = this.spawnedShapes[val_23];
            if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance.CanPlaceShape(blockShape:  this.spawnedShapes[val_23], fittingBlocks: out  val_1)) == true)
            {
                goto label_20;
            }
            
            val_19.RotateShape(isClockwise:  true, skipAnimate:  true);
            val_19 = val_19 + 1;
            if(val_19 <= 2)
            {
                goto label_21;
            }
            
            goto label_28;
            label_11:
            if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance.CanPlaceShape(blockShape:  this.spawnedShapes[val_23], fittingBlocks: out  val_1)) == false)
            {
                goto label_28;
            }
            
            val_19 = this.spawnedShapes[val_23];
            label_20:
            val_20 = this.spawnedShapes[0x0][0].rotationHeading;
            goto label_32;
            label_28:
            val_20 = 0;
            label_32:
            this.spawnedShapes[val_23].SetRotation(rotationId:  this.spawnedShapes[0x0][0].rotationHeading);
            BlockPuzzleMagic.ShapeInfo val_22 = this.spawnedShapes[val_23];
            var val_8 = (val_20 == this.spawnedShapes[0x0][0].rotationHeading) ? 1 : 0;
            var val_11 = (val_20 >= 0) ? 1 : 0;
            val_11 = BlockPuzzleMagic.ShapeInfo.IsRotationAllowed & val_11;
            val_18 = val_11 & ((val_20 != this.spawnedShapes[0x0][0].rotationHeading) ? 1 : 0);
            val_17 = val_23;
            label_7:
            this.ToggleRotationIcon(iconIndex:  0, isVisible:  val_18);
            val_23 = val_23 + 1;
            if(this.spawnedShapes != null)
            {
                goto label_39;
            }
            
            label_2:
            var val_25 = 0;
            label_47:
            if(val_25 >= (this.spawnedPowerupShapes.Length << ))
            {
                goto label_42;
            }
            
            if(this.spawnedPowerupShapes[val_25] != 0)
            {
                goto label_46;
            }
            
            val_25 = val_25 + 1;
            if(this.spawnedPowerupShapes != null)
            {
                goto label_47;
            }
            
            label_46:
            val_16 = 1;
            label_42:
            BlockPuzzleMagic.GamePlay val_13 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            if(val_13.OnShapesChecked == null)
            {
                    return;
            }
            
            BlockPuzzleMagic.GamePlay val_14 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            val_14.OnShapesChecked.Invoke(obj:  val_16 & 1);
        }
        public UnityEngine.GameObject AnyUnplaceablePieces()
        {
            var val_3 = 4;
            do
            {
                if((val_3 - 4) >= (this.spawnedShapes.Length << ))
            {
                    return 0;
            }
            
                if(this.spawnedShapes[0] != 0)
            {
                    if((this.spawnedShapes[0].<Placeable>k__BackingField) != true)
            {
                    if(this.spawnedShapes[0].PlaceableWithRotation == false)
            {
                goto label_11;
            }
            
            }
            
            }
            
                val_3 = val_3 + 1;
            }
            while(this.spawnedShapes != null);
            
            throw new NullReferenceException();
            label_11:
            var val_4 = val_3 - 4;
            return this.spawnedShapes[0].gameObject;
        }
        public bool IsAllPiecesUnplaceable()
        {
            var val_3;
            var val_4;
            val_3 = 4;
            label_12:
            if((val_3 - 4) >= (this.spawnedShapes.Length << ))
            {
                goto label_2;
            }
            
            if(this.spawnedShapes[0] != 0)
            {
                    if(((this.spawnedShapes[0].<Placeable>k__BackingField) == true) || (this.spawnedShapes[0].PlaceableWithRotation == true))
            {
                goto label_11;
            }
            
            }
            
            val_3 = val_3 + 1;
            if(this.spawnedShapes != null)
            {
                goto label_12;
            }
            
            throw new NullReferenceException();
            label_2:
            val_4 = 1;
            return (bool)val_4;
            label_11:
            val_4 = 0;
            return (bool)val_4;
        }
        private void ToggleRotationIcon(int iconIndex, bool isVisible)
        {
            System.Collections.Generic.Dictionary<BlockPuzzleMagic.GameMode, System.Boolean> val_14;
            BlockPuzzleMagic.GameMode val_15;
            DG.Tweening.Sequence[] val_16;
            if(isVisible == false)
            {
                goto label_1;
            }
            
            BestBlocksPlayer val_1 = BestBlocksPlayer.Instance;
            val_14 = val_1.rotationPrompted;
            BlockPuzzleMagic.GamePlay val_2 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            if(val_2.currentLevel == null)
            {
                goto label_6;
            }
            
            val_15 = val_2.currentLevel.gameMode;
            goto label_7;
            label_1:
            DG.Tweening.Sequence val_14 = this.rotationIconSeq[(long)iconIndex];
            if(val_14 != null)
            {
                    DG.Tweening.Sequence val_3 = DG.Tweening.TweenExtensions.Pause<DG.Tweening.Sequence>(t:  val_14);
            }
            
            UnityEngine.Color val_4 = this.rotateShapeIcon[(long)iconIndex].color;
            this.rotateShapeIcon[(long)iconIndex].color = new UnityEngine.Color() {r = val_4.r, g = val_4.g, b = val_4.b, a = 0f};
            return;
            label_6:
            val_15 = 0;
            label_7:
            EnumerableExtentions.SetOrAdd<BlockPuzzleMagic.GameMode, System.Boolean>(dic:  val_14, key:  val_15, newValue:  true);
            val_16 = this.rotationIconSeq;
            if(val_16[(long)iconIndex] == null)
            {
                    mem2[0] = DG.Tweening.DOTween.Sequence();
                DG.Tweening.Sequence val_6 = DG.Tweening.TweenSettingsExtensions.SetAutoKill<DG.Tweening.Sequence>(t:  this.rotationIconSeq[(long)iconIndex], autoKillOnCompletion:  false);
                DG.Tweening.Sequence val_7 = DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Sequence>(t:  this.rotationIconSeq[(long)iconIndex], loops:  0, loopType:  1);
                DG.Tweening.Sequence val_10 = DG.Tweening.TweenSettingsExtensions.Append(s:  this.rotationIconSeq[(long)iconIndex], t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.rotateShapeIcon[(long)iconIndex], endValue:  1f, duration:  1.25f), ease:  7));
                val_14 = this.rotationIconSeq[(long)iconIndex];
                DG.Tweening.Sequence val_13 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_14, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.rotateShapeIcon[(long)iconIndex], endValue:  0f, duration:  1.25f), ease:  7));
                val_16 = this.rotationIconSeq;
            }
            
            DG.Tweening.TweenExtensions.Restart(t:  val_16[(long)iconIndex], includeDelay:  true, changeDelayTo:  -1f);
        }
        public void OnTrashClicked()
        {
            var val_7 = 4;
            label_11:
            if((val_7 - 4) >= this.spawnedShapes.Length)
            {
                goto label_2;
            }
            
            UnityEngine.Object val_6 = 0;
            val_6 = UnityEngine.Object.op_Inequality(x:  this.spawnedShapes[0], y:  val_6);
            this.ShapeContainers[0].GetComponent<BlockPuzzleMagic.BlockSpawnerNode>().ShowTrashCross(show:  val_6);
            val_7 = val_7 + 1;
            if(this.spawnedShapes != null)
            {
                goto label_11;
            }
            
            label_2:
            this.TrashTooltip.SetActive(value:  true);
        }
        public void OnTrashUnClicked()
        {
            var val_3 = 0;
            label_7:
            if(val_3 >= this.spawnedShapes.Length)
            {
                goto label_2;
            }
            
            this.ShapeContainers[val_3].GetComponent<BlockPuzzleMagic.BlockSpawnerNode>().ShowTrashCross(show:  false);
            val_3 = val_3 + 1;
            if(this.spawnedShapes != null)
            {
                goto label_7;
            }
            
            throw new NullReferenceException();
            label_2:
            this.TrashTooltip.SetActive(value:  false);
        }
        public int GetAvailablePowerupShapeContainerIndex()
        {
            var val_4 = 0;
            label_9:
            if(val_4 >= (this.spawnedShapes.Length << ))
            {
                goto label_2;
            }
            
            if(this.spawnedShapes[val_4] == 0)
            {
                    if((this.tempCachedShapeInfoIndexes.Contains(item:  0)) == false)
            {
                    return (int)val_4;
            }
            
            }
            
            val_4 = val_4 + 1;
            if(this.spawnedShapes != null)
            {
                goto label_9;
            }
            
            label_2:
            if(this.spawnedShapes.Length >= 1)
            {
                    val_4 = 0;
                do
            {
                if((this.tempCachedShapeInfoIndexes.Contains(item:  0)) == false)
            {
                    return (int)val_4;
            }
            
                val_4 = val_4 + 1;
            }
            while(val_4 < this.spawnedShapes.Length);
            
            }
            
            val_4 = 0;
            return (int)val_4;
        }
        public UnityEngine.Vector3 GetShapeContainerPosition(int index)
        {
            if(((index & 2147483648) != 0) || (this.ShapeContainers.Length <= index))
            {
                    return UnityEngine.Vector3.zero;
            }
            
            return this.ShapeContainers[index].position;
        }
        public void SetPowerupShape(int index, BlockPuzzleMagic.ShapeInfo shape, BlockPuzzleMagic.PowerUpType powerupType)
        {
            BlockShapeSpawner.<>c__DisplayClass47_0 val_1 = new BlockShapeSpawner.<>c__DisplayClass47_0();
            .<>4__this = this;
            .index = index;
            .shape = shape;
            if(this.spawnedShapes[index] != 0)
            {
                    DG.Tweening.Tween val_4 = DG.Tweening.DOVirtual.DelayedCall(delay:  0.5f, callback:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void BlockShapeSpawner.<>c__DisplayClass47_0::<SetPowerupShape>b__0()), ignoreTimeScale:  true);
            }
            
            bool val_5 = this.tempCachedShapeInfoIndexes.Add(item:  (BlockShapeSpawner.<>c__DisplayClass47_0)[1152921520147197056].index);
            this.spawnedPowerupShapes[(BlockShapeSpawner.<>c__DisplayClass47_0)[1152921520147197056].index] = (BlockShapeSpawner.<>c__DisplayClass47_0)[1152921520147197056].shape;
            BlockPuzzleMagic.GamePlay val_6 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            bool val_7 = System.String.op_Equality(a:  (BlockShapeSpawner.<>c__DisplayClass47_0)[1152921520147197056].shape.<initSource>k__BackingField, b:  "shpsrc_shp_spwn");
            var val_11 = (((BlockPuzzleMagic.ShapeInfo.__il2cppRuntimeField_typeHierarchy + (BlockPuzzleMagic.GridPlaceableShapeInfo.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? (BlockShapeSpawner.<>c__DisplayClass47_0)[1152921520147197056].shape : 0;
            mem2[0] = val_7.BuyPowerup(powerupType:  powerupType, freeUsage:  val_7);
            var val_12 = (((BlockPuzzleMagic.ShapeInfo.__il2cppRuntimeField_typeHierarchy + (BlockPuzzleMagic.GridPlaceableShapeInfo.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? (BlockShapeSpawner.<>c__DisplayClass47_0)[1152921520147197056].shape : 0;
            mem2[0] = (BlockShapeSpawner.<>c__DisplayClass47_0)[1152921520147197056].index;
            (BlockShapeSpawner.<>c__DisplayClass47_0)[1152921520147197056].shape.transform.parent = this.transform;
            UnityEngine.Vector3 val_15 = this.GetShapeContainerPosition(index:  (BlockShapeSpawner.<>c__DisplayClass47_0)[1152921520147197056].index);
            .newPos = val_15;
            mem[1152921520147197100] = val_15.y;
            mem[1152921520147197104] = val_15.z;
            DG.Tweening.Tweener val_17 = DG.Tweening.ShortcutExtensions.DOScale(target:  (BlockShapeSpawner.<>c__DisplayClass47_0)[1152921520147197056].shape.transform, endValue:  2f, duration:  0.5f);
            DG.Tweening.Tweener val_22 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOMove(target:  (BlockShapeSpawner.<>c__DisplayClass47_0)[1152921520147197056].shape.transform, endValue:  new UnityEngine.Vector3() {x = (BlockShapeSpawner.<>c__DisplayClass47_0)[1152921520147197056].newPos, y = 0.5f, z = val_15.z}, duration:  0.5f, snapping:  false), ease:  7), action:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void BlockShapeSpawner.<>c__DisplayClass47_0::<SetPowerupShape>b__1()));
            (BlockShapeSpawner.<>c__DisplayClass47_0)[1152921520147197056].shape.Alpha = 1f;
            (BlockShapeSpawner.<>c__DisplayClass47_0)[1152921520147197056].shape.neutralAlpha = 1f;
            BlockPuzzleMagic.GamePlay val_23 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            val_23.currentLevel.SetUsablePowerupData(containerId:  (BlockShapeSpawner.<>c__DisplayClass47_0)[1152921520147197056].index, shapeId:  (BlockShapeSpawner.<>c__DisplayClass47_0)[1152921520147197056].shape.shapeId, isFreeUsage:  (((BlockPuzzleMagic.ShapeInfo.__il2cppRuntimeField_typeHierarchy + (BlockPuzzleMagic.GridPlaceableShapeInfo.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) != 0) ? 1 : 0, shapeColor:  (BlockShapeSpawner.<>c__DisplayClass47_0)[1152921520147197056].shape.colorData.blockColor);
            MonoSingleton<BlockPuzzleMagic.GameProgressManager>.Instance.SaveGame();
        }
        public void RemovePowerupShape(int index)
        {
            if(this.spawnedShapes[(long)index] != 0)
            {
                    this.spawnedShapes[(long)index].Alpha = 1f;
                BlockPuzzleMagic.ShapeInfo val_7 = this.spawnedShapes[(long)index];
                this.spawnedShapes[(long)(int)(index)][0].neutralAlpha = 1f;
                this.spawnedShapes[(long)index].Interactable = true;
            }
            
            bool val_2 = this.tempCachedShapeInfoIndexes.Remove(item:  index);
            this.spawnedPowerupShapes[(long)index] = 0;
            BlockPuzzleMagic.GamePlay val_3 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            val_3.currentLevel.SetUsablePowerupData(containerId:  index, shapeId:  0, isFreeUsage:  false, shapeColor:  0);
            this.FillShapeContainer(skipAutosave:  false);
            MonoSingleton<BlockPuzzleMagic.GameProgressManager>.Instance.SaveGame();
        }
        public BlockShapeSpawner()
        {
            this.spawnedShapes = new BlockPuzzleMagic.ShapeInfo[3];
            this.spawnedPowerupShapes = new BlockPuzzleMagic.ShapeInfo[3];
            this.rotationIconSeq = new DG.Tweening.Sequence[3];
            this.shapeBlockPickCounter = new System.Collections.Generic.Dictionary<System.Int32, System.Int32>();
            this.shapeColorPickCounter = new System.Collections.Generic.Dictionary<BlockPuzzleMagic.BlockColorType, System.Int32>();
            this.shapeBlockRandomPool = new System.Collections.Generic.List<System.Int32>();
            this.shapeColorRandomPool = new System.Collections.Generic.List<BlockPuzzleMagic.BlockColorType>();
            this.tempCachedShapeInfoIndexes = new System.Collections.Generic.HashSet<System.Int32>();
            this.powerupAPChanceRandomSet = new RandomSet();
        }
    
    }

}
