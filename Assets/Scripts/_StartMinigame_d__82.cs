using UnityEngine;
private sealed class TRVLevelComplete.<StartMinigame>d__82 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public TRVLevelComplete <>4__this;
    private System.Collections.Generic.Dictionary<TRVPickerGameButton, int> <instaCards>5__2;
    private System.Collections.Generic.Dictionary.KeyCollection.Enumerator<TRVPickerGameButton, int> <>7__wrap2;
    private TRVPickerGameButton <newMulti>5__4;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public TRVLevelComplete.<StartMinigame>d__82(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
        if((this.<>1__state) != 5)
        {
                if((this.<>1__state) != 3)
        {
                return;
        }
        
        }
        
        this.<>m__Finally1();
    }
    private bool MoveNext()
    {
        int val_15;
        Dictionary.KeyCollection.Enumerator<TRVPickerGameButton, System.Int32> val_16;
        TRVLevelComplete val_79;
        int val_84;
        int val_85;
        UnityEngine.Sprite val_88;
        UnityEngine.Font val_89;
        if((this.<>1__state) > 6)
        {
                return (bool)val_84;
        }
        
        var val_78 = 32497752 + (this.<>1__state) << 2;
        val_79 = this.<>4__this;
        val_78 = val_78 + 32497752;
        goto (32497752 + (this.<>1__state) << 2 + 32497752);
        label_115:
        if(val_16.MoveNext() == false)
        {
            goto label_73;
        }
        
        TRVLevelComplete.<>c__DisplayClass82_0 val_51 = new TRVLevelComplete.<>c__DisplayClass82_0();
        if(val_51 == null)
        {
                throw new NullReferenceException();
        }
        
        .<>4__this = ;
        .multi = val_15;
        TRVLevelComplete.<>c__DisplayClass82_1 val_52 = new TRVLevelComplete.<>c__DisplayClass82_1();
        if(val_52 == null)
        {
                throw new NullReferenceException();
        }
        
        .CS$<>8__locals1 = val_51;
        if(val_52 == null)
        {
                throw new NullReferenceException();
        }
        
        TRVPickerGameButton val_54 = UnityEngine.Object.Instantiate<TRVPickerGameButton>(original:  val_51, parent:  val_52.transform);
        .newMulti = val_54;
        if(val_54 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_55 = val_54.gameObject;
        if(((TRVLevelComplete.<>c__DisplayClass82_1)[1152921517283947392].CS$<>8__locals1) == null)
        {
                throw new NullReferenceException();
        }
        
        val_16 = (TRVLevelComplete.<>c__DisplayClass82_1)[1152921517283947392].CS$<>8__locals1.multi;
        string val_79 = "Card ";
        if(val_55 == null)
        {
                throw new NullReferenceException();
        }
        
        val_55.name = "Card " + val_16;
        System.Action val_57 = new System.Action(object:  val_52, method:  System.Void TRVLevelComplete.<>c__DisplayClass82_1::<StartMinigame>b__1());
        if(((TRVLevelComplete.<>c__DisplayClass82_1)[1152921517283947392].newMulti) == null)
        {
                throw new NullReferenceException();
        }
        
        (TRVLevelComplete.<>c__DisplayClass82_1)[1152921517283947392].newMulti.onClickAction = val_57;
        if(val_57 == null)
        {
                throw new NullReferenceException();
        }
        
        if(((TRVLevelComplete.<>c__DisplayClass82_1)[1152921517283947392].CS$<>8__locals1) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_79 < ((TRVLevelComplete.<>c__DisplayClass82_1)[1152921517283947392].CS$<>8__locals1.multi))
        {
                val_88 = 0;
        }
        else
        {
                int val_58 = ((TRVLevelComplete.<>c__DisplayClass82_1)[1152921517283947392].CS$<>8__locals1.multi) - 1;
            if(val_79 <= val_58)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_79 = val_79 + (val_58 << 3);
            val_88 = mem[("Card " + (((TRVLevelComplete.<>c__DisplayClass82_1)[1152921517283947392].CS$<>8__locals1.multi - 1)) << 3) + 32];
            val_88 = ("Card " + (((TRVLevelComplete.<>c__DisplayClass82_1)[1152921517283947392].CS$<>8__locals1.multi - 1)) << 3) + 32;
        }
        
        if(((TRVLevelComplete.<>c__DisplayClass82_1)[1152921517283947392].newMulti) == null)
        {
                throw new NullReferenceException();
        }
        
        (TRVLevelComplete.<>c__DisplayClass82_1)[1152921517283947392].newMulti.specificSprite = val_88;
        if(((TRVLevelComplete.<>c__DisplayClass82_1)[1152921517283947392].CS$<>8__locals1) == null)
        {
                throw new NullReferenceException();
        }
        
        if((this.<instaCards>5__2) == null)
        {
                throw new NullReferenceException();
        }
        
        this.<instaCards>5__2.Add(key:  (TRVLevelComplete.<>c__DisplayClass82_1)[1152921517283947392].newMulti, value:  (TRVLevelComplete.<>c__DisplayClass82_1)[1152921517283947392].CS$<>8__locals1.multi);
        CompanyDevices val_59 = CompanyDevices.Instance;
        if(val_59 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_59.CompanyDevice() == false) || ((CPlayerPrefs.GetBool(key:  "DisplayCardValue", defaultValue:  false)) == false))
        {
            goto label_115;
        }
        
        System.Type[] val_62 = new System.Type[1];
        if(val_62 == null)
        {
                throw new NullReferenceException();
        }
        
        val_62[0] = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
        UnityEngine.GameObject val_64 = new UnityEngine.GameObject(name:  "multiHack", components:  val_62);
        if(val_64 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_65 = val_64.transform;
        if(((TRVLevelComplete.<>c__DisplayClass82_1)[1152921517283947392].newMulti) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_65 == null)
        {
                throw new NullReferenceException();
        }
        
        val_65.SetParent(p:  (TRVLevelComplete.<>c__DisplayClass82_1)[1152921517283947392].newMulti.transform);
        MonoExtensions.ResetLocal(trans:  val_64.transform);
        if(((TRVLevelComplete.<>c__DisplayClass82_1)[1152921517283947392].CS$<>8__locals1) == null)
        {
                throw new NullReferenceException();
        }
        
        string val_69 = (TRVLevelComplete.<>c__DisplayClass82_1)[1152921517283947392].CS$<>8__locals1.multi.ToString();
        if((val_64.AddComponent<UnityEngine.UI.Text>()) == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.UI.Text val_70 = val_64.GetComponent<UnityEngine.UI.Text>();
        string val_80 = "Arial.ttf";
        UnityEngine.Object val_72 = UnityEngine.Resources.GetBuiltinResource(type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), path:  val_80);
        if(val_70 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_72 != null)
        {
                val_80 = (null == null) ? (val_72) : 0;
        }
        else
        {
                val_89 = 0;
        }
        
        val_70.font = val_89;
        UnityEngine.UI.Text val_73 = val_64.GetComponent<UnityEngine.UI.Text>();
        if(val_73 == null)
        {
                throw new NullReferenceException();
        }
        
        val_73.resizeTextForBestFit = true;
        UnityEngine.UI.Text val_74 = val_64.GetComponent<UnityEngine.UI.Text>();
        if(val_74 == null)
        {
                throw new NullReferenceException();
        }
        
        val_74.resizeTextMaxSize = 231;
        UnityEngine.UI.Outline val_75 = val_64.AddComponent<UnityEngine.UI.Outline>();
        val_16 = 0;
        UnityEngine.Vector2 val_76 = new UnityEngine.Vector2(x:  4f, y:  4f);
        if(val_75 == null)
        {
                throw new NullReferenceException();
        }
        
        val_75.effectDistance = new UnityEngine.Vector2() {x = val_76.x, y = val_76.y};
        goto label_115;
        label_73:
        val_79 = 0;
        val_16.Dispose();
        if(val_79 != 0)
        {
                throw null;
        }
        
        this.<>2__current = new UnityEngine.WaitForEndOfFrame();
        val_85 = 4;
        this.<>1__state = val_85;
        val_84 = 1;
        return (bool)val_84;
    }
    private void <>m__Finally1()
    {
        this.<>1__state = 0;
        this.<>7__wrap2.Dispose();
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
