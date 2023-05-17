using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScoreExporterButton : MonoBehaviour
{
    public Button buttonToExport;
    public string fileName = "output.html";
    private ScoreExporter scoreExporter;

    private void Start()
    {
        scoreExporter = GetComponent<ScoreExporter>();
        if (scoreExporter == null)
        {
            Debug.LogError("ScoreExporter component not found!");
        }

        buttonToExport.onClick.AddListener(ExportScoreToFile);
    }

    public void ExportScoreToFile()
    {
        Player player = Player.Instance;
        if (player != null && scoreExporter != null)
        {
            string filePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop), fileName);
            scoreExporter.ExportScoreToFile(filePath, player.score);
        }
    }
}