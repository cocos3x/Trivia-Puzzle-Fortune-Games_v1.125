using UnityEngine;

namespace Spine.Unity.Modules.AttachmentTools
{
    public static class AttachmentCloneExtensions
    {
        // Methods
        public static Spine.Attachment GetClone(Spine.Attachment o, bool cloneMeshesAsLinked)
        {
            return 0;
        }
        public static Spine.RegionAttachment GetClone(Spine.RegionAttachment o)
        {
            .x = o.x;
            .y = o.y;
            .rotation = o.rotation;
            .scaleX = o.scaleX;
            .scaleY = o.scaleY;
            .width = o.width;
            .height = o.height;
            .r = o.r;
            .g = o.g;
            .b = o.b;
            .a = o.a;
            .<Path>k__BackingField = o.<Path>k__BackingField;
            .RendererObject = o.RendererObject;
            .regionOffsetX = o.regionOffsetX;
            .regionOffsetY = o.regionOffsetY;
            .regionWidth = o.regionWidth;
            .regionHeight = o.regionHeight;
            .regionOriginalWidth = o.regionOriginalWidth;
            .regionOriginalHeight = o.regionOriginalHeight;
            object val_3 = o.uvs.Clone();
            .uvs = null;
            object val_4 = o.offset.Clone();
            .offset = null;
            return (Spine.RegionAttachment)new Spine.RegionAttachment(name:  4128 + "clone");
        }
        public static Spine.BoundingBoxAttachment GetClone(Spine.BoundingBoxAttachment o)
        {
            Spine.BoundingBoxAttachment val_1 = new Spine.BoundingBoxAttachment(name:  static_value_027FF000);
            Spine.Unity.Modules.AttachmentTools.AttachmentCloneExtensions.CloneVertexAttachment(src:  o, dest:  val_1);
            return val_1;
        }
        public static Spine.MeshAttachment GetLinkedClone(Spine.MeshAttachment o, bool inheritDeform = True)
        {
            var val_3 = 0;
            return Spine.Unity.Modules.AttachmentTools.AttachmentCloneExtensions.GetLinkedMesh(o:  o, newLinkedMeshName:  inheritDeform, region:  null, inheritDeform:  inheritDeform);
        }
        public static Spine.MeshAttachment GetClone(Spine.MeshAttachment o)
        {
            System.Int32[] val_6;
            Spine.MeshAttachment val_1 = new Spine.MeshAttachment(name:  X21);
            .r = o.r;
            .g = o.g;
            .b = o.b;
            .a = o.a;
            .inheritDeform = o.inheritDeform;
            .<Path>k__BackingField = o.<Path>k__BackingField;
            .RendererObject = o.RendererObject;
            .regionOffsetX = o.regionOffsetX;
            .regionOffsetY = o.regionOffsetY;
            .regionWidth = o.regionWidth;
            .regionHeight = o.regionHeight;
            .regionOriginalWidth = o.regionOriginalWidth;
            .regionOriginalHeight = o.regionOriginalHeight;
            .<RegionU>k__BackingField = o.<RegionU>k__BackingField;
            .<RegionV>k__BackingField = o.<RegionV>k__BackingField;
            .<RegionU2>k__BackingField = o.<RegionU2>k__BackingField;
            .<RegionV2>k__BackingField = o.<RegionV2>k__BackingField;
            .<RegionRotate>k__BackingField = o.<RegionRotate>k__BackingField;
            object val_2 = o.uvs.Clone();
            .uvs = null;
            if(o.parentMesh != null)
            {
                    val_1.ParentMesh = o.parentMesh;
                return val_1;
            }
            
            Spine.Unity.Modules.AttachmentTools.AttachmentCloneExtensions.CloneVertexAttachment(src:  o, dest:  val_1);
            object val_3 = o.regionUVs.Clone();
            .regionUVs = null;
            object val_4 = o.triangles.Clone();
            .triangles = null;
            .hulllength = o.hulllength;
            val_6 = o.<Edges>k__BackingField;
            if(val_6 != null)
            {
                    object val_5 = val_6.Clone();
            }
            
            .<Edges>k__BackingField = null;
            .<Width>k__BackingField = o.<Width>k__BackingField;
            .<Height>k__BackingField = o.<Height>k__BackingField;
            return val_1;
        }
        public static Spine.PathAttachment GetClone(Spine.PathAttachment o)
        {
            Spine.PathAttachment val_1 = new Spine.PathAttachment(name:  X21);
            object val_2 = o.lengths.Clone();
            .lengths = null;
            .closed = o.closed;
            .constantSpeed = o.constantSpeed;
            Spine.Unity.Modules.AttachmentTools.AttachmentCloneExtensions.CloneVertexAttachment(src:  o, dest:  val_1);
            return val_1;
        }
        private static void CloneVertexAttachment(Spine.VertexAttachment src, Spine.VertexAttachment dest)
        {
            dest.worldVerticesLength = src.worldVerticesLength;
            if(src.bones != null)
            {
                    object val_1 = src.bones.Clone();
                dest.bones = null;
            }
            
            if(src.vertices == null)
            {
                    return;
            }
            
            object val_2 = src.vertices.Clone();
            dest.vertices = null;
        }
        public static Spine.MeshAttachment GetLinkedMesh(Spine.MeshAttachment o, string newLinkedMeshName, Spine.AtlasRegion region, bool inheritDeform = True)
        {
            if(region == null)
            {
                    throw new System.ArgumentNullException(paramName:  "region");
            }
            
            Spine.MeshAttachment val_1 = new Spine.MeshAttachment(name:  newLinkedMeshName);
            Spine.Unity.Modules.AttachmentTools.AttachmentRegionExtensions.SetRegion(attachment:  val_1, region:  region, updateUVs:  false);
            .<Path>k__BackingField = newLinkedMeshName;
            .r = 1;
            .inheritDeform = inheritDeform;
            val_1.ParentMesh = (o.parentMesh == 0) ? o : o.parentMesh;
            val_1.UpdateUVs();
            return val_1;
        }
        public static Spine.MeshAttachment GetLinkedMesh(Spine.MeshAttachment o, UnityEngine.Sprite sprite, UnityEngine.Shader shader, bool inheritDeform = True, UnityEngine.Material materialPropertySource)
        {
            UnityEngine.Material val_1 = new UnityEngine.Material(shader:  shader);
            if(materialPropertySource != 0)
            {
                    val_1.CopyPropertiesFromMaterial(mat:  materialPropertySource);
                val_1.shaderKeywords = materialPropertySource.shaderKeywords;
            }
            
            inheritDeform = inheritDeform;
            return Spine.Unity.Modules.AttachmentTools.AttachmentCloneExtensions.GetLinkedMesh(o:  o, newLinkedMeshName:  sprite.name, region:  Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.ToAtlasRegion(s:  sprite, isolatedTexture:  false), inheritDeform:  inheritDeform);
        }
        public static Spine.MeshAttachment GetLinkedMesh(Spine.MeshAttachment o, UnityEngine.Sprite sprite, UnityEngine.Material materialPropertySource, bool inheritDeform = True)
        {
            inheritDeform = inheritDeform;
            return Spine.Unity.Modules.AttachmentTools.AttachmentCloneExtensions.GetLinkedMesh(o:  o, sprite:  sprite, shader:  materialPropertySource.shader, inheritDeform:  inheritDeform, materialPropertySource:  materialPropertySource);
        }
        public static Spine.Attachment GetRemappedClone(Spine.Attachment o, UnityEngine.Sprite sprite, UnityEngine.Material sourceMaterial, bool premultiplyAlpha = True, bool cloneMeshAsLinked = True, bool useOriginalRegionSize = False)
        {
            if(premultiplyAlpha != false)
            {
                    Spine.AtlasRegion val_1 = Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.ToAtlasRegionPMAClone(s:  sprite, materialPropertySource:  sourceMaterial, textureFormat:  4, mipmaps:  false);
            }
            
            float val_3 = sprite.pixelsPerUnit;
            val_3 = 1f / val_3;
            return Spine.Unity.Modules.AttachmentTools.AttachmentCloneExtensions.GetRemappedClone(o:  o, atlasRegion:  Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.ToAtlasRegion(s:  sprite, isolatedTexture:  false), cloneMeshAsLinked:  cloneMeshAsLinked, useOriginalRegionSize:  useOriginalRegionSize, scale:  val_3);
        }
        public static Spine.Attachment GetRemappedClone(Spine.Attachment o, Spine.AtlasRegion atlasRegion, bool cloneMeshAsLinked = True, bool useOriginalRegionSize = False, float scale = 0.01)
        {
            if(o == null)
            {
                    return Spine.Unity.Modules.AttachmentTools.AttachmentCloneExtensions.GetClone(o:  o, cloneMeshesAsLinked:  true);
            }
            
            return Spine.Unity.Modules.AttachmentTools.AttachmentCloneExtensions.GetClone(o:  o, cloneMeshesAsLinked:  true);
        }
    
    }

}
