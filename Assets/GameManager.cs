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

    // Start is called before the first frame update
    void Start()
    {
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
        _roomLoginPanel.SetActive(false);
        _gamePanel.SetActive(true);
        Debug.Log(playerName + "---" + name);
        roomName.text = name;
        player1Name.text = playerName;
    }
    public void EnterRoomAsSecondPlayerState(string currentPlayerName,string otherPlayerName, string name)
    {
        _roomLoginPanel.SetActive(false);
        _gamePanel.SetActive(true);

        player1Name.text = currentPlayerName;
        player2Name.text = otherPlayerName;
        roomName.text = name;
    }
    public void LeaveRoomState()
    {
        _roomLoginPanel.SetActive(true);
        _gamePanel.SetActive(false);
    }

    public void PlayMove(int i)
    {
        gameButtons[i].text = "X";
    }


}
