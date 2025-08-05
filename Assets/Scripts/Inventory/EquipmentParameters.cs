using Sirenix.OdinInspector;
using System;
using UnityEngine;
namespace mpw.InventorySystem
{
    [CreateAssetMenu(fileName = "Item_", menuName = "mpw/Inventory/Item_Equipment")]
    public class EquipmentParameters : ItemParameters
    {
        [BoxGroup("Equipment"), SerializeField] private EquipmentCategory category;
        [BoxGroup("Equipment"), HideIf("IsOffSetTexture"), SerializeField] private Mesh mesh;
        [BoxGroup("Equipment"), SerializeField] private Color defaultColor;
        [BoxGroup("Equipment"), SerializeField] private Material material;
        [BoxGroup("Equipment"), ShowIf("IsOffSetTexture"), SerializeField] Vector2Slider textureOffset;

        public override Sprite DisplayIcon => iconOverride == null? MPWApp.Instance.MpwResources.GetSocketSprite(category) : iconOverride;
        public Mesh Mesh => mesh;
        public Color DefaultColor => defaultColor;
        public EquipmentCategory Category => category;
        public Material Material => material;
        public Vector2 TextureOffset => textureOffset.Value;

        public bool IsOffSetTexture => category == EquipmentCategory.Eyes || category == EquipmentCategory.Cheeks || category == EquipmentCategory.Mouth;
        public override ItemData DefaultItemData => new EquipmentData(this);
        public class EquipmentData : ItemData
        {
            private Color colorData;

            public new EquipmentParameters Parameters => base.Parameters as EquipmentParameters;

            public Color ColorData
            {
                get
                {
                    return colorData;
                }
                set
                {
                    colorData = value;
                }
            }

            public EquipmentData() { }
            public EquipmentData(EquipmentParameters parameters) : base(parameters) 
            {
                colorData = parameters.DefaultColor;
            }
        }
    }

    [System.Serializable]
    public struct Vector2Slider
    {
        [Range(0f, 1f)] public float x;
        [Range(0f, 1f)] public float y;

        public Vector2 Value => new Vector2(x, y);
    }

    [Serializable] //to do (low prio): improve by adding Flag enums to support 'all' correctly.
    public enum EquipmentCategory 
    {
        Hair,
        Eyes,
        Cheeks,
        Mouth,
        Top,
        Bottom,
        Shoes,
        All
    }
}
