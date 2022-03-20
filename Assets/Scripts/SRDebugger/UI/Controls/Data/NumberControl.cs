using UnityEngine;

namespace SRDebugger.UI.Controls.Data
{
    public class NumberControl : DataBoundControl
    {
        // Fields
        private static readonly System.Type[] IntegerTypes;
        private static readonly System.Type[] DecimalTypes;
        public static readonly System.Collections.Generic.Dictionary<System.Type, SRDebugger.UI.Controls.Data.NumberControl.ValueRange> ValueRanges;
        private string _lastValue;
        private System.Type _type;
        public UnityEngine.GameObject[] DisableOnReadOnly;
        public SRF.UI.SRNumberButton DownNumberButton;
        public SRF.UI.SRNumberSpinner NumberSpinner;
        public UnityEngine.UI.Text Title;
        public SRF.UI.SRNumberButton UpNumberButton;
        
        // Methods
        protected override void Start()
        {
            this.Start();
            this.Refresh();
            mem[1152921519546934896] = 1;
            AddListener(call:  new UnityEngine.Events.UnityAction<System.String>(object:  this, method:  System.Void SRDebugger.UI.Controls.Data.NumberControl::OnValueChanged(string newValue)));
        }
        private void OnValueChanged(string newValue)
        {
            this.UpdateValue(newValue:  System.Convert.ChangeType(value:  newValue, conversionType:  this._type));
        }
        protected override void OnBind(string propertyName, System.Type t)
        {
            ContentType val_14;
            var val_15;
            if((SRDebugger.UI.Controls.Data.NumberControl.IsIntegerType(t:  t)) != false)
            {
                    val_14 = 2;
            }
            else
            {
                    if((SRDebugger.UI.Controls.Data.NumberControl.IsDecimalType(t:  t)) == false)
            {
                    throw new System.ArgumentException(message:  "Type must be one of expected types", paramName:  "t");
            }
            
                val_14 = 3;
            }
            
            this.NumberSpinner.contentType = val_14;
            SROptions.NumberRangeAttribute val_3 = this.NumberSpinner.GetAttribute<SROptions.NumberRangeAttribute>();
            val_15 = val_3;
            this.NumberSpinner.MaxValue = val_3.GetMaxValue(t:  t);
            this.NumberSpinner.MinValue = val_3.GetMinValue(t:  t);
            if(val_15 != null)
            {
                    this.NumberSpinner.MaxValue = System.Math.Min(val1:  val_3.Max, val2:  this.NumberSpinner.MaxValue);
                this.NumberSpinner.MinValue = System.Math.Max(val1:  val_3.Min, val2:  this.NumberSpinner.MinValue);
            }
            
            SROptions.IncrementAttribute val_8 = 0.GetAttribute<SROptions.IncrementAttribute>();
            if(val_8 != null)
            {
                    val_15 = val_8;
                if(this.UpNumberButton != 0)
            {
                    this.UpNumberButton.Amount = val_8.Increment;
            }
            
                if(this.DownNumberButton != 0)
            {
                    this.DownNumberButton.Amount = -val_8.Increment;
            }
            
            }
            
            this._type = t;
            this.NumberSpinner.interactable = (this.DownNumberButton == 0) ? 1 : 0;
            if(this.DisableOnReadOnly == null)
            {
                    return;
            }
            
            if(this.DisableOnReadOnly.Length < 1)
            {
                    return;
            }
            
            do
            {
                1152921507144892032.SetActive(value:  (this.DisableOnReadOnly.Length == 0) ? 1 : 0);
                val_15 = 0 + 1;
            }
            while(val_15 < this.DisableOnReadOnly.Length);
        
        }
        protected override void OnValueUpdated(object newValue)
        {
            string val_1 = System.Convert.ToString(value:  newValue);
            if((System.String.op_Inequality(a:  val_1, b:  this._lastValue)) != false)
            {
                    this.NumberSpinner.text = val_1;
            }
            
            this._lastValue = val_1;
        }
        public override bool CanBind(System.Type type, bool isReadOnly)
        {
            if((SRDebugger.UI.Controls.Data.NumberControl.IsDecimalType(t:  type)) == false)
            {
                    return SRDebugger.UI.Controls.Data.NumberControl.IsIntegerType(t:  type);
            }
            
            return true;
        }
        protected static bool IsIntegerType(System.Type t)
        {
            var val_2;
            var val_3;
            System.Type[] val_4;
            var val_5;
            val_2 = 0;
            label_11:
            val_3 = null;
            val_3 = null;
            val_4 = SRDebugger.UI.Controls.Data.NumberControl.IntegerTypes;
            if(val_2 >= SRDebugger.UI.Controls.Data.NumberControl.IntegerTypes.Length)
            {
                goto label_4;
            }
            
            val_4 = SRDebugger.UI.Controls.Data.NumberControl.IntegerTypes;
            val_2 = val_2 + 1;
            if((System.Type.op_Equality(left:  SRDebugger.UI.Controls.Data.NumberControl.IntegerTypes + 32, right:  t)) == false)
            {
                goto label_11;
            }
            
            val_5 = 1;
            return (bool)val_5;
            label_4:
            val_5 = 0;
            return (bool)val_5;
        }
        protected static bool IsDecimalType(System.Type t)
        {
            var val_2;
            var val_3;
            System.Type[] val_4;
            var val_5;
            val_2 = 0;
            label_11:
            val_3 = null;
            val_3 = null;
            val_4 = SRDebugger.UI.Controls.Data.NumberControl.DecimalTypes;
            if(val_2 >= SRDebugger.UI.Controls.Data.NumberControl.DecimalTypes.Length)
            {
                goto label_4;
            }
            
            val_4 = SRDebugger.UI.Controls.Data.NumberControl.DecimalTypes;
            val_2 = val_2 + 1;
            if((System.Type.op_Equality(left:  SRDebugger.UI.Controls.Data.NumberControl.DecimalTypes + 32, right:  t)) == false)
            {
                goto label_11;
            }
            
            val_5 = 1;
            return (bool)val_5;
            label_4:
            val_5 = 0;
            return (bool)val_5;
        }
        protected double GetMaxValue(System.Type t)
        {
            System.Type val_4;
            var val_5;
            val_4 = t;
            val_5 = null;
            val_5 = null;
            if((SRDebugger.UI.Controls.Data.NumberControl.ValueRanges.TryGetValue(key:  val_4, value: out  new ValueRange())) != false)
            {
                    return 1.79769313486232E+308;
            }
            
            object[] val_2 = new object[1];
            val_2[0] = val_4;
            val_4 = System.String.Format(format:  "[NumberControl] No MaxValue stored for type {0}", args:  val_2);
            UnityEngine.Debug.LogWarning(message:  val_4);
            return 1.79769313486232E+308;
        }
        protected double GetMinValue(System.Type t)
        {
            System.Type val_4;
            var val_5;
            val_4 = t;
            val_5 = null;
            val_5 = null;
            if((SRDebugger.UI.Controls.Data.NumberControl.ValueRanges.TryGetValue(key:  val_4, value: out  new ValueRange())) != false)
            {
                    return -1.79769313486232E+308;
            }
            
            object[] val_2 = new object[1];
            val_2[0] = val_4;
            val_4 = System.String.Format(format:  "[NumberControl] No MinValue stored for type {0}", args:  val_2);
            UnityEngine.Debug.LogWarning(message:  val_4);
            return -1.79769313486232E+308;
        }
        public NumberControl()
        {
            val_1 = new SRF.SRMonoBehaviourEx();
        }
        private static NumberControl()
        {
            System.Type[] val_1 = new System.Type[6];
            val_1[0] = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
            val_1[1] = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
            val_1[2] = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
            val_1[3] = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
            val_1[4] = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
            val_1[5] = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
            SRDebugger.UI.Controls.Data.NumberControl.IntegerTypes = val_1;
            System.Type[] val_8 = new System.Type[2];
            val_8[0] = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
            val_8[1] = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
            SRDebugger.UI.Controls.Data.NumberControl.DecimalTypes = val_8;
            System.Collections.Generic.Dictionary<System.Type, ValueRange> val_11 = new System.Collections.Generic.Dictionary<System.Type, ValueRange>();
            val_11.Add(key:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value:  new ValueRange() {MaxValue = 2147483647, MinValue = -2147483648});
            val_11.Add(key:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value:  new ValueRange() {MaxValue = 32767, MinValue = -32768});
            val_11.Add(key:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value:  new ValueRange() {MaxValue = 255});
            val_11.Add(key:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value:  new ValueRange() {MaxValue = 127, MinValue = -128});
            val_11.Add(key:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value:  new ValueRange() {MaxValue = 4294967295});
            val_11.Add(key:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value:  new ValueRange() {MaxValue = 65535});
            val_11.Add(key:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value:  new ValueRange() {MaxValue = 3.40282346638529E+38, MinValue = -3.40282346638529E+38});
            val_11.Add(key:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value:  new ValueRange() {MaxValue = 1.79769313486232E+308, MinValue = -1.79769313486232E+308});
            SRDebugger.UI.Controls.Data.NumberControl.ValueRanges = val_11;
        }
    
    }

}
