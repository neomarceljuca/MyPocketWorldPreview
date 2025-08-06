using mpw.Entity;
using mpw.UI;
using mpw.Utils;
using mpw.Multiplayer;
using UnityEngine;
using Unity.Netcode;
using NUnit.Framework;
using System.Collections.Generic;

public class MPWApp : Singleton<MPWApp>
{

    [SerializeField] private UIManager m_UIManager;
    [SerializeField] private MPWSessionManager m_SessionManager;

    [SerializeField] private MpwResources mpwResources;

    public UIManager UIManager => m_UIManager;
    public MPWSessionManager SessionManager => m_SessionManager;

    public Entity LocalPlayer => localPlayer;

    private NetworkManager _networkManager => NetworkManager.Singleton;
    public bool IsServer => _networkManager && Instance._networkManager.IsServer;
    public bool IsClient => _networkManager && !Instance._networkManager.IsServer;
    public MpwResources MpwResources => mpwResources;

    private Entity localPlayer;
    private List<Entity> currentPlayers = new();

    protected override void Awake()
    {
        base.Awake();
    }

    public void OnSpawnPlayer(Entity player, bool isLocalPlayer) 
    {
        if (isLocalPlayer) localPlayer = player;
        currentPlayers.Add(player);
    }

    public void OnPlayerDestroy(Entity player) 
    {
        currentPlayers.Remove(player);
    }


}
