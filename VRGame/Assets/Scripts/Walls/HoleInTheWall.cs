using UnityEngine;

public class HoleInTheWall : MonoBehaviour
{
    [SerializeField] private GameObject holePartPrefab;
    [SerializeField] private Transform partsAnchor;

    public void Setup(float width)
    {
        var partScale = holePartPrefab.transform.localScale.x;
        var offset = (partScale + width) / 2f;

        InstantiatePart(offset);
        InstantiatePart(-offset);
    }

    public void SetPosition(float localX)
    {
        var pos = partsAnchor.localPosition;
        pos.x = localX;
        partsAnchor.localPosition = pos;
    }

    private void InstantiatePart(float offset)
    {
        var instance = Instantiate(holePartPrefab, partsAnchor);
        instance.transform.localPosition = new Vector3(offset, 0, 0);
    }
}
