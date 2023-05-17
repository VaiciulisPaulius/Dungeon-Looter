using System.IO;
using UnityEngine;

public class ScoreExporter : MonoBehaviour
{
    public void ExportScoreToFile(string filePath, int score)
    {
        if (!string.IsNullOrEmpty(filePath))
        {
            string htmlContent = "<html><head><style>";
            htmlContent += "body { text-align: center;}";
            htmlContent += "#table-container { display: inline-block; }";
            htmlContent += "</style></head><body>";
            htmlContent += "<h1>DUNGEON LOOTER TOP 100 SCOREBOARD</h1>";
            htmlContent += "<div id=\"table-container\">";
            htmlContent += "<table><tr><th>Player name</th><th>Score</th></tr>";
            htmlContent += "<tr><td>xXxDungeonLooterxXx</td><td>1000</td></tr>";
            htmlContent += "<tr><td>Player</td><td>" + score + "</td></tr>";
            htmlContent += "</table>";
            htmlContent += "</div>";
            htmlContent += "</body></html>";



            File.WriteAllText(filePath, htmlContent);
            Debug.Log("Score exported to: " + filePath);
        }
    }
}