using UnityEngine;

namespace BlockPuzzleMagic
{
    public class GameBoardGenerator : MonoSingleton<BlockPuzzleMagic.GameBoardGenerator>
    {
        // Fields
        private int TotalRows;
        private int TotalColumns;
        private int UsableRowsMax;
        private int UsableColumnsMax;
        private float gridSpacing;
        private UnityEngine.RectOffset gridPadding;
        public UnityEngine.GameObject BoardContent;
        private UnityEngine.UI.Image gridBackgroundImage;
        private UnityEngine.RectOffset gridBgPadding;
        private UnityEngine.GameObject blocksContainer;
        private UnityEngine.Color blockColorA;
        private UnityEngine.Color blockColorB;
        private float blockWidth;
        private float blockHeight;
        private float startPosx;
        private float startPosy;
        private int cellIndex;
        
        // Properties
        public UnityEngine.UI.Image GridBackgroundImage { get; }
        public float BlockWidth { get; }
        public float BlockHeight { get; }
        
        // Methods
        public UnityEngine.UI.Image get_GridBackgroundImage()
        {
            return (UnityEngine.UI.Image)this.gridBackgroundImage;
        }
        public float get_BlockWidth()
        {
            return (float)this.blockWidth;
        }
        public float get_BlockHeight()
        {
            return (float)this.blockHeight;
        }
        private void OnRectTransformDimensionsChange()
        {
            this.RecalculateGridLayout();
        }
        public void GenerateBoard(BlockPuzzleMagic.Level _level)
        {
            BlockPuzzleMagic.GridCell val_29;
            System.Collections.Generic.List<BlockPuzzleMagic.GridCell> val_32;
            var val_33;
            System.Collections.Generic.List<BlockPuzzleMagic.Goal> val_34;
            var val_35;
            System.Predicate<BlockPuzzleMagic.Goal> val_37;
            BlockPuzzleMagic.CellImpedimentType val_38;
            if(_level == null)
            {
                    throw new NullReferenceException();
            }
            
            if(this.blocksContainer == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Transform val_1 = this.blocksContainer.transform;
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_1.childCount < 1)
            {
                goto label_4;
            }
            
            if(this.blocksContainer == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Transform val_3 = this.blocksContainer.transform;
            if(val_3 == null)
            {
                    throw new NullReferenceException();
            }
            
            System.Collections.IEnumerator val_4 = val_3.GetEnumerator();
            val_29 = 1152921504767389696;
            label_22:
            var val_30 = 0;
            val_30 = val_30 + 1;
            if(val_4.MoveNext() == false)
            {
                goto label_12;
            }
            
            var val_31 = 0;
            val_31 = val_31 + 1;
            object val_8 = val_4.Current;
            if(val_8 == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Object.Destroy(obj:  val_8.gameObject);
            goto label_22;
            label_12:
            val_32 = 0;
            if(X0 == false)
            {
                goto label_23;
            }
            
            var val_34 = X0;
            if((X0 + 294) == 0)
            {
                goto label_27;
            }
            
            var val_32 = X0 + 176;
            var val_33 = 0;
            val_32 = val_32 + 8;
            label_26:
            if(((X0 + 176 + 8) + -8) == null)
            {
                goto label_25;
            }
            
            val_33 = val_33 + 1;
            val_32 = val_32 + 16;
            if(val_33 < (X0 + 294))
            {
                goto label_26;
            }
            
            goto label_27;
            label_25:
            val_34 = val_34 + (((X0 + 176 + 8)) << 4);
            val_33 = val_34 + 304;
            label_27:
            X0.Dispose();
            label_23:
            if(val_32 != 0)
            {
                    throw X23;
            }
            
            label_4:
            this.cellIndex = 0;
            if(_level.gridLayout == null)
            {
                    throw new NullReferenceException();
            }
            
            this.TotalRows = _level.gridLayout.rowCount;
            this.TotalColumns = public System.Void System.IDisposable::Dispose();
            val_34 = _level.goals;
            if(val_34 == null)
            {
                goto label_36;
            }
            
            val_35 = null;
            val_35 = null;
            val_37 = GameBoardGenerator.<>c.<>9__24_0;
            if(val_37 == null)
            {
                    System.Predicate<BlockPuzzleMagic.Goal> val_11 = null;
                val_37 = val_11;
                val_11 = new System.Predicate<BlockPuzzleMagic.Goal>(object:  GameBoardGenerator.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean GameBoardGenerator.<>c::<GenerateBoard>b__24_0(BlockPuzzleMagic.Goal n));
                GameBoardGenerator.<>c.<>9__24_0 = val_37;
            }
            
            if((val_34.Find(match:  val_11)) == null)
            {
                goto label_36;
            }
            
            val_38 = val_12.impedimentType;
            goto label_37;
            label_36:
            val_38 = 1;
            label_37:
            System.Collections.Generic.List<BlockPuzzleMagic.GridCell> val_14 = null;
            val_32 = val_14;
            val_14 = new System.Collections.Generic.List<BlockPuzzleMagic.GridCell>();
            if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance) == null)
            {
                    throw new NullReferenceException();
            }
            
            val_13.cellGrid = val_32;
            if(_level.gridLayout.rowCount >= 1)
            {
                    var val_38 = 0;
                val_34 = 1152921520154884192;
                do
            {
                if(1152921520154884188 >= 1)
            {
                    val_32 = 0;
                var val_36 = 0;
                do
            {
                if(_level.gridLayout.gridBlockData == null)
            {
                    throw new NullReferenceException();
            }
            
                BlockPuzzleMagic.BlockData val_35 = _level.gridLayout.gridBlockData[this.cellIndex];
                bool val_20 = _level.gridLayout.IsFlagSetOnGridDataNode(_gridDataIndex:  this.cellIndex, _nodeType:  0);
                BlockPuzzleMagic.GridCell val_21 = this.GenerateNewGridCell(rowIndex:  0, columnIndex:  0);
                if(val_21 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_29 = val_21;
                val_21.Initialize(_cellId:  this.cellIndex, _rowId:  0, _colId:  0, _isOn:  (~val_20) & 1, _bgColor:  new UnityEngine.Color() {r = ((this.cellIndex & 1) != 0) ? this.blockColorA : this.blockColorB, g = ((this.cellIndex & 1) != 0) ? 1152921520154884172 : 1152921520154884188, b = ((this.cellIndex & 1) != 0) ? 1152921520154884176 : (val_34), a = ((this.cellIndex & 1) != 0) ? 1152921520154884180 : 1152921520154884196}, _blockData: ref  val_35);
                if(val_20 != true)
            {
                    val_32 = val_32 + 1;
                if((_level.gridLayout.IsFlagSetOnGridDataNode(_gridDataIndex:  this.cellIndex, _nodeType:  4)) != false)
            {
                    val_29.AddBlockStone(impedimentType:  val_38);
            }
            else
            {
                    if((val_35 != null) && (_level.gridLayout.gridBlockData[this.cellIndex][0].fillColorType != 0))
            {
                    val_29.AddBlockColorFill(blockColor:  _level.gridLayout.gridBlockData[this.cellIndex][0].fillColorType);
            }
            
            }
            
            }
            
                if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance) == null)
            {
                    throw new NullReferenceException();
            }
            
                if(val_25.cellGrid == null)
            {
                    throw new NullReferenceException();
            }
            
                val_25.cellGrid.Add(item:  val_29);
                val_36 = val_36 + 1;
                this.cellIndex = this.cellIndex + 1;
            }
            while(val_36 < this.cellIndex);
            
            }
            else
            {
                    val_32 = 0;
            }
            
                this.UsableColumnsMax = UnityEngine.Mathf.Max(a:  this.UsableColumnsMax, b:  0);
                if(val_32 >= 1)
            {
                    int val_37 = this.UsableRowsMax;
                val_37 = val_37 + 1;
                this.UsableRowsMax = val_37;
            }
            
                val_38 = val_38 + 1;
            }
            while(val_38 < _level.gridLayout.rowCount);
            
            }
            
            this.RecalculateGridLayout();
            if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance) == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_29.cellGrid == null)
            {
                    throw new NullReferenceException();
            }
            
            if(1152921513393502304 < 1)
            {
                    return;
            }
            
            var val_39 = 0;
            do
            {
                if(1152921513393502304 <= val_39)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                RefreshVisualState();
                val_39 = val_39 + 1;
            }
            while(val_39 < 44314208);
        
        }
        private void RecalculateGridLayout()
        {
            var val_48;
            int val_49;
            int val_50;
            var val_51;
            var val_52;
            var val_53;
            float val_54;
            float val_55;
            var val_56;
            val_48 = 1152921504893161472;
            if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance) == 0)
            {
                    return;
            }
            
            BlockPuzzleMagic.GamePlay val_3 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            if(val_3.cellGrid == null)
            {
                    return;
            }
            
            if(null != null)
            {
                goto label_12;
            }
            
            UnityEngine.Rect val_5 = this.blocksContainer.transform.rect;
            BlockPuzzleMagic.GamePlay val_6 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            float val_51 = val_5.m_XMin.width;
            float val_54 = val_5.m_XMin.height;
            float val_50 = (float)this.gridPadding.left;
            val_50 = val_51 - val_50;
            val_50 = val_50 - (float)this.gridPadding.right;
            val_50 = val_50 - (this.gridSpacing * ((float)this.TotalColumns - 1));
            val_51 = val_50 / (float)this.TotalColumns;
            float val_53 = this.gridSpacing;
            float val_52 = (float)this.gridPadding.top;
            val_52 = val_54 - val_52;
            val_52 = val_52 - (float)this.gridPadding.bottom;
            val_53 = val_53 * ((float)this.TotalRows - 1);
            val_53 = val_52 - val_53;
            val_54 = val_53 / (float)this.TotalRows;
            float val_16 = UnityEngine.Mathf.Min(a:  val_51, b:  val_54);
            this.blockWidth = val_16;
            this.blockHeight = val_16;
            val_49 = this.TotalRows;
            val_50 = this.TotalColumns;
            var val_55 = 0;
            val_51 = 0;
            val_52 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_53 = mem[(UnityEngine.Mathf.__il2cppRuntimeField_cctor_finished + 0) + 32];
            val_53 = (UnityEngine.Mathf.__il2cppRuntimeField_cctor_finished + 0) + 32;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_53 = val_53 + 0;
            val_53 = mem[((UnityEngine.Mathf.__il2cppRuntimeField_cctor_finished + 0) + 32 + 0) + 32];
            val_53 = ((UnityEngine.Mathf.__il2cppRuntimeField_cctor_finished + 0) + 32 + 0) + 32;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_53 = val_53 + 0;
            val_53 = mem[(((UnityEngine.Mathf.__il2cppRuntimeField_cctor_finished + 0) + 32 + 0) + 32 + 0) + 32];
            val_53 = (((UnityEngine.Mathf.__il2cppRuntimeField_cctor_finished + 0) + 32 + 0) + 32 + 0) + 32;
            val_50 = UnityEngine.Mathf.Min(a:  ((UnityEngine.Mathf.__il2cppRuntimeField_cctor_finished + 0) + 32 + 0) + 32 + 28, b:  val_50);
            val_52 = UnityEngine.Mathf.Max(a:  ((UnityEngine.Mathf.__il2cppRuntimeField_cctor_finished + 0) + 32 + 0) + 32 + 28, b:  0);
            val_49 = UnityEngine.Mathf.Min(a:  (UnityEngine.Mathf.__il2cppRuntimeField_cctor_finished + 0) + 32 + 24, b:  val_49);
            val_51 = UnityEngine.Mathf.Max(a:  (UnityEngine.Mathf.__il2cppRuntimeField_cctor_finished + 0) + 32 + 24, b:  0);
            val_55 = val_55 + 1;
            float val_66 = 0.5f;
            float val_56 = (float) - val_49;
            float val_58 = (float)val_49;
            float val_57 = (float) - val_50;
            val_56 = val_56 * val_66;
            int val_23 = this.TotalColumns - 1;
            val_54 = this.gridSpacing;
            float val_59 = (float)val_50;
            val_55 = this.blockWidth;
            float val_64 = this.blockHeight;
            val_57 = val_57 * val_66;
            val_58 = val_56 + val_58;
            float val_61 = (float)val_23;
            val_59 = val_57 + val_59;
            float val_63 = (float)this.TotalRows - 1;
            val_59 = val_59 - (val_61 * val_66);
            val_58 = val_58 - (val_63 * val_66);
            float val_60 = (float)this.TotalColumns;
            val_60 = val_55 * val_60;
            val_61 = val_54 * val_61;
            val_61 = val_60 + val_61;
            float val_62 = (float)this.TotalRows;
            val_62 = val_64 * val_62;
            val_63 = val_54 * val_63;
            val_63 = val_63 + val_62;
            float val_65 = -0.5f;
            val_59 = val_59 * (val_55 + val_54);
            val_58 = val_58 * (val_54 + val_64);
            val_64 = val_64 * val_66;
            val_65 = val_61 * val_65;
            val_66 = val_63 * val_66;
            val_65 = (val_55 * val_66) + val_65;
            val_66 = val_66 - val_64;
            float val_30 = val_65 - val_59;
            float val_31 = val_58 + val_66;
            this.startPosx = val_30;
            this.startPosy = val_31;
            if(val_23 < 1)
            {
                goto label_35;
            }
            
            var val_70 = 4;
            label_53:
            if(val_23 <= 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            UnityEngine.Transform val_32 = (this.TotalColumns - 1) + 32.transform;
            val_56 = val_32;
            if(val_32 != null)
            {
                    if(null != null)
            {
                goto label_50;
            }
            
            }
            
            UnityEngine.Vector3 val_33 = new UnityEngine.Vector3(x:  val_30, y:  val_31, z:  0f);
            val_56.anchoredPosition3D = new UnityEngine.Vector3() {x = val_33.x, y = val_33.y, z = val_33.z};
            UnityEngine.Vector2 val_34 = new UnityEngine.Vector2(x:  this.blockWidth, y:  this.blockHeight);
            val_56.sizeDelta = new UnityEngine.Vector2() {x = val_34.x, y = val_34.y};
            if(null <= 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            if((UnityEngine.Transform.__il2cppRuntimeField_byval_arg + 40) == 0)
            {
                goto label_45;
            }
            
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_56 = UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 32 + 40.transform;
            UnityEngine.Vector2 val_37 = new UnityEngine.Vector2(x:  this.blockWidth, y:  this.blockHeight);
            if(null != null)
            {
                goto label_50;
            }
            
            val_56.sizeDelta = new UnityEngine.Vector2() {x = val_37.x, y = val_37.y};
            label_45:
            int val_67 = this.TotalColumns;
            var val_38 = val_70 - 3;
            val_67 = val_38 - ((val_38 / val_67) * val_67);
            if(val_67 != 0)
            {
                    float val_68 = this.blockWidth;
                val_54 = this.gridSpacing;
                val_68 = val_68 + val_54;
                val_30 = val_30 + val_68;
            }
            else
            {
                    val_54 = this.gridSpacing;
                float val_69 = this.blockHeight;
                val_69 = val_69 + val_54;
                val_31 = val_31 - val_69;
            }
            
            val_70 = val_70 + 1;
            if((val_70 - 4) < val_67)
            {
                goto label_53;
            }
            
            val_55 = this.blockWidth;
            label_35:
            val_48 = this.gridBgPadding.left;
            if(this.gridBackgroundImage == 0)
            {
                    return;
            }
            
            float val_71 = (float)this.UsableColumnsMax;
            float val_72 = (float)this.UsableColumnsMax - 1;
            val_71 = val_55 * val_71;
            val_72 = val_54 * val_72;
            val_71 = val_71 + val_72;
            val_71 = val_71 + (float)val_48;
            val_71 = val_71 + (float)this.gridBgPadding.right;
            this.gridBackgroundImage.rectTransform.SetSizeWithCurrentAnchors(axis:  0, size:  val_71);
            float val_73 = (float)this.UsableRowsMax;
            float val_74 = (float)this.UsableRowsMax - 1;
            val_73 = this.blockHeight * val_73;
            val_74 = this.gridSpacing * val_74;
            val_73 = val_73 + val_74;
            val_73 = val_73 + (float)this.gridBgPadding.top;
            val_73 = val_73 + (float)this.gridBgPadding.bottom;
            this.gridBackgroundImage.rectTransform.SetSizeWithCurrentAnchors(axis:  1, size:  val_73);
            return;
            label_50:
            label_12:
        }
        private BlockPuzzleMagic.GridCell GenerateNewGridCell(int rowIndex, int columnIndex)
        {
            BlockPuzzleMagic.GameReferenceData val_1 = BlockPuzzleMagic.GameReferenceData.Instance;
            UnityEngine.GameObject val_2 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  val_1.emptyGridCellTemplate);
            val_2.transform.SetParent(p:  this.blocksContainer.transform);
            UnityEngine.Vector3 val_6 = UnityEngine.Vector3.one;
            val_2.transform.localScale = new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z};
            val_2.transform.SetAsLastSibling();
            val_2.name = "Cell-"("Cell-") + rowIndex.ToString() + "-"("-") + columnIndex.ToString();
            return (BlockPuzzleMagic.GridCell)val_2.GetComponent<BlockPuzzleMagic.GridCell>();
        }
        public GameBoardGenerator()
        {
            this.gridSpacing = 5f;
            UnityEngine.Color val_1 = UnityEngine.Color.white;
            this.blockColorA = val_1;
            mem[1152921520155627852] = val_1.g;
            mem[1152921520155627856] = val_1.b;
            mem[1152921520155627860] = val_1.a;
            UnityEngine.Color val_2 = UnityEngine.Color.white;
            this.blockColorB = val_2;
            mem[1152921520155627868] = val_2.g;
            mem[1152921520155627872] = val_2.b;
            mem[1152921520155627876] = val_2.a;
        }
    
    }

}
