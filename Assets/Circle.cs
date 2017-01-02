using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Circle : MonoBehaviour {

    public static Circle circle;
    public float turnAngle;
    public SpriteRenderer sprite;
    public List<Sprite> circleSprites = new List<Sprite>();
    public List<Collision> circleCollisions = new List<Collision>();
    public static List<Collision> circleCollision = new List<Collision>();

    private float turnAngleBase;
    private static int randomNumber;

    // Use this for initialization
    void Start ()
    {
        circle = this;
        turnAngleBase = turnAngle;
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void SetCircle()
    {
        
        
        switch(GameManager.gameManager.selectedDifficulty)
        {
            case 1:
                randomNumber = Random.Range(0, 3);
                switch (randomNumber)
                {
                    case 0:
                        for (int i = 0; i < circleCollisions.Count; i++)
                        {
                            circleCollisions[i].SetColor(((GameManager.Circle_1_Easy)i).ToString());
                        }
                        break;
                    case 1:
                        for (int i = 0; i < circleCollisions.Count; i++)
                        {
                            circleCollisions[i].SetColor(((GameManager.Circle_2_Easy)i).ToString());
                        }
                        break;
                    case 2:
                        for (int i = 0; i < circleCollisions.Count; i++)
                        {
                            circleCollisions[i].SetColor(((GameManager.Circle_3_Easy)i).ToString());
                        }
                        break;

                }
                break;
            case 2:
                randomNumber = Random.Range(0, 5);
                switch (randomNumber)
                {
                    case 0:
                        for (int i = 0; i < circleCollisions.Count; i++)
                        {
                            circleCollisions[i].SetColor(((GameManager.Circle_1_Medium)i).ToString());
                        }
                        break;
                    case 1:
                        for (int i = 0; i < circleCollisions.Count; i++)
                        {
                            circleCollisions[i].SetColor(((GameManager.Circle_2_Medium)i).ToString());
                        }
                        break;
                    case 2:
                        for (int i = 0; i < circleCollisions.Count; i++)
                        {
                            circleCollisions[i].SetColor(((GameManager.Circle_3_Medium)i).ToString());
                        }
                        break;
                    case 3:
                        for (int i = 0; i < circleCollisions.Count; i++)
                        {
                            circleCollisions[i].SetColor(((GameManager.Circle_4_Medium)i).ToString());
                        }
                        break;
                    case 4:
                        for (int i = 0; i < circleCollisions.Count; i++)
                        {
                            circleCollisions[i].SetColor(((GameManager.Circle_5_Medium)i).ToString());
                        }
                        break;
                }
                break;
            case 3:
                randomNumber = Random.Range(0, 2);
                switch (randomNumber)
                {
                    case 0:
                        for (int i = 0; i < circleCollisions.Count; i++)
                        {
                            circleCollisions[i].SetColor(((GameManager.Circle_1_Hard)i).ToString());
                        }
                        break;
                    case 1:
                        for (int i = 0; i < circleCollisions.Count; i++)
                        {
                            circleCollisions[i].SetColor(((GameManager.Circle_2_Hard)i).ToString());
                        }
                        break;
                }
                break;
        }
        

        transform.rotation = Quaternion.identity;
        sprite.sprite = circleSprites[randomNumber];
        GameManager.gameManager.selectedCircle = randomNumber;
        turnAngle = turnAngleBase;
    }

    public void StartSpin()
    {
        Debug.Log("Active? " + gameObject.activeInHierarchy);
        StartCoroutine(SpinCircle());
    }

    IEnumerator SpinCircle()
    {
        transform.Rotate(0, 0, turnAngle);

        yield return new WaitForSeconds(0);

        if (!GameManager.gameOver)
        {
            StartCoroutine(SpinCircle());
        }


    }
}
