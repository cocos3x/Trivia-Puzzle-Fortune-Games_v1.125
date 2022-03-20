using UnityEngine;
private sealed class LevelCompleteGoldenApplesUI.<StartShowingPetFtux>d__11 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public LevelCompleteGoldenApplesUI <>4__this;
    public WADPets.WADPet pet;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public LevelCompleteGoldenApplesUI.<StartShowingPetFtux>d__11(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        object val_21;
        int val_22;
        var val_23;
        object val_24;
        var val_25;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_2;
        }
        
        this.<>1__state = 0;
        UnityEngine.WaitForEndOfFrame val_1 = null;
        val_21 = val_1;
        val_1 = new UnityEngine.WaitForEndOfFrame();
        val_22 = 1;
        this.<>2__current = val_21;
        this.<>1__state = val_22;
        return (bool)val_22;
        label_1:
        this.<>1__state = 0;
        val_23 = null;
        val_23 = null;
        System.Collections.Generic.KeyValuePair<System.String, System.String> val_2 = WADPets.LocTexts.FtuxDescription.Item[2];
        val_24 = Localization.Localize(key:  "golden_apples_cap_first", defaultValue:  "Golden Apples", useSingularKey:  false);
        val_25 = null;
        val_25 = null;
        if(App.game == 4)
        {
                val_24 = Localization.Localize(key:  "acorns_cap_first", defaultValue:  "Acorns", useSingularKey:  false);
        }
        
        string val_7 = System.String.Format(format:  Localization.Localize(key:  val_2.Value, defaultValue:  2, useSingularKey:  false), arg0:  this.pet.GetPrettyName(), arg1:  val_24);
        this.<>4__this.petFtuxGroup.SetActive(value:  true);
        this.<>4__this.petFtuxOkButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this.<>4__this, method:  System.Void LevelCompleteGoldenApplesUI::<StartShowingPetFtux>b__11_0()));
        MonoSingleton<GameMaskOverlay>.Instance.CloseOverlay(onClosed:  0);
        UnityEngine.Color val_11 = new UnityEngine.Color(r:  0f, g:  0f, b:  0f, a:  0.45f);
        System.Nullable<UnityEngine.Color> val_12 = new System.Nullable<UnityEngine.Color>(value:  new UnityEngine.Color() {r = val_11.r, g = val_11.g, b = val_11.b, a = val_11.a});
        MonoSingleton<GameMaskOverlay>.Instance.SetOptions(bgColor:  new System.Nullable<UnityEngine.Color>() {HasValue = true}, fadeInDuration:  0.25f, fadeOutDuration:  0.15f);
        MonoSingleton<GameMaskOverlay>.Instance.BlockRaycasts = true;
        MonoSingleton<GameMaskOverlay>.Instance.Interactable = true;
        System.Collections.Generic.List<UnityEngine.Transform> val_15 = new System.Collections.Generic.List<UnityEngine.Transform>();
        val_15.Add(item:  this.<>4__this.petFtuxGroup.transform);
        val_15.Add(item:  this.<>4__this.goldenApplesGroup_pets.transform);
        val_21 = MonoSingleton<GameMaskOverlay>.Instance;
        val_21.ShowOverlay(contentToOverlay:  val_15.ToArray());
        label_2:
        val_22 = 0;
        return (bool)val_22;
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
