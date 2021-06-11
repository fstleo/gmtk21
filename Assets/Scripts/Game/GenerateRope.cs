using UnityEngine;

public class GenerateRope : MonoBehaviour
{
    [SerializeField] private int _length;
    
    [ContextMenu("Create rope")]
    private void Create()
    {
        Rigidbody previousChain = gameObject.GetComponent<Rigidbody>();
        for (int i = 0; i < _length; i++)
        {
            GameObject newChain = Instantiate(gameObject);
            newChain.GetComponent<HingeJoint>().connectedBody = previousChain;
            newChain.transform.position = previousChain.position + previousChain.transform.forward;
            previousChain = newChain.GetComponent<Rigidbody>();
        }
    }
}
