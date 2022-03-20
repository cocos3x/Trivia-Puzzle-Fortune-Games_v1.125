using UnityEngine;

namespace SLC.Minigames.WordBalloon
{
    public class WordBalloonFTUXPointer : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Graphic pointerGraphic;
        private DG.Tweening.Sequence pointerMoveSeq;
        
        // Methods
        public void MoveAlong(UnityEngine.GameObject startObj, UnityEngine.GameObject endObj, float moveAlongDuration, DG.Tweening.LoopType moveAlongLoopType = 0, DG.Tweening.Ease moveAlongEaseType = 1)
        {
            if(this.pointerMoveSeq != null)
            {
                    DG.Tweening.TweenExtensions.Kill(t:  this.pointerMoveSeq, complete:  false);
            }
            
            UnityEngine.Vector3 val_2 = startObj.transform.position;
            UnityEngine.Vector3 val_4 = startObj.transform.position;
            UnityEngine.Vector3 val_7 = this.gameObject.transform.position;
            UnityEngine.Vector3 val_8 = new UnityEngine.Vector3(x:  val_2.x, y:  val_4.y, z:  val_7.z);
            UnityEngine.Vector3 val_10 = endObj.transform.position;
            UnityEngine.Vector3 val_12 = endObj.transform.position;
            UnityEngine.Vector3 val_15 = this.gameObject.transform.position;
            UnityEngine.Vector3 val_16 = new UnityEngine.Vector3(x:  val_10.x, y:  val_12.y, z:  val_15.z);
            this.gameObject.transform.position = new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z};
            UnityEngine.Color val_19 = new UnityEngine.Color(r:  val_8.x, g:  val_8.y, b:  val_8.z, a:  0f);
            DG.Tweening.Sequence val_20 = DG.Tweening.DOTween.Sequence();
            this.pointerMoveSeq = val_20;
            DG.Tweening.Sequence val_21 = DG.Tweening.TweenSettingsExtensions.SetAutoKill<DG.Tweening.Sequence>(t:  val_20, autoKillOnCompletion:  false);
            DG.Tweening.Sequence val_22 = DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Sequence>(t:  this.pointerMoveSeq, loops:  0, loopType:  moveAlongLoopType);
            DG.Tweening.Sequence val_24 = DG.Tweening.TweenSettingsExtensions.Append(s:  this.pointerMoveSeq, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.pointerGraphic, endValue:  1f, duration:  0.15f));
            DG.Tweening.Sequence val_29 = DG.Tweening.TweenSettingsExtensions.Append(s:  this.pointerMoveSeq, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOMove(target:  this.gameObject.transform, endValue:  new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z}, duration:  moveAlongDuration, snapping:  false), ease:  moveAlongEaseType));
            DG.Tweening.Sequence val_31 = DG.Tweening.TweenSettingsExtensions.Append(s:  this.pointerMoveSeq, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.pointerGraphic, endValue:  0f, duration:  0.15f));
            DG.Tweening.Sequence val_32 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  this.pointerMoveSeq, interval:  0.5f);
        }
        public void Stop()
        {
            if(this.pointerMoveSeq == null)
            {
                    return;
            }
            
            DG.Tweening.TweenExtensions.Kill(t:  this.pointerMoveSeq, complete:  false);
        }
        public WordBalloonFTUXPointer()
        {
        
        }
    
    }

}
