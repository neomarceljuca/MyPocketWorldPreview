using mpw.Entity;
using UnityEngine;
using UnityEngine.UI;
namespace mpw.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] Canvas mainCanvas;
        [SerializeField] Transform tooltipHolder;
        [SerializeField] GameObject tooltipBaseObject;

        [SerializeField] UI_CharacterCustomization CustomizationPanel;
        [SerializeField] UI_Shop ShopPanel;

        private UI_Tooltip tooltipInstance;
        private UI_ContainerBase currentContainer;

        public Canvas MainCanvas;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ToggleUI("CC");
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                ToggleUI("Shop");
            }
        }

        public void ToggleUI(string uiType)
        {
            UI_ContainerBase targetContainer = null;
            switch (uiType) 
            {
                case "CC":
                    targetContainer = CustomizationPanel;
                    break;
                case "Shop":
                    targetContainer = ShopPanel;
                    break;
            }
            bool shouldEnable = !targetContainer.gameObject.activeSelf;

            if (shouldEnable)
            {
                if (currentContainer != null) return;
                currentContainer = targetContainer;
                targetContainer.Show();
            }
            else 
            {
                currentContainer = null;
                targetContainer.Hide();
            } 

            Entity_PlayerMovement.Entity_PlayerMovementData playerMovement = MPWApp.Instance.LocalPlayer.Movement as Entity_PlayerMovement.Entity_PlayerMovementData;
            playerMovement.InputBlocked = shouldEnable;
        }

        public void ShowTooltip(string message)
        {
            if (tooltipInstance == null)
            {
                tooltipInstance = Instantiate(tooltipBaseObject, tooltipHolder).GetComponent<UI_Tooltip>();
            }
            tooltipInstance.SetTexts(message);

            LayoutRebuilder.ForceRebuildLayoutImmediate(tooltipInstance.transform as RectTransform);
            tooltipInstance.gameObject.SetActive(true);
        }

        public void HideTooltip()
        {
            tooltipInstance?.gameObject.SetActive(false);
        }
    }
}