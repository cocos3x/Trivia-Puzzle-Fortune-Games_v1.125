using UnityEngine;

namespace AudienceNetwork
{
    public sealed class AdView : IDisposable
    {
        // Fields
        private readonly int uniqueId;
        private bool isLoaded;
        private readonly AudienceNetwork.AdSize size;
        private AudienceNetwork.AdHandler handler;
        private string <PlacementId>k__BackingField;
        public AudienceNetwork.FBAdViewBridgeCallback adViewDidLoad;
        public AudienceNetwork.FBAdViewBridgeCallback adViewWillLogImpression;
        public AudienceNetwork.FBAdViewBridgeErrorCallback adViewDidFailWithError;
        public AudienceNetwork.FBAdViewBridgeCallback adViewDidClick;
        public AudienceNetwork.FBAdViewBridgeCallback adViewDidFinishClick;
        
        // Properties
        public string PlacementId { get; set; }
        internal AudienceNetwork.FBAdViewBridgeCallback AdViewDidLoad { get; set; }
        internal AudienceNetwork.FBAdViewBridgeCallback AdViewWillLogImpression { get; set; }
        internal AudienceNetwork.FBAdViewBridgeErrorCallback AdViewDidFailWithError { get; set; }
        internal AudienceNetwork.FBAdViewBridgeCallback AdViewDidClick { get; set; }
        internal AudienceNetwork.FBAdViewBridgeCallback AdViewDidFinishClick { get; set; }
        
        // Methods
        public string get_PlacementId()
        {
            return (string)this.<PlacementId>k__BackingField;
        }
        private void set_PlacementId(string value)
        {
            this.<PlacementId>k__BackingField = value;
        }
        internal AudienceNetwork.FBAdViewBridgeCallback get_AdViewDidLoad()
        {
            return (AudienceNetwork.FBAdViewBridgeCallback)this.adViewDidLoad;
        }
        public void set_AdViewDidLoad(AudienceNetwork.FBAdViewBridgeCallback value)
        {
            AudienceNetwork.FBAdViewBridgeCallback val_2;
            var val_3;
            val_2 = value;
            this.adViewDidLoad = val_2;
            val_3 = null;
            val_3 = null;
            val_2 = this.adViewDidLoad;
            var val_2 = 0;
            val_2 = val_2 + 1;
            AudienceNetwork.AdViewBridge.Instance.OnLoad(uniqueId:  this.uniqueId, callback:  val_2);
        }
        internal AudienceNetwork.FBAdViewBridgeCallback get_AdViewWillLogImpression()
        {
            return (AudienceNetwork.FBAdViewBridgeCallback)this.adViewWillLogImpression;
        }
        public void set_AdViewWillLogImpression(AudienceNetwork.FBAdViewBridgeCallback value)
        {
            AudienceNetwork.FBAdViewBridgeCallback val_2;
            var val_3;
            val_2 = value;
            this.adViewWillLogImpression = val_2;
            val_3 = null;
            val_3 = null;
            val_2 = this.adViewWillLogImpression;
            var val_2 = 0;
            val_2 = val_2 + 1;
            AudienceNetwork.AdViewBridge.Instance.OnImpression(uniqueId:  this.uniqueId, callback:  val_2);
        }
        internal AudienceNetwork.FBAdViewBridgeErrorCallback get_AdViewDidFailWithError()
        {
            return (AudienceNetwork.FBAdViewBridgeErrorCallback)this.adViewDidFailWithError;
        }
        public void set_AdViewDidFailWithError(AudienceNetwork.FBAdViewBridgeErrorCallback value)
        {
            AudienceNetwork.FBAdViewBridgeErrorCallback val_2;
            var val_3;
            val_2 = value;
            this.adViewDidFailWithError = val_2;
            val_3 = null;
            val_3 = null;
            val_2 = this.adViewDidFailWithError;
            var val_2 = 0;
            val_2 = val_2 + 1;
            AudienceNetwork.AdViewBridge.Instance.OnError(uniqueId:  this.uniqueId, callback:  val_2);
        }
        internal AudienceNetwork.FBAdViewBridgeCallback get_AdViewDidClick()
        {
            return (AudienceNetwork.FBAdViewBridgeCallback)this.adViewDidClick;
        }
        public void set_AdViewDidClick(AudienceNetwork.FBAdViewBridgeCallback value)
        {
            AudienceNetwork.FBAdViewBridgeCallback val_2;
            var val_3;
            val_2 = value;
            this.adViewDidClick = val_2;
            val_3 = null;
            val_3 = null;
            val_2 = this.adViewDidClick;
            var val_2 = 0;
            val_2 = val_2 + 1;
            AudienceNetwork.AdViewBridge.Instance.OnClick(uniqueId:  this.uniqueId, callback:  val_2);
        }
        internal AudienceNetwork.FBAdViewBridgeCallback get_AdViewDidFinishClick()
        {
            return (AudienceNetwork.FBAdViewBridgeCallback)this.adViewDidFinishClick;
        }
        public void set_AdViewDidFinishClick(AudienceNetwork.FBAdViewBridgeCallback value)
        {
            AudienceNetwork.FBAdViewBridgeCallback val_2;
            var val_3;
            val_2 = value;
            this.adViewDidFinishClick = val_2;
            val_3 = null;
            val_3 = null;
            val_2 = this.adViewDidFinishClick;
            var val_2 = 0;
            val_2 = val_2 + 1;
            AudienceNetwork.AdViewBridge.Instance.OnFinishedClick(uniqueId:  this.uniqueId, callback:  val_2);
        }
        public AdView(string placementId, AudienceNetwork.AdSize size)
        {
            var val_8;
            AudienceNetwork.AudienceNetworkAds.Initialize();
            this.<PlacementId>k__BackingField = placementId;
            this.size = size;
            if(UnityEngine.Application.platform == 0)
            {
                    return;
            }
            
            val_8 = null;
            val_8 = null;
            var val_9 = 0;
            val_9 = val_9 + 1;
            int val_3 = AudienceNetwork.AdViewBridge.Instance.Create(placementId:  placementId, adView:  this, size:  size);
            this.uniqueId = val_3;
            var val_10 = 0;
            val_10 = val_10 + 1;
            AudienceNetwork.AdViewBridge.Instance.OnLoad(uniqueId:  val_3, callback:  this.adViewDidLoad);
            var val_11 = 0;
            val_11 = val_11 + 1;
            AudienceNetwork.AdViewBridge.Instance.OnImpression(uniqueId:  this.uniqueId, callback:  this.adViewWillLogImpression);
            var val_12 = 0;
            val_12 = val_12 + 1;
            AudienceNetwork.AdViewBridge.Instance.OnClick(uniqueId:  this.uniqueId, callback:  this.adViewDidClick);
            var val_13 = 0;
            val_13 = val_13 + 1;
            AudienceNetwork.AdViewBridge.Instance.OnError(uniqueId:  this.uniqueId, callback:  this.adViewDidFailWithError);
            var val_14 = 0;
            val_14 = val_14 + 1;
            AudienceNetwork.AdViewBridge.Instance.OnFinishedClick(uniqueId:  this.uniqueId, callback:  this.adViewDidFinishClick);
        }
        protected override void Finalize()
        {
            this.Dispose(iAmBeingCalledFromDisposeAndNotFinalize:  false);
            this.Finalize();
        }
        public void Dispose()
        {
            this.Dispose(iAmBeingCalledFromDisposeAndNotFinalize:  false);
            System.GC.SuppressFinalize(obj:  this);
        }
        private void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
            var val_2;
            UnityEngine.Debug.Log(message:  "Banner Ad Disposed.");
            val_2 = null;
            val_2 = null;
            var val_2 = 0;
            val_2 = val_2 + 1;
            AudienceNetwork.AdViewBridge.Instance.Release(uniqueId:  this.uniqueId);
        }
        public override string ToString()
        {
            int val_2;
            object[] val_1 = new object[6];
            val_2 = val_1.Length;
            val_1[0] = this.<PlacementId>k__BackingField;
            if(this.adViewDidLoad != null)
            {
                    val_2 = val_1.Length;
            }
            
            val_1[1] = this.adViewDidLoad;
            if(this.adViewWillLogImpression != null)
            {
                    val_2 = val_1.Length;
            }
            
            val_1[2] = this.adViewWillLogImpression;
            if(this.adViewDidFailWithError != null)
            {
                    val_2 = val_1.Length;
            }
            
            val_1[3] = this.adViewDidFailWithError;
            if(this.adViewDidClick != null)
            {
                    val_2 = val_1.Length;
            }
            
            val_1[4] = this.adViewDidClick;
            if(this.adViewDidFinishClick != null)
            {
                    val_2 = val_1.Length;
            }
            
            val_1[5] = this.adViewDidFinishClick;
            return System.String.Format(format:  "[AdView: PlacementId={0}, AdViewDidLoad={1}, AdViewWillLogImpression={2}, AdViewDidFailWithError={3}, AdViewDidClick={4}, adViewDidFinishClick={5}]", args:  val_1);
        }
        public void Register(UnityEngine.GameObject gameObject)
        {
            this.handler = gameObject.AddComponent<AudienceNetwork.AdHandler>();
        }
        public void LoadAd()
        {
            var val_3;
            if(UnityEngine.Application.platform != 0)
            {
                    val_3 = null;
                val_3 = null;
                var val_4 = 0;
                val_4 = val_4 + 1;
            }
            else
            {
                    this.adViewDidLoad.Invoke();
                return;
            }
            
            int val_3 = AudienceNetwork.AdViewBridge.Instance.Load(uniqueId:  this.uniqueId);
        }
        public void LoadAd(string bidPayload)
        {
            var val_3;
            if(UnityEngine.Application.platform != 0)
            {
                    val_3 = null;
                val_3 = null;
                var val_4 = 0;
                val_4 = val_4 + 1;
            }
            else
            {
                    this.adViewDidLoad.Invoke();
                return;
            }
            
            int val_3 = AudienceNetwork.AdViewBridge.Instance.Load(uniqueId:  this.uniqueId, bidPayload:  bidPayload);
        }
        public bool IsValid()
        {
            var val_3;
            var val_5;
            if(UnityEngine.Application.platform == 0)
            {
                goto label_1;
            }
            
            if(this.isLoaded == false)
            {
                goto label_2;
            }
            
            val_3 = null;
            val_3 = null;
            var val_3 = 0;
            val_3 = val_3 + 1;
            return AudienceNetwork.AdViewBridge.Instance.IsValid(uniqueId:  this.uniqueId);
            label_1:
            val_5 = 1;
            return (bool)val_5;
            label_2:
            val_5 = 0;
            return (bool)val_5;
        }
        internal void LoadAdFromData()
        {
            this.isLoaded = true;
            if(this.adViewDidLoad == null)
            {
                    return;
            }
            
            this.handler.ExecuteOnMainThread(action:  new System.Action(object:  this, method:  System.Void AudienceNetwork.AdView::<LoadAdFromData>b__37_0()));
        }
        private static double HeightFromType(AudienceNetwork.AdView instance, AudienceNetwork.AdSize size)
        {
            if(size > 2)
            {
                    return 0;
            }
            
            return (double)32564208 + (size) << 3;
        }
        public bool Show(AudienceNetwork.AdPosition position)
        {
            double val_3;
            float val_4;
            val_3 = 0;
            if(position != 0)
            {
                    if(position != 2)
            {
                    return this.Show(x:  0, y:  val_3);
            }
            
                val_4 = 0;
                if(this.size <= 2)
            {
                    val_4 = mem[32564208 + (this.size) << 3];
                val_4 = 32564208 + (this.size) << 3;
            }
            
                val_3 = AudienceNetwork.Utility.AdUtility.Height() - val_4;
                return this.Show(x:  0, y:  val_3);
            }
            
            UnityEngine.Debug.LogWarning(message:  "Use Show(double y) instead");
            return this.Show(x:  0, y:  val_3);
        }
        public bool Show(double y)
        {
            return this.Show(x:  0, y:  y);
        }
        public bool Show(double x, double y)
        {
            if(this.size > 2)
            {
                    return this.Show(x:  x, y:  y, width:  AudienceNetwork.Utility.AdUtility.Width(), height:  32564208 + (this.size) << 3);
            }
            
            return this.Show(x:  x, y:  y, width:  AudienceNetwork.Utility.AdUtility.Width(), height:  32564208 + (this.size) << 3);
        }
        private bool Show(double x, double y, double width, double height)
        {
            var val_2 = null;
            var val_2 = 0;
            val_2 = val_2 + 1;
            return AudienceNetwork.AdViewBridge.Instance.Show(uniqueId:  this.uniqueId, x:  x, y:  y, width:  width, height:  height);
        }
        public void SetExtraHints(AudienceNetwork.ExtraHints extraHints)
        {
            var val_2 = null;
            var val_2 = 0;
            val_2 = val_2 + 1;
            AudienceNetwork.AdViewBridge.Instance.SetExtraHints(uniqueId:  this.uniqueId, extraHints:  extraHints);
        }
        internal void ExecuteOnMainThread(System.Action action)
        {
            if((UnityEngine.Object.op_Implicit(exists:  this.handler)) == false)
            {
                    return;
            }
            
            this.handler.ExecuteOnMainThread(action:  action);
        }
        public static bool op_Implicit(AudienceNetwork.AdView obj)
        {
            return (bool)(obj != 0) ? 1 : 0;
        }
        private void <LoadAdFromData>b__37_0()
        {
            if(this.adViewDidLoad != null)
            {
                    this.adViewDidLoad.Invoke();
                return;
            }
            
            throw new NullReferenceException();
        }
    
    }

}
