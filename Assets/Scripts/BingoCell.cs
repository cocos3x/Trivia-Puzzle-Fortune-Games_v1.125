using UnityEngine;
public class BingoCell : MonoBehaviour
{
    // Fields
    public UnityEngine.UI.Text numberText;
    public UnityEngine.UI.Image highlightBG;
    public UnityEngine.UI.Image cellImage;
    private DG.Tweening.Tweener bingoAnimaTween;
    
    // Methods
    public void StartBingoAnima()
    {
        UnityEngine.Vector3 val_2 = UnityEngine.Vector3.one;
        UnityEngine.Vector3 val_3 = UnityEngine.Vector3.op_Multiply(a:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z}, d:  1.2f);
        this.bingoAnimaTween = DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.cellImage.transform, endValue:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z}, duration:  0.5f), loops:  0, loopType:  1);
    }
    public void StopBingoAnima()
    {
        if(this.bingoAnimaTween == null)
        {
                return;
        }
        
        DG.Tweening.TweenExtensions.Kill(t:  this.bingoAnimaTween, complete:  false);
        this.bingoAnimaTween = 0;
        UnityEngine.Vector3 val_2 = UnityEngine.Vector3.one;
        this.cellImage.transform.localScale = new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z};
    }
    public BingoCell()
    {
    
    }

}
