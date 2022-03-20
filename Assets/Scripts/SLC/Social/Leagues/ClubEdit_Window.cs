using UnityEngine;

namespace SLC.Social.Leagues
{
    public class ClubEdit_Window : MonoBehaviour
    {
        // Fields
        private SLC.Social.Leagues.LeaguesUICreateGuildView editGuildView;
        private UnityEngine.CanvasGroup flyoutCanvasGroup;
        private UnityEngine.UI.Text flyoutText;
        
        // Methods
        private void Start()
        {
            System.Delegate val_2 = System.Delegate.Combine(a:  this.editGuildView.showMessageFlyout, b:  new System.Action<System.String>(object:  this, method:  System.Void SLC.Social.Leagues.ClubEdit_Window::ShowTopFlyoutWithMessage(string message)));
            if(val_2 != null)
            {
                    if(null != null)
            {
                goto label_3;
            }
            
            }
            
            this.editGuildView.showMessageFlyout = val_2;
            return;
            label_3:
        }
        private void ShowTopFlyoutWithMessage(string message)
        {
            int val_1 = DG.Tweening.ShortcutExtensions.DOKill(target:  this.flyoutCanvasGroup, complete:  false);
            this.flyoutCanvasGroup.alpha = 0f;
            DG.Tweening.Tweener val_2 = DG.Tweening.ShortcutExtensions46.DOFade(target:  this.flyoutCanvasGroup, endValue:  1f, duration:  0.5f);
            System.Delegate val_4 = System.Delegate.Combine(a:  static_value_02806000, b:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void SLC.Social.Leagues.ClubEdit_Window::<ShowTopFlyoutWithMessage>b__4_0()));
            if(val_4 != null)
            {
                    if(null != null)
            {
                goto label_5;
            }
            
            }
            
            mem2[0] = val_4;
            return;
            label_5:
        }
        public ClubEdit_Window()
        {
        
        }
        private void <ShowTopFlyoutWithMessage>b__4_0()
        {
            DG.Tweening.Tweener val_2 = DG.Tweening.TweenSettingsExtensions.SetDelay<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.flyoutCanvasGroup, endValue:  0f, duration:  0.5f), delay:  3.5f);
        }
    
    }

}
