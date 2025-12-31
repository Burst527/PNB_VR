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
                    "Gedung D4 merupakan gedung multifungsi yang digunakan untuk kegiatan akademik dan fasilitas penunjang di lingkungan PNB.\n\n" +
            
                    "Lantai 1:\n" +
                    "Digunakan sebagai perpustakaan bersama Politeknik Negeri Bali.\n\n" +
                    
                    "Lantai 2:\n" +
                    "Terdapat ruang organisasi mahasiswa (HMJ) dan ruang transit dosen.\n" +
                    "Selain itu juga terdapat ruang kelas untuk jurusan lainnya.\n\n" +

                    "Lantai 3:\n" +
                    "Berisi ruang kelas yang diberi label CIII.1 sampai CIII.6, ruang rapat serta ruang dosen\n" +
                    "Ruang kelas biasanya digunakan oleh jurusan JTI dan Administrasi";
                break;

            case "GedungEB":
                infoText.text =
                    "GEDUNG EB dan Gedung EC\n\n" +
                    "Dua gedung ini berada dalam satu area kampus PNB Bali, dan digunakan bersama oleh Jurusan Teknologi Informasi (JTI) dan Jurusan Teknik Elektro (TE).\n\n" +

                    "GEDUNG EB:\n" +
                    "Lantai 1: Ruang praktik untuk Jurusan Teknik Elektro.\n" +
                    "Lantai 2: Seluruh ruangan digunakan untuk kegiatan Jurusan Teknologi Informasi (JTI).\n\n" +

                    "GEDUNG EC:\n" +
                    "Digunakan khusus untuk praktik teknologi jaringan dan komunikasi.\n" +
                    "Fasilitas: Laboratorium jaringan, server, router, dan perangkat WiFi.\n" +
                    "Sering digunakan bersama oleh mahasiswa JTI dan TE untuk praktikum jaringan.";
                break;

            case "GedungPUT":
                infoText.text =
                    "GEDUNG PUT\n\n" +
                    "Gedung PUT digunakan untuk menunjang kegiatan akademik dan administrasi di lingkungan kampus.\n\n" +
                    "Di dalam gedung ini terdapat ruang kelas, ruang dosen, ruang administrasi, serta ruang rapat.\n\n" +
                    "Informasi penggunaan ruang dapat menyesuaikan dengan kebutuhan akademik yang berlangsung.";
                break;

            default:
                infoText.text =
                    "INFORMASI\n\n" +
                    "Informasi gedung belum tersedia.";
                break;
        }
    }
}
