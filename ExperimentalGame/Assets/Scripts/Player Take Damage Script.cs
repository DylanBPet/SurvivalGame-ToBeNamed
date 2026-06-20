using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTakeDamageScript : MonoBehaviour
{
    public Slider playerHealthBar;

    public SpawningEnemyScript spawningEnemyScript;

    public GameObject player;
    public Transform playerKnockbackZone;

    public int enemyVariantOneContactDamage = 10;
    public int knockbackRange = 8;

    public Coroutine expandingKnockbackZoneCoroutine;

    public bool invincibleFrames;
    // Update is called once per frame
    void Update()
    {
        if (invincibleFrames == false)
        {
            CheckForDamage();
        }
    }

    public void CheckForDamage()
    {
        //enemy variant one check
        for (int i = 0; i < spawningEnemyScript.spawnedEnemiesOne.Count; i++)
        {
            Transform playerTransform = player.GetComponent<Transform>();
            SpriteRenderer enemySR = spawningEnemyScript.spawnedEnemiesOne[i].GetComponent<SpriteRenderer>();
            if (enemySR.bounds.Contains(playerTransform.transform.position))
            {
                PlayerTakeDamage(enemyVariantOneContactDamage);
            }
        }
    }
    public void PlayerTakeDamage(int damageAmount)
    {
        Debug.Log("player has been touched");
        InvincibilityToggle();
        playerHealthBar.value -= damageAmount;
        expandingKnockbackZoneCoroutine = StartCoroutine(ExpandKnockbackZone());
        Debug.Log("player has taken damage");
    }

    IEnumerator ExpandKnockbackZone()
    {
        playerKnockbackZone.localScale = Vector2.one;

        float t = 0.7f;
        while (playerKnockbackZone.localScale.x <= knockbackRange && playerKnockbackZone.localScale.y <= knockbackRange)
        {
            t += Time.deltaTime;
            playerKnockbackZone.localScale = Vector2.one * t * 2;
            yield return null;
        }
        playerKnockbackZone.localScale = Vector2.zero;
    }

    IEnumerator InvincibilityToggle()
    {
        float t = 0;
        while(t > 2)
        {
            invincibleFrames = true;
            yield return null;
        }

    }

}
