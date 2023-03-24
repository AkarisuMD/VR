using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoiteAFlipFlop : MonoBehaviour
{
    public List<AudioClip> m_AudioClipList;
    public AudioSource source;
    private const float sideOffset = 45f;

    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Material blue;
    [SerializeField] private Material red;
    public enum sideType { Up, Mid, Down};
    public sideType side;
    public bool onceSide;

    void Update()
    {
        if ((transform.eulerAngles.x < sideOffset || transform.eulerAngles.x > 360 - sideOffset) &&
            (transform.eulerAngles.z < sideOffset || transform.eulerAngles.z > 360 - sideOffset))
        {
            side = sideType.Up;

        }
        else if ((transform.eulerAngles.x < 180 + sideOffset && transform.eulerAngles.x > 180 - sideOffset) ||
            (transform.eulerAngles.z < 180 + sideOffset && transform.eulerAngles.z > 180 - sideOffset))
        {
            side= sideType.Down;
        }
        else
        {
            side = sideType.Mid;
        }


        if (sideType.Up == side && onceSide)
        {
            onceSide = false;
            Up();
        }
        else if (sideType.Down == side && !onceSide)
        {
            onceSide = true;
            Down();
        }
    }

    void Up()
    {
        source.PlayOneShot(m_AudioClipList[Random.Range(0, m_AudioClipList.Count)]);
        FlipFlopGlobal.Instance.FlipFlop();
        _meshRenderer.materials = new Material[] { blue };
    }
    void Down()
    {
        source.Stop();
        FlipFlopGlobal.Instance.FlipFlop();
        _meshRenderer.materials = new Material[] { red };
    }
}
