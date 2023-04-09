using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private int health=3;
    //public Transform Player_Text;
    [SerializeField] private Text healthtext;
    [SerializeField] private AudioSource HealthPickupSoundEffect;

    // Start is called before the first frame update
    //void Start()
    //{
    //    //keysText = Player_Text.Find("Keys").GetComponent<TextMeshProUGUI>();
    //    //keysText.text = "Keys: " + Keys;
    //}

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Health"))
        {
            Destroy(collision.gameObject);
            health++;
            HealthPickupSoundEffect.Play();

            healthtext.text = "Health:" + health;
        }
    }
}
