using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;


public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public Text scoreText;
    public Text healthText;
    public Text winLoseText;
    public Image winLoseBG;

    public int health = 5;
    public float speed = 2000f;
    private int score = 0;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
           rb.AddForce(-speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.S))
        {
           rb.AddForce(0, 0, -speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(0, 0, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            score++;
            SetScoreText();
            //Debug.Log("Score: " + score);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Trap"))
        {
            health--;
            SetHealthText();
            //Debug.Log("Health: " + health);
        }

        if (other.gameObject.CompareTag("Goal"))
        {
            //Debug.Log("You win!");
            winLoseBG.gameObject.SetActive(true);
            winLoseBG.color = Color.green;
            winLoseText.color = Color.black;
            winLoseText.text = "You win!";
            StartCoroutine(LoadScene(3));
            //Debug.Log("Your total Score is " + score);
        }
    }

    void Update()
    {
        if (health == 0)
        {
            //Debug.Log("Game Over!");
            winLoseBG.gameObject.SetActive(true);
            winLoseText.color = Color.white;
            winLoseBG.color = Color.red;
            winLoseText.text = "Game Over!";
            StartCoroutine(LoadScene(3));
            // Reestart Level
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString();
    }

    // Call method with StartCoroutine(LoadScene(3))
    IEnumerator LoadScene(float seconds)
    {
        yield return new WaitForSeconds(5);
    }
}
