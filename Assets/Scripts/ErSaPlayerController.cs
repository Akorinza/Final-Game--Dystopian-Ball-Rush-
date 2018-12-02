using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErSaPlayerController : MonoBehaviour {

    private Rigidbody2D rb2d;
    public float speed;
    public float jumpForce;

    public Text loseText;
    public Text startText;

    private int count;

    private bool facingRight = true;

    private AudioSource source;
    public AudioClip jumpClip;
    public AudioClip startClip;
    public AudioClip gameoverClip;

    // Use this for initialization
    void Start () {

        rb2d = GetComponent<Rigidbody2D>();
        loseText.text = "";
        startText.text = "Hurry and guide the ball into the goal!";
        source.PlayOneShot(startClip);

    }

    void Awake()
    { source = GetComponent<AudioSource>(); }

    // Update is called once per frame
    void Update () {

        if (Input.GetKey("escape"))
            Application.Quit();

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0);

        rb2d.AddForce(movement * speed);

        if (facingRight == false && moveHorizontal > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveHorizontal < 0)
        {
            Flip();
        }

    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "ErSaGround") {

            if (Input.GetKey(KeyCode.UpArrow)) {

                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                source.PlayOneShot(jumpClip);
            }
        }

        if (collision.collider.tag == ("ErSaPlayerDeath"))
        {
            loseText.text = "Game Over, Old Sport!";
            source.PlayOneShot(gameoverClip);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }

}
