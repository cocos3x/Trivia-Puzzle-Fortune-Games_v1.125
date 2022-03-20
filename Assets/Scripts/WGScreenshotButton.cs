using UnityEngine;
public class WGScreenshotButton : MyButton
{
    // Methods
    private void Awake()
    {
        UGUINetworkedButton val_1 = this.GetComponent<UGUINetworkedButton>();
        System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnConnectionClick, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void WGScreenshotButton::HandleConnectionClick(bool result)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_3;
        }
        
        }
        
        val_1.OnConnectionClick = val_3;
        return;
        label_3:
    }
    private void HandleConnectionClick(bool result)
    {
        var val_13;
        System.Action val_15;
        int val_16;
        var val_17;
        if(result != false)
        {
                WGScreenshotter val_1 = MonoSingletonSelfGenerating<WGScreenshotter>.Instance;
            val_13 = null;
            val_13 = null;
            val_15 = WGScreenshotButton.<>c.<>9__1_0;
            if(val_15 == null)
        {
                System.Action val_2 = null;
            val_15 = val_2;
            val_2 = new System.Action(object:  WGScreenshotButton.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGScreenshotButton.<>c::<HandleConnectionClick>b__1_0());
            WGScreenshotButton.<>c.<>9__1_0 = val_15;
        }
        
            val_1.OnScreenshotTaken = val_15;
            WGScreenshotter val_3 = MonoSingletonSelfGenerating<WGScreenshotter>.Instance;
            UnityEngine.Coroutine val_5 = val_3.StartCoroutine(routine:  val_3.TakeScreenshot(postToFacebook:  false));
            return;
        }
        
        bool[] val_10 = new bool[2];
        val_10[0] = true;
        string[] val_11 = new string[2];
        val_16 = val_11.Length;
        val_11[0] = Localization.Localize(key:  "ok_upper", defaultValue:  "OK", useSingularKey:  false);
        val_16 = val_11.Length;
        val_11[1] = "NULL";
        val_17 = null;
        val_17 = null;
        MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGMessagePopup>(showNext:  false).SetupMessage(titleTxt:  Localization.Localize(key:  "internet_required_upper", defaultValue:  "INTERNET REQUIRED", useSingularKey:  false), messageTxt:  Localization.Localize(key:  "connection_required_explanation", defaultValue:  "Sorry, internet connection required.\n\nPlease make sure you are connected to the internet and try again!", useSingularKey:  false), shownButtons:  val_10, buttonTexts:  val_11, showClose:  false, buttonCallbacks:  0, collectAmount:  new System.Decimal() {flags = System.Decimal.MinusOne, hi = System.Decimal.MinusOne, lo = System.Decimal.Powers10.__il2cppRuntimeField_30, mid = System.Decimal.Powers10.__il2cppRuntimeField_30}, collectType:  "credits");
    }
    public WGScreenshotButton()
    {
    
    }

}
