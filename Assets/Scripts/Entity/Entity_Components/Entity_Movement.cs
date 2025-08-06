using mpw.Multiplayer;
using Sirenix.OdinInspector;
using UnityEngine;

namespace mpw.Entity
{
    [CreateAssetMenu(fileName = "Entity Movement", menuName = "mpw/Entity/Components/Movement")]
    public class Entity_Movement : EntityComponent
    {
        [SerializeField] protected float baseSpeed;
        public override EntityComponentData BuildComponent(Entity entity) => new EntityMovementData(entity, this);

        public class EntityMovementData : EntityComponentData
        {
            public EntityMovementData(Entity entity, Entity_Movement parameters) : base(entity)
            {
                this.parameters = parameters;
            }
            private readonly Entity_Movement parameters;
            public Entity_Movement Parameters => parameters;

            #region variables
            protected Vector3 movementDirection; //for controlling rotation and getting base input
            #endregion
            #region Behaviour
            public override void Start()
            {
                base.Start();     
            }
            #endregion
            #region Utilities
            protected virtual void HandleMovement()
            {
                Entity.References.NetworkController.HandleMovement(movementDirection, Parameters.baseSpeed);
            }
            #endregion
        }
    }
}
