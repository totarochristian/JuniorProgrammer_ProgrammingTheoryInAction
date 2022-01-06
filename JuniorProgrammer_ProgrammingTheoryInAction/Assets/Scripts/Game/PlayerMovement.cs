using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private float speedWalk = 6f;
    private float speedRun = 12f;
    private float speedRotate = 6f;
    private float forceJump = 10f;
    private bool isRunning;
    private bool isGrounded = true;

    [SerializeField] private GameObject missileSpawnPoint;
    [SerializeField] private GameObject missilePrefab;

    private Animator playerAnim;
    private Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Animals Points").GetComponent<AnimalsPoints>().UpdatePoints();//Update the points text

        playerRb = GetComponent<Rigidbody>();//Get the rigid body
        playerAnim = GetComponent<Animator>();//Get the animator component
        playerAnim.SetBool("Static_b", false);       
    }
    void LateUpdate()
    {
        TransitionWalkRun();
        TransitionJumping();
        SpawnMissile();
        ExitGame();
    }
    void FixedUpdate()
    {
        Move();
    }
    // ABSTRACTION
    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float speed = SelectSpeed();
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        transform.Rotate(Vector3.up * speedRotate * horizontalInput);
        if (horizontalInput == 0 && verticalInput == 0)
            playerAnim.SetFloat("Speed_f", 0);
        else
        {
            if(isRunning)
                playerAnim.SetFloat("Speed_f", 1.1f);
            else
                playerAnim.SetFloat("Speed_f", 0.3f);
        }
    }
    private float SelectSpeed()
    {
        if (isRunning)
            return speedRun;
        else
            return speedWalk;
    }
    private void TransitionWalkRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = !isRunning;//Invert state
        }
    }
    private void TransitionJumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRb.AddForce(Vector3.up * forceJump, ForceMode.Impulse);
            playerAnim.SetBool("Jump_a", true);
            isGrounded = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Terrain")) {
            isGrounded = true;
            playerAnim.SetBool("Jump_a", false);
        }
    }
    private void ExitGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MainManager.instance.SaveData();//Save data
            SceneManager.LoadScene(0);//Return to menu
        }
    }
    private void SpawnMissile()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(missilePrefab, missileSpawnPoint.transform.position, missileSpawnPoint.transform.rotation);
        }
    }
}
