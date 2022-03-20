using UnityEngine;
public class UGUILocalizeTMP : UGUILocalizeText
{
    // Methods
    public override void updateLabel(string val)
    {
        TMPro.TextMeshProUGUI val_1 = this.GetComponent<TMPro.TextMeshProUGUI>();
        if(val_1 == 0)
        {
                return;
        }
        
        val_1.text = val;
    }
    protected override string getCurrentText()
    {
        TMPro.TextMeshProUGUI val_1 = this.GetComponent<TMPro.TextMeshProUGUI>();
        if(val_1 == 0)
        {
                return 0;
        }
        
        return val_1.text;
    }
    public UGUILocalizeTMP()
    {
        val_1 = new UnityEngine.MonoBehaviour();
    }

}
