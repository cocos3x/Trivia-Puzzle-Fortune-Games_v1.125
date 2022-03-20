using UnityEngine;

namespace WordForest
{
    public class WFOMysteryChestFTUXPopup : WGHintButtonDemoPopup
    {
        // Fields
        private UnityEngine.RectTransform tip_window;
        private UnityEngine.RectTransform tip_left;
        private UnityEngine.RectTransform tip_right;
        private UnityEngine.UI.Button gotBtn;
        private UnityEngine.GameObject ftux_window;
        private UnityEngine.UI.Button letsGoBtn;
        
        // Methods
        protected override void Start()
        {
            var val_8;
            this.ftux_window.SetActive(value:  true);
            this.tip_window.gameObject.SetActive(value:  false);
            AdsUIController val_2 = MonoSingleton<AdsUIController>.Instance;
            val_2.onAdToggled.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGHintButtonDemoPopup::OnAdToggled()));
            val_8 = null;
            val_8 = null;
            EnumerableExtentions.SetOrAdd<System.Type, System.Boolean>(dic:  WGHintButtonDemoPopup.shownTypeDict, key:  this.GetType(), newValue:  true);
            mem[1152921518102483944] = this.tip_window.gameObject;
            this.letsGoBtn.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.WFOMysteryChestFTUXPopup::<Start>b__6_0()));
            this.gotBtn.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.WFOMysteryChestFTUXPopup::<Start>b__6_1()));
        }
        private void ShowTip()
        {
            UnityEngine.Transform[] val_60;
            float val_61;
            var val_65;
            val_60 = this;
            this.tip_window.gameObject.SetActive(value:  true);
            WordRegion val_2 = WordRegion.instance;
            System.Collections.Generic.List<System.Int32> val_4 = MonoSingleton<WordForest.WFOMysteryChestManager>.Instance.GetChestsWordIndexes();
            if((public static WordForest.WFOMysteryChestManager MonoSingleton<WordForest.WFOMysteryChestManager>::get_Instance()) == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            if((X21 + 24) <= (public System.Void Dictionary.Enumerator<System.String, GameLevel>::Dispose()))
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            var val_60 = X21 + 16;
            val_60 = val_60 + (-9223371933156869248);
            if(((X21 + 16 + -9223371933156869248) + 32 + 40 + 24) == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            if(((X21 + 16 + -9223371933156869248) + 32 + 40 + 24) == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            UnityEngine.Vector3 val_7 = (X21 + 16 + -9223371933156869248) + 32 + 40 + 16 + 32.transform.localPosition;
            UnityEngine.Vector3 val_8 = new UnityEngine.Vector3(x:  -154f, y:  -100f, z:  0f);
            UnityEngine.Vector3 val_9 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z}, b:  new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z});
            UnityEngine.Vector3 val_10 = (X21 + 16 + -9223371933156869248) + 32 + 40 + 16 + 32.transform.TransformPoint(position:  new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z});
            if(((X21 + 16 + -9223371933156869248) + 32 + 40 + 24) == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            if(((X21 + 16 + -9223371933156869248) + 32 + 40 + 24) == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            UnityEngine.Vector3 val_13 = (X21 + 16 + -9223371933156869248) + 32 + 40 + 16 + 32.transform.localPosition;
            UnityEngine.Vector3 val_14 = new UnityEngine.Vector3(x:  -154f, y:  -100f, z:  0f);
            UnityEngine.Vector3 val_15 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z}, b:  new UnityEngine.Vector3() {x = val_14.x, y = val_14.y, z = val_14.z});
            UnityEngine.Vector3 val_16 = UnityEngine.Vector3.right;
            UnityEngine.Vector2 val_17 = this.tip_window.sizeDelta;
            UnityEngine.Vector3 val_18 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z}, d:  val_17.x);
            UnityEngine.Vector3 val_19 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_15.x, y = val_15.y, z = val_15.z}, b:  new UnityEngine.Vector3() {x = val_18.x, y = val_18.y, z = val_18.z});
            UnityEngine.Vector3 val_20 = (X21 + 16 + -9223371933156869248) + 32 + 40 + 16 + 32.transform.TransformPoint(position:  new UnityEngine.Vector3() {x = val_19.x, y = val_19.y, z = val_19.z});
            if(((X21 + 16 + -9223371933156869248) + 32 + 40 + 24) == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            UnityEngine.Vector3 val_25 = this.GetCameraByTransform(obTranform:  (X21 + 16 + -9223371933156869248) + 32 + 40 + 16 + 32.transform).WorldToScreenPoint(position:  new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z});
            UnityEngine.Vector3 val_26 = this.GetCameraByTransform(obTranform:  this.transform).ScreenToWorldPoint(position:  new UnityEngine.Vector3() {x = val_25.x, y = val_25.y, z = val_25.z});
            if(((X21 + 16 + -9223371933156869248) + 32 + 40 + 24) == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            UnityEngine.Vector3 val_31 = this.GetCameraByTransform(obTranform:  (X21 + 16 + -9223371933156869248) + 32 + 40 + 16 + 32.transform).WorldToScreenPoint(position:  new UnityEngine.Vector3() {x = val_20.x, y = val_20.y, z = val_20.z});
            UnityEngine.Vector3 val_32 = this.GetCameraByTransform(obTranform:  this.transform).ScreenToWorldPoint(position:  new UnityEngine.Vector3() {x = val_31.x, y = val_31.y, z = val_31.z});
            UnityEngine.Vector3 val_33 = this.tip_left.position;
            if(val_26.x < 0)
            {
                    UnityEngine.Vector3 val_34 = this.tip_left.position;
                val_61 = val_34.x;
                UnityEngine.Vector3 val_36 = this.tip_window.transform.position;
                UnityEngine.Vector3 val_37 = new UnityEngine.Vector3(x:  val_61, y:  val_26.y, z:  val_36.z);
                UnityEngine.Transform val_38 = this.tip_window.transform;
            }
            else
            {
                    UnityEngine.Vector3 val_39 = this.tip_right.position;
                if(val_32.x > val_39.x)
            {
                    UnityEngine.Vector3 val_40 = this.tip_right.position;
                val_61 = val_40.x;
                UnityEngine.Vector3 val_42 = this.tip_window.transform.position;
                UnityEngine.Vector3 val_43 = new UnityEngine.Vector3(x:  val_61, y:  val_32.y, z:  val_42.z);
                UnityEngine.Vector2 val_44 = UnityEngine.Vector2.one;
                this.tip_window.pivot = new UnityEngine.Vector2() {x = val_44.x, y = val_44.y};
                UnityEngine.Transform val_45 = this.tip_window.transform;
            }
            else
            {
                    val_61 = val_37.x;
                UnityEngine.Vector3 val_48 = this.tip_window.transform.position;
                UnityEngine.Vector3 val_49 = new UnityEngine.Vector3(x:  val_61, y:  val_37.y, z:  val_48.z);
            }
            
            }
            
            this.tip_window.transform.position = new UnityEngine.Vector3() {x = val_49.x, y = val_49.y, z = val_49.z};
            MonoSingleton<GameMaskOverlay>.Instance.BlockRaycasts = true;
            MonoSingleton<GameMaskOverlay>.Instance.Interactable = true;
            GameMaskOverlay val_52 = MonoSingleton<GameMaskOverlay>.Instance;
            UnityEngine.Color val_53 = new UnityEngine.Color(r:  0f, g:  0f, b:  0f, a:  0f);
            System.Nullable<UnityEngine.Color> val_54 = new System.Nullable<UnityEngine.Color>(value:  new UnityEngine.Color() {r = val_53.r, g = val_53.g, b = val_53.b, a = val_53.a});
            val_52.SetOptions(bgColor:  new System.Nullable<UnityEngine.Color>() {HasValue = true}, fadeInDuration:  0f, fadeOutDuration:  0f);
            if(val_52 == 0)
            {
                    return;
            }
            
            val_65 = MonoSingleton<GameMaskOverlay>.Instance;
            UnityEngine.Transform[] val_57 = new UnityEngine.Transform[2];
            val_60 = val_57;
            val_60[0] = transform;
            val_60[1] = (X21 + 16 + -9223371933156869248) + 32.transform;
            val_65.ShowOverlay(contentToOverlay:  val_57);
        }
        public WFOMysteryChestFTUXPopup()
        {
        
        }
        private void <Start>b__6_0()
        {
            this.ftux_window.SetActive(value:  false);
            this.ShowTip();
        }
        private void <Start>b__6_1()
        {
            this.OnClick_UseHint();
            UnityEngine.Object.Destroy(obj:  this.gameObject);
        }
    
    }

}
