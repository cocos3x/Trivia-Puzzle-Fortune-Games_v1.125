using UnityEngine;
public class WADPetsFeedFoodPopup : MonoBehaviour
{
    // Fields
    private System.Collections.Generic.List<WADPetCardItem> cards;
    private UnityEngine.ParticleSystem particles;
    private UnityEngine.UI.Text description;
    private UnityEngine.UI.Button storeButton;
    private UnityEngine.UI.Button infoButton;
    private UnityEngine.UI.Button feedButton;
    private UnityEngine.UI.Button visitPetsButton;
    private UnityEngine.UI.Button closeButton;
    
    // Methods
    private void Awake()
    {
        this.storeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WADPetsFeedFoodPopup::OnClick_FoodStore()));
        this.infoButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WADPetsFeedFoodPopup::OnClick_Info()));
        this.feedButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WADPetsFeedFoodPopup::OnClick_Feed()));
        this.visitPetsButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WADPetsFeedFoodPopup::OnClick_VisitPets()));
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WADPetsFeedFoodPopup::Close()));
    }
    private void Start()
    {
        var val_3;
        this.UpdateCardsCollection();
        val_3 = null;
        val_3 = null;
        string val_2 = System.String.Format(format:  Localization.Localize(key:  "feed_your_pets_popup_description", defaultValue:  "One food feeds all your pets for {0} hours!", useSingularKey:  false), arg0:  WADPets.WADPetsEcon.FedDurationHours);
    }
    private void UpdateCardsCollection()
    {
        System.Collections.Generic.List<WADPets.WADPet> val_1 = WADPetsManager.AllPetsCollection;
        if(true < 1)
        {
                return;
        }
        
        var val_3 = 0;
        do
        {
            if(W9 <= val_3)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            var val_2 = X9 + 0;
            if(true <= val_3)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            (X9 + 0) + 32.Setup(pet:  0, highlight:  false);
            val_3 = val_3 + 1;
        }
        while(val_3 < 1);
    
    }
    private System.Collections.IEnumerator OnFed()
    {
        .<>1__state = 0;
        .<>4__this = this;
        return (System.Collections.IEnumerator)new WADPetsFeedFoodPopup.<OnFed>d__11();
    }
    private void DeactivateAllButtons()
    {
        this.feedButton.interactable = false;
        this.visitPetsButton.interactable = false;
        this.storeButton.interactable = false;
    }
    private void OnClick_Feed()
    {
        var val_10;
        System.Action val_12;
        this.DeactivateAllButtons();
        if((MonoSingleton<WADPetsManager>.Instance.FeedAllPets()) != false)
        {
                UnityEngine.Coroutine val_4 = this.StartCoroutine(routine:  this.OnFed());
            return;
        }
        
        GameBehavior val_5 = App.getBehavior;
        SLCWindow val_7 = val_5.<metaGameBehavior>k__BackingField.GetComponent<SLCWindow>();
        val_10 = null;
        val_10 = null;
        val_12 = WADPetsFeedFoodPopup.<>c.<>9__13_0;
        if(val_12 == null)
        {
                System.Action val_8 = null;
            val_12 = val_8;
            val_8 = new System.Action(object:  WADPetsFeedFoodPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WADPetsFeedFoodPopup.<>c::<OnClick_Feed>b__13_0());
            WADPetsFeedFoodPopup.<>c.<>9__13_0 = val_12;
        }
        
        val_7.Action_OnClose = val_12;
        val_5.<metaGameBehavior>k__BackingField.Init(type:  0);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClick_VisitPets()
    {
        this.DeactivateAllButtons();
        WADPetsScreenUI.ShowMainScreen();
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClick_Info()
    {
        var val_6;
        System.Action val_8;
        this.DeactivateAllButtons();
        GameBehavior val_1 = App.getBehavior;
        SLCWindow val_3 = val_1.<metaGameBehavior>k__BackingField.GetComponent<SLCWindow>();
        val_6 = null;
        val_6 = null;
        val_8 = WADPetsFeedFoodPopup.<>c.<>9__15_0;
        if(val_8 == null)
        {
                System.Action val_4 = null;
            val_8 = val_4;
            val_4 = new System.Action(object:  WADPetsFeedFoodPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WADPetsFeedFoodPopup.<>c::<OnClick_Info>b__15_0());
            WADPetsFeedFoodPopup.<>c.<>9__15_0 = val_8;
        }
        
        val_3.Action_OnClose = val_8;
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void OnClick_FoodStore()
    {
        var val_6;
        var val_7;
        System.Action val_9;
        this.DeactivateAllButtons();
        val_6 = null;
        val_6 = null;
        PurchaseProxy.currentPurchasePoint = 80;
        GameBehavior val_1 = App.getBehavior;
        SLCWindow val_3 = val_1.<metaGameBehavior>k__BackingField.GetComponent<SLCWindow>();
        val_7 = null;
        val_7 = null;
        val_9 = WADPetsFeedFoodPopup.<>c.<>9__16_0;
        if(val_9 == null)
        {
                System.Action val_4 = null;
            val_9 = val_4;
            val_4 = new System.Action(object:  WADPetsFeedFoodPopup.<>c.__il2cppRuntimeField_static_fields, method:  System.Void WADPetsFeedFoodPopup.<>c::<OnClick_FoodStore>b__16_0());
            WADPetsFeedFoodPopup.<>c.<>9__16_0 = val_9;
        }
        
        val_3.Action_OnClose = val_9;
        val_1.<metaGameBehavior>k__BackingField.Init(type:  0);
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public WADPetsFeedFoodPopup()
    {
    
    }

}
