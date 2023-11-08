using General;
using UnityEngine;

namespace Enemy
{
    public class Enemy : MonoBehaviour
    {
        public void TryKill(GameObject target)
        {
            if (!target.TryGetComponent<IPlayer>(out var player))
                return;
            
            player.TakeDamage();
        }
    }
}