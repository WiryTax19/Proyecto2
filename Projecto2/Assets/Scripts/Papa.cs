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
            GetComponent<Rigidbody>().AddForce(Vector3.forward * 500);
            GetComponent<Rigidbody>().AddForce(Vector3.up * 500);
            bolita.transform.SetParent(null);
            bolita.GetComponent<Rigidbody>().useGravity = true;
            bolita.GetComponent<Collider>().isTrigger = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ground")
        {

            Debug.Log("Toco Piso");
            bolita.transform.SetParent(Player.transform);
            bolita.GetComponent<Rigidbody>().useGravity = false;
            bolita.transform.localPosition = new Vector3(0, 2, 0);
            
        }    

        if (other.gameObject.tag == "player")
        {
            Debug.Log("Toco Player");
            bolita.GetComponent<Collider>().isTrigger = true;
            //Destroy(gameObject, 5f);
        }

        if (other.gameObject.tag == "playerother")
        {
            Debug.Log("Toco Playerother");
        }
    }
}
