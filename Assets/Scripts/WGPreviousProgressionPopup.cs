using UnityEngine;
public class WGPreviousProgressionPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text progressionText;
    private UnityEngine.UI.Button okButton;
    private UnityEngine.UI.Button noButton;
    private UnityEngine.UI.Button cancelButton;
    private System.Action<WGPreviousProgressionPopup.Result> OnClickButton;
    
    // Methods
    public void add_OnClickButton(System.Action<WGPreviousProgressionPopup.Result> value)
    {
        do
        {
            if((System.Delegate.Combine(a:  this.OnClickButton, b:  value)) != null)
        {
                if(null != null)
        {
            goto label_2;
        }
        
        }
        
        }
        while(this.OnClickButton != 1152921517628508344);
        
        return;
        label_2:
    }
    public void remove_OnClickButton(System.Action<WGPreviousProgressionPopup.Result> value)
    {
        do
        {
            if((System.Delegate.Remove(source:  this.OnClickButton, value:  value)) != null)
        {
                if(null != null)
        {
            goto label_2;
        }
        
        }
        
        }
        while(this.OnClickButton != 1152921517628644920);
        
        return;
        label_2:
    }
    private void Awake()
    {
        this.okButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGPreviousProgressionPopup::OnClickOk()));
        this.noButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGPreviousProgressionPopup::OnClickNo()));
        this.cancelButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGPreviousProgressionPopup::OnClickCancel()));
    }
    public void LoadProgression(RestoreProgressManager.Progression progression)
    {
        object[] val_2 = new object[4];
        val_2[0] = progression.<lastPlayed>k__BackingField.ToString(format:  "MM/dd/yyyy");
        val_2[1] = progression.<level>k__BackingField;
        val_2[2] = progression.<coins>k__BackingField;
        val_2[3] = progression.<goldenCurrency>k__BackingField;
        string val_4 = System.String.Format(format:  Localization.Localize(key:  "previous_progression", defaultValue:  "Last Played: {0}\nLevel: {1}\nCoins: {2}\nGolden Apples: {3}", useSingularKey:  false), args:  val_2);
    }
    private void OnClickOk()
    {
        if(this.OnClickButton == null)
        {
                return;
        }
        
        this.OnClickButton.Invoke(obj:  0);
    }
    private void OnClickNo()
    {
        if(this.OnClickButton == null)
        {
                return;
        }
        
        this.OnClickButton.Invoke(obj:  1);
    }
    private void OnClickCancel()
    {
        if(this.OnClickButton == null)
        {
                return;
        }
        
        this.OnClickButton.Invoke(obj:  2);
    }
    public WGPreviousProgressionPopup()
    {
    
    }

}
