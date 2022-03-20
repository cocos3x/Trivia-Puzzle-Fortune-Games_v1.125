using UnityEngine;

namespace WordForest
{
    public class MysteryChestStatView : MonoBehaviour
    {
        // Fields
        private static WordForest.MysteryChestStatView <Instance>k__BackingField;
        private UnityEngine.GameObject parent;
        private UnityEngine.UI.Image[] chestIcons;
        private bool autoUpdate;
        
        // Properties
        public static WordForest.MysteryChestStatView Instance { get; set; }
        public bool SetAutoUpdate { set; }
        
        // Methods
        public static WordForest.MysteryChestStatView get_Instance()
        {
            return (WordForest.MysteryChestStatView)WordForest.MysteryChestStatView.<Instance>k__BackingField;
        }
        private static void set_Instance(WordForest.MysteryChestStatView value)
        {
            WordForest.MysteryChestStatView.<Instance>k__BackingField = value;
        }
        public void set_SetAutoUpdate(bool value)
        {
            this.autoUpdate = value;
        }
        private void Awake()
        {
            WordForest.MysteryChestStatView.<Instance>k__BackingField = this;
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "UpdateMysteryChestStatView");
        }
        private void Start()
        {
            this.UpdateMysteryChestStatView();
        }
        public void UpdateMysteryChestStatView()
        {
            var val_16;
            if(this.autoUpdate == false)
            {
                    return;
            }
            
            if(WordForest.WFOMysteryChestManager.IsFeatureUnlocked == false)
            {
                goto label_2;
            }
            
            val_16 = 1152921516959163216;
            if((MonoSingleton<WordForest.WFOMysteryChestUI>.Instance) == 0)
            {
                    return;
            }
            
            WordForest.WFOMysteryChestUI val_4 = MonoSingleton<WordForest.WFOMysteryChestUI>.Instance;
            if(val_4.mysteryChestTiles == null)
            {
                    return;
            }
            
            val_16 = 1152921515420673872;
            bool val_6 = UnityEngine.Object.op_Equality(x:  MonoSingleton<WordForest.WFOMysteryChestManager>.Instance, y:  0);
            if(val_6 == false)
            {
                goto label_16;
            }
            
            return;
            label_2:
            label_35:
            this.parent.SetActive(value:  WordForest.WFOMysteryChestManager.IsFeatureUnlocked);
            return;
            label_16:
            var val_19 = 4;
            label_32:
            var val_10 = val_19 - 4;
            if(val_10 >= this.chestIcons.Length)
            {
                goto label_35;
            }
            
            UnityEngine.UI.Image val_17 = this.chestIcons[0];
            if(val_10 >= val_6.GetCollectedChestCount())
            {
                goto label_21;
            }
            
            UnityEngine.Color val_11 = UnityEngine.Color.white;
            if(val_17 != null)
            {
                goto label_22;
            }
            
            label_21:
            UnityEngine.Color val_12 = UnityEngine.Color.gray;
            label_22:
            val_17.color = new UnityEngine.Color() {r = val_12.r, g = val_12.g, b = val_12.b, a = val_12.a};
            this.chestIcons[0].gameObject.SetActive(value:  ((MonoSingleton<WordForest.WFOMysteryChestManager>.Instance.GetChestCount) > val_10) ? 1 : 0);
            val_19 = val_19 + 1;
            if(this.chestIcons != null)
            {
                goto label_32;
            }
            
            goto label_35;
        }
        public void SetBalanceNow(int collected, int total)
        {
            var val_5 = 4;
            label_11:
            var val_1 = val_5 - 4;
            if(val_1 >= this.chestIcons.Length)
            {
                    return;
            }
            
            UnityEngine.UI.Image val_6 = this.chestIcons[0];
            if(val_1 >= collected)
            {
                goto label_3;
            }
            
            UnityEngine.Color val_2 = UnityEngine.Color.white;
            if(val_6 != null)
            {
                goto label_4;
            }
            
            label_3:
            UnityEngine.Color val_3 = UnityEngine.Color.gray;
            label_4:
            val_6.color = new UnityEngine.Color() {r = val_3.r, g = val_3.g, b = val_3.b, a = val_3.a};
            this.chestIcons[0].gameObject.SetActive(value:  (val_1 < total) ? 1 : 0);
            val_5 = val_5 + 1;
            if(this.chestIcons != null)
            {
                goto label_11;
            }
            
            throw new NullReferenceException();
        }
        public UnityEngine.Vector3 GetNextTileIconPosition()
        {
            return this.chestIcons[this.GetCollectedChestCount() - 1].transform.position;
        }
        public UnityEngine.Transform GetTileIcon(int index)
        {
            return this.chestIcons[index].transform;
        }
        public void HideIcon(int index)
        {
            UnityEngine.Color val_1 = UnityEngine.Color.clear;
            this.chestIcons[index].color = new UnityEngine.Color() {r = val_1.r, g = val_1.g, b = val_1.b, a = val_1.a};
        }
        private int GetCollectedChestCount()
        {
            var val_3;
            var val_4;
            val_3 = 0;
            val_4 = 0;
            goto label_1;
            label_12:
            WordForest.WFOMysteryChestUI val_1 = MonoSingleton<WordForest.WFOMysteryChestUI>.Instance;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_3 = 1;
            label_1:
            WordForest.WFOMysteryChestUI val_2 = MonoSingleton<WordForest.WFOMysteryChestUI>.Instance;
            if(val_3 < val_2.mysteryChestTiles)
            {
                goto label_12;
            }
            
            return (int)(val_4 + (MonoSingleton<T>.__il2cppRuntimeField_cctor_finished + 0) + 32 + 32);
        }
        private void OnDestroy()
        {
            WordForest.MysteryChestStatView.<Instance>k__BackingField = 0;
        }
        public MysteryChestStatView()
        {
            this.autoUpdate = true;
        }
    
    }

}
