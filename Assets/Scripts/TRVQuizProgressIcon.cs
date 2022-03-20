using UnityEngine;
public class TRVQuizProgressIcon : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Image checkMarkOverlay;
    private UnityEngine.UI.Image highlight;
    private UnityEngine.UI.Image incorrectOverlay;
    
    // Methods
    public void SetupIcon(TRVQuestionHistory history, bool firstQuestion, bool highlightMe = False)
    {
        var val_11;
        this.gameObject.GetComponent<UnityEngine.UI.Mask>().enabled = firstQuestion;
        this.highlight.gameObject.SetActive(value:  highlightMe);
        UnityEngine.GameObject val_6 = this.checkMarkOverlay.gameObject;
        if(history != null)
        {
                val_6.SetActive(value:  (history.pointsGained > 0) ? 1 : 0);
            UnityEngine.GameObject val_8 = this.incorrectOverlay.gameObject;
            var val_9 = (history.pointsGained < 1) ? 1 : 0;
        }
        else
        {
                val_6.SetActive(value:  false);
            val_11 = 0;
        }
        
        this.incorrectOverlay.gameObject.SetActive(value:  false);
    }
    public TRVQuizProgressIcon()
    {
    
    }

}
