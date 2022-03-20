using UnityEngine;
public class SeasonalSkinTexture : MonoBehaviour
{
    // Fields
    private SeasonSkinnedFeature feature;
    private string textureId;
    private UnityEngine.GameObject seasonalSkinObject;
    private UnityEngine.UI.RawImage rawImage;
    private UnityEngine.GameObject[] objectsToHideWhenActive;
    
    // Methods
    private void OnEnable()
    {
        this.SetSeasonalSkin();
    }
    private void SetSeasonalSkin()
    {
        UnityEngine.GameObject[] val_3;
        UnityEngine.Texture val_1 = this.TryGetSeasonalTexture();
        if(val_1 == 0)
        {
                this.seasonalSkinObject.SetActive(value:  false);
            val_3 = this.objectsToHideWhenActive;
            if(this.objectsToHideWhenActive.Length < 1)
        {
                return;
        }
        
            var val_4 = 0;
            do
        {
            val_3[val_4].SetActive(value:  true);
            val_4 = val_4 + 1;
        }
        while(val_4 < this.objectsToHideWhenActive.Length);
        
            return;
        }
        
        this.rawImage.texture = val_1;
        this.seasonalSkinObject.SetActive(value:  true);
        val_3 = this.objectsToHideWhenActive;
        if(this.objectsToHideWhenActive.Length < 1)
        {
                return;
        }
        
        var val_6 = 0;
        do
        {
            val_3[val_6].SetActive(value:  false);
            val_6 = val_6 + 1;
        }
        while(val_6 < this.objectsToHideWhenActive.Length);
    
    }
    private UnityEngine.Texture TryGetSeasonalTexture()
    {
        SeasonalSkin val_2 = MonoSingleton<SeasonalSkinsManager>.Instance.IsSkinActive(feature:  this.feature);
        if(val_2 == null)
        {
                return (UnityEngine.Texture)val_2;
        }
        
        SeasonalSkinsManager val_3 = MonoSingleton<SeasonalSkinsManager>.Instance;
        string val_4 = val_2.GetAssetName(textureId:  this.textureId);
        return val_4.GetTexture(assetName:  val_4);
    }
    public SeasonalSkinTexture()
    {
        this.textureId = "";
    }

}
