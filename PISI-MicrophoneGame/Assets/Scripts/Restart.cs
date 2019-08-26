using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Reload();
        }
    }

    void Reload()
    {
        //Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene(0);
    }
}