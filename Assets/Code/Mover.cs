using UnityEngine;

namespace TAMK.VCSExample
{
	public class Mover : MonoBehaviour
	{
        [SerializeField, Tooltip ("Cube's speed")]
        private float _Speed = 5f;

        void Update()
        {
            Move();
            Rotate();
            Spawn();

            if (Physics.Raycast(transform.position, Vector3.down, 0.5f) && Input.GetKey(KeyCode.Space))
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(0, 40f, 0), ForceMode.Impulse);
            }
        }

        private void Move()
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * _Speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * _Speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * _Speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * _Speed * Time.deltaTime);
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

        private void Spawn()
        {
            if(Input.GetKeyDown(KeyCode.P))
            {
                Instantiate(this.gameObject, new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z), transform.rotation);
            }
        }
    }
}
