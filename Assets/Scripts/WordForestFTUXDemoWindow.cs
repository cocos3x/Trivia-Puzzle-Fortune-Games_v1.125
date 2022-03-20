using UnityEngine;
public class WordForestFTUXDemoWindow : WordAddictFTUXDemoWindow
{
    // Fields
    private int ftuxWordsCompleted;
    
    // Methods
    protected override UnityEngine.RectTransform GetMaskWordRegion(int stepNum)
    {
        var val_2;
        var val_3;
        if(stepNum == 2)
        {
            goto label_1;
        }
        
        if(stepNum != 1)
        {
            goto label_2;
        }
        
        if((System.String.op_Equality(a:  37896, b:  "en")) == false)
        {
            goto label_4;
        }
        
        val_2 = 44520976;
        goto label_6;
        label_1:
        label_10:
        val_2 = true + 32;
        label_6:
        val_3 = mem[(true + 32)];
        val_3 = val_2;
        return (UnityEngine.RectTransform)val_3;
        label_2:
        val_3 = 0;
        return (UnityEngine.RectTransform)val_3;
        label_4:
        if("developerPayload" != null)
        {
            goto label_10;
        }
        
        throw new IndexOutOfRangeException();
    }
    protected override UnityEngine.RectTransform GetMaskPan(int stepNum)
    {
        var val_3;
        var val_4;
        var val_5;
        if(stepNum == 2)
        {
            goto label_1;
        }
        
        if(stepNum != 1)
        {
            goto label_2;
        }
        
        val_3 = "developerPayload";
        if((System.String.op_Equality(a:  37895, b:  "en")) == false)
        {
            goto label_4;
        }
        
        val_4 = 44520984;
        goto label_6;
        label_1:
        val_3 = 38021;
        label_4:
        val_4 = true + 40;
        label_6:
        val_5 = mem[(true + 40)];
        val_5 = val_4;
        return (UnityEngine.RectTransform)val_5;
        label_2:
        val_5 = 0;
        return (UnityEngine.RectTransform)val_5;
    }
    protected override void UpdateState(string word)
    {
        int val_3 = this.ftuxWordsCompleted;
        val_3 = val_3 + 1;
        this.ftuxWordsCompleted = val_3;
        if(val_3 == 2)
        {
                mem[1152921517445620008] = 4;
        }
        else
        {
                if(val_3 == 1)
        {
                if((System.String.op_Equality(a:  word.ToUpper(), b:  "CAT")) != false)
        {
                return;
        }
        
        }
        
        }
        
        this.UpdateState(word:  word);
    }
    protected override void Progress()
    {
        var val_87;
        var val_88;
        var val_89;
        UnityEngine.Transform[] val_90;
        var val_91;
        int val_92;
        var val_93;
        var val_94;
        System.Predicate<LetterTile> val_96;
        var val_97;
        var val_98;
        System.Predicate<LetterTile> val_100;
        var val_101;
        System.Predicate<LetterTile> val_103;
        var val_104;
        int val_105;
        var val_106;
        var val_107;
        System.Predicate<LetterTile> val_109;
        var val_110;
        var val_111;
        System.Predicate<LetterTile> val_113;
        var val_114;
        var val_115;
        System.Predicate<LetterTile> val_117;
        var val_118;
        int val_119;
        int val_122;
        if((System.String.op_Inequality(a:  37897, b:  "en")) != false)
        {
                this.Progress();
            return;
        }
        
        val_87 = 1152921504765632512;
        if(MainController.instance != 0)
        {
                if(MainController.instance == null)
        {
                throw new NullReferenceException();
        }
        
            if(val_4.isGameComplete != false)
        {
                mem[1152921517446010792] = 5;
        }
        
        }
        
        WordRegion val_5 = WordRegion.instance;
        val_88 = 1152921504893161472;
        val_89 = 1152921513393576032;
        GameMaskOverlay val_6 = MonoSingleton<GameMaskOverlay>.Instance;
        if(Pan.tappingAllowed == false)
        {
                throw new NullReferenceException();
        }
        
        if(val_5 == null)
        {
                throw new NullReferenceException();
        }
        
        if(X23 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_90 = mem[Pan.tappingAllowed + 88];
        val_90 = Pan.tappingAllowed + 88;
        if((X23 + 24) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((X23 + 16 + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        val_91 = mem[X23 + 16 + 32 + 40];
        val_91 = X23 + 16 + 32 + 40;
        if(val_91 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((X23 + 16 + 32 + 40 + 24) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((X23 + 16 + 32 + 40 + 16 + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_7 = X23 + 16 + 32 + 40 + 16 + 32.transform;
        if(val_7 == null)
        {
                throw new NullReferenceException();
        }
        
        if(null != null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Vector2 val_9 = (null == null) ? (val_7) : 0.sizeDelta;
        float val_87 = val_9.x;
        UnityEngine.Transform val_10 = val_5.transform;
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Vector3 val_11 = val_10.localScale;
        val_87 = val_87 * val_11.x;
        if(null == 2)
        {
            goto label_26;
        }
        
        if(null != 1)
        {
            goto label_27;
        }
        
        WGFTUXManager val_12 = MonoSingleton<WGFTUXManager>.Instance;
        if(val_12 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_91 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_91.SetActive(value:  val_12.DisplaySkipTutorial);
        if(val_91 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((X23 + 16 + 32 + 40 + 24) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((X23 + 16 + 32 + 40 + 16 + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((X23 + 16 + 32 + 40 + 16 + 32 + 40) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((X23 + 16 + 32 + 40 + 16 + 32 + 40 + 24) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((X23 + 16 + 32 + 40 + 16 + 32 + 40 + 16 + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_15 = X23 + 16 + 32 + 40 + 16 + 32 + 40 + 16 + 32.transform;
        if((X23 + 16 + 32 + 40 + 16 + 32 + 40) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((X23 + 16 + 32 + 40 + 16 + 32 + 40 + 24) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((X23 + 16 + 32 + 40 + 16 + 32 + 40 + 16 + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((X23 + 16 + 32 + 40 + 16 + 32 + 40 + 16 + 32 + 40) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((X23 + 16 + 32 + 40 + 16 + 32 + 40 + 16 + 32 + 40 + 24) <= 1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((X23 + 16 + 32 + 40 + 16 + 32 + 40 + 16 + 32 + 40 + 16 + 40) == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_16 = X23 + 16 + 32 + 40 + 16 + 32 + 40 + 16 + 32 + 40 + 16 + 40.transform;
        if((X23 + 16 + 32 + 40 + 16 + 32 + 40 + 16 + 32 + 40) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((X23 + 16 + 32 + 40 + 16 + 32 + 40 + 16 + 32 + 40 + 24) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((X23 + 16 + 32 + 40 + 16 + 32 + 40 + 16 + 32 + 40 + 16 + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((X23 + 16 + 32 + 40 + 16 + 32 + 40 + 16 + 32 + 40 + 16 + 32 + 40) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((X23 + 16 + 32 + 40 + 16 + 32 + 40 + 16 + 32 + 40 + 16 + 32 + 40 + 24) <= 2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((X23 + 16 + 32 + 40 + 16 + 32 + 40 + 16 + 32 + 40 + 16 + 32 + 40 + 16 + 48) == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_17 = X23 + 16 + 32 + 40 + 16 + 32 + 40 + 16 + 32 + 40 + 16 + 32 + 40 + 16 + 48.transform;
        UnityEngine.Transform[] val_18 = new UnityEngine.Transform[4];
        if(val_18 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_15 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        val_92 = val_18.Length;
        if(val_92 == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_18[0] = val_15;
        if(val_16 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
            val_92 = val_18.Length;
        }
        
        if(val_92 <= 1)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_18[1] = val_16;
        if(val_17 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
            val_92 = val_18.Length;
        }
        
        if(val_92 <= 2)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_18[2] = val_17;
        if(this != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
            val_92 = val_18.Length;
        }
        
        if(val_92 <= 3)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_18[3] = this;
        if(val_6 == null)
        {
                throw new NullReferenceException();
        }
        
        val_6.ShowOverlay(contentToOverlay:  val_18);
        if(val_16 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Vector3 val_19 = val_16.position;
        if(this == null)
        {
                throw new NullReferenceException();
        }
        
        this.position = new UnityEngine.Vector3() {x = val_19.x, y = val_19.y, z = val_19.z};
        this.sizeDelta = new UnityEngine.Vector2() {x = val_87, y = val_19.y};
        UnityEngine.GameObject val_20 = this.gameObject;
        if(val_20 == null)
        {
                throw new NullReferenceException();
        }
        
        val_20.SetActive(value:  true);
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_21.<metaGameBehavior>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        val_93 = 0;
        if((System.String.op_Equality(a:  val_21.<metaGameBehavior>k__BackingField.GetCurrentLanguage(), b:  "en")) == false)
        {
            goto label_71;
        }
        
        val_94 = null;
        val_94 = null;
        val_96 = WordForestFTUXDemoWindow.<>c.<>9__4_0;
        if(val_96 == null)
        {
                System.Predicate<LetterTile> val_24 = null;
            val_96 = val_24;
            val_24 = new System.Predicate<LetterTile>(object:  WordForestFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordForestFTUXDemoWindow.<>c::<Progress>b__4_0(LetterTile x));
            WordForestFTUXDemoWindow.<>c.<>9__4_0 = val_96;
        }
        
        if(val_90 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_97 = null;
        val_98 = val_90.FindIndex(match:  val_24);
        val_97 = null;
        val_100 = WordForestFTUXDemoWindow.<>c.<>9__4_1;
        if(val_100 == null)
        {
                System.Predicate<LetterTile> val_26 = null;
            val_100 = val_26;
            val_26 = new System.Predicate<LetterTile>(object:  WordForestFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordForestFTUXDemoWindow.<>c::<Progress>b__4_1(LetterTile x));
            WordForestFTUXDemoWindow.<>c.<>9__4_1 = val_100;
        }
        
        val_101 = null;
        val_91 = val_90.FindIndex(match:  val_26);
        val_101 = null;
        val_103 = WordForestFTUXDemoWindow.<>c.<>9__4_2;
        if(val_103 == null)
        {
                System.Predicate<LetterTile> val_28 = null;
            val_103 = val_28;
            val_28 = new System.Predicate<LetterTile>(object:  WordForestFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordForestFTUXDemoWindow.<>c::<Progress>b__4_2(LetterTile x));
            WordForestFTUXDemoWindow.<>c.<>9__4_2 = val_103;
        }
        
        val_93 = public System.Int32 System.Collections.Generic.List<LetterTile>::FindIndex(System.Predicate<T> match);
        val_104 = val_90.FindIndex(match:  val_28);
        goto label_88;
        label_26:
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        val_10.SetActive(value:  false);
        NotificationCenter val_30 = NotificationCenter.DefaultCenter;
        if(val_30 == null)
        {
                throw new NullReferenceException();
        }
        
        val_30.PostNotification(aSender:  this, aName:  "OnEnableAllLetters");
        if(val_91 == 0)
        {
                throw new NullReferenceException();
        }
        
        if((X23 + 16 + 32 + 40 + 24) <= 1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((X23 + 16 + 32 + 40 + 16 + 40) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((X23 + 16 + 32 + 40 + 16 + 40 + 40) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((X23 + 16 + 32 + 40 + 16 + 40 + 40 + 24) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((X23 + 16 + 32 + 40 + 16 + 40 + 40 + 16 + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_31 = X23 + 16 + 32 + 40 + 16 + 40 + 40 + 16 + 32.transform;
        if((X23 + 16 + 32 + 40 + 16 + 40 + 40) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((X23 + 16 + 32 + 40 + 16 + 40 + 40 + 24) <= 1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((X23 + 16 + 32 + 40 + 16 + 40 + 40 + 16 + 40) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((X23 + 16 + 32 + 40 + 16 + 40 + 40 + 16 + 40 + 40) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((X23 + 16 + 32 + 40 + 16 + 40 + 40 + 16 + 40 + 40 + 24) <= 1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((X23 + 16 + 32 + 40 + 16 + 40 + 40 + 16 + 40 + 40 + 16 + 40) == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_32 = X23 + 16 + 32 + 40 + 16 + 40 + 40 + 16 + 40 + 40 + 16 + 40.transform;
        if((X23 + 16 + 32 + 40 + 16 + 40 + 40 + 16 + 40 + 40) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((X23 + 16 + 32 + 40 + 16 + 40 + 40 + 16 + 40 + 40 + 24) <= 1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((X23 + 16 + 32 + 40 + 16 + 40 + 40 + 16 + 40 + 40 + 16 + 40) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((X23 + 16 + 32 + 40 + 16 + 40 + 40 + 16 + 40 + 40 + 16 + 40 + 40) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((X23 + 16 + 32 + 40 + 16 + 40 + 40 + 16 + 40 + 40 + 16 + 40 + 40 + 24) <= 2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((X23 + 16 + 32 + 40 + 16 + 40 + 40 + 16 + 40 + 40 + 16 + 40 + 40 + 16 + 48) == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_33 = X23 + 16 + 32 + 40 + 16 + 40 + 40 + 16 + 40 + 40 + 16 + 40 + 40 + 16 + 48.transform;
        UnityEngine.Transform[] val_34 = new UnityEngine.Transform[4];
        if(val_34 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_31 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        val_105 = val_34.Length;
        if(val_105 == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_34[0] = val_31;
        if(val_32 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
            val_105 = val_34.Length;
        }
        
        if(val_105 <= 1)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_34[1] = val_32;
        if(val_33 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
            val_105 = val_34.Length;
        }
        
        if(val_105 <= 2)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_34[2] = val_33;
        if(this != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
            val_105 = val_34.Length;
        }
        
        if(val_105 <= 3)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_34[3] = this;
        if(val_6 == null)
        {
                throw new NullReferenceException();
        }
        
        val_6.ShowOverlay(contentToOverlay:  val_34);
        if(val_32 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Vector3 val_35 = val_32.position;
        if(this == null)
        {
                throw new NullReferenceException();
        }
        
        this.position = new UnityEngine.Vector3() {x = val_35.x, y = val_35.y, z = val_35.z};
        this.sizeDelta = new UnityEngine.Vector2() {x = val_87, y = val_35.y};
        UnityEngine.GameObject val_36 = this.gameObject;
        if(val_36 == null)
        {
                throw new NullReferenceException();
        }
        
        val_36.SetActive(value:  true);
        if(App.getBehavior == null)
        {
                throw new NullReferenceException();
        }
        
        if((val_37.<metaGameBehavior>k__BackingField) == null)
        {
                throw new NullReferenceException();
        }
        
        val_106 = 0;
        if((System.String.op_Equality(a:  val_37.<metaGameBehavior>k__BackingField.GetCurrentLanguage(), b:  "en")) == false)
        {
            goto label_132;
        }
        
        val_107 = null;
        val_107 = null;
        val_109 = WordForestFTUXDemoWindow.<>c.<>9__4_3;
        if(val_109 == null)
        {
                System.Predicate<LetterTile> val_40 = null;
            val_109 = val_40;
            val_40 = new System.Predicate<LetterTile>(object:  WordForestFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordForestFTUXDemoWindow.<>c::<Progress>b__4_3(LetterTile x));
            WordForestFTUXDemoWindow.<>c.<>9__4_3 = val_109;
        }
        
        if(val_90 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_110 = null;
        val_111 = val_90.FindIndex(match:  val_40);
        val_110 = null;
        val_113 = WordForestFTUXDemoWindow.<>c.<>9__4_4;
        if(val_113 == null)
        {
                System.Predicate<LetterTile> val_42 = null;
            val_113 = val_42;
            val_42 = new System.Predicate<LetterTile>(object:  WordForestFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordForestFTUXDemoWindow.<>c::<Progress>b__4_4(LetterTile x));
            WordForestFTUXDemoWindow.<>c.<>9__4_4 = val_113;
        }
        
        val_114 = null;
        val_115 = val_90.FindIndex(match:  val_42);
        val_114 = null;
        val_117 = WordForestFTUXDemoWindow.<>c.<>9__4_5;
        if(val_117 == null)
        {
                System.Predicate<LetterTile> val_44 = null;
            val_117 = val_44;
            val_44 = new System.Predicate<LetterTile>(object:  WordForestFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordForestFTUXDemoWindow.<>c::<Progress>b__4_5(LetterTile x));
            WordForestFTUXDemoWindow.<>c.<>9__4_5 = val_117;
        }
        
        val_106 = public System.Int32 System.Collections.Generic.List<LetterTile>::FindIndex(System.Predicate<T> match);
        val_118 = val_90.FindIndex(match:  val_44);
        goto label_149;
        label_27:
        if(val_10 == null)
        {
                throw new NullReferenceException();
        }
        
        int val_47 = DG.Tweening.ShortcutExtensions.DOKill(target:  val_10.transform, complete:  false);
        if(val_47 == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.GameObject val_48 = val_47.gameObject;
        if(val_48 == null)
        {
                throw new NullReferenceException();
        }
        
        val_48.SetActive(value:  false);
        if(val_48 == null)
        {
                throw new NullReferenceException();
        }
        
        val_48.Clear();
        mem[1152921517446010784] = 1152921515808126464;
        UnityEngine.PlayerPrefs.SetInt(key:  "t_step", value:  1);
        bool val_49 = PrefsSerializationManager.SavePlayerPrefs();
        this.CloseWindow();
        goto label_156;
        label_71:
        val_104 = 0;
        val_98 = 2;
        val_91 = 1;
        label_88:
        val_6.Interactable = true;
        UnityEngine.Transform[] val_50 = new UnityEngine.Transform[4];
        if(Pan.tappingAllowed == false)
        {
                throw new NullReferenceException();
        }
        
        if((Pan.tappingAllowed + 88) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((Pan.tappingAllowed + 88 + 24) <= val_98)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_88 = Pan.tappingAllowed + 88 + 16;
        val_88 = val_88 + 16;
        if(((Pan.tappingAllowed + 88 + 16 + 16) + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_51 = (Pan.tappingAllowed + 88 + 16 + 16) + 32.transform;
        if(val_50 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_51 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_50.Length == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_50[0] = val_51;
        if(Pan.tappingAllowed == false)
        {
                throw new NullReferenceException();
        }
        
        if((Pan.tappingAllowed + 88) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((Pan.tappingAllowed + 88 + 24) <= val_91)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_89 = Pan.tappingAllowed + 88 + 16;
        val_89 = val_89 + 8;
        if(((Pan.tappingAllowed + 88 + 16 + 8) + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_52 = (Pan.tappingAllowed + 88 + 16 + 8) + 32.transform;
        if(val_52 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_50.Length <= 1)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_50[1] = val_52;
        if(Pan.tappingAllowed == false)
        {
                throw new NullReferenceException();
        }
        
        if((Pan.tappingAllowed + 88) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((Pan.tappingAllowed + 88 + 24) <= val_104)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_90 = Pan.tappingAllowed + 88 + 16;
        val_90 = val_90 + 0;
        if(((Pan.tappingAllowed + 88 + 16 + 0) + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_53 = (Pan.tappingAllowed + 88 + 16 + 0) + 32.transform;
        if(val_53 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        val_119 = val_50.Length;
        if(val_119 <= 2)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_50[2] = val_53;
        if(this != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
            val_119 = val_50.Length;
        }
        
        if(val_119 <= 3)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_50[3] = this;
        val_6.ShowOverlay(contentToOverlay:  val_50);
        if(Pan.tappingAllowed == false)
        {
                throw new NullReferenceException();
        }
        
        if((Pan.tappingAllowed + 88) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((Pan.tappingAllowed + 88 + 24) <= val_91)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_91 = Pan.tappingAllowed + 88 + 16;
        val_91 = val_91 + 8;
        if(((Pan.tappingAllowed + 88 + 16 + 8) + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_54 = (Pan.tappingAllowed + 88 + 16 + 8) + 32.transform;
        if(val_54 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Vector3 val_55 = val_54.position;
        if(this == null)
        {
                throw new NullReferenceException();
        }
        
        this.position = new UnityEngine.Vector3() {x = val_55.x, y = val_55.y, z = val_55.z};
        UnityEngine.GameObject val_56 = this.gameObject;
        if(val_56 == null)
        {
                throw new NullReferenceException();
        }
        
        val_56.SetActive(value:  true);
        System.Collections.Generic.List<UnityEngine.Transform> val_57 = new System.Collections.Generic.List<UnityEngine.Transform>();
        if(Pan.tappingAllowed == false)
        {
                throw new NullReferenceException();
        }
        
        if((Pan.tappingAllowed + 88) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((Pan.tappingAllowed + 88 + 24) <= val_104)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_92 = Pan.tappingAllowed + 88 + 16;
        val_92 = val_92 + 0;
        if(((Pan.tappingAllowed + 88 + 16 + 0) + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        if(val_57 == null)
        {
                throw new NullReferenceException();
        }
        
        val_57.Add(item:  (Pan.tappingAllowed + 88 + 16 + 0) + 32.transform);
        if(Pan.tappingAllowed == false)
        {
                throw new NullReferenceException();
        }
        
        if((Pan.tappingAllowed + 88) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((Pan.tappingAllowed + 88 + 24) <= val_98)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_93 = Pan.tappingAllowed + 88 + 16;
        val_93 = val_93 + 16;
        if(((Pan.tappingAllowed + 88 + 16 + 16) + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        val_57.Add(item:  (Pan.tappingAllowed + 88 + 16 + 16) + 32.transform);
        mem[1152921517446010776] = val_57;
        val_87 = 1152921504765632512;
        if(Pan.tappingAllowed == false)
        {
                throw new NullReferenceException();
        }
        
        if((Pan.tappingAllowed + 88) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((Pan.tappingAllowed + 88 + 24) <= val_91)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_94 = Pan.tappingAllowed + 88 + 16;
        val_94 = val_94 + 8;
        if(((Pan.tappingAllowed + 88 + 16 + 8) + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        mem[1152921517446010784] = (Pan.tappingAllowed + 88 + 16 + 8) + 32.transform;
        UnityEngine.Transform[] val_61 = new UnityEngine.Transform[1];
        val_88 = 1152921504893161472;
        val_89 = 1152921513393576032;
        if(val_94 != 0)
        {
            goto label_202;
        }
        
        throw new NullReferenceException();
        label_132:
        val_111 = 0;
        val_115 = 1;
        val_118 = 2;
        label_149:
        UnityEngine.Transform[] val_62 = new UnityEngine.Transform[4];
        if(Pan.tappingAllowed == false)
        {
                throw new NullReferenceException();
        }
        
        if((Pan.tappingAllowed + 88) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((Pan.tappingAllowed + 88 + 24) <= val_111)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_95 = Pan.tappingAllowed + 88 + 16;
        val_95 = val_95 + 0;
        if(((Pan.tappingAllowed + 88 + 16 + 0) + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_63 = (Pan.tappingAllowed + 88 + 16 + 0) + 32.transform;
        if(val_62 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_63 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_62.Length == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_62[0] = val_63;
        if(Pan.tappingAllowed == false)
        {
                throw new NullReferenceException();
        }
        
        if((Pan.tappingAllowed + 88) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((Pan.tappingAllowed + 88 + 24) <= val_115)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_96 = Pan.tappingAllowed + 88 + 16;
        val_96 = val_96 + 8;
        if(((Pan.tappingAllowed + 88 + 16 + 8) + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_64 = (Pan.tappingAllowed + 88 + 16 + 8) + 32.transform;
        if(val_64 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        if(val_62.Length <= 1)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_62[1] = val_64;
        if(Pan.tappingAllowed == false)
        {
                throw new NullReferenceException();
        }
        
        if((Pan.tappingAllowed + 88) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((Pan.tappingAllowed + 88 + 24) <= val_118)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_97 = Pan.tappingAllowed + 88 + 16;
        val_97 = val_97 + 16;
        if(((Pan.tappingAllowed + 88 + 16 + 16) + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_65 = (Pan.tappingAllowed + 88 + 16 + 16) + 32.transform;
        if(val_65 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        val_122 = val_62.Length;
        if(val_122 <= 2)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_62[2] = val_65;
        if(this != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
            val_122 = val_62.Length;
        }
        
        if(val_122 <= 3)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_62[3] = this;
        val_6.ShowOverlay(contentToOverlay:  val_62);
        if(Pan.tappingAllowed == false)
        {
                throw new NullReferenceException();
        }
        
        if((Pan.tappingAllowed + 88) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((Pan.tappingAllowed + 88 + 24) <= val_115)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_98 = Pan.tappingAllowed + 88 + 16;
        val_98 = val_98 + 8;
        if(((Pan.tappingAllowed + 88 + 16 + 8) + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Transform val_66 = (Pan.tappingAllowed + 88 + 16 + 8) + 32.transform;
        if(val_66 == null)
        {
                throw new NullReferenceException();
        }
        
        UnityEngine.Vector3 val_67 = val_66.position;
        if(this == null)
        {
                throw new NullReferenceException();
        }
        
        this.position = new UnityEngine.Vector3() {x = val_67.x, y = val_67.y, z = val_67.z};
        UnityEngine.GameObject val_68 = this.gameObject;
        if(val_68 == null)
        {
                throw new NullReferenceException();
        }
        
        val_68.SetActive(value:  true);
        System.Collections.Generic.List<UnityEngine.Transform> val_69 = new System.Collections.Generic.List<UnityEngine.Transform>();
        if(Pan.tappingAllowed == false)
        {
                throw new NullReferenceException();
        }
        
        if((Pan.tappingAllowed + 88) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((Pan.tappingAllowed + 88 + 24) <= val_115)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_99 = Pan.tappingAllowed + 88 + 16;
        val_99 = val_99 + 8;
        if(((Pan.tappingAllowed + 88 + 16 + 8) + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        val_87 = 1152921504765632512;
        if(val_69 == null)
        {
                throw new NullReferenceException();
        }
        
        val_91 = 1152921513396270672;
        val_69.Add(item:  (Pan.tappingAllowed + 88 + 16 + 8) + 32.transform);
        if(Pan.tappingAllowed == false)
        {
                throw new NullReferenceException();
        }
        
        if((Pan.tappingAllowed + 88) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((Pan.tappingAllowed + 88 + 24) <= val_111)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_100 = Pan.tappingAllowed + 88 + 16;
        val_100 = val_100 + 0;
        if(((Pan.tappingAllowed + 88 + 16 + 0) + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        val_69.Add(item:  (Pan.tappingAllowed + 88 + 16 + 0) + 32.transform);
        mem[1152921517446010776] = val_69;
        val_88 = 1152921504893161472;
        val_89 = 1152921513393576032;
        if(Pan.tappingAllowed == false)
        {
                throw new NullReferenceException();
        }
        
        if((Pan.tappingAllowed + 88) == 0)
        {
                throw new NullReferenceException();
        }
        
        if((Pan.tappingAllowed + 88 + 24) <= val_118)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_101 = Pan.tappingAllowed + 88 + 16;
        val_101 = val_101 + 16;
        if(((Pan.tappingAllowed + 88 + 16 + 16) + 32) == 0)
        {
                throw new NullReferenceException();
        }
        
        mem[1152921517446010784] = (Pan.tappingAllowed + 88 + 16 + 16) + 32.transform;
        UnityEngine.Transform[] val_73 = new UnityEngine.Transform[1];
        if(val_101 == 0)
        {
                throw new NullReferenceException();
        }
        
        label_202:
        val_90 = val_73;
        UnityEngine.Transform val_74 = val_101.transform;
        if(val_90 == null)
        {
                throw new NullReferenceException();
        }
        
        if(val_74 != null)
        {
                if(X0 == false)
        {
                throw new ArrayTypeMismatchException();
        }
        
        }
        
        int val_102 = val_73.Length;
        if(val_102 == 0)
        {
                throw new IndexOutOfRangeException();
        }
        
        val_90[0] = val_74;
        val_6.ShowOverlay(contentToOverlay:  val_73);
        label_156:
        val_102 = val_102 - 1;
        if(val_102 > 1)
        {
                return;
        }
        
        GameMaskOverlay val_75 = MonoSingleton<GameMaskOverlay>.Instance;
        val_75.BlockRaycasts = false;
        if(val_75.activeSelf == false)
        {
            goto label_259;
        }
        
        bool val_77 = UnityEngine.Object.op_Equality(x:  val_6, y:  0);
        if(val_77 == false)
        {
            goto label_262;
        }
        
        UnityEngine.GameObject val_80 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  val_6, parent:  this.gameObject.transform);
        mem[1152921517446010816] = val_80;
        if(val_80 != null)
        {
            goto label_266;
        }
        
        return;
        label_262:
        label_266:
        UnityEngine.Vector3 val_83 = UnityEngine.Object.__il2cppRuntimeField_cctor_finished.transform.position;
        val_77.transform.position = new UnityEngine.Vector3() {x = val_83.x, y = val_83.y, z = val_83.z};
        UnityEngine.Transform[] val_85 = new UnityEngine.Transform[1];
        val_90 = val_85;
        val_90[0] = transform;
        MonoSingleton<GameMaskOverlay>.Instance.ShowOverlay(contentToOverlay:  val_85);
        label_259:
        this.AnimateCursor();
    }
    public WordForestFTUXDemoWindow()
    {
    
    }

}
