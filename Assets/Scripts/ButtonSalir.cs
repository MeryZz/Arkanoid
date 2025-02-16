using UnityEngine;
using UnityEngine.UI;

public class ButtonSalir : MonoBehaviour
{
    [SerializeField] private Button botonQuit;

    private void Awake()
    {
        Debug.Log("SALIR!"); // Para probar en el editor
        botonQuit.onClick.AddListener(() => { Application.Quit(); });
    }
}
