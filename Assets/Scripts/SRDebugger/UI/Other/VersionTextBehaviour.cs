using UnityEngine;

namespace SRDebugger.UI.Other
{
    public class VersionTextBehaviour : SRMonoBehaviourEx
    {
        // Fields
        public string Format;
        public UnityEngine.UI.Text Text;
        
        // Methods
        protected override void Start()
        {
            this.Start();
            string val_1 = System.String.Format(format:  this.Format, arg0:  "1.6.0");
            goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
        }
        public VersionTextBehaviour()
        {
            this.Format = "SRDebugger {0}";
        }
    
    }

}
