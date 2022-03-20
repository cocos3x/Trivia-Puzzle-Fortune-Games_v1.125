using UnityEngine;
public class SeasonalSkin
{
    // Fields
    public string assetNameHead;
    public System.DateTime activeDate;
    public int durationInDays;
    
    // Methods
    public bool Active()
    {
        System.DateTime val_1 = DateTimeCheat.Now;
        if((System.DateTime.op_GreaterThanOrEqual(t1:  new System.DateTime() {dateData = val_1.dateData}, t2:  new System.DateTime() {dateData = this.activeDate})) == false)
        {
                return false;
        }
        
        System.DateTime val_3 = DateTimeCheat.Now;
        System.DateTime val_4 = this.activeDate.AddDays(value:  (double)this.durationInDays);
        return System.DateTime.op_LessThanOrEqual(t1:  new System.DateTime() {dateData = val_3.dateData}, t2:  new System.DateTime() {dateData = val_4.dateData});
    }
    public string GetAssetName(string textureId = "")
    {
        return this.assetNameHead + textureId + ".png";
    }
    public SeasonalSkin()
    {
    
    }

}
