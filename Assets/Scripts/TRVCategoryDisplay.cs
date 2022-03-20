using UnityEngine;
public class TRVCategoryDisplay : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text categoryNameText;
    private UnityEngine.UI.Image categoryImage;
    private UnityEngine.UI.Text crownText;
    private UnityEngine.UI.Text completedText;
    
    // Methods
    public void DisplayCategory(string name, UnityEngine.Sprite catSprite, bool grayOut = False)
    {
        bool val_1 = UnityEngine.Object.op_Inequality(x:  this.categoryNameText, y:  0);
        this.categoryImage.sprite = catSprite;
        if(grayOut == false)
        {
                return;
        }
        
        UnityEngine.Color val_2 = UnityEngine.Color.gray;
        this.categoryImage.color = new UnityEngine.Color() {r = val_2.r, g = val_2.g, b = val_2.b, a = val_2.a};
    }
    public void DisplayCategoryDetails(int crowns, int completedPercentage)
    {
        string val_1 = crowns.ToString();
        string val_3 = System.String.Format(format:  "{0}%", arg0:  completedPercentage.ToString());
    }
    public TRVCategoryDisplay()
    {
    
    }

}
