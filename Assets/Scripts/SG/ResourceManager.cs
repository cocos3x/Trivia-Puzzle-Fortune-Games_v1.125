using UnityEngine;

namespace SG
{
    public class ResourceManager : MonoBehaviour
    {
        // Fields
        private System.Collections.Generic.Dictionary<string, SG.Pool> poolDict;
        private static SG.ResourceManager mInstance;
        
        // Properties
        public static SG.ResourceManager Instance { get; }
        
        // Methods
        public static SG.ResourceManager get_Instance()
        {
            var val_10;
            SG.ResourceManager val_11;
            var val_12;
            var val_13;
            var val_14;
            val_10 = null;
            val_10 = null;
            val_11 = SG.ResourceManager.mInstance;
            if(val_11 == 0)
            {
                    System.Type[] val_2 = new System.Type[1];
                val_2[0] = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
                UnityEngine.GameObject val_4 = new UnityEngine.GameObject(name:  "ResourceManager", components:  val_2);
                UnityEngine.Vector3 val_6 = new UnityEngine.Vector3(x:  9999999f, y:  9999999f, z:  9999999f);
                val_4.transform.localPosition = new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z};
                val_12 = null;
                val_11 = val_4.GetComponent<SG.ResourceManager>();
                val_12 = null;
                SG.ResourceManager.mInstance = val_11;
                if(UnityEngine.Application.isPlaying != false)
            {
                    val_13 = null;
                val_13 = null;
                val_11 = SG.ResourceManager.mInstance.gameObject;
                UnityEngine.Object.DontDestroyOnLoad(target:  val_11);
            }
            else
            {
                    UnityEngine.Debug.LogWarning(message:  "[ResourceManager] You\'d better ignore ResourceManager in Editor mode");
            }
            
            }
            
            val_14 = null;
            val_14 = null;
            return (SG.ResourceManager)SG.ResourceManager.mInstance;
        }
        public void InitPool(UnityEngine.GameObject poolPrefab, int size, SG.PoolInflationType type = 1)
        {
            if(poolPrefab == 0)
            {
                    UnityEngine.Debug.LogError(message:  "[ResourceManager] null prefab for pooling.");
                return;
            }
            
            string val_2 = poolPrefab.name;
            if((this.poolDict.ContainsKey(key:  val_2)) != false)
            {
                    return;
            }
            
            this.poolDict.set_Item(key:  val_2, value:  new SG.Pool(poolName:  val_2, poolObjectPrefab:  poolPrefab, rootPoolObj:  this.gameObject, initialCount:  size, type:  type));
        }
        public UnityEngine.GameObject GetObjectFromPool(UnityEngine.GameObject poolPrefab, bool autoActive = True, int autoCreate = 0)
        {
            string val_1 = poolPrefab.name;
            if((autoCreate >= 1) && ((this.poolDict.ContainsKey(key:  val_1)) != true))
            {
                    this.InitPool(poolPrefab:  poolPrefab, size:  autoCreate, type:  0);
            }
            
            if((this.poolDict.ContainsKey(key:  val_1)) == false)
            {
                    return 0;
            }
            
            return this.poolDict.Item[val_1].NextAvailableObject(autoActive:  autoActive);
        }
        public void ReturnObjectToPool(UnityEngine.GameObject go)
        {
            SG.PoolObject val_1 = go.GetComponent<SG.PoolObject>();
            if(val_1 == 0)
            {
                    return;
            }
            
            if((this.poolDict.TryGetValue(key:  val_1.poolName, value: out  0)) == false)
            {
                    return;
            }
            
            val_3.ReturnObjectToPool(po:  val_1);
        }
        public void ReturnTransformToPool(UnityEngine.Transform t)
        {
            if(t == 0)
            {
                    return;
            }
            
            this.ReturnObjectToPool(go:  t.gameObject);
        }
        public ResourceManager()
        {
            this.poolDict = new System.Collections.Generic.Dictionary<System.String, SG.Pool>();
        }
        private static ResourceManager()
        {
        
        }
    
    }

}
