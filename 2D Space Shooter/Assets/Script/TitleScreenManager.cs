using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenManager : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
    }
    public void Start()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
