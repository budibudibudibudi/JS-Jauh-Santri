using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pemilihansuratscript : MonoBehaviour
{
    int suratindex;
    public void tosurah(int index)
    {
        suratindex = index;
        PlayerPrefs.SetInt("surahindex",suratindex);
        SceneManager.LoadScene("game membaca dan menulis");
    }
}
