using UnityEngine;
public class TRVTriviaPursuitCategoryDisplay : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text category;
    private UnityEngine.UI.Text progress;
    private UnityEngine.UI.Image categoryIcon;
    private UnityEngine.UI.Image progressBar;
    private System.Action onStartAction;
    
    // Methods
    private void OnEnable()
    {
        if(this.onStartAction != null)
        {
                this.onStartAction.Invoke();
        }
        
        this.onStartAction = 0;
    }
    public void Setup(TRVTriviaPursuitCategoryDisplayInfo info)
    {
        this.categoryIcon.sprite = info.categoryIcon;
        this.progressBar.fillAmount = info.progress;
    }
    public void AnimateCategory(System.Collections.Generic.List<string> incCats, TRVTriviaPursuitCategoryDisplayInfo finalInfo)
    {
        .<>4__this = this;
        .incCats = incCats;
        .finalInfo = finalInfo;
        if(this.gameObject.activeInHierarchy != false)
        {
                UnityEngine.Coroutine val_5 = this.StartCoroutine(routine:  this.AnimatingCategory(incCats:  (TRVTriviaPursuitCategoryDisplay.<>c__DisplayClass7_0)[1152921517398696528].incCats, finalInfo:  (TRVTriviaPursuitCategoryDisplay.<>c__DisplayClass7_0)[1152921517398696528].finalInfo));
            return;
        }
        
        this.onStartAction = new System.Action(object:  new TRVTriviaPursuitCategoryDisplay.<>c__DisplayClass7_0(), method:  System.Void TRVTriviaPursuitCategoryDisplay.<>c__DisplayClass7_0::<AnimateCategory>b__0());
    }
    private System.Collections.IEnumerator AnimatingCategory(System.Collections.Generic.List<string> incCats, TRVTriviaPursuitCategoryDisplayInfo finalInfo)
    {
        .<>1__state = 0;
        .incCats = incCats;
        .<>4__this = this;
        .finalInfo = finalInfo;
        return (System.Collections.IEnumerator)new TRVTriviaPursuitCategoryDisplay.<AnimatingCategory>d__8();
    }
    public TRVTriviaPursuitCategoryDisplay()
    {
    
    }

}
