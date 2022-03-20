using UnityEngine;
public class FPHKeyButton : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text letterText;
    private UnityEngine.UI.Image buttonImage;
    private UnityEngine.UI.Button myButton;
    private UnityEngine.CanvasGroup powerupRemovedGroup;
    private UnityEngine.Color buttonCorrectColor;
    private UnityEngine.Color buttonWrongColor;
    private UnityEngine.ParticleSystem glowAnim;
    private char <KeyChar>k__BackingField;
    public System.Action onClickAction;
    private FPHKeyButton.KeyState myState;
    
    // Properties
    public char KeyChar { get; set; }
    
    // Methods
    public char get_KeyChar()
    {
        return (char)this.<KeyChar>k__BackingField;
    }
    private void set_KeyChar(char value)
    {
        this.<KeyChar>k__BackingField = value;
    }
    public void Init(char myCharacter, FPHKeyButton.KeyState state)
    {
        char val_4 = myCharacter;
        this.myButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void FPHKeyButton::OnClick()));
        this.<KeyChar>k__BackingField = val_4;
        if((FPHKeyboard.IsLetter(value:  val_4 = myCharacter)) != false)
        {
                val_4 = this.letterText;
            string val_3 = myCharacter.ToString();
        }
        
        if(state > 3)
        {
                return;
        }
        
        var val_4 = 32562460 + (state) << 2;
        val_4 = val_4 + 32562460;
        goto (32562460 + (state) << 2 + 32562460);
    }
    private void OnClick()
    {
        if(this.onClickAction == null)
        {
                return;
        }
        
        this.onClickAction.Invoke();
    }
    public void SetPurchased(bool isCorrectLetter)
    {
        UnityEngine.Color val_2;
        var val_3;
        var val_4;
        var val_5;
        if((FPHKeyboard.IsLetter(value:  this.<KeyChar>k__BackingField)) == false)
        {
                return;
        }
        
        this.glowAnim.Stop();
        if(isCorrectLetter == false)
        {
            goto label_5;
        }
        
        val_2 = this.buttonCorrectColor;
        val_3 = 1152921515959344524;
        val_4 = 1152921515959344528;
        val_5 = 1152921515959344532;
        if(this.buttonImage != null)
        {
            goto label_6;
        }
        
        label_5:
        val_2 = this.buttonWrongColor;
        val_3 = 1152921515959344540;
        val_4 = 1152921515959344544;
        val_5 = 1152921515959344548;
        label_6:
        this.buttonImage.color = new UnityEngine.Color() {r = this.buttonWrongColor.r, g = 2.508578E-28f, b = 2.508578E-28f, a = 2.508578E-28f};
        this.myButton.interactable = false;
        this.myState = 2;
    }
    public void SetPowerupRemoved()
    {
        if((FPHKeyboard.IsLetter(value:  this.<KeyChar>k__BackingField)) == false)
        {
                return;
        }
        
        this.myButton.interactable = false;
        this.myState = 3;
        this.powerupRemovedGroup.alpha = 1f;
    }
    public void SetInactive()
    {
        this.glowAnim.Stop();
        this.myButton.interactable = false;
        this.myState = 0;
        this.powerupRemovedGroup.alpha = 0f;
    }
    public void SetActive()
    {
        this.glowAnim.Stop();
        this.myButton.interactable = true;
        this.myState = 1;
        this.powerupRemovedGroup.alpha = 0f;
    }
    public void SetHighlight()
    {
        if(this.glowAnim != null)
        {
                this.glowAnim.Play();
            return;
        }
        
        throw new NullReferenceException();
    }
    public void StopHighlight()
    {
        if(this.glowAnim != null)
        {
                this.glowAnim.Stop();
            return;
        }
        
        throw new NullReferenceException();
    }
    public FPHKeyButton()
    {
        UnityEngine.Color val_1 = UnityEngine.Color.white;
        this.buttonCorrectColor = val_1;
        mem[1152921515960110732] = val_1.g;
        mem[1152921515960110736] = val_1.b;
        mem[1152921515960110740] = val_1.a;
        UnityEngine.Color val_2 = UnityEngine.Color.white;
        this.buttonWrongColor = val_2;
        mem[1152921515960110748] = val_2.g;
        mem[1152921515960110752] = val_2.b;
        mem[1152921515960110756] = val_2.a;
        this.myState = 1;
    }

}
