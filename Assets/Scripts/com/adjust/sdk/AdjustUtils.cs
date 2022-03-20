using UnityEngine;

namespace com.adjust.sdk
{
    public class AdjustUtils
    {
        // Fields
        public static string KeyAdid;
        public static string KeyMessage;
        public static string KeyNetwork;
        public static string KeyAdgroup;
        public static string KeyCampaign;
        public static string KeyCreative;
        public static string KeyWillRetry;
        public static string KeyTimestamp;
        public static string KeyCallbackId;
        public static string KeyEventToken;
        public static string KeyClickLabel;
        public static string KeyTrackerName;
        public static string KeyTrackerToken;
        public static string KeyJsonResponse;
        public static string KeyCostType;
        public static string KeyCostAmount;
        public static string KeyCostCurrency;
        public static string KeyTestOptionsBaseUrl;
        public static string KeyTestOptionsGdprUrl;
        public static string KeyTestOptionsSubscriptionUrl;
        public static string KeyTestOptionsExtraPath;
        public static string KeyTestOptionsBasePath;
        public static string KeyTestOptionsGdprPath;
        public static string KeyTestOptionsDeleteState;
        public static string KeyTestOptionsUseTestConnectionOptions;
        public static string KeyTestOptionsTimerIntervalInMilliseconds;
        public static string KeyTestOptionsTimerStartInMilliseconds;
        public static string KeyTestOptionsSessionIntervalInMilliseconds;
        public static string KeyTestOptionsSubsessionIntervalInMilliseconds;
        public static string KeyTestOptionsTeardown;
        public static string KeyTestOptionsNoBackoffWait;
        public static string KeyTestOptionsiAdFrameworkEnabled;
        public static string KeyTestOptionsAdServicesFrameworkEnabled;
        
        // Methods
        public static int ConvertLogLevel(System.Nullable<com.adjust.sdk.AdjustLogLevel> logLevel)
        {
            var val_2;
            if((logLevel.HasValue & true) == 0)
            {
                    com.adjust.sdk.AdjustLogLevel val_1 = logLevel.HasValue.Value;
                return (int)val_2;
            }
            
            val_2 = 0;
            return (int)val_2;
        }
        public static int ConvertBool(System.Nullable<bool> value)
        {
            var val_4;
            if((value.HasValue & 65535) < true)
            {
                    val_4 = 0;
                return (int)val_4;
            }
            
            val_4 = value.HasValue.Value;
            return (int)val_4;
        }
        public static double ConvertDouble(System.Nullable<double> value)
        {
            if((X1 & 255) != 0)
            {
                    return -1;
            }
            
            double val_1 = value.HasValue.Value;
            return -1;
        }
        public static long ConvertLong(System.Nullable<long> value)
        {
            var val_2;
            if((X1 & 255) == 0)
            {
                    long val_1 = value.HasValue.Value;
                return (long)val_2;
            }
            
            val_2 = 0;
            return (long)val_2;
        }
        public static string ConvertListToJson(System.Collections.Generic.List<string> list)
        {
            var val_5;
            var val_6;
            if(list == null)
            {
                goto label_1;
            }
            
            com.adjust.sdk.JSONArray val_1 = null;
            val_5 = val_1;
            val_1 = new com.adjust.sdk.JSONArray();
            List.Enumerator<T> val_2 = list.GetEnumerator();
            label_4:
            if(0.MoveNext() == false)
            {
                goto label_2;
            }
            
            .m_Data = 0;
            if(val_5 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_1.Add(aItem:  new com.adjust.sdk.JSONData());
            goto label_4;
            label_2:
            0.Dispose();
            val_6 = val_5;
            return (string)val_6;
            label_1:
            val_6 = 0;
            return (string)val_6;
        }
        public static string GetJsonResponseCompact(System.Collections.Generic.Dictionary<string, object> dictionary)
        {
            string val_3;
            var val_5;
            string val_20;
            string val_21;
            string val_22;
            string val_23;
            string val_24;
            var val_25;
            int val_26;
            int val_27;
            int val_28;
            val_20 = dictionary;
            val_21 = "";
            if(val_20 == null)
            {
                    return (string)val_20 + "}";
            }
            
            val_22 = val_21 + "{";
            Dictionary.Enumerator<TKey, TValue> val_2 = val_20.GetEnumerator();
            var val_19 = 0;
            label_50:
            if(val_5.MoveNext() == false)
            {
                goto label_2;
            }
            
            val_23 = val_3;
            if(val_23 == 0)
            {
                goto label_6;
            }
            
            if(val_23 == null)
            {
                goto label_4;
            }
            
            val_23 = 0;
            goto label_6;
            label_4:
            val_19 = val_19 + 1;
            if(val_19 >= 2)
            {
                goto label_7;
            }
            
            val_24 = val_22;
            goto label_8;
            label_6:
            val_19 = val_19 + 1;
            if(val_19 >= 2)
            {
                    val_22 = val_22 + ",";
            }
            
            string val_10 = val_22 + "\"" + val_3 + "\":"("\":")(val_22 + "\"" + val_3 + "\":"("\":")) + ;
            goto label_50;
            label_7:
            val_24 = val_22 + ",";
            label_8:
            if(((val_23.StartsWith(value:  "{")) == false) || ((val_23.EndsWith(value:  "}")) == false))
            {
                goto label_15;
            }
            
            string[] val_14 = new string[5];
            if(val_24 != null)
            {
                    if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            }
            
            val_26 = val_14.Length;
            if(val_26 == 0)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_14[0] = val_24;
            val_25 = "\"";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_26 = val_14.Length;
            if(val_26 <= 1)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_14[1] = "\"";
            if(val_3 != 0)
            {
                    if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
                val_26 = val_14.Length;
            }
            
            val_14[2] = val_3;
            val_25 = "\":";
            val_26 = val_14.Length;
            if(val_26 <= 3)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_14[3] = "\":";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            if(val_14.Length <= 4)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_14[4] = val_23;
            string val_15 = +val_14;
            goto label_50;
            label_15:
            string[] val_16 = new string[6];
            if(val_16 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_24 != null)
            {
                    if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            }
            
            val_27 = val_16.Length;
            if(val_27 == 0)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_16[0] = val_24;
            val_25 = "\"";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_27 = val_16.Length;
            if(val_27 <= 1)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_16[1] = "\"";
            if(val_3 != 0)
            {
                    if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
                val_27 = val_16.Length;
            }
            
            if(val_27 <= 2)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_16[2] = val_3;
            val_25 = "\":\"";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_27 = val_16.Length;
            if(val_27 <= 3)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_16[3] = "\":\"";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_28 = val_16.Length;
            if(val_28 <= 4)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_16[4] = val_23;
            val_25 = "\"";
            if(X0 == false)
            {
                    throw new ArrayTypeMismatchException();
            }
            
            val_28 = val_16.Length;
            if(val_28 <= 5)
            {
                    throw new IndexOutOfRangeException();
            }
            
            val_16[5] = "\"";
            string val_17 = +val_16;
            goto label_50;
            label_2:
            val_5.Dispose();
            val_20 = val_22;
            return (string)val_20 + "}";
        }
        public static string GetJsonString(com.adjust.sdk.JSONNode node, string key)
        {
            if((com.adjust.sdk.JSONNode.op_Equality(a:  node, b:  0)) == true)
            {
                    return 0;
            }
            
            key = 0;
            if((com.adjust.sdk.JSONNode.op_Equality(a:  null, b:  0)) == true)
            {
                    return 0;
            }
            
            if((com.adjust.sdk.JSONNode.op_Equality(a:  null, b:  "")) != false)
            {
                    return 0;
            }
        
        }
        public static void WriteJsonResponseDictionary(com.adjust.sdk.JSONClass jsonObject, System.Collections.Generic.Dictionary<string, object> output)
        {
            var val_7;
            var val_8;
            var val_11;
            val_7 = output;
            if(jsonObject == null)
            {
                    throw new NullReferenceException();
            }
            
            val_8 = jsonObject.GetEnumerator();
            label_22:
            var val_8 = 0;
            val_8 = val_8 + 1;
            if(val_8.MoveNext() == false)
            {
                goto label_7;
            }
            
            var val_9 = 0;
            val_9 = val_9 + 1;
            if(val_8.Current == null)
            {
                    throw new NullReferenceException();
            }
            
            if(X23 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if((com.adjust.sdk.JSONNode.op_Equality(a:  X23, b:  0)) == false)
            {
                goto label_15;
            }
            
            if(val_7 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_7.Add(key:  1152921504626761728, value:  X23);
            goto label_22;
            label_15:
            if(val_7 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_7.Add(key:  1152921504626761728, value:  new System.Collections.Generic.Dictionary<System.String, System.Object>());
            goto label_22;
            label_7:
            val_7 = 0;
            if(X0 == false)
            {
                goto label_23;
            }
            
            var val_12 = X0;
            val_8 = X0;
            if((X0 + 294) == 0)
            {
                goto label_27;
            }
            
            var val_10 = X0 + 176;
            var val_11 = 0;
            val_10 = val_10 + 8;
            label_26:
            if(((X0 + 176 + 8) + -8) == null)
            {
                goto label_25;
            }
            
            val_11 = val_11 + 1;
            val_10 = val_10 + 16;
            if(val_11 < (X0 + 294))
            {
                goto label_26;
            }
            
            goto label_27;
            label_25:
            val_12 = val_12 + (((X0 + 176 + 8)) << 4);
            val_11 = val_12 + 304;
            label_27:
            val_8.Dispose();
            label_23:
            if(val_7 != 0)
            {
                    throw val_7;
            }
        
        }
        public static string TryGetValue(System.Collections.Generic.Dictionary<string, string> dictionary, string key)
        {
            var val_5;
            string val_1 = 0;
            if((dictionary.TryGetValue(key:  key, value: out  val_1)) != false)
            {
                    var val_4 = ((System.String.op_Equality(a:  val_1, b:  "")) != true) ? 0 : (val_1);
                return (string)val_5;
            }
            
            val_5 = 0;
            return (string)val_5;
        }
        public static UnityEngine.AndroidJavaObject TestOptionsMap2AndroidJavaObject(System.Collections.Generic.Dictionary<string, string> testOptionsMap, UnityEngine.AndroidJavaObject ajoCurrentActivity)
        {
            UnityEngine.AndroidJavaObject val_53;
            var val_54;
            var val_55;
            var val_56;
            var val_57;
            var val_58;
            var val_59;
            var val_60;
            var val_61;
            var val_62;
            var val_63;
            var val_64;
            var val_65;
            var val_66;
            var val_67;
            var val_68;
            var val_69;
            var val_70;
            var val_71;
            val_53 = ajoCurrentActivity;
            val_54 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_54 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            val_54 = mem[public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302];
            val_54 = public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 302;
            UnityEngine.AndroidJavaObject val_1 = new UnityEngine.AndroidJavaObject(className:  "com.adjust.sdk.AdjustTestOptions", args:  public static T[] System.Array::Empty<System.Object>().__il2cppRuntimeField_30 + 184);
            val_1.Set<System.String>(fieldName:  "baseUrl", val:  testOptionsMap.Item[com.adjust.sdk.AdjustUtils.KeyTestOptionsBaseUrl]);
            val_1.Set<System.String>(fieldName:  "gdprUrl", val:  testOptionsMap.Item[com.adjust.sdk.AdjustUtils.KeyTestOptionsGdprUrl]);
            val_1.Set<System.String>(fieldName:  "subscriptionUrl", val:  testOptionsMap.Item[com.adjust.sdk.AdjustUtils.KeyTestOptionsSubscriptionUrl]);
            if((testOptionsMap.ContainsKey(key:  com.adjust.sdk.AdjustUtils.KeyTestOptionsExtraPath)) != false)
            {
                    val_55 = null;
                val_55 = null;
                if((System.String.IsNullOrEmpty(value:  testOptionsMap.Item[com.adjust.sdk.AdjustUtils.KeyTestOptionsExtraPath])) != true)
            {
                    val_56 = null;
                val_56 = null;
                val_1.Set<System.String>(fieldName:  "basePath", val:  testOptionsMap.Item[com.adjust.sdk.AdjustUtils.KeyTestOptionsExtraPath]);
                val_1.Set<System.String>(fieldName:  "gdprPath", val:  testOptionsMap.Item[com.adjust.sdk.AdjustUtils.KeyTestOptionsExtraPath]);
                val_1.Set<System.String>(fieldName:  "subscriptionPath", val:  testOptionsMap.Item[com.adjust.sdk.AdjustUtils.KeyTestOptionsExtraPath]);
            }
            
            }
            
            val_57 = null;
            val_57 = null;
            if((val_53 != null) && ((testOptionsMap.ContainsKey(key:  com.adjust.sdk.AdjustUtils.KeyTestOptionsDeleteState)) != false))
            {
                    val_1.Set<UnityEngine.AndroidJavaObject>(fieldName:  "context", val:  val_53);
            }
            
            val_58 = null;
            val_58 = null;
            if((testOptionsMap.ContainsKey(key:  com.adjust.sdk.AdjustUtils.KeyTestOptionsUseTestConnectionOptions)) != false)
            {
                    val_59 = null;
                val_59 = null;
                object[] val_17 = new object[1];
                val_53 = val_17;
                val_53[0] = System.String.op_Equality(a:  testOptionsMap.Item[com.adjust.sdk.AdjustUtils.KeyTestOptionsUseTestConnectionOptions].ToLower(), b:  "true");
                val_1.Set<UnityEngine.AndroidJavaObject>(fieldName:  "useTestConnectionOptions", val:  new UnityEngine.AndroidJavaObject(className:  "java.lang.Boolean", args:  val_17));
            }
            
            val_60 = null;
            val_60 = null;
            if((testOptionsMap.ContainsKey(key:  com.adjust.sdk.AdjustUtils.KeyTestOptionsTimerIntervalInMilliseconds)) != false)
            {
                    val_61 = null;
                val_61 = null;
                object[] val_22 = new object[1];
                val_53 = val_22;
                val_53[0] = System.Int64.Parse(s:  testOptionsMap.Item[com.adjust.sdk.AdjustUtils.KeyTestOptionsTimerIntervalInMilliseconds]);
                val_1.Set<UnityEngine.AndroidJavaObject>(fieldName:  "timerIntervalInMilliseconds", val:  new UnityEngine.AndroidJavaObject(className:  "java.lang.Long", args:  val_22));
            }
            
            val_62 = null;
            val_62 = null;
            if((testOptionsMap.ContainsKey(key:  com.adjust.sdk.AdjustUtils.KeyTestOptionsTimerStartInMilliseconds)) != false)
            {
                    val_63 = null;
                val_63 = null;
                object[] val_27 = new object[1];
                val_53 = val_27;
                val_53[0] = System.Int64.Parse(s:  testOptionsMap.Item[com.adjust.sdk.AdjustUtils.KeyTestOptionsTimerStartInMilliseconds]);
                val_1.Set<UnityEngine.AndroidJavaObject>(fieldName:  "timerStartInMilliseconds", val:  new UnityEngine.AndroidJavaObject(className:  "java.lang.Long", args:  val_27));
            }
            
            val_64 = null;
            val_64 = null;
            if((testOptionsMap.ContainsKey(key:  com.adjust.sdk.AdjustUtils.KeyTestOptionsSessionIntervalInMilliseconds)) != false)
            {
                    val_65 = null;
                val_65 = null;
                object[] val_32 = new object[1];
                val_53 = val_32;
                val_53[0] = System.Int64.Parse(s:  testOptionsMap.Item[com.adjust.sdk.AdjustUtils.KeyTestOptionsSessionIntervalInMilliseconds]);
                val_1.Set<UnityEngine.AndroidJavaObject>(fieldName:  "sessionIntervalInMilliseconds", val:  new UnityEngine.AndroidJavaObject(className:  "java.lang.Long", args:  val_32));
            }
            
            val_66 = null;
            val_66 = null;
            if((testOptionsMap.ContainsKey(key:  com.adjust.sdk.AdjustUtils.KeyTestOptionsSubsessionIntervalInMilliseconds)) != false)
            {
                    val_67 = null;
                val_67 = null;
                object[] val_37 = new object[1];
                val_53 = val_37;
                val_53[0] = System.Int64.Parse(s:  testOptionsMap.Item[com.adjust.sdk.AdjustUtils.KeyTestOptionsSubsessionIntervalInMilliseconds]);
                val_1.Set<UnityEngine.AndroidJavaObject>(fieldName:  "subsessionIntervalInMilliseconds", val:  new UnityEngine.AndroidJavaObject(className:  "java.lang.Long", args:  val_37));
            }
            
            val_68 = null;
            val_68 = null;
            if((testOptionsMap.ContainsKey(key:  com.adjust.sdk.AdjustUtils.KeyTestOptionsTeardown)) != false)
            {
                    val_69 = null;
                val_69 = null;
                object[] val_44 = new object[1];
                val_53 = val_44;
                val_53[0] = System.String.op_Equality(a:  testOptionsMap.Item[com.adjust.sdk.AdjustUtils.KeyTestOptionsTeardown].ToLower(), b:  "true");
                val_1.Set<UnityEngine.AndroidJavaObject>(fieldName:  "teardown", val:  new UnityEngine.AndroidJavaObject(className:  "java.lang.Boolean", args:  val_44));
            }
            
            val_70 = null;
            val_70 = null;
            if((testOptionsMap.ContainsKey(key:  com.adjust.sdk.AdjustUtils.KeyTestOptionsNoBackoffWait)) == false)
            {
                    return val_1;
            }
            
            val_71 = null;
            val_71 = null;
            object[] val_51 = new object[1];
            val_51[0] = System.String.op_Equality(a:  testOptionsMap.Item[com.adjust.sdk.AdjustUtils.KeyTestOptionsNoBackoffWait].ToLower(), b:  "true");
            UnityEngine.AndroidJavaObject val_52 = null;
            val_53 = val_52;
            val_52 = new UnityEngine.AndroidJavaObject(className:  "java.lang.Boolean", args:  val_51);
            val_1.Set<UnityEngine.AndroidJavaObject>(fieldName:  "noBackoffWait", val:  val_52);
            return val_1;
        }
        public AdjustUtils()
        {
        
        }
        private static AdjustUtils()
        {
            com.adjust.sdk.AdjustUtils.KeyAdid = "adid";
            com.adjust.sdk.AdjustUtils.KeyMessage = "message";
            com.adjust.sdk.AdjustUtils.KeyNetwork = "network";
            com.adjust.sdk.AdjustUtils.KeyAdgroup = "adgroup";
            com.adjust.sdk.AdjustUtils.KeyCampaign = "campaign";
            com.adjust.sdk.AdjustUtils.KeyCreative = "creative";
            com.adjust.sdk.AdjustUtils.KeyWillRetry = "willRetry";
            com.adjust.sdk.AdjustUtils.KeyTimestamp = "timestamp";
            com.adjust.sdk.AdjustUtils.KeyCallbackId = "callbackId";
            com.adjust.sdk.AdjustUtils.KeyEventToken = "eventToken";
            com.adjust.sdk.AdjustUtils.KeyClickLabel = "clickLabel";
            com.adjust.sdk.AdjustUtils.KeyTrackerName = "trackerName";
            com.adjust.sdk.AdjustUtils.KeyTrackerToken = "trackerToken";
            com.adjust.sdk.AdjustUtils.KeyJsonResponse = "jsonResponse";
            com.adjust.sdk.AdjustUtils.KeyCostType = "costType";
            com.adjust.sdk.AdjustUtils.KeyCostAmount = "costAmount";
            com.adjust.sdk.AdjustUtils.KeyCostCurrency = "costCurrency";
            com.adjust.sdk.AdjustUtils.KeyTestOptionsBaseUrl = "baseUrl";
            com.adjust.sdk.AdjustUtils.KeyTestOptionsGdprUrl = "gdprUrl";
            com.adjust.sdk.AdjustUtils.KeyTestOptionsSubscriptionUrl = "subscriptionUrl";
            com.adjust.sdk.AdjustUtils.KeyTestOptionsExtraPath = "extraPath";
            com.adjust.sdk.AdjustUtils.KeyTestOptionsBasePath = "basePath";
            com.adjust.sdk.AdjustUtils.KeyTestOptionsGdprPath = "gdprPath";
            com.adjust.sdk.AdjustUtils.KeyTestOptionsDeleteState = "deleteState";
            com.adjust.sdk.AdjustUtils.KeyTestOptionsUseTestConnectionOptions = "useTestConnectionOptions";
            com.adjust.sdk.AdjustUtils.KeyTestOptionsTimerIntervalInMilliseconds = "timerIntervalInMilliseconds";
            com.adjust.sdk.AdjustUtils.KeyTestOptionsTimerStartInMilliseconds = "timerStartInMilliseconds";
            com.adjust.sdk.AdjustUtils.KeyTestOptionsSessionIntervalInMilliseconds = "sessionIntervalInMilliseconds";
            com.adjust.sdk.AdjustUtils.KeyTestOptionsSubsessionIntervalInMilliseconds = "subsessionIntervalInMilliseconds";
            com.adjust.sdk.AdjustUtils.KeyTestOptionsTeardown = "teardown";
            com.adjust.sdk.AdjustUtils.KeyTestOptionsNoBackoffWait = "noBackoffWait";
            com.adjust.sdk.AdjustUtils.KeyTestOptionsiAdFrameworkEnabled = "iAdFrameworkEnabled";
            com.adjust.sdk.AdjustUtils.KeyTestOptionsAdServicesFrameworkEnabled = "adServicesFrameworkEnabled";
        }
    
    }

}
