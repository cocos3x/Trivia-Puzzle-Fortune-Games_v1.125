using UnityEngine;
public class WADPetsFtuxPopup : MonoBehaviour
{
    // Fields
    private System.Collections.Generic.List<WADPetsFtuxDisplay> petsDisplay;
    private WADPets.WADPet pendingAlphabetTilePet;
    private System.Collections.Generic.List<WADPets.WADPet> pendingFtuxes;
    private bool onEnabled;
    
    // Methods
    private void OnEnable()
    {
        HintFeatureManager val_1 = MonoSingleton<HintFeatureManager>.Instance;
        val_1.<wgHbutton>k__BackingField.GetComponent<UnityEngine.UI.Button>().enabled = false;
        HintPickerController val_3 = MonoSingleton<HintPickerController>.Instance;
        val_3.gameHintPickerButton.GetComponent<UnityEngine.UI.Button>().enabled = false;
        MonoSingleton<AdsUIController>.Instance.FreeHintButtonGroup.GetComponent<UnityEngine.UI.Button>().enabled = false;
        GameBehavior val_8 = App.getBehavior;
        if(((val_8.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                Alphabet2Manager val_9 = MonoSingleton<Alphabet2Manager>.Instance;
            if(val_9.currentAlphabetTileObject != 0)
        {
                Alphabet2Manager val_11 = MonoSingleton<Alphabet2Manager>.Instance;
            val_11.currentAlphabetTileObject.transform.parent.GetComponent<UnityEngine.UI.Button>().enabled = false;
        }
        
        }
        
        this.onEnabled = true;
        if(this.pendingFtuxes != null)
        {
                if(true == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            this.ShowFtux(pet:  0);
            return;
        }
        
        if(this.pendingAlphabetTilePet == null)
        {
                return;
        }
        
        this.Close();
    }
    private void OnDisable()
    {
        UnityEngine.GameObject val_15;
        HintFeatureManager val_1 = MonoSingleton<HintFeatureManager>.Instance;
        val_1.<wgHbutton>k__BackingField.GetComponent<UnityEngine.UI.Button>().enabled = true;
        HintPickerController val_3 = MonoSingleton<HintPickerController>.Instance;
        val_15 = 1152921513413701424;
        val_3.gameHintPickerButton.GetComponent<UnityEngine.UI.Button>().enabled = true;
        MonoSingleton<AdsUIController>.Instance.FreeHintButtonGroup.GetComponent<UnityEngine.UI.Button>().enabled = true;
        GameBehavior val_8 = App.getBehavior;
        if(((val_8.<metaGameBehavior>k__BackingField) & 1) == 0)
        {
                return;
        }
        
        Alphabet2Manager val_9 = MonoSingleton<Alphabet2Manager>.Instance;
        val_15 = val_9.currentAlphabetTileObject;
        if(val_15 == 0)
        {
                return;
        }
        
        Alphabet2Manager val_11 = MonoSingleton<Alphabet2Manager>.Instance;
        val_11.currentAlphabetTileObject.transform.parent.GetComponent<UnityEngine.UI.Button>().enabled = true;
    }
    public void SetupFtux(System.Collections.Generic.List<WADPets.WADPet> pets)
    {
        UnityEngine.Events.UnityAction val_8;
        .pets = pets;
        .<>4__this = this;
        this.pendingFtuxes = pets;
        this.DeactiveAllFtux();
        WADPetsFtuxPopup.<>c__DisplayClass6_1 val_2 = new WADPetsFtuxPopup.<>c__DisplayClass6_1();
        .CS$<>8__locals1 = new WADPetsFtuxPopup.<>c__DisplayClass6_0();
        .i = 0;
        label_16:
        if(0 >= ((WADPetsFtuxPopup.<>c__DisplayClass6_0)[1152921517720343248].pets))
        {
            goto label_4;
        }
        
        if((this.petsDisplay.Find(match:  new System.Predicate<WADPetsFtuxDisplay>(object:  val_2, method:  System.Boolean WADPetsFtuxPopup.<>c__DisplayClass6_1::<SetupFtux>b__0(WADPetsFtuxDisplay x)))) != null)
        {
                System.Collections.Generic.List<WADPets.WADPet> val_8 = (WADPetsFtuxPopup.<>c__DisplayClass6_1)[1152921517720347344].CS$<>8__locals1.pets;
            val_8 = val_8 - 1;
            if(((WADPetsFtuxPopup.<>c__DisplayClass6_1)[1152921517720347344].i) == val_8)
        {
                val_8 = new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WADPetsFtuxPopup::Close());
        }
        else
        {
                .CS$<>8__locals2 = val_2;
            int val_9 = (WADPetsFtuxPopup.<>c__DisplayClass6_1)[1152921517720347344].i;
            val_9 = val_9 + 1;
            .nextPetIndex = val_9;
            UnityEngine.Events.UnityAction val_7 = new UnityEngine.Events.UnityAction(object:  new WADPetsFtuxPopup.<>c__DisplayClass6_2(), method:  System.Void WADPetsFtuxPopup.<>c__DisplayClass6_2::<SetupFtux>b__1());
            val_8 = val_7;
        }
        
            val_4.OkButton.m_OnClick.AddListener(call:  val_7);
        }
        
        int val_10 = (WADPetsFtuxPopup.<>c__DisplayClass6_1)[1152921517720347344].i;
        val_10 = val_10 + 1;
        .i = val_10;
        if(((WADPetsFtuxPopup.<>c__DisplayClass6_1)[1152921517720347344].CS$<>8__locals1) != null)
        {
            goto label_16;
        }
        
        label_4:
        if(this.onEnabled == false)
        {
                return;
        }
        
        if((mem[pets + 24]) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        this.ShowFtux(pet:  mem[pets + 16] + 32);
    }
    public void AddPetAlphabetTileFtux(WADPets.WADPet pet)
    {
        var val_8;
        this.pendingAlphabetTilePet = pet;
        GameBehavior val_1 = App.getBehavior;
        if(((val_1.<metaGameBehavior>k__BackingField) & 1) != 0)
        {
                val_8 = 1152921504893161472;
            Alphabet2Manager val_2 = MonoSingleton<Alphabet2Manager>.Instance;
            if(val_2.currentAlphabetTileObject != 0)
        {
                Alphabet2Manager val_4 = MonoSingleton<Alphabet2Manager>.Instance;
            val_4.currentAlphabetTileObject.transform.parent.GetComponent<UnityEngine.UI.Button>().enabled = false;
        }
        
        }
        
        if(this.onEnabled == false)
        {
                return;
        }
        
        this.Close();
    }
    private void ShowFtux(WADPets.WADPet pet)
    {
        object val_69;
        System.Collections.Generic.List<WADPetsFtuxDisplay> val_70;
        var val_71;
        float val_72;
        float val_73;
        float val_74;
        UnityEngine.Transform val_75;
        WADPetsFtuxPopup.<>c__DisplayClass8_0 val_1 = null;
        val_69 = val_1;
        val_1 = new WADPetsFtuxPopup.<>c__DisplayClass8_0();
        .pet = pet;
        this.DeactiveAllFtux();
        val_70 = this.petsDisplay;
        WADPetsFtuxDisplay val_3 = val_70.Find(match:  new System.Predicate<WADPetsFtuxDisplay>(object:  val_1, method:  System.Boolean WADPetsFtuxPopup.<>c__DisplayClass8_0::<ShowFtux>b__0(WADPetsFtuxDisplay x)));
        .petFtuxDisplay = val_3;
        if(val_3 == null)
        {
            goto label_3;
        }
        
        val_71 = null;
        val_71 = null;
        System.Collections.Generic.KeyValuePair<System.String, System.String> val_4 = WADPets.LocTexts.FtuxDescription.Item[(WADPetsFtuxPopup.<>c__DisplayClass8_0)[1152921517721081488].pet.Info.Ability];
        string val_7 = System.String.Format(format:  Localization.Localize(key:  val_4.Value, defaultValue:  (WADPetsFtuxPopup.<>c__DisplayClass8_0)[1152921517721081488].pet.Info.Ability, useSingularKey:  false), arg0:  (WADPetsFtuxPopup.<>c__DisplayClass8_0)[1152921517721081488].pet.GetPrettyName());
        MonoSingleton<GameMaskOverlay>.Instance.CloseOverlay(onClosed:  0);
        UnityEngine.Color val_10 = new UnityEngine.Color(r:  0f, g:  0f, b:  0f, a:  0f);
        System.Nullable<UnityEngine.Color> val_11 = new System.Nullable<UnityEngine.Color>(value:  new UnityEngine.Color() {r = val_10.r, g = val_10.g, b = val_10.b, a = val_10.a});
        val_72 = 0.15f;
        val_73 = 0.25f;
        MonoSingleton<GameMaskOverlay>.Instance.SetOptions(bgColor:  new System.Nullable<UnityEngine.Color>() {HasValue = true}, fadeInDuration:  val_73, fadeOutDuration:  val_72);
        MonoSingleton<GameMaskOverlay>.Instance.BlockRaycasts = true;
        MonoSingleton<GameMaskOverlay>.Instance.Interactable = true;
        System.Collections.Generic.List<UnityEngine.Transform> val_14 = null;
        val_70 = val_14;
        val_14 = new System.Collections.Generic.List<UnityEngine.Transform>();
        if(((WADPetsFtuxPopup.<>c__DisplayClass8_0)[1152921517721081488].pet.Info.Ability) > 4)
        {
            goto label_20;
        }
        
        var val_68 = 32498428 + ((WADPetsFtuxPopup.<>c__DisplayClass8_0)[1152921517721081488].pet.Info.Ability) << 2;
        val_68 = val_68 + 32498428;
        goto (32498428 + ((WADPetsFtuxPopup.<>c__DisplayClass8_0)[1152921517721081488].pet.Info.Ability) << 2 + 32498428);
        label_3:
        val_69 = System.String.Format(format:  "Error: showing {0} but it is not setup in the FTUX popup", arg0:  (WADPetsFtuxPopup.<>c__DisplayClass8_0)[1152921517721081488].pet.GetPrettyName());
        UnityEngine.Debug.LogError(message:  val_69);
        this.Close();
        return;
        label_20:
        val_75 = 0;
        val_74 = 0.5f;
        (WADPetsFtuxPopup.<>c__DisplayClass8_0)[1152921517721081488].petFtuxDisplay.Holder.SetActive(value:  true);
        val_14.Add(item:  null);
        val_14.Add(item:  (WADPetsFtuxPopup.<>c__DisplayClass8_0)[1152921517721081488].petFtuxDisplay.Holder.transform);
        MonoSingleton<GameMaskOverlay>.Instance.ShowOverlay(contentToOverlay:  val_14.ToArray());
        if(((WADPetsFtuxPopup.<>c__DisplayClass8_0)[1152921517721081488].pet.Info.Ability) < 2)
        {
            goto label_59;
        }
        
        if(((WADPetsFtuxPopup.<>c__DisplayClass8_0)[1152921517721081488].pet.Info.Ability) == 3)
        {
            goto label_60;
        }
        
        if(((WADPetsFtuxPopup.<>c__DisplayClass8_0)[1152921517721081488].pet.Info.Ability) != 4)
        {
                return;
        }
        
        label_59:
        UnityEngine.Transform val_35 = (WADPetsFtuxPopup.<>c__DisplayClass8_0)[1152921517721081488].petFtuxDisplay.Holder.transform;
        UnityEngine.Vector3 val_37 = (WADPetsFtuxPopup.<>c__DisplayClass8_0)[1152921517721081488].petFtuxDisplay.Holder.transform.position;
        UnityEngine.Vector3 val_38 = position;
        UnityEngine.Vector3 val_40 = (WADPetsFtuxPopup.<>c__DisplayClass8_0)[1152921517721081488].petFtuxDisplay.Holder.transform.position;
        UnityEngine.Vector3 val_42 = new UnityEngine.Vector3(x:  val_37.x, y:  val_74 + val_38.y, z:  val_40.z);
        goto label_72;
        label_60:
        Alphabet2Manager val_43 = MonoSingleton<Alphabet2Manager>.Instance;
        val_70 = val_43.currentAlphabetTileObject;
        UnityEngine.Vector2 val_45 = val_70.GetComponent<UnityEngine.RectTransform>().anchoredPosition;
        WADPetsFtuxDisplay val_47 = this.petsDisplay.Find(match:  new System.Predicate<WADPetsFtuxDisplay>(object:  val_1, method:  System.Boolean WADPetsFtuxPopup.<>c__DisplayClass8_0::<ShowFtux>b__1(WADPetsFtuxDisplay x)));
        val_47.Holder.transform.parent = val_70.transform;
        UnityEngine.Vector3 val_52 = val_47.Holder.transform.localPosition;
        UnityEngine.Vector3 val_54 = new UnityEngine.Vector3(x:  UnityEngine.Mathf.Clamp(value:  val_52.x, min:  -30f, max:  30f), y:  val_74, z:  0f);
        val_47.Holder.transform.localPosition = new UnityEngine.Vector3() {x = val_54.x, y = val_54.y, z = val_54.z};
        UnityEngine.Camera val_55 = SLCWindowManager<WGWindowManager>.monolithPopupCamera;
        UnityEngine.Vector3 val_57 = val_47.Holder.transform.position;
        UnityEngine.Vector3 val_58 = val_55.WorldToViewportPoint(position:  new UnityEngine.Vector3() {x = val_57.x, y = val_57.y, z = val_57.z});
        UnityEngine.Vector3 val_61 = val_55.ViewportToWorldPoint(position:  new UnityEngine.Vector3() {x = UnityEngine.Mathf.Clamp(value:  val_58.x, min:  0.4f, max:  0.6f), y = val_58.y, z = val_58.z});
        val_47.Holder.transform.position = new UnityEngine.Vector3() {x = val_61.x, y = val_61.y, z = val_61.z};
        UnityEngine.Vector3 val_63 = (WADPetsFtuxPopup.<>c__DisplayClass8_0)[1152921517721081488].petFtuxDisplay.TooltipPick.transform.position;
        val_74 = val_63.y;
        val_69 = (WADPetsFtuxPopup.<>c__DisplayClass8_0)[1152921517721081488].petFtuxDisplay.TooltipPick.transform;
        UnityEngine.Vector3 val_66 = val_70.transform.position;
        UnityEngine.Vector3 val_67 = new UnityEngine.Vector3(x:  val_66.x, y:  val_74, z:  val_63.z);
        label_72:
        val_69.position = new UnityEngine.Vector3() {x = val_67.x, y = val_67.y, z = val_67.z};
    }
    private void DeactiveAllFtux()
    {
        var val_3;
        List.Enumerator<T> val_1 = this.petsDisplay.GetEnumerator();
        label_5:
        if(0.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_3 = 9733424;
        if(val_3 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_3.SetActive(value:  false);
        goto label_5;
        label_2:
        0.Dispose();
    }
    private void Close()
    {
        if(this.pendingAlphabetTilePet != null)
        {
                this.onEnabled = false;
            System.Collections.Generic.List<WADPets.WADPet> val_1 = new System.Collections.Generic.List<WADPets.WADPet>();
            val_1.Add(item:  this.pendingAlphabetTilePet);
            this.SetupFtux(pets:  val_1);
            this.ShowFtux(pet:  this.pendingAlphabetTilePet);
            this.pendingAlphabetTilePet = 0;
            return;
        }
        
        MonoSingleton<GameMaskOverlay>.Instance.CloseOverlay(onClosed:  new System.Action(object:  this, method:  System.Void WADPetsFtuxPopup::<Close>b__10_0()));
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public WADPetsFtuxPopup()
    {
    
    }
    private void <Close>b__10_0()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }

}
