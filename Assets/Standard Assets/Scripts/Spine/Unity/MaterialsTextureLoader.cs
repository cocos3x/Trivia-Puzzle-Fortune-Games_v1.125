using UnityEngine;

namespace Spine.Unity
{
    public class MaterialsTextureLoader : TextureLoader
    {
        // Fields
        private Spine.Unity.AtlasAsset atlasAsset;
        
        // Methods
        public MaterialsTextureLoader(Spine.Unity.AtlasAsset atlasAsset)
        {
            this.atlasAsset = atlasAsset;
        }
        public void Load(Spine.AtlasPage page, string path)
        {
            var val_14;
            UnityEngine.Material val_15;
            Spine.Unity.AtlasAsset val_16;
            object val_17;
            UnityEngine.Object val_18;
            string val_1 = System.IO.Path.GetFileNameWithoutExtension(path:  path);
            if(this.atlasAsset.materials.Length < 1)
            {
                goto label_5;
            }
            
            val_14 = 0;
            label_13:
            val_15 = this.atlasAsset.materials[val_14];
            if(val_15.mainTexture == 0)
            {
                goto label_10;
            }
            
            if((System.String.op_Equality(a:  val_15.mainTexture.name, b:  val_1)) == true)
            {
                goto label_12;
            }
            
            val_14 = val_14 + 1;
            if(val_14 < this.atlasAsset.materials.Length)
            {
                goto label_13;
            }
            
            label_5:
            val_15 = 0;
            label_12:
            if(val_15 != 0)
            {
                goto label_16;
            }
            
            val_16 = this.atlasAsset;
            val_17 = "Material with texture name \"" + val_1 + "\" not found for atlas asset: "("\" not found for atlas asset: ") + this.atlasAsset.name;
            val_18 = val_16;
            goto label_20;
            label_16:
            page.rendererObject = val_15;
            if(page.width != 0)
            {
                    if(page.height != 0)
            {
                    return;
            }
            
            }
            
            page.width = val_15.mainTexture;
            page.height = val_15.mainTexture;
            return;
            label_10:
            val_16 = "Material is missing texture: "("Material is missing texture: ") + val_15.name;
            val_17 = val_16;
            val_18 = val_15;
            label_20:
            UnityEngine.Debug.LogError(message:  val_17, context:  val_18);
        }
        public void Unload(object texture)
        {
        
        }
    
    }

}
