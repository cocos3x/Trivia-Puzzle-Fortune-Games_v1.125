using UnityEngine;
private sealed class AttackMadnessEventHandler.<PlayPointCollectionSequence>d__73 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public WGEventButtonV2_AttackMadness attackMadnessButton;
    public AttackMadnessEventHandler <>4__this;
    public WGEventButtonV2 eventProgressUI;
    public int startValue;
    public int points;
    private AttackMadnessEventHandler.<>c__DisplayClass73_0 <>8__1;
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
    public AttackMadnessEventHandler.<PlayPointCollectionSequence>d__73(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_42;
        DG.Tweening.Tweener val_43;
        float val_44;
        int val_45;
        int val_46;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_26;
        }
        
        this.<>1__state = 0;
        this.<>8__1 = new AttackMadnessEventHandler.<>c__DisplayClass73_0();
        .attackMadnessButton = this.attackMadnessButton;
        this.<>8__1.<>4__this = this.<>4__this;
        this.<>8__1.eventProgressUI = this.eventProgressUI;
        this.<>8__1.startValue = this.startValue;
        this.<>8__1.points = this.points;
        val_42 = this;
        this.<pointsToFly>5__2 = UnityEngine.Mathf.Min(a:  this.<>8__1.points, b:  10);
        mem[1152921516071352628] = 3.05175851599415E-05;
        mem[1152921516071388656] = (float)mem[1152921516071388692];
        this.<>8__1.initialProgressLabelPoints = this.<>4__this.PointsCollectedInLevel;
        float val_42 = (float)this.<pointsToFly>5__2;
        val_42 = (this.<pointFlyInterval>5__3) * val_42;
        val_42 = val_42 + (this.<pointFlyDuration>5__4);
        val_43 = DG.Tweening.TweenSettingsExtensions.OnUpdate<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.DOTween.To(setter:  new DG.Tweening.Core.DOSetter<System.Single>(object:  this.<>8__1, method:  System.Void AttackMadnessEventHandler.<>c__DisplayClass73_0::<PlayPointCollectionSequence>b__0(float x)), startValue:  (float)this.<>8__1.startValue, endValue:  (float)(this.<>8__1.points) + (this.<>8__1.startValue), duration:  val_42), ease:  1), action:  new DG.Tweening.TweenCallback(object:  this.<>8__1, method:  System.Void AttackMadnessEventHandler.<>c__DisplayClass73_0::<PlayPointCollectionSequence>b__1()));
        UnityEngine.Vector2 val_13 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Tweener>(t:  val_43, action:  new DG.Tweening.TweenCallback(object:  this.<>8__1, method:  System.Void AttackMadnessEventHandler.<>c__DisplayClass73_0::<PlayPointCollectionSequence>b__2())).GetComponent<UnityEngine.RectTransform>().sizeDelta;
        val_44 = val_13.x;
        UnityEngine.Vector2 val_15 = this.<>8__1.eventProgressUI.icon.GetComponent<UnityEngine.RectTransform>().sizeDelta;
        val_15.x = val_44 / val_15.x;
        val_45 = 0;
        this.<scale>5__5 = val_15.x;
        this.<i>5__6 = 0;
        goto label_25;
        label_1:
        val_42 = this.<pointsToFly>5__2;
        this.<>1__state = 0;
        val_45 = (this.<i>5__6) + 1;
        this.<i>5__6 = val_45;
        label_25:
        if(val_45 < val_42)
        {
                .CS$<>8__locals1 = this.<>8__1;
            UnityEngine.GameObject val_19 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.<>8__1.eventProgressUI.icon.gameObject, parent:  this.popup.transform);
            .point = val_19;
            UnityEngine.Vector3 val_22 = (AttackMadnessEventHandler.<>c__DisplayClass73_1)[1152921516071503328].CS$<>8__locals1.eventProgressUI.transform.position;
            val_19.transform.position = new UnityEngine.Vector3() {x = val_22.x, y = val_22.y, z = val_22.z};
            val_43 = DG.Tweening.DOTween.Sequence();
            UnityEngine.Transform val_24 = (AttackMadnessEventHandler.<>c__DisplayClass73_1)[1152921516071503328].point.transform;
            UnityEngine.Vector3 val_26 = val_24.transform.position;
            val_42 = 1152921509727915456;
            DG.Tweening.Sequence val_29 = DG.Tweening.TweenSettingsExtensions.Append(s:  val_43, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOMoveX(target:  val_24, endValue:  val_26.x, duration:  this.<pointFlyDuration>5__4, snapping:  false), ease:  3));
            UnityEngine.Transform val_30 = (AttackMadnessEventHandler.<>c__DisplayClass73_1)[1152921516071503328].point.transform;
            UnityEngine.Vector3 val_32 = val_30.transform.position;
            DG.Tweening.Sequence val_35 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_43, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOMoveY(target:  val_30, endValue:  val_32.y, duration:  this.<pointFlyDuration>5__4, snapping:  false), ease:  9));
            DG.Tweening.Sequence val_38 = DG.Tweening.TweenSettingsExtensions.Join(s:  val_43, t:  DG.Tweening.ShortcutExtensions.DOScale(target:  (AttackMadnessEventHandler.<>c__DisplayClass73_1)[1152921516071503328].point.transform, endValue:  this.<scale>5__5, duration:  this.<pointFlyDuration>5__4));
            DG.Tweening.Sequence val_40 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  val_43, action:  new DG.Tweening.TweenCallback(object:  new AttackMadnessEventHandler.<>c__DisplayClass73_1(), method:  System.Void AttackMadnessEventHandler.<>c__DisplayClass73_1::<PlayPointCollectionSequence>b__3()));
            val_44 = this.<pointFlyInterval>5__3;
            val_46 = 1;
            this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  val_44);
            this.<>1__state = val_46;
            return (bool)val_46;
        }
        
        label_26:
        val_46 = 0;
        return (bool)val_46;
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
