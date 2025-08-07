using UnityEngine;
using System;
using System.Collections.Generic;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Multiplayer;
using System.Threading.Tasks;

namespace mpw.Multiplayer
{
    public class MPWSessionManager : MonoBehaviour
    {
        ISession activeSession;
        public static event Action<string> OnSessionCodeObtained;

        ISession ActiveSession
        {
            get { return activeSession; }
            set
            {
                activeSession = value;
                Debug.Log("Active session! " + activeSession);
            }
        }
        const string playerNamePropertyKey = "playerName";

        public async Task SignInAndHostSession(string joinCode) 
        {
            try
            {
                await UnityServices.InitializeAsync();
                await AuthenticationService.Instance.SignInAnonymouslyAsync();
                Debug.Log($"Anonymous sign in succeeded. PlayerID: {AuthenticationService.Instance.PlayerId}");
                await JoinSessionByCode(joinCode);
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }


        public async Task SignInAndHostSession()
        {
            try
            {
                await UnityServices.InitializeAsync();
                await AuthenticationService.Instance.SignInAnonymouslyAsync();
                Debug.Log($"Anonymous sign in succeeded. PlayerID: {AuthenticationService.Instance.PlayerId}");
                StartSessionAsHost();
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }

        async Task<Dictionary<string, PlayerProperty>> GetPlayerProperties()
        {
            var playerName = await AuthenticationService.Instance.GetPlayerNameAsync();
            var playerNameProperty = new PlayerProperty(playerName, VisibilityPropertyOptions.Member);
            return new Dictionary<string, PlayerProperty> { { playerNamePropertyKey, playerNameProperty } };
        }

        async void StartSessionAsHost()
        {
            var playerProperties = await GetPlayerProperties();

            var options = new SessionOptions
            {
                MaxPlayers = 2,
                IsLocked = false,
                IsPrivate = false,
                PlayerProperties = playerProperties
            }.WithRelayNetwork();

            ActiveSession = await MultiplayerService.Instance.CreateSessionAsync(options);
            Debug.Log($"Session {ActiveSession.Id} created. Join code: {ActiveSession.Code}");
            OnSessionCodeObtained.Invoke(ActiveSession.Code);
        }
    
        async Task JoinSessionById(string sessionId) 
        {
            ActiveSession = await MultiplayerService.Instance.JoinSessionByIdAsync(sessionId);
            Debug.Log($"Session {ActiveSession.Id} joined!");
        }

        async Task JoinSessionByCode(string sessionCode)
        {
            ActiveSession = await MultiplayerService.Instance.JoinSessionByCodeAsync(sessionCode);
            Debug.Log($"Session {ActiveSession.Code} joined!");
            OnSessionCodeObtained.Invoke(ActiveSession.Code);
        }

        async Task KickPlayer(string playerId) 
        {
            if (!ActiveSession.IsHost) return;
            await ActiveSession.AsHost().RemovePlayerAsync(playerId);
        }
    
        async Task LeaveSession() 
        {
            if (ActiveSession != null) 
            {
                try
                {
                    await ActiveSession.LeaveAsync();
                }
                catch { }
                finally {
                    ActiveSession = null;
                }
            }
        }
    }
}
