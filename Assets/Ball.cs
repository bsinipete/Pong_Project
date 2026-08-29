using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Ball : MonoBehaviour
{

    [SerializeField]
    float speed = 5;

    float radius;
    Vector2 direction;

    void Start()
    {
        direction = Vector2.one.normalized; //direction is (1,1) normalized
        radius = transform.localScale.x / 2;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (transform.position.y < GameManager.bottomLeft.y + radius && direction.y < 0)
        {
            direction.y = -direction.y;
        }
        if (transform.position.y > GameManager.topRight.y - radius && direction.y > 0)
        {
            direction.y = -direction.y;
        }

        //Game over
        if (transform.position.x < GameManager.bottomLeft.x + radius && direction.x < 0)
        {
            Debug.Log("Right player wins!!");
            Time.timeScale = 0;
            enabled = false;
        }
        if (transform.position.x > GameManager.topRight.x - radius && direction.x > 0)
        {
            Debug.Log("Left player wins!!");
            Time.timeScale = 0;
            enabled = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Paddle"){
            bool isRight = other.GetComponent<Paddle>().isRight;

            //if hitting right paddle, ricochet
            if(isRight == true && direction.x > 0){
                direction.x = -direction.x;
            }

            //if hitting left paddle
            if (isRight == false && direction.x < 0){
				direction.x = -direction.x;
			}
		}
    }

}
