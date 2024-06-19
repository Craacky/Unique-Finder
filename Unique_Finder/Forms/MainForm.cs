using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Unique_Finder.Database;
using Unique_Finder.Database.Entities;
using Unique_Finder.Forms;

namespace Unique_Finder
{
    public partial class MainForm : Form
    {
        private string sourceFileDirectory = "";
        private string sourceCameraFileDirectory = "";
        private string completedFileDirectory = "";
        private string logDirectory = "";
        private string fileErrorDirectory = "";
        private string databaseErrorDirectory = "";

        public string sourceFilePath = "";
        public string sourceCameraFilePath = "";
        public string completedFilePath = "";

        public string copiedSourceFilePath = "";
        public string copiedSourceCameraFilePath = "";
        public string logFilePath = "";
        public string errorReportPath = "";
        private LoadingForm? loadingForm;

        public MainForm()
        {
            InitApplicationDirectory();
            InitializeComponent();
            FormClosing += new FormClosingEventHandler(MainForm_FormClosing);
            InitializeLogger();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Restart_App();
        }

        //Form behavior setup section

        private void Restart_App()
        {
            if (CheckSqlServerInstalled() && CheckDatabaseValidation())
            {
                textBox3.BackColor = Color.White;
                textBox3.Text = "Для начала работы откройте исходный файл для проверки.";
                button1.Enabled = true;
                button1.BeginInvoke(new MethodInvoker(() => button1.Select()));

                groupBox4.Enabled = false;
                groupBox5.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                textBox4.Text = "";
                textBox5.Text = "";
                textBox4.BackColor = Color.White;
                textBox5.BackColor = Color.White;
            }
            else
            {
                button1.BeginInvoke(new MethodInvoker(() => button1.Select()));
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                groupBox4.Enabled = false;
                groupBox5.Enabled = false;
                MessageBox.Show(
                    "Требования для работы приложения не выполнены. Устраните проблему:\n-Установите Microsoft SQL Server\n-Удалите базу данных с названием  unique_db\n-Перезапустите приложение",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private bool CheckSqlServerInstalled()
        {
            string instanceName = "MSSQLSERVER";
            var rk = Registry.LocalMachine.OpenSubKey(
                @"SOFTWARE\Microsoft\Microsoft SQL Server\Instance Names\SQL"
            );

            if (rk != null)
            {
                foreach (string instance in rk.GetValueNames())
                {
                    if (instance == instanceName)
                    {
                        textBox1.BackColor = Color.LightBlue;
                        textBox1.Text = "Установлен";
                        return true;
                    }
                    else
                    {
                        textBox1.BackColor = Color.Red;
                        textBox1.Text = "Не Установлен";
                    }
                }
            }

            return false;
        }

        public bool CheckDatabaseValidation()
        {
            string connectionString = "Server = localhost; Integrated Security = true";
            var connection = new SqlConnection(connectionString);
            connection.Open();
            var databaseCommand = new SqlCommand(
                $"SELECT database_id FROM sys.databases WHERE Name = @databaseName",
                connection
            );
            databaseCommand.Parameters.AddWithValue("@databaseName", "unique_db");
            var databaseResult = databaseCommand.ExecuteScalar();

            var tableCommand = new SqlCommand(
                $"SELECT * FROM sys.tables WHERE name = @tableName",
                connection
            );
            tableCommand.Parameters.AddWithValue("@tableName", "'UniqueCodes'");
            var tableResult = tableCommand.ExecuteScalar();

            if (
                tableResult != null && databaseResult != null
                || tableResult == null && databaseResult == null
            )
            {
                textBox2.BackColor = Color.LightBlue;
                textBox2.Text = "Корректна";
                return true;
            }
            else
            {
                textBox2.BackColor = Color.Red;
                textBox2.Text = "Не Корректна";
                return false;
            }
        }

        private void InitApplicationDirectory()
        {
            string appDataPath = Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData
            );
            string uniqueFinderDirectory = Path.Combine(appDataPath, "Unique Finder");
            sourceFileDirectory = Path.Combine(uniqueFinderDirectory, "Approved Source File");
            sourceCameraFileDirectory = Path.Combine(
                uniqueFinderDirectory,
                "Approved Camera Source File"
            );
            completedFileDirectory = Path.Combine(uniqueFinderDirectory, "Completed File");
            fileErrorDirectory = Path.Combine(uniqueFinderDirectory, "File Errors");
            databaseErrorDirectory = Path.Combine(uniqueFinderDirectory, "Database Errors");
            logDirectory = Path.Combine(uniqueFinderDirectory, "Logs");

            CreateDirectory(uniqueFinderDirectory);
            CreateDirectory(sourceFileDirectory);
            CreateDirectory(sourceCameraFileDirectory);
            CreateDirectory(completedFileDirectory);
            CreateDirectory(fileErrorDirectory);
            CreateDirectory(databaseErrorDirectory);
            CreateDirectory(logDirectory);
        }

        private static void CreateDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

        private void InitializeLogger()
        {
            logDirectory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Unique Finder",
                "logs"
            );
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }
            logFilePath = Path.Combine(
                logDirectory,
                $"log_{DateTime.Now:_dd-MM-yyyy_HH-mm-ss}.txt"
            );
            LogMessage("Приложение запущено.");
        }

        private void LogMessage(string message)
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"[{DateTime.Now:HH:mm:ss}] {message}");
            }
        }

        // Form Closing Setup

        private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show(
                "Вы уверены, что хотите закрыть приложение?",
                "Подтверждение закрытия",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        //LOADING FORM INTEGRATION SECTION


        private void ShowLoadingForm(string label)
        {
            loadingForm = new LoadingForm();
            loadingForm.UpdateLabel(label);
            loadingForm.Show();
        }

        private void HideLoadingForm()
        {
            if (loadingForm != null)
            {
                loadingForm.Close();
                loadingForm.Dispose();
                loadingForm = null;
            }
        }

        // BUTTON 1 SECTION


        private void Button1_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog =
                new()
                {
                    InitialDirectory = "c:\\",
                    Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                    FilterIndex = 1,
                    RestoreDirectory = true
                };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                sourceFilePath = openFileDialog.FileName;
                textBox4.Text = sourceFilePath;
                textBox4.BackColor = Color.LightGreen;
                textBox3.Text = "Файл открыт, теперь, откройте файл камеры";
                textBox3.BackColor = Color.LightGreen;

                button2.Enabled = true;
                button2.BeginInvoke(new MethodInvoker(() => button2.Select()));
            }
        }

        private async void Button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            const int MaxLinesPerChunk = 1000000;
            try
            {
                ShowLoadingForm("Идет проверка файла на уникальность");
                textBox4.Text = "Идет проверка файла на уникальность";

                var globalDuplicates = new Dictionary<string, List<int>>();

                using (var reader = new StreamReader(sourceFilePath))
                {
                    int lineNumber = 0;

                    while (!reader.EndOfStream)
                    {
                        var uniqueLines = new HashSet<string>();
                        var chunkLines = new List<string>();
                        int linesInChunk = 0;

                        while (linesInChunk < MaxLinesPerChunk && !reader.EndOfStream)
                        {
                            string? line = await reader.ReadLineAsync();
                            if (line == null)
                                break;

                            chunkLines.Add(line);
                            linesInChunk++;
                        }

                        foreach (string line in chunkLines)
                        {
                            lineNumber++;

                            var trimmedLine = line.Trim();

                            if (!uniqueLines.Add(trimmedLine))
                            {
                                if (globalDuplicates.TryGetValue(trimmedLine, out var lineNumbers))
                                {
                                    lineNumbers.Add(lineNumber);
                                }
                                else
                                {
                                    globalDuplicates.Add(trimmedLine, new List<int> { lineNumber });
                                }
                            }
                        }
                    }
                }

                if (globalDuplicates.Count > 0)
                {
                    StringBuilder messageBuilder = new();
                    messageBuilder.AppendLine($"Текущий файл [{sourceFilePath}]");

                    foreach (var duplicate in globalDuplicates)
                    {
                        if (duplicate.Value.Count > 1)
                        {
                            messageBuilder.AppendLine(
                                $"Значение ['{duplicate.Key}'] повторяется в строках: {string.Join(", ", duplicate.Value)}"
                            );
                        }
                    }

                    string fullReportPath = Path.Combine(
                        fileErrorDirectory,
                        $"{Path.GetFileNameWithoutExtension(sourceFilePath)}{"_dd-MM-yyyy_HH-mm-ss"}_full_report.txt"
                    );

                    await File.WriteAllTextAsync(fullReportPath, messageBuilder.ToString());

                    string limitedMessage = messageBuilder.ToString();
                    int newlineIndex = limitedMessage.IndexOf('\n');
                    if (newlineIndex > 0)
                    {
                        limitedMessage = limitedMessage.Substring(0, newlineIndex);
                    }
                    limitedMessage += "Отчет находится в: " + fullReportPath;
                    HideLoadingForm();
                    MessageBox.Show(
                        limitedMessage,
                        "Найдены повторяющиеся значения",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    Restart_App();
                    textBox3.Text = "Найдены дубликаты";
                    textBox3.BackColor = Color.Red;
                }
                else
                {
                    string copiedSourceFilePath = Path.Combine(
                        sourceFileDirectory,
                        Path.GetFileNameWithoutExtension(sourceFilePath.Replace(" ", ""))
                            + "_success"
                            + DateTime.Now.ToString("_dd-MM-yyyy_HH-mm-ss")
                            + Path.GetExtension(sourceFilePath)
                    );

                    File.Copy(sourceFilePath, copiedSourceFilePath);
                    HideLoadingForm();

                    MessageBox.Show(
                        "Дубликаты не найдены. Всё хорошо. Есть доступ к следующему этапу",
                        "Проверка завершена.",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    textBox4.Text = copiedSourceFilePath;
                    textBox4.BackColor = Color.LightGreen;

                    textBox3.Text = "Дубликатов не найдено";
                    textBox3.BackColor = Color.LightGreen;
                    button1.Enabled = true;

                    groupBox4.Enabled = true;
                    button3.Enabled = true;
                    button3.BeginInvoke(new MethodInvoker(() => button3.Select()));
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show(
                    $"Произошла ошибка ввода-вывода: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show(
                    $"Отказано в доступе: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Произошла ошибка: {ex.Message}",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private async void Button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            LogMessage("Нажата кнопка сравнения.");
            List<string> duplicates = new List<string>();
            ShowLoadingForm("Идёт сравнение данных...");

            LogMessage("Начато сравнение данных.");

            using (DatabaseContextUnique unique_db = new())
            {
                var existingEntities = await unique_db.UniqueCodes.ToListAsync();

                if (existingEntities.Count == 0)
                {
                    MessageBox.Show(
                        "База данных пуста, можно переходить к добавлению данных.",
                        "Проверка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    LogMessage("База данных пуста.");

                    button4.Enabled = true;
                    button4.BeginInvoke(new MethodInvoker(() => button4.Select()));

                    HideLoadingForm();
                    return;
                }

                var existingMarkingCodes = existingEntities.Select(e => e.MarkingCode).ToHashSet();

                duplicates = new List<string>();

                using (StreamReader reader = new StreamReader(sourceFilePath))
                {
                    string? line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        if (existingMarkingCodes.Contains(line))
                        {
                            duplicates.Add(line);
                            if (duplicates.Count >= 20)
                            {
                                break;
                            }
                        }
                    }
                    HideLoadingForm();
                }

                if (duplicates.Count == 0)
                {
                    MessageBox.Show(
                        "Совпадения с базой данных отсутствуют, можете переходить к добавлению.",
                        "Проверка",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    LogMessage("Совпадения с базой данных отсутствуют.");

                    button4.Enabled = true;
                    button4.BeginInvoke(new MethodInvoker(() => button4.Select()));
                }
                else
                {
                    await CreateErrorReportAsync(duplicates, existingEntities);
                    MessageBox.Show(
                        $"Отчёт об ошибках создан:\n{errorReportPath}",
                        "Проверка провалена",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    LogMessage(
                        $"Совпадения с базой данных найдены. Отчет создан: {errorReportPath}"
                    );
                    Restart_App();
                }
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private async Task CreateErrorReportAsync(
            List<string> duplicates,
            List<DatabaseTemplate> existingEntities
        )
        {
            var currentDate = DateTime.Now.ToString("_dd-MM-yyyy_HH-mm-ss");
            errorReportPath = Path.Combine(logDirectory, $"error_report_{currentDate}.txt");
            string checkedFile =
                Path.GetFileNameWithoutExtension(copiedSourceFilePath.Replace(" ", ""))
                + Path.GetExtension(copiedSourceFilePath);

            using (var writer = new StreamWriter(errorReportPath))
            {
                foreach (var duplicate in duplicates)
                {
                    var entity = existingEntities.First(e => e.MarkingCode == duplicate);
                    await writer.WriteLineAsync(
                        $"[Источник]:{checkedFile}      [дубликат]:{duplicate}      [оригинал]:{entity.FileName}        [строка]:{entity.RowNumber}"
                    );
                }
                await writer.WriteLineAsync("\n\tЛимит проверки дубликатов = 20 кодов\t");
                await writer.DisposeAsync();
            }
        }

        private void Button4_Click(object sender, EventArgs e) { }
    }
}
