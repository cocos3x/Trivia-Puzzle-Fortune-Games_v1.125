using UnityEngine;

namespace WordForest
{
    public class RaidAttackScreenTransition : MonoSingleton<WordForest.RaidAttackScreenTransition>
    {
        // Fields
        private UnityEngine.GameObject rootContainer;
        private UnityEngine.CanvasGroup leftCurtain;
        private UnityEngine.CanvasGroup rightCurtain;
        private UnityEngine.UI.RawImage sceneIcon;
        private UnityEngine.UI.Text sceneText;
        private UnityEngine.Texture textureAttack;
        private UnityEngine.Texture textureRaid;
        
        // Methods
        public void ExtendCurtains(WordForest.RaidAttackActionType sceneType, System.Action onComplete)
        {
            var val_31;
            var val_33;
            float val_34;
            val_31 = sceneType;
            .onComplete = onComplete;
            if(val_31 == 1)
            {
                goto label_2;
            }
            
            if(val_31 != 2)
            {
                goto label_3;
            }
            
            this.sceneIcon.texture = this.textureAttack;
            val_33 = "ATTACK";
            goto label_6;
            label_2:
            this.sceneIcon.texture = this.textureRaid;
            val_33 = "RAID";
            label_6:
            label_3:
            UnityEngine.Transform val_2 = this.leftCurtain.transform;
            if(val_2 != null)
            {
                    if(null != null)
            {
                goto label_11;
            }
            
            }
            
            UnityEngine.Transform val_3 = this.rightCurtain.transform;
            if(val_3 != null)
            {
                    if(null != null)
            {
                goto label_14;
            }
            
            }
            
            UnityEngine.Vector2 val_4 = new UnityEngine.Vector2(x:  -1500f, y:  0f);
            val_2.anchoredPosition = new UnityEngine.Vector2() {x = val_4.x, y = val_4.y};
            UnityEngine.Vector2 val_5 = new UnityEngine.Vector2(x:  1500f, y:  0f);
            val_3.anchoredPosition = new UnityEngine.Vector2() {x = val_5.x, y = val_5.y};
            this.rightCurtain.alpha = 0f;
            this.leftCurtain.alpha = 0f;
            UnityEngine.Vector3 val_7 = UnityEngine.Vector3.zero;
            this.sceneIcon.transform.localScale = new UnityEngine.Vector3() {x = val_7.x, y = val_7.y, z = val_7.z};
            UnityEngine.Vector3 val_9 = UnityEngine.Vector3.zero;
            this.sceneText.transform.localScale = new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z};
            this.rootContainer.SetActive(value:  true);
            DG.Tweening.Sequence val_10 = DG.Tweening.DOTween.Sequence();
            val_34 = 1f;
            DG.Tweening.Sequence val_12 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_10, t:  DG.Tweening.ShortcutExtensions46.DOAnchorPosX(target:  val_2, endValue:  0f, duration:  val_34, snapping:  false));
            DG.Tweening.Sequence val_14 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_10, t:  DG.Tweening.ShortcutExtensions46.DOAnchorPosX(target:  val_3, endValue:  0f, duration:  val_34, snapping:  false));
            DG.Tweening.Sequence val_16 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_10, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.leftCurtain, endValue:  val_34, duration:  0.5f));
            DG.Tweening.Sequence val_18 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_10, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.rightCurtain, endValue:  val_34, duration:  0.5f));
            if(val_31 != 0)
            {
                    val_31 = 1152921510472987776;
                val_34 = 0.1f;
                DG.Tweening.Sequence val_23 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_10, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.sceneIcon.transform, endValue:  1f, duration:  0.25f), delay:  val_34), ease:  27));
                DG.Tweening.Sequence val_28 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_10, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.sceneText.transform, endValue:  1f, duration:  0.25f), delay:  val_34), ease:  27));
            }
            
            DG.Tweening.Sequence val_30 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_10, action:  new DG.Tweening.TweenCallback(object:  new RaidAttackScreenTransition.<>c__DisplayClass7_0(), method:  System.Void RaidAttackScreenTransition.<>c__DisplayClass7_0::<ExtendCurtains>b__0()));
            return;
            label_11:
            label_14:
        }
        public void WithdrawCurtains(float delay = 0, System.Action onComplete)
        {
            .<>4__this = this;
            .onComplete = onComplete;
            UnityEngine.Transform val_2 = this.leftCurtain.transform;
            if(val_2 != null)
            {
                    if(null != null)
            {
                goto label_4;
            }
            
            }
            
            UnityEngine.Transform val_3 = this.rightCurtain.transform;
            if(val_3 != null)
            {
                    if(null != null)
            {
                goto label_7;
            }
            
            }
            
            DG.Tweening.Sequence val_4 = DG.Tweening.DOTween.Sequence();
            DG.Tweening.Sequence val_5 = DG.Tweening.TweenSettingsExtensions.PrependInterval(s:  val_4, interval:  delay);
            DG.Tweening.Sequence val_7 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_4, t:  DG.Tweening.ShortcutExtensions46.DOAnchorPosX(target:  val_2, endValue:  -1500f, duration:  1f, snapping:  false));
            DG.Tweening.Sequence val_9 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_4, t:  DG.Tweening.ShortcutExtensions46.DOAnchorPosX(target:  val_3, endValue:  1500f, duration:  1f, snapping:  false));
            DG.Tweening.Sequence val_11 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_4, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.leftCurtain, endValue:  0f, duration:  1f));
            DG.Tweening.Sequence val_13 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_4, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.rightCurtain, endValue:  0f, duration:  1f));
            UnityEngine.Vector3 val_15 = this.sceneIcon.transform.localScale;
            UnityEngine.Vector3 val_16 = UnityEngine.Vector3.zero;
            if((val_15.x.Equals(other:  new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z})) != true)
            {
                    DG.Tweening.Sequence val_21 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_4, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.sceneIcon.transform, endValue:  0f, duration:  0.25f), ease:  26));
                DG.Tweening.Sequence val_25 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_4, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOScale(target:  this.sceneText.transform, endValue:  0f, duration:  0.25f), ease:  26));
            }
            
            DG.Tweening.Sequence val_27 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_4, action:  new DG.Tweening.TweenCallback(object:  new RaidAttackScreenTransition.<>c__DisplayClass8_0(), method:  System.Void RaidAttackScreenTransition.<>c__DisplayClass8_0::<WithdrawCurtains>b__0()));
            return;
            label_4:
            label_7:
        }
        public RaidAttackScreenTransition()
        {
        
        }
    
    }

}
