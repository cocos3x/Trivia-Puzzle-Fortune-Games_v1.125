using UnityEngine;

namespace BlockPuzzleMagic
{
    public class BBLGotoSceneButton : ButtonGotoScene
    {
        // Fields
        private UnityEngine.UI.Text buttonLabel;
        
        // Methods
        protected override void Start()
        {
            this.Start();
            if(true != 2)
            {
                    return;
            }
            
            if((MonoSingleton<BlockPuzzleMagic.GameProgressManager>.Instance.HasSavedGame(gameMode:  2)) == true)
            {
                goto label_5;
            }
            
            GameBehavior val_3 = App.getBehavior;
            if((val_3.<metaGameBehavior>k__BackingField) < 2)
            {
                goto label_10;
            }
            
            label_5:
            this = this.buttonLabel;
            GameBehavior val_4 = App.getBehavior;
            string val_5 = System.String.Format(format:  "Level {0}", arg0:  val_4.<metaGameBehavior>k__BackingField);
            return;
            label_10:
            string val_6 = Localization.Localize(key:  "play_upper", defaultValue:  "PLAY", useSingularKey:  false);
            goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
        }
        public override void OnButtonClick()
        {
            if(true == 2)
            {
                    if(this.CanProceedToGame() == false)
            {
                goto label_2;
            }
            
            }
            
            this.OnButtonClick();
            return;
            label_2:
            GameBehavior val_2 = App.getBehavior;
            goto mem[(1152921504946249728 + (public BBLOutOfLivesPopup MetaGameBehavior::ShowUGUIMonolith<BBLOutOfLivesPopup>(bool showNext).__il2cppRuntimeField_48) << 4) + 312];
        }
        private bool CanProceedToGame()
        {
            bool val_2 = BestBlocksPlayer.Instance.RefreshPlayerLives();
            BestBlocksPlayer val_3 = BestBlocksPlayer.Instance;
            return (bool)(val_3.livesBalance > 0) ? 1 : 0;
        }
        public BBLGotoSceneButton()
        {
        
        }
    
    }

}
