using UnityEngine;

namespace DefaultNamespace
{
    public class HeatHazeObject : MonoBehaviour
    {
        public float speed;
        
        private Material hazeMaterial;
        private const string TextureName = "_BumpMap";
        
        private void Update()
        {
            var offset = hazeMaterial.GetTextureOffset(TextureName);
            offset += speed * Vector2.one * Time.deltaTime;
            hazeMaterial.SetTextureOffset(TextureName, offset);
        }

        private void Awake()
        {
            hazeMaterial = GetComponent<Renderer>().sharedMaterial;
        }
    }
}