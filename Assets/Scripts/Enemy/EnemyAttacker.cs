﻿using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyAttacker : MonoBehaviour
    {
        [SerializeField] private float _coolDown;
        [SerializeField] private int _damage;

        private bool _canAttack = true;

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Health>(out Health player))
            {
                if (_canAttack)
                {
                    StartCoroutine(WaitAndAttack(_coolDown, player));
                }
            }
        }

        private IEnumerator WaitAndAttack(float coolDown, Health player)
        {
            _canAttack = false;

            player.TakeDamage(_damage);

            yield return new WaitForSecondsRealtime(coolDown);

            _canAttack = true;
        }
    }
}