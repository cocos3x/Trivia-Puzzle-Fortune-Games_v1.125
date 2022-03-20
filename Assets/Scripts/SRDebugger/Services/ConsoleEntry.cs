using UnityEngine;

namespace SRDebugger.Services
{
    public class ConsoleEntry
    {
        // Fields
        private const int MessagePreviewLength = 180;
        private const int StackTracePreviewLength = 120;
        private string _messagePreview;
        private string _stackTracePreview;
        public int Count;
        public UnityEngine.LogType LogType;
        public string Message;
        public string StackTrace;
        
        // Properties
        public string MessagePreview { get; }
        public string StackTracePreview { get; }
        
        // Methods
        public ConsoleEntry()
        {
            this.Count = 1;
        }
        public ConsoleEntry(SRDebugger.Services.ConsoleEntry other)
        {
            this.Count = 1;
            this.Message = other.Message;
            this.StackTrace = other.StackTrace;
            this.LogType = other.LogType;
            this.Count = other.Count;
        }
        public string get_MessagePreview()
        {
            string val_6 = this._messagePreview;
            if(val_6 != null)
            {
                    return val_5;
            }
            
            if((System.String.IsNullOrEmpty(value:  this.Message)) != false)
            {
                    val_6 = "";
                return val_5;
            }
            
            char[] val_2 = new char[1];
            val_2[0] = '
            ';
            string val_6 = this.Message.Split(separator:  val_2)[0];
            this._messagePreview = val_6;
            string val_5 = val_6.Substring(startIndex:  0, length:  UnityEngine.Mathf.Min(a:  val_3[0].m_stringLength, b:  180));
            this._messagePreview = val_5;
            return val_5;
        }
        public string get_StackTracePreview()
        {
            string val_6 = this._stackTracePreview;
            if(val_6 != null)
            {
                    return val_5;
            }
            
            if((System.String.IsNullOrEmpty(value:  this.StackTrace)) != false)
            {
                    val_6 = "";
                return val_5;
            }
            
            char[] val_2 = new char[1];
            val_2[0] = '
            ';
            string val_6 = this.StackTrace.Split(separator:  val_2)[0];
            this._stackTracePreview = val_6;
            string val_5 = val_6.Substring(startIndex:  0, length:  UnityEngine.Mathf.Min(a:  val_3[0].m_stringLength, b:  120));
            this._stackTracePreview = val_5;
            return val_5;
        }
        public bool Matches(SRDebugger.Services.ConsoleEntry other)
        {
            var val_4;
            if(other == null)
            {
                goto label_3;
            }
            
            if(this == other)
            {
                goto label_1;
            }
            
            if((System.String.Equals(a:  this.Message, b:  other.Message)) != false)
            {
                    if((System.String.Equals(a:  this.StackTrace, b:  other.StackTrace)) != false)
            {
                    var val_3 = (this.LogType == other.LogType) ? 1 : 0;
                return (bool)val_4;
            }
            
            }
            
            label_3:
            val_4 = 0;
            return (bool)val_4;
            label_1:
            val_4 = 1;
            return (bool)val_4;
        }
    
    }

}
