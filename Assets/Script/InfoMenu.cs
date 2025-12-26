using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InfoMenu : MonoBehaviour
{
    public TextMeshProUGUI infoText;

    void OnEnable()
    {
        UpdateInfo();
    }

    void UpdateInfo()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        switch (sceneName)
        {
            case "GedungD4":
                infoText.text =
                    "GEDUNG D4\n\n" +
                    "Gedung ini digunakan untuk kegiatan perkuliahan.\n" +
                    "Memiliki beberapa ruang kelas dan fasilitas pendukung.";
                break;

            case "GedungEB":
                infoText.text =
                    "GEDUNG EB\n\n" +
                    "Gedung administrasi dan layanan akademik.";
                break;

            default:
                infoText.text =
                    "INFORMASI\n\n" +
                    "Informasi gedung belum tersedia.";
                break;
        }
    }
}
