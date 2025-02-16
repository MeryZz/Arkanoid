using UnityEngine;
using TMPro; // Para TextMeshProUGUI


public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI numPoints; // Referencia al texto en pantalla
    private int points = 0;           // Variable para almacenar los puntos


    void Start()
    {
        PlayerPrefs.SetInt("Points", 0); // Reinicia los puntos al iniciar el juego
        PlayerPrefs.Save();               // Guarda el cambio
        points = 0;                       // Reinicia también la variable local
        UpdatePointsText();               // Actualiza el texto en pantalla
    }


    public void AddPoints(int value)
    {
        points += value;                  // Suma los puntos
        numPoints.text = points.ToString(); // Muestra los puntos en pantalla
        PlayerPrefs.SetInt("Points", points); // Guarda los puntos
        PlayerPrefs.Save();
    }


    private void UpdatePointsText()
    {
        numPoints.text = points.ToString(); // Actualiza el texto con los puntos actuales
    }
}
