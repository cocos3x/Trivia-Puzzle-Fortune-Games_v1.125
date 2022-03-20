using UnityEngine;

namespace twelvegigs.storage
{
    public class JsonDictionary
    {
        // Fields
        private System.Collections.IDictionary dataSource;
        
        // Properties
        public static System.DateTime UnixTimeZero { get; }
        
        // Methods
        public JsonDictionary()
        {
            this.dataSource = new System.Collections.Generic.Dictionary<System.String, System.Object>();
        }
        public JsonDictionary(System.Collections.IDictionary parsedDictionary)
        {
            System.Collections.IDictionary val_2 = parsedDictionary;
            if(val_2 == null)
            {
                    System.Collections.Generic.Dictionary<System.String, System.Object> val_1 = null;
                val_2 = val_1;
                val_1 = new System.Collections.Generic.Dictionary<System.String, System.Object>();
            }
            
            this.dataSource = val_2;
        }
        public System.Collections.IEnumerator getKeys()
        {
            var val_4 = 0;
            val_4 = val_4 + 1;
            var val_5 = 0;
            val_5 = val_5 + 1;
            return this.dataSource.Keys.GetEnumerator();
        }
        public void Add(string key, object data)
        {
            var val_2 = 0;
            val_2 = val_2 + 1;
            this.dataSource.Add(key:  key, value:  data);
        }
        public System.Collections.IDictionary getData()
        {
            return (System.Collections.IDictionary)this.dataSource;
        }
        public bool getBool(string key)
        {
            object val_6;
            var val_7;
            System.Collections.IDictionary val_8;
            var val_10;
            object val_12;
            val_6 = key;
            val_8 = this.dataSource;
            if(val_8 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_8 = 0;
            val_8 = val_8 + 1;
            val_10 = public System.Boolean System.Collections.IDictionary::Contains(object key);
            val_7 = val_8;
            if((val_7.Contains(key:  val_6)) != false)
            {
                    if(this.dataSource == null)
            {
                    throw new NullReferenceException();
            }
            
                var val_9 = 0;
                val_9 = val_9 + 1;
                val_10 = 0;
                val_12 = this.dataSource.Item[val_6];
                bool val_5 = System.Convert.ToBoolean(value:  val_12);
            }
            else
            {
                    val_12 = 0;
            }
            
            val_12 = val_12 & 1;
            return (bool)val_12;
        }
        public void setData(System.Collections.IDictionary data)
        {
            this.dataSource = data;
        }
        public bool Contains(object key)
        {
            var val_2 = 0;
            val_2 = val_2 + 1;
            return this.dataSource.Contains(key:  key);
        }
        public float getFloat(string key, float defaultValue = 0)
        {
            var val_6;
            var val_7;
            var val_9;
            object val_10;
            val_6 = defaultValue;
            if(this.dataSource == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_8 = 0;
            val_8 = val_8 + 1;
            val_9 = public System.Boolean System.Collections.IDictionary::Contains(object key);
            val_7 = this.dataSource;
            val_10 = key;
            if((val_7.Contains(key:  val_10)) == false)
            {
                    return (float)val_6;
            }
            
            if(this.dataSource == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_9 = 0;
            val_9 = val_9 + 1;
            val_9 = 0;
            val_7 = this.dataSource;
            val_10 = key;
            object val_4 = val_7.Item[val_10];
            if(val_4 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_6 = System.Single.Parse(s:  val_4);
            return (float)val_6;
        }
        public int getInt(string key, int defaultValue = 0)
        {
            var val_7;
            System.Collections.IDictionary val_8;
            var val_9;
            var val_11;
            object val_12;
            var val_14;
            val_7 = defaultValue;
            val_8 = this;
            if(this.dataSource == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_10 = 0;
            val_10 = val_10 + 1;
            val_11 = public System.Boolean System.Collections.IDictionary::Contains(object key);
            val_9 = this.dataSource;
            val_12 = key;
            if((val_9.Contains(key:  val_12)) == false)
            {
                    return (int)val_7;
            }
            
            if(this.dataSource == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_11 = 0;
            val_11 = val_11 + 1;
            val_11 = 0;
            val_14 = public System.Object System.Collections.IDictionary::get_Item(object key);
            val_9 = this.dataSource;
            val_12 = key;
            if(val_9.Item[val_12] == null)
            {
                    return (int)val_7;
            }
            
            val_8 = this.dataSource;
            if(val_8 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_12 = 0;
            val_12 = val_12 + 1;
            val_14 = 0;
            val_9 = val_8;
            val_12 = key;
            object val_6 = val_9.Item[val_12];
            if(val_6 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_7 = System.Int32.Parse(s:  val_6);
            return (int)val_7;
        }
        public decimal getDecimal(string key, decimal defaultValue)
        {
            int val_6;
            int val_7;
            var val_8;
            var val_10;
            object val_11;
            val_6 = defaultValue.lo;
            val_7 = defaultValue.flags;
            if(this.dataSource == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_8 = 0;
            val_8 = val_8 + 1;
            val_10 = public System.Boolean System.Collections.IDictionary::Contains(object key);
            val_8 = this.dataSource;
            val_11 = key;
            if((val_8.Contains(key:  val_11)) == false)
            {
                    return new System.Decimal() {flags = val_7, hi = val_5.hi, lo = val_6, mid = val_5.mid};
            }
            
            if(this.dataSource == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_9 = 0;
            val_9 = val_9 + 1;
            val_10 = 0;
            val_8 = this.dataSource;
            val_11 = key;
            object val_4 = val_8.Item[val_11];
            if(val_4 == null)
            {
                    throw new NullReferenceException();
            }
            
            decimal val_5 = System.Decimal.Parse(s:  val_4, style:  511);
            val_7 = val_5.flags;
            val_6 = val_5.lo;
            return new System.Decimal() {flags = val_7, hi = val_5.hi, lo = val_6, mid = val_5.mid};
        }
        public string getSafeString(string key, string defaultValue = "")
        {
            var val_6;
            var val_8;
            var val_8 = 0;
            val_8 = val_8 + 1;
            val_6 = public System.Boolean System.Collections.IDictionary::Contains(object key);
            if((this.dataSource.Contains(key:  key)) == false)
            {
                    return (string)defaultValue;
            }
            
            var val_9 = 0;
            val_9 = val_9 + 1;
            val_6 = 0;
            val_8 = public System.Object System.Collections.IDictionary::get_Item(object key);
            if((System.String.IsNullOrEmpty(value:  this.dataSource.Item[key])) != false)
            {
                    return (string)defaultValue;
            }
            
            var val_10 = 0;
            val_10 = val_10 + 1;
            val_8 = 0;
            object val_7 = this.dataSource.Item[key];
            goto typeof(System.Object).__il2cppRuntimeField_160;
        }
        public string getString(string key, string defaultValue = "")
        {
            var val_5;
            System.Collections.IDictionary val_6;
            var val_7;
            var val_9;
            object val_10;
            val_5 = defaultValue;
            val_6 = this;
            if(this.dataSource == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_7 = 0;
            val_7 = val_7 + 1;
            val_9 = public System.Boolean System.Collections.IDictionary::Contains(object key);
            val_7 = this.dataSource;
            val_10 = key;
            if((val_7.Contains(key:  val_10)) == false)
            {
                    return (string)val_5;
            }
            
            val_6 = this.dataSource;
            if(val_6 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_8 = 0;
            val_8 = val_8 + 1;
            val_9 = 0;
            val_7 = val_6;
            val_10 = key;
            object val_4 = val_7.Item[val_10];
            if(val_4 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_5 = val_4;
            return (string)val_5;
        }
        public System.DateTime getDate(string key)
        {
            object val_5;
            var val_6;
            System.Collections.IDictionary val_7;
            var val_9;
            object val_10;
            var val_12;
            val_5 = key;
            val_7 = this.dataSource;
            if(val_7 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_7 = 0;
            val_7 = val_7 + 1;
            val_9 = public System.Boolean System.Collections.IDictionary::Contains(object key);
            val_6 = val_7;
            val_10 = val_5;
            if((val_6.Contains(key:  val_10)) != false)
            {
                    if(this.dataSource == null)
            {
                    throw new NullReferenceException();
            }
            
                var val_8 = 0;
                val_8 = val_8 + 1;
                val_9 = 0;
                val_6 = this.dataSource;
                val_10 = val_5;
                if(val_6.Item[val_10] == null)
            {
                    throw new NullReferenceException();
            }
            
                val_10 = null;
                return (System.DateTime)val_12;
            }
            
            val_12 = 0;
            return (System.DateTime)val_12;
        }
        public System.Collections.Generic.List<object> getList(string key)
        {
            var val_5;
            var val_7;
            var val_6 = 0;
            val_6 = val_6 + 1;
            val_5 = public System.Boolean System.Collections.IDictionary::Contains(object key);
            if((this.dataSource.Contains(key:  key)) != false)
            {
                    var val_7 = 0;
                val_7 = val_7 + 1;
                val_5 = 0;
                val_7 = this.dataSource;
                if(val_7.Item[key] == null)
            {
                    return (System.Collections.Generic.List<System.Object>)val_7;
            }
            
            }
            
            val_7 = 0;
            return (System.Collections.Generic.List<System.Object>)val_7;
        }
        public twelvegigs.storage.JsonDictionary getJsonDictionary(string key)
        {
            object val_6;
            var val_7;
            System.Collections.IDictionary val_8;
            var val_10;
            twelvegigs.storage.JsonDictionary val_12;
            val_6 = key;
            val_8 = this.dataSource;
            if(val_8 == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_8 = 0;
            val_8 = val_8 + 1;
            val_10 = public System.Boolean System.Collections.IDictionary::Contains(object key);
            val_7 = val_8;
            if((val_7.Contains(key:  val_6)) != false)
            {
                    if(this.dataSource == null)
            {
                    throw new NullReferenceException();
            }
            
                var val_9 = 0;
                val_9 = val_9 + 1;
                val_10 = 0;
                val_8 = this.dataSource.Item[val_6];
                val_12 = new twelvegigs.storage.JsonDictionary();
                val_12 = new twelvegigs.storage.JsonDictionary(parsedDictionary:  X0);
                return (twelvegigs.storage.JsonDictionary)val_12;
            }
            
            val_12 = 0;
            return (twelvegigs.storage.JsonDictionary)val_12;
        }
        public static System.DateTime get_UnixTimeZero()
        {
            System.DateTime val_1 = new System.DateTime(year:  178, month:  1, day:  1, hour:  0, minute:  0, second:  0, kind:  1);
            return (System.DateTime)val_1.dateData;
        }
        public static System.DateTime ConvertToUTC(decimal timestamp)
        {
            System.DateTime val_1 = new System.DateTime(year:  178, month:  1, day:  1, hour:  0, minute:  0, second:  0, kind:  1);
            System.DateTime val_3 = val_1.dateData.AddSeconds(value:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = timestamp.flags, hi = timestamp.hi, lo = timestamp.lo, mid = timestamp.mid}));
            return (System.DateTime)val_3.dateData;
        }
        public static System.DateTime ConvertToUTCMilliseconds(decimal timestamp)
        {
            System.DateTime val_1 = new System.DateTime(year:  178, month:  1, day:  1, hour:  0, minute:  0, second:  0, kind:  1);
            System.DateTime val_3 = val_1.dateData.AddMilliseconds(value:  System.Decimal.op_Explicit(value:  new System.Decimal() {flags = timestamp.flags, hi = timestamp.hi, lo = timestamp.lo, mid = timestamp.mid}));
            return (System.DateTime)val_3.dateData;
        }
        public static long TotalSeconds(System.DateTime dateTime)
        {
            System.DateTime val_1 = new System.DateTime(year:  178, month:  1, day:  1, hour:  0, minute:  0, second:  0, kind:  1);
            System.TimeSpan val_2 = System.DateTime.op_Subtraction(d1:  new System.DateTime() {dateData = dateTime.dateData}, d2:  new System.DateTime() {dateData = val_1.dateData});
            double val_3 = val_2._ticks.TotalSeconds;
            val_3 = (val_3 == Infinity) ? (-val_3) : (val_3);
            return (long)(long)val_3;
        }
        public System.DateTime getEpochInUTC(string key)
        {
            System.DateTime val_2 = new System.DateTime(year:  178, month:  1, day:  1, hour:  0, minute:  0, second:  0, kind:  1);
            System.DateTime val_3 = val_2.dateData.AddSeconds(value:  (double)this.getInt(key:  key, defaultValue:  0));
            return (System.DateTime)val_3.dateData;
        }
        public System.Collections.Generic.Dictionary<string, object> getDictionary(string key)
        {
            var val_6;
            var val_8;
            if(this.dataSource == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_8 = 0;
            val_8 = val_8 + 1;
            val_8 = public System.Boolean System.Collections.IDictionary::Contains(object key);
            val_6 = this.dataSource;
            if((val_6.Contains(key:  key)) == false)
            {
                    return 0;
            }
            
            if(this.dataSource == null)
            {
                    throw new NullReferenceException();
            }
            
            var val_9 = 0;
            val_9 = val_9 + 1;
            val_8 = 0;
            object val_4 = this.dataSource.Item[key];
            return 0;
        }
        public override string ToString()
        {
            if(this.dataSource == null)
            {
                    return "{empty}";
            }
            
            return MiniJSON.Json.Serialize(obj:  this.dataSource);
        }
    
    }

}
