using System.IO;
using UnityEngine;

public class ScoreExporter : MonoBehaviour
{
    public void ExportScoreToFile(string filePath, int score)
    {
        if (!string.IsNullOrEmpty(filePath))
        {
            string htmlContent = "<html><head><style>";
            htmlContent += "body { text-align: center; font-size: 40px; color: white; background-image: url('https://i.ibb.co/0nP3C14/main-menu-background.jpg'); background-size: cover;}";
            htmlContent += "#table-container { display: inline-block; }";
            htmlContent += "th { font-size: 60px; }";
            htmlContent += "td { font-size: 40px; text-align: center; }";
            htmlContent += "</style></head><body>";
            htmlContent += "<h1>DUNGEON LOOTER TOP 100 SCOREBOARD</h1>";
            htmlContent += "<div id=\"table-container\">";
            htmlContent += "<table><tr><th>Player name</th><th>Score</th></tr>";
            htmlContent += "<tr><td>xXxDungeonLooterxXx</td><td>1000</td></tr>";
            htmlContent += "<tr><td>Indiana Jones</td><td>870</td></tr>";
            htmlContent += "<tr><td>Lara Croft</td><td>680</td></tr>";
            htmlContent += "<tr><td>Nathan Drake</td><td>520</td></tr>";
            htmlContent += "<tr><td>Nicolas Cage</td><td>430</td></tr>";
            htmlContent += "<tr><td>Rick Astley</td><td>250</td></tr>";
            htmlContent += "<tr><td>Player</td><td>" + score + "</td></tr>";
            htmlContent += "</table>";
            htmlContent += "</div>";
            htmlContent += "</body></html>";



            File.WriteAllText(filePath, htmlContent);
            Debug.Log("Score exported to: " + filePath);
        }
    }
}