using UnityEngine;
public class WADPetUnlockedPopup : MonoBehaviour
{
    // Fields
    private Spine.Unity.SkeletonGraphic skeletonGraphic;
    private UnityEngine.UI.Text description;
    private UnityEngine.UI.Button meetPetButton;
    private UnityEngine.UI.Text buttonText;
    private UnityEngine.UI.Button closeButton;
    
    // Methods
    public void Setup(WADPets.WADPet pet)
    {
        .<>4__this = this;
        .pet = pet;
        this.skeletonGraphic.skeletonDataAsset = pet.Info.AnimIdleSkeletonDataAsset;
        this.skeletonGraphic.Initialize(overwrite:  true);
        if(this.skeletonGraphic.IsValid != false)
        {
                this.skeletonGraphic.startingAnimation = "Idle";
            Spine.TrackEntry val_3 = this.skeletonGraphic.state.SetAnimation(trackIndex:  0, animationName:  this.skeletonGraphic.startingAnimation, loop:  true);
            this.skeletonGraphic.skeleton.SetSlotsToSetupPose();
        }
        
        string val_6 = System.String.Format(format:  Localization.Localize(key:  "wadpets_unlocked_desc", defaultValue:  "You’ve collected enough cards to unlock {0}!", useSingularKey:  false), arg0:  (WADPetUnlockedPopup.<>c__DisplayClass5_0)[1152921517715922080].pet.GetPrettyName());
        mem2[0] = (WADPetUnlockedPopup.<>c__DisplayClass5_0)[1152921517715922080].pet.Info.Name;
        string val_10 = System.String.Format(format:  "{0} {1}", arg0:  Localization.Localize(key:  "meet_upper", defaultValue:  "MEET", useSingularKey:  false), arg1:  (WADPetUnlockedPopup.<>c__DisplayClass5_0)[1152921517715922080].pet.Info.Name.ToString().ToUpper());
        this.meetPetButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  new WADPetUnlockedPopup.<>c__DisplayClass5_0(), method:  System.Void WADPetUnlockedPopup.<>c__DisplayClass5_0::<Setup>b__0()));
        this.closeButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WADPetUnlockedPopup::Close()));
    }
    private void OnClick_MeetPet(WADPets.WADPet pet)
    {
        null = null;
        PetsScreenMain.HighlightPet = pet;
        WADPetsScreenUI.ShowMainScreen();
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    private void Close()
    {
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    public WADPetUnlockedPopup()
    {
    
    }

}
