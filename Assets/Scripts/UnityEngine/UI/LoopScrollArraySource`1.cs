using UnityEngine;

namespace UnityEngine.UI
{
    public class LoopScrollArraySource<T> : LoopScrollDataSource
    {
        // Fields
        private T[] objectsToFill;
        
        // Methods
        public LoopScrollArraySource<T>(T[] objectsToFill)
        {
            mem[1152921520062103136] = objectsToFill;
        }
        public override void ProvideData(UnityEngine.Transform transform, int idx)
        {
            bool val_1 = true;
            val_1 = val_1 + (idx << 3);
            transform.SendMessage(methodName:  "ScrollCellContent", value:  (true + (idx) << 3) + 32);
        }
    
    }

}
