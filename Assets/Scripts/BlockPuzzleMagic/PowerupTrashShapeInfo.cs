using UnityEngine;

namespace BlockPuzzleMagic
{
    public class PowerupTrashShapeInfo : ShapeInfo
    {
        // Fields
        public const int SHAPE_ID = -102;
        protected BlockPuzzleMagic.BlockSpawnerNode highlightedSpawnerNode;
        private DG.Tweening.Sequence activeHoverSeq;
        
        // Methods
        protected override void Awake()
        {
            mem[1152921520201653592] = 101;
            this.Awake();
        }
        public override void Init(UnityEngine.Transform parent, UnityEngine.Vector3 worldPos, float scale, float alpha, string source, bool anima = True)
        {
            BlockPuzzleMagic.BlockColor val_2 = BlockPuzzleMagic.GameReferenceData.Instance.GetBlockColor(colorType:  0);
            bool val_3 = anima;
            goto typeof(BlockPuzzleMagic.PowerupTrashShapeInfo).__il2cppRuntimeField_1E0;
        }
        public override void Init(BlockPuzzleMagic.BlockColor color, UnityEngine.Transform parent, UnityEngine.Vector3 worldPos, float scale, float alpha, string source, bool anima = True)
        {
            anima = anima;
            this.Init(color:  BlockPuzzleMagic.GameReferenceData.Instance.GetBlockColor(colorType:  0), parent:  parent, worldPos:  new UnityEngine.Vector3() {x = worldPos.x, y = worldPos.y, z = worldPos.z}, scale:  scale, alpha:  alpha, source:  source, anima:  anima);
        }
        public override void OnDrag(UnityEngine.EventSystems.PointerEventData eventData)
        {
            this.OnDrag(eventData:  eventData);
            if(W8 == 0)
            {
                    return;
            }
            
            this.SearchForShapeInfo();
        }
        public override bool CanResolveAction()
        {
            if(this.highlightedSpawnerNode == 0)
            {
                    return false;
            }
            
            if(this.highlightedSpawnerNode.ContainsShape() == false)
            {
                    return false;
            }
            
            return MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance.CanUsePowerup(powerupType:  0, showStoreIfOOC:  true, oocDelay:  0f);
        }
        public override void SnapBackAndReset(System.Action onComplete)
        {
            this.SnapBackAndReset(onComplete:  onComplete);
            if(this.highlightedSpawnerNode == 0)
            {
                    return;
            }
            
            if(this.highlightedSpawnerNode.ContainsShape() == false)
            {
                    return;
            }
            
            this.SetUsableShapeHighlight(shape:  this.highlightedSpawnerNode.GetShape(), highlight:  false);
        }
        public override void ResolveAction()
        {
            MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance.UsePowerup(powerupType:  0, freeUsage:  MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance.BuyPowerup(powerupType:  0, freeUsage:  false));
            MonoSingleton<BlockPuzzleMagic.BlockShapeSpawner>.Instance.DestroyShape(containerIndex:  this.highlightedSpawnerNode.spawnerId);
            MonoSingleton<BlockPuzzleMagic.BlockShapeSpawner>.Instance.FillShapeContainer(skipAutosave:  true);
        }
        private void SearchForShapeInfo()
        {
            BlockPuzzleMagic.BlockSpawnerNode val_22;
            var val_25 = 0;
            label_25:
            if(val_25 >= (X21 + 24))
            {
                goto label_2;
            }
            
            if((X21 + 24) <= val_25)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_22 = X21 + 16;
            val_22 = val_22 + 0;
            UnityEngine.Vector3 val_1 = (X21 + 16 + 0) + 32 + 16.position;
            UnityEngine.Vector2 val_2 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z});
            UnityEngine.Vector2 val_3 = UnityEngine.Vector2.zero;
            int val_4 = UnityEngine.Physics2D.RaycastNonAlloc(origin:  new UnityEngine.Vector2() {x = val_2.x, y = val_2.y}, direction:  new UnityEngine.Vector2() {x = val_3.x, y = val_3.y}, results:  X21, distance:  1f);
            if(val_4 >= 1)
            {
                    var val_23 = 0;
                var val_24 = 32;
                do
            {
                UnityEngine.GameObject val_7 = (UnityEngine.Physics2D.__il2cppRuntimeField_cctor_finished + 32).collider.gameObject;
                if(val_7 != this.gameObject)
            {
                    if((collider.gameObject.GetComponentInChildren<BlockPuzzleMagic.BlockSpawnerNode>()) != 0)
            {
                goto label_23;
            }
            
            }
            
                val_23 = val_23 + 1;
                val_24 = val_24 + 36;
            }
            while(val_23 < (long)val_4);
            
            }
            
            label_23:
            val_25 = val_25 + 1;
            if(val_7 != null)
            {
                goto label_25;
            }
            
            label_2:
            if(0 != 0)
            {
                    val_22 = this.highlightedSpawnerNode;
                if(val_22 != 0)
            {
                    if(9733424 == this.highlightedSpawnerNode.spawnerId)
            {
                    return;
            }
            
            }
            
            }
            
            val_22 = this.highlightedSpawnerNode;
            if(val_22 != 0)
            {
                    if(this.highlightedSpawnerNode.ContainsShape() != false)
            {
                    this.SetUsableShapeHighlight(shape:  this.highlightedSpawnerNode.GetShape(), highlight:  false);
            }
            
            }
            
            if(0 != 0)
            {
                    if(0.ContainsShape() != false)
            {
                    this.SetUsableShapeHighlight(shape:  0.GetShape(), highlight:  true);
            }
            
            }
            
            this.highlightedSpawnerNode = 0;
        }
        private void SetUsableShapeHighlight(BlockPuzzleMagic.ShapeInfo shape, bool highlight)
        {
            if(highlight != false)
            {
                    UnityEngine.Vector3 val_2 = shape.transform.position;
                UnityEngine.Vector3 val_4 = shape.transform.localScale;
                UnityEngine.Vector3 val_5 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z}, d:  1.8f);
                this.ToggleSortingOrder(bringToFront:  true);
            }
        
        }
        public PowerupTrashShapeInfo()
        {
        
        }
    
    }

}
