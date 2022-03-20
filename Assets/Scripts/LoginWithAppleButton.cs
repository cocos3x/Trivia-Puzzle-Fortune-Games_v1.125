using UnityEngine;
public class LoginWithAppleButton : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject overlayButton;
    
    // Methods
    private void Awake()
    {
    
    }
    private void OnEnable()
    {
        this.UpdateState();
    }
    public void OnClick()
    {
        MonoSingletonSelfGenerating<SignInWithApplePlugin>.Instance.LogIn();
    }
    public void UpdateState()
    {
        NGUITools.SetActive(go:  this.overlayButton, state:  (~(MonoSingletonSelfGenerating<SignInWithApplePlugin>.Instance.IsSignInAvailable())) & 1);
    }
    public LoginWithAppleButton()
    {
    
    }

}
