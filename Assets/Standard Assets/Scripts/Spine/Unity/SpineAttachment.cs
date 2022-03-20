using UnityEngine;

namespace Spine.Unity
{
    public class SpineAttachment : SpineAttributeBase
    {
        // Fields
        public bool returnAttachmentPath;
        public bool currentSkinOnly;
        public bool placeholdersOnly;
        public string skinField;
        public string slotField;
        
        // Methods
        public SpineAttachment(bool currentSkinOnly = True, bool returnAttachmentPath = False, bool placeholdersOnly = False, string slotField = "", string dataField = "", string skinField = "", bool includeNone = True)
        {
            this.skinField = "";
            this.slotField = "";
            this.skinField = skinField;
            this.slotField = slotField;
            mem[1152921513283218904] = dataField;
            this.currentSkinOnly = currentSkinOnly;
            this.returnAttachmentPath = returnAttachmentPath;
            this.placeholdersOnly = placeholdersOnly;
            mem[1152921513283218920] = includeNone;
        }
        public static Spine.Unity.SpineAttachment.Hierarchy GetHierarchy(string fullPath)
        {
            Hierarchy val_0;
            val_0.skin = 0;
            val_0.slot = 0;
            val_0.name = 0;
            val_0 = new SpineAttachment.Hierarchy(fullPath:  fullPath);
        }
        public static Spine.Attachment GetAttachment(string attachmentPath, Spine.SkeletonData skeletonData)
        {
            SpineAttachment.Hierarchy val_1 = new SpineAttachment.Hierarchy(fullPath:  attachmentPath);
            if((System.String.IsNullOrEmpty(value:  val_1.name)) == false)
            {
                    return skeletonData.FindSkin(skinName:  val_1.skin).GetAttachment(slotIndex:  skeletonData.FindSlotIndex(slotName:  val_1.slot), name:  val_1.name);
            }
            
            return 0;
        }
        public static Spine.Attachment GetAttachment(string attachmentPath, Spine.Unity.SkeletonDataAsset skeletonDataAsset)
        {
            return Spine.Unity.SpineAttachment.GetAttachment(attachmentPath:  attachmentPath, skeletonData:  skeletonDataAsset.GetSkeletonData(quiet:  true));
        }
    
    }

}
