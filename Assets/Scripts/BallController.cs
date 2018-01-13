using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public int force;
    int scoreP1 = 0;
    int scoreP2 = 0;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(2,1).normalized * force);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector2 direction = new Vector2(GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y).normalized;
            GetComponent<Rigidbody2D>().AddForce(direction * force * 3 / 4);
        }
        else if (collision.gameObject.name =="Left") {
            scoreP2 += 1;
            ResetBall();
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-2, 2).normalized * force/2);
        }
        else if (collision.gameObject.name == "Rigth")
        {
            scoreP1 += 1;
            ResetBall();
            GetComponent<Rigidbody2D>().AddForce(new Vector2(2, 2).normalized * force/2);
        }

    }

    void ResetBall()
    {
        transform.localPosition = new Vector2(0,0);
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
}
