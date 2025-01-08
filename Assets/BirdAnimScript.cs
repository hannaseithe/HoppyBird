using UnityEngine;

public class BirdAnimScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public GameObject gameOverScreen;
    public LogicScript logic;
    public Component[] animators;
    private Animator mAnimator;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        mAnimator = GameObject.FindGameObjectWithTag("Wings").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !logic.birdDead)
        {
            myRigidbody.linearVelocity = Vector2.up * flapStrength;
            if (mAnimator != null)
            {
                mAnimator.SetTrigger("Trig_Open");
            }
        }

        if ((transform.position.y > 22 || transform.position.y < -22) && !logic.birdDead)
        {
            logic.gameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
    }
}