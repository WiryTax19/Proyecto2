using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Papa : MonoBehaviour
{
    public GameObject bolita;
    public GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        bolita.transform.SetParent(Player.transform);
        bolita.GetComponent<Rigidbody>().useGravity = false;
        bolita.transform.localPosition = new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            bolita.GetComponent<Rigidbody>().AddForce(transform.forward * 250);
            bolita.GetComponent<Rigidbody>().AddForce(transform.up * 250);
            bolita.transform.SetParent(null);
            bolita.GetComponent<Rigidbody>().useGravity = true;
            bolita.GetComponent<Collider>().isTrigger = false;
        }

        if(bolita.activeSelf == false)
        {
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ground")
        {
            StartCoroutine(TimerReturn());
        }

        if (other.gameObject.tag == "player")
        {
            //while (true)
            {
                StartCoroutine(TimerExplossion());
            }
        }

        if (other.gameObject.tag == "playerother")
        {
            Debug.Log("Toco Playerother");
            //Destroy(gameObject, 5f);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "ground")
        {
            //StartCoroutine(TimerExplossion());
        }
    }

    private IEnumerator TimerReturn()
    {
        yield return new WaitForSeconds(3);

        bolita.transform.SetParent(Player.transform);
        bolita.GetComponent<Rigidbody>().useGravity = false;
        bolita.transform.localPosition = new Vector3(0, 2, 0);
    }

    private IEnumerator TimerExplossion()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("Esto");
        bolita.SetActive(false);
        bolita.transform.SetParent(null);
        yield return new Null();
    }
}
