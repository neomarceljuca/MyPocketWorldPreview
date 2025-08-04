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

        private UI_Tooltip tooltipInstance;

        public Canvas MainCanvas;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ToggleUI(""); //to do: improve panels management and control
            }
        }

        public void ToggleUI(string uiType)
        {
            bool shouldEnable = !CustomizationPanel.gameObject.activeSelf;

            if (shouldEnable) CustomizationPanel.Show();
            else CustomizationPanel.Hide();

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