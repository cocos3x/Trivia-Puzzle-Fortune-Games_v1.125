using UnityEngine;

namespace twelvegigs.Autopilot
{
    public class AutopilotRequester : MonoBehaviour
    {
        // Fields
        private twelvegigs.net.JsonApiRequester apiRequester;
        private string screenshotServerUrl;
        private string eventServerUrl;
        private int cachedEvents;
        private bool screenshotRunning;
        private System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> events;
        private System.Collections.Generic.List<System.Collections.Generic.Dictionary<string, object>> screenshots;
        private System.DateTime startSession;
        private bool initialize;
        
        // Methods
        public void Start()
        {
            System.DateTime val_1 = System.DateTime.UtcNow;
            this.startSession = val_1;
            this.events = new System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>>();
            this.screenshots = new System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>>();
            this.apiRequester = new twelvegigs.net.JsonApiRequester(ServerURL:  this.eventServerUrl, dequeueHandler:  new System.Action(object:  this, method:  System.Void twelvegigs.Autopilot.AutopilotRequester::<Start>b__9_0()), logStuff:  false, adminServerURL:  0, throwExceptionsOnRequestFailures:  false);
            this.initialize = true;
        }
        public void SendEvent(System.Collections.Generic.Dictionary<string, object> eventData, bool sendImmediately = False)
        {
            if(this.initialize == false)
            {
                    return;
            }
            
            eventData.Add(key:  "start_time", value:  this.startSession.ToString());
            this.events.Add(item:  eventData);
            if(sendImmediately != true)
            {
                    if(this.events <= this.cachedEvents)
            {
                    return;
            }
            
            }
            
            this.SendEvents();
        }
        public void TakeScreenshot(long actionTimestamp, string uniqueTag, string game)
        {
            if(this.initialize != false)
            {
                    UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.Screenshot(actionTimestamp:  actionTimestamp, uniqueTag:  uniqueTag, game:  game));
                return;
            }
            
            MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance.PauseAutomation(pause:  false);
        }
        private System.Collections.IEnumerator Screenshot(long actionTimestamp, string uniqueTag, string game)
        {
            .<>1__state = 0;
            .<>4__this = this;
            .actionTimestamp = actionTimestamp;
            .uniqueTag = uniqueTag;
            .game = game;
            return (System.Collections.IEnumerator)new AutopilotRequester.<Screenshot>d__12();
        }
        private System.Collections.IEnumerator SendScreenshots()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new AutopilotRequester.<SendScreenshots>d__13();
        }
        private void AddScreenShoot(long actionTimestamp, string uniqueTag, string game, byte[] file)
        {
            if(this.initialize == false)
            {
                    return;
            }
            
            System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_1.Add(key:  "actionTimestamp", value:  actionTimestamp);
            val_1.Add(key:  "uniqueTag", value:  uniqueTag);
            val_1.Add(key:  "file", value:  file);
            val_1.Add(key:  "game", value:  game);
            this.screenshots.Add(item:  val_1);
            if(this.screenshotRunning == true)
            {
                    return;
            }
            
            UnityEngine.Coroutine val_3 = this.StartCoroutine(routine:  this.SendScreenshots());
        }
        private void SendEvents()
        {
            System.Collections.Generic.Dictionary<System.String, System.Object> val_2 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            val_2.Add(key:  "events", value:  new System.Collections.Generic.List<System.Collections.Generic.Dictionary<System.String, System.Object>>(collection:  this.events));
            val_2.Add(key:  "valid", value:  "12g");
            this.apiRequester.DoPost(path:  "events", postBody:  val_2, onCompleteFunction:  0, timeout:  20, destroy:  false, immediate:  false, serverType:  0);
            this.events.Clear();
        }
        public AutopilotRequester()
        {
            this.screenshotServerUrl = "https://automation-stage.12gigs.com/api/automated_tests/screenshots";
            this.cachedEvents = 10;
            this.eventServerUrl = "https://automation-stage.12gigs.com/api/automated_tests/";
        }
        private void <Start>b__9_0()
        {
            if(this.apiRequester != null)
            {
                    this.apiRequester.Dequeue();
                return;
            }
            
            throw new NullReferenceException();
        }
    
    }

}
