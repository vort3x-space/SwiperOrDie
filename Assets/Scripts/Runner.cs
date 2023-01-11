using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


using System;

public class Runner : MonoBehaviour
{
    [Header(" Components ")]
    [SerializeField] private Animator animator;
    [SerializeField] private Collider collider;
    [SerializeField] private float moveSpeed;
    public static int currentIndex;

    

    //[SerializeField] public Canvas gameOverCanvas; 
    private bool targeted;


    [Header(" Detection ")]
    [SerializeField] private LayerMask obstaclesLayer;


    void Start()
    {
        currentIndex = SceneManager.GetActiveScene().buildIndex;
    }

  
    void Update()
    {
        if (!collider.enabled)
            return;

        DetectObstacles();
    }


    private void DetectObstacles()
    {
        if (Physics.OverlapSphere(transform.position, 0.1f, obstaclesLayer).Length > 0)
            Explode();

    }

    public void SetAsTarget()
    {
        targeted = true;
    }

    public bool IsTargeted()
    {
        return targeted;
    }

    public void Explode()
    {
        collider.enabled = false;
        GetComponent<Renderer>().enabled = false;

        if (transform.parent != null && transform.parent.childCount <= 1)


        transform.parent = null;
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Booster"))
        {
            Debug.Log("asd");

            StartCoroutine(nameof(SpeedBoostRoutine));
        }
    }
    IEnumerator SpeedBoostRoutine()
    {
        moveSpeed += 3;
        yield return new WaitForSeconds(1);
        moveSpeed -= 3;
    }

}
