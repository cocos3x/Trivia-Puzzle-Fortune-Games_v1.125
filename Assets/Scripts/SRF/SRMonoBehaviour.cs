using UnityEngine;

namespace SRF
{
    public abstract class SRMonoBehaviour : MonoBehaviour
    {
        // Fields
        private UnityEngine.Collider _collider;
        private UnityEngine.Transform _transform;
        private UnityEngine.Rigidbody _rigidBody;
        private UnityEngine.GameObject _gameObject;
        private UnityEngine.Rigidbody2D _rigidbody2D;
        private UnityEngine.Collider2D _collider2D;
        
        // Properties
        public UnityEngine.Transform CachedTransform { get; }
        public UnityEngine.Collider CachedCollider { get; }
        public UnityEngine.Collider2D CachedCollider2D { get; }
        public UnityEngine.Rigidbody CachedRigidBody { get; }
        public UnityEngine.Rigidbody2D CachedRigidBody2D { get; }
        public UnityEngine.GameObject CachedGameObject { get; }
        public UnityEngine.Transform transform { get; }
        public UnityEngine.Collider collider { get; }
        public UnityEngine.Collider2D collider2D { get; }
        public UnityEngine.Rigidbody rigidbody { get; }
        public UnityEngine.Rigidbody2D rigidbody2D { get; }
        public UnityEngine.GameObject gameObject { get; }
        
        // Methods
        public UnityEngine.Transform get_CachedTransform()
        {
            UnityEngine.Transform val_3;
            if(this._transform == 0)
            {
                    this._transform = this.transform;
                return val_3;
            }
            
            val_3 = this._transform;
            return val_3;
        }
        public UnityEngine.Collider get_CachedCollider()
        {
            UnityEngine.Collider val_3;
            if(this._collider == 0)
            {
                    this._collider = this.GetComponent<UnityEngine.Collider>();
                return val_3;
            }
            
            val_3 = this._collider;
            return val_3;
        }
        public UnityEngine.Collider2D get_CachedCollider2D()
        {
            UnityEngine.Collider2D val_3;
            if(this._collider2D == 0)
            {
                    this._collider2D = this.GetComponent<UnityEngine.Collider2D>();
                return val_3;
            }
            
            val_3 = this._collider2D;
            return val_3;
        }
        public UnityEngine.Rigidbody get_CachedRigidBody()
        {
            UnityEngine.Rigidbody val_3;
            if(this._rigidBody == 0)
            {
                    this._rigidBody = this.GetComponent<UnityEngine.Rigidbody>();
                return val_3;
            }
            
            val_3 = this._rigidBody;
            return val_3;
        }
        public UnityEngine.Rigidbody2D get_CachedRigidBody2D()
        {
            UnityEngine.Rigidbody2D val_3;
            if(this._rigidbody2D == 0)
            {
                    this._rigidbody2D = this.GetComponent<UnityEngine.Rigidbody2D>();
                return val_3;
            }
            
            val_3 = this._rigidbody2D;
            return val_3;
        }
        public UnityEngine.GameObject get_CachedGameObject()
        {
            UnityEngine.GameObject val_3;
            if(this._gameObject == 0)
            {
                    this._gameObject = this.gameObject;
                return val_3;
            }
            
            val_3 = this._gameObject;
            return val_3;
        }
        public UnityEngine.Transform get_transform()
        {
            return this.CachedTransform;
        }
        public UnityEngine.Collider get_collider()
        {
            return this.CachedCollider;
        }
        public UnityEngine.Collider2D get_collider2D()
        {
            return this.CachedCollider2D;
        }
        public UnityEngine.Rigidbody get_rigidbody()
        {
            return this.CachedRigidBody;
        }
        public UnityEngine.Rigidbody2D get_rigidbody2D()
        {
            return this.CachedRigidBody2D;
        }
        public UnityEngine.GameObject get_gameObject()
        {
            return this.CachedGameObject;
        }
        protected void AssertNotNull(object value, string fieldName)
        {
            SRDebugUtil.AssertNotNull(value:  value, message:  fieldName, instance:  this);
        }
        protected void Assert(bool condition, string message)
        {
            SRDebugUtil.Assert(condition:  condition, message:  message, instance:  this);
        }
        protected void EditorAssertNotNull(object value, string fieldName)
        {
            SRDebugUtil.AssertNotNull(value:  value, message:  fieldName, instance:  this);
        }
        protected void EditorAssert(bool condition, string message)
        {
            SRDebugUtil.Assert(condition:  condition, message:  message, instance:  this);
        }
        protected SRMonoBehaviour()
        {
        
        }
    
    }

}
