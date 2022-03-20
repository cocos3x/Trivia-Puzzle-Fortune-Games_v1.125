using UnityEngine;

namespace UnityEngine.UI
{
    [Serializable]
    public class LoopScrollPrefabSource
    {
        // Fields
        public UnityEngine.GameObject poolPrefab;
        public int poolSize;
        private bool inited;
        
        // Methods
        public virtual UnityEngine.GameObject GetObject()
        {
            if(this.inited == true)
            {
                    return SG.ResourceManager.Instance.GetObjectFromPool(poolPrefab:  this.poolPrefab, autoActive:  true, autoCreate:  0);
            }
            
            SG.ResourceManager.Instance.InitPool(poolPrefab:  this.poolPrefab, size:  this.poolSize, type:  1);
            this.inited = true;
            return SG.ResourceManager.Instance.GetObjectFromPool(poolPrefab:  this.poolPrefab, autoActive:  true, autoCreate:  0);
        }
        public virtual void ReturnObject(UnityEngine.Transform go)
        {
            go.SendMessage(methodName:  "ScrollCellReturn", options:  1);
            SG.ResourceManager.Instance.ReturnObjectToPool(go:  go.gameObject);
        }
        public LoopScrollPrefabSource()
        {
            this.poolSize = 5;
        }
    
    }

}
