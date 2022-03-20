using UnityEngine;

namespace SLC.Social.Leagues
{
    public class LeaguesTutorial_Window : MonoBehaviour
    {
        // Fields
        private UnityEngine.GameObject[] pages;
        private UnityEngine.UI.Button blockerButton;
        private UnityEngine.UI.Button bgButton;
        private int currPageIndex;
        
        // Methods
        private void Start()
        {
            if((MonoSingleton<SLC.Social.Leagues.LeaguesUIManager>.Instance) == 0)
            {
                    SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
                return;
            }
            
            this.AdvancePage();
        }
        public void AdvancePage()
        {
            object val_21;
            int val_22;
            ButtonClickedEvent val_23;
            var val_24;
            LeaguesTutorial_Window.<>c__DisplayClass5_0 val_1 = null;
            val_21 = val_1;
            val_1 = new LeaguesTutorial_Window.<>c__DisplayClass5_0();
            if(val_21 == null)
            {
                    throw new NullReferenceException();
            }
            
            .<>4__this = this;
            if(this.currPageIndex != 1)
            {
                    if(this.pages == null)
            {
                    throw new NullReferenceException();
            }
            
                UnityEngine.GameObject val_21 = this.pages[this.currPageIndex];
                if(val_21 == null)
            {
                    throw new NullReferenceException();
            }
            
                val_21.SetActive(value:  false);
                if((MonoSingleton<SLC.Social.Leagues.LeaguesUIManager>.Instance) == null)
            {
                    throw new NullReferenceException();
            }
            
                if(val_2.tutorialHighlights == null)
            {
                    throw new NullReferenceException();
            }
            
                val_2.tutorialHighlights.UnhighlightCurrent();
                val_22 = this.currPageIndex;
            }
            else
            {
                    val_22 = 0;
            }
            
            val_22 = val_22 + 1;
            this.currPageIndex = val_22;
            if(this.pages == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_22 >= this.pages.Length)
            {
                goto label_12;
            }
            
            UnityEngine.GameObject val_22 = this.pages[val_22];
            if(val_22 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_22.SetActive(value:  true);
            if((MonoSingleton<SLC.Social.Leagues.LeaguesUIManager>.Instance) == null)
            {
                    throw new NullReferenceException();
            }
            
            if(this.pages == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.GameObject val_23 = this.pages[this.currPageIndex];
            if(val_23 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_3.tutorialHighlights == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Transform val_5 = val_3.tutorialHighlights.HighlightByIndex(index:  this.currPageIndex, stage:  val_23.transform, disableButton:  false);
            if((val_5 == null) || (null != null))
            {
                goto label_23;
            }
            
            .highlightRect = val_5;
            val_5.SetAsFirstSibling();
            if(this.blockerButton == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Transform val_6 = this.blockerButton.transform;
            if(this.pages == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.GameObject val_24 = this.pages[this.currPageIndex];
            if(val_24 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_6 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_6.SetParent(p:  val_24.transform);
            if(this.blockerButton == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.RectTransform val_8 = this.blockerButton.GetComponent<UnityEngine.RectTransform>();
            if(((LeaguesTutorial_Window.<>c__DisplayClass5_0)[1152921519733042736].highlightRect) == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Vector2 val_9 = (LeaguesTutorial_Window.<>c__DisplayClass5_0)[1152921519733042736].highlightRect.anchorMin;
            if(val_8 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_8.anchorMin = new UnityEngine.Vector2() {x = val_9.x, y = val_9.y};
            if(this.blockerButton == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.RectTransform val_10 = this.blockerButton.GetComponent<UnityEngine.RectTransform>();
            if(((LeaguesTutorial_Window.<>c__DisplayClass5_0)[1152921519733042736].highlightRect) == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Vector2 val_11 = (LeaguesTutorial_Window.<>c__DisplayClass5_0)[1152921519733042736].highlightRect.anchorMax;
            if(val_10 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_10.anchorMax = new UnityEngine.Vector2() {x = val_11.x, y = val_11.y};
            if(this.blockerButton == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.RectTransform val_12 = this.blockerButton.GetComponent<UnityEngine.RectTransform>();
            if(((LeaguesTutorial_Window.<>c__DisplayClass5_0)[1152921519733042736].highlightRect) == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Vector2 val_13 = (LeaguesTutorial_Window.<>c__DisplayClass5_0)[1152921519733042736].highlightRect.anchoredPosition;
            if(val_12 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_12.anchoredPosition = new UnityEngine.Vector2() {x = val_13.x, y = val_13.y};
            if(this.blockerButton == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.RectTransform val_14 = this.blockerButton.GetComponent<UnityEngine.RectTransform>();
            if(((LeaguesTutorial_Window.<>c__DisplayClass5_0)[1152921519733042736].highlightRect) == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Vector2 val_15 = (LeaguesTutorial_Window.<>c__DisplayClass5_0)[1152921519733042736].highlightRect.pivot;
            if(val_14 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_14.pivot = new UnityEngine.Vector2() {x = val_15.x, y = val_15.y};
            if(this.blockerButton == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.RectTransform val_16 = this.blockerButton.GetComponent<UnityEngine.RectTransform>();
            if(((LeaguesTutorial_Window.<>c__DisplayClass5_0)[1152921519733042736].highlightRect) == null)
            {
                    throw new NullReferenceException();
            }
            
            UnityEngine.Vector2 val_17 = (LeaguesTutorial_Window.<>c__DisplayClass5_0)[1152921519733042736].highlightRect.sizeDelta;
            if(val_16 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_16.sizeDelta = new UnityEngine.Vector2() {x = val_17.x, y = val_17.y};
            if(this.blockerButton == null)
            {
                    throw new NullReferenceException();
            }
            
            if(this.blockerButton.m_OnClick == null)
            {
                    throw new NullReferenceException();
            }
            
            this.blockerButton.m_OnClick.RemoveAllListeners();
            int val_25 = this.currPageIndex;
            if(val_25 > 5)
            {
                goto label_47;
            }
            
            val_25 = 1 << val_25;
            if((val_25 & 52) != 0)
            {
                goto label_47;
            }
            
            if(this.blockerButton == null)
            {
                    throw new NullReferenceException();
            }
            
            val_23 = this.blockerButton.m_OnClick;
            if(val_23 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_23.AddListener(call:  new UnityEngine.Events.UnityAction(object:  val_1, method:  System.Void LeaguesTutorial_Window.<>c__DisplayClass5_0::<AdvancePage>b__0()));
            if(this.bgButton == null)
            {
                    throw new NullReferenceException();
            }
            
            val_24 = 0;
            goto label_51;
            label_12:
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
            return;
            label_47:
            if(this.blockerButton == null)
            {
                    throw new NullReferenceException();
            }
            
            val_21 = this.blockerButton.m_OnClick;
            UnityEngine.Events.UnityAction val_20 = null;
            val_23 = val_20;
            val_20 = new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void SLC.Social.Leagues.LeaguesTutorial_Window::AdvancePage());
            if(val_21 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_21.AddListener(call:  val_20);
            if(this.bgButton == null)
            {
                    throw new NullReferenceException();
            }
            
            val_24 = 1;
            label_51:
            this.bgButton.interactable = true;
            return;
            label_23:
            .highlightRect = 0;
            throw new NullReferenceException();
        }
        public void Skip()
        {
            SLC.Social.Leagues.LeaguesUIManager val_1 = MonoSingleton<SLC.Social.Leagues.LeaguesUIManager>.Instance;
            val_1.tutorialHighlights.UnhighlightCurrent();
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        private void Close()
        {
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        public LeaguesTutorial_Window()
        {
            this.currPageIndex = 0;
        }
    
    }

}
