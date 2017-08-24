using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class pickup : MonoBehaviour
{
    private Text timedisplayed;
    private float ingametime;
    private int minutes;
    private bool isLevelcomplete;
    private int pickedupitmes = 0;
    private AudioClip pickItemsound;
    private AudioClip spotsound;
    private AudioSource audiosource;
    private GameObject puerta;
    private RawImage alma;
    private RawImage corazon;
    private RawImage retrato;
    private RawImage oso;
    private RawImage flor;

    void Start()
    {
        source = GetComponent<AudioSource>();
        ingametime = 0;
        timedisplayed.text = "Tiempo:00:00" + ingametime;
    }

    void Update()
    {
        ingametime = ingametime + Time.deltaTime;
        timedisplayed.text = "Tiempo:00:" + Mathf.RoundToInt(ingametime);
        if (ingametime == 60)
        {
            minutes = 1;
            ingametime = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collindingobject)
    {
        if (collindingobject.gameObject.tag == "ganar")
        {
            SceneManager.LoadScene(5);
        }
        if (collindingobject.gameObject.tag == "Spot")
        {
            source.PlayOneShot(spotsound);
        }
        if (collindingobject.gameObject.tag == "alma")
        {
            Destroy(collindingobject.gameObject);
            ScoreManager.Instance.Score += 100;
            pickedupitmes++;
            alma.enabled = false;
            source.PlayOneShot(pickItemsound);
        }
        if (collindingobject.gameObject.tag == "corazon")
        {
            Destroy(collindingobject.gameObject);
            Collectitem(corazon);
        }
        if (collindingobject.gameObject.tag == "oso")
        {
            Destroy(collindingobject.gameObject);
            Collectitem(oso);
        }
        if (collindingobject.gameObject.tag == "retrato")
        {
            Destroy(collindingobject.gameObject);
            Collectitem(retrato);
        }
        if (collindingobject.gameObject.tag == "flor")
        {
            Destroy(collindingobject.gameObject);
            Collectitem(flor);
        }
    }

    public void Collectitem(RawImage itemtodisable)
    {
        setscore(1);
        ScoreManager.Instance.Score += 100;
        itemtodisable.enabled = false;
        audiosource.PlayOneShot(pickItemsound);
    }
    public void setscore(int addedscore)
    {
        pickedupitmes += addedscore;
        if (pickedupitmes < 4)
        {
            Destroy(puerta);
        }
    }
}