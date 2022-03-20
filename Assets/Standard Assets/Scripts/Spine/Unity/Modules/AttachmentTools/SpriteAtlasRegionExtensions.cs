using UnityEngine;

namespace Spine.Unity.Modules.AttachmentTools
{
    public static class SpriteAtlasRegionExtensions
    {
        // Fields
        internal const UnityEngine.TextureFormat SpineTextureFormat = 4;
        internal const bool UseMipMaps = False;
        internal const float DefaultScale = 0.01;
        
        // Methods
        public static Spine.AtlasRegion ToAtlasRegion(UnityEngine.Texture2D t, UnityEngine.Material materialPropertySource, float scale = 0.01)
        {
            return Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.ToAtlasRegion(t:  t, shader:  materialPropertySource.shader, scale:  scale, materialPropertySource:  materialPropertySource);
        }
        public static Spine.AtlasRegion ToAtlasRegion(UnityEngine.Texture2D t, UnityEngine.Shader shader, float scale = 0.01, UnityEngine.Material materialPropertySource)
        {
            UnityEngine.Material val_1 = new UnityEngine.Material(shader:  shader);
            if(materialPropertySource != 0)
            {
                    val_1.CopyPropertiesFromMaterial(mat:  materialPropertySource);
                val_1.shaderKeywords = materialPropertySource.shaderKeywords;
            }
            
            val_1.mainTexture = t;
            .name = t.name;
            .rotate = false;
            .index = 0;
            UnityEngine.Vector2 val_9 = UnityEngine.Vector2.zero;
            UnityEngine.Vector2 val_10 = new UnityEngine.Vector2(x:  (float)t.width, y:  (float)t.height);
            UnityEngine.Vector2 val_11 = UnityEngine.Vector2.op_Multiply(a:  new UnityEngine.Vector2() {x = val_10.x, y = val_10.y}, d:  scale);
            float val_13 = 0f;
            .width = (int)(float)t.width;
            .height = (int)(float)t.height;
            .originalWidth = (int)(float)t.width;
            .originalHeight = (int)(float)t.height;
            val_11.x = val_11.x - val_9.x;
            val_11.y = val_11.y - val_9.y;
            val_13 = val_13 - val_9.y;
            val_11.x = (val_13 - val_9.x) / val_11.x;
            val_11.y = val_13 / val_11.y;
            val_11.x = 0.5f - val_11.x;
            val_11.y = 0.5f - val_11.y;
            val_11.x = val_11.x * (float)t.width;
            val_11.y = val_11.y * (float)t.height;
            .x = 0;
            .y = 0;
            .offsetX = val_11.x;
            .offsetY = val_11.y;
            .u = ;
            .v = ;
            .u2 = 1f;
            .v2 = 0f;
            .page = Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.ToSpineAtlasPage(m:  val_1);
            return (Spine.AtlasRegion)new Spine.AtlasRegion();
        }
        public static Spine.AtlasRegion ToAtlasRegionPMAClone(UnityEngine.Texture2D t, UnityEngine.Material materialPropertySource, UnityEngine.TextureFormat textureFormat = 4, bool mipmaps = False)
        {
            mipmaps = mipmaps;
            return Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.ToAtlasRegionPMAClone(t:  t, shader:  materialPropertySource.shader, textureFormat:  textureFormat, mipmaps:  mipmaps, materialPropertySource:  materialPropertySource);
        }
        public static Spine.AtlasRegion ToAtlasRegionPMAClone(UnityEngine.Texture2D t, UnityEngine.Shader shader, UnityEngine.TextureFormat textureFormat = 4, bool mipmaps = False, UnityEngine.Material materialPropertySource)
        {
            UnityEngine.Material val_1 = new UnityEngine.Material(shader:  shader);
            if(materialPropertySource != 0)
            {
                    val_1.CopyPropertiesFromMaterial(mat:  materialPropertySource);
                val_1.shaderKeywords = materialPropertySource.shaderKeywords;
            }
            
            mipmaps = mipmaps;
            UnityEngine.Texture2D val_4 = Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.GetClone(t:  t, applyImmediately:  false, textureFormat:  textureFormat, mipmaps:  mipmaps);
            Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.ApplyPMA(texture:  val_4, applyImmediately:  true);
            val_4.name = t.name + "-pma-"("-pma-");
            val_1.name = t.name + shader.name;
            val_1.mainTexture = val_4;
            val_11.page = Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.ToSpineAtlasPage(m:  val_1);
            return (Spine.AtlasRegion)Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.ToAtlasRegion(t:  val_4, shader:  shader, scale:  0.01f, materialPropertySource:  0);
        }
        public static Spine.AtlasPage ToSpineAtlasPage(UnityEngine.Material m)
        {
            .rendererObject = m;
            .name = m.name;
            UnityEngine.Texture val_3 = m.mainTexture;
            if(val_3 == 0)
            {
                    return (Spine.AtlasPage)new Spine.AtlasPage();
            }
            
            .width = val_3;
            .height = val_3;
            return (Spine.AtlasPage)new Spine.AtlasPage();
        }
        public static Spine.AtlasRegion ToAtlasRegion(UnityEngine.Sprite s, Spine.AtlasPage page)
        {
            if(page == null)
            {
                    throw new System.ArgumentNullException(paramName:  "page", message:  "page cannot be null. AtlasPage determines which texture region belongs and how it should be rendered. You can use material.ToSpineAtlasPage() to get a shareable AtlasPage from a Material, or use the sprite.ToAtlasRegion(material) overload.");
            }
            
            val_1.page = page;
            return (Spine.AtlasRegion)Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.ToAtlasRegion(s:  s, isolatedTexture:  false);
        }
        public static Spine.AtlasRegion ToAtlasRegion(UnityEngine.Sprite s, UnityEngine.Material material)
        {
            val_1.page = Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.ToSpineAtlasPage(m:  material);
            return (Spine.AtlasRegion)Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.ToAtlasRegion(s:  s, isolatedTexture:  false);
        }
        public static Spine.AtlasRegion ToAtlasRegionPMAClone(UnityEngine.Sprite s, UnityEngine.Shader shader, UnityEngine.TextureFormat textureFormat = 4, bool mipmaps = False, UnityEngine.Material materialPropertySource)
        {
            UnityEngine.Material val_1 = new UnityEngine.Material(shader:  shader);
            if(materialPropertySource != 0)
            {
                    val_1.CopyPropertiesFromMaterial(mat:  materialPropertySource);
                val_1.shaderKeywords = materialPropertySource.shaderKeywords;
            }
            
            mipmaps = mipmaps;
            UnityEngine.Texture2D val_4 = Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.ToTexture(s:  s, applyImmediately:  false, textureFormat:  textureFormat, mipmaps:  mipmaps);
            Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.ApplyPMA(texture:  val_4, applyImmediately:  true);
            val_4.name = s.name + "-pma-"("-pma-");
            val_1.name = val_4.name + shader.name;
            val_1.mainTexture = val_4;
            val_11.page = Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.ToSpineAtlasPage(m:  val_1);
            return (Spine.AtlasRegion)Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.ToAtlasRegion(s:  s, isolatedTexture:  true);
        }
        public static Spine.AtlasRegion ToAtlasRegionPMAClone(UnityEngine.Sprite s, UnityEngine.Material materialPropertySource, UnityEngine.TextureFormat textureFormat = 4, bool mipmaps = False)
        {
            mipmaps = mipmaps;
            return Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.ToAtlasRegionPMAClone(s:  s, shader:  materialPropertySource.shader, textureFormat:  textureFormat, mipmaps:  mipmaps, materialPropertySource:  materialPropertySource);
        }
        internal static Spine.AtlasRegion ToAtlasRegion(UnityEngine.Sprite s, bool isolatedTexture = False)
        {
            var val_8;
            bool val_38;
            float val_39;
            float val_40;
            int val_41;
            .name = s.name;
            .index = 0;
            if(s.packed != false)
            {
                    var val_5 = (s.packingRotation != 0) ? 1 : 0;
            }
            else
            {
                    val_38 = false;
            }
            
            .rotate = val_38;
            UnityEngine.Bounds val_6 = s.bounds;
            UnityEngine.Vector3 val_9 = val_8.min;
            UnityEngine.Vector2 val_10 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z});
            val_39 = val_10.y;
            UnityEngine.Vector3 val_11 = val_8.max;
            UnityEngine.Vector2 val_12 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z});
            val_40 = val_12.y;
            UnityEngine.Rect val_13 = s.rect;
            UnityEngine.Rect val_16 = Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.SpineUnityFlipRect(rect:  new UnityEngine.Rect() {m_XMin = val_13.m_XMin, m_YMin = val_13.m_YMin, m_Width = val_13.m_Width, m_Height = val_13.m_Height}, textureHeight:  s.texture.height);
            float val_17 = val_16.m_XMin.width;
            val_17 = (val_17 == Infinityf) ? (-(double)val_17) : ((double)val_17);
            .width = (int)val_17;
            float val_18 = val_16.m_XMin.width;
            val_18 = (val_18 == Infinityf) ? (-(double)val_18) : ((double)val_18);
            .originalWidth = (int)val_18;
            float val_19 = val_16.m_XMin.height;
            val_19 = (val_19 == Infinityf) ? (-(double)val_19) : ((double)val_19);
            .height = (int)val_19;
            float val_20 = val_16.m_XMin.height;
            val_20 = (val_20 == Infinityf) ? (-(double)val_20) : ((double)val_20);
            .originalHeight = (int)val_20;
            float val_21 = val_16.m_XMin.width;
            float val_22 = val_12.x - val_10.x;
            val_22 = (0f - val_10.x) / val_22;
            val_22 = 0.5f - val_22;
            val_21 = val_22 * val_21;
            .offsetX = val_21;
            float val_24 = val_16.m_XMin.height;
            float val_25 = 0f - val_39;
            val_25 = val_25 / (val_40 - val_39);
            val_25 = 0.5f - val_25;
            val_24 = val_25 * val_24;
            .offsetY = val_24;
            if(isolatedTexture != false)
            {
                    val_41 = 0;
                .x = 0;
                .u = ;
                .v = ;
                .u2 = 1f;
                .v2 = 0f;
            }
            else
            {
                    UnityEngine.Texture2D val_27 = s.texture;
                UnityEngine.Rect val_28 = s.textureRect;
                val_39 = val_28.m_XMin;
                val_40 = val_28.m_Width;
                UnityEngine.Rect val_31 = Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.TextureRectToUVRect(textureRect:  new UnityEngine.Rect() {m_XMin = val_39, m_YMin = val_28.m_YMin, m_Width = val_40, m_Height = val_28.m_Height}, texWidth:  val_27.width, texHeight:  val_27.height);
                .u = val_31.m_XMin.xMin;
                .v = val_31.m_XMin.yMax;
                .u2 = val_31.m_XMin.xMax;
                .v2 = val_31.m_XMin.yMin;
                float val_36 = val_16.m_XMin.x;
                val_36 = (val_36 == Infinityf) ? (-(double)val_36) : ((double)val_36);
                .x = (int)val_36;
                float val_37 = val_16.m_XMin.y;
                val_37 = (val_37 == Infinityf) ? (-(double)val_37) : ((double)val_37);
                val_41 = (int)val_37;
            }
            
            .y = val_41;
            return (Spine.AtlasRegion)new Spine.AtlasRegion();
        }
        public static Spine.Skin GetRepackedSkin(Spine.Skin o, string newName, UnityEngine.Material materialPropertySource, out UnityEngine.Material m, out UnityEngine.Texture2D t, int maxAtlasSize = 1024, int padding = 2, UnityEngine.TextureFormat textureFormat = 4, bool mipmaps = False)
        {
            return (Spine.Skin)Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.GetRepackedSkin(o:  o, newName:  newName, shader:  materialPropertySource.shader, m: out  UnityEngine.Material val_3 = m, t: out  UnityEngine.Texture2D val_4 = t, maxAtlasSize:  maxAtlasSize, padding:  padding, textureFormat:  textureFormat, mipmaps:  mipmaps, materialPropertySource:  materialPropertySource);
        }
        public static Spine.Skin GetRepackedSkin(Spine.Skin o, string newName, UnityEngine.Shader shader, out UnityEngine.Material m, out UnityEngine.Texture2D t, int maxAtlasSize = 1024, int padding = 2, UnityEngine.TextureFormat textureFormat = 4, bool mipmaps = False, UnityEngine.Material materialPropertySource)
        {
            Spine.Attachment val_8;
            int val_9;
            var val_11;
            System.Collections.Generic.List<T> val_33;
            var val_34;
            Spine.AtlasRegion val_35;
            var val_36;
            var val_37;
            var val_39;
            if(o == null)
            {
                    throw new NullReferenceException();
            }
            
            Spine.Skin val_1 = new Spine.Skin(name:  newName);
            System.Collections.Generic.Dictionary<Spine.AtlasRegion, System.Int32> val_2 = new System.Collections.Generic.Dictionary<Spine.AtlasRegion, System.Int32>();
            System.Collections.Generic.List<System.Int32> val_3 = new System.Collections.Generic.List<System.Int32>();
            System.Collections.Generic.List<Spine.Attachment> val_4 = new System.Collections.Generic.List<Spine.Attachment>();
            System.Collections.Generic.List<UnityEngine.Texture2D> val_5 = new System.Collections.Generic.List<UnityEngine.Texture2D>();
            System.Collections.Generic.List<Spine.AtlasRegion> val_6 = null;
            val_34 = val_6;
            val_6 = new System.Collections.Generic.List<Spine.AtlasRegion>();
            if(o.attachments == null)
            {
                    throw new NullReferenceException();
            }
            
            Dictionary.Enumerator<TKey, TValue> val_7 = o.attachments.GetEnumerator();
            var val_33 = 0;
            label_14:
            if(val_11.MoveNext() == false)
            {
                goto label_3;
            }
            
            val_35 = 1;
            Spine.Attachment val_13 = Spine.Unity.Modules.AttachmentTools.AttachmentCloneExtensions.GetClone(o:  val_8, cloneMeshesAsLinked:  true);
            if((Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.IsRenderable(a:  val_13)) != false)
            {
                    Spine.AtlasRegion val_15 = Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.GetAtlasRegion(a:  val_13);
                if(val_2 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_33 = val_2;
                val_35 = val_15;
                if((val_2.TryGetValue(key:  val_35, value: out  0)) != false)
            {
                    if(val_3 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_3.Add(item:  0);
            }
            else
            {
                    val_6.Add(item:  val_15);
                val_35 = Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.ToTexture(ar:  val_15, applyImmediately:  true, textureFormat:  4, mipmaps:  false);
                val_33 = val_5;
                if(val_33 == 0)
            {
                    throw new NullReferenceException();
            }
            
                val_5.Add(item:  val_35);
                val_33 = val_2;
                val_35 = val_15;
                val_2.Add(key:  val_35, value:  0);
                if(val_3 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_33 = val_3;
                val_35 = val_33;
                val_3.Add(item:  0);
                val_33 = val_33 + 1;
            }
            
                if(val_4 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_4.Add(item:  val_13);
            }
            
            val_33 = val_1;
            if(val_33 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_1.AddAttachment(slotIndex:  val_9, name:  val_9, attachment:  val_13);
            goto label_14;
            label_3:
            val_11.Dispose();
            UnityEngine.Texture2D val_20 = new UnityEngine.Texture2D(width:  maxAtlasSize, height:  maxAtlasSize, textureFormat:  textureFormat, mipChain:  mipmaps);
            if(val_5 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(mem[1152921513312292408] == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_33 = mem[mem[1152921513312292400] + 32];
            val_33 = mem[1152921513312292400] + 32;
            if(val_33 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(val_20 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_20.anisoLevel = val_33.anisoLevel;
            val_20.name = newName;
            UnityEngine.Rect[] val_23 = val_20.PackTextures(textures:  val_5.ToArray(), padding:  padding, maximumAtlasSize:  maxAtlasSize);
            UnityEngine.Material val_24 = new UnityEngine.Material(shader:  shader);
            val_33 = materialPropertySource;
            if(val_33 != 0)
            {
                    if(val_24 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_33 = val_24;
                val_24.CopyPropertiesFromMaterial(mat:  materialPropertySource);
                if(materialPropertySource == 0)
            {
                    throw new NullReferenceException();
            }
            
                val_24.shaderKeywords = materialPropertySource.shaderKeywords;
            }
            else
            {
                    if(val_24 == null)
            {
                    throw new NullReferenceException();
            }
            
            }
            
            val_24.name = newName;
            val_24.mainTexture = val_20;
            Spine.AtlasPage val_27 = Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.ToSpineAtlasPage(m:  val_24);
            if(val_27 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_27.name = newName;
            System.Collections.Generic.List<Spine.AtlasRegion> val_28 = new System.Collections.Generic.List<Spine.AtlasRegion>();
            if(val_34 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(materialPropertySource < 1)
            {
                goto label_28;
            }
            
            val_37 = 0;
            val_39 = materialPropertySource;
            goto label_29;
            label_35:
            val_37 = 1;
            label_29:
            if(val_39 <= val_37)
            {
                    val_33 = 0;
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            if(val_23 == null)
            {
                    throw new NullReferenceException();
            }
            
            int val_34 = val_23.Length;
            val_34 = val_34 + 8;
            if(((val_23.Length + 8) + 32) == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(val_28 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_33 = val_28;
            val_28.Add(item:  Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.UVRectToAtlasRegion(uvRect:  new UnityEngine.Rect() {m_XMin = 1.106224E+18f, m_YMin = 1.106224E+18f, m_Width = 1.106224E+18f, m_Height = 1.106224E+18f}, name:  (val_23.Length + 8) + 32 + 24, page:  val_27, offsetX:  (val_23.Length + 8) + 32 + 64, offsetY:  (val_23.Length + 8) + 32 + 64 + 4, rotate:  (val_23.Length + 8) + 32 + 84));
            var val_30 = val_37 + 1;
            if(val_30 < materialPropertySource)
            {
                goto label_35;
            }
            
            label_28:
            if(val_4 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_30 < 1)
            {
                goto label_37;
            }
            
            var val_35 = 0;
            val_36 = (long)val_30;
            goto label_38;
            label_44:
            label_38:
            if(val_35 >= val_30)
            {
                    val_33 = 0;
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            if(val_3 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_30 = val_30 + 0;
            if(val_35 >= X9)
            {
                    val_33 = 0;
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            if(val_28 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_30 = val_30 + 0;
            val_34 = mem[(((val_37 + 1) + 0) + 0) + 32];
            val_34 = (((val_37 + 1) + 0) + 0) + 32;
            if(val_30 <= val_34)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_30 = val_30 + (((((val_37 + 1) + 0) + 0) + 32) << 3);
            Spine.Unity.Modules.AttachmentTools.AttachmentRegionExtensions.SetRegion(attachment:  ((val_37 + 1) + 0) + 32, region:  ((((val_37 + 1) + 0) + 0) + ((((val_37 + 1) + 0) + 0) + 32) << 3) + 32, updateOffset:  true);
            val_35 = val_35 + 1;
            if(val_35 < val_36)
            {
                goto label_44;
            }
            
            label_37:
            List.Enumerator<T> val_31 = val_5.GetEnumerator();
            label_48:
            if(0.MoveNext() == false)
            {
                goto label_45;
            }
            
            UnityEngine.Object.Destroy(obj:  0);
            goto label_48;
            label_45:
            0.Dispose();
            mem2[0] = val_20;
            mem2[0] = val_24;
            return val_1;
        }
        public static UnityEngine.Sprite ToSprite(Spine.AtlasRegion ar, float pixelsPerUnit = 100)
        {
            UnityEngine.Rect val_2 = Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.GetUnityRect(region:  ar);
            UnityEngine.Vector2 val_3 = new UnityEngine.Vector2(x:  0.5f, y:  0.5f);
            return (UnityEngine.Sprite)UnityEngine.Sprite.Create(texture:  Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.GetMainTexture(region:  ar), rect:  new UnityEngine.Rect() {m_XMin = val_2.m_XMin, m_YMin = val_2.m_YMin, m_Width = val_2.m_Width, m_Height = val_2.m_Height}, pivot:  new UnityEngine.Vector2() {x = val_3.x, y = val_3.y}, pixelsPerUnit:  pixelsPerUnit);
        }
        public static UnityEngine.Texture2D ToTexture(Spine.AtlasRegion ar, bool applyImmediately = True, UnityEngine.TextureFormat textureFormat = 4, bool mipmaps = False)
        {
            UnityEngine.Texture2D val_1 = Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.GetMainTexture(region:  ar);
            UnityEngine.Rect val_3 = Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.GetUnityRect(region:  ar, textureHeight:  val_1.height);
            float val_4 = val_3.m_XMin.width;
            val_4 = (val_4 == Infinityf) ? (-(double)val_4) : ((double)val_4);
            float val_5 = val_3.m_XMin.height;
            val_5 = (val_5 == Infinityf) ? (-(double)val_5) : ((double)val_5);
            UnityEngine.Texture2D val_7 = new UnityEngine.Texture2D(width:  (int)val_4, height:  (int)val_5, textureFormat:  textureFormat, mipChain:  mipmaps);
            val_7.name = ar.name;
            float val_8 = val_3.m_XMin.x;
            float val_9 = val_3.m_XMin.y;
            double val_11 = (double)val_8;
            val_11 = (val_8 == Infinityf) ? (-val_11) : (val_11);
            val_9 = (val_9 == Infinityf) ? (-(double)val_9) : ((double)val_9);
            val_7.SetPixels(colors:  val_1.GetPixels(x:  (int)val_11, y:  (int)val_9, blockWidth:  (int)val_4, blockHeight:  (int)val_5));
            if(applyImmediately == false)
            {
                    return val_7;
            }
            
            val_7.Apply();
            return val_7;
        }
        private static UnityEngine.Texture2D ToTexture(UnityEngine.Sprite s, bool applyImmediately = True, UnityEngine.TextureFormat textureFormat = 4, bool mipmaps = False)
        {
            UnityEngine.Rect val_2 = s.textureRect;
            float val_3 = val_2.m_XMin.x;
            float val_4 = val_2.m_XMin.y;
            float val_5 = val_2.m_XMin.width;
            float val_6 = val_2.m_XMin.height;
            double val_15 = (double)val_3;
            val_15 = (val_3 == Infinityf) ? (-val_15) : (val_15);
            val_6 = (val_6 == Infinityf) ? (-(double)val_6) : ((double)val_6);
            float val_10 = val_2.m_XMin.width;
            float val_11 = val_2.m_XMin.height;
            UnityEngine.Texture2D val_14 = null;
            double val_16 = (double)val_10;
            val_16 = (val_10 == Infinityf) ? (-val_16) : (val_16);
            val_14 = new UnityEngine.Texture2D(width:  (int)val_16, height:  (int)(val_11 == Infinityf) ? (-(double)val_11) : ((double)val_11), textureFormat:  textureFormat, mipChain:  mipmaps);
            val_14.SetPixels(colors:  s.texture.GetPixels(x:  (int)val_15, y:  (int)(val_4 == Infinityf) ? (-(double)val_4) : ((double)val_4), blockWidth:  (int)(val_5 == Infinityf) ? (-(double)val_5) : ((double)val_5), blockHeight:  (int)val_6));
            if(applyImmediately == false)
            {
                    return val_14;
            }
            
            val_14.Apply();
            return val_14;
        }
        private static UnityEngine.Texture2D GetClone(UnityEngine.Texture2D t, bool applyImmediately = True, UnityEngine.TextureFormat textureFormat = 4, bool mipmaps = False)
        {
            UnityEngine.Texture2D val_7 = new UnityEngine.Texture2D(width:  t.width, height:  t.height, textureFormat:  textureFormat, mipChain:  mipmaps);
            val_7.SetPixels(colors:  t.GetPixels(x:  0, y:  0, blockWidth:  t.width, blockHeight:  t.height));
            if(applyImmediately == false)
            {
                    return val_7;
            }
            
            val_7.Apply();
            return val_7;
        }
        private static bool IsRenderable(Spine.Attachment a)
        {
            var val_3 = 0;
            return (bool);
        }
        private static UnityEngine.Rect SpineUnityFlipRect(UnityEngine.Rect rect, int textureHeight)
        {
            float val_2 = rect.m_XMin.height;
            float val_3 = (float)textureHeight;
            val_3 = val_3 - rect.m_XMin.y;
            val_2 = val_3 - val_2;
            rect.m_XMin.y = val_2;
            return new UnityEngine.Rect() {m_XMin = rect.m_XMin, m_YMin = rect.m_YMin, m_Width = rect.m_Width, m_Height = rect.m_Height};
        }
        private static UnityEngine.Rect GetUnityRect(Spine.AtlasRegion region)
        {
            UnityEngine.Rect val_1 = Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.GetSpineAtlasRect(region:  region, includeRotate:  true);
            return Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.SpineUnityFlipRect(rect:  new UnityEngine.Rect() {m_XMin = val_1.m_XMin, m_YMin = val_1.m_YMin, m_Width = val_1.m_Width, m_Height = val_1.m_Height}, textureHeight:  region.page.height);
        }
        private static UnityEngine.Rect GetUnityRect(Spine.AtlasRegion region, int textureHeight)
        {
            UnityEngine.Rect val_1 = Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.GetSpineAtlasRect(region:  region, includeRotate:  true);
            return Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.SpineUnityFlipRect(rect:  new UnityEngine.Rect() {m_XMin = val_1.m_XMin, m_YMin = val_1.m_YMin, m_Width = val_1.m_Width, m_Height = val_1.m_Height}, textureHeight:  textureHeight);
        }
        private static UnityEngine.Rect GetSpineAtlasRect(Spine.AtlasRegion region, bool includeRotate = True)
        {
            int val_2;
            int val_3;
            int val_4;
            int val_5;
            if(includeRotate == false)
            {
                goto label_0;
            }
            
            if(region.rotate == false)
            {
                goto label_2;
            }
            
            val_2 = region.x;
            val_3 = region.y;
            val_5 = region.width;
            val_4 = region.height;
            goto label_3;
            label_0:
            label_2:
            val_2 = region.x;
            val_3 = region.y;
            val_4 = region.width;
            val_5 = region.height;
            label_3:
            UnityEngine.Rect val_1 = new UnityEngine.Rect(x:  (float)val_2, y:  (float)val_3, width:  (float)val_4, height:  (float)val_5);
            return new UnityEngine.Rect() {m_XMin = val_1.m_XMin, m_YMin = val_1.m_YMin, m_Width = val_1.m_Width, m_Height = val_1.m_Height};
        }
        private static UnityEngine.Rect UVRectToTextureRect(UnityEngine.Rect uvRect, int texWidth, int texHeight)
        {
            float val_1 = uvRect.m_XMin.x;
            val_1 = val_1 * (float)texWidth;
            uvRect.m_XMin.x = val_1;
            float val_2 = uvRect.m_XMin.width;
            val_2 = val_2 * (float)texWidth;
            uvRect.m_XMin.width = val_2;
            float val_3 = uvRect.m_XMin.y;
            val_3 = val_3 * (float)texHeight;
            uvRect.m_XMin.y = val_3;
            float val_4 = uvRect.m_XMin.height;
            val_4 = val_4 * (float)texHeight;
            uvRect.m_XMin.height = val_4;
            return new UnityEngine.Rect() {m_XMin = uvRect.m_XMin, m_YMin = uvRect.m_YMin, m_Width = uvRect.m_Width, m_Height = uvRect.m_Height};
        }
        private static UnityEngine.Rect TextureRectToUVRect(UnityEngine.Rect textureRect, int texWidth, int texHeight)
        {
            textureRect.m_XMin.x = UnityEngine.Mathf.InverseLerp(a:  0f, b:  (float)texWidth, value:  textureRect.m_XMin.x);
            textureRect.m_XMin.y = UnityEngine.Mathf.InverseLerp(a:  0f, b:  (float)texHeight, value:  textureRect.m_XMin.y);
            textureRect.m_XMin.width = UnityEngine.Mathf.InverseLerp(a:  0f, b:  (float)texWidth, value:  textureRect.m_XMin.width);
            textureRect.m_XMin.height = UnityEngine.Mathf.InverseLerp(a:  0f, b:  (float)texHeight, value:  textureRect.m_XMin.height);
            return new UnityEngine.Rect() {m_XMin = textureRect.m_XMin, m_YMin = textureRect.m_YMin, m_Width = textureRect.m_Width, m_Height = textureRect.m_Height};
        }
        private static Spine.AtlasRegion UVRectToAtlasRegion(UnityEngine.Rect uvRect, string name, Spine.AtlasPage page, float offsetX, float offsetY, bool rotate)
        {
            UnityEngine.Rect val_1 = Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.UVRectToTextureRect(uvRect:  new UnityEngine.Rect() {m_XMin = uvRect.m_XMin, m_YMin = uvRect.m_YMin, m_Width = uvRect.m_Width, m_Height = uvRect.m_Height}, texWidth:  page.width, texHeight:  page.height);
            UnityEngine.Rect val_2 = Spine.Unity.Modules.AttachmentTools.SpriteAtlasRegionExtensions.SpineUnityFlipRect(rect:  new UnityEngine.Rect() {m_XMin = val_1.m_XMin, m_YMin = val_1.m_YMin, m_Width = val_1.m_Width, m_Height = val_1.m_Height}, textureHeight:  page.height);
            float val_3 = val_2.m_XMin.x;
            float val_5 = val_2.m_XMin.y;
            if(rotate != false)
            {
                    float val_7 = val_2.m_XMin.height;
                var val_8 = (val_7 == Infinityf) ? (-(double)val_7) : ((double)val_7);
                float val_9 = val_2.m_XMin.width;
            }
            else
            {
                    float val_10 = val_2.m_XMin.width;
                float val_12 = val_2.m_XMin.height;
            }
            
            .page = page;
            .name = name;
            .u = uvRect.m_XMin.xMin;
            .u2 = uvRect.m_XMin.xMax;
            .v = uvRect.m_XMin.yMax;
            .width = (int)(val_10 == Infinityf) ? (-(double)val_10) : ((double)val_10);
            .height = (int)(val_12 == Infinityf) ? (-(double)val_12) : ((double)val_12);
            .originalWidth = (int)(val_10 == Infinityf) ? (-(double)val_10) : ((double)val_10);
            .originalHeight = (int)(val_12 == Infinityf) ? (-(double)val_12) : ((double)val_12);
            .v2 = uvRect.m_XMin.yMin;
            .offsetX = offsetX;
            .offsetY = offsetY;
            .x = (int)(val_3 == Infinityf) ? (-(double)val_3) : ((double)val_3);
            .y = (int)(val_5 == Infinityf) ? (-(double)val_5) : ((double)val_5);
            .index = 0;
            .rotate = rotate;
            return (Spine.AtlasRegion)new Spine.AtlasRegion();
        }
        private static Spine.AtlasRegion GetAtlasRegion(Spine.Attachment a)
        {
            var val_4;
            var val_5;
            if(a != null)
            {
                    val_4 = 0;
                var val_2 = (((Spine.Attachment.__il2cppRuntimeField_typeHierarchy + (Spine.MeshAttachment.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8) == null) ? a : 0;
                val_5 = mem[(Spine.Attachment.__il2cppRuntimeField_typeHierarchy + (Spine.MeshAttachment.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8 == null ? a : 0 + 144];
                val_5 = (Spine.Attachment.__il2cppRuntimeField_typeHierarchy + (Spine.MeshAttachment.__il2cppRuntimeField_typeHierarchyDepth) << 3) + -8 == null ? a : 0 + 144;
            }
            
            val_4 = 0;
            return (Spine.AtlasRegion)val_4;
        }
        private static UnityEngine.Texture2D GetMainTexture(Spine.AtlasRegion region)
        {
            UnityEngine.Texture val_1 = region.page.rendererObject.mainTexture;
            if(val_1 == null)
            {
                    return (UnityEngine.Texture2D)(null == null) ? (val_1) : 0;
            }
            
            return (UnityEngine.Texture2D)(null == null) ? (val_1) : 0;
        }
        private static void ApplyPMA(UnityEngine.Texture2D texture, bool applyImmediately = True)
        {
            UnityEngine.Color[] val_1 = texture.GetPixels();
            int val_3 = val_1.Length;
            if(val_3 >= 1)
            {
                    val_3 = val_3 & 4294967295;
                var val_4 = 0;
                do
            {
                val_4 = val_4 + 1;
                mem2[0] = null;
                mem2[0] = S2 * S1;
            }
            while(val_4 < (long)val_3);
            
            }
            
            texture.SetPixels(colors:  val_1);
            if(applyImmediately == false)
            {
                    return;
            }
            
            texture.Apply();
        }
        private static float InverseLerp(float a, float b, float value)
        {
            value = value - a;
            a = b - a;
            a = value / a;
            return (float)a;
        }
    
    }

}
