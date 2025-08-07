using mpw.Entity;
using mpw.Multiplayer;
using UnityEngine;
using UnityEngine.UI;
namespace mpw.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] Canvas mainCanvas;
        [SerializeField] Transform tooltipHolder;
        [SerializeField] GameObject tooltipBaseObject;
        [SerializeField] GameObject ShopPrompt;
        [SerializeField] GameObject CustomizePrompt;

        [SerializeField] UI_CharacterCustomization CustomizationPanel;
        [SerializeField] UI_Shop shopPanel;
        [SerializeField] UI_MultiplayerLobby UI_MultiplayerLobby;

        private UI_Tooltip tooltipInstance;
        private UI_ContainerBase currentContainer;
        private bool EnableShopToggle;

        public Canvas MainCanvas;
        public UI_Shop ShopPanel => shopPanel;

        private void Start()
        {
            MPWSessionManager.OnSessionCodeObtained += OnSessionCodeObtained;
        }

        private void OnDisable()
        {
            MPWSessionManager.OnSessionCodeObtained -= OnSessionCodeObtained;
        }

        public void OnSessionCodeObtained(string code) 
        {
            CustomizePrompt.gameObject.SetActive(true);
            UI_MultiplayerLobby.SetupJoinCode(code);
        }

        private void Update()
        {
            if (MPWApp.Instance.LocalPlayer == null) return;
            if (Input.GetKeyDown(KeyCode.E))
            {
                ToggleUI("CC");
            }
            if (Input.GetKeyDown(KeyCode.Q) && EnableShopToggle)
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
                HideTooltip();
            } 

            Entity_PlayerMovement.Entity_PlayerMovementData playerMovement = MPWApp.Instance.LocalPlayer.Movement as Entity_PlayerMovement.Entity_PlayerMovementData;
            playerMovement.InputBlocked = shouldEnable;
        }

        public void ToggleShopPrompt(bool targetState) 
        {
            ShopPrompt.gameObject.SetActive(targetState);
            EnableShopToggle = targetState;
        }

        public void ShowTooltip(string message1, string message2)
        {
            if (tooltipInstance == null)
            {
                tooltipInstance = Instantiate(tooltipBaseObject, tooltipHolder).GetComponent<UI_Tooltip>();
            }
            tooltipInstance.SetTexts(message1, message2);

            LayoutRebuilder.ForceRebuildLayoutImmediate(tooltipInstance.transform as RectTransform);
            tooltipInstance.gameObject.SetActive(true);
        }

        public void HideTooltip()
        {
            tooltipInstance?.gameObject.SetActive(false);
        }
    }
}