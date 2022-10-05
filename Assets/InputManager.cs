using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class InputManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _usernameInput, _passwordInput, _loginButton, _createAccountButton;
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
            _networkClient.SendMessageToHost(0 + "," + username + "," + password);
            Debug.Log(0 + "," + username + "," + password);
        }
    }
    public void CreateAccount()
    {
        string username = _usernameInput.GetComponent<TMP_InputField>().text;
        string password = _passwordInput.GetComponent<TMP_InputField>().text;
        if (username.Length > 3 && password.Length > 3)
        {
            _networkClient.SendMessageToHost(1 + "," + username + "," + password);
        }
        Debug.Log(1 + "," + username + "," + password);
    }
}
