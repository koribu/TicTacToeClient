using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;



public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject _loginPanel, _roomLoginPanel, _gamePanel;
    [SerializeField]
    TextMeshProUGUI player1Name, player2Name, roomName;

    [SerializeField]
    TextMeshProUGUI[] gameButtons;
    [SerializeField]
    NetworkedClient _networkClient;

    private int[] gameStatus = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

    bool isFirstPlayer, isGameStart = false;
    int isYourTurn = 0;
    // Start is called before the first frame update
    void Start()
    {
        isFirstPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoginToRoomJoinPanel()
    {
        _loginPanel.SetActive(false);
        _roomLoginPanel.SetActive(true);
    }

    public void EnterRoomAsFirstPlayerState(string playerName,string name)
    {
        Debug.Log("First player enter to the room");
        _roomLoginPanel.SetActive(false);
        _gamePanel.SetActive(true);
        Debug.Log(playerName + "---" + name);
        roomName.text = name;
        player1Name.text = playerName;

        isFirstPlayer = true;
        isYourTurn = 1;
    }
    public void EnterRoomAsSecondPlayerState(string currentPlayerName,string otherPlayerName, string name)
    {
        Debug.Log("Second player enter to the room");
        _roomLoginPanel.SetActive(false);
        _gamePanel.SetActive(true);

        player1Name.text = currentPlayerName;
        player2Name.text = otherPlayerName;
        roomName.text = name;

        isGameStart = true;
    }
    public void LeaveRoomState()
    {
        _roomLoginPanel.SetActive(true);
        _gamePanel.SetActive(false);
    }

    public void PlayMove(int i)
    {
        if (!isGameStart)
        {
            Debug.Log("Game not ready to start");
            return;
        }
        if (isYourTurn == 0 )
        {
            Debug.Log("it is not your turn");
            return;
        }
       
           
        if (isFirstPlayer)
            gameButtons[i].text = "X";
        else
            gameButtons[i].text = "O";

        _networkClient.SendMessageToHost(ClientMessageSignifierList.GameUpdate + "," + i);
    }

    public void UpdateGame(string[] msgs)
    {
        isYourTurn = int.Parse(msgs[1]);
        Debug.Log("Game updated by server");

        for (int i = 0; i < gameButtons.Length; i++)
        {
            int spotCondition = int.Parse(msgs[i + 3]);
            if (spotCondition == 0)
                gameButtons[i].text = "";
            else if (spotCondition == 1)
                gameButtons[i].text = "X";
            else 
                gameButtons[i].text = "O";
        }

        if (int.Parse(msgs[2]) == 1)
        {
            Debug.Log("GameEnded");
            isGameStart = false;
            //LeaveRoomState();
        }
           
    }


}
