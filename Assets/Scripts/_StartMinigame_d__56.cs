using UnityEngine;
private sealed class FPHLevelCompletePopup.<StartMinigame>d__56 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public FPHLevelCompletePopup <>4__this;
    private System.Collections.Generic.List<FPHPickerGameButton> <instaCards>5__2;
    private System.Collections.Generic.List.Enumerator<FPHPickerGameButton> <>7__wrap2;
    private FPHPickerGameButton <newMulti>5__4;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public FPHLevelCompletePopup.<StartMinigame>d__56(int <>1__state)
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
        int val_5;
        List.Enumerator<FPHPickerGameButton> val_6;
        FPHLevelCompletePopup val_64;
        int val_65;
        int val_67;
        UnityEngine.Sprite val_69;
        UnityEngine.Font val_70;
        if((this.<>1__state) > 8)
        {
                return (bool)val_65;
        }
        
        var val_63 = 32562492 + (this.<>1__state) << 2;
        val_64 = this.<>4__this;
        val_63 = val_63 + 32562492;
        goto (32562492 + (this.<>1__state) << 2 + 32562492);
        label_62:
        if(val_6.MoveNext() == false)
        {
            goto label_25;
        }
        
        FPHLevelCompletePopup.<>c__DisplayClass56_0 val_22 = new FPHLevelCompletePopup.<>c__DisplayClass56_0();
        if(val_22 == null)
        {
                throw new NullReferenceException();
        }
        
        .currMulti = val_5;
        mem[1152921515968242336] = ;
        if(val_22 == null)
        {
                throw new NullReferenceException();
        }
        
        FPHPickerGameButton val_24 = UnityEngine.Object.Instantiate<FPHPickerGameButton>(original:  val_5, parent:  val_22.transform);
        .newMulti = val_24;
        if(val_24 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_25 = val_24.gameObject;
        val_6 = .currMulti;
        if(val_25 == null)
        {
                throw new NullReferenceException();
        }
        
        val_25.name = "Card " + val_6;
        var val_64 = 1152921504614301696;
        System.Action val_27 = new System.Action(object:  val_22, method:  System.Void FPHLevelCompletePopup.<>c__DisplayClass56_0::<StartMinigame>b__0());
        if(((FPHLevelCompletePopup.<>c__DisplayClass56_0)[1152921515968242304].newMulti) == null)
        {
                throw new NullReferenceException();
        }
        
        (FPHLevelCompletePopup.<>c__DisplayClass56_0)[1152921515968242304].newMulti.onClickAction = val_27;
        if(val_27 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_64 < .currMulti)
        {
                val_69 = 0;
        }
        else
        {
                int val_28 = .currMulti - 1;
            if(val_64 <= val_28)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_64 = val_64 + (val_28 << 3);
            val_69 = mem[(1152921504614301696 + ((val_5 - 1)) << 3) + 32];
            val_69 = (1152921504614301696 + ((val_5 - 1)) << 3) + 32;
        }
        
        if(((FPHLevelCompletePopup.<>c__DisplayClass56_0)[1152921515968242304].newMulti) == null)
        {
                throw new NullReferenceException();
        }
        
        (FPHLevelCompletePopup.<>c__DisplayClass56_0)[1152921515968242304].newMulti.specificSprite = val_69;
        if((this.<instaCards>5__2) == null)
        {
                throw new NullReferenceException();
        }
        
        this.<instaCards>5__2.Add(item:  (FPHLevelCompletePopup.<>c__DisplayClass56_0)[1152921515968242304].newMulti);
        CompanyDevices val_29 = CompanyDevices.Instance;
        if(val_29 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_29.CompanyDevice() == false) || ((CPlayerPrefs.GetBool(key:  "DisplayCardValue", defaultValue:  false)) == false))
        {
            goto label_62;
        }
        
        System.Type[] val_32 = new System.Type[1];
        if(val_32 == null)
        {
                throw new NullReferenceException();
        }
        
        val_32[0] = System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle());
        UnityEngine.GameObject val_34 = new UnityEngine.GameObject(name:  "multiHack", components:  val_32);
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_35 = val_34.transform;
        if(((FPHLevelCompletePopup.<>c__DisplayClass56_0)[1152921515968242304].newMulti) == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_35 == null)
        {
                throw new NullReferenceException();
        }
        
        val_35.SetParent(p:  (FPHLevelCompletePopup.<>c__DisplayClass56_0)[1152921515968242304].newMulti.transform);
        MonoExtensions.ResetLocal(trans:  val_34.transform);
        string val_39 = .currMulti.ToString();
        if((val_34.AddComponent<UnityEngine.UI.Text>()) == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.UI.Text val_40 = val_34.GetComponent<UnityEngine.UI.Text>();
        string val_65 = "Arial.ttf";
        UnityEngine.Object val_42 = UnityEngine.Resources.GetBuiltinResource(type:  System.Type.GetTypeFromHandle(handle:  new System.RuntimeTypeHandle()), path:  val_65);
        if(val_40 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_42 != null)
        {
                val_65 = (null == null) ? (val_42) : 0;
        }
        else
        {
                val_70 = 0;
        }
        
        val_40.font = val_70;
        UnityEngine.UI.Text val_43 = val_34.GetComponent<UnityEngine.UI.Text>();
        if(val_43 == null)
        {
                throw new NullReferenceException();
        }
        
        val_43.resizeTextForBestFit = true;
        UnityEngine.UI.Text val_44 = val_34.GetComponent<UnityEngine.UI.Text>();
        if(val_44 == null)
        {
                throw new NullReferenceException();
        }
        
        val_44.resizeTextMaxSize = 231;
        UnityEngine.UI.Outline val_45 = val_34.AddComponent<UnityEngine.UI.Outline>();
        val_6 = 0;
        UnityEngine.Vector2 val_46 = new UnityEngine.Vector2(x:  4f, y:  4f);
        if(val_45 == null)
        {
                throw new NullReferenceException();
        }
        
        val_45.effectDistance = new UnityEngine.Vector2() {x = val_46.x, y = val_46.y};
        goto label_62;
        label_25:
        val_64 = 0;
        val_6.Dispose();
        if(val_64 != 0)
        {
                throw null;
        }
        
        this.<>2__current = new UnityEngine.WaitForEndOfFrame();
        val_67 = 4;
        this.<>1__state = val_67;
        val_65 = 1;
        return (bool)val_65;
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
