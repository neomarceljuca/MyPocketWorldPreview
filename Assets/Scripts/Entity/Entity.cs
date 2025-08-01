using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;

namespace mpw.Entity 
{
    public class Entity : MonoBehaviour
    {
        #region variables
        [TabGroup("Tab", "Components"), SerializeField] private Entity_Movement entityMovement;
        private EntityReferences references;
        private readonly List<EntityComponent> components = new();

        public EntityReferences References => references ? references : references = GetComponent<EntityReferences>();
        #endregion
        #region Behaviour
        int i;
        private void Awake()
        {
            HandleComponentsInnit();
        }

        void Start()
        {
            StartEntity();
        }

        public virtual void StartEntity()
        {
            for (i = 0; i < components.Count; i++)
                components[i].Start();
        }

        protected virtual void Update()
        {
            for (i = 0; i < components.Count; i++)
                components[i].Update();
        }
        protected virtual void LateUpdate()
        {
            for (i = 0; i < components.Count; i++)
                components[i].LateUpdate();
        }
        protected virtual void FixedUpdate()
        {
            for (i = 0; i < components.Count; i++)
                components[i].FixedUpdate();
        }
        #endregion

        #region Utilities
        void HandleComponentsInnit() 
        {
            components.Add(entityMovement);
            entityMovement.Entity = this;
        }
        //void HandleMultiplayerComponentsInnit() { } TO DO: When implementing multiplayer sync
        #endregion
    }
}
