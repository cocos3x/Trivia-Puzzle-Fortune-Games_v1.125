using UnityEngine;

namespace AudienceNetwork
{
    public sealed class InterstitialAd : IDisposable
    {
        // Fields
        private readonly int uniqueId;
        private bool isLoaded;
        private AudienceNetwork.AdHandler handler;
        private string <PlacementId>k__BackingField;
        public AudienceNetwork.FBInterstitialAdBridgeCallback interstitialAdDidLoad;
        public AudienceNetwork.FBInterstitialAdBridgeCallback interstitialAdWillLogImpression;
        public AudienceNetwork.FBInterstitialAdBridgeErrorCallback interstitialAdDidFailWithError;
        public AudienceNetwork.FBInterstitialAdBridgeCallback interstitialAdDidClick;
        public AudienceNetwork.FBInterstitialAdBridgeCallback interstitialAdWillClose;
        public AudienceNetwork.FBInterstitialAdBridgeCallback interstitialAdDidClose;
        public AudienceNetwork.FBInterstitialAdBridgeCallback interstitialAdActivityDestroyed;
        
        // Properties
        public string PlacementId { get; set; }
        internal AudienceNetwork.FBInterstitialAdBridgeCallback InterstitialAdDidLoad { get; set; }
        internal AudienceNetwork.FBInterstitialAdBridgeCallback InterstitialAdWillLogImpression { get; set; }
        internal AudienceNetwork.FBInterstitialAdBridgeErrorCallback InterstitialAdDidFailWithError { get; set; }
        internal AudienceNetwork.FBInterstitialAdBridgeCallback InterstitialAdDidClick { get; set; }
        internal AudienceNetwork.FBInterstitialAdBridgeCallback InterstitialAdWillClose { get; set; }
        internal AudienceNetwork.FBInterstitialAdBridgeCallback InterstitialAdDidClose { get; set; }
        internal AudienceNetwork.FBInterstitialAdBridgeCallback InterstitialAdActivityDestroyed { get; set; }
        
        // Methods
        public string get_PlacementId()
        {
            return (string)this.<PlacementId>k__BackingField;
        }
        private void set_PlacementId(string value)
        {
            this.<PlacementId>k__BackingField = value;
        }
        internal AudienceNetwork.FBInterstitialAdBridgeCallback get_InterstitialAdDidLoad()
        {
            return (AudienceNetwork.FBInterstitialAdBridgeCallback)this.interstitialAdDidLoad;
        }
        public void set_InterstitialAdDidLoad(AudienceNetwork.FBInterstitialAdBridgeCallback value)
        {
            AudienceNetwork.FBInterstitialAdBridgeCallback val_2;
            var val_3;
            val_2 = value;
            this.interstitialAdDidLoad = val_2;
            val_3 = null;
            val_3 = null;
            val_2 = this.interstitialAdDidLoad;
            var val_2 = 0;
            val_2 = val_2 + 1;
            AudienceNetwork.InterstitialAdBridge.Instance.OnLoad(uniqueId:  this.uniqueId, callback:  val_2);
        }
        internal AudienceNetwork.FBInterstitialAdBridgeCallback get_InterstitialAdWillLogImpression()
        {
            return (AudienceNetwork.FBInterstitialAdBridgeCallback)this.interstitialAdWillLogImpression;
        }
        public void set_InterstitialAdWillLogImpression(AudienceNetwork.FBInterstitialAdBridgeCallback value)
        {
            AudienceNetwork.FBInterstitialAdBridgeCallback val_2;
            var val_3;
            val_2 = value;
            this.interstitialAdWillLogImpression = val_2;
            val_3 = null;
            val_3 = null;
            val_2 = this.interstitialAdWillLogImpression;
            var val_2 = 0;
            val_2 = val_2 + 1;
            AudienceNetwork.InterstitialAdBridge.Instance.OnImpression(uniqueId:  this.uniqueId, callback:  val_2);
        }
        internal AudienceNetwork.FBInterstitialAdBridgeErrorCallback get_InterstitialAdDidFailWithError()
        {
            return (AudienceNetwork.FBInterstitialAdBridgeErrorCallback)this.interstitialAdDidFailWithError;
        }
        public void set_InterstitialAdDidFailWithError(AudienceNetwork.FBInterstitialAdBridgeErrorCallback value)
        {
            AudienceNetwork.FBInterstitialAdBridgeErrorCallback val_2;
            var val_3;
            val_2 = value;
            this.interstitialAdDidFailWithError = val_2;
            val_3 = null;
            val_3 = null;
            val_2 = this.interstitialAdDidFailWithError;
            var val_2 = 0;
            val_2 = val_2 + 1;
            AudienceNetwork.InterstitialAdBridge.Instance.OnError(uniqueId:  this.uniqueId, callback:  val_2);
        }
        internal AudienceNetwork.FBInterstitialAdBridgeCallback get_InterstitialAdDidClick()
        {
            return (AudienceNetwork.FBInterstitialAdBridgeCallback)this.interstitialAdDidClick;
        }
        public void set_InterstitialAdDidClick(AudienceNetwork.FBInterstitialAdBridgeCallback value)
        {
            AudienceNetwork.FBInterstitialAdBridgeCallback val_2;
            var val_3;
            val_2 = value;
            this.interstitialAdDidClick = val_2;
            val_3 = null;
            val_3 = null;
            val_2 = this.interstitialAdDidClick;
            var val_2 = 0;
            val_2 = val_2 + 1;
            AudienceNetwork.InterstitialAdBridge.Instance.OnClick(uniqueId:  this.uniqueId, callback:  val_2);
        }
        internal AudienceNetwork.FBInterstitialAdBridgeCallback get_InterstitialAdWillClose()
        {
            return (AudienceNetwork.FBInterstitialAdBridgeCallback)this.interstitialAdWillClose;
        }
        public void set_InterstitialAdWillClose(AudienceNetwork.FBInterstitialAdBridgeCallback value)
        {
            AudienceNetwork.FBInterstitialAdBridgeCallback val_2;
            var val_3;
            val_2 = value;
            this.interstitialAdWillClose = val_2;
            val_3 = null;
            val_3 = null;
            val_2 = this.interstitialAdWillClose;
            var val_2 = 0;
            val_2 = val_2 + 1;
            AudienceNetwork.InterstitialAdBridge.Instance.OnWillClose(uniqueId:  this.uniqueId, callback:  val_2);
        }
        internal AudienceNetwork.FBInterstitialAdBridgeCallback get_InterstitialAdDidClose()
        {
            return (AudienceNetwork.FBInterstitialAdBridgeCallback)this.interstitialAdDidClose;
        }
        public void set_InterstitialAdDidClose(AudienceNetwork.FBInterstitialAdBridgeCallback value)
        {
            AudienceNetwork.FBInterstitialAdBridgeCallback val_2;
            var val_3;
            val_2 = value;
            this.interstitialAdDidClose = val_2;
            val_3 = null;
            val_3 = null;
            val_2 = this.interstitialAdDidClose;
            var val_2 = 0;
            val_2 = val_2 + 1;
            AudienceNetwork.InterstitialAdBridge.Instance.OnDidClose(uniqueId:  this.uniqueId, callback:  val_2);
        }
        internal AudienceNetwork.FBInterstitialAdBridgeCallback get_InterstitialAdActivityDestroyed()
        {
            return (AudienceNetwork.FBInterstitialAdBridgeCallback)this.interstitialAdActivityDestroyed;
        }
        public void set_InterstitialAdActivityDestroyed(AudienceNetwork.FBInterstitialAdBridgeCallback value)
        {
            AudienceNetwork.FBInterstitialAdBridgeCallback val_2;
            var val_3;
            val_2 = value;
            this.interstitialAdActivityDestroyed = val_2;
            val_3 = null;
            val_3 = null;
            val_2 = this.interstitialAdActivityDestroyed;
            var val_2 = 0;
            val_2 = val_2 + 1;
            AudienceNetwork.InterstitialAdBridge.Instance.OnActivityDestroyed(uniqueId:  this.uniqueId, callback:  val_2);
        }
        public InterstitialAd(string placementId)
        {
            var val_10;
            AudienceNetwork.AudienceNetworkAds.Initialize();
            this.<PlacementId>k__BackingField = placementId;
            if(UnityEngine.Application.platform == 0)
            {
                    return;
            }
            
            val_10 = null;
            val_10 = null;
            var val_11 = 0;
            val_11 = val_11 + 1;
            int val_3 = AudienceNetwork.InterstitialAdBridge.Instance.Create(placementId:  placementId, interstitialAd:  this);
            this.uniqueId = val_3;
            var val_12 = 0;
            val_12 = val_12 + 1;
            AudienceNetwork.InterstitialAdBridge.Instance.OnLoad(uniqueId:  val_3, callback:  this.interstitialAdDidLoad);
            var val_13 = 0;
            val_13 = val_13 + 1;
            AudienceNetwork.InterstitialAdBridge.Instance.OnImpression(uniqueId:  this.uniqueId, callback:  this.interstitialAdWillLogImpression);
            var val_14 = 0;
            val_14 = val_14 + 1;
            AudienceNetwork.InterstitialAdBridge.Instance.OnClick(uniqueId:  this.uniqueId, callback:  this.interstitialAdDidClick);
            var val_15 = 0;
            val_15 = val_15 + 1;
            AudienceNetwork.InterstitialAdBridge.Instance.OnError(uniqueId:  this.uniqueId, callback:  this.interstitialAdDidFailWithError);
            var val_16 = 0;
            val_16 = val_16 + 1;
            AudienceNetwork.InterstitialAdBridge.Instance.OnWillClose(uniqueId:  this.uniqueId, callback:  this.interstitialAdWillClose);
            var val_17 = 0;
            val_17 = val_17 + 1;
            AudienceNetwork.InterstitialAdBridge.Instance.OnDidClose(uniqueId:  this.uniqueId, callback:  this.interstitialAdDidClose);
            var val_18 = 0;
            val_18 = val_18 + 1;
            AudienceNetwork.InterstitialAdBridge.Instance.OnActivityDestroyed(uniqueId:  this.uniqueId, callback:  this.interstitialAdActivityDestroyed);
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
            UnityEngine.Debug.Log(message:  "Interstitial Ad Disposed.");
            val_2 = null;
            val_2 = null;
            var val_2 = 0;
            val_2 = val_2 + 1;
            AudienceNetwork.InterstitialAdBridge.Instance.Release(uniqueId:  this.uniqueId);
        }
        public override string ToString()
        {
            int val_2;
            object[] val_1 = new object[8];
            val_2 = val_1.Length;
            val_1[0] = this.<PlacementId>k__BackingField;
            if(this.interstitialAdDidLoad != null)
            {
                    val_2 = val_1.Length;
            }
            
            val_1[1] = this.interstitialAdDidLoad;
            if(this.interstitialAdWillLogImpression != null)
            {
                    val_2 = val_1.Length;
            }
            
            val_1[2] = this.interstitialAdWillLogImpression;
            if(this.interstitialAdDidFailWithError != null)
            {
                    val_2 = val_1.Length;
            }
            
            val_1[3] = this.interstitialAdDidFailWithError;
            if(this.interstitialAdDidClick != null)
            {
                    val_2 = val_1.Length;
            }
            
            val_1[4] = this.interstitialAdDidClick;
            if(this.interstitialAdWillClose != null)
            {
                    val_2 = val_1.Length;
            }
            
            val_1[5] = this.interstitialAdWillClose;
            if(this.interstitialAdDidClose != null)
            {
                    val_2 = val_1.Length;
            }
            
            val_1[6] = this.interstitialAdDidClose;
            if(this.interstitialAdActivityDestroyed != null)
            {
                    val_2 = val_1.Length;
            }
            
            val_1[7] = this.interstitialAdActivityDestroyed;
            return System.String.Format(format:  "[InterstitialAd: PlacementId={0}, InterstitialAdDidLoad={1}, InterstitialAdWillLogImpression={2}, InterstitialAdDidFailWithError={3}, InterstitialAdDidClick={4}, InterstitialAdWillClose={5}, InterstitialAdDidClose={6}], InterstitialAdActivityDestroyed={7}]", args:  val_1);
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
                    this.interstitialAdDidLoad.Invoke();
                return;
            }
            
            int val_3 = AudienceNetwork.InterstitialAdBridge.Instance.Load(uniqueId:  this.uniqueId);
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
                    this.interstitialAdDidLoad.Invoke();
                return;
            }
            
            int val_3 = AudienceNetwork.InterstitialAdBridge.Instance.Load(uniqueId:  this.uniqueId, bidPayload:  bidPayload);
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
            return AudienceNetwork.InterstitialAdBridge.Instance.IsValid(uniqueId:  this.uniqueId);
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
            if(this.interstitialAdDidLoad == null)
            {
                    return;
            }
            
            this.handler.ExecuteOnMainThread(action:  new System.Action(object:  this, method:  System.Void AudienceNetwork.InterstitialAd::<LoadAdFromData>b__44_0()));
        }
        public bool Show()
        {
            var val_2 = null;
            var val_2 = 0;
            val_2 = val_2 + 1;
            return AudienceNetwork.InterstitialAdBridge.Instance.Show(uniqueId:  this.uniqueId);
        }
        public void SetExtraHints(AudienceNetwork.ExtraHints extraHints)
        {
            var val_2 = null;
            var val_2 = 0;
            val_2 = val_2 + 1;
            AudienceNetwork.InterstitialAdBridge.Instance.SetExtraHints(uniqueId:  this.uniqueId, extraHints:  extraHints);
        }
        internal void ExecuteOnMainThread(System.Action action)
        {
            if((UnityEngine.Object.op_Implicit(exists:  this.handler)) == false)
            {
                    return;
            }
            
            this.handler.ExecuteOnMainThread(action:  action);
        }
        public static bool op_Implicit(AudienceNetwork.InterstitialAd obj)
        {
            return (bool)(obj != 0) ? 1 : 0;
        }
        private void <LoadAdFromData>b__44_0()
        {
            if(this.interstitialAdDidLoad != null)
            {
                    this.interstitialAdDidLoad.Invoke();
                return;
            }
            
            throw new NullReferenceException();
        }
    
    }

}
