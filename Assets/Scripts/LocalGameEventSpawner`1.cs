using UnityEngine;
public class LocalGameEventSpawner<T> : MonoSingleton<T>
{
    // Fields
    private static readonly System.Collections.Generic.Dictionary<System.Type, System.Type> ProxyEventHandlerTypeLookup;
    
    // Methods
    public virtual void Start()
    {
        var val_9;
        var val_11;
        var val_12;
        var val_14;
        System.Delegate val_15;
        System.Delegate val_16;
        var val_18;
        val_9 = MonoSingleton<WordGameEventsController>.Instance;
        System.Delegate val_3 = System.Delegate.Combine(a:  val_1.AddProxyEventHandlers, b:  new WordGameEventsController.ProxyEventHandlerDelegate(object:  this, method:  typeof(LocalGameEventSpawner<T>).__il2cppRuntimeField_1F8));
        if(val_3 == null)
        {
            goto label_5;
        }
        
        val_11 = null;
        val_12 = val_3;
        if(X0 == false)
        {
            goto label_9;
        }
        
        label_5:
        val_1.AddProxyEventHandlers = null;
        val_9 = MonoSingleton<WordGameEventsController>.Instance;
        System.Delegate val_6 = System.Delegate.Combine(a:  val_4.RemoveExpiredProxyEventHandlers, b:  new WordGameEventsController.ProxyEventHandlerDelegate(object:  this, method:  typeof(LocalGameEventSpawner<T>).__il2cppRuntimeField_208));
        if(val_6 == null)
        {
            goto label_8;
        }
        
        val_11 = null;
        val_12 = val_6;
        if(X0 == false)
        {
            goto label_9;
        }
        
        label_8:
        val_4.RemoveExpiredProxyEventHandlers = null;
        val_14 = null;
        val_14 = null;
        WordGameEventsController.ProxyEventTrackingDelegate val_7 = null;
        val_15 = val_7;
        val_7 = new WordGameEventsController.ProxyEventTrackingDelegate(object:  this, method:  typeof(LocalGameEventSpawner<T>).__il2cppRuntimeField_218);
        val_16 = val_15;
        System.Delegate val_8 = System.Delegate.Combine(a:  WordGameEventsController.AddTrackingEventData, b:  val_7);
        if(val_8 == null)
        {
            goto label_12;
        }
        
        val_18 = null;
        val_9 = val_8;
        val_16 = val_18;
        if(X0 == false)
        {
            goto label_13;
        }
        
        label_12:
        WordGameEventsController.AddTrackingEventData = null;
        val_9 = ???;
        val_11 = ???;
        val_12 = ???;
        goto typeof(LocalGameEventSpawner<T>).__il2cppRuntimeField_1A0;
        label_9:
        label_13:
    }
    public virtual void InitSpwaner()
    {
    
    }
    protected virtual bool CanAddProxyEvent()
    {
        UnityEngine.Debug.LogError(message:  "No override method for LocalGameEventSpawner.CanAddProxyEvent -- not going to spawn local game event!");
        return false;
    }
    protected virtual bool ShouldRemoveProxyEvent(WGEventHandler handler)
    {
        UnityEngine.Debug.LogError(message:  "No override method for LocalGameEventSpawner.ShouldRemoveProxyEvent -- never going to despawn local game event!");
        return false;
    }
    private System.Type GetMyProxyEventHandlerType()
    {
        var val_2 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 32 + 302];
        val_2 = __RuntimeMethodHiddenParam + 24 + 192 + 32 + 302;
        if((val_2 & 1) == 0)
        {
                val_2 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 32 + 302];
            val_2 = __RuntimeMethodHiddenParam + 24 + 192 + 32 + 302;
        }
        
        if((val_2 & 512) == 0)
        {
                return __RuntimeMethodHiddenParam + 24 + 192 + 32 + 184.Item[this.GetType()];
        }
        
        return __RuntimeMethodHiddenParam + 24 + 192 + 32 + 184.Item[this.GetType()];
    }
    protected virtual void PopulateProxyEvent(ref GameEventV2 proxyEvent)
    {
    
    }
    protected virtual void UpdateProxyEventHandler(ref WGEventHandler proxyEventHandler)
    {
    
    }
    protected virtual object AddProxyEventHandler(ref System.Collections.Generic.List<WGEventHandler> existingEventHandlers)
    {
        GameEventV2 val_8;
        System.Func<TSource, System.Boolean> val_9;
        IntPtr val_10;
        if(this == null)
        {
                throw new NullReferenceException();
        }
        
        if((this & 1) == 0)
        {
                return (object)existingEventHandlers;
        }
        
        GameEventV2 val_1 = null;
        val_8 = val_1;
        val_1 = new GameEventV2();
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        .type = this;
        System.Func<WGEventHandler, System.Boolean> val_2 = null;
        val_9 = val_2;
        val_2 = new System.Func<WGEventHandler, System.Boolean>(object:  this, method:  __RuntimeMethodHiddenParam + 24 + 192 + 72);
        if((System.Linq.Enumerable.FirstOrDefault<WGEventHandler>(source:  existingEventHandlers, predicate:  val_2)) != null)
        {
                return (object)existingEventHandlers;
        }
        
        val_9 = this;
        val_8 = System.Activator.CreateInstance(type:  this);
        val_10 = null;
        System.Type val_5 = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle() {value = val_10});
        if(this == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_9 & 1) == 0)
        {
            goto label_9;
        }
        
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        val_10 = null;
        if(X0 == false)
        {
            goto label_11;
        }
        
        val_9 = X0;
        if(val_9 == false)
        {
            goto label_12;
        }
        
        if(existingEventHandlers == null)
        {
                throw new NullReferenceException();
        }
        
        existingEventHandlers.Add(item:  X0);
        return (object)existingEventHandlers;
        label_9:
        UnityEngine.Debug.LogError(message:  "We don\'t a type for event of " + this);
        return (object)existingEventHandlers;
        label_12:
        UnityEngine.Debug.LogWarning(message:  "InValidated By Handler " + this);
        return (object)existingEventHandlers;
        label_11:
    }
    protected virtual object RemoveExpiredProxyEventHandler(ref System.Collections.Generic.List<WGEventHandler> existingEventHandlers)
    {
        System.Collections.Generic.List<WGEventHandler> val_10;
        var val_11;
        var val_12;
        System.Collections.Generic.List<WGEventHandler> val_1 = new System.Collections.Generic.List<WGEventHandler>();
        val_10 = existingEventHandlers;
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        val_11 = 4;
        label_20:
        var val_2 = val_11 - 4;
        if(val_2 >= (mem[existingEventHandlers + 24]))
        {
            goto label_2;
        }
        
        if((mem[existingEventHandlers + 24]) <= val_2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((mem[existingEventHandlers + 16] + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        val_10 = mem[existingEventHandlers + 16] + 32.GetType();
        val_12 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 32 + 302];
        val_12 = __RuntimeMethodHiddenParam + 24 + 192 + 32 + 302;
        if((val_12 & 1) == 0)
        {
                val_12 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 32 + 302];
            val_12 = __RuntimeMethodHiddenParam + 24 + 192 + 32 + 302;
        }
        
        if(this == null)
        {
                throw new NullReferenceException();
        }
        
        if((__RuntimeMethodHiddenParam + 24 + 192 + 32 + 184) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((System.Type.op_Inequality(left:  val_10, right:  __RuntimeMethodHiddenParam + 24 + 192 + 32 + 184.Item[this.GetType()])) != true)
        {
                val_10 = existingEventHandlers;
            if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
            if((mem[existingEventHandlers + 24]) <= val_2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_10 = mem[mem[existingEventHandlers + 16] + 32];
            val_10 = mem[existingEventHandlers + 16] + 32;
            if((this & 1) != 0)
        {
                if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
            val_1.Add(item:  val_10);
        }
        
        }
        
        val_10 = existingEventHandlers;
        val_11 = val_11 + 1;
        if(val_10 != null)
        {
            goto label_20;
        }
        
        throw new NullReferenceException();
        label_2:
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        List.Enumerator<T> val_7 = val_1.GetEnumerator();
        label_24:
        if(0.MoveNext() == false)
        {
            goto label_22;
        }
        
        bool val_9 = existingEventHandlers.Remove(item:  0);
        goto label_24;
        label_22:
        var val_10 = 0;
        val_10 = val_10 + 1;
        null.Dispose();
        if(0 != 0)
        {
                throw ???;
        }
        
        return (object)existingEventHandlers;
    }
    protected virtual object AddProxyEventTrackingData(ref System.Collections.Generic.Dictionary<string, object> trackingData)
    {
        System.Object[] val_9;
        mem2[0] = this;
        string val_1 = System.String.Format(format:  "EA {0}", arg0:  this);
        if((trackingData.ContainsKey(key:  val_1)) != false)
        {
                object[] val_3 = new object[1];
            val_9 = val_3;
            val_9[0] = __RuntimeMethodHiddenParam + 24 + 192 + 104 + 16;
            UnityEngine.Debug.LogErrorFormat(format:  "LocalGameEventSpawner:AddProxyEventTrackingData, property with name {0} already exists", args:  val_3);
            return 0;
        }
        
        val_9 = trackingData;
        val_9.Add(key:  val_1, value:  MonoSingleton<WordGameEventsController>.Instance.GetOrderedEventHandlers().Exists(match:  new System.Predicate<WGEventHandler>(object:  __RuntimeMethodHiddenParam + 24 + 192 + 104, method:  __RuntimeMethodHiddenParam + 24 + 192 + 120)));
        return 0;
    }
    protected virtual string GetProxyEventTrackingName()
    {
        object[] val_1 = new object[1];
        val_1[0] = this;
        UnityEngine.Debug.LogErrorFormat(format:  "GetProxyEventTrackingName() not implemented for {0}! Not going to track the event-active of local event properly!", args:  val_1);
        return "Error: Not Implemented!";
    }
    public LocalGameEventSpawner<T>()
    {
        var val_1 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 40 + 302];
        val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 40 + 302;
        if((val_1 & 1) == 0)
        {
                val_1 = mem[__RuntimeMethodHiddenParam + 24 + 192 + 40 + 302];
            val_1 = __RuntimeMethodHiddenParam + 24 + 192 + 40 + 302;
        }
        
        if(((val_1 & 512) != 0) && ((__RuntimeMethodHiddenParam + 24 + 192 + 40 + 224) == 0))
        {
            
        }
    
    }
    private static LocalGameEventSpawner<T>()
    {
        System.Collections.Generic.Dictionary<System.Type, System.Type> val_1 = new System.Collections.Generic.Dictionary<System.Type, System.Type>();
        val_1.Add(key:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        val_1.Add(key:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), value:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()));
        mem2[0] = val_1;
    }
    private bool <AddProxyEventHandler>b__8_0(WGEventHandler p)
    {
        return System.Type.op_Equality(left:  p.GetType(), right:  this);
    }

}
