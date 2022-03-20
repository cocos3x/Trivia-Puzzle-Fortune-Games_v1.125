using UnityEngine;

namespace Spine.Unity.Modules
{
    public class SlotBlendModes : MonoBehaviour
    {
        // Fields
        private static System.Collections.Generic.Dictionary<Spine.Unity.Modules.SlotBlendModes.MaterialTexturePair, UnityEngine.Material> materialTable;
        public UnityEngine.Material multiplyMaterialSource;
        public UnityEngine.Material screenMaterialSource;
        private UnityEngine.Texture2D texture;
        private bool <Applied>k__BackingField;
        
        // Properties
        internal static System.Collections.Generic.Dictionary<Spine.Unity.Modules.SlotBlendModes.MaterialTexturePair, UnityEngine.Material> MaterialTable { get; }
        public bool Applied { get; set; }
        
        // Methods
        internal static System.Collections.Generic.Dictionary<Spine.Unity.Modules.SlotBlendModes.MaterialTexturePair, UnityEngine.Material> get_MaterialTable()
        {
            System.Collections.Generic.Dictionary<TKey, TValue> val_2;
            System.Collections.Generic.Dictionary<MaterialTexturePair, UnityEngine.Material> val_3 = Spine.Unity.Modules.SlotBlendModes.materialTable;
            if(val_3 != null)
            {
                    return (System.Collections.Generic.Dictionary<MaterialTexturePair, UnityEngine.Material>)val_3;
            }
            
            System.Collections.Generic.Dictionary<MaterialTexturePair, UnityEngine.Material> val_1 = null;
            val_2 = val_1;
            val_1 = new System.Collections.Generic.Dictionary<MaterialTexturePair, UnityEngine.Material>();
            Spine.Unity.Modules.SlotBlendModes.materialTable = val_2;
            val_3 = Spine.Unity.Modules.SlotBlendModes.materialTable;
            return (System.Collections.Generic.Dictionary<MaterialTexturePair, UnityEngine.Material>)val_3;
        }
        internal static UnityEngine.Material GetMaterialFor(UnityEngine.Material materialSource, UnityEngine.Texture2D texture)
        {
            var val_10;
            UnityEngine.Material val_11;
            val_10 = 1152921504765632512;
            val_11 = 0;
            if(materialSource == 0)
            {
                    return val_11;
            }
            
            val_11 = 0;
            if(texture == 0)
            {
                    return val_11;
            }
            
            System.Collections.Generic.Dictionary<MaterialTexturePair, UnityEngine.Material> val_3 = Spine.Unity.Modules.SlotBlendModes.MaterialTable;
            val_10 = val_3;
            if((val_3.TryGetValue(key:  new MaterialTexturePair() {texture2D = texture, material = materialSource}, value: out  0)) != true)
            {
                    UnityEngine.Material val_6 = new UnityEngine.Material(source:  materialSource);
                val_6.name = "(Clone)" + texture.name + "-"("-") + materialSource.name;
                val_6.mainTexture = texture;
                val_10.set_Item(key:  new MaterialTexturePair() {texture2D = texture, material = materialSource}, value:  val_6);
            }
            
            val_11 = val_6;
            return val_11;
        }
        public bool get_Applied()
        {
            return (bool)this.<Applied>k__BackingField;
        }
        private void set_Applied(bool value)
        {
            this.<Applied>k__BackingField = value;
        }
        private void Start()
        {
            if((this.<Applied>k__BackingField) != false)
            {
                    return;
            }
            
            this.Apply();
        }
        private void OnDestroy()
        {
            if((this.<Applied>k__BackingField) == false)
            {
                    return;
            }
            
            this.Remove();
        }
        public void Apply()
        {
            Spine.Slot val_5;
            var val_6;
            UnityEngine.Texture2D val_13;
            this.GetTexture();
            if(this.texture == 0)
            {
                    return;
            }
            
            if((this.GetComponent<Spine.Unity.SkeletonRenderer>()) == 0)
            {
                    return;
            }
            
            ExposedList.Enumerator<T> val_4 = val_2.skeleton.slots.GetEnumerator();
            label_24:
            val_13 = public System.Boolean ExposedList.Enumerator<Spine.Slot>::MoveNext();
            if(val_6.MoveNext() == false)
            {
                goto label_10;
            }
            
            if(val_5 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if((val_5 + 16) == 0)
            {
                    throw new NullReferenceException();
            }
            
            if((val_5 + 16 + 80) == 2)
            {
                goto label_13;
            }
            
            if(((val_5 + 16 + 80) != 3) || (this.screenMaterialSource == 0))
            {
                goto label_24;
            }
            
            val_13 = this.texture;
            if(val_2.customSlotMaterials == null)
            {
                    throw new NullReferenceException();
            }
            
            val_2.customSlotMaterials.set_Item(key:  val_5, value:  Spine.Unity.Modules.SlotBlendModes.GetMaterialFor(materialSource:  this.screenMaterialSource, texture:  val_13));
            goto label_24;
            label_13:
            if(this.multiplyMaterialSource == 0)
            {
                goto label_24;
            }
            
            val_13 = this.texture;
            if(val_2.customSlotMaterials == null)
            {
                    throw new NullReferenceException();
            }
            
            val_2.customSlotMaterials.set_Item(key:  val_5, value:  Spine.Unity.Modules.SlotBlendModes.GetMaterialFor(materialSource:  this.multiplyMaterialSource, texture:  val_13));
            goto label_24;
            label_10:
            val_6.Dispose();
            this.<Applied>k__BackingField = true;
        }
        public void Remove()
        {
            Spine.Slot val_5;
            var val_6;
            System.Collections.Generic.Dictionary<Spine.Slot, UnityEngine.Material> val_16;
            this.GetTexture();
            val_16 = 1152921504765632512;
            if(this.texture == 0)
            {
                    return;
            }
            
            if((this.GetComponent<Spine.Unity.SkeletonRenderer>()) == 0)
            {
                    return;
            }
            
            val_16 = val_2.customSlotMaterials;
            ExposedList.Enumerator<T> val_4 = val_2.skeleton.slots.GetEnumerator();
            label_22:
            if(val_6.MoveNext() == false)
            {
                goto label_10;
            }
            
            UnityEngine.Material val_8 = 0;
            if(val_5 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if((val_5 + 16) == 0)
            {
                    throw new NullReferenceException();
            }
            
            if((val_5 + 16 + 80) == 2)
            {
                goto label_13;
            }
            
            if((val_5 + 16 + 80) != 3)
            {
                goto label_22;
            }
            
            if(val_16 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(((val_16.TryGetValue(key:  val_5, value: out  val_8)) == false) || (val_8 != (Spine.Unity.Modules.SlotBlendModes.GetMaterialFor(materialSource:  this.screenMaterialSource, texture:  this.texture))))
            {
                goto label_22;
            }
            
            bool val_11 = val_16.Remove(key:  val_5);
            goto label_22;
            label_13:
            if(val_16 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(((val_16.TryGetValue(key:  val_5, value: out  val_8)) == false) || (val_8 != (Spine.Unity.Modules.SlotBlendModes.GetMaterialFor(materialSource:  this.multiplyMaterialSource, texture:  this.texture))))
            {
                goto label_22;
            }
            
            bool val_14 = val_16.Remove(key:  val_5);
            goto label_22;
            label_10:
            val_6.Dispose();
            this.<Applied>k__BackingField = false;
        }
        public void GetTexture()
        {
            UnityEngine.Texture2D val_9;
            if(this.texture != 0)
            {
                    return;
            }
            
            if((this.GetComponent<Spine.Unity.SkeletonRenderer>()) == 0)
            {
                    return;
            }
            
            if(val_2.skeletonDataAsset == 0)
            {
                    return;
            }
            
            if(val_2.skeletonDataAsset.atlasAssets[0] == 0)
            {
                    return;
            }
            
            UnityEngine.Material val_10 = val_2.skeletonDataAsset.atlasAssets[0].materials[0];
            if(val_10 == 0)
            {
                    return;
            }
            
            UnityEngine.Texture val_7 = val_10.mainTexture;
            if(val_7 != null)
            {
                    var val_8 = (null == null) ? (val_7) : 0;
            }
            else
            {
                    val_9 = 0;
            }
            
            this.texture = val_9;
        }
        public SlotBlendModes()
        {
        
        }
    
    }

}
