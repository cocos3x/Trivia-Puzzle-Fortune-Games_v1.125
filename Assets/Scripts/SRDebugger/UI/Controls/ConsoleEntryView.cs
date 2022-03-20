using UnityEngine;

namespace SRDebugger.UI.Controls
{
    public class ConsoleEntryView : SRMonoBehaviourEx, IVirtualView
    {
        // Fields
        public const string ConsoleBlobInfo = "Console_Info_Blob";
        public const string ConsoleBlobWarning = "Console_Warning_Blob";
        public const string ConsoleBlobError = "Console_Error_Blob";
        private int _count;
        private bool _hasCount;
        private SRDebugger.Services.ConsoleEntry _prevData;
        private UnityEngine.RectTransform _rectTransform;
        public UnityEngine.UI.Text Count;
        public UnityEngine.CanvasGroup CountContainer;
        public SRF.UI.StyleComponent ImageStyle;
        public UnityEngine.UI.Text Message;
        public UnityEngine.UI.Text StackTrace;
        
        // Methods
        public void SetDataContext(object data)
        {
            UnityEngine.UI.Text val_9;
            float val_10;
            if(data == null)
            {
                    throw new System.Exception(message:  "Data should be a ConsoleEntry");
            }
            
            if(6461 >= 2)
            {
                goto label_4;
            }
            
            if(this._hasCount == false)
            {
                goto label_10;
            }
            
            val_10 = 0f;
            this.CountContainer.alpha = val_10;
            this._hasCount = false;
            goto label_10;
            label_4:
            if(this._hasCount != true)
            {
                    val_10 = 1f;
                this.CountContainer.alpha = val_10;
                this._hasCount = true;
            }
            
            if(this.CountContainer != this._count)
            {
                    val_9 = this.Count;
                string val_1 = SRDebugger.Internal.SRDebuggerUtil.GetNumberString(value:  this.CountContainer, max:  231, exceedsMaxString:  "999+");
                this._count = null;
            }
            
            label_10:
            if(this._prevData == data)
            {
                    return;
            }
            
            this._prevData = data;
            string val_2 = data.MessagePreview;
            string val_3 = data.StackTracePreview;
            val_9 = this.Message.rectTransform;
            UnityEngine.Rect val_6 = this._rectTransform.rect;
            float val_7 = val_6.m_XMin.height;
            if((System.String.IsNullOrEmpty(value:  this.StackTrace)) != false)
            {
                    float val_9 = -4f;
                val_9 = val_7 + val_9;
            }
            else
            {
                    float val_10 = -14f;
                val_10 = val_7 + val_10;
            }
            
            val_9.SetInsetAndSizeFromParentEdge(edge:  3, inset:  12f, size:  val_10);
            if(this._rectTransform > 4)
            {
                    return;
            }
            
            var val_11 = 32557688 + (this._rectTransform) << 2;
            val_11 = val_11 + 32557688;
            goto (32557688 + (this._rectTransform) << 2 + 32557688);
        }
        protected override void Awake()
        {
            UnityEngine.RectTransform val_4;
            this.Awake();
            UnityEngine.Transform val_1 = this.CachedTransform;
            if(val_1 != null)
            {
                    var val_2 = (null == null) ? (val_1) : 0;
            }
            else
            {
                    val_4 = 0;
            }
            
            this._rectTransform = val_4;
            this.CountContainer.alpha = 0f;
            SRDebugger.Settings val_3 = SRDebugger.Settings.Instance;
            this.Message.supportRichText = val_3._richTextInConsole;
        }
        public ConsoleEntryView()
        {
        
        }
    
    }

}
