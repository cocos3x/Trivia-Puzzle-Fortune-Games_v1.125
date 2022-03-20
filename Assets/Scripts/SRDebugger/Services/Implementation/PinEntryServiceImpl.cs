using UnityEngine;

namespace SRDebugger.Services.Implementation
{
    public class PinEntryServiceImpl : SRServiceBase<SRDebugger.Services.IPinEntryService>, IPinEntryService
    {
        // Fields
        private SRDebugger.Services.PinEntryCompleteCallback _callback;
        private bool _isVisible;
        private SRDebugger.UI.Controls.PinEntryControl _pinControl;
        private System.Collections.Generic.List<int> _requiredPin;
        
        // Properties
        public bool IsShowingKeypad { get; }
        
        // Methods
        public bool get_IsShowingKeypad()
        {
            return (bool)this._isVisible;
        }
        public void ShowPinEntry(System.Collections.Generic.IList<int> requiredPin, string message, SRDebugger.Services.PinEntryCompleteCallback callback, bool allowCancel = True)
        {
            if(this._isVisible == true)
            {
                    throw new System.InvalidOperationException(message:  "Pin entry is already in progress");
            }
            
            this.VerifyPin(pin:  requiredPin);
            if(this._pinControl == 0)
            {
                    this.Load();
            }
            
            if(this._pinControl == 0)
            {
                    UnityEngine.Debug.LogWarning(message:  "[PinEntry] Pin entry failed loading, executing callback with fail result");
                callback.Invoke(validPinEntered:  false);
                return;
            }
            
            this._pinControl.Clear();
            this._pinControl.CanCancel = allowCancel;
            this._callback = callback;
            this._requiredPin.Clear();
            this._requiredPin.AddRange(collection:  requiredPin);
            this._pinControl.Show();
            this._isVisible = true;
            bool val_4 = SRDebugger.Internal.SRDebuggerUtil.EnsureEventSystemExists();
        }
        public void ShowPinEntry(System.Collections.Generic.IList<int> requiredPin, string message, SRDebugger.Services.PinEntryCompleteCallback callback, bool blockInput, bool allowCancel)
        {
            this.ShowPinEntry(requiredPin:  requiredPin, message:  message, callback:  callback, allowCancel:  allowCancel);
        }
        protected override void Awake()
        {
            this.Awake();
            this.CachedTransform.SetParent(p:  SRF.Hierarchy.Get(key:  "SRDebugger"));
        }
        private void Load()
        {
            SRDebugger.UI.Controls.PinEntryControl val_1 = UnityEngine.Resources.Load<SRDebugger.UI.Controls.PinEntryControl>(path:  "SRDebugger/UI/Prefabs/PinEntry");
            if(val_1 == 0)
            {
                    UnityEngine.Debug.LogError(message:  "[PinEntry] Unable to load pin entry prefab");
                return;
            }
            
            SRDebugger.UI.Controls.PinEntryControl val_3 = SRInstantiate.Instantiate<SRDebugger.UI.Controls.PinEntryControl>(prefab:  val_1);
            this._pinControl = val_3;
            val_3.CachedTransform.SetParent(parent:  this.CachedTransform, worldPositionStays:  false);
            this._pinControl.Hide();
            this._pinControl.add_Complete(value:  new SRDebugger.UI.Controls.PinEntryControlCallback(object:  this, method:  System.Void SRDebugger.Services.Implementation.PinEntryServiceImpl::PinControlOnComplete(System.Collections.Generic.IList<int> result, bool didCancel)));
        }
        private void PinControlOnComplete(System.Collections.Generic.IList<int> result, bool didCancel)
        {
            bool val_3;
            bool val_1 = System.Linq.Enumerable.SequenceEqual<System.Int32>(first:  this._requiredPin, second:  result);
            if((val_1 != true) && (didCancel != true))
            {
                    this._pinControl.Clear();
                this._pinControl.PlayInvalidCodeAnimation();
                return;
            }
            
            this._isVisible = false;
            this._pinControl.Hide();
            if(didCancel != false)
            {
                    val_3 = 0;
            }
            else
            {
                    val_3 = val_1;
            }
            
            this._callback.Invoke(validPinEntered:  val_3);
        }
        private void VerifyPin(System.Collections.Generic.IList<int> pin)
        {
            var val_6;
            var val_7;
            var val_11;
            val_6 = pin;
            var val_10 = 0;
            val_10 = val_10 + 1;
            val_7 = 0;
            if(val_6.Count != 4)
            {
                goto label_22;
            }
            
            var val_14 = 0;
            label_21:
            var val_11 = 0;
            val_11 = val_11 + 1;
            val_7 = 0;
            if(val_14 >= val_6.Count)
            {
                    return;
            }
            
            var val_12 = 0;
            val_12 = val_12 + 1;
            val_7 = 0;
            val_11 = public T System.Collections.Generic.IList<T>::get_Item(int index);
            if((val_6.Item[0] & 2147483648) != 0)
            {
                goto label_16;
            }
            
            var val_13 = 0;
            val_13 = val_13 + 1;
            val_11 = 0;
            val_14 = val_14 + 1;
            if(val_6.Item[0] < 10)
            {
                goto label_21;
            }
            
            label_16:
            System.ArgumentException val_9 = null;
            label_22:
            val_6 = val_9;
            val_9 = new System.ArgumentException(message:  "Pin numbers must be >= 0 && <= 9");
            throw val_6;
        }
        public PinEntryServiceImpl()
        {
            this._requiredPin = new System.Collections.Generic.List<System.Int32>(capacity:  4);
        }
    
    }

}
