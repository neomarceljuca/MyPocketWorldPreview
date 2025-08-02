using System;
using UnityEngine;

namespace mpw.Entity
{
    [CreateAssetMenu(fileName = "Player Movement", menuName = "mpw/Entity/Components/PlayerMovement")]
    public class Entity_PlayerMovement : Entity_Movement
    {
        public override EntityComponentData BuildComponent(Entity entity) => new Entity_PlayerMovementData(entity, this);

        public class Entity_PlayerMovementData : EntityMovementData
        {
            public Entity_PlayerMovementData(Entity entity, Entity_PlayerMovement parameters) : base(entity, parameters)
            {
                this.parameters = parameters;
            }
            private Entity_PlayerMovement parameters;
            public new Entity_PlayerMovement Parameters => parameters;

            #region Behaviour
            public override void Start()
            {
                base.Start();
            }

            public override void Update()
            {
                HandleMovement();
            }
            #endregion
            #region Utilities
            protected override void HandleMovement()
            {
                float horizontal = Input.GetAxis("Horizontal");
                float vertical = Input.GetAxis("Vertical");

                movementDirection = new Vector3(horizontal, 0, vertical).normalized;
                base.HandleMovement();
            }
            #endregion
        }
    }
}
