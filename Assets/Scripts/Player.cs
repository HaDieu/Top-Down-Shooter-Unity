using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SpriteRenderer characterSR;
    Vector3 moveInput;
    public float moveSpeed = 2f;
    public Animator animator;

    public float rollBost = 4f;
    float rollTime;
    public float RollTime;
    bool isRoll = false;

    public float CoolDownRollTime = 3f;
    float coolDownRollTime;

    public GameObject gameOver;

    public AudioManagement audioManagement;

    private void Awake()
    {
        audioManagement = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagement>();    
    }

    private void Start()
    {
        coolDownRollTime = CoolDownRollTime;
        Time.timeScale = 1;
        gameOver.SetActive(false);
    }
    private void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        transform.position += moveInput * moveSpeed * Time.deltaTime;

        if (moveInput.x != 0)
        {
            if (moveInput.x > 0) 
            {
                characterSR.transform.localScale = new Vector3(1, 1, 0);
            }
            else
            {
                characterSR.transform.localScale = new Vector3(-1, 1, 0);
            }
            animator.SetBool("isWalk", true);
        }
        else
        {
            animator.SetBool("isWalk", false);
        }

        
        //if (Input.GetKeyDown(KeyCode.Space) && rollTime <=0)
        //{
        //    animator.SetBool("Roll", true);
        //    moveSpeed += rollBost;
        //    rollTime = RollTime;
        //    isRoll = true;
        //}

        //if( rollTime <= 0 && isRoll == true)
        //{
        //    animator.SetBool("Roll", false);
        //    moveSpeed -= rollBost;
        //    isRoll = false;
        //}
        //else
        //{
        //    rollTime -= Time.deltaTime;
        //}

        if(Input.GetKeyDown(KeyCode.Space) && coolDownRollTime >= CoolDownRollTime) 
        {
            coolDownRollTime = 0;
            StartCoroutine(PlayerRoll());
        }

        if (coolDownRollTime < CoolDownRollTime)
        {
            coolDownRollTime += Time.deltaTime;
        }
    }

    IEnumerator PlayerRoll()
    {
        isRoll = true;
        moveSpeed += rollBost;
        animator.SetBool("Roll", true);

        yield return new WaitForSeconds(RollTime);

        isRoll = false;
        animator.SetBool("Roll", false);
        moveSpeed -= rollBost;
        
    }

    public Health healthPlayer;
    public void TakeDamage(int damage)
    {
        healthPlayer.TakeDam(damage);
        if(healthPlayer.isDead)
        {
            Time.timeScale = 0;
            gameOver.SetActive(true);
            audioManagement.StopMusic();

            audioManagement.PlaySfx(audioManagement.gameOverClip);
        }
    }


}
