using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    //[Tooltip("")] template

        [Tooltip("RigidBody")]
        public Rigidbody RB;

        [Tooltip("What object layer should the player be able to jump on ")]
        public LayerMask layermask;

        [Tooltip("Current GameManager")]
        GameObject GameManager;

        [Tooltip("Current Tilespawner")]
        TileSpawner Tilespawner;

        [Tooltip("Current ScoreController")]
        ScoreController ScoreController;

        [Tooltip("Death Canvas")]
        public GameObject DeathCanvas;
        
        [Tooltip("Pause menu Canvas")]
        public GameObject PauseCanvas;

        [Tooltip("How fast player will go")]
        public float speed;

        [Tooltip("How much the player will be offset when going left or right")]
        public Vector3 Offset;
        
        [Tooltip("How much force is applied to player *multiplied by 200")]
        public float JumpForce = 20;  

        [Tooltip("Is the player alive")]
        public bool IsAlive = true;  

        [Tooltip("Maxium distance from the floor that the player can jump from")]
        public float maxdistance;

        [Tooltip("Ground check box size")]
        public Vector3 boxsize;

        



        [Tooltip("Where the player is (-1 = left, 0 = center, 1 = right)")]
        public int WhereIs = 0;
        public bool IsPaused = false;

        
        
        
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameController");
        Tilespawner = GameManager.GetComponent<TileSpawner>();
        ScoreController = GameManager.GetComponent<ScoreController>();
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      /*var dir = new Vector3(Input.GetAxis("Horizontal"),0 , Input.GetAxis("Vertical"));

        transform.Translate(dir * speed * Time.deltaTime);*/
        if(IsAlive)
        {
            if(Input.GetKeyDown(KeyCode.Escape) && IsPaused == false)
            {
                IsPaused = true;
                Time.timeScale = 0;
                PauseCanvas.SetActive(true);
            }
            else if(Input.GetKeyDown(KeyCode.Escape) && IsPaused == true)
            {
                IsPaused = false;
                Time.timeScale = 1;
                PauseCanvas.SetActive(false);
            }
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
    public void Death()
    {   
        IsAlive = false;
        DeathCanvas.SetActive(true);
        ScoreController.setscore(ScoreController.DeathText);
    }
    void OnTriggerEnter(Collider Col)
    {
        if(Col.tag == "Obstacle")
        {
            Death();
            return;
        }
            Destroy(Col.gameObject);
            Tilespawner.Spawn();
    }

}
