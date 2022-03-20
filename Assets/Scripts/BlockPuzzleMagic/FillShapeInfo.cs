using UnityEngine;

namespace BlockPuzzleMagic
{
    public class FillShapeInfo : GridPlaceableShapeInfo
    {
        // Methods
        public override void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData)
        {
            if(BlockPuzzleMagic.ShapeInfo.IsRotationAllowed == false)
            {
                    return;
            }
            
            this.RotateShape(isClockwise:  true, skipAnimate:  false);
            MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance.NotifyShapeRotated(shape:  this);
        }
        public override void ResolveAction()
        {
            if(true != 0)
            {
                    return;
            }
            
            if(X21 == 0)
            {
                    return;
            }
            
            var val_2 = 0;
            do
            {
                if(val_2 >= (X21 + 24))
            {
                    return;
            }
            
                if((X21 + 24) <= val_2)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                var val_1 = X21 + 16;
                val_1 = val_1 + 0;
                (X21 + 16 + 0) + 32.AddBlockColorFill(blockColor:  X21 + 24 + 16);
                val_2 = val_2 + 1;
            }
            while(X21 != 0);
            
            throw new NullReferenceException();
        }
        public FillShapeInfo()
        {
        
        }
    
    }

}
