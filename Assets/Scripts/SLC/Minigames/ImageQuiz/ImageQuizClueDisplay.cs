using UnityEngine;

namespace SLC.Minigames.ImageQuiz
{
    public class ImageQuizClueDisplay : MonoBehaviour
    {
        // Fields
        private UnityEngine.CanvasGroup clueCanvasGroup;
        private UnityEngine.UI.RawImage clueImage;
        private UnityEngine.UI.Image correctImage;
        private UnityEngine.UI.Image wrongImage;
        private DG.Tweening.Tweener tweener;
        private System.Nullable<UnityEngine.Vector2> preferredDimension;
        
        // Methods
        private void Start()
        {
            twelvegigs.Autopilot.AutopilotManager val_1 = MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance;
            System.Delegate val_3 = System.Delegate.Combine(a:  val_1.<aButtons>k__BackingField, b:  new System.Action(object:  this, method:  System.Void SLC.Minigames.ImageQuiz.ImageQuizClueDisplay::OnMinigameBegin()));
            if(val_3 != null)
            {
                    if(null != null)
            {
                goto label_5;
            }
            
            }
            
            val_1.<aButtons>k__BackingField = val_3;
            return;
            label_5:
        }
        private void OnDestroy()
        {
            if((MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance) == 0)
            {
                    return;
            }
            
            twelvegigs.Autopilot.AutopilotManager val_3 = MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance;
            1152921504893161472 = val_3.<aButtons>k__BackingField;
            System.Delegate val_5 = System.Delegate.Remove(source:  1152921504893161472, value:  new System.Action(object:  this, method:  System.Void SLC.Minigames.ImageQuiz.ImageQuizClueDisplay::OnMinigameBegin()));
            if(val_5 != null)
            {
                    if(null != null)
            {
                goto label_10;
            }
            
            }
            
            val_3.<aButtons>k__BackingField = val_5;
            return;
            label_10:
        }
        private void OnMinigameBegin()
        {
            this.UpdateClueDisplay();
        }
        public void UpdateClueDisplay()
        {
            SLC.Minigames.ImageQuiz.ImageQuizLevelInfo val_2 = MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance.GetCurrentQuizLevel();
            this.SetImage(imgTexture:  val_2.imageTexture);
        }
        private void SetImage(UnityEngine.Texture imgTexture)
        {
            this.clueImage.gameObject.SetActive(value:  true);
            UnityEngine.Vector2 val_4 = new UnityEngine.Vector2(x:  0.5f, y:  0.5f);
            this.clueImage.rectTransform.anchorMax = new UnityEngine.Vector2() {x = val_4.x, y = val_4.y};
            this.clueImage.rectTransform.anchorMin = new UnityEngine.Vector2() {x = val_4.x, y = val_4.y};
            this.clueImage.texture = imgTexture;
            this.ResizeImage();
        }
        private void ResizeImage()
        {
            var val_10;
            if(true == 0)
            {
                    UnityEngine.Vector2 val_2 = this.clueImage.rectTransform.sizeDelta;
                System.Nullable<UnityEngine.Vector2> val_3 = new System.Nullable<UnityEngine.Vector2>(value:  new UnityEngine.Vector2() {x = val_2.x, y = val_2.y});
                this.preferredDimension = val_3.HasValue;
                mem[1152921519928836600] = 0;
            }
            
            UnityEngine.Texture val_10 = this.clueImage.m_Texture;
            val_10 = val_10 / this.clueImage.m_Texture;
            float val_11 = (float)val_10;
            UnityEngine.Vector2 val_4 = this.preferredDimension.Value;
            if(val_10 >= 1)
            {
                    val_11 = val_4.x / val_11;
                val_10 = this.clueImage.rectTransform;
                UnityEngine.Vector2 val_6 = this.preferredDimension.Value;
            }
            else
            {
                    val_11 = val_4.y * val_11;
                val_10 = this.clueImage.rectTransform;
                UnityEngine.Vector2 val_8 = this.preferredDimension.Value;
                UnityEngine.Vector2 val_9;
            }
            
            val_9 = new UnityEngine.Vector2(x:  val_11, y:  val_8.y);
            val_10.sizeDelta = new UnityEngine.Vector2() {x = val_9.x, y = val_9.y};
        }
        public void FadeDisplay(float alphaTo, float duration)
        {
            if(this.tweener != null)
            {
                    DG.Tweening.TweenExtensions.Kill(t:  this.tweener, complete:  false);
            }
            
            this.tweener = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.clueCanvasGroup, endValue:  alphaTo, duration:  duration);
        }
        public void ToggleResultOverlay(bool isVisible, bool isCorrect)
        {
            UnityEngine.UI.Image val_10;
            var val_11;
            if(isVisible == false)
            {
                goto label_1;
            }
            
            if(isCorrect == false)
            {
                goto label_2;
            }
            
            val_10 = this.correctImage;
            val_10.gameObject.SetActive(value:  true);
            UnityEngine.GameObject val_2 = this.wrongImage.gameObject;
            val_11 = 0;
            goto label_7;
            label_1:
            this.correctImage.gameObject.SetActive(value:  false);
            this.wrongImage.gameObject.SetActive(value:  false);
            return;
            label_2:
            val_10 = this.wrongImage;
            this.correctImage.gameObject.SetActive(value:  false);
            val_11 = 1;
            label_7:
            this.wrongImage.gameObject.SetActive(value:  true);
            UnityEngine.Color val_7 = new UnityEngine.Color(r:  1f, g:  1f, b:  1f, a:  0f);
            val_10.color = new UnityEngine.Color() {r = val_7.r, g = val_7.g, b = val_7.b, a = val_7.a};
            DG.Tweening.Tweener val_9 = DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  val_10, endValue:  1f, duration:  0.1f), ease:  1);
        }
        public ImageQuizClueDisplay()
        {
        
        }
    
    }

}
