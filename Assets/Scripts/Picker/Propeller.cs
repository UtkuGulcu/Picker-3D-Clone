using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Propeller : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject visuals;
    
    [Header("Values")]
    [SerializeField] private float rotateSpeed;

    private bool isRotating;
    
    private void Update()
    {
        if (!isRotating)
        {
            return;
        }
        
        transform.eulerAngles += new Vector3(0, rotateSpeed * Time.deltaTime, 0);
    }
    
    public void EnableVisuals()
    {
        visuals.SetActive(true);
        StartCoroutine(SpawnAnimation());
    }
    
    public void DisableVisuals()
    {
        visuals.SetActive(false);
        isRotating = false;
    }

    private IEnumerator SpawnAnimation()
    {
        float lerpTime = 0f;
        float duration = 0.4f;

        while (lerpTime <= duration)
        {
            lerpTime += Time.deltaTime;
            visuals.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, lerpTime / duration);
            yield return Helpers.GetWaitForEndOfFrame();    
        }

        isRotating = true;
    }
}
