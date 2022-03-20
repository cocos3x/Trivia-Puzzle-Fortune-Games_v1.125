using UnityEngine;

namespace SRDebugger.UI
{
    public class ProfilerFPSLabel : SRMonoBehaviourEx
    {
        // Fields
        private float _nextUpdate;
        private SRDebugger.Services.IProfilerService _profilerService;
        public float UpdateFrequency;
        private UnityEngine.UI.Text _text;
        
        // Methods
        protected override void Update()
        {
            this.Update();
            if(UnityEngine.Time.realtimeSinceStartup <= this._nextUpdate)
            {
                    return;
            }
            
            this.Refresh();
        }
        private void Refresh()
        {
            object[] val_1 = new object[1];
            var val_6 = 0;
            val_6 = val_6 + 1;
            float val_3 = this._profilerService.AverageFrameTime;
            val_3 = 1f / val_3;
            val_1[0] = val_3;
            string val_4 = System.String.Format(format:  "FPS: {0:0.00}", args:  val_1);
            float val_5 = UnityEngine.Time.realtimeSinceStartup;
            val_5 = val_5 + this.UpdateFrequency;
            this._nextUpdate = val_5;
        }
        public ProfilerFPSLabel()
        {
            this.UpdateFrequency = 1f;
        }
    
    }

}
