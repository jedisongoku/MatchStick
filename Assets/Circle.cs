using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Circle : MonoBehaviour {

    public static Circle circle;
    public float turnAngle;
    public SpriteRenderer sprite;
    public List<Sprite> circleSprites = new List<Sprite>();
    public List<Collision> circleCollisions = new List<Collision>();

    private float turnAngleBase;

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
        int rand = Random.Range(0, 5);
        transform.rotation = Quaternion.identity;
        sprite.sprite = circleSprites[rand];
        GameManager.gameManager.selectedCircle = rand;
        turnAngle = turnAngleBase;

        switch(rand)
        {
            case 0:
                for(int i = 0; i < circleCollisions.Count; i++)
                {
                    circleCollisions[i].SetColor(((GameManager.Circle_1)i).ToString());
                }
                break;
            case 1:
                for (int i = 0; i < circleCollisions.Count; i++)
                {
                    circleCollisions[i].SetColor(((GameManager.Circle_2)i).ToString());
                }
                break;
            case 2:
                for (int i = 0; i < circleCollisions.Count; i++)
                {
                    circleCollisions[i].SetColor(((GameManager.Circle_3)i).ToString());
                }
                break;
            case 3:
                for (int i = 0; i < circleCollisions.Count; i++)
                {
                    circleCollisions[i].SetColor(((GameManager.Circle_4)i).ToString());
                }
                break;
            case 4:
                for (int i = 0; i < circleCollisions.Count; i++)
                {
                    circleCollisions[i].SetColor(((GameManager.Circle_5)i).ToString());
                }
                break;
        }
    }

    public void StartSpin()
    {
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
