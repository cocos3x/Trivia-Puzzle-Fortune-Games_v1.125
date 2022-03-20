using UnityEngine;

namespace BlockPuzzleMagic
{
    public class Block : MonoBehaviour
    {
        // Fields
        public const int METAL_BLOCK_BREAK_LIMIT = 3;
        public const int STONE_BLOCK_BREAK_LIMIT = 2;
        public const int CRATE_BLOCK_BREAK_LIMIT = 1;
        public static readonly BlockPuzzleMagic.GridLayout.NodeType[] BLOCK_TYPES;
        private BlockPuzzleMagic.GridLayout.NodeType <blockType>k__BackingField;
        private BlockPuzzleMagic.GridCell <ParentCell>k__BackingField;
        private UnityEngine.CanvasGroup blockCanvasGroup;
        public UnityEngine.UI.Image blockImage;
        private UnityEngine.ParticleSystem particleStoneChipped;
        private UnityEngine.Sprite normalBlockSprite;
        private UnityEngine.RectOffset normalSpriteRectOffset;
        private UnityEngine.Sprite stoneBlockSprite;
        private UnityEngine.RectOffset stoneSpriteRectOffset;
        private System.Collections.Generic.List<UnityEngine.Sprite> crackedStoneBlockSprite;
        private UnityEngine.Sprite crateBlockSprite;
        private UnityEngine.RectOffset crateSpriteRectOffset;
        private UnityEngine.Sprite metalBlockSprite;
        private UnityEngine.RectOffset metalSpriteRectOffset;
        private UnityEngine.Sprite rainbowBlockSprite;
        private UnityEngine.RectOffset rainbowSpriteRectOffset;
        private DG.Tweening.Sequence blockSeq;
        private UnityEngine.Sprite activeCrackedStoneSprite;
        private UnityEngine.ParticleSystem particleStoneChippedInstance;
        
        // Properties
        public BlockPuzzleMagic.GridLayout.NodeType blockType { get; set; }
        public BlockPuzzleMagic.BlockColorType fillColorType { get; }
        public int breaksRequired { get; }
        public bool hasStone { get; }
        public BlockPuzzleMagic.GridCell ParentCell { get; set; }
        public UnityEngine.CanvasGroup BlockCanvasGroup { get; }
        
        // Methods
        public BlockPuzzleMagic.GridLayout.NodeType get_blockType()
        {
            return (NodeType)this.<blockType>k__BackingField;
        }
        private void set_blockType(BlockPuzzleMagic.GridLayout.NodeType value)
        {
            this.<blockType>k__BackingField = value;
        }
        public BlockPuzzleMagic.BlockColorType get_fillColorType()
        {
            return (BlockPuzzleMagic.BlockColorType)this.<ParentCell>k__BackingField.<blockData>k__BackingField.fillColorType;
        }
        public int get_breaksRequired()
        {
            return (int)this.<ParentCell>k__BackingField.<blockData>k__BackingField.breaksRequired;
        }
        public bool get_hasStone()
        {
            return (bool)((this.<blockType>k__BackingField) == 4) ? 1 : 0;
        }
        public BlockPuzzleMagic.GridCell get_ParentCell()
        {
            return (BlockPuzzleMagic.GridCell)this.<ParentCell>k__BackingField;
        }
        public void set_ParentCell(BlockPuzzleMagic.GridCell value)
        {
            this.<ParentCell>k__BackingField = value;
        }
        public UnityEngine.CanvasGroup get_BlockCanvasGroup()
        {
            return (UnityEngine.CanvasGroup)this.blockCanvasGroup;
        }
        private static BlockPuzzleMagic.Block CreateBlock(BlockPuzzleMagic.GridLayout.NodeType blockType)
        {
            BlockPuzzleMagic.GameReferenceData val_1 = BlockPuzzleMagic.GameReferenceData.Instance;
            UnityEngine.GameObject val_2 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  val_1.emptyBlockTemplate);
            val_3.<blockType>k__BackingField = blockType;
            UnityEngine.Vector3 val_5 = UnityEngine.Vector3.one;
            val_2.transform.localScale = new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z};
            UnityEngine.Vector3 val_7 = UnityEngine.Vector3.zero;
            val_2.transform.localPosition = new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z};
            val_2.transform.SetAsLastSibling();
            val_2.name = "Block-"("Block-") + blockType.ToString();
            return (BlockPuzzleMagic.Block)val_2.GetComponent<BlockPuzzleMagic.Block>();
        }
        public static BlockPuzzleMagic.Block CreateColorFillBlock(BlockPuzzleMagic.BlockColorType _colorType)
        {
            var val_18;
            var val_19;
            UnityEngine.RectOffset val_20;
            BlockPuzzleMagic.BlockColor val_3 = BlockPuzzleMagic.GameReferenceData.Instance.GetBlockColor(colorType:  _colorType);
            if(_colorType != 1)
            {
                goto label_5;
            }
            
            val_1.blockImage.sprite = val_1.rainbowBlockSprite;
            UnityEngine.Vector2 val_7 = new UnityEngine.Vector2(x:  (float)val_1.rainbowSpriteRectOffset.left, y:  (float)val_1.rainbowSpriteRectOffset.bottom);
            val_1.blockImage.rectTransform.offsetMin = new UnityEngine.Vector2() {x = val_7.x, y = val_7.y};
            val_18 = val_1.blockImage.rectTransform;
            val_19 = val_1.rainbowSpriteRectOffset;
            int val_9 = val_19.right;
            val_20 = val_1.rainbowSpriteRectOffset;
            if(val_20 != null)
            {
                goto label_13;
            }
            
            label_5:
            val_1.blockImage.sprite = val_1.normalBlockSprite;
            UnityEngine.Vector2 val_13 = new UnityEngine.Vector2(x:  (float)val_1.normalSpriteRectOffset.left, y:  (float)val_1.normalSpriteRectOffset.bottom);
            val_1.blockImage.rectTransform.offsetMin = new UnityEngine.Vector2() {x = val_13.x, y = val_13.y};
            val_18 = val_1.blockImage.rectTransform;
            val_19 = val_1.normalSpriteRectOffset;
            val_20 = val_1.normalSpriteRectOffset;
            label_13:
            UnityEngine.Vector2 val_17 = new UnityEngine.Vector2(x:  (float)-val_19.right, y:  (float)-val_20.top);
            val_18.offsetMax = new UnityEngine.Vector2() {x = val_17.x, y = val_17.y};
            val_1.blockImage.color = new UnityEngine.Color() {r = val_3.colorValue, g = val_17.y};
            return (BlockPuzzleMagic.Block)BlockPuzzleMagic.Block.CreateBlock(blockType:  1);
        }
        public static BlockPuzzleMagic.Block CreateStoneBlock()
        {
            BlockPuzzleMagic.Block val_1 = BlockPuzzleMagic.Block.CreateBlock(blockType:  4);
            val_1.blockImage.sprite = val_1.stoneBlockSprite;
            UnityEngine.Vector2 val_5 = new UnityEngine.Vector2(x:  (float)val_1.stoneSpriteRectOffset.left, y:  (float)val_1.stoneSpriteRectOffset.bottom);
            val_1.blockImage.rectTransform.offsetMin = new UnityEngine.Vector2() {x = val_5.x, y = val_5.y};
            UnityEngine.Vector2 val_9 = new UnityEngine.Vector2(x:  (float)-val_1.stoneSpriteRectOffset.right, y:  (float)-val_1.stoneSpriteRectOffset.top);
            val_1.blockImage.rectTransform.offsetMax = new UnityEngine.Vector2() {x = val_9.x, y = val_9.y};
            UnityEngine.Color val_10 = UnityEngine.Color.white;
            val_1.blockImage.color = new UnityEngine.Color() {r = val_10.r, g = val_10.g, b = val_10.b, a = val_10.a};
            if(val_1.particleStoneChippedInstance != 0)
            {
                    return val_1;
            }
            
            UnityEngine.ParticleSystem val_13 = UnityEngine.Object.Instantiate<UnityEngine.ParticleSystem>(original:  val_1.particleStoneChipped, parent:  val_1.transform);
            val_1.particleStoneChippedInstance = val_13;
            UnityEngine.Vector3 val_16 = UnityEngine.Vector3.zero;
            val_13.gameObject.transform.localPosition = new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z};
            return val_1;
        }
        public void RefreshVisualState()
        {
            var val_27;
            var val_28;
            var val_29;
            UnityEngine.RectOffset val_30;
            val_27 = this;
            UnityEngine.Vector3 val_3 = UnityEngine.Vector3.one;
            this.blockImage.gameObject.transform.localScale = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
            if((this.<blockType>k__BackingField) != 4)
            {
                    return;
            }
            
            if(this.breaksRequired != 1)
            {
                goto label_7;
            }
            
            this.blockImage.sprite = this.crateBlockSprite;
            UnityEngine.Vector2 val_8 = new UnityEngine.Vector2(x:  (float)this.crateSpriteRectOffset.left, y:  (float)this.crateSpriteRectOffset.bottom);
            this.blockImage.rectTransform.offsetMin = new UnityEngine.Vector2() {x = val_8.x, y = val_8.y};
            val_28 = this.blockImage.rectTransform;
            val_29 = this.crateSpriteRectOffset;
            int val_10 = val_29.right;
            val_30 = this.crateSpriteRectOffset;
            if(val_30 != null)
            {
                goto label_25;
            }
            
            label_7:
            if(this.breaksRequired != 2)
            {
                goto label_17;
            }
            
            this.blockImage.sprite = this.stoneBlockSprite;
            UnityEngine.Vector2 val_15 = new UnityEngine.Vector2(x:  (float)this.stoneSpriteRectOffset.left, y:  (float)this.stoneSpriteRectOffset.bottom);
            this.blockImage.rectTransform.offsetMin = new UnityEngine.Vector2() {x = val_15.x, y = val_15.y};
            val_28 = this.blockImage.rectTransform;
            val_29 = this.stoneSpriteRectOffset;
            int val_17 = val_29.right;
            val_30 = this.stoneSpriteRectOffset;
            if(val_30 != null)
            {
                goto label_25;
            }
            
            label_17:
            if(this.breaksRequired != 3)
            {
                    return;
            }
            
            this.blockImage.sprite = this.metalBlockSprite;
            UnityEngine.Vector2 val_22 = new UnityEngine.Vector2(x:  (float)this.metalSpriteRectOffset.left, y:  (float)this.metalSpriteRectOffset.bottom);
            this.blockImage.rectTransform.offsetMin = new UnityEngine.Vector2() {x = val_22.x, y = val_22.y};
            val_28 = this.blockImage.rectTransform;
            val_29 = this.metalSpriteRectOffset;
            val_30 = this.metalSpriteRectOffset;
            label_25:
            val_27 = val_29.right;
            UnityEngine.Vector2 val_26 = new UnityEngine.Vector2(x:  (float)-val_27, y:  (float)-val_30.top);
            val_28.offsetMax = new UnityEngine.Vector2() {x = val_26.x, y = val_26.y};
        }
        public DG.Tweening.Sequence ClearBlock(bool isLastBlockBreak, float animationDelay = 0)
        {
            if((this.<blockType>k__BackingField) == 4)
            {
                    if(this.particleStoneChippedInstance != 0)
            {
                    this.particleStoneChippedInstance.Play();
            }
            
            }
            
            if(this.blockSeq != null)
            {
                    DG.Tweening.TweenExtensions.Kill(t:  this.blockSeq, complete:  false);
            }
            
            DG.Tweening.Sequence val_2 = DG.Tweening.DOTween.Sequence();
            this.blockSeq = val_2;
            DG.Tweening.Sequence val_3 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_2, interval:  animationDelay);
            if(isLastBlockBreak != false)
            {
                    DG.Tweening.Sequence val_5 = DG.Tweening.TweenSettingsExtensions.Append(s:  this.blockSeq, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.blockImage, endValue:  0f, duration:  0.3f));
                UnityEngine.Vector3 val_7 = UnityEngine.Vector3.zero;
                DG.Tweening.Sequence val_9 = DG.Tweening.TweenSettingsExtensions.Join(s:  this.blockSeq, t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.blockImage.transform, endValue:  new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z}, duration:  0.35f));
                return (DG.Tweening.Sequence)this.blockSeq;
            }
            
            DG.Tweening.Sequence val_12 = DG.Tweening.TweenSettingsExtensions.Append(s:  this.blockSeq, t:  DG.Tweening.ShortcutExtensions.DOShakePosition(target:  this.blockImage.transform, duration:  0.3f, strength:  5f, vibrato:  30, randomness:  90f, snapping:  false, fadeOut:  true));
            return (DG.Tweening.Sequence)this.blockSeq;
        }
        public Block()
        {
        
        }
        private static Block()
        {
            NodeType[] val_1 = new NodeType[2];
            val_1[0] = 8;
            val_1[0] = 4;
            BlockPuzzleMagic.Block.BLOCK_TYPES = val_1;
        }
    
    }

}
