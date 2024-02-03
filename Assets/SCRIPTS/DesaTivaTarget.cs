using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;


public class DesaTivaTarget : MonoBehaviour {
    public GameObject Inimigo;
    // Use this for initialization
    void Start () {
		
	}
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inimigo.GetComponent<AICharacterControl>().target = Inimigo.transform;
            Inimigo.GetComponent<Animator>().SetBool("Parou",true);


        }
    }
    
}
