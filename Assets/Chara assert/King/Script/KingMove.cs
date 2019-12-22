using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingMove : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Camera mainCamera;
  //  private float cameraHeight;
  //  private float cameraX;
   // private float cameraZ;
    [SerializeField]
    private float speed;
    float halfSpeed;

    private Vector3 wantedPosition;

    private float currentX;
    private float currentY;
    private float currentZ;

    private float goCurrentX;
    private float goCurrentX2;
    private float goCurrentZ;
    private float goCurrentZ2;

    private float xVelocity = 0.0F;
    private float yVelocity = 0.0F;
    private float zVelocity = 0.0f;

    private float xVelocitygo = 0.0F;
    private float zVelocitygo = 0.0f;
    private float xVelocitygo2 = 0.0F;
    private float zVelocitygo2 = 0.0f;
    private float distanceSnapTime = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
       // cameraHeight = mainCamera.transform.position.y;
       // cameraX = this.gameObject.transform.position.x - mainCamera.transform.position.x;
       // cameraZ = this.gameObject.transform.position.z - mainCamera.transform.position.z;
        halfSpeed = Mathf.Sqrt(speed);
    }

    // Update is called once per frame
    void Update()
    {
        //mainCamera.transform.position = new Vector3(this.gameObject.transform.position.x-cameraX, cameraHeight, this.gameObject.transform.position.z-cameraZ);
        Vector3 targetPos = this.gameObject.transform.position;

        wantedPosition.x = targetPos.x;

        wantedPosition.z = targetPos.z + 7f;//Vector3.forward*distance;   

        wantedPosition.y = targetPos.y + 5f;// + heightAbovePlayer;

        currentX = Mathf.SmoothDamp(currentX, wantedPosition.x, ref xVelocity, distanceSnapTime);

        currentY = Mathf.SmoothDamp(currentY, wantedPosition.y, ref yVelocity, distanceSnapTime);

        currentZ = Mathf.SmoothDamp(currentZ, wantedPosition.z, ref zVelocity, 0.5f);

        mainCamera.transform.position = new Vector3(currentX, currentY, currentZ);



        goCurrentX = Mathf.SmoothDamp(goCurrentX,  + speed, ref xVelocitygo, distanceSnapTime);

        goCurrentX2 = Mathf.SmoothDamp(goCurrentX2,  - speed, ref xVelocitygo2, distanceSnapTime);

        goCurrentZ = Mathf.SmoothDamp(goCurrentZ,  + speed, ref zVelocitygo, distanceSnapTime);

        goCurrentZ2 = Mathf.SmoothDamp(goCurrentZ2,  - speed, ref zVelocitygo2, distanceSnapTime);

        mainCamera.transform.LookAt(transform.position + new Vector3(0f, 0f, -10f));
        animator.SetBool("rightMove", false);
        animator.SetBool("leftMove", false);
        animator.SetBool("frontMove", false);
        animator.SetBool("backMove", false);
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("frontMove", true);
            this.gameObject.transform.localPosition += Vector3.Lerp(new Vector3(0,0,0), new Vector3(0, 0, goCurrentZ),Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("leftMove", true);
            this.gameObject.transform.localPosition += Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(goCurrentX2, 0, 0), Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("backMove", true);
            this.gameObject.transform.localPosition += Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(0, 0, goCurrentZ2), Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("rightMove", true);
            this.gameObject.transform.localPosition += Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(goCurrentX, 0, 0), Time.deltaTime);
        }
        /*
        if(Input.GetKeyDown(KeyCode.W)&& Input.GetKeyDown(KeyCode.A))
        {
            this.gameObject.transform.localPosition += new Vector3(-halfSpeed, 0, halfSpeed);
        }
        if (Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.D))
        {
            this.gameObject.transform.localPosition += new Vector3(halfSpeed, 0, halfSpeed);
        }

        if (Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.A))
        {
            this.gameObject.transform.localPosition += new Vector3(-halfSpeed, 0, -halfSpeed);
        }
        if (Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.D))
        {
            this.gameObject.transform.localPosition += new Vector3(halfSpeed, 0, -halfSpeed);
        }*/
    }
}
