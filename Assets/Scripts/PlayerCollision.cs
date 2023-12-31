using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FinishLine"))
        {
            EventManager.Broadcast(GameEvent.OnPassFinishLine);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Particle>())
        {
            EventManager.Broadcast(GameEvent.OnPlaySound, "collect");
            switch (other.GetComponent<Particle>().particleState)
            {
                case ParticleState.star:
                    EventManager.Broadcast(GameEvent.OnParticlePlay, "Star", other.transform.localPosition);
                    Destroy(other.gameObject);
                    break;
                case ParticleState.diamond:
                    EventManager.Broadcast(GameEvent.OnParticlePlay, "Diamond", other.transform.localPosition);
                    Destroy(other.gameObject);
                    break;
                case ParticleState.gold:
                    EventManager.Broadcast(GameEvent.OnParticlePlay, "Gold", other.transform.localPosition);
                    Destroy(other.gameObject);
                    break;
                default:
                    break;
            }
        }
    }
}
