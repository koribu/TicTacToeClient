using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class InputManager : MonoBehaviour
{
    static public class ClientMessageSignifierList
    {
        public const int Login = 0;
        public const int CreateAccount = 1;
        public const int JoinRoom = 2;
    }

    [SerializeField]
    private GameObject _usernameInput, _passwordInput, _roomNameInput, _loginButton, _createAccountButton;
    [SerializeField]
    NetworkedClient _networkClient;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SendLoginInfo()
    {
        string username = _usernameInput.GetComponent<TMP_InputField>().text;
        string password = _passwordInput.GetComponent<TMP_InputField>().text;
        if (username.Length > 3 && password.Length > 3)
        {
            _networkClient.SendMessageToHost(ClientMessageSignifierList.Login + "," + username + "," + password);
            Debug.Log(0 + "," + username + "," + password);
        }
    }
    public void CreateAccount()
    {
        string username = _usernameInput.GetComponent<TMP_InputField>().text;
        string password = _passwordInput.GetComponent<TMP_InputField>().text;
        if (username.Length > 3 && password.Length > 3)
        {
            _networkClient.SendMessageToHost(ClientMessageSignifierList.CreateAccount + "," + username + "," + password);
        }
        Debug.Log(1 + "," + username + "," + password);
    }

    public void RoomJoinInfo()
    {
        string roomName = _roomNameInput.GetComponent<TMP_InputField>().text;

        if (roomName.Length > 3)
        {
            _networkClient.SendMessageToHost(ClientMessageSignifierList.JoinRoom + "," + roomName);
        }
    }
}
