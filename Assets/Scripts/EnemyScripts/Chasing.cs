using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class Chasing : MonoBehaviour
{
    public float speed ;
    public Transform player;
    public float rotationSpeed;
    float x, y;
    public bool PlayerNotSeen = true, isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerNotSeen == true && isMoving == false){
            StartCoroutine(LookAround());
        }
    }
    public IEnumerator LookAround(){
        isMoving = true;
        int i = UnityEngine.Random.Range(-180, 180);
        while (Math.Round(transform.rotation.eulerAngles.z) % 180 != Math.Abs(i)){
            transform.Rotate(Vector3.forward*i, rotationSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0);
            Debug.Log(Math.Round(transform.rotation.eulerAngles.z) + " hello world " + i);
        }
        yield return new WaitForSeconds(3f);
        isMoving = false;
    }

}
