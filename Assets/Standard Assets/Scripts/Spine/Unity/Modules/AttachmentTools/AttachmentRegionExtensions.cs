using UnityEngine;

namespace Spine.Unity.Modules.AttachmentTools
{
    public static class AttachmentRegionExtensions
    {
        // Methods
        public static Spine.AtlasRegion GetRegion(Spine.Attachment attachment)
        {
            var val_4;
            var val_5;
            if(attachment != null)
            {
                    val_4 = 0;
                var val_2 = (((Spine.Attachment.__il2cppRuntimeField_typeHierarchy + (Spine.MeshAttachment.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? attachment : 0;
                val_5 = mem[(Spine.Attachment.__il2cppRuntimeField_typeHierarchy + (Spine.MeshAttachment.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8 == null ? attachment : 0 + 144];
                val_5 = (Spine.Attachment.__il2cppRuntimeField_typeHierarchy + (Spine.MeshAttachment.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8 == null ? attachment : 0 + 144;
            }
            
            val_4 = 0;
            return (Spine.AtlasRegion)val_4;
        }
        public static Spine.AtlasRegion GetRegion(Spine.RegionAttachment regionAttachment)
        {
            var val_2 = 0;
            return (Spine.AtlasRegion);
        }
        public static Spine.AtlasRegion GetRegion(Spine.MeshAttachment meshAttachment)
        {
            var val_2 = 0;
            return (Spine.AtlasRegion);
        }
        public static void SetRegion(Spine.Attachment attachment, Spine.AtlasRegion region, bool updateOffset = True)
        {
            if(attachment == null)
            {
                    return;
            }
            
            updateOffset = updateOffset;
            Spine.Unity.Modules.AttachmentTools.AttachmentRegionExtensions.SetRegion(attachment:  attachment, region:  region, updateOffset:  updateOffset);
        }
        public static void SetRegion(Spine.RegionAttachment attachment, Spine.AtlasRegion region, bool updateOffset = True)
        {
            if(region == null)
            {
                    throw new System.ArgumentNullException(paramName:  "region");
            }
            
            attachment.RendererObject = region;
            attachment.SetUVs(u:  region.u, v:  region.v, u2:  region.u2, v2:  region.v2, rotate:  region.rotate);
            attachment.regionOffsetX = region.offsetX;
            attachment.regionOffsetY = region.offsetY;
            attachment.regionWidth = (float)region.width;
            attachment.regionHeight = (float)region.height;
            attachment.regionOriginalWidth = (float)region.originalWidth;
            attachment.regionOriginalHeight = (float)region.originalHeight;
            if(updateOffset == false)
            {
                    return;
            }
            
            attachment.UpdateOffset();
        }
        public static void SetRegion(Spine.MeshAttachment attachment, Spine.AtlasRegion region, bool updateUVs = True)
        {
            if(region == null)
            {
                    throw new System.ArgumentNullException(paramName:  "region");
            }
            
            attachment.RendererObject = region;
            attachment.<RegionU>k__BackingField = region.u;
            attachment.<RegionV>k__BackingField = region.v;
            attachment.<RegionU2>k__BackingField = region.u2;
            attachment.<RegionV2>k__BackingField = region.v2;
            attachment.<RegionRotate>k__BackingField = region.rotate;
            attachment.regionOffsetX = region.offsetX;
            attachment.regionOffsetY = region.offsetY;
            attachment.regionWidth = (float)region.width;
            attachment.regionHeight = (float)region.height;
            attachment.regionOriginalWidth = (float)region.originalWidth;
            attachment.regionOriginalHeight = (float)region.originalHeight;
            if(updateUVs == false)
            {
                    return;
            }
            
            attachment.UpdateUVs();
        }
        public static Spine.RegionAttachment ToRegionAttachment(UnityEngine.Sprite sprite, UnityEngine.Material material)
        {
            return Spine.Unity.Modules.AttachmentTools.AttachmentRegionExtensions.ToRegionAttachment(sprite:  sprite, page:  Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.ToSpineAtlasPage(m:  material));
        }
        public static Spine.RegionAttachment ToRegionAttachment(UnityEngine.Sprite sprite, Spine.AtlasPage page)
        {
            string val_8;
            if(sprite == 0)
            {
                goto label_3;
            }
            
            if(page == null)
            {
                goto label_4;
            }
            
            return Spine.Unity.Modules.AttachmentTools.AttachmentRegionExtensions.ToRegionAttachment(region:  Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.ToAtlasRegion(s:  sprite, page:  page), attachmentName:  sprite.name, scale:  1f / sprite.pixelsPerUnit);
            label_3:
            val_8 = "sprite";
            goto label_6;
            label_4:
            System.ArgumentNullException val_6 = null;
            val_8 = "page";
            label_6:
            val_6 = new System.ArgumentNullException(paramName:  val_8);
            throw val_6;
        }
        public static Spine.RegionAttachment ToRegionAttachmentPMAClone(UnityEngine.Sprite sprite, UnityEngine.Shader shader, UnityEngine.TextureFormat textureFormat = 4, bool mipmaps = False, UnityEngine.Material materialPropertySource)
        {
            string val_9;
            if(sprite == 0)
            {
                goto label_3;
            }
            
            if(shader == 0)
            {
                goto label_6;
            }
            
            mipmaps = mipmaps;
            return Spine.Unity.Modules.AttachmentTools.AttachmentRegionExtensions.ToRegionAttachment(region:  Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.ToAtlasRegionPMAClone(s:  sprite, shader:  shader, textureFormat:  textureFormat, mipmaps:  mipmaps, materialPropertySource:  materialPropertySource), attachmentName:  sprite.name, scale:  1f / sprite.pixelsPerUnit);
            label_3:
            val_9 = "sprite";
            goto label_8;
            label_6:
            System.ArgumentNullException val_7 = null;
            val_9 = "shader";
            label_8:
            val_7 = new System.ArgumentNullException(paramName:  val_9);
            throw val_7;
        }
        public static Spine.RegionAttachment ToRegionAttachmentPMAClone(UnityEngine.Sprite sprite, UnityEngine.Material materialPropertySource, UnityEngine.TextureFormat textureFormat = 4, bool mipmaps = False)
        {
            mipmaps = mipmaps;
            return Spine.Unity.Modules.AttachmentTools.AttachmentRegionExtensions.ToRegionAttachmentPMAClone(sprite:  sprite, shader:  materialPropertySource.shader, textureFormat:  textureFormat, mipmaps:  mipmaps, materialPropertySource:  materialPropertySource);
        }
        public static Spine.RegionAttachment ToRegionAttachment(Spine.AtlasRegion region, string attachmentName, float scale = 0.01)
        {
            var val_6;
            if((System.String.IsNullOrEmpty(value:  attachmentName)) == true)
            {
                goto label_1;
            }
            
            if(region == null)
            {
                goto label_2;
            }
            
            Spine.RegionAttachment val_2 = new Spine.RegionAttachment(name:  attachmentName);
            .RendererObject = region;
            val_2.SetUVs(u:  region.u, v:  region.v, u2:  region.u2, v2:  region.v2, rotate:  region.rotate);
            .regionOffsetX = region.offsetX;
            .regionOffsetY = region.offsetY;
            .regionWidth = (float)region.width;
            .regionHeight = (float)region.height;
            float val_6 = (float)region.originalWidth;
            .regionOriginalWidth = val_6;
            val_6 = val_6 * scale;
            float val_7 = (float)region.originalHeight;
            .regionOriginalHeight = val_7;
            val_7 = val_7 * scale;
            .scaleY = 1f;
            .rotation = 0f;
            .scaleX = 1f;
            .r = 1;
            .<Path>k__BackingField = region.name;
            .width = val_6;
            .height = val_7;
            UnityEngine.Color val_3 = UnityEngine.Color.white;
            Spine.Unity.SkeletonExtensions.SetColor(attachment:  val_2, color:  new UnityEngine.Color() {r = val_3.r, g = val_3.g, b = val_3.b, a = val_3.a});
            val_2.UpdateOffset();
            return val_2;
            label_1:
            System.ArgumentException val_4 = null;
            val_6 = val_4;
            val_4 = new System.ArgumentException(message:  "attachmentName can\'t be null or empty.", paramName:  "attachmentName");
            throw val_6 = val_5;
            label_2:
            System.ArgumentNullException val_5 = null;
            val_5 = new System.ArgumentNullException(paramName:  "region");
            throw val_6;
        }
        public static void SetScale(Spine.RegionAttachment regionAttachment, UnityEngine.Vector2 scale)
        {
            if(regionAttachment != null)
            {
                    regionAttachment.scaleX = scale.x;
                regionAttachment.scaleY = scale.y;
                return;
            }
            
            throw new NullReferenceException();
        }
        public static void SetScale(Spine.RegionAttachment regionAttachment, float x, float y)
        {
            if(regionAttachment != null)
            {
                    regionAttachment.scaleX = x;
                regionAttachment.scaleY = y;
                return;
            }
            
            throw new NullReferenceException();
        }
        public static void SetPositionOffset(Spine.RegionAttachment regionAttachment, UnityEngine.Vector2 offset)
        {
            if(regionAttachment != null)
            {
                    regionAttachment.x = offset.x;
                regionAttachment.y = offset.y;
                return;
            }
            
            throw new NullReferenceException();
        }
        public static void SetPositionOffset(Spine.RegionAttachment regionAttachment, float x, float y)
        {
            if(regionAttachment != null)
            {
                    regionAttachment.x = x;
                regionAttachment.y = y;
                return;
            }
            
            throw new NullReferenceException();
        }
        public static void SetRotation(Spine.RegionAttachment regionAttachment, float rotation)
        {
            if(regionAttachment != null)
            {
                    regionAttachment.rotation = rotation;
                return;
            }
            
            throw new NullReferenceException();
        }
    
    }

}
