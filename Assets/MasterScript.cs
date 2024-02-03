using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class MasterScript : MonoBehaviour
    {
        public float velocidade=2;
        public GameObject Player;
        public GameObject Eric;
        public bool PodeAndar = true;
    //public bool podePagar = true;
        public float TempoDeEspera = 0;
        Animator AnimPlayer, AnimEric;
        public   bool andaSom = false;
        public GameObject mao;
        public GameObject arvore;
        bool parouDeolhar = true;
       public  bool parouDeAndar = true;
    public float tempoParouDeAndar = 0.5f;
    public Animator ButonA, ButonB, ButonY;    


    public GameObject LoadButton, LoadButton2, LoadButton3;

    public float tempoDeAtivacaoCadaParte, parteTempo;
    int i;

    void Start()
        {
            AnimPlayer = Player.GetComponent<Animator>();
            AnimEric = Eric.GetComponent<Animator>();

        }
               
        void Update()
        {


       if ((Mathf.Abs(Input.GetAxis("Vertical")) == 0))
        {
            
            if (tempoParouDeAndar>0)
            {
                tempoParouDeAndar = tempoParouDeAndar - Time.deltaTime;
                if (tempoParouDeAndar<0)
                {
                    parouDeAndar = true;
                }
            }
        }
        else
        {
            parouDeAndar = false;
            tempoParouDeAndar = 0.6f;
        }



        if (tempoDeAtivacaoCadaParte<0)
        {
            if (i>0)
            {
                LoadButton.transform.GetChild(i-1).gameObject.SetActive(false);
              //  LoadButton2.transform.GetChild(i - 1).gameObject.SetActive(false);
                LoadButton3.transform.GetChild(i - 1).gameObject.SetActive(false);
                i--;
                tempoDeAtivacaoCadaParte = parteTempo;
            }          
           
        }




        if (parouDeolhar)
        {


            if (tempoDeAtivacaoCadaParte > -1.0f)
            {
                tempoDeAtivacaoCadaParte = tempoDeAtivacaoCadaParte - Time.deltaTime;

            }


            if (!PodeAndar)
            {
                
                TempoDeEspera = TempoDeEspera - Time.deltaTime;
                if (TempoDeEspera < 0)
                {
                    PodeAndar = !PodeAndar;
                }

            }
        }

        if (PodeAndar)
            {
            arvore.GetComponent<CapsuleCollider>().isTrigger = false;

            if ((Mathf.Abs(Input.GetAxis("Vertical")) > 0))
                {
                    AnimEric.SetBool("Andou", true);
                    Player.transform.position = Player.transform.position + Camera.main.transform.forward * velocidade * Time.deltaTime;                    
                }
                else
                {
                    AnimEric.SetBool("Andou", false);                    
                }
            }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton1))            
        {
            ButonB.SetBool("apertou", true);

        }
        else if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.JoystickButton1))
        {
            ButonB.SetBool("apertou", false);
        }




            if ((((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton0))) && (((Mathf.Abs(Input.GetAxis("Vertical")) == 0))) && parouDeAndar) 
            && mao.transform.childCount == 1)
            //&& mao.transform.GetChild(0).tag=="Maxado"))
        {
            if (PodeAndar)
            {
                ButonA.SetBool("apertou", true);
                arvore.GetComponent<CapsuleCollider>().isTrigger = true;
                AnimEric.SetBool("maxado", true);
                TempoDeEspera = 2.5f;
                parteTempo = TempoDeEspera / 8;
                i = 8;
                LoadButton.transform.GetChild(0).gameObject.SetActive(true);
                LoadButton.transform.GetChild(1).gameObject.SetActive(true);
                LoadButton.transform.GetChild(2).gameObject.SetActive(true);
                LoadButton.transform.GetChild(3).gameObject.SetActive(true);
                LoadButton.transform.GetChild(4).gameObject.SetActive(true);
                LoadButton.transform.GetChild(5).gameObject.SetActive(true);
                LoadButton.transform.GetChild(6).gameObject.SetActive(true);
                LoadButton.transform.GetChild(7).gameObject.SetActive(true);

               // LoadButton2.transform.GetChild(0).gameObject.SetActive(true);
               // LoadButton2.transform.GetChild(1).gameObject.SetActive(true);
               // LoadButton2.transform.GetChild(2).gameObject.SetActive(true);
               // LoadButton2.transform.GetChild(3).gameObject.SetActive(true);
               // LoadButton2.transform.GetChild(4).gameObject.SetActive(true);
               // LoadButton2.transform.GetChild(5).gameObject.SetActive(true);
               // LoadButton2.transform.GetChild(6).gameObject.SetActive(true);
               // LoadButton2.transform.GetChild(7).gameObject.SetActive(true);

                LoadButton3.transform.GetChild(0).gameObject.SetActive(true);
                LoadButton3.transform.GetChild(1).gameObject.SetActive(true);
                LoadButton3.transform.GetChild(2).gameObject.SetActive(true);
                LoadButton3.transform.GetChild(3).gameObject.SetActive(true);
                LoadButton3.transform.GetChild(4).gameObject.SetActive(true);
                LoadButton3.transform.GetChild(5).gameObject.SetActive(true);
                LoadButton3.transform.GetChild(6).gameObject.SetActive(true);
                LoadButton3.transform.GetChild(7).gameObject.SetActive(true);

                tempoDeAtivacaoCadaParte = parteTempo;

            }
           
            PodeAndar = false;
           
        }
        else
        {
           
            AnimEric.SetBool("maxado", false);

        }

      

       
            //se nao tem nada na mao
            if ((((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton0))) && (((Mathf.Abs(Input.GetAxis("Vertical")) == 0))) && parouDeAndar
            && mao.transform.childCount == 0)) 
            {
            if ((PodeAndar) && AnimEric.GetBool("olhar")==false)
            {
                ButonA.SetBool("apertou", true);
                AnimEric.SetBool("pegar", true);
                AnimPlayer.SetBool("pegou", true);
                TempoDeEspera = 2.5f;
                parteTempo = TempoDeEspera / 8;
                i = 8;
                LoadButton.transform.GetChild(0).gameObject.SetActive(true);
                LoadButton.transform.GetChild(1).gameObject.SetActive(true);
                LoadButton.transform.GetChild(2).gameObject.SetActive(true);
                LoadButton.transform.GetChild(3).gameObject.SetActive(true);
                LoadButton.transform.GetChild(4).gameObject.SetActive(true);
                LoadButton.transform.GetChild(5).gameObject.SetActive(true);
                LoadButton.transform.GetChild(6).gameObject.SetActive(true);
                LoadButton.transform.GetChild(7).gameObject.SetActive(true);

                // LoadButton2.transform.GetChild(0).gameObject.SetActive(true);
                // LoadButton2.transform.GetChild(1).gameObject.SetActive(true);
                // LoadButton2.transform.GetChild(2).gameObject.SetActive(true);
                // LoadButton2.transform.GetChild(3).gameObject.SetActive(true);
                // LoadButton2.transform.GetChild(4).gameObject.SetActive(true);
                // LoadButton2.transform.GetChild(5).gameObject.SetActive(true);
                // LoadButton2.transform.GetChild(6).gameObject.SetActive(true);
                // LoadButton2.transform.GetChild(7).gameObject.SetActive(true);

                LoadButton3.transform.GetChild(0).gameObject.SetActive(true);
                LoadButton3.transform.GetChild(1).gameObject.SetActive(true);
                LoadButton3.transform.GetChild(2).gameObject.SetActive(true);
                LoadButton3.transform.GetChild(3).gameObject.SetActive(true);
                LoadButton3.transform.GetChild(4).gameObject.SetActive(true);
                LoadButton3.transform.GetChild(5).gameObject.SetActive(true);
                LoadButton3.transform.GetChild(6).gameObject.SetActive(true);
                LoadButton3.transform.GetChild(7).gameObject.SetActive(true);

                tempoDeAtivacaoCadaParte = parteTempo;
            }
              
                PodeAndar = false;
               
            }
            else
            {
            ButonA.SetBool("apertou", false);
            AnimEric.SetBool("pegar", false);
                AnimPlayer.SetBool("pegou", false);
            }
            if (((Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.JoystickButton3))) && (((Mathf.Abs(Input.GetAxis("Vertical")) == 0))) && parouDeAndar)
            {
          
            if (PodeAndar)
            {
                ButonY.SetBool("apertou", true);
                AnimEric.SetBool("olhar", true);
                TempoDeEspera = 2.5f;
                parteTempo = TempoDeEspera / 8;
                tempoDeAtivacaoCadaParte = parteTempo;
                i = 8;
               
                LoadButton.transform.GetChild(0).gameObject.SetActive(true);
                LoadButton.transform.GetChild(1).gameObject.SetActive(true);
                LoadButton.transform.GetChild(2).gameObject.SetActive(true);
                LoadButton.transform.GetChild(3).gameObject.SetActive(true);
                LoadButton.transform.GetChild(4).gameObject.SetActive(true);
                LoadButton.transform.GetChild(5).gameObject.SetActive(true);
                LoadButton.transform.GetChild(6).gameObject.SetActive(true);
                LoadButton.transform.GetChild(7).gameObject.SetActive(true);

                // LoadButton2.transform.GetChild(0).gameObject.SetActive(true);
                // LoadButton2.transform.GetChild(1).gameObject.SetActive(true);
                // LoadButton2.transform.GetChild(2).gameObject.SetActive(true);
                // LoadButton2.transform.GetChild(3).gameObject.SetActive(true);
                // LoadButton2.transform.GetChild(4).gameObject.SetActive(true);
                // LoadButton2.transform.GetChild(5).gameObject.SetActive(true);
                // LoadButton2.transform.GetChild(6).gameObject.SetActive(true);
                // LoadButton2.transform.GetChild(7).gameObject.SetActive(true);

                LoadButton3.transform.GetChild(0).gameObject.SetActive(true);
                LoadButton3.transform.GetChild(1).gameObject.SetActive(true);
                LoadButton3.transform.GetChild(2).gameObject.SetActive(true);
                LoadButton3.transform.GetChild(3).gameObject.SetActive(true);
                LoadButton3.transform.GetChild(4).gameObject.SetActive(true);
                LoadButton3.transform.GetChild(5).gameObject.SetActive(true);
                LoadButton3.transform.GetChild(6).gameObject.SetActive(true);
                LoadButton3.transform.GetChild(7).gameObject.SetActive(true);
                parouDeolhar = false;
                PodeAndar = false;
            }
            

           
              
            }
            else if(((Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.JoystickButton3))))
            {
            ButonY.SetBool("apertou", false);
            parouDeolhar = true;
                AnimEric.SetBool("olhar", false);
            }
        
    }
    }

