using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float rotationSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.Translate(new Vector3(0f, 0f, 10f) * Time.deltaTime);

            if (Input.GetKey(KeyCode.A))
            {
                //this.transform.Translate (new Vector3 (-10f, 0f, 5f) * Time.deltaTime);
                this.transform.Rotate(0, -rotationSpeed, 0);
            }

            if (Input.GetKey(KeyCode.D))
            {
                //this.transform.Translate(new Vector3(10f, 0f, 5f) * Time.deltaTime);
                this.transform.Rotate(0, rotationSpeed, 0);
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(new Vector3(0f, 0f, -5f) * Time.deltaTime);

            if (Input.GetKey(KeyCode.A))
            {
                //this.transform.Translate (new Vector3 (-10f, 0f, 5f) * Time.deltaTime);
                this.transform.Rotate(0, rotationSpeed, 0);
            }

            if (Input.GetKey(KeyCode.D))
            {
                //this.transform.Translate(new Vector3(10f, 0f, 5f) * Time.deltaTime);
                this.transform.Rotate(0, -rotationSpeed, 0);
            }
        }

    }
}
