using UnityEngine;
public class LibraryBookDisplay_AcquireBookPack : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text Title;
    private UnityEngine.UI.Text desc;
    private UnityEngine.UI.Text cost;
    private UnityEngine.UI.Button button_purchase;
    private System.Action<LibraryBookDisplay_AcquireBookPack> bookClickedAction;
    private int _packSize;
    
    // Properties
    public int PackSize { get; }
    
    // Methods
    public int get_PackSize()
    {
        return (int)this._packSize;
    }
    private void Awake()
    {
        this.button_purchase.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void LibraryBookDisplay_AcquireBookPack::OnPurchaseClicked()));
    }
    public void Setup(string bookpack, string packdescription, int packcost, int packSize, System.Action<LibraryBookDisplay_AcquireBookPack> onBookClicked)
    {
        string val_1 = packcost.ToString();
        this._packSize = packSize;
        this.bookClickedAction = onBookClicked;
    }
    private void OnPurchaseClicked()
    {
        if(this.bookClickedAction == null)
        {
                return;
        }
        
        this.bookClickedAction.Invoke(obj:  this);
    }
    public LibraryBookDisplay_AcquireBookPack()
    {
    
    }

}
