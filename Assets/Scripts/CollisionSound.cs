using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSound : MonoBehaviour
{
  public AudioSource audioSource;

  private void OnTriggerEnter3D(Collider other)
  {
    if (other.tag == "fence")
    {
        audioSource.Play();
    }
  }
}
