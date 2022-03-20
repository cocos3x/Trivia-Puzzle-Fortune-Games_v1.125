using UnityEngine;

namespace Crystal
{
    public class SafeAreaDemo : MonoBehaviour
    {
        // Fields
        private UnityEngine.KeyCode KeySafeArea;
        private UnityEngine.KeyCode KeyLayout;
        private UnityEngine.KeyCode KeyDisplay;
        private Crystal.SafeArea.SimDevice[] Sims;
        private int SimIdx;
        private UnityEngine.GameObject safeAreaLayout;
        private UnityEngine.UI.Image phoneLayout;
        private UnityEngine.GameObject text;
        
        // Methods
        private void Awake()
        {
            if(UnityEngine.Application.isEditor != true)
            {
                    UnityEngine.Object.Destroy(obj:  this.gameObject);
            }
            
            if((System.Enum.GetValues(enumType:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()))) != null)
            {
                    if(X0 == false)
            {
                goto label_9;
            }
            
            }
            
            this.Sims = null;
            return;
            label_9:
        }
        private void Update()
        {
            if((UnityEngine.Input.GetKeyDown(key:  this.KeySafeArea)) != false)
            {
                    this.ToggleSafeArea();
            }
            
            if((UnityEngine.Input.GetKeyDown(key:  this.KeyLayout)) != false)
            {
                    this.TogglePhoneLayout();
            }
            
            if((UnityEngine.Input.GetKeyDown(key:  this.KeyDisplay)) == false)
            {
                    return;
            }
            
            this.ToggleTipDisplay();
        }
        private void ToggleSafeArea()
        {
            int val_2;
            int val_3;
            var val_4;
            val_2 = this.SimIdx + 1;
            this.SimIdx = val_2;
            val_3 = this.Sims.Length;
            if(val_2 >= val_3)
            {
                    this.SimIdx = 0;
                val_3 = this.Sims.Length;
                val_2 = 0;
            }
            
            val_4 = null;
            val_4 = null;
            Crystal.SafeArea.Sim = this.Sims[0];
            object[] val_1 = new object[2];
            val_1[0] = this.Sims[(this.SimIdx) << 2];
            val_1[1] = this.KeySafeArea;
            UnityEngine.Debug.LogFormat(format:  "Switched to sim device {0} with debug key \'{1}\'", args:  val_1);
        }
        private void TogglePhoneLayout()
        {
            bool val_3 = this.safeAreaLayout.activeSelf ^ 1;
            this.safeAreaLayout.SetActive(value:  val_3);
            this.phoneLayout.enabled = val_3;
        }
        private void ToggleTipDisplay()
        {
            if((UnityEngine.Object.op_Implicit(exists:  this.text)) == false)
            {
                    return;
            }
            
            this.text.SetActive(value:  (~this.text.activeSelf) & 1);
        }
        public SafeAreaDemo()
        {
            this.KeyDisplay = 100;
            this.KeySafeArea = 2.44029516008931E-312;
        }
    
    }

}
