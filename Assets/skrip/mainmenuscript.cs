using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenuscript : MonoBehaviour
{
    public void changescene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
