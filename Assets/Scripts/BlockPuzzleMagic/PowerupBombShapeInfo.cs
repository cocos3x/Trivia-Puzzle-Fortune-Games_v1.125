using UnityEngine;

namespace BlockPuzzleMagic
{
    public class PowerupBombShapeInfo : GridPlaceableShapeInfo
    {
        // Fields
        public const int SHAPE_ID = -100;
        
        // Methods
        protected override void Awake()
        {
            mem[1152921520196977208] = 99;
            this.Awake();
        }
        public override bool CanResolveAction()
        {
            if(true == 0)
            {
                    return (bool)(38021 > 0) ? 1 : 0;
            }
            
            return MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance.CanUsePowerup(powerupType:  1, showStoreIfOOC:  true, oocDelay:  0f);
        }
        public override void ResolveAction()
        {
            if(true != 0)
            {
                    return;
            }
            
            if(true == 0)
            {
                    return;
            }
            
            MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance.UpdateGoalProgress(clearedBlocks:  null, skipRowColumnCheck:  true);
            var val_5 = 0;
            label_10:
            if(val_5 >= (X23 + 24))
            {
                goto label_7;
            }
            
            if((X23 + 24) <= val_5)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_4 = X23 + 16;
            val_4 = val_4 + 0;
            (X23 + 16 + 0) + 32.ClearCell(doAnimation:  true, animationDelay:  0f, ignoreBreaksRequired:  false);
            val_5 = val_5 + 1;
            if(X23 != 0)
            {
                goto label_10;
            }
            
            label_7:
            MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance.UsePowerup(powerupType:  1, freeUsage:  true);
            MonoSingleton<BlockPuzzleMagic.BlockShapeSpawner>.Instance.RemovePowerupShape(index:  1);
        }
        public PowerupBombShapeInfo()
        {
        
        }
    
    }

}
