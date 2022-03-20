using UnityEngine;
public class ChapterBookProgressBar : MonoBehaviour
{
    // Fields
    private ChapterBookProgressElement progressChapterElementPrefab;
    private UnityEngine.Transform elementGrid;
    private UnityEngine.Transform elementDividerGrid;
    private UnityEngine.Transform elementCoinGrid;
    private System.Collections.Generic.List<ChapterBookProgressElement> elementInstances;
    private System.Collections.Generic.List<ChapterBookProgressElement> elementDividerInstances;
    private System.Collections.Generic.List<ChapterBookProgressElement> elementCoinInstances;
    
    // Methods
    public void Setup(int playerLevel = -1, bool showIncomplete = False)
    {
        var val_25;
        int val_26;
        var val_27;
        var val_28;
        var val_29;
        int val_30;
        var val_31;
        System.Collections.Generic.List<ChapterBookProgressElement> val_32;
        System.Collections.Generic.List<ChapterBookProgressElement> val_33;
        System.Collections.Generic.List<ChapterBookProgressElement> val_34;
        System.Collections.Generic.List<ChapterBookProgressElement> val_35;
        val_25 = playerLevel;
        if(val_25 == 1)
        {
                val_25 = App.Player;
        }
        
        val_26 = val_25 - 1;
        int val_29 = ChapterBookLogic.GetChaptersPerBook(playerLevel:  val_26);
        int val_3 = ChapterBookLogic.GetCurrentChapter(playerLevel:  val_26);
        val_27 = ChapterBookLogic.GetLevelsPerChapter(playerLevel:  val_26);
        if(val_29 >= 1)
        {
                val_27 = -val_3;
            val_28 = 1152921504765632512;
            val_29 = -val_29;
            var val_26 = 4;
            do
        {
            var val_9 = val_26 - 4;
            val_30 = val_27 + val_26;
            val_31 = 1f;
            if((val_3 - 1) <= val_9)
        {
                var val_10 = (val_30 != 3) ? 1 : 0;
            val_10 = val_10 | showIncomplete;
            float val_11 = (val_10 != true) ? 0f : (((float)val_25 - (ChapterBookLogic.GetFirstLevelOfChapter(playerLevel:  val_26))) / (float)val_27);
        }
        
            val_32 = this.elementInstances;
            if(val_9 >= val_10)
        {
                this.elementInstances.Add(item:  UnityEngine.Object.Instantiate<ChapterBookProgressElement>(original:  this.progressChapterElementPrefab, parent:  this.elementGrid));
            val_32 = this.elementInstances;
        }
        
            if(this.elementInstances <= val_9)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            0.gameObject.SetActive(value:  true);
            if(this.elementInstances <= val_9)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            int val_14 = val_26 - 3;
            0.Setup(chapter:  val_14, completeProgress:  val_11, lastChapterInBook:  val_29, isCurrentChapter:  false);
            val_33 = this.elementCoinInstances;
            if(val_9 >= this.elementInstances)
        {
                this.elementCoinInstances.Add(item:  UnityEngine.Object.Instantiate<ChapterBookProgressElement>(original:  this.progressChapterElementPrefab, parent:  this.elementCoinGrid));
            val_33 = this.elementCoinInstances;
            val_28 = val_28;
            val_27 = val_27;
            val_29 = val_29;
            val_30 = val_30;
        }
        
            if(this.elementCoinInstances <= val_9)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            0.gameObject.SetActive(value:  true);
            val_26 = this.elementCoinInstances;
            if(this.elementCoinInstances <= val_9)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            0.SetupAsCoin(chapter:  val_14, completeProgress:  val_11, lastChapterInBook:  val_29, isCurrentChapter:  (val_30 == 3) ? 1 : 0);
            val_34 = this.elementDividerInstances;
            if(val_9 >= this.elementCoinInstances)
        {
                val_26 = this.elementDividerGrid;
            this.elementDividerInstances.Add(item:  UnityEngine.Object.Instantiate<ChapterBookProgressElement>(original:  this.progressChapterElementPrefab, parent:  val_26));
            val_34 = this.elementDividerInstances;
        }
        
            if(this.elementDividerInstances <= val_9)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            0.gameObject.SetActive(value:  true);
            if(this.elementDividerInstances <= val_9)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            0.SetupAsDivider(lastElement:  ((val_29 + val_26) == 3) ? 1 : 0);
            val_26 = val_26 + 1;
            var val_22 = val_26 - 4;
        }
        while(val_22 < val_29);
        
        }
        
        if(val_22 > val_29)
        {
                var val_27 = val_29;
            do
        {
            if(val_22 <= val_27)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_22 = val_22 + (val_27 << 3);
            (((4 + 1) - 4) + (val_2) << 3) + 32.gameObject.SetActive(value:  false);
            val_27 = val_27 + 1;
        }
        while(val_27 < val_22);
        
        }
        
        if(val_22 > val_29)
        {
                var val_28 = val_29;
            do
        {
            if(val_22 <= val_28)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_22 = val_22 + (val_28 << 3);
            ((((4 + 1) - 4) + (val_2) << 3) + (val_2) << 3) + 32.gameObject.SetActive(value:  false);
            val_28 = val_28 + 1;
        }
        while(val_28 < val_22);
        
        }
        
        val_35 = this.elementDividerInstances;
        if(val_22 <= val_29)
        {
                return;
        }
        
        do
        {
            if(val_22 <= val_29)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            val_22 = val_22 + (val_29 << 3);
            (((((4 + 1) - 4) + (val_2) << 3) + (val_2) << 3) + (val_2) << 3) + 32.gameObject.SetActive(value:  false);
            val_35 = this.elementDividerInstances;
            val_29 = val_29 + 1;
        }
        while(val_29 < val_22);
    
    }
    public ChapterBookProgressBar()
    {
        this.elementInstances = new System.Collections.Generic.List<ChapterBookProgressElement>();
        this.elementDividerInstances = new System.Collections.Generic.List<ChapterBookProgressElement>();
        this.elementCoinInstances = new System.Collections.Generic.List<ChapterBookProgressElement>();
    }

}
