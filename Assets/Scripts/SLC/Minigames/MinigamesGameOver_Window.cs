using UnityEngine;

namespace SLC.Minigames
{
    public class MinigamesGameOver_Window : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Slider nextRankSlider;
        private UnityEngine.UI.Text checkpointsText;
        private UnityEngine.UI.Button collectRewardButton;
        private UnityEngine.UI.Button homeButton;
        private UnityEngine.UI.Button restartButton;
        private UnityEngine.UI.Button storeButton;
        private UnityEngine.UI.Text rewardButtonText;
        private GridCoinCollectAnimationInstantiator coinsAnimControl;
        private SLC.Minigames.MinigameRankSpriteDisplay mainRankDisplay;
        private UnityEngine.GameObject mainRankDisplayContainer;
        private UnityEngine.UI.Text rankText;
        
        // Methods
        private void Start()
        {
            this.collectRewardButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.MinigamesGameOver_Window::OnClick_RewardButton()));
            this.restartButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.MinigamesGameOver_Window::OnClick_RestartButton()));
            this.homeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.MinigamesGameOver_Window::OnClick_HomeButton()));
            this.storeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.MinigamesGameOver_Window::OnClick_StoreButton()));
        }
        private void OnClick_RewardButton()
        {
            SLC.Minigames.MinigameManager val_1 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            SLC.Minigames.MinigameManager val_2 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            decimal val_3 = System.Decimal.op_Implicit(value:  val_1.currentPlayerData.checkpointsReached);
            decimal val_4 = System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = val_2.checkpointReward, hi = val_2.checkpointReward, lo = 41967616}, d2:  new System.Decimal() {flags = val_3.flags, hi = val_3.hi, lo = val_3.lo, mid = val_3.mid});
            App.Player.AddCredits(amount:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid}, source:  System.String.Format(format:  "MG {0} REWARD", arg0:  MonoSingleton<SLC.Minigames.MinigameManager>.Instance.CurrentMinigameName), subSource:  0, externalParams:  0, doTrack:  true);
            Player val_9 = App.Player;
            decimal val_10 = System.Decimal.op_Subtraction(d1:  new System.Decimal() {flags = val_9._credits, hi = val_9._credits, lo = val_4.flags, mid = val_4.hi}, d2:  new System.Decimal() {flags = val_4.flags, hi = val_4.hi, lo = val_4.lo, mid = val_4.mid});
            Player val_11 = App.Player;
            this.coinsAnimControl.Play(fromValue:  new System.Decimal() {flags = val_10.flags, hi = val_10.hi, lo = val_10.lo, mid = val_10.mid}, toValue:  new System.Decimal() {flags = val_11._credits, hi = val_11._credits}, textTickTime:  -1f, delayBeforeComplete:  -1f);
            SLC.Minigames.MinigameManager val_12 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            val_12.currentPlayerData.checkpointsReached = 0;
            MonoSingleton<SLC.Minigames.MinigameManager>.Instance.SaveCurrentPlayerData();
            this.collectRewardButton.interactable = false;
            this.restartButton.interactable = true;
            this.homeButton.interactable = true;
        }
        private void OnClick_RestartButton()
        {
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
            SLC.Minigames.MinigamesUIController val_2 = MonoSingleton<SLC.Minigames.MinigamesUIController>.Instance;
            MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleGameRestart();
        }
        private void OnClick_HomeButton()
        {
            MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleHomeClicked(redirectToGameplay:  false);
        }
        private void OnClick_StoreButton()
        {
            var val_5;
            var val_6;
            System.Action val_8;
            val_5 = null;
            val_5 = null;
            PurchaseProxy.currentPurchasePoint = 22;
            val_6 = null;
            val_6 = null;
            val_8 = MinigamesGameOver_Window.<>c.<>9__15_0;
            if(val_8 == null)
            {
                    System.Action val_3 = null;
                val_8 = val_3;
                val_3 = new System.Action(object:  MinigamesGameOver_Window.<>c.__il2cppRuntimeField_static_fields, method:  System.Void MinigamesGameOver_Window.<>c::<OnClick_StoreButton>b__15_0());
                MinigamesGameOver_Window.<>c.<>9__15_0 = val_8;
            }
            
            MonoSingleton<SLC.Minigames.MinigamesWindowManager>.Instance.ShowUGUIMonolith<WGStoreProxy>(showNext:  true).Init(outOfCredits:  false, onCloseAction:  val_3);
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        private void OnEnable()
        {
            object val_25;
            var val_26;
            SLC.Minigames.MinigameManager val_1 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            var val_25 = public static SLC.Minigames.MinigameManager MonoSingleton<SLC.Minigames.MinigameManager>::get_Instance();
            SLC.Minigames.MinigameLevelRank val_5 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance.GetNextRank;
            if(W25 == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_25 = val_25 + ((W25 - 1) << 2);
            float val_26 = (float)(public static SLC.Minigames.MinigameManager MonoSingleton<SLC.Minigames.MinigameManager>::get_Instance() + ((W25 - 1)) << 2) + 32;
            val_26 = (float)val_1.currentPlayerData.checkpointLevel / val_26;
            this.mainRankDisplay.DisplaySprite(rank:  MonoSingleton<SLC.Minigames.MinigameManager>.Instance.GetCurrentRank);
            string val_27 = 0.ToString();
            val_27 = System.String.op_Inequality(a:  val_3.rankName, b:  val_27);
            this.mainRankDisplayContainer.SetActive(value:  val_27);
            if((val_3.rankName.Equals(value:  0.ToString())) != false)
            {
                    val_25 = "";
            }
            else
            {
                    val_25 = val_3.rankName.ToUpper();
            }
            
            string val_14 = System.String.Format(format:  "{0} {1}", arg0:  val_25, arg1:  SLC.Minigames.MinigamesUtils.RomanNumeralize(num:  val_1.currentPlayerData.GetCheckpointsCompletedInRank()));
            string val_16 = System.String.Format(format:  "{0}", arg0:  val_1.currentPlayerData.checkpointsReached.ToString());
            SLC.Minigames.MinigameManager val_17 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            decimal val_18 = System.Decimal.op_Implicit(value:  val_1.currentPlayerData.checkpointsReached);
            decimal val_19 = System.Decimal.op_Multiply(d1:  new System.Decimal() {flags = val_17.checkpointReward, hi = val_17.checkpointReward, lo = this.checkpointsText, mid = this.checkpointsText}, d2:  new System.Decimal() {flags = val_18.flags, hi = val_18.hi, lo = val_18.lo, mid = val_18.mid});
            GameEcon val_20 = App.getGameEcon;
            string val_22 = System.String.Format(format:  "{0}", arg0:  val_19.flags.ToString(format:  val_20.numberFormatInt));
            if((System.Decimal.op_GreaterThan(d1:  new System.Decimal() {flags = val_19.flags, hi = val_19.hi, lo = val_19.lo, mid = val_19.mid}, d2:  new System.Decimal() {flags = System.Decimal.Zero, hi = System.Decimal.Zero, lo = System.Decimal.Powers10.__il2cppRuntimeField_10>>0&0xFFFFFFFF, mid = System.Decimal.Powers10.__il2cppRuntimeField_10>>32&0x0})) != false)
            {
                    this.collectRewardButton.interactable = true;
                this.restartButton.interactable = false;
                val_26 = 0;
            }
            else
            {
                    this.collectRewardButton.interactable = false;
                this.restartButton.interactable = true;
                val_26 = 1;
            }
            
            this.homeButton.interactable = true;
            MonoSingleton<SLC.Minigames.MinigameManager>.Instance.TrackMinigameSessionEnd();
        }
        public MinigamesGameOver_Window()
        {
        
        }
    
    }

}
