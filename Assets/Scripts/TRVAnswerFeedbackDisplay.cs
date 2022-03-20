using UnityEngine;
public class TRVAnswerFeedbackDisplay : MonoBehaviour
{
    // Fields
    private UnityEngine.Sprite correctSprite;
    private UnityEngine.Sprite incorrectSprite;
    private UnityEngine.UI.Image resultImage;
    private UnityEngine.UI.Text resultText;
    
    // Methods
    public void DisplayResult(bool correct)
    {
        UnityEngine.CanvasGroup val_1 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(child:  this);
        val_1.alpha = 0f;
        var val_2 = (correct != true) ? 24 : 32;
        this.resultImage.sprite = null;
        string val_5 = Localization.Localize(key:  (correct != true) ? "correct_upper" : "incorrect_upper", defaultValue:  (correct != true) ? "CORRECT" : "INCORRECT", useSingularKey:  false);
        this.gameObject.SetActive(value:  true);
        DG.Tweening.Tweener val_7 = DG.Tweening.ShortcutExtensions46.DOFade(target:  val_1, endValue:  1f, duration:  0.2f);
    }
    public void Hide()
    {
        this.gameObject.SetActive(value:  false);
    }
    public TRVAnswerFeedbackDisplay()
    {
    
    }

}
