using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Papa : MonoBehaviour
{
    public GameObject bolita;
    public GameObject Player;
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
        if(Input.GetKeyDown(KeyCode.F))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.forward * 1000);
            GetComponent<Rigidbody>().AddForce(Vector3.up * 1000);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ground")
        {
            Debug.Log("Toco Piso");
            //Destroy(gameObject, 5f);
            bolita.transform.SetParent(Player.transform);
            bolita.transform.localPosition = new Vector3(0, 1, 0);
        }    

        if (other.gameObject.tag == "player")
        {
            Debug.Log("Toco Player");
            //Destroy(gameObject, 5f);
        }
    }
}
