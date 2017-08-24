using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class pickup : MonoBehaviour
{
  
    public Text tiempo;
 
    public float time;
    public int minutos;
    public bool levelComplete;
    public string highscorePos;




    public int temp;

    public int pickedup=0;
    public AudioClip tp;
    public AudioClip cp;
    public AudioSource source;
    public GameObject puerta;
    

    public RawImage alma;
    public RawImage corazon;
    public RawImage retrato;
    public RawImage oso;
    public RawImage flor;

    // Use this for initialization
    void Start()
    {
       source = GetComponent<AudioSource>();

        time = 0;
        temp = 0;
     
        tiempo.text = "Tiempo:00:00" + time;
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;
     
        tiempo.text = "Tiempo:00:" + Mathf.RoundToInt(time);
        if (time == 60)
        {
            minutos = 1;
            time = 0;
         
        }

        if (pickedup==5)
        {
            Destroy(puerta);
        }
    }



    
    void OnTriggerEnter2D(Collider2D dmg)
    {

        if (dmg.gameObject.tag == "ganar")


        {
            SceneManager.LoadScene(5);
        }

            if (dmg.gameObject.tag == "Spot")
        {


            source.PlayOneShot(cp);

        }


    

    
        if (dmg.gameObject.tag == "alma")
        {
            Destroy(dmg.gameObject);

            ScoreManager.Instance.Score += 100;

            pickedup++;
          

            alma.enabled = false;

            source.PlayOneShot(tp);





        }

        if (dmg.gameObject.tag == "corazon")
        {
            Destroy(dmg.gameObject);

            pickedup++;

            ScoreManager.Instance.Score += 100;
            corazon.enabled = false;
            source.PlayOneShot(tp);


        }
        if (dmg.gameObject.tag == "oso")
        {
            Destroy(dmg.gameObject);

            pickedup++;

            ScoreManager.Instance.Score += 100;
            oso.enabled = false;

            source.PlayOneShot(tp);

        }
        if (dmg.gameObject.tag == "retrato")
        {
            Destroy(dmg.gameObject);
            ScoreManager.Instance.Score += 100;
            pickedup++;
         

            retrato.enabled = false;
            source.PlayOneShot(tp);


        }
        if (dmg.gameObject.tag == "flor")
        {
            Destroy(dmg.gameObject);

            pickedup++;

            ScoreManager.Instance.Score += 100;
            flor.enabled = false;
            source.PlayOneShot(tp);


        }

       

    }
   
}

