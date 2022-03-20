using UnityEngine;
public class UGUILocalizeText : UGUILocalizeComponent
{
    // Methods
    public override void updateLabel(string val)
    {
        if((this.GetComponent<UnityEngine.UI.Text>()) == 0)
        {
                return;
        }
        
        val = ???;
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    protected override string getCurrentText()
    {
        UnityEngine.UI.Text val_7 = this.GetComponent<UnityEngine.UI.Text>();
        if(val_7 == 0)
        {
                return 0;
        }
        
        val_7 = ???;
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5D0;
    }
    public UGUILocalizeText()
    {
        val_1 = new UnityEngine.MonoBehaviour();
    }

}
