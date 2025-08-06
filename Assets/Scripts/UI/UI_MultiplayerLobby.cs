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
        gameObject.SetActive(false);
    }

    public void Button_Join() 
    {
        _ = sessionManager.SignInAndHostSession(joinCode.text);
        gameObject.SetActive(false);
    }
}
