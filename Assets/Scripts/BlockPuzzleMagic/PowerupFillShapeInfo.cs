using UnityEngine;

namespace BlockPuzzleMagic
{
    public class PowerupFillShapeInfo : GridPlaceableShapeInfo
    {
        // Fields
        public const int SHAPE_ID = -101;
        
        // Methods
        protected override void Awake()
        {
            mem[1152921520200530904] = 100;
            this.Awake();
        }
        public override void Init(UnityEngine.Transform parent, UnityEngine.Vector3 worldPos, float scale, float alpha, string source, bool anima = True)
        {
            BlockPuzzleMagic.BlockColor val_2 = BlockPuzzleMagic.GameReferenceData.Instance.GetBlockColor(colorType:  1);
            bool val_3 = anima;
            goto typeof(BlockPuzzleMagic.PowerupFillShapeInfo).__il2cppRuntimeField_1E0;
        }
        public override void Init(BlockPuzzleMagic.BlockColor color, UnityEngine.Transform parent, UnityEngine.Vector3 worldPos, float scale, float alpha, string source, bool anima = True)
        {
            anima = anima;
            this.Init(color:  BlockPuzzleMagic.GameReferenceData.Instance.GetBlockColor(colorType:  1), parent:  parent, worldPos:  new UnityEngine.Vector3() {x = worldPos.x, y = worldPos.y, z = worldPos.z}, scale:  scale, alpha:  alpha, source:  source, anima:  anima);
        }
        public override void OnDrag(UnityEngine.EventSystems.PointerEventData eventData)
        {
            var val_5;
            this.OnDrag(eventData:  eventData);
            var val_6 = 0;
            do
            {
                var val_3 = static_value_02805018;
                val_3 = val_3 & 4294967295;
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
                var val_4 = mem[41963536];
                val_4 = val_4 + 0;
                if(((mem[41963536] + 0) + 32) != 0)
            {
                    if(val_6 >= ((mem[41963536] + 0) + 32 + 24))
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                var val_5 = (mem[41963536] + 0) + 32 + 16;
                val_5 = val_5 + 0;
                val_5 = ((mem[41963536] + 0) + 32 + 16 + 0) + 32.CanBeFilled;
            }
            else
            {
                    val_5 = 1;
            }
            
                this.FadeShapeBlock(index:  0, visible:  true);
                val_6 = val_6 + 1;
            }
            while(((mem[41963536] + 0) + 32) != 0);
            
            throw new NullReferenceException();
        }
        public override bool CanResolveAction()
        {
            return (bool)(38021 > 0) ? 1 : 0;
        }
        public override void ResolveAction()
        {
            if(X21 == 0)
            {
                    return;
            }
            
            var val_4 = 0;
            label_6:
            if(val_4 >= (X21 + 24))
            {
                goto label_2;
            }
            
            if((X21 + 24) <= val_4)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_3 = X21 + 16;
            val_3 = val_3 + 0;
            (X21 + 16 + 0) + 32.AddBlockColorFill(blockColor:  X21 + 24 + 16);
            val_4 = val_4 + 1;
            if(X21 != 0)
            {
                goto label_6;
            }
            
            label_2:
            MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance.UsePowerup(powerupType:  2, freeUsage:  false);
            MonoSingleton<BlockPuzzleMagic.BlockShapeSpawner>.Instance.RemovePowerupShape(index:  2);
        }
        public override void SnapBackAndReset(System.Action onComplete)
        {
            this.SnapBackAndReset(onComplete:  onComplete);
            var val_1 = 0;
            do
            {
                if(val_1 >= 38021)
            {
                    return;
            }
            
                this.FadeShapeBlock(index:  0, visible:  true);
                val_1 = val_1 + 1;
            }
            while(38021 != 0);
            
            throw new NullReferenceException();
        }
        private void FadeShapeBlock(int index, bool visible)
        {
            bool val_3 = true;
            if(val_3 <= index)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_3 = val_3 + (index << 3);
            DG.Tweening.Tweener val_2 = DG.Tweening.ShortcutExtensions46.DOFade(target:  (true + (index) << 3) + 32 + 32, endValue:  (visible != true) ? 1f : 0.35f, duration:  0.65f);
        }
        public PowerupFillShapeInfo()
        {
        
        }
    
    }

}
