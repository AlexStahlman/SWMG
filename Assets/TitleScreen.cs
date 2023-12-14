using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TitleScreen : MonoBehaviour
{
    public Image credits;
    public Image Instructions;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnableInstructions(){
        Instructions.gameObject.SetActive(true);
        return;
    }
    public void EnableCredits(){
        credits.gameObject.SetActive(true);
        return;
    }
    public void StartGame(){
        SceneManager.LoadScene("LevelOne");
        return;
    }
    public void Return(){
        credits.gameObject.SetActive(false);
        Instructions.gameObject.SetActive(false);
    }
}
