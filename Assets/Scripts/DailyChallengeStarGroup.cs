using UnityEngine;
public class DailyChallengeStarGroup : MonoBehaviour
{
    // Fields
    private UnityEngine.Sprite star_fill;
    private UnityEngine.Sprite star_empty;
    private UnityEngine.UI.Image[] starImages;
    
    // Methods
    private void ResetStars()
    {
        T[] val_2 = this.transform.GetComponentsInChildren<UnityEngine.UI.Image>();
        this.starImages = val_2;
        if(val_2.Length < 1)
        {
                return;
        }
        
        var val_4 = 0;
        do
        {
            val_2[val_4].sprite = this.star_empty;
            val_4 = val_4 + 1;
        }
        while(val_4 < val_2.Length);
    
    }
    public void Setup(int stars)
    {
        this.ResetStars();
        if(stars < 1)
        {
                return;
        }
        
        var val_3 = 0;
        do
        {
            if(val_3 > (this.starImages.Length - 1))
        {
                return;
        }
        
            this.starImages[val_3].sprite = this.star_fill;
            val_3 = val_3 + 1;
        }
        while(val_3 < stars);
    
    }
    public DailyChallengeStarGroup()
    {
    
    }

}
