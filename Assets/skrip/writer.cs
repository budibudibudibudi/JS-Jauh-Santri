using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ArabicSupport;

public class writer : MonoBehaviour
{
    [SerializeField] bacaanblueprint [] suratsurat;
    [SerializeField] GameObject [] surat;
    [SerializeField] Text clue;
    [SerializeField] Text hp;
    string remainword;
    string currentword;
    GameObject[] keyboard;
    int index = 0;
    int suratindex;
    int munculclue = 3;
    public AudioClip bismillah;
    [SerializeField] GameObject bgclue;
    AudioSource audio;
    // Start is called before the first frame update
    void Awake()
    {
        suratindex = PlayerPrefs.GetInt("surahindex");
        audio = gameObject.AddComponent<AudioSource>();
        audio.clip = bismillah;
        keyboard = GameObject.FindGameObjectsWithTag("tombolkey");
        surat[suratindex].SetActive(true);
        currentword = suratsurat[suratindex].bacaan[index].GetComponent<ArabicText>().Text;
        suratsurat[suratindex].bacaan[index].gameObject.SetActive(true);
        setCurrentWord();
    }

    void setCurrentWord()
    {
        setRemainingWord(currentword);
    }
    
    void setRemainingWord(string newstring)
    {
        remainword = newstring;
    }
 
    public void Enterletter(string typedletter)
    {
        bacaanblueprint bb = suratsurat[suratindex];
        if(IsCorrectLetter(typedletter))
        {
            RemoveLetter();
            munculclue = 3;
            hp.text = "Bantuan akan muncul dalam "+munculclue;

            if(iswordcomplete())
            {
                bb.bacaan[index].gameObject.SetActive(false);
                index++;
                if(index == bb.bacaan.Length)
                {
                    foreach(GameObject k in keyboard)
                    {
                        k.SetActive(false);
                    }
                }
                audio.Play();
                bb.bacaan[index].gameObject.SetActive(true);
                currentword = bb.bacaan[index].GetComponent<ArabicText>().Text;
                setCurrentWord();
                
            }
        }

        else
        {
            //Debug.Log("salah");
            IsWrongword();
        }
    }

    bool IsCorrectLetter(string letter)
    {
        return remainword.IndexOf(letter) == 0;
    }

    void IsWrongword()
    {
        munculclue--;
        if(munculclue <= 0)
        {
            char [] c = FindObjectOfType<ArabicText>().Text.ToCharArray();
            bgclue.SetActive(true);
            clue.text = "Tekan"+c[0];
            if(c[0]==' ')
            {
                clue.text = "Tekan Spasi";
            }
            munculclue = 0;
            hp.text = "Bantuan akan muncul dalam "+munculclue;
        }
        else
        {
            hp.text = "Bantuan akan muncul dalam "+munculclue;
        }
    }

    void RemoveLetter()
    {
        bacaanblueprint bb = suratsurat[suratindex];
        string newString = remainword.Remove(0,1);
        bb.bacaan[index].GetComponent<ArabicText>().Text = newString;
        bgclue.SetActive(false);
        setRemainingWord(newString);
    }

    bool iswordcomplete()
    {
        return remainword.Length == 0;
    }
}
