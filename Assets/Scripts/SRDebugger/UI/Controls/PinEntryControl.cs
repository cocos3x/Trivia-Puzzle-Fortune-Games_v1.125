using UnityEngine;

namespace SRDebugger.UI.Controls
{
    public class PinEntryControl : SRMonoBehaviourEx
    {
        // Fields
        private bool _isVisible;
        private System.Collections.Generic.List<int> _numbers;
        public UnityEngine.UI.Image Background;
        public bool CanCancel;
        public UnityEngine.UI.Button CancelButton;
        public UnityEngine.UI.Text CancelButtonText;
        public UnityEngine.CanvasGroup CanvasGroup;
        public UnityEngine.Animator DotAnimator;
        public UnityEngine.UI.Button[] NumberButtons;
        public UnityEngine.UI.Toggle[] NumberDots;
        public UnityEngine.UI.Text PromptText;
        private SRDebugger.UI.Controls.PinEntryControlCallback Complete;
        
        // Methods
        public void add_Complete(SRDebugger.UI.Controls.PinEntryControlCallback value)
        {
            do
            {
                if((System.Delegate.Combine(a:  this.Complete, b:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.Complete != 1152921519535665648);
            
            return;
            label_2:
        }
        public void remove_Complete(SRDebugger.UI.Controls.PinEntryControlCallback value)
        {
            do
            {
                if((System.Delegate.Remove(source:  this.Complete, value:  value)) != null)
            {
                    if(null != null)
            {
                goto label_2;
            }
            
            }
            
            }
            while(this.Complete != 1152921519535802224);
            
            return;
            label_2:
        }
        protected override void Awake()
        {
            this.Awake();
            int val_5 = 0;
            label_8:
            if(val_5 >= this.NumberButtons.Length)
            {
                goto label_2;
            }
            
            .<>4__this = this;
            .number = val_5;
            UnityEngine.UI.Button val_4 = this.NumberButtons[val_5];
            this.NumberButtons[0x0][0].m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  new PinEntryControl.<>c__DisplayClass14_0(), method:  System.Void PinEntryControl.<>c__DisplayClass14_0::<Awake>b__0()));
            val_5 = val_5 + 1;
            if(this.NumberButtons != null)
            {
                goto label_8;
            }
            
            throw new NullReferenceException();
            label_2:
            this.CancelButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SRDebugger.UI.Controls.PinEntryControl::CancelButtonPressed()));
            this.RefreshState();
        }
        protected override void Update()
        {
            this.Update();
            if(this._isVisible == false)
            {
                    return;
            }
            
            if(this._numbers >= 1)
            {
                    if((UnityEngine.Input.GetKeyDown(key:  8)) != true)
            {
                    if((UnityEngine.Input.GetKeyDown(key:  127)) == false)
            {
                goto label_5;
            }
            
            }
            
                int val_3 = SRF.SRFIListExtensions.PopLast<System.Int32>(list:  this._numbers);
                this.RefreshState();
            }
            
            label_5:
            string val_4 = UnityEngine.Input.inputString;
            if(val_4.m_stringLength < 1)
            {
                    return;
            }
            
            var val_7 = 0;
            do
            {
                if((System.Char.IsNumber(s:  val_4, index:  0)) != false)
            {
                    double val_6 = System.Char.GetNumericValue(s:  val_4, index:  0);
                val_6 = (val_6 == Infinity) ? (-val_6) : (val_6);
                if((int)val_6 <= 9)
            {
                    this.PushNumber(number:  (int)val_6);
            }
            
            }
            
                val_7 = val_7 + 1;
            }
            while(val_7 < val_4.m_stringLength);
        
        }
        public void Show()
        {
            this.CanvasGroup.alpha = 1f;
            this.CanvasGroup.interactable = true;
            this.CanvasGroup.blocksRaycasts = true;
            this._isVisible = true;
        }
        public void Hide()
        {
            this.CanvasGroup.alpha = 0f;
            this.CanvasGroup.interactable = false;
            this.CanvasGroup.blocksRaycasts = false;
            this._isVisible = false;
        }
        public void Clear()
        {
            this._numbers.Clear();
            this.RefreshState();
        }
        public void PlayInvalidCodeAnimation()
        {
            this.DotAnimator.SetTrigger(name:  "Invalid");
        }
        protected void OnComplete()
        {
            if(this.Complete == null)
            {
                    return;
            }
            
            this.Complete.Invoke(result:  new System.Collections.ObjectModel.ReadOnlyCollection<System.Int32>(list:  this._numbers), didCancel:  false);
        }
        protected void OnCancel()
        {
            if(this.Complete == null)
            {
                    return;
            }
            
            this.Complete.Invoke(result:  new int[0], didCancel:  true);
        }
        private void CancelButtonPressed()
        {
            if(true >= 1)
            {
                    int val_1 = SRF.SRFIListExtensions.PopLast<System.Int32>(list:  this._numbers);
            }
            else
            {
                    this.OnCancel();
            }
            
            this.RefreshState();
        }
        public void PushNumber(int number)
        {
            if(true >= 4)
            {
                    UnityEngine.Debug.LogWarning(message:  "[PinEntry] Expected 4 numbers");
                return;
            }
            
            this._numbers.Add(item:  number);
            if(this._numbers >= 4)
            {
                    this.OnComplete();
            }
            
            this.RefreshState();
        }
        private void RefreshState()
        {
            var val_4 = 0;
            label_6:
            if(val_4 >= this.NumberDots.Length)
            {
                goto label_2;
            }
            
            this.NumberDots[val_4].isOn = (val_4 < this.NumberDots[val_4]) ? 1 : 0;
            val_4 = val_4 + 1;
            if(this.NumberDots != null)
            {
                goto label_6;
            }
            
            throw new NullReferenceException();
            label_2:
            if(this._numbers >= 1)
            {
                
            }
            else
            {
                    var val_2 = (this.CanCancel == false) ? "" : "Cancel";
            }
        
        }
        public PinEntryControl()
        {
            this._isVisible = true;
            this._numbers = new System.Collections.Generic.List<System.Int32>(capacity:  4);
            this.CanCancel = true;
        }
    
    }

}
