using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkedClientProcessing : MonoBehaviour
{
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

    private void ProcessRecievedMsg(string msg, int id)
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
}
