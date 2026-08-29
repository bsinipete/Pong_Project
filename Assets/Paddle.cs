using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    float speed;
    float height;

    string input;
    public bool isRight;

    private Vector2 move;
    private PlayerInput playerInput;

    void Awake() {
		playerInput = GetComponent<PlayerInput>();
	}

    void Start () {
        height = transform.localScale.y;
        speed = 10;
        
    }

    public void Init(bool isRightPaddle) {

        isRight = isRightPaddle;    
    
        Vector2 pos = Vector2.zero;
        
        if(isRightPaddle){
            //Place paddle on right
            pos = new Vector2(GameManager.topRight.x, 0);
            pos -= Vector2.right * transform.localScale.x;
            input = "PaddleRight";

        } else {
            //Place paddle on left
            pos = new Vector2(GameManager.bottomLeft.x, 0);
			pos += Vector2.right * transform.localScale.x;
            input = "PaddleLeft";    
        }


		//Update this paddle's position
		transform.position = pos;
        transform.name = input;

        //swap inputs between paddles
        playerInput.SwitchCurrentActionMap(input);
    }


    void OnPaddleLeft(InputValue value){
        if (!isRight) { 
            move = value.Get<Vector2>();
        }
    }
    void OnPaddleRight(InputValue value){
        if (isRight) {
            move = value.Get<Vector2>();
        }
    }

    //what "moves" the paddle
    void Update() {
        transform.Translate(new Vector3(0, move.y, 0) * speed * Time.deltaTime);

        //If paddle gets too low, stop
        if(transform.position.y < GameManager.bottomLeft.y + height / 2 && move.y < 0){
            move.y = 0;
        }

        //If paddle gets too high, stop
        if(transform.position.y > GameManager.topRight.y - height / 2 && move.y > 0){
            move.y = 0;
        }
    }

    void OnExitGame(InputValue value){
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}

