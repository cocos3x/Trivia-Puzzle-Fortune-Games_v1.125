using UnityEngine;

namespace WordForest
{
    public class WFODigAnimation : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Image holeImage;
        private UnityEngine.UI.Image shovelImage;
        
        // Methods
        public void StartDigAnimation()
        {
            var val_39;
            DG.Tweening.TweenCallback val_41;
            var val_42;
            DG.Tweening.TweenCallback val_44;
            var val_45;
            DG.Tweening.TweenCallback val_47;
            DG.Tweening.Sequence val_1 = DG.Tweening.DOTween.Sequence();
            val_39 = null;
            val_39 = null;
            val_41 = WFODigAnimation.<>c.<>9__2_0;
            if(val_41 == null)
            {
                    DG.Tweening.TweenCallback val_2 = null;
                val_41 = val_2;
                val_2 = new DG.Tweening.TweenCallback(object:  WFODigAnimation.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WFODigAnimation.<>c::<StartDigAnimation>b__2_0());
                WFODigAnimation.<>c.<>9__2_0 = val_41;
            }
            
            DG.Tweening.Sequence val_3 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_1, callback:  val_2);
            UnityEngine.Vector3 val_5 = UnityEngine.Vector3.zero;
            DG.Tweening.Sequence val_8 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_1, t:  DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOLocalMove(target:  this.shovelImage.transform, endValue:  new UnityEngine.Vector3() {x = val_5.x, y = val_5.y, z = val_5.z}, duration:  0.15f, snapping:  false), loops:  2, loopType:  1));
            val_42 = null;
            val_42 = null;
            val_44 = WFODigAnimation.<>c.<>9__2_1;
            if(val_44 == null)
            {
                    DG.Tweening.TweenCallback val_9 = null;
                val_44 = val_9;
                val_9 = new DG.Tweening.TweenCallback(object:  WFODigAnimation.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WFODigAnimation.<>c::<StartDigAnimation>b__2_1());
                WFODigAnimation.<>c.<>9__2_1 = val_44;
            }
            
            DG.Tweening.Sequence val_10 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_1, callback:  val_9);
            UnityEngine.Vector3 val_12 = UnityEngine.Vector3.zero;
            DG.Tweening.Sequence val_15 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_1, t:  DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOLocalMove(target:  this.shovelImage.transform, endValue:  new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z}, duration:  0.15f, snapping:  false), loops:  2, loopType:  1));
            val_45 = null;
            val_45 = null;
            val_47 = WFODigAnimation.<>c.<>9__2_2;
            if(val_47 == null)
            {
                    DG.Tweening.TweenCallback val_16 = null;
                val_47 = val_16;
                val_16 = new DG.Tweening.TweenCallback(object:  WFODigAnimation.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WFODigAnimation.<>c::<StartDigAnimation>b__2_2());
                WFODigAnimation.<>c.<>9__2_2 = val_47;
            }
            
            DG.Tweening.Sequence val_17 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_1, callback:  val_16);
            UnityEngine.Vector3 val_19 = UnityEngine.Vector3.zero;
            DG.Tweening.Sequence val_22 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_1, t:  DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOLocalMove(target:  this.shovelImage.transform, endValue:  new UnityEngine.Vector3() {x = val_19.x, y = val_19.y, z = val_19.z}, duration:  0.15f, snapping:  false), loops:  2, loopType:  1));
            DG.Tweening.Sequence val_23 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_1, interval:  0.2f);
            DG.Tweening.Sequence val_25 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_1, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.shovelImage, endValue:  0f, duration:  0.2f));
            DG.Tweening.Sequence val_26 = DG.Tweening.DOTween.Sequence();
            DG.Tweening.Sequence val_27 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_26, interval:  0.15f);
            DG.Tweening.Sequence val_30 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_26, t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.holeImage.transform, endValue:  0.3f, duration:  0.05f));
            DG.Tweening.Sequence val_31 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_26, interval:  0.2f);
            DG.Tweening.Sequence val_34 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_26, t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.holeImage.transform, endValue:  0.6f, duration:  0.05f));
            DG.Tweening.Sequence val_35 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_26, interval:  0.2f);
            DG.Tweening.Sequence val_38 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_26, t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.holeImage.transform, endValue:  1f, duration:  0.05f));
        }
        public void FadeHole()
        {
            DG.Tweening.Tweener val_1 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.holeImage, endValue:  0f, duration:  0.65f);
        }
        public WFODigAnimation()
        {
        
        }
    
    }

}
