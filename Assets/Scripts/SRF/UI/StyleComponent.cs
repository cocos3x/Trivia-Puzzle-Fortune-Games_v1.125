using UnityEngine;

namespace SRF.UI
{
    public class StyleComponent : SRMonoBehaviour
    {
        // Fields
        private SRF.UI.Style _activeStyle;
        private SRF.UI.StyleRoot _cachedRoot;
        private UnityEngine.UI.Graphic _graphic;
        private bool _hasStarted;
        private UnityEngine.UI.Image _image;
        private UnityEngine.UI.Selectable _selectable;
        private string _styleKey;
        public bool IgnoreImage;
        
        // Properties
        public string StyleKey { get; set; }
        
        // Methods
        public string get_StyleKey()
        {
            return (string)this._styleKey;
        }
        public void set_StyleKey(string value)
        {
            this._styleKey = value;
            this.Refresh(invalidateCache:  false);
        }
        private void Start()
        {
            this.Refresh(invalidateCache:  true);
            this._hasStarted = true;
        }
        private void OnEnable()
        {
            if(this._hasStarted == false)
            {
                    return;
            }
            
            this.Refresh(invalidateCache:  false);
        }
        public void Refresh(bool invalidateCache)
        {
            SRF.UI.StyleRoot val_8;
            SRF.UI.StyleRoot val_9;
            object val_10;
            if((System.String.IsNullOrEmpty(value:  this._styleKey)) != true)
            {
                    val_8 = this._cachedRoot;
                if((val_8 != 0) && (invalidateCache != true))
            {
                    val_9 = this._cachedRoot;
            }
            else
            {
                    SRF.UI.StyleRoot val_3 = this.GetStyleRoot();
                val_9 = val_3;
                this._cachedRoot = val_3;
            }
            
                if(val_9 == 0)
            {
                    val_10 = "[StyleComponent] No active StyleRoot object found in parents.";
            }
            else
            {
                    SRF.UI.Style val_5 = this._cachedRoot.GetStyle(key:  this._styleKey);
                if(val_5 != null)
            {
                    this._activeStyle = val_5;
                this.ApplyStyle();
                return;
            }
            
                object[] val_6 = new object[1];
                val_8 = this._styleKey;
                val_6[0] = val_8;
                val_10 = SRF.SRFStringExtensions.Fmt(formatString:  "[StyleComponent] Style not found ({0})", args:  val_6);
            }
            
                UnityEngine.Debug.LogWarning(message:  val_10, context:  this);
            }
            
            this._activeStyle = 0;
        }
        private SRF.UI.StyleRoot GetStyleRoot()
        {
            UnityEngine.Object val_9 = this.CachedTransform;
            var val_9 = 0;
            label_15:
            SRF.UI.StyleRoot val_2 = val_9.GetComponentInParent<SRF.UI.StyleRoot>();
            if(val_2 != 0)
            {
                    val_9 = val_2.transform.parent;
            }
            
            val_9 = val_9 + 1;
            if(val_9 >= 101)
            {
                goto label_7;
            }
            
            if(val_2 == 0)
            {
                    return val_2;
            }
            
            if(val_2.enabled == true)
            {
                    return val_2;
            }
            
            if(val_9 != 0)
            {
                goto label_15;
            }
            
            return val_2;
            label_7:
            UnityEngine.Debug.LogWarning(message:  "Breaking Loop");
            return val_2;
        }
        private void ApplyStyle()
        {
            if(this._activeStyle == null)
            {
                    return;
            }
            
            if(this._graphic == 0)
            {
                    this._graphic = this.GetComponent<UnityEngine.UI.Graphic>();
            }
            
            if(this._selectable == 0)
            {
                    this._selectable = this.GetComponent<UnityEngine.UI.Selectable>();
            }
            
            if(this._image == 0)
            {
                    this._image = this.GetComponent<UnityEngine.UI.Image>();
            }
            
            if(this.IgnoreImage != true)
            {
                    if(this._image != 0)
            {
                    this._image.sprite = this._activeStyle.Image;
            }
            
            }
            
            if(this._selectable != 0)
            {
                    this._selectable.colors = new UnityEngine.UI.ColorBlock() {m_NormalColor = new UnityEngine.Color() {r = this._activeStyle.NormalColor, g = this._activeStyle.NormalColor, b = this._activeStyle.NormalColor, a = this._activeStyle.NormalColor}, m_HighlightedColor = new UnityEngine.Color() {r = this._activeStyle.HoverColor, g = this._activeStyle.HoverColor, b = this._activeStyle.HoverColor, a = this._activeStyle.HoverColor}, m_PressedColor = new UnityEngine.Color() {r = this._activeStyle.ActiveColor, g = this._activeStyle.ActiveColor, b = this._activeStyle.ActiveColor, a = this._activeStyle.ActiveColor}, m_SelectedColor = new UnityEngine.Color() {r = ???, g = ???, b = ???, a = ???}, m_DisabledColor = new UnityEngine.Color() {r = this._activeStyle.DisabledColor, g = this._activeStyle.DisabledColor, b = this._activeStyle.DisabledColor, a = this._activeStyle.DisabledColor}, m_ColorMultiplier = 1f, m_FadeDuration = ???};
                if(this._graphic == 0)
            {
                    return;
            }
            
                this = this._graphic;
                UnityEngine.Color val_10 = UnityEngine.Color.white;
                return;
            }
            
            if(this._graphic == 0)
            {
                    return;
            }
        
        }
        private void SRStyleDirty()
        {
            if(this.CachedGameObject.activeInHierarchy != false)
            {
                    this.Refresh(invalidateCache:  true);
                return;
            }
            
            this._cachedRoot = 0;
        }
        public StyleComponent()
        {
        
        }
    
    }

}
