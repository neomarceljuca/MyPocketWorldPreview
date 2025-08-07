using UnityEngine;
using mpw.Multiplayer;
using TMPro;
using UnityEngine.UI;

public class UI_MultiplayerLobby : MonoBehaviour
{
    [SerializeField] MPWSessionManager sessionManager;

    [SerializeField] Button hostButton;
    [SerializeField] TMP_InputField joinCode;
    [SerializeField] Button joinButton;


    public void Button_Host() 
    {
        _ = sessionManager.SignInAndHostSession();
        SetOnlineState();
    }

    public void Button_Join() 
    {
        _ = sessionManager.SignInAndHostSession(joinCode.text);
        SetOnlineState();
    }

    private void SetOnlineState() 
    {
        hostButton.interactable = false;
        joinCode.interactable = false;
        joinButton.interactable = false;
    }

    public void SetupJoinCode(string code) 
    {
        joinCode.text = code;
        joinCode.interactable = false;
    } 
}
