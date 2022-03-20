using UnityEngine;

namespace BlockPuzzleMagic
{
    public class GridPlaceableShapeInfo : ShapeInfo
    {
        // Fields
        protected System.Collections.Generic.List<BlockPuzzleMagic.GridCell> highlightedCells;
        protected System.Collections.Generic.List<BlockPuzzleMagic.GridCell> gridBlocksUnderShapeBlocks;
        protected bool isMarkedForDiscard;
        private int <SpawnedShapesInde>k__BackingField;
        private bool <isFreeUsage>k__BackingField;
        
        // Properties
        public bool IsMarkedForDiscard { get; }
        public int SpawnedShapesInde { get; set; }
        public bool isFreeUsage { get; set; }
        
        // Methods
        public bool get_IsMarkedForDiscard()
        {
            return (bool)this.isMarkedForDiscard;
        }
        public int get_SpawnedShapesInde()
        {
            return (int)this.<SpawnedShapesInde>k__BackingField;
        }
        public void set_SpawnedShapesInde(int value)
        {
            this.<SpawnedShapesInde>k__BackingField = value;
        }
        public bool get_isFreeUsage()
        {
            return (bool)this.<isFreeUsage>k__BackingField;
        }
        public void set_isFreeUsage(bool value)
        {
            this.<isFreeUsage>k__BackingField = value;
        }
        public override void InitBlockList()
        {
            this.InitBlockList();
            this.gridBlocksUnderShapeBlocks = new System.Collections.Generic.List<BlockPuzzleMagic.GridCell>(capacity:  38021);
            var val_2 = 0;
            do
            {
                val_2 = val_2 + 1;
                if(val_2 >= (public Spine.Unity.Modules.SkeletonRenderSeparator UnityEngine.GameObject::AddComponent<Spine.Unity.Modules.SkeletonRenderSeparator>()))
            {
                    return;
            }
            
                this.gridBlocksUnderShapeBlocks.Add(item:  0);
            }
            while(as. 
               
               
              
            
            
            
             != 0);
            
            throw new NullReferenceException();
        }
        protected virtual bool CanPlaceAtCurrentWorldPos(out System.Collections.Generic.List<BlockPuzzleMagic.GridCell> fittingBlocks)
        {
            System.Collections.Generic.List<T> val_43;
            GridPlaceableShapeInfo.<>c__DisplayClass14_0 val_44;
            var val_45;
            System.Predicate<BlockPuzzleMagic.ShapeBlock> val_47;
            var val_48;
            System.Predicate<BlockPuzzleMagic.ShapeBlock> val_50;
            var val_51;
            var val_52;
            System.Collections.Generic.List<BlockPuzzleMagic.GridCell> val_53;
            var val_54;
            GridPlaceableShapeInfo.<>c__DisplayClass14_0 val_55;
            val_44 = 1152921520177314336;
            GridPlaceableShapeInfo.<>c__DisplayClass14_0 val_1 = new GridPlaceableShapeInfo.<>c__DisplayClass14_0();
            BlockPuzzleMagic.GamePlay val_2 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            if((val_2.<GridCellsInteractable>k__BackingField) == false)
            {
                goto label_4;
            }
            
            var val_44 = 0;
            label_8:
            if(val_44 >= (X22 + 24))
            {
                goto label_6;
            }
            
            this.gridBlocksUnderShapeBlocks.set_Item(index:  0, value:  0);
            val_44 = val_44 + 1;
            if(X22 != 0)
            {
                goto label_8;
            }
            
            label_6:
            val_45 = null;
            val_45 = null;
            val_47 = GridPlaceableShapeInfo.<>c.<>9__14_0;
            if(val_47 == null)
            {
                    System.Predicate<BlockPuzzleMagic.ShapeBlock> val_3 = null;
                val_47 = val_3;
                val_3 = new System.Predicate<BlockPuzzleMagic.ShapeBlock>(object:  GridPlaceableShapeInfo.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean GridPlaceableShapeInfo.<>c::<CanPlaceAtCurrentWorldPos>b__14_0(BlockPuzzleMagic.ShapeBlock n));
                GridPlaceableShapeInfo.<>c.<>9__14_0 = val_47;
            }
            
            mem[1152921520177318376] = X22.FindAll(match:  val_3);
            val_48 = null;
            val_48 = null;
            val_50 = GridPlaceableShapeInfo.<>c.<>9__14_1;
            if(val_50 == null)
            {
                    System.Predicate<BlockPuzzleMagic.ShapeBlock> val_5 = null;
                val_50 = val_5;
                val_5 = new System.Predicate<BlockPuzzleMagic.ShapeBlock>(object:  GridPlaceableShapeInfo.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean GridPlaceableShapeInfo.<>c::<CanPlaceAtCurrentWorldPos>b__14_1(BlockPuzzleMagic.ShapeBlock n));
                GridPlaceableShapeInfo.<>c.<>9__14_1 = val_50;
            }
            
            val_44 = val_1;
            val_43 = mem[1152921520177318376];
            mem[1152921520177318384] = X22.FindAll(match:  val_5);
            if((val_43 == 0) || ((val_4 + 24) < 1))
            {
                goto label_138;
            }
            
            mem[1152921520177318368] = 0;
            val_51 = "UI";
            val_52 = 0;
            label_54:
            if(val_52 >= (val_4 + 24))
            {
                goto label_24;
            }
            
            if((val_4 + 24) <= val_52)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_45 = val_4 + 16;
            val_45 = val_45 + 0;
            UnityEngine.Vector3 val_7 = (val_4 + 16 + 0) + 32 + 16.position;
            UnityEngine.Vector2 val_8 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z});
            UnityEngine.Vector2 val_9 = UnityEngine.Vector2.zero;
            string[] val_10 = new string[1];
            val_10[0] = "UI";
            int val_12 = UnityEngine.Physics2D.RaycastNonAlloc(origin:  new UnityEngine.Vector2() {x = val_8.x, y = val_8.y}, direction:  new UnityEngine.Vector2() {x = val_9.x, y = val_9.y}, results:  val_5, distance:  1f, layerMask:  UnityEngine.LayerMask.GetMask(layerNames:  val_10));
            if(val_12 < 1)
            {
                goto label_51;
            }
            
            var val_46 = 0;
            var val_47 = 32;
            label_50:
            if((0 + val_47.collider.gameObject) == this.gameObject)
            {
                goto label_42;
            }
            
            BlockPuzzleMagic.GridCell val_20 = collider.gameObject.GetComponentInChildren<BlockPuzzleMagic.GridCell>();
            if(val_20 != 0)
            {
                goto label_49;
            }
            
            label_42:
            val_46 = val_46 + 1;
            val_47 = val_47 + 36;
            if(val_46 < (long)val_12)
            {
                goto label_50;
            }
            
            val_44 = val_1;
            goto label_51;
            label_49:
            val_44 = val_1;
            if((val_4 + 24) <= val_52)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_48 = val_4 + 16;
            val_48 = val_48 + 0;
            mem[1152921520177318368] = (val_4 + 16 + 0) + 32;
            label_51:
            val_43 = mem[1152921520177318376];
            val_52 = val_52 + 1;
            if(val_43 != 0)
            {
                goto label_54;
            }
            
            throw new NullReferenceException();
            label_4:
            val_53 = 0;
            val_54 = 0;
            goto label_55;
            label_24:
            int val_23 = val_5.FindIndex(match:  new System.Predicate<BlockPuzzleMagic.ShapeBlock>(object:  val_1, method:  System.Boolean GridPlaceableShapeInfo.<>c__DisplayClass14_0::<CanPlaceAtCurrentWorldPos>b__2(BlockPuzzleMagic.ShapeBlock n)));
            val_51 = 1152921513393502304;
            if((val_23 & 2147483648) == 0)
            {
                    this.gridBlocksUnderShapeBlocks.set_Item(index:  val_23, value:  val_20);
            }
            
            if(mem[1152921520177318368] != 0)
            {
                    if(val_20 != 0)
            {
                goto label_62;
            }
            
            }
            
            label_138:
            val_53 = 0;
            val_54 = 0;
            label_133:
            val_44 = val_44;
            label_55:
            fittingBlocks = val_53;
            return (bool)val_54;
            label_62:
            System.Collections.Generic.List<BlockPuzzleMagic.GridCell> val_25 = new System.Collections.Generic.List<BlockPuzzleMagic.GridCell>();
            BlockPuzzleMagic.GamePlay val_26 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            .CS$<>8__locals1 = val_44;
            .i = 0;
            label_104:
            var val_49 = val_4 + 24;
            if(0 >= val_49)
            {
                goto label_69;
            }
            
            val_55 = (GridPlaceableShapeInfo.<>c__DisplayClass14_1)[1152921520177396192].CS$<>8__locals1;
            if(val_49 <= ((GridPlaceableShapeInfo.<>c__DisplayClass14_1)[1152921520177396192].i))
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
                val_55 = (GridPlaceableShapeInfo.<>c__DisplayClass14_1)[1152921520177396192].CS$<>8__locals1;
            }
            
            val_49 = val_49 + (((GridPlaceableShapeInfo.<>c__DisplayClass14_1)[1152921520177396192].i) << 3);
            if(((val_4 + 24 + ((GridPlaceableShapeInfo.<>c__DisplayClass14_1)[1152921520177396192].i) << 3) + 32) == ((GridPlaceableShapeInfo.<>c__DisplayClass14_1)[1152921520177396192].CS$<>8__locals1.rootShapeBlock))
            {
                goto label_97;
            }
            
            if(val_55 <= ((GridPlaceableShapeInfo.<>c__DisplayClass14_1)[1152921520177396192].i))
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_55 = val_55 + (((GridPlaceableShapeInfo.<>c__DisplayClass14_1)[1152921520177396192].i) << 3);
            System.Collections.Generic.List<BlockPuzzleMagic.ShapeBlock> val_50 = ((GridPlaceableShapeInfo.<>c__DisplayClass14_1)[1152921520177396192].CS$<>8__locals1 + ((GridPlaceableShapeInfo.<>c__DisplayClass14_1)[1152921520177396192].i) << 3).concealedBlocks;
            val_50 = val_50 + (val_20 + 24);
            val_50 = val_50 - ((GridPlaceableShapeInfo.<>c__DisplayClass14_1)[1152921520177396192].CS$<>8__locals1.rootShapeBlock.rowIDOrientated);
            .derivedRowIdForGridCell = val_50;
            GridPlaceableShapeInfo.<>c__DisplayClass14_0 val_51 = (GridPlaceableShapeInfo.<>c__DisplayClass14_1)[1152921520177396192].CS$<>8__locals1;
            if(val_51 <= ((GridPlaceableShapeInfo.<>c__DisplayClass14_1)[1152921520177396192].i))
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_51 = val_51 + (((GridPlaceableShapeInfo.<>c__DisplayClass14_1)[1152921520177396192].i) << 3);
            System.Collections.Generic.List<BlockPuzzleMagic.ShapeBlock> val_52 = ((GridPlaceableShapeInfo.<>c__DisplayClass14_1)[1152921520177396192].CS$<>8__locals1 + ((GridPlaceableShapeInfo.<>c__DisplayClass14_1)[1152921520177396192].i) << 3).concealedBlocks;
            val_52 = val_52 + (val_20 + 28);
            val_52 = val_52 - ((GridPlaceableShapeInfo.<>c__DisplayClass14_1)[1152921520177396192].CS$<>8__locals1.rootShapeBlock.columnIDOrientated);
            .derivedColIdForGridCell = val_52;
            System.Predicate<BlockPuzzleMagic.GridCell> val_29 = new System.Predicate<BlockPuzzleMagic.GridCell>(object:  new GridPlaceableShapeInfo.<>c__DisplayClass14_2(), method:  System.Boolean GridPlaceableShapeInfo.<>c__DisplayClass14_2::<CanPlaceAtCurrentWorldPos>b__3(BlockPuzzleMagic.GridCell o));
            BlockPuzzleMagic.GridCell val_30 = val_26.cellGrid.Find(match:  val_29);
            this.gridBlocksUnderShapeBlocks.set_Item(index:  val_29.FindIndex(match:  new System.Predicate<BlockPuzzleMagic.ShapeBlock>(object:  new GridPlaceableShapeInfo.<>c__DisplayClass14_1(), method:  System.Boolean GridPlaceableShapeInfo.<>c__DisplayClass14_1::<CanPlaceAtCurrentWorldPos>b__4(BlockPuzzleMagic.ShapeBlock n))), value:  val_30);
            if(this.gridBlocksUnderShapeBlocks == null)
            {
                    if(val_30 == 0)
            {
                goto label_138;
            }
            
            }
            
            if(val_30 == 0)
            {
                goto label_97;
            }
            
            if(((val_30.<isOn>k__BackingField) == false) || ((val_30.isFilled == true) || (val_30.isInteractable == false)))
            {
                goto label_138;
            }
            
            val_25.Add(item:  val_30);
            label_97:
            int val_53 = (GridPlaceableShapeInfo.<>c__DisplayClass14_1)[1152921520177396192].i;
            val_53 = val_53 + 1;
            .i = val_53;
            if(((GridPlaceableShapeInfo.<>c__DisplayClass14_1)[1152921520177396192].CS$<>8__locals1) != null)
            {
                goto label_104;
            }
            
            label_69:
            .CS$<>8__locals2 = val_44;
            .i = 0;
            label_130:
            if(0 >= (val_6 + 24))
            {
                goto label_108;
            }
            
            GridPlaceableShapeInfo.<>c__DisplayClass14_0 val_54 = (GridPlaceableShapeInfo.<>c__DisplayClass14_3)[1152921520177478112].CS$<>8__locals2;
            if(val_54 <= ((GridPlaceableShapeInfo.<>c__DisplayClass14_3)[1152921520177478112].i))
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_54 = val_54 + (((GridPlaceableShapeInfo.<>c__DisplayClass14_3)[1152921520177478112].i) << 3);
            System.Collections.Generic.List<BlockPuzzleMagic.ShapeBlock> val_55 = ((GridPlaceableShapeInfo.<>c__DisplayClass14_3)[1152921520177478112].CS$<>8__locals2 + ((GridPlaceableShapeInfo.<>c__DisplayClass14_3)[1152921520177478112].i) << 3).concealedBlocks;
            val_55 = val_55 + (val_20 + 24);
            val_55 = val_55 - ((GridPlaceableShapeInfo.<>c__DisplayClass14_3)[1152921520177478112].CS$<>8__locals2.rootShapeBlock.rowIDOrientated);
            .derivedRowIdForGridCell = val_55;
            GridPlaceableShapeInfo.<>c__DisplayClass14_0 val_56 = (GridPlaceableShapeInfo.<>c__DisplayClass14_3)[1152921520177478112].CS$<>8__locals2;
            if(val_56 <= ((GridPlaceableShapeInfo.<>c__DisplayClass14_3)[1152921520177478112].i))
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_56 = val_56 + (((GridPlaceableShapeInfo.<>c__DisplayClass14_3)[1152921520177478112].i) << 3);
            System.Collections.Generic.List<BlockPuzzleMagic.ShapeBlock> val_57 = ((GridPlaceableShapeInfo.<>c__DisplayClass14_3)[1152921520177478112].CS$<>8__locals2 + ((GridPlaceableShapeInfo.<>c__DisplayClass14_3)[1152921520177478112].i) << 3).concealedBlocks;
            val_57 = val_57 + (val_20 + 28);
            val_57 = val_57 - ((GridPlaceableShapeInfo.<>c__DisplayClass14_3)[1152921520177478112].CS$<>8__locals2.rootShapeBlock.columnIDOrientated);
            .derivedColIdForGridCell = val_57;
            System.Predicate<BlockPuzzleMagic.GridCell> val_38 = new System.Predicate<BlockPuzzleMagic.GridCell>(object:  new GridPlaceableShapeInfo.<>c__DisplayClass14_4(), method:  System.Boolean GridPlaceableShapeInfo.<>c__DisplayClass14_4::<CanPlaceAtCurrentWorldPos>b__5(BlockPuzzleMagic.GridCell o));
            BlockPuzzleMagic.GridCell val_39 = val_26.cellGrid.Find(match:  val_38);
            if(val_39 != 0)
            {
                    val_25.Add(item:  val_39);
            }
            
            this.gridBlocksUnderShapeBlocks.set_Item(index:  val_38.FindIndex(match:  new System.Predicate<BlockPuzzleMagic.ShapeBlock>(object:  new GridPlaceableShapeInfo.<>c__DisplayClass14_3(), method:  System.Boolean GridPlaceableShapeInfo.<>c__DisplayClass14_3::<CanPlaceAtCurrentWorldPos>b__6(BlockPuzzleMagic.ShapeBlock n))), value:  val_39);
            int val_58 = (GridPlaceableShapeInfo.<>c__DisplayClass14_3)[1152921520177478112].i;
            val_58 = val_58 + 1;
            .i = val_58;
            if(((GridPlaceableShapeInfo.<>c__DisplayClass14_3)[1152921520177478112].CS$<>8__locals2) != null)
            {
                goto label_130;
            }
            
            label_108:
            val_25.Add(item:  val_20);
            goto label_133;
        }
        protected virtual void HighlightCellsMarkedByShape(System.Collections.Generic.List<BlockPuzzleMagic.GridCell> targetBlocks)
        {
            var val_3;
            bool val_4 = true;
            if(val_4 >= 1)
            {
                    var val_5 = 0;
                do
            {
                if(val_5 >= val_4)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_4 = val_4 + 0;
                if((this.highlightedCells.Contains(item:  (true + 0) + 32)) != true)
            {
                    this.highlightedCells.Add(item:  (true + 0) + 32);
            }
            
                val_5 = val_5 + 1;
            }
            while(val_5 < val_4);
            
            }
            
            val_3 = 4;
            do
            {
                var val_2 = val_3 - 4;
                if(val_2 >= val_4)
            {
                    return;
            }
            
                val_4 = val_4 & 4294967295;
                if(val_2 >= val_4)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                if((((true + 0) & 4294967295) + 32) != 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
                UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 32.SetHighlight(_colorData:  0);
            }
            
                val_3 = val_3 + 1;
            }
            while(this.highlightedCells != null);
            
            throw new NullReferenceException();
        }
        protected virtual void StopHighlighting()
        {
            System.Collections.Generic.List<BlockPuzzleMagic.GridCell> val_1;
            bool val_1 = true;
            val_1 = this.highlightedCells;
            if(val_1 == null)
            {
                    return;
            }
            
            var val_2 = 0;
            label_5:
            if(val_2 >= val_1)
            {
                goto label_2;
            }
            
            if(val_1 <= val_2)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_1 = val_1 + 0;
            (true + 0) + 32.StopHighlighting();
            val_1 = this.highlightedCells;
            val_2 = val_2 + 1;
            if(val_1 != null)
            {
                goto label_5;
            }
            
            throw new NullReferenceException();
            label_2:
            val_1.Clear();
        }
        public override void OnDrag(UnityEngine.EventSystems.PointerEventData eventData)
        {
            if(true == 0)
            {
                    return;
            }
            
            BlockPuzzleMagic.GamePlay val_1 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            if((val_1.currentLevel != null) && (val_1.currentLevel.gameMode == 1))
            {
                    this.OnDragZen(eventData:  eventData);
                return;
            }
            
            this.OnDragChallenge(eventData:  eventData);
        }
        protected void OnDragZen(UnityEngine.EventSystems.PointerEventData eventData)
        {
            this.OnDrag(eventData:  eventData);
            if((this & 1) == 0)
            {
                    return;
            }
        
        }
        protected void OnDragChallenge(UnityEngine.EventSystems.PointerEventData eventData)
        {
            int val_55;
            DG.Tweening.Sequence val_56;
            float val_57;
            bool val_58;
            val_56 = this;
            this.isMarkedForDiscard = false;
            bool val_1 = System.String.op_Equality(a:  13394, b:  "shpsrc_shp_spwn");
            if(val_1 == false)
            {
                goto label_19;
            }
            
            BlockPuzzleMagic.BBLGameplayUIController val_2 = MonoSingleton<BlockPuzzleMagic.BBLGameplayUIController>.Instance;
            if((val_2.buttonPowerupTrash.BlockRaycasts == false) || ((MonoSingleton<BlockPuzzleMagic.BBLGameplayUIController>.Instance.IsFtuxTopBannerActive) == true))
            {
                goto label_19;
            }
            
            val_55 = App.Player;
            BlockPuzzleMagic.BestBlocksGameEcon val_7 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
            if((GameEcon.IsEnabledAndLevelMet(playerLevel:  val_55, knobValue:  val_7.powerupTrashTutorialLevel)) == false)
            {
                goto label_19;
            }
            
            BlockPuzzleMagic.BBLGameplayUIController val_9 = MonoSingleton<BlockPuzzleMagic.BBLGameplayUIController>.Instance;
            val_55 = val_9.buttonPowerupTrash.hitboxDragIn;
            UnityEngine.Vector3 val_11 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = eventData.<position>k__BackingField, y = V8.16B});
            UnityEngine.Vector3 val_12 = eventData.pressEventCamera.ScreenToWorldPoint(position:  new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z});
            UnityEngine.Vector3 val_13 = val_55.InverseTransformPoint(position:  new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z});
            val_57 = val_13.x;
            UnityEngine.Rect val_14 = val_55.rect;
            val_58 = val_14.m_XMin.Contains(point:  new UnityEngine.Vector3() {x = val_57, y = val_13.y, z = val_13.z});
            this.isMarkedForDiscard = val_58;
            goto label_29;
            label_19:
            val_58 = this.isMarkedForDiscard;
            label_29:
            var val_16 = (this.isMarkedForDiscard == true) ? 1 : 0;
            val_16 = val_16 ^ ((val_58 == true) ? 1 : 0);
            if(val_58 != false)
            {
                    if(val_16 == 0)
            {
                    return;
            }
            
                BlockPuzzleMagic.BBLGameplayUIController val_18 = MonoSingleton<BlockPuzzleMagic.BBLGameplayUIController>.Instance;
                UnityEngine.Vector3 val_21 = val_18.buttonPowerupTrash.gameObject.transform.position;
                UnityEngine.Transform val_23 = this.gameObject.transform;
                UnityEngine.Vector3 val_24 = val_23.position;
                if(val_23 != null)
            {
                    DG.Tweening.TweenExtensions.Kill(t:  val_23, complete:  false);
            }
            
                DG.Tweening.Sequence val_25 = DG.Tweening.DOTween.Sequence();
                mem[1152921520178355440] = val_25;
                DG.Tweening.Sequence val_29 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_25, t:  DG.Tweening.ShortcutExtensions.DOMove(target:  this.gameObject.transform, endValue:  new UnityEngine.Vector3() {x = val_21.x, y = val_21.y, z = val_24.z}, duration:  0.25f, snapping:  false));
                UnityEngine.Vector3 val_32 = UnityEngine.Vector3.zero;
                DG.Tweening.Sequence val_34 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_25, t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.gameObject.transform, endValue:  new UnityEngine.Vector3() {x = val_32.x, y = val_32.y, z = val_32.z}, duration:  0.25f));
                BlockPuzzleMagic.BBLGameplayUIController val_35 = MonoSingleton<BlockPuzzleMagic.BBLGameplayUIController>.Instance;
                val_56 = DG.Tweening.DOTween.Sequence();
                UnityEngine.Vector3 val_38 = new UnityEngine.Vector3(x:  0f, y:  0f, z:  12f);
                val_57 = 0.1f;
                DG.Tweening.Sequence val_40 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_56, t:  DG.Tweening.ShortcutExtensions.DOLocalRotate(target:  val_25.transform, endValue:  new UnityEngine.Vector3() {x = val_38.x, y = val_38.y, z = val_38.z}, duration:  val_57, mode:  0));
                val_55 = val_25.transform;
                UnityEngine.Vector3 val_42 = new UnityEngine.Vector3(x:  0f, y:  0f, z:  348f);
                DG.Tweening.Sequence val_44 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_56, t:  DG.Tweening.ShortcutExtensions.DOLocalRotate(target:  val_55, endValue:  new UnityEngine.Vector3() {x = val_42.x, y = val_42.y, z = val_42.z}, duration:  0.2f, mode:  0));
                UnityEngine.Vector3 val_46 = new UnityEngine.Vector3(x:  0f, y:  0f, z:  0f);
                DG.Tweening.Sequence val_48 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_56, t:  DG.Tweening.ShortcutExtensions.DOLocalRotate(target:  val_25.transform, endValue:  new UnityEngine.Vector3() {x = val_46.x, y = val_46.y, z = val_46.z}, duration:  val_57, mode:  0));
                return;
            }
            
            if(val_16 != 0)
            {
                    if(val_1 != false)
            {
                    DG.Tweening.TweenExtensions.Complete(t:  val_1);
            }
            
                DG.Tweening.Sequence val_49 = DG.Tweening.DOTween.Sequence();
                val_55 = val_49;
                mem[1152921520178355440] = val_49;
                DG.Tweening.Sequence val_53 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_55, t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.gameObject.transform, endValue:  new UnityEngine.Vector3(), duration:  0.05f));
            }
            
            this.OnDrag(eventData:  eventData);
            if((val_56 & 1) == 0)
            {
                    return;
            }
        
        }
        public override void SnapBackAndReset(System.Action onComplete)
        {
            this.SnapBackAndReset(onComplete:  onComplete);
            if(this.isMarkedForDiscard == false)
            {
                    return;
            }
            
            bool val_2 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance.CanUsePowerup(powerupType:  0, showStoreIfOOC:  true, oocDelay:  0.25f);
        }
        public override bool CanResolveAction()
        {
            if(this.isMarkedForDiscard == false)
            {
                    return (bool)(this.highlightedCells > 0) ? 1 : 0;
            }
            
            return MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance.CanUsePowerup(powerupType:  0, showStoreIfOOC:  true, oocDelay:  0f);
        }
        protected virtual void Discard()
        {
            MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance.UsePowerup(powerupType:  0, freeUsage:  MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance.BuyPowerup(powerupType:  0, freeUsage:  false));
        }
        public override void Consume()
        {
            this.Consume();
        }
        public GridPlaceableShapeInfo()
        {
            this.highlightedCells = new System.Collections.Generic.List<BlockPuzzleMagic.GridCell>();
        }
    
    }

}
