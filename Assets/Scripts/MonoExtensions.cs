using UnityEngine;
public static class MonoExtensions
{
    // Methods
    public static void ResetLocal(UnityEngine.Transform trans)
    {
        UnityEngine.Vector3 val_1 = UnityEngine.Vector3.zero;
        trans.localPosition = new UnityEngine.Vector3() {x = val_1.x, y = val_1.y, z = val_1.z};
        UnityEngine.Vector3 val_2 = UnityEngine.Vector3.one;
        trans.localScale = new UnityEngine.Vector3() {x = val_2.x, y = val_2.y, z = val_2.z};
        UnityEngine.Quaternion val_3 = UnityEngine.Quaternion.identity;
        trans.localRotation = new UnityEngine.Quaternion() {x = val_3.x, y = val_3.y, z = val_3.z, w = val_3.w};
    }
    public static void DelayedCallEndOfFrame(UnityEngine.MonoBehaviour monoBehaviour, System.Action callback, int count = 1)
    {
        UnityEngine.Coroutine val_2 = monoBehaviour.StartCoroutine(routine:  MonoExtensions.DelayedCallEndOfFrameCoroutine(callback:  callback, count:  count));
    }
    private static System.Collections.IEnumerator DelayedCallEndOfFrameCoroutine(System.Action callback, int count = 1)
    {
        .<>1__state = 0;
        .callback = callback;
        .count = count;
        return (System.Collections.IEnumerator)new MonoExtensions.<DelayedCallEndOfFrameCoroutine>d__2();
    }
    public static void ScrollToTop(UnityEngine.UI.ScrollRect scrollRect)
    {
        UnityEngine.Vector2 val_1 = new UnityEngine.Vector2(x:  0f, y:  1f);
        scrollRect.normalizedPosition = new UnityEngine.Vector2() {x = val_1.x, y = val_1.y};
    }
    public static void ScrollToBottom(UnityEngine.UI.ScrollRect scrollRect)
    {
        UnityEngine.Vector2 val_1 = new UnityEngine.Vector2(x:  0f, y:  0f);
        scrollRect.normalizedPosition = new UnityEngine.Vector2() {x = val_1.x, y = val_1.y};
    }
    public static void SetUIAnchor_WRONGLY(UnityEngine.RectTransform rect, Anchor anchor)
    {
        if((anchor - 1) > 8)
        {
                return;
        }
        
        var val_20 = 32498712 + ((anchor - 1)) << 2;
        val_20 = val_20 + 32498712;
        goto (32498712 + ((anchor - 1)) << 2 + 32498712);
    }
    public static void SetUIAnchor(UnityEngine.RectTransform rect, Anchor anchor)
    {
        if((anchor - 1) > 8)
        {
                return;
        }
        
        var val_17 = 32498748 + ((anchor - 1)) << 2;
        val_17 = val_17 + 32498748;
        goto (32498748 + ((anchor - 1)) << 2 + 32498748);
    }
    public static int SetUnsetBit(int value, int bit, bool isOn)
    {
        var val_2 = 1;
        val_2 = val_2 << bit;
        val_2 = val_2 | value;
        value = (isOn != true) ? (val_2) : (value & (~val_2));
        return (int)value;
    }
    public static int SetBit(int value, int bit)
    {
        var val_1 = 1;
        val_1 = val_1 << bit;
        value = val_1 | value;
        return (int)value;
    }
    public static int UnsetBit(int value, int bit)
    {
        var val_1 = 1;
        val_1 = val_1 << bit;
        value = value & (~val_1);
        return (int)value;
    }
    public static bool IsBitSet(int value, int bit)
    {
        var val_2 = 1;
        val_2 = val_2 << bit;
        return (bool)(val_2 != value) ? 1 : 0;
    }

}
