using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Ball
{
    public class BallPhysicsController : MonoBehaviour
    {
        [SerializeField] BallManager manager;


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("InNet"))
            {
               
                manager.SetInHoof(true);
                manager.CheakIsScore();
            }
            if (other.CompareTag("OutNet"))
            {
                manager.SetOutHoof(false);
            }
        }
    }
}