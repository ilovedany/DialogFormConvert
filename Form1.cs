using System.Diagnostics;
namespace DialogFormConvert;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }
    private int selectView=1; //выбор вида запуска утилиты (1-xml из файла, 2-xml из бд)
    private string pathToExe="C:/dllFiles/ConvertUtilityForm.exe"; //путь до exe
    private string pathToSaveXlsx="C:/XmlFiles/Смена профессии.xlsx"; //путь до место сохранения xlsx
    private int deleteOrNo=1; //выбор удалять xml файл после конвертации или нет
    private int openOrNo=1; //выбор открывать xlsx файл после конвертации или нет

    private void button1_Click(object sender, EventArgs e)
    {
        if (selectView == 1)
        {
            using (OpenFileDialog openXml = new OpenFileDialog())
            {
                openXml.Filter = "Все файлы (*.*)|*.*";
                openXml.FilterIndex = 1;
                openXml.RestoreDirectory = true;

                if (openXml.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = openXml.FileName;
                    Process.Start(new ProcessStartInfo(pathToExe, $"{selectView} \"{openXml.FileName}\" null {deleteOrNo} {openOrNo}") { UseShellExecute = true });
                }
            }
        }
        else if (selectView == 2)
        {
            Process.Start(new ProcessStartInfo(pathToExe, $"{selectView} null \"{pathToSaveXlsx}\" null {openOrNo}") { UseShellExecute = true });
        }

    }
}
