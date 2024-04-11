using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public GameObject muzzle;
    public Transform FirePos;
    public float bulletForce;
    public float TimeBWTFire;
    float timeBTWFire;

    private AudioManagement audioManagement;

    private void Awake()
    {
        audioManagement = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagement>();
    }

    private void Update()
    {
        RotateGun();
        timeBTWFire -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && timeBTWFire < 0)
        {
            FireBullet();
            audioManagement.PlaySfx(audioManagement.gunClip);
        }
    }

    void RotateGun()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - transform.position;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        transform.rotation = rotation;

        if(transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)
        {
            transform.localScale = new Vector3(1, -1, 0);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 0);
        }
    }

    void FireBullet()
    {
        timeBTWFire = TimeBWTFire;
        GameObject bulletTMP = Instantiate(bullet, FirePos.position, Quaternion.identity);
        Instantiate(muzzle, FirePos.position, transform.rotation, transform);

        Rigidbody2D rb = bulletTMP.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);

    }
}
