using UnityEngine;
public class AwardController : MonoSingleton<AwardController>
{
    // Fields
    private Award current_award;
    
    // Methods
    public override void InitMonoSingleton()
    {
        bool val_1 = this.FetchAwards();
    }
    private void OnApplicationPause(bool pauseStatus)
    {
        if(pauseStatus != false)
        {
                return;
        }
        
        bool val_1 = this.FetchAwards();
    }
    public void HandleUpdateFromServer()
    {
        bool val_1 = this.FetchAwards();
    }
    private bool FetchAwards()
    {
        MetaGameBehavior val_10;
        GameBehavior val_1 = App.getBehavior;
        val_10 = val_1.<metaGameBehavior>k__BackingField;
        if(val_10 == null)
        {
                return (bool)val_10;
        }
        
        System.Collections.Generic.List<Award> val_2 = ServerHandler.Awards;
        System.Collections.Generic.List<Award> val_3 = ServerHandler.Awards;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        this.current_award = ServerHandler.__il2cppRuntimeField_cctor_finished + 32;
        mem[1152921515729307896] = ServerHandler.__il2cppRuntimeField_cctor_finished + 64;
        mem[1152921515729307880] = ServerHandler.__il2cppRuntimeField_cctor_finished + 32 + 16;
        if((System.String.op_Equality(a:  val_3, b:  "credits")) != false)
        {
                this.ShowCoinAward();
        }
        else
        {
                if((System.String.op_Equality(a:  val_3, b:  "gems")) != false)
        {
                this.ShowGemsAward();
        }
        else
        {
                if((System.String.op_Equality(a:  val_3, b:  "no_ads")) != false)
        {
                this.ShowNoAdsAward();
        }
        else
        {
                if((System.String.op_Equality(a:  val_3, b:  "level")) != false)
        {
                this.ShowLevelAward();
        }
        else
        {
                if((System.String.op_Equality(a:  val_3, b:  "name_change")) != false)
        {
                this.ShowNewNameAward();
        }
        else
        {
                if((System.String.op_Equality(a:  val_3, b:  "pets_food")) != false)
        {
                this.ShowPetsAward();
        }
        
        }
        
        }
        
        }
        
        }
        
        }
        
        val_10 = 0;
        return (bool)val_10;
    }
    private Award GenerateAwardFromPair(ConsumableAmountPair cap)
    {
        Award val_0;
        System.DateTime val_1 = System.DateTime.Now;
        object[] val_2 = new object[5];
        val_2[0] = val_1.dateData.Year;
        val_2[1] = val_1.dateData.Month.ToString(format:  "00");
        val_2[2] = val_1.dateData.Day.ToString(format:  "00");
        val_2[3] = val_1.dateData.Millisecond;
        val_2[4] = UnityEngine.Random.Range(min:  0, max:  999999999).ToString();
        val_0.id = System.String.Format(format:  "{0}-{1}-{2}_{3}-{4}", args:  val_2);
        val_0.kind = null;
        val_0.amount.flags = ;
        val_0.amount.lo = ;
        val_0.text = 0;
        return val_0;
    }
    public void AddAwards(System.Collections.Generic.List<ConsumableAmountPair> awards)
    {
        string val_5;
        string val_6;
        int val_7;
        List.Enumerator<T> val_1 = awards.GetEnumerator();
        label_6:
        if(0.MoveNext() == false)
        {
            goto label_2;
        }
        
        ServerHandler val_3 = DefaultHandler<ServerHandler>.Instance;
        Award val_4 = val_3.GenerateAwardFromPair(cap:  0);
        if(val_3 == null)
        {
                throw new NullReferenceException();
        }
        
        val_3.AddAward(award:  new Award() {id = val_6, kind = val_6, amount = new System.Decimal() {flags = val_7, hi = val_7, lo = val_7, mid = val_7}, text = val_5});
        goto label_6;
        label_2:
        0.Dispose();
        bool val_8 = this.FetchAwards();
    }
    private void ShowCoinAward()
    {
        decimal val_15;
        int val_16;
        var val_17;
        var val_18;
        var val_19;
        GameBehavior val_1 = App.getBehavior;
        GameEcon val_5 = App.getGameEcon;
        val_15 = 1152921515729878136;
        bool[] val_8 = new bool[2];
        val_8[0] = true;
        string[] val_9 = new string[2];
        val_16 = val_9.Length;
        val_9[0] = Localization.Localize(key:  "collect_upper", defaultValue:  "COLLECT", useSingularKey:  false);
        val_16 = val_9.Length;
        val_9[1] = "OK";
        GameBehavior val_11 = App.getBehavior;
        if(((val_11.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                val_17 = val_1.<metaGameBehavior>k__BackingField;
            val_18 = 1152921515729878144;
        }
        else
        {
                val_19 = null;
            val_19 = null;
            val_17 = val_1.<metaGameBehavior>k__BackingField;
            val_15 = 1152921504617021480;
            val_18 = 1152921504617021488;
        }
        
        System.Func<System.Boolean>[] val_12 = new System.Func<System.Boolean>[2];
        val_12[0] = new System.Func<System.Boolean>(object:  this, method:  System.Boolean AwardController::OnClick_Collect());
        val_12[1] = new System.Func<System.Boolean>(object:  this, method:  System.Boolean AwardController::OnClick_Collect());
        val_17.SetupMessage(titleTxt:  Localization.Localize(key:  "award_upper", defaultValue:  "AWARD", useSingularKey:  false), messageTxt:  System.String.Format(format:  Localization.Localize(key:  "you_have_been_gifted", defaultValue:  "You have been gifted\n{0} coins!", useSingularKey:  false), arg0:  ToString(format:  val_5.numberFormatInt)), shownButtons:  val_8, buttonTexts:  val_9, showClose:  false, buttonCallbacks:  val_12, collectAmount:  new System.Decimal() {flags = val_15, hi = val_15, lo = mem[1152921504617021488], mid = mem[1152921504617021488]}, collectType:  "credits");
    }
    private void ShowGemsAward()
    {
        decimal val_15;
        int val_16;
        var val_17;
        var val_18;
        var val_19;
        GameBehavior val_1 = App.getBehavior;
        GameEcon val_5 = App.getGameEcon;
        val_15 = 1152921515730121576;
        bool[] val_8 = new bool[2];
        val_8[0] = true;
        string[] val_9 = new string[2];
        val_16 = val_9.Length;
        val_9[0] = Localization.Localize(key:  "collect_upper", defaultValue:  "COLLECT", useSingularKey:  false);
        val_16 = val_9.Length;
        val_9[1] = "OK";
        GameBehavior val_11 = App.getBehavior;
        if(((val_11.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                val_17 = val_1.<metaGameBehavior>k__BackingField;
            val_18 = 1152921515730121584;
        }
        else
        {
                val_19 = null;
            val_19 = null;
            val_17 = val_1.<metaGameBehavior>k__BackingField;
            val_15 = 1152921504617021480;
            val_18 = 1152921504617021488;
        }
        
        System.Func<System.Boolean>[] val_12 = new System.Func<System.Boolean>[2];
        val_12[0] = new System.Func<System.Boolean>(object:  this, method:  System.Boolean AwardController::OnClick_Collect());
        val_12[1] = new System.Func<System.Boolean>(object:  this, method:  System.Boolean AwardController::OnClick_Collect());
        val_17.SetupMessage(titleTxt:  Localization.Localize(key:  "award_upper", defaultValue:  "AWARD", useSingularKey:  false), messageTxt:  System.String.Format(format:  Localization.Localize(key:  "you_have_been_gifted_gems", defaultValue:  "You have been gifted\n{0} gems!", useSingularKey:  false), arg0:  ToString(format:  val_5.numberFormatInt)), shownButtons:  val_8, buttonTexts:  val_9, showClose:  false, buttonCallbacks:  val_12, collectAmount:  new System.Decimal() {flags = val_15, hi = val_15, lo = mem[1152921504617021488], mid = mem[1152921504617021488]}, collectType:  "gems");
    }
    private void ShowNoAdsAward()
    {
        int val_11;
        var val_12;
        MetaGameBehavior val_13;
        GameBehavior val_1 = App.getBehavior;
        bool[] val_5 = new bool[2];
        val_5[0] = true;
        string[] val_6 = new string[2];
        val_11 = val_6.Length;
        val_6[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_11 = val_6.Length;
        val_6[1] = "OK";
        System.Func<System.Boolean>[] val_8 = new System.Func<System.Boolean>[2];
        val_8[0] = new System.Func<System.Boolean>(object:  this, method:  System.Boolean AwardController::OnClick_Collect());
        val_8[1] = new System.Func<System.Boolean>(object:  this, method:  System.Boolean AwardController::OnClick_Collect());
        val_12 = null;
        val_13 = val_1.<metaGameBehavior>k__BackingField;
        if(val_13 == 0)
        {
                throw new NullReferenceException();
        }
        
        SetupMessage(titleTxt:  Localization.Localize(key:  "no_more_ads_upper", defaultValue:  "NO MORE ADS", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "you_now_have_no_ads_time", defaultValue:  "You now have some no-ads time.\n\nThank you for your support!", useSingularKey:  false), shownButtons:  val_5, buttonTexts:  val_6, showClose:  false, buttonCallbacks:  val_8, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
    }
    private void ShowLevelAward()
    {
        int val_11;
        var val_12;
        MetaGameBehavior val_13;
        GameBehavior val_1 = App.getBehavior;
        bool[] val_5 = new bool[2];
        val_5[0] = true;
        string[] val_6 = new string[2];
        val_11 = val_6.Length;
        val_6[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_11 = val_6.Length;
        val_6[1] = "OK";
        System.Func<System.Boolean>[] val_8 = new System.Func<System.Boolean>[2];
        val_8[0] = new System.Func<System.Boolean>(object:  this, method:  System.Boolean AwardController::Collect_New_Level());
        val_8[1] = new System.Func<System.Boolean>(object:  this, method:  System.Boolean AwardController::Collect_New_Level());
        val_12 = null;
        val_13 = val_1.<metaGameBehavior>k__BackingField;
        if(val_13 == 0)
        {
                throw new NullReferenceException();
        }
        
        SetupMessage(titleTxt:  Localization.Localize(key:  "level_award_upper", defaultValue:  "LEVEL AWARD", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "level_progress_changed", defaultValue:  "Your level progress has been changed!", useSingularKey:  false), shownButtons:  val_5, buttonTexts:  val_6, showClose:  false, buttonCallbacks:  val_8, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
    }
    private void ShowNewNameAward()
    {
        int val_12;
        var val_13;
        MetaGameBehavior val_14;
        GameBehavior val_1 = App.getBehavior;
        bool[] val_6 = new bool[2];
        val_6[0] = true;
        string[] val_7 = new string[2];
        val_12 = val_7.Length;
        val_7[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_12 = val_7.Length;
        val_7[1] = "OK";
        System.Func<System.Boolean>[] val_9 = new System.Func<System.Boolean>[2];
        val_9[0] = new System.Func<System.Boolean>(object:  this, method:  System.Boolean AwardController::OnClick_Collect());
        val_9[1] = new System.Func<System.Boolean>(object:  this, method:  System.Boolean AwardController::OnClick_Collect());
        val_13 = null;
        val_14 = val_1.<metaGameBehavior>k__BackingField;
        if(val_14 == 0)
        {
                throw new NullReferenceException();
        }
        
        SetupMessage(titleTxt:  Localization.Localize(key:  "name_changed_upper", defaultValue:  "NAME CHANGED", useSingularKey:  false), messageTxt:  System.String.Format(format:  "{0}\n{1}", arg0:  Localization.Localize(key:  "name_changed_desc", defaultValue:  "Your name has been changed to:", useSingularKey:  false), arg1:  0), shownButtons:  val_6, buttonTexts:  val_7, showClose:  false, buttonCallbacks:  val_9, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
    }
    private void ShowPetsAward()
    {
        decimal val_16;
        int val_17;
        var val_18;
        var val_19;
        var val_20;
        GameBehavior val_1 = App.getBehavior;
        GameEcon val_6 = App.getGameEcon;
        val_16 = 1152921515730962024;
        bool[] val_9 = new bool[2];
        val_9[0] = true;
        string[] val_10 = new string[2];
        val_17 = val_10.Length;
        val_10[0] = Localization.Localize(key:  "collect_upper", defaultValue:  "COLLECT", useSingularKey:  false);
        val_17 = val_10.Length;
        val_10[1] = "OK";
        GameBehavior val_12 = App.getBehavior;
        if(((val_12.<gameplayBehavior>k__BackingField) & 1) != 0)
        {
                val_18 = val_1.<metaGameBehavior>k__BackingField;
            val_19 = 1152921515730962032;
        }
        else
        {
                val_20 = null;
            val_20 = null;
            val_18 = val_1.<metaGameBehavior>k__BackingField;
            val_16 = 1152921504617021480;
            val_19 = 1152921504617021488;
        }
        
        System.Func<System.Boolean>[] val_13 = new System.Func<System.Boolean>[2];
        val_13[0] = new System.Func<System.Boolean>(object:  this, method:  System.Boolean AwardController::OnClick_Collect());
        val_13[1] = new System.Func<System.Boolean>(object:  this, method:  System.Boolean AwardController::OnClick_Collect());
        val_18.SetupMessage(titleTxt:  Localization.Localize(key:  "award_upper", defaultValue:  "AWARD", useSingularKey:  false), messageTxt:  System.String.Format(format:  Localization.Localize(key:  System.String.Format(format:  "you_have_been_gifted_{0}", arg0:  "AWARD"), defaultValue:  "You have been gifted\n{0} pet supplies!", useSingularKey:  false), arg0:  ToString(format:  val_6.numberFormatInt)), shownButtons:  val_9, buttonTexts:  val_10, showClose:  false, buttonCallbacks:  val_13, collectAmount:  new System.Decimal() {flags = val_16, hi = val_16, lo = mem[1152921504617021488], mid = mem[1152921504617021488]}, collectType:  val_13.Length);
    }
    private bool Collect_New_Level()
    {
        if(SceneDictator.GetActiveSceneType() != 2)
        {
                return this.OnClick_Collect();
        }
        
        GameBehavior val_2 = App.getBehavior;
        DefaultHandler<ServerHandler>.Instance.CashOutAward(id:  this.current_award);
        return true;
    }
    private bool OnClick_Collect()
    {
        DefaultHandler<ServerHandler>.Instance.CashOutAward(id:  this.current_award);
        CurrencyController.HandleBalanceChanged(type:  0);
        CurrencyController.HandleBalanceChanged(type:  1);
        return this.FetchAwards();
    }
    public AwardController()
    {
    
    }

}
