using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject _loginPanel, _roomLoginPanel;
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
  
}
