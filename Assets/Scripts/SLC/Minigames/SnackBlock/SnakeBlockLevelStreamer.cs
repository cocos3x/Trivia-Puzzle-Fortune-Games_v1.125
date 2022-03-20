using UnityEngine;

namespace SLC.Minigames.SnackBlock
{
    public class SnakeBlockLevelStreamer : MonoBehaviour
    {
        // Fields
        private UnityEngine.GameObject blockerObject;
        private UnityEngine.GameObject blockerObject2;
        private UnityEngine.GameObject correctWord;
        private UnityEngine.GameObject correctWordFtux;
        private UnityEngine.GameObject incorrectWord;
        private UnityEngine.GameObject incorrectWordFtux;
        private UnityEngine.GameObject foodObject;
        private UnityEngine.GameObject finishLinePart;
        private UnityEngine.GameObject ftuxMessageBlank;
        private float spriteWidth;
        private int lastRowSpawned;
        private System.Collections.Generic.Queue<UnityEngine.GameObject> sectionHolders;
        
        // Properties
        public UnityEngine.GameObject getSnakeLevel { get; }
        
        // Methods
        public UnityEngine.GameObject get_getSnakeLevel()
        {
            return this.sectionHolders.Peek();
        }
        public void Spawnlevel()
        {
            var val_21;
            var val_22;
            var val_23;
            var val_25;
            val_21 = this;
            this.lastRowSpawned = 0;
            if(this.sectionHolders == null)
            {
                goto label_2;
            }
            
            label_5:
            if(true <= 0)
            {
                goto label_2;
            }
            
            UnityEngine.Object.Destroy(obj:  this.sectionHolders.Dequeue());
            if(this.sectionHolders != null)
            {
                goto label_5;
            }
            
            label_2:
            UnityEngine.GameObject val_4 = new UnityEngine.GameObject(name:  "SectionHolder " + this.lastRowSpawned.ToString());
            val_4.transform.SetParent(p:  this.transform);
            this.sectionHolders.Enqueue(item:  val_4);
            val_22 = 0;
            val_23 = 2;
            goto label_10;
            label_48:
            new UnityEngine.GameObject(name:  "RowParent " + 0.ToString()).transform.SetParent(p:  val_4.transform);
            val_21 = 0;
            SLC.Minigames.SnackBlock.SnakeBlockManager val_19 = MonoSingleton<SLC.Minigames.SnackBlock.SnakeBlockManager>.Instance;
            val_25 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_22 = 1;
            label_10:
            SLC.Minigames.SnackBlock.SnakeBlockManager val_20 = MonoSingleton<SLC.Minigames.SnackBlock.SnakeBlockManager>.Instance;
            if(val_22 < val_20.myLevelData)
            {
                goto label_48;
            }
        
        }
        public void SpawnNextSections()
        {
            UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.SpawnNext());
        }
        private System.Collections.IEnumerator SpawnNext()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new SnakeBlockLevelStreamer.<SpawnNext>d__16();
        }
        private UnityEngine.GameObject SpawnThing(SLC.Minigames.SnackBlock.SnakeGridSpaceType type, float x, int y)
        {
            float val_10;
            UnityEngine.Transform val_11;
            var val_12;
            UnityEngine.Object val_14;
            UnityEngine.GameObject val_15;
            val_10 = x;
            val_11 = this;
            if((type - 1) <= 7)
            {
                    var val_10 = 32555536 + ((type - 1)) << 2;
                val_10 = val_10 + 32555536;
            }
            else
            {
                    val_12 = 0;
                val_14 = 0;
                val_15 = 0;
                if( == 0)
            {
                    return val_15;
            }
            
                UnityEngine.Vector3 val_4 = new UnityEngine.Vector3(x:  val_10, y:  (float)y, z:  0f);
                UnityEngine.Quaternion val_5 = UnityEngine.Quaternion.identity;
                val_10 = val_5.x;
                val_11 = this.sectionHolders.Peek().transform;
                val_15 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  null, position:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z}, rotation:  new UnityEngine.Quaternion() {x = val_10, y = val_5.y, z = val_5.z, w = val_5.w}, parent:  val_11);
                if( == 0)
            {
                    return val_15;
            }
            
                SLC.Minigames.SnackBlock.SnakeBlockManager val_9 = MonoSingleton<SLC.Minigames.SnackBlock.SnakeBlockManager>.Instance;
                val_9.avoidText = val_15;
                return val_15;
            }
        
        }
        public SnakeBlockLevelStreamer()
        {
            this.spriteWidth = 1.5f;
            this.sectionHolders = new System.Collections.Generic.Queue<UnityEngine.GameObject>();
        }
    
    }

}
