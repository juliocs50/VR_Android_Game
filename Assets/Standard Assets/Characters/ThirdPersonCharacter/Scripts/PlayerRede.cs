using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using UnityEngine.Networking;
using UnityStandardAssets.Characters.ThirdPerson;


public  class PlayerRede : MonoBehaviour {
  public  bool pode = false;

    public static float tempo = 100;
    public static int mult = 1;
    public int speed = 2;
    private Rigidbody rigid;
    public GameObject interruptor, painel;
    public GameObject camera;
    // Use this for initialization
    void Start () {
        mult++;
        rigid = GetComponent<Rigidbody>();
        camera = transform.GetChild(0).gameObject;

        
    }
	
	// Update is called once per frame
	void Update () {
        tempo = tempo - Time.deltaTime*mult;            
        print(tempo);
        print(mult);
        float v = CrossPlatformInputManager.GetAxis("Vertical");
         v = Input.GetAxis("Vertical");
        if (v>0.2f)
        {
            transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;
        }
     
        //  if (v<-0.2f)
        // {
        //transform.position = transform.position - Camera.main.transform.forward * speed * Time.deltaTime;
        // }
        // RT
        if (Input.GetKey(KeyCode.JoystickButton9))
        {
            transform.position = transform.position + Camera.main.transform.forward * speed * Time.deltaTime;
        }


        //JoystickButton0 = a JoystickButton1=b JoystickButton2=x JoystickButton3=y 

        if (Input.GetKeyDown(KeyCode.N) || Input.GetKeyDown(KeyCode.JoystickButton0))
        {

            interruptor.GetComponent<desligaLuz>().swithlight();

        }
        if (Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            painel.GetComponent<DesligaPainel>().swithlight();


        }


        if (tempo<0)
        {

            // SceneManager.LoadScene(0);
            camera.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {

            SceneManager.LoadScene(0);
        }

        if (other.CompareTag("Next"))
        {

            SceneManager.LoadScene(0);

        }
        if (other.CompareTag("light"))
        {
            other.gameObject.transform.GetChild(0).transform.gameObject.SetActive(true);
            interruptor = other.gameObject;


        }
        if (other.CompareTag("Painel"))
        {
            other.gameObject.transform.GetChild(0).transform.gameObject.SetActive(true);
            painel = other.gameObject;


        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("light"))
        {
            other.gameObject.transform.GetChild(0).transform.gameObject.SetActive(false);
            interruptor = null;
        }

        if (other.CompareTag("Painel"))
        {
            other.gameObject.transform.GetChild(0).transform.gameObject.SetActive(false);
            painel = null;
        }
    }

}
