using UnityEngine;

namespace SRDebugger
{
    public class SRDebuggerInit : SRMonoBehaviourEx
    {
        // Methods
        protected override void Awake()
        {
            this.Awake();
            SRDebugger.Settings val_1 = SRDebugger.Settings.Instance;
            if(val_1._isEnabled == false)
            {
                    return;
            }
            
            SRDebug.Init();
        }
        protected override void Start()
        {
            this.Start();
            UnityEngine.Object.Destroy(obj:  this.CachedGameObject);
        }
        public SRDebuggerInit()
        {
        
        }
    
    }

}
