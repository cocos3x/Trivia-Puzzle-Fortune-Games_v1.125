using UnityEngine;

namespace Spine.Unity.Modules
{
    public class SkeletonRendererCustomMaterials : MonoBehaviour
    {
        // Fields
        public Spine.Unity.SkeletonRenderer skeletonRenderer;
        protected System.Collections.Generic.List<Spine.Unity.Modules.SkeletonRendererCustomMaterials.SlotMaterialOverride> customSlotMaterials;
        protected System.Collections.Generic.List<Spine.Unity.Modules.SkeletonRendererCustomMaterials.AtlasMaterialOverride> customMaterialOverrides;
        
        // Methods
        private void SetCustomSlotMaterials()
        {
            var val_5;
            if(this.skeletonRenderer == 0)
            {
                    UnityEngine.Debug.LogError(message:  "skeletonRenderer == null");
                return;
            }
            
            var val_5 = 0;
            val_5 = 0;
            do
            {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
                if((System.String.IsNullOrEmpty(value:  ((UnityEngine.Object.__il2cppRuntimeField_cctor_finished & 4294967295) + 0) + 40)) != true)
            {
                    this.skeletonRenderer.customSlotMaterials.set_Item(key:  this.skeletonRenderer.skeleton.FindSlot(slotName:  ((UnityEngine.Object.__il2cppRuntimeField_cctor_finished & 4294967295) + 0) + 40), value:  ((UnityEngine.Object.__il2cppRuntimeField_cctor_finished & 4294967295) + 0) + 40 + 8);
            }
            
                val_5 = val_5 + 1;
                val_5 = val_5 + 24;
            }
            while(this.customSlotMaterials != null);
            
            throw new NullReferenceException();
        }
        private void RemoveCustomSlotMaterials()
        {
            var val_9;
            string val_10;
            UnityEngine.Material val_5 = 0;
            if(this.skeletonRenderer == 0)
            {
                    UnityEngine.Debug.LogError(message:  "skeletonRenderer == null");
                return;
            }
            
            var val_9 = 0;
            val_9 = 0;
            do
            {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
                val_10 = mem[((UnityEngine.Object.__il2cppRuntimeField_cctor_finished & 4294967295) + 0) + 40];
                val_10 = ((UnityEngine.Object.__il2cppRuntimeField_cctor_finished & 4294967295) + 0) + 40;
                if((System.String.IsNullOrEmpty(value:  val_10)) != true)
            {
                    val_10 = this.skeletonRenderer.skeleton.FindSlot(slotName:  val_10);
                if((this.skeletonRenderer.customSlotMaterials.TryGetValue(key:  val_10, value: out  val_5)) != false)
            {
                    if(val_5 == (((UnityEngine.Object.__il2cppRuntimeField_cctor_finished & 4294967295) + 0) + 40 + 8))
            {
                    bool val_8 = this.skeletonRenderer.customSlotMaterials.Remove(key:  val_10);
            }
            
            }
            
            }
            
                val_9 = val_9 + 1;
                val_9 = val_9 + 24;
            }
            while(this.customSlotMaterials != null);
            
            throw new NullReferenceException();
        }
        private void SetCustomMaterialOverrides()
        {
            var val_3;
            if(this.skeletonRenderer == 0)
            {
                    UnityEngine.Debug.LogError(message:  "skeletonRenderer == null");
                return;
            }
            
            var val_3 = 0;
            val_3 = 0;
            do
            {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
                this.skeletonRenderer.customMaterialOverride.set_Item(key:  ((UnityEngine.Object.__il2cppRuntimeField_cctor_finished & 4294967295) + 0) + 40, value:  ((UnityEngine.Object.__il2cppRuntimeField_cctor_finished & 4294967295) + 0) + 40 + 8);
                val_3 = val_3 + 1;
                val_3 = val_3 + 24;
            }
            while(this.customMaterialOverrides != null);
            
            throw new NullReferenceException();
        }
        private void RemoveCustomMaterialOverrides()
        {
            var val_6;
            UnityEngine.Material val_2 = 0;
            if(this.skeletonRenderer == 0)
            {
                    UnityEngine.Debug.LogError(message:  "skeletonRenderer == null");
                return;
            }
            
            var val_6 = 0;
            val_6 = 0;
            do
            {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
                if((this.skeletonRenderer.customMaterialOverride.TryGetValue(key:  typeof(Spine.Unity.SkeletonRenderer).__il2cppRuntimeField_28, value: out  val_2)) != false)
            {
                    if(val_2 == Spine.Unity.SkeletonRenderer.__il2cppRuntimeField_this_arg)
            {
                    bool val_5 = this.skeletonRenderer.customMaterialOverride.Remove(key:  typeof(Spine.Unity.SkeletonRenderer).__il2cppRuntimeField_28);
            }
            
            }
            
                val_6 = val_6 + 1;
                val_6 = val_6 + 24;
            }
            while(this.customMaterialOverrides != null);
            
            throw new NullReferenceException();
        }
        private void OnEnable()
        {
            Spine.Unity.SkeletonRenderer val_4;
            if(this.skeletonRenderer == 0)
            {
                    Spine.Unity.SkeletonRenderer val_2 = this.GetComponent<Spine.Unity.SkeletonRenderer>();
                val_4 = val_2;
                this.skeletonRenderer = val_2;
            }
            else
            {
                    val_4 = this.skeletonRenderer;
            }
            
            if(val_4 == 0)
            {
                    UnityEngine.Debug.LogError(message:  "skeletonRenderer == null");
                return;
            }
            
            this.SetCustomMaterialOverrides();
            this.SetCustomSlotMaterials();
        }
        private void OnDisable()
        {
            if(this.skeletonRenderer == 0)
            {
                    UnityEngine.Debug.LogError(message:  "skeletonRenderer == null");
                return;
            }
            
            this.RemoveCustomMaterialOverrides();
            this.RemoveCustomSlotMaterials();
        }
        public SkeletonRendererCustomMaterials()
        {
            this.customSlotMaterials = new System.Collections.Generic.List<SlotMaterialOverride>();
            this.customMaterialOverrides = new System.Collections.Generic.List<AtlasMaterialOverride>();
        }
    
    }

}
