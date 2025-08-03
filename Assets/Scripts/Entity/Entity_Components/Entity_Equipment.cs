using Sirenix.OdinInspector;
using UnityEngine;
using mpw.InventorySystem;
using System.Collections.Generic;

namespace mpw.Entity
{
    [CreateAssetMenu(fileName = "Entity Equipment", menuName = "mpw/Entity/Components/Equipment")]
    public class Entity_Equipment : EntityComponent
    {
        public override EntityComponentData BuildComponent(Entity entity) => new Entity_EquipmentData(entity, this);
        public class Entity_EquipmentData: EntityComponentData 
        {
            public Entity_EquipmentData(Entity entity, Entity_Equipment parameters) : base(entity)
            {
                this.parameters = parameters;
            }
            private readonly Entity_Equipment parameters;
            public Entity_Equipment Parameters => parameters;

            #region variables
            Dictionary<EquipmentCategory, EquipmentParameters> equipped = new();

            #endregion

            public override void Start()
            {
                base.Start();
                Innit();
            }

            public void Innit() 
            {
                foreach (var equip in Entity.References.StartingEquipmentTest.Items)
                {
                    EquipItem(equip as EquipmentParameters);
                }

                RefreshEquipment();
            }

            public void RefreshEquipment() 
            {
                foreach (var item in equipped) 
                {
                    SetSocket(item.Value);
                }
            }

            public void EquipItem(EquipmentParameters parameters) 
            {
                equipped[parameters.Category] = parameters;
                SetSocket(parameters);
            }

            void SetSocket(EquipmentParameters parameters) 
            {
                SkinnedMeshRenderer targetMeshRenderer = Entity.References.ModelsPerCategory[parameters.Category];
                targetMeshRenderer.sharedMesh = parameters.Mesh;

                if (parameters.Material != null) 
                {
                    targetMeshRenderer.material = parameters.Material;
                    //to do: apply stored instance data instead
                    targetMeshRenderer.material.SetColor("_mainColor", parameters.DefaultColor); // Show flat color

                }

            }
        }

    }
}
