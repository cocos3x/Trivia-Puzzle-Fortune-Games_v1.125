using UnityEngine;

namespace SG
{
    internal class Pool
    {
        // Fields
        private System.Collections.Generic.Stack<SG.PoolObject> availableObjStack;
        private UnityEngine.GameObject rootObj;
        private SG.PoolInflationType inflationType;
        private string poolName;
        private int objectsInUse;
        
        // Methods
        public Pool(string poolName, UnityEngine.GameObject poolObjectPrefab, UnityEngine.GameObject rootPoolObj, int initialCount, SG.PoolInflationType type)
        {
            SG.PoolObject val_13;
            this.availableObjStack = new System.Collections.Generic.Stack<SG.PoolObject>();
            val_2 = new System.Object();
            if(val_2 == 0)
            {
                    return;
            }
            
            this.poolName = poolName;
            this.inflationType = type;
            UnityEngine.GameObject val_5 = new UnityEngine.GameObject(name:  poolName + "Pool");
            this.rootObj = val_5;
            val_5.transform.SetParent(parent:  rootPoolObj.transform, worldPositionStays:  false);
            UnityEngine.GameObject val_8 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  UnityEngine.GameObject val_2 = poolObjectPrefab);
            SG.PoolObject val_9 = val_8.GetComponent<SG.PoolObject>();
            val_13 = val_9;
            if(val_9 == 0)
            {
                    val_13 = val_8.AddComponent<SG.PoolObject>();
            }
            
            val_11.poolName = poolName;
            this.AddObjectToPool(po:  val_13);
            this.populatePool(initialCount:  UnityEngine.Mathf.Max(a:  initialCount, b:  1));
        }
        private void AddObjectToPool(SG.PoolObject po)
        {
            po.gameObject.SetActive(value:  false);
            po.gameObject.name = this.poolName;
            this.availableObjStack.Push(item:  po);
            po.isPooled = true;
            po.gameObject.transform.SetParent(parent:  this.rootObj.transform, worldPositionStays:  false);
        }
        private void populatePool(int initialCount)
        {
            SG.PoolObject val_3;
            if(initialCount < 1)
            {
                    return;
            }
            
            var val_3 = 0;
            do
            {
                val_3 = this.availableObjStack.Peek();
                this.AddObjectToPool(po:  UnityEngine.Object.Instantiate<SG.PoolObject>(original:  val_3));
                val_3 = val_3 + 1;
            }
            while(val_3 < initialCount);
        
        }
        public UnityEngine.GameObject NextAvailableObject(bool autoActive)
        {
            var val_6;
            UnityEngine.Object val_7;
            var val_8;
            if(W22 >= 2)
            {
                goto label_2;
            }
            
            if(this.inflationType == 0)
            {
                goto label_3;
            }
            
            if(this.inflationType != 1)
            {
                goto label_4;
            }
            
            val_6 = (UnityEngine.Mathf.Max(a:  this.objectsInUse, b:  0)) + W22;
            if(val_6 >= 1)
            {
                goto label_7;
            }
            
            label_4:
            val_7 = 0;
            goto label_8;
            label_3:
            val_6 = 1;
            label_7:
            this.populatePool(initialCount:  1);
            label_2:
            val_7 = this.availableObjStack.Pop();
            label_8:
            val_8 = 0;
            if(val_7 == 0)
            {
                    return (UnityEngine.GameObject)val_8;
            }
            
            int val_5 = this.objectsInUse;
            val_5 = val_5 + 1;
            this.objectsInUse = val_5;
            val_2.isPooled = false;
            val_8 = val_7.gameObject;
            if(autoActive == false)
            {
                    return (UnityEngine.GameObject)val_8;
            }
            
            val_8.SetActive(value:  true);
            return (UnityEngine.GameObject)val_8;
        }
        public void ReturnObjectToPool(SG.PoolObject po)
        {
            if((this.poolName.Equals(value:  po.poolName)) == false)
            {
                goto label_3;
            }
            
            int val_3 = this.objectsInUse;
            val_3 = val_3 - 1;
            this.objectsInUse = val_3;
            if(po.isPooled == false)
            {
                goto label_4;
            }
            
            return;
            label_3:
            UnityEngine.Debug.LogError(message:  System.String.Format(format:  "Trying to add object to incorrect pool {0} {1}", arg0:  po.poolName, arg1:  this.poolName));
            return;
            label_4:
            this.AddObjectToPool(po:  po);
        }
    
    }

}
