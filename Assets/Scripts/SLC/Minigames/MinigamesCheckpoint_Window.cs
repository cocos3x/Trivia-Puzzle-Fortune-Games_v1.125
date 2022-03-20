using UnityEngine;

namespace SLC.Minigames
{
    public class MinigamesCheckpoint_Window : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Text descText;
        private UnityEngine.UI.Button continueButton;
        private UnityEngine.UI.Slider nextRankSlider;
        
        // Methods
        private void Start()
        {
            this.continueButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void SLC.Minigames.MinigamesCheckpoint_Window::OnClick_ContinueButton()));
        }
        private void OnClick_ContinueButton()
        {
            MonoSingleton<SLC.Minigames.MinigameManager>.Instance.HandleCheckpointRankUpContinue();
            this.gameObject.SetActive(value:  false);
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        private void OnEnable()
        {
            int val_17;
            SLC.Minigames.MinigameManager val_1 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance;
            var val_17 = public static SLC.Minigames.MinigameManager MonoSingleton<SLC.Minigames.MinigameManager>::get_Instance();
            if(W26 == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            val_17 = val_17 + ((W26 - 1) << 2);
            float val_18 = (float)(public static SLC.Minigames.MinigameManager MonoSingleton<SLC.Minigames.MinigameManager>::get_Instance() + ((W26 - 1)) << 2) + 32;
            val_18 = (float)val_1.currentPlayerData.checkpointLevel / val_18;
            SLC.Minigames.MinigameLevelRank val_8 = (MonoSingleton<SLC.Minigames.MinigameManager>.Instance.GetCurrentRank) - val_1.currentPlayerData.GetCheckpointsCompletedInRank();
            object[] val_10 = new object[4];
            val_10[0] = val_8.ToString();
            UnityEngine.Color val_12 = MonoSingleton<SLC.Minigames.MinigameManager>.Instance.GetNextRank.TitleColor;
            UnityEngine.Color32 val_13 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color() {r = val_12.r, g = val_12.g, b = val_12.b, a = val_12.a});
            val_13.r = val_13.r & 4294967295;
            val_17 = val_10.Length;
            val_10[1] = System.String.Format(format:  "<color=#{0}>", arg0:  SLC.Minigames.MinigamesUtils.ColorToHex(color:  new UnityEngine.Color32() {r = val_13.r, g = val_13.r, b = val_13.r, a = val_13.r}));
            if(val_5.rankName != null)
            {
                    val_17 = val_10.Length;
            }
            
            val_10[2] = val_5.rankName;
            val_17 = val_10.Length;
            val_10[3] = "</color>";
            string val_16 = System.String.Format(format:  (val_8 > 1) ? "Only {0} checkpoints until {1}{2}{3}" : "Only {0} checkpoint until {1}{2}{3}", args:  val_10);
        }
        public MinigamesCheckpoint_Window()
        {
        
        }
    
    }

}
