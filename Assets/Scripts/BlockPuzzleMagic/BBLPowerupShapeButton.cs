using UnityEngine;

namespace BlockPuzzleMagic
{
    public class BBLPowerupShapeButton : BBLPowerupButton
    {
        // Fields
        protected float startShapeSize;
        protected bool isModeOn;
        protected BlockPuzzleMagic.ShapeInfo shapePiece;
        protected bool isInputInterrupted;
        
        // Methods
        protected override void Start()
        {
            this.Start();
            BlockPuzzleMagic.GamePlay val_1 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnPowerupMode, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void BlockPuzzleMagic.BBLPowerupShapeButton::OnPowerupMode(bool isEntered)));
            if(val_3 != null)
            {
                    if(null != null)
            {
                goto label_5;
            }
            
            }
            
            val_1.OnPowerupMode = val_3;
            return;
            label_5:
        }
        protected override void OnDestroy()
        {
            System.Action<System.Boolean> val_6;
            this.OnDestroy();
            val_6 = 1152921504893161472;
            if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance) == 0)
            {
                    return;
            }
            
            BlockPuzzleMagic.GamePlay val_3 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            val_6 = val_3.OnPowerupMode;
            System.Delegate val_5 = System.Delegate.Remove(source:  val_6, value:  new System.Action<System.Boolean>(object:  this, method:  System.Void BlockPuzzleMagic.BBLPowerupShapeButton::OnPowerupMode(bool isEntered)));
            if(val_5 != null)
            {
                    if(null != null)
            {
                goto label_10;
            }
            
            }
            
            val_3.OnPowerupMode = val_5;
            return;
            label_10:
        }
        protected override void OnLevelInitialized(BlockPuzzleMagic.Level level)
        {
            this.OnLevelInitialized(level:  level);
            MonoExtensions.DelayedCallEndOfFrame(monoBehaviour:  this, callback:  new System.Action(object:  this, method:  System.Void BlockPuzzleMagic.BBLPowerupShapeButton::CreatePowerupShapeObject()), count:  1);
        }
        protected virtual void OnApplicationFocus(bool hasFocus)
        {
            if(hasFocus != false)
            {
                    if(this.isInputInterrupted == false)
            {
                    return;
            }
            
                if(this.isModeOn != false)
            {
                    bool val_1 = this.ToggleMode();
            }
            
                this.isInputInterrupted = false;
                return;
            }
            
            if(this.isModeOn == false)
            {
                    return;
            }
            
            this.isInputInterrupted = true;
        }
        protected override void OnButtonClicked()
        {
            if(true == 0)
            {
                    return;
            }
            
            if((System.String.op_Equality(a:  this.shapePiece.<initSource>k__BackingField, b:  "shpsrc_shp_spwn")) == true)
            {
                    return;
            }
            
            if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance.CanUsePowerup(powerupType:  "shpsrc_shp_spwn", showStoreIfOOC:  true, oocDelay:  0f)) == false)
            {
                    return;
            }
            
            int val_5 = MonoSingleton<BlockPuzzleMagic.BlockShapeSpawner>.Instance.GetAvailablePowerupShapeContainerIndex();
            if(val_5 == 1)
            {
                    return;
            }
            
            MonoSingleton<BlockPuzzleMagic.BlockShapeSpawner>.Instance.SetPowerupShape(index:  val_5, shape:  this.shapePiece, powerupType:  0);
            MonoSingleton<BlockPuzzleMagic.BBLGameplayUIController>.Instance.OnPowerupsBuy();
            this.shapePiece = 0;
            this.CreatePowerupShapeObject();
        }
        private void OnPowerupMode(bool isEntered)
        {
            if(isEntered != false)
            {
                    if(this.isModeOn == false)
            {
                goto label_1;
            }
            
            }
            
            this.interactable = isEntered;
            this.RefreshPriceLabel();
            return;
            label_1:
            this.interactable = false;
        }
        private bool ToggleMode()
        {
            bool val_8 = this.isModeOn;
            if(val_8 == false)
            {
                goto label_1;
            }
            
            val_8 = val_8 ^ 1;
            this.isModeOn = val_8;
            label_14:
            BlockPuzzleMagic.GamePlay val_1 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            if(val_1.OnPowerupMode != null)
            {
                    BlockPuzzleMagic.GamePlay val_2 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
                val_2.OnPowerupMode.Invoke(obj:  false);
            }
            
            return true;
            label_1:
            if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance.CanUsePowerup(powerupType:  null, showStoreIfOOC:  true, oocDelay:  0f)) == false)
            {
                    return true;
            }
            
            this.isModeOn = this.isModeOn ^ 1;
            if(this.isModeOn == true)
            {
                goto label_14;
            }
            
            BlockPuzzleMagic.GamePlay val_6 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            if(val_6.OnPowerupMode == null)
            {
                    return true;
            }
            
            BlockPuzzleMagic.GamePlay val_7 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            val_7.OnPowerupMode.Invoke(obj:  true);
            return true;
        }
        protected virtual void OnModeEntered()
        {
            UnityEngine.Transform[] val_1 = new UnityEngine.Transform[2];
            BlockPuzzleMagic.GameBoardGenerator val_2 = MonoSingleton<BlockPuzzleMagic.GameBoardGenerator>.Instance;
            val_1[0] = val_2.BoardContent.transform;
            val_1[1] = this.gameObject.transform;
            BlockPuzzleMagic.BBLGameplayUIHelper.ShowGameplayOverlay(contentToShow:  val_1);
        }
        protected virtual void OnModeExit()
        {
            if(W8 != 0)
            {
                    this.CreatePowerupShapeObject();
            }
            
            mem[1152921520126212536] = 0;
            BlockPuzzleMagic.BBLGameplayUIHelper.CloseGameplayOverlay(immediate:  false, onOverlayClosed:  0);
        }
        protected void CreatePowerupShapeObject()
        {
            var val_15;
            if(this.shapePiece != 0)
            {
                    UnityEngine.Object.Destroy(obj:  this.shapePiece.gameObject);
            }
            
            BlockPuzzleMagic.GameBoardGenerator val_5 = MonoSingleton<BlockPuzzleMagic.GameBoardGenerator>.Instance;
            this.shapePiece = UnityEngine.Object.Instantiate<BlockPuzzleMagic.ShapeInfo>(original:  BlockPuzzleMagic.GameReferenceData.Instance.GetShapePrefabForPowerup(powerupType:  0), parent:  val_5.BoardContent.transform);
            UnityEngine.Transform val_9 = this.gameObject.transform;
            UnityEngine.Vector3 val_11 = new UnityEngine.Vector3(x:  0f, y:  0f, z:  0f);
            if(null == null)
            {
                    UnityEngine.Vector3 val_12 = this.transform.TransformPoint(position:  new UnityEngine.Vector3() {x = val_11.x, y = val_11.y, z = val_11.z});
                this.shapePiece.Interactable = false;
                val_15 = 0;
                if( == 0)
            {
                    return;
            }
            
                mem2[0] = 0;
                return;
            }
        
        }
        public BBLPowerupShapeButton()
        {
            this.startShapeSize = 1.5f;
            mem[1152921520126568729] = 1;
            val_1 = new UnityEngine.MonoBehaviour();
        }
    
    }

}
