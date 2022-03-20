using UnityEngine;

namespace SRDebugger.UI.Controls
{
    public class ProfilerGraphControl : Graphic
    {
        // Fields
        public SRDebugger.UI.Controls.ProfilerGraphControl.VerticalAlignments VerticalAlignment;
        private static readonly float[] ScaleSteps;
        public bool FloatingScale;
        public bool TargetFpsUseApplication;
        public bool DrawAxes;
        public int TargetFps;
        public bool Clip;
        public const float DataPointMargin = 2;
        public const float DataPointVerticalMargin = 2;
        public const float DataPointWidth = 4;
        public int VerticalPadding;
        public const int LineCount = 3;
        public UnityEngine.Color[] LineColours;
        private SRDebugger.Services.IProfilerService _profilerService;
        private SRDebugger.UI.Controls.ProfilerGraphAxisLabel[] _axisLabels;
        private UnityEngine.Rect _clipBounds;
        private readonly System.Collections.Generic.List<UnityEngine.Vector3> _meshVertices;
        private readonly System.Collections.Generic.List<UnityEngine.Color32> _meshVertexColors;
        private readonly System.Collections.Generic.List<int> _meshTriangles;
        
        // Methods
        protected override void Awake()
        {
            this.Awake();
            this._profilerService = SRF.Service.SRServiceManager.GetService<SRDebugger.Services.IProfilerService>();
        }
        protected override void Start()
        {
            this.Start();
        }
        protected void Update()
        {
            this.SetVerticesDirty();
        }
        protected override void OnPopulateMesh(UnityEngine.Mesh m)
        {
            float val_26;
            int val_28;
            float val_29;
            var val_30;
            var val_31;
            var val_32;
            var val_33;
            var val_34;
            int val_35;
            int val_36;
            var val_37;
            var val_38;
            this._meshVertices.Clear();
            this._meshVertexColors.Clear();
            this._meshTriangles.Clear();
            UnityEngine.Rect val_2 = this.rectTransform.rect;
            val_26 = val_2.m_XMin.width;
            UnityEngine.Rect val_5 = this.rectTransform.rect;
            float val_28 = val_5.m_XMin.height;
            UnityEngine.Rect val_7 = new UnityEngine.Rect(x:  0f, y:  0f, width:  val_26, height:  val_28);
            val_28 = this.TargetFps;
            this._clipBounds = val_7.m_XMin;
            if((UnityEngine.Application.isPlaying != false) && (this.TargetFpsUseApplication != false))
            {
                    if(UnityEngine.Application.targetFrameRate >= 1)
            {
                    val_28 = UnityEngine.Application.targetFrameRate;
            }
            
            }
            
            val_29 = 1f / (float)val_28;
            if(this.FloatingScale == false)
            {
                goto label_10;
            }
            
            float val_11 = this.CalculateMaxFrameTime();
            if(this.FloatingScale == false)
            {
                goto label_10;
            }
            
            val_30 = 0;
            val_31 = null;
            goto label_11;
            label_20:
            val_31 = null;
            int val_23 = SRDebugger.UI.Controls.ProfilerGraphControl.LineCount;
            val_23 = val_23 + 0;
            if(val_11 < 0)
            {
                goto label_16;
            }
            
            val_30 = 1;
            label_11:
            val_31 = null;
            if(val_30 < (SRDebugger.UI.Controls.ProfilerGraphControl.LineCount + 24))
            {
                goto label_20;
            }
            
            goto label_21;
            label_10:
            val_32 = 0;
            val_33 = 0;
            val_34 = null;
            goto label_22;
            label_30:
            val_34 = null;
            int val_24 = SRDebugger.UI.Controls.ProfilerGraphControl.LineCount;
            val_24 = val_24 + 0;
            var val_13 = (val_29 > ((SRDebugger.UI.Controls.ProfilerGraphControl.LineCount + 0) + 32)) ? (val_32) : (val_33);
            val_32 = 1;
            label_22:
            val_34 = null;
            if(val_32 < (SRDebugger.UI.Controls.ProfilerGraphControl.LineCount + 24))
            {
                goto label_30;
            }
            
            goto label_32;
            label_16:
            if((val_30 & 2147483648) == 0)
            {
                goto label_32;
            }
            
            label_21:
            val_31 = null;
            int val_25 = SRDebugger.UI.Controls.ProfilerGraphControl.LineCount;
            val_33 = (SRDebugger.UI.Controls.ProfilerGraphControl.LineCount + 24) - 1;
            val_25 = val_25 + (val_33 << 2);
            val_29 = mem[(SRDebugger.UI.Controls.ProfilerGraphControl.LineCount + ((SRDebugger.UI.Controls.ProfilerGraphControl.LineCount + 24 - 1)) << 2) + 32];
            val_29 = (SRDebugger.UI.Controls.ProfilerGraphControl.LineCount + ((SRDebugger.UI.Controls.ProfilerGraphControl.LineCount + 24 - 1)) << 2) + 32;
            label_32:
            int val_26 = this.VerticalPadding;
            val_26 = val_26 << 1;
            float val_27 = (float)val_26;
            val_27 = val_28 - val_27;
            val_28 = val_27 / val_29;
            val_35 = this.CalculateVisibleDataPointCount();
            int val_15 = this.GetFrameBufferCurrentSize();
            val_36 = val_15 - 1;
            if((val_11 < (((SRDebugger.UI.Controls.ProfilerGraphControl.LineCount + 0) + 32) * 1.1f)) || (val_35 < 1))
            {
                goto label_39;
            }
            
            var val_30 = 0;
            label_40:
            SRDebugger.Services.ProfilerFrame val_17 = this.GetFrame(i:  val_36);
            float val_29 = 0f;
            val_29 = val_29 * (-4f);
            val_29 = val_26 + val_29;
            val_29 = val_29 + (-4f);
            val_29 = val_29 - (val_26 * 0.5f);
            this.DrawDataPoint(xPosition:  val_29, verticalScale:  val_28, frame:  new SRDebugger.Services.ProfilerFrame() {FrameTime = val_36, OtherTime = val_36, RenderTime = val_36, UpdateTime = val_36});
            val_30 = val_30 + 1;
            if(val_15 <= val_30)
            {
                goto label_39;
            }
            
            val_36 = val_36 - 1;
            if(val_30 < val_35)
            {
                goto label_40;
            }
            
            label_39:
            if(this.DrawAxes == false)
            {
                goto label_50;
            }
            
            if(this.FloatingScale == false)
            {
                goto label_42;
            }
            
            val_37 = 0;
            if((val_33 & 2147483648) == 0)
            {
                goto label_43;
            }
            
            goto label_50;
            label_42:
            this.DrawAxis(frameTime:  val_29, yPosition:  val_29 * val_28, label:  this.GetAxisLabel(index:  0));
            if((val_33 & 2147483648) != 0)
            {
                goto label_50;
            }
            
            label_43:
            val_36 = 1152921505013927936;
            var val_32 = (long)val_33;
            label_51:
            val_38 = null;
            val_35 = (this.FloatingScale == false) ? 1 : 0;
            val_38 = null;
            int val_31 = SRDebugger.UI.Controls.ProfilerGraphControl.LineCount;
            val_31 = val_31 + (((long)(int)((SRDebugger.UI.Controls.ProfilerGraphControl.LineCount + 24 - 1))) << 2);
            val_26 = mem[(SRDebugger.UI.Controls.ProfilerGraphControl.LineCount + ((long)(int)((SRDebugger.UI.Controls.ProfilerGraphControl.LineCount + 24 - 1))) << 2) + 32];
            val_26 = (SRDebugger.UI.Controls.ProfilerGraphControl.LineCount + ((long)(int)((SRDebugger.UI.Controls.ProfilerGraphControl.LineCount + 24 - 1))) << 2) + 32;
            this.DrawAxis(frameTime:  val_26, yPosition:  val_28 * val_26, label:  this.GetAxisLabel(index:  val_35));
            val_32 = val_32 - 1;
            if(val_32 >= (SRDebugger.UI.Controls.ProfilerGraphControl.LineCount + 24))
            {
                    if(val_35 == 0)
            {
                goto label_51;
            }
            
            }
            
            label_50:
            m.Clear();
            m.SetVertices(inVertices:  this._meshVertices);
            m.SetColors(inColors:  this._meshVertexColors);
            m.SetTriangles(triangles:  this._meshTriangles, submesh:  0);
        }
        protected void DrawDataPoint(float xPosition, float verticalScale, SRDebugger.Services.ProfilerFrame frame)
        {
            float val_23;
            float val_24;
            float val_25;
            float val_26;
            val_23 = V4.16B;
            float val_21 = V3.16B;
            float val_19 = 4f;
            float val_20 = 0.5f;
            val_19 = xPosition + val_19;
            val_20 = this._clipBounds.width * val_20;
            val_19 = val_19 + (-2f);
            float val_2 = UnityEngine.Mathf.Min(a:  val_20, b:  val_19);
            var val_29 = 0;
            var val_28 = 0;
            val_24 = 0f;
            goto label_20;
            label_15:
            val_25 = (val_23 - val_21) + 2f;
            goto label_4;
            label_20:
            if(val_28 == 2)
            {
                goto label_5;
            }
            
            val_26 = (float)val_23;
            if(val_28 == 1)
            {
                goto label_8;
            }
            
            val_26 = 0f;
            if(val_28 != 0)
            {
                goto label_8;
            }
            
            val_26 = (float)V5.16B;
            goto label_8;
            label_5:
            val_26 = (float)val_21;
            label_8:
            val_21 = val_26 * verticalScale;
            if((SRF.SRFFloatExtensions.ApproxZero(f:  val_21)) == true)
            {
                goto label_10;
            }
            
            float val_22 = -4f;
            val_22 = val_21 + val_22;
            if(val_22 < 0)
            {
                goto label_10;
            }
            
            UnityEngine.Rect val_6 = this.rectTransform.rect;
            float val_7 = val_6.m_XMin.height;
            if(this.VerticalAlignment == 0)
            {
                goto label_12;
            }
            
            float val_23 = 2f;
            val_23 = val_24 + val_23;
            val_7 = val_7 * (-0.5f);
            val_23 = val_23 + val_7;
            goto label_13;
            label_12:
            UnityEngine.Rect val_9 = this.rectTransform.rect;
            float val_10 = val_9.m_XMin.height;
            val_10 = val_10 * 0.5f;
            val_10 = val_10 - val_24;
            val_23 = val_10 + (-2f);
            if(this.VerticalAlignment == 0)
            {
                goto label_15;
            }
            
            label_13:
            val_10 = val_21 + val_23;
            val_25 = val_10 + (-2f);
            label_4:
            UnityEngine.Color val_25 = this.LineColours[val_29];
            UnityEngine.Color val_27 = this.LineColours[val_29];
            float val_11 = this._clipBounds.width;
            val_11 = val_11 * (-0.5f);
            UnityEngine.Vector3 val_13 = new UnityEngine.Vector3(x:  UnityEngine.Mathf.Max(a:  val_11, b:  xPosition), y:  val_23);
            float val_14 = this._clipBounds.width;
            val_14 = val_14 * (-0.5f);
            UnityEngine.Vector3 val_16 = new UnityEngine.Vector3(x:  UnityEngine.Mathf.Max(a:  val_14, b:  xPosition), y:  val_25);
            UnityEngine.Vector3 val_17 = new UnityEngine.Vector3(x:  val_2, y:  val_25);
            UnityEngine.Vector3 val_18 = new UnityEngine.Vector3(x:  val_2, y:  val_23);
            this.AddRect(tl:  new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z}, tr:  new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z}, bl:  new UnityEngine.Vector3() {x = val_17.x, y = val_17.z, z = val_18.x}, br:  new UnityEngine.Vector3() {x = val_18.z, y = this.LineColours[val_29], z = this.LineColours[val_29]}, c:  new UnityEngine.Color() {b = (float)V5.16B, a = xPosition});
            val_24 = val_24 + val_21;
            label_10:
            val_28 = val_28 + 1;
            val_29 = val_29 + 16;
            if(val_28 < 2)
            {
                goto label_20;
            }
        
        }
        protected void DrawAxis(float frameTime, float yPosition, SRDebugger.UI.Controls.ProfilerGraphAxisLabel label)
        {
            UnityEngine.Rect val_2 = this.rectTransform.rect;
            float val_18 = val_2.m_XMin.width;
            UnityEngine.Rect val_5 = this.rectTransform.rect;
            float val_19 = val_5.m_XMin.height;
            float val_8 = val_19 * 0.5f;
            float val_20 = -0.5f;
            val_8 = yPosition - val_8;
            float val_9 = val_18 * val_20;
            val_18 = val_18 * 0.5f;
            val_19 = val_8 + 0.5f;
            UnityEngine.Rect val_10 = this.rectTransform.rect;
            float val_11 = val_10.m_XMin.height;
            val_11 = val_11 * val_20;
            val_11 = yPosition + val_11;
            val_20 = val_11 + val_20;
            UnityEngine.Color val_12 = new UnityEngine.Color(r:  1f, g:  1f, b:  1f, a:  0.4f);
            UnityEngine.Vector3 val_13 = new UnityEngine.Vector3(x:  val_9, y:  val_20);
            UnityEngine.Vector3 val_14 = new UnityEngine.Vector3(x:  val_9, y:  val_19);
            UnityEngine.Vector3 val_15 = new UnityEngine.Vector3(x:  val_18, y:  val_19);
            UnityEngine.Vector3 val_16 = new UnityEngine.Vector3(x:  val_18, y:  val_20);
            this.AddRect(tl:  new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z}, tr:  new UnityEngine.Vector3() {x = val_14.x, y = val_14.y, z = val_14.z}, bl:  new UnityEngine.Vector3() {x = val_15.x, y = val_15.z, z = val_16.x}, br:  new UnityEngine.Vector3() {x = val_16.z, y = val_12.r}, c:  new UnityEngine.Color() {r = val_16.x, g = val_16.z, b = val_15.x, a = val_15.z});
            if(label == 0)
            {
                    return;
            }
            
            label.SetValue(frameTime:  frameTime, yPosition:  yPosition);
        }
        protected void AddRect(UnityEngine.Vector3 tl, UnityEngine.Vector3 tr, UnityEngine.Vector3 bl, UnityEngine.Vector3 br, UnityEngine.Color c)
        {
            var val_1;
            var val_2;
            float val_3;
            float val_4;
            this._meshVertices.Add(item:  new UnityEngine.Vector3() {x = tl.x, y = tl.y, z = tl.z});
            this._meshVertices.Add(item:  new UnityEngine.Vector3() {x = tr.x, y = tr.y, z = tr.z});
            this._meshVertices.Add(item:  new UnityEngine.Vector3() {x = bl.x, y = val_4, z = bl.y});
            this._meshVertices.Add(item:  new UnityEngine.Vector3() {x = bl.z, y = val_3, z = br.x});
            this._meshTriangles.Add(item:  this._meshVertices - 4);
            this._meshTriangles.Add(item:  this._meshVertices - 3);
            this._meshTriangles.Add(item:  this._meshVertices - 1);
            this._meshTriangles.Add(item:  this._meshVertices - 2);
            this._meshTriangles.Add(item:  this._meshVertices - 1);
            this._meshTriangles.Add(item:  this._meshVertices - 3);
            UnityEngine.Color32 val_11 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color() {r = br.y, g = val_2, b = br.z, a = val_1});
            this._meshVertexColors.Add(item:  new UnityEngine.Color32() {r = val_11.r & 4294967295, g = val_11.r & 4294967295, b = val_11.r & 4294967295, a = val_11.r & 4294967295});
            UnityEngine.Color32 val_13 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color() {r = br.y, g = val_2, b = br.z, a = val_1});
            this._meshVertexColors.Add(item:  new UnityEngine.Color32() {r = val_13.r & 4294967295, g = val_13.r & 4294967295, b = val_13.r & 4294967295, a = val_13.r & 4294967295});
            UnityEngine.Color32 val_15 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color() {r = br.y, g = val_2, b = br.z, a = val_1});
            this._meshVertexColors.Add(item:  new UnityEngine.Color32() {r = val_15.r & 4294967295, g = val_15.r & 4294967295, b = val_15.r & 4294967295, a = val_15.r & 4294967295});
            UnityEngine.Color32 val_17 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color() {r = br.y, g = val_2, b = br.z, a = val_1});
            this._meshVertexColors.Add(item:  new UnityEngine.Color32() {r = val_17.r & 4294967295, g = val_17.r & 4294967295, b = val_17.r & 4294967295, a = val_17.r & 4294967295});
        }
        protected SRDebugger.Services.ProfilerFrame GetFrame(int i)
        {
            var val_3 = 0;
            val_3 = val_3 + 1;
            return this._profilerService.FrameBuffer.Item[i];
        }
        protected int CalculateVisibleDataPointCount()
        {
            UnityEngine.Rect val_2 = this.rectTransform.rect;
            float val_5 = 0.25f;
            val_5 = val_2.m_XMin.width * val_5;
            return (int)UnityEngine.Mathf.RoundToInt(f:  val_5);
        }
        protected int GetFrameBufferCurrentSize()
        {
            var val_3 = 0;
            val_3 = val_3 + 1;
            return (int)this._profilerService.FrameBuffer;
        }
        protected int GetFrameBufferMaxSize()
        {
            var val_3 = 0;
            val_3 = val_3 + 1;
            return this._profilerService.FrameBuffer.Capacity;
        }
        protected float CalculateMaxFrameTime()
        {
            int val_6 = this.GetFrameBufferCurrentSize();
            int val_3 = UnityEngine.Mathf.Min(a:  this.CalculateVisibleDataPointCount(), b:  val_6);
            if(val_3 < 1)
            {
                    return 0f;
            }
            
            var val_7 = val_3;
            val_6 = val_6 - 1;
            do
            {
                SRDebugger.Services.ProfilerFrame val_4 = this.GetFrame(i:  val_6);
                var val_5 = (D0 > 0) ? (D0) : 0;
                val_7 = val_7 - 1;
                val_6 = val_6 - 1;
            }
            while(D0 != 0);
            
            return 0f;
        }
        private SRDebugger.UI.Controls.ProfilerGraphAxisLabel GetAxisLabel(int index)
        {
            SRDebugger.UI.Controls.ProfilerGraphAxisLabel[] val_3;
            T val_4;
            if((this._axisLabels == null) || (UnityEngine.Application.isPlaying == false))
            {
                goto label_2;
            }
            
            val_3 = this._axisLabels;
            if(val_3 != null)
            {
                goto label_3;
            }
            
            label_2:
            T[] val_2 = this.GetComponentsInChildren<SRDebugger.UI.Controls.ProfilerGraphAxisLabel>();
            this._axisLabels = val_2;
            label_3:
            if(val_2.Length > index)
            {
                    val_4 = val_2[index];
                return (SRDebugger.UI.Controls.ProfilerGraphAxisLabel)val_4;
            }
            
            UnityEngine.Debug.LogWarning(message:  "[SRDebugger.Profiler] Not enough axis labels in pool");
            val_4 = 0;
            return (SRDebugger.UI.Controls.ProfilerGraphAxisLabel)val_4;
        }
        public ProfilerGraphControl()
        {
            this.VerticalAlignment = 1;
            this.DrawAxes = 1;
            this.TargetFps = 60;
            this.Clip = 1;
            this.VerticalPadding = 10;
            this.LineColours = new UnityEngine.Color[0];
            this._meshVertices = new System.Collections.Generic.List<UnityEngine.Vector3>();
            this._meshVertexColors = new System.Collections.Generic.List<UnityEngine.Color32>();
            this._meshTriangles = new System.Collections.Generic.List<System.Int32>();
        }
        private static ProfilerGraphControl()
        {
            SRDebugger.UI.Controls.ProfilerGraphControl.LineCount = new float[9] {2.076515E-32f, -4.294921E+08f, -3.274855E-33f, 2.0717E-32f, -3.286892E-33f, -3.274856E-33f, -4.284436E+08f, -1.212648E-12f, -1.209095E-12f};
        }
    
    }

}
