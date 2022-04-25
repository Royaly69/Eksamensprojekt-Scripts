using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    private TextMeshPro textMesh;
    private float disappearTimer;
    private const float disappearTimerMax = 1f;
    private Color color;
    private Vector3 moveVector;
    private static int sortingOrder;
    public static DamagePopup Create(Vector3 position, int damage)
    {
        Transform damagePopupTransform = Instantiate(GameAssets.i.pfDamagePopup, position, Quaternion.identity);
        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(damage);
        return damagePopup;
    }
    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }
    public void Setup(int damage)
    {
        textMesh.SetText(damage.ToString());
        color = textMesh.color;
        disappearTimer = disappearTimerMax;
        moveVector = new Vector3(0,0.3f) * 5f;
        sortingOrder++;
        textMesh.sortingOrder = sortingOrder;

    }
    void Update()
    {
        transform.position += moveVector * Time.deltaTime;
        moveVector -= moveVector * 2f * Time.deltaTime;

        if (disappearTimer > disappearTimerMax * 0.5f)
        {
            float increaseScaleAmount = 1f;
            transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
        }
        else
        {
            float decreaseScaleAmount = 1f;
            transform.localScale -= Vector3.one * decreaseScaleAmount * Time.deltaTime;
        }
        
        disappearTimer -= Time.deltaTime;
        if (disappearTimer < 0)
        {
            float disappearSpeed = 3f;
            color.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = color;
            if (color.a < 0)
            {
                Destroy(gameObject);
            }
        }

    }
}
