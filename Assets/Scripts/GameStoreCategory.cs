using UnityEngine;
public class GameStoreCategory : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject obj_category_title;
    private UnityEngine.UI.Text text_category_title;
    private UnityEngine.UI.HorizontalOrVerticalLayoutGroup layout_pack_contents;
    
    // Properties
    public UnityEngine.Transform XfmPackageContents { get; }
    
    // Methods
    public UnityEngine.Transform get_XfmPackageContents()
    {
        if(this.layout_pack_contents != null)
        {
                return this.layout_pack_contents.transform;
        }
        
        throw new NullReferenceException();
    }
    public void Setup(string categoryTitle, bool showTitle = True)
    {
        GameBehavior val_1 = App.getBehavior;
        string val_2 = System.String.Format(format:  val_1.<metaGameBehavior>k__BackingField, arg0:  categoryTitle);
        this.obj_category_title.SetActive(value:  showTitle);
    }
    public void SetSpacing(float verticalSpacing)
    {
        if(this.layout_pack_contents != null)
        {
                this.layout_pack_contents.spacing = verticalSpacing;
            return;
        }
        
        throw new NullReferenceException();
    }
    public int GetFirstAvailableSiblingIndex()
    {
        return 1;
    }
    public GameStoreCategory()
    {
    
    }

}
