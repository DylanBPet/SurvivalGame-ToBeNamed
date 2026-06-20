using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class ControllingXPandLvlupScript : MonoBehaviour
{
    public GameObject xpPip;
    public List<GameObject> pipList;

    public Transform player;
    public float playerPickupRange = 100;

    public Slider playerXpBar;
    public TextMeshProUGUI playerLevelDisplay;

    public int playerLevel = 0;

    void Update()
    {
        playerLevelDisplay.SetText("Player Level " + playerLevel);
        for (int i = 0; i < pipList.Count; i++)
        {
            SpriteRenderer pipTransform = pipList[i].GetComponent<SpriteRenderer>();
            float distance = Vector2.Distance(pipTransform.transform.position, player.transform.position);

            if (distance <= playerPickupRange)
            {
                Destroy(pipList[i]);
                pipList.Remove(pipList[i]);

                playerXpBar.value++;
                if (playerXpBar.value == playerXpBar.maxValue)
                {
                    LevelUp();
                }
            }
        }
    }

    public void SpawnXpPip(Vector2 spawnPoint)
    {
        pipList.Add(Instantiate(xpPip, spawnPoint, Quaternion.identity));
    }

    public void LevelUp()
    {
        playerLevel++;
        playerXpBar.value = 0;
        playerXpBar.maxValue++;

    }
}
