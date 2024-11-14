using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResourceManager : MonoBehaviour
{
    public int wood;
    public int remains;
    public int gemstone;

    public TMP_Text woodDisplay;
    public TMP_Text remainsDisplay;
    public TMP_Text gemstoneDisplay;

    public static ResourceManager instance;

    public int numberOfWorkersSacrificed;
    public TMP_Text sacrificedTxt;
    public int sacrificeGoal;

    public int gameWinIndex;

    private void Awake()
    {
        instance = this;
    }

    public void AddResource(string resourceType, int amount)
    {

        if (resourceType == "wood")
        {
            wood += amount;
            woodDisplay.text = wood.ToString();
        }

        if (resourceType == "remains")
        {
            remains += amount;
            remainsDisplay.text = remains.ToString();
        }

        if (resourceType == "gemstone")
        {
            gemstone += amount;
            gemstoneDisplay.text = gemstone.ToString();
        }
    }

    public void AddSacrificedWorker()
    {
        numberOfWorkersSacrificed++;
        sacrificedTxt.text = numberOfWorkersSacrificed + " / " + sacrificeGoal;

        if (numberOfWorkersSacrificed >= sacrificeGoal)
        {
            print("You Win");
            SceneManager.LoadScene(gameWinIndex);
        }
    }
}
