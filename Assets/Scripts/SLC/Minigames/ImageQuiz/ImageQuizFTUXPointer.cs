using UnityEngine;

namespace SLC.Minigames.ImageQuiz
{
    public class ImageQuizFTUXPointer : MonoBehaviour
    {
        // Fields
        private UnityEngine.RectTransform pointerTransform;
        private UnityEngine.Vector2 moveBy;
        private float moveDuration;
        private DG.Tweening.LoopType moveLoopType;
        private DG.Tweening.Ease moveEaseType;
        private DG.Tweening.Sequence pointerSeq;
        private System.Nullable<UnityEngine.Vector2> originalPointerAnchoredPosition;
        private UnityEngine.UI.Image pointerImage;
        
        // Methods
        public void PointAt(UnityEngine.GameObject targetObj, bool flipPointerX = False, bool flipPointerY = False)
        {
            if(this.pointerSeq != null)
            {
                    DG.Tweening.TweenExtensions.Kill(t:  this.pointerSeq, complete:  false);
            }
            
            if(true == 0)
            {
                    UnityEngine.Vector2 val_1 = this.pointerTransform.anchoredPosition;
                System.Nullable<UnityEngine.Vector2> val_2 = new System.Nullable<UnityEngine.Vector2>(value:  new UnityEngine.Vector2() {x = val_1.x, y = val_1.y});
                this.originalPointerAnchoredPosition = val_2.HasValue;
                mem[1152921519949105912] = 0;
            }
            
            if(this.pointerImage == 0)
            {
                    this.pointerImage = this.pointerTransform.GetComponentInChildren<UnityEngine.UI.Image>();
            }
            
            UnityEngine.Vector3 val_8 = targetObj.transform.position;
            UnityEngine.Vector3 val_10 = targetObj.transform.position;
            UnityEngine.Vector3 val_13 = this.gameObject.transform.position;
            UnityEngine.Vector3 val_14 = new UnityEngine.Vector3(x:  val_8.x, y:  val_10.y, z:  val_13.z);
            this.gameObject.transform.position = new UnityEngine.Vector3() {x = val_14.x, y = val_14.y, z = val_14.z};
            UnityEngine.Vector2 val_15 = this.originalPointerAnchoredPosition.Value;
            this.pointerTransform.anchoredPosition = new UnityEngine.Vector2() {x = val_15.x, y = val_15.y};
            UnityEngine.Quaternion val_18 = UnityEngine.Quaternion.Euler(x:  (flipPointerY != true) ? 180f : 0f, y:  (flipPointerX != true) ? 180f : 0f, z:  0f);
            this.pointerTransform.localRotation = new UnityEngine.Quaternion() {x = val_18.x, y = val_18.y, z = val_18.z, w = val_18.w};
            UnityEngine.Vector2 val_31 = this.moveBy;
            val_31 = (flipPointerX != true) ? (-val_31) : (val_31);
            val_18.y = (flipPointerY != true) ? (-val_18.y) : val_18.y;
            UnityEngine.Vector2 val_19 = new UnityEngine.Vector2(x:  val_31, y:  val_18.y);
            DG.Tweening.Sequence val_20 = DG.Tweening.DOTween.Sequence();
            this.pointerSeq = val_20;
            DG.Tweening.Sequence val_21 = DG.Tweening.TweenSettingsExtensions.SetAutoKill<DG.Tweening.Sequence>(t:  val_20, autoKillOnCompletion:  false);
            DG.Tweening.Sequence val_22 = DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Sequence>(t:  this.pointerSeq, loops:  0, loopType:  this.moveLoopType);
            UnityEngine.Vector2 val_23 = this.originalPointerAnchoredPosition.Value;
            UnityEngine.Vector2 val_24 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_23.x, y = val_23.y}, b:  new UnityEngine.Vector2() {x = val_19.x, y = val_19.y});
            DG.Tweening.Sequence val_27 = DG.Tweening.TweenSettingsExtensions.Append(s:  this.pointerSeq, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOAnchorPos(target:  this.pointerTransform, endValue:  new UnityEngine.Vector2() {x = val_24.x, y = val_24.y}, duration:  this.moveDuration, snapping:  false), ease:  this.moveEaseType));
            UnityEngine.Color val_28 = this.pointerImage.color;
            this.pointerImage.color = new UnityEngine.Color() {r = val_28.r, g = val_28.g, b = val_28.b, a = 0f};
            DG.Tweening.Tweener val_30 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.pointerImage, endValue:  1f, duration:  0.2f), ease:  1);
        }
        public void Stop()
        {
            if(this.pointerSeq == null)
            {
                    return;
            }
            
            DG.Tweening.TweenExtensions.Kill(t:  this.pointerSeq, complete:  false);
        }
        public ImageQuizFTUXPointer()
        {
            this.moveLoopType = 1.4853970537251E-313;
        }
    
    }

}
