using UnityEngine;

namespace BlockPuzzleMagic
{
    public class GridCell : MonoBehaviour
    {
        // Fields
        public int rowId;
        public int columnId;
        private int <cellId>k__BackingField;
        private bool <isOn>k__BackingField;
        public bool isInteractable;
        private BlockPuzzleMagic.Block <ChildBlock>k__BackingField;
        private BlockPuzzleMagic.BlockData <blockData>k__BackingField;
        private UnityEngine.CanvasGroup cellCanvasGroup;
        private UnityEngine.UI.Image backgroundImage;
        private UnityEngine.Sprite bgSpriteA;
        private UnityEngine.Sprite bgSpriteB;
        private UnityEngine.RectTransform blockContainer;
        private UnityEngine.RectTransform cellOverlayContainer;
        private UnityEngine.UI.Image overlayImage;
        private UnityEngine.UI.Image highlightImage;
        private UnityEngine.BoxCollider2D blockCollider;
        private UnityEngine.ParticleSystem particleEarthquakeCell;
        private UnityEngine.Sprite dotSprite;
        private UnityEngine.Color dotUnfilledColor;
        private UnityEngine.Color dotFilledPlainColor;
        private UnityEngine.Color dotFilledSpecialColor;
        private UnityEngine.Color bgColor;
        private DG.Tweening.Sequence highlightSeq;
        private DG.Tweening.Sequence blockSeq;
        private UnityEngine.Sprite bgSprite;
        private UnityEngine.ParticleSystem particleEarthquakeCellInstance;
        
        // Properties
        public int cellId { get; set; }
        public bool isOn { get; set; }
        public bool isFilled { get; }
        public bool CanBeFilled { get; }
        public BlockPuzzleMagic.Block ChildBlock { get; set; }
        public BlockPuzzleMagic.BlockData blockData { get; set; }
        public UnityEngine.CanvasGroup CellCanvasGroup { get; }
        public UnityEngine.UI.Image BackgroundImage { get; }
        public UnityEngine.UI.Image OverlayImage { get; }
        
        // Methods
        public int get_cellId()
        {
            return (int)this.<cellId>k__BackingField;
        }
        private void set_cellId(int value)
        {
            this.<cellId>k__BackingField = value;
        }
        public bool get_isOn()
        {
            return (bool)this.<isOn>k__BackingField;
        }
        private void set_isOn(bool value)
        {
            this.<isOn>k__BackingField = value;
        }
        public bool get_isFilled()
        {
            return UnityEngine.Object.op_Inequality(x:  this.<ChildBlock>k__BackingField, y:  0);
        }
        public bool get_CanBeFilled()
        {
            var val_3;
            if((this.<isOn>k__BackingField) != false)
            {
                    if(this.isFilled == false)
            {
                    return (bool)(this.isInteractable == true) ? 1 : 0;
            }
            
            }
            
            val_3 = 0;
            return (bool)(this.isInteractable == true) ? 1 : 0;
        }
        public BlockPuzzleMagic.Block get_ChildBlock()
        {
            return (BlockPuzzleMagic.Block)this.<ChildBlock>k__BackingField;
        }
        private void set_ChildBlock(BlockPuzzleMagic.Block value)
        {
            this.<ChildBlock>k__BackingField = value;
        }
        public BlockPuzzleMagic.BlockData get_blockData()
        {
            return (BlockPuzzleMagic.BlockData)this.<blockData>k__BackingField;
        }
        private void set_blockData(BlockPuzzleMagic.BlockData value)
        {
            this.<blockData>k__BackingField = value;
        }
        public UnityEngine.CanvasGroup get_CellCanvasGroup()
        {
            return (UnityEngine.CanvasGroup)this.cellCanvasGroup;
        }
        public UnityEngine.UI.Image get_BackgroundImage()
        {
            return (UnityEngine.UI.Image)this.backgroundImage;
        }
        public UnityEngine.UI.Image get_OverlayImage()
        {
            return (UnityEngine.UI.Image)this.overlayImage;
        }
        public void Initialize(int _cellId, int _rowId, int _colId, bool _isOn, UnityEngine.Color _bgColor, ref BlockPuzzleMagic.BlockData _blockData)
        {
            if(_blockData != null)
            {
                    BlockPuzzleMagic.BlockColorType val_2 = _blockData.fillColorType;
                val_2 = val_2 - 2;
                if(val_2 <= 5)
            {
                    fillColorType = 2;
            }
            
                this.columnId = _colId;
                this.<cellId>k__BackingField = _cellId;
                this.rowId = _rowId;
                this.<isOn>k__BackingField = _isOn;
                this.bgColor = _bgColor;
                mem[1152921520172507572] = _bgColor.g;
                mem[1152921520172507576] = _bgColor.b;
                mem[1152921520172507580] = _bgColor.a;
                this.bgSprite = this.bgSpriteB;
                this.<blockData>k__BackingField = _blockData;
                this.RefreshVisualState();
                return;
            }
            
            throw new NullReferenceException();
        }
        public void RefreshVisualState()
        {
            this.gameObject.SetActive(value:  this.<isOn>k__BackingField);
            this.backgroundImage.color = new UnityEngine.Color() {r = this.bgColor};
            this.backgroundImage.sprite = this.bgSprite;
            if((this.<isOn>k__BackingField) == false)
            {
                    return;
            }
            
            if(this.isFilled == false)
            {
                    return;
            }
            
            this.<ChildBlock>k__BackingField.RefreshVisualState();
        }
        private void OnRectTransformDimensionsChange()
        {
            if(null == null)
            {
                    UnityEngine.Rect val_3 = this.gameObject.transform.rect;
                UnityEngine.Vector2 val_4 = val_3.m_XMin.size;
                this.blockCollider.size = new UnityEngine.Vector2() {x = val_4.x, y = val_4.y};
                return;
            }
        
        }
        public void AddBlockColorFill(BlockPuzzleMagic.BlockColorType blockColor)
        {
            this.<blockData>k__BackingField.fillColorType = blockColor;
            this.LinkCellWithBlock(someblock:  BlockPuzzleMagic.Block.CreateColorFillBlock(_colorType:  blockColor), recenterBlock:  true);
            this.RefreshVisualState();
            this.StopHighlighting();
        }
        public void AddBlockStone(BlockPuzzleMagic.CellImpedimentType impedimentType)
        {
            int val_2;
            if((this.<blockData>k__BackingField.breaksRequired) > 0)
            {
                goto label_7;
            }
            
            if(impedimentType == 3)
            {
                goto label_5;
            }
            
            if(impedimentType == 2)
            {
                goto label_6;
            }
            
            if(impedimentType != 1)
            {
                goto label_7;
            }
            
            val_2 = 1;
            goto label_9;
            label_6:
            val_2 = 2;
            goto label_9;
            label_5:
            val_2 = 3;
            label_9:
            this.<blockData>k__BackingField.breaksRequired = val_2;
            label_7:
            this.<blockData>k__BackingField.fillColorType = 0;
            this.LinkCellWithBlock(someblock:  BlockPuzzleMagic.Block.CreateStoneBlock(), recenterBlock:  true);
            this.RefreshVisualState();
            this.StopHighlighting();
        }
        public void LinkCellWithBlock(BlockPuzzleMagic.Block someblock, bool recenterBlock = False)
        {
            this.<ChildBlock>k__BackingField = someblock;
            someblock.gameObject.gameObject.transform.SetParent(p:  this.blockContainer);
            this.<ChildBlock>k__BackingField.<ParentCell>k__BackingField = this;
            if(recenterBlock == false)
            {
                    return;
            }
            
            UnityEngine.Vector3 val_6 = UnityEngine.Vector3.one;
            this.<ChildBlock>k__BackingField.gameObject.transform.localScale = new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z};
            UnityEngine.Vector3 val_9 = UnityEngine.Vector3.zero;
            this.<ChildBlock>k__BackingField.gameObject.transform.localPosition = new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z};
            if(null == null)
            {
                    UnityEngine.Vector2 val_13 = this.transform.sizeDelta;
                if(null == null)
            {
                    this.<ChildBlock>k__BackingField.gameObject.transform.sizeDelta = new UnityEngine.Vector2() {x = val_13.x, y = val_13.y};
                return;
            }
            
            }
        
        }
        public void ClearCellEarthquake(float animationDelay = 0)
        {
            if(((this.<ChildBlock>k__BackingField) != 0) && ((this.<ChildBlock>k__BackingField.<blockType>k__BackingField) == 4))
            {
                    int val_2 = (this.<blockData>k__BackingField.breaksRequired) - 1;
                this.<blockData>k__BackingField.breaksRequired = val_2;
                this.<blockData>k__BackingField.breaksRequired = UnityEngine.Mathf.Max(a:  val_2, b:  0);
            }
            
            DG.Tweening.Sequence val_4 = DG.Tweening.DOTween.Sequence();
            this.blockSeq = val_4;
            DG.Tweening.Sequence val_5 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_4, interval:  animationDelay);
            DG.Tweening.Sequence val_9 = DG.Tweening.TweenSettingsExtensions.Append(s:  this.blockSeq, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.transform, endValue:  0.3f, duration:  0.15f), ease:  6));
            DG.Tweening.Sequence val_11 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  this.blockSeq, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void BlockPuzzleMagic.GridCell::<ClearCellEarthquake>b__54_0()));
            DG.Tweening.Sequence val_15 = DG.Tweening.TweenSettingsExtensions.Append(s:  this.blockSeq, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.transform, endValue:  1.1f, duration:  0.15f), ease:  7));
            DG.Tweening.Sequence val_19 = DG.Tweening.TweenSettingsExtensions.Append(s:  this.blockSeq, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.transform, endValue:  1f, duration:  0.05f), ease:  7));
            this.StopHighlighting();
        }
        private void PlayEarthquake()
        {
            if(this.particleEarthquakeCellInstance == 0)
            {
                    UnityEngine.ParticleSystem val_3 = UnityEngine.Object.Instantiate<UnityEngine.ParticleSystem>(original:  this.particleEarthquakeCell, parent:  this.transform);
                this.particleEarthquakeCellInstance = val_3;
                UnityEngine.Vector3 val_6 = UnityEngine.Vector3.zero;
                val_3.gameObject.transform.localPosition = new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z};
            }
            
            this.particleEarthquakeCellInstance.Play();
        }
        public void ClearCell(bool doAnimation = True, float animationDelay = 0, bool ignoreBreaksRequired = False)
        {
            float val_32;
            DG.Tweening.Sequence val_33;
            var val_34;
            var val_35;
            DG.Tweening.Sequence val_36;
            DG.Tweening.TweenCallback val_37;
            val_32 = animationDelay;
            val_33 = doAnimation;
            this.RemoveAttributeDot();
            if(this.isFilled != false)
            {
                    var val_2 = ((this.<blockData>k__BackingField.breaksRequired) < 2) ? 1 : 0;
            }
            else
            {
                    val_34 = 1;
            }
            
            val_34 = val_34 | ignoreBreaksRequired;
            if(val_34 == false)
            {
                goto label_4;
            }
            
            .<>4__this = this;
            .blockToDestroy = this.<ChildBlock>k__BackingField;
            this.EmptyCell();
            if(val_33 == false)
            {
                goto label_6;
            }
            
            DG.Tweening.Sequence val_5 = DG.Tweening.DOTween.Sequence();
            this.blockSeq = val_5;
            DG.Tweening.Sequence val_6 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_5, interval:  val_32);
            DG.Tweening.Sequence val_8 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  this.blockSeq, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void BlockPuzzleMagic.GridCell::<ClearCell>b__56_0()));
            val_32 = 0.35f;
            DG.Tweening.Sequence val_11 = DG.Tweening.TweenSettingsExtensions.Append(s:  this.blockSeq, t:  DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.backgroundImage, endValue:  1f, duration:  val_32), delay:  0.3f));
            if(((GridCell.<>c__DisplayClass56_0)[1152921520174127584].blockToDestroy) != 0)
            {
                    DG.Tweening.Sequence val_14 = DG.Tweening.TweenSettingsExtensions.Join(s:  this.blockSeq, t:  (GridCell.<>c__DisplayClass56_0)[1152921520174127584].blockToDestroy.ClearBlock(isLastBlockBreak:  true, animationDelay:  0f));
            }
            
            DG.Tweening.Sequence val_16 = DG.Tweening.TweenSettingsExtensions.Join(s:  this.blockSeq, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.overlayImage, endValue:  0f, duration:  0.3f));
            UnityEngine.Vector3 val_18 = UnityEngine.Vector3.zero;
            DG.Tweening.Sequence val_20 = DG.Tweening.TweenSettingsExtensions.Join(s:  this.blockSeq, t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.overlayImage.transform, endValue:  new UnityEngine.Vector3() {x = val_18.x, y = val_18.y, z = val_18.z}, duration:  val_32));
            val_33 = this.blockSeq;
            val_35 = 1152921513401904048;
            val_36 = val_33;
            val_37 = new DG.Tweening.TweenCallback(object:  new GridCell.<>c__DisplayClass56_0(), method:  System.Void GridCell.<>c__DisplayClass56_0::<ClearCell>b__1());
            goto label_16;
            label_4:
            int val_22 = (this.<blockData>k__BackingField.breaksRequired) - 1;
            this.<blockData>k__BackingField.breaksRequired = val_22;
            this.<blockData>k__BackingField.breaksRequired = UnityEngine.Mathf.Max(a:  val_22, b:  0);
            if((val_33 == false) || (this.isFilled == false))
            {
                goto label_21;
            }
            
            DG.Tweening.Sequence val_25 = DG.Tweening.DOTween.Sequence();
            this.blockSeq = val_25;
            DG.Tweening.Sequence val_26 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_25, interval:  val_32);
            DG.Tweening.Sequence val_28 = DG.Tweening.TweenSettingsExtensions.Append(s:  this.blockSeq, t:  this.<ChildBlock>k__BackingField.ClearBlock(isLastBlockBreak:  false, animationDelay:  0f));
            DG.Tweening.TweenCallback val_29 = null;
            val_33 = val_29;
            val_29 = new DG.Tweening.TweenCallback(object:  this, method:  public System.Void BlockPuzzleMagic.GridCell::RefreshVisualState());
            val_35 = 1152921513401904048;
            val_36 = this.blockSeq;
            val_37 = val_33;
            label_16:
            DG.Tweening.Sequence val_30 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_36, action:  val_29);
            goto label_25;
            label_6:
            UnityEngine.Object.Destroy(obj:  (GridCell.<>c__DisplayClass56_0)[1152921520174127584].blockToDestroy.gameObject);
            label_21:
            this.RefreshVisualState();
            label_25:
            this.StopHighlighting();
        }
        public void EmptyCell()
        {
            var val_3;
            var val_4;
            BlockPuzzleMagic.GamePlay val_1 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            val_3 = 0;
            goto label_4;
            label_14:
            val_1.currentLevel.gridLayout.RemoveFlagFromGridDataNode(_gridDataIndex:  this.<cellId>k__BackingField, _nodeType:  BlockPuzzleMagic.Block.BLOCK_TYPES + 32);
            val_3 = 1;
            label_4:
            val_4 = null;
            val_4 = null;
            if(val_3 < BlockPuzzleMagic.Block.BLOCK_TYPES.Length)
            {
                goto label_14;
            }
            
            this.RemoveAttributeDot();
            this.<blockData>k__BackingField.fillColorType = 0;
            this.<blockData>k__BackingField.breaksRequired = 0;
            if((this.<ChildBlock>k__BackingField) == 0)
            {
                    return;
            }
            
            this.<ChildBlock>k__BackingField.<ParentCell>k__BackingField = 0;
            this.<ChildBlock>k__BackingField = 0;
        }
        private void RemoveAttributeDot()
        {
            BlockPuzzleMagic.GamePlay val_1 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            val_1.currentLevel.gridLayout.RemoveFlagFromGridDataNode(_gridDataIndex:  this.<cellId>k__BackingField, _nodeType:  2);
        }
        public void SetHighlight(BlockPuzzleMagic.BlockColor _colorData)
        {
            if(this.highlightSeq != null)
            {
                    DG.Tweening.TweenExtensions.Kill(t:  this.highlightSeq, complete:  false);
            }
            
            UnityEngine.Color val_1 = new UnityEngine.Color(r:  _colorData.colorValue, g:  null, b:  null, a:  0.6f);
            this.highlightImage.color = new UnityEngine.Color() {r = val_1.r, g = val_1.g, b = val_1.b, a = val_1.a};
        }
        public void StopHighlighting()
        {
            if(this.highlightSeq != null)
            {
                    DG.Tweening.TweenExtensions.Kill(t:  this.highlightSeq, complete:  false);
            }
            
            DG.Tweening.Sequence val_1 = DG.Tweening.DOTween.Sequence();
            this.highlightSeq = val_1;
            DG.Tweening.Sequence val_4 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_1, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.highlightImage, endValue:  0f, duration:  0.2f), ease:  1));
        }
        public void PlayInitialAnimation(float animationDelay = 0)
        {
            DG.Tweening.Sequence val_1 = DG.Tweening.DOTween.Sequence();
            this.blockSeq = val_1;
            DG.Tweening.Sequence val_2 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_1, interval:  animationDelay);
            UnityEngine.Color val_3 = new UnityEngine.Color(r:  1f, g:  1f, b:  1f, a:  0.65f);
            DG.Tweening.Sequence val_5 = DG.Tweening.TweenSettingsExtensions.Append(s:  this.blockSeq, t:  DG.Tweening.ShortcutExtensions46.DOColor(target:  this.highlightImage, endValue:  new UnityEngine.Color() {r = val_3.r, g = val_3.g, b = val_3.b, a = val_3.a}, duration:  0.15f));
            UnityEngine.Color val_6 = new UnityEngine.Color(r:  1f, g:  1f, b:  1f, a:  0f);
            DG.Tweening.Sequence val_8 = DG.Tweening.TweenSettingsExtensions.Append(s:  this.blockSeq, t:  DG.Tweening.ShortcutExtensions46.DOColor(target:  this.highlightImage, endValue:  new UnityEngine.Color() {r = val_6.r, g = val_6.g, b = val_6.b, a = val_6.a}, duration:  0.15f));
            DG.Tweening.Sequence val_10 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  this.blockSeq, action:  new DG.Tweening.TweenCallback(object:  this, method:  public System.Void BlockPuzzleMagic.GridCell::RefreshVisualState()));
        }
        public void PlayLevelClearAnimation(float animationDelay = 0)
        {
            DG.Tweening.Sequence val_1 = DG.Tweening.DOTween.Sequence();
            this.blockSeq = val_1;
            DG.Tweening.Sequence val_2 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_1, interval:  animationDelay);
            DG.Tweening.Sequence val_4 = DG.Tweening.TweenSettingsExtensions.Append(s:  this.blockSeq, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.backgroundImage, endValue:  0f, duration:  0.3f));
            if(this.isFilled != false)
            {
                    DG.Tweening.Sequence val_7 = DG.Tweening.TweenSettingsExtensions.Join(s:  this.blockSeq, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.<ChildBlock>k__BackingField.blockCanvasGroup, endValue:  0f, duration:  0.3f));
                UnityEngine.Vector3 val_9 = UnityEngine.Vector3.zero;
                DG.Tweening.Sequence val_11 = DG.Tweening.TweenSettingsExtensions.Join(s:  this.blockSeq, t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.<ChildBlock>k__BackingField.transform, endValue:  new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z}, duration:  0.35f));
            }
            
            DG.Tweening.Sequence val_13 = DG.Tweening.TweenSettingsExtensions.Join(s:  this.blockSeq, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.overlayImage, endValue:  0f, duration:  0.3f));
            UnityEngine.Vector3 val_15 = UnityEngine.Vector3.zero;
            DG.Tweening.Sequence val_17 = DG.Tweening.TweenSettingsExtensions.Join(s:  this.blockSeq, t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.overlayImage.transform, endValue:  new UnityEngine.Vector3() {x = val_15.x, y = val_15.y, z = val_15.z}, duration:  0.35f));
            DG.Tweening.Sequence val_18 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  this.blockSeq, interval:  0.3f);
            DG.Tweening.Sequence val_20 = DG.Tweening.TweenSettingsExtensions.Append(s:  this.blockSeq, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.backgroundImage, endValue:  1f, duration:  0.3f));
            DG.Tweening.Sequence val_22 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  this.blockSeq, action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void BlockPuzzleMagic.GridCell::<PlayLevelClearAnimation>b__62_0()));
        }
        public GridCell()
        {
            this.isInteractable = true;
        }
        private void <ClearCellEarthquake>b__54_0()
        {
            if((((this.<ChildBlock>k__BackingField) != 0) && ((this.<ChildBlock>k__BackingField.<blockType>k__BackingField) == 4)) && ((this.<blockData>k__BackingField.breaksRequired) <= 0))
            {
                    UnityEngine.Object.Destroy(obj:  this.<ChildBlock>k__BackingField.gameObject);
            }
            
            this.RefreshVisualState();
            this.PlayEarthquake();
        }
        private void <ClearCell>b__56_0()
        {
            UnityEngine.Color val_1 = this.backgroundImage.color;
            this.backgroundImage.color = new UnityEngine.Color() {r = val_1.r, g = val_1.g, b = val_1.b, a = 0f};
        }
        private void <PlayLevelClearAnimation>b__62_0()
        {
            this.EmptyCell();
            this.RefreshVisualState();
        }
    
    }

}
