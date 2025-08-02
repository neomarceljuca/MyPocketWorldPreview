using mpw.UI;
using UnityEngine;

public class MPWApp : MonoBehaviour
{
    public static MPWApp Instance;

    [SerializeField] private UIManager m_UIManager;

    public UIManager UIManager => m_UIManager;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
