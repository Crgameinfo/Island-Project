using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    [SerializeField]
    private GameObject Chainsaw;
    [SerializeField]
    private Animator pug_animator;
    [SerializeField]
    private Animator hat_animator;
    
    [SerializeField]
    LayerMask mask;
    float Reach   = 2.0f;

    private bool RayHit  ;
    
    //private Transform RightHand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastChecker();
        if (Global.doMove) {
            if (ControlFreak2.CF2Input.GetKeyDown(KeyCode.E)) Cut();
         

        }
        
    }
    private void Cut(){
        
            //ch_animator.SetTrigger("kick1");
            pug_animator.Play("Cutting", 0, 0.25f);
            hat_animator.Play("Cutting", 0, 0.25f);
            Chainsaw.SetActive(true);
            Global.doMove = false;
 
             
        
    }
    private void RaycastChecker(){
            Ray ray2 = new Ray(transform.position, transform.TransformDirection(Vector3.forward) * 2);
            RaycastHit hit2;
			Debug.DrawRay (transform.position, transform.TransformDirection(Vector3.forward) * 2, Color.red);
            if (Physics.Raycast(ray2, out hit2, 45, mask))
            {
                 Debug.Log("Близко");
				 //mode=1;
                
				

			}
			else
			{
            //mode=2;
            Debug.Log("Далеко");
            }
	
    }
    public void AlertObservers(string message)
    {
        if (message.Equals("AttackAnimationEnded"))
        {
            
            Chainsaw.SetActive(false);
            Global.doMove = true;
        }
    }
}
