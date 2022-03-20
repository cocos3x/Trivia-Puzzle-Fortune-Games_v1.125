using UnityEngine;

namespace LeTai.Asset.TranslucentImage
{
    public class TranslucentImageSource : MonoBehaviour
    {
        // Fields
        public float maxUpdateRate;
        public bool preview;
        private float size;
        private int iteration;
        private int maxDepth;
        private int downsample;
        private int lastDownsample;
        private float strength;
        private float lastUpdate;
        private UnityEngine.Camera camera;
        private UnityEngine.Shader shader;
        private UnityEngine.Material material;
        private UnityEngine.RenderTexture <BlurredScreen>k__BackingField;
        
        // Properties
        public UnityEngine.RenderTexture BlurredScreen { get; set; }
        public UnityEngine.Camera Cam { get; }
        public float Strength { get; set; }
        public float Size { get; set; }
        public int Iteration { get; set; }
        public int Downsample { get; set; }
        public int MaxDepth { get; set; }
        private float ScreenSize { get; }
        private float MinUpdateCycle { get; }
        
        // Methods
        public UnityEngine.RenderTexture get_BlurredScreen()
        {
            return (UnityEngine.RenderTexture)this.<BlurredScreen>k__BackingField;
        }
        private void set_BlurredScreen(UnityEngine.RenderTexture value)
        {
            this.<BlurredScreen>k__BackingField = value;
        }
        public UnityEngine.Camera get_Cam()
        {
            if(this.camera != null)
            {
                    return val_1;
            }
            
            UnityEngine.Camera val_1 = this.GetComponent<UnityEngine.Camera>();
            this.camera = val_1;
            return val_1;
        }
        public float get_Strength()
        {
            int val_1 = this.downsample + this.iteration;
            float val_2 = 1f;
            val_2 = this.size * val_2;
            this.strength = val_2;
            return val_2;
        }
        public void set_Strength(float value)
        {
            this.strength = UnityEngine.Mathf.Max(a:  0f, b:  value);
            goto typeof(LeTai.Asset.TranslucentImage.TranslucentImageSource).__il2cppRuntimeField_170;
        }
        public float get_Size()
        {
            return (float)this.size;
        }
        public void set_Size(float value)
        {
            this.size = UnityEngine.Mathf.Max(a:  0f, b:  value);
        }
        public int get_Iteration()
        {
            return (int)this.iteration;
        }
        public void set_Iteration(int value)
        {
            this.iteration = UnityEngine.Mathf.Max(a:  0, b:  value);
        }
        public int get_Downsample()
        {
            return (int)this.downsample;
        }
        public void set_Downsample(int value)
        {
            this.downsample = UnityEngine.Mathf.Max(a:  0, b:  value);
        }
        public int get_MaxDepth()
        {
            return (int)this.maxDepth;
        }
        public void set_MaxDepth(int value)
        {
            this.maxDepth = UnityEngine.Mathf.Max(a:  1, b:  value);
        }
        private float get_ScreenSize()
        {
            float val_6 = 1080f;
            val_6 = ((float)UnityEngine.Mathf.Min(a:  this.Cam.pixelWidth, b:  this.Cam.pixelHeight)) / val_6;
            return (float)val_6;
        }
        private float get_MinUpdateCycle()
        {
            float val_2 = this.maxUpdateRate;
            float val_1 = 1f;
            val_1 = val_1 / val_2;
            val_2 = (val_2 <= 0f) ? Infinityf : (val_1);
            return (float)val_2;
        }
        protected virtual void SetAdvancedFieldFromSimple()
        {
            float val_5;
            int val_1 = this.downsample + this.iteration;
            float val_5 = 1f;
            val_5 = this.strength / val_5;
            this.Size = val_5;
            val_5 = this.size;
            if(val_5 >= 0)
            {
                goto label_3;
            }
            
            if(val_5 < 1f)
            {
                goto label_4;
            }
            
            this.Downsample = this.downsample - 1;
            goto label_5;
            label_4:
            if(val_5 < 1f)
            {
                goto label_6;
            }
            
            this.Iteration = this.iteration - 1;
            label_5:
            float val_6 = this.size;
            val_6 = val_6 + val_6;
            this.Size = val_6;
            label_6:
            val_5 = this.size;
            label_3:
            if(val_5 <= 8f)
            {
                    return;
            }
            
            do
            {
                val_5 = val_5 * 0.5f;
                this.Size = val_5;
                this.Iteration = this.iteration + 1;
            }
            while(this.size > 8f);
        
        }
        protected virtual void Start()
        {
            this.camera = this.Cam;
            UnityEngine.Shader val_2 = UnityEngine.Shader.Find(name:  "Hidden/EfficientBlur");
            this.shader = val_2;
            if(val_2.isSupported != true)
            {
                    this.enabled = false;
            }
            
            this.material = new UnityEngine.Material(shader:  this.shader);
            UnityEngine.RenderTexture val_11 = new UnityEngine.RenderTexture(width:  this.Cam.pixelWidth >> this.downsample, height:  this.Cam.pixelHeight >> this.downsample, depth:  0);
            val_11.filterMode = 1;
            this.<BlurredScreen>k__BackingField = val_11;
            this.lastDownsample = this.downsample;
        }
        protected virtual void ProgressiveResampling(UnityEngine.RenderTexture source, int level, ref UnityEngine.RenderTexture target)
        {
            int val_1 = UnityEngine.Mathf.Min(a:  level, b:  this.maxDepth);
            int val_7 = this.downsample;
            val_7 = val_7 + val_1;
            UnityEngine.RenderTexture val_6 = UnityEngine.RenderTexture.GetTemporary(width:  source >> (this.downsample + val_1), height:  source >> val_7, depthBuffer:  0, format:  source.format);
            val_6.filterMode = 1;
            UnityEngine.Graphics.Blit(source:  target, dest:  val_6, mat:  this.material, pass:  0);
            UnityEngine.RenderTexture.ReleaseTemporary(temp:  target);
            target = val_6;
        }
        protected virtual void ProgressiveBlur(UnityEngine.RenderTexture source)
        {
            UnityEngine.RenderTexture val_18;
            UnityEngine.RenderTexture val_19;
            var val_20;
            var val_21;
            int val_22;
            if(this.downsample != this.lastDownsample)
            {
                goto label_1;
            }
            
            val_18 = this;
            val_19 = this.<BlurredScreen>k__BackingField;
            if(val_19 != null)
            {
                goto label_2;
            }
            
            label_1:
            UnityEngine.RenderTexture val_7 = null;
            val_19 = val_7;
            val_7 = new UnityEngine.RenderTexture(width:  this.Cam.pixelWidth >> this.downsample, height:  this.Cam.pixelHeight >> this.downsample, depth:  0);
            val_18 = this.<BlurredScreen>k__BackingField;
            this.<BlurredScreen>k__BackingField = val_19;
            this.lastDownsample = this.downsample;
            label_2:
            if(val_7.IsCreated() != false)
            {
                    mem[this.<BlurredScreen>k__BackingField].DiscardContents();
            }
            
            float val_9 = this.ScreenSize;
            val_9 = this.size * val_9;
            this.material.SetFloat(name:  "size", value:  val_9);
            if(this.iteration <= 0)
            {
                goto label_10;
            }
            
            val_20 = 1;
            if(source != null)
            {
                goto label_11;
            }
            
            label_10:
            val_20 = this.downsample & 31;
            label_11:
            UnityEngine.RenderTexture val_13 = UnityEngine.RenderTexture.GetTemporary(width:  source >> val_20, height:  source >> val_20, depthBuffer:  0, format:  source.format);
            val_13.filterMode = 1;
            source.filterMode = 1;
            val_21 = 0;
            UnityEngine.Graphics.Blit(source:  source, dest:  val_13, mat:  this.material, pass:  0);
            val_22 = this.iteration;
            if((val_22 + 1) >= 3)
            {
                    var val_17 = 2;
                do
            {
                val_22 = this.iteration;
                val_17 = val_17 + 1;
            }
            while(val_17 < (val_22 + 1));
            
            }
            
            int val_16 = val_22 - 1;
            if(val_16 >= 1)
            {
                    do
            {
                val_16 = val_16 - 1;
            }
            while(val_16 > 0);
            
            }
            
            UnityEngine.Graphics.Blit(source:  val_13, dest:  this.<BlurredScreen>k__BackingField, mat:  this.material, pass:  0);
            UnityEngine.RenderTexture.ReleaseTemporary(temp:  val_13);
        }
        protected virtual void OnRenderImage(UnityEngine.RenderTexture source, UnityEngine.RenderTexture destination)
        {
            UnityEngine.RenderTexture val_3;
            var val_4;
            val_3 = source;
            float val_1 = UnityEngine.Time.unscaledTime;
            float val_4 = this.maxUpdateRate;
            float val_3 = 1f;
            val_3 = val_3 / val_4;
            val_4 = (val_4 <= 0f) ? Infinityf : (val_3);
            val_1 = val_1 - this.lastUpdate;
            if(val_1 >= val_4)
            {
                    this.lastUpdate = UnityEngine.Time.unscaledTime;
            }
            
            if(this.preview != false)
            {
                    val_4 = 1152921504759189504;
                val_3 = this.<BlurredScreen>k__BackingField;
            }
            else
            {
                    val_4 = 1152921504759189504;
            }
            
            UnityEngine.Graphics.Blit(source:  val_3, dest:  destination);
        }
        public TranslucentImageSource()
        {
            this.maxUpdateRate = Infinityf;
            this.size = 5f;
            this.iteration = 4;
            this.maxDepth = 0;
        }
    
    }

}
