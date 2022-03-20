using UnityEngine;

namespace SLC.Minigames
{
    public class MinigamesPopup : MonoBehaviour
    {
        // Fields
        private SLC.Minigames.MinigameButton MinigameButtonPrefab;
        private UnityEngine.Transform buttonsParent;
        public bool someMinigameLoading;
        private twelvegigs.storage.JsonDictionary knobsData;
        private System.Collections.Generic.List<SLC.Minigames.MinigameButton> myButtons;
        
        // Methods
        private void Awake()
        {
            this.Setup();
        }
        public void ToggleLoading(bool isLoading)
        {
            bool val_5 = isLoading;
            List.Enumerator<T> val_1 = this.myButtons.GetEnumerator();
            val_5 = val_5 ^ 1;
            label_4:
            if(0.MoveNext() == false)
            {
                goto label_2;
            }
            
            this.someMinigameLoading = val_5;
            if(0 == 0)
            {
                    throw new NullReferenceException();
            }
            
            0.ToggleInteractable(interactable:  val_5);
            goto label_4;
            label_2:
            0.Dispose();
        }
        public void Setup()
        {
            var val_3;
            var val_4;
            UnityEngine.Transform val_17;
            System.Collections.Generic.List<SLC.Minigames.MinigameButton> val_18;
            var val_19;
            AppConfigs val_1 = App.Configuration;
            List.Enumerator<T> val_2 = val_1.minigamesConfig.minigames.GetEnumerator();
            label_28:
            val_17 = public System.Boolean List.Enumerator<MiniGame>::MoveNext();
            if(val_4.MoveNext() == false)
            {
                goto label_6;
            }
            
            if(val_3 == 0)
            {
                    throw new NullReferenceException();
            }
            
            if((val_3 + 68) == 0)
            {
                goto label_28;
            }
            
            val_18 = mem[val_3 + 16];
            val_18 = val_3 + 16;
            if(val_18 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_17 = 0;
            string val_6 = val_18.ToLower();
            if(val_6 == null)
            {
                    throw new NullReferenceException();
            }
            
            if((val_6.Contains(value:  "framework")) == true)
            {
                goto label_28;
            }
            
            val_17 = 0;
            val_19 = val_3.UnlockLevel;
            Player val_9 = App.Player;
            if(val_9 == null)
            {
                    throw new NullReferenceException();
            }
            
            if(val_19 > val_9)
            {
                    val_19 = mem[val_3 + 64];
                val_19 = val_3 + 64;
                Bootstrapper val_10 = MonoSingleton<Bootstrapper>.Instance;
                if(val_10 == null)
            {
                    throw new NullReferenceException();
            }
            
                if(val_19 != val_10.DeeplinkedWhichMinigame)
            {
                    if((UnityEngine.PlayerPrefs.HasKey(key:  val_3 + 16)) == false)
            {
                goto label_28;
            }
            
            }
            
            }
            
            val_17 = 0;
            ResourceLoader val_14 = MonoSingletonSelfGenerating<ResourceLoader>.Instance;
            if(val_14 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_17 = this.buttonsParent;
            SLC.Minigames.MinigameButton val_16 = UnityEngine.Object.Instantiate<SLC.Minigames.MinigameButton>(original:  this.MinigameButtonPrefab, parent:  val_17);
            if(val_16 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_17 = val_3 + 16;
            val_16.Setup(gameName:  val_17, minigameIndex:  val_3 + 64, reqLevel:  val_3.UnlockLevel, gameIcon:  val_14.GetSpriteFromBundle(bundleName:  "minigames_framework", spriteName:  val_3 + 40), displayGameName:  val_3 + 16 + 8, parentPopup:  this);
            val_18 = this.myButtons;
            if(val_18 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_18.Add(item:  val_16);
            goto label_28;
            label_6:
            val_4.Dispose();
        }
        private int GetRequiredLevelFromKnobs(string currentMinigameName)
        {
            string val_4 = currentMinigameName;
            if((this.knobsData.Contains(key:  val_4 = currentMinigameName)) == false)
            {
                    return 0;
            }
            
            twelvegigs.storage.JsonDictionary val_2 = this.knobsData.getJsonDictionary(key:  val_4);
            val_4 = val_2;
            if((val_2.Contains(key:  "req_lvl")) == false)
            {
                    return 0;
            }
            
            return val_4.getInt(key:  "req_lvl", defaultValue:  0);
        }
        public MinigamesPopup()
        {
            this.myButtons = new System.Collections.Generic.List<SLC.Minigames.MinigameButton>();
        }
    
    }

}
