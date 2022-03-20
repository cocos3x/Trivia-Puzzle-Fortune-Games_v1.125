using UnityEngine;
public class BBLFTUXDemoWindow : FTUXDemoWindow
{
    // Fields
    private UnityEngine.UI.Image handCursor;
    private UnityEngine.UI.Image cellFrameOutline;
    private UnityEngine.UI.Image arrowHead;
    private UnityEngine.GameObject bubbleObject;
    private UnityEngine.UI.Image bubbleTipImageDown;
    private UnityEngine.UI.Image bubbleTipImageUp;
    private UnityEngine.UI.Text bubbleHeader;
    private UnityEngine.UI.Text[] bubbleLabel;
    private UnityEngine.UI.Button bubbleButton;
    private UnityEngine.GameObject groupButton;
    private UnityEngine.GameObject groupNoButton;
    private UnityEngine.GameObject textBandParentObject;
    private UnityEngine.UI.Text textBandGenericLabel;
    private UnityEngine.GameObject textBandRemoveStones;
    private UnityEngine.UI.Image bgImage;
    private UnityEngine.GameObject actedObject;
    private UnityEngine.GameObject tutorialTitle;
    private static BlockPuzzleMagic.FtuxId currentFtuxFlag;
    private bool stepCompletedByPlayer;
    private DG.Tweening.Sequence pointerMoveSeq;
    private int subStepCounter;
    private bool isDisplayFtuxQueued;
    private UnityEngine.GameObject targetFtuxGO;
    
    // Properties
    public static BlockPuzzleMagic.FtuxId CurrentFtux { get; }
    
    // Methods
    public static BlockPuzzleMagic.FtuxId get_CurrentFtux()
    {
        null = null;
        return (BlockPuzzleMagic.FtuxId)BBLFTUXDemoWindow.currentFtuxFlag;
    }
    private void Awake()
    {
        this.textBandParentObject.gameObject.SetActive(value:  false);
        this.textBandGenericLabel.gameObject.SetActive(value:  false);
        this.textBandRemoveStones.gameObject.SetActive(value:  false);
        this.HideSpeechBubble();
    }
    private void Start()
    {
        BlockPuzzleMagic.GamePlay val_1 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
        System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnShapePlaced, b:  new System.Action<BlockPuzzleMagic.ShapeInfo>(object:  this, method:  System.Void BBLFTUXDemoWindow::OnShapePlaced(BlockPuzzleMagic.ShapeInfo shape)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_19;
        }
        
        }
        
        val_1.OnShapePlaced = val_3;
        BlockPuzzleMagic.GamePlay val_4 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
        System.Delegate val_6 = System.Delegate.Combine(a:  val_4.OnShapeRotated, b:  new System.Action<BlockPuzzleMagic.ShapeInfo>(object:  this, method:  System.Void BBLFTUXDemoWindow::OnShapeRotated(BlockPuzzleMagic.ShapeInfo shape)));
        if(val_6 != null)
        {
                if(null != null)
        {
            goto label_19;
        }
        
        }
        
        val_4.OnShapeRotated = val_6;
        BlockPuzzleMagic.GamePlay val_7 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
        System.Delegate val_9 = System.Delegate.Combine(a:  val_7.OnPowerupUsed, b:  new System.Action<BlockPuzzleMagic.PowerUpType>(object:  this, method:  System.Void BBLFTUXDemoWindow::OnPowerupUsed(BlockPuzzleMagic.PowerUpType pType)));
        if(val_9 != null)
        {
                if(null != null)
        {
            goto label_19;
        }
        
        }
        
        val_7.OnPowerupUsed = val_9;
        BlockPuzzleMagic.GamePlay val_10 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
        System.Delegate val_12 = System.Delegate.Combine(a:  val_10.OnPowerupMode, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void BBLFTUXDemoWindow::OnPowerupMode(bool isOn)));
        if(val_12 != null)
        {
                if(null != null)
        {
            goto label_19;
        }
        
        }
        
        val_10.OnPowerupMode = val_12;
        GameMaskOverlay val_13 = MonoSingleton<GameMaskOverlay>.Instance;
        System.Delegate val_15 = System.Delegate.Combine(a:  val_13.OnOverlayOpened, b:  new System.Action(object:  this, method:  System.Void BBLFTUXDemoWindow::OnGameMaskOverlayOpened()));
        if(val_15 != null)
        {
                if(null != null)
        {
            goto label_19;
        }
        
        }
        
        val_13.OnOverlayOpened = val_15;
        this.bubbleButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void BBLFTUXDemoWindow::OnSpeechBubbleButtonClicked()));
        this.handCursor.gameObject.SetActive(value:  false);
        return;
        label_19:
    }
    private void OnDestroy()
    {
        System.Action val_21;
        if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance) != 0)
        {
                BlockPuzzleMagic.GamePlay val_3 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            System.Delegate val_5 = System.Delegate.Remove(source:  val_3.OnShapePlaced, value:  new System.Action<BlockPuzzleMagic.ShapeInfo>(object:  this, method:  System.Void BBLFTUXDemoWindow::OnShapePlaced(BlockPuzzleMagic.ShapeInfo shape)));
            if(val_5 != null)
        {
                if(null != null)
        {
            goto label_29;
        }
        
        }
        
            val_3.OnShapePlaced = val_5;
            BlockPuzzleMagic.GamePlay val_6 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            System.Delegate val_8 = System.Delegate.Remove(source:  val_6.OnShapeRotated, value:  new System.Action<BlockPuzzleMagic.ShapeInfo>(object:  this, method:  System.Void BBLFTUXDemoWindow::OnShapeRotated(BlockPuzzleMagic.ShapeInfo shape)));
            if(val_8 != null)
        {
                if(null != null)
        {
            goto label_29;
        }
        
        }
        
            val_6.OnShapeRotated = val_8;
            BlockPuzzleMagic.GamePlay val_9 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            System.Delegate val_11 = System.Delegate.Remove(source:  val_9.OnPowerupUsed, value:  new System.Action<BlockPuzzleMagic.PowerUpType>(object:  this, method:  System.Void BBLFTUXDemoWindow::OnPowerupUsed(BlockPuzzleMagic.PowerUpType pType)));
            if(val_11 != null)
        {
                if(null != null)
        {
            goto label_29;
        }
        
        }
        
            val_9.OnPowerupUsed = val_11;
            BlockPuzzleMagic.GamePlay val_12 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
            System.Delegate val_14 = System.Delegate.Remove(source:  val_12.OnPowerupMode, value:  new System.Action<System.Boolean>(object:  this, method:  System.Void BBLFTUXDemoWindow::OnPowerupMode(bool isOn)));
            if(val_14 != null)
        {
                if(null != null)
        {
            goto label_29;
        }
        
        }
        
            val_12.OnPowerupMode = val_14;
        }
        
        val_21 = 1152921504893161472;
        if((MonoSingleton<GameMaskOverlay>.Instance) != 0)
        {
                GameMaskOverlay val_17 = MonoSingleton<GameMaskOverlay>.Instance;
            val_21 = val_17.OnOverlayOpened;
            System.Delegate val_19 = System.Delegate.Remove(source:  val_21, value:  new System.Action(object:  this, method:  System.Void BBLFTUXDemoWindow::OnGameMaskOverlayOpened()));
            if(val_19 != null)
        {
                if(null != null)
        {
            goto label_29;
        }
        
        }
        
            val_17.OnOverlayOpened = val_19;
        }
        
        UnityEngine.Object.Destroy(obj:  this.handCursor.gameObject);
        UnityEngine.Object.Destroy(obj:  this.bubbleObject);
        return;
        label_29:
    }
    private void OnEnable()
    {
        if(this.isDisplayFtuxQueued == false)
        {
                return;
        }
        
        this.DisplayFTUXStepDelayed();
        this.isDisplayFtuxQueued = false;
    }
    private void OnSpeechBubbleButtonClicked()
    {
        this.stepCompletedByPlayer = true;
        this.CloseWindow(immediate:  false);
    }
    private void OnShapePlaced(BlockPuzzleMagic.ShapeInfo shape)
    {
        var val_5;
        var val_6;
        var val_7;
        var val_8;
        val_5 = null;
        val_5 = null;
        val_6 = val_5;
        if(BBLFTUXDemoWindow.currentFtuxFlag == 1)
        {
                int val_5 = this.subStepCounter;
            val_5 = val_5 + 1;
            this.subStepCounter = val_5;
            if(val_5 >= 2)
        {
                this.stepCompletedByPlayer = true;
            DG.Tweening.Tween val_2 = DG.Tweening.DOVirtual.DelayedCall(delay:  0.2f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void BBLFTUXDemoWindow::CloseWindow()), ignoreTimeScale:  true);
        }
        else
        {
                val_6 = 1152921504873406648;
            this.DisplayFTUXStep(stage:  BBLFTUXDemoWindow.currentFtuxFlag, targetGO:  this.actedObject);
        }
        
        }
        
        val_7 = null;
        val_7 = null;
        val_8 = val_7;
        if(BBLFTUXDemoWindow.currentFtuxFlag != 2)
        {
                return;
        }
        
        int val_6 = this.subStepCounter;
        val_6 = val_6 + 1;
        this.subStepCounter = val_6;
        if(val_6 >= 1)
        {
                this.stepCompletedByPlayer = true;
            DG.Tweening.Tween val_4 = DG.Tweening.DOVirtual.DelayedCall(delay:  0.2f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void BBLFTUXDemoWindow::CloseWindow()), ignoreTimeScale:  true);
            return;
        }
        
        val_8 = 1152921504873406648;
        this.DisplayFTUXStep(stage:  BBLFTUXDemoWindow.currentFtuxFlag, targetGO:  this.actedObject);
    }
    private void OnShapeRotated(BlockPuzzleMagic.ShapeInfo shape)
    {
        null = null;
        if(BBLFTUXDemoWindow.currentFtuxFlag != 14)
        {
                return;
        }
        
        if((this.actedObject.GetComponent<BlockPuzzleMagic.ShapeInfo>()) != 0)
        {
                val_1.draggable = true;
        }
        
        this.stepCompletedByPlayer = true;
        this.CloseWindow(immediate:  false);
    }
    private void OnPowerupUsed(BlockPuzzleMagic.PowerUpType pType)
    {
        var val_3;
        BlockPuzzleMagic.FtuxId val_4;
        BlockPuzzleMagic.FtuxId val_5;
        var val_6;
        System.Action<BlockPuzzleMagic.GridCell> val_8;
        val_3 = null;
        val_3 = null;
        val_4 = BBLFTUXDemoWindow.currentFtuxFlag;
        if(val_4 != 4)
        {
                val_3 = null;
            val_4 = BBLFTUXDemoWindow.currentFtuxFlag;
            if(val_4 != 5)
        {
                val_3 = null;
            val_4 = BBLFTUXDemoWindow.currentFtuxFlag;
            if(val_4 != 6)
        {
                return;
        }
        
        }
        
        }
        
        val_3 = null;
        val_5 = BBLFTUXDemoWindow.currentFtuxFlag;
        if(val_5 == 4)
        {
            goto label_12;
        }
        
        val_5 = BBLFTUXDemoWindow.currentFtuxFlag;
        if(val_5 != 5)
        {
            goto label_15;
        }
        
        label_12:
        BlockPuzzleMagic.GamePlay val_1 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
        val_6 = null;
        val_6 = null;
        val_8 = BBLFTUXDemoWindow.<>c.<>9__32_0;
        if(val_8 == null)
        {
                System.Action<BlockPuzzleMagic.GridCell> val_2 = null;
            val_8 = val_2;
            val_2 = new System.Action<BlockPuzzleMagic.GridCell>(object:  BBLFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Void BBLFTUXDemoWindow.<>c::<OnPowerupUsed>b__32_0(BlockPuzzleMagic.GridCell n));
            BBLFTUXDemoWindow.<>c.<>9__32_0 = val_8;
        }
        
        val_1.cellGrid.ForEach(action:  val_2);
        label_15:
        this.stepCompletedByPlayer = true;
        this.actedObject = 0;
        this.CloseWindow(immediate:  false);
    }
    private void OnPowerupMode(bool isOn)
    {
        var val_1;
        BlockPuzzleMagic.FtuxId val_2;
        val_1 = null;
        val_1 = null;
        val_2 = BBLFTUXDemoWindow.currentFtuxFlag;
        if(val_2 != 6)
        {
                val_1 = null;
            val_2 = BBLFTUXDemoWindow.currentFtuxFlag;
            if(val_2 != 5)
        {
                val_1 = null;
            val_2 = BBLFTUXDemoWindow.currentFtuxFlag;
            if(val_2 != 4)
        {
                return;
        }
        
        }
        
        }
        
        if(isOn != false)
        {
                this.HideSpeechBubble();
            return;
        }
        
        if(this.stepCompletedByPlayer != false)
        {
                return;
        }
        
        val_1 = null;
        this.DisplayFTUXStep(stage:  BBLFTUXDemoWindow.currentFtuxFlag, targetGO:  this.actedObject);
    }
    private void OnGameMaskOverlayOpened()
    {
        if(this.cellFrameOutline.gameObject.activeSelf != false)
        {
                this.cellFrameOutline.transform.SetAsLastSibling();
        }
        
        if(this.arrowHead.gameObject.activeSelf != false)
        {
                this.arrowHead.transform.SetAsLastSibling();
        }
        
        if(this.handCursor.gameObject.activeSelf != false)
        {
                this.handCursor.transform.SetAsLastSibling();
        }
        
        BlockPuzzleMagic.GamePlay val_10 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
        val_10.floatingShapesLayer.SetAsLastSibling();
    }
    public void ShowFTUXStep(BlockPuzzleMagic.FtuxId stage, UnityEngine.GameObject targetGO)
    {
        null = null;
        BBLFTUXDemoWindow.currentFtuxFlag = stage;
        this.targetFtuxGO = targetGO;
        if(this.gameObject.activeInHierarchy != false)
        {
                this.DisplayFTUXStepDelayed();
            return;
        }
        
        this.isDisplayFtuxQueued = true;
    }
    private void DisplayFTUXStepDelayed()
    {
        MonoExtensions.DelayedCallEndOfFrame(monoBehaviour:  this, callback:  new System.Action(object:  this, method:  System.Void BBLFTUXDemoWindow::<DisplayFTUXStepDelayed>b__36_0()), count:  1);
    }
    private void DisplayFTUXStep(BlockPuzzleMagic.FtuxId stage, UnityEngine.GameObject targetGO)
    {
        BlockPuzzleMagic.FtuxId val_202;
        BBLFTUXDemoWindow val_203;
        var val_204;
        System.Collections.Generic.List<BlockPuzzleMagic.GridCell> val_205;
        UnityEngine.Transform val_206;
        var val_207;
        float val_211;
        UnityEngine.Transform val_212;
        string val_213;
        float val_214;
        var val_215;
        System.Action<BlockPuzzleMagic.GridCell> val_217;
        float val_219;
        float val_220;
        float val_221;
        float val_222;
        var val_224;
        float val_227;
        var val_228;
        val_202 = stage;
        val_203 = this;
        val_204 = null;
        val_204 = null;
        BBLFTUXDemoWindow.currentFtuxFlag = val_202;
        if(targetGO != 0)
        {
                this.actedObject = targetGO;
        }
        
        if(this.textBandParentObject == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_2 = this.textBandParentObject.gameObject;
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        val_2.SetActive(value:  false);
        if(this.cellFrameOutline == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_3 = this.cellFrameOutline.gameObject;
        if(val_3 == null)
        {
                throw new NullReferenceException();
        }
        
        val_3.SetActive(value:  false);
        if((val_202 - 1) > 2)
        {
            goto label_10;
        }
        
        BBLFTUXDemoWindow.<>c__DisplayClass37_0 val_5 = new BBLFTUXDemoWindow.<>c__DisplayClass37_0();
        if(val_5 == null)
        {
                throw new NullReferenceException();
        }
        
        .<>4__this = val_203;
        if((MonoSingleton<BlockPuzzleMagic.BBLGameplayUIController>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_6.topStatViewCanvasGroup == null)
        {
                throw new NullReferenceException();
        }
        
        val_6.topStatViewCanvasGroup.alpha = 0f;
        if((MonoSingleton<BlockPuzzleMagic.BBLGameplayUIController>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_7.topGameplayCanvasGroup == null)
        {
                throw new NullReferenceException();
        }
        
        val_7.topGameplayCanvasGroup.alpha = 0f;
        if(this.bgImage == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_8 = this.bgImage.gameObject;
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        val_8.SetActive(value:  true);
        if(this.textBandParentObject == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_9 = this.textBandParentObject.gameObject;
        if(val_9 == null)
        {
                throw new NullReferenceException();
        }
        
        val_9.SetActive(value:  true);
        if(this.textBandGenericLabel == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_10 = this.textBandGenericLabel.gameObject;
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        val_10.SetActive(value:  false);
        if(this.textBandRemoveStones == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_11 = this.textBandRemoveStones.gameObject;
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        val_11.SetActive(value:  false);
        UnityEngine.Transform[] val_12 = new UnityEngine.Transform[8];
        if(this.bgImage == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_13 = this.bgImage.transform;
        if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_13 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_12.Length == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_12[0] = val_13;
        if(this.textBandParentObject == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_14 = this.textBandParentObject.transform;
        if(val_14 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_12.Length <= 1)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_12[1] = val_14;
        if((MonoSingleton<BlockPuzzleMagic.GameBoardGenerator>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_15.BoardContent == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_16 = val_15.BoardContent.transform;
        if(val_16 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_12.Length <= 2)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_12[2] = val_16;
        val_205 = 1152921513395544352;
        BlockPuzzleMagic.BlockShapeSpawner val_17 = MonoSingleton<BlockPuzzleMagic.BlockShapeSpawner>.Instance;
        if(val_17 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_18 = val_17.gameObject;
        if(val_18 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_19 = val_18.transform;
        if(val_19 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_12.Length <= 3)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_12[3] = val_19;
        if(this.arrowHead == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_20 = this.arrowHead.transform;
        if(val_20 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_12.Length <= 4)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_12[4] = val_20;
        if(this.handCursor == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_21 = this.handCursor.transform;
        if(val_21 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_12.Length <= 5)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_12[5] = val_21;
        if(this.cellFrameOutline == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_22 = this.cellFrameOutline.transform;
        if(val_22 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_12.Length <= 6)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_12[6] = val_22;
        if(this.tutorialTitle == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_23 = this.tutorialTitle.transform;
        if(val_23 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_12.Length <= 7)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_12[7] = val_23;
        BlockPuzzleMagic.BBLGameplayUIHelper.ShowGameplayOverlay(contentToShow:  val_12);
        if(this.tutorialTitle == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_24 = this.tutorialTitle.gameObject;
        if(val_24 == null)
        {
                throw new NullReferenceException();
        }
        
        val_24.SetActive(value:  true);
        if(this.tutorialTitle == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_25 = this.tutorialTitle.transform;
        UnityEngine.Vector3 val_26 = new UnityEngine.Vector3(x:  0f, y:  699f, z:  0f);
        if(val_25 == null)
        {
            goto label_68;
        }
        
        var val_27 = (null == null) ? (val_25) : 0;
        goto label_69;
        label_10:
        BlockPuzzleMagic.FtuxId val_28 = val_202 - 4;
        if(val_28 >= 3)
        {
            goto label_70;
        }
        
        .<>4__this = val_203;
        this.HidePointer();
        this.HideArrowHead();
        val_207 = 1152921504762171392;
        UnityEngine.Vector3 val_30 = UnityEngine.Vector3.zero;
        .pointerStartPos = val_30;
        mem[1152921513396781564] = val_30.y;
        mem[1152921513396781568] = val_30.z;
        UnityEngine.Vector3 val_31 = UnityEngine.Vector3.zero;
        .pointerEndPos = val_31;
        mem[1152921513396781576] = val_31.y;
        mem[1152921513396781580] = val_31.z;
        UnityEngine.Vector3 val_32 = UnityEngine.Vector3.zero;
        .arrowStartPos = val_32;
        mem[1152921513396781540] = val_32.y;
        mem[1152921513396781544] = val_32.z;
        UnityEngine.Vector3 val_33 = UnityEngine.Vector3.zero;
        val_211 = 0.7f;
        .arrowEndPos = val_33;
        mem[1152921513396781552] = val_33.y;
        mem[1152921513396781556] = val_33.z;
        UnityEngine.Color val_34 = new UnityEngine.Color(r:  0f, g:  0f, b:  0f, a:  val_211);
        BlockPuzzleMagic.BBLGameplayUIController val_35 = MonoSingleton<BlockPuzzleMagic.BBLGameplayUIController>.Instance;
        val_35.buttonPowerupTrash.BlockRaycasts = false;
        BlockPuzzleMagic.BBLGameplayUIController val_36 = MonoSingleton<BlockPuzzleMagic.BBLGameplayUIController>.Instance;
        val_36.buttonPowerupBomb.BlockRaycasts = false;
        BlockPuzzleMagic.BBLGameplayUIController val_37 = MonoSingleton<BlockPuzzleMagic.BBLGameplayUIController>.Instance;
        val_37.buttonPowerupFill.BlockRaycasts = false;
        if(val_202 == 6)
        {
            goto label_82;
        }
        
        if(val_202 == 5)
        {
            goto label_83;
        }
        
        if(val_202 != 4)
        {
            goto label_84;
        }
        
        BlockPuzzleMagic.BBLGameplayUIController val_38 = MonoSingleton<BlockPuzzleMagic.BBLGameplayUIController>.Instance;
        val_212 = val_38.buttonPowerupBomb.transform;
        val_213 = Localization.Localize(key:  "powerup_bomb_description", defaultValue:  "The BOMB explodes the row and column where it is placed.", useSingularKey:  false);
        BlockPuzzleMagic.BBLGameplayUIController val_41 = MonoSingleton<BlockPuzzleMagic.BBLGameplayUIController>.Instance;
        val_41.buttonPowerupBomb.RefreshPriceLabel();
        UnityEngine.Vector3 val_42 = val_212.position;
        .pointerStartPos = val_42;
        mem[1152921513396781564] = val_42.y;
        mem[1152921513396781568] = val_42.z;
        BlockPuzzleMagic.GamePlay val_43 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
        if(1152921513393502304 <= 40)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        UnityEngine.Vector3 val_45 = transform.position;
        .pointerEndPos = val_45;
        mem[1152921513396781576] = val_45.y;
        mem[1152921513396781580] = val_45.z;
        goto label_311;
        label_70:
        if(val_202 != 14)
        {
            goto label_100;
        }
        
        BlockPuzzleMagic.GamePlay val_46 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
        val_46.<GridCellsInteractable>k__BackingField = false;
        if((MonoSingleton<BlockPuzzleMagic.BBLGameplayUIController>.Instance) != 0)
        {
                BlockPuzzleMagic.BBLGameplayUIController val_49 = MonoSingleton<BlockPuzzleMagic.BBLGameplayUIController>.Instance;
            val_49.buttonPowerupTrash.BlockRaycasts = false;
        }
        
        if((targetGO.GetComponent<BlockPuzzleMagic.ShapeInfo>()) != 0)
        {
                val_50.draggable = false;
        }
        
        val_202 = Localization.Localize(key:  "rotate_shape_description", defaultValue:  "Tap to rotate. Try it now!", useSingularKey:  false);
        UnityEngine.Color val_53 = UnityEngine.Color.clear;
        UnityEngine.Transform[] val_54 = new UnityEngine.Transform[1];
        val_212 = targetGO.transform.parent;
        val_54[0] = val_212;
        BlockPuzzleMagic.BBLGameplayUIHelper.ShowGameplayOverlay(bgColor:  new UnityEngine.Color() {r = val_53.r, g = val_53.g, b = val_53.b, a = val_53.a}, contentToShow:  val_54);
        UnityEngine.Vector3 val_58 = targetGO.transform.position;
        val_211 = val_58.x;
        val_214 = val_58.z;
        UnityEngine.Vector3 val_59 = new UnityEngine.Vector3(x:  0f, y:  0.45f, z:  0f);
        UnityEngine.Vector3 val_60 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_211, y = val_58.y, z = val_214}, b:  new UnityEngine.Vector3() {x = val_59.x, y = val_59.y, z = val_59.z});
        System.Nullable<UnityEngine.Vector3> val_61 = new System.Nullable<UnityEngine.Vector3>(value:  new UnityEngine.Vector3() {x = val_60.x, y = val_60.y, z = val_60.z});
        UnityEngine.Color val_62 = UnityEngine.Color.clear;
        System.Nullable<UnityEngine.Color> val_63 = new System.Nullable<UnityEngine.Color>(value:  new UnityEngine.Color() {r = val_62.r, g = val_62.g, b = val_62.b, a = val_62.a});
        this.ShowSpeechBubble(header:  0, body:  val_202, worldPos:  new System.Nullable<UnityEngine.Vector3>() {HasValue = val_61.HasValue}, tipPointUp:  0, noButton:  true, maskBgColor:  new System.Nullable<UnityEngine.Color>() {HasValue = true});
        return;
        label_68:
        val_206 = 0;
        label_69:
        PluginExtension.SetPosition2D(transform:  val_206, target:  new UnityEngine.Vector3() {x = val_63.HasValue, y = 0f, z = 0f});
        this.HideSpeechBubble();
        this.HidePointer();
        this.HideArrowHead();
        BlockPuzzleMagic.BlockShapeSpawner val_64 = MonoSingleton<BlockPuzzleMagic.BlockShapeSpawner>.Instance;
        if(val_64 == null)
        {
                throw new NullReferenceException();
        }
        
        val_64.Interactable = false;
        if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        val_207 = 1152921504873459712;
        val_215 = null;
        val_215 = null;
        val_217 = BBLFTUXDemoWindow.<>c.<>9__37_0;
        if(val_217 == null)
        {
                System.Action<BlockPuzzleMagic.GridCell> val_66 = null;
            val_217 = val_66;
            val_66 = new System.Action<BlockPuzzleMagic.GridCell>(object:  BBLFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Void BBLFTUXDemoWindow.<>c::<DisplayFTUXStep>b__37_0(BlockPuzzleMagic.GridCell n));
            BBLFTUXDemoWindow.<>c.<>9__37_0 = val_217;
        }
        
        if(val_65.cellGrid == null)
        {
                throw new NullReferenceException();
        }
        
        val_65.cellGrid.ForEach(action:  val_66);
        if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_67.cellGrid == null)
        {
                throw new NullReferenceException();
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        UnityEngine.Transform val_68 = MonoSingleton<T>.__il2cppRuntimeField_cctor_finished + 32.transform;
        if(val_68 == null)
        {
                throw new NullReferenceException();
        }
        
        if(null != null)
        {
                throw new IndexOutOfRangeException();
        }
        
        UnityEngine.Vector2 val_69 = val_68.anchoredPosition;
        if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_70.cellGrid == null)
        {
                throw new NullReferenceException();
        }
        
        if(null <= 1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        UnityEngine.Transform val_71 = typeof(UnityEngine.Transform).__il2cppRuntimeField_28.transform;
        if(val_71 == null)
        {
                throw new NullReferenceException();
        }
        
        if(null != null)
        {
                throw new IndexOutOfRangeException();
        }
        
        UnityEngine.Vector2 val_72 = val_71.anchoredPosition;
        val_212 = 1152921504762331136;
        val_214 = val_72.x;
        if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_74.cellGrid == null)
        {
                throw new NullReferenceException();
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        UnityEngine.Transform val_75 = UnityEngine.Vector2.__il2cppRuntimeField_cctor_finished + 32.transform;
        if(val_75 == null)
        {
                throw new NullReferenceException();
        }
        
        if(null != null)
        {
                throw new IndexOutOfRangeException();
        }
        
        UnityEngine.Vector2 val_76 = val_75.sizeDelta;
        val_211 = (UnityEngine.Vector2.Distance(a:  new UnityEngine.Vector2() {x = val_69.x, y = val_69.y}, b:  new UnityEngine.Vector2() {x = val_214, y = val_72.y})) - val_76.x;
        UnityEngine.Vector3 val_77 = UnityEngine.Vector3.zero;
        .startpoint = val_77;
        mem[1152921513396634032] = val_77.y;
        mem[1152921513396634036] = val_77.z;
        UnityEngine.Vector3 val_78 = UnityEngine.Vector3.zero;
        .endpoint = val_78;
        mem[1152921513396634020] = val_78.y;
        mem[1152921513396634024] = val_78.z;
        if(val_202 == 2)
        {
            goto label_161;
        }
        
        if(val_202 != 1)
        {
            goto label_211;
        }
        
        if(this.subStepCounter == 1)
        {
            goto label_163;
        }
        
        if(this.subStepCounter != 0)
        {
            goto label_211;
        }
        
        if(this.textBandGenericLabel == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.textBandGenericLabel == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_79 = this.textBandGenericLabel.gameObject;
        if(val_79 == null)
        {
                throw new NullReferenceException();
        }
        
        val_79.SetActive(value:  true);
        if((MonoSingleton<BlockPuzzleMagic.BlockShapeSpawner>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_80.ShapeContainers == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_80.ShapeContainers.Length <= 1)
        {
                throw new IndexOutOfRangeException();
        }
        
        UnityEngine.Transform val_201 = val_80.ShapeContainers[1];
        if(val_201 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Vector3 val_81 = val_201.position;
        .startpoint = val_81;
        mem[1152921513396634032] = val_81.y;
        mem[1152921513396634036] = val_81.z;
        if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_82.cellGrid == null)
        {
                throw new NullReferenceException();
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        UnityEngine.GameObject val_83 = MonoSingleton<T>.__il2cppRuntimeField_cctor_finished + 288.gameObject;
        if(val_83 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_84 = val_83.transform;
        if(val_84 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Vector3 val_85 = val_84.position;
        if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_86.cellGrid == null)
        {
                throw new NullReferenceException();
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        UnityEngine.GameObject val_87 = MonoSingleton<T>.__il2cppRuntimeField_cctor_finished + 368.gameObject;
        if(val_87 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_88 = val_87.transform;
        if(val_88 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Vector3 val_89 = val_88.position;
        val_219 = val_89.x;
        val_220 = val_85.x;
        val_221 = val_85.y;
        val_222 = val_219;
        UnityEngine.Vector3 val_90 = UnityEngine.Vector3.Lerp(a:  new UnityEngine.Vector3() {x = val_220, y = val_221, z = val_85.z}, b:  new UnityEngine.Vector3() {x = val_222, y = val_89.y, z = val_89.z}, t:  0.5f);
        .endpoint = val_90;
        mem[1152921513396634020] = val_90.y;
        mem[1152921513396634024] = val_90.z;
        if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_91.cellGrid == null)
        {
                throw new NullReferenceException();
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        mem2[0] = 1;
        if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_92.cellGrid == null)
        {
                throw new NullReferenceException();
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        mem2[0] = 1;
        if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_93.cellGrid == null)
        {
                throw new NullReferenceException();
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        mem2[0] = 1;
        if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_94.cellGrid == null)
        {
                throw new NullReferenceException();
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        mem2[0] = 1;
        if((MonoSingleton<BlockPuzzleMagic.BlockShapeSpawner>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_95.spawnedShapes == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_95.spawnedShapes.Length <= 1)
        {
                throw new IndexOutOfRangeException();
        }
        
        if(val_95.spawnedShapes[1] != null)
        {
            goto label_209;
        }
        
        throw new NullReferenceException();
        label_161:
        if(this.subStepCounter != 0)
        {
            goto label_211;
        }
        
        if(this.textBandRemoveStones == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_96 = this.textBandRemoveStones.gameObject;
        if(val_96 == null)
        {
                throw new NullReferenceException();
        }
        
        val_96.SetActive(value:  true);
        if((MonoSingleton<BlockPuzzleMagic.BlockShapeSpawner>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_97.ShapeContainers == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_97.ShapeContainers.Length <= 1)
        {
                throw new IndexOutOfRangeException();
        }
        
        UnityEngine.Vector3 val_98 = val_97.ShapeContainers[1].position;
        .startpoint = val_98;
        mem[1152921513396634032] = val_98.y;
        mem[1152921513396634036] = val_98.z;
        BlockPuzzleMagic.GamePlay val_99 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        UnityEngine.Vector3 val_102 = MonoSingleton<T>.__il2cppRuntimeField_cctor_finished + 288.gameObject.transform.position;
        BlockPuzzleMagic.GamePlay val_103 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        UnityEngine.Vector3 val_106 = MonoSingleton<T>.__il2cppRuntimeField_cctor_finished + 368.gameObject.transform.position;
        val_219 = val_106.x;
        UnityEngine.Vector3 val_107 = UnityEngine.Vector3.Lerp(a:  new UnityEngine.Vector3() {x = val_102.x, y = val_102.y, z = val_102.z}, b:  new UnityEngine.Vector3() {x = val_219, y = val_106.y, z = val_106.z}, t:  0.5f);
        .endpoint = val_107;
        mem[1152921513396634020] = val_107.y;
        mem[1152921513396634024] = val_107.z;
        BlockPuzzleMagic.GamePlay val_108 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        mem2[0] = 1;
        BlockPuzzleMagic.GamePlay val_109 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        mem2[0] = 1;
        BlockPuzzleMagic.GamePlay val_110 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        mem2[0] = 1;
        BlockPuzzleMagic.GamePlay val_111 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        mem2[0] = 1;
        BlockPuzzleMagic.BlockShapeSpawner val_112 = MonoSingleton<BlockPuzzleMagic.BlockShapeSpawner>.Instance;
        val_112.spawnedShapes[1].Interactable = true;
        val_224 = this.cellFrameOutline.rectTransform;
        BlockPuzzleMagic.GamePlay val_114 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
        val_202 = val_114.cellGrid;
        if(as. 
           
           
          
        
        
        
         == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(null != null)
        {
                throw new ArrayTypeMismatchException();
        }
        
        UnityEngine.Vector2 val_116 = public static BlockPuzzleMagic.GamePlay MonoSingleton<BlockPuzzleMagic.GamePlay>::get_Instance().__il2cppRuntimeField_20.transform.sizeDelta;
        UnityEngine.Vector2 val_117 = UnityEngine.Vector2.op_Multiply(a:  new UnityEngine.Vector2() {x = val_116.x, y = val_116.y}, d:  2f);
        val_214 = val_117.y;
        UnityEngine.Vector2 val_118 = new UnityEngine.Vector2(x:  val_211, y:  val_211);
        UnityEngine.Vector2 val_119 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_117.x, y = val_214}, b:  new UnityEngine.Vector2() {x = val_118.x, y = val_118.y});
        if(val_224 != null)
        {
            goto label_265;
        }
        
        label_100:
        this.stepCompletedByPlayer = true;
        this.CloseWindow(immediate:  false);
        return;
        label_83:
        BlockPuzzleMagic.BBLGameplayUIController val_120 = MonoSingleton<BlockPuzzleMagic.BBLGameplayUIController>.Instance;
        val_212 = val_120.buttonPowerupFill.transform;
        val_213 = Localization.Localize(key:  "powerup_fill_description", defaultValue:  "The 1x1 block will help you fill those pesky holes!", useSingularKey:  false);
        BlockPuzzleMagic.BBLGameplayUIController val_123 = MonoSingleton<BlockPuzzleMagic.BBLGameplayUIController>.Instance;
        val_123.buttonPowerupFill.RefreshPriceLabel();
        UnityEngine.Vector3 val_124 = val_212.position;
        .pointerStartPos = val_124;
        mem[1152921513396781564] = val_124.y;
        mem[1152921513396781568] = val_124.z;
        BlockPuzzleMagic.GamePlay val_125 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        UnityEngine.Vector3 val_127 = MonoSingleton<T>.__il2cppRuntimeField_cctor_finished + 512.transform.position;
        .pointerEndPos = val_127;
        mem[1152921513396781576] = val_127.y;
        mem[1152921513396781580] = val_127.z;
        BlockPuzzleMagic.GamePlay val_129 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
        val_205 = val_129.cellGrid;
        if((public static BlockPuzzleMagic.GamePlay MonoSingleton<BlockPuzzleMagic.GamePlay>::get_Instance()) <= 16)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(null != null)
        {
                throw new ArrayTypeMismatchException();
        }
        
        UnityEngine.Vector2 val_131 = public static BlockPuzzleMagic.GamePlay MonoSingleton<BlockPuzzleMagic.GamePlay>::get_Instance().__il2cppRuntimeField_A0.transform.sizeDelta;
        this.cellFrameOutline.rectTransform.sizeDelta = new UnityEngine.Vector2() {x = val_131.x, y = val_131.y};
        UnityEngine.Vector3 val_132 = new UnityEngine.Vector3(x:  0.27f, y:  -0.27f, z:  0f);
        val_227 = val_132.y;
        UnityEngine.Vector3 val_133 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = (BBLFTUXDemoWindow.<>c__DisplayClass37_1)[1152921513396781520].pointerStartPos, y = V10.16B, z = V11.16B}, b:  new UnityEngine.Vector3() {x = val_132.x, y = val_227, z = val_132.z});
        .arrowStartPos = val_133;
        mem[1152921513396781540] = val_133.y;
        mem[1152921513396781544] = val_133.z;
        .arrowEndPos = (BBLFTUXDemoWindow.<>c__DisplayClass37_1)[1152921513396781520].pointerEndPos;
        mem[1152921513396781556] = 1752396385;
        goto label_311;
        label_82:
        BlockPuzzleMagic.GamePlay val_134 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
        val_134.<GridCellsInteractable>k__BackingField = false;
        BlockPuzzleMagic.BBLGameplayUIController val_135 = MonoSingleton<BlockPuzzleMagic.BBLGameplayUIController>.Instance;
        val_212 = val_135.buttonPowerupTrash.transform;
        val_213 = Localization.Localize(key:  "powerup_trash_description", defaultValue:  "Use the TRASH to get rid of a piece you don\'t want to place.", useSingularKey:  false);
        BlockPuzzleMagic.BBLGameplayUIController val_138 = MonoSingleton<BlockPuzzleMagic.BBLGameplayUIController>.Instance;
        val_138.buttonPowerupTrash.RefreshPriceLabel();
        BlockPuzzleMagic.BlockShapeSpawner val_139 = MonoSingleton<BlockPuzzleMagic.BlockShapeSpawner>.Instance;
        UnityEngine.Vector3 val_140 = val_139.ShapeContainers[1].position;
        .pointerStartPos = val_140;
        mem[1152921513396781564] = val_140.y;
        mem[1152921513396781568] = val_140.z;
        UnityEngine.Vector3 val_141 = val_212.position;
        .pointerEndPos = val_141;
        mem[1152921513396781576] = val_141.y;
        mem[1152921513396781580] = val_141.z;
        UnityEngine.Vector3 val_142 = new UnityEngine.Vector3(x:  0f, y:  0.27f, z:  0f);
        UnityEngine.Vector3 val_143 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = (BBLFTUXDemoWindow.<>c__DisplayClass37_1)[1152921513396781520].pointerStartPos, y = V10.16B, z = V11.16B}, b:  new UnityEngine.Vector3() {x = val_142.x, y = val_142.y, z = val_142.z});
        .arrowStartPos = val_143;
        mem[1152921513396781540] = val_143.y;
        mem[1152921513396781544] = val_143.z;
        UnityEngine.Vector3 val_144 = new UnityEngine.Vector3(x:  0.29f, y:  -0.27f, z:  0f);
        val_227 = val_144.y;
        UnityEngine.Vector3 val_145 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = (BBLFTUXDemoWindow.<>c__DisplayClass37_1)[1152921513396781520].pointerEndPos, y = V10.16B, z = V11.16B}, b:  new UnityEngine.Vector3() {x = val_144.x, y = val_227, z = val_144.z});
        .arrowEndPos = val_145;
        mem[1152921513396781552] = val_145.y;
        mem[1152921513396781556] = val_145.z;
        goto label_311;
        label_84:
        val_213 = 0;
        val_212 = 0;
        label_311:
        System.Collections.Generic.List<UnityEngine.Transform> val_146 = new System.Collections.Generic.List<UnityEngine.Transform>();
        if(val_202 == 6)
        {
                MonoSingleton<BlockPuzzleMagic.BlockShapeSpawner>.Instance.Interactable = false;
            val_146.Add(item:  MonoSingleton<BlockPuzzleMagic.BlockShapeSpawner>.Instance.transform);
        }
        
        val_202 = 1152921513396270672;
        val_146.Add(item:  val_212);
        val_146.Add(item:  this.arrowHead.transform);
        val_146.Add(item:  this.handCursor.transform);
        val_146.Add(item:  this.cellFrameOutline.transform);
        val_219 = val_34.a;
        BlockPuzzleMagic.BBLGameplayUIHelper.ShowGameplayOverlay(bgColor:  new UnityEngine.Color() {r = val_34.r, g = val_34.g, b = val_34.b, a = val_219}, contentToShow:  val_146.ToArray());
        UnityEngine.Vector3 val_154 = val_212.position;
        if(val_28 <= 2)
        {
                UnityEngine.Vector3 val_155 = val_212.position;
            UnityEngine.Vector3 val_157 = new UnityEngine.Vector3(x:  0f, y:  val_154.y + (-2.5f), z:  val_155.z);
            System.Nullable<UnityEngine.Vector3> val_158 = new System.Nullable<UnityEngine.Vector3>(value:  new UnityEngine.Vector3() {x = val_157.x, y = val_157.y, z = val_157.z});
            System.Nullable<UnityEngine.Color> val_159 = new System.Nullable<UnityEngine.Color>(value:  new UnityEngine.Color() {r = val_34.r, g = val_34.g, b = val_34.b, a = val_34.a});
            this.ShowSpeechBubble(header:  0, body:  val_213, worldPos:  new System.Nullable<UnityEngine.Vector3>() {HasValue = val_158.HasValue}, tipPointUp:  0, noButton:  false, maskBgColor:  new System.Nullable<UnityEngine.Color>() {HasValue = false});
            UnityEngine.Vector3 val_160 = val_212.position;
            UnityEngine.Vector3 val_162 = this.bubbleObject.transform.position;
            UnityEngine.Vector3 val_164 = this.bubbleObject.transform.position;
            UnityEngine.Vector3 val_166 = new UnityEngine.Vector3(x:  val_160.x, y:  val_162.y + 0.95f, z:  val_164.z);
            UnityEngine.Vector3 val_167 = val_212.position;
            val_211 = val_167.x;
            val_214 = val_167.z;
            UnityEngine.Vector3 val_168 = new UnityEngine.Vector3(x:  0f, y:  0.65f, z:  0f);
            UnityEngine.Vector3 val_169 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = val_211, y = val_167.y, z = val_214}, b:  new UnityEngine.Vector3() {x = val_168.x, y = val_168.y, z = val_168.z});
            this.ShowArrowHead(from:  new UnityEngine.Vector3() {x = val_166.x, y = val_166.y, z = val_166.z}, to:  new UnityEngine.Vector3() {x = val_169.x, y = val_169.y, z = val_169.z});
            return;
        }
        
        val_214 = val_154.x;
        UnityEngine.Vector3 val_170 = new UnityEngine.Vector3(x:  0f, y:  0.5f, z:  0f);
        UnityEngine.Vector3 val_171 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = val_214, y = val_154.y, z = val_154.z}, b:  new UnityEngine.Vector3() {x = val_170.x, y = val_170.y, z = val_170.z});
        System.Nullable<UnityEngine.Vector3> val_172 = new System.Nullable<UnityEngine.Vector3>(value:  new UnityEngine.Vector3() {x = val_171.x, y = val_171.y, z = val_171.z});
        System.Nullable<UnityEngine.Color> val_173 = new System.Nullable<UnityEngine.Color>(value:  new UnityEngine.Color() {r = val_34.r, g = val_34.g, b = val_34.b, a = val_34.a});
        this.ShowSpeechBubble(header:  0, body:  val_213, worldPos:  new System.Nullable<UnityEngine.Vector3>() {HasValue = val_172.HasValue}, tipPointUp:  0, noButton:  false, maskBgColor:  new System.Nullable<UnityEngine.Color>() {HasValue = true});
        DG.Tweening.TweenCallback val_174 = null;
        val_203 = val_174;
        val_174 = new DG.Tweening.TweenCallback(object:  new BBLFTUXDemoWindow.<>c__DisplayClass37_1(), method:  System.Void BBLFTUXDemoWindow.<>c__DisplayClass37_1::<DisplayFTUXStep>b__2());
        val_228 = 1;
        goto label_334;
        label_163:
        if(this.textBandGenericLabel == null)
        {
                throw new NullReferenceException();
        }
        
        if(this.textBandGenericLabel == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_175 = this.textBandGenericLabel.gameObject;
        if(val_175 == null)
        {
                throw new NullReferenceException();
        }
        
        val_175.SetActive(value:  true);
        if((MonoSingleton<BlockPuzzleMagic.BlockShapeSpawner>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_176.ShapeContainers == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_176.ShapeContainers.Length <= 2)
        {
                throw new IndexOutOfRangeException();
        }
        
        UnityEngine.Transform val_206 = val_176.ShapeContainers[2];
        if(val_206 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Vector3 val_177 = val_206.position;
        .startpoint = val_177;
        mem[1152921513396634032] = val_177.y;
        mem[1152921513396634036] = val_177.z;
        if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_178.cellGrid == null)
        {
                throw new NullReferenceException();
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        UnityEngine.GameObject val_179 = MonoSingleton<T>.__il2cppRuntimeField_cctor_finished + 200.gameObject;
        if(val_179 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_180 = val_179.transform;
        if(val_180 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Vector3 val_181 = val_180.position;
        if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_182.cellGrid == null)
        {
                throw new NullReferenceException();
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        UnityEngine.GameObject val_183 = MonoSingleton<T>.__il2cppRuntimeField_cctor_finished + 280.gameObject;
        if(val_183 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_184 = val_183.transform;
        if(val_184 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Vector3 val_185 = val_184.position;
        val_219 = val_185.x;
        val_220 = val_181.x;
        val_221 = val_181.y;
        val_222 = val_219;
        UnityEngine.Vector3 val_186 = UnityEngine.Vector3.Lerp(a:  new UnityEngine.Vector3() {x = val_220, y = val_221, z = val_181.z}, b:  new UnityEngine.Vector3() {x = val_222, y = val_185.y, z = val_185.z}, t:  0.5f);
        .endpoint = val_186;
        mem[1152921513396634020] = val_186.y;
        mem[1152921513396634024] = val_186.z;
        if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_187.cellGrid == null)
        {
                throw new NullReferenceException();
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        mem2[0] = 1;
        if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_188.cellGrid == null)
        {
                throw new NullReferenceException();
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        mem2[0] = 1;
        if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_189.cellGrid == null)
        {
                throw new NullReferenceException();
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        mem2[0] = 1;
        if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_190.cellGrid == null)
        {
                throw new NullReferenceException();
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        mem2[0] = 1;
        if((MonoSingleton<BlockPuzzleMagic.BlockShapeSpawner>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_191.spawnedShapes == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_191.spawnedShapes.Length <= 2)
        {
                throw new IndexOutOfRangeException();
        }
        
        BlockPuzzleMagic.ShapeInfo val_207 = val_191.spawnedShapes[2];
        if(val_207 == null)
        {
                throw new NullReferenceException();
        }
        
        label_209:
        val_207.Interactable = true;
        if(this.cellFrameOutline == null)
        {
                throw new NullReferenceException();
        }
        
        val_224 = this.cellFrameOutline.rectTransform;
        if((MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance) == null)
        {
                throw new NullReferenceException();
        }
        
        val_202 = val_193.cellGrid;
        if(val_202 == null)
        {
                throw new NullReferenceException();
        }
        
        if(as. 
           
           
          
        
        
        
         == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        UnityEngine.Transform val_194 = public static BlockPuzzleMagic.GamePlay MonoSingleton<BlockPuzzleMagic.GamePlay>::get_Instance().__il2cppRuntimeField_20.transform;
        if(val_194 == null)
        {
                throw new NullReferenceException();
        }
        
        if(null != null)
        {
                throw new IndexOutOfRangeException();
        }
        
        UnityEngine.Vector2 val_195 = val_194.sizeDelta;
        UnityEngine.Vector2 val_196 = UnityEngine.Vector2.op_Multiply(a:  new UnityEngine.Vector2() {x = val_195.x, y = val_195.y}, d:  2f);
        val_214 = val_196.y;
        UnityEngine.Vector2 val_197 = new UnityEngine.Vector2(x:  val_211, y:  val_211);
        UnityEngine.Vector2 val_198 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_196.x, y = val_214}, b:  new UnityEngine.Vector2() {x = val_197.x, y = val_197.y});
        if(val_224 == null)
        {
                throw new NullReferenceException();
        }
        
        label_265:
        val_224.sizeDelta = new UnityEngine.Vector2() {x = val_198.x, y = val_198.y};
        label_211:
        DG.Tweening.TweenCallback val_199 = null;
        val_203 = val_199;
        val_199 = new DG.Tweening.TweenCallback(object:  val_5, method:  System.Void BBLFTUXDemoWindow.<>c__DisplayClass37_0::<DisplayFTUXStep>b__1());
        val_228 = 1;
        label_334:
        DG.Tweening.Tween val_200 = DG.Tweening.DOVirtual.DelayedCall(delay:  0.7f, callback:  val_199, ignoreTimeScale:  true);
    }
    private void ShowSpeechBubble(string header, string body, System.Nullable<UnityEngine.Vector3> worldPos, int tipPointUp = -1, bool noButton = False, System.Nullable<UnityEngine.Color> maskBgColor)
    {
        var val_16;
        bool val_66;
        string val_67;
        var val_68;
        float val_71;
        float val_72;
        UnityEngine.UI.Image val_73;
        float val_74;
        float val_75;
        float val_76;
        val_66 = maskBgColor.HasValue;
        val_67 = header;
        UnityEngine.RectOffset val_1 = null;
        val_68 = val_1;
        val_1 = new UnityEngine.RectOffset(left:  30, right:  30, top:  10, bottom:  10);
        this.bubbleObject.SetActive(value:  true);
        this.groupNoButton.SetActive(value:  val_66);
        this.groupButton.SetActive(value:  (~val_66) & 1);
        if((System.String.IsNullOrEmpty(value:  val_67)) != false)
        {
                this.bubbleHeader.gameObject.SetActive(value:  false);
        }
        
        if((System.String.IsNullOrEmpty(value:  body)) == false)
        {
            goto label_8;
        }
        
        var val_67 = 0;
        label_14:
        if(val_67 >= this.bubbleLabel.Length)
        {
            goto label_17;
        }
        
        this.bubbleLabel[val_67].gameObject.SetActive(value:  false);
        val_67 = val_67 + 1;
        if(this.bubbleLabel != null)
        {
            goto label_14;
        }
        
        label_8:
        val_67 = 0;
        label_20:
        if(val_67 >= this.bubbleLabel.Length)
        {
            goto label_17;
        }
        
        UnityEngine.UI.Text val_68 = this.bubbleLabel[val_67];
        val_67 = val_67 + 1;
        if(this.bubbleLabel != null)
        {
            goto label_20;
        }
        
        throw new NullReferenceException();
        label_17:
        if((X7 + 16) != 0)
        {
                UnityEngine.Color val_8 = X7.Value;
            UnityEngine.Transform[] val_9 = new UnityEngine.Transform[1];
            val_9[0] = this.bubbleObject.transform;
            BlockPuzzleMagic.BBLGameplayUIHelper.ShowGameplayOverlay(bgColor:  new UnityEngine.Color() {r = val_8.r, g = val_8.g, b = val_8.b, a = val_8.a}, contentToShow:  val_9);
        }
        else
        {
                UnityEngine.Transform[] val_11 = new UnityEngine.Transform[1];
            val_11[0] = this.bubbleObject.transform;
            BlockPuzzleMagic.BBLGameplayUIHelper.ShowGameplayOverlay(contentToShow:  val_11);
        }
        
        UnityEngine.Canvas val_14 = this.bubbleObject.GetComponentInChildren<UnityEngine.UI.Graphic>().canvas;
        UnityEngine.Transform val_15 = this.bubbleObject.transform;
        if(val_15 != null)
        {
                if(null != null)
        {
            goto label_37;
        }
        
        }
        
        if(val_16 != false)
        {
                val_67 = val_14.gameObject.transform;
            val_66 = val_14.worldCamera;
            UnityEngine.Vector3 val_20 = worldPos.HasValue.Value;
            if(val_67 != null)
        {
                if(null != null)
        {
            goto label_42;
        }
        
        }
        
            UnityEngine.Vector2 val_21 = worldPos.HasValue.WorldToCanvasPosition(canvasRect:  val_67, canvasCamera:  val_66, position:  new UnityEngine.Vector3() {x = val_20.x, y = val_20.y, z = val_20.z});
        }
        else
        {
                UnityEngine.Vector2 val_22 = UnityEngine.Vector2.zero;
        }
        
        if(null != null)
        {
            goto label_52;
        }
        
        UnityEngine.Rect val_25 = val_14.gameObject.transform.rect;
        UnityEngine.Vector2 val_26 = val_25.m_XMin.min;
        if(null != null)
        {
            goto label_52;
        }
        
        UnityEngine.Rect val_29 = val_14.gameObject.transform.rect;
        UnityEngine.Vector2 val_30 = val_29.m_XMin.max;
        if(noButton == true)
        {
            goto label_62;
        }
        
        if(noButton == true)
        {
            goto label_54;
        }
        
        this.bubbleTipImageUp.gameObject.SetActive(value:  false);
        this.bubbleTipImageDown.gameObject.SetActive(value:  false);
        UnityEngine.Vector2 val_33 = new UnityEngine.Vector2(x:  0.5f, y:  0.5f);
        val_71 = val_33.x;
        val_72 = val_33.y;
        val_15.pivot = new UnityEngine.Vector2() {x = val_71, y = val_72};
        val_73 = 0;
        goto label_67;
        label_54:
        UnityEngine.Vector2 val_34 = val_15.sizeDelta;
        if(val_22.y >= (val_30.y - val_34.y))
        {
            goto label_62;
        }
        
        UnityEngine.Vector2 val_36 = new UnityEngine.Vector2(x:  0.5f, y:  0f);
        val_71 = val_36.x;
        val_72 = val_36.y;
        val_15.pivot = new UnityEngine.Vector2() {x = val_71, y = val_72};
        this.bubbleTipImageUp.gameObject.SetActive(value:  false);
        this.bubbleTipImageDown.gameObject.SetActive(value:  true);
        val_73 = this.bubbleTipImageDown;
        goto label_67;
        label_62:
        UnityEngine.Vector2 val_39 = new UnityEngine.Vector2(x:  0.5f, y:  1f);
        val_71 = val_39.x;
        val_72 = val_39.y;
        val_15.pivot = new UnityEngine.Vector2() {x = val_71, y = val_72};
        this.bubbleTipImageUp.gameObject.SetActive(value:  true);
        this.bubbleTipImageDown.gameObject.SetActive(value:  false);
        val_73 = this.bubbleTipImageUp;
        label_67:
        UnityEngine.Rect val_42 = val_15.rect;
        UnityEngine.Vector2 val_43 = val_42.m_XMin.min;
        UnityEngine.Vector2 val_44 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_43.x, y = val_43.y}, b:  new UnityEngine.Vector2() {x = val_22.x, y = val_22.y});
        UnityEngine.Rect val_45 = val_15.rect;
        UnityEngine.Vector2 val_46 = val_45.m_XMin.max;
        UnityEngine.Vector2 val_47 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_46.x, y = val_46.y}, b:  new UnityEngine.Vector2() {x = val_22.x, y = val_22.y});
        UnityEngine.Vector2 val_48 = UnityEngine.Vector2.zero;
        val_74 = val_48.x;
        val_75 = val_48.y;
        float val_69 = (float)val_1.left;
        val_69 = val_26.x + val_69;
        if(val_44.x < 0)
        {
                float val_70 = (float)val_1.left;
            val_70 = val_26.x + val_70;
            val_70 = val_70 - val_44.x;
            val_74 = val_74 + val_70;
        }
        
        float val_71 = (float)val_1.right;
        val_71 = val_30.x - val_71;
        if(val_47.x > val_71)
        {
                float val_72 = (float)val_1.right;
            val_72 = val_30.x - val_72;
            val_72 = val_47.x - val_72;
            val_74 = val_74 - val_72;
        }
        
        float val_73 = (float)val_1.bottom;
        val_73 = val_26.y + val_73;
        if(val_44.y < 0)
        {
                float val_74 = (float)val_1.bottom;
            val_74 = val_26.y + val_74;
            val_74 = val_74 - val_44.y;
            val_75 = val_75 + val_74;
        }
        
        float val_75 = (float)val_1.top;
        val_75 = val_30.y - val_75;
        if(val_47.y > val_75)
        {
                float val_76 = (float)val_1.top;
            val_76 = val_30.y - val_76;
            val_76 = val_47.y - val_76;
            val_75 = val_75 - val_76;
        }
        
        val_76 = val_22.x;
        UnityEngine.Vector2 val_57 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = val_76, y = val_22.y}, b:  new UnityEngine.Vector2() {x = val_74, y = val_75});
        val_15.anchoredPosition = new UnityEngine.Vector2() {x = val_57.x, y = val_57.y};
        UnityEngine.Vector2 val_58 = val_15.sizeDelta;
        float val_78 = val_58.x;
        UnityEngine.Vector2 val_59 = val_15.anchoredPosition;
        if(val_73 == 0)
        {
                return;
        }
        
        float val_77 = 0.8f;
        val_77 = val_78 * val_77;
        val_78 = val_77 * 0.5f;
        val_76 = val_76 - val_59.x;
        val_68 = val_73.rectTransform;
        val_76 = UnityEngine.Mathf.Clamp(value:  val_76, min:  -val_78, max:  val_78);
        UnityEngine.Vector2 val_64 = val_73.rectTransform.anchoredPosition;
        UnityEngine.Vector2 val_65 = new UnityEngine.Vector2(x:  val_76, y:  val_64.y);
        val_68.anchoredPosition = new UnityEngine.Vector2() {x = val_65.x, y = val_65.y};
        return;
        label_37:
        label_42:
        label_52:
    }
    private void HideSpeechBubble()
    {
        if(this.bubbleObject != null)
        {
                this.bubbleObject.SetActive(value:  false);
            return;
        }
        
        throw new NullReferenceException();
    }
    private UnityEngine.Vector2 WorldToCanvasPosition(UnityEngine.RectTransform canvasRect, UnityEngine.Camera canvasCamera, UnityEngine.Vector3 position)
    {
        UnityEngine.Vector3 val_1 = canvasCamera.WorldToViewportPoint(position:  new UnityEngine.Vector3() {x = position.x, y = position.y, z = position.z});
        UnityEngine.Vector2 val_2 = UnityEngine.Vector2.op_Implicit(v:  new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z});
        float val_11 = val_2.x;
        UnityEngine.Vector2 val_3 = canvasRect.sizeDelta;
        val_11 = val_11 * val_3.x;
        UnityEngine.Vector2 val_4 = canvasRect.sizeDelta;
        UnityEngine.Vector2 val_6 = canvasRect.sizeDelta;
        float val_12 = val_6.x;
        UnityEngine.Vector2 val_7 = canvasRect.pivot;
        val_7.x = val_12 * val_7.x;
        val_12 = val_11 - val_7.x;
        UnityEngine.Vector2 val_8 = canvasRect.sizeDelta;
        UnityEngine.Vector2 val_9 = canvasRect.pivot;
        val_9.y = (val_2.y * val_4.y) - (val_8.y * val_9.y);
        return new UnityEngine.Vector2() {x = val_12, y = val_9.y};
    }
    private void CloseWindow()
    {
        this.CloseWindow(immediate:  false);
    }
    private void CloseWindow(bool immediate)
    {
        var val_14;
        BlockPuzzleMagic.FtuxId val_15;
        var val_16;
        val_14 = null;
        val_14 = null;
        val_15 = BBLFTUXDemoWindow.currentFtuxFlag;
        if((val_15 == 0) || (this.stepCompletedByPlayer == false))
        {
            goto label_50;
        }
        
        val_14 = null;
        val_15 = BBLFTUXDemoWindow.currentFtuxFlag;
        if(val_15 == 1)
        {
            goto label_10;
        }
        
        val_14 = null;
        val_15 = BBLFTUXDemoWindow.currentFtuxFlag;
        if(val_15 == 2)
        {
            goto label_10;
        }
        
        val_14 = null;
        val_15 = BBLFTUXDemoWindow.currentFtuxFlag;
        if(val_15 != 3)
        {
            goto label_13;
        }
        
        label_10:
        val_14 = null;
        if(BBLFTUXDemoWindow.currentFtuxFlag == 2)
        {
                BlockPuzzleMagic.BBLGameplayUIController val_1 = MonoSingleton<BlockPuzzleMagic.BBLGameplayUIController>.Instance;
            val_1.topStatViewCanvasGroup.alpha = 1f;
            BlockPuzzleMagic.BBLGameplayUIController val_2 = MonoSingleton<BlockPuzzleMagic.BBLGameplayUIController>.Instance;
            val_2.topGameplayCanvasGroup.alpha = 1f;
        }
        
        MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance.GameOver(success:  true);
        label_50:
        MonoSingleton<BlockPuzzleMagic.BlockShapeSpawner>.Instance.Interactable = true;
        BlockPuzzleMagic.GamePlay val_5 = MonoSingleton<BlockPuzzleMagic.GamePlay>.Instance;
        val_5.<GridCellsInteractable>k__BackingField = true;
        if((MonoSingleton<BlockPuzzleMagic.BBLGameplayUIController>.Instance) != 0)
        {
                BlockPuzzleMagic.BBLGameplayUIController val_8 = MonoSingleton<BlockPuzzleMagic.BBLGameplayUIController>.Instance;
            val_8.buttonPowerupTrash.BlockRaycasts = true;
            BlockPuzzleMagic.BBLGameplayUIController val_9 = MonoSingleton<BlockPuzzleMagic.BBLGameplayUIController>.Instance;
            val_9.buttonPowerupBomb.BlockRaycasts = true;
            BlockPuzzleMagic.BBLGameplayUIController val_10 = MonoSingleton<BlockPuzzleMagic.BBLGameplayUIController>.Instance;
            val_10.buttonPowerupFill.BlockRaycasts = true;
        }
        
        val_16 = null;
        val_16 = null;
        BBLFTUXDemoWindow.currentFtuxFlag = 0;
        BlockPuzzleMagic.BBLGameplayUIHelper.CloseGameplayOverlay(immediate:  immediate, onOverlayClosed:  new System.Action(object:  this, method:  System.Void BBLFTUXDemoWindow::<CloseWindow>b__42_0()));
        return;
        label_13:
        BestBlocksPlayer.Instance.SetFtuxStatus(ftuxId:  BBLFTUXDemoWindow.currentFtuxFlag, completed:  true);
        goto label_50;
    }
    private void MovePointerAlong(UnityEngine.Vector3 startPos, UnityEngine.Vector3 endPos, float moveAlongDuration, DG.Tweening.LoopType moveAlongLoopType = 0, DG.Tweening.Ease moveAlongEaseType = 1)
    {
        if(this.pointerMoveSeq != null)
        {
                DG.Tweening.TweenExtensions.Kill(t:  this.pointerMoveSeq, complete:  false);
        }
        
        UnityEngine.Vector3 val_3 = this.gameObject.transform.position;
        UnityEngine.Vector3 val_4 = new UnityEngine.Vector3(x:  startPos.x, y:  startPos.y, z:  val_3.z);
        UnityEngine.Vector3 val_7 = this.gameObject.transform.position;
        UnityEngine.Vector3 val_8 = new UnityEngine.Vector3(x:  endPos.x, y:  endPos.y, z:  val_7.z);
        this.handCursor.transform.position = new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z};
        UnityEngine.Color val_10 = this.handCursor.color;
        UnityEngine.Color val_11 = this.handCursor.color;
        UnityEngine.Color val_12 = this.handCursor.color;
        UnityEngine.Color val_13 = new UnityEngine.Color(r:  val_10.r, g:  val_11.g, b:  val_12.b, a:  0f);
        this.handCursor.color = new UnityEngine.Color() {r = val_13.r, g = val_13.g, b = val_13.b, a = val_13.a};
        this.handCursor.gameObject.SetActive(value:  true);
        DG.Tweening.Sequence val_15 = DG.Tweening.DOTween.Sequence();
        this.pointerMoveSeq = val_15;
        DG.Tweening.Sequence val_16 = DG.Tweening.TweenSettingsExtensions.SetAutoKill<DG.Tweening.Sequence>(t:  val_15, autoKillOnCompletion:  false);
        DG.Tweening.Sequence val_17 = DG.Tweening.TweenSettingsExtensions.SetLoops<DG.Tweening.Sequence>(t:  this.pointerMoveSeq, loops:  0, loopType:  moveAlongLoopType);
        DG.Tweening.Sequence val_19 = DG.Tweening.TweenSettingsExtensions.Append(s:  this.pointerMoveSeq, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.handCursor, endValue:  1f, duration:  0.15f));
        DG.Tweening.Sequence val_23 = DG.Tweening.TweenSettingsExtensions.Append(s:  this.pointerMoveSeq, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOMove(target:  this.handCursor.transform, endValue:  new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z}, duration:  moveAlongDuration, snapping:  false), ease:  moveAlongEaseType));
        DG.Tweening.Sequence val_25 = DG.Tweening.TweenSettingsExtensions.Append(s:  this.pointerMoveSeq, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.handCursor, endValue:  0f, duration:  0.15f));
        DG.Tweening.Sequence val_26 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  this.pointerMoveSeq, interval:  0.5f);
    }
    private void HidePointer()
    {
        if(this.pointerMoveSeq != null)
        {
                DG.Tweening.TweenExtensions.Kill(t:  this.pointerMoveSeq, complete:  false);
        }
        
        this.handCursor.gameObject.SetActive(value:  false);
    }
    private void ShowArrowHead(UnityEngine.Vector3 from, UnityEngine.Vector3 to)
    {
        UnityEngine.RectTransform val_24 = this.arrowHead.canvas.gameObject.transform;
        UnityEngine.Camera val_5 = this.arrowHead.canvas.worldCamera;
        if(val_24 != null)
        {
                if(null != null)
        {
            goto label_14;
        }
        
        }
        
        UnityEngine.Vector2 val_6 = val_5.WorldToCanvasPosition(canvasRect:  val_24 = this.arrowHead.canvas.gameObject.transform, canvasCamera:  val_5, position:  new UnityEngine.Vector3() {x = from.x, y = from.y, z = from.z});
        val_24 = this.arrowHead.canvas.gameObject.transform;
        UnityEngine.Camera val_11 = this.arrowHead.canvas.worldCamera;
        if(val_24 != null)
        {
                if(null != null)
        {
            goto label_14;
        }
        
        }
        
        UnityEngine.Vector2 val_12 = val_11.WorldToCanvasPosition(canvasRect:  val_24, canvasCamera:  val_11, position:  new UnityEngine.Vector3() {x = to.x, y = to.y, z = to.z});
        this.arrowHead.gameObject.SetActive(value:  true);
        this.arrowHead.rectTransform.anchoredPosition = new UnityEngine.Vector2() {x = val_6.x, y = val_6.y};
        UnityEngine.Vector2 val_16 = this.arrowHead.rectTransform.sizeDelta;
        this.arrowHead.rectTransform.sizeDelta = new UnityEngine.Vector2() {x = val_16.x, y = UnityEngine.Vector2.Distance(a:  new UnityEngine.Vector2() {x = val_6.x, y = val_6.y}, b:  new UnityEngine.Vector2() {x = val_12.x, y = val_12.y})};
        UnityEngine.Vector2 val_19 = UnityEngine.Vector2.op_Subtraction(a:  new UnityEngine.Vector2() {x = val_12.x, y = val_12.y}, b:  new UnityEngine.Vector2() {x = val_6.x, y = val_6.y});
        UnityEngine.Vector3 val_23 = new UnityEngine.Vector3(x:  0f, y:  0f, z:  (val_19.y * 57.29578f) + (-90f));
        this.arrowHead.rectTransform.localEulerAngles = new UnityEngine.Vector3() {x = val_23.x, y = val_23.y, z = val_23.z};
        return;
        label_14:
    }
    private void HideArrowHead()
    {
        this.arrowHead.gameObject.SetActive(value:  false);
    }
    public void OnSkipTutorialClick()
    {
        MonoSingleton<WGFTUXManager>.Instance.SkipTutorial();
        this.CloseWindow(immediate:  false);
    }
    public BBLFTUXDemoWindow()
    {
    
    }
    private static BBLFTUXDemoWindow()
    {
    
    }
    private void <DisplayFTUXStepDelayed>b__36_0()
    {
        null = null;
        this.DisplayFTUXStep(stage:  BBLFTUXDemoWindow.currentFtuxFlag, targetGO:  this.targetFtuxGO);
    }
    private void <CloseWindow>b__42_0()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }

}
