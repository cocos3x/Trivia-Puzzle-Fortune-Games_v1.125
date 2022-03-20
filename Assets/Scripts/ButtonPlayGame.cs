using UnityEngine;
public class ButtonPlayGame : MyButton
{
    // Fields
    protected UnityEngine.UI.Text buttonLabel;
    
    // Methods
    protected override void Start()
    {
        NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnLocalize");
        this.Start();
        this.SetupPlayText();
    }
    private void OnLocalize()
    {
        this.SetupPlayText();
    }
    protected void SetupPlayText()
    {
        UnityEngine.UI.Text val_16;
        MetaGameBehavior val_17;
        val_16 = this;
        if(this.buttonLabel == 0)
        {
                return;
        }
        
        GameBehavior val_2 = App.getBehavior;
        val_17 = val_2.<metaGameBehavior>k__BackingField;
        val_16 = this.buttonLabel;
        if(val_17 == 1)
        {
                string val_3 = Localization.Localize(key:  "play_upper", defaultValue:  "PLAY", useSingularKey:  false);
            val_17 = val_16;
            val_16 = ???;
        }
        else
        {
                decimal val_5 = System.Decimal.op_Implicit(value:  val_17);
            decimal val_6 = new System.Decimal(value:  16);
            string val_8 = System.String.Format(format:  "{0} {1}", arg0:  Localization.Localize(key:  "level_upper", defaultValue:  "LEVEL", useSingularKey:  false), arg1:  MetricSystem.Abbreviate(number:  new System.Decimal() {flags = val_5.flags, hi = val_5.hi, lo = val_5.lo, mid = val_5.mid}, maxSigFigs:  2, round:  false, useColor:  false, maxValueWithoutAbbr:  new System.Decimal() {flags = val_6.flags, hi = val_6.flags, lo = val_6.lo, mid = val_6.lo}, useRichText:  false, withSpaces:  false));
        }
    
    }
    public override void OnButtonClick()
    {
        var val_5;
        var val_6;
        this.OnButtonClick();
        val_5 = null;
        val_5 = null;
        TRVMainController.noAnswerSelectedCharacter = 0;
        if((MonoSingleton<WGDailyChallengeManager>.Instance) != 0)
        {
                MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge = false;
        }
        
        val_6 = null;
        val_6 = null;
        AmplitudePluginHelper.lastFeatureAccessPoint = 4;
        GameBehavior val_4 = App.getBehavior;
        goto typeof(MetaGameBehavior).__il2cppRuntimeField_3D0;
    }
    public ButtonPlayGame()
    {
    
    }

}
