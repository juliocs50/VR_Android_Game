using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FimDoMundo : MonoBehaviour {




    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            SceneManager.LoadScene(0);
        }
    }


}
