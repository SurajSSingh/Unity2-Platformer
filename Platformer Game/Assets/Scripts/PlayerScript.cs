using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public string sceneName;
    public int score;
    public int lives;
    public float health;
    public List<Collectable> collectionList;

    private float jumpForce = 25.0f;
    private float playerSpeed = 1.0f;
    private int current_index = 0;
    private bool onGround = false;

    //UI Elements
    public Text health_text;
    public Text lives_text;
    public Text item_text;
    public Text score_text;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        lives = 3;
        health = 100.0f;
        health_text.text = "Health: " + health.ToString();
        lives_text.text = "Lives: " + lives.ToString();
        score_text.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0.0)
        {
            lives -= 1;
            health = 100.0f;
            SceneManager.LoadScene(sceneName);
            // Update Text
            health_text.text = "Health: " + health.ToString();
            lives_text.text = "Lives: " + lives.ToString();
        }
        // Shift keys change items
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            current_index = (current_index+1)%collectionList.Count;
            item_text.text = "Current Item: " + collectionList[current_index].Name();
        }
        // U key uses item
        if (Input.GetKeyDown(KeyCode.U) && collectionList.Count > 0)
        {
            // Debug.Log(collectionList[current_index].GetType());
            collectionList[current_index].Use();
            Collectable temp = collectionList[current_index];
            collectionList.Remove(temp);
            Destroy(temp);
            // Move back one
            if (collectionList.Count == 0)
            {
                current_index = 0;
                item_text.text = "No Items";
            }
            else
            {
                current_index = (current_index-1)%collectionList.Count;
                item_text.text = "Current Item: " + collectionList[current_index].Name();
            }
            health_text.text = "Health: " + health.ToString();
            lives_text.text = "Lives: " + lives.ToString();
            score_text.text = "Score: " + score.ToString();
        }
        float jump = 0.0f;
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            onGround = false;
            jump = 1.0f;
        }
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Input.GetAxis("Horizontal")*playerSpeed,jump*jumpForce));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Collectable>() != null)
        {
            // Debug.Log("Collecting Item: " + other.gameObject.GetComponent<Collectable>().Name());
            AddCollectable(other.gameObject.GetComponent<Collectable>());
            other.gameObject.SetActive(false);
            score_text.text = "Score: " + score.ToString();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    { 
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            other.gameObject.GetComponent<Obstacle>().DoSomething(this);
            health_text.text = "Health: " + health.ToString();
        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }
    private void AddCollectable(Collectable c)
    {
        c.addPlayer(this); // This adds the current script to the collectable
        collectionList.Add(c);
        item_text.text = "Current Item: " + collectionList[current_index].Name();
    }
    
}
