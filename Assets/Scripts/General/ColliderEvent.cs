using System;
using UnityEngine;
using UnityEngine.Events;

namespace General
{
    [RequireComponent(typeof(Collider))]
    public class ColliderEvent : MonoBehaviour
    {
        public UnityEvent<GameObject> triggerEnter;

        private void OnTriggerEnter(Collider other)
        {
            triggerEnter?.Invoke(other.gameObject);
        }
    }
}