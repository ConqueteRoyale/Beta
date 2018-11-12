using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NetworkManager_Custom : NetworkManager {

	public void StartupHost(){
        SetPort();
        NetworkManager.singleton.StartHost();
    }

    public void JoinGame(){
        SetIpAddress();
        SetPort();
        NetworkManager.singleton.StartClient();
    }

    public void SetIpAddress(){
        string ipAddress = GameObject.Find("InputFieldIPAddress").transform.Find("Text").GetComponent<Text>().text;
        NetworkManager.singleton.networkAddress = ipAddress;
    }
    void SetPort(){
        NetworkManager.singleton.networkPort = 7777;
    }

}
