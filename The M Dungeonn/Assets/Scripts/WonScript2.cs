using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WonScript2 : MonoBehaviour
{
    public Items PlayerItems;
    public GameObject Door;
    public GameObject Stick;
    [SerializeField] private AudioSource finishSoundEffect;
    public GameObject LevelCompletePanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && PlayerItems.Keys == 3)
        {
            Stick.GetComponent<Animator>().enabled = true;
            Door.GetComponent<Animator>().enabled = true;
            gameObject.SetActive(false);
            finishSoundEffect.Play();
            Invoke("LoadCompletePanel", 2);
            Invoke("LoadMainMenu", 6);
        }
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);// this make it load the next scene 
    }
    void LoadCompletePanel()
    {
        LevelCompletePanel.SetActive(true);
    }
}
