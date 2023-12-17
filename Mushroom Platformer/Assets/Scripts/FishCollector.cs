using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishCollector : MonoBehaviour
{
    private int collectedFishCount = 0;
    public int fishNeededToWin = 5;

    // called when colliders interact
    private void OnTriggerEnter(Collider other)
    {
        // checks for fish tag
        if (other.CompareTag("Fish"))
        {
            //call collectfish
            CollectFish(other.gameObject);

            // destory object
            Destroy(other.gameObject);

            // check if the player wins
            if (collectedFishCount >= fishNeededToWin)
            {
                WinGame();
            }
        }
    }

    private void CollectFish(GameObject fish)
    {
        //update fishcount
        collectedFishCount++;
    }

    private void WinGame()
    {
        // opens winner scene
        SceneManager.LoadScene("WinnerScene");
    }
}
