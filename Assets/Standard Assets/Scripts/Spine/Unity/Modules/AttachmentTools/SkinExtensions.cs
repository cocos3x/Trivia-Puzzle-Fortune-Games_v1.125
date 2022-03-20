using UnityEngine;

namespace Spine.Unity.Modules.AttachmentTools
{
    public static class SkinExtensions
    {
        // Methods
        public static Spine.Skin UnshareSkin(Spine.Skeleton skeleton, bool includeDefaultSkin, bool unshareAttachments, Spine.AnimationState state)
        {
            Spine.Skin val_3 = Spine.Unity.Modules.AttachmentTools.SkinExtensions.GetClonedSkin(skeleton:  skeleton, newSkinName:  "cloned skin", includeDefaultSkin:  includeDefaultSkin, cloneAttachments:  unshareAttachments, cloneMeshesAsLinked:  true);
            skeleton.SetSkin(newSkin:  val_3);
            if(state == null)
            {
                    return val_3;
            }
            
            skeleton.SetToSetupPose();
            bool val_4 = state.Apply(skeleton:  skeleton);
            return val_3;
        }
        public static Spine.Skin GetClonedSkin(Spine.Skeleton skeleton, string newSkinName, bool includeDefaultSkin = False, bool cloneAttachments = False, bool cloneMeshesAsLinked = True)
        {
            Spine.Skin val_1 = new Spine.Skin(name:  newSkinName);
            if(includeDefaultSkin != false)
            {
                    cloneAttachments = cloneAttachments;
                cloneMeshesAsLinked = cloneMeshesAsLinked;
                Spine.Unity.Modules.AttachmentTools.SkinExtensions.CopyTo(source:  skeleton.data.defaultSkin, destination:  val_1, overwrite:  true, cloneAttachments:  cloneAttachments, cloneMeshesAsLinked:  cloneMeshesAsLinked);
            }
            
            if(skeleton.skin == null)
            {
                    return val_1;
            }
            
            Spine.Unity.Modules.AttachmentTools.SkinExtensions.CopyTo(source:  skeleton.skin, destination:  val_1, overwrite:  true, cloneAttachments:  cloneAttachments, cloneMeshesAsLinked:  cloneMeshesAsLinked);
            return val_1;
        }
        public static Spine.Skin GetClone(Spine.Skin original)
        {
            Dictionary.Enumerator<TKey, TValue> val_3 = original.attachments.GetEnumerator();
            label_6:
            if(0.MoveNext() == false)
            {
                goto label_4;
            }
            
            if((Spine.Skin)[1152921513315215184].attachments == null)
            {
                    throw new NullReferenceException();
            }
            
            (Spine.Skin)[1152921513315215184].attachments.set_Item(key:  new AttachmentKeyTuple() {slotIndex = 118377232, nameHashCode = 21825824}, value:  null);
            goto label_6;
            label_4:
            0.Dispose();
            return (Spine.Skin)new Spine.Skin(name:  original.name + " clone");
        }
        public static void SetAttachment(Spine.Skin skin, string slotName, string keyName, Spine.Attachment attachment, Spine.Skeleton skeleton)
        {
            int val_1 = skeleton.FindSlotIndex(slotName:  slotName);
            if(val_1 == 1)
            {
                    throw new System.ArgumentException(message:  System.String.Format(format:  "Slot \'{0}\' does not exist in skeleton.", arg0:  ???), paramName:  "slotName");
            }
            
            skin.AddAttachment(slotIndex:  val_1, name:  keyName, attachment:  attachment);
        }
        public static Spine.Attachment GetAttachment(Spine.Skin skin, string slotName, string keyName, Spine.Skeleton skeleton)
        {
            int val_1 = skeleton.FindSlotIndex(slotName:  slotName);
            if(val_1 == 1)
            {
                    throw new System.ArgumentException(message:  System.String.Format(format:  "Slot \'{0}\' does not exist in skeleton.", arg0:  ???), paramName:  "slotName");
            }
            
            return skin.GetAttachment(slotIndex:  val_1, name:  keyName);
        }
        public static void SetAttachment(Spine.Skin skin, int slotIndex, string keyName, Spine.Attachment attachment)
        {
            if(skin != null)
            {
                    skin.AddAttachment(slotIndex:  slotIndex, name:  keyName, attachment:  attachment);
                return;
            }
            
            throw new NullReferenceException();
        }
        public static bool RemoveAttachment(Spine.Skin skin, string slotName, string keyName, Spine.Skeleton skeleton)
        {
            int val_1 = skeleton.FindSlotIndex(slotName:  slotName);
            if(val_1 == 1)
            {
                    throw new System.ArgumentException(message:  System.String.Format(format:  "Slot \'{0}\' does not exist in skeleton.", arg0:  ???), paramName:  "slotName");
            }
            
            return Spine.Unity.Modules.AttachmentTools.SkinExtensions.RemoveAttachment(skin:  skin, slotIndex:  val_1, keyName:  keyName);
        }
        public static bool RemoveAttachment(Spine.Skin skin, int slotIndex, string keyName)
        {
            return (bool)skin.attachments.Remove(key:  new AttachmentKeyTuple() {slotIndex = 119158600, name = public System.Boolean System.Collections.Generic.Dictionary<AttachmentKeyTuple, Spine.Attachment>::Remove(AttachmentKeyTuple key)});
        }
        public static void Clear(Spine.Skin skin)
        {
            skin.attachments.Clear();
        }
        public static void Append(Spine.Skin destination, Spine.Skin source)
        {
            Spine.Unity.Modules.AttachmentTools.SkinExtensions.CopyTo(source:  source, destination:  destination, overwrite:  true, cloneAttachments:  false, cloneMeshesAsLinked:  true);
        }
        public static void CopyTo(Spine.Skin source, Spine.Skin destination, bool overwrite, bool cloneAttachments, bool cloneMeshesAsLinked = True)
        {
            var val_3;
            Spine.Attachment val_4;
            var val_5;
            var val_19;
            bool val_20;
            bool val_21;
            Spine.Attachment val_24;
            var val_25;
            var val_28;
            var val_29;
            val_19;
            val_20 = cloneMeshesAsLinked;
            val_21 = overwrite;
            if(cloneAttachments == false)
            {
                goto label_3;
            }
            
            if(val_21 == false)
            {
                goto label_4;
            }
            
            Dictionary.Enumerator<TKey, TValue> val_1 = source.attachments.GetEnumerator();
            label_8:
            if(val_5.MoveNext() == false)
            {
                goto label_14;
            }
            
            val_3 = val_4;
            val_5 = val_3;
            if(destination.attachments == null)
            {
                    throw new NullReferenceException();
            }
            
            destination.attachments.set_Item(key:  new AttachmentKeyTuple() {slotIndex = 119567184, name = Spine.Unity.Modules.AttachmentTools.AttachmentCloneExtensions.GetClone(o:  val_4, cloneMeshesAsLinked:  val_20), nameHashCode = 21825824}, value:  cloneMeshesAsLinked);
            goto label_8;
            label_4:
            Dictionary.Enumerator<TKey, TValue> val_9 = source.attachments.GetEnumerator();
            val_21 = 1152921513316330800;
            label_17:
            if(val_5.MoveNext() == false)
            {
                goto label_14;
            }
            
            val_24 = val_4;
            val_3 = val_4;
            val_5 = val_3;
            if(destination.attachments == null)
            {
                    throw new NullReferenceException();
            }
            
            if((destination.attachments.ContainsKey(key:  new AttachmentKeyTuple() {slotIndex = 119567248, name = public System.Boolean System.Collections.Generic.Dictionary<AttachmentKeyTuple, Spine.Attachment>::ContainsKey(AttachmentKeyTuple key), nameHashCode = cloneAttachments})) == true)
            {
                goto label_17;
            }
            
            val_3 = val_4;
            val_5 = val_3;
            destination.attachments.Add(key:  new AttachmentKeyTuple() {slotIndex = 119567248, name = Spine.Unity.Modules.AttachmentTools.AttachmentCloneExtensions.GetClone(o:  val_24, cloneMeshesAsLinked:  val_20), nameHashCode = 119550256}, value:  cloneMeshesAsLinked);
            goto label_17;
            label_14:
            val_25 = public System.Void Dictionary.Enumerator<AttachmentKeyTuple, Spine.Attachment>::Dispose();
            goto label_18;
            label_3:
            if( == false)
            {
                goto label_24;
            }
            
            Dictionary.Enumerator<TKey, TValue> val_14 = source.attachments.GetEnumerator();
            label_28:
            if(val_5.MoveNext() == false)
            {
                goto label_26;
            }
            
            val_3 = val_4;
            val_5 = val_3;
            if(destination.attachments == null)
            {
                    throw new NullReferenceException();
            }
            
            destination.attachments.set_Item(key:  new AttachmentKeyTuple() {slotIndex = 119567216, name = val_4, nameHashCode = 21825824}, value:  cloneMeshesAsLinked);
            goto label_28;
            label_24:
            val_28 = 0;
            if(source.attachments != null)
            {
                goto label_29;
            }
            
            label_26:
            val_5.Dispose();
            val_28 = 0;
            if(val_28 != 1)
            {
                    if(327 == 327)
            {
                    return;
            }
            
            }
            
            label_29:
            Dictionary.Enumerator<TKey, TValue> val_16 = source.attachments.GetEnumerator();
            val_29 = 1152921510603384832;
            val_21 = 1152921513316331824;
            label_37:
            if(val_5.MoveNext() == false)
            {
                goto label_34;
            }
            
            if(destination.attachments == null)
            {
                    throw new NullReferenceException();
            }
            
            val_3 = val_4;
            val_5 = val_3;
            if((destination.attachments.ContainsKey(key:  new AttachmentKeyTuple() {slotIndex = 119566992, name = public System.Boolean System.Collections.Generic.Dictionary<AttachmentKeyTuple, Spine.Attachment>::ContainsKey(AttachmentKeyTuple key), nameHashCode = cloneAttachments})) == true)
            {
                goto label_37;
            }
            
            val_3 = val_4;
            val_5 = val_3;
            destination.attachments.Add(key:  new AttachmentKeyTuple() {slotIndex = 119566992, name = val_4, nameHashCode = 119550256}, value:  cloneMeshesAsLinked);
            goto label_37;
            label_34:
            val_25 = public System.Void Dictionary.Enumerator<AttachmentKeyTuple, Spine.Attachment>::Dispose();
            label_18:
            val_5.Dispose();
        }
    
    }

}
