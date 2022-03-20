using UnityEngine;
public class WGDailyChallengeZooTile : MonoBehaviour
{
    // Fields
    private TMPro.TMP_Text animalName;
    private UnityEngine.UI.Image animal;
    private UnityEngine.Sprite tileBackground;
    private UnityEngine.UI.Image lockOverlay;
    private UnityEngine.GameObject lockIcon;
    private UnityEngine.UI.Text comingSoonText;
    private UnityEngine.GameObject requiredStarsGroup;
    private UnityEngine.UI.Text requiredStars;
    private UnityEngine.UI.Button tileBtn;
    private WGDailyChallengeFunFact funFact;
    private DailyChallengeZooTilesConfig zooTilesConfig;
    public ZooTile tile;
    
    // Methods
    private void Awake()
    {
        this.tileBtn.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGDailyChallengeZooTile::OnTileClicked()));
    }
    private void OnTileClicked()
    {
        if(this.funFact != null)
        {
                this.funFact.ShowFunFact(info:  this.tile);
            return;
        }
        
        throw new NullReferenceException();
    }
    public void Setup(int lockCompValue, bool isMonthTileInCollection = False)
    {
        var val_13;
        if(this.tile == null)
        {
            goto label_1;
        }
        
        string val_4 = Localization.Localize(key:  this.tile.name.ToLower() + "_upper", defaultValue:  this.tile.name.ToUpper(), useSingularKey:  false);
        string val_5 = this.tile.requiredStars.ToString();
        this.animal.sprite = this.zooTilesConfig.GetSprite(type:  0, name:  this.tile.name);
        if(isMonthTileInCollection == false)
        {
            goto label_11;
        }
        
        val_13 = 1;
        goto label_19;
        label_1:
        this.requiredStarsGroup.SetActive(value:  false);
        this.lockIcon.SetActive(value:  false);
        this.animal.sprite = this.tileBackground;
        string val_7 = Localization.Localize(key:  "coming_soon_upper", defaultValue:  "COMING SOON", useSingularKey:  false);
        this.comingSoonText.gameObject.SetActive(value:  true);
        val_13 = 0;
        goto label_19;
        label_11:
        bool val_9 = (this.tile.requiredStars <= lockCompValue) ? 1 : 0;
        label_19:
        this.lockOverlay.gameObject.SetActive(value:  val_9 ^ 1);
        this.animalName.gameObject.SetActive(value:  val_9);
        this.tileBtn.interactable = val_9;
    }
    public WGDailyChallengeZooTile()
    {
        this.tile = new ZooTile(name:  "Koala", requiredStars:  200, funFact:  "See Zootopia");
    }

}
