using UnityEngine;
public class PetsScreenMain : MonoSingleton<PetsScreenMain>
{
    // Fields
    public static WADPets.WADPet HighlightPet;
    private UnityEngine.UI.Button buttonExit;
    private UnityEngine.UI.Button buttonInfo;
    private WADPetProfile petProfile;
    private UnityEngine.RectTransform petsContainer;
    private UnityEngine.GameObject petCardItemPrefab;
    private bool initialized;
    
    // Methods
    public override void InitMonoSingleton()
    {
        this.buttonExit.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void PetsScreenMain::BackToLobby()));
        this.buttonInfo.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void PetsScreenMain::OnClick_PetsInfo()));
    }
    public void Start()
    {
        this.Refresh(highlightPet:  0);
    }
    public void Refresh(WADPets.WADPet highlightPet)
    {
        WADPets.WADPet val_2;
        var val_3;
        var val_4;
        val_2 = highlightPet;
        if(this.initialized == false)
        {
            goto label_1;
        }
        
        if(val_2 != null)
        {
            goto label_4;
        }
        
        goto label_3;
        label_1:
        this.InitializePets();
        this.initialized = true;
        if(val_2 != null)
        {
            goto label_4;
        }
        
        label_3:
        val_3 = null;
        val_3 = null;
        if(PetsScreenMain.HighlightPet != null)
        {
                val_3 = null;
        }
        else
        {
                System.Collections.Generic.List<WADPets.WADPet> val_1 = WADPetsManager.GetAllPetsCollection();
            if(PetsScreenMain.HighlightPet == null)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_3 = null;
            val_4 = 1152921504936988704;
        }
        
        val_2 = mem[1152921504936988704];
        val_3 = null;
        PetsScreenMain.HighlightPet = 0;
        label_4:
        this.petProfile.Setup(pet:  val_2);
        this.UpdateCardsCollection(highlightPet:  val_2);
    }
    private void Initialize()
    {
        this.InitializePets();
        this.initialized = true;
    }
    private void InitializePets()
    {
        WADPets.WADPet val_3;
        var val_4;
        UnityEngine.Transform val_9;
        List.Enumerator<T> val_2 = WADPetsManager.GetAllPetsCollection().GetEnumerator();
        label_13:
        val_9 = public System.Boolean List.Enumerator<WADPets.WADPet>::MoveNext();
        if(val_4.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(val_3 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_3 + 16) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((val_3 + 16 + 20) == 3)
        {
                if(Alphabet2Manager.IsAvailable == false)
        {
            goto label_13;
        }
        
        }
        
        val_9 = this.petsContainer;
        UnityEngine.GameObject val_7 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.petCardItemPrefab, parent:  val_9);
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        val_9 = public WADPetCardItem UnityEngine.GameObject::GetComponent<WADPetCardItem>();
        WADPetCardItem val_8 = val_7.GetComponent<WADPetCardItem>();
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        val_8.Setup(pet:  val_3, highlight:  false);
        goto label_13;
        label_2:
        val_4.Dispose();
    }
    private void UpdateCardsCollection(WADPets.WADPet highlightPet)
    {
        if(val_1.Length < 1)
        {
                return;
        }
        
        var val_3 = 0;
        do
        {
            this.petsContainer.GetComponentsInChildren<WADPetCardItem>()[val_3].UpdateCard(highlightedPet:  highlightPet);
            val_3 = val_3 + 1;
        }
        while(val_3 < val_1.Length);
    
    }
    private void OnClick_PetsInfo()
    {
        WADPetsWindowManager val_2 = MonoSingleton<WADPetsWindowManager>.Instance.ShowUGUIMonolith<WADPetsInfoPopup>(showNext:  false);
    }
    private void BackToLobby()
    {
        MonoSingleton<WADPetsScreenUI>.Instance.BackButtonPressed();
    }
    public PetsScreenMain()
    {
    
    }
    private static PetsScreenMain()
    {
    
    }

}
