using UnityEngine;

namespace SRDebugger.Services.Implementation
{
    public class StandardSystemInformationService : ISystemInformationService
    {
        // Fields
        private readonly System.Collections.Generic.Dictionary<string, System.Collections.Generic.IList<SRDebugger.InfoEntry>> _info;
        
        // Methods
        public StandardSystemInformationService()
        {
            this._info = new System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.IList<SRDebugger.InfoEntry>>();
            this.CreateDefaultSet();
        }
        public System.Collections.Generic.IEnumerable<string> GetCategories()
        {
            return this._info.Keys;
        }
        public System.Collections.Generic.IList<SRDebugger.InfoEntry> GetInfo(string category)
        {
            string val_6;
            var val_7;
            val_6 = category;
            System.Collections.Generic.IList<SRDebugger.InfoEntry> val_1 = 0;
            if((this._info.TryGetValue(key:  val_6, value: out  val_1)) != false)
            {
                    val_7 = val_1;
                return (System.Collections.Generic.IList<SRDebugger.InfoEntry>)new SRDebugger.InfoEntry[0];
            }
            
            object[] val_3 = new object[1];
            val_3[0] = val_6;
            val_6 = SRF.SRFStringExtensions.Fmt(formatString:  "[SystemInformationService] Category not found: {0}", args:  val_3);
            UnityEngine.Debug.LogError(message:  val_6);
            return (System.Collections.Generic.IList<SRDebugger.InfoEntry>)new SRDebugger.InfoEntry[0];
        }
        public void Add(SRDebugger.InfoEntry info, string category = "Default")
        {
            var val_10;
            var val_11;
            .info = info;
            if((this._info.TryGetValue(key:  category, value: out  0)) != true)
            {
                    System.Collections.Generic.List<SRDebugger.InfoEntry> val_4 = new System.Collections.Generic.List<SRDebugger.InfoEntry>();
                this._info.Add(key:  category, value:  val_4);
            }
            
            val_10 = public static System.Boolean System.Linq.Enumerable::Any<SRDebugger.InfoEntry>(System.Collections.Generic.IEnumerable<TSource> source, System.Func<TSource, bool> predicate);
            if((System.Linq.Enumerable.Any<SRDebugger.InfoEntry>(source:  val_4, predicate:  new System.Func<SRDebugger.InfoEntry, System.Boolean>(object:  new StandardSystemInformationService.<>c__DisplayClass4_0(), method:  System.Boolean StandardSystemInformationService.<>c__DisplayClass4_0::<Add>b__0(SRDebugger.InfoEntry p)))) == true)
            {
                    throw new System.ArgumentException(message:  "An InfoEntry object with the same title already exists in that category.", paramName:  "info");
            }
            
            System.Collections.Generic.List<T> val_11 = val_4;
            if((public System.Void System.Func<SRDebugger.InfoEntry, System.Boolean>::.ctor(object object, IntPtr method)) == 0)
            {
                goto label_7;
            }
            
            var val_9 = 0;
            var val_7 = X11 + 8;
            label_9:
            if(((X11 + 8) + -8) == null)
            {
                goto label_8;
            }
            
            val_9 = val_9 + 1;
            val_7 = val_7 + 16;
            if(val_9 < 1152921519574293600)
            {
                goto label_9;
            }
            
            label_7:
            val_10 = 2;
            goto label_10;
            label_8:
            var val_10 = val_7;
            val_10 = val_10 + 2;
            val_11 = val_11 + val_10;
            val_11 = val_11 + 304;
            label_10:
            val_4.Add(item:  null);
        }
        public System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<string, object>> CreateReport(bool includePrivate = False)
        {
            string val_3;
            var val_5;
            var val_14;
            string val_17;
            System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.Dictionary<System.String, System.Object>>();
            Dictionary.Enumerator<TKey, TValue> val_2 = this._info.GetEnumerator();
            var val_23 = 0;
            label_31:
            if(val_5.MoveNext() == false)
            {
                goto label_2;
            }
            
            System.Collections.Generic.Dictionary<System.String, System.Object> val_7 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            if(val_3 == 0)
            {
                    throw new NullReferenceException();
            }
            
            var val_20 = val_3;
            if((val_3 + 294) == 0)
            {
                goto label_7;
            }
            
            var val_18 = val_3 + 176;
            var val_19 = 0;
            val_18 = val_18 + 8;
            label_6:
            if(((val_3 + 176 + 8) + -8) == null)
            {
                goto label_5;
            }
            
            val_19 = val_19 + 1;
            val_18 = val_18 + 16;
            if(val_19 < (val_3 + 294))
            {
                goto label_6;
            }
            
            goto label_7;
            label_5:
            val_20 = val_20 + (((val_3 + 176 + 8)) << 4);
            val_14 = val_20 + 304;
            label_7:
            System.Collections.Generic.IEnumerator<T> val_8 = val_3.GetEnumerator();
            if(val_8 == null)
            {
                    throw new NullReferenceException();
            }
            
            label_22:
            var val_21 = 0;
            val_21 = val_21 + 1;
            if(val_8.MoveNext() == false)
            {
                goto label_13;
            }
            
            var val_22 = 0;
            val_22 = val_22 + 1;
            T val_12 = val_8.Current;
            if(val_12 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if((val_12 + 24) != 0)
            {
                    if(includePrivate == false)
            {
                goto label_22;
            }
            
            }
            
            val_17 = mem[val_12 + 16];
            val_17 = val_12 + 16;
            if(val_7 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_7.Add(key:  val_17, value:  val_12.Value);
            goto label_22;
            label_13:
            val_17 = 0;
            val_23 = val_23 + 1;
            mem2[0] = 114;
            if(val_8 != null)
            {
                    var val_24 = 0;
                val_24 = val_24 + 1;
                val_8.Dispose();
            }
            
            if(val_17 != 0)
            {
                    throw val_17;
            }
            
            if(val_23 != 1)
            {
                    var val_15 = ((2082736512 + ((0 + 1)) << 2) == 114) ? 1 : 0;
                val_15 = ((val_23 >= 0) ? 1 : 0) & val_15;
                val_23 = val_23 - val_15;
            }
            
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_1.Add(key:  val_3, value:  val_7);
            goto label_31;
            label_2:
            var val_17 = val_23 + 1;
            mem2[0] = 153;
            val_5.Dispose();
            return val_1;
        }
        private void CreateDefaultSet()
        {
            string val_65;
            System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.IList<SRDebugger.InfoEntry>> val_128;
            object val_129;
            var val_130;
            System.Func<System.Object> val_132;
            var val_133;
            System.Func<System.Object> val_135;
            var val_136;
            System.Func<System.Object> val_138;
            var val_139;
            System.Func<System.Object> val_141;
            var val_142;
            System.Func<System.Object> val_144;
            var val_145;
            System.Func<System.Object> val_147;
            var val_148;
            System.Func<System.Object> val_150;
            var val_151;
            System.Func<System.Object> val_153;
            object val_154;
            val_128 = this._info;
            SRDebugger.InfoEntry[] val_1 = new SRDebugger.InfoEntry[7];
            val_129 = UnityEngine.SystemInfo.operatingSystem;
            if(val_1 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_1[0] = SRDebugger.InfoEntry.Create(name:  "Operating System", value:  val_129, isPrivate:  false);
            val_1[1] = SRDebugger.InfoEntry.Create(name:  "Device Name", value:  UnityEngine.SystemInfo.deviceName, isPrivate:  true);
            val_1[2] = SRDebugger.InfoEntry.Create(name:  "Device Type", value:  UnityEngine.SystemInfo.deviceType, isPrivate:  false);
            val_1[3] = SRDebugger.InfoEntry.Create(name:  "Device Model", value:  UnityEngine.SystemInfo.deviceModel, isPrivate:  false);
            val_1[4] = SRDebugger.InfoEntry.Create(name:  "CPU Type", value:  UnityEngine.SystemInfo.processorType, isPrivate:  false);
            val_1[5] = SRDebugger.InfoEntry.Create(name:  "CPU Count", value:  UnityEngine.SystemInfo.processorCount, isPrivate:  false);
            val_129 = SRFileUtil.GetBytesReadable(i:  UnityEngine.SystemInfo.systemMemorySize);
            val_1[6] = SRDebugger.InfoEntry.Create(name:  "System Memory", value:  val_129, isPrivate:  false);
            if(val_128 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_128.Add(key:  "System", value:  val_1);
            val_128 = this._info;
            SRDebugger.InfoEntry[] val_17 = new SRDebugger.InfoEntry[8];
            val_129 = UnityEngine.Application.unityVersion;
            if(val_17 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_17[0] = SRDebugger.InfoEntry.Create(name:  "Version", value:  val_129, isPrivate:  false);
            val_17[1] = SRDebugger.InfoEntry.Create(name:  "Debug", value:  UnityEngine.Debug.isDebugBuild, isPrivate:  false);
            val_17[2] = SRDebugger.InfoEntry.Create(name:  "Unity Pro", value:  UnityEngine.Application.HasProLicense(), isPrivate:  false);
            val_129 = 2;
            object[] val_26 = new object[2];
            if(val_26 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_26[0] = (UnityEngine.Application.genuine != true) ? "Yes" : "No";
            val_26[1] = (UnityEngine.Application.genuineCheckAvailable != true) ? "Trusted" : "Untrusted";
            val_17[3] = SRDebugger.InfoEntry.Create(name:  "Genuine", value:  SRF.SRFStringExtensions.Fmt(formatString:  "{0} ({1})", args:  val_26), isPrivate:  false);
            UnityEngine.SystemLanguage val_33 = UnityEngine.Application.systemLanguage;
            val_17[4] = SRDebugger.InfoEntry.Create(name:  "System Language", value:  val_33, isPrivate:  false);
            val_17[5] = SRDebugger.InfoEntry.Create(name:  "Platform", value:  UnityEngine.Application.platform, isPrivate:  false);
            val_17[6] = SRDebugger.InfoEntry.Create(name:  "IL2CPP", value:  "Yes", isPrivate:  false);
            val_129 = "1.6.0";
            val_17[7] = SRDebugger.InfoEntry.Create(name:  "SRDebugger Version", value:  val_129, isPrivate:  false);
            if(val_128 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_128.Add(key:  "Unity", value:  val_17);
            val_128 = this._info;
            SRDebugger.InfoEntry[] val_39 = new SRDebugger.InfoEntry[4];
            val_130 = null;
            val_130 = null;
            val_132 = StandardSystemInformationService.<>c.<>9__6_0;
            if(val_132 == null)
            {
                    System.Func<System.Object> val_40 = null;
                val_132 = val_40;
                val_40 = new System.Func<System.Object>(object:  StandardSystemInformationService.<>c.__il2cppRuntimeField_static_fields, method:  System.Object StandardSystemInformationService.<>c::<CreateDefaultSet>b__6_0());
                StandardSystemInformationService.<>c.<>9__6_0 = val_132;
            }
            
            val_129 = val_132;
            if(val_39 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_39[0] = SRDebugger.InfoEntry.Create(name:  "Resolution", getter:  val_40, isPrivate:  false);
            val_133 = null;
            val_133 = null;
            val_135 = StandardSystemInformationService.<>c.<>9__6_1;
            if(val_135 == null)
            {
                    System.Func<System.Object> val_42 = null;
                val_135 = val_42;
                val_42 = new System.Func<System.Object>(object:  StandardSystemInformationService.<>c.__il2cppRuntimeField_static_fields, method:  System.Object StandardSystemInformationService.<>c::<CreateDefaultSet>b__6_1());
                StandardSystemInformationService.<>c.<>9__6_1 = val_135;
            }
            
            val_39[1] = SRDebugger.InfoEntry.Create(name:  "DPI", getter:  val_42, isPrivate:  false);
            val_136 = null;
            val_136 = null;
            val_138 = StandardSystemInformationService.<>c.<>9__6_2;
            if(val_138 == null)
            {
                    System.Func<System.Object> val_44 = null;
                val_138 = val_44;
                val_44 = new System.Func<System.Object>(object:  StandardSystemInformationService.<>c.__il2cppRuntimeField_static_fields, method:  System.Object StandardSystemInformationService.<>c::<CreateDefaultSet>b__6_2());
                StandardSystemInformationService.<>c.<>9__6_2 = val_138;
            }
            
            val_39[2] = SRDebugger.InfoEntry.Create(name:  "Fullscreen", getter:  val_44, isPrivate:  false);
            val_139 = null;
            val_139 = null;
            val_141 = StandardSystemInformationService.<>c.<>9__6_3;
            if(val_141 == null)
            {
                    System.Func<System.Object> val_46 = null;
                val_141 = val_46;
                val_46 = new System.Func<System.Object>(object:  StandardSystemInformationService.<>c.__il2cppRuntimeField_static_fields, method:  System.Object StandardSystemInformationService.<>c::<CreateDefaultSet>b__6_3());
                StandardSystemInformationService.<>c.<>9__6_3 = val_141;
            }
            
            val_129 = val_141;
            val_39[3] = SRDebugger.InfoEntry.Create(name:  "Orientation", getter:  val_46, isPrivate:  false);
            if(val_128 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_128.Add(key:  "Display", value:  val_39);
            val_128 = this._info;
            SRDebugger.InfoEntry[] val_48 = new SRDebugger.InfoEntry[4];
            val_142 = null;
            val_142 = null;
            val_144 = StandardSystemInformationService.<>c.<>9__6_4;
            if(val_144 == null)
            {
                    System.Func<System.Object> val_49 = null;
                val_144 = val_49;
                val_49 = new System.Func<System.Object>(object:  StandardSystemInformationService.<>c.__il2cppRuntimeField_static_fields, method:  System.Object StandardSystemInformationService.<>c::<CreateDefaultSet>b__6_4());
                StandardSystemInformationService.<>c.<>9__6_4 = val_144;
            }
            
            val_129 = val_144;
            if(val_48 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_48[0] = SRDebugger.InfoEntry.Create(name:  "Play Time", getter:  val_49, isPrivate:  false);
            val_145 = null;
            val_145 = null;
            val_147 = StandardSystemInformationService.<>c.<>9__6_5;
            if(val_147 == null)
            {
                    System.Func<System.Object> val_51 = null;
                val_147 = val_51;
                val_51 = new System.Func<System.Object>(object:  StandardSystemInformationService.<>c.__il2cppRuntimeField_static_fields, method:  System.Object StandardSystemInformationService.<>c::<CreateDefaultSet>b__6_5());
                StandardSystemInformationService.<>c.<>9__6_5 = val_147;
            }
            
            val_48[1] = SRDebugger.InfoEntry.Create(name:  "Level Play Time", getter:  val_51, isPrivate:  false);
            val_148 = null;
            val_148 = null;
            val_150 = StandardSystemInformationService.<>c.<>9__6_6;
            if(val_150 == null)
            {
                    System.Func<System.Object> val_53 = null;
                val_150 = val_53;
                val_53 = new System.Func<System.Object>(object:  StandardSystemInformationService.<>c.__il2cppRuntimeField_static_fields, method:  System.Object StandardSystemInformationService.<>c::<CreateDefaultSet>b__6_6());
                StandardSystemInformationService.<>c.<>9__6_6 = val_150;
            }
            
            val_48[2] = SRDebugger.InfoEntry.Create(name:  "Current Level", getter:  val_53, isPrivate:  false);
            val_151 = null;
            val_151 = null;
            val_153 = StandardSystemInformationService.<>c.<>9__6_7;
            if(val_153 == null)
            {
                    System.Func<System.Object> val_55 = null;
                val_153 = val_55;
                val_55 = new System.Func<System.Object>(object:  StandardSystemInformationService.<>c.__il2cppRuntimeField_static_fields, method:  System.Object StandardSystemInformationService.<>c::<CreateDefaultSet>b__6_7());
                StandardSystemInformationService.<>c.<>9__6_7 = val_153;
            }
            
            val_129 = val_153;
            val_48[3] = SRDebugger.InfoEntry.Create(name:  "Quality Level", getter:  val_55, isPrivate:  false);
            if(val_128 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_128.Add(key:  "Runtime", value:  val_48);
            UnityEngine.Object val_57 = UnityEngine.Resources.Load(path:  "UnityCloudBuildManifest.json");
            val_128 = val_57;
            if(val_57 != null)
            {
                    val_129 = null;
            }
            
            val_129 = 0;
            if(val_128 == val_129)
            {
                goto label_136;
            }
            
            if(val_128 == null)
            {
                    throw new NullReferenceException();
            }
            
            object val_60 = SRF.Json.Deserialize(json:  val_128.text);
            if(val_60 == null)
            {
                goto label_136;
            }
            
            System.Collections.Generic.List<SRDebugger.InfoEntry> val_62 = null;
            val_128 = val_62;
            val_62 = new System.Collections.Generic.List<SRDebugger.InfoEntry>(capacity:  val_60.Count);
            Dictionary.Enumerator<TKey, TValue> val_63 = val_60.GetEnumerator();
            label_140:
            if(val_33.MoveNext() == false)
            {
                goto label_137;
            }
            
            if(val_65 == 0)
            {
                goto label_140;
            }
            
            val_62.Add(item:  SRDebugger.InfoEntry.Create(name:  SRDebugger.Services.Implementation.StandardSystemInformationService.GetCloudManifestPrettyName(name:  val_65), value:  val_65, isPrivate:  false));
            goto label_140;
            label_137:
            val_129 = public System.Void Dictionary.Enumerator<System.String, System.Object>::Dispose();
            val_33.Dispose();
            if(this._info == null)
            {
                    throw new NullReferenceException();
            }
            
            this._info.Add(key:  "Build", value:  val_62);
            label_136:
            val_128 = this._info;
            SRDebugger.InfoEntry[] val_69 = new SRDebugger.InfoEntry[4];
            bool val_71 = UnityEngine.SystemInfo.supportsLocationService;
            val_129 = val_71;
            if(val_69 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_69[0] = SRDebugger.InfoEntry.Create(name:  "Location", value:  val_71, isPrivate:  false);
            val_69[1] = SRDebugger.InfoEntry.Create(name:  "Accelerometer", value:  UnityEngine.SystemInfo.supportsAccelerometer, isPrivate:  false);
            val_69[2] = SRDebugger.InfoEntry.Create(name:  "Gyroscope", value:  UnityEngine.SystemInfo.supportsGyroscope, isPrivate:  false);
            bool val_80 = UnityEngine.SystemInfo.supportsVibration;
            val_129 = val_80;
            val_69[3] = SRDebugger.InfoEntry.Create(name:  "Vibration", value:  val_80, isPrivate:  false);
            if(val_128 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_128.Add(key:  "Features", value:  val_69);
            SRDebugger.InfoEntry[] val_82 = new SRDebugger.InfoEntry[15];
            val_128 = val_82;
            val_129 = UnityEngine.SystemInfo.graphicsDeviceName;
            if(val_128 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_128[0] = SRDebugger.InfoEntry.Create(name:  "Device Name", value:  val_129, isPrivate:  false);
            val_128[1] = SRDebugger.InfoEntry.Create(name:  "Device Vendor", value:  UnityEngine.SystemInfo.graphicsDeviceVendor, isPrivate:  false);
            val_128[2] = SRDebugger.InfoEntry.Create(name:  "Device Version", value:  UnityEngine.SystemInfo.graphicsDeviceVersion, isPrivate:  false);
            val_128[3] = SRDebugger.InfoEntry.Create(name:  "Max Tex Size", value:  UnityEngine.SystemInfo.maxTextureSize, isPrivate:  false);
            if(UnityEngine.SystemInfo.graphicsPixelFillrate > 0)
            {
                    object[] val_92 = new object[1];
                if(val_92 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_92[0] = UnityEngine.SystemInfo.graphicsPixelFillrate;
                val_154 = SRF.SRFStringExtensions.Fmt(formatString:  "{0}mpix/s", args:  val_92);
            }
            else
            {
                    val_154 = "Unknown";
            }
            
            val_128[4] = SRDebugger.InfoEntry.Create(name:  "Fill Rate", value:  val_154, isPrivate:  false);
            val_128[5] = SRDebugger.InfoEntry.Create(name:  "NPOT Support", value:  UnityEngine.SystemInfo.npotSupport, isPrivate:  false);
            val_129 = 2;
            object[] val_98 = new object[2];
            if(val_98 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_98[0] = (UnityEngine.SystemInfo.supportsRenderTextures != true) ? "Yes" : "No";
            val_98[1] = UnityEngine.SystemInfo.supportedRenderTargetCount;
            val_128[6] = SRDebugger.InfoEntry.Create(name:  "Render Textures", value:  SRF.SRFStringExtensions.Fmt(formatString:  "{0} ({1})", args:  val_98), isPrivate:  false);
            val_128[7] = SRDebugger.InfoEntry.Create(name:  "3D Textures", value:  UnityEngine.SystemInfo.supports3DTextures, isPrivate:  false);
            val_128[8] = SRDebugger.InfoEntry.Create(name:  "Compute Shaders", value:  UnityEngine.SystemInfo.supportsComputeShaders, isPrivate:  false);
            val_128[9] = SRDebugger.InfoEntry.Create(name:  "Vertex Programs", value:  UnityEngine.SystemInfo.supportsVertexPrograms, isPrivate:  false);
            val_128[10] = SRDebugger.InfoEntry.Create(name:  "Image Effects", value:  UnityEngine.SystemInfo.supportsImageEffects, isPrivate:  false);
            val_128[11] = SRDebugger.InfoEntry.Create(name:  "Cubemaps", value:  UnityEngine.SystemInfo.supportsRenderToCubemap, isPrivate:  false);
            val_128[12] = SRDebugger.InfoEntry.Create(name:  "Shadows", value:  UnityEngine.SystemInfo.supportsShadows, isPrivate:  false);
            val_128[13] = SRDebugger.InfoEntry.Create(name:  "Stencil", value:  UnityEngine.SystemInfo.supportsStencil, isPrivate:  false);
            bool val_125 = UnityEngine.SystemInfo.supportsSparseTextures;
            val_129 = val_125;
            val_128[14] = SRDebugger.InfoEntry.Create(name:  "Sparse Textures", value:  val_125, isPrivate:  false);
            if(this._info == null)
            {
                    throw new NullReferenceException();
            }
            
            this._info.Add(key:  "Graphics", value:  val_82);
        }
        private static string GetCloudManifestPrettyName(string name)
        {
            var val_8;
            if((System.String.op_Equality(a:  name, b:  "scmCommitId")) != false)
            {
                    val_8 = "Commit";
                return (string)val_8;
            }
            
            if((System.String.op_Equality(a:  name, b:  "scmBranch")) != false)
            {
                    val_8 = "Branch";
                return (string)val_8;
            }
            
            if((System.String.op_Equality(a:  name, b:  "cloudBuildTargetName")) != false)
            {
                    val_8 = "Build Target";
                return (string)val_8;
            }
            
            if((System.String.op_Equality(a:  name, b:  "buildStartTime")) == false)
            {
                    return name.Substring(startIndex:  0, length:  1).ToUpper()(name.Substring(startIndex:  0, length:  1).ToUpper()) + name.Substring(startIndex:  1)(name.Substring(startIndex:  1));
            }
            
            val_8 = "Build Date";
            return (string)val_8;
        }
    
    }

}
