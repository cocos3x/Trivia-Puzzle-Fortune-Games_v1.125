using UnityEngine;
public class WFOMysteryChestMovingObject : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject sunBurst;
    private UnityEngine.GameObject chestIcon;
    
    // Methods
    private void Start()
    {
        UnityEngine.Vector3 val_2 = UnityEngine.Vector3.zero;
        this.sunBurst.transform.localScale = new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z};
        UnityEngine.Vector2 val_5 = new UnityEngine.Vector2(x:  UnityEngine.Random.Range(min:  -1f, max:  1f), y:  UnityEngine.Random.Range(min:  -1f, max:  1f));
        val_5.x.Normalize();
        UnityEngine.Vector2 val_6 = UnityEngine.Vector2.op_Multiply(a:  new UnityEngine.Vector2() {x = val_5.x, y = val_5.y}, d:  300f);
        UnityEngine.Vector3 val_9 = this.chestIcon.transform.localPosition;
        UnityEngine.Vector3 val_10 = new UnityEngine.Vector3(x:  val_6.x, y:  val_6.y, z:  val_9.z);
        this.chestIcon.transform.localPosition = new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z};
        this.chestIcon.GetComponent<UnityEngine.CanvasGroup>().alpha = 0f;
        DG.Tweening.Sequence val_12 = DG.Tweening.DOTween.Sequence();
        DG.Tweening.Sequence val_14 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_12, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WFOMysteryChestMovingObject::<Start>b__2_0()));
        DG.Tweening.Sequence val_15 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_12, interval:  0.5f);
        DG.Tweening.Sequence val_17 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_12, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WFOMysteryChestMovingObject::<Start>b__2_1()));
        DG.Tweening.Sequence val_18 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_12, interval:  0.5f);
        DG.Tweening.Sequence val_21 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_12, t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.chestIcon.transform, endValue:  1f, duration:  0.2f));
    }
    public WFOMysteryChestMovingObject()
    {
    
    }
    private void <Start>b__2_0()
    {
        UnityEngine.Vector3 val_2 = UnityEngine.Vector3.zero;
        DG.Tweening.Tweener val_3 = DG.Tweening.ShortcutExtensions.DOLocalMove(target:  this.chestIcon.transform, endValue:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z}, duration:  0.5f, snapping:  false);
        DG.Tweening.Tweener val_5 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.chestIcon.GetComponent<UnityEngine.CanvasGroup>(), endValue:  1f, duration:  0.5f);
    }
    private void <Start>b__2_1()
    {
        DG.Tweening.Tweener val_2 = DG.Tweening.ShortcutExtensions.DOScale(target:  this.chestIcon.transform, endValue:  1.3f, duration:  0.4f);
        DG.Tweening.Tweener val_4 = DG.Tweening.ShortcutExtensions.DOScale(target:  this.sunBurst.transform, endValue:  2.3f, duration:  0.5f);
        DG.Tweening.Tweener val_7 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.sunBurst.GetComponent<UnityEngine.CanvasGroup>(), endValue:  0f, duration:  0.5f), delay:  1f);
    }

}
