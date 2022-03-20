using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
    public class Blur : MonoBehaviour
    {
        // Fields
        public int iterations;
        public float blurSpread;
        public UnityEngine.Shader blurShader;
        private static UnityEngine.Material m_Material;
        
        // Properties
        protected UnityEngine.Material material { get; }
        
        // Methods
        protected UnityEngine.Material get_material()
        {
            UnityEngine.Material val_3;
            var val_4;
            var val_5;
            var val_6;
            val_3 = this;
            val_4 = null;
            val_4 = null;
            if(UnityStandardAssets.ImageEffects.Blur.m_Material == 0)
            {
                    UnityEngine.Material val_2 = null;
                val_3 = val_2;
                val_2 = new UnityEngine.Material(shader:  this.blurShader);
                val_5 = null;
                val_5 = null;
                UnityStandardAssets.ImageEffects.Blur.m_Material = val_3;
                val_2.hideFlags = 52;
            }
            
            val_6 = null;
            val_6 = null;
            return (UnityEngine.Material)UnityStandardAssets.ImageEffects.Blur.m_Material;
        }
        protected void OnDisable()
        {
            var val_2;
            var val_3;
            val_2 = null;
            val_2 = null;
            if((UnityEngine.Object.op_Implicit(exists:  UnityStandardAssets.ImageEffects.Blur.m_Material)) == false)
            {
                    return;
            }
            
            val_3 = null;
            val_3 = null;
            UnityEngine.Object.DestroyImmediate(obj:  UnityStandardAssets.ImageEffects.Blur.m_Material);
        }
        protected void Start()
        {
            if((UnityEngine.SystemInfo.supportsImageEffects != false) && ((UnityEngine.Object.op_Implicit(exists:  this.blurShader)) != false))
            {
                    if(this.material.shader.isSupported != false)
            {
                    return;
            }
            
            }
            
            this.enabled = false;
        }
        public void FourTapCone(UnityEngine.RenderTexture source, UnityEngine.RenderTexture dest, int iteration)
        {
            float val_8 = this.blurSpread;
            val_8 = val_8 * (float)iteration;
            float val_1 = val_8 + 0.5f;
            UnityEngine.Vector2[] val_3 = new UnityEngine.Vector2[4];
            UnityEngine.Vector2 val_4 = new UnityEngine.Vector2(x:  -val_1, y:  -val_1);
            val_3[0] = val_4.x;
            UnityEngine.Vector2 val_5 = new UnityEngine.Vector2(x:  -val_1, y:  val_1);
            val_3[1] = val_5.x;
            UnityEngine.Vector2 val_6 = new UnityEngine.Vector2(x:  val_1, y:  val_1);
            val_3[2] = val_6.x;
            UnityEngine.Vector2 val_7 = new UnityEngine.Vector2(x:  val_1, y:  -val_1);
            val_3[3] = val_7.x;
            UnityEngine.Graphics.BlitMultiTap(source:  source, dest:  dest, mat:  this.material, offsets:  val_3);
        }
        private void DownSample4x(UnityEngine.RenderTexture source, UnityEngine.RenderTexture dest)
        {
            UnityEngine.Vector2[] val_2 = new UnityEngine.Vector2[4];
            UnityEngine.Vector2 val_3 = new UnityEngine.Vector2(x:  -1f, y:  -1f);
            val_2[0] = val_3.x;
            UnityEngine.Vector2 val_4 = new UnityEngine.Vector2(x:  -1f, y:  1f);
            val_2[1] = val_4.x;
            UnityEngine.Vector2 val_5 = new UnityEngine.Vector2(x:  1f, y:  1f);
            UnityEngine.Vector2 val_6;
            val_2[2] = val_5.x;
            val_6 = new UnityEngine.Vector2(x:  1f, y:  -1f);
            val_2[3] = val_6.x;
            UnityEngine.Graphics.BlitMultiTap(source:  source, dest:  dest, mat:  this.material, offsets:  val_2);
        }
        private void OnRenderImage(UnityEngine.RenderTexture source, UnityEngine.RenderTexture destination)
        {
            UnityEngine.RenderTexture val_9;
            int val_3 = ((source < 0) ? (source + 7) : source) >> 3;
            int val_6 = ((source < 0) ? (source + 7) : source) >> 3;
            UnityEngine.RenderTexture val_7 = UnityEngine.RenderTexture.GetTemporary(width:  val_3, height:  val_6, depthBuffer:  0);
            this.DownSample4x(source:  source, dest:  val_7);
            if(this.iterations >= 1)
            {
                    var val_9 = 0;
                do
            {
                val_9 = UnityEngine.RenderTexture.GetTemporary(width:  val_3, height:  val_6, depthBuffer:  0);
                this.FourTapCone(source:  val_7, dest:  val_9, iteration:  0);
                UnityEngine.RenderTexture.ReleaseTemporary(temp:  val_7);
                val_9 = val_9 + 1;
            }
            while(val_9 < this.iterations);
            
            }
            else
            {
                    val_9 = val_7;
            }
            
            UnityEngine.Graphics.Blit(source:  val_9, dest:  destination);
            UnityEngine.RenderTexture.ReleaseTemporary(temp:  val_9);
        }
        public Blur()
        {
            this.iterations = 3;
            this.blurSpread = 5.510186E-41f;
        }
        private static Blur()
        {
        
        }
    
    }

}
