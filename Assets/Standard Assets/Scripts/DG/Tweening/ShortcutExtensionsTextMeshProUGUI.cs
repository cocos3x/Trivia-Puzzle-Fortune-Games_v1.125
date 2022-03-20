using UnityEngine;

namespace DG.Tweening
{
    public static class ShortcutExtensionsTextMeshProUGUI
    {
        // Methods
        public static DG.Tweening.Tweener DOColor(TMPro.TextMeshProUGUI target, UnityEngine.Color endValue, float duration)
        {
            ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass0_0 val_1 = new ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass0_0();
            .target = target;
            return DG.Tweening.TweenSettingsExtensions.SetTarget<DG.Tweening.Core.TweenerCore<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>>(t:  DG.Tweening.DOTween.To(getter:  new DG.Tweening.Core.DOGetter<UnityEngine.Color>(object:  val_1, method:  UnityEngine.Color ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass0_0::<DOColor>b__0()), setter:  new DG.Tweening.Core.DOSetter<UnityEngine.Color>(object:  val_1, method:  System.Void ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass0_0::<DOColor>b__1(UnityEngine.Color x)), endValue:  new UnityEngine.Color() {r = endValue.r, g = endValue.g, b = endValue.b, a = endValue.a}, duration:  duration), target:  (ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass0_0)[1152921513380287744].target);
        }
        public static DG.Tweening.Tweener DOFaceColor(TMPro.TextMeshProUGUI target, UnityEngine.Color32 endValue, float duration)
        {
            ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass1_0 val_1 = new ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass1_0();
            .target = target;
            UnityEngine.Color val_5 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color32() {r = endValue.r & 4294967295, g = endValue.r & 4294967295, b = endValue.r & 4294967295, a = endValue.r & 4294967295});
            return DG.Tweening.TweenSettingsExtensions.SetTarget<DG.Tweening.Core.TweenerCore<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>>(t:  DG.Tweening.DOTween.To(getter:  new DG.Tweening.Core.DOGetter<UnityEngine.Color>(object:  val_1, method:  UnityEngine.Color ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass1_0::<DOFaceColor>b__0()), setter:  new DG.Tweening.Core.DOSetter<UnityEngine.Color>(object:  val_1, method:  System.Void ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass1_0::<DOFaceColor>b__1(UnityEngine.Color x)), endValue:  new UnityEngine.Color() {r = val_5.r, g = val_5.g, b = val_5.b, a = val_5.a}, duration:  duration), target:  (ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass1_0)[1152921513380450944].target);
        }
        public static DG.Tweening.Tweener DOOutlineColor(TMPro.TextMeshProUGUI target, UnityEngine.Color32 endValue, float duration)
        {
            ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass2_0 val_1 = new ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass2_0();
            .target = target;
            UnityEngine.Color val_5 = UnityEngine.Color32.op_Implicit(c:  new UnityEngine.Color32() {r = endValue.r & 4294967295, g = endValue.r & 4294967295, b = endValue.r & 4294967295, a = endValue.r & 4294967295});
            return DG.Tweening.TweenSettingsExtensions.SetTarget<DG.Tweening.Core.TweenerCore<UnityEngine.Color, UnityEngine.Color, DG.Tweening.Plugins.Options.ColorOptions>>(t:  DG.Tweening.DOTween.To(getter:  new DG.Tweening.Core.DOGetter<UnityEngine.Color>(object:  val_1, method:  UnityEngine.Color ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass2_0::<DOOutlineColor>b__0()), setter:  new DG.Tweening.Core.DOSetter<UnityEngine.Color>(object:  val_1, method:  System.Void ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass2_0::<DOOutlineColor>b__1(UnityEngine.Color x)), endValue:  new UnityEngine.Color() {r = val_5.r, g = val_5.g, b = val_5.b, a = val_5.a}, duration:  duration), target:  (ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass2_0)[1152921513380614144].target);
        }
        public static DG.Tweening.Tweener DOGlowColor(TMPro.TextMeshProUGUI target, UnityEngine.Color endValue, float duration, bool useSharedMaterial = False)
        {
            if(useSharedMaterial != false)
            {
                    UnityEngine.Material val_1 = target.fontSharedMaterial;
                return DG.Tweening.TweenSettingsExtensions.SetTarget<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOColor(target:  target.fontMaterial, endValue:  new UnityEngine.Color() {r = endValue.r, g = endValue.g, b = endValue.b, a = endValue.a}, property:  "_GlowColor", duration:  duration), target:  target);
            }
            
            return DG.Tweening.TweenSettingsExtensions.SetTarget<DG.Tweening.Tweener>(t:  DG.Tweening.ShortcutExtensions.DOColor(target:  target.fontMaterial, endValue:  new UnityEngine.Color() {r = endValue.r, g = endValue.g, b = endValue.b, a = endValue.a}, property:  "_GlowColor", duration:  duration), target:  target);
        }
        public static DG.Tweening.Tweener DOFade(TMPro.TextMeshProUGUI target, float endValue, float duration)
        {
            ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass4_0 val_1 = new ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass4_0();
            .target = target;
            return DG.Tweening.TweenSettingsExtensions.SetTarget<DG.Tweening.Tweener>(t:  DG.Tweening.DOTween.ToAlpha(getter:  new DG.Tweening.Core.DOGetter<UnityEngine.Color>(object:  val_1, method:  UnityEngine.Color ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass4_0::<DOFade>b__0()), setter:  new DG.Tweening.Core.DOSetter<UnityEngine.Color>(object:  val_1, method:  System.Void ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass4_0::<DOFade>b__1(UnityEngine.Color x)), endValue:  endValue, duration:  duration), target:  (ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass4_0)[1152921513380922112].target);
        }
        public static DG.Tweening.Tweener DOFaceFade(TMPro.TextMeshProUGUI target, float endValue, float duration)
        {
            ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass5_0 val_1 = new ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass5_0();
            .target = target;
            return DG.Tweening.TweenSettingsExtensions.SetTarget<DG.Tweening.Tweener>(t:  DG.Tweening.DOTween.ToAlpha(getter:  new DG.Tweening.Core.DOGetter<UnityEngine.Color>(object:  val_1, method:  UnityEngine.Color ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass5_0::<DOFaceFade>b__0()), setter:  new DG.Tweening.Core.DOSetter<UnityEngine.Color>(object:  val_1, method:  System.Void ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass5_0::<DOFaceFade>b__1(UnityEngine.Color x)), endValue:  endValue, duration:  duration), target:  (ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass5_0)[1152921513381085312].target);
        }
        public static DG.Tweening.Tweener DOScale(TMPro.TextMeshProUGUI target, float endValue, float duration)
        {
            ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass6_0 val_1 = new ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass6_0();
            .t = target.transform;
            UnityEngine.Vector3 val_3 = new UnityEngine.Vector3(x:  endValue, y:  endValue, z:  endValue);
            return (DG.Tweening.Tweener)DG.Tweening.TweenSettingsExtensions.SetTarget<DG.Tweening.Core.TweenerCore<UnityEngine.Vector3, UnityEngine.Vector3, DG.Tweening.Plugins.Options.VectorOptions>>(t:  DG.Tweening.DOTween.To(getter:  new DG.Tweening.Core.DOGetter<UnityEngine.Vector3>(object:  val_1, method:  UnityEngine.Vector3 ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass6_0::<DOScale>b__0()), setter:  new DG.Tweening.Core.DOSetter<UnityEngine.Vector3>(object:  val_1, method:  System.Void ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass6_0::<DOScale>b__1(UnityEngine.Vector3 x)), endValue:  new UnityEngine.Vector3() {x = val_3.x, y = val_3.y, z = val_3.z}, duration:  duration), target:  target);
        }
        public static DG.Tweening.Tweener DOFontSize(TMPro.TextMeshProUGUI target, float endValue, float duration)
        {
            ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass7_0 val_1 = new ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass7_0();
            .target = target;
            return DG.Tweening.TweenSettingsExtensions.SetTarget<DG.Tweening.Core.TweenerCore<System.Single, System.Single, DG.Tweening.Plugins.Options.FloatOptions>>(t:  DG.Tweening.DOTween.To(getter:  new DG.Tweening.Core.DOGetter<System.Single>(object:  val_1, method:  System.Single ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass7_0::<DOFontSize>b__0()), setter:  new DG.Tweening.Core.DOSetter<System.Single>(object:  val_1, method:  System.Void ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass7_0::<DOFontSize>b__1(float x)), endValue:  endValue, duration:  duration), target:  (ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass7_0)[1152921513381419904].target);
        }
        public static DG.Tweening.Tweener DOMaxVisibleCharacters(TMPro.TextMeshProUGUI target, int endValue, float duration)
        {
            ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass8_0 val_1 = new ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass8_0();
            .target = target;
            return DG.Tweening.TweenSettingsExtensions.SetTarget<DG.Tweening.Tweener>(t:  DG.Tweening.DOTween.To(getter:  new DG.Tweening.Core.DOGetter<System.Int32>(object:  val_1, method:  System.Int32 ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass8_0::<DOMaxVisibleCharacters>b__0()), setter:  new DG.Tweening.Core.DOSetter<System.Int32>(object:  val_1, method:  System.Void ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass8_0::<DOMaxVisibleCharacters>b__1(int x)), endValue:  endValue, duration:  duration), target:  (ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass8_0)[1152921513381583104].target);
        }
        public static DG.Tweening.Tweener DOText(TMPro.TextMeshProUGUI target, string endValue, float duration, bool richTextEnabled = True, DG.Tweening.ScrambleMode scrambleMode = 0, string scrambleChars)
        {
            ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass9_0 val_1 = new ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass9_0();
            .target = target;
            return DG.Tweening.TweenSettingsExtensions.SetTarget<DG.Tweening.Tweener>(t:  DG.Tweening.TweenSettingsExtensions.SetOptions(t:  DG.Tweening.DOTween.To(getter:  new DG.Tweening.Core.DOGetter<System.String>(object:  val_1, method:  System.String ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass9_0::<DOText>b__0()), setter:  new DG.Tweening.Core.DOSetter<System.String>(object:  val_1, method:  System.Void ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass9_0::<DOText>b__1(string x)), endValue:  endValue, duration:  duration), richTextEnabled:  richTextEnabled, scrambleMode:  scrambleMode, scrambleChars:  scrambleChars), target:  (ShortcutExtensionsTextMeshProUGUI.<>c__DisplayClass9_0)[1152921513381774976].target);
        }
    
    }

}
