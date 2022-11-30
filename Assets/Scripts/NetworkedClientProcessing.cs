using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class NetworkedClientProcessing
{

   
    static public void ProcessRecievedMsg(string msg, int id)
    {
        Debug.Log("msg recieved = " + msg + ".  connection id = " + id);

        string[] msgs = msg.Split(',');
        int signifier = int.Parse(msgs[0]);
        if (signifier == ServerFeedBackSignifierList.LoginSuccess)
        {
            _gameManager.LoginToRoomJoinPanel();
        }
        else if (signifier == ServerFeedBackSignifierList.JoinRoomAsPlayer1)// || signifier == ServerFeedBackSignifierList.JoinRoomAsObserver)
        {
            _gameManager.EnterRoomAsFirstPlayerState(msgs[1], msgs[2]);
        }
        else if (signifier == ServerFeedBackSignifierList.JoinRoomAsPlayer2)
        {
            _gameManager.EnterRoomAsSecondPlayerState(msgs[1], msgs[2], msgs[3]);
        }
        else if (signifier == ServerFeedBackSignifierList.GameUpdate)
        {
            _gameManager.UpdateGame(msgs);
        }
    }
    static public void SendMessageToHost(string msg)
    {
        networkedClient.SendMessageToHost(msg);
    }

    #region Setup
    static NetworkedClient networkedClient;
    static GameManager _gameManager;

    static public void SetNetworkedClient(NetworkedClient NetworkedClient)
    {
        networkedClient = NetworkedClient;
    }
    static public NetworkedClient GetNetworkedClient()
    {
        return networkedClient;
    }
    static public void SetGameLogic(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    #endregion

    #region Protocol Signifiers
    static public class ServerFeedBackSignifierList
    {
        public const int LoginSuccess = 0;
        public const int LoginFailure = 1;
        public const int CreateAccountSuccess = 2;
        public const int CreateAccountFailure = 3;
        public const int JoinRoomAsPlayer1 = 4;
        public const int JoinRoomAsPlayer2 = 5;
        public const int GameUpdate = 6;
    }

    #endregion

}
