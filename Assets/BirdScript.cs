using UnityEngine;

public class BirdScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public GameObject gameOverScreen;
    public LogicScript logic;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !logic.birdDead)
        { 
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
        }

        if (transform.position.y > 22 || transform.position.y <-22)
        {
            logic.gameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
    }
}
