using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public AudioSource a;
    // Start is called before the first frame update
    void Start()
    {
        a.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onStartClick(){
        SceneManager.LoadScene("Game");
    }

    public void onExitClick(){
        Application.Quit();
        System.Console.WriteLine("Exit!");
    }

    public void onCreditClick(){
        SceneManager.LoadScene("Credits");
    }
}
