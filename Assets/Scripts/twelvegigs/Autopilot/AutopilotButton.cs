using UnityEngine;

namespace twelvegigs.Autopilot
{
    public class AutopilotButton : MonoBehaviour
    {
        // Fields
        public const string TEST_TEXT = "Hello, brave new world!!";
        private int <CameraId>k__BackingField;
        private float <CameraDepth>k__BackingField;
        public UnityEngine.Vector3 centerPos;
        private UnityEngine.UI.Selectable selectable;
        private string route;
        private string cameraName;
        private bool exclude;
        private int count;
        private int hiddenCount;
        private UnityEngine.UI.Button button;
        private UnityEngine.UI.Toggle toggle;
        private UnityEngine.UI.InputField inputField;
        private UnityEngine.UI.ScrollRect scroll;
        
        // Properties
        public int CameraId { get; set; }
        public float CameraDepth { get; set; }
        public string Route { get; }
        public UnityEngine.GameObject Target { get; }
        public bool SkipExecuteClick { get; }
        
        // Methods
        public int get_CameraId()
        {
            return (int)this.<CameraId>k__BackingField;
        }
        public void set_CameraId(int value)
        {
            this.<CameraId>k__BackingField = value;
        }
        public float get_CameraDepth()
        {
            return (float)this.<CameraDepth>k__BackingField;
        }
        public void set_CameraDepth(float value)
        {
            this.<CameraDepth>k__BackingField = value;
        }
        public string get_Route()
        {
            return (string)this.route;
        }
        public UnityEngine.GameObject get_Target()
        {
            if(this.selectable == 0)
            {
                    return 0;
            }
            
            Transition val_3 = this.selectable.m_Transition;
            val_3 = val_3 - 1;
            if(val_3 > 1)
            {
                    return this.selectable.gameObject;
            }
            
            if((this.selectable.m_TargetGraphic == 0) || ((this.selectable.m_TargetGraphic & 1) == 0))
            {
                    return this.selectable.gameObject;
            }
            
            if(this.selectable.m_TargetGraphic != null)
            {
                    return this.selectable.gameObject;
            }
            
            throw new NullReferenceException();
        }
        public bool get_SkipExecuteClick()
        {
            return UnityEngine.Object.op_Inequality(x:  this.inputField, y:  0);
        }
        private void Start()
        {
            UnityEngine.UI.Selectable val_1 = this.GetComponent<UnityEngine.UI.Selectable>();
            this.selectable = val_1;
            if(val_1 == 0)
            {
                    return;
            }
            
            string val_4 = twelvegigs.Autopilot.AutopilotTools.GetRoute(transform:  this.transform);
            this.route = val_4;
            if((val_4.Contains(value:  "SRDebugger")) != false)
            {
                    this.exclude = true;
                return;
            }
            
            this.exclude = true;
            UnityEngine.Camera val_9 = twelvegigs.Autopilot.AutopilotTools.GetCamera(go:  this.transform);
            this.<CameraDepth>k__BackingField = -1f;
            if(val_9 != 0)
            {
                    this.<CameraId>k__BackingField = val_9.GetInstanceID();
                this.cameraName = val_9.name;
                this.<CameraDepth>k__BackingField = val_9.depth;
            }
            
            this.count = this.GetCount(hidden:  false);
            this.hiddenCount = this.GetCount(hidden:  true);
        }
        public int GetCount(bool hidden = False)
        {
            return MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance.ButtonPressedCount(path:  this.route, hiddenCount:  hidden);
        }
        public int GetTotalCount()
        {
            int val_2 = this.GetCount(hidden:  true);
            val_2 = val_2 + (this.GetCount(hidden:  false));
            return (int)val_2;
        }
        public System.Collections.Generic.List<UnityEngine.GameObject> GetTargets()
        {
            UnityEngine.UI.Selectable val_11;
            var val_12;
            System.Collections.Generic.List<UnityEngine.GameObject> val_1 = new System.Collections.Generic.List<UnityEngine.GameObject>();
            val_11 = this.selectable;
            if(val_11 == 0)
            {
                    return val_1;
            }
            
            val_11 = this.selectable.GetComponents<UnityEngine.UI.Graphic>();
            if(val_3.Length >= 1)
            {
                    do
            {
                T val_11 = val_11[0];
                if((val_11 & 1) != 0)
            {
                    if((val_1.Contains(item:  val_11.gameObject)) != true)
            {
                    val_1.Add(item:  val_11.gameObject);
            }
            
            }
            
                val_12 = 0 + 1;
            }
            while(val_12 < val_3.Length);
            
            }
            
            if(val_3.Length > 0)
            {
                    return val_1;
            }
            
            if(val_7.Length < 1)
            {
                    return val_1;
            }
            
            val_12 = 1152921519994868288;
            var val_12 = 0;
            do
            {
                val_11 = this.selectable.GetComponentsInChildren<UnityEngine.UI.Graphic>()[val_12];
                if((val_11 & 1) != 0)
            {
                    if((val_1.Contains(item:  val_11.gameObject)) != true)
            {
                    val_1.Add(item:  val_11.gameObject);
            }
            
            }
            
                val_12 = val_12 + 1;
            }
            while(val_12 < val_7.Length);
            
            return val_1;
        }
        public bool CanBePressed()
        {
            if(this.selectable == 0)
            {
                    return false;
            }
            
            if(this.gameObject == 0)
            {
                    return false;
            }
            
            if(this.exclude != false)
            {
                    return false;
            }
            
            if(this.selectable.m_Interactable == false)
            {
                    return false;
            }
            
            if(this.selectable.enabled == false)
            {
                    return false;
            }
            
            return this.gameObject.activeInHierarchy;
        }
        public UnityEngine.Vector3 GetWorldCenterPos()
        {
            return this.GetWorldCenterPos(target:  this.Target);
        }
        public UnityEngine.Vector3 GetWorldCenterPos(UnityEngine.GameObject target)
        {
            if(target == 0)
            {
                goto label_3;
            }
            
            UnityEngine.RectTransform val_2 = target.GetComponent<UnityEngine.RectTransform>();
            if(val_2 != 0)
            {
                goto label_7;
            }
            
            label_3:
            UnityEngine.Vector3 val_5 = this.transform.position;
            return new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z};
            label_7:
            UnityEngine.Vector3[] val_6 = new UnityEngine.Vector3[4];
            val_2.GetWorldCorners(fourCornersArray:  val_6);
            UnityEngine.Vector3 val_7 = val_2.CenterOfVectors(vectors:  val_6);
            this.centerPos = val_7;
            mem[1152921519995451588] = val_7.y;
            mem[1152921519995451592] = val_7.z;
            return new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z};
        }
        public virtual void OnValueChanged(bool value)
        {
            if(value == false)
            {
                    return;
            }
            
            goto typeof(twelvegigs.Autopilot.AutopilotButton).__il2cppRuntimeField_180;
        }
        public virtual void OnButtonClick(bool hiddenClick = False)
        {
            int val_13;
            if(this.inputField != 0)
            {
                    this.inputField.text = "Hello, brave new world!!";
            }
            
            if(hiddenClick != false)
            {
                    this.hiddenCount = (this.GetCount(hidden:  true)) + 1;
            }
            else
            {
                    this.count = (this.GetCount(hidden:  false)) + 1;
            }
            
            object[] val_6 = new object[7];
            val_6[0] = this.route;
            val_6[1] = this.gameObject.GetInstanceID();
            val_13 = val_6.Length;
            val_6[2] = this.gameObject.name;
            if(this.cameraName != null)
            {
                    val_13 = val_6.Length;
            }
            
            val_6[3] = this.cameraName;
            val_6[4] = this.<CameraDepth>k__BackingField;
            val_6[5] = this.count;
            val_6[6] = this.centerPos;
            twelvegigs.Autopilot.AutopilotTools.LogFormat(format:  "<color=green>OnClick:</color> {0}\n{1}: {2}\n camera: {3} \n depth: {4}\n Count: {5} \n Rect:{6}", args:  val_6);
            MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance.UpdateCounter(path:  this.route, count:  this.count, hiddenCount:  this.hiddenCount);
            MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance.TrackButtonPressed(button:  this);
        }
        public override string ToString()
        {
            int val_7;
            string val_3 = this.route.Substring(startIndex:  UnityEngine.Mathf.Max(a:  0, b:  this.route.m_stringLength - 50));
            object[] val_4 = new object[4];
            val_4[0] = this.<CameraDepth>k__BackingField;
            val_4[1] = this.count;
            val_7 = val_4.Length;
            val_4[2] = this.name;
            if(val_3 != null)
            {
                    val_7 = val_4.Length;
            }
            
            val_4[3] = val_3;
            return (string)System.String.Format(format:  "Depth:{0} Count:{1} Name:{2} Route:{3}", args:  val_4);
        }
        private UnityEngine.Vector3 CenterOfVectors(UnityEngine.Vector3[] vectors)
        {
            float val_7;
            float val_8;
            float val_9;
            int val_10;
            float val_14;
            float val_15;
            float val_16;
            float val_20;
            float val_21;
            float val_22;
            UnityEngine.Vector3 val_1 = UnityEngine.Vector3.zero;
            val_7 = val_1.x;
            val_8 = val_1.y;
            val_9 = val_1.z;
            if(vectors == null)
            {
                    return new UnityEngine.Vector3() {x = val_20, y = val_21, z = val_22};
            }
            
            val_10 = vectors.Length;
            if(val_10 == 0)
            {
                    return new UnityEngine.Vector3() {x = val_20, y = val_21, z = val_22};
            }
            
            if(val_10 >= 1)
            {
                    var val_4 = 0;
                do
            {
                UnityEngine.Vector3 val_2 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_7, y = val_8, z = val_9}, b:  new UnityEngine.Vector3() {x = 1.187865E-20f, y = 1.187865E-20f, z = 1.187865E-20f});
                val_10 = vectors.Length;
                val_4 = val_4 + 1;
                val_14 = val_2.x;
                val_15 = val_2.y;
                val_16 = val_2.z;
            }
            while(val_4 < (val_10 << ));
            
            }
            
            val_10 = vectors.Length;
            UnityEngine.Vector3 val_3 = UnityEngine.Vector3.op_Division(a:  new UnityEngine.Vector3() {x = val_14, y = val_15, z = val_16}, d:  (float)val_10);
            val_20 = val_3.x;
            val_21 = val_3.y;
            val_22 = val_3.z;
            return new UnityEngine.Vector3() {x = val_20, y = val_21, z = val_22};
        }
        public AutopilotButton()
        {
            UnityEngine.Vector3 val_1 = UnityEngine.Vector3.zero;
            this.centerPos = val_1;
            mem[1152921519996282692] = val_1.y;
            mem[1152921519996282696] = val_1.z;
            this.route = System.String.alignConst;
            this.cameraName = System.String.alignConst;
        }
    
    }

}
