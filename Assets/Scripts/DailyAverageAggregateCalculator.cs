using UnityEngine;
public class DailyAverageAggregateCalculator
{
    // Fields
    private DailyEventComponent dailyComponent;
    private AverageEventCalculator averageCalculator;
    private AggregateEventCalculator aggregateCalculator;
    
    // Properties
    public float Average { get; }
    
    // Methods
    public float get_Average()
    {
        return this.averageCalculator.CalculateCurrent(valueToAdd:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = this.aggregateCalculator.aggregate, hi = this.aggregateCalculator.aggregate, lo = 41975808}));
    }
    public DailyAverageAggregateCalculator(string name)
    {
        this.dailyComponent = new DailyEventComponent(name:  name);
        this.averageCalculator = new AverageEventCalculator(name:  name);
        this.aggregateCalculator = new AggregateEventCalculator(name:  name);
    }
    public void Calculate(decimal valueToAggregate)
    {
        AggregateEventCalculator val_4;
        if(this.dailyComponent.IsTracked() != false)
        {
                val_4 = this.aggregateCalculator;
        }
        else
        {
                val_4 = this;
            this.averageCalculator.Calculate(valueToAdd:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = this.aggregateCalculator.aggregate, hi = this.aggregateCalculator.aggregate, lo = X23, mid = X23}));
            null.Flush();
            this.dailyComponent.Reset();
        }
        
        null.Calculate(valueToAggregate:  new System.Decimal() {flags = valueToAggregate.flags, hi = valueToAggregate.hi, lo = valueToAggregate.lo, mid = valueToAggregate.mid}, autoFlush:  false);
        bool val_3 = PrefsSerializationManager.SavePlayerPrefs();
    }

}
