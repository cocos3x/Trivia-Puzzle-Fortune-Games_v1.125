using UnityEngine;
public class WGDailyChallengeManagerHelper
{
    // Fields
    private const int MORNING_MIN_HOUR = 0;
    private const int MORNING_MAX_HOUR = 12;
    private const int EVENING_MIN_HOUR = 12;
    private const int EVENING_MAX_HOUR = 24;
    
    // Methods
    public static System.TimeSpan GetTimeSpanToNextChallenge()
    {
        if(WGDailyChallengeManagerHelper.MorningChallengeAvailableNow() != false)
        {
                System.DateTime val_2 = WGDailyChallengeManagerHelper.MorningBeginTime();
        }
        else
        {
                if(WGDailyChallengeManagerHelper.EveningChallengeAvailableNow() != false)
        {
                System.DateTime val_4 = WGDailyChallengeManagerHelper.EveningBeginTime();
        }
        else
        {
                System.DateTime val_5 = WGDailyChallengeManagerHelper.EveningEndTime();
            System.DateTime val_6 = val_5.dateData.AddHours(value:  0);
        }
        
        }
        
        System.DateTime val_7 = DateTimeCheat.Now;
        System.TimeSpan val_8 = val_6.dateData.Subtract(value:  new System.DateTime() {dateData = val_7.dateData});
        return (System.TimeSpan)val_8._ticks;
    }
    private static System.DateTime MorningBeginTime()
    {
        System.DateTime val_1 = DateTimeCheat.Today;
        System.DateTime val_2 = val_1.dateData.AddHours(value:  0);
        return (System.DateTime)val_2.dateData;
    }
    public static bool MorningChallengeAvailableNow()
    {
        var val_6;
        System.DateTime val_1 = DateTimeCheat.Now;
        if((val_1.dateData.Hour & 2147483648) == 0)
        {
                System.DateTime val_3 = DateTimeCheat.Now;
            var val_5 = (val_3.dateData.Hour < 12) ? 1 : 0;
            return (bool)val_6;
        }
        
        val_6 = 0;
        return (bool)val_6;
    }
    private static System.DateTime EveningBeginTime()
    {
        System.DateTime val_1 = DateTimeCheat.Today;
        System.DateTime val_2 = val_1.dateData.AddHours(value:  12);
        return (System.DateTime)val_2.dateData;
    }
    private static System.DateTime EveningEndTime()
    {
        System.DateTime val_1 = DateTimeCheat.Today;
        System.DateTime val_2 = val_1.dateData.AddHours(value:  24);
        return (System.DateTime)val_2.dateData;
    }
    public static bool EveningChallengeAvailableNow()
    {
        var val_6;
        System.DateTime val_1 = DateTimeCheat.Now;
        if(val_1.dateData.Hour >= 12)
        {
                System.DateTime val_3 = DateTimeCheat.Now;
            var val_5 = (val_3.dateData.Hour < 24) ? 1 : 0;
            return (bool)val_6;
        }
        
        val_6 = 0;
        return (bool)val_6;
    }
    public static string GetLocMorningChallenge()
    {
        return Localization.Localize(key:  "morning_challenge_upper", defaultValue:  "MORNING CHALLENGE", useSingularKey:  false);
    }
    public static string GetLocEveningChallenge()
    {
        return Localization.Localize(key:  "evening_challenge_upper", defaultValue:  "EVENING CHALLENGE", useSingularKey:  false);
    }
    public WGDailyChallengeManagerHelper()
    {
    
    }

}
