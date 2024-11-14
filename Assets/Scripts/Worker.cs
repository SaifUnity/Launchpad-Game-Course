using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    bool isSelected;

    public LayerMask resourceLayer;

    public float collectDistance;

    Resource currentResource;

    public float timeBetweenCollects;
    float nextCollectTime;
    public int collectAmount;

    GameObject bloodAltar;

    public GameObject Remains;

    public float distanceToAltar;

    public GameObject resourcePopup;

    private Animator camAnim;

    public GameObject bloodAltarFed;
    public GameObject isSelectedPop;
    public GameObject workerDeath;

    public GameObject woodMiningSound;
    public GameObject gemstoneMiningSound;
    public GameObject remainsMiningSound;

    private void Start()
    {
        camAnim = Camera.main.GetComponent<Animator>();
        bloodAltar = GameObject.FindGameObjectWithTag("Altar");
    }

    void Update()
    {
        if (isSelected)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            transform.position = mousePos;
        }

        else
        {

            if (Vector3.Distance(transform.position, bloodAltar.transform.position) < distanceToAltar)
            {
                Instantiate(workerDeath);
                Instantiate(bloodAltarFed, transform.position, Quaternion.identity);
                ResourceManager.instance.AddSacrificedWorker();
                Destroy(gameObject);
            }

            Collider2D col = Physics2D.OverlapCircle(transform.position, collectDistance, resourceLayer);
            if (col != null && currentResource == null)
            {
                currentResource = col.GetComponent<Resource>();
            }

            else
            {
                currentResource = null;
            }

            if (currentResource != null && currentResource.gameObject.tag == "Remains")
            {
                if (Time.time > nextCollectTime)
                {
                    nextCollectTime = Time.time + timeBetweenCollects;
                    currentResource.resourceAmount -= collectAmount;
                    Instantiate(remainsMiningSound, transform.position, Quaternion.identity);
                    ResourceManager.instance.AddResource(currentResource.resourceType, collectAmount);
                    Instantiate(resourcePopup, transform.position, Quaternion.identity);
                }
            }

            if (currentResource != null && currentResource.gameObject.tag == "Gemstone")
            {
                if (Time.time > nextCollectTime)
                {
                    nextCollectTime = Time.time + timeBetweenCollects;
                    currentResource.resourceAmount -= collectAmount;
                    Instantiate(gemstoneMiningSound, transform.position, Quaternion.identity);
                    ResourceManager.instance.AddResource(currentResource.resourceType, collectAmount);
                    Instantiate(resourcePopup, transform.position, Quaternion.identity);
                }
            }

            if (currentResource != null && currentResource.gameObject.tag == "Wood")
            {
                if (Time.time > nextCollectTime)
                {
                    nextCollectTime = Time.time + timeBetweenCollects;
                    currentResource.resourceAmount -= collectAmount;
                    Instantiate(woodMiningSound, transform.position, Quaternion.identity);
                    ResourceManager.instance.AddResource(currentResource.resourceType, collectAmount);
                    Instantiate(resourcePopup, transform.position, Quaternion.identity);
                }
            }
        }
    }

    private void OnMouseDown()
    {
        Instantiate(isSelectedPop);
        isSelected = true;
    }

    private void OnMouseUp() 
    {
        isSelected = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isSelected == false)
        {
            if (collision.tag == "Enemy")
            {
                Instantiate(workerDeath);
                camAnim.SetTrigger("shake");
                Instantiate(Remains, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        
    }
}
