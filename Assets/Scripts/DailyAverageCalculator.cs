using UnityEngine;
public class DailyAverageCalculator
{
    // Fields
    private DailyEventComponent dailyComponent;
    private AverageEventCalculator averageCalculator;
    
    // Properties
    public float Average { get; }
    public bool IsTracked { get; }
    
    // Methods
    public float get_Average()
    {
        if(this.averageCalculator != null)
        {
                return (float)this.averageCalculator.average;
        }
        
        throw new NullReferenceException();
    }
    public bool get_IsTracked()
    {
        if(this.dailyComponent != null)
        {
                return this.dailyComponent.IsTracked();
        }
        
        throw new NullReferenceException();
    }
    public DailyAverageCalculator(string name)
    {
        this.dailyComponent = new DailyEventComponent(name:  name);
        this.averageCalculator = new AverageEventCalculator(name:  name);
    }
    public void Calculate(float newValue)
    {
        if(this.dailyComponent.IsTracked() != false)
        {
                return;
        }
        
        this.averageCalculator.Calculate(valueToAdd:  newValue);
        this.dailyComponent.Reset();
    }

}
