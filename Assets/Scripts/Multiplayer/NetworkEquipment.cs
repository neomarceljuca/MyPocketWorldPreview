using Unity.Netcode;
using UnityEngine;
using mpw.InventorySystem;
using mpw.Entity;

namespace mpw.Multiplayer
{
    public class NetworkEquipment : NetworkBehaviour
    {
        [SerializeField] private SkinnedMeshRenderer meshRenderer;

        public NetworkVariable<int> equippedItemID = new(writePerm: NetworkVariableWritePermission.Owner);

        public override void OnNetworkSpawn()
        {
            equippedItemID.OnValueChanged += (_, newValue) => ApplyVisual(newValue);
            ApplyVisual(equippedItemID.Value);
        }
        private void ApplyVisual(int id)
        {
            EquipmentParameters equip = MPWApp.Instance.MpwResources.EquipmentDatabase.GetByID(id);
            if (equip != null)
            {
                if (equip.Material != null)
                {
                    meshRenderer.material = equip.Material;
                    meshRenderer.material.SetColor("_mainColor", equip.DefaultColor); // Show flat color
                }
                if (equip.IsOffSetTexture)
                {
                    meshRenderer.material.SetVector("_offset", new(equip.TextureOffset.x, equip.TextureOffset.y));
                }
                meshRenderer.sharedMesh = equip.Mesh;
            }
        }

        public void Equip(EquipmentParameters parameters, bool isNPC)
        {
            if (isNPC)
                ApplyVisual(MPWApp.Instance.MpwResources.EquipmentDatabase.GetID(parameters));

            else if (!IsOwner) return;
            int id = MPWApp.Instance.MpwResources.EquipmentDatabase.GetID(parameters);
            if (id >= 0)
            {
                equippedItemID.Value = id;
            }
        }
    }
}
