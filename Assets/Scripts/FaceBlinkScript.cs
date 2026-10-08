using System.Collections;
using UnityEngine;

public class FaceBlinkScript : MonoBehaviour
{
    [SerializeField] private float blinkTime = 5f;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(WaitToBlink());
    }

    private IEnumerator WaitToBlink()
    {
        while (true)
        {
            yield return new WaitForSeconds(blinkTime);
            anim.SetBool("blink", true);
        }
    }

    public void Blinked()
    {
        anim.SetBool("blink", false);
    }
}
