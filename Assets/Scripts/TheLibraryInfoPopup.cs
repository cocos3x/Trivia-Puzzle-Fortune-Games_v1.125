using UnityEngine;
public class TheLibraryInfoPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button button_close;
    private UnityEngine.UI.Text text_refresh;
    private UnityEngine.UI.Text text_pack_rarities;
    
    // Methods
    private void Awake()
    {
        this.button_close.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TheLibraryInfoPopup::<Awake>b__3_0()));
    }
    private void OnEnable()
    {
        var val_15 = null;
        string val_3 = System.String.Format(format:  Localization.Localize(key:  "library_info_popup_3", defaultValue:  "Books available for purchase refresh every {0} hours.", useSingularKey:  false), arg0:  ToString());
        object[] val_5 = new object[4];
        BookEconInfo val_6 = TheLibraryLogic.BookEcon.Item[0];
        val_5[0] = System.String.Format(format:  "{0}%", arg0:  val_6.FreeBookChance);
        BookEconInfo val_8 = TheLibraryLogic.BookEcon.Item[1];
        val_5[1] = System.String.Format(format:  "{0}%", arg0:  val_8.FreeBookChance);
        BookEconInfo val_10 = TheLibraryLogic.BookEcon.Item[2];
        val_5[2] = System.String.Format(format:  "{0}%", arg0:  val_10.FreeBookChance);
        BookEconInfo val_12 = TheLibraryLogic.BookEcon.Item[3];
        val_5[3] = System.String.Format(format:  "{0}%", arg0:  val_12.FreeBookChance);
        string val_14 = System.String.Format(format:  Localization.Localize(key:  "library_info_popup_6", defaultValue:  "Book rarity in book packs: Common {0}, Uncommon {1}, Rare {2}, Super Rare {3}", useSingularKey:  false), args:  val_5);
    }
    public TheLibraryInfoPopup()
    {
    
    }
    private void <Awake>b__3_0()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }

}
