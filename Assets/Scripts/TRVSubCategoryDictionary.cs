using UnityEngine;
public class TRVSubCategoryDictionary
{
    // Fields
    private System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> subCategories;
    private string language;
    
    // Properties
    public string GetLanguage { get; }
    
    // Methods
    public string get_GetLanguage()
    {
        return (string)this.language;
    }
    public System.Collections.Generic.Dictionary<string, System.Collections.Generic.List<string>> GetSubCategories(string currentLocale)
    {
        bool val_2 = this.language.Equals(value:  this.ParseLanguageFromLocale(currentLocale:  currentLocale));
        if(val_2 != false)
        {
                this = this.subCategories;
            return (System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>>)this.subCategories;
        }
        
        string val_3 = val_2.ParseLanguageFromLocale(currentLocale:  currentLocale);
        this.language = val_3;
        this.subCategories = TRVDataParser.LoadCategoryInfo(currentLanguage:  val_3);
        MonoSingleton<TRVUtils>.Instance.Init(forceUpdate:  true);
        return (System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>>)this.subCategories;
    }
    public TRVSubCategoryDictionary(string currentLocale)
    {
        this.subCategories = new System.Collections.Generic.Dictionary<System.String, System.Collections.Generic.List<System.String>>();
        this.language = "";
        string val_2 = this.ParseLanguageFromLocale(currentLocale:  currentLocale);
        this.language = val_2;
        this.subCategories = TRVDataParser.LoadCategoryInfo(currentLanguage:  val_2);
    }
    private string ParseLanguageFromLocale(string currentLocale)
    {
        char[] val_1 = new char[1];
        val_1[0] = '-';
        return (string)currentLocale.Split(separator:  val_1)[0];
    }

}
