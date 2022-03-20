using UnityEngine;
public class WGChapterSelectLevelItem : MonoBehaviour
{
    // Fields
    private UnityEngine.UI.Button playbutton;
    private UnityEngine.UI.Text levelText;
    private UnityEngine.GameObject checkmarkGroup;
    private UnityEngine.GameObject checkmark;
    private UnityEngine.GameObject playButtonGroup;
    private UnityEngine.GameObject darkOverlay;
    private UnityEngine.GameObject[] letterContainers;
    private TheLibraryBookProgressPopup _ProgressPopup;
    private System.Action<int> PlayLevelCallback;
    private int thisLevel;
    private static System.Collections.Generic.List<string> defaultLetters;
    
    // Properties
    private TheLibraryBookProgressPopup ProgressPopup { get; }
    
    // Methods
    private TheLibraryBookProgressPopup get_ProgressPopup()
    {
        TheLibraryBookProgressPopup val_4;
        if(this._ProgressPopup == 0)
        {
                this._ProgressPopup = this.transform.GetComponentInParent<TheLibraryBookProgressPopup>();
            return val_4;
        }
        
        val_4 = this._ProgressPopup;
        return val_4;
    }
    private void Awake()
    {
        this.playbutton.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  System.Void WGChapterSelectLevelItem::OnClickPlayLevel()));
    }
    private void ScrollCellIndex(int index)
    {
        this.ProgressPopup.SetupGridItem(gridItem:  this, i:  index);
    }
    public void Setup(int levelName, int currentLevel, string levelWord, System.Action<int> playLevelCallback)
    {
        string val_7 = levelWord;
        this.gameObject.SetActive(value:  (levelName >> 31) ^ 1);
        if((levelName & 2147483648) != 0)
        {
                return;
        }
        
        this.PlayLevelCallback = playLevelCallback;
        this.thisLevel = levelName;
        this.SetState(levelName:  levelName, currentLevel:  currentLevel);
        this.SetWord(levelWord:  (levelName > currentLevel) ? "" : (val_7));
        val_7 = Localization.Localize(key:  "level_#_upper", defaultValue:  "LEVEL {0}", useSingularKey:  false);
        string val_6 = System.String.Format(format:  val_7, arg0:  levelName);
    }
    private void SetState(int levelName, int currentLevel)
    {
        var val_1;
        var val_2;
        if(levelName >= currentLevel)
        {
            goto label_0;
        }
        
        this.checkmarkGroup.SetActive(value:  true);
        this.checkmark.SetActive(value:  true);
        val_1 = 0;
        goto label_4;
        label_0:
        if(levelName != currentLevel)
        {
            goto label_6;
        }
        
        this.checkmarkGroup.SetActive(value:  false);
        val_1 = 1;
        label_4:
        this.playButtonGroup.SetActive(value:  true);
        val_2 = 0;
        goto label_9;
        label_6:
        this.checkmarkGroup.SetActive(value:  true);
        this.checkmark.SetActive(value:  false);
        this.playButtonGroup.SetActive(value:  false);
        val_2 = 1;
        label_9:
        this.darkOverlay.SetActive(value:  true);
    }
    private void SetWord(string levelWord)
    {
        string val_14;
        var val_15;
        var val_16;
        val_14 = levelWord;
        if((System.String.IsNullOrEmpty(value:  val_14)) != false)
        {
                val_15 = null;
            val_15 = null;
            int val_2 = UnityEngine.Random.Range(min:  0, max:  WGChapterSelectLevelItem.defaultLetters + 24);
            if((WGChapterSelectLevelItem.defaultLetters + 24) <= val_2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            var val_14 = WGChapterSelectLevelItem.defaultLetters + 16;
            val_14 = val_14 + (val_2 << 3);
            val_14 = mem[(WGChapterSelectLevelItem.defaultLetters + 16 + (val_2) << 3) + 32];
            val_14 = (WGChapterSelectLevelItem.defaultLetters + 16 + (val_2) << 3) + 32;
        }
        
        int val_5 = val_4.Length - 3;
        UnityEngine.GameObject val_15 = this.letterContainers[val_5];
        if(this.letterContainers.Length >= 1)
        {
                do
        {
            this.letterContainers[0].SetActive(value:  (val_5 == 0) ? 1 : 0);
            val_16 = 0 + 1;
        }
        while(val_16 < this.letterContainers.Length);
        
        }
        
        var val_18 = 0;
        do
        {
            if(val_18 >= (val_15.transform.childCount << ))
        {
                return;
        }
        
            val_16 = val_15.transform.GetChild(index:  0).GetComponentInChildren<UnityEngine.UI.Text>();
            string val_12 = val_14.Replace(oldValue:  "|", newValue:  "").ToCharArray()[32].ToString();
            val_18 = val_18 + 1;
        }
        while(val_15.transform != null);
        
        throw new NullReferenceException();
    }
    private void OnClickPlayLevel()
    {
        if(this.PlayLevelCallback == null)
        {
                return;
        }
        
        this.PlayLevelCallback.Invoke(obj:  this.thisLevel);
        this.PlayLevelCallback = 0;
    }
    public WGChapterSelectLevelItem()
    {
    
    }
    private static WGChapterSelectLevelItem()
    {
        System.Collections.Generic.List<System.String> val_1 = new System.Collections.Generic.List<System.String>();
        val_1.Add(item:  "???");
        val_1.Add(item:  "????");
        val_1.Add(item:  "?????");
        val_1.Add(item:  "??????");
        val_1.Add(item:  "???????");
        WGChapterSelectLevelItem.defaultLetters = val_1;
    }

}
