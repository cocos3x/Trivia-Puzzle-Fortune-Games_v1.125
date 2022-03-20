using UnityEngine;

namespace SRF.Service
{
    public class SRServiceManager : SRAutoSingleton<SRF.Service.SRServiceManager>
    {
        // Fields
        public const bool EnableLogging = False;
        public static int LoadingCount;
        private readonly SRF.SRList<SRF.Service.SRServiceManager.Service> _services;
        private System.Collections.Generic.List<SRF.Service.SRServiceManager.ServiceStub> _serviceStubs;
        private static bool _hasQuit;
        
        // Properties
        public static bool IsLoading { get; }
        
        // Methods
        public static bool get_IsLoading()
        {
            null = null;
            return (bool)(SRF.Service.SRServiceManager.LoadingCount > 0) ? 1 : 0;
        }
        public static T GetService<T>()
        {
            object val_6;
            var val_7;
            var val_8;
            var val_9;
            val_6 = __RuntimeMethodHiddenParam;
            object val_2 = SRF.Service.SRServiceManager.GetServiceInternal(t:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 48}));
            if(X0 != false)
            {
                    if(X0 == true)
            {
                    return (SRDebugger.Services.IBugReportService)val_7;
            }
            
            }
            
            val_8 = null;
            val_8 = null;
            if(SRF.Service.SRServiceManager._hasQuit != true)
            {
                    object[] val_3 = new object[2];
                val_3[0] = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 48});
                val_9 = null;
                val_9 = null;
                val_3[1] = SRF.Service.SRServiceManager._hasQuit;
                val_6 = SRF.SRFStringExtensions.Fmt(formatString:  "Service {0} not found. (HasQuit: {1})", args:  val_3);
                UnityEngine.Debug.LogWarning(message:  val_6);
            }
            
            val_7 = 0;
            return (SRDebugger.Services.IBugReportService)val_7;
        }
        public static object GetService(System.Type t)
        {
            System.Type val_4;
            var val_5;
            var val_6;
            val_4 = t;
            object val_1 = SRF.Service.SRServiceManager.GetServiceInternal(t:  val_4);
            if(val_1 != null)
            {
                    return val_1;
            }
            
            val_5 = null;
            val_5 = null;
            if(SRF.Service.SRServiceManager._hasQuit == true)
            {
                    return val_1;
            }
            
            object[] val_2 = new object[2];
            val_2[0] = val_4;
            val_6 = null;
            val_6 = null;
            val_4 = SRF.Service.SRServiceManager._hasQuit;
            val_2[1] = val_4;
            UnityEngine.Debug.LogWarning(message:  SRF.SRFStringExtensions.Fmt(formatString:  "Service {0} not found. (HasQuit: {1})", args:  val_2));
            return val_1;
        }
        private static object GetServiceInternal(System.Type t)
        {
            var val_5;
            object val_6;
            var val_7;
            val_5 = null;
            val_5 = null;
            if(SRF.Service.SRServiceManager._hasQuit != false)
            {
                    val_6 = 0;
                return val_6;
            }
            
            bool val_1 = UnityEngine.Application.isPlaying;
            val_6 = 0;
            if(val_1 == false)
            {
                    return val_6;
            }
            
            SRF.Service.SRServiceManager val_2 = SRF.Components.SRAutoSingleton<SRF.Service.SRServiceManager>.Instance;
            if(val_1 < true)
            {
                    return SRF.Components.SRAutoSingleton<SRF.Service.SRServiceManager>.Instance.AutoCreateService(t:  t);
            }
            
            val_7 = 0;
            label_12:
            Service val_3 = val_2._services.Item[0];
            if((t & 1) != 0)
            {
                goto label_11;
            }
            
            val_7 = val_7 + 1;
            if(val_7 < null)
            {
                goto label_12;
            }
            
            return SRF.Components.SRAutoSingleton<SRF.Service.SRServiceManager>.Instance.AutoCreateService(t:  t);
            label_11:
            val_6 = val_3.Object;
            if(val_6 != null)
            {
                    return val_6;
            }
            
            SRF.Service.SRServiceManager.UnRegisterService(t:  t);
            return SRF.Components.SRAutoSingleton<SRF.Service.SRServiceManager>.Instance.AutoCreateService(t:  t);
        }
        public static bool HasService<T>()
        {
            return SRF.Service.SRServiceManager.HasService(t:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 48}));
        }
        public static bool HasService(System.Type t)
        {
            null = null;
            if(SRF.Service.SRServiceManager._hasQuit == true)
            {
                    return false;
            }
            
            if(UnityEngine.Application.isPlaying == false)
            {
                    return false;
            }
            
            SRF.Service.SRServiceManager val_2 = SRF.Components.SRAutoSingleton<SRF.Service.SRServiceManager>.Instance;
            if(1152921519484503344 < 1)
            {
                    return false;
            }
            
            var val_5 = 0;
            label_11:
            Service val_3 = val_2._services.Item[0];
            if((t & 1) != 0)
            {
                goto label_10;
            }
            
            val_5 = val_5 + 1;
            if(val_5 < null)
            {
                goto label_11;
            }
            
            return false;
            label_10:
            var val_4 = (val_3.Object != 0) ? 1 : 0;
            return false;
        }
        public static void RegisterService<T>(object service)
        {
            SRF.Service.SRServiceManager.RegisterService(t:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 48}), service:  service);
        }
        private static void RegisterService(System.Type t, object service)
        {
            var val_11;
            var val_12;
            val_11 = null;
            val_11 = null;
            if(SRF.Service.SRServiceManager._hasQuit == true)
            {
                    return;
            }
            
            if((SRF.Service.SRServiceManager.HasService(t:  t)) == false)
            {
                goto label_6;
            }
            
            if((SRF.Service.SRServiceManager.GetServiceInternal(t:  t)) != service)
            {
                goto label_9;
            }
            
            return;
            label_6:
            SRF.Service.SRServiceManager.UnRegisterService(t:  t);
            if((t & 1) == 0)
            {
                goto label_13;
            }
            
            SRF.Service.SRServiceManager val_3 = SRF.Components.SRAutoSingleton<SRF.Service.SRServiceManager>.Instance;
            .Object = service;
            .Type = t;
            val_3._services.Add(item:  new SRServiceManager.Service());
            return;
            label_9:
            System.Exception val_6 = null;
            val_12 = val_6;
            val_6 = new System.Exception(message:  "Service already registered for type " + ???(???));
            throw val_12 = val_10;
            label_13:
            System.Type val_8 = service.GetType();
            System.ArgumentException val_10 = null;
            val_10 = new System.ArgumentException(message:  SRF.SRFStringExtensions.Fmt(formatString:  "service {0} must be assignable from type {1}", args:  new object[2]));
            throw val_12;
        }
        public static void UnRegisterService<T>()
        {
            SRF.Service.SRServiceManager.UnRegisterService(t:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = __RuntimeMethodHiddenParam + 48}));
        }
        private static void UnRegisterService(System.Type t)
        {
            var val_6;
            var val_7;
            val_6 = null;
            val_6 = null;
            if(SRF.Service.SRServiceManager._hasQuit == true)
            {
                    return;
            }
            
            if((SRF.Components.SRAutoSingleton<SRF.Service.SRServiceManager>.HasInstance) == false)
            {
                    return;
            }
            
            if((SRF.Service.SRServiceManager.HasService(t:  t)) == false)
            {
                    return;
            }
            
            SRF.Service.SRServiceManager val_3 = SRF.Components.SRAutoSingleton<SRF.Service.SRServiceManager>.Instance;
            val_7 = 44339567;
            if(<0)
            {
                    return;
            }
            
            do
            {
                Service val_4 = val_3._services.Item[44339567];
                if((System.Type.op_Equality(left:  val_4.Type, right:  t)) != false)
            {
                    val_3._services.RemoveAt(index:  44339567);
            }
            
                val_7 = 44339566;
            }
            while(>=0);
        
        }
        protected override void Awake()
        {
            null = null;
            SRF.Service.SRServiceManager._hasQuit = false;
            this.Awake();
            UnityEngine.Object.DontDestroyOnLoad(target:  this.CachedGameObject);
            this.CachedGameObject.hideFlags = 8;
        }
        protected void UpdateStubs()
        {
            System.Collections.Generic.IEnumerable<T> val_8;
            if(this._serviceStubs != null)
            {
                    return;
            }
            
            this._serviceStubs = new System.Collections.Generic.List<ServiceStub>();
            System.Collections.Generic.List<System.Type> val_2 = new System.Collections.Generic.List<System.Type>();
            System.Type val_3 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
            if(val_3 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_8 = val_3;
            if(val_2 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_2.AddRange(collection:  val_8);
            List.Enumerator<T> val_4 = val_2.GetEnumerator();
            label_8:
            if(0.MoveNext() == false)
            {
                goto label_7;
            }
            
            this.ScanType(type:  0);
            goto label_8;
            label_7:
            0.Dispose();
        }
        protected object AutoCreateService(System.Type t)
        {
            var val_2;
            var val_3;
            var val_12;
            System.Type val_13;
            System.Collections.Generic.List<ServiceStub> val_14;
            object val_16;
            System.Type val_17;
            val_13 = t;
            this.UpdateStubs();
            val_14 = this._serviceStubs;
            if(val_14 == null)
            {
                    throw new NullReferenceException();
            }
            
            List.Enumerator<T> val_1 = val_14.GetEnumerator();
            label_6:
            if(val_3.MoveNext() == false)
            {
                goto label_2;
            }
            
            if(val_2 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if((System.Type.op_Inequality(left:  val_2 + 24, right:  val_13)) == true)
            {
                goto label_6;
            }
            
            if((val_2 + 16) == 0)
            {
                goto label_7;
            }
            
            object val_6 = val_2 + 16.Invoke();
            goto label_8;
            label_2:
            val_16 = 0;
            goto label_18;
            label_7:
            val_17 = mem[val_2 + 40];
            val_17 = val_2 + 40;
            if((System.Type.op_Equality(left:  val_17, right:  0)) != false)
            {
                    val_17 = val_2 + 32.Invoke();
            }
            
            label_8:
            val_12 = 1152921505009721344;
            val_16 = SRF.Service.SRServiceManager.DefaultServiceConstructor(serviceIntType:  val_13, implType:  val_17);
            if((SRF.Service.SRServiceManager.HasService(t:  val_13)) != true)
            {
                    SRF.Service.SRServiceManager.RegisterService(t:  val_13, service:  val_16);
            }
            
            label_18:
            val_3.Dispose();
            return val_16;
        }
        protected void OnApplicationQuit()
        {
            null = null;
            SRF.Service.SRServiceManager._hasQuit = true;
        }
        private static object DefaultServiceConstructor(System.Type serviceIntType, System.Type implType)
        {
            IntPtr val_7 = null;
            if(((System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = val_7})) & 1) != 0)
            {
                    val_7 = "_S_" + serviceIntType;
                UnityEngine.Component val_4 = new UnityEngine.GameObject(name:  val_7).AddComponent(componentType:  implType);
                return (object)UnityEngine.ScriptableObject.CreateInstance(type:  implType);
            }
            
            if(((System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle())) & 1) == 0)
            {
                    return System.Activator.CreateInstance(type:  implType);
            }
            
            return (object)UnityEngine.ScriptableObject.CreateInstance(type:  implType);
        }
        private void ScanType(System.Type type)
        {
            if((SRF.Helpers.SRReflection.GetAttribute<SRF.Service.ServiceAttribute>(t:  type)) != null)
            {
                    .Type = type;
                .InterfaceType = val_1.<ServiceType>k__BackingField;
                this._serviceStubs.Add(item:  new SRServiceManager.ServiceStub());
            }
            
            SRF.Service.SRServiceManager.ScanTypeForConstructors(t:  type, stubs:  this._serviceStubs);
            SRF.Service.SRServiceManager.ScanTypeForSelectors(t:  type, stubs:  this._serviceStubs);
        }
        private static void ScanTypeForSelectors(System.Type t, System.Collections.Generic.List<SRF.Service.SRServiceManager.ServiceStub> stubs)
        {
            var val_14;
            ServiceStub val_15;
            IntPtr val_16;
            string val_18;
            if(null < 1)
            {
                    return;
            }
            
            val_14 = 1152921519486487312;
            var val_14 = 0;
            System.Type val_1 = t + 32;
            goto label_42;
            label_32:
            ServiceStub val_3 = System.Linq.Enumerable.FirstOrDefault<ServiceStub>(source:  stubs, predicate:  new System.Func<ServiceStub, System.Boolean>(object:  X23, method:  System.Boolean SRServiceManager.<>c__DisplayClass24_0::<ScanTypeForSelectors>b__0(SRF.Service.SRServiceManager.ServiceStub p)));
            val_15 = val_3;
            if(val_3 == null)
            {
                    SRServiceManager.ServiceStub val_4 = null;
                val_15 = val_4;
                val_4 = new SRServiceManager.ServiceStub();
                .InterfaceType = X23 + 16 + 16;
                stubs.Add(item:  val_4);
            }
            
            val_16 = null;
            System.Delegate val_6 = System.Delegate.CreateDelegate(type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = val_16}), method:  X22);
            if(val_6 != null)
            {
                    if(null != null)
            {
                goto label_14;
            }
            
            }
            
            .Selector = val_6;
            goto label_18;
            label_42:
            SRServiceManager.<>c__DisplayClass24_0 val_7 = null;
            val_16 = val_7;
            val_7 = new SRServiceManager.<>c__DisplayClass24_0();
            SRF.Service.ServiceSelectorAttribute val_8 = SRF.Helpers.SRReflection.GetAttribute<SRF.Service.ServiceSelectorAttribute>(t:  1152921504623353856);
            .attrib = val_8;
            if(val_8 == null)
            {
                goto label_18;
            }
            
            if((System.Type.op_Inequality(left:  1152921504623353856, right:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()))) == false)
            {
                goto label_22;
            }
            
            val_16 = new object[2];
            val_16[0] = t;
            val_16[1] = 1152921504623353856;
            val_18 = "ServiceSelector must have return type of Type ({0}.{1}())";
            goto label_30;
            label_22:
            if(System == null)
            {
                goto label_32;
            }
            
            object[] val_12 = new object[2];
            val_16 = val_12;
            val_16[0] = t;
            val_16[1] = 1152921504623353856;
            val_18 = "ServiceSelector must have no parameters ({0}.{1}())";
            label_30:
            UnityEngine.Debug.LogError(message:  SRF.SRFStringExtensions.Fmt(formatString:  val_18, args:  val_12));
            label_18:
            val_14 = val_14 + 1;
            if(val_14 < (null << ))
            {
                goto label_42;
            }
            
            return;
            label_14:
        }
        private static void ScanTypeForConstructors(System.Type t, System.Collections.Generic.List<SRF.Service.SRServiceManager.ServiceStub> stubs)
        {
            var val_12;
            ServiceStub val_13;
            System.Object[] val_14;
            System.Type val_15;
            int val_17;
            string val_18;
            System.Object[] val_19;
            if(null < 1)
            {
                    return;
            }
            
            val_12 = 1152921519486710336;
            var val_12 = 0;
            System.Type val_1 = t + 32;
            goto label_43;
            label_33:
            ServiceStub val_3 = System.Linq.Enumerable.FirstOrDefault<ServiceStub>(source:  stubs, predicate:  new System.Func<ServiceStub, System.Boolean>(object:  X23, method:  static_value_02A4B168));
            val_13 = val_3;
            if(val_3 == null)
            {
                    SRServiceManager.ServiceStub val_4 = null;
                val_13 = val_4;
                val_4 = new SRServiceManager.ServiceStub();
                .InterfaceType = X23 + 16 + 16;
                stubs.Add(item:  val_4);
            }
            
            mem2[0] = ???;
            .Constructor = new System.Func<System.Object>(object:  X23, method:  System.Object SRServiceManager.<>c__DisplayClass25_0::<ScanTypeForConstructors>b__1());
            goto label_14;
            label_43:
            SRServiceManager.<>c__DisplayClass25_0 val_6 = null;
            val_14 = val_6;
            val_6 = new SRServiceManager.<>c__DisplayClass25_0();
            SRF.Service.ServiceConstructorAttribute val_7 = SRF.Helpers.SRReflection.GetAttribute<SRF.Service.ServiceConstructorAttribute>(t:  1152921504623353856);
            .attrib = val_7;
            if(val_7 == null)
            {
                goto label_14;
            }
            
            val_15 = (SRServiceManager.<>c__DisplayClass25_0)[1152921519486846624].attrib.<ServiceType>k__BackingField;
            if((System.Type.op_Inequality(left:  1152921504623353856, right:  val_15)) == false)
            {
                goto label_19;
            }
            
            object[] val_9 = new object[3];
            val_15 = t;
            val_9[0] = val_15;
            val_17 = val_9.Length;
            val_9[1] = 1152921504623353856;
            if(((SRServiceManager.<>c__DisplayClass25_0)[1152921519486846624].attrib.<ServiceType>k__BackingField) != null)
            {
                    val_17 = val_9.Length;
            }
            
            val_9[2] = (SRServiceManager.<>c__DisplayClass25_0)[1152921519486846624].attrib.<ServiceType>k__BackingField;
            val_18 = "ServiceConstructor must have return type of {2} ({0}.{1}())";
            val_19 = val_9;
            goto label_31;
            label_19:
            if(System == null)
            {
                goto label_33;
            }
            
            object[] val_10 = new object[2];
            val_14 = val_10;
            val_14[0] = t;
            val_14[1] = 1152921504623353856;
            val_18 = "ServiceConstructor must have no parameters ({0}.{1}())";
            val_19 = val_14;
            label_31:
            UnityEngine.Debug.LogError(message:  SRF.SRFStringExtensions.Fmt(formatString:  val_18, args:  val_10));
            label_14:
            val_12 = val_12 + 1;
            if(val_12 < (null << ))
            {
                goto label_43;
            }
        
        }
        private static System.Reflection.MethodInfo[] GetStaticMethods(System.Type t)
        {
            if(t != null)
            {
                
            }
            else
            {
                    throw new NullReferenceException();
            }
        
        }
        public SRServiceManager()
        {
            this._services = new SRF.SRList<Service>();
        }
        private static SRServiceManager()
        {
        
        }
    
    }

}
