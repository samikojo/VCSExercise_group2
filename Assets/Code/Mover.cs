using UnityEngine;

namespace TAMK.VCSExample
{
	public class Mover : MonoBehaviour
	{
		void Update()
		{
            Rotate();

            if(Physics.Raycast(transform.position,Vector3.down,0.5f) && Input.GetKey(KeyCode.Space))
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(0, 40f, 0), ForceMode.Impulse);
            }
		}

        private void Rotate()
        {
            short rotationY = 0;

            short left = -5;
            short right = 5;

            if (Input.GetKey(KeyCode.Q))
            {
                rotationY += left;
            }

            if (Input.GetKey(KeyCode.E))
            {
                rotationY += right;
            }

            if (rotationY != 0)
            {
                gameObject.transform.Rotate(gameObject.transform.rotation.x,
                                            rotationY,
                                            gameObject.transform.rotation.z);
            }
        }
	}
}
