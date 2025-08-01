using Sirenix.OdinInspector;
using UnityEngine;
namespace mpw.Entity
{

    public class EntityComponent : SerializedScriptableObject
    {
        private Entity entity;

        public Entity Entity
        {
            get { return entity; }
            set { entity = value; }
        }
        public virtual void Start() => HandleSubscribeToPersistentEvents(true);
        public virtual void OnEnable()
        {
            HandleSubscribeToEvents(true);
        }
        public virtual void OnDisable()
        {
            HandleSubscribeToEvents(false);
        }
        public virtual void OnDestroy() => HandleSubscribeToPersistentEvents(false);
        public virtual void Update() { }
        public virtual void LateUpdate() { }
        public virtual void FixedUpdate() { }


        #region Events
        protected virtual void HandleSubscribeToEvents(bool subscribe) { }
        protected virtual void HandleSubscribeToPersistentEvents(bool subscribe) { }
        #endregion
    }
}
