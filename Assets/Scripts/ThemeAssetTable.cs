using UnityEngine;
public class ThemeAssetTable
{
    // Fields
    public System.Collections.Generic.Dictionary<string, UnityEngine.Sprite> sprites;
    public System.Collections.Generic.Dictionary<string, UnityEngine.Texture> textures;
    public System.Collections.Generic.Dictionary<string, UnityEngine.Color> contextColors;
    public UIThemeTemplate[] templates;
    public ThemeSettings themeSettings;
    public System.Collections.Generic.List<ThemeTextSettings> themeTextSettings;
    private System.Collections.Generic.Dictionary<string, UIThemeTemplate> cachedThemeTemplates;
    private System.Collections.Generic.Dictionary<string, ThemeTextSettings> cachedTextSettings;
    
    // Properties
    public System.Collections.Generic.Dictionary<string, UIThemeTemplate> CachedThemeTemplates { get; }
    public System.Collections.Generic.Dictionary<string, ThemeTextSettings> CachedTextSettings { get; }
    
    // Methods
    public System.Collections.Generic.Dictionary<string, UIThemeTemplate> get_CachedThemeTemplates()
    {
        System.Collections.Generic.Dictionary<System.String, UIThemeTemplate> val_13;
        UIThemeTemplate[] val_14;
        string val_16;
        string val_17;
        UnityEngine.Object val_18;
        val_13 = this.cachedThemeTemplates;
        if(val_13 != null)
        {
                return val_13;
        }
        
        val_14 = this.templates;
        System.Collections.Generic.Dictionary<System.String, UIThemeTemplate> val_1 = null;
        val_13 = val_1;
        val_1 = new System.Collections.Generic.Dictionary<System.String, UIThemeTemplate>();
        this.cachedThemeTemplates = val_13;
        if(val_14 == null)
        {
                return val_13;
        }
        
        label_44:
        if(0 >= this.templates.Length)
        {
            goto label_4;
        }
        
        UIThemeTemplate val_14 = this.templates[0];
        if(this.templates[0x0][0].gameObject != 0)
        {
            goto label_9;
        }
        
        string val_3 = 0.ToString();
        val_16 = "Theme is missing template GameObject at index ";
        val_17 = ". Skipping this template.";
        goto label_10;
        label_9:
        UIThemeTemplate val_15 = this.templates[0];
        val_18 = this.templates[0x0][0].gameObject.GetComponent<UnityEngine.UI.Image>();
        if(val_18 == 0)
        {
            goto label_17;
        }
        
        val_14 = val_4.m_Sprite;
        if(val_14 != 0)
        {
            goto label_21;
        }
        
        label_17:
        UIThemeTemplate val_16 = this.templates[0];
        val_18 = this.templates[0x0][0].gameObject.GetComponent<UnityEngine.UI.RawImage>();
        if(val_18 == 0)
        {
            goto label_32;
        }
        
        val_14 = val_7.m_Texture;
        if(val_14 == 0)
        {
            goto label_32;
        }
        
        label_21:
        this.cachedThemeTemplates.Add(key:  val_7.m_Texture.name, value:  this.templates[0]);
        goto label_37;
        label_32:
        UIThemeTemplate val_18 = this.templates[0];
        val_17 = " because no Image or RawImage was found on the template object.";
        val_16 = "Couldn\'t cache theme template for ";
        label_10:
        UnityEngine.Debug.LogError(message:  val_16 + this.templates[0x0][0].gameObject.name + val_17);
        label_37:
        var val_13 = 0 + 1;
        if(this.templates != null)
        {
            goto label_44;
        }
        
        throw new NullReferenceException();
        label_4:
        val_13 = this.cachedThemeTemplates;
        return val_13;
    }
    public System.Collections.Generic.Dictionary<string, ThemeTextSettings> get_CachedTextSettings()
    {
        System.Collections.Generic.Dictionary<System.String, ThemeTextSettings> val_7;
        System.Collections.Generic.List<ThemeTextSettings> val_8;
        val_7 = this.cachedTextSettings;
        if(val_7 != null)
        {
                return val_7;
        }
        
        val_8 = this.themeTextSettings;
        System.Collections.Generic.Dictionary<System.String, ThemeTextSettings> val_1 = null;
        val_7 = val_1;
        val_1 = new System.Collections.Generic.Dictionary<System.String, ThemeTextSettings>();
        this.cachedTextSettings = val_7;
        if(val_8 == null)
        {
                return val_7;
        }
        
        val_8 = this.themeTextSettings;
        label_20:
        if(0 >= 1152921517094292848)
        {
            goto label_4;
        }
        
        if(1152921517094292848 <= 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if(null == 0)
        {
            goto label_12;
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        if((System.String.IsNullOrEmpty(value:  (UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 0) + 32 + 112)) == true)
        {
            goto label_12;
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        if((this.cachedTextSettings.ContainsKey(key:  ((UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 0) + 32 + 0) + 32 + 112)) == false)
        {
            goto label_17;
        }
        
        label_12:
        UnityEngine.Debug.LogError(message:  "Couldn\'t cache index " + 0.ToString() + " of theme\'s ThemeTextSettings. Either the list has a null in it, or an undefined use case, or a duplicate use case.");
        label_28:
        var val_7 = 0 + 1;
        if(this.themeTextSettings != null)
        {
            goto label_20;
        }
        
        label_17:
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        this.cachedTextSettings.Add(key:  (((UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 0) + 32 + 0) + 32 + ((0 + 1)) << 3) + 32 + 112, value:  ((((UnityEngine.Object.__il2cppRuntimeField_cctor_finished + 0) + 32 + 0) + 32 + ((0 + 1)) << 3) + 32 + ((0 + 1)) << 3) + 32);
        goto label_28;
        label_4:
        val_7 = this.cachedTextSettings;
        return val_7;
    }
    public ThemeAssetTable()
    {
        this.sprites = new System.Collections.Generic.Dictionary<System.String, UnityEngine.Sprite>();
        this.textures = new System.Collections.Generic.Dictionary<System.String, UnityEngine.Texture>();
        this.contextColors = new System.Collections.Generic.Dictionary<System.String, UnityEngine.Color>();
    }

}
