using UnityEngine;

namespace UnityEngine.UI
{
    public class LoopScrollSendIndexSource : LoopScrollDataSource
    {
        // Fields
        public static readonly UnityEngine.UI.LoopScrollSendIndexSource Instance;
        
        // Methods
        private LoopScrollSendIndexSource()
        {
            val_1 = new System.Object();
        }
        public override void ProvideData(UnityEngine.Transform transform, int idx)
        {
            transform.SendMessage(methodName:  "ScrollCellIndex", value:  idx);
        }
        private static LoopScrollSendIndexSource()
        {
            UnityEngine.UI.LoopScrollSendIndexSource.Instance = new UnityEngine.UI.LoopScrollSendIndexSource();
        }
    
    }

}
