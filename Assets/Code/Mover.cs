using UnityEngine;

namespace TAMK.VCSExample
{
	public class Mover : MonoBehaviour
	{
		void Update()
		{
            if(Physics.Raycast(transform.position,Vector3.down,0.5f) && Input.GetKey(KeyCode.Space))
            {
                GetComponent<Rigidbody>().AddForce(new Vector3(0, 40f, 0), ForceMode.Impulse);
            }
		}
	}
}
