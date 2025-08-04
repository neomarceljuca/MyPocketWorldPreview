using UnityEngine;

namespace mpw.UI 
{
public class UI_ContainerBase : MonoBehaviour
{
        private void Start()
        {
            gameObject.SetActive(false);
        }


        public virtual void Show()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
