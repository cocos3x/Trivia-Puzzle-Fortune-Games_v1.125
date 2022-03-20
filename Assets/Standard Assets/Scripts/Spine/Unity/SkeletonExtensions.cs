using UnityEngine;

namespace Spine.Unity
{
    public static class SkeletonExtensions
    {
        // Fields
        private const float ByteToFloat = 0.003921569;
        
        // Methods
        public static UnityEngine.Color GetColor(Spine.Skeleton s)
        {
            UnityEngine.Color val_1 = new UnityEngine.Color(r:  s.r, g:  s.g, b:  s.b, a:  s.a);
            return new UnityEngine.Color() {r = val_1.r, g = val_1.g, b = val_1.b, a = val_1.a};
        }
        public static UnityEngine.Color GetColor(Spine.RegionAttachment a)
        {
            UnityEngine.Color val_1 = new UnityEngine.Color(r:  a.r, g:  a.g, b:  a.b, a:  a.a);
            return new UnityEngine.Color() {r = val_1.r, g = val_1.g, b = val_1.b, a = val_1.a};
        }
        public static UnityEngine.Color GetColor(Spine.MeshAttachment a)
        {
            UnityEngine.Color val_1 = new UnityEngine.Color(r:  a.r, g:  a.g, b:  a.b, a:  a.a);
            return new UnityEngine.Color() {r = val_1.r, g = val_1.g, b = val_1.b, a = val_1.a};
        }
        public static void SetColor(Spine.Skeleton skeleton, UnityEngine.Color color)
        {
            if(skeleton != null)
            {
                    skeleton.b = color.b;
                skeleton.a = color.a;
                skeleton.r = color.r;
                skeleton.g = color.g;
                return;
            }
            
            throw new NullReferenceException();
        }
        public static void SetColor(Spine.Skeleton skeleton, UnityEngine.Color32 color)
        {
            if(skeleton != null)
            {
                    byte val_1 = color.r >> 8;
                byte val_2 = color.r >> 16;
                byte val_3 = color.r >> 24;
                double val_4 = (double)color.r;
                val_4 = val_4 * V1.4S;
                skeleton.r = val_4;
                return;
            }
            
            throw new NullReferenceException();
        }
        public static void SetColor(Spine.Slot slot, UnityEngine.Color color)
        {
            if(slot != null)
            {
                    slot.b = color.b;
                slot.a = color.a;
                slot.r = color.r;
                slot.g = color.g;
                return;
            }
            
            throw new NullReferenceException();
        }
        public static void SetColor(Spine.Slot slot, UnityEngine.Color32 color)
        {
            if(slot != null)
            {
                    byte val_1 = color.r >> 8;
                byte val_2 = color.r >> 16;
                byte val_3 = color.r >> 24;
                double val_4 = (double)color.r;
                val_4 = val_4 * V1.4S;
                slot.r = val_4;
                return;
            }
            
            throw new NullReferenceException();
        }
        public static void SetColor(Spine.RegionAttachment attachment, UnityEngine.Color color)
        {
            if(attachment != null)
            {
                    attachment.b = color.b;
                attachment.a = color.a;
                attachment.r = color.r;
                attachment.g = color.g;
                return;
            }
            
            throw new NullReferenceException();
        }
        public static void SetColor(Spine.RegionAttachment attachment, UnityEngine.Color32 color)
        {
            if(attachment != null)
            {
                    byte val_1 = color.r >> 8;
                byte val_2 = color.r >> 16;
                byte val_3 = color.r >> 24;
                double val_4 = (double)color.r;
                val_4 = val_4 * V1.4S;
                attachment.r = val_4;
                return;
            }
            
            throw new NullReferenceException();
        }
        public static void SetColor(Spine.MeshAttachment attachment, UnityEngine.Color color)
        {
            if(attachment != null)
            {
                    attachment.b = color.b;
                attachment.a = color.a;
                attachment.r = color.r;
                attachment.g = color.g;
                return;
            }
            
            throw new NullReferenceException();
        }
        public static void SetColor(Spine.MeshAttachment attachment, UnityEngine.Color32 color)
        {
            if(attachment != null)
            {
                    byte val_1 = color.r >> 8;
                byte val_2 = color.r >> 16;
                byte val_3 = color.r >> 24;
                double val_4 = (double)color.r;
                val_4 = val_4 * V1.4S;
                attachment.r = val_4;
                return;
            }
            
            throw new NullReferenceException();
        }
        public static void SetPosition(Spine.Bone bone, UnityEngine.Vector2 position)
        {
            if(bone != null)
            {
                    bone.x = position.x;
                bone.y = position.y;
                return;
            }
            
            throw new NullReferenceException();
        }
        public static void SetPosition(Spine.Bone bone, UnityEngine.Vector3 position)
        {
            if(bone != null)
            {
                    bone.x = position.x;
                bone.y = position.y;
                return;
            }
            
            throw new NullReferenceException();
        }
        public static UnityEngine.Vector2 GetLocalPosition(Spine.Bone bone)
        {
            UnityEngine.Vector2 val_1 = new UnityEngine.Vector2(x:  bone.x, y:  bone.y);
            return new UnityEngine.Vector2() {x = val_1.x, y = val_1.y};
        }
        public static UnityEngine.Vector2 GetSkeletonSpacePosition(Spine.Bone bone)
        {
            UnityEngine.Vector2 val_1 = new UnityEngine.Vector2(x:  bone.worldX, y:  bone.worldY);
            return new UnityEngine.Vector2() {x = val_1.x, y = val_1.y};
        }
        public static UnityEngine.Vector2 GetSkeletonSpacePosition(Spine.Bone bone, UnityEngine.Vector2 boneLocal)
        {
            bone.LocalToWorld(localX:  boneLocal.x, localY:  boneLocal.y, worldX: out  float val_1 = 2.401511E-36f, worldY: out  float val_2 = 2.401512E-36f);
            return new UnityEngine.Vector2() {x = 0f, y = 0f};
        }
        public static UnityEngine.Vector3 GetWorldPosition(Spine.Bone bone, UnityEngine.Transform spineGameObjectTransform)
        {
            UnityEngine.Vector3 val_1 = new UnityEngine.Vector3(x:  bone.worldX, y:  bone.worldY);
            UnityEngine.Vector3 val_2 = spineGameObjectTransform.TransformPoint(position:  new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z});
            return new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z};
        }
        public static UnityEngine.Quaternion GetQuaternion(Spine.Bone bone)
        {
            float val_2 = bone.c;
            val_2 = val_2 * 0.5f;
            UnityEngine.Quaternion val_1 = new UnityEngine.Quaternion(x:  0f, y:  0f, z:  val_2, w:  val_2);
            return new UnityEngine.Quaternion() {x = val_1.x, y = val_1.y, z = val_1.z, w = val_1.w};
        }
        public static UnityEngine.Vector3 GetWorldPosition(Spine.PointAttachment attachment, Spine.Slot slot, UnityEngine.Transform spineGameObjectTransform)
        {
            attachment.ComputeWorldPosition(bone:  slot.bone, ox: out  0f, oy: out  float val_2 = 2.469856E-36f);
            UnityEngine.Vector3 val_3 = spineGameObjectTransform.TransformPoint(position:  new UnityEngine.Vector3() {x = 0f, y = 0f, z = 0f});
            return new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
        }
        public static UnityEngine.Vector3 GetWorldPosition(Spine.PointAttachment attachment, Spine.Bone bone, UnityEngine.Transform spineGameObjectTransform)
        {
            attachment.ComputeWorldPosition(bone:  bone, ox: out  0f, oy: out  float val_2 = 2.495088E-36f);
            UnityEngine.Vector3 val_3 = spineGameObjectTransform.TransformPoint(position:  new UnityEngine.Vector3() {x = 0f, y = 0f, z = 0f});
            return new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
        }
        public static UnityEngine.Matrix4x4 GetMatrix4x4(Spine.Bone bone)
        {
            UnityEngine.Matrix4x4 val_0;
            val_0.m21 = 0f;
            val_0.m31 = 0f;
            val_0.m02 = 0f;
            val_0.m12 = 0f;
            val_0.m20 = 0f;
            val_0.m30 = 0f;
            val_0.m00 = bone.a;
            val_0.m10 = bone.c;
            val_0.m01 = bone.b;
            val_0.m11 = bone.d;
            val_0.m22 = 0f;
            val_0.m32 = 0f;
            val_0.m03 = bone.worldX;
            val_0.m13 = bone.worldY;
            val_0.m23 = 0f;
            val_0.m33 = 1f;
            return val_0;
        }
        public static void GetWorldToLocalMatrix(Spine.Bone bone, out float ia, out float ib, out float ic, out float id)
        {
            if(bone != null)
            {
                    float val_5 = bone.c;
                float val_3 = bone.d;
                float val_6 = bone.a;
                float val_4 = bone.b;
                float val_1 = val_6 * val_3;
                val_1 = val_1 - (val_4 * val_5);
                val_1 = 1f / val_1;
                val_3 = val_3 * val_1;
                val_4 = -(val_4 * val_1);
                val_5 = -(val_5 * val_1);
                val_6 = val_6 * val_1;
                ia = val_3;
                ib = val_4;
                ic = val_5;
                id = val_6;
                return;
            }
            
            throw new NullReferenceException();
        }
        public static UnityEngine.Vector2 WorldToLocal(Spine.Bone bone, UnityEngine.Vector2 worldPosition)
        {
            bone.WorldToLocal(worldX:  worldPosition.x, worldY:  worldPosition.y, localX: out  float val_1 = 2.56848E-36f, localY: out  float val_2 = 2.56848E-36f);
            return new UnityEngine.Vector2() {x = 0f, y = 0f};
        }
        public static UnityEngine.Material GetMaterial(Spine.Attachment a)
        {
            var val_2;
            if(a != null)
            {
                    val_2 = 0;
                if(val_2 == 0)
            {
                    return (UnityEngine.Material)val_2;
            }
            
                val_2 = mem[4306960435];
                if(val_2 == 0)
            {
                    return (UnityEngine.Material)val_2;
            }
            
            }
            
            val_2 = 0;
            return (UnityEngine.Material)val_2;
        }
        public static UnityEngine.Vector2[] GetLocalVertices(Spine.VertexAttachment va, Spine.Slot slot, UnityEngine.Vector2[] buffer)
        {
            var val_15;
            Spine.Slot val_16;
            var val_17;
            val_15 = buffer;
            val_16 = slot;
            val_17 = va.worldVerticesLength >> 1;
            if(val_15 == null)
            {
                    val_15 = new UnityEngine.Vector2[0];
            }
            
            if(val_17 > val_1.Length)
            {
                    throw new System.ArgumentException(message:  System.String.Format(format:  "Vector2 buffer too small. {0} requires an array of size {1}. Use the attachment\'s .WorldVerticesLength to get the correct size.", arg0:  ??? + 16, arg1:  ???), paramName:  "buffer");
            }
            
            if(va.bones != null)
            {
                    float[] val_2 = new float[0];
                va.ComputeWorldVertices(slot:  val_16, worldVertices:  val_2);
                Spine.Unity.SkeletonExtensions.GetWorldToLocalMatrix(bone:  slot.bone, ia: out  float val_3 = 2.636803E-36f, ib: out  float val_4 = 2.636802E-36f, ic: out  float val_5 = 2.636802E-36f, id: out  float val_6 = 2.636801E-36f);
                if(va.worldVerticesLength < 2)
            {
                    return (UnityEngine.Vector2[])val_15;
            }
            
                var val_18 = 0;
                val_17 = (long)val_17;
                do
            {
                var val_7 = val_18 + 1;
                float val_16 = val_2[0];
                float val_17 = val_2[0];
                val_16 = val_16 - slot.bone.worldX;
                val_17 = val_17 - slot.bone.worldY;
                val_17 = val_17 * 0f;
                val_16 = (val_16 * 0f) + (val_17 * 0f);
                val_17 = (val_16 * 0f) + val_17;
                UnityEngine.Vector2 val_11 = new UnityEngine.Vector2(x:  val_16, y:  val_17);
                val_18 = val_18 + 2;
                mem2[0] = val_11.x;
                val_16 = 0 + 1;
            }
            while(val_16 < val_17);
            
                return (UnityEngine.Vector2[])val_15;
            }
            
            if(va.worldVerticesLength < 2)
            {
                    return (UnityEngine.Vector2[])val_15;
            }
            
            var val_21 = 0;
            val_17 = (long)val_17;
            do
            {
                var val_12 = val_21 + 1;
                UnityEngine.Vector2 val_13 = new UnityEngine.Vector2(x:  va.vertices[val_21], y:  va.vertices[val_21]);
                val_21 = val_21 + 2;
                mem2[0] = val_13.x;
                val_16 = 0 + 1;
            }
            while(val_16 < val_17);
            
            return (UnityEngine.Vector2[])val_15;
        }
        public static UnityEngine.Vector2[] GetWorldVertices(Spine.VertexAttachment a, Spine.Slot slot, UnityEngine.Vector2[] buffer)
        {
            var val_7;
            var val_8;
            int val_9;
            val_7 = buffer;
            val_8 = a;
            val_9 = a.worldVerticesLength;
            int val_1 = val_9 >> 1;
            if(val_7 == null)
            {
                    val_7 = new UnityEngine.Vector2[0];
            }
            
            if(val_1 > val_2.Length)
            {
                    throw new System.ArgumentException(message:  System.String.Format(format:  "Vector2 buffer too small. {0} requires an array of size {1}. Use the attachment\'s .WorldVerticesLength to get the correct size.", arg0:  ??? + 16, arg1:  ???), paramName:  "buffer");
            }
            
            float[] val_3 = new float[0];
            val_8.ComputeWorldVertices(slot:  slot, worldVertices:  val_3);
            if(val_9 < 2)
            {
                    return (UnityEngine.Vector2[])val_7;
            }
            
            var val_10 = 0;
            val_9 = (long)val_1;
            do
            {
                var val_4 = 0 + 1;
                UnityEngine.Vector2 val_5 = new UnityEngine.Vector2(x:  val_3[0], y:  val_3[0]);
                val_8 = 0 + 2;
                mem2[0] = val_5.x;
                val_10 = val_10 + 1;
            }
            while(val_10 < val_9);
            
            return (UnityEngine.Vector2[])val_7;
        }
    
    }

}
