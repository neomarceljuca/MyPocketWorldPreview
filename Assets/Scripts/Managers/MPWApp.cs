using mpw.Entity;
using mpw.UI;
using mpw.Utils;
using mpw.Multiplayer;
using UnityEngine;

public class MPWApp : Singleton<MPWApp>
{

    [SerializeField] private UIManager m_UIManager;
    [SerializeField] private MPWSessionManager m_SessionManager;

    [SerializeField] private MpwResources mpwResources;

    public UIManager UIManager => m_UIManager;
    public MPWSessionManager SessionManager => m_SessionManager;

    public Entity LocalPlayer => localPlayer;
    public MpwResources MpwResources => mpwResources;

    private Entity localPlayer;

    protected override void Awake()
    {
        base.Awake();
        //InnitPlayer();
    }

    void InnitPlayer() 
    {
        localPlayer.Innit(true);
    }
}
