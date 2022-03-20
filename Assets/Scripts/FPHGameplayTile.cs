using UnityEngine;
public class FPHGameplayTile : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text revealedLetter;
    private UnityEngine.UI.Image revealedTileBackground;
    
    // Methods
    public void InitTile(string letter)
    {
        this.revealedTileBackground.gameObject.SetActive(value:  false);
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    public void RevealLetter()
    {
        UnityEngine.CanvasGroup val_1 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(child:  this.revealedTileBackground);
        val_1.alpha = 0f;
        this.revealedTileBackground.gameObject.SetActive(value:  true);
        UnityEngine.Vector3 val_4 = UnityEngine.Vector3.zero;
        val_1.GetComponent<UnityEngine.RectTransform>().localScale = new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z};
        DG.Tweening.Tweener val_5 = DG.Tweening.ShortcutExtensions46.DOFade(target:  val_1, endValue:  1f, duration:  0.2f);
        UnityEngine.Vector3 val_7 = UnityEngine.Vector3.one;
        DG.Tweening.Tweener val_8 = DG.Tweening.ShortcutExtensions.DOPunchScale(target:  val_1.GetComponent<UnityEngine.RectTransform>(), punch:  new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z}, duration:  0.4f, vibrato:  10, elasticity:  1f);
    }
    public FPHGameplayTile()
    {
    
    }

}
