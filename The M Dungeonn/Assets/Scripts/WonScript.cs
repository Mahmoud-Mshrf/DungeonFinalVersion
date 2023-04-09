using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WonScript : MonoBehaviour
{
    public Items PlayerItems;
    public GameObject Door;
    public GameObject Stick;
    [SerializeField] private AudioSource finishSoundEffect;
    public GameObject LevelCompletePanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player"&& PlayerItems.Keys==2)
        {
            Stick.GetComponent<Animator>().enabled = true;
            Door.GetComponent<Animator>().enabled = true;
            gameObject.SetActive(false);
            finishSoundEffect.Play();
            //Invoke("LoadNextLevel", 2);
            Invoke("LoadCompletePanel", 2);
        }
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);// this make it load the next scene 
    }
    void LoadCompletePanel()
    {
        LevelCompletePanel.SetActive(true);
    }
}
