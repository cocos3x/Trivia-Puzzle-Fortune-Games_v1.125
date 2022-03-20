using UnityEngine;
public class WordAddictFTUXDemoWindow : FTUXDemoWindow
{
    // Fields
    protected UnityEngine.UI.Image handCursor;
    protected UnityEngine.RectTransform[] maskActionStep1;
    protected UnityEngine.RectTransform[] maskActionStep2;
    protected UnityEngine.GameObject SkipTutorialBtn;
    protected UnityEngine.Transform bottom_left;
    private UnityEngine.Transform top;
    private UnityEngine.Transform bottom_right;
    protected int padding;
    private const string CURRENT_LANGUAGE_TUTORIAL = "current_language_tutorial";
    protected const string EN = "en";
    private const string ES = "es";
    private const string FR = "fr";
    private const string DE = "de";
    protected const int L = 0;
    protected const int O = 1;
    protected const int S = 2;
    protected const int G = 0;
    protected const int U = 0;
    protected const int N = 1;
    protected const int A = 2;
    protected const int B = 0;
    protected System.Collections.Generic.List<UnityEngine.Transform> allowedPoints;
    protected UnityEngine.Transform initial;
    protected int state;
    protected string currentLanguage;
    private DG.Tweening.Sequence cursorSeq;
    protected UnityEngine.GameObject dummySkipButton;
    
    // Properties
    protected virtual int M { get; }
    protected virtual int Y { get; }
    protected virtual int D { get; }
    protected virtual int E { get; }
    
    // Methods
    protected virtual int get_M()
    {
        return 1;
    }
    protected virtual int get_Y()
    {
        return 2;
    }
    protected virtual int get_D()
    {
        return 1;
    }
    protected virtual int get_E()
    {
        return 2;
    }
    private void OnEnable()
    {
        GameBehavior val_1 = App.getBehavior;
        string val_2 = val_1.<metaGameBehavior>k__BackingField.GetCurrentLanguage();
        this.currentLanguage = val_2;
        if((System.String.op_Inequality(a:  val_2, b:  UnityEngine.PlayerPrefs.GetString(key:  "current_language_tutorial", defaultValue:  "en"))) != false)
        {
                this.state = 1;
            UnityEngine.PlayerPrefs.SetString(key:  "current_language_tutorial", value:  this.currentLanguage);
        }
        else
        {
                this.state = UnityEngine.PlayerPrefs.GetInt(key:  "t_step", defaultValue:  1);
        }
        
        WordRegion.instance.addOnWordFoundAction(callback:  new System.Action<System.String>(object:  this, method:  System.Void WordAddictFTUXDemoWindow::OnWordFound(string word)));
        UnityEngine.Color val_9 = new UnityEngine.Color(r:  0f, g:  0f, b:  0f, a:  0.45f);
        System.Nullable<UnityEngine.Color> val_10 = new System.Nullable<UnityEngine.Color>(value:  new UnityEngine.Color() {r = val_9.r, g = val_9.g, b = val_9.b, a = val_9.a});
        MonoSingleton<GameMaskOverlay>.Instance.SetOptions(bgColor:  new System.Nullable<UnityEngine.Color>() {HasValue = true}, fadeInDuration:  0.5f, fadeOutDuration:  0.15f);
    }
    private void OnWordFound(string word)
    {
        MonoSingleton<GameMaskOverlay>.Instance.CloseOverlay(onClosed:  new System.Action(object:  this, method:  System.Void WordAddictFTUXDemoWindow::OnOverlayClosed()));
        if(this.cursorSeq != null)
        {
                DG.Tweening.TweenExtensions.Kill(t:  this.cursorSeq, complete:  false);
        }
        
        this.handCursor.gameObject.SetActive(value:  false);
        UnityEngine.PlayerPrefs.SetInt(key:  "t_step", value:  this.state);
        bool val_4 = PrefsSerializationManager.SavePlayerPrefs();
        this.StopAllCoroutines();
        UnityEngine.Coroutine val_6 = this.StartCoroutine(routine:  this.ProgressSoon(seconds:  1.1f));
    }
    private System.Collections.IEnumerator ProgressSoon(float seconds = 1.1)
    {
        .<>1__state = 0;
        .<>4__this = this;
        .seconds = seconds;
        return (System.Collections.IEnumerator)new WordAddictFTUXDemoWindow.<ProgressSoon>d__37();
    }
    protected virtual void UpdateState(string word)
    {
        int val_1 = this.state;
        val_1 = val_1 + 1;
        this.state = val_1;
    }
    protected virtual void Progress()
    {
        var val_160;
        var val_161;
        var val_162;
        var val_163;
        UnityEngine.Transform[] val_164;
        float val_165;
        int val_166;
        var val_167;
        System.Predicate<LetterTile> val_169;
        var val_170;
        var val_171;
        var val_172;
        System.Predicate<LetterTile> val_174;
        int val_175;
        var val_176;
        System.Predicate<LetterTile> val_178;
        var val_179;
        var val_180;
        var val_181;
        System.Predicate<LetterTile> val_183;
        var val_184;
        var val_185;
        System.Predicate<LetterTile> val_187;
        var val_188;
        System.Predicate<LetterTile> val_190;
        var val_191;
        var val_193;
        System.Predicate<LetterTile> val_195;
        var val_196;
        System.Predicate<LetterTile> val_198;
        var val_199;
        var val_201;
        System.Predicate<LetterTile> val_203;
        var val_204;
        var val_206;
        System.Predicate<LetterTile> val_208;
        var val_209;
        var val_211;
        System.Predicate<LetterTile> val_213;
        var val_214;
        System.Predicate<LetterTile> val_216;
        var val_217;
        var val_219;
        System.Predicate<LetterTile> val_221;
        var val_222;
        System.Predicate<LetterTile> val_224;
        var val_225;
        var val_227;
        System.Predicate<LetterTile> val_229;
        var val_230;
        var val_232;
        System.Predicate<LetterTile> val_234;
        var val_235;
        var val_237;
        System.Predicate<LetterTile> val_239;
        var val_240;
        System.Predicate<LetterTile> val_242;
        var val_243;
        var val_245;
        System.Predicate<LetterTile> val_247;
        var val_248;
        System.Predicate<LetterTile> val_250;
        var val_251;
        var val_253;
        System.Predicate<LetterTile> val_255;
        var val_256;
        var val_258;
        System.Predicate<LetterTile> val_260;
        var val_261;
        int val_263;
        var val_265;
        System.Predicate<LetterTile> val_267;
        var val_268;
        System.Predicate<LetterTile> val_270;
        var val_271;
        var val_273;
        System.Predicate<LetterTile> val_275;
        var val_276;
        System.Predicate<LetterTile> val_278;
        var val_279;
        int val_281;
        val_160 = 1152921504765632512;
        if(MainController.instance != 0)
        {
                MainController val_3 = MainController.instance;
            if(val_3.isGameComplete != false)
        {
                this.state = 5;
        }
        
        }
        
        val_161 = 1152921504893161472;
        val_162 = WordRegion.instance;
        val_163 = 1152921513393576032;
        GameMaskOverlay val_5 = MonoSingleton<GameMaskOverlay>.Instance;
        GameBehavior val_6 = App.getBehavior;
        string val_7 = val_6.<metaGameBehavior>k__BackingField.GetCurrentLanguage();
        val_164 = mem[Pan.tappingAllowed + 88];
        val_164 = Pan.tappingAllowed + 88;
        if((X24 + 24) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((X24 + 16 + 32 + 40 + 24) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        UnityEngine.Vector2 val_10 = (null == null) ? X24 + 16 + 32 + 40 + 16 + 32.transform : 0.sizeDelta;
        UnityEngine.Vector3 val_12 = val_162.transform.localScale;
        val_165 = val_10.x * val_12.x;
        if(this.state == 2)
        {
            goto label_29;
        }
        
        if(this.state != 1)
        {
            goto label_30;
        }
        
        this.SkipTutorialBtn.SetActive(value:  MonoSingleton<WGFTUXManager>.Instance.DisplaySkipTutorial);
        if((public static WGFTUXManager MonoSingleton<WGFTUXManager>::get_Instance()) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        System.ThrowHelper.ThrowArgumentOutOfRangeException();
        UnityEngine.Transform val_17 = public System.Void System.Predicate<SubscriptionModel>::.ctor(object object, IntPtr method).__il2cppRuntimeField_28 + 16 + 32 + 40 + 16 + 40.transform;
        UnityEngine.Transform[] val_18 = new UnityEngine.Transform[3];
        val_166 = val_18.Length;
        val_18[0] = public System.Void System.Predicate<SubscriptionModel>::.ctor(object object, IntPtr method).__il2cppRuntimeField_28 + 16 + 32.transform;
        if(val_17 != null)
        {
                val_166 = val_18.Length;
        }
        
        val_18[1] = val_17;
        if(this != null)
        {
                val_166 = val_18.Length;
        }
        
        val_18[2] = this;
        val_5.ShowOverlay(contentToOverlay:  val_18);
        this.position = new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z};
        this.sizeDelta = new UnityEngine.Vector2() {x = val_165, y = val_12.y};
        this.gameObject.SetActive(value:  true);
        bool val_21 = System.String.op_Equality(a:  val_7, b:  "en");
        if(App.Player != 1)
        {
            goto label_63;
        }
        
        if(val_21 == false)
        {
            goto label_64;
        }
        
        val_167 = null;
        val_167 = null;
        val_169 = WordAddictFTUXDemoWindow.<>c.<>9__39_0;
        if(val_169 == null)
        {
                System.Predicate<LetterTile> val_22 = null;
            val_169 = val_22;
            val_22 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_0(LetterTile x));
            WordAddictFTUXDemoWindow.<>c.<>9__39_0 = val_169;
        }
        
        val_170 = 1152921517445783712;
        val_171 = null;
        val_172 = val_164.FindIndex(match:  val_22);
        val_171 = null;
        val_174 = WordAddictFTUXDemoWindow.<>c.<>9__39_1;
        if(val_174 != null)
        {
            goto label_322;
        }
        
        System.Predicate<LetterTile> val_24 = null;
        val_174 = val_24;
        val_24 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_1(LetterTile x));
        WordAddictFTUXDemoWindow.<>c.<>9__39_1 = val_174;
        goto label_322;
        label_29:
        this.SkipTutorialBtn.SetActive(value:  false);
        NotificationCenter.DefaultCenter.PostNotification(aSender:  this, aName:  "OnEnableAllLetters");
        if((X24 + 16 + 32 + 40 + 24) <= 1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((X24 + 16 + 32 + 40 + 16 + 40 + 40 + 24) == 0)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((X24 + 16 + 32 + 40 + 16 + 40 + 40 + 24) <= 1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((X24 + 16 + 32 + 40 + 16 + 40 + 40 + 16 + 40 + 40 + 24) <= 1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        UnityEngine.Transform val_27 = X24 + 16 + 32 + 40 + 16 + 40 + 40 + 16 + 40 + 40 + 16 + 40.transform;
        if((X24 + 16 + 32 + 40 + 16 + 40 + 40 + 16 + 40 + 40 + 24) <= 1)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        if((X24 + 16 + 32 + 40 + 16 + 40 + 40 + 16 + 40 + 40 + 16 + 40 + 40 + 24) <= 2)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        UnityEngine.Transform val_28 = X24 + 16 + 32 + 40 + 16 + 40 + 40 + 16 + 40 + 40 + 16 + 40 + 40 + 16 + 48.transform;
        UnityEngine.Transform[] val_29 = new UnityEngine.Transform[4];
        val_175 = val_29.Length;
        val_29[0] = X24 + 16 + 32 + 40 + 16 + 40 + 40 + 16 + 32.transform;
        if(val_27 != null)
        {
                val_175 = val_29.Length;
        }
        
        val_29[1] = val_27;
        if(val_28 != null)
        {
                val_175 = val_29.Length;
        }
        
        val_29[2] = val_28;
        if(this != null)
        {
                val_175 = val_29.Length;
        }
        
        val_29[3] = this;
        val_5.ShowOverlay(contentToOverlay:  val_29);
        UnityEngine.Vector3 val_30 = val_27.position;
        this.position = new UnityEngine.Vector3() {x = val_30.x, y = val_30.y, z = val_30.z};
        this.sizeDelta = new UnityEngine.Vector2() {x = val_165, y = val_30.y};
        this.gameObject.SetActive(value:  true);
        bool val_33 = System.String.op_Equality(a:  val_7, b:  "en");
        if(App.Player != 1)
        {
            goto label_119;
        }
        
        if(val_33 == false)
        {
            goto label_120;
        }
        
        val_176 = null;
        val_176 = null;
        val_178 = WordAddictFTUXDemoWindow.<>c.<>9__39_16;
        if(val_178 == null)
        {
                System.Predicate<LetterTile> val_34 = null;
            val_178 = val_34;
            val_34 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_16(LetterTile x));
            WordAddictFTUXDemoWindow.<>c.<>9__39_16 = val_178;
        }
        
        val_179 = 1152921517445783712;
        val_180 = null;
        val_181 = val_164.FindIndex(match:  val_34);
        val_180 = null;
        val_183 = WordAddictFTUXDemoWindow.<>c.<>9__39_17;
        if(val_183 == null)
        {
                System.Predicate<LetterTile> val_36 = null;
            val_183 = val_36;
            val_36 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_17(LetterTile x));
            WordAddictFTUXDemoWindow.<>c.<>9__39_17 = val_183;
        }
        
        val_184 = null;
        val_185 = val_164.FindIndex(match:  val_36);
        val_184 = null;
        val_187 = WordAddictFTUXDemoWindow.<>c.<>9__39_18;
        if(val_187 != null)
        {
            goto label_390;
        }
        
        System.Predicate<LetterTile> val_38 = null;
        val_187 = val_38;
        val_38 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_18(LetterTile x));
        WordAddictFTUXDemoWindow.<>c.<>9__39_18 = val_187;
        goto label_390;
        label_30:
        int val_40 = DG.Tweening.ShortcutExtensions.DOKill(target:  this.handCursor.transform, complete:  false);
        this.handCursor.gameObject.SetActive(value:  false);
        this.allowedPoints.Clear();
        this.initial = this.bottom_left;
        UnityEngine.PlayerPrefs.SetInt(key:  "t_step", value:  1);
        bool val_42 = PrefsSerializationManager.SavePlayerPrefs();
        this.CloseWindow();
        goto label_144;
        label_63:
        if(val_21 == false)
        {
            goto label_145;
        }
        
        val_188 = null;
        val_188 = null;
        val_190 = WordAddictFTUXDemoWindow.<>c.<>9__39_8;
        if(val_190 == null)
        {
                System.Predicate<LetterTile> val_43 = null;
            val_190 = val_43;
            val_43 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_8(LetterTile x));
            WordAddictFTUXDemoWindow.<>c.<>9__39_8 = val_190;
        }
        
        val_170 = 1152921517445783712;
        val_191 = null;
        val_172 = val_164.FindIndex(match:  val_43);
        val_191 = null;
        val_174 = WordAddictFTUXDemoWindow.<>c.<>9__39_9;
        if(val_174 != null)
        {
            goto label_322;
        }
        
        System.Predicate<LetterTile> val_45 = null;
        val_174 = val_45;
        val_45 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_9(LetterTile x));
        WordAddictFTUXDemoWindow.<>c.<>9__39_9 = val_174;
        goto label_322;
        label_119:
        if(val_33 == false)
        {
            goto label_158;
        }
        
        val_193 = null;
        val_193 = null;
        val_195 = WordAddictFTUXDemoWindow.<>c.<>9__39_28;
        if(val_195 == null)
        {
                System.Predicate<LetterTile> val_46 = null;
            val_195 = val_46;
            val_46 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_28(LetterTile x));
            WordAddictFTUXDemoWindow.<>c.<>9__39_28 = val_195;
        }
        
        val_179 = 1152921517445783712;
        val_196 = null;
        val_181 = val_164.FindIndex(match:  val_46);
        val_196 = null;
        val_198 = WordAddictFTUXDemoWindow.<>c.<>9__39_29;
        if(val_198 == null)
        {
                System.Predicate<LetterTile> val_48 = null;
            val_198 = val_48;
            val_48 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_29(LetterTile x));
            WordAddictFTUXDemoWindow.<>c.<>9__39_29 = val_198;
        }
        
        val_199 = null;
        val_185 = val_164.FindIndex(match:  val_48);
        val_199 = null;
        val_187 = WordAddictFTUXDemoWindow.<>c.<>9__39_30;
        if(val_187 != null)
        {
            goto label_390;
        }
        
        System.Predicate<LetterTile> val_50 = null;
        val_187 = val_50;
        val_50 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_30(LetterTile x));
        WordAddictFTUXDemoWindow.<>c.<>9__39_30 = val_187;
        goto label_390;
        label_64:
        if((System.String.op_Equality(a:  val_7, b:  "es")) == false)
        {
            goto label_176;
        }
        
        val_201 = null;
        val_201 = null;
        val_203 = WordAddictFTUXDemoWindow.<>c.<>9__39_2;
        if(val_203 == null)
        {
                System.Predicate<LetterTile> val_52 = null;
            val_203 = val_52;
            val_52 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_2(LetterTile x));
            WordAddictFTUXDemoWindow.<>c.<>9__39_2 = val_203;
        }
        
        val_170 = 1152921517445783712;
        val_204 = null;
        val_172 = val_164.FindIndex(match:  val_52);
        val_204 = null;
        val_174 = WordAddictFTUXDemoWindow.<>c.<>9__39_3;
        if(val_174 != null)
        {
            goto label_322;
        }
        
        System.Predicate<LetterTile> val_54 = null;
        val_174 = val_54;
        val_54 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_3(LetterTile x));
        WordAddictFTUXDemoWindow.<>c.<>9__39_3 = val_174;
        goto label_322;
        label_145:
        if((System.String.op_Equality(a:  val_7, b:  "es")) == false)
        {
            goto label_189;
        }
        
        val_206 = null;
        val_206 = null;
        val_208 = WordAddictFTUXDemoWindow.<>c.<>9__39_10;
        if(val_208 == null)
        {
                System.Predicate<LetterTile> val_56 = null;
            val_208 = val_56;
            val_56 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_10(LetterTile x));
            WordAddictFTUXDemoWindow.<>c.<>9__39_10 = val_208;
        }
        
        val_170 = 1152921517445783712;
        val_209 = null;
        val_172 = val_164.FindIndex(match:  val_56);
        val_209 = null;
        val_174 = WordAddictFTUXDemoWindow.<>c.<>9__39_11;
        if(val_174 != null)
        {
            goto label_322;
        }
        
        System.Predicate<LetterTile> val_58 = null;
        val_174 = val_58;
        val_58 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_11(LetterTile x));
        WordAddictFTUXDemoWindow.<>c.<>9__39_11 = val_174;
        goto label_322;
        label_120:
        if((System.String.op_Equality(a:  val_7, b:  "es")) == false)
        {
            goto label_202;
        }
        
        val_211 = null;
        val_211 = null;
        val_213 = WordAddictFTUXDemoWindow.<>c.<>9__39_19;
        if(val_213 == null)
        {
                System.Predicate<LetterTile> val_60 = null;
            val_213 = val_60;
            val_60 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_19(LetterTile x));
            WordAddictFTUXDemoWindow.<>c.<>9__39_19 = val_213;
        }
        
        val_179 = 1152921517445783712;
        val_214 = null;
        val_181 = val_164.FindIndex(match:  val_60);
        val_214 = null;
        val_216 = WordAddictFTUXDemoWindow.<>c.<>9__39_20;
        if(val_216 == null)
        {
                System.Predicate<LetterTile> val_62 = null;
            val_216 = val_62;
            val_62 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_20(LetterTile x));
            WordAddictFTUXDemoWindow.<>c.<>9__39_20 = val_216;
        }
        
        val_217 = null;
        val_185 = val_164.FindIndex(match:  val_62);
        val_217 = null;
        val_187 = WordAddictFTUXDemoWindow.<>c.<>9__39_21;
        if(val_187 != null)
        {
            goto label_390;
        }
        
        System.Predicate<LetterTile> val_64 = null;
        val_187 = val_64;
        val_64 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_21(LetterTile x));
        WordAddictFTUXDemoWindow.<>c.<>9__39_21 = val_187;
        goto label_390;
        label_158:
        if((System.String.op_Equality(a:  val_7, b:  "es")) == false)
        {
            goto label_220;
        }
        
        val_219 = null;
        val_219 = null;
        val_221 = WordAddictFTUXDemoWindow.<>c.<>9__39_31;
        if(val_221 == null)
        {
                System.Predicate<LetterTile> val_66 = null;
            val_221 = val_66;
            val_66 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_31(LetterTile x));
            WordAddictFTUXDemoWindow.<>c.<>9__39_31 = val_221;
        }
        
        val_179 = 1152921517445783712;
        val_222 = null;
        val_181 = val_164.FindIndex(match:  val_66);
        val_222 = null;
        val_224 = WordAddictFTUXDemoWindow.<>c.<>9__39_32;
        if(val_224 == null)
        {
                System.Predicate<LetterTile> val_68 = null;
            val_224 = val_68;
            val_68 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_32(LetterTile x));
            WordAddictFTUXDemoWindow.<>c.<>9__39_32 = val_224;
        }
        
        val_225 = null;
        val_185 = val_164.FindIndex(match:  val_68);
        val_225 = null;
        val_187 = WordAddictFTUXDemoWindow.<>c.<>9__39_33;
        if(val_187 != null)
        {
            goto label_390;
        }
        
        System.Predicate<LetterTile> val_70 = null;
        val_187 = val_70;
        val_70 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_33(LetterTile x));
        WordAddictFTUXDemoWindow.<>c.<>9__39_33 = val_187;
        goto label_390;
        label_176:
        if((System.String.op_Equality(a:  val_7, b:  "fr")) == false)
        {
            goto label_238;
        }
        
        val_227 = null;
        val_227 = null;
        val_229 = WordAddictFTUXDemoWindow.<>c.<>9__39_4;
        if(val_229 == null)
        {
                System.Predicate<LetterTile> val_72 = null;
            val_229 = val_72;
            val_72 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_4(LetterTile x));
            WordAddictFTUXDemoWindow.<>c.<>9__39_4 = val_229;
        }
        
        val_170 = 1152921517445783712;
        val_230 = null;
        val_172 = val_164.FindIndex(match:  val_72);
        val_230 = null;
        val_174 = WordAddictFTUXDemoWindow.<>c.<>9__39_5;
        if(val_174 != null)
        {
            goto label_322;
        }
        
        System.Predicate<LetterTile> val_74 = null;
        val_174 = val_74;
        val_74 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_5(LetterTile x));
        WordAddictFTUXDemoWindow.<>c.<>9__39_5 = val_174;
        goto label_322;
        label_189:
        if((System.String.op_Equality(a:  val_7, b:  "fr")) == false)
        {
            goto label_251;
        }
        
        val_232 = null;
        val_232 = null;
        val_234 = WordAddictFTUXDemoWindow.<>c.<>9__39_12;
        if(val_234 == null)
        {
                System.Predicate<LetterTile> val_76 = null;
            val_234 = val_76;
            val_76 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_12(LetterTile x));
            WordAddictFTUXDemoWindow.<>c.<>9__39_12 = val_234;
        }
        
        val_170 = 1152921517445783712;
        val_235 = null;
        val_172 = val_164.FindIndex(match:  val_76);
        val_235 = null;
        val_174 = WordAddictFTUXDemoWindow.<>c.<>9__39_13;
        if(val_174 != null)
        {
            goto label_322;
        }
        
        System.Predicate<LetterTile> val_78 = null;
        val_174 = val_78;
        val_78 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_13(LetterTile x));
        WordAddictFTUXDemoWindow.<>c.<>9__39_13 = val_174;
        goto label_322;
        label_202:
        if((System.String.op_Equality(a:  val_7, b:  "fr")) == false)
        {
            goto label_264;
        }
        
        val_237 = null;
        val_237 = null;
        val_239 = WordAddictFTUXDemoWindow.<>c.<>9__39_22;
        if(val_239 == null)
        {
                System.Predicate<LetterTile> val_80 = null;
            val_239 = val_80;
            val_80 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_22(LetterTile x));
            WordAddictFTUXDemoWindow.<>c.<>9__39_22 = val_239;
        }
        
        val_179 = 1152921517445783712;
        val_240 = null;
        val_181 = val_164.FindIndex(match:  val_80);
        val_240 = null;
        val_242 = WordAddictFTUXDemoWindow.<>c.<>9__39_23;
        if(val_242 == null)
        {
                System.Predicate<LetterTile> val_82 = null;
            val_242 = val_82;
            val_82 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_23(LetterTile x));
            WordAddictFTUXDemoWindow.<>c.<>9__39_23 = val_242;
        }
        
        val_243 = null;
        val_185 = val_164.FindIndex(match:  val_82);
        val_243 = null;
        val_187 = WordAddictFTUXDemoWindow.<>c.<>9__39_24;
        if(val_187 != null)
        {
            goto label_390;
        }
        
        System.Predicate<LetterTile> val_84 = null;
        val_187 = val_84;
        val_84 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_24(LetterTile x));
        WordAddictFTUXDemoWindow.<>c.<>9__39_24 = val_187;
        goto label_390;
        label_220:
        if((System.String.op_Equality(a:  val_7, b:  "fr")) == false)
        {
            goto label_282;
        }
        
        val_245 = null;
        val_245 = null;
        val_247 = WordAddictFTUXDemoWindow.<>c.<>9__39_34;
        if(val_247 == null)
        {
                System.Predicate<LetterTile> val_86 = null;
            val_247 = val_86;
            val_86 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_34(LetterTile x));
            WordAddictFTUXDemoWindow.<>c.<>9__39_34 = val_247;
        }
        
        val_179 = 1152921517445783712;
        val_248 = null;
        val_181 = val_164.FindIndex(match:  val_86);
        val_248 = null;
        val_250 = WordAddictFTUXDemoWindow.<>c.<>9__39_35;
        if(val_250 == null)
        {
                System.Predicate<LetterTile> val_88 = null;
            val_250 = val_88;
            val_88 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_35(LetterTile x));
            WordAddictFTUXDemoWindow.<>c.<>9__39_35 = val_250;
        }
        
        val_251 = null;
        val_185 = val_164.FindIndex(match:  val_88);
        val_251 = null;
        val_187 = WordAddictFTUXDemoWindow.<>c.<>9__39_36;
        if(val_187 != null)
        {
            goto label_390;
        }
        
        System.Predicate<LetterTile> val_90 = null;
        val_187 = val_90;
        val_90 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_36(LetterTile x));
        WordAddictFTUXDemoWindow.<>c.<>9__39_36 = val_187;
        goto label_390;
        label_238:
        if((System.String.op_Equality(a:  val_7, b:  "de")) == false)
        {
            goto label_475;
        }
        
        val_253 = null;
        val_253 = null;
        val_255 = WordAddictFTUXDemoWindow.<>c.<>9__39_6;
        if(val_255 == null)
        {
                System.Predicate<LetterTile> val_92 = null;
            val_255 = val_92;
            val_92 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_6(LetterTile x));
            WordAddictFTUXDemoWindow.<>c.<>9__39_6 = val_255;
        }
        
        val_170 = 1152921517445783712;
        val_256 = null;
        val_172 = val_164.FindIndex(match:  val_92);
        val_256 = null;
        val_174 = WordAddictFTUXDemoWindow.<>c.<>9__39_7;
        if(val_174 != null)
        {
            goto label_322;
        }
        
        System.Predicate<LetterTile> val_94 = null;
        val_174 = val_94;
        val_94 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_7(LetterTile x));
        WordAddictFTUXDemoWindow.<>c.<>9__39_7 = val_174;
        goto label_322;
        label_251:
        if((System.String.op_Equality(a:  val_7, b:  "de")) == false)
        {
            goto label_475;
        }
        
        val_258 = null;
        val_258 = null;
        val_260 = WordAddictFTUXDemoWindow.<>c.<>9__39_14;
        if(val_260 == null)
        {
                System.Predicate<LetterTile> val_96 = null;
            val_260 = val_96;
            val_96 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_14(LetterTile x));
            WordAddictFTUXDemoWindow.<>c.<>9__39_14 = val_260;
        }
        
        val_170 = 1152921517445783712;
        val_261 = null;
        val_172 = val_164.FindIndex(match:  val_96);
        val_261 = null;
        val_174 = WordAddictFTUXDemoWindow.<>c.<>9__39_15;
        if(val_174 == null)
        {
                System.Predicate<LetterTile> val_98 = null;
            val_174 = val_98;
            val_98 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_15(LetterTile x));
            WordAddictFTUXDemoWindow.<>c.<>9__39_15 = val_174;
        }
        
        label_322:
        val_162 = val_164.FindIndex(match:  val_98);
        label_475:
        UnityEngine.Transform[] val_100 = new UnityEngine.Transform[3];
        if((Pan.tappingAllowed + 88 + 24) <= val_172)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_160 = Pan.tappingAllowed + 88 + 16;
        val_160 = val_160 + (val_172 << 3);
        val_100[0] = (Pan.tappingAllowed + 88 + 16 + (val_97) << 3) + 32.transform;
        if((Pan.tappingAllowed + 88 + 24) <= val_162)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_161 = Pan.tappingAllowed + 88 + 16;
        val_161 = val_161 + (val_162 << 3);
        val_263 = val_100.Length;
        val_100[1] = (Pan.tappingAllowed + 88 + 16 + (val_99) << 3) + 32.transform;
        if(this != null)
        {
                val_263 = val_100.Length;
        }
        
        val_100[2] = this;
        val_5.ShowOverlay(contentToOverlay:  val_100);
        if((Pan.tappingAllowed + 88 + 24) <= val_172)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_162 = Pan.tappingAllowed + 88 + 16;
        val_162 = val_162 + (((long)(int)(val_97)) << 3);
        UnityEngine.Vector3 val_104 = (Pan.tappingAllowed + 88 + 16 + ((long)(int)(val_97)) << 3) + 32.transform.position;
        val_165 = val_104.x;
        if((Pan.tappingAllowed + 88 + 24) <= val_162)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_163 = Pan.tappingAllowed + 88 + 16;
        val_163 = val_163 + (((long)(int)(val_99)) << 3);
        UnityEngine.Vector3 val_106 = (Pan.tappingAllowed + 88 + 16 + ((long)(int)(val_99)) << 3) + 32.transform.position;
        UnityEngine.Vector3 val_107 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_165, y = val_104.y, z = val_104.z}, b:  new UnityEngine.Vector3() {x = val_106.x, y = val_106.y, z = val_106.z});
        UnityEngine.Vector3 val_108 = UnityEngine.Vector3.op_Division(a:  new UnityEngine.Vector3() {x = val_107.x, y = val_107.y, z = val_107.z}, d:  2f);
        this.position = new UnityEngine.Vector3() {x = val_108.x, y = val_108.y, z = val_108.z};
        this.gameObject.SetActive(value:  true);
        System.Collections.Generic.List<UnityEngine.Transform> val_110 = new System.Collections.Generic.List<UnityEngine.Transform>();
        if((Pan.tappingAllowed + 88 + 24) <= val_162)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_164 = Pan.tappingAllowed + 88 + 16;
        val_164 = val_164 + (((long)(int)(val_99)) << 3);
        val_110.Add(item:  (Pan.tappingAllowed + 88 + 16 + ((long)(int)(val_99)) << 3) + 32.transform);
        this.allowedPoints = val_110;
        if((Pan.tappingAllowed + 88 + 24) <= val_172)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_165 = Pan.tappingAllowed + 88 + 16;
        val_165 = val_165 + (((long)(int)(val_97)) << 3);
        this.initial = (Pan.tappingAllowed + 88 + 16 + ((long)(int)(val_97)) << 3) + 32.transform;
        val_164 = new UnityEngine.Transform[1];
        UnityEngine.Transform val_114 = this.handCursor.transform;
        val_160 = 1152921504765632512;
        val_161 = 1152921504893161472;
        val_163 = 1152921513393576032;
        if(val_164 != null)
        {
            goto label_356;
        }
        
        label_264:
        if((System.String.op_Equality(a:  val_7, b:  "de")) == false)
        {
            goto label_476;
        }
        
        val_265 = null;
        val_265 = null;
        val_267 = WordAddictFTUXDemoWindow.<>c.<>9__39_25;
        if(val_267 == null)
        {
                System.Predicate<LetterTile> val_116 = null;
            val_267 = val_116;
            val_116 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_25(LetterTile x));
            WordAddictFTUXDemoWindow.<>c.<>9__39_25 = val_267;
        }
        
        val_179 = 1152921517445783712;
        val_268 = null;
        val_181 = val_164.FindIndex(match:  val_116);
        val_268 = null;
        val_270 = WordAddictFTUXDemoWindow.<>c.<>9__39_26;
        if(val_270 == null)
        {
                System.Predicate<LetterTile> val_118 = null;
            val_270 = val_118;
            val_118 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_26(LetterTile x));
            WordAddictFTUXDemoWindow.<>c.<>9__39_26 = val_270;
        }
        
        val_271 = null;
        val_185 = val_164.FindIndex(match:  val_118);
        val_271 = null;
        val_187 = WordAddictFTUXDemoWindow.<>c.<>9__39_27;
        if(val_187 != null)
        {
            goto label_390;
        }
        
        System.Predicate<LetterTile> val_120 = null;
        val_187 = val_120;
        val_120 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_27(LetterTile x));
        WordAddictFTUXDemoWindow.<>c.<>9__39_27 = val_187;
        goto label_390;
        label_282:
        if((System.String.op_Equality(a:  val_7, b:  "de")) == false)
        {
            goto label_476;
        }
        
        val_273 = null;
        val_273 = null;
        val_275 = WordAddictFTUXDemoWindow.<>c.<>9__39_37;
        if(val_275 == null)
        {
                System.Predicate<LetterTile> val_122 = null;
            val_275 = val_122;
            val_122 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_37(LetterTile x));
            WordAddictFTUXDemoWindow.<>c.<>9__39_37 = val_275;
        }
        
        val_179 = 1152921517445783712;
        val_276 = null;
        val_181 = val_164.FindIndex(match:  val_122);
        val_276 = null;
        val_278 = WordAddictFTUXDemoWindow.<>c.<>9__39_38;
        if(val_278 == null)
        {
                System.Predicate<LetterTile> val_124 = null;
            val_278 = val_124;
            val_124 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_38(LetterTile x));
            WordAddictFTUXDemoWindow.<>c.<>9__39_38 = val_278;
        }
        
        val_279 = null;
        val_185 = val_164.FindIndex(match:  val_124);
        val_279 = null;
        val_187 = WordAddictFTUXDemoWindow.<>c.<>9__39_39;
        if(val_187 == null)
        {
                System.Predicate<LetterTile> val_126 = null;
            val_187 = val_126;
            val_126 = new System.Predicate<LetterTile>(object:  WordAddictFTUXDemoWindow.<>c.__il2cppRuntimeField_static_fields, method:  System.Boolean WordAddictFTUXDemoWindow.<>c::<Progress>b__39_39(LetterTile x));
            WordAddictFTUXDemoWindow.<>c.<>9__39_39 = val_187;
        }
        
        label_390:
        int val_127 = val_164.FindIndex(match:  val_126);
        label_476:
        UnityEngine.Transform[] val_128 = new UnityEngine.Transform[4];
        if((Pan.tappingAllowed + 88 + 24) <= val_181)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_166 = Pan.tappingAllowed + 88 + 16;
        val_166 = val_166 + (val_181 << 3);
        val_128[0] = (Pan.tappingAllowed + 88 + 16 + (val_123) << 3) + 32.transform;
        if((Pan.tappingAllowed + 88 + 24) <= val_185)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_167 = Pan.tappingAllowed + 88 + 16;
        val_167 = val_167 + (val_185 << 3);
        val_128[1] = (Pan.tappingAllowed + 88 + 16 + (val_125) << 3) + 32.transform;
        if((Pan.tappingAllowed + 88 + 24) <= val_127)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_168 = Pan.tappingAllowed + 88 + 16;
        val_168 = val_168 + (val_127 << 3);
        val_281 = val_128.Length;
        val_128[2] = (Pan.tappingAllowed + 88 + 16 + (val_127) << 3) + 32.transform;
        if(this != null)
        {
                val_281 = val_128.Length;
        }
        
        val_128[3] = this;
        val_5.ShowOverlay(contentToOverlay:  val_128);
        if((Pan.tappingAllowed + 88 + 24) <= val_185)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_169 = Pan.tappingAllowed + 88 + 16;
        val_169 = val_169 + (((long)(int)(val_125)) << 3);
        UnityEngine.Vector3 val_133 = (Pan.tappingAllowed + 88 + 16 + ((long)(int)(val_125)) << 3) + 32.transform.position;
        this.position = new UnityEngine.Vector3() {x = val_133.x, y = val_133.y, z = val_133.z};
        this.gameObject.SetActive(value:  true);
        GameBehavior val_135 = App.getBehavior;
        System.Collections.Generic.List<UnityEngine.Transform> val_136 = new System.Collections.Generic.List<UnityEngine.Transform>();
        if((Pan.tappingAllowed + 88 + 24) <= val_185)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_170 = Pan.tappingAllowed + 88 + 16;
        val_170 = val_170 + (((long)(int)(val_125)) << 3);
        val_162 = (long)val_181;
        val_136.Add(item:  (Pan.tappingAllowed + 88 + 16 + ((long)(int)(val_125)) << 3) + 32.transform);
        if((val_135.<metaGameBehavior>k__BackingField) != 1)
        {
            goto label_425;
        }
        
        if((Pan.tappingAllowed + 88 + 24) <= val_181)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_171 = Pan.tappingAllowed + 88 + 16;
        val_171 = val_171 + (((long)(int)(val_123)) << 3);
        val_136.Add(item:  (Pan.tappingAllowed + 88 + 16 + ((long)(int)(val_123)) << 3) + 32.transform);
        this.allowedPoints = val_136;
        if((Pan.tappingAllowed + 88 + 24) <= val_127)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_172 = Pan.tappingAllowed + 88 + 16;
        val_172 = val_172 + (((long)(int)(val_127)) << 3);
        val_160 = 1152921504765632512;
        val_161 = 1152921504893161472;
        val_163 = 1152921513393576032;
        if(((Pan.tappingAllowed + 88 + 16 + ((long)(int)(val_127)) << 3) + 32) != 0)
        {
            goto label_429;
        }
        
        label_425:
        if((Pan.tappingAllowed + 88 + 24) <= val_127)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_173 = Pan.tappingAllowed + 88 + 16;
        val_173 = val_173 + (((long)(int)(val_127)) << 3);
        val_136.Add(item:  (Pan.tappingAllowed + 88 + 16 + ((long)(int)(val_127)) << 3) + 32.transform);
        this.allowedPoints = val_136;
        val_160 = 1152921504765632512;
        val_161 = 1152921504893161472;
        val_163 = 1152921513393576032;
        if((Pan.tappingAllowed + 88 + 24) <= val_181)
        {
                System.ThrowHelper.ThrowArgumentOutOfRangeException();
        }
        
        var val_174 = Pan.tappingAllowed + 88 + 16;
        val_174 = val_174 + (((long)(int)(val_123)) << 3);
        label_429:
        this.initial = (Pan.tappingAllowed + 88 + 16 + ((long)(int)(val_123)) << 3) + 32.transform;
        UnityEngine.Transform[] val_141 = new UnityEngine.Transform[1];
        val_164 = val_141;
        label_356:
        val_164[0] = this.handCursor.transform;
        val_5.ShowOverlay(contentToOverlay:  val_141);
        label_144:
        int val_175 = this.state;
        val_175 = val_175 - 1;
        if(val_175 > 1)
        {
                return;
        }
        
        MonoSingleton<GameMaskOverlay>.Instance.BlockRaycasts = false;
        if(this.SkipTutorialBtn.activeSelf == false)
        {
            goto label_445;
        }
        
        if(this.dummySkipButton != 0)
        {
            goto label_448;
        }
        
        UnityEngine.GameObject val_148 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.SkipTutorialBtn, parent:  this.gameObject.transform);
        this.dummySkipButton = val_148;
        if(val_148 != null)
        {
            goto label_452;
        }
        
        return;
        label_448:
        label_452:
        UnityEngine.Vector3 val_151 = this.SkipTutorialBtn.transform.position;
        this.dummySkipButton.transform.position = new UnityEngine.Vector3() {x = val_151.x, y = val_151.y, z = val_151.z};
        UnityEngine.UI.Button val_153 = this.dummySkipButton.GetComponent<UnityEngine.UI.Button>();
        this.SkipTutorialBtn.GetComponent<UnityEngine.UI.Button>().targetGraphic = public UnityEngine.UI.Button UnityEngine.GameObject::GetComponent<UnityEngine.UI.Button>();
        if((val_152.m_OnClick.GetPersistentTarget(index:  0)) == 0)
        {
                val_152.m_OnClick.AddListener(call:  new UnityEngine.Events.UnityAction(object:  this, method:  public System.Void WordAddictFTUXDemoWindow::OnSkipTutorialClick()));
        }
        
        UnityEngine.Transform[] val_158 = new UnityEngine.Transform[1];
        val_164 = val_158;
        val_164[0] = this.dummySkipButton.transform;
        MonoSingleton<GameMaskOverlay>.Instance.ShowOverlay(contentToOverlay:  val_158);
        label_445:
        this.AnimateCursor();
    }
    protected void CloseWindow()
    {
        MonoSingleton<GameMaskOverlay>.Instance.CloseOverlay(forceImmediate:  true, onClosed:  new System.Action(object:  this, method:  System.Void WordAddictFTUXDemoWindow::OnOverlayClosed()));
        SLCWindow.CloseWindow(window:  this.gameObject, setDestroyOnDisableState:  false, dontDestroyOnDisable:  false);
    }
    protected void AnimateCursor()
    {
        var val_20;
        var val_21;
        var val_37;
        var val_38;
        this.handCursor.gameObject.SetActive(value:  true);
        int val_3 = DG.Tweening.ShortcutExtensions.DOKill(target:  this.handCursor.transform, complete:  false);
        UnityEngine.Color val_4 = UnityEngine.Color.white;
        this.handCursor.color = new UnityEngine.Color() {r = val_4.r, g = val_4.g, b = val_4.b, a = val_4.a};
        UnityEngine.Rect val_7 = this.handCursor.rectTransform.rect;
        float val_37 = -0.5f;
        val_37 = val_7.m_XMin.height * val_37;
        UnityEngine.Vector3 val_9 = new UnityEngine.Vector3(x:  0f, y:  val_37, z:  0f);
        UnityEngine.Vector3 val_10 = this.handCursor.rectTransform.TransformPoint(position:  new UnityEngine.Vector3() {x = val_9.x, y = val_9.y, z = val_9.z});
        UnityEngine.Vector3 val_12 = this.handCursor.rectTransform.position;
        UnityEngine.Vector3 val_13 = UnityEngine.Vector3.op_Subtraction(a:  new UnityEngine.Vector3() {x = val_10.x, y = val_10.y, z = val_10.z}, b:  new UnityEngine.Vector3() {x = val_12.x, y = val_12.y, z = val_12.z});
        UnityEngine.Vector3 val_16 = this.initial.position;
        UnityEngine.Vector3 val_17 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_16.x, y = val_16.y, z = val_16.z}, b:  new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z});
        this.handCursor.gameObject.transform.position = new UnityEngine.Vector3() {x = val_17.x, y = val_17.y, z = val_17.z};
        System.Collections.Generic.List<UnityEngine.Vector3> val_18 = new System.Collections.Generic.List<UnityEngine.Vector3>();
        List.Enumerator<T> val_19 = this.allowedPoints.GetEnumerator();
        label_23:
        val_37 = public System.Boolean List.Enumerator<UnityEngine.Transform>::MoveNext();
        if(val_21.MoveNext() == false)
        {
            goto label_18;
        }
        
        val_38 = val_20;
        if(val_38 == 0)
        {
                throw new NullReferenceException();
        }
        
        val_37 = 0;
        UnityEngine.Vector3 val_23 = val_38.position;
        val_38 = 0;
        UnityEngine.Vector3 val_24 = UnityEngine.Vector3.op_Addition(a:  new UnityEngine.Vector3() {x = val_23.x, y = val_23.y, z = val_23.z}, b:  new UnityEngine.Vector3() {x = val_13.x, y = val_13.y, z = val_13.z});
        if(val_18 == null)
        {
                throw new NullReferenceException();
        }
        
        val_18.Add(item:  new UnityEngine.Vector3() {x = val_24.x, y = val_24.y, z = val_24.z});
        goto label_23;
        label_18:
        val_21.Dispose();
        DG.Tweening.Sequence val_26 = DG.Tweening.DOTween.Sequence();
        this.cursorSeq = val_26;
        DG.Tweening.Sequence val_27 = DG.Tweening.TweenSettingsExtensions.SetAutoKill<DG.Tweening.Sequence>(t:  val_26, autoKillOnCompletion:  true);
        DG.Tweening.Sequence val_28 = DG.Tweening.TweenSettingsExtensions.PrependInterval(s:  this.cursorSeq, interval:  0.25f);
        DG.Tweening.Sequence val_32 = DG.Tweening.TweenSettingsExtensions.Append(s:  this.cursorSeq, t:  DG.Tweening.TweenSettingsExtensions.SetEase<DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, DG.Tweening.Plugins.Core.PathCore.Path, DG.Tweening.Plugins.Options.PathOptions>>(t:  DG.Tweening.ShortcutExtensions.DOPath(target:  this.handCursor.transform, path:  val_18.ToArray(), duration:  (float)val_25.Length, pathType:  0, pathMode:  1, resolution:  10, gizmoColor:  new System.Nullable<UnityEngine.Color>() {HasValue = true}), ease:  1));
        DG.Tweening.Sequence val_34 = DG.Tweening.TweenSettingsExtensions.Append(s:  this.cursorSeq, t:  DG.Tweening.ShortcutExtensions46.DOFade(target:  this.handCursor, endValue:  0f, duration:  0.75f));
        DG.Tweening.Sequence val_36 = DG.Tweening.TweenSettingsExtensions.OnComplete<DG.Tweening.Sequence>(t:  this.cursorSeq, action:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WordAddictFTUXDemoWindow::OnCompleteCycle()));
    }
    private void OnCompleteCycle()
    {
        if(this.gameObject.activeSelf != false)
        {
                this.AnimateCursor();
            return;
        }
        
        this.StopAllCoroutines();
    }
    public void OnSkipTutorialClick()
    {
        MonoSingleton<WGFTUXManager>.Instance.SkipTutorial();
        this.CloseWindow();
    }
    private void OnOverlayClosed()
    {
        this.SkipTutorialBtn.SetActive(value:  false);
        if(this.dummySkipButton == 0)
        {
                return;
        }
        
        UnityEngine.Object.Destroy(obj:  this.dummySkipButton);
    }
    protected virtual UnityEngine.RectTransform GetMaskWordRegion(int stepNum)
    {
        UnityEngine.RectTransform val_1;
        if(stepNum == 2)
        {
            goto label_0;
        }
        
        if(stepNum != 1)
        {
            goto label_1;
        }
        
        label_5:
        val_1 = this.maskActionStep1[0];
        return (UnityEngine.RectTransform)val_1;
        label_0:
        if(this.maskActionStep2 != null)
        {
            goto label_5;
        }
        
        throw new NullReferenceException();
        label_1:
        val_1 = 0;
        return (UnityEngine.RectTransform)val_1;
    }
    protected virtual UnityEngine.RectTransform GetMaskPan(int stepNum)
    {
        UnityEngine.RectTransform val_1;
        if(stepNum == 2)
        {
            goto label_0;
        }
        
        if(stepNum != 1)
        {
            goto label_1;
        }
        
        label_5:
        val_1 = this.maskActionStep1[1];
        return (UnityEngine.RectTransform)val_1;
        label_0:
        if(this.maskActionStep2 != null)
        {
            goto label_5;
        }
        
        throw new NullReferenceException();
        label_1:
        val_1 = 0;
        return (UnityEngine.RectTransform)val_1;
    }
    protected virtual UnityEngine.Vector3 GetWordRegionPosStep1(UnityEngine.Transform letterSlot1, UnityEngine.Transform letterSlot2)
    {
        UnityEngine.Vector3 val_1 = letterSlot1.position;
        UnityEngine.Vector3 val_2 = letterSlot2.position;
        UnityEngine.Vector3 val_3 = letterSlot1.position;
        UnityEngine.Vector3 val_4 = letterSlot1.position;
        float val_5 = val_1.x + val_2.x;
        val_5 = val_5 * 0.5f;
        UnityEngine.Vector3 val_6 = new UnityEngine.Vector3(x:  val_5, y:  val_3.y, z:  val_4.z);
        return new UnityEngine.Vector3() {x = val_6.x, y = val_6.y, z = val_6.z};
    }
    protected virtual UnityEngine.Vector2 GetWordRegionSizeStep1(float cellSize)
    {
        int val_5 = this.padding;
        val_5 = val_5 << 1;
        float val_6 = (float)val_5 << 2;
        val_6 = (cellSize + cellSize) + val_6;
        UnityEngine.Vector2 val_4 = new UnityEngine.Vector2(x:  val_6, y:  (float)val_5 + cellSize);
        return new UnityEngine.Vector2() {x = val_4.x, y = val_4.y};
    }
    protected virtual UnityEngine.Vector2 GetWordRegionSizeStep2(float cellSize)
    {
        int val_5 = this.padding;
        float val_4 = 3f;
        val_4 = cellSize * val_4;
        int val_1 = val_5 + (val_5 << 1);
        val_1 = val_1 << 1;
        val_5 = val_5 << 1;
        float val_6 = (float)val_1;
        val_6 = val_4 + val_6;
        UnityEngine.Vector2 val_3 = new UnityEngine.Vector2(x:  val_6, y:  (float)val_5 + cellSize);
        return new UnityEngine.Vector2() {x = val_3.x, y = val_3.y};
    }
    public WordAddictFTUXDemoWindow()
    {
        this.padding = 10;
        this.allowedPoints = new System.Collections.Generic.List<UnityEngine.Transform>();
        this.state = 1;
        this.currentLanguage = "en";
    }

}
