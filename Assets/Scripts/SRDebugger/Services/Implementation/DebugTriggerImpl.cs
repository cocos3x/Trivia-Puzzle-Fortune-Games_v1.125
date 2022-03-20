using UnityEngine;

namespace SRDebugger.Services.Implementation
{
    public class DebugTriggerImpl : SRServiceBase<SRDebugger.Services.IDebugTriggerService>, IDebugTriggerService
    {
        // Fields
        private SRDebugger.PinAlignment _position;
        private SRDebugger.UI.Other.TriggerRoot _trigger;
        
        // Properties
        public bool IsEnabled { get; set; }
        public SRDebugger.PinAlignment Position { get; set; }
        
        // Methods
        public bool get_IsEnabled()
        {
            if(this._trigger == 0)
            {
                    return false;
            }
            
            return this._trigger.CachedGameObject.activeSelf;
        }
        public void set_IsEnabled(bool value)
        {
            if(value != false)
            {
                    if(this._trigger == 0)
            {
                    this.CreateTrigger();
            }
            
            }
            
            if(this._trigger == 0)
            {
                    return;
            }
            
            this._trigger.CachedGameObject.SetActive(value:  value);
        }
        public SRDebugger.PinAlignment get_Position()
        {
            return (SRDebugger.PinAlignment)this._position;
        }
        public void set_Position(SRDebugger.PinAlignment value)
        {
            if(this._trigger != 0)
            {
                    SRDebugger.Services.Implementation.DebugTriggerImpl.SetTriggerPosition(t:  this._trigger.TriggerTransform, position:  value);
            }
            
            this._position = value;
        }
        protected override void Awake()
        {
            this.Awake();
            UnityEngine.Object.DontDestroyOnLoad(target:  this.CachedGameObject);
            this.CachedTransform.SetParent(parent:  SRF.Hierarchy.Get(key:  "SRDebugger"), worldPositionStays:  true);
            this.name = "Trigger";
        }
        private void CreateTrigger()
        {
            SRDebugger.UI.Other.TriggerRoot val_1 = UnityEngine.Resources.Load<SRDebugger.UI.Other.TriggerRoot>(path:  "SRDebugger/UI/Prefabs/Trigger");
            if(val_1 == 0)
            {
                    UnityEngine.Debug.LogError(message:  "[SRDebugger] Error loading trigger prefab");
                return;
            }
            
            SRDebugger.UI.Other.TriggerRoot val_3 = SRInstantiate.Instantiate<SRDebugger.UI.Other.TriggerRoot>(prefab:  val_1);
            this._trigger = val_3;
            UnityEngine.Transform val_4 = val_3.CachedTransform;
            val_4.SetParent(parent:  this.CachedTransform, worldPositionStays:  true);
            SRDebugger.Services.Implementation.DebugTriggerImpl.SetTriggerPosition(t:  this._trigger.TriggerTransform, position:  this._position);
            SRDebugger.Settings val_6 = SRDebugger.Settings.Instance;
            if(val_6._triggerBehaviour == 2)
            {
                goto label_10;
            }
            
            if(val_6._triggerBehaviour == 1)
            {
                goto label_11;
            }
            
            if(val_6._triggerBehaviour == 0)
            {
                goto label_12;
            }
            
            System.Exception val_7 = null;
            this = val_7;
            val_7 = new System.Exception(message:  "Unhandled TriggerBehaviour");
            throw this;
            label_11:
            (System.Exception)[1152921519559083296]._remoteStackIndex + 80 + 264.AddListener(call:  new UnityEngine.Events.UnityAction(object:  val_7, method:  System.Void SRDebugger.Services.Implementation.DebugTriggerImpl::OnTriggerButtonClick()));
            if(((System.Exception)[1152921519559083296]._remoteStackIndex + 96) != 0)
            {
                goto label_17;
            }
            
            label_10:
            this._trigger.TripleTapButton.RequiredTapCount = 2;
            label_12:
            val_4.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SRDebugger.Services.Implementation.DebugTriggerImpl::OnTriggerButtonClick()));
            label_17:
            this._trigger.TapHoldButton.gameObject.SetActive(value:  false);
            bool val_11 = SRDebugger.Internal.SRDebuggerUtil.EnsureEventSystemExists();
            UnityEngine.SceneManagement.SceneManager.add_activeSceneChanged(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.Scene>(object:  0, method:  static System.Void SRDebugger.Services.Implementation.DebugTriggerImpl::OnActiveSceneChanged(UnityEngine.SceneManagement.Scene s1, UnityEngine.SceneManagement.Scene s2)));
        }
        protected override void OnDestroy()
        {
            UnityEngine.SceneManagement.SceneManager.remove_activeSceneChanged(value:  new UnityEngine.Events.UnityAction<UnityEngine.SceneManagement.Scene, UnityEngine.SceneManagement.Scene>(object:  0, method:  static System.Void SRDebugger.Services.Implementation.DebugTriggerImpl::OnActiveSceneChanged(UnityEngine.SceneManagement.Scene s1, UnityEngine.SceneManagement.Scene s2)));
            this.OnDestroy();
        }
        private static void OnActiveSceneChanged(UnityEngine.SceneManagement.Scene s1, UnityEngine.SceneManagement.Scene s2)
        {
            bool val_1 = SRDebugger.Internal.SRDebuggerUtil.EnsureEventSystemExists();
        }
        private void OnTriggerButtonClick()
        {
            var val_3 = 0;
            val_3 = val_3 + 1;
            SRDebug.Instance.ShowDebugPanel(requireEntryCode:  true);
        }
        private static void SetTriggerPosition(UnityEngine.RectTransform t, SRDebugger.PinAlignment position)
        {
            var val_4;
            float val_5;
            float val_6;
            val_4 = null;
            val_4 = null;
            val_5 = 0f;
            var val_1 = (App.game == 19) ? 7 : position;
            if(val_1 <= 7)
            {
                    var val_4 = 32558088;
                val_4 = (32558088 + (App.game == 0x13 ? 7 : position) << 2) + val_4;
            }
            else
            {
                    val_6 = 0f;
                if(val_1 <= 7)
            {
                    val_1 = 1 << val_1;
                if((val_1 & 42) == 0)
            {
                    val_6 = val_6;
                val_5 = 1f;
            }
            else
            {
                    if((val_1 & 192) == 0)
            {
                    val_5 = 0.5f;
                val_6 = val_6;
            }
            
            }
            
            }
            
                UnityEngine.Vector2 val_2 = new UnityEngine.Vector2(x:  val_5, y:  val_6);
                t.pivot = new UnityEngine.Vector2() {x = val_2.x, y = val_2.y};
                UnityEngine.Vector2 val_3 = new UnityEngine.Vector2(x:  val_5, y:  val_6);
                t.anchorMin = new UnityEngine.Vector2() {x = val_3.x, y = val_3.y};
                t.anchorMax = new UnityEngine.Vector2() {x = val_3.x, y = val_3.y};
            }
        
        }
        public DebugTriggerImpl()
        {
        
        }
    
    }

}
