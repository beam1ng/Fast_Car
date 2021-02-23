using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    public float turnSpeed = 10f;
    public float accelerationSpeed = 10f;
    private bool isBacking = false;
    private bool isAccelerating = false;
    private float turnDirection = 0;
    public Time_update tu;
    public Rigidbody rb;
    private string[] scenes = {"lvl1","lvl2"};

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 0)
        {
            LevelReset();
        }
    }

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * turnDirection * turnSpeed);
        if (isAccelerating)
        {
            rb.AddForce(transform.forward * accelerationSpeed * Time.deltaTime, ForceMode.Acceleration);
        }
        if (isBacking)
        {
            rb.AddForce(-1 * transform.forward * accelerationSpeed * Time.deltaTime, ForceMode.Acceleration);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            //LevelReset();
            tu.racing = false;
        }
    }

    public void Restart(InputAction.CallbackContext context)
    {
        LevelReset();
    }

    public void Turn(InputAction.CallbackContext context)
    {
        turnDirection = context.ReadValue<float>();
    }

    public void Accelerate(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isAccelerating = true;
        }
        else
        {
            isAccelerating = false;
        }
    }

    public void Go_back(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isBacking = true;
        }
        else
        {
            isBacking = false;
        }
    }

    public void LevelReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LevelSwitch(InputAction.CallbackContext context)
    {
        string currentScene = SceneManager.GetActiveScene().name;
        for(int i = 0; i < scenes.Length; i++)
        {
            if (scenes[i] == currentScene)
            {
                if (i == scenes.Length - 1)
                {
                    SceneManager.LoadScene(scenes[0]);
                }
                else
                {
                    SceneManager.LoadScene(scenes[i + 1]);
                }
            }
        }
    }
}
