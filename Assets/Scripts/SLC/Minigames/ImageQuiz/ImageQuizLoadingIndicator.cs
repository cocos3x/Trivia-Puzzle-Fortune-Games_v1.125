using UnityEngine;

namespace SLC.Minigames.ImageQuiz
{
    public class ImageQuizLoadingIndicator : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Image[] dots;
        private DG.Tweening.Sequence loadSeq;
        
        // Methods
        public void Show(bool isVisible)
        {
            DG.Tweening.Sequence val_18 = this.loadSeq;
            if(val_18 == null)
            {
                goto label_1;
            }
            
            if(isVisible == false)
            {
                goto label_2;
            }
            
            label_18:
            DG.Tweening.TweenExtensions.Restart(t:  val_18 = this.loadSeq, includeDelay:  true, changeDelayTo:  -1f);
            goto label_3;
            label_1:
            DG.Tweening.Sequence val_1 = DG.Tweening.DOTween.Sequence();
            this.loadSeq = val_1;
            DG.Tweening.Sequence val_2 = DG.Tweening.TweenSettingsExtensions.SetAutoKill<DG.Tweening.Sequence>(t:  val_1, autoKillOnCompletion:  false);
            DG.Tweening.Sequence val_3 = DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Sequence>(t:  this.loadSeq, loops:  0, loopType:  0);
            var val_21 = 4;
            label_16:
            var val_4 = val_21 - 4;
            if(val_4 >= this.dots.Length)
            {
                goto label_7;
            }
            
            DG.Tweening.Sequence val_5 = DG.Tweening.DOTween.Sequence();
            DG.Tweening.Sequence val_9 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_5, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOLocalMoveY(target:  this.dots[0].transform, endValue:  25f, duration:  0.15f, snapping:  false), ease:  6));
            DG.Tweening.Sequence val_14 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_5, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOLocalMoveY(target:  this.dots[0].transform, endValue:  0f, duration:  0.1f, snapping:  false), ease:  5));
            DG.Tweening.Sequence val_15 = DG.Tweening.TweenSettingsExtensions.Insert(s:  this.loadSeq, atPosition:  (float)val_4 * 0.2f, t:  val_5);
            val_21 = val_21 + 1;
            if(this.dots != null)
            {
                goto label_16;
            }
            
            label_7:
            val_18 = this.loadSeq;
            if(isVisible == true)
            {
                goto label_18;
            }
            
            label_2:
            DG.Tweening.Sequence val_16 = DG.Tweening.TweenExtensions.Pause<DG.Tweening.Sequence>(t:  val_18);
            label_3:
            this.gameObject.SetActive(value:  isVisible);
        }
        public ImageQuizLoadingIndicator()
        {
        
        }
    
    }

}
