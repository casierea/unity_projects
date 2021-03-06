﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiRetaget : MonoBehaviour {

    private NavMeshAgent agent;

    //public Transform Destination;
    public Transform Target;
    //public Transform Destination3;
    //can we have a target type set here?
    //target type text, read into scan for targets as tag
    //public textbox targeType;
    //collection TargetList
    private GameObject[] targetList;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
        //get initial target
    }


    void Update()
    {
        //if (Destination != null) agent.destination = Destination.position;
        if (Target != null)
        {
            agent.destination = Target.position;
        }
        else
        {
            scanForTargets();
            SetNewTarget();
        }
    }

    private void scanForTargets()
    {
        //make list of targets using findgameobjectswithtag
        targetList = GameObject.FindGameObjectsWithTag("object");
        if (targetList.Length == 0)
        {
            //Debug.Log(gameObject.GetComponent<DestroyOnCollision>().Score.ToString());
            var player = GameObject.FindGameObjectWithTag("Player");
          int playerScore = player.GetComponent<DestroyOnCollision>().Score;
            int Score = gameObject.GetComponent<DestroyOnCollision>().Score;
            
           if (playerScore > Score)
            {
                Debug.Log("Player wins!!");
           }
           else if (playerScore < Score)
           {
               Debug.Log("Enemy of Evil Wins!!");
            }
           else
           {
                Debug.Log("Tie with Evil!!");
            }

        //Debug.Log(player.GetComponent<DestroyOnCollision>().Score.ToString());
        }
        foreach (var target in targetList)
        {
            Debug.Log(target.name);
        }
        Debug.Log(targetList.ToString());
        //return targetList;
    }

public void SetNewTarget()
{
    GameObject closest = null;
     float distance = Mathf.Infinity;
     Vector3 position = transform.position;
     foreach (GameObject go in targetList)
     {
         Vector3 diff = go.transform.position - position;
         float curDistance = diff.sqrMagnitude;
         if (curDistance < distance)
         {
             closest = go;
             distance = curDistance;
         }
     }
     //return closest;
    Target = closest.transform;
}
 }

