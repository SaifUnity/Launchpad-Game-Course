using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{

    public ghost worker;
    public ghost spikes;
    public ghost gemstone;
    public ghost tree;
    public GhostVillage village;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnShopClick(string whatItem)
    {
        if (whatItem == "worker")
        {
            Instantiate(worker);
        }

        if (whatItem == "village")
        {
            Instantiate(village);
        }

        if (whatItem == "tree")
        {
            Instantiate(tree);
        }

        if (whatItem == "gemstone")
        {
            Instantiate(gemstone);
        }

        if (whatItem == "spikes")
        {
            Instantiate(spikes);
        }
    }
}
