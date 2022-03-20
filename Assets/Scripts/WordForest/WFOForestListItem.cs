using UnityEngine;

namespace WordForest
{
    public class WFOForestListItem : MonoBehaviour
    {
        // Fields
        private UnityEngine.Transform contentTransform;
        private UnityEngine.UI.Button button;
        private UnityEngine.UI.Text forestTitleText;
        private UnityEngine.UI.RawImage forestTexture;
        private UnityEngine.UI.RawImage maskTexture;
        private UnityEngine.UI.Image currentForestGlow;
        private UnityEngine.UI.Image lockImage;
        private UnityEngine.Transform dotsTransform;
        private UnityEngine.ParticleSystem particleSystem;
        private UnityEngine.UI.Image[] dots;
        private System.Action OnItemClicked;
        
        // Methods
        private void Start()
        {
            this.button.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.WFOForestListItem::<Start>b__11_0()));
        }
        public void SetForestInfo(int forestIndex, WordForest.WFOForestData forestData, System.Action onItemClicked, UnityEngine.Texture forestTexture)
        {
            string val_2 = System.String.Format(format:  "{0}. {1}", arg0:  forestData.level.ToString(), arg1:  forestData.forestName);
            var val_3 = ((forestIndex & 1) != 0) ? 1 : 0;
            UnityEngine.Vector3 val_4 = new UnityEngine.Vector3(x:  32558648 + (forestIndex & 1)!=0 ? 1 : 0, y:  0f, z:  0f);
            this.contentTransform.localPosition = new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z};
            UnityEngine.Vector3 val_6 = new UnityEngine.Vector3(x:  ((forestIndex & 1) != 0) ? 1f : -1f, y:  1f, z:  1f);
            this.dotsTransform.localScale = new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z};
            this.forestTexture.texture = forestTexture;
            this.maskTexture.texture = forestTexture;
            if(forestIndex == 0)
            {
                    this.dotsTransform.gameObject.SetActive(value:  false);
            }
            
            System.Delegate val_8 = System.Delegate.Combine(a:  this.OnItemClicked, b:  onItemClicked);
            if(val_8 != null)
            {
                    if(null != null)
            {
                goto label_10;
            }
            
            }
            
            this.OnItemClicked = val_8;
            return;
            label_10:
        }
        public void SetLocked()
        {
            this.ToggleDots(active:  false);
            this.button.transition = 0;
            this.button.interactable = false;
            UnityEngine.Color val_1 = UnityEngine.Color.gray;
            this.forestTexture.color = new UnityEngine.Color() {r = val_1.r, g = val_1.g, b = val_1.b, a = val_1.a};
            this.lockImage.gameObject.SetActive(value:  true);
            this.currentForestGlow.enabled = false;
            this.particleSystem.Stop();
        }
        public void SetCompleted()
        {
            this.ToggleDots(active:  true);
            this.button.transition = 0;
            this.button.interactable = false;
            UnityEngine.Color val_1 = UnityEngine.Color.white;
            this.forestTexture.color = new UnityEngine.Color() {r = val_1.r, g = val_1.g, b = val_1.b, a = val_1.a};
            this.lockImage.gameObject.SetActive(value:  false);
            this.currentForestGlow.enabled = false;
            this.particleSystem.Stop();
        }
        public void SetCurrent()
        {
            this.ToggleDots(active:  true);
            this.button.transition = 1;
            UnityEngine.Color val_1 = UnityEngine.Color.white;
            this.forestTexture.color = new UnityEngine.Color() {r = val_1.r, g = val_1.g, b = val_1.b, a = val_1.a};
            this.lockImage.gameObject.SetActive(value:  false);
            this.currentForestGlow.enabled = true;
            this.button.interactable = true;
            this.particleSystem.Play();
        }
        public DG.Tweening.Sequence DoUnlockSequence()
        {
            DG.Tweening.Sequence val_1 = DG.Tweening.DOTween.Sequence();
            DG.Tweening.Sequence val_2 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_1, interval:  0.2f);
            var val_21 = 0;
            label_6:
            if(val_21 >= (this.dots.Length << ))
            {
                goto label_4;
            }
            
            UnityEngine.Color val_3 = UnityEngine.Color.white;
            DG.Tweening.Sequence val_5 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_1, t:  DG.Tweening.ShortcutExtensions46.DOColor(target:  this.dots[val_21], endValue:  new UnityEngine.Color() {r = val_3.r, g = val_3.g, b = val_3.b, a = val_3.a}, duration:  0.35f));
            DG.Tweening.Sequence val_6 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_1, interval:  0.2f);
            val_21 = val_21 + 1;
            if(this.dots != null)
            {
                goto label_6;
            }
            
            throw new NullReferenceException();
            label_4:
            DG.Tweening.Sequence val_8 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_1, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.lockImage, endValue:  0f, duration:  0.5f));
            DG.Tweening.Sequence val_10 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_1, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WordForest.WFOForestListItem::<DoUnlockSequence>b__16_0()));
            DG.Tweening.Sequence val_12 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_1, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WordForest.WFOForestListItem::<DoUnlockSequence>b__16_1()));
            UnityEngine.Color val_13 = UnityEngine.Color.white;
            DG.Tweening.Sequence val_15 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_1, t:  DG.Tweening.ShortcutExtensions46.DOColor(target:  this.forestTexture, endValue:  new UnityEngine.Color() {r = val_13.r, g = val_13.g, b = val_13.b, a = val_13.a}, duration:  1f));
            DG.Tweening.Sequence val_17 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_1, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.currentForestGlow, endValue:  1f, duration:  1f));
            DG.Tweening.Sequence val_19 = DG.Tweening.TweenSettingsExtensions.AppendCallback(s:  val_1, callback:  new DG.Tweening.TweenCallback(object:  this, method:  public System.Void WordForest.WFOForestListItem::SetCurrent()));
            return val_1;
        }
        private void ToggleDots(bool active)
        {
            if(active != false)
            {
                    UnityEngine.Color val_1 = UnityEngine.Color.white;
            }
            else
            {
                    UnityEngine.Color val_2 = UnityEngine.Color.black;
            }
            
            var val_4 = 0;
            do
            {
                if(val_4 >= this.dots.Length)
            {
                    return;
            }
            
                this.dots[val_4].color = new UnityEngine.Color() {r = val_2.r, g = val_2.g, b = val_2.b, a = val_2.a};
                val_4 = val_4 + 1;
            }
            while(this.dots != null);
            
            throw new NullReferenceException();
        }
        public WFOForestListItem()
        {
        
        }
        private void <Start>b__11_0()
        {
            if(this.OnItemClicked == null)
            {
                    return;
            }
            
            this.OnItemClicked.Invoke();
        }
        private void <DoUnlockSequence>b__16_0()
        {
            if(this.currentForestGlow != null)
            {
                    this.currentForestGlow.enabled = true;
                return;
            }
            
            throw new NullReferenceException();
        }
        private void <DoUnlockSequence>b__16_1()
        {
            PluginExtension.SetColorAlpha(graphic:  this.currentForestGlow, a:  0f);
        }
    
    }

}
