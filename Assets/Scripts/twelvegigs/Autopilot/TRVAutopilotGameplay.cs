using UnityEngine;

namespace twelvegigs.Autopilot
{
    public class TRVAutopilotGameplay : AutopilotGameplay
    {
        // Fields
        private SceneType sceneType;
        private TRVCategorySelection categorySelection;
        
        // Methods
        public override bool IsExecutable()
        {
            System.Collections.Generic.List<System.String> val_35 = this;
            if(App.Player > null)
            {
                    if(UnityEngine.Random.value < 0)
            {
                    return false;
            }
            
            }
            
            if(this.sceneType == 2)
            {
                goto label_6;
            }
            
            if(this.sceneType != 1)
            {
                    return false;
            }
            
            System.Collections.Generic.List<System.String> val_3 = null;
            val_35 = val_3;
            val_3 = new System.Collections.Generic.List<System.String>();
            label_56:
            label_38:
            val_3.Add(item:  "TRV_Button_Green");
            MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance.AddInstruction(newInstructions:  val_3, clearPrevious:  true);
            return false;
            label_6:
            WGWindowManager val_5 = MonoSingleton<WGWindowManager>.Instance;
            if(val_5 == 0)
            {
                goto label_54;
            }
            
            WGWindowManager val_7 = MonoSingleton<WGWindowManager>.Instance;
            if(val_5 == 0)
            {
                goto label_54;
            }
            
            TRVCategorySelection val_10 = MonoSingleton<WGWindowManager>.Instance.GetComponent<TRVCategorySelection>();
            this.categorySelection = val_10;
            if(val_10 == 0)
            {
                goto label_30;
            }
            
            UnityEngine.Debug.Log(message:  "TRVAutopilotGameplay TRVCategorySelection");
            T val_35 = this.categorySelection.GetComponentsInChildren<TRVCategoryButton>()[UnityEngine.Random.Range(min:  0, max:  val_12.Length)];
            System.Collections.Generic.List<System.String> val_14 = new System.Collections.Generic.List<System.String>();
            UnityEngine.Debug.LogError(message:  "TRVAutopilotGameplay: "("TRVAutopilotGameplay: ") + val_35.name);
            string val_17 = val_35.name;
            goto label_38;
            label_30:
            if((MonoSingleton<WGWindowManager>.Instance.GetComponent<TRVQuestionComplete>()) == 0)
            {
                goto label_45;
            }
            
            System.Collections.Generic.List<System.String> val_21 = new System.Collections.Generic.List<System.String>();
            goto label_56;
            label_45:
            if((MonoSingleton<WGWindowManager>.Instance.GetComponent<TRVLevelComplete>()) == 0)
            {
                goto label_54;
            }
            
            System.Collections.Generic.List<System.String> val_25 = new System.Collections.Generic.List<System.String>();
            goto label_56;
            label_54:
            val_35 = MonoSingleton<TRVMainController>.Instance;
            if(val_35 == 0)
            {
                    return false;
            }
            
            TRVMainController val_28 = MonoSingleton<TRVMainController>.Instance;
            if(val_28.currentGame == null)
            {
                    return false;
            }
            
            if(val_28.currentGame.quizCompleted != false)
            {
                    return false;
            }
            
            if(val_28.currentGame.currentGameplayState == null)
            {
                    return false;
            }
            
            if(val_30.Length < 1)
            {
                    return false;
            }
            
            var val_37 = 0;
            do
            {
                if((System.String.op_Equality(a:  val_30[0x0][0] + 32, b:  val_28.currentGame.currentQuestionData.<answer>k__BackingField)) != false)
            {
                    System.Collections.Generic.List<System.String> val_32 = new System.Collections.Generic.List<System.String>();
                val_32.Add(item:  MonoSingleton<TRVGameplayUI>.Instance.GetComponentsInChildren<TRVQuestionButton>()[val_37].name);
                MonoSingleton<twelvegigs.Autopilot.AutopilotManager>.Instance.AddInstruction(newInstructions:  val_32, clearPrevious:  true);
            }
            
                val_37 = val_37 + 1;
            }
            while(val_37 < val_30.Length);
            
            return false;
        }
        public override void RunAction()
        {
        
        }
        public override void OnSceneLoaded(SceneType sceneType)
        {
            this.sceneType = sceneType;
        }
        public override void OnSceneUnloaded(SceneType sceneType)
        {
        
        }
        public TRVAutopilotGameplay()
        {
        
        }
    
    }

}
