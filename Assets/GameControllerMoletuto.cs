using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameControllerMoletuto : MonoBehaviour {
    public GameObject moleContainer;
    public TextMesh infoText;
    public PlayerMole Player;
    public float spwanDuration = 1.5f;
    public float spwanDecrement = 0.1f;
    public float mimSpawnDuration = 0.5f;

    public float gameTimer = 60f;

    private float resetTimer= 3f;
    private float spawnTimer = 0f;
    private Mole[] moles;
	// Use this for initialization
	void Start () {
        moles = moleContainer.GetComponentsInChildren<Mole>();

        moles[Random.Range(0, moles.Length)].Rise();
	}
	
	// Update is called once per frame
	void Update () {

        gameTimer -= Time.deltaTime;
        if (gameTimer>0)
        {
            infoText.text = "Acerte 10 vezes!\nTempo:" + Mathf.Floor(gameTimer)+ "\nPontos: "+ Player.score;

            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0f)
            {
                moles[Random.Range(0, moles.Length)].Rise();
                spawnTimer -= spwanDecrement;
                if (spwanDuration < mimSpawnDuration)
                {
                    spwanDuration = mimSpawnDuration;

                }
                spawnTimer = spwanDuration;
            }

        }
        else
        {
            if (Player.score>9)
            {
                infoText.text = "Voce conseguiu !\n Sua pontuacao: " + Mathf.Floor(Player.score);

            }
            else
            {
                infoText.text = "Fim de jogo!\n Sua pontuacao: " + Mathf.Floor(Player.score);

            }
            resetTimer -= Time.deltaTime;
            if (resetTimer<0)
            {
                if (Player.score > 9)
                {
                    SceneManager.LoadScene("RVPraiaFinal");
                }
                else
                {
                    SceneManager.LoadScene("RVMiniGame");
                }
            }

        }

        
	}
}
