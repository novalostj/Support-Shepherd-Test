using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy
{
    public class AIFollow : MonoBehaviour
    {
        [SerializeField] private float followInterval = 0.1f;
        [SerializeField] private Transform player;
        
        private NavMeshAgent _agent;
        private NavMeshAgent Agent => _agent != null ? _agent : _agent = GetComponent<NavMeshAgent>();

        private void Start()
        {
            StartCoroutine(FollowPlayer());
        }

        private IEnumerator FollowPlayer()
        {
            while (player != null)
            {
                yield return new WaitForSeconds(followInterval);
                Agent.SetDestination(player.position);
            }

            Agent.isStopped = true;
        }
    }
}