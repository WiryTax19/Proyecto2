using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class Papa : MonoBehaviour
{
    [SerializeField] private GameObject bolita;
    [SerializeField] private GameObject Player;
    [SerializeField] private bool itsHided = false;
    //[SerializeField] private bool itsHolded = false;

    // Start is called before the first frame update
    void Start()
    {
        //Bola se hace hija de player
        bolita.transform.SetParent(null);
        bolita.GetComponent<Rigidbody>().useGravity = true;
        bolita.transform.localPosition = new Vector3(0, 1, 0);

        timerReturn = TimerReturn(3.0f);
        timerExplossion = TimerExplossion(8.0f);
        timerRespawn = TimerRespawn(3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //Se lanza la bola y se quita de padre player
        if(Input.GetKeyDown(KeyCode.F))
        {
            bolita.GetComponent<Rigidbody>().AddForce(transform.forward * 250);
            bolita.GetComponent<Rigidbody>().AddForce(transform.up * 250);
            bolita.transform.SetParent(null);
            bolita.GetComponent<Rigidbody>().useGravity = true;
            bolita.GetComponent<Collider>().isTrigger = false;

            //StopCoroutine(timerExplossion);
        }

        if(itsHided == true)
        {
            Debug.Log("Se Escondio");
            StartCoroutine(timerRespawn);
        }

        //if (bolita.transform.parent.parent == Player) 
        //{
            //Debug.Log("itsHolded True");
        //}

        //if(itsHolded == true)
        //{
            //StartCoroutine(TimerExplossion());
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        //Si toca el piso empieza el timer para regresar
        if (other.gameObject.tag == "ground")
        {
            StartCoroutine(timerReturn);
        }

        //Si toca al player empieza el timer de explosion
        if (other.gameObject.tag == "player")
        {
            //itsHolded = true;
            StartCoroutine(timerExplossion);
        }

        if (other.gameObject.tag == "playerother")
        {
            
        }
    }
    private IEnumerator timerReturn;
    private IEnumerator timerExplossion;
    private IEnumerator timerRespawn;

    private IEnumerator TimerReturn(float waitTime)
    {
        //Regresa con Player despues de los segundos
        Debug.Log("Empezo TimerReturn");
        yield return new WaitForSeconds(waitTime);

        bolita.transform.SetParent(Player.transform);
        bolita.GetComponent<Rigidbody>().useGravity = false;
        bolita.transform.localPosition = new Vector3(0, 2, 0);
    }

    private IEnumerator TimerExplossion(float waitTime)
    {
        //Se esconde si pasan los segundos
        Debug.Log("Empezo TimerExplossion");
        yield return new WaitForSeconds(waitTime);
        Debug.Log("BUUUM Explotaste");
        bolita.GetComponent<Renderer>().enabled = false;
        bolita.transform.SetParent(null);
        bolita.transform.localPosition = new Vector3(0, 2, 0);
        itsHided = true;
    }

    private IEnumerator TimerRespawn(float waitTime)
    {
        Debug.Log("Empezo TimerRespawn");
        itsHided = false;
        yield return new WaitForSeconds(waitTime);

        bolita.GetComponent<Rigidbody>().useGravity = true;
        bolita.GetComponent<Renderer>().enabled = true;
        bolita.transform.localPosition = new Vector3(1, 2, 0);

    }
}
