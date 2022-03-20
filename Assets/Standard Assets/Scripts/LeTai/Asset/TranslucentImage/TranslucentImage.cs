using UnityEngine;

namespace LeTai.Asset.TranslucentImage
{
    public class TranslucentImage : Image, IMeshModifier
    {
        // Fields
        public LeTai.Asset.TranslucentImage.TranslucentImageSource source;
        public float vibrancy;
        public float brightness;
        public float flatten;
        private UnityEngine.Shader correctShader;
        private int vibrancyPropId;
        private int brightnessPropId;
        private int flattenPropId;
        private float oldVibrancy;
        private float oldBrightness;
        private float oldFlatten;
        public float spriteBlending;
        
        // Methods
        protected override void Start()
        {
            bool val_6;
            LeTai.Asset.TranslucentImage.TranslucentImageSource val_7;
            val_6 = static_value_02809055;
            val_6 = true;
            this.Start();
            this.PrepShader();
            val_7 = this.source;
            mem2[0] = this.vibrancy;
            this.oldFlatten = this.flatten;
            this.source = UnityEngine.Object.FindObjectOfType<LeTai.Asset.TranslucentImage.TranslucentImageSource>();
            this.material.SetTexture(name:  "_BlurTex", value:  this.source.<BlurredScreen>k__BackingField);
            UnityEngine.Canvas val_3 = this.canvas;
            val_3.additionalShaderChannels = val_3.additionalShaderChannels | 1;
        }
        private void PrepShader()
        {
            this.correctShader = UnityEngine.Shader.Find(name:  "UI/TranslucentImage");
            this.vibrancyPropId = UnityEngine.Shader.PropertyToID(name:  "_Vibrancy");
            this.brightnessPropId = UnityEngine.Shader.PropertyToID(name:  "_Brightness");
            this.flattenPropId = UnityEngine.Shader.PropertyToID(name:  "_Flatten");
        }
        protected void LateUpdate()
        {
            if((UnityEngine.Object.op_Implicit(exists:  this.source)) == false)
            {
                goto label_3;
            }
            
            if(this.IsActive() == false)
            {
                    return;
            }
            
            if((UnityEngine.Object.op_Implicit(exists:  this.source.<BlurredScreen>k__BackingField)) == false)
            {
                    return;
            }
            
            if((UnityEngine.Object.op_Implicit(exists:  this.material)) != false)
            {
                    if(this.material.shader == this.correctShader)
            {
                goto label_15;
            }
            
            }
            
            UnityEngine.Debug.LogError(message:  "Material using \"UI/TranslucentImage\" is required");
            label_15:
            this.materialForRendering.SetTexture(name:  "_BlurTex", value:  this.source.<BlurredScreen>k__BackingField);
            return;
            label_3:
            UnityEngine.Debug.LogError(message:  "Source missing. Add TranslucentImageSource component to your main camera, then drag the camera to Source slot");
        }
        private void Update()
        {
            if(this.vibrancyPropId == 0)
            {
                    return;
            }
            
            if(this.brightnessPropId == 0)
            {
                    return;
            }
            
            if(this.flattenPropId == 0)
            {
                    return;
            }
            
            this.SyncMaterialProperty(propId:  this.vibrancyPropId, value: ref  this.vibrancy, oldValue: ref  this.oldVibrancy);
            this.SyncMaterialProperty(propId:  this.brightnessPropId, value: ref  this.brightness, oldValue: ref  this.oldBrightness);
            this.SyncMaterialProperty(propId:  this.flattenPropId, value: ref  this.flatten, oldValue: ref  this.oldFlatten);
        }
        private void SyncMaterialProperty(int propId, ref float value, ref float oldValue)
        {
            float val_2 = this.materialForRendering.GetFloat(nameID:  propId);
            if((UnityEngine.Mathf.Approximately(a:  val_2, b:  value)) != true)
            {
                    if((UnityEngine.Mathf.Approximately(a:  value, b:  oldValue)) != false)
            {
                    value = val_2;
            }
            else
            {
                    this.material.SetFloat(nameID:  propId, value:  value);
                this.materialForRendering.SetFloat(nameID:  propId, value:  value);
                this.SetMaterialDirty();
            }
            
            }
            
            oldValue = value;
        }
        public virtual void ModifyMesh(UnityEngine.UI.VertexHelper vh)
        {
            System.Collections.Generic.List<UnityEngine.UIVertex> val_1 = new System.Collections.Generic.List<UnityEngine.UIVertex>();
            vh.GetUIVertexStream(stream:  val_1);
            if(1152921510494635168 >= 1)
            {
                    var val_4 = 0;
                var val_3 = 0;
                do
            {
                if(val_3 >= 1152921510494635168)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                UnityEngine.Vector2 val_2 = new UnityEngine.Vector2(x:  this.spriteBlending, y:  0f);
                val_1.set_Item(index:  0, value:  new UnityEngine.UIVertex() {position = new UnityEngine.Vector3() {x = 8.66789E+18f, y = 2.524355E-29f, z = 8.66789E+18f}, normal = new UnityEngine.Vector3() {x = 2.524355E-29f, y = 8.666764E+18f, z = 2.524355E-29f}, tangent = new UnityEngine.Vector4() {x = 8.666764E+18f, y = 2.524355E-29f, z = 8.667327E+18f, w = 2.524355E-29f}, color = new UnityEngine.Color32() {r = 16, g = 145, b = 240, a = 94}, uv0 = new UnityEngine.Vector2() {x = 2.524355E-29f, y = "interopXmlElement"}, uv1 = new UnityEngine.Vector2() {x = val_2.x}, uv2 = new UnityEngine.Vector2() {x = 1152921510494635168.__il2cppRuntimeField_5C, y = 1152921510494635168.__il2cppRuntimeField_5C}, uv3 = new UnityEngine.Vector2() {x = 1152921510494635168.__il2cppRuntimeField_5C, y = 1152921510494635168.__il2cppRuntimeField_5C}});
                val_3 = val_3 + 1;
                val_4 = val_4 + 76;
            }
            while(val_3 < val_2.x);
            
            }
            
            vh.Clear();
            vh.AddUIVertexTriangleStream(verts:  val_1);
        }
        protected override void OnEnable()
        {
            this.OnEnable();
            this.SetVerticesDirty();
        }
        protected override void OnDisable()
        {
            this.SetVerticesDirty();
            this.OnDisable();
        }
        protected override void OnDidApplyAnimationProperties()
        {
            this.SetVerticesDirty();
            this.OnDidApplyAnimationProperties();
        }
        public virtual void ModifyMesh(UnityEngine.Mesh mesh)
        {
            UnityEngine.UI.VertexHelper val_1 = new UnityEngine.UI.VertexHelper(m:  mesh);
            val_1.FillMesh(mesh:  mesh);
            var val_3 = 0;
            val_3 = val_3 + 1;
            val_1.Dispose();
            if(0 != 0)
            {
                    throw 0;
            }
        
        }
        public TranslucentImage()
        {
            this.vibrancy = 1f;
            this.flatten = 0.1f;
            this.spriteBlending = 0.65f;
        }
    
    }

}
