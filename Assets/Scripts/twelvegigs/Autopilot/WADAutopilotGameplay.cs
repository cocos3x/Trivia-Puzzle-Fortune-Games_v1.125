using UnityEngine;

namespace twelvegigs.Autopilot
{
    public class WADAutopilotGameplay : AutopilotGameplay
    {
        // Fields
        private Pan pan;
        private UnityEngine.Camera panCamera;
        private bool onGameScene;
        
        // Methods
        public void Start()
        {
            mem[1152921520011735672] = 130;
        }
        public override bool IsExecutable()
        {
            if(this.onGameScene == false)
            {
                    return false;
            }
            
            if(App.Player <= null)
            {
                    return this.IsPanEnabled();
            }
            
            if(UnityEngine.Random.value >= 0)
            {
                    return this.IsPanEnabled();
            }
            
            return false;
        }
        public override void RunAction()
        {
            if(WordRegion.instance == 0)
            {
                    return;
            }
            
            WordRegion val_3 = WordRegion.instance;
            goto typeof(WordRegion).__il2cppRuntimeField_260;
        }
        public override void OnSceneLoaded(SceneType sceneType)
        {
            this.onGameScene = (sceneType == 2) ? 1 : 0;
            if(sceneType != 2)
            {
                    return;
            }
            
            this.pan = Pan.tappingAllowed;
            this.panCamera = twelvegigs.Autopilot.AutopilotTools.GetCamera(go:  Pan.tappingAllowed.transform);
            if((UnityEngine.Object.op_Implicit(exists:  MainController.instance)) == false)
            {
                    return;
            }
            
            MainController val_6 = MainController.instance;
            val_6.onLevelComplete.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void twelvegigs.Autopilot.WADAutopilotGameplay::HandleLevelComplete()));
        }
        public override void OnSceneUnloaded(SceneType sceneType)
        {
            this.pan = 0;
            this.panCamera = 0;
            if(this.onGameScene == false)
            {
                    return;
            }
            
            MainController val_1 = MainController.instance;
            val_1.onLevelComplete.RemoveListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void twelvegigs.Autopilot.WADAutopilotGameplay::HandleLevelComplete()));
        }
        public void HandleLevelComplete()
        {
            var val_16;
            var val_17;
            string val_18;
            MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance.ClearIgnore();
            if(App.Player > null)
            {
                    return;
            }
            
            if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false)
            {
                    return;
            }
            
            if(PlayingLevel.CurrentGameplayMode == 4)
            {
                    CategoryPacksManager val_6 = MonoSingleton<CategoryPacksManager>.Instance;
                val_16 = 0;
                var val_7 = ((val_6.<IsChapterCompleted>k__BackingField) == true) ? 1 : 0;
            }
            else
            {
                    val_17 = ChapterBookLogic.ShowChapterComplete(playerLevel:  App.Player);
                val_16 = ChapterBookLogic.ShowBookComplete(playerLevel:  App.Player);
            }
            
            System.Collections.Generic.List<System.String> val_12 = new System.Collections.Generic.List<System.String>();
            if(val_16 != false)
            {
                    val_12.Add(item:  "WAD_Button_Green_Continue");
                val_12.Add(item:  "Button_BookSelected_TapToContinue");
                MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance.AddIgnore(button:  "ChapterBookProgressBarFrame", clearPrevious:  true);
            }
            else
            {
                    if(val_17 != false)
            {
                    val_18 = "ChapterClear_collect_button";
            }
            else
            {
                    val_18 = "click_to_continue";
            }
            
                val_12.Add(item:  val_18);
            }
            
            val_12.Add(item:  "WAD_Button_Green_Continue");
            MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance.AddIgnore(button:  "ChapterBookProgressBarFrame", clearPrevious:  false);
            MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance.AddInstruction(newInstructions:  val_12, clearPrevious:  true);
        }
        private bool IsPanEnabled()
        {
            if(this.pan == 0)
            {
                    return false;
            }
            
            UnityEngine.Vector3 val_3 = this.pan.centerPoint.position;
            return twelvegigs.Autopilot.AutopilotTools.RaycastOnPosition(target:  this.pan.gameObject, worldPos:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z}, camera:  this.panCamera);
        }
        public WADAutopilotGameplay()
        {
        
        }
    
    }

}
