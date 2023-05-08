using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public CharacterStat characterStats;

    public float MaxHealth = 100f;
    public float currentHealth;

    public HealthBar healthBar;
    //扣血
    public float harm = 0.1f;
    public float speed = 0.1f;

    float startTime;

    private void Start()
    {
        characterStats = new CharacterStat(100);

        currentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);

    }

    private void Update()
    {
        //使用能力消耗
        if (Input.GetKey(KeyCode.E)) {
            TakeDamage(0.015f);
        }
        //隨時間回復
        if (currentHealth <= MaxHealth)
        {
            RecoverDamage(0.001f);
            StartCoroutine(Coroutine());
        }
    }

    void TakeDamage(float damage)
    {
        currentHealth -= damage;
        //Tiam.time 楨開始時間(read only)
        startTime = Time.time;

        if (currentHealth != currentHealth)
        {
            //Lerp(開始值，結束值，每次扣血的百分比) 當開始值趨向於結束值時，扣血速度會越來越慢 通過 當前時間減去開始扣血的時間*扣血百分比來解決
            currentHealth = Mathf.Lerp(currentHealth, currentHealth, (Time.time - startTime) * speed);
        }

        healthBar.SetHealth(currentHealth);
    }   
    void RecoverDamage(float damage)
    {
        currentHealth += damage;
        //Tiam.time 楨開始時間(read only)
        startTime = Time.time;

        if (currentHealth != currentHealth)
        {
            //Lerp(開始值，結束值，每次扣血的百分比) 當開始值趨向於結束值時，扣血速度會越來越慢 通過 當前時間減去開始扣血的時間*扣血百分比來解決
            currentHealth = Mathf.Lerp(currentHealth, currentHealth, (Time.time + startTime) * speed);
        }
        if (currentHealth > MaxHealth) currentHealth = MaxHealth;
        healthBar.SetHealth(currentHealth);

    }


    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(3f);
    }
}
