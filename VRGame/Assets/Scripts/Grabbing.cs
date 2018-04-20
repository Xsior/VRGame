using UnityEngine;

public class Grabbing : MonoBehaviour
{
    private SteamVR_TrackedObject trackedObj;

    private SteamVR_Controller.Device Controller => SteamVR_Controller.Input((int) trackedObj.index);

    private GameObject collidingObject;
    private GameObject objectInHand;

    private FixedJoint joint;

    public void HapticPulse()
    {
        Controller.TriggerHapticPulse(1000);
    }

    private void Grab ()
    {
        if (collidingObject == null) {
            return;
        }

        objectInHand = collidingObject;
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }

    private void Release ()
    {
        if (objectInHand == null) {
            return;
        }

        joint.connectedBody = null;
        objectInHand = null;
    }

    private void SetCollidingObject (Collider obj)
    {
        if (collidingObject != null || obj.GetComponent<Rigidbody>() == null) {
            return;
        }

        collidingObject = obj.gameObject;
    }

    private void Update ()
    {
        if (Controller.GetHairTriggerDown()) {
            Grab();
        } else if (Controller.GetHairTriggerUp()) {
            Release();
        }
    }

    private void OnTriggerEnter (Collider other)
    {
        SetCollidingObject(other);
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.gameObject != collidingObject) {
            return;
        }
        collidingObject = null;
    }

    private void OnTriggerStay (Collider other)
    {
        SetCollidingObject(other);
    }

    private void Awake ()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        joint = GetComponent<FixedJoint>();
    }
}

