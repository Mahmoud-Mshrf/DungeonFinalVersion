using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player_life : MonoBehaviour
{
    private int startingLives = 3; // Starting number of lives
    [SerializeField] private Text LivesText;
    private int currentLives; // Current number of lives
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private AudioSource DeathSoundEffect;
    [SerializeField] GameObject[] Axes;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        if (PlayerPrefs.HasKey("Live")) // Check if there is a saved lives value
        {
            currentLives = PlayerPrefs.GetInt("Live"); // Load the saved value
            LivesText.text = "LIVES: " + currentLives;
        }
        else
        {
            currentLives = startingLives; // Use the default starting value
            LivesText.text = "LIVES: " + currentLives;

        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap")) // Check if collision is with a trap
        {
            currentLives--; // Subtract one from current lives
            LivesText.text = "LIVES: " + currentLives;
            DeathSoundEffect.Play();
            rb.bodyType = RigidbodyType2D.Static;
            anim.SetTrigger("Death");

            //if (currentLives <= 0) // Check if player has run out of lives
            //{
            //    PlayerPrefs.DeleteKey("Live"); // Delete the saved lives value
            //    //PlayerPrefs.Save();
            //    SceneManager.LoadScene(2); // Load the game over scene
            //}
            //else
            //{
            //    PlayerPrefs.SetInt("Live", currentLives); // Save the current lives value
            //    //PlayerPrefs.Save();
            //    SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
            //}
            //GameOverOrNot();
        }
        if (collision.gameObject.CompareTag("KILLFloor"))
        {
            Axes[0].SetActive(true);
            Axes[1].SetActive(true);
        }
    }

    public int GetCurrentLives()
    {
        return currentLives; // Return the current number of lives
    }
    public void GameOverOrNot()
    {
        if (currentLives <= 0) // Check if player has run out of lives
        {
            PlayerPrefs.DeleteKey("Live"); // Delete the saved lives value
                                           //PlayerPrefs.Save();
            SceneManager.LoadScene(3); // Load the game over scene
        }
        else
        {
            PlayerPrefs.SetInt("Live", currentLives); // Save the current lives value
                                                      //PlayerPrefs.Save();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
        }
    }
}
