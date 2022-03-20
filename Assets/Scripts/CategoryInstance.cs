using UnityEngine;
private class OptionsTabController.CategoryInstance
{
    // Fields
    private SRDebugger.UI.Other.CategoryGroup <CategoryGroup>k__BackingField;
    public readonly System.Collections.Generic.List<SRDebugger.UI.Controls.OptionsControlBase> Options;
    
    // Properties
    public SRDebugger.UI.Other.CategoryGroup CategoryGroup { get; set; }
    
    // Methods
    public SRDebugger.UI.Other.CategoryGroup get_CategoryGroup()
    {
        return (SRDebugger.UI.Other.CategoryGroup)this.<CategoryGroup>k__BackingField;
    }
    private void set_CategoryGroup(SRDebugger.UI.Other.CategoryGroup value)
    {
        this.<CategoryGroup>k__BackingField = value;
    }
    public OptionsTabController.CategoryInstance(SRDebugger.UI.Other.CategoryGroup group)
    {
        this.Options = new System.Collections.Generic.List<SRDebugger.UI.Controls.OptionsControlBase>();
        this.<CategoryGroup>k__BackingField = group;
    }

}
