using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using Unity.Netcode;

namespace mpw.Entity 
{
    public class Entity : MonoBehaviour
    {
        #region variables
        [TabGroup("Tab", "Components"), SerializeField] private Entity_Movement entityMovement;
        [TabGroup("Tab", "Components"), SerializeField] private Entity_Equipment entityEquipment;

        [TabGroup("Tab", "References"), SerializeField] private EntityReferences references;
        [TabGroup("Tab", "Setup"), SerializeField] private bool isNPC;


        private readonly List<EntityComponent.EntityComponentData> componentsData = new();

        public EntityReferences References => references;
        public bool IsNPC => isNPC;

        private Entity_Movement.EntityMovementData m_Movement;
        private Entity_Equipment.Entity_EquipmentData m_Equipment;
        private NetworkObject m_networkObject;

        public Entity_Movement.EntityMovementData Movement => m_Movement;
        public Entity_Equipment.Entity_EquipmentData Equipment => m_Equipment;

        public bool IsLocalPlayer => m_networkObject != null && m_networkObject.IsLocalPlayer;
        #endregion
        #region Behaviour
        int i;
        protected virtual void Awake()
        {
            HandleComponentsInnit();
            m_networkObject = GetComponent<NetworkObject>();
        }

        protected virtual void Start()
        {
            if(!isNPC)
                MultiplayerSetup();
            StartEntity();
        }
        void MultiplayerSetup() 
        {
            MPWApp.Instance.OnSpawnPlayer(this, IsLocalPlayer);
            if (IsLocalPlayer) 
            {
                References.Inventory.InnitData(References.StartingInventory, 100);
            }
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


        protected virtual void OnDestroy() 
        {
            if (IsLocalPlayer) MPWApp.Instance.OnPlayerDestroy(this);
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
            HandleCreateComponentData(ref m_Equipment, entityEquipment);
        }
        //void HandleMultiplayerComponentsInnit() { } TO DO: When implementing multiplayer sync
        #endregion
    }
}
