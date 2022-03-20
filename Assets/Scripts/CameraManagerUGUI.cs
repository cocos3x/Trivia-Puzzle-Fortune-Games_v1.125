using UnityEngine;
public class CameraManagerUGUI : MonoSingletonSelfGenerating<CameraManagerUGUI>
{
    // Fields
    private System.Collections.Generic.Dictionary<int, CameraOperatorUGUI> guidsToCameras;
    private System.Collections.Generic.Stack<System.Collections.Generic.Dictionary<int, bool>> cameraSnapshotQueue;
    
    // Methods
    public void AddCamera(CameraOperatorUGUI cam)
    {
        if(cam == 0)
        {
                return;
        }
        
        if(cam.gameObject == 0)
        {
                return;
        }
        
        if((this.guidsToCameras.ContainsKey(key:  cam.GetInstanceID())) != false)
        {
                return;
        }
        
        this.guidsToCameras.Add(key:  cam.GetInstanceID(), value:  cam);
    }
    public void RemoveCamera(CameraOperatorUGUI cam)
    {
        System.Collections.Generic.Dictionary<System.Int32, CameraOperatorUGUI> val_6;
        var val_7;
        val_6 = 1152921504884269056;
        val_7 = null;
        val_7 = null;
        if(App.isQuitting == true)
        {
                return;
        }
        
        if(cam == 0)
        {
                return;
        }
        
        val_6 = this.guidsToCameras;
        if((val_6.ContainsKey(key:  cam.GetInstanceID())) == false)
        {
                return;
        }
        
        bool val_5 = this.guidsToCameras.Remove(key:  cam.GetInstanceID());
    }
    public void TakeCameraStateSnapshot()
    {
        var val_15;
        null = null;
        if(App.isQuitting == true)
        {
                return;
        }
        
        System.Collections.Generic.Dictionary<System.Int32, System.Boolean> val_1 = new System.Collections.Generic.Dictionary<System.Int32, System.Boolean>();
        val_15 = System.Linq.Enumerable.ToList<CameraOperatorUGUI>(source:  this.guidsToCameras.Values);
        if(1152921515527767808 < 1)
        {
            goto label_9;
        }
        
        var val_16 = 4;
        label_32:
        if(0 >= 1152921515527767808)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if("create" == 0)
        {
            goto label_13;
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        if((UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 32.gameObject) != 0)
        {
            goto label_18;
        }
        
        label_13:
        if(0 >= null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        UnityEngine.Debug.LogError(message:  "Trying to remove " + UnityEngine.Object.__il2cppRuntimeField_byval_arg.GetInstanceID().ToString() + " because it wasn\'t properly removed.");
        if(0 >= null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        bool val_11 = this.guidsToCameras.Remove(key:  UnityEngine.Debug.__il2cppRuntimeField_byval_arg.GetInstanceID());
        goto label_26;
        label_18:
        if(0 >= null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(0 >= null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_1.Add(key:  UnityEngine.Object.__il2cppRuntimeField_byval_arg.GetInstanceID(), value:  UnityEngine.Object.__il2cppRuntimeField_byval_arg.IsCameraActive());
        label_26:
        val_16 = val_16 + 1;
        if((val_16 - 3) < 1152921515527789568)
        {
            goto label_32;
        }
        
        label_9:
        this.cameraSnapshotQueue.Push(item:  val_1);
    }
    public void RestoreCameraStateSnapshot()
    {
        var val_17;
        var val_19;
        val_17 = null;
        val_17 = null;
        if(App.isQuitting != false)
        {
                return;
        }
        
        if(App.isQuitting == false)
        {
                return;
        }
        
        System.Collections.Generic.Dictionary<System.Int32, System.Boolean> val_1 = this.cameraSnapshotQueue.Pop();
        if(val_1 == null)
        {
                return;
        }
        
        if(val_1.Count < 1)
        {
                return;
        }
        
        System.Collections.Generic.List<TSource> val_4 = System.Linq.Enumerable.ToList<CameraOperatorUGUI>(source:  this.guidsToCameras.Values);
        if(1152921515527767808 < 1)
        {
                return;
        }
        
        var val_19 = 4;
        goto label_39;
        label_31:
        if(X25 >= 1152921515527767808)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((val_1.ContainsKey(key:  GetInstanceID())) == false)
        {
            goto label_22;
        }
        
        if(X25 >= 1152921515527967104)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_19 = X9 + 32;
        if(1152921515527967104 <= X25)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_19 = null;
        }
        
        int val_18 = GetInstanceID();
        val_18 = val_1.Item[val_18];
        X9 + 32.SetCameraState(active:  val_18);
        goto label_22;
        label_39:
        if(0 >= 1152921515527767808)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if("create" == 0)
        {
            goto label_26;
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        if((UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 32.gameObject) != 0)
        {
            goto label_31;
        }
        
        label_26:
        if(0 >= null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        UnityEngine.Debug.LogError(message:  "Trying to remove " + UnityEngine.Object.__il2cppRuntimeField_byval_arg.GetInstanceID().ToString() + " because it wasn\'t properly removed.");
        if(0 >= null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        bool val_16 = this.guidsToCameras.Remove(key:  UnityEngine.Debug.__il2cppRuntimeField_byval_arg.GetInstanceID());
        label_22:
        val_19 = val_19 + 1;
        if((val_19 - 3) < null)
        {
            goto label_39;
        }
    
    }
    public void DisableSnapshottedCameras()
    {
        if(true == 0)
        {
                return;
        }
        
        System.Collections.Generic.Dictionary<System.Int32, System.Boolean> val_1 = this.cameraSnapshotQueue.Peek();
        if(val_1 == null)
        {
                return;
        }
        
        if(val_1.Count < 1)
        {
                return;
        }
        
        System.Collections.Generic.List<TSource> val_4 = System.Linq.Enumerable.ToList<CameraOperatorUGUI>(source:  this.guidsToCameras.Values);
        if(1152921515527767808 < 1)
        {
                return;
        }
        
        var val_16 = 4;
        goto label_31;
        label_23:
        if(X25 >= 1152921515527767808)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((val_1.ContainsKey(key:  GetInstanceID())) == false)
        {
            goto label_14;
        }
        
        if(X25 >= 1152921515527967104)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        SetCameraState(active:  false);
        goto label_14;
        label_31:
        if(0 >= 1152921515527767808)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if("create" == 0)
        {
            goto label_18;
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        if((UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 32.gameObject) != 0)
        {
            goto label_23;
        }
        
        label_18:
        if(0 >= null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        UnityEngine.Debug.LogError(message:  "Trying to remove " + UnityEngine.Object.__il2cppRuntimeField_byval_arg.GetInstanceID().ToString() + " because it wasn\'t properly removed.");
        if(0 >= null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        bool val_14 = this.guidsToCameras.Remove(key:  UnityEngine.Debug.__il2cppRuntimeField_byval_arg.GetInstanceID());
        label_14:
        val_16 = val_16 + 1;
        if((val_16 - 3) < null)
        {
            goto label_31;
        }
    
    }
    public CameraManagerUGUI()
    {
        this.guidsToCameras = new System.Collections.Generic.Dictionary<System.Int32, CameraOperatorUGUI>();
        this.cameraSnapshotQueue = new System.Collections.Generic.Stack<System.Collections.Generic.Dictionary<System.Int32, System.Boolean>>();
    }

}
