using UnityEngine;

namespace BlockPuzzleMagic
{
    public class BBLTrashShapeButton : BBLPowerupShapeButton
    {
        // Fields
        private UnityEngine.RectTransform hitboxDragIn;
        private shake trashIconShake;
        private UnityEngine.GameObject trashIcon;
        private UnityEngine.GameObject crossIcon;
        private UnityEngine.GameObject cost;
        private bool onCLickMode;
        
        // Properties
        public UnityEngine.RectTransform HitboxDragIn { get; }
        
        // Methods
        public UnityEngine.RectTransform get_HitboxDragIn()
        {
            return (UnityEngine.RectTransform)this.hitboxDragIn;
        }
        private void Awake()
        {
            NotificationCenter.DefaultCenter.AddObserver(observer:  this, name:  "OnTrashButtonModeExit");
        }
        public void Shake()
        {
            if(this.trashIconShake != null)
            {
                    this.trashIconShake.ShakeNow();
                return;
            }
            
            throw new NullReferenceException();
        }
        protected override void OnButtonClicked()
        {
            if(true == 0)
            {
                    return;
            }
            
            if(this.onCLickMode != true)
            {
                    if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance.CanUsePowerup(powerupType:  0, showStoreIfOOC:  true, oocDelay:  0f)) != false)
            {
                    MonoSingleton<BlockPuzzleMagic.BlockShapeSpawner>.Instance.Interactable = false;
                UnityEngine.Transform[] val_4 = new UnityEngine.Transform[2];
                val_4[0] = MonoSingleton<BlockPuzzleMagic.BlockShapeSpawner>.Instance.gameObject.transform;
                val_4[1] = this.gameObject.transform;
                BlockPuzzleMagic.BBLGameplayUIHelper.ShowGameplayOverlay(contentToShow:  val_4);
                MonoSingleton<BlockPuzzleMagic.BlockShapeSpawner>.Instance.OnTrashClicked();
                MonoSingleton<BlockPuzzleMagic.BBLGameplayUIController>.Instance.OnPowerupsBuy();
                this.crossIcon.SetActive(value:  true);
                this.trashIcon.SetActive(value:  false);
                this.cost.SetActive(value:  false);
                this.onCLickMode = true;
                return;
            }
            
            }
            
            this.FinishedTrashMode();
            MonoSingleton<BlockPuzzleMagic.BlockShapeSpawner>.Instance.CheckIfAvailableShapesArePlaceable();
        }
        private void FinishedTrashMode()
        {
            MonoSingleton<BlockPuzzleMagic.BlockShapeSpawner>.Instance.Interactable = true;
            BlockPuzzleMagic.BBLGameplayUIHelper.CloseGameplayOverlay(immediate:  false, onOverlayClosed:  0);
            MonoSingleton<BlockPuzzleMagic.BlockShapeSpawner>.Instance.OnTrashUnClicked();
            this.crossIcon.SetActive(value:  false);
            this.trashIcon.SetActive(value:  true);
            this.cost.SetActive(value:  true);
            this.onCLickMode = false;
        }
        private void OnTrashButtonModeExit()
        {
            this.FinishedTrashMode();
        }
        public BBLTrashShapeButton()
        {
            mem[1152921520127533112] = 1069547520;
            mem[1152921520127533097] = 1;
            val_1 = new UnityEngine.MonoBehaviour();
        }
    
    }

}
