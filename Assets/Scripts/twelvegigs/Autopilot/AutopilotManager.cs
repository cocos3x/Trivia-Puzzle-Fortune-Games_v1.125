using UnityEngine;

namespace twelvegigs.Autopilot
{
    public class AutopilotManager : MonoSingleton<twelvegigs.Autopilot.AutopilotManager>
    {
        // Fields
        private const double NO_ACTIVITY_MAX_SEC = 60;
        private const float REPEAT_ACTION_RATE = 3;
        private const string HIDDEN_CLICKS = "[hidden_clicks] ";
        private bool <AllowPurchases>k__BackingField;
        private System.Collections.Generic.List<twelvegigs.Autopilot.AutopilotButton> <aButtons>k__BackingField;
        private bool initialized;
        private System.Collections.Generic.List<string> instructions;
        private System.Collections.Generic.HashSet<string> ignoreButtons;
        private System.Collections.Hashtable pressedBtn;
        private twelvegigs.Autopilot.AutopilotGameplay gameplay;
        private twelvegigs.Autopilot.AutopilotRequester requester;
        private bool pauseSceneChange;
        private bool pauseAutomation;
        private System.DateTime lastAction;
        private bool defaultAllowPurchases;
        private int defaultLevels;
        
        // Properties
        public static twelvegigs.Autopilot.AutopilotRequester Requester { get; }
        public static twelvegigs.Autopilot.AutopilotGameplay Gameplay { get; }
        public bool AllowPurchases { get; set; }
        public System.Collections.Generic.List<twelvegigs.Autopilot.AutopilotButton> aButtons { get; set; }
        
        // Methods
        public static twelvegigs.Autopilot.AutopilotRequester get_Requester()
        {
            if((MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance) == 0)
            {
                    return 0;
            }
            
            twelvegigs.Autopilot.AutopilotManager val_3 = MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance;
            0 = val_3.requester;
            return 0;
        }
        public static twelvegigs.Autopilot.AutopilotGameplay get_Gameplay()
        {
            if((MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance) == 0)
            {
                    return 0;
            }
            
            twelvegigs.Autopilot.AutopilotManager val_3 = MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance;
            0 = val_3.gameplay;
            return 0;
        }
        public bool get_AllowPurchases()
        {
            return (bool)this.<AllowPurchases>k__BackingField;
        }
        public void set_AllowPurchases(bool value)
        {
            this.<AllowPurchases>k__BackingField = value;
        }
        public System.Collections.Generic.List<twelvegigs.Autopilot.AutopilotButton> get_aButtons()
        {
            return (System.Collections.Generic.List<twelvegigs.Autopilot.AutopilotButton>)this.<aButtons>k__BackingField;
        }
        private void set_aButtons(System.Collections.Generic.List<twelvegigs.Autopilot.AutopilotButton> value)
        {
            this.<aButtons>k__BackingField = value;
        }
        public override void InitMonoSingleton()
        {
            this.InitMonoSingleton();
            if(this.initialized == true)
            {
                    return;
            }
            
            this.initialized = true;
        }
        public void AddInstruction(System.Collections.Generic.List<string> newInstructions, bool clearPrevious = False)
        {
            if(clearPrevious != false)
            {
                    this.instructions.Clear();
            }
            
            this.instructions.AddRange(collection:  newInstructions);
        }
        public void AddIgnore(string button, bool clearPrevious = False)
        {
            if(clearPrevious != false)
            {
                    this.ignoreButtons.Clear();
            }
            
            bool val_1 = this.ignoreButtons.Add(item:  button);
        }
        public void ClearIgnore()
        {
            this.ignoreButtons.Clear();
        }
        public void UpdateCounter(string path, int count, int hiddenCount = 0)
        {
            if(hiddenCount < 1)
            {
                    return;
            }
            
            this = this.pressedBtn;
            string val_1 = 31135432 + path;
        }
        public void TrackButtonPressed(twelvegigs.Autopilot.AutopilotButton button)
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_10;
            var val_11;
            val_10 = this;
            if(this.pauseAutomation == true)
            {
                    return;
            }
            
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = null;
            val_10 = val_1;
            val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            System.DateTime val_2 = System.DateTime.UtcNow;
            val_1.Add(key:  "timestamp", value:  twelvegigs.storage.JsonDictionary.TotalSeconds(dateTime:  new System.DateTime() {dateData = val_2.dateData}));
            val_1.Add(key:  "route", value:  button.route);
            val_1.Add(key:  "count", value:  (button.GetCount(hidden:  true)) + (button.GetCount(hidden:  false)));
            val_1.Add(key:  "unique_tag", value:  new System.Random().ToString());
            val_11 = null;
            val_11 = null;
            App.trackerManager.track(eventName:  "auto_breadcrumb", data:  val_1);
        }
        public void TrackError(System.Collections.Generic.Dictionary<string, string> newError)
        {
            long val_9;
            twelvegigs.Autopilot.AutopilotRequester val_10;
            var val_11;
            System.Func<System.Collections.Generic.KeyValuePair<System.String, System.String>, System.String> val_13;
            System.Func<System.Collections.Generic.KeyValuePair<System.String, System.String>, System.Object> val_15;
            var val_16;
            val_10 = this;
            if(this.pauseAutomation == true)
            {
                    return;
            }
            
            this.PauseAutomation(pause:  true);
            val_11 = null;
            val_11 = null;
            val_13 = AutopilotManager.<>c.<>9__32_0;
            if(val_13 == null)
            {
                    System.Func<System.Collections.Generic.KeyValuePair<System.String, System.String>, System.String> val_1 = null;
                val_13 = val_1;
                val_1 = new System.Func<System.Collections.Generic.KeyValuePair<System.String, System.String>, System.String>(object:  AutopilotManager.<>c.__il2cppRuntimeField_static_fields, method:  System.String AutopilotManager.<>c::<TrackError>b__32_0(System.Collections.Generic.KeyValuePair<string, string> pair));
                val_11 = null;
                AutopilotManager.<>c.<>9__32_0 = val_13;
            }
            
            val_11 = null;
            val_15 = AutopilotManager.<>c.<>9__32_1;
            if(val_15 == null)
            {
                    System.Func<System.Collections.Generic.KeyValuePair<System.String, System.String>, System.Object> val_2 = null;
                val_15 = val_2;
                val_2 = new System.Func<System.Collections.Generic.KeyValuePair<System.String, System.String>, System.Object>(object:  AutopilotManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Object AutopilotManager.<>c::<TrackError>b__32_1(System.Collections.Generic.KeyValuePair<string, string> pair));
                AutopilotManager.<>c.<>9__32_1 = val_15;
            }
            
            System.Collections.Generic.Dictionary<TKey, TElement> val_3 = System.Linq.Enumerable.ToDictionary<System.Collections.Generic.KeyValuePair<System.String, System.String>, System.String, System.Object>(source:  newError, keySelector:  val_1, elementSelector:  val_2);
            System.DateTime val_4 = System.DateTime.UtcNow;
            long val_5 = twelvegigs.storage.JsonDictionary.TotalSeconds(dateTime:  new System.DateTime() {dateData = val_4.dateData});
            val_9 = val_5;
            val_3.Add(key:  "timestamp", value:  val_5);
            string val_7 = new System.Random().ToString();
            val_3.Add(key:  "unique_tag", value:  val_7);
            val_16 = null;
            val_16 = null;
            App.trackerManager.track(eventName:  "auto_errors", data:  val_3);
            val_10 = this.requester;
            AppConfigs val_8 = App.Configuration;
            val_10.TakeScreenshot(actionTimestamp:  val_9, uniqueTag:  val_7, game:  val_8.appConfig.gameName);
        }
        public int ButtonPressedCount(string path, bool hiddenCount = False)
        {
            string val_2;
            var val_3;
            val_2 = path;
            if(val_2 != null)
            {
                    if(hiddenCount != false)
            {
                    val_2 = "[hidden_clicks] " + val_2;
            }
            
                if((this.pressedBtn & 1) != 0)
            {
                    return (int)val_3;
            }
            
            }
            
            val_3 = 0;
            return (int)val_3;
        }
        public void PauseAutomation(bool pause = True)
        {
            twelvegigs.Autopilot.AutopilotTools.Log(message:  (pause != true) ? "PAUSE" : "RESUME"((pause != true) ? "PAUSE" : "RESUME") + " AUTOMATION");
            this.pauseAutomation = pause;
            System.DateTime val_4 = System.DateTime.UtcNow;
            this.lastAction = val_4;
        }
        private void OnSceneChange(SceneType sceneType)
        {
            this.pauseSceneChange = true;
            UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.GetButtonElements());
        }
        private void OnSceneUnloaded(SceneType sceneType)
        {
            this.<aButtons>k__BackingField.Clear();
            goto typeof(twelvegigs.Autopilot.AutopilotGameplay).__il2cppRuntimeField_1A0;
        }
        private void ExecutePilot()
        {
            if(this.pauseAutomation == true)
            {
                    return;
            }
            
            if(this.pauseSceneChange == true)
            {
                    return;
            }
            
            System.DateTime val_1 = System.DateTime.UtcNow;
            System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = this.lastAction}, d2:  new System.DateTime() {dateData = val_1.dateData});
            if(val_2._ticks.TotalSeconds > 60)
            {
                    this.StopAutomation();
                return;
            }
            
            if((this.gameplay & 1) != 0)
            {
                    System.DateTime val_4 = System.DateTime.UtcNow;
                this.lastAction = val_4;
                return;
            }
            
            UnityEngine.Coroutine val_6 = this.StartCoroutine(routine:  this.TrySelectableAction());
        }
        private void StopAutomation()
        {
            var val_7;
            twelvegigs.Autopilot.AutopilotTools.Log(message:  "STOP AUTOMATION");
            this.pauseAutomation = true;
            this.CancelInvoke(methodName:  "ExecutePilot");
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            System.DateTime val_2 = System.DateTime.UtcNow;
            long val_3 = twelvegigs.storage.JsonDictionary.TotalSeconds(dateTime:  new System.DateTime() {dateData = val_2.dateData});
            val_1.Add(key:  "timestamp", value:  val_3);
            string val_5 = new System.Random().ToString();
            val_1.Add(key:  "unique_tag", value:  val_5);
            val_7 = null;
            val_7 = null;
            App.trackerManager.track(eventName:  "auto_stop_actions", data:  val_1);
            AppConfigs val_6 = App.Configuration;
            this.requester.TakeScreenshot(actionTimestamp:  val_3, uniqueTag:  val_5, game:  val_6.appConfig.gameName);
        }
        private System.Collections.IEnumerator GetButtonElements()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new AutopilotManager.<GetButtonElements>d__39();
        }
        private System.Collections.IEnumerator TrySelectableAction()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new AutopilotManager.<TrySelectableAction>d__40();
        }
        private void ExecuteSelectableAction()
        {
            twelvegigs.Autopilot.AutopilotButton val_18;
            var val_19;
            var val_34;
            System.Collections.Generic.IEnumerable<TSource> val_35;
            var val_36;
            System.Func<UnityEngine.Camera, System.Single> val_38;
            var val_40;
            var val_41;
            var val_44;
            System.Func<twelvegigs.Autopilot.AutopilotButton, System.Int32> val_46;
            var val_47;
            var val_48;
            var val_49;
            var val_50;
            val_34 = this;
            if(((this.<aButtons>k__BackingField) == null) || ((this.<aButtons>k__BackingField) < 1))
            {
                goto label_102;
            }
            
            val_35 = UnityEngine.Camera.allCameras;
            val_36 = null;
            val_36 = null;
            val_38 = AutopilotManager.<>c.<>9__41_0;
            if(val_38 == null)
            {
                    System.Func<UnityEngine.Camera, System.Single> val_2 = null;
                val_38 = val_2;
                val_2 = new System.Func<UnityEngine.Camera, System.Single>(object:  AutopilotManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Single AutopilotManager.<>c::<ExecuteSelectableAction>b__41_0(UnityEngine.Camera camera));
                AutopilotManager.<>c.<>9__41_0 = val_38;
            }
            
            System.Linq.IOrderedEnumerable<TSource> val_3 = System.Linq.Enumerable.OrderByDescending<UnityEngine.Camera, System.Single>(source:  val_35, keySelector:  val_2);
            if(val_3 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_36 = 0;
            val_36 = val_36 + 1;
            val_40 = val_3.GetEnumerator();
            val_41 = 0;
            label_65:
            var val_37 = 0;
            val_37 = val_37 + 1;
            if(val_40.MoveNext() == false)
            {
                goto label_18;
            }
            
            var val_38 = 0;
            val_38 = val_38 + 1;
            val_38 = val_40.Current;
            AutopilotManager.<>c__DisplayClass41_0 val_10 = new AutopilotManager.<>c__DisplayClass41_0();
            if(val_38 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(val_10 == null)
            {
                    throw new NullReferenceException();
            }
            
            .cameraInstanceID = val_38.GetInstanceID();
            val_44 = null;
            val_44 = null;
            val_46 = AutopilotManager.<>c.<>9__41_2;
            if(val_46 == null)
            {
                    System.Func<twelvegigs.Autopilot.AutopilotButton, System.Int32> val_14 = null;
                val_46 = val_14;
                val_14 = new System.Func<twelvegigs.Autopilot.AutopilotButton, System.Int32>(object:  AutopilotManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Int32 AutopilotManager.<>c::<ExecuteSelectableAction>b__41_2(twelvegigs.Autopilot.AutopilotButton aButton));
                AutopilotManager.<>c.<>9__41_2 = val_46;
            }
            
            System.Collections.Generic.List<TSource> val_16 = System.Linq.Enumerable.ToList<twelvegigs.Autopilot.AutopilotButton>(source:  System.Linq.Enumerable.OrderBy<twelvegigs.Autopilot.AutopilotButton, System.Int32>(source:  System.Linq.Enumerable.Where<twelvegigs.Autopilot.AutopilotButton>(source:  this.<aButtons>k__BackingField, predicate:  new System.Func<twelvegigs.Autopilot.AutopilotButton, System.Boolean>(object:  val_10, method:  System.Boolean AutopilotManager.<>c__DisplayClass41_0::<ExecuteSelectableAction>b__1(twelvegigs.Autopilot.AutopilotButton aButton))), keySelector:  val_14));
            if(this.instructions == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_16 == null)
            {
                    throw new NullReferenceException();
            }
            
            List.Enumerator<T> val_17 = val_16.GetEnumerator();
            label_38:
            if(val_19.MoveNext() == false)
            {
                goto label_33;
            }
            
            if(val_18 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if((val_18 + 56) == 0)
            {
                    throw new NullReferenceException();
            }
            
            if((val_18 + 56.Contains(value:  val_14)) == false)
            {
                goto label_38;
            }
            
            bool val_22 = val_18.CanBePressed();
            if((val_22 == false) || ((val_22.SimulateClick(btn:  val_18, camera:  val_38, hiddenClick:  true)) == false))
            {
                goto label_38;
            }
            
            object[] val_24 = new object[1];
            if(val_24 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_24[0] = val_46;
            twelvegigs.Autopilot.AutopilotTools.LogFormat(format:  "Follow instruction: {0}", args:  val_24);
            if(this.instructions == null)
            {
                    throw new NullReferenceException();
            }
            
            this.instructions.RemoveAt(index:  0);
            val_46 = 0;
            val_47 = val_41 + 1;
            val_48 = 451;
            goto label_44;
            label_33:
            val_46 = 0;
            val_47 = val_41 + 1;
            val_48 = 320;
            label_44:
            mem2[0] = 320;
            val_19.Dispose();
            if(val_46 != 0)
            {
                    throw val_46;
            }
            
            if(val_47 == 1)
            {
                goto label_46;
            }
            
            if((1152921520000184432 + ((val_41 + 1)) << 2) == 451)
            {
                goto label_64;
            }
            
            var val_25 = ((1152921520000184432 + ((val_41 + 1)) << 2) == 320) ? 1 : 0;
            val_25 = ((val_47 >= 0) ? 1 : 0) & val_25;
            val_49 = val_47 - val_25;
            label_46:
            if(val_16 == null)
            {
                    throw new NullReferenceException();
            }
            
            List.Enumerator<T> val_27 = val_16.GetEnumerator();
            label_56:
            if(val_19.MoveNext() == false)
            {
                goto label_51;
            }
            
            if(val_18 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if(val_18.CanBePressed() == false)
            {
                goto label_56;
            }
            
            val_46 = this.ignoreButtons;
            if(val_46 == null)
            {
                    throw new NullReferenceException();
            }
            
            bool val_31 = val_46.Contains(item:  val_18.name);
            if((val_31 == true) || ((val_31.SimulateClick(btn:  val_18, camera:  val_38, hiddenClick:  false)) == false))
            {
                goto label_56;
            }
            
            System.DateTime val_33 = System.DateTime.UtcNow;
            val_47 =  + 1;
            val_50 = 451;
            val_38 = 0;
            this.lastAction = val_33;
            goto label_59;
            label_51:
            val_47 =  + 1;
            val_50 = 418;
            val_38 = 0;
            label_59:
            mem2[0] = 418;
            val_19.Dispose();
            if(val_38 != 0)
            {
                    throw val_38;
            }
            
            if(val_47 == 1)
            {
                goto label_65;
            }
            
            if((1152921520000184432 + ((val_49 + 1)) << 2) == 418)
            {
                goto label_62;
            }
            
            val_41 = val_47;
            if((1152921520000184432 + ((val_49 + 1)) << 2) != 451)
            {
                goto label_65;
            }
            
            goto label_64;
            label_62:
            var val_39 = 0;
            val_39 = val_39 ^ (val_47 >> 31);
            var val_34 = val_47 + val_39;
            goto label_65;
            label_18:
            val_47 = val_41 + 1;
            val_34 = 0;
            mem2[0] = 441;
            if(val_40 != null)
            {
                goto label_126;
            }
            
            goto label_127;
            label_64:
            val_34 = 0;
            if(val_40 == null)
            {
                goto label_127;
            }
            
            label_126:
            var val_40 = 0;
            val_40 = val_40 + 1;
            val_40.Dispose();
            label_127:
            if(val_34 != 0)
            {
                    throw val_34;
            }
            
            if(val_47 != 1)
            {
                    if((1152921520000184432 + ((val_41 + 1)) << 2) == 451)
            {
                    return;
            }
            
            }
            
            label_102:
            twelvegigs.Autopilot.AutopilotTools.Log(message:  "No Buttons found!!");
        }
        private bool SimulateClick(twelvegigs.Autopilot.AutopilotButton btn, UnityEngine.Camera camera, bool hiddenClick = False)
        {
            UnityEngine.Camera val_8;
            ExecuteEvents.EventFunction<UnityEngine.EventSystems.ISubmitHandler> val_9;
            var val_10;
            var val_11;
            val_8 = camera;
            val_9 = 0;
            if((twelvegigs.Autopilot.AutopilotTools.RaycastOnButton(button:  btn, camera:  val_8)) != false)
            {
                    if(btn.SkipExecuteClick != true)
            {
                    val_8 = btn.gameObject;
                val_10 = null;
                val_10 = null;
                val_9 = UnityEngine.EventSystems.ExecuteEvents.s_SubmitHandler;
                bool val_6 = UnityEngine.EventSystems.ExecuteEvents.Execute<UnityEngine.EventSystems.ISubmitHandler>(target:  val_8, eventData:  new UnityEngine.EventSystems.BaseEventData(eventSystem:  UnityEngine.EventSystems.EventSystem.current), functor:  val_9);
            }
            
                bool val_7 = hiddenClick;
                val_11 = 1;
                return (bool)val_11;
            }
            
            val_11 = 0;
            return (bool)val_11;
        }
        private void AttachButtonTracker()
        {
            UnityEngine.Component val_4;
            var val_5;
            twelvegigs.Autopilot.AutopilotButton val_15;
            var val_17;
            System.Func<twelvegigs.Autopilot.AutopilotButton, System.Single> val_19;
            System.Collections.Generic.List<twelvegigs.Autopilot.AutopilotButton> val_2 = new System.Collections.Generic.List<twelvegigs.Autopilot.AutopilotButton>();
            List.Enumerator<T> val_3 = UnityEngine.UI.Selectable.allSelectables.GetEnumerator();
            label_11:
            val_15 = public System.Boolean List.Enumerator<UnityEngine.UI.Selectable>::MoveNext();
            if(val_5.MoveNext() == false)
            {
                goto label_4;
            }
            
            if(val_4 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_15 = 0;
            UnityEngine.GameObject val_7 = val_4.gameObject;
            if(val_7 == null)
            {
                    throw new NullReferenceException();
            }
            
            if((val_7.activeInHierarchy == false) || ((val_4.enabled == false) || ((val_4 + 208) == 0)))
            {
                goto label_11;
            }
            
            twelvegigs.Autopilot.AutopilotButton val_10 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<twelvegigs.Autopilot.AutopilotButton>(child:  val_4);
            val_15 = MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<twelvegigs.Autopilot.AutopilotButton>(child:  val_4);
            if(val_2 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_2.Add(item:  val_15);
            goto label_11;
            label_4:
            val_5.Dispose();
            this.<aButtons>k__BackingField.Clear();
            val_17 = null;
            val_17 = null;
            val_19 = AutopilotManager.<>c.<>9__43_0;
            if(val_19 == null)
            {
                    AutopilotManager.<>c val_12 = null;
                val_19 = val_12;
                val_12 = new AutopilotManager.<>c(object:  AutopilotManager.<>c.__il2cppRuntimeField_static_fields, method:  System.Single AutopilotManager.<>c::<AttachButtonTracker>b__43_0(twelvegigs.Autopilot.AutopilotButton aButton));
                AutopilotManager.<>c.<>9__43_0 = val_19;
            }
            
            this.<aButtons>k__BackingField.AddRange(collection:  System.Linq.Enumerable.ToList<twelvegigs.Autopilot.AutopilotButton>(source:  System.Linq.Enumerable.OrderByDescending<twelvegigs.Autopilot.AutopilotButton, System.Single>(source:  val_2, keySelector:  val_12)));
        }
        private twelvegigs.Autopilot.AutopilotGameplay GetAutopilotGameplay()
        {
            var val_2;
            var val_3;
            val_2 = null;
            val_2 = null;
            if(App.game <= 7)
            {
                goto label_6;
            }
            
            val_3 = 1152921520000745248;
            if(App.game == 10)
            {
                    return MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<twelvegigs.Autopilot.AutopilotGameplay>(child:  this);
            }
            
            if(App.game == 18)
            {
                    return MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<twelvegigs.Autopilot.AutopilotGameplay>(child:  this);
            }
            
            if(App.game != 17)
            {
                goto label_11;
            }
            
            val_3 = 1152921520000746272;
            return MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<twelvegigs.Autopilot.AutopilotGameplay>(child:  this);
            label_6:
            if((App.game - 1) < 7)
            {
                    val_3 = mem[39724992 + ((App.game - 1)) << 3];
                val_3 = 39724992 + ((App.game - 1)) << 3;
                return MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<twelvegigs.Autopilot.AutopilotGameplay>(child:  this);
            }
            
            label_11:
            val_3 = 1152921520000747296;
            return MethodExtensionForMonoBehaviourTransform.GetOrAddComponent<twelvegigs.Autopilot.AutopilotGameplay>(child:  this);
        }
        private void OnDestroy()
        {
            SceneDictator val_1 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
            System.Delegate val_3 = System.Delegate.Remove(source:  val_1.OnSceneLoaded, value:  new System.Action<SceneType>(object:  this, method:  System.Void twelvegigs.Autopilot.AutopilotManager::OnSceneChange(SceneType sceneType)));
            if(val_3 != null)
            {
                    if(null != null)
            {
                goto label_5;
            }
            
            }
            
            val_1.OnSceneLoaded = val_3;
            return;
            label_5:
        }
        public AutopilotManager()
        {
            this.pressedBtn = new System.Collections.Hashtable();
            this.defaultAllowPurchases = true;
            this.defaultLevels = 130;
        }
    
    }

}
