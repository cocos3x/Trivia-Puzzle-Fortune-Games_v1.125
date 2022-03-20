using UnityEngine;
public class WGAlphabetCollectionFlyout : MonoBehaviour
{
    // Fields
    private UnityEngine.GameObject progress;
    private UnityEngine.GameObject complete;
    private UnityEngine.UI.Slider progressSlider;
    private UnityEngine.UI.Text sliderLabel;
    private UnityEngine.RectTransform flyToPos;
    private UnityEngine.UI.Button completeButton;
    public bool PlayAnimation;
    private float delayBeforeClose;
    
    // Methods
    private void Awake()
    {
        if((UnityEngine.Object.op_Implicit(exists:  MainController.instance)) != false)
        {
                MainController val_3 = MainController.instance;
            val_3.onLevelComplete.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGAlphabetCollectionFlyout::onLevelComplete()));
        }
        
        SceneDictator val_5 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_7 = System.Delegate.Combine(a:  val_5.OnSceneLoaded, b:  new System.Action<SceneType>(object:  this, method:  System.Void WGAlphabetCollectionFlyout::onAnotherSceneLoaded(SceneType scene)));
        if(val_7 != null)
        {
                if(null != null)
        {
            goto label_14;
        }
        
        }
        
        val_5.OnSceneLoaded = val_7;
        return;
        label_14:
    }
    private void onAnotherSceneLoaded(SceneType scene)
    {
        if(scene == 2)
        {
                if((MonoSingleton<Alphabet2Manager>.Instance.IsCollectionBoxFull()) == false)
        {
                return;
        }
        
        }
        
        this.delayBeforeClose = 0.1f;
        UnityEngine.Coroutine val_4 = this.StartCoroutine(routine:  this.CloseAfterDelay());
    }
    private void Start()
    {
        object val_15;
        DG.Tweening.TweenCallback val_16;
        val_15 = this;
        DG.Tweening.TweenCallback val_4 = null;
        val_16 = val_4;
        val_4 = new DG.Tweening.TweenCallback(object:  this, method:  System.Void WGAlphabetCollectionFlyout::<Start>b__10_0());
        DG.Tweening.Tweener val_5 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOLocalMoveY(target:  this.gameObject.transform, endValue:  0f, duration:  0.5f, snapping:  false), action:  val_4);
        if(this.PlayAnimation != false)
        {
                this.progress.SetActive(value:  true);
            this.complete.SetActive(value:  false);
            val_16 = 1152921515419469536;
            System.Collections.Generic.List<System.String> val_7 = MonoSingleton<Alphabet2Manager>.Instance.GetCurrentCollectionBox;
            Alphabet2Manager val_8 = MonoSingleton<Alphabet2Manager>.Instance;
            float val_15 = (float)W22;
            val_15 = val_15 + (-1f);
            val_15 = val_15 / (float)val_8.tilesPerCollectionBox;
            val_15 = this.sliderLabel;
            System.Collections.Generic.List<System.String> val_10 = MonoSingleton<Alphabet2Manager>.Instance.GetCurrentCollectionBox;
            Alphabet2Manager val_12 = MonoSingleton<Alphabet2Manager>.Instance;
            string val_14 = System.String.Format(format:  "{0}/{1}", arg0:  1152921504814620671.ToString(), arg1:  val_12.tilesPerCollectionBox.ToString());
            return;
        }
        
        this.UpdateUI();
    }
    private void onLevelComplete()
    {
        this.delayBeforeClose = 1.25f;
        if((MonoSingleton<Alphabet2Manager>.Instance.IsCollectionBoxFull()) != false)
        {
                this.completeButton.interactable = false;
            UnityEngine.Coroutine val_4 = this.StartCoroutine(routine:  this.completeButton.ShowPopupAfterDelay());
        }
        
        if((UnityEngine.Object.op_Implicit(exists:  MainController.instance)) != false)
        {
                MainController val_7 = MainController.instance;
            val_7.onLevelComplete.RemoveListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGAlphabetCollectionFlyout::onLevelComplete()));
        }
        
        UnityEngine.Coroutine val_10 = this.StartCoroutine(routine:  this.CloseAfterDelay());
    }
    private System.Collections.IEnumerator ShowPopupAfterDelay()
    {
        .<>1__state = 0;
        return (System.Collections.IEnumerator)new WGAlphabetCollectionFlyout.<ShowPopupAfterDelay>d__12();
    }
    private void UpdateUI()
    {
        UnityEngine.Events.UnityAction val_15;
        if((MonoSingleton<Alphabet2Manager>.Instance.IsCollectionBoxFull()) != false)
        {
                this.progress.SetActive(value:  false);
            this.complete.SetActive(value:  true);
            UnityEngine.Events.UnityAction val_3 = null;
            val_15 = val_3;
            val_3 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGAlphabetCollectionFlyout::<UpdateUI>b__13_0());
            this.completeButton.m_OnClick.AddListener(call:  val_3);
            return;
        }
        
        this.progress.SetActive(value:  true);
        this.complete.SetActive(value:  false);
        System.Collections.Generic.List<System.String> val_5 = MonoSingleton<Alphabet2Manager>.Instance.GetCurrentCollectionBox;
        Alphabet2Manager val_6 = MonoSingleton<Alphabet2Manager>.Instance;
        float val_15 = (float)val_6.tilesPerCollectionBox;
        val_15 = (float)W22 / val_15;
        System.Collections.Generic.List<System.String> val_8 = MonoSingleton<Alphabet2Manager>.Instance.GetCurrentCollectionBox;
        val_15 = null.ToString();
        Alphabet2Manager val_10 = MonoSingleton<Alphabet2Manager>.Instance;
        string val_12 = System.String.Format(format:  "{0}/{1}", arg0:  val_15, arg1:  val_10.tilesPerCollectionBox.ToString());
        UnityEngine.Coroutine val_14 = this.StartCoroutine(routine:  this.CloseAfterDelay());
    }
    private System.Collections.IEnumerator CloseAfterDelay()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WGAlphabetCollectionFlyout.<CloseAfterDelay>d__14();
    }
    private void OnDestroy()
    {
        SceneDictator val_1 = MonoSingletonSelfGenerating<SceneDictator>.Instance;
        System.Delegate val_3 = System.Delegate.Remove(source:  val_1.OnSceneLoaded, value:  new System.Action<SceneType>(object:  this, method:  System.Void WGAlphabetCollectionFlyout::onAnotherSceneLoaded(SceneType scene)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_5;
        }
        
        }
        
        val_1.OnSceneLoaded = val_3;
        return;
        label_5:
    }
    public WGAlphabetCollectionFlyout()
    {
        this.PlayAnimation = true;
        this.delayBeforeClose = 4f;
    }
    private void <Start>b__10_0()
    {
        object val_24;
        UnityEngine.GameObject val_25;
        if(this.PlayAnimation == false)
        {
                return;
        }
        
        WGAlphabetCollectionFlyout.<>c__DisplayClass10_0 val_1 = null;
        val_24 = val_1;
        val_1 = new WGAlphabetCollectionFlyout.<>c__DisplayClass10_0();
        .<>4__this = this;
        Alphabet2Manager val_2 = MonoSingleton<Alphabet2Manager>.Instance;
        val_25 = val_2.currentAlphabetTileObject;
        .tile = val_25;
        if(val_25 == 0)
        {
                return;
        }
        
        UnityEngine.Vector3 val_8 = (WGAlphabetCollectionFlyout.<>c__DisplayClass10_0)[1152921516049699232].tile.transform.position;
        UnityEngine.Vector3 val_9 = (WGAlphabetCollectionFlyout.<>c__DisplayClass10_0)[1152921516049699232].tile.transform.root.GetComponentInChildren<UnityEngine.Camera>().WorldToScreenPoint(position:  new UnityEngine.Vector3() {x = val_8.x, y = val_8.y, z = val_8.z});
        UnityEngine.Vector3 val_13 = this.transform.root.GetComponentInChildren<UnityEngine.Camera>().ScreenToWorldPoint(position:  new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z});
        (WGAlphabetCollectionFlyout.<>c__DisplayClass10_0)[1152921516049699232].tile.transform.SetParent(p:  this.flyToPos);
        (WGAlphabetCollectionFlyout.<>c__DisplayClass10_0)[1152921516049699232].tile.transform.position = new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z};
        UnityEngine.Vector3[] val_17 = new UnityEngine.Vector3[3];
        val_17[0] = val_13;
        val_17[0] = val_13.y;
        val_17[1] = val_13.z;
        UnityEngine.Vector3 val_18 = this.flyToPos.position;
        UnityEngine.Vector3 val_19 = CUtils.GetMiddlePoint(begin:  new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z}, end:  new UnityEngine.Vector3() {x = val_18.x, y = val_18.y, z = val_18.z}, delta:  -0.3f);
        val_17[1] = val_19;
        val_17[2] = val_19.y;
        val_17[2] = val_19.z;
        UnityEngine.Vector3 val_20 = this.flyToPos.position;
        val_17[3] = val_20;
        val_17[3] = val_20.y;
        val_17[4] = val_20.z;
        DG.Tweening.TweenCallback val_22 = null;
        val_25 = val_22;
        val_22 = new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void WGAlphabetCollectionFlyout.<>c__DisplayClass10_0::<Start>b__1());
        DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions> val_23 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>>(t:  DG.Tweening.ShortcutExtensions.DOPath(target:  (WGAlphabetCollectionFlyout.<>c__DisplayClass10_0)[1152921516049699232].tile.transform, path:  val_17, duration:  0.5f, pathType:  0, pathMode:  1, resolution:  10, gizmoColor:  new System.Nullable<UnityEngine.Color>() {HasValue = true}), action:  val_22);
    }
    private void <UpdateUI>b__13_0()
    {
        WGWindowManager val_2 = MonoSingleton<WGWindowManager>.Instance.ShowUGUIMonolith<WGAlphabetCollectionBoxPopup>(showNext:  true);
        this.gameObject.SetActive(value:  false);
    }
    private void <CloseAfterDelay>b__14_0()
    {
        this.gameObject.SetActive(value:  false);
    }

}
