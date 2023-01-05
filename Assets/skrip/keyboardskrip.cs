using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboardskrip : MonoBehaviour
{
    
    public void keyboard(string hurufarab)
    {
        hurufarab = Input.inputString;
        if(hurufarab.Length == 1)
        {
            FindObjectOfType<writer>().Enterletter(hurufarab);
        }
    }
}
