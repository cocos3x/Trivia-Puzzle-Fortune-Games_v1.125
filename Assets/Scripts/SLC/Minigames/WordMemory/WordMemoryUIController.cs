using UnityEngine;

namespace SLC.Minigames.WordMemory
{
    public class WordMemoryUIController : MonoBehaviour
    {
        // Fields
        private UnityEngine.GameObject cardItemPrefab;
        private UnityEngine.Transform cardHolder;
        private UnityEngine.GameObject cardRowPrefab;
        private UnityEngine.UI.Text livesText;
        private int lives;
        private int maxLives;
        private System.Collections.Generic.List<SLC.Minigames.WordMemory.CardItem> cards;
        private System.Collections.Generic.Dictionary<int, int[]> layout;
        
        // Methods
        public void LoadLevel(int maxLives, int lives, int pairs, string[] words)
        {
            UnityEngine.GameObject val_8;
            var val_9;
            int val_10;
            this.SetLives(lives:  lives, maxLives:  lives);
            MethodExtensionForMonoBehaviourTransform.DestroyChildren(t:  this.cardHolder);
            this.cards.Clear();
            if(val_1.Length >= 1)
            {
                    val_9 = 0;
                var val_12 = 0;
                do
            {
                val_8 = this.cardRowPrefab;
                val_10 = val_1.Length;
                if(this.layout.Item[pairs][0] >= 1)
            {
                    var val_11 = 0;
                do
            {
                val_8 = UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  this.cardItemPrefab, parent:  UnityEngine.Object.Instantiate<UnityEngine.GameObject>(original:  val_8, parent:  this.cardHolder).transform).GetComponent<SLC.Minigames.WordMemory.CardItem>();
                this.cards.Add(item:  val_8);
                int val_6 = val_9 + val_11;
                val_8.Init(_index:  val_6, _word:  words[val_6]);
                val_10 = val_1.Length;
                val_11 = val_11 + 1;
            }
            while(val_11 < (val_1[0x0] + 32));
            
                val_9 = val_9 + val_11;
            }
            
                val_12 = val_12 + 1;
            }
            while(val_12 < (val_10 << ));
            
            }
            
            UnityEngine.Coroutine val_8 = this.StartCoroutine(routine:  this.FaceUpOnStart());
        }
        public void SetLives(int lives, int maxLives)
        {
            string val_1 = System.String.Format(format:  "{0} / {1}", arg0:  lives, arg1:  maxLives);
        }
        public void HandleComplete()
        {
        
        }
        public void HandleContinue()
        {
        
        }
        private System.Collections.IEnumerator FaceUpOnStart()
        {
            .<>1__state = 0;
            .<>4__this = this;
            return (System.Collections.IEnumerator)new WordMemoryUIController.<FaceUpOnStart>d__12();
        }
        public void FaceUpAll()
        {
            bool val_1 = true;
            var val_2 = 0;
            do
            {
                if(val_2 >= val_1)
            {
                    return;
            }
            
                if(val_1 <= val_2)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_1 = val_1 + 0;
                (true + 0) + 32.FaceUp();
                val_2 = val_2 + 1;
            }
            while(this.cards != null);
            
            throw new NullReferenceException();
        }
        public void FaceDownAll()
        {
            bool val_1 = true;
            var val_2 = 0;
            do
            {
                if(val_2 >= val_1)
            {
                    return;
            }
            
                if(val_1 <= val_2)
            {
                    System.ThrowHelper.ThrowArgumentOutOfRangeException();
            }
            
                val_1 = val_1 + 0;
                (true + 0) + 32.FaceDown();
                val_2 = val_2 + 1;
            }
            while(this.cards != null);
            
            throw new NullReferenceException();
        }
        public void FaceDown(int card1, int card2)
        {
            UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.DelayFaceDownPair(card1:  card1, card2:  card2));
        }
        public void HidePair(int card1, int card2)
        {
            UnityEngine.Coroutine val_2 = this.StartCoroutine(routine:  this.DelayHidePair(card1:  card1, card2:  card2));
        }
        private System.Collections.IEnumerator DelayHidePair(int card1, int card2)
        {
            .<>1__state = 0;
            .<>4__this = this;
            .card1 = card1;
            .card2 = card2;
            return (System.Collections.IEnumerator)new WordMemoryUIController.<DelayHidePair>d__17();
        }
        private System.Collections.IEnumerator DelayFaceDownPair(int card1, int card2)
        {
            .<>1__state = 0;
            .<>4__this = this;
            .card1 = card1;
            .card2 = card2;
            return (System.Collections.IEnumerator)new WordMemoryUIController.<DelayFaceDownPair>d__18();
        }
        private void Start()
        {
        
        }
        private void Update()
        {
        
        }
        public WordMemoryUIController()
        {
            this.cards = new System.Collections.Generic.List<SLC.Minigames.WordMemory.CardItem>();
            System.Collections.Generic.Dictionary<System.Int32, System.Int32[]> val_2 = new System.Collections.Generic.Dictionary<System.Int32, System.Int32[]>();
            int[] val_3 = new int[2];
            val_3[0] = 3;
            val_3[0] = 3;
            val_2.Add(key:  3, value:  val_3);
            val_2.Add(key:  4, value:  new int[3] {2, 3, 3});
            val_2.Add(key:  5, value:  new int[4] {2, 3, 3, 2});
            val_2.Add(key:  6, value:  new int[4] {3, 3, 3, 3});
            val_2.Add(key:  7, value:  new int[4] {3, 4, 4, 3});
            val_2.Add(key:  8, value:  new int[4] {4, 4, 4, 4});
            val_2.Add(key:  9, value:  new int[5] {3, 4, 4, 4, 3});
            val_2.Add(key:  10, value:  new int[5] {4, 4, 4, 4, 4});
            this.layout = val_2;
        }
    
    }

}
