using UnityEngine;
public class TRVExpertProficiencyDisplay : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Image profImage;
    private System.Collections.Generic.List<UnityEngine.UI.Image> starBGs;
    private System.Collections.Generic.List<UnityEngine.UI.Image> stars;
    
    // Methods
    public void DisplayProf(TRVCategoryProficiencies data)
    {
        var val_7;
        this.profImage.sprite = MonoSingleton<TRVUtils>.Instance.GetCategoryIcon(category:  data.subCat);
        var val_7 = 0;
        label_11:
        if(val_7 >= 1152921517152757248)
        {
            goto label_7;
        }
        
        if(1152921517152757248 <= val_7)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        gameObject.SetActive(value:  (val_7 < data.maxPotential) ? 1 : 0);
        val_7 = val_7 + 1;
        if(this.starBGs != null)
        {
            goto label_11;
        }
        
        label_7:
        val_7 = 0;
        do
        {
            if(val_7 >= 1152921517152757248)
        {
                return;
        }
        
            if(1152921517152757248 <= val_7)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            gameObject.SetActive(value:  (val_7 < data.currentPotential) ? 1 : 0);
            val_7 = val_7 + 1;
        }
        while(this.stars != null);
        
        throw new NullReferenceException();
    }
    public void UpdateProf(TRVCategoryProficiencies data)
    {
        System.Collections.Generic.List<UnityEngine.UI.Image> val_7;
        bool val_8 = true;
        val_7 = this.stars;
        var val_9 = 4;
        do
        {
            var val_1 = val_9 - 4;
            if(val_1 >= val_8)
        {
                return;
        }
        
            if(val_1 < data.currentPotential)
        {
                val_8 = val_8 & 4294967295;
            if(val_1 >= val_8)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(((true & 4294967295) + 32.gameObject.activeSelf) != true)
        {
                if(val_1 >= val_8)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            (true & 4294967295) + 32.gameObject.SetActive(value:  true);
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            UnityEngine.ParticleSystem val_7 = MonoSingleton<WGSFXController>.Instance.PlaySFX(reqType:  3, parent:  MonoSingleton<T>.__il2cppRuntimeField_cctor_finished + 32.GetComponent<UnityEngine.RectTransform>(), playImmediate:  true);
        }
        
        }
        
            val_7 = this.stars;
            val_9 = val_9 + 1;
        }
        while(val_7 != null);
        
        throw new NullReferenceException();
    }
    public TRVExpertProficiencyDisplay()
    {
    
    }

}
