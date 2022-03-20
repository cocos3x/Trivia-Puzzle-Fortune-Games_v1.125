using UnityEngine;
public class GameMaskOverlay : MonoSingleton<GameMaskOverlay>
{
    // Fields
    private UnityEngine.Camera overlayCam;
    private UnityEngine.Canvas overlayCanvas;
    private UnityEngine.CanvasGroup overlayCanvasGroup;
    private UnityEngine.RectTransform overlayObjectContainer;
    private UnityEngine.CanvasGroup backgroundCanvasGroup;
    private UnityEngine.UI.Image backgroundImage;
    private UnityEngine.Color backgroundColor;
    private float bgFadeInDuration;
    private float bgFadeOutDuration;
    private System.Collections.Generic.Dictionary<int, OverlaidObject> overlaidObjectsDict;
    private System.Collections.Generic.Dictionary<int, UnityEngine.Transform> standInObjectsDict;
    private System.Collections.Generic.Dictionary<int, UnityEngine.Camera> overlaidObjectsParentCamera;
    private DG.Tweening.Tween backgroundTween;
    private bool blockRaycast;
    public System.Action OnOverlayOpened;
    public System.Action OnOverlayClosed;
    
    // Properties
    public bool BlockRaycasts { get; set; }
    public bool Interactable { get; set; }
    public float Alpha { get; set; }
    
    // Methods
    public bool get_BlockRaycasts()
    {
        return (bool)this.blockRaycast;
    }
    public void set_BlockRaycasts(bool value)
    {
        bool val_1 = value;
        this.blockRaycast = val_1;
        if(this.overlayCanvasGroup != null)
        {
                this.overlayCanvasGroup.blocksRaycasts = val_1;
            return;
        }
        
        throw new NullReferenceException();
    }
    public bool get_Interactable()
    {
        if(this.overlayCanvasGroup != null)
        {
                return this.overlayCanvasGroup.interactable;
        }
        
        throw new NullReferenceException();
    }
    public void set_Interactable(bool value)
    {
        if(this.overlayCanvasGroup != null)
        {
                this.overlayCanvasGroup.interactable = value;
            return;
        }
        
        throw new NullReferenceException();
    }
    public float get_Alpha()
    {
        if(this.overlayCanvasGroup != null)
        {
                return this.overlayCanvasGroup.alpha;
        }
        
        throw new NullReferenceException();
    }
    public void set_Alpha(float value)
    {
        if(this.overlayCanvasGroup != null)
        {
                this.overlayCanvasGroup.alpha = value;
            return;
        }
        
        throw new NullReferenceException();
    }
    public override void InitMonoSingleton()
    {
        this.backgroundCanvasGroup.alpha = 0f;
        this.SetOptions(bgColor:  new System.Nullable<UnityEngine.Color>() {HasValue = true}, fadeInDuration:  0.15f, fadeOutDuration:  0.15f);
        this.overlayCam.enabled = false;
        this.overlayCanvas.enabled = false;
        UnityEngine.Vector3 val_3 = UnityEngine.Vector3.zero;
        this.gameObject.transform.position = new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z};
    }
    public void SetOptions(System.Nullable<UnityEngine.Color> bgColor, float fadeInDuration = 0.15, float fadeOutDuration = 0.15)
    {
        if((bgColor.HasValue + 16) != 0)
        {
                UnityEngine.Color val_1 = bgColor.Value;
            this.backgroundColor = val_1;
            mem[1152921517559377260] = val_1.g;
            mem[1152921517559377264] = val_1.b;
            mem[1152921517559377268] = val_1.a;
        }
        
        this.bgFadeInDuration = fadeInDuration;
        this.bgFadeOutDuration = fadeOutDuration;
    }
    public void ShowOverlay(UnityEngine.Transform[] contentToOverlay)
    {
        var val_19;
        var val_21;
        DG.Tweening.Tween val_30;
        System.Collections.Generic.Dictionary<T, U> val_31;
        var val_32;
        var val_33;
        UnityEngine.Transform val_34;
        var val_35;
        if((this.backgroundTween != null) && ((DG.Tweening.TweenExtensions.IsPlaying(t:  this.backgroundTween)) != false))
        {
                val_30 = this.backgroundTween;
            if(this.backgroundTween.onComplete != null)
        {
                this.backgroundTween.onComplete.Invoke();
            val_30 = this.backgroundTween;
        }
        
            DG.Tweening.TweenExtensions.Kill(t:  val_30, complete:  false);
        }
        
        this.overlayCam.enabled = true;
        this.overlayCanvas.enabled = true;
        this.overlayCanvasGroup.alpha = 1f;
        this.overlayCanvasGroup.blocksRaycasts = this.blockRaycast;
        System.Collections.Generic.Dictionary<System.Int32, System.Boolean> val_2 = null;
        val_31 = val_2;
        val_2 = new System.Collections.Generic.Dictionary<System.Int32, System.Boolean>();
        if(contentToOverlay != null)
        {
                int val_29 = contentToOverlay.Length;
            if(val_29 >= 1)
        {
                val_32 = 1152921504765632512;
            val_33 = 1152921517559538912;
            val_29 = val_29 & 4294967295;
            do
        {
            if(1152921506814915152 != 0)
        {
                int val_4 = 1152921506814915152.GetInstanceID();
            if((this.overlaidObjectsDict.ContainsKey(key:  val_4)) != false)
        {
                val_2.Add(key:  val_4, value:  true);
        }
        else
        {
                var val_30 = contentToOverlay[32];
            val_34 = 1152921506814915152.parent;
            OverlaidObject val_8 = new OverlaidObject(_transform:  1152921506814915152, _parent:  val_34, _siblingIndex:  1152921506814915152.GetSiblingIndex());
            this.overlaidObjectsDict.Add(key:  val_4, value:  new OverlaidObject() {transform = val_8.transform, parent = val_8.transform, siblingIndex = val_8.siblingIndex});
            val_33 = val_33;
            val_31 = val_31;
            val_32 = 1152921504765632512;
        }
        
        }
        
            val_35 = 0 + 1;
        }
        while(val_35 < (contentToOverlay.Length << ));
        
            if(contentToOverlay.Length >= 1)
        {
                val_35 = 1152921517559553248;
            val_33 = 1152921517559554272;
            var val_32 = 0;
            do
        {
            if(1152921506814915152 != 0)
        {
                int val_10 = 1152921506814915152.GetInstanceID();
            if((EnumerableExtentions.GetOrDefault<System.Int32, System.Boolean>(dic:  val_2, key:  val_10, defaultValue:  false)) != true)
        {
                if((this.standInObjectsDict.ContainsKey(key:  val_10)) != true)
        {
                OverlaidObject val_13 = this.overlaidObjectsDict.Item[val_10];
            this.standInObjectsDict.Add(key:  val_10, value:  this.overlaidObjectsDict.CreateStandInGameObject(original:  val_8.transform));
            val_33 = val_33;
            val_35 = val_35;
            val_34 = contentToOverlay[32];
        }
        
            OverlaidObject val_15 = this.overlaidObjectsDict.Item[val_10];
            UnityEngine.Vector3 val_16 = this.TransformPositionToOverlaySpace(objectTransform:  val_8.transform);
            OverlaidObject val_17 = this.overlaidObjectsDict.Item[val_10];
            val_8.transform.SetParent(p:  this.overlayObjectContainer);
            OverlaidObject val_18 = this.overlaidObjectsDict.Item[val_10];
            val_19.position = new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z};
            OverlaidObject val_20 = this.overlaidObjectsDict.Item[val_10];
            val_21.SetAsLastSibling();
        }
        
        }
        
            val_32 = val_32 + 1;
        }
        while(val_32 < (contentToOverlay.Length << ));
        
        }
        
        }
        
        }
        
        DG.Tweening.Sequence val_22 = DG.Tweening.DOTween.Sequence();
        DG.Tweening.Sequence val_25 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_22, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.backgroundCanvasGroup, endValue:  1f, duration:  this.bgFadeInDuration), ease:  1));
        DG.Tweening.Sequence val_28 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_22, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOColor(target:  this.backgroundImage, endValue:  new UnityEngine.Color() {r = this.backgroundColor, g = this.bgFadeInDuration, b = val_16.z}, duration:  this.bgFadeInDuration), ease:  1));
        this.backgroundTween = val_22;
        if(this.OnOverlayOpened == null)
        {
                return;
        }
        
        this.OnOverlayOpened.Invoke();
    }
    public UnityEngine.Vector3 TransformPositionToOverlaySpace(UnityEngine.Transform objectTransform)
    {
        UnityEngine.Vector3 val_2 = objectTransform.position;
        UnityEngine.Vector3 val_3 = this.GetParentCamera(objectTransform:  objectTransform).WorldToScreenPoint(position:  new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z});
        return this.overlayCam.ScreenToWorldPoint(position:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z});
    }
    public void CloseOverlay(System.Action onClosed)
    {
        this.CloseOverlay(forceImmediate:  false, onClosed:  onClosed);
    }
    public void CloseOverlay(bool forceImmediate, System.Action onClosed)
    {
        DG.Tweening.Tween val_8;
        GameMaskOverlay.<>c__DisplayClass30_0 val_1 = new GameMaskOverlay.<>c__DisplayClass30_0();
        .<>4__this = this;
        .onClosed = onClosed;
        if((this.backgroundTween != null) && ((DG.Tweening.TweenExtensions.IsPlaying(t:  this.backgroundTween)) != false))
        {
                val_8 = this.backgroundTween;
            if(this.backgroundTween.onComplete != null)
        {
                this.backgroundTween.onComplete.Invoke();
            val_8 = this.backgroundTween;
        }
        
            DG.Tweening.TweenExtensions.Kill(t:  val_8, complete:  false);
        }
        
        .closeAction = new System.Action(object:  val_1, method:  System.Void GameMaskOverlay.<>c__DisplayClass30_0::<CloseOverlay>b__0());
        if(forceImmediate != false)
        {
                this.backgroundCanvasGroup.alpha = 0f;
            (GameMaskOverlay.<>c__DisplayClass30_0)[1152921517560405408].closeAction.Invoke();
            return;
        }
        
        this.backgroundTween = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.backgroundCanvasGroup, endValue:  0f, duration:  this.bgFadeOutDuration), ease:  1), action:  new DG.Tweening.TweenCallback(object:  val_1, method:  System.Void GameMaskOverlay.<>c__DisplayClass30_0::<CloseOverlay>b__1()));
    }
    public void FlushOverlaidObjects()
    {
        var val_3;
        int val_4;
        UnityEngine.Object val_6;
        System.Collections.Generic.Dictionary<System.Int32, OverlaidObject> val_34;
        int val_35;
        System.Collections.Generic.Dictionary<System.Int32, OverlaidObject> val_36;
        var val_37;
        System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.Int32>> val_1 = null;
        val_34 = val_1;
        val_35 = public System.Void System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.Int32>>::.ctor();
        val_1 = new System.Collections.Generic.Dictionary<System.Int32, System.Collections.Generic.List<System.Int32>>();
        val_36 = this.overlaidObjectsDict;
        if(val_36 == null)
        {
                throw new NullReferenceException();
        }
        
        Dictionary.Enumerator<TKey, TValue> val_2 = val_36.GetEnumerator();
        label_7:
        val_35 = public System.Boolean Dictionary.Enumerator<System.Int32, OverlaidObject>::MoveNext();
        if(val_6.MoveNext() == false)
        {
            goto label_2;
        }
        
        val_36 = val_3;
        if(val_36 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_35 = 0;
        int val_8 = val_36.GetInstanceID();
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_1.ContainsKey(key:  val_8)) != true)
        {
                val_1.Add(key:  val_8, value:  new System.Collections.Generic.List<System.Int32>());
        }
        
        val_35 = val_8;
        System.Collections.Generic.List<System.Int32> val_11 = val_1.Item[val_35];
        if(val_11 == null)
        {
                throw new NullReferenceException();
        }
        
        val_11.Add(item:  val_4);
        goto label_7;
        label_2:
        val_35 = public System.Void Dictionary.Enumerator<System.Int32, OverlaidObject>::Dispose();
        val_6.Dispose();
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        Dictionary.Enumerator<TKey, TValue> val_12 = val_1.GetEnumerator();
        label_11:
        if(val_6.MoveNext() == false)
        {
            goto label_9;
        }
        
        System.Comparison<System.Int32> val_14 = null;
        val_35 = this;
        val_14 = new System.Comparison<System.Int32>(object:  this, method:  System.Int32 GameMaskOverlay::<FlushOverlaidObjects>b__31_0(int a, int b));
        if(val_4 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_4.Sort(comparison:  val_14);
        goto label_11;
        label_9:
        val_6.Dispose();
        Dictionary.Enumerator<TKey, TValue> val_15 = val_1.GetEnumerator();
        goto label_14;
        label_30:
        if((val_4 != 0) && ((val_4 + 24) >= 1))
        {
                var val_36 = 8;
            do
        {
            val_34 = this.overlaidObjectsDict;
            var val_16 = val_36 - 8;
            if(val_16 >= (val_4 + 24))
        {
                val_36 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
            val_35 = mem[val_4 + 16 + 32];
            val_35 = val_4 + 16 + 32;
            if((val_34.ContainsKey(key:  val_35)) != false)
        {
                val_34 = this.overlaidObjectsDict;
            if(val_16 >= (val_4 + 24))
        {
                val_36 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
            val_35 = mem[val_4 + 16 + 32];
            val_35 = val_4 + 16 + 32;
            OverlaidObject val_18 = val_34.Item[val_35];
            val_34 = this.standInObjectsDict;
            if(val_16 >= (val_4 + 24))
        {
                val_36 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
            val_34 = val_34.Item[val_4 + 16 + 32];
            val_35 = 0;
            if(val_34 != val_35)
        {
                val_34 = this.standInObjectsDict;
            if(val_16 >= (val_4 + 24))
        {
                val_36 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
            val_35 = mem[val_4 + 16 + 32];
            val_35 = val_4 + 16 + 32;
            UnityEngine.Transform val_21 = val_34.Item[val_35];
            if(val_21 == null)
        {
                throw new NullReferenceException();
        }
        
            val_6.Restore(_siblingIndex:  val_21.GetSiblingIndex());
        }
        else
        {
                val_6.Restore();
        }
        
        }
        
            val_36 = val_36 + 1;
        }
        while((val_36 - 7) < (val_4 + 24));
        
        }
        
        label_14:
        if(val_6.MoveNext() == true)
        {
            goto label_30;
        }
        
        val_35 = public System.Void Dictionary.Enumerator<System.Int32, System.Collections.Generic.List<System.Int32>>::Dispose();
        val_6.Dispose();
        var val_37 = 0;
        if(val_37 != 1)
        {
                var val_25 = (412 == 412) ? 1 : 0;
            val_25 = ((val_37 >= 0) ? 1 : 0) & val_25;
            val_37 = val_37 - val_25;
            val_37 = val_37 + 1;
            val_37 = (long)val_37;
        }
        else
        {
                val_37 = 0;
        }
        
        val_36 = this.standInObjectsDict;
        if(val_36 == null)
        {
                throw new NullReferenceException();
        }
        
        Dictionary.Enumerator<TKey, TValue> val_27 = val_36.GetEnumerator();
        label_51:
        if(val_6.MoveNext() == false)
        {
            goto label_34;
        }
        
        val_34 = val_4;
        val_35 = 0;
        if(val_34 == val_35)
        {
            goto label_51;
        }
        
        val_36 = this.overlaidObjectsDict;
        if(val_36 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = val_4;
        if((val_36.ContainsKey(key:  val_35)) == false)
        {
            goto label_43;
        }
        
        val_36 = this.overlaidObjectsDict;
        if(val_36 == null)
        {
                throw new NullReferenceException();
        }
        
        OverlaidObject val_31 = val_36.Item[val_4];
        val_35 = 0;
        if(val_6 == val_35)
        {
            goto label_43;
        }
        
        val_36 = this.overlaidObjectsDict;
        if(val_36 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = val_4;
        OverlaidObject val_33 = val_36.Item[val_35];
        if(val_34 == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Vector3 val_34 = val_34.position;
        val_6.position = new UnityEngine.Vector3() {x = val_34.x, y = val_34.y, z = val_34.z};
        goto label_47;
        label_43:
        if(val_34 == 0)
        {
                throw new NullReferenceException();
        }
        
        label_47:
        UnityEngine.Object.Destroy(obj:  val_34.gameObject);
        goto label_51;
        label_34:
        val_35 = public System.Void Dictionary.Enumerator<System.Int32, UnityEngine.Transform>::Dispose();
        val_6.Dispose();
        val_36 = this.overlaidObjectsDict;
        if(val_36 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = public System.Void System.Collections.Generic.Dictionary<System.Int32, OverlaidObject>::Clear();
        val_36.Clear();
        val_36 = this.standInObjectsDict;
        if(val_36 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35 = public System.Void System.Collections.Generic.Dictionary<System.Int32, UnityEngine.Transform>::Clear();
        val_36.Clear();
        val_36 = this.overlaidObjectsParentCamera;
        if(val_36 == null)
        {
                throw new NullReferenceException();
        }
        
        val_36.Clear();
    }
    public UnityEngine.Transform GetStandInTransformForObject(UnityEngine.Transform original)
    {
        var val_5;
        if((this.standInObjectsDict.ContainsKey(key:  original.GetInstanceID())) != false)
        {
                UnityEngine.Transform val_4 = this.standInObjectsDict.Item[original.GetInstanceID()];
            return (UnityEngine.Transform)val_5;
        }
        
        val_5 = 0;
        return (UnityEngine.Transform)val_5;
    }
    private UnityEngine.Transform CreateStandInGameObject(UnityEngine.Transform original)
    {
        var val_28;
        UnityEngine.Transform val_1 = original.transform;
        if(val_1 != null)
        {
                if(null != null)
        {
            goto label_3;
        }
        
        }
        
        UnityEngine.UI.LayoutElement val_3 = original.gameObject.GetComponent<UnityEngine.UI.LayoutElement>();
        if(val_3 != 0)
        {
                val_28 = val_3;
        }
        else
        {
                val_28 = 0;
        }
        
        UnityEngine.GameObject val_8 = new UnityEngine.GameObject(name:  "[MaskStandIn] " + original.gameObject.name);
        val_8.transform.SetParent(p:  original.parent);
        val_8.transform.SetSiblingIndex(index:  original.GetSiblingIndex());
        UnityEngine.Vector3 val_14 = UnityEngine.Vector3.one;
        val_8.transform.localScale = new UnityEngine.Vector3() {x = val_14.x, y = val_14.y, z = val_14.z};
        UnityEngine.Vector3 val_16 = UnityEngine.Vector3.zero;
        val_8.transform.localPosition = new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z};
        UnityEngine.RectTransform val_17 = val_8.AddComponent<UnityEngine.RectTransform>();
        UnityEngine.UI.LayoutElement val_18 = val_8.AddComponent<UnityEngine.UI.LayoutElement>();
        UnityEngine.Rect val_19 = val_1.rect;
        float val_20 = val_19.m_XMin.width;
        UnityEngine.Rect val_21 = val_1.rect;
        float val_22 = val_21.m_XMin.height;
        var val_23 = val_28 & 1;
        UnityEngine.Vector2 val_24 = val_1.anchorMin;
        val_17.anchorMin = new UnityEngine.Vector2() {x = val_24.x, y = val_24.y};
        UnityEngine.Vector2 val_25 = val_1.anchorMax;
        val_17.anchorMax = new UnityEngine.Vector2() {x = val_25.x, y = val_25.y};
        UnityEngine.Vector2 val_26 = val_1.sizeDelta;
        val_17.sizeDelta = new UnityEngine.Vector2() {x = val_26.x, y = val_26.y};
        UnityEngine.Vector2 val_27 = val_1.anchoredPosition;
        val_17.anchoredPosition = new UnityEngine.Vector2() {x = val_27.x, y = val_27.y};
        return (UnityEngine.Transform)val_8.transform;
        label_3:
    }
    private UnityEngine.Camera GetParentCamera(UnityEngine.Transform objectTransform)
    {
        var val_14;
        UnityEngine.Object val_15;
        UnityEngine.Object val_17;
        var val_18;
        int val_1 = objectTransform.GetInstanceID();
        if((this.overlaidObjectsParentCamera.ContainsKey(key:  val_1)) == true)
        {
                return this.overlaidObjectsParentCamera.Item[val_1];
        }
        
        val_14 = 1152921504765632512;
        val_15 = objectTransform.GetComponentInParent<UnityEngine.Canvas>();
        if(val_15 != 0)
        {
                if(val_15.isRootCanvas != true)
        {
                val_15 = val_15.rootCanvas;
        }
        
        }
        
        if(val_15 != 0)
        {
                UnityEngine.Camera val_8 = val_15.worldCamera;
        }
        
        val_17 = objectTransform.GetComponentInParent<UnityEngine.Camera>();
        if(val_17 != 0)
        {
            goto label_26;
        }
        
        val_14 = UnityEngine.Camera.allCameras;
        if(val_11.Length < 1)
        {
            goto label_26;
        }
        
        val_18 = 0;
        do
        {
            UnityEngine.Vector3 val_12 = objectTransform.position;
            UnityEngine.Vector3 val_13 = val_14[val_18].WorldToViewportPoint(position:  new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z});
            if(((val_13.y <= 1f) && (val_13.y >= 0f)) && (val_13.x >= 0f))
        {
                if(val_13.x <= 1f)
        {
            goto label_24;
        }
        
        }
        
            val_18 = val_18 + 1;
        }
        while(val_18 < val_11.Length);
        
        goto label_26;
        label_24:
        val_17 = mem[val_11[0x0] + 32];
        val_17 = val_11[0x0] + 32;
        label_26:
        this.overlaidObjectsParentCamera.Add(key:  val_1, value:  val_17);
        return this.overlaidObjectsParentCamera.Item[val_1];
    }
    public GameMaskOverlay()
    {
        UnityEngine.Color val_1 = new UnityEngine.Color(r:  0f, g:  0f, b:  0f, a:  0.65f);
        this.bgFadeInDuration = 0f;
        this.backgroundColor = val_1.r;
        this.overlaidObjectsDict = new System.Collections.Generic.Dictionary<System.Int32, OverlaidObject>();
        this.standInObjectsDict = new System.Collections.Generic.Dictionary<System.Int32, UnityEngine.Transform>();
        this.overlaidObjectsParentCamera = new System.Collections.Generic.Dictionary<System.Int32, UnityEngine.Camera>();
        this.blockRaycast = true;
    }
    private int <FlushOverlaidObjects>b__31_0(int a, int b)
    {
        var val_2;
        int val_5;
        OverlaidObject val_1 = this.overlaidObjectsDict.Item[a];
        OverlaidObject val_4 = this.overlaidObjectsDict.Item[b];
        return (int)val_2.CompareTo(value:  val_5);
    }

}
