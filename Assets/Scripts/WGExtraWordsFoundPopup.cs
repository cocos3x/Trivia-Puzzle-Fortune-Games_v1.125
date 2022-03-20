using UnityEngine;
public class WGExtraWordsFoundPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button infoButton;
    private UnityEngine.UI.Button closeButton;
    private UnityEngine.UI.Text wordListingLabel;
    
    // Methods
    private void Start()
    {
        this.infoButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGExtraWordsFoundPopup::OnInfoClicked()));
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGExtraWordsFoundPopup::OnCloseClicked()));
        this.Initialize();
    }
    private void Initialize()
    {
        System.Collections.Generic.IEnumerable<T> val_5 = 1152921504878039040;
        if(ExtraWord.GAMETYPE_CATEGORY_LEVELS != 0)
        {
                val_5 = mem[ExtraWord.GAMETYPE_CATEGORY_LEVELS + 32];
            val_5 = ExtraWord.GAMETYPE_CATEGORY_LEVELS + 32;
            if(val_5 != 0)
        {
                new System.Collections.Generic.List<System.String>(collection:  val_5).Sort();
            val_5 = "";
            if(1152921515899197520 >= 1)
        {
                var val_5 = 0;
            do
        {
            if(val_5 >= 1152921515899197520)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_5 = val_5 + "WGInviteManager:: Not trying to become a recruit, as the server returned false."("WGInviteManager:: Not trying to become a recruit, as the server returned false.");
            if(val_5 < (44171615 << ))
        {
                val_5 = val_5 + ", ";
        }
        
            val_5 = val_5 + 1;
        }
        while(val_5 < (44171616 << ));
        
        }
        
        }
        
        }
        
        ExtraWord.HasViewedWordList = true;
    }
    private void OnInfoClicked()
    {
        var val_4;
        System.Action val_6;
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGExtraWordsInfoPopup>(showNext:  false);
        val_4 = null;
        val_4 = null;
        val_6 = WGExtraWordsFoundPopup.<>c.<>9__5_0;
        if(val_6 == null)
        {
                System.Action val_3 = null;
            val_6 = val_3;
            val_3 = new System.Action(object:  WGExtraWordsFoundPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WGExtraWordsFoundPopup.<>c::<OnInfoClicked>b__5_0());
            WGExtraWordsFoundPopup.<>c.<>9__5_0 = val_6;
        }
        
        mem2[0] = val_6;
        this.OnCloseClicked();
    }
    private void OnCloseClicked()
    {
        this.gameObject.SetActive(value:  false);
    }
    public WGExtraWordsFoundPopup()
    {
    
    }

}
