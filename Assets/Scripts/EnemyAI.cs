using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Unity.VisualScripting;

public class EnemyAI : MonoBehaviour
{
    public Transform target;

    Seeker seeker;
    Path path;
    Rigidbody2D rb;
    Coroutine moveCoroutine;
    public SpriteRenderer characterSR;
    public Animator animator;
    
    public bool isBoss = false;
    public float rollBost = 5f;
    public float RollTime = 0.25f;
    float rollTime;
    bool isRoll = false;

    public float RollTimeColDown = 8f;
    float cDRollTime;

    public float moveSpeed = 2f;
    public float nextWPDistance = 0.3f;
    public float repeatTimeUpdatePath = 0.5f;

    private void Start()
    {
        cDRollTime = 0;
        rb = GetComponent<Rigidbody2D>();
        seeker = GetComponent<Seeker>();
        target = FindObjectOfType<Player>().transform;
        
        InvokeRepeating("CaculatePath", 0f, repeatTimeUpdatePath);
    }

    void CaculatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPathCompleted);
        }
    }

    void OnPathCompleted(Path p)
    {
        if (!p.error)
        {
            path = p;
            MoveToTarget();
        }
    }

    void MoveToTarget()
    {
        if (moveCoroutine !=  null) 
        {
            StopCoroutine(moveCoroutine);
        }
        moveCoroutine = StartCoroutine(MoveToTargetCoroutine());
    }

    IEnumerator MoveToTargetCoroutine()
    {
        int currentWP = 0;

        while (currentWP < path.vectorPath.Count)
        {
            Vector2 direction = ((Vector2)path.vectorPath[currentWP] - rb.position).normalized;
            Vector2 force = direction * moveSpeed * Time.deltaTime;
            transform.position += (Vector3)force;

            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWP]);
            if (distance < nextWPDistance)
            {
                currentWP++;
            }

            if (force.x != 0)
            {
                if(force.x > 0)
                {
                    characterSR.transform.localScale = new Vector3(1, 1, 0);
                }
                else
                {
                    characterSR.transform.localScale = new Vector3(-1, 1, 0);
                }
            }
            yield return null;
        }
    }

    

    private void Update()
    {
        if (isBoss)
        {
            if (cDRollTime > RollTimeColDown)
            {
                cDRollTime = 0;
                if (!isRoll)
                {
                    StartCoroutine(BossRoll());
                }
            }
            else
            {
                cDRollTime += Time.deltaTime;
            }
        }
    }

    IEnumerator BossRoll()
    {
        isRoll = true;
        animator.SetBool("BossRoll", true);
        moveSpeed += rollBost;
        //rollTime = RollTime;

        yield return new WaitForSeconds(RollTime);

        animator.SetBool("BossRoll", false);
        moveSpeed -= rollBost;
        isRoll = false;
    }
}
