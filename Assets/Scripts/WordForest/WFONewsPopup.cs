using UnityEngine;

namespace WordForest
{
    public class WFONewsPopup : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Button closeButton;
        private WordForest.WFONewsListItem prefabNewsListItem;
        private UnityEngine.UI.ScrollRect scrollRect;
        private static System.Nullable<System.DateTime> lastSeenNewsTimestamp;
        
        // Properties
        public static int UnseenNewsCount { get; }
        public static System.DateTime LastSeenNewsTimestamp { get; set; }
        
        // Methods
        public static int get_UnseenNewsCount()
        {
            var val_10;
            var val_11;
            WordForest.RaidAttackManager val_1 = MonoSingleton<WordForest.RaidAttackManager>.Instance;
            if(val_1.dataController.NewsArticles != null)
            {
                    val_10 = 0;
                val_11 = 0;
                WordForest.RaidAttackManager val_8 = MonoSingleton<WordForest.RaidAttackManager>.Instance;
                System.Collections.Generic.List<WordForest.NewsArticle> val_9 = val_8.dataController.NewsArticles;
                return (int)val_11;
            }
            
            val_11 = 0;
            return (int)val_11;
        }
        public static System.DateTime get_LastSeenNewsTimestamp()
        {
            string val_8;
            var val_9;
            string val_1 = UnityEngine.PlayerPrefs.GetString(key:  "wfo_news_lastseen_ts", defaultValue:  0);
            val_8 = val_1;
            if((System.String.IsNullOrEmpty(value:  val_1)) != true)
            {
                    System.DateTime val_3 = Newtonsoft.Json.JsonConvert.DeserializeObject<System.DateTime>(value:  val_8);
                System.Nullable<System.DateTime> val_4 = new System.Nullable<System.DateTime>(value:  new System.DateTime() {dateData = val_3.dateData});
                WordForest.WFONewsPopup.lastSeenNewsTimestamp = val_4.HasValue;
            }
            
            val_8 = 1152921504616751104;
            val_9 = null;
            val_9 = null;
            System.Nullable<System.DateTime> val_5 = new System.Nullable<System.DateTime>(value:  new System.DateTime() {dateData = System.DateTime.MinValue});
            WordForest.WFONewsPopup.lastSeenNewsTimestamp = val_5.HasValue;
            System.DateTime val_6 = WordForest.WFONewsPopup.lastSeenNewsTimestamp.Value;
            return (System.DateTime)val_6.dateData;
        }
        public static void set_LastSeenNewsTimestamp(System.DateTime value)
        {
            System.Nullable<System.DateTime> val_1 = new System.Nullable<System.DateTime>(value:  new System.DateTime() {dateData = value.dateData});
            WordForest.WFONewsPopup.lastSeenNewsTimestamp = val_1.HasValue;
            UnityEngine.PlayerPrefs.SetString(key:  "wfo_news_lastseen_ts", value:  Newtonsoft.Json.JsonConvert.SerializeObject(value:  value));
        }
        private void Start()
        {
            this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WordForest.WFONewsPopup::CloseWindow()));
            this.Initialize();
        }
        private void CloseWindow()
        {
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
            WordForest.RaidAttackManager val_2 = MonoSingleton<WordForest.RaidAttackManager>.Instance;
            val_2.notifyController.Notify(note:  5, data:  0);
        }
        private void Initialize()
        {
            var val_5;
            var val_6;
            System.Comparison<WordForest.NewsArticle> val_8;
            var val_9;
            WordForest.RaidAttackManager val_1 = MonoSingleton<WordForest.RaidAttackManager>.Instance;
            System.Collections.Generic.List<WordForest.NewsArticle> val_2 = val_1.dataController.NewsArticles;
            if(val_2 == null)
            {
                    return;
            }
            
            val_5 = 1152921505004875776;
            val_6 = null;
            val_6 = null;
            val_8 = WFONewsPopup.<>c.<>9__11_0;
            if(val_8 == null)
            {
                    System.Comparison<WordForest.NewsArticle> val_3 = null;
                val_8 = val_3;
                val_3 = new System.Comparison<WordForest.NewsArticle>(object:  WFONewsPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 WFONewsPopup.<>c::<Initialize>b__11_0(WordForest.NewsArticle a, WordForest.NewsArticle b));
                WFONewsPopup.<>c.<>9__11_0 = val_8;
            }
            
            val_2.Sort(comparison:  val_3);
            if(1152921518072511056 < 1)
            {
                    return;
            }
            
            val_8 = 0;
            if(0 >= 1152921518072511056)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_9 = "pp_skp_t";
            if((val_8 & 1) == 0)
            {
                    if(0 >= 1152921518072510032)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                WordForest.WFONewsPopup.LastSeenNewsTimestamp = new System.DateTime() {dateData = "pp_skp_t".__il2cppRuntimeField_20 + 32};
            }
            
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            UnityEngine.Object.Instantiate<WordForest.WFONewsListItem>(original:  this.prefabNewsListItem, parent:  this.scrollRect.m_Content).Initialize(data:  UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 32);
            val_8 = 1;
            var val_5 = 4 - 3;
            val_5 = 4 + 1;
        }
        public WFONewsPopup()
        {
        
        }
    
    }

}
