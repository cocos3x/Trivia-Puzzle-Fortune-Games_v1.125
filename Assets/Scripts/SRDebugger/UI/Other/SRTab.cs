using UnityEngine;

namespace SRDebugger.UI.Other
{
    public class SRTab : SRMonoBehaviourEx
    {
        // Fields
        public UnityEngine.RectTransform HeaderExtraContent;
        public UnityEngine.Sprite Icon;
        public UnityEngine.RectTransform IconExtraContent;
        public string IconStyleKey;
        public int SortIndex;
        public SRDebugger.UI.Controls.SRTabButton TabButton;
        private string _title;
        private string _longTitle;
        private string _key;
        
        // Properties
        public string Title { get; }
        public string LongTitle { get; }
        public string Key { get; }
        
        // Methods
        public string get_Title()
        {
            return (string)this._title;
        }
        public string get_LongTitle()
        {
            var val_2 = ((System.String.IsNullOrEmpty(value:  this._longTitle)) != true) ? 120 : 128;
            return (string)null;
        }
        public string get_Key()
        {
            return (string)this._key;
        }
        public SRTab()
        {
            this.IconStyleKey = "Icon_Stompy";
        }
    
    }

}
