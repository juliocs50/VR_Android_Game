using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class EntrouEscuro : MonoBehaviour {
    public GameObject Inimigo;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inimigo.GetComponent<AICharacterControl>().target = other.transform;
            Inimigo.GetComponent<Animator>().SetBool("Parou", false);
        }
    }
   
}
