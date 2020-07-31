using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emotionTry : MonoBehaviour
{

    public GameObject questionBox;

    public void Question()
    {
        if (!questionBox.activeInHierarchy)
        {
            questionBox.SetActive(true);
        }
        else
        {
            questionBox.SetActive(false);
        }
    }
}
