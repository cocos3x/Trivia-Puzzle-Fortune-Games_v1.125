using UnityEngine;

namespace WordForest
{
    public class WFOManagerGameplayUI : MonoSingleton<WordForest.WFOManagerGameplayUI>
    {
        // Fields
        private WordForest.WFOGameAcornStatView acornStatView;
        private CoinCurrencyStatView coinStatView;
        private WordForest.WFOShieldStatView shieldStatView;
        private EventButtonPanel eventButtonPanelTab;
        private ExtraWordGameplayIcon extraWordGameplayIcon;
        private WordForest.WFOAcornGameBalanceParticle acornParticleSystem;
        private UnityEngine.Transform acornParticlesContainer;
        private WordRegion wordRegion;
        
        // Properties
        public WordForest.WFOGameAcornStatView AcornStatView { get; }
        public CoinCurrencyStatView CoinStatView { get; }
        public WordForest.WFOShieldStatView ShieldStatView { get; }
        public EventButtonPanel EventButtonPanelTab { get; }
        
        // Methods
        public WordForest.WFOGameAcornStatView get_AcornStatView()
        {
            return (WordForest.WFOGameAcornStatView)this.acornStatView;
        }
        public CoinCurrencyStatView get_CoinStatView()
        {
            return (CoinCurrencyStatView)this.coinStatView;
        }
        public WordForest.WFOShieldStatView get_ShieldStatView()
        {
            return (WordForest.WFOShieldStatView)this.shieldStatView;
        }
        public EventButtonPanel get_EventButtonPanelTab()
        {
            return (EventButtonPanel)this.eventButtonPanelTab;
        }
        private void Start()
        {
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnPlayerMoveUpdated");
            this.wordRegion = WordRegion.instance;
            DeviceKeypressManager.AddBackAction(backAction:  new System.Action(object:  this, method:  System.Void WordForest.WFOManagerGameplayUI::OnAndroidBackButtonPressed()));
        }
        private void OnDestroy()
        {
            NotificationCenter.DefaultCenter.RemoveObserver(observer:  this, name:  "OnPlayerMoveUpdated");
        }
        private void OnDisable()
        {
            DeviceKeypressManager.RemoveBackAction(backAction:  new System.Action(object:  this, method:  System.Void WordForest.WFOManagerGameplayUI::OnAndroidBackButtonPressed()));
        }
        private void OnPlayerMoveUpdated()
        {
            WordForest.WFOManagerGameplay val_1 = MonoSingleton<WordForest.WFOManagerGameplay>.Instance;
            if(val_1.acornAwardedAnimQueue < 1)
            {
                    return;
            }
            
            WordForest.WFOManagerGameplay val_2 = MonoSingleton<WordForest.WFOManagerGameplay>.Instance;
            Dictionary.Enumerator<TKey, TValue> val_4 = val_2.acornAwardedAnimQueue.Dequeue().GetEnumerator();
            label_12:
            if(0.MoveNext() == false)
            {
                goto label_11;
            }
            
            UnityEngine.Coroutine val_7 = this.StartCoroutine(routine:  this.PlayAcornParticles(wordIndex:  0, slotIndices:  0));
            goto label_12;
            label_11:
            0.Dispose();
        }
        private void OnAndroidBackButtonPressed()
        {
            if((MonoSingleton<WGDailyChallengeManager>.Instance.PlayingChallenge) != false)
            {
                    GameBehavior val_3 = App.getBehavior;
            }
            else
            {
                    GameBehavior val_4 = App.getBehavior;
            }
        
        }
        public System.Collections.IEnumerator PlayAcornParticles(int wordIndex, System.Collections.Generic.List<int> slotIndices)
        {
            .<>1__state = 0;
            .wordIndex = wordIndex;
            .<>4__this = this;
            .slotIndices = slotIndices;
            return (System.Collections.IEnumerator)new WFOManagerGameplayUI.<PlayAcornParticles>d__21();
        }
        public WFOManagerGameplayUI()
        {
        
        }
    
    }

}
