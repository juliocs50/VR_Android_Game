using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class NetworkMultplayer : MonoBehaviour {
    public string ServidorIP= "localhost";
    public Text ServidorIPText;
	// Use this for initialization
	public void StartGame()
    {

       // NetworkManager.singleton.StartHost();
    }
    public void JoinGame()
    {
      //  NetworkManager.singleton.networkAddress = ServidorIP;
      //  NetworkManager.singleton.StartClient();

    }

}
