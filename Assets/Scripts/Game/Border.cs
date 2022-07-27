using UnityEngine;

public class Border : MonoBehaviour
{
    [SerializeField] private Area _area;
    [SerializeField] private float _coefficientX;
    [SerializeField] private float _width;

    private void OnEnable()
    {
        _area.onUpdateBorder += UpdateBorder;
    }

    private void UpdateBorder(float border)
    {
        transform.localPosition = transform.localPosition.SetX((border + (_width /2 )) * _coefficientX);
    }

    private void OnDisable()
    {
        _area.onUpdateBorder -= UpdateBorder;
    }
}
