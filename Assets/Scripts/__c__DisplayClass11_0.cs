using UnityEngine;
private sealed class AdViewBridgeAndroid.<>c__DisplayClass11_0
{
    // Fields
    public UnityEngine.AndroidJavaObject activity;
    public double width;
    public double height;
    public UnityEngine.AndroidJavaObject adView;
    public double x;
    public double y;
    
    // Methods
    public AdViewBridgeAndroid.<>c__DisplayClass11_0()
    {
    
    }
    internal void <Show>b__0()
    {
        var val_29;
        var val_30;
        var val_31;
        var val_32;
        UnityEngine.AndroidJavaObject val_33;
        var val_34;
        val_29 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_29 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_29 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_29 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_30 = 1152921509994827216;
        val_31 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_31 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_31 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_31 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_32 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_32 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_32 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_32 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        object[] val_5 = new object[2];
        double val_29 = this.width;
        double val_6 = val_29 * ((double)this.activity.Call<UnityEngine.AndroidJavaObject>(methodName:  "getApplicationContext", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184).Call<UnityEngine.AndroidJavaObject>(methodName:  "getResources", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184).Call<UnityEngine.AndroidJavaObject>(methodName:  "getDisplayMetrics", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184).Get<System.Single>(fieldName:  "density"));
        val_29 = -(val_29 * ((double)this.activity.Call<UnityEngine.AndroidJavaObject>(methodName:  "getApplicationContext", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184).Call<UnityEngine.AndroidJavaObject>(methodName:  "getResources", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184).Call<UnityEngine.AndroidJavaObject>(methodName:  "getDisplayMetrics", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184).Get<System.Single>(fieldName:  "density")));
        val_5[0] = (int)(val_6 == Infinity) ? (val_29) : (val_6);
        double val_30 = this.height;
        double val_8 = val_30 * ((double)this.activity.Call<UnityEngine.AndroidJavaObject>(methodName:  "getApplicationContext", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184).Call<UnityEngine.AndroidJavaObject>(methodName:  "getResources", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184).Call<UnityEngine.AndroidJavaObject>(methodName:  "getDisplayMetrics", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184).Get<System.Single>(fieldName:  "density"));
        val_30 = -(val_30 * ((double)this.activity.Call<UnityEngine.AndroidJavaObject>(methodName:  "getApplicationContext", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184).Call<UnityEngine.AndroidJavaObject>(methodName:  "getResources", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184).Call<UnityEngine.AndroidJavaObject>(methodName:  "getDisplayMetrics", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184).Get<System.Single>(fieldName:  "density")));
        val_5[1] = (int)(val_8 == Infinity) ? (val_30) : (val_8);
        UnityEngine.AndroidJavaObject val_10 = new UnityEngine.AndroidJavaObject(className:  "android.widget.LinearLayout$LayoutParams", args:  val_5);
        object[] val_11 = new object[1];
        val_11[0] = this.activity;
        UnityEngine.AndroidJavaObject val_12 = new UnityEngine.AndroidJavaObject(className:  "android.widget.LinearLayout", args:  val_11);
        object[] val_14 = new object[1];
        val_14[0] = new UnityEngine.AndroidJavaClass(className:  "android.R$id").GetStatic<System.Int32>(fieldName:  "content");
        val_33 = public static T[] System.Array::Empty<System.Object>();
        val_34 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_34 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        val_34 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
        val_34 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
        UnityEngine.AndroidJavaObject val_17 = this.adView.Call<UnityEngine.AndroidJavaObject>(methodName:  "getParent", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        if(val_17 != null)
        {
                val_30 = "removeView";
            if((System.IntPtr.op_Inequality(value1:  UnityEngine.AndroidJNI.GetMethodID(clazz:  val_17.GetRawClass(), name:  "removeView", sig:  "(Landroid/view/View;)V"), value2:  0)) != false)
        {
                object[] val_21 = new object[1];
            val_33 = this.adView;
            val_21[0] = val_33;
            val_17.Call(methodName:  "removeView", args:  val_21);
        }
        else
        {
                UnityEngine.AndroidJNI.ExceptionClear();
        }
        
        }
        
        object[] val_22 = new object[4];
        double val_31 = this.x;
        double val_23 = val_31 * ((double)this.activity.Call<UnityEngine.AndroidJavaObject>(methodName:  "getApplicationContext", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184).Call<UnityEngine.AndroidJavaObject>(methodName:  "getResources", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184).Call<UnityEngine.AndroidJavaObject>(methodName:  "getDisplayMetrics", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184).Get<System.Single>(fieldName:  "density"));
        val_31 = -(val_31 * ((double)this.activity.Call<UnityEngine.AndroidJavaObject>(methodName:  "getApplicationContext", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184).Call<UnityEngine.AndroidJavaObject>(methodName:  "getResources", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184).Call<UnityEngine.AndroidJavaObject>(methodName:  "getDisplayMetrics", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184).Get<System.Single>(fieldName:  "density")));
        val_22[0] = (int)(val_23 == Infinity) ? (val_31) : (val_23);
        double val_32 = this.y;
        double val_25 = val_32 * ((double)this.activity.Call<UnityEngine.AndroidJavaObject>(methodName:  "getApplicationContext", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184).Call<UnityEngine.AndroidJavaObject>(methodName:  "getResources", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184).Call<UnityEngine.AndroidJavaObject>(methodName:  "getDisplayMetrics", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184).Get<System.Single>(fieldName:  "density"));
        val_32 = -(val_32 * ((double)this.activity.Call<UnityEngine.AndroidJavaObject>(methodName:  "getApplicationContext", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184).Call<UnityEngine.AndroidJavaObject>(methodName:  "getResources", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184).Call<UnityEngine.AndroidJavaObject>(methodName:  "getDisplayMetrics", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184).Get<System.Single>(fieldName:  "density")));
        val_22[1] = (int)(val_25 == Infinity) ? (val_32) : (val_25);
        val_22[2] = 0;
        val_22[3] = 0;
        val_10.Call(methodName:  "setMargins", args:  val_22);
        object[] val_27 = new object[2];
        val_27[0] = this.adView;
        val_27[1] = val_10;
        val_12.Call(methodName:  "addView", args:  val_27);
        object[] val_28 = new object[1];
        val_28[0] = val_12;
        this.activity.Call<UnityEngine.AndroidJavaObject>(methodName:  "findViewById", args:  val_14).Call(methodName:  "addView", args:  val_28);
    }

}
