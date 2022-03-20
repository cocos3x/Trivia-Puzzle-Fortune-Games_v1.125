using UnityEngine;
public class WGEmailLoginPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject emailGroup;
    private UnityEngine.UI.InputField emailInput;
    private UnityEngine.UI.Button submitEmail;
    private UnityEngine.UI.Text emailValidError;
    private UnityEngine.GameObject confirmGroup;
    private UnityEngine.UI.InputField codeInput;
    private UnityEngine.UI.Button submitCode;
    private UnityEngine.UI.Button resendCode;
    private UnityEngine.UI.Text alertMessage;
    private UnityEngine.GameObject loadingImage;
    private System.Action<bool> OnLoginAction;
    private string userEmail;
    private string verificationCode;
    private bool resendCodeRequest;
    
    // Methods
    public void add_OnLoginAction(System.Action<bool> value)
    {
        do
        {
            if((System.Delegate.Combine(a:  this.OnLoginAction, b:  value)) != null)
        {
                if(null != null)
        {
            goto label_2;
        }
        
        }
        
        }
        while(this.OnLoginAction != 1152921517626393544);
        
        return;
        label_2:
    }
    public void remove_OnLoginAction(System.Action<bool> value)
    {
        do
        {
            if((System.Delegate.Remove(source:  this.OnLoginAction, value:  value)) != null)
        {
                if(null != null)
        {
            goto label_2;
        }
        
        }
        
        }
        while(this.OnLoginAction != 1152921517626530120);
        
        return;
        label_2:
    }
    private void Awake()
    {
        this.submitEmail.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGEmailLoginPopup::OnClickSubmitEmail()));
        this.submitCode.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGEmailLoginPopup::OnClickSubmitCode()));
        this.resendCode.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGEmailLoginPopup::OnClickResendCode()));
        this.emailInput.m_OnEndEdit.AddListener(call:  new UnityEngine.Events.UnityAction<System.String>(object:  this, method:  System.Void WGEmailLoginPopup::OnValueChanged_Email(string value)));
        this.codeInput.m_OnEndEdit.AddListener(call:  new UnityEngine.Events.UnityAction<System.String>(object:  this, method:  System.Void WGEmailLoginPopup::OnValueChanged_Code(string value)));
    }
    public void UpdateUI(WGEmailLoginPopup.State state)
    {
        this.emailGroup.SetActive(value:  (state == 0) ? 1 : 0);
        this.confirmGroup.SetActive(value:  (state == 1) ? 1 : 0);
        this.emailValidError.gameObject.SetActive(value:  false);
        this.alertMessage.gameObject.SetActive(value:  false);
        this.loadingImage.SetActive(value:  false);
        this.resendCode.interactable = true;
        if(this.resendCodeRequest == false)
        {
                return;
        }
        
        if(state != 1)
        {
                return;
        }
        
        this.ShowAlertMessage(errorCode:  false);
        this.resendCodeRequest = false;
    }
    public void Close()
    {
        if(this.OnLoginAction == null)
        {
                return;
        }
        
        this.OnLoginAction.Invoke(obj:  false);
    }
    public void ShowAlertMessage(bool errorCode)
    {
        this.alertMessage.gameObject.SetActive(value:  true);
        string val_4 = Localization.Localize(key:  (errorCode != true) ? "email_code_error" : "code_sent", defaultValue:  (errorCode != true) ? "We\'re Sorry, the code didn\'t match. Input the right code or try resending another one." : "Code Sent! Check your Inbox!", useSingularKey:  false);
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void OnClickSubmitEmail()
    {
        if((System.String.IsNullOrEmpty(value:  this.userEmail)) == true)
        {
                return;
        }
        
        Player val_2 = App.Player;
        val_2.email = this.userEmail;
        App.Player.SaveState();
        MonoSingleton<RestoreProgressManager>.Instance.OnEmailLogin(email:  this.userEmail);
        if(this.OnLoginAction == null)
        {
                return;
        }
        
        this.OnLoginAction.Invoke(obj:  true);
    }
    private void OnClickSubmitCode()
    {
        if((System.String.IsNullOrEmpty(value:  this.verificationCode)) == true)
        {
                return;
        }
        
        MonoSingleton<RestoreProgressManager>.Instance.ConfirmVerificationCode(code:  this.verificationCode);
        if(this.OnLoginAction == null)
        {
                return;
        }
        
        this.OnLoginAction.Invoke(obj:  true);
    }
    private void OnClickResendCode()
    {
        this.resendCodeRequest = true;
        Player val_2 = App.Player;
        MonoSingleton<RestoreProgressManager>.Instance.OnEmailLogin(email:  val_2.email);
        this.alertMessage.gameObject.SetActive(value:  false);
        this.resendCode.interactable = false;
        this.submitCode.interactable = false;
        this.loadingImage.SetActive(value:  true);
    }
    private void OnValueChanged_Email(string value)
    {
        this.submitEmail.interactable = false;
        if(value.m_stringLength == 0)
        {
                return;
        }
        
        UnityEngine.GameObject val_2 = this.emailValidError.gameObject;
        if((this.submitEmail.isValidEmail(email:  value)) != false)
        {
                val_2.SetActive(value:  false);
            this.submitEmail.interactable = true;
            this.userEmail = value;
            return;
        }
        
        val_2.SetActive(value:  true);
    }
    private void OnValueChanged_Code(string value)
    {
        this.submitCode.interactable = false;
        if(value.m_stringLength == 0)
        {
                return;
        }
        
        if((this.submitCode.isNumber(value:  value)) == false)
        {
                return;
        }
        
        this.submitCode.interactable = true;
        this.verificationCode = value;
    }
    private bool isValidEmail(string email)
    {
        return new System.Text.RegularExpressions.Regex(pattern:  "\\A(?:[a-z0-9!#$%&\'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&\'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\\Z", options:  1).IsMatch(input:  email);
    }
    private bool isNumber(string value)
    {
        return new System.Text.RegularExpressions.Regex(pattern:  "^[0-9]{5}$", options:  1).IsMatch(input:  value);
    }
    public WGEmailLoginPopup()
    {
    
    }

}
