using UnityEngine;

namespace Spine.Unity
{
    public class BoundingBoxFollower : MonoBehaviour
    {
        // Fields
        internal static bool DebugMessages;
        public Spine.Unity.SkeletonRenderer skeletonRenderer;
        public string slotName;
        public bool isTrigger;
        public bool clearStateOnDisable;
        private Spine.Slot slot;
        private Spine.BoundingBoxAttachment currentAttachment;
        private string currentAttachmentName;
        private UnityEngine.PolygonCollider2D currentCollider;
        public readonly System.Collections.Generic.Dictionary<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D> colliderTable;
        public readonly System.Collections.Generic.Dictionary<Spine.BoundingBoxAttachment, string> nameTable;
        
        // Properties
        public Spine.Slot Slot { get; }
        public Spine.BoundingBoxAttachment CurrentAttachment { get; }
        public string CurrentAttachmentName { get; }
        public UnityEngine.PolygonCollider2D CurrentCollider { get; }
        public bool IsTrigger { get; }
        
        // Methods
        public Spine.Slot get_Slot()
        {
            return (Spine.Slot)this.slot;
        }
        public Spine.BoundingBoxAttachment get_CurrentAttachment()
        {
            return (Spine.BoundingBoxAttachment)this.currentAttachment;
        }
        public string get_CurrentAttachmentName()
        {
            return (string)this.currentAttachmentName;
        }
        public UnityEngine.PolygonCollider2D get_CurrentCollider()
        {
            return (UnityEngine.PolygonCollider2D)this.currentCollider;
        }
        public bool get_IsTrigger()
        {
            return (bool)this.isTrigger;
        }
        private void Start()
        {
            this.Initialize();
        }
        private void OnEnable()
        {
            if(this.skeletonRenderer != 0)
            {
                    this.skeletonRenderer.remove_OnRebuild(value:  new SkeletonRenderer.SkeletonRendererDelegate(object:  this, method:  System.Void Spine.Unity.BoundingBoxFollower::HandleRebuild(Spine.Unity.SkeletonRenderer sr)));
                this.skeletonRenderer.add_OnRebuild(value:  new SkeletonRenderer.SkeletonRendererDelegate(object:  this, method:  System.Void Spine.Unity.BoundingBoxFollower::HandleRebuild(Spine.Unity.SkeletonRenderer sr)));
            }
            
            this.Initialize();
        }
        private void HandleRebuild(Spine.Unity.SkeletonRenderer sr)
        {
            this.Initialize();
        }
        public void Initialize()
        {
            string val_10;
            var val_11;
            object val_29;
            var val_30;
            Spine.Skeleton val_31;
            var val_33;
            var val_35;
            var val_38;
            var val_40;
            val_29 = this;
            if(this.skeletonRenderer == 0)
            {
                    return;
            }
            
            if((System.String.IsNullOrEmpty(value:  this.slotName)) == true)
            {
                    return;
            }
            
            val_30 = 1152921513250908096;
            if(((this.colliderTable.Count >= 1) && (this.slot != null)) && (this.skeletonRenderer.skeleton == this.slot.bone.skeleton))
            {
                    if((System.String.op_Equality(a:  this.slotName, b:  this.slot.data.name)) == true)
            {
                    return;
            }
            
            }
            
            this.DisposeColliders();
            val_31 = this.skeletonRenderer.skeleton;
            this.slot = val_31.FindSlot(slotName:  this.slotName);
            int val_6 = val_31.FindSlotIndex(slotName:  this.slotName);
            if(this.slot == null)
            {
                goto label_16;
            }
            
            if(this.gameObject.activeInHierarchy == false)
            {
                goto label_90;
            }
            
            ExposedList.Enumerator<T> val_9 = this.skeletonRenderer.skeleton.data.skins.GetEnumerator();
            val_31 = 0;
            label_45:
            if(val_11.MoveNext() == false)
            {
                goto label_21;
            }
            
            val_33 = val_10;
            System.Collections.Generic.List<System.String> val_13 = new System.Collections.Generic.List<System.String>();
            if(val_33 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_33.FindNamesForSlot(slotIndex:  val_6, names:  val_13);
            if(val_13 == null)
            {
                    throw new NullReferenceException();
            }
            
            List.Enumerator<T> val_14 = val_13.GetEnumerator();
            label_39:
            if(val_11.MoveNext() == false)
            {
                goto label_24;
            }
            
            val_35 = 0;
            if(((val_33.GetAttachment(slotIndex:  val_6, name:  val_10)) != null) && (Spine.Unity.BoundingBoxFollower.DebugMessages != false))
            {
                    UnityEngine.Debug.Log(message:  "BoundingBoxFollower tried to follow a slot that contains non-boundingbox attachments: "("BoundingBoxFollower tried to follow a slot that contains non-boundingbox attachments: ") + this.slotName);
            }
            
            UnityEngine.PolygonCollider2D val_20 = Spine.Unity.SkeletonUtility.AddBoundingBoxAsComponent(box:  null, slot:  this.slot, gameObject:  this.gameObject, isTrigger:  this.isTrigger);
            if(val_20 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_20.enabled = false;
            val_20.hideFlags = 8;
            val_20.isTrigger = this.isTrigger;
            if(this.colliderTable == null)
            {
                    throw new NullReferenceException();
            }
            
            this.colliderTable.Add(key:  null, value:  val_20);
            if(this.nameTable == null)
            {
                    throw new NullReferenceException();
            }
            
            this.nameTable.Add(key:  null, value:  val_10);
            goto label_39;
            label_24:
            val_33 = 0;
            var val_21 = val_31 + 1;
            mem2[0] = 473;
            val_11.Dispose();
            if(val_33 != 0)
            {
                    throw val_33;
            }
            
            if((val_21 == 1) || ((54284720 + ((val_31 + 1)) << 2) != 473))
            {
                goto label_45;
            }
            
            var val_31 = 0;
            val_31 = val_31 ^ (val_21 >> 31);
            var val_22 = val_21 + val_31;
            goto label_45;
            label_16:
            val_38 = null;
            val_38 = null;
            if(Spine.Unity.BoundingBoxFollower.DebugMessages == false)
            {
                    return;
            }
            
            string val_25 = System.String.Format(format:  "Slot \'{0}\' not found for BoundingBoxFollower on \'{1}\'. (Previous colliders were disposed.)", arg0:  this.slotName, arg1:  this.gameObject.name);
            goto label_68;
            label_21:
            var val_26 = val_31 + 1;
            mem2[0] = 501;
            val_11.Dispose();
            val_30 = 1152921513250908096;
            label_90:
            val_40 = null;
            val_40 = null;
            if(Spine.Unity.BoundingBoxFollower.DebugMessages == false)
            {
                    return;
            }
            
            if(this.colliderTable.Count != 0)
            {
                    return;
            }
            
            if(this.gameObject.activeInHierarchy == false)
            {
                goto label_80;
            }
            
            label_68:
            val_29 = "Bounding Box Follower not valid! Slot ["("Bounding Box Follower not valid! Slot [") + this.slotName + "] does not contain any Bounding Box Attachments!"("] does not contain any Bounding Box Attachments!");
            label_80:
            UnityEngine.Debug.LogWarning(message:  val_29);
        }
        private void OnDisable()
        {
            if(this.clearStateOnDisable == false)
            {
                    return;
            }
            
            this.ClearState();
        }
        public void ClearState()
        {
            if(this.colliderTable == null)
            {
                goto label_9;
            }
            
            Dictionary.ValueCollection.Enumerator<TKey, TValue> val_2 = this.colliderTable.Values.GetEnumerator();
            label_5:
            if(0.MoveNext() == false)
            {
                goto label_3;
            }
            
            if(0 == 0)
            {
                    throw new NullReferenceException();
            }
            
            0.enabled = false;
            goto label_5;
            label_3:
            0.Dispose();
            label_9:
            this.currentAttachment = 0;
            this.currentAttachmentName = 0;
            this.currentCollider = 0;
        }
        private void DisposeColliders()
        {
            T[] val_1 = this.GetComponents<UnityEngine.PolygonCollider2D>();
            if(val_1.Length == 0)
            {
                    return;
            }
            
            if(UnityEngine.Application.isEditor == false)
            {
                goto label_3;
            }
            
            int val_4 = val_1.Length & 4294967295;
            if(UnityEngine.Application.isPlaying == false)
            {
                goto label_4;
            }
            
            if(val_1.Length < 1)
            {
                goto label_23;
            }
            
            var val_8 = 0;
            do
            {
                if(1152921506205249424 != 0)
            {
                    UnityEngine.Object.Destroy(obj:  1152921506205249424);
            }
            
                val_8 = val_8 + 1;
            }
            while(val_8 < (val_1.Length << ));
            
            goto label_23;
            label_3:
            int val_9 = val_1.Length;
            if(val_9 < 1)
            {
                goto label_23;
            }
            
            var val_10 = 0;
            val_9 = val_9 & 4294967295;
            do
            {
                if(1152921506205249424 != 0)
            {
                    UnityEngine.Object.Destroy(obj:  1152921506205249424);
            }
            
                val_10 = val_10 + 1;
            }
            while(val_10 < (val_1.Length << ));
            
            goto label_23;
            label_4:
            if(val_1.Length >= 1)
            {
                    var val_11 = 0;
                do
            {
                if(1152921506205249424 != 0)
            {
                    UnityEngine.Object.DestroyImmediate(obj:  1152921506205249424);
            }
            
                val_11 = val_11 + 1;
            }
            while(val_11 < (val_1.Length << ));
            
            }
            
            label_23:
            this.slot = 0;
            this.currentAttachmentName = 0;
            this.colliderTable.Clear();
            this.nameTable.Clear();
        }
        private void LateUpdate()
        {
            if(this.slot == null)
            {
                    return;
            }
            
            if(this.slot.attachment == this.currentAttachment)
            {
                    return;
            }
            
            this.MatchAttachment(attachment:  this.slot.attachment);
        }
        private void MatchAttachment(Spine.Attachment attachment)
        {
            var val_5;
            var val_6;
            val_5 = 0;
            val_6 = null;
            val_6 = null;
            if((attachment != null) && (Spine.Unity.BoundingBoxFollower.DebugMessages != false))
            {
                    UnityEngine.Debug.LogWarning(message:  "BoundingBoxFollower tried to match a non-boundingbox attachment. It will treat it as null.");
            }
            
            if(this.currentCollider != 0)
            {
                    this.currentCollider.enabled = false;
            }
            
            UnityEngine.PolygonCollider2D val_3 = this.colliderTable.Item[null];
            this.currentCollider = val_3;
            val_3.enabled = true;
            this.currentAttachment = ;
            string val_4 = this.nameTable.Item[null];
            this.currentAttachmentName = ;
        }
        public BoundingBoxFollower()
        {
            this.clearStateOnDisable = true;
            this.colliderTable = new System.Collections.Generic.Dictionary<Spine.BoundingBoxAttachment, UnityEngine.PolygonCollider2D>();
            this.nameTable = new System.Collections.Generic.Dictionary<Spine.BoundingBoxAttachment, System.String>();
        }
        private static BoundingBoxFollower()
        {
            Spine.Unity.BoundingBoxFollower.DebugMessages = true;
        }
    
    }

}
