using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTimeDestroy : MonoBehaviour
{
    public float TimeDestroy;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, TimeDestroy);
    }

    
}
