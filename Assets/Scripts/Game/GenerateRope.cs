using UnityEngine;

public class GenerateRope : MonoBehaviour
{
    [SerializeField] private GameObject _start;
    [SerializeField] private GameObject _end;
    [SerializeField] private GameObject _chainPrefab;
    [SerializeField] private int _length;
    [SerializeField] private float _distance;
    
    [ContextMenu("Create rope")]
    private void Create()
    {
        Rigidbody previousChain = _start.GetComponent<Rigidbody>();
        for (int i = 0; i < _length; i++)
        {
            GameObject newChain = Instantiate(_chainPrefab);
            var jointToPrevious = newChain.AddComponent<HingeJoint>();
            jointToPrevious.connectedBody = previousChain;
            jointToPrevious.anchor = -Vector3.forward;

            var jointFromPrevious = previousChain.gameObject.AddComponent<HingeJoint>();
            jointFromPrevious.connectedBody = newChain.GetComponent<Rigidbody>();
            jointFromPrevious.anchor = Vector3.forward;
            
            newChain.transform.position = previousChain.position + previousChain.transform.forward * _distance;

            previousChain = newChain.GetComponent<Rigidbody>();
        }

        var jointToEnd = previousChain.gameObject.AddComponent<HingeJoint>();
        jointToEnd.connectedBody = _end.GetComponent<Rigidbody>();
        jointToEnd.anchor = -Vector3.forward;
    }
    
   
}
