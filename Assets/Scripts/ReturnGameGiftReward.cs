using UnityEngine;
public class ReturnGameGiftReward
{
    // Fields
    private int <tier>k__BackingField;
    private decimal <coins>k__BackingField;
    private decimal <spins>k__BackingField;
    
    // Properties
    public int tier { get; set; }
    public decimal coins { get; set; }
    public decimal spins { get; set; }
    
    // Methods
    public int get_tier()
    {
        return (int)this.<tier>k__BackingField;
    }
    private void set_tier(int value)
    {
        this.<tier>k__BackingField = value;
    }
    public decimal get_coins()
    {
        return new System.Decimal() {flags = this.<coins>k__BackingField, hi = this.<coins>k__BackingField};
    }
    private void set_coins(decimal value)
    {
        this.<coins>k__BackingField = value;
        mem[1152921517633568492] = value.lo;
        mem[1152921517633568496] = value.mid;
    }
    public decimal get_spins()
    {
        return new System.Decimal() {flags = this.<spins>k__BackingField, hi = this.<spins>k__BackingField};
    }
    private void set_spins(decimal value)
    {
        this.<spins>k__BackingField = value;
        mem[1152921517633792508] = value.lo;
        mem[1152921517633792512] = value.mid;
    }
    public ReturnGameGiftReward()
    {
        var val_1;
        this.<tier>k__BackingField = 1;
        val_1 = null;
        val_1 = null;
        this.<coins>k__BackingField = System.Decimal.Zero;
        this.<spins>k__BackingField = System.Decimal.Zero;
    }
    public ReturnGameGiftReward(int _tier, decimal _coins, decimal _spins)
    {
        this.<tier>k__BackingField = _tier;
        this.<coins>k__BackingField = _coins;
        mem[1152921517634016492] = _coins.lo;
        mem[1152921517634016496] = _coins.mid;
        this.<spins>k__BackingField = _spins;
        mem[1152921517634016508] = _spins.lo;
        mem[1152921517634016512] = _spins.mid;
    }

}
