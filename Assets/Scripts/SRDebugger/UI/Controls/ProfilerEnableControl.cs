using UnityEngine;

namespace SRDebugger.UI.Controls
{
    public class ProfilerEnableControl : SRMonoBehaviourEx
    {
        // Fields
        private bool _previousState;
        public UnityEngine.UI.Text ButtonText;
        public UnityEngine.UI.Button EnableButton;
        public UnityEngine.UI.Text Text;
        
        // Methods
        protected override void Start()
        {
            UnityEngine.UI.Text val_4;
            var val_5;
            var val_7;
            this.Start();
            if(UnityEngine.Profiling.Profiler.supported == false)
            {
                goto label_1;
            }
            
            if(UnityEngine.Application.HasProLicense() == false)
            {
                goto label_2;
            }
            
            this.UpdateLabels();
            return;
            label_1:
            val_4 = this.Text;
            val_5 = null;
            val_5 = null;
            goto label_7;
            label_2:
            val_4 = this.Text;
            val_7 = null;
            val_7 = null;
            label_7:
            this.EnableButton.gameObject.SetActive(value:  false);
            this.enabled = false;
        }
        protected void UpdateLabels()
        {
            var val_4;
            var val_5;
            var val_7;
            var val_8;
            val_4 = null;
            if(UnityEngine.Profiling.Profiler.enabled != false)
            {
                    val_5 = null;
                val_7 = "Disable";
            }
            else
            {
                    val_8 = null;
                val_7 = "Enable";
            }
            
            this._previousState = UnityEngine.Profiling.Profiler.enabled;
        }
        protected override void Update()
        {
            this.Update();
            var val_2 = (this._previousState == true) ? 1 : 0;
            val_2 = UnityEngine.Profiling.Profiler.enabled ^ val_2;
            if(val_2 == false)
            {
                    return;
            }
            
            this.UpdateLabels();
        }
        public void ToggleProfiler()
        {
            UnityEngine.Debug.Log(message:  "Toggle Profiler");
            bool val_1 = UnityEngine.Profiling.Profiler.enabled;
            val_1 = (~val_1) & 1;
            UnityEngine.Profiling.Profiler.enabled = val_1;
        }
        public ProfilerEnableControl()
        {
        
        }
    
    }

}
