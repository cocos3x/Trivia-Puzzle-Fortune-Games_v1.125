using UnityEngine;

namespace SLC.Minigames.TwistyArrow
{
    public class FlyingArrow : MonoBehaviour
    {
        // Fields
        private UnityEngine.UI.Image arrowimage;
        private UnityEngine.Sprite normalSprite;
        private UnityEngine.Sprite brokenSprite;
        private UnityEngine.Collider2D normalColl;
        private UnityEngine.Collider2D brokenColl;
        private float speed;
        private UnityEngine.Rigidbody2D rb;
        private bool hit;
        
        // Methods
        private void Awake()
        {
            this.rb = this.GetComponent<UnityEngine.Rigidbody2D>();
            this.arrowimage = this.GetComponent<UnityEngine.UI.Image>();
            this.rb.bodyType = 0;
            this.rb.collisionDetectionMode = 1;
            this.rb.gravityScale = 0f;
            this.arrowimage.sprite = this.normalSprite;
            this.normalColl.enabled = true;
            this.brokenColl.enabled = false;
            this.hit = false;
        }
        private void OnCollisionEnter2D(UnityEngine.Collision2D col)
        {
            if(this.hit == true)
            {
                    return;
            }
            
            if((System.String.op_Equality(a:  col.gameObject.tag, b:  "StuckArrow")) == false)
            {
                    return;
            }
            
            this.hit = true;
            UnityEngine.Vector2 val_4 = UnityEngine.Vector2.down;
            this.rb.AddForce(force:  new UnityEngine.Vector2() {x = val_4.x, y = val_4.y});
            this.rb.gravityScale = 1f;
            this.arrowimage.sprite = this.brokenSprite;
            this.normalColl.enabled = false;
            this.brokenColl.enabled = true;
            MonoSingleton<SLC.Minigames.TwistyArrow.TwistyArrowLogic>.Instance.HandleHitArrow();
        }
        public void SetSpeed(float _speed)
        {
            UnityEngine.Vector2 val_1 = new UnityEngine.Vector2(x:  0f, y:  _speed);
            this.rb.velocity = new UnityEngine.Vector2() {x = val_1.x, y = val_1.y};
        }
        public void ClearRigidBody()
        {
            UnityEngine.Object.Destroy(obj:  this.rb);
            this.rb = 0;
        }
        public void SetNormalColliderActive(bool state)
        {
            if(this.brokenColl.enabled != false)
            {
                    return;
            }
            
            this.normalColl.enabled = state;
        }
        public FlyingArrow()
        {
            this.speed = 1f;
        }
    
    }

}
