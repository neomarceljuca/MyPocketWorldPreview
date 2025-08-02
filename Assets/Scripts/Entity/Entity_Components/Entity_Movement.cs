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
            private Vector3 deltaMoveDirection; //for calculated movement After Gravity
            protected Transform targetTransform;
            protected CharacterController controller;

            private Vector3 simulatedGravity = Vector3.down * 9.81f;
            #endregion
            #region Behaviour
            public override void Start()
            {
                base.Start();
                controller = Entity.References.Controller;
                targetTransform = Entity.References.BodyTransform;
            }
            #endregion
            #region Utilities
            protected virtual void HandleMovement()
            {
                deltaMoveDirection = movementDirection * Parameters.baseSpeed;

                if (movementDirection != Vector3.zero)
                    targetTransform.rotation = Quaternion.LookRotation(movementDirection);

                if (!controller.isGrounded)
                    deltaMoveDirection += simulatedGravity;
                controller.Move(deltaMoveDirection  * Time.deltaTime);
            }
            #endregion
        }
    }
}
