using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{

    public int remainsCost;
    public int woodCost;
    public int gemstoneCost;

    Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ResourceManager.instance.remains < remainsCost || ResourceManager.instance.wood < woodCost || ResourceManager.instance.gemstone < gemstoneCost)
        {
            button.interactable = false;
        }

        else
        {
            button.interactable = true;
        }
    }

    public void RemoveResources()
    {
        ResourceManager.instance.AddResource("remains", -remainsCost);
        ResourceManager.instance.AddResource("wood", -woodCost);
        ResourceManager.instance.AddResource("gemstone", -gemstoneCost);
    }
}
