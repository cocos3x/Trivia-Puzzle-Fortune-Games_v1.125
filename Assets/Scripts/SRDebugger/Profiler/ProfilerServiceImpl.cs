using UnityEngine;

namespace SRDebugger.Profiler
{
    public class ProfilerServiceImpl : SRServiceBase<SRDebugger.Services.IProfilerService>, IProfilerService
    {
        // Fields
        private const int FrameBufferSize = 400;
        private readonly SRF.SRList<SRDebugger.Profiler.ProfilerCameraListener> _cameraListeners;
        private readonly SRDebugger.CircularBuffer<SRDebugger.Services.ProfilerFrame> _frameBuffer;
        private UnityEngine.Camera[] _cameraCache;
        private SRDebugger.Profiler.ProfilerLateUpdateListener _lateUpdateListener;
        private double _renderDuration;
        private int _reportedCameras;
        private System.Diagnostics.Stopwatch _stopwatch;
        private double _updateDuration;
        private double _updateToRenderDuration;
        private float <AverageFrameTime>k__BackingField;
        private float <LastFrameTime>k__BackingField;
        
        // Properties
        public float AverageFrameTime { get; set; }
        public float LastFrameTime { get; set; }
        public SRDebugger.CircularBuffer<SRDebugger.Services.ProfilerFrame> FrameBuffer { get; }
        
        // Methods
        public float get_AverageFrameTime()
        {
            return (float)this.<AverageFrameTime>k__BackingField;
        }
        private void set_AverageFrameTime(float value)
        {
            this.<AverageFrameTime>k__BackingField = value;
        }
        public float get_LastFrameTime()
        {
            return (float)this.<LastFrameTime>k__BackingField;
        }
        private void set_LastFrameTime(float value)
        {
            this.<LastFrameTime>k__BackingField = value;
        }
        public SRDebugger.CircularBuffer<SRDebugger.Services.ProfilerFrame> get_FrameBuffer()
        {
            return (SRDebugger.CircularBuffer<SRDebugger.Services.ProfilerFrame>)this._frameBuffer;
        }
        protected void PushFrame(double totalTime, double updateTime, double renderTime)
        {
            totalTime = totalTime - updateTime;
            updateTime = totalTime - renderTime;
            this._frameBuffer.PushBack(item:  new SRDebugger.Services.ProfilerFrame());
        }
        protected override void Awake()
        {
            this.Awake();
            this._lateUpdateListener = this.gameObject.AddComponent<SRDebugger.Profiler.ProfilerLateUpdateListener>();
            val_2.OnLateUpdate = new System.Action(object:  this, method:  System.Void SRDebugger.Profiler.ProfilerServiceImpl::OnLateUpdate());
            this.CachedGameObject.hideFlags = 8;
            this.CachedTransform.SetParent(parent:  SRF.Hierarchy.Get(key:  "SRDebugger"), worldPositionStays:  true);
        }
        protected override void Update()
        {
            var val_6;
            float val_7;
            this.Update();
            if(true >= 1)
            {
                    SRDebugger.Services.ProfilerFrame val_1 = this._frameBuffer.Back();
                val_6 = V1.16B;
                float val_2 = UnityEngine.Time.deltaTime;
                this._frameBuffer.set_Item(index:  2087460831, value:  new SRDebugger.Services.ProfilerFrame());
            }
            
            float val_3 = UnityEngine.Time.deltaTime;
            this.<LastFrameTime>k__BackingField = val_3;
            int val_4 = UnityEngine.Mathf.Min(a:  20, b:  41971712);
            if(val_4 >= 1)
            {
                    var val_6 = 0;
                do
            {
                SRDebugger.Services.ProfilerFrame val_5 = this._frameBuffer.Item[0];
                val_6 = val_6 + 1;
                val_6 = 0 + val_3;
            }
            while(val_6 < val_4);
            
                val_7 = (float)val_6;
            }
            else
            {
                    val_7 = 0f;
            }
            
            val_7 = val_7 / (float)val_4;
            this.<AverageFrameTime>k__BackingField = val_7;
            if(this._stopwatch.is_running != false)
            {
                    this._stopwatch.Stop();
                this._stopwatch.Reset();
            }
            
            this._renderDuration = 0;
            this._reportedCameras = 0;
            this._updateDuration = 0;
            this._updateToRenderDuration = 0;
            this.CameraCheck();
            this._stopwatch.Start();
        }
        private void OnLateUpdate()
        {
            System.TimeSpan val_1 = this._stopwatch.Elapsed;
            this._updateDuration = val_1._ticks.TotalSeconds;
        }
        private void EndFrame()
        {
            if(this._stopwatch.is_running == false)
            {
                    return;
            }
            
            System.TimeSpan val_1 = this._stopwatch.Elapsed;
            this.PushFrame(totalTime:  val_1._ticks.TotalSeconds, updateTime:  this._updateDuration, renderTime:  this._renderDuration);
            this._stopwatch.Reset();
            this._stopwatch.Start();
        }
        private void CameraDurationCallback(SRDebugger.Profiler.ProfilerCameraListener listener, double duration)
        {
            int val_4 = this._reportedCameras;
            val_4 = val_4 + 1;
            this._reportedCameras = val_4;
            System.TimeSpan val_1 = this._stopwatch.Elapsed;
            double val_2 = val_1._ticks.TotalSeconds;
            val_2 = val_2 - this._updateDuration;
            val_2 = val_2 - this._updateToRenderDuration;
            this._renderDuration = val_2;
            if(this._reportedCameras < this.GetExpectedCameraCount())
            {
                    return;
            }
            
            this.EndFrame();
        }
        private int GetExpectedCameraCount()
        {
            var val_8;
            var val_9;
            val_8 = 0;
            val_9 = 0;
            label_13:
            if(val_9 >= true)
            {
                    return (int)val_8;
            }
            
            if(this._cameraListeners.Item[0] != 0)
            {
                    if((this._cameraListeners.Item[0].isActiveAndEnabled == false) || (this._cameraListeners.Item[0].Camera.isActiveAndEnabled == false))
            {
                goto label_12;
            }
            
            }
            
            val_8 = val_8 + 1;
            label_12:
            val_9 = val_9 + 1;
            if(this._cameraListeners != null)
            {
                goto label_13;
            }
            
            throw new NullReferenceException();
        }
        private void CameraCheck()
        {
            var val_14;
            UnityEngine.Object val_15;
            UnityEngine.Camera[] val_16;
            var val_14 = 0;
            if(<0)
            {
                goto label_7;
            }
            
            val_14 = 1152921504765632512;
            label_8:
            val_15 = this._cameraListeners.Item[0];
            if(val_15 == 0)
            {
                    this._cameraListeners.RemoveAt(index:  0);
            }
            
            val_14 = val_14 - 1;
            if(>=0)
            {
                    if(this._cameraListeners != null)
            {
                goto label_8;
            }
            
            }
            
            label_7:
            if(UnityEngine.Camera.allCamerasCount == this._cameraListeners)
            {
                    return;
            }
            
            val_16 = this._cameraCache;
            if(UnityEngine.Camera.allCamerasCount > this._cameraCache.Length)
            {
                    int val_5 = UnityEngine.Camera.allCamerasCount;
                UnityEngine.Camera[] val_6 = new UnityEngine.Camera[0];
                val_16 = val_6;
                this._cameraCache = val_6;
            }
            
            int val_7 = UnityEngine.Camera.GetAllCameras(cameras:  val_6);
            if(val_7 < 1)
            {
                    return;
            }
            
            label_29:
            UnityEngine.Camera val_15 = this._cameraCache[0];
            val_15 = 0;
            label_23:
            if(val_15 >= this._cameraCache[0])
            {
                goto label_18;
            }
            
            if(this._cameraListeners.Item[0].Camera == val_15)
            {
                goto label_22;
            }
            
            val_15 = val_15 + 1;
            if(this._cameraListeners != null)
            {
                goto label_23;
            }
            
            label_18:
            SRDebugger.Profiler.ProfilerCameraListener val_12 = val_15.gameObject.AddComponent<SRDebugger.Profiler.ProfilerCameraListener>();
            val_12.hideFlags = 60;
            System.Action<SRDebugger.Profiler.ProfilerCameraListener, System.Double> val_13 = null;
            val_15 = val_13;
            val_13 = new System.Action<SRDebugger.Profiler.ProfilerCameraListener, System.Double>(object:  this, method:  System.Void SRDebugger.Profiler.ProfilerServiceImpl::CameraDurationCallback(SRDebugger.Profiler.ProfilerCameraListener listener, double duration));
            val_12.RenderDurationCallback = val_15;
            this._cameraListeners.Add(item:  val_12);
            label_22:
            val_14 = 0 + 1;
            if(val_14 < (long)val_7)
            {
                goto label_29;
            }
        
        }
        public ProfilerServiceImpl()
        {
            this._cameraListeners = new SRF.SRList<SRDebugger.Profiler.ProfilerCameraListener>();
            this._frameBuffer = new SRDebugger.CircularBuffer<SRDebugger.Services.ProfilerFrame>(capacity:  144);
            this._cameraCache = new UnityEngine.Camera[6];
            this._stopwatch = new System.Diagnostics.Stopwatch();
        }
    
    }

}
