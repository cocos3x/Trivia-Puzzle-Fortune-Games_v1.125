using UnityEngine;
public static class GenericStringExtentions
{
    // Methods
    public static string ToString(System.TimeSpan span, bool formatted = True)
    {
        object val_14;
        int val_15;
        val_14 = formatted;
        if(val_14 == false)
        {
            goto label_1;
        }
        
        if(span._ticks.Hours < 1)
        {
            goto label_2;
        }
        
        val_15 = span._ticks.Hours;
        if(span._ticks.Days >= 1)
        {
                val_15 = val_15 + (span._ticks.Days * 24);
        }
        
        val_14 = val_15;
        string val_7 = System.String.Format(format:  "{0:D2}:{1:D2}:{2:D2}", arg0:  val_15, arg1:  span._ticks.Minutes, arg2:  span._ticks.Seconds);
        return (string)System.String.Format(format:  "{0:D2}:{1:D2}", arg0:  int val_10 = UnityEngine.Mathf.Max(a:  0, b:  span._ticks.Minutes), arg1:  UnityEngine.Mathf.Max(a:  0, b:  span._ticks.Seconds));
        label_1:
        string val_8 = span._ticks.ToString();
        return (string)System.String.Format(format:  "{0:D2}:{1:D2}", arg0:  val_10, arg1:  UnityEngine.Mathf.Max(a:  0, b:  span._ticks.Seconds));
        label_2:
        val_14 = val_10;
        return (string)System.String.Format(format:  "{0:D2}:{1:D2}", arg0:  val_10, arg1:  UnityEngine.Mathf.Max(a:  0, b:  span._ticks.Seconds));
    }

}
