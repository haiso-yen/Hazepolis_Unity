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
    //����
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
        //�ϥί�O����
        if (Input.GetKey(KeyCode.E)) {
            TakeDamage(0.015f);
        }
        //�H�ɶ��^�_
        if (currentHealth <= MaxHealth)
        {
            RecoverDamage(0.001f);
            StartCoroutine(Coroutine());
        }
    }

    void TakeDamage(float damage)
    {
        currentHealth -= damage;
        //Tiam.time ���}�l�ɶ�(read only)
        startTime = Time.time;

        if (currentHealth != currentHealth)
        {
            //Lerp(�}�l�ȡA�����ȡA�C�����媺�ʤ���) ��}�l���ͦV�󵲧��ȮɡA����t�׷|�V�ӶV�C �q�L ��e�ɶ���h�}�l���媺�ɶ�*����ʤ���ӸѨM
            currentHealth = Mathf.Lerp(currentHealth, currentHealth, (Time.time - startTime) * speed);
        }

        healthBar.SetHealth(currentHealth);
    }   
    void RecoverDamage(float damage)
    {
        currentHealth += damage;
        //Tiam.time ���}�l�ɶ�(read only)
        startTime = Time.time;

        if (currentHealth != currentHealth)
        {
            //Lerp(�}�l�ȡA�����ȡA�C�����媺�ʤ���) ��}�l���ͦV�󵲧��ȮɡA����t�׷|�V�ӶV�C �q�L ��e�ɶ���h�}�l���媺�ɶ�*����ʤ���ӸѨM
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
