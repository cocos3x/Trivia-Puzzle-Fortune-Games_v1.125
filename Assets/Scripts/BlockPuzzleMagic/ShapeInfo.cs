using UnityEngine;

namespace BlockPuzzleMagic
{
    public class ShapeInfo : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IBeginDragHandler, IDragHandler, IPointerClickHandler
    {
        // Fields
        public const int NULL_SHAPE_ID = -1;
        public const string SHAPE_SRC_SHAPE_SPAWNER = "shpsrc_shp_spwn";
        public const string SHAPE_SRC_POWERUP_BUTTON = "shpsrc_pwr_but";
        protected const float ALPHA_UNPLAYABLE = 0.3;
        private const float DRAG_OFFSET_Y = 0.55;
        protected int shapeId;
        private BlockPuzzleMagic.ShapeBlock <FirstBlock>k__BackingField;
        public bool allowPartialFit;
        public bool ignoreFilled;
        protected UnityEngine.Vector2Int blockGridCount;
        protected UnityEngine.Vector2Int blockGridCountUnrotated;
        protected int rotationHeading;
        protected int rotationHeadingNeededToPlace;
        private System.Collections.Generic.List<BlockPuzzleMagic.ShapeBlock> <ShapeBlocks>k__BackingField;
        protected BlockPuzzleMagic.BlockColor colorData;
        private bool isDragged;
        protected bool draggable;
        protected UnityEngine.Vector3 neutralWorldPosition;
        protected UnityEngine.Vector3 neutralScale;
        protected float neutralAlpha;
        protected UnityEngine.Vector3 activeScale;
        protected UnityEngine.RaycastHit2D[] raycastHit;
        protected DG.Tweening.Sequence shapeAnimSeq;
        protected UnityEngine.CanvasGroup shapeCanvas;
        private UnityEngine.Transform originalParentTransform;
        private int originalSiblingIndex;
        private bool prevInteractableState;
        private float dragOffsetY;
        private DG.Tweening.Tween shapeSpawnTween;
        private bool isInputInterrupted;
        private DG.Tweening.Tween initiateDragModeTween;
        private DG.Tweening.Tweener shapeRotationSeq;
        private string <initSource>k__BackingField;
        private UnityEngine.Vector2 <Size>k__BackingField;
        private bool <Placeable>k__BackingField;
        
        // Properties
        public static bool IsRotationAllowed { get; }
        public int ShapeId { get; }
        public BlockPuzzleMagic.ShapeBlock FirstBlock { get; set; }
        public int RotationHeading { get; }
        public System.Collections.Generic.List<BlockPuzzleMagic.ShapeBlock> ShapeBlocks { get; set; }
        public BlockPuzzleMagic.BlockColor ColorData { get; }
        public bool IsDragged { get; }
        public bool Draggable { get; set; }
        public UnityEngine.Vector3 NeutralWorldPosition { get; set; }
        public float NeutralAlpha { get; set; }
        public string initSource { get; set; }
        public UnityEngine.Vector2 Size { get; set; }
        public bool Interactable { get; set; }
        public float Alpha { get; set; }
        public bool Placeable { get; set; }
        public bool PlaceableWithRotation { get; }
        
        // Methods
        public static bool get_IsRotationAllowed()
        {
            return false;
        }
        public int get_ShapeId()
        {
            return (int)this.shapeId;
        }
        public BlockPuzzleMagic.ShapeBlock get_FirstBlock()
        {
            return (BlockPuzzleMagic.ShapeBlock)this.<FirstBlock>k__BackingField;
        }
        protected void set_FirstBlock(BlockPuzzleMagic.ShapeBlock value)
        {
            this.<FirstBlock>k__BackingField = value;
        }
        public int get_RotationHeading()
        {
            return (int)this.rotationHeading;
        }
        public System.Collections.Generic.List<BlockPuzzleMagic.ShapeBlock> get_ShapeBlocks()
        {
            return (System.Collections.Generic.List<BlockPuzzleMagic.ShapeBlock>)this.<ShapeBlocks>k__BackingField;
        }
        private void set_ShapeBlocks(System.Collections.Generic.List<BlockPuzzleMagic.ShapeBlock> value)
        {
            this.<ShapeBlocks>k__BackingField = value;
        }
        public BlockPuzzleMagic.BlockColor get_ColorData()
        {
            return (BlockPuzzleMagic.BlockColor)this.colorData;
        }
        public bool get_IsDragged()
        {
            return (bool)this.isDragged;
        }
        public bool get_Draggable()
        {
            return (bool)this.draggable;
        }
        public void set_Draggable(bool value)
        {
            this.draggable = value;
        }
        public void set_NeutralWorldPosition(UnityEngine.Vector3 value)
        {
            this.neutralWorldPosition = value;
            mem[1152921520204703136] = value.y;
            mem[1152921520204703140] = value.z;
        }
        public UnityEngine.Vector3 get_NeutralWorldPosition()
        {
            return new UnityEngine.Vector3() {x = this.neutralWorldPosition};
        }
        public void set_NeutralAlpha(float value)
        {
            this.neutralAlpha = value;
        }
        public float get_NeutralAlpha()
        {
            return (float)this.neutralAlpha;
        }
        public string get_initSource()
        {
            return (string)this.<initSource>k__BackingField;
        }
        private void set_initSource(string value)
        {
            this.<initSource>k__BackingField = value;
        }
        public UnityEngine.Vector2 get_Size()
        {
            return new UnityEngine.Vector2() {x = this.<Size>k__BackingField};
        }
        private void set_Size(UnityEngine.Vector2 value)
        {
            this.<Size>k__BackingField = value;
            mem[1152921520205503652] = value.y;
        }
        public bool get_Interactable()
        {
            if(this.shapeCanvas != null)
            {
                    return this.shapeCanvas.blocksRaycasts;
            }
            
            throw new NullReferenceException();
        }
        public void set_Interactable(bool value)
        {
            if(this.shapeCanvas != null)
            {
                    this.shapeCanvas.blocksRaycasts = value;
                return;
            }
            
            throw new NullReferenceException();
        }
        public float get_Alpha()
        {
            if(this.shapeCanvas != null)
            {
                    return this.shapeCanvas.alpha;
            }
            
            throw new NullReferenceException();
        }
        public void set_Alpha(float value)
        {
            if(this.shapeCanvas != null)
            {
                    this.shapeCanvas.alpha = value;
                return;
            }
            
            throw new NullReferenceException();
        }
        public bool get_Placeable()
        {
            return (bool)this.<Placeable>k__BackingField;
        }
        protected void set_Placeable(bool value)
        {
            this.<Placeable>k__BackingField = value;
        }
        public bool get_PlaceableWithRotation()
        {
            return (bool)(this.rotationHeadingNeededToPlace < 4) ? 1 : 0;
        }
        protected virtual void Awake()
        {
            this.shapeCanvas = this.gameObject.GetComponent<UnityEngine.CanvasGroup>();
        }
        public virtual void Init(UnityEngine.Transform parent, UnityEngine.Vector3 worldPos, float scale, float alpha, string source, bool anima = True)
        {
            BlockPuzzleMagic.BlockColor val_2 = BlockPuzzleMagic.GameReferenceData.Instance.GetBlockColor(colorType:  0);
            bool val_3 = anima;
            goto typeof(BlockPuzzleMagic.ShapeInfo).__il2cppRuntimeField_1E0;
        }
        public virtual void Init(BlockPuzzleMagic.BlockColor color, UnityEngine.Transform parent, UnityEngine.Vector3 worldPos, float scale, float alpha, string source, bool anima = True)
        {
            this.colorData = new BlockPuzzleMagic.BlockColor(_colorType:  color.blockColor, _colorValues:  new UnityEngine.Color() {r = color.colorValue, g = V14.16B, b = V15.16B, a = V8.16B});
            this.gameObject.transform.SetParent(p:  parent);
            UnityEngine.Vector3 val_6 = UnityEngine.Vector3.zero;
            this.gameObject.transform.localScale = new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z};
            this.neutralWorldPosition = worldPos;
            mem[1152921520206779168] = worldPos.y;
            mem[1152921520206779172] = worldPos.z;
            this.gameObject.transform.position = new UnityEngine.Vector3() {x = worldPos.x, y = worldPos.y, z = worldPos.z};
            UnityEngine.Vector3 val_9 = new UnityEngine.Vector3(x:  scale, y:  scale, z:  1f);
            this.neutralScale = val_9.x;
            mem[1152921520206779184] = val_9.z;
            this.neutralAlpha = alpha;
            this.shapeCanvas.alpha = alpha;
            this.originalParentTransform = parent;
            this.originalSiblingIndex = this.gameObject.transform.GetSiblingIndex();
            this.<initSource>k__BackingField = source;
            this.ToggleSortingOrder(bringToFront:  false);
            UnityEngine.Transform val_14 = this.gameObject.transform;
            if(anima != false)
            {
                    this.shapeSpawnTween = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  val_14, endValue:  new UnityEngine.Vector3() {x = this.neutralScale, y = scale, z = 1f}, duration:  0.3f), ease:  27);
                return;
            }
            
            val_14.localScale = new UnityEngine.Vector3() {x = this.neutralScale, y = scale, z = 1f};
        }
        public void SetNeutralWorldPosition(UnityEngine.Vector3 worldPos)
        {
            this.neutralWorldPosition = worldPos;
            mem[1152921520206964896] = worldPos.y;
            mem[1152921520206964900] = worldPos.z;
        }
        public virtual void InitBlockList()
        {
            var val_22;
            UnityEngine.Vector2Int val_23;
            var val_24;
            UnityEngine.UI.Image val_25;
            this.<ShapeBlocks>k__BackingField = new System.Collections.Generic.List<BlockPuzzleMagic.ShapeBlock>();
            if(val_3.Length >= 1)
            {
                    val_22 = 1152921505060011504;
                var val_25 = 0;
                val_23 = this.blockGridCountUnrotated;
                val_24 = 45;
                do
            {
                T val_22 = this.transform.GetComponentsInChildren<UnityEngine.Transform>()[val_25];
                val_25 = val_22.GetInstanceID();
                if(val_25 != this.transform.GetInstanceID())
            {
                    char[] val_8 = new char[1];
                val_8[0] = '-';
                val_25 = val_22.name.Split(separator:  val_8);
                if(val_9.Length == 3)
            {
                    bool val_11 = System.Int32.TryParse(s:  val_25[1], result: out  0);
                bool val_13 = System.Int32.TryParse(s:  val_25[2], result: out  0);
                val_25 = val_22.GetComponent<UnityEngine.UI.Image>();
                val_23.x = UnityEngine.Mathf.Max(a:  val_23.x, b:  1);
                val_23.y = UnityEngine.Mathf.Max(a:  val_23.y, b:  1);
                BlockPuzzleMagic.ShapeBlock val_20 = new BlockPuzzleMagic.ShapeBlock();
                .block = val_22;
                .rowIDOrientated = 0;
                .columnIDOrientated = 0;
                .rowID = 0;
                .columnID = 0;
                .image = val_25;
                .properties = val_22.GetComponent<BlockPuzzleMagic.ShapeBlockProperties>();
                val_22 = 1152921505060011504;
                if((this.colorData != null) && (this.colorData.blockColor != 0))
            {
                    val_25.color = new UnityEngine.Color() {r = this.colorData.colorValue};
            }
            
                val_23 = val_23;
                val_24 = 45;
                if((this.<ShapeBlocks>k__BackingField.Contains(item:  val_20)) != true)
            {
                    this.<ShapeBlocks>k__BackingField.Add(item:  val_20);
            }
            
            }
            
            }
            
                val_25 = val_25 + 1;
            }
            while(val_25 < val_3.Length);
            
            }
            
            this.SetRotation(rotationId:  0);
        }
        public void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData)
        {
            UnityEngine.Vector3 val_6 = this.neutralScale;
            UnityEngine.Vector3 val_2;
            val_6 = val_6 * 1.5f;
            val_2 = new UnityEngine.Vector3(x:  val_6, y:  S1 * 1.5f, z:  null);
            this.DoSimpleScale(scale:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z}, duration:  0.1f);
            if(this.draggable == false)
            {
                    return;
            }
            
            .<>4__this = this;
            if(this.initiateDragModeTween != null)
            {
                    DG.Tweening.TweenExtensions.Kill(t:  this.initiateDragModeTween, complete:  false);
            }
            
            .eData = eventData;
            this.initiateDragModeTween = DG.Tweening.DOVirtual.DelayedCall(delay:  0.38f, callback:  new DG.Tweening.TweenCallback(object:  new ShapeInfo.<>c__DisplayClass82_0(), method:  System.Void ShapeInfo.<>c__DisplayClass82_0::<OnPointerDown>b__0()), ignoreTimeScale:  true);
        }
        protected void InitiateDragMode(UnityEngine.EventSystems.PointerEventData eventData)
        {
            UnityEngine.Vector3 val_2 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = eventData.<position>k__BackingField, y = V8.16B});
            UnityEngine.Vector3 val_3 = UnityEngine.Camera.main.ScreenToWorldPoint(position:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z});
            UnityEngine.Vector3 val_6 = this.gameObject.transform.localScale;
            if(this == null)
            {
                goto label_9;
            }
            
            if(null == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            if(null != null)
            {
                goto label_15;
            }
            
            UnityEngine.Rect val_8 = BlockPuzzleMagic.GridPlaceableShapeInfo.__il2cppRuntimeField_byval_arg + 16.transform.rect;
            BlockPuzzleMagic.GameBoardGenerator val_10 = MonoSingleton<BlockPuzzleMagic.GameBoardGenerator>.Instance;
            float val_16 = val_10.blockHeight;
            val_16 = val_16 / val_8.m_XMin.height;
            val_16 = val_16 * 1.2f;
            UnityEngine.Vector3 val_11 = new UnityEngine.Vector3(x:  val_16, y:  val_16, z:  1f);
            label_9:
            UnityEngine.Vector3 val_14 = this.gameObject.transform.position;
            UnityEngine.Vector3 val_15 = new UnityEngine.Vector3(x:  val_3.x, y:  val_3.y, z:  val_14.z);
            eventData.<eligibleForClick>k__BackingField = false;
            this.isDragged = true;
            return;
            label_15:
        }
        public void OnPointerUp(UnityEngine.EventSystems.PointerEventData eventData)
        {
            if(this.initiateDragModeTween != null)
            {
                    DG.Tweening.TweenExtensions.Kill(t:  this.initiateDragModeTween, complete:  false);
            }
            
            if(this.isDragged == false)
            {
                goto label_2;
            }
            
            if((this & 1) == 0)
            {
                goto label_3;
            }
            
            MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance.NotifyShapePlaced(shape:  this);
            goto label_8;
            label_2:
            this.DoSimpleScale(scale:  new UnityEngine.Vector3() {x = this.neutralScale}, duration:  0.1f);
            goto label_8;
            label_3:
            label_8:
            this.isDragged = false;
        }
        public virtual void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData)
        {
        
        }
        public void OnBeginDrag(UnityEngine.EventSystems.PointerEventData eventData)
        {
            if(this.initiateDragModeTween != null)
            {
                    DG.Tweening.TweenExtensions.Complete(t:  this.initiateDragModeTween, withCallbacks:  true);
            }
            
            if(this.shapeRotationSeq != null)
            {
                    DG.Tweening.TweenExtensions.Complete(t:  this.shapeRotationSeq);
            }
            
            if(this.isDragged == false)
            {
                    return;
            }
            
            UnityEngine.Vector3 val_2 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = eventData.<position>k__BackingField, y = V8.16B});
            UnityEngine.Vector3 val_3 = UnityEngine.Camera.main.ScreenToWorldPoint(position:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z});
            UnityEngine.Vector3 val_6 = this.gameObject.transform.localPosition;
            this.gameObject.transform.localPosition = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_6.z};
        }
        public virtual void OnDrag(UnityEngine.EventSystems.PointerEventData eventData)
        {
            if(this.isDragged == false)
            {
                    return;
            }
            
            UnityEngine.Vector3 val_2 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector2() {x = eventData.<position>k__BackingField, y = V8.16B});
            UnityEngine.Vector3 val_3 = UnityEngine.Camera.main.ScreenToWorldPoint(position:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z});
            UnityEngine.Vector3 val_8 = this.gameObject.transform.position;
            UnityEngine.Vector3 val_10 = new UnityEngine.Vector3(x:  val_3.x, y:  val_3.y + this.dragOffsetY, z:  val_8.z);
            this.gameObject.transform.position = new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z};
        }
        protected virtual void OnApplicationFocus(bool hasFocus)
        {
            if(hasFocus != false)
            {
                    if(this.isInputInterrupted == false)
            {
                    return;
            }
            
                this.isDragged = false;
                this.isInputInterrupted = false;
                return;
            }
            
            if(this.isDragged == false)
            {
                    return;
            }
            
            this.isInputInterrupted = true;
        }
        public virtual bool CanResolveAction()
        {
            return false;
        }
        public virtual void ResolveAction()
        {
        
        }
        public virtual void Consume()
        {
            UnityEngine.Object.Destroy(obj:  this.gameObject);
        }
        public virtual void SetPlaceableStatus(bool _isPlayable, int validRotationId = -1)
        {
            this.<Placeable>k__BackingField = _isPlayable;
            this.rotationHeadingNeededToPlace = validRotationId;
            if(_isPlayable == false)
            {
                goto label_0;
            }
            
            if(this.shapeCanvas != null)
            {
                goto label_1;
            }
            
            goto label_3;
            label_0:
            if(this.shapeCanvas == null)
            {
                goto label_3;
            }
            
            label_1:
            this.shapeCanvas.alpha = 0.3f;
            return;
            label_3:
            throw new NullReferenceException();
        }
        public virtual void SnapAndScaleToWorldPos(UnityEngine.Vector3 posTo, UnityEngine.Vector3 scaleTo, float duration = 0.05, bool applyDragOffset = False)
        {
            float val_21 = posTo.y;
            this.prevInteractableState = this.shapeCanvas.blocksRaycasts;
            this.shapeCanvas.blocksRaycasts = false;
            this.activeScale = scaleTo;
            mem[1152921520209057884] = scaleTo.y;
            mem[1152921520209057888] = scaleTo.z;
            UnityEngine.Vector3 val_5 = this.shapeCanvas.gameObject.transform.lossyScale;
            UnityEngine.Vector3 val_8 = this.shapeCanvas.gameObject.transform.localScale;
            float val_20 = 0.5f;
            val_8.y = scaleTo.y / val_8.y;
            val_20 = posTo.x * val_20;
            val_8.y = val_5.y * val_8.y;
            val_20 = val_20 * val_8.y;
            val_20 = val_20 + 0.55f;
            this.dragOffsetY = val_20;
            val_20 = val_21 + val_20;
            val_21 = (applyDragOffset != true) ? (val_20) : (val_21);
            if(this.shapeSpawnTween != null)
            {
                    DG.Tweening.TweenExtensions.Kill(t:  this.shapeSpawnTween, complete:  false);
            }
            
            if(this.shapeAnimSeq != null)
            {
                    DG.Tweening.TweenExtensions.Kill(t:  this.shapeAnimSeq, complete:  false);
            }
            
            DG.Tweening.Sequence val_9 = DG.Tweening.DOTween.Sequence();
            this.shapeAnimSeq = val_9;
            DG.Tweening.Sequence val_13 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_9, t:  DG.Tweening.ShortcutExtensions.DOMove(target:  this.gameObject.transform, endValue:  new UnityEngine.Vector3() {x = posTo.x, y = val_21, z = posTo.z}, duration:  duration, snapping:  false));
            DG.Tweening.Sequence val_17 = DG.Tweening.TweenSettingsExtensions.Join(s:  this.shapeAnimSeq, t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.gameObject.transform, endValue:  new UnityEngine.Vector3() {x = scaleTo.x, y = scaleTo.y, z = scaleTo.z}, duration:  duration));
            DG.Tweening.Sequence val_19 = DG.Tweening.TweenSettingsExtensions.Join(s:  this.shapeAnimSeq, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.shapeCanvas, endValue:  1f, duration:  duration));
            this.ToggleSortingOrder(bringToFront:  true);
        }
        public virtual void SnapBackAndReset(System.Action onComplete)
        {
            .<>4__this = this;
            .onComplete = onComplete;
            this.shapeCanvas.blocksRaycasts = this.prevInteractableState;
            if(this.shapeSpawnTween != null)
            {
                    DG.Tweening.TweenExtensions.Kill(t:  this.shapeSpawnTween, complete:  false);
            }
            
            if(this.shapeAnimSeq != null)
            {
                    DG.Tweening.TweenExtensions.Kill(t:  this.shapeAnimSeq, complete:  false);
            }
            
            DG.Tweening.Sequence val_2 = DG.Tweening.DOTween.Sequence();
            this.shapeAnimSeq = val_2;
            DG.Tweening.Sequence val_6 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_2, t:  DG.Tweening.ShortcutExtensions.DOMove(target:  this.gameObject.transform, endValue:  new UnityEngine.Vector3() {x = this.neutralWorldPosition}, duration:  0.25f, snapping:  false));
            DG.Tweening.Sequence val_10 = DG.Tweening.TweenSettingsExtensions.Join(s:  this.shapeAnimSeq, t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.gameObject.transform, endValue:  new UnityEngine.Vector3() {x = this.neutralScale}, duration:  0.25f));
            if((this.<Placeable>k__BackingField) != false)
            {
                
            }
            
            DG.Tweening.Sequence val_12 = DG.Tweening.TweenSettingsExtensions.Join(s:  this.shapeAnimSeq, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.shapeCanvas, endValue:  0.3f, duration:  0.25f));
            DG.Tweening.Sequence val_14 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  this.shapeAnimSeq, action:  new DG.Tweening.TweenCallback(object:  new ShapeInfo.<>c__DisplayClass94_0(), method:  System.Void ShapeInfo.<>c__DisplayClass94_0::<SnapBackAndReset>b__0()));
        }
        protected void DoSimpleScale(UnityEngine.Vector3 scale, float duration)
        {
            if(this.shapeSpawnTween != null)
            {
                    DG.Tweening.TweenExtensions.Kill(t:  this.shapeSpawnTween, complete:  false);
            }
            
            if(this.shapeAnimSeq != null)
            {
                    DG.Tweening.TweenExtensions.Kill(t:  this.shapeAnimSeq, complete:  false);
            }
            
            DG.Tweening.Sequence val_1 = DG.Tweening.DOTween.Sequence();
            this.shapeAnimSeq = val_1;
            DG.Tweening.Sequence val_6 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_1, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.gameObject.transform, endValue:  new UnityEngine.Vector3() {x = scale.x, y = scale.y, z = scale.z}, duration:  duration), ease:  1));
        }
        public void RotateShape(bool isClockwise = True, bool skipAnimate = False)
        {
            UnityEngine.Transform val_8;
            int val_9;
            val_8 = skipAnimate;
            val_9 = this.rotationHeading + (((isClockwise & true) != 0) ? (-1) : 1);
            this.rotationHeading = val_9;
            if(val_9 > 3)
            {
                goto label_2;
            }
            
            if((val_9 & 2147483648) == 0)
            {
                goto label_3;
            }
            
            val_9 = val_9 + 4;
            goto label_4;
            label_2:
            val_9 = 0;
            label_4:
            this.rotationHeading = val_9;
            label_3:
            this.SetRotation(rotationId:  0);
            if(val_8 == true)
            {
                    return;
            }
            
            if(this.shapeRotationSeq != null)
            {
                    DG.Tweening.TweenExtensions.Complete(t:  this.shapeRotationSeq);
            }
            
            val_8 = this.gameObject.transform;
            UnityEngine.Vector3 val_5 = new UnityEngine.Vector3(x:  0f, y:  0f, z:  (isClockwise != true) ? -90f : 90f);
            this.shapeRotationSeq = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOLocalRotate(target:  val_8, endValue:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z}, duration:  0.1f, mode:  3), ease:  1);
        }
        public void SetRotation(int rotationId)
        {
            float val_36;
            float val_37;
            var val_40;
            this.rotationHeading = rotationId;
            UnityEngine.Vector2Int val_1 = UnityEngine.Vector2Int.zero;
            UnityEngine.Vector2Int val_2 = new UnityEngine.Vector2Int(x:  99, y:  99);
            UnityEngine.Vector2 val_3 = UnityEngine.Vector2.zero;
            val_36 = val_3.x;
            val_37 = val_3.y;
            var val_38 = 0;
            label_34:
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            var val_4 = X9 + 0;
            if(this.rotationHeading > 3)
            {
                goto label_14;
            }
            
            var val_34 = 32497532 + (this.rotationHeading) << 2;
            val_34 = val_34 + 32497532;
            goto (32497532 + (this.rotationHeading) << 2 + 32497532);
            label_14:
            if((this.<FirstBlock>k__BackingField) == null)
            {
                goto label_16;
            }
            
            if((((X9 + 0) + 32 + 48) > (this.<FirstBlock>k__BackingField.rowIDOrientated)) || (((X9 + 0) + 32 + 52) >= (this.<FirstBlock>k__BackingField.columnIDOrientated)))
            {
                goto label_20;
            }
            
            this.<FirstBlock>k__BackingField = (X9 + 0) + 32;
            goto label_20;
            label_16:
            this.<FirstBlock>k__BackingField = (X9 + 0) + 32;
            label_20:
            if(((X9 + 0) + 32 + 40) != 0)
            {
                    val_40 = mem[(X9 + 0) + 32 + 40 + 24];
                val_40 = (X9 + 0) + 32 + 40 + 24;
            }
            else
            {
                    val_40 = 0;
            }
            
            if((val_40 == 0) && (S3 > 0f))
            {
                    val_1.m_X.x = UnityEngine.Mathf.Max(a:  val_1.m_X.x, b:  (X9 + 0) + 32 + 52);
                val_1.m_X.y = UnityEngine.Mathf.Max(a:  val_1.m_X.y, b:  (X9 + 0) + 32 + 48);
                val_2.m_X.x = UnityEngine.Mathf.Min(a:  val_2.m_X.x, b:  (X9 + 0) + 32 + 52);
                val_2.m_X.y = UnityEngine.Mathf.Min(a:  val_2.m_X.y, b:  (X9 + 0) + 32 + 48);
                UnityEngine.Rect val_19 = (X9 + 0) + 32 + 32.rectTransform.rect;
                UnityEngine.Vector2 val_20 = val_19.m_XMin.size;
                val_36 = val_20.x;
                val_37 = val_20.y;
            }
            
            val_38 = val_38 + 1;
            if((this.<ShapeBlocks>k__BackingField) != null)
            {
                goto label_34;
            }
            
            throw new NullReferenceException();
        }
        protected void ToggleSortingOrder(bool bringToFront)
        {
            UnityEngine.Transform val_2 = this.gameObject.transform;
            if(bringToFront != false)
            {
                    BlockPuzzleMagic.GamePlay val_3 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
                val_2.SetParent(p:  val_3.floatingShapesLayer);
                this.gameObject.transform.SetAsLastSibling();
                return;
            }
            
            val_2.SetParent(p:  this.originalParentTransform);
            this.gameObject.transform.SetSiblingIndex(index:  this.originalSiblingIndex);
        }
        public ShapeInfo()
        {
            UnityEngine.Vector2Int val_1 = UnityEngine.Vector2Int.zero;
            this.blockGridCount = val_1;
            UnityEngine.Vector2Int val_2 = UnityEngine.Vector2Int.zero;
            this.blockGridCountUnrotated = val_2;
            this.rotationHeadingNeededToPlace = 0;
            this.draggable = true;
            UnityEngine.Vector3 val_3 = UnityEngine.Vector3.zero;
            this.neutralWorldPosition = val_3;
            mem[1152921520210218352] = val_3.y;
            mem[1152921520210218356] = val_3.z;
            UnityEngine.Vector3 val_4 = UnityEngine.Vector3.one;
            this.neutralScale = val_4;
            mem[1152921520210218364] = val_4.y;
            mem[1152921520210218368] = val_4.z;
            this.neutralAlpha = 1f;
            UnityEngine.Vector3 val_5 = UnityEngine.Vector3.one;
            this.activeScale = val_5;
            mem[1152921520210218380] = val_5.y;
            mem[1152921520210218384] = val_5.z;
            this.raycastHit = new UnityEngine.RaycastHit2D[5];
            this.dragOffsetY = 0.55f;
        }
    
    }

}
