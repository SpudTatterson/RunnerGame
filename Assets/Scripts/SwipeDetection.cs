using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    public Player player;
    private Vector2 StartPos;
    public int MinDetectionDistance = 20;
    public bool IsFingerDown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!IsFingerDown && Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            StartPos = Input.touches[0].position;
            IsFingerDown = true;
        }
        
        if(IsFingerDown)
        {
            if(Input.touches[0].position.y >= StartPos.y + MinDetectionDistance && player.GroundCheck())
            {
                IsFingerDown = false;
                player.Jump();
            }
            else if(Input.touches[0].position.x <= StartPos.x - MinDetectionDistance && (player.WhereIs == 0 || player.WhereIs == 1))
            {
                IsFingerDown = false;
                player.MoveLeft();
            }
            else if(Input.touches[0].position.x >= StartPos.x + MinDetectionDistance && (player.WhereIs == 0 || player.WhereIs == -1))
            {
                IsFingerDown = false;
                player.MoveRight();
            }
            if(IsFingerDown && Input.touches[0].phase == TouchPhase.Ended)
            {
                IsFingerDown = false;
            }
        }
    }
}
