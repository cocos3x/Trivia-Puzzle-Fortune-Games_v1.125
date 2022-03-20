using UnityEngine;
public class WGEventButton_CustomEventText : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text customEventText;
    private UnityEngine.Transform suffixGroup;
    private UnityEngine.UI.Text textSuffix;
    private UnityEngine.GameObject plusText;
    
    // Methods
    private void ResetUI()
    {
        MethodExtensionForMonoBehaviourTransform.SetActiveChildren(t:  this.suffixGroup, state:  false);
    }
    public void Setup(string eventName)
    {
        UnityEngine.UI.Text val_35;
        var val_36;
        var val_37;
        float val_38;
        MethodExtensionForMonoBehaviourTransform.SetActiveChildren(t:  this.suffixGroup, state:  false);
        if((System.String.op_Equality(a:  eventName, b:  "Leaderboard")) != false)
        {
                val_36 = null;
            val_36 = null;
            val_37 = null;
            val_37 = null;
            bool val_3 = LeaderboardEventHandler.instance.GetCurrentRankText().Contains(value:  "+");
            if(val_3 != true)
        {
                string val_4 = Ordinal.AddOrdinal(num:  370180096);
        }
        
            this.textSuffix.gameObject.SetActive(value:  val_3 ^ 1);
            this.plusText.SetActive(value:  val_3);
            UnityEngine.Rect val_10 = this.customEventText.GetComponent<UnityEngine.RectTransform>().rect;
            val_38 = val_10.m_XMin.width;
            UnityEngine.Rect val_13 = this.customEventText.GetComponent<UnityEngine.RectTransform>().rect;
            UnityEngine.Vector2 val_17 = new UnityEngine.Vector2(x:  val_38, y:  (val_2.m_stringLength == 1) ? 55f : val_13.m_XMin.height);
            this.customEventText.GetComponent<UnityEngine.RectTransform>().sizeDelta = new UnityEngine.Vector2() {x = val_17.x, y = val_17.y};
            val_35 = this.customEventText;
            string val_20 = Localization.Localize(key:  "leaderboard_upper", defaultValue:  "LEADERBOARD", useSingularKey:  false)(Localization.Localize(key:  "leaderboard_upper", defaultValue:  "LEADERBOARD", useSingularKey:  false)) + (val_2.m_stringLength == 1) ? "  " : " "((val_2.m_stringLength == 1) ? "  " : " ") + LeaderboardEventHandler.instance.playerInfo;
        }
        else
        {
                if((System.String.op_Equality(a:  eventName, b:  "LightningWords")) != false)
        {
                this.customEventText.alignment = 4;
            this.customEventText.horizontalOverflow = 0;
            this.customEventText.GetComponent<UnityEngine.UI.LayoutElement>().enabled = true;
            UnityEngine.RectTransform val_23 = this.customEventText.GetComponent<UnityEngine.RectTransform>();
            UnityEngine.Vector3 val_24 = val_23.localPosition;
            val_38 = val_24.y;
            UnityEngine.Vector3 val_26 = new UnityEngine.Vector3(x:  0f, y:  val_38, z:  val_24.z);
            this.customEventText.GetComponent<UnityEngine.RectTransform>().localPosition = new UnityEngine.Vector3() {x = val_26.x, y = val_26.y, z = val_26.z};
            val_35 = this.customEventText.GetComponent<UnityEngine.RectTransform>();
            UnityEngine.Rect val_28 = val_23.rect;
            UnityEngine.Vector2 val_30 = new UnityEngine.Vector2(x:  500f, y:  val_28.m_XMin.height);
            val_35.sizeDelta = new UnityEngine.Vector2() {x = val_30.x, y = val_30.y};
        }
        else
        {
                if(CompanyDevices.Instance.CompanyDevice() != false)
        {
                UnityEngine.Debug.LogError(message:  eventName + ": Event Custom Text is Not Implemented!"(": Event Custom Text is Not Implemented!"));
        }
        
        }
        
        }
        
        this.gameObject.SetActive(value:  true);
    }
    public WGEventButton_CustomEventText()
    {
    
    }

}
