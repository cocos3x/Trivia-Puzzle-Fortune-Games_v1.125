using UnityEngine;

namespace SRDebugger.UI.Controls
{
    public class ProfilerMemoryBlock : SRMonoBehaviourEx
    {
        // Fields
        private float _lastRefresh;
        public UnityEngine.UI.Text CurrentUsedText;
        public UnityEngine.UI.Slider Slider;
        public UnityEngine.UI.Text TotalAllocatedText;
        
        // Methods
        protected override void OnEnable()
        {
            this.OnEnable();
            this.TriggerRefresh();
        }
        protected override void Update()
        {
            this.Update();
            float val_1 = UnityEngine.Time.realtimeSinceStartup;
            val_1 = val_1 - this._lastRefresh;
            if(val_1 <= 1f)
            {
                    return;
            }
            
            this.TriggerRefresh();
            this._lastRefresh = UnityEngine.Time.realtimeSinceStartup;
        }
        public void TriggerRefresh()
        {
            uint val_1 = UnityEngine.Profiling.Profiler.GetTotalReservedMemory();
            this.Slider.maxValue = (float)(double)val_1;
            object[] val_4 = new object[1];
            val_4[0] = val_1 >> 20;
            string val_5 = System.String.Format(format:  "Reserved: <color=#FFFFFF>{0}</color>MB", args:  val_4);
            object[] val_7 = new object[1];
            val_7[0] = UnityEngine.Profiling.Profiler.GetTotalAllocatedMemory() >> 20;
            string val_8 = System.String.Format(format:  "<color=#FFFFFF>{0}</color>MB", args:  val_7);
        }
        public void TriggerCleanup()
        {
            UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.CleanUp());
        }
        private System.Collections.IEnumerator CleanUp()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new ProfilerMemoryBlock.<CleanUp>d__8();
        }
        public ProfilerMemoryBlock()
        {
        
        }
    
    }

}
