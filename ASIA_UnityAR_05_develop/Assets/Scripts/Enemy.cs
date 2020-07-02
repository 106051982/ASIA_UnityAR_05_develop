using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("速度"), Range(0, 10)]
    public float speed = 1.5f;
    [Header("停止距離"), Range(0,5)]
    public float stopDistance = 2;
    [Header("追蹤目標名稱")]
    public string targetName = "111";
    [Header("傷害"), Range(10, 100)]
    public float damge;

    private Transform target;
    private NavMeshAgent nma;

    private void Start()
    {
        nma = GetComponent<NavMeshAgent>();
        nma.speed = speed;
        nma.stoppingDistance = stopDistance;

        target = GameObject.Find(targetName).transform;
        nma.SetDestination(target.position);
    }
    private void Update()
    {
        Track();
    }
    void CreateEffect()
    {
        Destroy(gameObject);
    }
    void Track()
    {
        nma.SetDestination(target.position);

        if(nma.remainingDistance<=stopDistance)
         CreateEffect();
        target.GetComponent<flowerpot>().Damage(damge);
    }
    void ClickAndDie()
    {
        CreateEffect();
        flowerpot.target = transform;
    }
    private void OnMouseDown()
    {
        ClickAndDie();
    }
}
