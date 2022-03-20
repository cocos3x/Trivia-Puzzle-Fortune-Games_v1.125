using UnityEngine;
public class InputFieldPlus : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.InputField inputField;
    private bool LetterOrDigit;
    private bool WhiteSpace;
    private bool Punctuation;
    private char[] Additional;
    
    // Methods
    private void Start()
    {
        UnityEngine.UI.InputField val_6;
        if(this.inputField != 0)
        {
            goto label_3;
        }
        
        UnityEngine.UI.InputField val_3 = this.gameObject.GetComponent<UnityEngine.UI.InputField>();
        val_6 = val_3;
        this.inputField = val_3;
        if(val_6 != null)
        {
            goto label_5;
        }
        
        label_3:
        val_6 = this.inputField;
        label_5:
        System.Delegate val_5 = System.Delegate.Combine(a:  this.inputField.m_OnValidateInput, b:  new InputField.OnValidateInput(object:  this, method:  System.Char InputFieldPlus::<Start>b__5_0(string input, int charIndex, char addedChar)));
        if(val_5 != null)
        {
                if(null != null)
        {
            goto label_9;
        }
        
        }
        
        val_6.onValidateInput = val_5;
        return;
        label_9:
    }
    private char MyValidate(char c)
    {
        var val_6;
        if(this.LetterOrDigit != false)
        {
                if((System.Char.IsLetterOrDigit(c:  c)) == true)
        {
            goto label_8;
        }
        
        }
        
        if(this.WhiteSpace != false)
        {
                if((System.Char.IsWhiteSpace(c:  c)) == true)
        {
            goto label_8;
        }
        
        }
        
        if(this.Punctuation == false)
        {
                return (char)((this.MatchesAdds(c:  c)) != true) ? c : 0;
        }
        
        if((System.Char.IsPunctuation(c:  c)) == false)
        {
                return (char)((this.MatchesAdds(c:  c)) != true) ? c : 0;
        }
        
        label_8:
        val_6 = c;
        return (char)((this.MatchesAdds(c:  c)) != true) ? c : 0;
    }
    private bool MatchesAdds(char c)
    {
        var val_2 = 0;
        if(this.Additional.Length == 0)
        {
                return (bool)val_2;
        }
        
        if(this.Additional.Length < 1)
        {
                return (bool)val_2;
        }
        
        var val_3 = 0;
        label_6:
        if((c.Equals(obj:  this.Additional[0])) == true)
        {
            goto label_4;
        }
        
        val_3 = val_3 + 1;
        if(val_3 < (this.Additional.Length << ))
        {
            goto label_6;
        }
        
        val_2 = 0;
        return (bool)val_2;
        label_4:
        val_2 = 1;
        return (bool)val_2;
    }
    public InputFieldPlus()
    {
        this.LetterOrDigit = true;
        this.WhiteSpace = true;
        this.Punctuation = true;
    }
    private char <Start>b__5_0(string input, int charIndex, char addedChar)
    {
        return this.MyValidate(c:  addedChar);
    }

}
