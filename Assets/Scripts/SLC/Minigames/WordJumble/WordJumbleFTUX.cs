using UnityEngine;

namespace SLC.Minigames.WordJumble
{
    public class WordJumbleFTUX : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Image handImage;
        private string answer;
        private int curIndex;
        private System.Collections.Generic.List<SLC.Minigames.WordJumble.WordJumbleLetterTile> tiles;
        private SLC.Minigames.WordJumble.WordJumbleLetterTile curTile;
        
        // Methods
        public void Init(SLC.Minigames.WordJumble.WordJumbleGameplayController controller)
        {
            var val_8;
            var val_9;
            if(true == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
            List.Enumerator<T> val_1 = mem[-2305843009213693896].GetEnumerator();
            label_9:
            val_8 = public System.Boolean List.Enumerator<SLC.Minigames.WordJumble.WordJumbleLetterTile>::MoveNext();
            if(0.MoveNext() == false)
            {
                goto label_6;
            }
            
            val_9 = 0;
            if(val_9 == 0)
            {
                    throw new NullReferenceException();
            }
            
            val_8 = public UnityEngine.UI.Button UnityEngine.Component::GetComponent<UnityEngine.UI.Button>();
            UnityEngine.UI.Button val_3 = val_9.GetComponent<UnityEngine.UI.Button>();
            if(val_3 == null)
            {
                    throw new NullReferenceException();
            }
            
            val_3.interactable = false;
            goto label_9;
            label_6:
            0.Dispose();
            this.answer = mem[-2305843009213693888];
            this.FillListWithTilesSequentially(myArea:  0);
            this.SetHand();
            mem2[-2305843009213693880] = new System.Action(object:  this, method:  System.Void SLC.Minigames.WordJumble.WordJumbleFTUX::OnTileClicked());
            mem2[-2305843009213693872] = new System.Action(object:  this, method:  System.Void SLC.Minigames.WordJumble.WordJumbleFTUX::OnWordComplete());
            UnityEngine.Coroutine val_7 = this.StartCoroutine(routine:  this.FlashHand());
        }
        private void FillListWithTilesSequentially(SLC.Minigames.WordJumble.WordJumbleWordArea myArea)
        {
            System.Collections.Generic.List<SLC.Minigames.WordJumble.WordJumbleLetterTile> val_1 = new System.Collections.Generic.List<SLC.Minigames.WordJumble.WordJumbleLetterTile>();
            val_1.AddRange(collection:  myArea.inputLetters);
            UnityEngine.Debug.LogError(message:  "cur answer " + this.answer);
            if(this.answer.m_stringLength >= 1)
            {
                    var val_13 = 0;
                do
            {
                .character = this.answer.Chars[0];
                SLC.Minigames.WordJumble.WordJumbleLetterTile val_6 = System.Linq.Enumerable.First<SLC.Minigames.WordJumble.WordJumbleLetterTile>(source:  val_1, predicate:  new System.Func<SLC.Minigames.WordJumble.WordJumbleLetterTile, System.Boolean>(object:  new WordJumbleFTUX.<>c__DisplayClass6_0(), method:  System.Boolean WordJumbleFTUX.<>c__DisplayClass6_0::<FillListWithTilesSequentially>b__0(SLC.Minigames.WordJumble.WordJumbleLetterTile x)));
                UnityEngine.Debug.LogError(message:  "checking selected tiles and it\'s null? "("checking selected tiles and it\'s null? ") + UnityEngine.Object.op_Equality(x:  val_6, y:  0).ToString()(UnityEngine.Object.op_Equality(x:  val_6, y:  0).ToString()));
                bool val_11 = val_1.Remove(item:  val_6);
                this.tiles.Add(item:  val_6);
                val_13 = val_13 + 1;
            }
            while(val_13 < this.answer.m_stringLength);
            
            }
            
            UnityEngine.Debug.LogError(message:  "Tiles " + this.tiles);
        }
        private void SetHand()
        {
            if(true == 0)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
                this.tiles = this.tiles;
            }
            
            this.curTile = 0;
            bool val_1 = this.tiles.Remove(item:  0);
            UnityEngine.Vector3 val_4 = this.curTile.transform.position;
            this.handImage.transform.position = new UnityEngine.Vector3() {x = val_4.x, y = val_4.y, z = val_4.z};
            this.curTile.GetComponent<UnityEngine.UI.Button>().interactable = true;
        }
        private void OnTileClicked()
        {
            if(this.tiles != null)
            {
                    this.SetHand();
                return;
            }
            
            UnityEngine.Debug.LogError(message:  "FTuX COMPLETE");
        }
        private void OnWordComplete()
        {
            this.handImage.gameObject.SetActive(value:  false);
            this.enabled = false;
        }
        private System.Collections.IEnumerator FlashHand()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new WordJumbleFTUX.<FlashHand>d__10();
        }
        public WordJumbleFTUX()
        {
            this.answer = "";
            this.tiles = new System.Collections.Generic.List<SLC.Minigames.WordJumble.WordJumbleLetterTile>();
        }
    
    }

}
