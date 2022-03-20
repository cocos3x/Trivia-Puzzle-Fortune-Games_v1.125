using UnityEngine;
public class TRVMoreCategoriesPopup : MonoBehaviour
{
    // Fields
    public const string POPUP_SHOWN_KEY = "moreCatShown";
    private UnityEngine.UI.Button continueButton;
    private UnityEngine.UI.Button closeButton;
    private System.Collections.Generic.List<UnityEngine.UI.Text> categoryText;
    private System.Collections.Generic.List<UnityEngine.UI.Image> categoryImage;
    private System.Collections.Generic.List<string> categoriesToShow;
    
    // Methods
    private void OnEnable()
    {
        System.Collections.Generic.List<System.String> val_6;
        var val_7;
        var val_8;
        var val_9;
        System.Collections.Generic.List<System.String> val_10;
        System.Collections.Generic.List<System.String> val_11;
        this.continueButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVMoreCategoriesPopup::Close()));
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVMoreCategoriesPopup::Close()));
        val_6 = this.categoriesToShow;
        var val_7 = 0;
        val_7 = 32;
        label_25:
        if(val_7 >= this.closeButton)
        {
            goto label_6;
        }
        
        if((val_7 >= this.closeButton) || (val_7 >= this.categoryImage))
        {
            goto label_10;
        }
        
        if(this.closeButton > val_7)
        {
                val_8 = val_7;
            val_9 = this.closeButton + val_7;
        }
        else
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_10 = this.categoriesToShow;
            val_8 = 0;
        }
        
        if(this.categoryImage <= val_7)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_6 = mem[null];
        if(val_6 <= val_7)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_6 = val_6 + 0;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        (mem[null] + 0) + 32.sprite = MonoSingleton<TRVUtils>.Instance.GetCategoryIcon(category:  (MonoSingleton<T>.__il2cppRuntimeField_cctor_finished + 0) + 32);
        val_11 = this.categoriesToShow;
        val_7 = val_7 + 1;
        val_7 = val_7 + 8;
        if(val_11 != null)
        {
            goto label_25;
        }
        
        throw new NullReferenceException();
        label_10:
        UnityEngine.Debug.LogError(message:  "More Categories Popup is borked, failing out");
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        label_6:
        CPlayerPrefs.SetBool(key:  "moreCatShown", value:  true);
        CPlayerPrefs.Save();
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public TRVMoreCategoriesPopup()
    {
    
    }

}
