using System.Collections;
using UnityEngine;

public class Moveover : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
