using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ctfccontrol : MonoBehaviour
{
    float xDirection;
    float yDirection;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30;
    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = 10;
        xDirection = Input.GetAxisRaw("Horizontal");
        yDirection = Input.GetAxisRaw("Vertical");
//		Debug.Log(xDirection);
		float moveStepX = moveSpeed * xDirection * Time.deltaTime;
        if ((transform.position.x <= -7.73 && xDirection < 0 )||(transform.position.x >= 7.77 && xDirection > 0)) {
            return;
        }
        transform.position = transform.position + new Vector3(moveStepX, 0, 0);
        float moveStepY = moveSpeed * yDirection * Time.deltaTime;
        transform.position = transform.position + new Vector3(0, moveStepY, 0);


    }
}
