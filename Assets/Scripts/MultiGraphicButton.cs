using UnityEngine;
public class MultiGraphicButton : Button
{
    // Fields
    public UnityEngine.UI.Graphic[] additionalGraphics;
    protected float disabledAlpha;
    public UnityEngine.UI.Graphic[] tintGraphics;
    protected UnityEngine.Color pressedTint;
    protected UnityEngine.Color disabledTint;
    protected float tintFadeDuration;
    protected bool autoGetTintGraphics;
    public bool useOverlay;
    public UnityEngine.UI.Image[] overlays;
    public bool useOverlayWhenPressed;
    public UnityEngine.UI.Image[] pressedOverlays;
    protected UnityEngine.RectTransform[] offsetTransforms;
    protected MultiGraphicButton.TransformType pressedOffsetType;
    protected UnityEngine.Vector2 pressedOffset;
    protected UnityEngine.RectTransform[] scalingTransforms;
    protected MultiGraphicButton.TransformType pressedScalingType;
    protected UnityEngine.Vector2 pressedScale;
    protected System.Collections.Generic.List<UnityEngine.Vector2> initialOffsetTransformsPos;
    protected System.Collections.Generic.List<UnityEngine.Vector3> initialScalingTransformsValue;
    protected UnityEngine.UI.Graphic[] tintGraphicsRuntime;
    
    // Methods
    protected override void Awake()
    {
        this.GetInitialOffsetPosition();
        this.GetInitialScales();
    }
    protected override void Start()
    {
        this.TryGetTintGraphic();
    }
    protected void GetInitialOffsetPosition()
    {
        var val_4;
        if(UnityEngine.Application.isPlaying == false)
        {
                return;
        }
        
        if(this.offsetTransforms.Length == 0)
        {
                return;
        }
        
        this.initialOffsetTransformsPos = new System.Collections.Generic.List<UnityEngine.Vector2>();
        val_4 = 0;
        do
        {
            if(val_4 >= this.offsetTransforms.Length)
        {
                return;
        }
        
            UnityEngine.Vector2 val_3 = this.offsetTransforms[val_4].anchoredPosition;
            this.initialOffsetTransformsPos.Add(item:  new UnityEngine.Vector2() {x = val_3.x, y = val_3.y});
            val_4 = val_4 + 1;
        }
        while(this.offsetTransforms != null);
        
        throw new NullReferenceException();
    }
    protected void GetInitialScales()
    {
        var val_4;
        if(UnityEngine.Application.isPlaying == false)
        {
                return;
        }
        
        if(this.scalingTransforms.Length == 0)
        {
                return;
        }
        
        this.initialScalingTransformsValue = new System.Collections.Generic.List<UnityEngine.Vector3>();
        val_4 = 0;
        do
        {
            if(val_4 >= this.scalingTransforms.Length)
        {
                return;
        }
        
            UnityEngine.Vector3 val_3 = this.scalingTransforms[val_4].localScale;
            this.initialScalingTransformsValue.Add(item:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z});
            val_4 = val_4 + 1;
        }
        while(this.scalingTransforms != null);
        
        throw new NullReferenceException();
    }
    protected void TryGetTintGraphic()
    {
        if(this.autoGetTintGraphics == false)
        {
                return;
        }
        
        this.tintGraphicsRuntime = this.GetComponentsInChildren<UnityEngine.UI.Graphic>(includeInactive:  true);
    }
    protected override void DoStateTransition(UnityEngine.UI.Selectable.SelectionState state, bool instant)
    {
        SelectionState val_17;
        float val_21;
        var val_22;
        UnityEngine.Color val_23;
        var val_24;
        var val_25;
        var val_26;
        var val_27;
        var val_28;
        float val_29;
        var val_30;
        float val_31;
        var val_32;
        var val_33;
        UnityEngine.RectTransform val_36;
        UnityEngine.RectTransform val_37;
        val_17 = state;
        if(this.initialOffsetTransformsPos == null)
        {
                this.GetInitialOffsetPosition();
        }
        
        if(this.initialScalingTransformsValue == null)
        {
                this.GetInitialScales();
        }
        
        UnityEngine.Color val_1 = UnityEngine.Color.white;
        if(val_17 == 2)
        {
            goto label_3;
        }
        
        if(val_17 != 4)
        {
            goto label_4;
        }
        
        if(this.useOverlay == false)
        {
            goto label_5;
        }
        
        val_21 = 1f;
        val_22 = 1;
        goto label_6;
        label_3:
        val_22 = 0;
        val_23 = this.pressedTint;
        val_24 = 1152921517685482252;
        val_25 = 1152921517685482256;
        val_26 = 1152921517685482260;
        val_21 = 1f;
        var val_2 = (this.useOverlayWhenPressed == true) ? 1 : 0;
        val_28 = 1;
        goto label_7;
        label_4:
        val_29 = val_1.r;
        val_30 = val_1.g;
        val_31 = val_1.b;
        val_32 = val_1.a;
        val_28 = 0;
        val_27 = 0;
        val_22 = 0;
        val_21 = 1f;
        goto label_8;
        label_5:
        val_21 = this.disabledAlpha;
        val_22 = 0;
        label_6:
        val_28 = 0;
        val_27 = 0;
        val_23 = this.disabledTint;
        val_24 = 1152921517685482268;
        val_25 = 1152921517685482272;
        val_26 = 1152921517685482276;
        label_7:
        val_29 = mem[this.disabledTint];
        val_29 = this.disabledTint.r;
        label_8:
        if(this.gameObject.activeInHierarchy == false)
        {
                return;
        }
        
        if(this.useOverlay == false)
        {
            goto label_11;
        }
        
        int val_17 = this.overlays.Length;
        val_17 = instant;
        if(val_17 < 1)
        {
            goto label_20;
        }
        
        val_17 = val_17 & 4294967295;
        do
        {
            if(1152921507880486736 != 0)
        {
                1152921507880486736.enabled = false;
        }
        
            val_33 = 0 + 1;
        }
        while(val_33 < (this.overlays.Length << ));
        
        goto label_20;
        label_11:
        val_17 = instant;
        this.SetAlpha(targetAlpha:  val_21, instant:  instant);
        label_20:
        this.SetTint(color:  new UnityEngine.Color() {r = val_29, g = 1.790777E-25f, b = 1.790777E-25f, a = 1.790777E-25f}, instant:  val_17);
        if(this.useOverlayWhenPressed != false)
        {
                int val_18 = this.pressedOverlays.Length;
            if(val_18 >= 1)
        {
                var val_19 = 0;
            val_18 = val_18 & 4294967295;
            do
        {
            if(1152921507880486736 != 0)
        {
                1152921507880486736.enabled = false;
        }
        
            val_19 = val_19 + 1;
        }
        while(val_19 < (this.pressedOverlays.Length << ));
        
        }
        
        }
        
        if(UnityEngine.Application.isPlaying == false)
        {
            goto label_75;
        }
        
        if((val_28 & 1) == 0)
        {
            goto label_31;
        }
        
        var val_25 = 0;
        label_49:
        if(val_25 >= (this.offsetTransforms.Length << ))
        {
            goto label_33;
        }
        
        if(this.pressedOffsetType == 1)
        {
            goto label_34;
        }
        
        if(this.pressedOffsetType != 0)
        {
            goto label_35;
        }
        
        UnityEngine.Vector2 val_10 = this.GetButtonDimension();
        UnityEngine.Vector2 val_20 = this.pressedOffset;
        val_36 = this.offsetTransforms[val_25];
        if(val_25 >= this.offsetTransforms.Length)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_20 = val_10.x * val_20;
        float val_11 = val_10.y * S13;
        UnityEngine.RectTransform val_21 = this.offsetTransforms[val_25][val_25];
        UnityEngine.RectTransform val_22 = this.offsetTransforms[val_25][val_25];
        goto label_42;
        label_34:
        val_36 = this.offsetTransforms[val_25];
        if(val_25 >= this.offsetTransforms.Length)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        label_42:
        UnityEngine.Vector2 val_12 = UnityEngine.Vector2.op_Addition(a:  new UnityEngine.Vector2() {x = this.offsetTransforms[val_25][val_25], y = this.offsetTransforms[val_25][val_25]}, b:  new UnityEngine.Vector2() {x = this.pressedOffset, y = 1.790777E-25f});
        val_36.anchoredPosition = new UnityEngine.Vector2() {x = val_12.x, y = val_12.y};
        label_35:
        val_25 = val_25 + 1;
        if(this.offsetTransforms != null)
        {
            goto label_49;
        }
        
        label_31:
        var val_30 = 0;
        var val_29 = 0;
        label_57:
        if(val_29 >= this.offsetTransforms.Length)
        {
            goto label_52;
        }
        
        if(this.offsetTransforms.Length <= val_29)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        this.offsetTransforms[val_30].anchoredPosition = new UnityEngine.Vector2() {x = this.offsetTransforms[val_30][val_30], y = this.offsetTransforms[val_30][val_30]};
        val_29 = val_29 + 1;
        val_30 = val_30 + 8;
        if(this.offsetTransforms != null)
        {
            goto label_57;
        }
        
        label_33:
        val_28 = 1152921504762171392;
        val_22 = 0;
        var val_34 = 0;
        val_31 = 1f;
        label_72:
        if(val_34 >= (this.scalingTransforms.Length << ))
        {
            goto label_75;
        }
        
        if(this.pressedScalingType == 1)
        {
            goto label_61;
        }
        
        if(this.pressedScalingType != 0)
        {
            goto label_62;
        }
        
        val_37 = this.scalingTransforms[val_34];
        if(val_34 >= this.scalingTransforms.Length)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        UnityEngine.Vector3 val_13 = new UnityEngine.Vector3(x:  this.pressedScale, y:  1.790777E-25f, z:  val_31);
        UnityEngine.Vector3 val_14 = UnityEngine.Vector3.Scale(a:  new UnityEngine.Vector3() {x = this.scalingTransforms[val_34][val_22], y = this.scalingTransforms[val_34][val_22], z = this.scalingTransforms[val_34][val_22]}, b:  new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z});
        if(val_37 != null)
        {
            goto label_68;
        }
        
        label_61:
        val_37 = this.scalingTransforms[val_34];
        UnityEngine.Vector3 val_15 = new UnityEngine.Vector3(x:  this.pressedScale, y:  1.790777E-25f, z:  val_31);
        label_68:
        val_37.localScale = new UnityEngine.Vector3() {x = val_15.x, y = val_15.y, z = val_15.z};
        label_62:
        val_34 = val_34 + 1;
        val_22 = val_22 + 12;
        if(this.scalingTransforms != null)
        {
            goto label_72;
        }
        
        label_52:
        val_22 = 0;
        var val_39 = 0;
        label_80:
        if(val_39 >= this.scalingTransforms.Length)
        {
            goto label_75;
        }
        
        if(this.scalingTransforms.Length <= val_39)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        this.scalingTransforms[val_39].localScale = new UnityEngine.Vector3() {x = this.scalingTransforms[val_39][val_22], y = this.scalingTransforms[val_39][val_22], z = this.scalingTransforms[val_39][val_22]};
        val_39 = val_39 + 1;
        val_22 = val_22 + 12;
        if(this.scalingTransforms != null)
        {
            goto label_80;
        }
        
        throw new NullReferenceException();
        label_75:
        this.DoStateTransition(state:  val_17, instant:  val_17);
    }
    protected void SetAlpha(float targetAlpha, bool instant)
    {
        int val_2 = this.additionalGraphics.Length;
        if(val_2 < 1)
        {
                return;
        }
        
        var val_3 = 0;
        val_2 = val_2 & 4294967295;
        do
        {
            bool val_1 = UnityEngine.Object.op_Inequality(x:  1152921507880482640, y:  0);
            val_3 = val_3 + 1;
        }
        while(val_3 < (this.additionalGraphics.Length << ));
    
    }
    protected void SetTint(UnityEngine.Color color, bool instant)
    {
        var val_4;
        if(this.autoGetTintGraphics != false)
        {
                int val_3 = this.tintGraphicsRuntime.Length;
            if(val_3 < 1)
        {
                return;
        }
        
            val_3 = val_3 & 4294967295;
            do
        {
            bool val_1 = UnityEngine.Object.op_Inequality(x:  1152921507880494928, y:  0);
            val_4 = 0 + 1;
        }
        while(val_4 < (this.tintGraphicsRuntime.Length << ));
        
            return;
        }
        
        int val_4 = this.tintGraphics.Length;
        if(val_4 < 1)
        {
                return;
        }
        
        val_4 = val_4 & 4294967295;
        do
        {
            bool val_2 = UnityEngine.Object.op_Inequality(x:  1152921507880482640, y:  0);
            val_4 = 0 + 1;
        }
        while(val_4 < (this.tintGraphics.Length << ));
    
    }
    protected UnityEngine.Vector2 GetButtonDimension()
    {
        UnityEngine.Transform val_1 = this.transform;
        if(null == null)
        {
                UnityEngine.Vector2 val_2 = val_1.sizeDelta;
            UnityEngine.Vector3 val_4 = this.transform.localScale;
            UnityEngine.Vector2 val_5 = val_1.sizeDelta;
            UnityEngine.Vector3 val_7 = this.transform.localScale;
            val_7.y = val_5.y * val_7.y;
            UnityEngine.Vector2 val_9 = new UnityEngine.Vector2(x:  val_2.x * val_4.x, y:  val_7.y);
            return new UnityEngine.Vector2() {x = val_9.x, y = val_9.y};
        }
    
    }
    public MultiGraphicButton()
    {
        this.additionalGraphics = new UnityEngine.UI.Graphic[0];
        this.disabledAlpha = 0.4f;
        this.tintGraphics = new UnityEngine.UI.Graphic[0];
        UnityEngine.Color val_3 = new UnityEngine.Color(r:  0.6f, g:  0.6f, b:  0.6f);
        UnityEngine.Color val_4;
        mem2[0] = val_3.r;
        val_4 = new UnityEngine.Color(r:  0.6f, g:  0.6f, b:  0.6f);
        mem2[0] = val_4.r;
        this.tintFadeDuration = 0.07f;
        this.offsetTransforms = new UnityEngine.RectTransform[0];
        UnityEngine.Vector2 val_6 = UnityEngine.Vector2.zero;
        this.pressedOffset = val_6;
        mem[1152921517686692184] = val_6.y;
        this.scalingTransforms = new UnityEngine.RectTransform[0];
        UnityEngine.Vector2 val_8 = UnityEngine.Vector2.one;
        this.pressedScale = val_8;
        mem[1152921517686692208] = val_8.y;
        this.tintGraphicsRuntime = new UnityEngine.UI.Graphic[0];
    }

}
