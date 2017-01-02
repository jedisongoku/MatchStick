using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {/*
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if(GameManager.colorMatch)
            {
                Stick.stick.SetStickColor();
                Stick.stick.turnAngle *= -1;
            }
        }*/
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("FIRED");
            if (GameManager.colorMatch)
            {
                Stick.stick.SetStickColor();
                Stick.stick.turnAngle *= -1;
            }
            else
            {
                GameManager.gameOver = true;
            }
        }
    }
}
