using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Characters.FirstPerson;
public class PLayer_Network : NetworkBehaviour {

    public GameObject firstPersonCharacter;
    public GameObject[] characterModel;
    public override void OnStartLocalPlayer()
    {
        GetComponent<PlayerRede>().enabled = true;
        firstPersonCharacter.SetActive(true);

        foreach (GameObject go in characterModel)
        {
            go.SetActive(false);
        }
    }
}
