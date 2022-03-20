using UnityEngine;

namespace AudienceNetwork
{
    [Serializable]
    public class ExtraHints
    {
        // Fields
        private const int KEYWORDS_MAX_COUNT = 5;
        public System.Collections.Generic.List<string> keywords;
        public string extraData;
        public string contentURL;
        
        // Methods
        internal UnityEngine.AndroidJavaObject GetAndroidObject()
        {
            string val_6;
            var val_7;
            AudienceNetwork.ExtraHints val_22;
            var val_23;
            UnityEngine.AndroidJavaObject val_24;
            System.Object[] val_25;
            UnityEngine.AndroidJavaObject val_26;
            var val_27;
            System.Collections.Generic.List<System.String> val_28;
            var val_29;
            var val_30;
            var val_31;
            UnityEngine.AndroidJavaObject val_32;
            var val_33;
            val_22 = this;
            val_23 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_23 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_23 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_23 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_24 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30];
            val_24 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30;
            val_25 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184];
            val_25 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184;
            UnityEngine.AndroidJavaObject val_1 = null;
            val_26 = val_1;
            val_1 = new UnityEngine.AndroidJavaObject(className:  "com.facebook.ads.ExtraHints$Builder", args:  val_25);
            if(val_26 == null)
            {
                goto label_54;
            }
            
            if(this.keywords == null)
            {
                goto label_8;
            }
            
            UnityEngine.AndroidJavaClass val_2 = new UnityEngine.AndroidJavaClass(className:  "com.facebook.ads.ExtraHints$Keyword");
            val_24 = public static T[] System.Array::Empty<System.Object>();
            val_27 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_27 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_27 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_27 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_28 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30;
            if(val_2 == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.AndroidJavaObject[] val_3 = val_2.CallStatic<UnityEngine.AndroidJavaObject[]>(methodName:  "values", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            val_24 = public static T[] System.Array::Empty<System.Object>();
            val_29 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_29 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_29 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_29 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            UnityEngine.AndroidJavaObject val_4 = new UnityEngine.AndroidJavaObject(className:  "java.util.ArrayList", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            val_28 = this.keywords;
            if(val_28 == null)
            {
                    throw new NullReferenceException();
            }
            
            List.Enumerator<T> val_5 = val_28.GetEnumerator();
            val_30 = 1152921513250978752;
            val_25 = 1152921509994974672;
            goto label_26;
            label_43:
            if(0 == 5)
            {
                goto label_24;
            }
            
            if(val_3 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_3.Length < 1)
            {
                goto label_26;
            }
            
            val_24 = 0;
            label_37:
            if(val_24 >= val_3.Length)
            {
                    throw new IndexOutOfRangeException();
            }
            
            UnityEngine.AndroidJavaObject val_21 = val_3[val_24];
            val_31 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_31 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_31 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_31 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_28 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30;
            if(val_21 == null)
            {
                    throw new NullReferenceException();
            }
            
            string val_8 = val_21.Call<System.String>(methodName:  "toString", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            if(val_8 == null)
            {
                    throw new NullReferenceException();
            }
            
            if((System.String.op_Equality(a:  val_8.ToLower(), b:  val_6)) == true)
            {
                goto label_36;
            }
            
            val_24 = val_24 + 1;
            if(val_24 < val_3.Length)
            {
                goto label_37;
            }
            
            goto label_38;
            label_36:
            object[] val_11 = new object[1];
            if(val_11 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_28 = val_4;
            if(val_11.Length == 0)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_11[0] = val_21;
            bool val_12 = val_4.Call<System.Boolean>(methodName:  "add", args:  val_11);
            label_38:
            val_30 = 1152921513250978752;
            label_26:
            if(val_7.MoveNext() == true)
            {
                goto label_43;
            }
            
            label_24:
            val_7.Dispose();
            val_22 = val_22;
            val_24 = val_26;
            object[] val_14 = new object[1];
            if(val_14 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_32 = val_4;
            if(val_32 != 0)
            {
                    val_32 = val_4;
            }
            
            val_14[0] = val_32;
            val_26 = val_1.Call<UnityEngine.AndroidJavaObject>(methodName:  "keywords", args:  val_14);
            label_8:
            if(mem[1152921520230445928] != 0)
            {
                    object[] val_16 = new object[1];
                if(val_16 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_25 = val_16;
                val_25[0] = mem[1152921520230445928];
                if(val_26 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_26 = val_26.Call<UnityEngine.AndroidJavaObject>(methodName:  "extraData", args:  val_16);
            }
            
            if(mem[1152921520230445936] != 0)
            {
                    object[] val_18 = new object[1];
                if(val_18 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_25 = val_18;
                val_25[0] = mem[1152921520230445936];
                if(val_26 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_26 = val_26.Call<UnityEngine.AndroidJavaObject>(methodName:  "contentUrl", args:  val_18);
            }
            
            label_54:
            val_24 = public static T[] System.Array::Empty<System.Object>();
            val_33 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_33 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_33 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_33 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_28 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30;
            if(val_26 == null)
            {
                    throw new NullReferenceException();
            }
            
            return (UnityEngine.AndroidJavaObject)val_26.Call<UnityEngine.AndroidJavaObject>(methodName:  "build", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
        }
        public ExtraHints()
        {
        
        }
    
    }

}
