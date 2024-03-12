using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoss : MonoBehaviour
{
    public PlayerScript objects;
    public GameObject leftpillar;
    public GameObject rightpillar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (objects.pickedup == 1)
        {
            leftpillar.SetActive(true);
        }
        if (objects.pickedup == 2)
        {
            rightpillar.SetActive(true);
        }
        if (objects.pickedup == 3)
        {
            SceneManager.LoadScene("CreditsScreen");
        }
    }
}
