using UnityEngine;

namespace BlockPuzzleMagic
{
    public class BBLPowerupInfoPopup : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Button closeButton;
        private UnityEngine.UI.Text titleText;
        private UnityEngine.UI.Text infoText;
        private UnityEngine.GameObject[] pages;
        private System.Collections.Generic.Dictionary<BlockPuzzleMagic.PowerUpType, string> titleDict;
        private System.Collections.Generic.Dictionary<BlockPuzzleMagic.PowerUpType, string> infoDict;
        
        // Methods
        private void Awake()
        {
            this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void BlockPuzzleMagic.BBLPowerupInfoPopup::OnCloseButtonClicked()));
        }
        public void Initialize(BlockPuzzleMagic.PowerUpType powerupType)
        {
            var val_5 = 0;
            label_5:
            if(val_5 >= this.pages.Length)
            {
                goto label_2;
            }
            
            this.pages[val_5].SetActive(value:  (powerupType == val_5) ? 1 : 0);
            val_5 = val_5 + 1;
            if(this.pages != null)
            {
                goto label_5;
            }
            
            throw new NullReferenceException();
            label_2:
            string val_2 = this.titleDict.Item[powerupType];
            string val_3 = this.infoDict.Item[powerupType];
            goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
        }
        private void OnCloseButtonClicked()
        {
            SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
        }
        public BBLPowerupInfoPopup()
        {
            System.Collections.Generic.Dictionary<BlockPuzzleMagic.PowerUpType, System.String> val_1 = new System.Collections.Generic.Dictionary<BlockPuzzleMagic.PowerUpType, System.String>();
            val_1.Add(key:  0, value:  "TRASH CAN");
            val_1.Add(key:  1, value:  "BOMB BLOCK");
            val_1.Add(key:  2, value:  "RAINBOW BLOCK");
            this.titleDict = val_1;
            System.Collections.Generic.Dictionary<BlockPuzzleMagic.PowerUpType, System.String> val_2 = new System.Collections.Generic.Dictionary<BlockPuzzleMagic.PowerUpType, System.String>();
            val_2.Add(key:  0, value:  "Use Trash to remove pieces you don\'t want to use. Drag pieces to the trash, or drag trash to a piece.");
            val_2.Add(key:  1, value:  "Drag and place a bomb block to clear all spaces around it.");
            val_2.Add(key:  2, value:  "Drag and place a Rainbow Block when you need a 1x1 block! It counts as all colors.");
            this.infoDict = val_2;
        }
    
    }

}
