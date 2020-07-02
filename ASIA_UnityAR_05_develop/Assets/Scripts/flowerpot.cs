using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class flowerpot : MonoBehaviour
{
    public static Transform target;
    [Header("血量"), Range(100, 500)]
    public float hp;
    [Header("血條")]
    public Image hpBar;
    public GameObject final;
    public Text textCount;

    int count;
    float hpMax;
    private void Start()
    {
        hpMax = hp;
    }
    
    public void Damage(float damage)
    {
        hp -= damage;
        hpBar.fillAmount = hp / hpMax;

        if (hp == 0)
            final.SetActive(true);
        textCount.text = "被種進去的數量：" + count;
    }
    public void Replay()
    {
        SceneManager.LoadScene("develop");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
