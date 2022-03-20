using UnityEngine;

namespace BlockPuzzleMagic
{
    public class BlockSpawnerNode : MonoBehaviour
    {
        // Fields
        private int spawnerId;
        private UnityEngine.BoxCollider2D spawnerCollider;
        private UnityEngine.UI.Button cross;
        
        // Properties
        public int SpawnerId { get; }
        
        // Methods
        public int get_SpawnerId()
        {
            return (int)this.spawnerId;
        }
        private void Start()
        {
            this.ShowTrashCross(show:  false);
            this.cross.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void BlockPuzzleMagic.BlockSpawnerNode::<Start>b__5_0()));
        }
        private void OnRectTransformDimensionsChange()
        {
            if(null == null)
            {
                    UnityEngine.Rect val_2 = this.transform.rect;
                UnityEngine.Vector2 val_3 = val_2.m_XMin.size;
                this.spawnerCollider.size = new UnityEngine.Vector2() {x = val_3.x, y = val_3.y};
                return;
            }
        
        }
        public bool ContainsShape()
        {
            BlockPuzzleMagic.BlockShapeSpawner val_1 = MonoSingleton<BlockPuzzleMagic.BlockShapeSpawner>.Instance;
            return UnityEngine.Object.op_Inequality(x:  val_1.spawnedShapes[this.spawnerId], y:  0);
        }
        public BlockPuzzleMagic.ShapeInfo GetShape()
        {
            BlockPuzzleMagic.BlockShapeSpawner val_1 = MonoSingleton<BlockPuzzleMagic.BlockShapeSpawner>.Instance;
            return (BlockPuzzleMagic.ShapeInfo)val_1.spawnedShapes[this.spawnerId];
        }
        public void ShowTrashCross(bool show)
        {
            this.cross.gameObject.SetActive(value:  show);
        }
        public BlockSpawnerNode()
        {
        
        }
        private void <Start>b__5_0()
        {
            MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance.UsePowerup(powerupType:  0, freeUsage:  MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance.BuyPowerup(powerupType:  0, freeUsage:  false));
            MonoSingleton<BlockPuzzleMagic.BlockShapeSpawner>.Instance.DestroyShape(containerIndex:  this.spawnerId);
            NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnTrashButtonModeExit");
            MonoSingleton<BlockPuzzleMagic.BlockShapeSpawner>.Instance.FillShapeContainer(skipAutosave:  true);
        }
    
    }

}
