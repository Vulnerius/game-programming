using System;
using System.Collections;
using UnityEngine;

namespace Enemy {
    public class Enemy : MonoBehaviour {
        [SerializeField] private Health.Health health;

        private Animator animator;
        internal bool DragonAlive = true;

        private void Awake() {
            animator = gameObject.GetComponentInChildren<Animator>();
        }

        private void Update() {
            if (health.CurrentHealth == 0)
                StartCoroutine(Die());
        }

        private IEnumerator Die() {
            DragonAlive = false;
            animator.Play("Die");
            yield return new WaitForSeconds(1.2f);
            Destroy(gameObject);
        }

        public void GettingHit() {
            animator.Play("Get Hit");
        }
        
        private void OnTriggerEnter(Collider other) {
            if(other.gameObject.GetComponent<Health.Health>() == null) return;
            
            other.gameObject.GetComponent<Health.Health>().GetDamagedInstantly(100);
        }

        private void OnDestroy() {
            StopAllCoroutines();
        }
    }
}