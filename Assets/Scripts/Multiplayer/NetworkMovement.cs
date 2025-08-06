using Unity.Netcode;
using UnityEngine;

namespace mpw.Multiplayer
{
    public class NetworkMovement : NetworkBehaviour
    {
        private Vector3 deltaDisplacement;

        public void HandleMovement(Vector3 movementDirection, float baseSpeed) 
        {
            if (!IsOwner || !IsSpawned) return;

            deltaDisplacement = movementDirection;

            if (movementDirection != Vector3.zero)
                transform.rotation = Quaternion.LookRotation(movementDirection);

            transform.position += deltaDisplacement * (Time.deltaTime * baseSpeed);
        }
    }
}
