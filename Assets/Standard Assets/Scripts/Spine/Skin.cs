using UnityEngine;

namespace Spine
{
    public class Skin
    {
        // Fields
        internal string name;
        private System.Collections.Generic.Dictionary<Spine.Skin.AttachmentKeyTuple, Spine.Attachment> attachments;
        
        // Properties
        public string Name { get; }
        public System.Collections.Generic.Dictionary<Spine.Skin.AttachmentKeyTuple, Spine.Attachment> Attachments { get; }
        
        // Methods
        public string get_Name()
        {
            return (string)this.name;
        }
        public System.Collections.Generic.Dictionary<Spine.Skin.AttachmentKeyTuple, Spine.Attachment> get_Attachments()
        {
            return (System.Collections.Generic.Dictionary<AttachmentKeyTuple, Spine.Attachment>)this.attachments;
        }
        public Skin(string name)
        {
            null = null;
            this.attachments = new System.Collections.Generic.Dictionary<AttachmentKeyTuple, Spine.Attachment>(comparer:  Skin.AttachmentKeyTupleComparer.Instance);
            if(name == null)
            {
                    throw new System.ArgumentNullException(paramName:  "name", message:  "name cannot be null.");
            }
            
            this.name = name;
        }
        public void AddAttachment(int slotIndex, string name, Spine.Attachment attachment)
        {
            if(attachment == null)
            {
                    throw new System.ArgumentNullException(paramName:  "attachment", message:  "attachment cannot be null.");
            }
            
            this.attachments.set_Item(key:  new AttachmentKeyTuple() {slotIndex = 21844008, name = attachment, nameHashCode = 21825824}, value:  null);
        }
        public Spine.Attachment GetAttachment(int slotIndex, string name)
        {
            bool val_2 = this.attachments.TryGetValue(key:  new AttachmentKeyTuple() {slotIndex = 21981624, nameHashCode = 21968672}, value: out  Spine.Attachment val_1 = null);
            return (Spine.Attachment)0;
        }
        public void FindNamesForSlot(int slotIndex, System.Collections.Generic.List<string> names)
        {
            if(names == null)
            {
                    throw new System.ArgumentNullException(paramName:  "names", message:  "names cannot be null.");
            }
            
            Dictionary.KeyCollection.Enumerator<TKey, TValue> val_2 = this.attachments.Keys.GetEnumerator();
            label_6:
            if(0.MoveNext() == false)
            {
                goto label_4;
            }
            
            if(0 != slotIndex)
            {
                goto label_6;
            }
            
            names.Add(item:  0);
            goto label_6;
            label_4:
            0.Dispose();
        }
        public void FindAttachmentsForSlot(int slotIndex, System.Collections.Generic.List<Spine.Attachment> attachments)
        {
            if(attachments == null)
            {
                    throw new System.ArgumentNullException(paramName:  "attachments", message:  "attachments cannot be null.");
            }
            
            Dictionary.Enumerator<TKey, TValue> val_1 = this.attachments.GetEnumerator();
            label_5:
            if(0.MoveNext() == false)
            {
                goto label_3;
            }
            
            if(0 != slotIndex)
            {
                goto label_5;
            }
            
            attachments.Add(item:  0);
            goto label_5;
            label_3:
            0.Dispose();
        }
        public override string ToString()
        {
            return (string)this.name;
        }
        internal void AttachAll(Spine.Skeleton skeleton, Spine.Skin oldSkin)
        {
            var val_3;
            int val_4;
            var val_5;
            Dictionary.Enumerator<TKey, TValue> val_1 = oldSkin.attachments.GetEnumerator();
            label_11:
            if(val_5.MoveNext() == false)
            {
                goto label_3;
            }
            
            if(skeleton == null)
            {
                    throw new NullReferenceException();
            }
            
            if(skeleton.slots == null)
            {
                    throw new NullReferenceException();
            }
            
            if(X9 == 0)
            {
                    throw new NullReferenceException();
            }
            
            var val_8 = X9 + ((val_4 << 32) >> 29);
            if(((X9 + ((ulong)(val_4 << 32)) >> 29) + 32) == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(((X9 + ((ulong)(val_4 << 32)) >> 29) + 32 + 64) != val_3)
            {
                goto label_11;
            }
            
            Spine.Attachment val_9 = this.GetAttachment(slotIndex:  val_4, name:  val_4);
            if(val_9 == null)
            {
                goto label_11;
            }
            
            (X9 + ((ulong)(val_4 << 32)) >> 29) + 32.Attachment = val_9;
            goto label_11;
            label_3:
            val_5.Dispose();
        }
    
    }

}
