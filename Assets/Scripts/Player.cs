using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //[Tooltip("")] template

        [Tooltip("RigidBody")]
        public Rigidbody RB;

        [Tooltip("")]
        public LayerMask layermask;



        [Tooltip("How fast player will go")]
        public float speed;

        [Tooltip("How much the player will be offset when going left or right")]
        public Vector3 Offset;
        
        [Tooltip("How much force is applied to player *multiplied by 200")]
        public float JumpForce = 20;  

        [Tooltip("")]
        public float maxdistance;

        [Tooltip("")]
        public Vector3 boxsize;
        



        [Tooltip("Where the player is (-1 = left, 0 = center, 1 = right)")]
        public int WhereIs = 0;


        
        
        
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      /*var dir = new Vector3(Input.GetAxis("Horizontal"),0 , Input.GetAxis("Vertical"));

        transform.Translate(dir * speed * Time.deltaTime);*/

        //Push Forward
        transform.Translate(transform.forward * speed * Time.deltaTime);

        //Go left and right
        if(Input.GetKeyDown(KeyCode.D) && (WhereIs == 0 || WhereIs == -1))
        {
           MoveRight();
        }
        if(Input.GetKeyDown(KeyCode.A) && (WhereIs == 0 || WhereIs == 1))
        {
            MoveLeft();
        }
        
        //Jump
        if(Input.GetKeyDown(KeyCode.Space) && GroundCheck())
        {
           Jump();
        }
    }

    public void MoveLeft()
    {
        transform.Translate(-Offset);
            WhereIs -= 1;
    }
    public void MoveRight()
    {
         transform.Translate(Offset);
            WhereIs += 1;
    }
    public void Jump()
    {
         RB.AddForce(Vector3.up * JumpForce * 200);
    }
     void OnDrawGizmos() 
        {
            Gizmos.color = Color.black;
            Gizmos.DrawCube(transform.position - transform.up * maxdistance ,boxsize);
        }
   
    public bool GroundCheck()
    {
        if(Physics.BoxCast(transform.position,boxsize,-transform.up,transform.rotation,maxdistance,layermask))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
