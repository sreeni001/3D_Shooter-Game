using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RayCastGun : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera playerCamera;
    public Transform laserOrigin;
    public float gunRange = 500f;
    public float fireRate = 0.2f;
    public float laserDuration= 0.05f;
    LineRenderer laserLine;
    float fireTimer;
    Rigidbody movement;
    public float speed=20f;
    public float rspeed =2f;
    void Awake()
    {
        laserLine = GetComponent<LineRenderer>();
        movement =GetComponent<Rigidbody>();
    }

    
    void Update()
    {   
        fireTimer += Time.deltaTime;
        Movement();
        GunRotation();

        if(Input.GetButtonDown("Fire1") && fireTimer >fireRate){

            laserLine.SetPosition(0,laserOrigin.position);
            Vector3 rayOrigin = playerCamera.ViewportToWorldPoint(new Vector3(0.5f,0.5f,0));
            RaycastHit hit;
            
            if(Physics.Raycast(rayOrigin, playerCamera.transform.forward,out hit, gunRange)){
                laserLine.SetPosition(1,hit.point);
                Debug.Log("ENtered if1");
                if (hit.transform.gameObject.tag == "Barrel"){
                Debug.Log("ENtered if2");
            
                Destroy(hit.transform.gameObject);

        }
                

            }
            else
            {
                laserLine.SetPosition(1,rayOrigin+(playerCamera.transform.forward*gunRange));

            }
            StartCoroutine(ShootLaser());
        }
    
    }

    void Movement(){
        
            float hori = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            movement.velocity = new Vector3(hori*speed ,movement.velocity.y,vertical*speed);
    }
    void GunRotation(){
        
        float mouseY = Input.GetAxis("Mouse Y");
        float mouseX = Input.GetAxis("Mouse X");
        movement.rotation *=Quaternion.Euler(0,0,mouseY*rspeed);
        //movement.transform.Rotate(Vector3.forward, mouseY * rspeed);
        movement.transform.Rotate(Vector3.up, mouseX * rspeed);
   
    }
   
    IEnumerator ShootLaser(){
        laserLine.enabled = true;
        yield return new WaitForSeconds(laserDuration);
        laserLine.enabled = false;
    }
}
