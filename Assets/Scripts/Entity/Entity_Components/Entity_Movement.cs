using Sirenix.OdinInspector;
using UnityEngine;

namespace mpw.Entity
{
    [CreateAssetMenu(fileName = "Entity Movement", menuName = "mpw/Entity/Components/Movement")]
    public class Entity_Movement : EntityComponent
    {
        #region variables
        [SerializeField] protected float baseSpeed;
        protected Vector3 movementDirection; //for controlling rotation and getting base input
        private Vector3 deltaMoveDirection; //for calculated movement After Gravity
        protected Transform targetTransform;
        protected CharacterController controller;

        private Vector3 simulatedGravity = Vector3.down * 5f;
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
            deltaMoveDirection = movementDirection;

            if(movementDirection != Vector3.zero)
                targetTransform.rotation = Quaternion.LookRotation(movementDirection);

            if (!controller.isGrounded)
                deltaMoveDirection += simulatedGravity;
            controller.Move(deltaMoveDirection * baseSpeed * Time.deltaTime);
        }
        #endregion
    }
}
