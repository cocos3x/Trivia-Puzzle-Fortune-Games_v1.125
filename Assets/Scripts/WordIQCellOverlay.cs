using UnityEngine;
public class WordIQCellOverlay : MonoBehaviour
{
    // Fields
    public const int CellSiblingIndex = 1;
    private UnityEngine.Sprite emptyCellSprite;
    private UnityEngine.Sprite pickerHintEmptyCellSprite;
    private UnityEngine.ParticleSystem particles;
    private Cell ParentCell;
    
    // Methods
    public void SetParentCell(Cell parentCell)
    {
        this.ParentCell = parentCell;
        System.Delegate val_2 = System.Delegate.Combine(a:  parentCell.CellClickedAction, b:  new System.Action(object:  this, method:  System.Void WordIQCellOverlay::OnClicked()));
        if(val_2 != null)
        {
                if(null != null)
        {
            goto label_3;
        }
        
        }
        
        parentCell.CellClickedAction = val_2;
        UnityEngine.UI.Button val_3 = parentCell.GetComponent<UnityEngine.UI.Button>();
        val_3.spriteState = new UnityEngine.UI.SpriteState() {m_DisabledSprite = this.pickerHintEmptyCellSprite};
        val_3.image.sprite = this.emptyCellSprite;
        return;
        label_3:
    }
    public void PlayFoundAnimation()
    {
        this.gameObject.SetActive(value:  true);
        this.particles.Play();
    }
    private void OnClicked()
    {
        GameBehavior val_1 = App.getBehavior;
        goto mem[(1152921504946249728 + (public WordIQFoundWordsMenu MetaGameBehavior::ShowUGUIMonolith<WordIQFoundWordsMenu>(bool showNext).__il2cppRuntimeField_48) << 4) + 312];
    }
    public WordIQCellOverlay()
    {
    
    }

}
