using UnityEngine;

namespace BlockPuzzleMagic
{
    public class MovesDisplayUI : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Text countLabel;
        private System.Collections.Generic.List<UnityEngine.UI.Image> starIconFrames;
        private System.Collections.Generic.List<UnityEngine.UI.Image> starIcons;
        private UnityEngine.ParticleSystem efxStarDisspiate;
        private UnityEngine.ParticleSystem efxStarPulsate;
        private UnityEngine.ParticleSystem efxStarExplode;
        private int currentMoves;
        private int currentStars;
        private bool hasDisplayInitialized;
        
        // Methods
        private void Start()
        {
            BlockPuzzleMagic.GamePlay val_1 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnLevelDataInitialized, b:  new System.Action<BlockPuzzleMagic.Level>(object:  this, method:  System.Void BlockPuzzleMagic.MovesDisplayUI::OnLevelInitialized(BlockPuzzleMagic.Level level)));
            if(val_3 != null)
            {
                    if(null != null)
            {
                goto label_8;
            }
            
            }
            
            val_1.OnLevelDataInitialized = val_3;
            BlockPuzzleMagic.GamePlay val_4 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            System.Delegate val_6 = System.Delegate.Combine(a:  val_4.OnShapePlaced, b:  new System.Action<BlockPuzzleMagic.ShapeInfo>(object:  this, method:  System.Void BlockPuzzleMagic.MovesDisplayUI::OnShapePlaced(BlockPuzzleMagic.ShapeInfo shapeInfo)));
            if(val_6 != null)
            {
                    if(null != null)
            {
                goto label_8;
            }
            
            }
            
            val_4.OnShapePlaced = val_6;
            return;
            label_8:
        }
        private void OnDestroy()
        {
            System.Action<BlockPuzzleMagic.ShapeInfo> val_9;
            var val_10;
            val_9 = 1152921504893161472;
            val_10 = 1152921513393502304;
            if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance) == 0)
            {
                    return;
            }
            
            BlockPuzzleMagic.GamePlay val_3 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            System.Delegate val_5 = System.Delegate.Remove(source:  val_3.OnLevelDataInitialized, value:  new System.Action<BlockPuzzleMagic.Level>(object:  this, method:  System.Void BlockPuzzleMagic.MovesDisplayUI::OnLevelInitialized(BlockPuzzleMagic.Level level)));
            if(val_5 != null)
            {
                    if(null != null)
            {
                goto label_13;
            }
            
            }
            
            val_3.OnLevelDataInitialized = val_5;
            BlockPuzzleMagic.GamePlay val_6 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            val_9 = val_6.OnShapePlaced;
            val_10 = 1152921504614248448;
            System.Delegate val_8 = System.Delegate.Remove(source:  val_9, value:  new System.Action<BlockPuzzleMagic.ShapeInfo>(object:  this, method:  System.Void BlockPuzzleMagic.MovesDisplayUI::OnShapePlaced(BlockPuzzleMagic.ShapeInfo shapeInfo)));
            if(val_8 != null)
            {
                    if(null != null)
            {
                goto label_13;
            }
            
            }
            
            val_6.OnShapePlaced = val_8;
            return;
            label_13:
        }
        private void OnLevelInitialized(BlockPuzzleMagic.Level level)
        {
            this.hasDisplayInitialized = false;
            this.RefreshContent(animated:  false);
            this.hasDisplayInitialized = true;
        }
        private void OnShapePlaced(BlockPuzzleMagic.ShapeInfo shapeInfo)
        {
            this.RefreshContent(animated:  false);
        }
        private void RefreshContent(bool animated = False)
        {
            int val_33;
            int val_34;
            int val_35;
            var val_36;
            object val_37;
            var val_38;
            float val_39;
            BlockPuzzleMagic.GamePlay val_1 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            val_33 = val_1.currentLevel.movesMade;
            if(this.currentMoves == val_33)
            {
                    return;
            }
            
            this.currentMoves = val_33;
            BlockPuzzleMagic.BestBlocksGameEcon val_2 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
            if(val_33 <= val_2.starThreshold1)
            {
                goto label_9;
            }
            
            BlockPuzzleMagic.BestBlocksGameEcon val_3 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
            if(val_33 <= val_3.starThreshold2)
            {
                goto label_13;
            }
            
            val_34 = 1;
            this.currentStars = val_34;
            val_33 = 0;
            val_35 = 0;
            val_36 = 0;
            val_37 = "∞";
            goto label_14;
            label_9:
            BlockPuzzleMagic.BestBlocksGameEcon val_4 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
            val_35 = val_4.starThreshold1;
            val_34 = 3;
            goto label_18;
            label_13:
            BlockPuzzleMagic.BestBlocksGameEcon val_5 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
            BlockPuzzleMagic.BestBlocksGameEcon val_6 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
            BlockPuzzleMagic.BestBlocksGameEcon val_7 = BlockPuzzleMagic.BestBlocksGameEcon.Instance;
            val_35 = val_5.starThreshold2 - val_6.starThreshold1;
            val_34 = 2;
            val_33 = val_33 - val_7.starThreshold1;
            label_18:
            this.currentStars = val_34;
            if(this.hasDisplayInitialized != false)
            {
                    WGFTUXManager val_8 = MonoSingleton<WGFTUXManager>.Instance;
                if(val_8.currDemoWindow == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
                this.efxStarDisspiate.transform.SetParent(p:  (UnityEngine.Object.__il2cppRuntimeField_cctor_finished + (val_34 - 1)) + 32.transform);
                var val_37 = null;
                UnityEngine.Vector3 val_14 = UnityEngine.Vector3.zero;
                this.efxStarDisspiate.transform.localPosition = new UnityEngine.Vector3() {x = val_14.x, y = val_14.y, z = val_14.z};
                this.efxStarDisspiate.Stop();
                this.efxStarDisspiate.Play();
                if(val_37 <= (val_34 - 1))
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_37 = val_37 + (((val_34 - 1)) << 3);
                this.efxStarExplode.transform.SetParent(p:  (null + ((val_34 - 1)) << 3) + 32.transform);
                UnityEngine.Vector3 val_18 = UnityEngine.Vector3.zero;
                this.efxStarExplode.transform.localPosition = new UnityEngine.Vector3() {x = val_18.x, y = val_18.y, z = val_18.z};
                this.efxStarExplode.Stop();
                this.efxStarExplode.Play();
            }
            
            }
            
            val_37 = val_35 - val_33.ToString();
            val_36 = 1;
            label_14:
            string val_21 = System.String.Format(format:  "MOVES: {0}", arg0:  val_37);
            float val_38 = (float)val_33;
            val_38 = val_38 / (float)val_35;
            float val_23 = 1f - val_38;
            var val_24 = (val_23 > 0f) ? 1 : 0;
            var val_25 = val_34 - 1;
            var val_39 = 4;
            label_83:
            var val_28 = val_39 - 4;
            if(val_28 >= val_24)
            {
                    return;
            }
            
            var val_30 = (((-val_25) + val_39) != 4) ? 1 : 0;
            val_30 = val_36 ^ 1 | val_30;
            if((val_30 & 1) != 0)
            {
                goto label_54;
            }
            
            if((val_24 & ((val_23 < 0) ? 1 : 0)) == 0)
            {
                goto label_56;
            }
            
            if(val_24 <= val_25)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_24 = val_24 + (((val_34 - 1)) << 3);
            this.efxStarPulsate.transform.SetParent(p:  (val_23 > 0 ? 1 : 0 + ((val_34 - 1)) << 3) + 32.transform);
            UnityEngine.Vector2 val_34 = new UnityEngine.Vector2(x:  0f, y:  9f);
            if(null != null)
            {
                goto label_63;
            }
            
            this.efxStarPulsate.transform.anchoredPosition = new UnityEngine.Vector2() {x = val_34.x, y = val_34.y};
            if(this.efxStarPulsate.isPlaying == true)
            {
                goto label_67;
            }
            
            this.efxStarPulsate.Play();
            goto label_67;
            label_54:
            val_24 = val_24 & 4294967295;
            if(val_28 >= val_24)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            if(val_28 >= val_34)
            {
                goto label_70;
            }
            
            (val_23 > 0 ? 1 : 0 & 4294967295) + 32.fillAmount = 1f;
            if(val_28 >= val_24)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_38 = mem[(val_23 > 0 ? 1 : 0 & 4294967295) + 32];
            val_38 = (val_23 > 0 ? 1 : 0 & 4294967295) + 32;
            goto label_73;
            label_56:
            this.efxStarPulsate.Stop();
            label_67:
            if(val_24 <= val_25)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_24 = val_24 + (((val_34 - 1)) << 3);
            (val_23 > 0 ? 1 : 0 + ((val_34 - 1)) << 3) + 32.fillAmount = val_23;
            if(val_24 <= val_25)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_24 = val_24 + (((val_34 - 1)) << 3);
            val_38 = mem[((val_23 > 0 ? 1 : 0 + ((val_34 - 1)) << 3) + ((val_34 - 1)) << 3) + 32];
            val_38 = ((val_23 > 0 ? 1 : 0 + ((val_34 - 1)) << 3) + ((val_34 - 1)) << 3) + 32;
            label_73:
            val_39 = 0.54f;
            goto label_79;
            label_70:
            (val_23 > 0 ? 1 : 0 & 4294967295) + 32.fillAmount = 0f;
            if(val_28 >= val_24)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            UnityEngine.Color val_36;
            val_39 = 0.125f;
            val_38 = mem[(val_23 > 0 ? 1 : 0 & 4294967295) + 32];
            val_38 = (val_23 > 0 ? 1 : 0 & 4294967295) + 32;
            label_79:
            val_36 = new UnityEngine.Color(r:  0.125f, g:  val_39, b:  0.125f, a:  1f);
            val_39 = val_39 + 1;
            if(this.starIcons != null)
            {
                goto label_83;
            }
            
            throw new NullReferenceException();
            label_63:
        }
        public MovesDisplayUI()
        {
            this.currentMoves = -1;
            this.currentStars = -1;
        }
    
    }

}
