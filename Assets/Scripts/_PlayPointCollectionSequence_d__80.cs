using UnityEngine;
private sealed class IslandParadiseEventHandler.<PlayPointCollectionSequence>d__80 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGEventButtonV2_IslandParadise islandParadiseButton;
    public IslandParadiseEventHandler <>4__this;
    public WGEventButtonV2 eventProgressUI;
    public int startValue;
    public int points;
    private IslandParadiseEventHandler.<>c__DisplayClass80_0 <>8__1;
    public WGLevelClearPopup popup;
    private int <pointsToFly>5__2;
    private float <pointFlyInterval>5__3;
    private float <pointFlyDuration>5__4;
    private float <scale>5__5;
    private int <i>5__6;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public IslandParadiseEventHandler.<PlayPointCollectionSequence>d__80(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_41;
        DG.Tweening.Tweener val_42;
        float val_43;
        int val_44;
        int val_45;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_26;
        }
        
        this.<>1__state = 0;
        this.<>8__1 = new IslandParadiseEventHandler.<>c__DisplayClass80_0();
        .islandParadiseButton = this.islandParadiseButton;
        this.<>8__1.<>4__this = this.<>4__this;
        this.<>8__1.eventProgressUI = this.eventProgressUI;
        this.<>8__1.startValue = this.startValue;
        this.<>8__1.points = this.points;
        val_41 = this;
        this.<pointsToFly>5__2 = UnityEngine.Mathf.Min(a:  this.<>8__1.points, b:  10);
        mem[1152921516279355716] = 3.05175851599415E-05;
        mem[1152921516279391744] = (float)mem[1152921516279391780];
        this.<>8__1.initialProgressLabelPoints = this.<>4__this.<ProgressLabelPoints>k__BackingField;
        float val_41 = (float)this.<pointsToFly>5__2;
        val_41 = (this.<pointFlyInterval>5__3) * val_41;
        val_41 = val_41 + (this.<pointFlyDuration>5__4);
        val_42 = DG.Tweening.TweenSettingsExtensions.OnUpdate<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.DOTween.To(setter:  new DG.Tweening.Core.DOSetter<System.Single>(object:  this.<>8__1, method:  System.Void IslandParadiseEventHandler.<>c__DisplayClass80_0::<PlayPointCollectionSequence>b__0(float x)), startValue:  (float)this.<>8__1.startValue, endValue:  (float)(this.<>8__1.points) + (this.<>8__1.startValue), duration:  val_41), ease:  1), action:  new DG.Tweening.TweenCallback(object:  this.<>8__1, method:  System.Void IslandParadiseEventHandler.<>c__DisplayClass80_0::<PlayPointCollectionSequence>b__1()));
        UnityEngine.Vector2 val_12 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  val_42, action:  new DG.Tweening.TweenCallback(object:  this.<>8__1, method:  System.Void IslandParadiseEventHandler.<>c__DisplayClass80_0::<PlayPointCollectionSequence>b__2())).GetComponent<UnityEngine.RectTransform>().sizeDelta;
        val_43 = val_12.x;
        UnityEngine.Vector2 val_14 = this.<>8__1.eventProgressUI.icon.GetComponent<UnityEngine.RectTransform>().sizeDelta;
        val_14.x = val_43 / val_14.x;
        val_44 = 0;
        this.<scale>5__5 = val_14.x;
        this.<i>5__6 = 0;
        goto label_25;
        label_1:
        val_41 = this.<pointsToFly>5__2;
        this.<>1__state = 0;
        val_44 = (this.<i>5__6) + 1;
        this.<i>5__6 = val_44;
        label_25:
        if(val_44 < val_41)
        {
                .CS$<>8__locals1 = this.<>8__1;
            UnityEngine.GameObject val_18 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.<>8__1.eventProgressUI.icon.gameObject, parent:  this.popup.transform);
            .point = val_18;
            UnityEngine.Vector3 val_21 = (IslandParadiseEventHandler.<>c__DisplayClass80_1)[1152921516279506416].CS$<>8__locals1.eventProgressUI.icon.transform.position;
            val_18.transform.position = new UnityEngine.Vector3() {x = val_21.x, y = val_21.y, z = val_21.z};
            val_42 = DG.Tweening.DOTween.Sequence();
            UnityEngine.Transform val_23 = (IslandParadiseEventHandler.<>c__DisplayClass80_1)[1152921516279506416].point.transform;
            UnityEngine.Vector3 val_25 = val_23.transform.position;
            val_41 = 1152921509727915456;
            DG.Tweening.Sequence val_28 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_42, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOMoveX(target:  val_23, endValue:  val_25.x, duration:  this.<pointFlyDuration>5__4, snapping:  false), ease:  3));
            UnityEngine.Transform val_29 = (IslandParadiseEventHandler.<>c__DisplayClass80_1)[1152921516279506416].point.transform;
            UnityEngine.Vector3 val_31 = val_29.transform.position;
            DG.Tweening.Sequence val_34 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_42, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOMoveY(target:  val_29, endValue:  val_31.y, duration:  this.<pointFlyDuration>5__4, snapping:  false), ease:  9));
            DG.Tweening.Sequence val_37 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_42, t:  DG.Tweening.ShortcutExtensions.DOScale(target:  (IslandParadiseEventHandler.<>c__DisplayClass80_1)[1152921516279506416].point.transform, endValue:  this.<scale>5__5, duration:  this.<pointFlyDuration>5__4));
            DG.Tweening.Sequence val_39 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_42, action:  new DG.Tweening.TweenCallback(object:  new IslandParadiseEventHandler.<>c__DisplayClass80_1(), method:  System.Void IslandParadiseEventHandler.<>c__DisplayClass80_1::<PlayPointCollectionSequence>b__3()));
            val_43 = this.<pointFlyInterval>5__3;
            val_45 = 1;
            this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  val_43);
            this.<>1__state = val_45;
            return (bool)val_45;
        }
        
        label_26:
        val_45 = 0;
        return (bool)val_45;
    }
    private object System.Collections.Generic.IEnumerator<System.Object>.get_Current()
    {
        return (object)this.<>2__current;
    }
    private void System.Collections.IEnumerator.Reset()
    {
        throw new System.NotSupportedException();
    }
    private object System.Collections.IEnumerator.get_Current()
    {
        return (object)this.<>2__current;
    }

}
