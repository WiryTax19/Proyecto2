using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Papa : MonoBehaviour
{
    //public GameObject explosion;
    //float time;

    // Start is called before the first frame update
    void Start()
    {
        //time += Time.deltaTime;
        //if (time >= 3) Instantiate(explosion, transform.position, Quaternion.identity);
        //{
            //Destroy(gameObject, 3);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 5f);
    }
}
