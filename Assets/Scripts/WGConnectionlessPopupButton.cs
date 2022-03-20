using UnityEngine;
public class WGConnectionlessPopupButton : MyButton
{
    // Fields
    private System.Collections.Generic.Dictionary<WGConnectionlessType, System.Action> ConnectionlessPopupActions;
    public WGConnectionlessType ConnectionlessType;
    
    // Methods
    public override void OnButtonClick()
    {
        this.ConnectionlessPopupActions.Item[this.ConnectionlessType].Invoke();
        this.OnButtonClick();
    }
    public static bool EmptyDub()
    {
        return true;
    }
    public WGConnectionlessPopupButton()
    {
        var val_23;
        System.Action val_25;
        var val_26;
        System.Action val_28;
        var val_29;
        System.Action val_31;
        var val_32;
        System.Action val_34;
        var val_35;
        System.Action val_37;
        var val_38;
        System.Action val_40;
        var val_41;
        System.Action val_43;
        var val_44;
        System.Action val_46;
        var val_47;
        System.Action val_49;
        var val_50;
        System.Action val_52;
        var val_53;
        System.Action val_55;
        var val_56;
        System.Action val_58;
        var val_59;
        System.Action val_61;
        var val_62;
        System.Action val_64;
        var val_65;
        System.Action val_67;
        var val_68;
        System.Action val_70;
        var val_71;
        System.Action val_73;
        var val_74;
        System.Action val_76;
        var val_77;
        System.Action val_79;
        var val_80;
        System.Action val_82;
        var val_83;
        System.Action val_85;
        System.Collections.Generic.Dictionary<WGConnectionlessType, System.Action> val_1 = new System.Collections.Generic.Dictionary<WGConnectionlessType, System.Action>();
        val_23 = null;
        val_23 = null;
        val_25 = WGConnectionlessPopupButton.<>c.<>9__4_0;
        if(val_25 == null)
        {
                System.Action val_2 = null;
            val_25 = val_2;
            val_2 = new System.Action(object:  WGConnectionlessPopupButton.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGConnectionlessPopupButton.<>c::<.ctor>b__4_0());
            WGConnectionlessPopupButton.<>c.<>9__4_0 = val_25;
        }
        
        val_1.Add(key:  0, value:  val_2);
        val_26 = null;
        val_26 = null;
        val_28 = WGConnectionlessPopupButton.<>c.<>9__4_1;
        if(val_28 == null)
        {
                System.Action val_3 = null;
            val_28 = val_3;
            val_3 = new System.Action(object:  WGConnectionlessPopupButton.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGConnectionlessPopupButton.<>c::<.ctor>b__4_1());
            WGConnectionlessPopupButton.<>c.<>9__4_1 = val_28;
        }
        
        val_1.Add(key:  8, value:  val_3);
        val_29 = null;
        val_29 = null;
        val_31 = WGConnectionlessPopupButton.<>c.<>9__4_2;
        if(val_31 == null)
        {
                System.Action val_4 = null;
            val_31 = val_4;
            val_4 = new System.Action(object:  WGConnectionlessPopupButton.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGConnectionlessPopupButton.<>c::<.ctor>b__4_2());
            WGConnectionlessPopupButton.<>c.<>9__4_2 = val_31;
        }
        
        val_1.Add(key:  1, value:  val_4);
        val_32 = null;
        val_32 = null;
        val_34 = WGConnectionlessPopupButton.<>c.<>9__4_3;
        if(val_34 == null)
        {
                System.Action val_5 = null;
            val_34 = val_5;
            val_5 = new System.Action(object:  WGConnectionlessPopupButton.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGConnectionlessPopupButton.<>c::<.ctor>b__4_3());
            WGConnectionlessPopupButton.<>c.<>9__4_3 = val_34;
        }
        
        val_1.Add(key:  19, value:  val_5);
        val_35 = null;
        val_35 = null;
        val_37 = WGConnectionlessPopupButton.<>c.<>9__4_4;
        if(val_37 == null)
        {
                System.Action val_6 = null;
            val_37 = val_6;
            val_6 = new System.Action(object:  WGConnectionlessPopupButton.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGConnectionlessPopupButton.<>c::<.ctor>b__4_4());
            WGConnectionlessPopupButton.<>c.<>9__4_4 = val_37;
        }
        
        val_1.Add(key:  17, value:  val_6);
        val_38 = null;
        val_38 = null;
        val_40 = WGConnectionlessPopupButton.<>c.<>9__4_5;
        if(val_40 == null)
        {
                System.Action val_7 = null;
            val_40 = val_7;
            val_7 = new System.Action(object:  WGConnectionlessPopupButton.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGConnectionlessPopupButton.<>c::<.ctor>b__4_5());
            WGConnectionlessPopupButton.<>c.<>9__4_5 = val_40;
        }
        
        val_1.Add(key:  2, value:  val_7);
        val_41 = null;
        val_41 = null;
        val_43 = WGConnectionlessPopupButton.<>c.<>9__4_6;
        if(val_43 == null)
        {
                System.Action val_8 = null;
            val_43 = val_8;
            val_8 = new System.Action(object:  WGConnectionlessPopupButton.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGConnectionlessPopupButton.<>c::<.ctor>b__4_6());
            WGConnectionlessPopupButton.<>c.<>9__4_6 = val_43;
        }
        
        val_1.Add(key:  15, value:  val_8);
        val_44 = null;
        val_44 = null;
        val_46 = WGConnectionlessPopupButton.<>c.<>9__4_7;
        if(val_46 == null)
        {
                System.Action val_9 = null;
            val_46 = val_9;
            val_9 = new System.Action(object:  WGConnectionlessPopupButton.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGConnectionlessPopupButton.<>c::<.ctor>b__4_7());
            WGConnectionlessPopupButton.<>c.<>9__4_7 = val_46;
        }
        
        val_1.Add(key:  3, value:  val_9);
        val_47 = null;
        val_47 = null;
        val_49 = WGConnectionlessPopupButton.<>c.<>9__4_8;
        if(val_49 == null)
        {
                System.Action val_10 = null;
            val_49 = val_10;
            val_10 = new System.Action(object:  WGConnectionlessPopupButton.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGConnectionlessPopupButton.<>c::<.ctor>b__4_8());
            WGConnectionlessPopupButton.<>c.<>9__4_8 = val_49;
        }
        
        val_1.Add(key:  4, value:  val_10);
        val_50 = null;
        val_50 = null;
        val_52 = WGConnectionlessPopupButton.<>c.<>9__4_9;
        if(val_52 == null)
        {
                System.Action val_11 = null;
            val_52 = val_11;
            val_11 = new System.Action(object:  WGConnectionlessPopupButton.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGConnectionlessPopupButton.<>c::<.ctor>b__4_9());
            WGConnectionlessPopupButton.<>c.<>9__4_9 = val_52;
        }
        
        val_1.Add(key:  5, value:  val_11);
        val_53 = null;
        val_53 = null;
        val_55 = WGConnectionlessPopupButton.<>c.<>9__4_10;
        if(val_55 == null)
        {
                System.Action val_12 = null;
            val_55 = val_12;
            val_12 = new System.Action(object:  WGConnectionlessPopupButton.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGConnectionlessPopupButton.<>c::<.ctor>b__4_10());
            WGConnectionlessPopupButton.<>c.<>9__4_10 = val_55;
        }
        
        val_1.Add(key:  6, value:  val_12);
        val_56 = null;
        val_56 = null;
        val_58 = WGConnectionlessPopupButton.<>c.<>9__4_11;
        if(val_58 == null)
        {
                System.Action val_13 = null;
            val_58 = val_13;
            val_13 = new System.Action(object:  WGConnectionlessPopupButton.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGConnectionlessPopupButton.<>c::<.ctor>b__4_11());
            WGConnectionlessPopupButton.<>c.<>9__4_11 = val_58;
        }
        
        val_1.Add(key:  21, value:  val_13);
        val_59 = null;
        val_59 = null;
        val_61 = WGConnectionlessPopupButton.<>c.<>9__4_12;
        if(val_61 == null)
        {
                System.Action val_14 = null;
            val_61 = val_14;
            val_14 = new System.Action(object:  WGConnectionlessPopupButton.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGConnectionlessPopupButton.<>c::<.ctor>b__4_12());
            WGConnectionlessPopupButton.<>c.<>9__4_12 = val_61;
        }
        
        val_1.Add(key:  7, value:  val_14);
        val_62 = null;
        val_62 = null;
        val_64 = WGConnectionlessPopupButton.<>c.<>9__4_13;
        if(val_64 == null)
        {
                System.Action val_15 = null;
            val_64 = val_15;
            val_15 = new System.Action(object:  WGConnectionlessPopupButton.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGConnectionlessPopupButton.<>c::<.ctor>b__4_13());
            WGConnectionlessPopupButton.<>c.<>9__4_13 = val_64;
        }
        
        val_1.Add(key:  9, value:  val_15);
        val_65 = null;
        val_65 = null;
        val_67 = WGConnectionlessPopupButton.<>c.<>9__4_14;
        if(val_67 == null)
        {
                System.Action val_16 = null;
            val_67 = val_16;
            val_16 = new System.Action(object:  WGConnectionlessPopupButton.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGConnectionlessPopupButton.<>c::<.ctor>b__4_14());
            WGConnectionlessPopupButton.<>c.<>9__4_14 = val_67;
        }
        
        val_1.Add(key:  11, value:  val_16);
        val_68 = null;
        val_68 = null;
        val_70 = WGConnectionlessPopupButton.<>c.<>9__4_15;
        if(val_70 == null)
        {
                System.Action val_17 = null;
            val_70 = val_17;
            val_17 = new System.Action(object:  WGConnectionlessPopupButton.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGConnectionlessPopupButton.<>c::<.ctor>b__4_15());
            WGConnectionlessPopupButton.<>c.<>9__4_15 = val_70;
        }
        
        val_1.Add(key:  12, value:  val_17);
        val_71 = null;
        val_71 = null;
        val_73 = WGConnectionlessPopupButton.<>c.<>9__4_16;
        if(val_73 == null)
        {
                System.Action val_18 = null;
            val_73 = val_18;
            val_18 = new System.Action(object:  WGConnectionlessPopupButton.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGConnectionlessPopupButton.<>c::<.ctor>b__4_16());
            WGConnectionlessPopupButton.<>c.<>9__4_16 = val_73;
        }
        
        val_1.Add(key:  13, value:  val_18);
        val_74 = null;
        val_74 = null;
        val_76 = WGConnectionlessPopupButton.<>c.<>9__4_17;
        if(val_76 == null)
        {
                System.Action val_19 = null;
            val_76 = val_19;
            val_19 = new System.Action(object:  WGConnectionlessPopupButton.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGConnectionlessPopupButton.<>c::<.ctor>b__4_17());
            WGConnectionlessPopupButton.<>c.<>9__4_17 = val_76;
        }
        
        val_1.Add(key:  14, value:  val_19);
        val_77 = null;
        val_77 = null;
        val_79 = WGConnectionlessPopupButton.<>c.<>9__4_18;
        if(val_79 == null)
        {
                System.Action val_20 = null;
            val_79 = val_20;
            val_20 = new System.Action(object:  WGConnectionlessPopupButton.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGConnectionlessPopupButton.<>c::<.ctor>b__4_18());
            WGConnectionlessPopupButton.<>c.<>9__4_18 = val_79;
        }
        
        val_1.Add(key:  16, value:  val_20);
        val_80 = null;
        val_80 = null;
        val_82 = WGConnectionlessPopupButton.<>c.<>9__4_19;
        if(val_82 == null)
        {
                System.Action val_21 = null;
            val_82 = val_21;
            val_21 = new System.Action(object:  WGConnectionlessPopupButton.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGConnectionlessPopupButton.<>c::<.ctor>b__4_19());
            WGConnectionlessPopupButton.<>c.<>9__4_19 = val_82;
        }
        
        val_1.Add(key:  18, value:  val_21);
        val_83 = null;
        val_83 = null;
        val_85 = WGConnectionlessPopupButton.<>c.<>9__4_20;
        if(val_85 == null)
        {
                System.Action val_22 = null;
            val_85 = val_22;
            val_22 = new System.Action(object:  WGConnectionlessPopupButton.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGConnectionlessPopupButton.<>c::<.ctor>b__4_20());
            WGConnectionlessPopupButton.<>c.<>9__4_20 = val_85;
        }
        
        val_1.Add(key:  20, value:  val_22);
        this.ConnectionlessPopupActions = val_1;
    }

}
