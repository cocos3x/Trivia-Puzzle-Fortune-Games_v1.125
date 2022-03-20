using UnityEngine;
public class SROptions_Ads : SuperLuckySROptionsParent<SROptions_Ads>, INotifyPropertyChanged
{
    // Properties
    public string NoAdsCooldown { get; }
    public string GetHackedVideos { get; }
    public string AdSegment { get; }
    public string NetworkPurchaser { get; }
    
    // Methods
    public static void NotifyPropertyChanged(string propertyName)
    {
        if((SuperLuckySROptionsParent<T>._Instance) == 0)
        {
                return;
        }
        
        propertyName = ???;
        goto typeof(T).__il2cppRuntimeField_190;
    }
    public void Back()
    {
        var val_5;
        var val_5 = 0;
        val_5 = val_5 + 1;
        val_5 = 18;
        SRDebug.Instance.ClearPinnedOptions();
        var val_6 = 0;
        val_6 = val_6 + 1;
        val_5 = 13;
        SRDebug.Instance.RemoveOptionContainer(container:  this);
        SuperLuckySROptionsController.OpenGameSpecificOptionsController();
    }
    public string get_NoAdsCooldown()
    {
        var val_11;
        System.TimeSpan val_12;
        var val_13;
        System.TimeSpan val_14;
        var val_15;
        val_11 = null;
        val_11 = null;
        System.DateTime val_1 = AdsManager.LastPurchaseCooldownEnd;
        System.DateTime val_2 = ServerHandler.ServerTime;
        System.TimeSpan val_3 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_1.dateData}, d2:  new System.DateTime() {dateData = val_2.dateData});
        val_12 = val_3._ticks;
        val_13 = null;
        if((System.TimeSpan.op_LessThan(t1:  new System.TimeSpan() {_ticks = val_3._ticks}, t2:  new System.TimeSpan() {_ticks = System.TimeSpan.Zero})) != false)
        {
                val_13 = null;
            val_12 = System.TimeSpan.Zero;
        }
        
        System.TimeSpan val_5 = System.TimeSpan.op_Addition(t1:  new System.TimeSpan() {_ticks = System.TimeSpan.Zero}, t2:  new System.TimeSpan() {_ticks = val_12});
        System.DateTime val_6 = AdsManager.AdsCooldownEnd;
        System.DateTime val_7 = ServerHandler.ServerTime;
        System.TimeSpan val_8 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = val_6.dateData}, d2:  new System.DateTime() {dateData = val_7.dateData});
        val_14 = val_8._ticks;
        val_15 = null;
        if((System.TimeSpan.op_LessThan(t1:  new System.TimeSpan() {_ticks = val_8._ticks}, t2:  new System.TimeSpan() {_ticks = System.TimeSpan.Zero})) != false)
        {
                val_15 = null;
            val_14 = System.TimeSpan.Zero;
        }
        
        System.TimeSpan val_10 = System.TimeSpan.op_Addition(t1:  new System.TimeSpan() {_ticks = val_5._ticks}, t2:  new System.TimeSpan() {_ticks = val_14});
        return GenericStringExtentions.ToString(span:  new System.TimeSpan() {_ticks = val_10._ticks}, formatted:  true);
    }
    public void ResetAds()
    {
        Player val_1 = App.Player;
        val_1.total_purchased = 0f;
        Player val_2 = App.Player;
        System.DateTime val_3 = ServerHandler.ServerTime;
        val_2.properties.NoAdsEndTime = val_3;
        System.DateTime val_5 = ServerHandler.ServerTime;
        MonoSingletonSelfGenerating<AdsManager>.Instance.AdsWatchedCooldownEnd = new System.DateTime() {dateData = val_5.dateData};
        if((UnityEngine.Object.op_Implicit(exists:  MonoSingleton<AdsUIController>.Instance)) == false)
        {
                return;
        }
        
        MonoSingleton<AdsUIController>.Instance.ShowOrHideBanner();
    }
    public void HideAds()
    {
        Player val_1 = App.Player;
        val_1.total_purchased = 1f;
        Player val_2 = App.Player;
        System.DateTime val_3 = ServerHandler.ServerTime;
        System.TimeSpan val_4 = System.TimeSpan.FromDays(value:  10);
        System.DateTime val_5 = val_3.dateData.Add(value:  new System.TimeSpan() {_ticks = val_4._ticks});
        val_2.properties.NoAdsEndTime = val_5;
        System.DateTime val_7 = ServerHandler.ServerTime;
        System.TimeSpan val_8 = System.TimeSpan.FromDays(value:  10);
        System.DateTime val_9 = val_7.dateData.Add(value:  new System.TimeSpan() {_ticks = val_8._ticks});
        MonoSingletonSelfGenerating<AdsManager>.Instance.AdsWatchedCooldownEnd = new System.DateTime() {dateData = val_9.dateData};
        if((UnityEngine.Object.op_Implicit(exists:  MonoSingleton<AdsUIController>.Instance)) == false)
        {
                return;
        }
        
        MonoSingleton<AdsUIController>.Instance.ShowOrHideBanner();
    }
    public void ResetNoAdsCooldown()
    {
        UnityEngine.Object val_8;
        if(AdsManager.isInPurchaseCooldown == false)
        {
                return;
        }
        
        Player val_2 = App.Player;
        System.DateTime val_3 = ServerHandler.ServerTime;
        System.DateTime val_4 = val_3.dateData.AddMinutes(value:  5);
        val_2.properties.NoAdsEndTime = val_4;
        val_8 = MonoSingleton<AdsUIController>.Instance;
        if((UnityEngine.Object.op_Implicit(exists:  val_8)) == false)
        {
                return;
        }
        
        MonoSingleton<AdsUIController>.Instance.ShowOrHideBanner();
    }
    public void ResetNoAdsVideo()
    {
        UnityEngine.Object val_6;
        if(AdsManager.isInVideoCooldown == false)
        {
                return;
        }
        
        MonoSingletonSelfGenerating<AdsManager>.Instance.HackResetAdsWatchedCoolDown();
        val_6 = MonoSingleton<AdsUIController>.Instance;
        if((UnityEngine.Object.op_Implicit(exists:  val_6)) == false)
        {
                return;
        }
        
        MonoSingleton<AdsUIController>.Instance.ShowOrHideBanner();
    }
    public void NoAdsAvailable()
    {
        if((MonoSingleton<ApplovinMaxPlugin>.Instance) == 0)
        {
                return;
        }
        
        MonoSingleton<ApplovinMaxPlugin>.Instance.Hack_NoVideoAdsAvailable();
    }
    public void ShowMediationTestSuite()
    {
        if((MonoSingleton<ApplovinMaxPlugin>.Instance) == 0)
        {
                return;
        }
        
        MonoSingleton<ApplovinMaxPlugin>.Instance.ShowAdMediationSuite();
    }
    public string get_GetHackedVideos()
    {
        AdsManager val_4 = MonoSingletonSelfGenerating<AdsManager>.Instance;
        return (string)System.String.Format(format:  "{0}/{1}", arg0:  MonoSingletonSelfGenerating<AdsManager>.Instance.HackAdsWatchedToday(increment:  0).ToString(), arg1:  val_4._rewardedVideoCap.ToString());
    }
    public void AddFiveHackedVideos()
    {
        int val_2 = MonoSingletonSelfGenerating<AdsManager>.Instance.HackAdsWatchedToday(increment:  5);
        SROptions_Ads.NotifyPropertyChanged(propertyName:  "Video Ads");
    }
    public void AddMinusFourHackedVideos()
    {
        int val_2 = MonoSingletonSelfGenerating<AdsManager>.Instance.HackAdsWatchedToday(increment:  -4);
        SROptions_Ads.NotifyPropertyChanged(propertyName:  "Video Ads");
    }
    public string get_AdSegment()
    {
        return AdSegmentation.Segment;
    }
    public string get_NetworkPurchaser()
    {
        Player val_1 = App.Player;
        return (string)val_1.network_purchaser;
    }
    public void AdsHighval()
    {
        Player val_1 = App.Player;
        val_1.properties.ads_segment = "highval";
        SROptions_Ads.NotifyPropertyChanged(propertyName:  "Ads Segmentation");
        DefaultHandler<ServerHandler>.Instance.RequestDataFlush(immediate:  false, reset:  false);
    }
    public void AdsMediumval()
    {
        Player val_1 = App.Player;
        val_1.properties.ads_segment = "mediumval";
        SROptions_Ads.NotifyPropertyChanged(propertyName:  "Ads Segmentation");
        DefaultHandler<ServerHandler>.Instance.RequestDataFlush(immediate:  false, reset:  false);
    }
    public void AdsLowval()
    {
        Player val_1 = App.Player;
        val_1.properties.ads_segment = "lowval";
        SROptions_Ads.NotifyPropertyChanged(propertyName:  "Ads Segmentation");
        DefaultHandler<ServerHandler>.Instance.RequestDataFlush(immediate:  false, reset:  false);
    }
    public void AdsOrganic()
    {
        Player val_1 = App.Player;
        val_1.properties.ads_segment = "organic";
        SROptions_Ads.NotifyPropertyChanged(propertyName:  "Ads Segmentation");
        DefaultHandler<ServerHandler>.Instance.RequestDataFlush(immediate:  false, reset:  false);
    }
    public SROptions_Ads()
    {
    
    }

}
