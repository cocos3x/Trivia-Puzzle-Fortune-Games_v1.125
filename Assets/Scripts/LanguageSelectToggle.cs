using UnityEngine;
public class LanguageSelectToggle : MonoBehaviour
{
    // Fields
    public UnityEngine.UI.Toggle toggle;
    private UnityEngine.GameObject english_only_group;
    private UnityEngine.GameObject selectable_group;
    private System.Collections.Generic.List<UnityEngine.UI.Text> language_texts;
    private System.Collections.Generic.List<UnityEngine.UI.Image> image_flags;
    
    // Methods
    public void Setup(string locLanguage, bool isSolo, UnityEngine.Sprite flag)
    {
        string val_4 = locLanguage;
        this.english_only_group.SetActive(value:  isSolo);
        var val_4 = ~isSolo;
        this.selectable_group.SetActive(value:  val_4 & 1);
        var val_5 = 0;
        label_7:
        if(val_5 >= val_4)
        {
            goto label_4;
        }
        
        if(val_4 <= val_5)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_4 = val_4 + 0;
        val_5 = val_5 + 1;
        if(this.language_texts != null)
        {
            goto label_7;
        }
        
        label_4:
        if(flag == 0)
        {
                return;
        }
        
        val_4 = 0;
        do
        {
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            (UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 0) + 32.sprite = flag;
            val_4 = val_4 + 1;
        }
        while(this.image_flags != null);
        
        throw new NullReferenceException();
    }
    public LanguageSelectToggle()
    {
    
    }

}
