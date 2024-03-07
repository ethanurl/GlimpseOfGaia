using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsMenu : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OpenCreditsList()
    {
        Application.OpenURL("https://docs.google.com/document/d/1n6N_iHahCEeqZvSLCq_TRtr35f_GhVMVTuQvayKbIpY/edit?usp=sharing");
    }
}
