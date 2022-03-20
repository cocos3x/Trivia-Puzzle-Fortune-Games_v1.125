using UnityEngine;

namespace AudienceNetwork
{
    public class AdHandler : MonoBehaviour
    {
        // Fields
        private static readonly System.Collections.Generic.Queue<System.Action> executeOnMainThreadQueue;
        
        // Methods
        public void ExecuteOnMainThread(System.Action action)
        {
            var val_2;
            var val_3;
            val_2 = null;
            val_2 = null;
            bool val_1 = false;
            System.Threading.Monitor.Enter(obj:  AudienceNetwork.AdHandler.executeOnMainThreadQueue, lockTaken: ref  val_1);
            val_3 = null;
            val_3 = null;
            AudienceNetwork.AdHandler.executeOnMainThreadQueue.Enqueue(item:  action);
            if(val_1 != 0)
            {
                    System.Threading.Monitor.Exit(obj:  AudienceNetwork.AdHandler.executeOnMainThreadQueue);
            }
            
            if(0 != 0)
            {
                    throw 0;
            }
        
        }
        private void Update()
        {
            var val_5;
            System.Collections.Generic.Queue<System.Action> val_6;
            var val_7;
            var val_5 = 0;
            do
            {
                label_14:
                val_5 = null;
                val_5 = null;
                val_6 = AudienceNetwork.AdHandler.executeOnMainThreadQueue;
                if((AudienceNetwork.AdHandler.executeOnMainThreadQueue + 32) <= 0)
            {
                    return;
            }
            
                val_6 = AudienceNetwork.AdHandler.executeOnMainThreadQueue;
                bool val_1 = false;
                System.Threading.Monitor.Enter(obj:  val_6, lockTaken: ref  val_1);
                val_7 = null;
                val_7 = null;
                if(AudienceNetwork.AdHandler.executeOnMainThreadQueue == null)
            {
                    throw new NullReferenceException();
            }
            
                System.Action val_2 = AudienceNetwork.AdHandler.executeOnMainThreadQueue.Dequeue();
                val_5 = val_5 + 1;
                mem2[0] = 50;
                if(val_1 != 0)
            {
                    System.Threading.Monitor.Exit(obj:  val_6);
            }
            
                if(0 != 0)
            {
                    throw ???;
            }
            
                if(val_5 != 1)
            {
                    var val_3 = ((1152921520211208672 + ((0 + 1)) << 2) == 50) ? 1 : 0;
                val_3 = ((val_5 >= 0) ? 1 : 0) & val_3;
                val_5 = val_5 - val_3;
            }
            
            }
            while(val_2 == null);
            
            val_2.Invoke();
            goto label_14;
        }
        public void RemoveFromParent()
        {
            UnityEngine.Object.Destroy(obj:  this);
        }
        public AdHandler()
        {
        
        }
        private static AdHandler()
        {
            AudienceNetwork.AdHandler.executeOnMainThreadQueue = new System.Collections.Generic.Queue<System.Action>();
        }
    
    }

}
