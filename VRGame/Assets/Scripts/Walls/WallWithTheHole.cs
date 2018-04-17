using Framework.References;
using UnityEngine;

public class WallWithTheHole : MonoBehaviour
{
    public float holeWidth;
    public FloatReference wallWidth;

    public HoleInTheWall hole;

    /// <summary>
    /// Creates hole at the specified position
    /// </summary>
    /// <param name="t">Specifies relative to the wall's width position of the hole</param>
    private void CreateHole(float t)
    {
        var leftEdge = (holeWidth - wallWidth) / 2f;
        var rightEdge = - leftEdge;

        var offset = Mathf.Lerp(leftEdge, rightEdge, t);
        hole.SetPosition(offset);
    }

    [ContextMenu("Regenerate hole")]
    private void CreateHole()
    {
        CreateHole(Random.value);
    }

    private void Start()
    {
        hole?.Setup(holeWidth);
        CreateHole();
    }

    private void Awake ()
    {
        holeWidth = Mathf.Clamp(holeWidth, 0f, wallWidth);
    }
}
