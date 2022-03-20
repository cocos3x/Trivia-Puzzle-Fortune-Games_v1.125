using UnityEngine;

namespace WADPets
{
    public static class LocTexts
    {
        // Fields
        public static System.Collections.Generic.Dictionary<WADPets.WADPetAbility, System.Collections.Generic.KeyValuePair<string, string>> AbilityDescription;
        public static System.Collections.Generic.Dictionary<WADPets.WADPetAbility, System.Collections.Generic.KeyValuePair<string, string>> FtuxDescription;
        
        // Methods
        private static LocTexts()
        {
            System.Collections.Generic.Dictionary<WADPets.WADPetAbility, System.Collections.Generic.KeyValuePair<System.String, System.String>> val_1 = new System.Collections.Generic.Dictionary<WADPets.WADPetAbility, System.Collections.Generic.KeyValuePair<System.String, System.String>>();
            System.Collections.Generic.KeyValuePair<System.String, System.String> val_2 = new System.Collections.Generic.KeyValuePair<System.String, System.String>(key:  "wadpets_pa_hint_price_reduction_desc", value:  "Hint cost reduced by {0} coins.");
            val_1.Add(key:  0, value:  new System.Collections.Generic.KeyValuePair<System.String, System.String>() {Value = val_2.Value});
            System.Collections.Generic.KeyValuePair<System.String, System.String> val_3 = new System.Collections.Generic.KeyValuePair<System.String, System.String>(key:  "wadpets_pa_pick_hint_price_reduction_desc", value:  "Pick cost reduced by {0} coins.");
            val_1.Add(key:  1, value:  new System.Collections.Generic.KeyValuePair<System.String, System.String>() {Value = val_3.Value});
            System.Collections.Generic.KeyValuePair<System.String, System.String> val_4 = new System.Collections.Generic.KeyValuePair<System.String, System.String>(key:  "wadpets_pa_bonus_golden_apples_desc", value:  "Earn {0}% additional Golden Apples after each level.");
            val_1.Add(key:  2, value:  new System.Collections.Generic.KeyValuePair<System.String, System.String>() {Value = val_4.Value});
            System.Collections.Generic.KeyValuePair<System.String, System.String> val_5 = new System.Collections.Generic.KeyValuePair<System.String, System.String>(key:  "wadpets_pa_vid_rew_desc", value:  "Increases coins earned from watching videos by {0}.");
            val_1.Add(key:  4, value:  new System.Collections.Generic.KeyValuePair<System.String, System.String>() {Value = val_5.Value});
            System.Collections.Generic.KeyValuePair<System.String, System.String> val_6 = new System.Collections.Generic.KeyValuePair<System.String, System.String>(key:  "wadpets_pa_alphabet_tile_spawn_chance_desc", value:  "Increase chance of Alphabet Tiles appearing by {0}%.");
            val_1.Add(key:  3, value:  new System.Collections.Generic.KeyValuePair<System.String, System.String>() {Value = val_6.Value});
            System.Collections.Generic.KeyValuePair<System.String, System.String> val_7 = new System.Collections.Generic.KeyValuePair<System.String, System.String>(key:  "wadpets_pa_bonus_coin_daily_bonus_chapter_rew_desc", value:  "Increases coin reward of daily bonus and chapter reward by {0}-{1}.");
            val_1.Add(key:  5, value:  new System.Collections.Generic.KeyValuePair<System.String, System.String>() {Value = val_7.Value});
            WADPets.LocTexts.AbilityDescription = val_1;
            System.Collections.Generic.Dictionary<WADPets.WADPetAbility, System.Collections.Generic.KeyValuePair<System.String, System.String>> val_8 = new System.Collections.Generic.Dictionary<WADPets.WADPetAbility, System.Collections.Generic.KeyValuePair<System.String, System.String>>();
            System.Collections.Generic.KeyValuePair<System.String, System.String> val_9 = new System.Collections.Generic.KeyValuePair<System.String, System.String>(key:  "wadpets_hint_reduction_ftux", value:  "When active, {0} reduces the cost of hint!");
            val_8.Add(key:  0, value:  new System.Collections.Generic.KeyValuePair<System.String, System.String>() {Value = val_9.Value});
            System.Collections.Generic.KeyValuePair<System.String, System.String> val_10 = new System.Collections.Generic.KeyValuePair<System.String, System.String>(key:  "wadpets_pick_hint_reduction_ftux", value:  "When active, {0} reduces the cost of pick!");
            val_8.Add(key:  1, value:  new System.Collections.Generic.KeyValuePair<System.String, System.String>() {Value = val_10.Value});
            System.Collections.Generic.KeyValuePair<System.String, System.String> val_11 = new System.Collections.Generic.KeyValuePair<System.String, System.String>(key:  "wadpets_video_reward_ftux", value:  "When active, {0} gives more coins for watching videos!");
            val_8.Add(key:  4, value:  new System.Collections.Generic.KeyValuePair<System.String, System.String>() {Value = val_11.Value});
            System.Collections.Generic.KeyValuePair<System.String, System.String> val_12 = new System.Collections.Generic.KeyValuePair<System.String, System.String>(key:  "wadpets_alphabet_tile_chance_ftux", value:  "When active, {0} occasionally provides an alphabet tile!");
            val_8.Add(key:  3, value:  new System.Collections.Generic.KeyValuePair<System.String, System.String>() {Value = val_12.Value});
            System.Collections.Generic.KeyValuePair<System.String, System.String> val_13 = new System.Collections.Generic.KeyValuePair<System.String, System.String>(key:  "wadpets_extra_golden_currency_ftux", value:  "When fed, {0} gives you additional {1} every level!");
            val_8.Add(key:  2, value:  new System.Collections.Generic.KeyValuePair<System.String, System.String>() {Value = val_13.Value});
            WADPets.LocTexts.FtuxDescription = val_8;
        }
    
    }

}
