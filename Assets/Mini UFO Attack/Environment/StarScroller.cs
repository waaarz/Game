using UnityEngine;

public class StarScroller : MonoBehaviour
{
    public float scrollSpeed = .1f;
    private Material mat;

    void Awake() { mat = GetComponent<Renderer>().material; }

    void Update()
    {
        Vector2 o = mat.mainTextureOffset;
        o.x += scrollSpeed * Time.deltaTime;
        mat.mainTextureOffset = o;
    }
}