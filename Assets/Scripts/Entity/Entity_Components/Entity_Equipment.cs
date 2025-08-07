using Sirenix.OdinInspector;
using UnityEngine;
using mpw.InventorySystem;
using System.Collections.Generic;
using mpw.Multiplayer;

namespace mpw.Entity
{
    [CreateAssetMenu(fileName = "Entity Equipment", menuName = "mpw/Entity/Components/Equipment")]
    public class Entity_Equipment : EntityComponent
    {
        public override EntityComponentData BuildComponent(Entity entity) => new Entity_EquipmentData(entity, this);
        public class Entity_EquipmentData : EntityComponentData
        {
            public Entity_EquipmentData(Entity entity, Entity_Equipment parameters) : base(entity)
            {
                this.parameters = parameters;
            }
            private readonly Entity_Equipment parameters;
            public Entity_Equipment Parameters => parameters;

            #region variables
            Dictionary<EquipmentCategory, EquipmentParameters.EquipmentData> equipped = new();

            public Dictionary<EquipmentCategory, EquipmentParameters.EquipmentData> Equipped => equipped;
            #endregion

            public override void Start()
            {
                base.Start();
                Innit();
            }

            public void Innit()
            {
                ItemGroup equipmentToBeLoaded = null;

                if (equipmentToBeLoaded == null)
                {
                    equipmentToBeLoaded = Entity.References.StartingEquipment;
                }

                if (equipmentToBeLoaded != null)
                {

                    foreach (var equip in equipmentToBeLoaded.Items)
                    {
                        EquipItem(equip as EquipmentParameters);
                    }
                }
            }

            public void RefreshEquipment()
            {
                foreach (var item in equipped)
                {
                    SetSocket(item.Value);
                }
            }

            public void CopyLoadout(Entity_EquipmentData otherEntityEquipmentData)
            {
                foreach (var equipment in otherEntityEquipmentData.Equipped)
                {
                    EquipItem(equipment.Value);
                }
            }

            public void EquipItem(EquipmentParameters parameters)
            {
                EquipItem(parameters.DefaultItemData as EquipmentParameters.EquipmentData);
            }
            public void EquipItem(EquipmentParameters.EquipmentData data)
            {
                equipped[data.Parameters.Category] = data;
                SetSocket(data);
            }

            void SetSocket(EquipmentParameters.EquipmentData data)
            {
                SkinnedMeshRenderer targetMeshRenderer = Entity.References.ModelsPerCategory[data.Parameters.Category];
                NetworkEquipment networkEquipment = targetMeshRenderer.GetComponent<NetworkEquipment>();
                if (networkEquipment != null) 
                {
                    networkEquipment.Equip(data.Parameters, Entity.IsNPC);
                }    
            }

            public bool isEquipping(EquipmentParameters.EquipmentData data) 
            {
                return equipped.ContainsValue(data);

            }

        }
    }
}
