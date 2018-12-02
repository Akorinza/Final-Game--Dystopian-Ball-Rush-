using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErSaBallController : MonoBehaviour {

    public Text countText;
    public Text winText;

    private AudioSource source;
    public AudioClip goalClip;

    private int count;

    void Awake()
    { source = GetComponent<AudioSource>(); }

    // Use this for initialization
    void Start ()
    {
        count = 0;
        winText.text = "";
        SetCountText();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == ("ErSaGoal"))
        {
            count = count + 10;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 10)
        {
            winText.text = "Now That's A Goal!";
            source.PlayOneShot(goalClip);
        }
    }

}
