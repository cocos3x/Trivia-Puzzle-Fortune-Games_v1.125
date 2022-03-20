using UnityEngine;
public class TRVCategoryRankDisplay : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Image categoryIcon;
    private UnityEngine.UI.Image progressBar;
    
    // Methods
    public void DisplayCategoryRank(UnityEngine.Sprite categorySp, float startProgress, float endProgress)
    {
        UnityEngine.CanvasGroup val_1 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<UnityEngine.CanvasGroup>(child:  this);
        val_1.alpha = 0f;
        this.categoryIcon.sprite = categorySp;
        this.Show();
        if(startProgress < 0)
        {
                UnityEngine.Coroutine val_3 = this.StartCoroutine(routine:  this.PlayProgressAnimation(from:  startProgress, to:  endProgress, duration:  1f));
        }
        
        DG.Tweening.Tweener val_4 = DG.Tweening.ShortcutExtensions46.DOFade(target:  val_1, endValue:  1f, duration:  0.2f);
    }
    public void Hide()
    {
        this.gameObject.SetActive(value:  false);
    }
    private System.Collections.IEnumerator PlayProgressAnimation(float from, float to, float duration)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .from = from;
        .to = to;
        .duration = duration;
        return (System.Collections.IEnumerator)new TRVCategoryRankDisplay.<PlayProgressAnimation>d__4();
    }
    private void Show()
    {
        this.gameObject.SetActive(value:  true);
    }
    public TRVCategoryRankDisplay()
    {
    
    }

}
