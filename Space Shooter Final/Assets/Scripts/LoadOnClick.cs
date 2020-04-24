using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
            Debug.Log("Quitting");
        }
    }

    public void LoadScene(int level)
    {
        SceneManager.LoadScene(level);
    }
}
