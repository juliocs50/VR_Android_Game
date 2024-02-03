using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameControllerMole : MonoBehaviour {
    public GameObject moleContainer;
    public TextMesh infoText;
    public PlayerMoletuto Player;
    public float spwanDuration = 1.5f;
    public float spwanDecrement = 0.1f;
    public float mimSpawnDuration = 0.5f;

    public float gameTimer = 15f;

    private float resetTimer= 3f;
    private float spawnTimer = 0f;
    private Moletuto[] moles;
	// Use this for initialization
	void Start () {
        moles = moleContainer.GetComponentsInChildren<Moletuto>();

        moles[Random.Range(0, moles.Length)].Rise();
	}
	
	// Update is called once per frame
	void Update () {

     
        if (Player.score <2)
        {
            infoText.text = "Mire com a cabeca!\n" +
                "e Aperte 'A' para bater nos pregos!";            

        }

        else
        {
            if (Player.score>2)
            {
                infoText.text = "Muito bem!" ;
                resetTimer -= Time.deltaTime;

            }
           
        
            if (resetTimer<0)
            {
                if (Player.score > 2)
                {
                    SceneManager.LoadScene("RVMiniGame");
                }
                
            }

        }

        
	}
}
