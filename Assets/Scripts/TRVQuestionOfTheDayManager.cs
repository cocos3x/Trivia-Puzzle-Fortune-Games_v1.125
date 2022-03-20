using UnityEngine;
public class TRVQuestionOfTheDayManager : MonoSingleton<TRVQuestionOfTheDayManager>
{
    // Fields
    public const string QOTD_QUESTION_SET_CATEGORY = "QOTD";
    private TRVQotdStatus <Status>k__BackingField;
    
    // Properties
    private TRVQotdStatus Status { get; set; }
    
    // Methods
    private TRVQotdStatus get_Status()
    {
        return (TRVQotdStatus)this.<Status>k__BackingField;
    }
    private void set_Status(TRVQotdStatus value)
    {
        this.<Status>k__BackingField = value;
    }
    public override void InitMonoSingleton()
    {
        this.InitMonoSingleton();
        this.<Status>k__BackingField = new TRVQotdStatus();
        goto typeof(TRVQotdStatus).__il2cppRuntimeField_170;
    }
    public TRVReward GetReward(bool isBonus)
    {
        TRVReward val_3;
        if(isBonus != false)
        {
                TRVEcon val_1 = App.GetGameSpecificEcon<TRVEcon>();
            val_3 = val_1.qotdEcon.bonusReward;
            return (TRVReward)mem[val_2.qotdEcon.normalReward];
        }
        
        TRVEcon val_2 = App.GetGameSpecificEcon<TRVEcon>();
        val_3 = val_2.qotdEcon.normalReward;
        return (TRVReward)mem[val_2.qotdEcon.normalReward];
    }
    public void CheckQOTD()
    {
        this.CheckLPN();
    }
    public void Play()
    {
        null = null;
        TRVMainController.noAnswerSelectedCharacter = 1;
        System.DateTime val_1 = DateTimeCheat.Now;
        System.DateTime val_2 = val_1.dateData.Date;
        this.<Status>k__BackingField.LastFinishedTime = val_2;
        this.<Status>k__BackingField.playing = true;
        GameBehavior val_3 = App.getBehavior;
    }
    public void Complete()
    {
        MonoSingleton<TRVMainController>.Instance.CheckShouldShowLowGems();
        this.<Status>k__BackingField.playing = false;
        GameBehavior val_2 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_3D0;
    }
    public void CollectReward(TRVReward reward)
    {
        if(reward.rewardType != 1)
        {
                if(reward.rewardType != 0)
        {
                return;
        }
        
            decimal val_2 = System.Decimal.op_Implicit(value:  reward.rewardAmount);
            App.Player.AddCredits(amount:  new System.Decimal() {flags = val_2.flags, hi = val_2.hi, lo = val_2.lo, mid = val_2.mid}, source:  "Question of the Day Event", subSource:  0, externalParams:  0, doTrack:  true);
            return;
        }
        
        App.Player.AddGems(amount:  reward.rewardAmount, source:  "Question of the Day Event", subsource:  0);
        App.Player.TrackNonCoinReward(source:  "Question of the Day Event", subSource:  0, rewardType:  "Gems", rewardAmount:  reward.rewardAmount.ToString(), additionalParams:  0);
    }
    public bool IsPlaying()
    {
        if((this.<Status>k__BackingField) != null)
        {
                return (bool)this.<Status>k__BackingField.playing;
        }
        
        throw new NullReferenceException();
    }
    public bool IsEligible()
    {
        ulong val_9;
        ulong val_10;
        val_9 = this;
        if(this.IsFeatureEnabled() == false)
        {
            goto label_1;
        }
        
        TRVEcon val_3 = App.GetGameSpecificEcon<TRVEcon>();
        if(App.Player >= val_3.qotdEcon.unlockLevel)
        {
            goto label_7;
        }
        
        label_1:
        val_10 = 0;
        return (bool)System.DateTime.op_LessThan(t1:  new System.DateTime() {dateData = val_10}, t2:  new System.DateTime() {dateData = val_6.dateData});
        label_7:
        System.DateTime val_4 = this.<Status>k__BackingField.LastFinishedTime.Date;
        val_9 = val_4.dateData;
        System.DateTime val_5 = DateTimeCheat.Now;
        System.DateTime val_6 = val_5.dateData.Date;
        val_10 = val_9;
        return (bool)System.DateTime.op_LessThan(t1:  new System.DateTime() {dateData = val_10}, t2:  new System.DateTime() {dateData = val_6.dateData});
    }
    public bool IsFeatureEnabled()
    {
        TRVEcon val_1 = App.GetGameSpecificEcon<TRVEcon>();
        if((val_1.qotdEcon.unlockLevel & 2147483648) != 0)
        {
                return false;
        }
        
        GameBehavior val_2 = App.getBehavior;
        return System.String.op_Equality(a:  val_2.<metaGameBehavior>k__BackingField.GetCurrentLanguage(), b:  "en");
    }
    public TRVCategorySelectionInfo GetRandomSubCategory()
    {
        .categoryName = "QOTD_AllQuestions";
        .associatedEvents = new System.Collections.Generic.List<WGEventHandler>();
        return (TRVCategorySelectionInfo)new TRVCategorySelectionInfo();
    }
    private void CheckLPN()
    {
        ulong val_8;
        twelvegigs.plugins.LocalNotificationsPlugin.KillNotification(tipo:  26);
        System.DateTime val_1 = DateTimeCheat.Today;
        System.DateTime val_2 = val_1.dateData.AddHours(value:  16);
        val_8 = val_2.dateData;
        System.DateTime val_3 = DateTimeCheat.Now;
        if((System.DateTime.op_GreaterThan(t1:  new System.DateTime() {dateData = val_3.dateData}, t2:  new System.DateTime() {dateData = val_8})) != false)
        {
                System.DateTime val_5 = DateTimeCheat.Today;
            System.DateTime val_6 = val_5.dateData.AddHours(value:  40);
            val_8 = val_6.dateData;
        }
        
        System.Collections.Generic.Dictionary<System.String, System.Object> val_7 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        val_7.Add(key:  "notification_type", value:  "Question of the Day");
        twelvegigs.plugins.LocalNotificationsPlugin.PostNotification(tipo:  26, when:  new System.DateTime() {dateData = val_8}, interval:  0, optTitle:  "Question of the Day", optMessage:  "Question of the Day is now available!", extraData:  val_7, priority:  0, useTimeModifier:  true);
    }
    private void CheckQOTDGameplayStatus()
    {
        bool val_1 = this.IsEligible();
        if(val_1 == false)
        {
                return;
        }
        
        val_1.ShowQOTDPopup();
    }
    private void ShowQOTDPopup()
    {
        GameBehavior val_1 = App.getBehavior;
        goto mem[(1152921504946249728 + (public TRVQotdPopup MetaGameBehavior::ShowUGUIMonolith<TRVQotdPopup>(bool showNext).__il2cppRuntimeField_48) << 4) + 312];
    }
    public TRVQuestionOfTheDayManager()
    {
    
    }

}
