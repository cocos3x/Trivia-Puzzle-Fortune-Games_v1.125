using UnityEngine;

namespace SLC.Social.Leagues
{
    public class LeaguesWelcome_Window : MonoBehaviour
    {
        // Fields
        private AvatarSlotUGUI[] friendAvatars;
        private UnityEngine.UI.Text descriptionText;
        private UnityEngine.UI.Button skipButton;
        private UnityEngine.UI.Button tourButton;
        
        // Methods
        private void Awake()
        {
            this.skipButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesWelcome_Window::onClick_Skip()));
            this.tourButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Social.Leagues.LeaguesWelcome_Window::onClick_Tour()));
        }
        private void onClick_Tour()
        {
            SLC.Social.Leagues.LeaguesWindowManager val_2 = MonoSingleton<SLC.Social.Leagues.LeaguesWindowManager>.Instance.ShowUGUIMonolith<SLC.Social.Leagues.LeaguesTutorial_Window>(showNext:  true);
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        private void onClick_Skip()
        {
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        private void OnEnable()
        {
            var val_20;
            System.Func<SLC.Social.Profile, System.Boolean> val_22;
            var val_23;
            System.Predicate<SLC.Social.Profile> val_25;
            if(SLC.Social.Leagues.LeaguesManager.DAO.MyGuild != null)
            {
                    SLC.Social.Leagues.Guild val_5 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
                string val_6 = System.String.Format(format:  Localization.Localize(key:  "club_welcome_info", defaultValue:  "The team members of {0} welcome you to the club!", useSingularKey:  false), arg0:  val_5.Name);
                System.Collections.Generic.List<SLC.Social.Profile> val_7 = new System.Collections.Generic.List<SLC.Social.Profile>();
                SLC.Social.Leagues.Guild val_9 = SLC.Social.Leagues.LeaguesManager.DAO.MyGuild;
                val_20 = null;
                val_20 = null;
                val_22 = LeaguesWelcome_Window.<>c.<>9__7_0;
                if(val_22 == null)
            {
                    System.Func<SLC.Social.Profile, System.Boolean> val_11 = null;
                val_22 = val_11;
                val_11 = new System.Func<SLC.Social.Profile, System.Boolean>(object:  LeaguesWelcome_Window.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean LeaguesWelcome_Window.<>c::<OnEnable>b__7_0(SLC.Social.Profile x));
                LeaguesWelcome_Window.<>c.<>9__7_0 = val_22;
            }
            
                val_7.AddRange(collection:  System.Linq.Enumerable.OrderBy<SLC.Social.Profile, System.Boolean>(source:  val_9.members.Values, keySelector:  val_11));
                val_23 = null;
                val_23 = null;
                val_25 = LeaguesWelcome_Window.<>c.<>9__7_1;
                if(val_25 == null)
            {
                    System.Predicate<SLC.Social.Profile> val_13 = null;
                val_25 = val_13;
                val_13 = new System.Predicate<SLC.Social.Profile>(object:  LeaguesWelcome_Window.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean LeaguesWelcome_Window.<>c::<OnEnable>b__7_1(SLC.Social.Profile x));
                LeaguesWelcome_Window.<>c.<>9__7_1 = val_25;
            }
            
                int val_14 = val_7.RemoveAll(match:  val_13);
                var val_22 = 4;
                do
            {
                if((val_22 - 4) >= (this.friendAvatars.Length << ))
            {
                    return;
            }
            
                val_25 = this.friendAvatars[0];
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
                val_22 = val_22 + 1;
            }
            while(this.friendAvatars != null);
            
                throw new NullReferenceException();
            }
            
            UnityEngine.Debug.LogError(message:  "no club to welcome to!", context:  this);
            UnityEngine.Coroutine val_20 = this.StartCoroutine(routine:  this.CloseAfterFrame());
        }
        private System.Collections.IEnumerator CloseAfterFrame()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new LeaguesWelcome_Window.<CloseAfterFrame>d__8();
        }
        private void Close()
        {
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        public LeaguesWelcome_Window()
        {
        
        }
    
    }

}
