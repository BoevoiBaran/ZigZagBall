using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private float fallDownTime = 1.0f;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Character")
        {
            TileManager.Instanse.TileSpawn();
            StartCoroutine(FallDown());
        }
    }

    IEnumerator FallDown()
    {
        yield return new WaitForSeconds(fallDownTime);
        rb.isKinematic = false;
        yield return new WaitForSeconds(2.0f);

        switch(gameObject.name)
        {
            case "LeftTile":
                TileManager.Instanse.LeftTiles.Push(gameObject);
                rb.isKinematic = true;
                gameObject.SetActive(false);
                    break;
            case "TopTile":
                TileManager.Instanse.TopTiles.Push(gameObject);
                rb.isKinematic = true;
                gameObject.SetActive(false);
                break;

        }
        
    }
}
