using UnityEngine;

namespace TAMK.VCSExample
{
	public class Mover : MonoBehaviour
	{
        [SerializeField, Tooltip ("Cube's speed")]
        private float _Speed = 5f;
        public Material material;


        void Update()
        {
            Move();
            Rotate();
            Spawn();
            PartyTiem();

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

            short right = 100;
            short left = (short) (-1 * right);

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
                                            rotationY * Time.deltaTime,
                                            gameObject.transform.rotation.z);
            }
        }

        private void Spawn()
        {
            if(Input.GetKey(KeyCode.P))
            {
                Instantiate(this.gameObject, new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z), transform.rotation);
            }
        }

        private void PartyTiem ()
        {
            transform.localScale = new Vector3(Random.Range(1, 10), Random.Range(1, 10), Random.Range(1, 10));

            Color colour = new Color(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            material.color = colour;
        }
    }
}
