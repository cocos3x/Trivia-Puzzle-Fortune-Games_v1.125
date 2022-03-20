using UnityEngine;

namespace Spine.Unity
{
    public class AtlasAsset : ScriptableObject
    {
        // Fields
        public UnityEngine.TextAsset atlasFile;
        public UnityEngine.Material[] materials;
        protected Spine.Atlas atlas;
        
        // Properties
        public bool IsLoaded { get; }
        
        // Methods
        public bool get_IsLoaded()
        {
            return (bool)(this.atlas != 0) ? 1 : 0;
        }
        public static Spine.Unity.AtlasAsset CreateRuntimeInstance(UnityEngine.TextAsset atlasText, UnityEngine.Material[] materials, bool initialize)
        {
            val_1.atlasFile = atlasText;
            val_1.materials = materials;
            if(initialize == false)
            {
                    return (Spine.Unity.AtlasAsset)UnityEngine.ScriptableObject.CreateInstance<Spine.Unity.AtlasAsset>();
            }
            
            return (Spine.Unity.AtlasAsset)UnityEngine.ScriptableObject.CreateInstance<Spine.Unity.AtlasAsset>();
        }
        public static Spine.Unity.AtlasAsset CreateRuntimeInstance(UnityEngine.TextAsset atlasText, UnityEngine.Texture2D[] textures, UnityEngine.Shader shader, bool initialize)
        {
            bool val_20;
            var val_21;
            var val_22;
            UnityEngine.Object val_23;
            val_20 = initialize;
            val_21 = "";
            char[] val_5 = new char[1];
            val_5[0] = '
            ';
            System.String[] val_6 = atlasText.text.Replace(oldValue:  "\r", newValue:  "").Split(separator:  val_5);
            if((val_6.Length - 1) >= 1)
            {
                    val_22 = ".png";
                do
            {
                string val_9 = val_6[0].Trim();
                var val_10 = 0 + 1;
                if(val_9.m_stringLength == 0)
            {
                    new System.Collections.Generic.List<System.String>().Add(item:  1152921505059157200.Trim().Replace(oldValue:  ".png", newValue:  ""));
            }
            
                val_20 = val_10;
            }
            while(val_10 < (val_6.Length - 1));
            
            }
            
            UnityEngine.Material[] val_14 = new UnityEngine.Material[0];
            if(1152921506161210128 < 1)
            {
                    return Spine.Unity.AtlasAsset.CreateRuntimeInstance(atlasText:  atlasText, materials:  val_14, initialize:  val_20);
            }
            
            goto label_22;
            label_42:
            label_22:
            if(0 >= 1152921506161210128)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_20 = textures.Length;
            if(val_20 < 1)
            {
                goto label_29;
            }
            
            val_21 = 0;
            label_30:
            if((System.String.Equals(a:  "WordGameEventsController:InjectEventsTrackingData, property with name {0} alrady exist", b:  textures[val_21].name, comparisonType:  5)) == true)
            {
                goto label_28;
            }
            
            val_21 = val_21 + 1;
            if(val_21 < val_20)
            {
                    if(val_21 < textures.Length)
            {
                goto label_30;
            }
            
            }
            
            label_29:
            val_23 = 0;
            goto label_32;
            label_28:
            UnityEngine.Material val_17 = null;
            val_23 = val_17;
            val_17 = new UnityEngine.Material(shader:  UnityEngine.Shader.Find(name:  "Spine/Skeleton"));
            val_17.mainTexture = textures[0x0] + 32;
            label_32:
            if(val_17 == 0)
            {
                    throw new System.ArgumentException(message:  "Could not find matching atlas page in the texture array.");
            }
            
            val_22 = 0 + 1;
            val_14[0] = val_23;
            if(val_22 < 44392488)
            {
                goto label_42;
            }
            
            return Spine.Unity.AtlasAsset.CreateRuntimeInstance(atlasText:  atlasText, materials:  val_14, initialize:  val_20);
        }
        public static Spine.Unity.AtlasAsset CreateRuntimeInstance(UnityEngine.TextAsset atlasText, UnityEngine.Texture2D[] textures, UnityEngine.Material materialPropertySource, bool initialize)
        {
            bool val_4 = initialize;
            initialize = val_4;
            if(val_2.materials.Length < 1)
            {
                    return (Spine.Unity.AtlasAsset)Spine.Unity.AtlasAsset.CreateRuntimeInstance(atlasText:  atlasText, textures:  textures, shader:  materialPropertySource.shader, initialize:  initialize);
            }
            
            var val_4 = 0;
            do
            {
                val_4 = val_2.materials[val_4];
                val_4.CopyPropertiesFromMaterial(mat:  materialPropertySource);
                val_4.shaderKeywords = materialPropertySource.shaderKeywords;
                val_4 = val_4 + 1;
            }
            while(val_4 < val_2.materials.Length);
            
            return (Spine.Unity.AtlasAsset)Spine.Unity.AtlasAsset.CreateRuntimeInstance(atlasText:  atlasText, textures:  textures, shader:  materialPropertySource.shader, initialize:  initialize);
        }
        private void Reset()
        {
            goto typeof(Spine.Unity.AtlasAsset).__il2cppRuntimeField_170;
        }
        public virtual void Clear()
        {
            this.atlas = 0;
        }
        public virtual Spine.Atlas GetAtlas()
        {
            UnityEngine.Object val_12;
            string val_14;
            Spine.Atlas val_15;
            UnityEngine.TextAsset val_16;
            val_12 = 0;
            if(this.atlasFile == val_12)
            {
                    string val_2 = this.name;
                val_14 = "Atlas file not set for atlas asset: ";
            }
            else
            {
                    if((this.materials != null) && (this.materials.Length != 0))
            {
                    val_15 = this.atlas;
                if(val_15 != null)
            {
                    return (Spine.Atlas)val_15;
            }
            
                val_16 = this.atlasFile;
                if(val_16 == null)
            {
                    throw new NullReferenceException();
            }
            
                System.IO.StringReader val_4 = new System.IO.StringReader(s:  val_16.text);
                .atlasAsset = this;
                Spine.Atlas val_6 = null;
                val_12 = val_4;
                val_6 = new Spine.Atlas(reader:  val_4, dir:  "", textureLoader:  new Spine.Unity.MaterialsTextureLoader());
                this.atlas = val_6;
                if(val_6 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_6.FlipV();
                val_15 = this.atlas;
                return (Spine.Atlas)val_15;
            }
            
                val_14 = "Materials not set for atlas asset: ";
            }
            
            UnityEngine.Debug.LogError(message:  val_14 + this.name, context:  this);
            val_15 = 0;
            return (Spine.Atlas)val_15;
        }
        public UnityEngine.Mesh GenerateMesh(string name, UnityEngine.Mesh mesh, out UnityEngine.Material material, float scale = 0.01)
        {
            UnityEngine.Color[] val_32;
            float val_33;
            UnityEngine.Object val_34;
            var val_35;
            float val_36;
            val_33 = scale;
            val_34 = mesh;
            val_35 = this;
            Spine.AtlasRegion val_1 = this.atlas.FindRegion(name:  name);
            material = 0;
            if(val_1 == null)
            {
                goto label_2;
            }
            
            val_35 = val_1;
            if(val_34 == 0)
            {
                    UnityEngine.Mesh val_3 = null;
                val_34 = val_3;
                val_3 = new UnityEngine.Mesh();
                val_3.name = name;
            }
            
            UnityEngine.Vector3[] val_4 = new UnityEngine.Vector3[4];
            UnityEngine.Vector2[] val_5 = new UnityEngine.Vector2[4];
            UnityEngine.Color[] val_6 = new UnityEngine.Color[4];
            val_32 = val_6;
            UnityEngine.Color val_7 = UnityEngine.Color.white;
            val_32[0] = val_7;
            val_32[0] = val_7.g;
            val_32[1] = val_7.b;
            val_32[1] = val_7.a;
            UnityEngine.Color val_8 = UnityEngine.Color.white;
            val_32[2] = val_8;
            val_32[2] = val_8.g;
            val_32[3] = val_8.b;
            val_32[3] = val_8.a;
            UnityEngine.Color val_9 = UnityEngine.Color.white;
            val_32[4] = val_9;
            val_32[4] = val_9.g;
            val_32[5] = val_9.b;
            val_32[5] = val_9.a;
            UnityEngine.Color val_10 = UnityEngine.Color.white;
            val_32[6] = val_10;
            val_32[6] = val_10.g;
            val_32[7] = val_10.b;
            val_32[7] = val_10.a;
            float val_32 = (float)val_1.height;
            float val_12 = (float)val_1.width * (-0.5f);
            float val_13 = val_32 * (-0.5f);
            UnityEngine.Vector3 val_14 = new UnityEngine.Vector3(x:  val_12, y:  val_13, z:  0f);
            UnityEngine.Vector3 val_15 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_14.x, y = val_14.y, z = val_14.z}, d:  val_33);
            val_32 = val_32 * 0.5f;
            val_4[0] = val_15;
            val_4[0] = val_15.y;
            val_4[1] = val_15.z;
            UnityEngine.Vector3 val_16 = new UnityEngine.Vector3(x:  val_12, y:  val_32, z:  0f);
            UnityEngine.Vector3 val_17 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z}, d:  val_33);
            float val_18 = (float)val_1.width * 0.5f;
            val_4[1] = val_17;
            val_4[2] = val_17.y;
            val_4[2] = val_17.z;
            UnityEngine.Vector3 val_19 = new UnityEngine.Vector3(x:  val_18, y:  val_32, z:  0f);
            UnityEngine.Vector3 val_20 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_19.x, y = val_19.y, z = val_19.z}, d:  val_33);
            val_4[3] = val_20;
            val_4[3] = val_20.y;
            val_4[4] = val_20.z;
            UnityEngine.Vector3 val_21 = new UnityEngine.Vector3(x:  val_18, y:  val_13, z:  0f);
            UnityEngine.Vector3 val_22 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_21.x, y = val_21.y, z = val_21.z}, d:  val_33);
            val_4[4] = val_22;
            val_4[5] = val_22.y;
            val_4[5] = val_22.z;
            val_33 = val_1.u2;
            if(val_1.rotate == false)
            {
                goto label_19;
            }
            
            UnityEngine.Vector2 val_23 = new UnityEngine.Vector2(x:  val_33, y:  val_1.v2);
            val_5[0] = val_23.x;
            UnityEngine.Vector2 val_24 = new UnityEngine.Vector2(x:  val_1.u, y:  val_1.v2);
            val_5[1] = val_24.x;
            UnityEngine.Vector2 val_25 = new UnityEngine.Vector2(x:  val_1.u, y:  val_1.v);
            val_36 = val_25.x;
            goto label_24;
            label_2:
            val_34 = 0;
            return (UnityEngine.Mesh)val_34;
            label_19:
            UnityEngine.Vector2 val_26 = new UnityEngine.Vector2(x:  val_1.u, y:  val_1.v2);
            val_5[0] = val_26.x;
            UnityEngine.Vector2 val_27 = new UnityEngine.Vector2(x:  val_1.u, y:  val_1.v);
            val_5[1] = val_27.x;
            UnityEngine.Vector2 val_28 = new UnityEngine.Vector2(x:  val_33, y:  val_1.v);
            val_36 = val_28.x;
            UnityEngine.Vector2 val_29;
            label_24:
            val_5[2] = val_36;
            val_29 = new UnityEngine.Vector2(x:  val_33, y:  val_1.v2);
            val_5[3] = val_29.x;
            val_3.triangles = new int[0];
            val_3.vertices = val_4;
            val_3.uv = val_5;
            val_3.colors = val_6;
            val_3.triangles = new int[6] {0, 1, 2, 2, 3, 0};
            val_3.RecalculateNormals();
            val_3.RecalculateBounds();
            if(val_1.page.rendererObject != null)
            {
                    material = val_1.page.rendererObject;
            }
            
            material = 0;
            return (UnityEngine.Mesh)val_34;
        }
        public AtlasAsset()
        {
        
        }
    
    }

}
