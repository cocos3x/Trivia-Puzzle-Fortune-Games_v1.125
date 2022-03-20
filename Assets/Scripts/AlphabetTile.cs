using UnityEngine;
public class AlphabetTile : MonoBehaviour
{
    // Fields
    private UnityEngine.Sprite commonBG;
    private UnityEngine.Sprite uncommonBG;
    private UnityEngine.Sprite rareBG;
    private UnityEngine.Sprite superBG;
    private UnityEngine.Sprite petBG;
    private UnityEngine.UI.Image bgImage;
    private bool matchParentScale;
    private bool useParentLetter;
    private bool useVideoLetter;
    private bool addOnClickAction;
    private Cell parentCell;
    private System.Action prevCellClickedAction;
    
    // Methods
    private void Start()
    {
        if(this.useVideoLetter != true)
        {
                if(this.useParentLetter == false)
        {
                return;
        }
        
        }
        
        this.Init(showPet:  false);
    }
    private void Setup(Alphabet2Manager.Rarity rarity, UnityEngine.Vector3 cellSize)
    {
        if(rarity <= 3)
        {
                var val_2 = 32560384 + (rarity) << 2;
            val_2 = val_2 + 32560384;
        }
        else
        {
                if(this.matchParentScale == false)
        {
                return;
        }
        
            this.transform.localScale = new UnityEngine.Vector3() {x = cellSize.x, y = cellSize.y, z = cellSize.z};
        }
    
    }
    private void OnDisable()
    {
        if((MonoSingleton<Alphabet2Manager>.Instance) == 0)
        {
                return;
        }
        
        if(this.addOnClickAction == false)
        {
                return;
        }
        
        if(this.parentCell == 0)
        {
                return;
        }
        
        this.parentCell.CellClickedAction = this.prevCellClickedAction;
    }
    public void Init(bool showPet = False)
    {
        Cell val_20;
        float val_21;
        float val_22;
        float val_23;
        var val_24;
        System.Action val_26;
        string val_27;
        this.parentCell = this.GetComponentInParent<Cell>();
        UnityEngine.Vector3 val_3 = this.transform.localScale;
        val_20 = this.parentCell;
        val_21 = val_3.x;
        val_22 = val_3.y;
        val_23 = val_3.z;
        if(val_20 == 0)
        {
            goto label_4;
        }
        
        UnityEngine.Vector3 val_6 = this.parentCell.letterGroup.transform.localScale;
        val_20 = this.parentCell;
        val_21 = val_6.x;
        val_22 = val_6.y;
        val_23 = val_6.z;
        this.prevCellClickedAction = this.parentCell.CellClickedAction;
        Alphabet2Manager val_7 = MonoSingleton<Alphabet2Manager>.Instance;
        this.parentCell.CellClickedAction = val_7.OnTileClickAction;
        if(showPet == false)
        {
            goto label_20;
        }
        
        val_24 = null;
        val_24 = null;
        val_26 = AlphabetTile.<>c.<>9__15_0;
        if(val_26 == null)
        {
                System.Action val_8 = null;
            val_26 = val_8;
            val_8 = new System.Action(object:  AlphabetTile.<>c.__il2cppRuntimeField_static_fields, method:  System.Void AlphabetTile.<>c::<Init>b__15_0());
            AlphabetTile.<>c.<>9__15_0 = val_26;
        }
        
        this.parentCell.CellClickedAction = val_26;
        goto label_19;
        label_4:
        if(showPet == false)
        {
            goto label_20;
        }
        
        label_19:
        this.bgImage.sprite = this.petBG;
        if(this.matchParentScale == false)
        {
                return;
        }
        
        this.transform.localScale = new UnityEngine.Vector3() {x = val_21, y = val_22, z = val_23};
        return;
        label_20:
        if(this.useParentLetter == false)
        {
            goto label_24;
        }
        
        Alphabet2Manager val_10 = MonoSingleton<Alphabet2Manager>.Instance;
        val_27 = this.parentCell.letter;
        goto label_29;
        label_24:
        if(this.useVideoLetter == false)
        {
            goto label_30;
        }
        
        val_27 = MonoSingleton<Alphabet2Manager>.Instance.GetCurrentVideoRewardLetter;
        label_29:
        label_38:
        this.Setup(rarity:  MonoSingleton<Alphabet2Manager>.Instance.GetRarity(letter:  val_27), cellSize:  new UnityEngine.Vector3() {x = val_21, y = val_22, z = val_23});
        return;
        label_30:
        Rarity val_16 = MonoSingleton<Alphabet2Manager>.Instance.GetCurrentRarity();
        goto label_38;
    }
    public AlphabetTile()
    {
    
    }

}
