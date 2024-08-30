using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speedMove; // скорость персонажа

    private float gravityForce; //гравитация персонажа
    private Vector3 moveVector; // направление движения персонажа

    private CharacterController ch_controler;
    public Animator ch_animator;
    public Animator hat_animator;
    void Start()
    {
        ch_controler = GetComponent <CharacterController>();
        //ch_animator = ch_animator.GetComponent <Animator>();
    }
     void Update()
    {
        CharacterMove();
        GamingGravity();
        Attack();

    }
    private void Attack(){
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ch_animator.SetTrigger("kick1");
        }
    }
    private void CharacterMove(){
        if (ch_controler.isGrounded){

        
        moveVector = Vector3.zero;
        moveVector.x = Input.GetAxis("Horizontal") * speedMove;
        moveVector.z = Input.GetAxis("Vertical") * speedMove;

        //animation
        if (moveVector.x!=0||moveVector.z!=0) 
        {
            ch_animator.SetBool("walking",true);
            hat_animator.SetBool("walking",true);
        }
        else 
        {
            ch_animator.SetBool("walking",false);
            hat_animator.SetBool("walking",false);
        }

        if (Vector3.Angle(Vector3.forward,moveVector)>1f || Vector3.Angle(Vector3.forward,moveVector)==0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward,moveVector,speedMove, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }

        }
      moveVector.y = gravityForce;
      ch_controler.Move (moveVector*Time.deltaTime);

    }
    private void GamingGravity(){
        if (!ch_controler.isGrounded) gravityForce -= 20f *Time.deltaTime;
        else gravityForce = -1f; 
    }
}
