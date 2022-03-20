using UnityEngine;

namespace SRDebugger.UI.Controls
{
    public class ProfilerMonoBlock : SRMonoBehaviourEx
    {
        // Fields
        private float _lastRefresh;
        public UnityEngine.UI.Text CurrentUsedText;
        public UnityEngine.GameObject NotSupportedMessage;
        public UnityEngine.UI.Slider Slider;
        public UnityEngine.UI.Text TotalAllocatedText;
        private bool _isSupported;
        
        // Methods
        protected override void OnEnable()
        {
            this.OnEnable();
            uint val_1 = UnityEngine.Profiling.Profiler.GetMonoUsedSize();
            this._isSupported = (val_1 != 0) ? 1 : 0;
            this.NotSupportedMessage.SetActive(value:  (val_1 == 0) ? 1 : 0);
            this.CurrentUsedText.gameObject.SetActive(value:  this._isSupported);
            this.TriggerRefresh();
        }
        protected override void Update()
        {
            this.Update();
            var val_6 = 0;
            val_6 = val_6 + 1;
            if(SRDebug.Instance.IsDebugPanelVisible == false)
            {
                    return;
            }
            
            float val_4 = UnityEngine.Time.realtimeSinceStartup;
            val_4 = val_4 - this._lastRefresh;
            if(val_4 <= 1f)
            {
                    return;
            }
            
            this.TriggerRefresh();
            this._lastRefresh = UnityEngine.Time.realtimeSinceStartup;
        }
        public void TriggerRefresh()
        {
            UnityEngine.UI.Text val_12;
            var val_13;
            UnityEngine.UI.Text val_14;
            val_12 = this;
            if(this._isSupported != false)
            {
                    val_13 = UnityEngine.Profiling.Profiler.GetMonoHeapSize();
            }
            else
            {
                    val_13 = System.GC.GetTotalMemory(forceFullCollection:  false);
            }
            
            this.Slider.maxValue = (float)val_13;
            long val_4 = val_13 >> 10;
            val_14 = this.TotalAllocatedText;
            val_4 = (val_4 < 0) ? (val_4 + 1023) : (val_4);
            object[] val_7 = new object[1];
            val_7[0] = val_4 >> 10;
            string val_8 = System.String.Format(format:  "Total: <color=#FFFFFF>{0}</color>MB", args:  val_7);
            uint val_9 = UnityEngine.Profiling.Profiler.GetMonoUsedSize() >> 20;
            if(val_9 == 0)
            {
                    return;
            }
            
            val_12 = this.CurrentUsedText;
            object[] val_10 = new object[1];
            val_14 = val_9;
            val_10[0] = val_14;
            string val_11 = System.String.Format(format:  "<color=#FFFFFF>{0}</color>MB", args:  val_10);
        }
        public void TriggerCollection()
        {
            System.GC.Collect();
            this.TriggerRefresh();
        }
        public ProfilerMonoBlock()
        {
        
        }
    
    }

}
