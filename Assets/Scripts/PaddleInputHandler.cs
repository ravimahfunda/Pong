using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleInputHandler : MonoBehaviour {

    public int moveSpeed = 3;
    public string keyControl;

    int currentState;
    const int NORMAL = 0;
    const int STUCK_ATAS = 1;
    const int STUCK_BAWAH = 2;

    // Use this for initialization
    void Start () {
        currentState = NORMAL;
	}
	
	// Update is called once per frame
	void Update () {
        float yChange = Input.GetAxis(keyControl) * moveSpeed;

        switch (currentState) {
            case STUCK_ATAS:
                if (yChange < 0) {
                    currentState = NORMAL;
                }
                break;
            case STUCK_BAWAH:
                if (yChange > 0)
                {
                    currentState = NORMAL;
                }
                break;
            default:
                transform.position = new Vector2(transform.position.x, transform.position.y + yChange);
                break;
        }
        
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Top") {
            currentState = STUCK_ATAS;
        }else if (collision.gameObject.name == "Bottom")
        {
            currentState = STUCK_BAWAH;
        }
    }
}
