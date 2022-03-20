using UnityEngine;
public class FPHAnswerDisplay : MonoBehaviour
{
    // Fields
    private int maxSlotsPerRow;
    private float maxWidthPerSlot;
    private FPHAnswerTile tilePrefab;
    private UnityEngine.UI.HorizontalLayoutGroup wordRowPrefab;
    private UnityEngine.RectTransform wordRowParent;
    private UnityEngine.UI.Text labelClue;
    private System.Collections.Generic.List<FPHAnswerTile> <spawnedTiles>k__BackingField;
    private System.Collections.Generic.List<UnityEngine.UI.HorizontalLayoutGroup> spawnedWordRows;
    private System.Collections.Generic.List<FPHAnswerTile> spawnedSpacingTiles;
    private UnityEngine.UI.HorizontalOrVerticalLayoutGroup wordRowParentLayoutGroup;
    private int widestRowSlotCount;
    
    // Properties
    public System.Collections.Generic.List<FPHAnswerTile> spawnedTiles { get; set; }
    
    // Methods
    public System.Collections.Generic.List<FPHAnswerTile> get_spawnedTiles()
    {
        return (System.Collections.Generic.List<FPHAnswerTile>)this.<spawnedTiles>k__BackingField;
    }
    private void set_spawnedTiles(System.Collections.Generic.List<FPHAnswerTile> value)
    {
        this.<spawnedTiles>k__BackingField = value;
    }
    private void Start()
    {
        FPHGameplayController val_1 = FPHGameplayController.Instance;
        System.Delegate val_3 = System.Delegate.Combine(a:  val_1.OnSolveModeToggled, b:  new System.Action<System.Boolean>(object:  this, method:  System.Void FPHAnswerDisplay::OnSolveModeToggled(bool isOn)));
        if(val_3 != null)
        {
                if(null != null)
        {
            goto label_5;
        }
        
        }
        
        val_1.OnSolveModeToggled = val_3;
        this.wordRowParentLayoutGroup = this.wordRowParent.gameObject.GetComponent<UnityEngine.UI.HorizontalOrVerticalLayoutGroup>();
        return;
        label_5:
    }
    private void OnDestroy()
    {
        if(FPHGameplayController.Instance == 0)
        {
                return;
        }
        
        FPHGameplayController val_3 = FPHGameplayController.Instance;
        1152921504901894144 = val_3.OnSolveModeToggled;
        System.Delegate val_5 = System.Delegate.Remove(source:  1152921504901894144, value:  new System.Action<System.Boolean>(object:  this, method:  System.Void FPHAnswerDisplay::OnSolveModeToggled(bool isOn)));
        if(val_5 != null)
        {
                if(null != null)
        {
            goto label_10;
        }
        
        }
        
        val_3.OnSolveModeToggled = val_5;
        return;
        label_10:
    }
    public void Setup(FPHGameplayState state)
    {
        this.CreateAnswerDisplay(state:  state);
    }
    private void OnRectTransformDimensionsChange()
    {
        var val_15;
        var val_16;
        var val_29;
        var val_30;
        var val_32;
        val_29 = this;
        if((this.<spawnedTiles>k__BackingField) == null)
        {
                return;
        }
        
        if((this.<spawnedTiles>k__BackingField) < 1)
        {
                return;
        }
        
        UnityEngine.Rect val_1 = this.wordRowParent.rect;
        UnityEngine.Vector2 val_2 = val_1.m_XMin.size;
        int val_3 = val_1.m_XMin.left;
        float val_28 = (float)val_3;
        val_28 = val_2.x - val_28;
        val_28 = val_28 - (float)val_3.right;
        val_2.x = val_2.x * ((float)this.widestRowSlotCount - 1);
        val_2.x = val_28 - val_2.x;
        float val_7 = UnityEngine.Mathf.Min(a:  this.maxWidthPerSlot, b:  val_2.x / (float)this.widestRowSlotCount);
        UnityEngine.Rect val_8 = this.wordRowParent.rect;
        UnityEngine.Vector2 val_9 = val_8.m_XMin.size;
        int val_10 = val_8.m_XMin.top;
        val_30 = val_10;
        float val_30 = this.wordRowParentLayoutGroup.m_Spacing;
        float val_29 = (float)val_30;
        val_29 = val_9.y - val_29;
        val_29 = val_29 - (float)val_10.bottom;
        val_30 = val_30 * ((float)this.spawnedWordRows - 1);
        val_30 = val_29 - val_30;
        val_30 = val_30 / (float)this.spawnedWordRows;
        float val_13 = UnityEngine.Mathf.Min(a:  this.maxWidthPerSlot, b:  val_30);
        List.Enumerator<T> val_14 = this.<spawnedTiles>k__BackingField.GetEnumerator();
        label_27:
        val_32 = public System.Boolean List.Enumerator<FPHAnswerTile>::MoveNext();
        if(val_16.MoveNext() == false)
        {
            goto label_19;
        }
        
        if(val_15 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_32 = 0;
        UnityEngine.GameObject val_18 = val_15.gameObject;
        if(val_18 == null)
        {
                throw new NullReferenceException();
        }
        
        val_32 = 0;
        UnityEngine.Transform val_19 = val_18.transform;
        val_30 = val_19;
        if(val_19 != null)
        {
                val_32 = null;
            if(null != val_32)
        {
                throw new NullReferenceException();
        }
        
        }
        
        if(val_30 == null)
        {
                throw new NullReferenceException();
        }
        
        val_30.SetSizeWithCurrentAnchors(axis:  0, size:  UnityEngine.Mathf.Min(a:  val_7, b:  val_13));
        val_30.SetSizeWithCurrentAnchors(axis:  1, size:  UnityEngine.Mathf.Min(a:  val_7, b:  val_13));
        goto label_27;
        label_19:
        val_16.Dispose();
        List.Enumerator<T> val_22 = this.spawnedSpacingTiles.GetEnumerator();
        label_37:
        val_32 = public System.Boolean List.Enumerator<FPHAnswerTile>::MoveNext();
        if(val_16.MoveNext() == false)
        {
            goto label_29;
        }
        
        if(val_15 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_32 = 0;
        UnityEngine.GameObject val_24 = val_15.gameObject;
        if(val_24 == null)
        {
                throw new NullReferenceException();
        }
        
        val_32 = 0;
        UnityEngine.Transform val_25 = val_24.transform;
        val_29 = val_25;
        if(val_25 != null)
        {
                val_32 = null;
            if(null != val_32)
        {
                throw new NullReferenceException();
        }
        
        }
        
        if(val_29 == null)
        {
                throw new NullReferenceException();
        }
        
        val_29.SetSizeWithCurrentAnchors(axis:  0, size:  UnityEngine.Mathf.Min(a:  val_7, b:  val_13));
        val_29.SetSizeWithCurrentAnchors(axis:  1, size:  UnityEngine.Mathf.Min(a:  val_7, b:  val_13));
        goto label_37;
        label_29:
        val_16.Dispose();
    }
    private void CreateAnswerDisplay(FPHGameplayState state)
    {
        var val_2;
        var val_3;
        UnityEngine.Object val_40;
        var val_41;
        int val_42;
        int val_43;
        char val_44;
        UnityEngine.UI.HorizontalLayoutGroup val_45;
        var val_46;
        if((this.<spawnedTiles>k__BackingField) == null)
        {
            goto label_94;
        }
        
        List.Enumerator<T> val_1 = this.<spawnedTiles>k__BackingField.GetEnumerator();
        label_6:
        if(val_3.MoveNext() == false)
        {
            goto label_2;
        }
        
        val_40 = val_2;
        if(val_40 == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Object.Destroy(obj:  val_40.gameObject);
        goto label_6;
        label_2:
        val_3.Dispose();
        label_94:
        if(this.spawnedSpacingTiles == null)
        {
            goto label_91;
        }
        
        List.Enumerator<T> val_6 = this.spawnedSpacingTiles.GetEnumerator();
        label_12:
        if(val_3.MoveNext() == false)
        {
            goto label_8;
        }
        
        val_40 = val_2;
        if(val_40 == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Object.Destroy(obj:  val_40.gameObject);
        goto label_12;
        label_8:
        val_3.Dispose();
        label_91:
        if(this.spawnedWordRows == null)
        {
            goto label_19;
        }
        
        List.Enumerator<T> val_9 = this.spawnedWordRows.GetEnumerator();
        label_18:
        if(val_3.MoveNext() == false)
        {
            goto label_14;
        }
        
        val_40 = val_2;
        if(val_40 == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Object.Destroy(obj:  val_40.gameObject);
        goto label_18;
        label_14:
        val_3.Dispose();
        var val_39 = 0;
        if(val_39 == 1)
        {
            goto label_19;
        }
        
        var val_12 = (195 == 195) ? 1 : 0;
        val_12 = ((val_39 >= 0) ? 1 : 0) & val_12;
        val_39 = val_39 - val_12;
        val_39 = val_39 + 1;
        val_41 = (long)val_39;
        goto label_20;
        label_19:
        val_41 = 0;
        label_20:
        this.<spawnedTiles>k__BackingField = new System.Collections.Generic.List<FPHAnswerTile>();
        this.spawnedWordRows = new System.Collections.Generic.List<UnityEngine.UI.HorizontalLayoutGroup>();
        this.spawnedSpacingTiles = new System.Collections.Generic.List<FPHAnswerTile>();
        System.Collections.Generic.List<System.String> val_17 = new System.Collections.Generic.List<System.String>();
        char[] val_18 = new char[1];
        val_18[0] = 32;
        val_17.AddRange(collection:  state.<levelData>k__BackingField.<phrase>k__BackingField.Split(separator:  val_18));
        UnityEngine.Debug.Log(message:  "displaying " + state.<levelData>k__BackingField.<phrase>k__BackingField(state.<levelData>k__BackingField.<phrase>k__BackingField));
        List.Enumerator<T> val_21 = val_17.GetEnumerator();
        val_43 = 0;
        goto label_46;
        label_55:
        var val_22 = (val_43 > 0) ? 1 : 0;
        if(val_2 == 0)
        {
                throw new NullReferenceException();
        }
        
        var val_40 = val_2 + 16;
        val_40 = (val_43 + val_22) + val_40;
        val_42 = this.maxSlotsPerRow;
        var val_25 = (val_40 > val_42) ? 0 : (val_43);
        val_40 = (val_40 > val_42) ? 0 : 0;
        if(val_40 == 0)
        {
                val_45 = UnityEngine.Object.Instantiate<UnityEngine.UI.HorizontalLayoutGroup>(original:  this.wordRowPrefab, parent:  this.wordRowParent);
            val_40 = this.spawnedWordRows;
            if(val_40 == null)
        {
                throw new NullReferenceException();
        }
        
            val_40.Add(item:  val_45);
        }
        
        if(val_25 != 0)
        {
                if(val_45 == null)
        {
                throw new NullReferenceException();
        }
        
            FPHAnswerTile val_29 = UnityEngine.Object.Instantiate<FPHAnswerTile>(original:  this.tilePrefab, parent:  val_45.transform);
            if(val_29 == null)
        {
                throw new NullReferenceException();
        }
        
            val_29.Setup(myLetter:  ' ', revealed:  false);
            val_40 = this.spawnedSpacingTiles;
            if(val_40 == null)
        {
                throw new NullReferenceException();
        }
        
            val_40.Add(item:  val_29);
            val_46 = val_25 + val_22;
        }
        else
        {
                val_46 = 0;
        }
        
        val_43 = (val_2 + 16) + val_46;
        this.widestRowSlotCount = UnityEngine.Mathf.Max(a:  this.widestRowSlotCount, b:  val_43);
        if((val_2 + 16) >= 1)
        {
                var val_42 = 0;
            do
        {
            val_40 = val_2;
            if(val_45 == null)
        {
                throw new NullReferenceException();
        }
        
            val_44 = val_40.Chars[0];
            FPHAnswerTile val_33 = UnityEngine.Object.Instantiate<FPHAnswerTile>(original:  this.tilePrefab, parent:  val_45.transform);
            if((state + 112) == 0)
        {
                throw new NullReferenceException();
        }
        
            val_42 = 0;
            var val_34 = val_42 + val_42;
            if((state + 112 + 24) <= val_34)
        {
                val_40 = 0;
            System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(val_33 == null)
        {
                throw new NullReferenceException();
        }
        
            var val_41 = state + 112 + 16;
            val_41 = val_41 + (val_34 << 2);
            val_33.Setup(myLetter:  val_44, revealed:  (((state + 112 + 16 + ((val_42 + 0)) << 2) + 32) == 1) ? 1 : 0);
            val_40 = this.<spawnedTiles>k__BackingField;
            if(val_40 == null)
        {
                throw new NullReferenceException();
        }
        
            val_40.Add(item:  val_33);
            val_42 = val_42 + 1;
        }
        while(val_42 < (val_2 + 16));
        
            var val_43 = 0;
            val_43 = val_43 + val_42;
        }
        
        label_46:
        if(val_3.MoveNext() == true)
        {
            goto label_55;
        }
        
        val_3.Dispose();
        MonoExtensions.DelayedCallEndOfFrame(monoBehaviour:  this, callback:  new System.Action(object:  this, method:  System.Void FPHAnswerDisplay::OnRectTransformDimensionsChange()), count:  1);
        MonoExtensions.DelayedCallEndOfFrame(monoBehaviour:  this, callback:  new System.Action(object:  this, method:  public System.Void FPHAnswerDisplay::DoStartAnimation()), count:  1);
    }
    public void UpdateState(FPHGameplayState state)
    {
        var val_4 = 0;
        label_26:
        if(val_4 >= (this.<spawnedTiles>k__BackingField))
        {
            goto label_2;
        }
        
        if(val_4 >= (this.<spawnedTiles>k__BackingField))
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        (System.Collections.Generic.List<T>.__il2cppRuntimeField_byval_arg + 0) + 32.DisplayLetter();
        val_4 = val_4 + 1;
        if((this.<spawnedTiles>k__BackingField) != null)
        {
            goto label_26;
        }
        
        label_2:
        FPHGameplayController val_2 = FPHGameplayController.Instance;
        if((val_2.<IsSolveModeOn>k__BackingField) != false)
        {
                FPHGameplayController val_3 = FPHGameplayController.Instance;
            this.HighlightTile(index:  val_3.<CaretIndex>k__BackingField);
            return;
        }
        
        this.RemoveAllHighlights();
    }
    public void DoStartAnimation()
    {
        System.Collections.Generic.List<FPHAnswerTile> val_8;
        DG.Tweening.Sequence val_1 = DG.Tweening.DOTween.Sequence();
        DG.Tweening.Sequence val_2 = DG.Tweening.TweenSettingsExtensions.AppendInterval(s:  val_1, interval:  0.1f);
        val_8 = this.<spawnedTiles>k__BackingField;
        var val_10 = 4;
        do
        {
            var val_3 = val_10 - 4;
            if(val_3 >= 30134272)
        {
                return;
        }
        
            if(30134272 <= val_3)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(30134272 <= val_3)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            UnityEngine.Vector3 val_6 = 740701304.transform.localPosition;
            float val_9 = (float)val_3;
            val_9 = val_9 * 0.06f;
            DG.Tweening.Sequence val_8 = DG.Tweening.TweenSettingsExtensions.Insert(s:  val_1, atPosition:  val_9, t:  DG.Tweening.ShortcutExtensions.DOLocalJump(target:  740701304.transform, endValue:  new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z}, jumpPower:  12f, numJumps:  1, duration:  0.3f, snapping:  false));
            val_8 = this.<spawnedTiles>k__BackingField;
            val_10 = val_10 + 1;
        }
        while(val_8 != null);
        
        throw new NullReferenceException();
    }
    public void DoLevelCompleteAnimation()
    {
        var val_5 = 4;
        do
        {
            var val_1 = val_5 - 4;
            if(val_1 >= true)
        {
                return;
        }
        
            if(true <= val_1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            if(true <= val_1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            UnityEngine.Vector3 val_4 = 0.transform.localPosition;
            DG.Tweening.Sequence val_5 = DG.Tweening.ShortcutExtensions.DOLocalJump(target:  0.transform, endValue:  new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z}, jumpPower:  20f, numJumps:  1, duration:  0.5f, snapping:  false);
            val_5 = val_5 + 1;
        }
        while((this.<spawnedTiles>k__BackingField) != null);
        
        throw new NullReferenceException();
    }
    public void DoLevelFailAnimation()
    {
        var val_3 = 0;
        do
        {
            if(val_3 >= 30134272)
        {
                return;
        }
        
            if(30134272 <= val_3)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
            DG.Tweening.Tweener val_2 = DG.Tweening.ShortcutExtensions.DOShakePosition(target:  740701304.transform, duration:  0.3f, strength:  1f, vibrato:  10, randomness:  90f, snapping:  false, fadeOut:  true);
            val_3 = val_3 + 1;
        }
        while((this.<spawnedTiles>k__BackingField) != null);
        
        throw new NullReferenceException();
    }
    private void OnSolveModeToggled(bool isOn)
    {
        if(isOn == false)
        {
                return;
        }
        
        FPHGameplayController val_1 = FPHGameplayController.Instance;
        this.HighlightTile(index:  val_1.<CaretIndex>k__BackingField);
    }
    private void HighlightTile(int index)
    {
        bool val_1 = true;
        this.RemoveAllHighlights();
        if((index & 2147483648) != 0)
        {
                return;
        }
        
        if(val_1 <= index)
        {
                return;
        }
        
        if(val_1 <= index)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_1 = val_1 + (index << 3);
        (true + (index) << 3) + 32.Highlight(isVisible:  true);
    }
    private void RemoveAllHighlights()
    {
        List.Enumerator<T> val_1 = this.<spawnedTiles>k__BackingField.GetEnumerator();
        label_4:
        if(0.MoveNext() == false)
        {
            goto label_2;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        0.Highlight(isVisible:  false);
        goto label_4;
        label_2:
        0.Dispose();
    }
    public FPHAnswerDisplay()
    {
        this.maxSlotsPerRow = 10;
        this.maxWidthPerSlot = 108f;
    }

}
