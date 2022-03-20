using UnityEngine;
private sealed class EmojiMatchUIController.<MoveFTUXHand>d__36 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    public SLC.Minigames.EmojiMatch.EmojiMatchUIController <>4__this;
    private SLC.Minigames.EmojiMatch.EmojiMatchCardDisplay <targetCard>5__2;
    private UnityEngine.Vector3 <targetPosition>5__3;
    private UnityEngine.Vector3 <emojiPosition>5__4;
    private float <progress>5__5;
    private float <timeToMove>5__6;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public EmojiMatchUIController.<MoveFTUXHand>d__36(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        int val_35;
        UnityEngine.Object val_36;
        SLC.Minigames.EmojiMatch.EmojiMatchCardDisplay val_37;
        float val_38;
        int val_40;
        if((this.<>1__state) > 3)
        {
            goto label_37;
        }
        
        var val_35 = 32562440 + (this.<>1__state) << 2;
        val_35 = val_35 + 32562440;
        goto (32562440 + (this.<>1__state) << 2 + 32562440);
        label_29:
        if( >= (this.<>4__this.phraseParent.childCount))
        {
            goto label_24;
        }
        
        SLC.Minigames.EmojiMatch.EmojiMatchPhraseDisplay val_16 = this.<>4__this.phraseParent.GetChild(index:  0).GetComponent<SLC.Minigames.EmojiMatch.EmojiMatchPhraseDisplay>();
        if((val_16.<index>k__BackingField) == (val_13.<index>k__BackingField))
        {
            goto label_28;
        }
        
         =  + 1;
        if((this.<>4__this.phraseParent) != null)
        {
            goto label_29;
        }
        
        throw new NullReferenceException();
        label_24:
        val_36 = 0;
        goto label_30;
        label_28:
        val_36 = this.<>4__this.phraseParent.GetChild(index:  0);
        label_30:
        if(val_36 != 0)
        {
            goto label_34;
        }
        
        UnityEngine.Debug.LogError(message:  "didn\'t find a correct match for the FTUX");
        goto label_37;
        label_34:
        UnityEngine.Vector3 val_20 = GetComponent<SLC.Minigames.EmojiMatch.EmojiMatchCardDisplay>().GetLinePosition();
        this.<targetPosition>5__3 = val_20;
        mem[1152921519977396644] = val_20.y;
        mem[1152921519977396648] = val_20.z;
        UnityEngine.Vector3 val_22 = val_36.GetComponent<SLC.Minigames.EmojiMatch.EmojiMatchPhraseDisplay>().GetLinePosition();
        this.<emojiPosition>5__4 = val_22;
        mem[1152921519977396656] = val_22.y;
        mem[1152921519977396660] = val_22.z;
        this.<>4__this.FTUXHand.gameObject.transform.position = new UnityEngine.Vector3() {x = this.<targetPosition>5__3, y = val_22.y, z = val_22.z};
        this.<progress>5__5 = 0f;
        this.<timeToMove>5__6 = 2f;
        UnityEngine.Vector3[] val_25 = new UnityEngine.Vector3[2];
        val_25[0] = this.<targetPosition>5__3;
        val_25[1] = new UnityEngine.Vector3();
        val_25[1] = this.<emojiPosition>5__4;
        val_25[2] = this.<targetPosition>5__3;
        this.<>4__this.FTUXRenderer.SetPositions(positions:  val_25);
        this.<>4__this.FTUXRenderer.gameObject.SetActive(value:  true);
        if(val_13.completed == false)
        {
            goto label_51;
        }
        
        this.<>4__this.FTUXRenderer.gameObject.SetActive(value:  false);
        this.<>4__this.FTUXHand.gameObject.SetActive(value:  false);
        label_37:
        val_35 = 0;
        return (bool)val_35;
        label_51:
        val_36 = this.<progress>5__5;
        val_37 = this.<timeToMove>5__6;
        if(val_36 >= 0)
        {
                mem2[0] = 0;
            this.<>4__this.FTUXHand.enabled = false;
            this.<>2__current = new UnityEngine.WaitForSeconds(seconds:  0.2f);
            val_40 = 3;
        }
        else
        {
                UnityEngine.Vector2 val_31 = this.<>4__this.FTUXRenderer.material.mainTextureOffset;
            val_38 = val_31.x;
            if(System.Math.Abs(val_38) > 1f)
        {
                UnityEngine.Vector2 val_33 = UnityEngine.Vector2.zero;
            this.<>4__this.FTUXRenderer.material.mainTextureOffset = new UnityEngine.Vector2() {x = val_33.x, y = val_33.y};
        }
        
            val_40 = 2;
            this.<>2__current = new UnityEngine.WaitForFixedUpdate();
        }
        
        this.<>1__state = val_40;
        val_35 = 1;
        return (bool)val_35;
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
