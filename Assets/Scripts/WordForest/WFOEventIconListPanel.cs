using UnityEngine;

namespace WordForest
{
    public class WFOEventIconListPanel : MonoBehaviour
    {
        // Fields
        private const float REFRESH_INTERVAL = 4;
        private float refreshTimer;
        protected UnityEngine.GameObject buttonParentContainer;
        protected WordForest.WFOMiniEventButton buttonAttackMadness;
        protected WordForest.WFOMiniEventButton buttonRaidMadness;
        protected WordForest.WFOMiniEventButton buttonForestMaster;
        protected WordForest.WFOMiniEventButton buttonLightningLevels;
        protected WordForest.WFOMiniEventButton buttonWildWord;
        protected WordForest.WFOMiniEventButton buttonIslandParadise;
        protected WordForest.WFOMiniEventButton buttonWordHunt;
        private System.Collections.Generic.Dictionary<string, WordForest.WFOMiniEventButton> buttonList;
        private static System.Collections.Generic.Dictionary<string, bool> isButtonTypeShown;
        
        // Methods
        private WordForest.WFOMiniEventButton GetButtonPrefab(string eventId)
        {
            WordForest.WFOMiniEventButton val_9;
            string val_10;
            uint val_1 = _PrivateImplementationDetails_.ComputeStringHash(s:  eventId);
            if(val_1 > (-1392364358))
            {
                goto label_1;
            }
            
            if(val_1 > 999457290)
            {
                goto label_2;
            }
            
            if(val_1 == 145907821)
            {
                goto label_3;
            }
            
            if(val_1 != 999457290)
            {
                goto label_16;
            }
            
            val_9 = 0;
            if((System.String.op_Equality(a:  eventId, b:  "AttackMadness")) == false)
            {
                    return val_9;
            }
            
            val_9 = this.buttonAttackMadness;
            return val_9;
            label_1:
            if(val_1 > (-1050565114))
            {
                goto label_7;
            }
            
            if(val_1 == (-1129030916))
            {
                goto label_8;
            }
            
            if(val_1 != (-1050565114))
            {
                goto label_16;
            }
            
            val_9 = 0;
            if((System.String.op_Equality(a:  eventId, b:  "ForestMaster")) == false)
            {
                    return val_9;
            }
            
            val_9 = this.buttonForestMaster;
            return val_9;
            label_2:
            if(val_1 == (-1392364358))
            {
                goto label_12;
            }
            
            if(val_1 != 1751534916)
            {
                goto label_16;
            }
            
            val_10 = "HotNSpicy";
            goto label_14;
            label_7:
            if(val_1 == (-623396922))
            {
                goto label_15;
            }
            
            if(val_1 == (-84738646))
            {
                    val_9 = 0;
                if((System.String.op_Equality(a:  eventId, b:  "LightningLevels")) == false)
            {
                    return val_9;
            }
            
                val_9 = this.buttonLightningLevels;
                return val_9;
            }
            
            label_16:
            val_9 = 0;
            return val_9;
            label_3:
            val_10 = "IslandParadiseSymbol";
            label_14:
            val_9 = 0;
            if((System.String.op_Equality(a:  eventId, b:  val_10)) == false)
            {
                    return val_9;
            }
            
            val_9 = this.buttonIslandParadise;
            return val_9;
            label_8:
            val_9 = 0;
            if((System.String.op_Equality(a:  eventId, b:  "WordHunt")) == false)
            {
                    return val_9;
            }
            
            val_9 = this.buttonWordHunt;
            return val_9;
            label_12:
            val_9 = 0;
            if((System.String.op_Equality(a:  eventId, b:  "WildWordWeekend")) == false)
            {
                    return val_9;
            }
            
            val_9 = this.buttonWildWord;
            return val_9;
            label_15:
            val_9 = 0;
            if((System.String.op_Equality(a:  eventId, b:  "RaidMadness")) == false)
            {
                    return val_9;
            }
            
            val_9 = this.buttonRaidMadness;
            return val_9;
        }
        private void Awake()
        {
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnGameEventControllerUpdate");
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnGameEventHandlerProgress");
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnGameEventDataReceived");
        }
        private void OnDestroy()
        {
            NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  "OnGameEventControllerUpdate");
            NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  "OnGameEventHandlerProgress");
            NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  "OnGameEventDataReceived");
        }
        private void OnEnable()
        {
            this.UpdateDisplay();
        }
        private void Update()
        {
            float val_1 = UnityEngine.Time.deltaTime;
            val_1 = this.refreshTimer + val_1;
            this.refreshTimer = val_1;
            if(val_1 < 4f)
            {
                    return;
            }
            
            this.Refresh();
            this.refreshTimer = 0f;
        }
        private void Refresh()
        {
            MonoSingleton<GameEventsManager>.Instance.CheckAndRequestServerEvents();
        }
        private void OnGameEventDataReceived()
        {
            this.UpdateDisplay();
        }
        private void OnGameEventControllerUpdate()
        {
            this.UpdateDisplay();
        }
        private void OnGameEventHandlerProgress()
        {
            this.UpdateDisplay();
        }
        private void UpdateDisplay()
        {
            WordForest.WFOMiniEventButton val_28;
            var val_29;
            System.Collections.Generic.Dictionary<System.String, WordForest.WFOMiniEventButton> val_41;
            System.Collections.Generic.IComparer<T> val_42;
            var val_43;
            var val_44;
            var val_45;
            var val_46;
            var val_47;
            var val_48;
            var val_49;
            val_41 = 0;
            if(this.buttonParentContainer == null)
            {
                    throw new NullReferenceException();
            }
            
            val_42 = 0;
            UnityEngine.GameObject val_2 = this.buttonParentContainer.gameObject;
            if(val_2 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(WordGameEventsController.EventsEnabled == false)
            {
                goto label_5;
            }
            
            val_42 = 1;
            val_2.SetActive(value:  true);
            WordGameEventsController val_3 = MonoSingleton<WordGameEventsController>.Instance;
            if(val_3 == null)
            {
                    throw new NullReferenceException();
            }
            
            System.Collections.Generic.List<WGEventHandler> val_4 = val_3.GetOrderedEventHandlers();
            WordForest.WFOEventSort val_5 = null;
            val_42 = 0;
            val_5 = new WordForest.WFOEventSort();
            if(val_4 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_42 = val_5;
            val_4.Sort(comparer:  val_5);
            if(1152921518100365552 < 1)
            {
                goto label_10;
            }
            
            label_48:
            if(this.buttonList == null)
            {
                goto label_14;
            }
            
            if(0 >= 1152921518100365552)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_41 = "Free Life From Ads";
            val_42 = EventType;
            if((this.buttonList.ContainsKey(key:  val_42)) == false)
            {
                goto label_14;
            }
            
            if(0 >= 44414000)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_41 = "Free Life From Ads";
            val_42 = 0;
            if(this.buttonList == null)
            {
                    throw new NullReferenceException();
            }
            
            val_42 = 0;
            if(this.buttonList.Item[EventType] != val_42)
            {
                goto label_39;
            }
            
            label_14:
            if(0 >= null)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_42 = 0;
            if((this.GetButtonPrefab(eventId:  UnityEngine.Object.__il2cppRuntimeField_byval_arg.EventType)) == val_42)
            {
                goto label_25;
            }
            
            if(0 >= null)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_42 = UnityEngine.Object.__il2cppRuntimeField_byval_arg.EventType;
            if(this.buttonParentContainer == null)
            {
                    throw new NullReferenceException();
            }
            
            val_42 = this.buttonParentContainer.transform;
            WordForest.WFOMiniEventButton val_17 = UnityEngine.Object.Instantiate<WordForest.WFOMiniEventButton>(original:  this.GetButtonPrefab(eventId:  val_42), parent:  val_42);
            if(0 >= 1152921518100414704)
            {
                    val_41 = 0;
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            if(val_17 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_42 = System.Boolean TRVCategoryUnlockPopup.<>c::<UnlockCategory>b__5_0(System.Collections.Generic.KeyValuePair<string, int> x);
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            val_41 = mem[(typeof(WordForest.WFOMiniEventButton).__il2cppRuntimeField_180 + 0) + 32];
            val_41 = (typeof(WordForest.WFOMiniEventButton).__il2cppRuntimeField_180 + 0) + 32;
            val_42 = val_41.EventType;
            EnumerableExtentions.SetOrAdd<System.String, WordForest.WFOMiniEventButton>(dic:  this.buttonList, key:  val_42, newValue:  val_17);
            val_43 = null;
            val_43 = null;
            if(0 >= null)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_42 = WordForest.WFOEventIconListPanel.isButtonTypeShown.__il2cppRuntimeField_20.EventType;
            if((EnumerableExtentions.GetOrDefault<System.String, System.Boolean>(dic:  WordForest.WFOEventIconListPanel.isButtonTypeShown, key:  val_42, defaultValue:  false)) != true)
            {
                    val_42 = 0;
                val_17.ShowIntroAnimation();
                val_44 = null;
                val_44 = null;
                if(0 >= null)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_42 = WordForest.WFOEventIconListPanel.isButtonTypeShown.__il2cppRuntimeField_20.EventType;
                EnumerableExtentions.SetOrAdd<System.String, System.Boolean>(dic:  WordForest.WFOEventIconListPanel.isButtonTypeShown, key:  val_42, newValue:  true);
            }
            
            label_39:
            if(0 >= 1152921518100437232)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_41 = "pur_ret_0101";
            val_42 = 0;
            if(this.buttonList == null)
            {
                    throw new NullReferenceException();
            }
            
            val_42 = EventType;
            if(this.buttonList.Item[val_42] == null)
            {
                    throw new NullReferenceException();
            }
            
            label_25:
            val_45 = 0 + 1;
            if(val_45 < null)
            {
                goto label_48;
            }
            
            label_10:
            System.Collections.Generic.List<System.String> val_25 = null;
            val_42 = public System.Void System.Collections.Generic.List<System.String>::.ctor();
            val_25 = new System.Collections.Generic.List<System.String>();
            val_41 = this.buttonList;
            if(val_41 == null)
            {
                    throw new NullReferenceException();
            }
            
            Dictionary.Enumerator<TKey, TValue> val_26 = val_41.GetEnumerator();
            val_46 = 1152921505001254912;
            val_47 = 1152921518100460784;
            label_59:
            if(val_29.MoveNext() == false)
            {
                goto label_50;
            }
            
            WFOEventIconListPanel.<>c__DisplayClass21_0 val_31 = null;
            val_42 = 0;
            val_31 = new WFOEventIconListPanel.<>c__DisplayClass21_0();
            if(val_31 == null)
            {
                    throw new NullReferenceException();
            }
            
            .currVisibleButton = val_28;
            val_41 = val_28;
            val_42 = 0;
            if(val_41 != val_42)
            {
                goto label_54;
            }
            
            if(val_25 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_25.Add(item:  val_28);
            goto label_59;
            label_54:
            if((val_4.FindIndex(match:  new System.Predicate<WGEventHandler>(object:  val_31, method:  System.Boolean WFOEventIconListPanel.<>c__DisplayClass21_0::<UpdateDisplay>b__0(WGEventHandler n)))) != 1)
            {
                goto label_59;
            }
            
            val_25.Add(item:  val_28);
            goto label_59;
            label_5:
            val_2.SetActive(value:  false);
            return;
            label_50:
            val_42 = public System.Void Dictionary.Enumerator<System.String, WordForest.WFOMiniEventButton>::Dispose();
            val_29.Dispose();
            if(val_25 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(1152921518100471024 < 1)
            {
                    return;
            }
            
            val_45 = 1152921518100367600;
            val_46 = 1152921510207326080;
            val_47 = 1152921518100473072;
            var val_42 = 4;
            var val_35 = val_42 - 4;
            if(val_35 >= 1152921518100471024)
            {
                    val_41 = 0;
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            if(this.buttonList == null)
            {
                    throw new NullReferenceException();
            }
            
            WordForest.WFOMiniEventButton val_36 = this.buttonList.Item["to cannot be null."];
            val_41 = val_36;
            val_42 = 0;
            if(val_41 != val_42)
            {
                    if(val_36 == null)
            {
                    throw new NullReferenceException();
            }
            
            }
            
            if(val_35 >= null)
            {
                    val_41 = 0;
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            if(this.buttonList == null)
            {
                    throw new NullReferenceException();
            }
            
            bool val_38 = this.buttonList.Remove(key:  WordForest.WFOMiniEventButton.__il2cppRuntimeField_byval_arg);
            val_48 = null;
            val_48 = null;
            val_41 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
            if(WordForest.WFOEventIconListPanel.isButtonTypeShown == null)
            {
                    throw new NullReferenceException();
            }
            
            if((WordForest.WFOEventIconListPanel.isButtonTypeShown.ContainsKey(key:  WordForest.WFOEventIconListPanel.isButtonTypeShown.__il2cppRuntimeField_20)) != false)
            {
                    val_49 = null;
                val_49 = null;
                val_41 = 0;
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
                if(WordForest.WFOEventIconListPanel.isButtonTypeShown == null)
            {
                    throw new NullReferenceException();
            }
            
                bool val_40 = WordForest.WFOEventIconListPanel.isButtonTypeShown.Remove(key:  WordForest.WFOEventIconListPanel.isButtonTypeShown.__il2cppRuntimeField_20);
            }
            
            var val_41 = val_42 - 3;
            val_42 = val_42 + 1;
        }
        public WFOEventIconListPanel()
        {
            this.buttonList = new System.Collections.Generic.Dictionary<System.String, WordForest.WFOMiniEventButton>();
        }
        private static WFOEventIconListPanel()
        {
            WordForest.WFOEventIconListPanel.isButtonTypeShown = new System.Collections.Generic.Dictionary<System.String, System.Boolean>();
        }
    
    }

}
