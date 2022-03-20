using UnityEngine;
public class PurchaseUserInfo
{
    // Fields
    public float total_purchase;
    public decimal total_credits;
    
    // Methods
    public override string ToString()
    {
        return (string)System.String.Format(format:  "[PurchaseUserInfo] total_purchase: {0}, total_credits: {1}", arg0:  this.total_purchase, arg1:  this.total_credits);
    }
    public PurchaseUserInfo()
    {
        null = null;
        this.total_credits = System.Decimal.MinusOne;
    }

}
