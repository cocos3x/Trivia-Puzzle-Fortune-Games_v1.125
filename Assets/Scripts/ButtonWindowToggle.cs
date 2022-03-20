using UnityEngine;
public class ButtonWindowToggle : MyButton
{
    // Fields
    private UnityEngine.GameObject selfWindow;
    private bool closeSelf;
    private WGWindowPool toggleWindow;
    private System.Collections.Generic.Dictionary<WGWindowPool, System.Action<bool>> ToggleActions;
    
    // Methods
    public override void OnButtonClick()
    {
        var val_4;
        System.Action<System.Boolean> val_1 = this.ToggleActions.Item[this.toggleWindow];
        if((UnityEngine.Object.op_Implicit(exists:  this.selfWindow)) == false)
        {
            goto label_4;
        }
        
        var val_3 = (this.closeSelf == true) ? 1 : 0;
        if(val_1 != null)
        {
            goto label_5;
        }
        
        label_4:
        val_4 = 0;
        label_5:
        val_1.Invoke(obj:  false);
        if(this.closeSelf != false)
        {
                SLCWindow.CloseWindow(window:  this.selfWindow, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        
        this.OnButtonClick();
    }
    public ButtonWindowToggle()
    {
        var val_11;
        System.Action<System.Boolean> val_13;
        var val_14;
        System.Action<System.Boolean> val_16;
        var val_17;
        System.Action<System.Boolean> val_19;
        var val_20;
        System.Action<System.Boolean> val_22;
        var val_23;
        System.Action<System.Boolean> val_25;
        var val_26;
        System.Action<System.Boolean> val_28;
        var val_29;
        System.Action<System.Boolean> val_31;
        var val_32;
        System.Action<System.Boolean> val_34;
        var val_35;
        System.Action<System.Boolean> val_37;
        System.Collections.Generic.Dictionary<WGWindowPool, System.Action<System.Boolean>> val_1 = new System.Collections.Generic.Dictionary<WGWindowPool, System.Action<System.Boolean>>();
        val_11 = null;
        val_11 = null;
        val_13 = ButtonWindowToggle.<>c.<>9__5_0;
        if(val_13 == null)
        {
                System.Action<System.Boolean> val_2 = null;
            val_13 = val_2;
            val_2 = new System.Action<System.Boolean>(object:  ButtonWindowToggle.<>c.__il2cppRuntimeField_static_fields, method:  System.Void ButtonWindowToggle.<>c::<.ctor>b__5_0(bool forceNext));
            ButtonWindowToggle.<>c.<>9__5_0 = val_13;
        }
        
        val_1.Add(key:  0, value:  val_2);
        val_14 = null;
        val_14 = null;
        val_16 = ButtonWindowToggle.<>c.<>9__5_1;
        if(val_16 == null)
        {
                System.Action<System.Boolean> val_3 = null;
            val_16 = val_3;
            val_3 = new System.Action<System.Boolean>(object:  ButtonWindowToggle.<>c.__il2cppRuntimeField_static_fields, method:  System.Void ButtonWindowToggle.<>c::<.ctor>b__5_1(bool forceNext));
            ButtonWindowToggle.<>c.<>9__5_1 = val_16;
        }
        
        val_1.Add(key:  1, value:  val_3);
        val_17 = null;
        val_17 = null;
        val_19 = ButtonWindowToggle.<>c.<>9__5_2;
        if(val_19 == null)
        {
                System.Action<System.Boolean> val_4 = null;
            val_19 = val_4;
            val_4 = new System.Action<System.Boolean>(object:  ButtonWindowToggle.<>c.__il2cppRuntimeField_static_fields, method:  System.Void ButtonWindowToggle.<>c::<.ctor>b__5_2(bool forceNext));
            ButtonWindowToggle.<>c.<>9__5_2 = val_19;
        }
        
        val_1.Add(key:  2, value:  val_4);
        val_20 = null;
        val_20 = null;
        val_22 = ButtonWindowToggle.<>c.<>9__5_3;
        if(val_22 == null)
        {
                System.Action<System.Boolean> val_5 = null;
            val_22 = val_5;
            val_5 = new System.Action<System.Boolean>(object:  ButtonWindowToggle.<>c.__il2cppRuntimeField_static_fields, method:  System.Void ButtonWindowToggle.<>c::<.ctor>b__5_3(bool forceNext));
            ButtonWindowToggle.<>c.<>9__5_3 = val_22;
        }
        
        val_1.Add(key:  3, value:  val_5);
        val_23 = null;
        val_23 = null;
        val_25 = ButtonWindowToggle.<>c.<>9__5_4;
        if(val_25 == null)
        {
                System.Action<System.Boolean> val_6 = null;
            val_25 = val_6;
            val_6 = new System.Action<System.Boolean>(object:  ButtonWindowToggle.<>c.__il2cppRuntimeField_static_fields, method:  System.Void ButtonWindowToggle.<>c::<.ctor>b__5_4(bool forceNext));
            ButtonWindowToggle.<>c.<>9__5_4 = val_25;
        }
        
        val_1.Add(key:  4, value:  val_6);
        val_26 = null;
        val_26 = null;
        val_28 = ButtonWindowToggle.<>c.<>9__5_5;
        if(val_28 == null)
        {
                System.Action<System.Boolean> val_7 = null;
            val_28 = val_7;
            val_7 = new System.Action<System.Boolean>(object:  ButtonWindowToggle.<>c.__il2cppRuntimeField_static_fields, method:  System.Void ButtonWindowToggle.<>c::<.ctor>b__5_5(bool forceNext));
            ButtonWindowToggle.<>c.<>9__5_5 = val_28;
        }
        
        val_1.Add(key:  5, value:  val_7);
        val_29 = null;
        val_29 = null;
        val_31 = ButtonWindowToggle.<>c.<>9__5_6;
        if(val_31 == null)
        {
                System.Action<System.Boolean> val_8 = null;
            val_31 = val_8;
            val_8 = new System.Action<System.Boolean>(object:  ButtonWindowToggle.<>c.__il2cppRuntimeField_static_fields, method:  System.Void ButtonWindowToggle.<>c::<.ctor>b__5_6(bool forceNext));
            ButtonWindowToggle.<>c.<>9__5_6 = val_31;
        }
        
        val_1.Add(key:  6, value:  val_8);
        val_32 = null;
        val_32 = null;
        val_34 = ButtonWindowToggle.<>c.<>9__5_7;
        if(val_34 == null)
        {
                System.Action<System.Boolean> val_9 = null;
            val_34 = val_9;
            val_9 = new System.Action<System.Boolean>(object:  ButtonWindowToggle.<>c.__il2cppRuntimeField_static_fields, method:  System.Void ButtonWindowToggle.<>c::<.ctor>b__5_7(bool forceNext));
            ButtonWindowToggle.<>c.<>9__5_7 = val_34;
        }
        
        val_1.Add(key:  7, value:  val_9);
        val_35 = null;
        val_35 = null;
        val_37 = ButtonWindowToggle.<>c.<>9__5_8;
        if(val_37 == null)
        {
                System.Action<System.Boolean> val_10 = null;
            val_37 = val_10;
            val_10 = new System.Action<System.Boolean>(object:  ButtonWindowToggle.<>c.__il2cppRuntimeField_static_fields, method:  System.Void ButtonWindowToggle.<>c::<.ctor>b__5_8(bool forceNext));
            ButtonWindowToggle.<>c.<>9__5_8 = val_37;
        }
        
        val_1.Add(key:  8, value:  val_10);
        this.ToggleActions = val_1;
    }

}
