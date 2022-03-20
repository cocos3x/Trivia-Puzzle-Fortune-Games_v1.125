using UnityEngine;
public class WGEventButtonProgressWordHunt : WGEventButtonProgress
{
    // Fields
    public UnityEngine.CanvasGroup[] toolTips;
    
    // Methods
    public override void Refresh()
    {
        goto X19 + 1504;
    }
    public void ShowToolTip()
    {
        if(true == 1)
        {
                return;
        }
        
        bool val_1 = UnityEngine.Object.op_Inequality(x:  this.toolTips[true], y:  0);
        if(val_1 == false)
        {
                return;
        }
        
        if(val_1.EvtBtnFtuxShown != false)
        {
                return;
        }
        
        this.toolTips[WordHuntEvent.__il2cppRuntimeField_typeHierarchyDepth].GetComponent<UnityEngine.Canvas>().sortingLayerName = "Foreground";
        this.toolTips[WordHuntEvent.__il2cppRuntimeField_typeHierarchyDepth].alpha = 1f;
        DG.Tweening.DOVirtual.DelayedCall(delay:  1f, callback:  new DG.Tweening.TweenCallback(object:  this, method:  System.Void WGEventButtonProgressWordHunt::<ShowToolTip>b__2_0()), ignoreTimeScale:  true).EvtBtnFtuxShown = true;
    }
    public WGEventButtonProgressWordHunt()
    {
        mem[1152921517500506752] = 0;
        val_1 = new UnityEngine.MonoBehaviour();
    }
    private void <ShowToolTip>b__2_0()
    {
        DG.Tweening.Tweener val_1 = DG.Tweening.ShortcutExtensions46.DOFade(target:  null, endValue:  0f, duration:  1f);
    }

}
