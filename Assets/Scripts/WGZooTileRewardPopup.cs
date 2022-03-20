using UnityEngine;
public class WGZooTileRewardPopup : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Image tileImage;
    private UnityEngine.UI.Text tileName;
    private UnityEngine.UI.Text description;
    private UnityEngine.UI.Button collectButton;
    private DailyChallengeZooTilesConfig zooTilesConfig;
    public System.Action OnZooTileRewardCollected;
    
    // Methods
    private void Awake()
    {
        this.collectButton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGZooTileRewardPopup::OnRewardCollected()));
    }
    public void Setup(ZooTile tile)
    {
        this.tileImage.sprite = this.zooTilesConfig.GetSprite(type:  1, name:  tile.name);
        string val_4 = System.String.Format(format:  Localization.Localize(key:  "zoo_tile_reward_description", defaultValue:  "You earned enough Stars to unlock the {0} Zoo Tile!", useSingularKey:  false), arg0:  tile.name.ToUpper());
        goto typeof(UnityEngine.UI.Text).__il2cppRuntimeField_5E0;
    }
    private void OnRewardCollected()
    {
        if(this.OnZooTileRewardCollected != null)
        {
                this.OnZooTileRewardCollected.Invoke();
        }
        
        this.Close();
    }
    private void Close()
    {
        this.gameObject.SetActive(value:  false);
    }
    public WGZooTileRewardPopup()
    {
    
    }

}
