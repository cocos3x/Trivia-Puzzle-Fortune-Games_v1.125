using UnityEngine;

namespace AudienceNetwork
{
    public sealed class RewardedVideoAd : IDisposable
    {
        // Fields
        private readonly int uniqueId;
        private bool isLoaded;
        private AudienceNetwork.AdHandler handler;
        private string <PlacementId>k__BackingField;
        private AudienceNetwork.RewardData <RewardData>k__BackingField;
        public AudienceNetwork.FBRewardedVideoAdBridgeCallback rewardedVideoAdDidLoad;
        public AudienceNetwork.FBRewardedVideoAdBridgeCallback rewardedVideoAdWillLogImpression;
        public AudienceNetwork.FBRewardedVideoAdBridgeErrorCallback rewardedVideoAdDidFailWithError;
        public AudienceNetwork.FBRewardedVideoAdBridgeCallback rewardedVideoAdDidClick;
        public AudienceNetwork.FBRewardedVideoAdBridgeCallback rewardedVideoAdWillClose;
        public AudienceNetwork.FBRewardedVideoAdBridgeCallback rewardedVideoAdDidClose;
        public AudienceNetwork.FBRewardedVideoAdBridgeCallback rewardedVideoAdComplete;
        public AudienceNetwork.FBRewardedVideoAdBridgeCallback rewardedVideoAdDidSucceed;
        public AudienceNetwork.FBRewardedVideoAdBridgeCallback rewardedVideoAdDidFail;
        public AudienceNetwork.FBRewardedVideoAdBridgeCallback rewardedVideoAdActivityDestroyed;
        
        // Properties
        public string PlacementId { get; set; }
        public AudienceNetwork.RewardData RewardData { get; set; }
        internal AudienceNetwork.FBRewardedVideoAdBridgeCallback RewardedVideoAdDidLoad { get; set; }
        internal AudienceNetwork.FBRewardedVideoAdBridgeCallback RewardedVideoAdWillLogImpression { get; set; }
        internal AudienceNetwork.FBRewardedVideoAdBridgeErrorCallback RewardedVideoAdDidFailWithError { get; set; }
        internal AudienceNetwork.FBRewardedVideoAdBridgeCallback RewardedVideoAdDidClick { get; set; }
        internal AudienceNetwork.FBRewardedVideoAdBridgeCallback RewardedVideoAdWillClose { get; set; }
        internal AudienceNetwork.FBRewardedVideoAdBridgeCallback RewardedVideoAdDidClose { get; set; }
        internal AudienceNetwork.FBRewardedVideoAdBridgeCallback RewardedVideoAdComplete { get; set; }
        internal AudienceNetwork.FBRewardedVideoAdBridgeCallback RewardedVideoAdDidSucceed { get; set; }
        internal AudienceNetwork.FBRewardedVideoAdBridgeCallback RewardedVideoAdDidFail { get; set; }
        internal AudienceNetwork.FBRewardedVideoAdBridgeCallback RewardedVideoAdActivityDestroyed { get; set; }
        
        // Methods
        public string get_PlacementId()
        {
            return (string)this.<PlacementId>k__BackingField;
        }
        private void set_PlacementId(string value)
        {
            this.<PlacementId>k__BackingField = value;
        }
        public AudienceNetwork.RewardData get_RewardData()
        {
            return (AudienceNetwork.RewardData)this.<RewardData>k__BackingField;
        }
        private void set_RewardData(AudienceNetwork.RewardData value)
        {
            this.<RewardData>k__BackingField = value;
        }
        internal AudienceNetwork.FBRewardedVideoAdBridgeCallback get_RewardedVideoAdDidLoad()
        {
            return (AudienceNetwork.FBRewardedVideoAdBridgeCallback)this.rewardedVideoAdDidLoad;
        }
        public void set_RewardedVideoAdDidLoad(AudienceNetwork.FBRewardedVideoAdBridgeCallback value)
        {
            AudienceNetwork.FBRewardedVideoAdBridgeCallback val_2;
            var val_3;
            val_2 = value;
            this.rewardedVideoAdDidLoad = val_2;
            val_3 = null;
            val_3 = null;
            val_2 = this.rewardedVideoAdDidLoad;
            var val_2 = 0;
            val_2 = val_2 + 1;
            AudienceNetwork.RewardedVideoAdBridge.Instance.OnLoad(uniqueId:  this.uniqueId, callback:  val_2);
        }
        internal AudienceNetwork.FBRewardedVideoAdBridgeCallback get_RewardedVideoAdWillLogImpression()
        {
            return (AudienceNetwork.FBRewardedVideoAdBridgeCallback)this.rewardedVideoAdWillLogImpression;
        }
        public void set_RewardedVideoAdWillLogImpression(AudienceNetwork.FBRewardedVideoAdBridgeCallback value)
        {
            AudienceNetwork.FBRewardedVideoAdBridgeCallback val_2;
            var val_3;
            val_2 = value;
            this.rewardedVideoAdWillLogImpression = val_2;
            val_3 = null;
            val_3 = null;
            val_2 = this.rewardedVideoAdWillLogImpression;
            var val_2 = 0;
            val_2 = val_2 + 1;
            AudienceNetwork.RewardedVideoAdBridge.Instance.OnImpression(uniqueId:  this.uniqueId, callback:  val_2);
        }
        internal AudienceNetwork.FBRewardedVideoAdBridgeErrorCallback get_RewardedVideoAdDidFailWithError()
        {
            return (AudienceNetwork.FBRewardedVideoAdBridgeErrorCallback)this.rewardedVideoAdDidFailWithError;
        }
        public void set_RewardedVideoAdDidFailWithError(AudienceNetwork.FBRewardedVideoAdBridgeErrorCallback value)
        {
            AudienceNetwork.FBRewardedVideoAdBridgeErrorCallback val_2;
            var val_3;
            val_2 = value;
            this.rewardedVideoAdDidFailWithError = val_2;
            val_3 = null;
            val_3 = null;
            val_2 = this.rewardedVideoAdDidFailWithError;
            var val_2 = 0;
            val_2 = val_2 + 1;
            AudienceNetwork.RewardedVideoAdBridge.Instance.OnError(uniqueId:  this.uniqueId, callback:  val_2);
        }
        internal AudienceNetwork.FBRewardedVideoAdBridgeCallback get_RewardedVideoAdDidClick()
        {
            return (AudienceNetwork.FBRewardedVideoAdBridgeCallback)this.rewardedVideoAdDidClick;
        }
        public void set_RewardedVideoAdDidClick(AudienceNetwork.FBRewardedVideoAdBridgeCallback value)
        {
            AudienceNetwork.FBRewardedVideoAdBridgeCallback val_2;
            var val_3;
            val_2 = value;
            this.rewardedVideoAdDidClick = val_2;
            val_3 = null;
            val_3 = null;
            val_2 = this.rewardedVideoAdDidClick;
            var val_2 = 0;
            val_2 = val_2 + 1;
            AudienceNetwork.RewardedVideoAdBridge.Instance.OnClick(uniqueId:  this.uniqueId, callback:  val_2);
        }
        internal AudienceNetwork.FBRewardedVideoAdBridgeCallback get_RewardedVideoAdWillClose()
        {
            return (AudienceNetwork.FBRewardedVideoAdBridgeCallback)this.rewardedVideoAdWillClose;
        }
        public void set_RewardedVideoAdWillClose(AudienceNetwork.FBRewardedVideoAdBridgeCallback value)
        {
            AudienceNetwork.FBRewardedVideoAdBridgeCallback val_2;
            var val_3;
            val_2 = value;
            this.rewardedVideoAdWillClose = val_2;
            val_3 = null;
            val_3 = null;
            val_2 = this.rewardedVideoAdWillClose;
            var val_2 = 0;
            val_2 = val_2 + 1;
            AudienceNetwork.RewardedVideoAdBridge.Instance.OnWillClose(uniqueId:  this.uniqueId, callback:  val_2);
        }
        internal AudienceNetwork.FBRewardedVideoAdBridgeCallback get_RewardedVideoAdDidClose()
        {
            return (AudienceNetwork.FBRewardedVideoAdBridgeCallback)this.rewardedVideoAdDidClose;
        }
        public void set_RewardedVideoAdDidClose(AudienceNetwork.FBRewardedVideoAdBridgeCallback value)
        {
            AudienceNetwork.FBRewardedVideoAdBridgeCallback val_2;
            var val_3;
            val_2 = value;
            this.rewardedVideoAdDidClose = val_2;
            val_3 = null;
            val_3 = null;
            val_2 = this.rewardedVideoAdDidClose;
            var val_2 = 0;
            val_2 = val_2 + 1;
            AudienceNetwork.RewardedVideoAdBridge.Instance.OnDidClose(uniqueId:  this.uniqueId, callback:  val_2);
        }
        internal AudienceNetwork.FBRewardedVideoAdBridgeCallback get_RewardedVideoAdComplete()
        {
            return (AudienceNetwork.FBRewardedVideoAdBridgeCallback)this.rewardedVideoAdComplete;
        }
        public void set_RewardedVideoAdComplete(AudienceNetwork.FBRewardedVideoAdBridgeCallback value)
        {
            AudienceNetwork.FBRewardedVideoAdBridgeCallback val_2;
            var val_3;
            val_2 = value;
            this.rewardedVideoAdComplete = val_2;
            val_3 = null;
            val_3 = null;
            val_2 = this.rewardedVideoAdComplete;
            var val_2 = 0;
            val_2 = val_2 + 1;
            AudienceNetwork.RewardedVideoAdBridge.Instance.OnComplete(uniqueId:  this.uniqueId, callback:  val_2);
        }
        internal AudienceNetwork.FBRewardedVideoAdBridgeCallback get_RewardedVideoAdDidSucceed()
        {
            return (AudienceNetwork.FBRewardedVideoAdBridgeCallback)this.rewardedVideoAdDidSucceed;
        }
        public void set_RewardedVideoAdDidSucceed(AudienceNetwork.FBRewardedVideoAdBridgeCallback value)
        {
            AudienceNetwork.FBRewardedVideoAdBridgeCallback val_2;
            var val_3;
            val_2 = value;
            this.rewardedVideoAdDidSucceed = val_2;
            val_3 = null;
            val_3 = null;
            val_2 = this.rewardedVideoAdDidSucceed;
            var val_2 = 0;
            val_2 = val_2 + 1;
            AudienceNetwork.RewardedVideoAdBridge.Instance.OnDidSucceed(uniqueId:  this.uniqueId, callback:  val_2);
        }
        internal AudienceNetwork.FBRewardedVideoAdBridgeCallback get_RewardedVideoAdDidFail()
        {
            return (AudienceNetwork.FBRewardedVideoAdBridgeCallback)this.rewardedVideoAdDidFail;
        }
        public void set_RewardedVideoAdDidFail(AudienceNetwork.FBRewardedVideoAdBridgeCallback value)
        {
            AudienceNetwork.FBRewardedVideoAdBridgeCallback val_2;
            var val_3;
            val_2 = value;
            this.rewardedVideoAdDidFail = val_2;
            val_3 = null;
            val_3 = null;
            val_2 = this.rewardedVideoAdDidFail;
            var val_2 = 0;
            val_2 = val_2 + 1;
            AudienceNetwork.RewardedVideoAdBridge.Instance.OnDidFail(uniqueId:  this.uniqueId, callback:  val_2);
        }
        internal AudienceNetwork.FBRewardedVideoAdBridgeCallback get_RewardedVideoAdActivityDestroyed()
        {
            return (AudienceNetwork.FBRewardedVideoAdBridgeCallback)this.rewardedVideoAdActivityDestroyed;
        }
        public void set_RewardedVideoAdActivityDestroyed(AudienceNetwork.FBRewardedVideoAdBridgeCallback value)
        {
            AudienceNetwork.FBRewardedVideoAdBridgeCallback val_2;
            var val_3;
            val_2 = value;
            this.rewardedVideoAdActivityDestroyed = val_2;
            val_3 = null;
            val_3 = null;
            val_2 = this.rewardedVideoAdActivityDestroyed;
            var val_2 = 0;
            val_2 = val_2 + 1;
            AudienceNetwork.RewardedVideoAdBridge.Instance.OnActivityDestroyed(uniqueId:  this.uniqueId, callback:  val_2);
        }
        public RewardedVideoAd(string placementId)
        {
        
        }
        public RewardedVideoAd(string placementId, AudienceNetwork.RewardData rewardData)
        {
            var val_14;
            val_1 = new System.Object();
            AudienceNetwork.AudienceNetworkAds.Initialize();
            this.<PlacementId>k__BackingField = placementId;
            this.<RewardData>k__BackingField = val_1;
            if(UnityEngine.Application.platform == 0)
            {
                    return;
            }
            
            val_14 = null;
            val_14 = null;
            var val_15 = 0;
            val_15 = val_15 + 1;
            int val_4 = AudienceNetwork.RewardedVideoAdBridge.Instance.Create(placementId:  placementId, rewardData:  this.<RewardData>k__BackingField, rewardedVideoAd:  this);
            this.uniqueId = val_4;
            var val_16 = 0;
            val_16 = val_16 + 1;
            AudienceNetwork.RewardedVideoAdBridge.Instance.OnLoad(uniqueId:  val_4, callback:  this.rewardedVideoAdDidLoad);
            var val_17 = 0;
            val_17 = val_17 + 1;
            AudienceNetwork.RewardedVideoAdBridge.Instance.OnImpression(uniqueId:  this.uniqueId, callback:  this.rewardedVideoAdWillLogImpression);
            var val_18 = 0;
            val_18 = val_18 + 1;
            AudienceNetwork.RewardedVideoAdBridge.Instance.OnClick(uniqueId:  this.uniqueId, callback:  this.rewardedVideoAdDidClick);
            var val_19 = 0;
            val_19 = val_19 + 1;
            AudienceNetwork.RewardedVideoAdBridge.Instance.OnError(uniqueId:  this.uniqueId, callback:  this.rewardedVideoAdDidFailWithError);
            var val_20 = 0;
            val_20 = val_20 + 1;
            AudienceNetwork.RewardedVideoAdBridge.Instance.OnWillClose(uniqueId:  this.uniqueId, callback:  this.rewardedVideoAdWillClose);
            var val_21 = 0;
            val_21 = val_21 + 1;
            AudienceNetwork.RewardedVideoAdBridge.Instance.OnDidClose(uniqueId:  this.uniqueId, callback:  this.rewardedVideoAdDidClose);
            var val_22 = 0;
            val_22 = val_22 + 1;
            AudienceNetwork.RewardedVideoAdBridge.Instance.OnComplete(uniqueId:  this.uniqueId, callback:  this.rewardedVideoAdComplete);
            var val_23 = 0;
            val_23 = val_23 + 1;
            AudienceNetwork.RewardedVideoAdBridge.Instance.OnDidSucceed(uniqueId:  this.uniqueId, callback:  this.rewardedVideoAdDidSucceed);
            var val_24 = 0;
            val_24 = val_24 + 1;
            AudienceNetwork.RewardedVideoAdBridge.Instance.OnDidFail(uniqueId:  this.uniqueId, callback:  this.rewardedVideoAdDidFail);
            var val_25 = 0;
            val_25 = val_25 + 1;
            AudienceNetwork.RewardedVideoAdBridge.Instance.OnActivityDestroyed(uniqueId:  this.uniqueId, callback:  this.rewardedVideoAdActivityDestroyed);
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
            var val_3;
            if((UnityEngine.Object.op_Implicit(exists:  this.handler)) != false)
            {
                    this.handler.RemoveFromParent();
            }
            
            UnityEngine.Debug.Log(message:  "RewardedVideo Ad Disposed.");
            val_3 = null;
            val_3 = null;
            var val_3 = 0;
            val_3 = val_3 + 1;
            AudienceNetwork.RewardedVideoAdBridge.Instance.Release(uniqueId:  this.uniqueId);
        }
        public override string ToString()
        {
            int val_2;
            object[] val_1 = new object[11];
            val_2 = val_1.Length;
            val_1[0] = this.<PlacementId>k__BackingField;
            if(this.rewardedVideoAdDidLoad != null)
            {
                    val_2 = val_1.Length;
            }
            
            val_1[1] = this.rewardedVideoAdDidLoad;
            if(this.rewardedVideoAdWillLogImpression != null)
            {
                    val_2 = val_1.Length;
            }
            
            val_1[2] = this.rewardedVideoAdWillLogImpression;
            if(this.rewardedVideoAdDidFailWithError != null)
            {
                    val_2 = val_1.Length;
            }
            
            val_1[3] = this.rewardedVideoAdDidFailWithError;
            if(this.rewardedVideoAdDidClick != null)
            {
                    val_2 = val_1.Length;
            }
            
            val_1[4] = this.rewardedVideoAdDidClick;
            if(this.rewardedVideoAdWillClose != null)
            {
                    val_2 = val_1.Length;
            }
            
            val_1[5] = this.rewardedVideoAdWillClose;
            if(this.rewardedVideoAdDidClose != null)
            {
                    val_2 = val_1.Length;
            }
            
            val_1[6] = this.rewardedVideoAdDidClose;
            if(this.rewardedVideoAdComplete != null)
            {
                    val_2 = val_1.Length;
            }
            
            val_1[7] = this.rewardedVideoAdComplete;
            if(this.rewardedVideoAdDidSucceed != null)
            {
                    val_2 = val_1.Length;
            }
            
            val_1[8] = this.rewardedVideoAdDidSucceed;
            if(this.rewardedVideoAdDidFail != null)
            {
                    val_2 = val_1.Length;
            }
            
            val_1[9] = this.rewardedVideoAdDidFail;
            if(this.rewardedVideoAdActivityDestroyed != null)
            {
                    val_2 = val_1.Length;
            }
            
            val_1[10] = this.rewardedVideoAdActivityDestroyed;
            return System.String.Format(format:  "[RewardedVideoAd: PlacementId={0}, RewardedVideoAdDidLoad={1}, RewardedVideoAdWillLogImpression={2}, RewardedVideoAdDidFailWithError={3}, RewardedVideoAdDidClick={4}, RewardedVideoAdWillClose={5}, RewardedVideoAdDidClose={6}, RewardedVideoAdComplete={7}, RewardedVideoAdDidSucceed={8}, RewardedVideoAdDidFail={9},RewardedVideoAdActivityDestroyed={10}]", args:  val_1);
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
                    this.rewardedVideoAdDidLoad.Invoke();
                return;
            }
            
            int val_3 = AudienceNetwork.RewardedVideoAdBridge.Instance.Load(uniqueId:  this.uniqueId);
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
                    this.rewardedVideoAdDidLoad.Invoke();
                return;
            }
            
            int val_3 = AudienceNetwork.RewardedVideoAdBridge.Instance.Load(uniqueId:  this.uniqueId, bidPayload:  bidPayload);
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
            return AudienceNetwork.RewardedVideoAdBridge.Instance.IsValid(uniqueId:  this.uniqueId);
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
            if(this.rewardedVideoAdDidLoad == null)
            {
                    return;
            }
            
            this.handler.ExecuteOnMainThread(action:  new System.Action(object:  this, method:  System.Void AudienceNetwork.RewardedVideoAd::<LoadAdFromData>b__61_0()));
        }
        public bool Show()
        {
            var val_2 = null;
            var val_2 = 0;
            val_2 = val_2 + 1;
            return AudienceNetwork.RewardedVideoAdBridge.Instance.Show(uniqueId:  this.uniqueId);
        }
        public void SetExtraHints(AudienceNetwork.ExtraHints extraHints)
        {
            var val_2 = null;
            var val_2 = 0;
            val_2 = val_2 + 1;
            AudienceNetwork.RewardedVideoAdBridge.Instance.SetExtraHints(uniqueId:  this.uniqueId, extraHints:  extraHints);
        }
        internal void ExecuteOnMainThread(System.Action action)
        {
            if((UnityEngine.Object.op_Implicit(exists:  this.handler)) == false)
            {
                    return;
            }
            
            this.handler.ExecuteOnMainThread(action:  action);
        }
        public static bool op_Implicit(AudienceNetwork.RewardedVideoAd obj)
        {
            return (bool)(obj != 0) ? 1 : 0;
        }
        private void <LoadAdFromData>b__61_0()
        {
            if(this.rewardedVideoAdDidLoad != null)
            {
                    this.rewardedVideoAdDidLoad.Invoke();
                return;
            }
            
            throw new NullReferenceException();
        }
    
    }

}
