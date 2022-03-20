using UnityEngine;

namespace Spine
{
    public static class SkeletonExtensions
    {
        // Methods
        public static bool IsWeighted(Spine.VertexAttachment va)
        {
            if(va != null)
            {
                    if(va.bones == null)
            {
                    return false;
            }
            
                return (bool)(va.bones.Length != 0) ? 1 : 0;
            }
            
            throw new NullReferenceException();
        }
        public static bool InheritsRotation(Spine.TransformMode mode)
        {
            return (bool)((mode & 1) != 0) ? 1 : 0;
        }
        public static bool InheritsScale(Spine.TransformMode mode)
        {
            return (bool)((mode & 2) != 0) ? 1 : 0;
        }
        internal static void SetPropertyToSetupPose(Spine.Skeleton skeleton, int propertyID)
        {
            if((propertyID >> 24) > 14)
            {
                    return;
            }
            
            var val_22 = 30113312 + ((propertyID >> 24)) << 2;
            propertyID = propertyID & 16777215;
            val_22 = val_22 + 30113312;
            goto (30113312 + ((propertyID >> 24)) << 2 + 30113312);
        }
        public static void SetDrawOrderToSetupPose(Spine.Skeleton skeleton)
        {
            skeleton.drawOrder.Clear(clearArray:  false);
            skeleton.drawOrder.GrowIfNeeded(newCount:  41934848);
            System.Array.Copy(sourceArray:  X21, destinationArray:  41934848, length:  41934848);
        }
        public static void SetColorToSetupPose(Spine.Slot slot)
        {
            slot.r = slot.data.r;
            slot.g = slot.data.g;
            slot.b = slot.data.b;
            slot.a = slot.data.a;
            slot.r2 = slot.data.r2;
            slot.g2 = slot.data.g2;
            slot.b2 = slot.data.b2;
        }
        public static void SetAttachmentToSetupPose(Spine.Slot slot)
        {
            slot.Attachment = slot.bone.skeleton.GetAttachment(slotName:  slot.data.name, attachmentName:  slot.data.attachmentName);
        }
        public static void SetSlotAttachmentToSetupPose(Spine.Skeleton skeleton, int slotIndex)
        {
            Spine.Attachment val_3;
            Spine.ExposedList<Spine.Slot> val_3 = skeleton.slots;
            val_3 = val_3 + (slotIndex << 3);
            if((System.String.IsNullOrEmpty(value:  X21 + 16 + 72)) != false)
            {
                    val_3 = 0;
            }
            else
            {
                    val_3 = skeleton.GetAttachment(slotIndex:  slotIndex, attachmentName:  X21 + 16 + 72);
            }
            
            X21.Attachment = val_3;
        }
        public static void PoseWithAnimation(Spine.Skeleton skeleton, string animationName, float time, bool loop = False)
        {
            Spine.Animation val_1 = skeleton.data.FindAnimation(animationName:  animationName);
            if(val_1 == null)
            {
                    return;
            }
            
            loop = loop;
            val_1.Apply(skeleton:  skeleton, lastTime:  0f, time:  time, loop:  loop, events:  0, alpha:  1f, pose:  0, direction:  0);
        }
        public static void PoseSkeleton(Spine.Animation animation, Spine.Skeleton skeleton, float time, bool loop = False)
        {
            if(animation != null)
            {
                    animation.Apply(skeleton:  skeleton, lastTime:  0f, time:  time, loop:  loop, events:  0, alpha:  1f, pose:  0, direction:  0);
                return;
            }
            
            throw new NullReferenceException();
        }
        public static void SetKeyedItemsToSetupPose(Spine.Animation animation, Spine.Skeleton skeleton)
        {
            if(animation != null)
            {
                    animation.Apply(skeleton:  skeleton, lastTime:  0f, time:  0f, loop:  false, events:  0, alpha:  0f, pose:  0, direction:  1);
                return;
            }
            
            throw new NullReferenceException();
        }
        public static void FindNamesForSlot(Spine.Skin skin, string slotName, Spine.SkeletonData skeletonData, System.Collections.Generic.List<string> results)
        {
            skin.FindNamesForSlot(slotIndex:  skeletonData.FindSlotIndex(slotName:  slotName), names:  results);
        }
        public static void FindAttachmentsForSlot(Spine.Skin skin, string slotName, Spine.SkeletonData skeletonData, System.Collections.Generic.List<Spine.Attachment> results)
        {
            skin.FindAttachmentsForSlot(slotIndex:  skeletonData.FindSlotIndex(slotName:  slotName), attachments:  results);
        }
    
    }

}
