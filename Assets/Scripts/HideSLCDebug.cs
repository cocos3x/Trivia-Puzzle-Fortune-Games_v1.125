using UnityEngine;
public class HideSLCDebug : MonoBehaviour
{
    // Fields
    public UnityEngine.UI.Image strikeThrough;
    private static bool hidden;
    public UnityEngine.UI.Button button;
    
    // Methods
    private void Awake()
    {
        this.button = this.GetComponent<UnityEngine.UI.Button>();
        this.strikeThrough.canvasRenderer.SetAlpha(alpha:  0f);
    }
    private void Start()
    {
    
    }
    private void OnEnable()
    {
        null = null;
        if(HideSLCDebug.hidden == false)
        {
                return;
        }
        
        this.OnClick();
    }
    public void OnClick()
    {
        this.strikeThrough.CrossFadeAlpha(alpha:  (HideSLCDebug.hidden == false) ? 0f : 1f, duration:  0.2f, ignoreTimeScale:  true);
        HideSLCDebug.ToggleHideButton(overrideMessage:  "");
    }
    public static void ToggleHideButton(string overrideMessage = "")
    {
        var val_11;
        UnityEngine.Object val_12;
        var val_13;
        string val_14;
        val_11 = null;
        val_11 = null;
        bool val_11 = HideSLCDebug.hidden;
        val_11 = val_11 ^ 1;
        HideSLCDebug.hidden = val_11;
        UnityEngine.GameObject val_1 = UnityEngine.GameObject.FindGameObjectWithTag(tag:  "SRDebugButton");
        if((UnityEngine.Object.op_Implicit(exists:  val_1)) != false)
        {
                val_12 = val_1.GetComponent<UnityEngine.UI.Image>();
            if((UnityEngine.Object.op_Implicit(exists:  val_12)) != false)
        {
                val_12 = val_12.canvasRenderer;
            val_12.SetAlpha(alpha:  (HideSLCDebug.hidden == false) ? 1f : 0f);
        }
        
            SRF.UI.FlashGraphic val_7 = val_1.GetComponent<SRF.UI.FlashGraphic>();
            if((UnityEngine.Object.op_Implicit(exists:  val_7)) != false)
        {
                val_7.enabled = (HideSLCDebug.hidden == false) ? 1 : 0;
        }
        
        }
        
        if((System.String.IsNullOrEmpty(value:  overrideMessage)) != true)
        {
                DebugMessageDisplay.DisplayMessage(msgTxt:  overrideMessage, displayTime:  1f);
        }
        
        val_13 = null;
        val_13 = null;
        if(HideSLCDebug.hidden != false)
        {
                val_14 = "The 12 gigs debug tab will now be <b>hidden</b>.\n(You can still double-tap the area to open the debug panel)";
        }
        else
        {
                val_14 = "The 12 gigs debug tab will be <b>visible</b>";
        }
        
        DebugMessageDisplay.DisplayMessage(msgTxt:  val_14, displayTime:  3f);
    }
    public HideSLCDebug()
    {
    
    }
    private static HideSLCDebug()
    {
    
    }

}
