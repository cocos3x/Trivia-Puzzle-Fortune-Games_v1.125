using UnityEngine;

namespace twelvegigs.sweepstakes
{
    public class Security
    {
        // Methods
        public string RequestId()
        {
            System.DateTime val_3 = System.DateTime.Today;
            System.DateTime val_6 = System.DateTime.Now;
            return (string)twelvegigs.sweepstakes.HashUtil.MD5(text:  System.String.Format(format:  "{0}{1}{2}", arg0:  UnityEngine.Random.Range(min:  -1E+07f, max:  1E+07f).ToString(), arg1:  val_3.dateData.Ticks.ToString(), arg2:  val_6.dateData.ToString())).Substring(startIndex:  0, length:  UnityEngine.Random.Range(min:  13, max:  15)).ToLower();
        }
        public int Seed()
        {
            return UnityEngine.Random.Range(min:  1, max:  99999999);
        }
        public int UnixTimestamp()
        {
            System.DateTime val_1 = System.DateTime.UtcNow;
            System.DateTime val_2 = new System.DateTime(year:  178, month:  1, day:  1);
            System.TimeSpan val_3 = val_1.dateData.Subtract(value:  new System.DateTime() {dateData = val_2.dateData});
            double val_4 = val_3._ticks.TotalSeconds;
            val_4 = (val_4 == Infinity) ? (-val_4) : (val_4);
            return (int)(int)val_4;
        }
        public string Sign(string[] signParams, System.Collections.Generic.Dictionary<string, object> payload)
        {
            string val_9;
            var val_10;
            string val_11;
            System.Text.StringBuilder val_1 = null;
            val_9 = 0;
            val_1 = new System.Text.StringBuilder();
            int val_9 = signParams.Length;
            if(val_9 >= 1)
            {
                    var val_10 = 0;
                val_9 = val_9 & 4294967295;
                do
            {
                val_9 = twelvegigs.sweepstakes.StringUtil.ReverseString(s:  null);
                System.Text.StringBuilder val_3 = val_1.Append(value:  val_9);
                val_10 = val_10 + 1;
            }
            while(val_10 < (signParams.Length << ));
            
            }
            
            if(payload != null)
            {
                    val_10 = 0;
                string val_4 = MiniJSON.Json.Serialize(obj:  payload);
                return twelvegigs.sweepstakes.HashUtil.SHA512(bytes:  twelvegigs.sweepstakes.HashUtil.ToByte(text:  val_1 + twelvegigs.sweepstakes.HashUtil.SHA512(bytes:  twelvegigs.sweepstakes.HashUtil.ToByte(text:  val_11 = "empty"))(twelvegigs.sweepstakes.HashUtil.SHA512(bytes:  twelvegigs.sweepstakes.HashUtil.ToByte(text:  val_11 = "empty"))) + val_1));
            }
            
            return twelvegigs.sweepstakes.HashUtil.SHA512(bytes:  twelvegigs.sweepstakes.HashUtil.ToByte(text:  val_1 + twelvegigs.sweepstakes.HashUtil.SHA512(bytes:  twelvegigs.sweepstakes.HashUtil.ToByte(text:  val_11))(twelvegigs.sweepstakes.HashUtil.SHA512(bytes:  twelvegigs.sweepstakes.HashUtil.ToByte(text:  val_11))) + val_1));
        }
        public string OpenUdidGenerator(string fromId)
        {
            return twelvegigs.sweepstakes.HashUtil.SHA512(bytes:  twelvegigs.sweepstakes.HashUtil.ToByte(text:  fromId));
        }
        public Security()
        {
        
        }
    
    }

}
