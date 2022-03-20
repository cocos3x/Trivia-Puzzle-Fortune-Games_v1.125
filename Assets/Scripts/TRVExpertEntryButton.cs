using UnityEngine;
public class TRVExpertEntryButton : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button entryButton;
    private UnityEngine.UI.Image upgradeArrow;
    
    // Methods
    private void Start()
    {
        this.entryButton.m_OnClick.RemoveAllListeners();
        this.entryButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void TRVExpertEntryButton::OnClick()));
        this.CheckUpgradeArrow();
    }
    private void OnClick()
    {
        GameBehavior val_1 = App.getBehavior;
        WGWindow val_3 = val_1.<metaGameBehavior>k__BackingField.GetComponent<WGWindow>();
        mem2[0] = new System.Action(object:  this, method:  System.Void TRVExpertEntryButton::CheckUpgradeArrow());
    }
    private void CheckUpgradeArrow()
    {
        this.upgradeArrow.gameObject.SetActive(value:  MonoSingleton<TRVExpertsController>.Instance.AnyExpertReadyToUpgrade());
    }
    public TRVExpertEntryButton()
    {
    
    }

}
