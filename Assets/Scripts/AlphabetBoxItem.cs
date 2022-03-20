using UnityEngine;
public class AlphabetBoxItem : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Text rarityLabel;
    private Cell cell;
    private readonly UnityEngine.Color[] colors;
    private Alphabet2Manager.Rarity myRarity;
    
    // Properties
    public Cell GetCell { get; }
    public UnityEngine.GameObject GetRarityLabel { get; }
    
    // Methods
    public Cell get_GetCell()
    {
        return (Cell)this.cell;
    }
    public UnityEngine.GameObject get_GetRarityLabel()
    {
        if(this.rarityLabel != null)
        {
                return this.rarityLabel.gameObject;
        }
        
        throw new NullReferenceException();
    }
    public void Setup(string letter)
    {
        this.cell.letter = letter;
        this.cell.SetAndShowText();
        this.cell.letterGroup.SetActive(value:  false);
        Rarity val_2 = MonoSingleton<Alphabet2Manager>.Instance.GetRarity(letter:  letter);
        this.myRarity = val_2;
        if(val_2 > 3)
        {
                return;
        }
        
        var val_3 = 32560368 + (val_2) << 2;
        val_3 = val_3 + 32560368;
        goto (32560368 + (val_2) << 2 + 32560368);
    }
    public AlphabetBoxItem()
    {
        UnityEngine.Color[] val_1 = new UnityEngine.Color[4];
        UnityEngine.Color val_2 = new UnityEngine.Color(r:  0.1254902f, g:  0.9843137f, b:  0.1254902f);
        val_1[0] = val_2.r;
        UnityEngine.Color val_3 = new UnityEngine.Color(r:  0.02352941f, g:  0.454902f, b:  0.9882353f);
        val_1[2] = val_3.r;
        UnityEngine.Color val_4 = new UnityEngine.Color(r:  0.6588235f, g:  0f, b:  1f);
        UnityEngine.Color val_5;
        val_1[4] = val_4.r;
        val_5 = new UnityEngine.Color(r:  1f, g:  0.6117647f, b:  0f);
        val_1[6] = val_5.r;
        this.colors = val_1;
    }

}
