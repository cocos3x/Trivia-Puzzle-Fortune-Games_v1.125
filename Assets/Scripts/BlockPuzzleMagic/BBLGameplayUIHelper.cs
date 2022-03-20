using UnityEngine;

namespace BlockPuzzleMagic
{
    public class BBLGameplayUIHelper
    {
        // Methods
        public static void ShowGameplayOverlay(UnityEngine.Transform[] contentToShow)
        {
            UnityEngine.Color val_1 = new UnityEngine.Color(r:  0f, g:  0f, b:  0f, a:  0.785f);
            BlockPuzzleMagic.BBLGameplayUIHelper.ShowGameplayOverlay(bgColor:  new UnityEngine.Color() {r = val_1.r, g = val_1.g, b = val_1.b, a = val_1.a}, setBgColorInstantly:  false, contentToShow:  contentToShow);
        }
        public static void ShowGameplayOverlay(UnityEngine.Color bgColor, UnityEngine.Transform[] contentToShow)
        {
            BlockPuzzleMagic.BBLGameplayUIHelper.ShowGameplayOverlay(bgColor:  new UnityEngine.Color() {r = bgColor.r, g = bgColor.g, b = bgColor.b, a = bgColor.a}, setBgColorInstantly:  false, contentToShow:  contentToShow);
        }
        public static void ShowGameplayOverlay(UnityEngine.Color bgColor, bool setBgColorInstantly = False, UnityEngine.Transform[] contentToShow)
        {
            MonoSingleton<GameMaskOverlay>.Instance.Interactable = true;
            MonoSingleton<GameMaskOverlay>.Instance.BlockRaycasts = true;
            GameMaskOverlay val_3 = MonoSingleton<GameMaskOverlay>.Instance;
            System.Nullable<UnityEngine.Color> val_4 = new System.Nullable<UnityEngine.Color>(value:  new UnityEngine.Color() {r = bgColor.r, g = bgColor.g, b = bgColor.b, a = bgColor.a});
            if(setBgColorInstantly != false)
            {
                    if(val_3 != null)
            {
                goto label_6;
            }
            
            }
            
            label_6:
            val_3.SetOptions(bgColor:  new System.Nullable<UnityEngine.Color>() {HasValue = true}, fadeInDuration:  0.15f, fadeOutDuration:  0.15f);
            MonoSingleton<GameMaskOverlay>.Instance.ShowOverlay(contentToOverlay:  contentToShow);
            UnityEngine.Transform[] val_7 = new UnityEngine.Transform[1];
            BlockPuzzleMagic.GamePlay val_8 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            val_7[0] = val_8.floatingShapesLayer;
            MonoSingleton<GameMaskOverlay>.Instance.ShowOverlay(contentToOverlay:  val_7);
        }
        public static void CloseGameplayOverlay(bool immediate = False, System.Action onOverlayClosed)
        {
            MonoSingleton<GameMaskOverlay>.Instance.CloseOverlay(forceImmediate:  immediate, onClosed:  onOverlayClosed);
        }
        public static void PlayLevelIntroAnimation(int pulseOrigin)
        {
            var val_7;
            System.Collections.Generic.List<System.Collections.Generic.List<System.Int32>> val_1 = BlockPuzzleMagic.BBLGameplayUIHelper.GetGridRingedPattern(center:  pulseOrigin);
            if(true < 1)
            {
                    return;
            }
            
            float val_7 = 0f;
            val_7 = val_7 * 0.055f;
            val_7 = 0;
            float val_2 = val_7 + 0f;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            var val_6 = 0 + 1;
        }
        public static void PlayLevelClearAnimation()
        {
            var val_9;
            System.Collections.Generic.List<System.Collections.Generic.List<System.Int32>> val_3 = BlockPuzzleMagic.BBLGameplayUIHelper.GetGridRingedPattern(center:  new int[9] {40, 44, 36, 0, 40, 8, 72, 80, 40}[(UnityEngine.Random.Range(min:  0, max:  val_1.Length)) << 2]);
            if((new int[9] {40, 44, 36, 0, 40, 8, 72, 80, 40}[(UnityEngine.Random.Range(min:  0, max:  val_1.Length)) << 2]) < 1)
            {
                    return;
            }
            
            float val_10 = 0f;
            val_10 = val_10 * 0.055f;
            val_9 = 0;
            float val_4 = val_10 + 0.25f;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            var val_8 = 0 + 1;
        }
        public static System.Collections.Generic.List<System.Collections.Generic.List<int>> GetGridRingedPattern(int center)
        {
            float val_32;
            BlockPuzzleMagic.GamePlay val_1 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            int val_3 = val_1.currentLevel.gridLayout.rowCount * W23;
            UnityEngine.Vector2 val_4 = BlockPuzzleMagic.GridLayout.GetColumnRowIndexFromGridIndex(gridIndex:  center);
            System.Collections.Generic.List<System.Collections.Generic.List<System.Int32>> val_5 = new System.Collections.Generic.List<System.Collections.Generic.List<System.Int32>>();
            if(((center & 2147483648) == 0) && (val_3 > center))
            {
                    System.Collections.Generic.List<System.Int32> val_6 = new System.Collections.Generic.List<System.Int32>();
                val_6.Add(item:  center);
                val_5.Add(item:  val_6);
            }
            
            var val_32 = 0;
            val_32 = val_32 + 1;
            System.Collections.Generic.List<System.Int32> val_7 = new System.Collections.Generic.List<System.Int32>();
            var val_8 = val_32 * W23;
            int val_9 = center - val_8;
            if(val_3 >= 0)
            {
                    val_7.Add(item:  val_9);
            }
            
            UnityEngine.Vector2 val_10 = BlockPuzzleMagic.GridLayout.GetColumnRowIndexFromGridIndex(gridIndex:  val_9);
            int val_11 = val_8 + center;
            val_32 = val_10.x;
            if(val_11 < val_3)
            {
                    val_7.Add(item:  val_11);
            }
            
            UnityEngine.Vector2 val_12 = BlockPuzzleMagic.GridLayout.GetColumnRowIndexFromGridIndex(gridIndex:  val_11);
            if(val_32 < 1)
            {
                    return val_5;
            }
            
            var val_34 = 0;
            do
            {
                float val_33 = val_32 + (-1f);
                float val_19 = (val_10.y + 1f) + 0f;
                val_33 = val_33 - 0f;
                UnityEngine.Vector2 val_20 = new UnityEngine.Vector2(x:  val_33, y:  val_19);
                UnityEngine.Vector2 val_22 = new UnityEngine.Vector2(x:  (val_32 + 1f) + 0f, y:  val_19);
                float val_23 = (val_12.y + (-1f)) - 0f;
                UnityEngine.Vector2 val_25 = new UnityEngine.Vector2(x:  (val_12.x + (-1f)) - 0f, y:  val_23);
                UnityEngine.Vector2 val_27 = new UnityEngine.Vector2(x:  (val_12.x + 1f) + 0f, y:  val_23);
                if((((val_20.x >= 0f) && (val_20.x < 0)) && (val_20.y >= 0f)) && (val_20.y <= val_4.y))
            {
                    val_7.Add(item:  BlockPuzzleMagic.GridLayout.GetGridIndexFromColumnRowIndex(gridColRow:  new UnityEngine.Vector2() {x = val_20.x, y = val_20.y}));
            }
            
                if((((val_22.x > val_4.x) && (val_22.x < 0)) && (val_22.y >= 0f)) && (val_22.y <= val_4.y))
            {
                    val_7.Add(item:  BlockPuzzleMagic.GridLayout.GetGridIndexFromColumnRowIndex(gridColRow:  new UnityEngine.Vector2() {x = val_22.x, y = val_22.y}));
            }
            
                if((((val_25.x >= 0f) && (val_25.x < 0)) && (val_25.y > val_4.y)) && (val_25.y < 0))
            {
                    val_7.Add(item:  BlockPuzzleMagic.GridLayout.GetGridIndexFromColumnRowIndex(gridColRow:  new UnityEngine.Vector2() {x = val_25.x, y = val_25.y}));
            }
            
                val_32 = val_27.x;
                if((((val_32 > val_4.x) && (val_32 < 0)) && (val_27.y > val_4.y)) && (val_27.y < 0))
            {
                    val_7.Add(item:  BlockPuzzleMagic.GridLayout.GetGridIndexFromColumnRowIndex(gridColRow:  new UnityEngine.Vector2() {x = val_32, y = val_27.y}));
            }
            
                val_34 = val_34 + 1;
            }
            while(val_34 < val_32);
            
            return val_5;
        }
        public BBLGameplayUIHelper()
        {
        
        }
    
    }

}
