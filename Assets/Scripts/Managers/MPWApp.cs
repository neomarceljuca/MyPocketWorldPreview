using mpw.Entity;
using mpw.UI;
using mpw.Utils;
using UnityEngine;

public class MPWApp : MonoBehaviour
{
    public static MPWApp Instance;

    [SerializeField] private UIManager m_UIManager;
    [SerializeField] private GameObject playerPrefab;

    [SerializeField] private MpwResources mpwResources;

    public UIManager UIManager => m_UIManager;

    public Entity LocalPlayer => localPlayer;
    public MpwResources MpwResources => mpwResources;

    private Entity localPlayer;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); 
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        InnitPlayer();
    }

    void InnitPlayer() 
    {
        localPlayer = Instantiate(playerPrefab).GetComponent<Entity>();
    }
}
