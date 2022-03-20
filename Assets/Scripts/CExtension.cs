using UnityEngine;
public static class CExtension
{
    // Methods
    public static void SetText(UnityEngine.GameObject obj, string value)
    {
        bool val_2 = UnityEngine.Object.op_Inequality(x:  obj.GetComponent<UnityEngine.UI.Text>(), y:  0);
        TMPro.TextMeshProUGUI val_3 = obj.GetComponent<TMPro.TextMeshProUGUI>();
        if(val_3 == 0)
        {
                return;
        }
        
        val_3.text = value;
    }
    public static void SetText(UnityEngine.UI.Text objText, string value)
    {
        if(objText != null)
        {
            
        }
        else
        {
                throw new NullReferenceException();
        }
    
    }
    public static void SetTimeText(UnityEngine.UI.Text text, string preFix, int time)
    {
        System.TimeSpan val_1 = System.TimeSpan.FromSeconds(value:  (double)time);
        string val_5 = preFix + System.String.Format(format:  "{0:D2}:{1:D2}", arg0:  val_1._ticks.Minutes, arg1:  val_1._ticks.Seconds)(System.String.Format(format:  "{0:D2}:{1:D2}", arg0:  val_1._ticks.Minutes, arg1:  val_1._ticks.Seconds));
    }

}
