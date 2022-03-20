using UnityEngine;
private sealed class ImageQuizDataManager.<LoadQuizLevelsCoroutine>d__26 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public SLC.Minigames.ImageQuiz.ImageQuizDataManager <>4__this;
    private SLC.Minigames.ImageQuiz.ImageQuizDataManager.<>c__DisplayClass26_0 <>8__1;
    private SLC.Minigames.ImageQuiz.ImageQuizDataManager.<>c__DisplayClass26_1 <>8__2;
    public int levelCount;
    private int <totalImageFailAttempts>5__2;
    private System.Collections.Generic.List<int> <successfulLevelIds>5__3;
    private System.Collections.Generic.List<int> <levelIdsAttempted>5__4;
    private SLC.Minigames.ImageQuiz.QuizLevelData[] <lDataArray>5__5;
    private int <i>5__6;
    private SLC.Minigames.ImageQuiz.QuizLevelData <lData>5__7;
    private int <wordIndex>5__8;
    private int <retries>5__9;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public ImageQuizDataManager.<LoadQuizLevelsCoroutine>d__26(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        System.Collections.Generic.List<System.Int32> val_24;
        System.Collections.Generic.List<System.Int32> val_25;
        var val_26;
        int val_27;
        object val_28;
        if((this.<>1__state) == 1)
        {
            goto label_1;
        }
        
        if((this.<>1__state) != 0)
        {
                return false;
        }
        
        int val_24 = 0;
        this.<totalImageFailAttempts>5__2 = 0;
        this.<>1__state = val_24;
        this.<successfulLevelIds>5__3 = new System.Collections.Generic.List<System.Int32>();
        System.Collections.Generic.List<System.Int32> val_2 = null;
        val_24 = val_2;
        val_2 = new System.Collections.Generic.List<System.Int32>();
        this.<levelIdsAttempted>5__4 = val_24;
        var val_25 = 0;
        val_25 = this.<successfulLevelIds>5__3;
        label_8:
        if(val_25 >= val_24)
        {
            goto label_5;
        }
        
        val_24 = val_24 & 4294967295;
        if(val_25 >= val_24)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_24 = val_24 + 0;
        this.<levelIdsAttempted>5__4.Add(item:  ((0 & 4294967295) + 0) + 32);
        val_25 = val_25 + 1;
        if((this.<>4__this.levelsLoadedButUnconsumed) != null)
        {
            goto label_8;
        }
        
        label_1:
        this.<>1__state = 0;
        if((this.<>8__2.CS$<>8__locals1.downloadSucceed) == false)
        {
            goto label_12;
        }
        
        this.<successfulLevelIds>5__3.Add(item:  this.<wordIndex>5__8);
        UnityEngine.Texture2D val_3 = null;
        val_24 = val_3;
        val_3 = new UnityEngine.Texture2D(width:  1, height:  1);
        this.<>4__this.stageQuizLevels.Enqueue(item:  UnityEngine.ImageConversion.LoadImage(tex:  val_3, data:  this.<>8__2.imageRawData).GenerateLevelInfo(word:  this.<lData>5__7.word, img:  val_3));
        this.<>8__2 = 0;
        goto label_19;
        label_12:
        int val_26 = this.<retries>5__9;
        val_26 = val_26 + 1;
        this.<retries>5__9 = val_26;
        goto label_19;
        label_47:
        SLC.Minigames.ImageQuiz.QuizLevelData[] val_6 = this.<>4__this.GetUniqueLevelDatas(amountOfLevels:  1, filters:  this.<levelIdsAttempted>5__4);
        this.<i>5__6 = 0;
        val_27 = 0;
        mem[1152921519933616624] = val_6;
        if(val_6 != null)
        {
            goto label_21;
        }
        
        label_44:
        this.<>8__1 = new ImageQuizDataManager.<>c__DisplayClass26_0();
        this.<lData>5__7 = this.<lDataArray>5__5[this.<i>5__6];
        this.<lDataArray>5__5[this.<i>5__6][0].imageUrl = "https://cdn.12gigs.com/mg/iq/"("https://cdn.12gigs.com/mg/iq/") + this.<lDataArray>5__5[this.<i>5__6][0].word.ToLowerInvariant()(this.<lDataArray>5__5[this.<i>5__6][0].word.ToLowerInvariant()) + ".png";
        int val_10 = this.<>4__this.FindLevelIndexOfWord(word:  this.<lData>5__7.word);
        this.<wordIndex>5__8 = val_10;
        this.<levelIdsAttempted>5__4.Add(item:  val_10);
        val_24 = ImageLoadingController.GetTexture2D(path:  SLC.Minigames.ImageQuiz.ImageQuizDataManager.LocalImageStoragePath + "/"("/") + this.<lData>5__7.word.ToLowerInvariant()(this.<lData>5__7.word.ToLowerInvariant()));
        if(val_24 == 0)
        {
            goto label_34;
        }
        
        this.<successfulLevelIds>5__3.Add(item:  this.<wordIndex>5__8);
        this.<>4__this.stageQuizLevels.Enqueue(item:  this.<successfulLevelIds>5__3.GenerateLevelInfo(word:  this.<lData>5__7.word, img:  val_24));
        goto label_38;
        label_34:
        this.<retries>5__9 = 0;
        this.<>8__1.downloadSucceed = false;
        label_19:
        if((this.<>8__1.downloadSucceed) == true)
        {
            goto label_41;
        }
        
        if((this.<retries>5__9) < 2)
        {
            goto label_42;
        }
        
        int val_28 = this.<totalImageFailAttempts>5__2;
        val_28 = val_28 + 1;
        this.<totalImageFailAttempts>5__2 = val_28;
        label_41:
        this.<>8__1 = 0;
        this.<lData>5__7 = 0;
        label_38:
        val_27 = (this.<i>5__6) + 1;
        mem2[0] = val_27;
        val_26 = mem[this.<lDataArray>5__5];
        label_21:
        if(val_27 < (mem[this.<lDataArray>5__5] + 24))
        {
            goto label_44;
        }
        
        val_25 = this.<successfulLevelIds>5__3;
        this.<lDataArray>5__5 = 0;
        label_5:
        val_28 = mem[this.<successfulLevelIds>5__3];
        val_28 = this.<successfulLevelIds>5__3.SyncRoot;
        if((mem[this.<successfulLevelIds>5__3.SyncRoot + 24]) < this.levelCount)
        {
                if((this.<totalImageFailAttempts>5__2) < 3)
        {
            goto label_47;
        }
        
        }
        
        if((mem[this.<successfulLevelIds>5__3.SyncRoot + 24]) >= 1)
        {
                var val_30 = 0;
            do
        {
            val_24 = this.<>4__this.levelsLoadedButUnconsumed;
            if(val_30 >= (mem[this.<successfulLevelIds>5__3.SyncRoot + 24]))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            var val_29 = mem[this.<successfulLevelIds>5__3.SyncRoot + 16];
            val_29 = val_29 + 0;
            val_24.Add(item:  (mem[this.<successfulLevelIds>5__3.SyncRoot + 16] + 0) + 32);
            val_28 = mem[this.<successfulLevelIds>5__3];
            val_28 = this.<successfulLevelIds>5__3.SyncRoot;
            val_30 = val_30 + 1;
        }
        while(val_30 < (mem[this.<successfulLevelIds>5__3.SyncRoot + 24]));
        
        }
        
        this.<>4__this.<DataLoaderState>k__BackingField = 0;
        this.<>4__this.OnDataLoaded.Invoke(obj:  ((mem[this.<successfulLevelIds>5__3.SyncRoot + 24]) >= this.levelCount) ? 1 : 0);
        if(((this.<totalImageFailAttempts>5__2) > 2) || ((this.<>4__this.stageQuizLevels) > 4))
        {
                return false;
        }
        
        this.<>4__this.LoadQuizLevels();
        return false;
        label_42:
        this.<>8__2 = new ImageQuizDataManager.<>c__DisplayClass26_1();
        .CS$<>8__locals1 = this.<>8__1;
        this.<>8__2.onRequestComplete = false;
        this.<>8__2.imageRawData = 0;
        RemoteResourcesLoadingController.DownloadItem(uri:  this.<lData>5__7.imageUrl, fileName:  this.<lData>5__7.word.ToLowerInvariant(), fileExtention:  0, localDirectory:  SLC.Minigames.ImageQuiz.ImageQuizDataManager.LocalImageStoragePath, callback:  new System.Action<System.Boolean, System.Byte[]>(object:  this.<>8__2, method:  System.Void ImageQuizDataManager.<>c__DisplayClass26_1::<LoadQuizLevelsCoroutine>b__0(bool isReqSuccess, byte[] rawData)));
        this.<>2__current = new UnityEngine.WaitUntil(predicate:  new System.Func<System.Boolean>(object:  this.<>8__2, method:  System.Boolean ImageQuizDataManager.<>c__DisplayClass26_1::<LoadQuizLevelsCoroutine>b__1()));
        this.<>1__state = 1;
        return false;
    }
    private object System.Collections.Generic.IEnumerator<System.Object>.get_Current()
    {
        return (object)this.<>2__current;
    }
    private void System.Collections.IEnumerator.Reset()
    {
        throw new System.NotSupportedException();
    }
    private object System.Collections.IEnumerator.get_Current()
    {
        return (object)this.<>2__current;
    }

}
