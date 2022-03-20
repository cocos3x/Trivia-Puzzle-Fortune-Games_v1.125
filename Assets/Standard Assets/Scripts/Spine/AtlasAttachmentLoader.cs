using UnityEngine;

namespace Spine
{
    public class AtlasAttachmentLoader : AttachmentLoader
    {
        // Fields
        private Spine.Atlas[] atlasArray;
        
        // Methods
        public AtlasAttachmentLoader(Spine.Atlas[] atlasArray)
        {
            if(atlasArray == null)
            {
                    throw new System.ArgumentNullException(paramName:  "atlas array cannot be null.");
            }
            
            this.atlasArray = atlasArray;
        }
        public Spine.RegionAttachment NewRegionAttachment(Spine.Skin skin, string name, string path)
        {
            Spine.AtlasRegion val_1 = this.FindRegion(name:  path);
            if(val_1 == null)
            {
                    throw new System.ArgumentException(message:  System.String.Format(format:  "Region not found in atlas: {0} (region attachment: {1})", arg0:  path, arg1:  name));
            }
            
            Spine.RegionAttachment val_2 = new Spine.RegionAttachment(name:  name);
            .RendererObject = val_1;
            val_2.SetUVs(u:  val_1.u, v:  val_1.v, u2:  val_1.u2, v2:  val_1.v2, rotate:  val_1.rotate);
            .regionOffsetX = val_1.offsetX;
            .regionOffsetY = val_1.offsetY;
            .regionWidth = (float)val_1.width;
            .regionHeight = (float)val_1.height;
            .regionOriginalWidth = (float)val_1.originalWidth;
            .regionOriginalHeight = (float)val_1.originalHeight;
            return val_2;
        }
        public Spine.MeshAttachment NewMeshAttachment(Spine.Skin skin, string name, string path)
        {
            Spine.AtlasRegion val_1 = this.FindRegion(name:  path);
            if(val_1 == null)
            {
                    throw new System.ArgumentException(message:  System.String.Format(format:  "Region not found in atlas: {0} (region attachment: {1})", arg0:  path, arg1:  name));
            }
            
            .RendererObject = val_1;
            .<RegionU>k__BackingField = val_1.u;
            .<RegionV>k__BackingField = val_1.v;
            .<RegionU2>k__BackingField = val_1.u2;
            .<RegionV2>k__BackingField = val_1.v2;
            .<RegionRotate>k__BackingField = val_1.rotate;
            .regionOffsetX = val_1.offsetX;
            .regionOffsetY = val_1.offsetY;
            .regionWidth = (float)val_1.width;
            .regionHeight = (float)val_1.height;
            .regionOriginalWidth = (float)val_1.originalWidth;
            .regionOriginalHeight = (float)val_1.originalHeight;
            return (Spine.MeshAttachment)new Spine.MeshAttachment(name:  name);
        }
        public Spine.BoundingBoxAttachment NewBoundingBoxAttachment(Spine.Skin skin, string name)
        {
            return (Spine.BoundingBoxAttachment)new Spine.BoundingBoxAttachment(name:  name);
        }
        public Spine.PathAttachment NewPathAttachment(Spine.Skin skin, string name)
        {
            return (Spine.PathAttachment)new Spine.PathAttachment(name:  name);
        }
        public Spine.PointAttachment NewPointAttachment(Spine.Skin skin, string name)
        {
            return (Spine.PointAttachment)new Spine.PointAttachment(name:  name);
        }
        public Spine.ClippingAttachment NewClippingAttachment(Spine.Skin skin, string name)
        {
            return (Spine.ClippingAttachment)new Spine.ClippingAttachment(name:  name);
        }
        public Spine.AtlasRegion FindRegion(string name)
        {
            var val_2;
            var val_3 = 0;
            label_5:
            if(val_3 >= this.atlasArray.Length)
            {
                goto label_1;
            }
            
            if((this.atlasArray[val_3].FindRegion(name:  name)) != null)
            {
                    return (Spine.AtlasRegion)val_2;
            }
            
            val_3 = val_3 + 1;
            if(this.atlasArray != null)
            {
                goto label_5;
            }
            
            throw new NullReferenceException();
            label_1:
            val_2 = 0;
            return (Spine.AtlasRegion)val_2;
        }
    
    }

}
