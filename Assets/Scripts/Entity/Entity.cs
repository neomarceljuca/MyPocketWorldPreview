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
        private readonly List<EntityComponent.EntityComponentData> componentsData = new();

        public EntityReferences References => references ? references : references = GetComponent<EntityReferences>();

        private Entity_Movement.EntityMovementData m_Movement;

        public Entity_Movement.EntityMovementData Movement => m_Movement;
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
            for (i = 0; i < componentsData.Count; i++)
                componentsData[i].Start();
        }

        protected virtual void Update()
        {
            for (i = 0; i < componentsData.Count; i++)
                componentsData[i].Update();
        }
        protected virtual void LateUpdate()
        {
            for (i = 0; i < componentsData.Count; i++)
                componentsData[i].LateUpdate();
        }
        protected virtual void FixedUpdate()
        {
            for (i = 0; i < componentsData.Count; i++)
                componentsData[i].FixedUpdate();
        }
        #endregion

        #region Utilities
        protected void HandleCreateComponentData<T>(ref T componentData, EntityComponent parameters) where T : EntityComponent.EntityComponentData 
        {
            if (parameters == null) return;
            componentData = parameters.BuildComponent(this) as T;
            componentsData.Add(componentData);
        }

        protected void HandleComponentsInnit() 
        {
            HandleCreateComponentData(ref m_Movement, entityMovement);
        }
        //void HandleMultiplayerComponentsInnit() { } TO DO: When implementing multiplayer sync
        #endregion
    }
}
