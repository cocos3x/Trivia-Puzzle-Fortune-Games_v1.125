using UnityEngine;
public class FPHKeyboard : MonoBehaviour
{
    // Fields
    public const char KEY_QUIT = '\x7';
    public const char KEY_BACKSPACE = '\x8';
    private System.Collections.Generic.List<UnityEngine.UI.HorizontalLayoutGroup> keyRows;
    private bool setup;
    private FPHKeyButton keyButtonPrefab;
    private FPHKeyButton keyButtonBackspacePrefab;
    private FPHKeyButton keyButtonQuitPrefab;
    private System.Collections.Generic.Dictionary<char, FPHKeyButton> keyboardKeys;
    public static readonly System.Collections.Generic.List<System.Collections.Generic.List<char>> LettersPerRow;
    
    // Methods
    public static bool IsLetter(char value)
    {
        return System.Char.IsLetter(c:  value);
    }
    public static bool IsVowel(char value)
    {
        char val_1 = value & 65535;
        char val_2 = val_1 - 65;
        if(val_2 > '4')
        {
                return (bool)(val_1 == 'U') ? 1 : 0;
        }
        
        val_2 = 1 << val_2;
        if((val_2 & '䄑') != 0)
        {
                return (bool)(val_1 == 'U') ? 1 : 0;
        }
        
        return true;
    }
    private void SetupNewKeyboard()
    {
        char val_3;
        var val_4;
        var val_11;
        var val_12;
        System.Collections.Generic.List<System.Collections.Generic.List<System.Char>> val_13;
        FPHKeyButton val_14;
        if(this.setup == true)
        {
                return;
        }
        
        this.keyboardKeys = new System.Collections.Generic.Dictionary<System.Char, FPHKeyButton>();
        var val_14 = 0;
        val_11 = 0;
        label_27:
        val_12 = null;
        val_12 = null;
        val_13 = FPHKeyboard.LettersPerRow;
        if(val_14 >= (FPHKeyboard.LettersPerRow + 24))
        {
            goto label_5;
        }
        
        val_13 = FPHKeyboard.LettersPerRow;
        if((FPHKeyboard.LettersPerRow + 24) <= val_14)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_11 = FPHKeyboard.LettersPerRow + 16;
        val_11 = val_11 + 0;
        List.Enumerator<T> val_2 = (FPHKeyboard.LettersPerRow + 16 + 0) + 32.GetEnumerator();
        label_25:
        if(val_4.MoveNext() == false)
        {
            goto label_11;
        }
        
        FPHKeyboard.<>c__DisplayClass11_0 val_6 = new FPHKeyboard.<>c__DisplayClass11_0();
        if(val_6 == null)
        {
                throw new NullReferenceException();
        }
        
        .<>4__this = this;
        .newKey = val_3;
        if(val_3 == 7)
        {
            goto label_13;
        }
        
        val_14 = this.keyButtonPrefab;
        if(val_3 != 8)
        {
            goto label_15;
        }
        
        val_14 = this.keyButtonBackspacePrefab;
        goto label_15;
        label_13:
        val_14 = this.keyButtonQuitPrefab;
        label_15:
        if(this.keyRows == null)
        {
                throw new NullReferenceException();
        }
        
        if(W9 <= val_14)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        val_14 = val_14 + 0;
        if(((this.keyButtonQuitPrefab + 0) + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        FPHKeyButton val_8 = UnityEngine.Object.Instantiate<FPHKeyButton>(original:  val_14, parent:  (this.keyButtonQuitPrefab + 0) + 32.transform);
        if(val_8 == null)
        {
                throw new NullReferenceException();
        }
        
        val_8.Init(myCharacter:  (FPHKeyboard.<>c__DisplayClass11_0)[1152921515960523728].newKey, state:  1);
        System.Delegate val_10 = System.Delegate.Combine(a:  val_8.onClickAction, b:  new System.Action(object:  val_6, method:  System.Void FPHKeyboard.<>c__DisplayClass11_0::<SetupNewKeyboard>b__0()));
        if(val_10 != null)
        {
                if(null != null)
        {
            goto label_47;
        }
        
        }
        
        val_8.onClickAction = val_10;
        if(this.keyboardKeys == null)
        {
                throw new NullReferenceException();
        }
        
        this.keyboardKeys.Add(key:  (FPHKeyboard.<>c__DisplayClass11_0)[1152921515960523728].newKey, value:  val_8);
        goto label_25;
        label_11:
        var val_13 = 1;
        val_4.Dispose();
        label_49:
        if(val_13 != 1)
        {
                var val_12 = 0;
            val_12 = val_12 ^ 0;
            val_13 = val_13 + val_12;
        }
        
        val_14 = val_14 + 1;
        goto label_27;
        label_47:
        val_11 = val_11;
        if(null != 1)
        {
            goto label_48;
        }
        
        val_4.Dispose();
        if(null == null)
        {
            goto label_49;
        }
        
        throw 1152921504625324032;
        label_5:
        this.setup = true;
        return;
        label_48:
    }
    public void OnKeyClicked(char key)
    {
        FPHGameplayController.Instance.OnLetterPressed(letter:  key);
    }
    public void ResetKeyboard()
    {
        if(this.setup == false)
        {
            goto label_1;
        }
        
        Dictionary.Enumerator<TKey, TValue> val_1 = this.keyboardKeys.GetEnumerator();
        this = 1152921515960737808;
        label_5:
        if(0.MoveNext() == false)
        {
            goto label_3;
        }
        
        if(0 == 0)
        {
                throw new NullReferenceException();
        }
        
        0.SetActive();
        goto label_5;
        label_3:
        0.Dispose();
        return;
        label_1:
        this.SetupNewKeyboard();
    }
    public void UpdateKeyboard(FPHGameplayState state)
    {
        char val_2;
        var val_3;
        System.Collections.Generic.Dictionary<System.Char, FPHKeyButton> val_16;
        string val_17;
        bool val_18;
        if(this.setup != true)
        {
                this.SetupNewKeyboard();
        }
        
        List.Enumerator<T> val_1 = state.lettersPurchased.GetEnumerator();
        label_11:
        if(val_3.MoveNext() == false)
        {
            goto label_4;
        }
        
        val_17 = val_2.ToString();
        if(state.phraseSlotCorrectValue == null)
        {
                throw new NullReferenceException();
        }
        
        if((state.phraseSlotCorrectValue.Contains(value:  val_17)) != false)
        {
                val_18 = 1;
        }
        else
        {
                string val_7 = state.phraseSlotCorrectValueNormalized;
            val_17 = val_2.ToString();
            if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
            val_18 = val_7.Contains(value:  val_17);
        }
        
        val_16 = this.keyboardKeys;
        if(val_16 == null)
        {
                throw new NullReferenceException();
        }
        
        val_17 = val_2;
        FPHKeyButton val_10 = val_16.Item[val_17];
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        val_10.SetPurchased(isCorrectLetter:  val_18);
        goto label_11;
        label_4:
        val_3.Dispose();
        List.Enumerator<T> val_11 = state.lettersPowerupRemoved.GetEnumerator();
        label_18:
        val_17 = public System.Boolean List.Enumerator<System.Char>::MoveNext();
        if(val_3.MoveNext() == false)
        {
            goto label_13;
        }
        
        val_16 = this.keyboardKeys;
        if(val_16 == null)
        {
                throw new NullReferenceException();
        }
        
        val_17 = val_2;
        if((val_16.ContainsKey(key:  val_17)) == false)
        {
            goto label_18;
        }
        
        val_16 = this.keyboardKeys;
        if(val_16 == null)
        {
                throw new NullReferenceException();
        }
        
        val_17 = val_2;
        FPHKeyButton val_14 = val_16.Item[val_17];
        if(val_14 == null)
        {
                throw new NullReferenceException();
        }
        
        val_14.SetPowerupRemoved();
        goto label_18;
        label_13:
        val_3.Dispose();
        this.UpdateTutorialKeyboard(state:  state);
    }
    private void UpdateTutorialKeyboard(FPHGameplayState state)
    {
        char val_6;
        char val_7;
        var val_18;
        System.Collections.Generic.Dictionary<System.Char, FPHKeyButton> val_19;
        char val_20;
        val_18 = 1152921504901894144;
        FPHGameplayController val_1 = FPHGameplayController.Instance;
        if(val_1 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_1 & 1) == 0)
        {
                return;
        }
        
        FPHGameplayController val_2 = FPHGameplayController.Instance;
        if(val_2 == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_2 & 1) == 0)
        {
                return;
        }
        
        if(state == null)
        {
                throw new NullReferenceException();
        }
        
        val_19 = this.keyboardKeys;
        if(val_19 == null)
        {
                throw new NullReferenceException();
        }
        
        val_20 = state.currentTutorialLetter;
        if(val_19.Item[val_20] == null)
        {
                throw new NullReferenceException();
        }
        
        val_19 = val_3.glowAnim;
        if(val_19 == null)
        {
                throw new NullReferenceException();
        }
        
        val_20 = 0;
        val_19.Play();
        val_19 = this.keyboardKeys;
        if(val_19 == null)
        {
                throw new NullReferenceException();
        }
        
        Dictionary.Enumerator<TKey, TValue> val_4 = val_19.GetEnumerator();
        label_25:
        if(val_7.MoveNext() == false)
        {
            goto label_14;
        }
        
        val_19 = state.phraseSlotCorrectValue;
        val_20 = val_6;
        if((System.Linq.Enumerable.Contains<System.Char>(source:  val_19, value:  val_20)) == true)
        {
            goto label_15;
        }
        
        val_20 = val_6;
        if((System.Linq.Enumerable.Contains<System.Char>(source:  state.phraseSlotCorrectValueNormalized, value:  val_20)) == false)
        {
            goto label_16;
        }
        
        label_15:
        if(state.currentTutorialLetter != val_6)
        {
            goto label_17;
        }
        
        if(val_6 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19 = mem[val_6 + 88];
        val_19 = val_6 + 88;
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19.Play();
        goto label_25;
        label_17:
        if(val_6 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19 = mem[val_6 + 88];
        val_19 = val_6 + 88;
        if(val_19 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_19.Stop();
        goto label_25;
        label_16:
        val_6.SetInactive();
        goto label_25;
        label_14:
        val_7.Dispose();
        val_18 = MonoSingleton<FPHGameplayUIController>.Instance;
        val_7 = state.currentTutorialLetter;
        val_20 = val_7;
        if(val_18 == null)
        {
                throw new NullReferenceException();
        }
        
        val_18.UpdateTutorialText(text:  System.String.Format(format:  System.String.Format(format:  "{0}\n{1}", arg0:  Localization.Localize(key:  "FPH_FTUX1_ln1", defaultValue:  "Tap letters to guess the phrase.", useSingularKey:  false), arg1:  Localization.Localize(key:  "FPH_FTUX1_ln2", defaultValue:  "Tap {0} now!", useSingularKey:  false)), arg0:  val_7));
    }
    public FPHKeyboard()
    {
    
    }
    private static FPHKeyboard()
    {
        System.Collections.Generic.List<System.Collections.Generic.List<System.Char>> val_1 = new System.Collections.Generic.List<System.Collections.Generic.List<System.Char>>();
        System.Collections.Generic.List<System.Char> val_2 = new System.Collections.Generic.List<System.Char>();
        val_2.Add(item:  'Q');
        val_2.Add(item:  'W');
        val_2.Add(item:  'E');
        val_2.Add(item:  'R');
        val_2.Add(item:  'T');
        val_2.Add(item:  'Y');
        val_2.Add(item:  'U');
        val_2.Add(item:  'I');
        val_2.Add(item:  'O');
        val_2.Add(item:  'P');
        val_1.Add(item:  val_2);
        System.Collections.Generic.List<System.Char> val_3 = new System.Collections.Generic.List<System.Char>();
        val_3.Add(item:  'A');
        val_3.Add(item:  'S');
        val_3.Add(item:  'D');
        val_3.Add(item:  'F');
        val_3.Add(item:  'G');
        val_3.Add(item:  'H');
        val_3.Add(item:  'J');
        val_3.Add(item:  'K');
        val_3.Add(item:  'L');
        val_1.Add(item:  val_3);
        System.Collections.Generic.List<System.Char> val_4 = new System.Collections.Generic.List<System.Char>();
        val_4.Add(item:  '');
        val_4.Add(item:  'Z');
        val_4.Add(item:  'X');
        val_4.Add(item:  'C');
        val_4.Add(item:  'V');
        val_4.Add(item:  'B');
        val_4.Add(item:  'N');
        val_4.Add(item:  'M');
        val_4.Add(item:  '');
        val_1.Add(item:  val_4);
        FPHKeyboard.LettersPerRow = val_1;
    }

}
