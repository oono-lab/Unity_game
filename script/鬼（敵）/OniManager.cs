using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class OniManager : MonoBehaviour
{
    private game_clear_hantei clear_bool;
    private GameObject player;
    private NavMeshAgent navMeshAgent;
    private NewBehaviourScript13 run;
    private DisplayTextOnKeyPress hantei_crear;
    private Animator oni_animator;
    private string GameObject_name = "Escape";
    private string GameObject_name1 = "Main Camera";
    private string GameObject_name2 = "Canvas";
    // Start is called before the first frame update
    void Start()
    {
        GameObject targetObject = GameObject.Find(GameObject_name1);
        clear_bool = targetObject.GetComponent<game_clear_hantei>();
        GameObject targetObject2 = GameObject.Find(GameObject_name2);
        hantei_crear = targetObject2.GetComponent<DisplayTextOnKeyPress>();
        GameObject oni = this.gameObject;

        oni_animator = oni.GetComponent<Animator>();
        GameObject targetObject1 = GameObject.Find(GameObject_name);
        run = targetObject1.GetComponent<NewBehaviourScript13>();
        player = GameObject.Find("player");
        navMeshAgent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {   if (run.hantei == 0)
        {
            if (clear_bool.clear_hantei)
            {
                navMeshAgent.enabled = false;
                hantei_crear.script_hantei(false);
            }
            else
            {
                oni_animator.enabled = true;
                navMeshAgent.destination = player.transform.position;

                UpdateOniMovement();
            }
            
            
        }
        
    }
    void UpdateOniMovement()
    {
        if (navMeshAgent.remainingDistance > navMeshAgent.stoppingDistance)
        {
            navMeshAgent.velocity = (navMeshAgent.steeringTarget - transform.position).normalized * navMeshAgent.speed;
            if (navMeshAgent.pathPending) transform.forward = navMeshAgent.steeringTarget - transform.position;
        }
    }
}
