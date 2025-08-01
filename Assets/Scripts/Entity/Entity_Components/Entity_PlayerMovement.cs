using System;
using UnityEngine;

namespace mpw.Entity
{
    [CreateAssetMenu(fileName = "Player Movement", menuName = "mpw/Entity/Components/PlayerMovement")]
    public class Entity_PlayerMovement : Entity_Movement
    {
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
