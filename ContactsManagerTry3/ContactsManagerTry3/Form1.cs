using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactsManagerTry3
{
    public partial class Form1 : Form
    {
        private string filePath = "Database.txt";
        private FileManager fileManager;
        public Form1()
        {
            InitializeComponent();
            fileManager = new FileManager();
            dataGridView1.ColumnCount = 3;
            dataGridView1.RowCount = 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            fileManager.LoadTaskFromFile(filePath);
            dataGridView1.RowCount = fileManager.contacts.Count;
            for (int i = 0; i < fileManager.contacts.Count; i++)
            {
                dataGridView1[0,i].Value = fileManager.contacts[i].FirstName;
                dataGridView1[1, i].Value = fileManager.contacts[i].LastName;
                dataGridView1[2, i].Value = fileManager.contacts[i].PhoneNumber;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Создание файла, если его нет
            if (!File.Exists(filePath))
            {
                try
                {
                    File.Create(filePath).Close();
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"Ошибка при создании файла: {ex.Message}");
                    return;
                }
            }

            // Сохранение данных в файл
            fileManager.SaveTaskToFile(fileManager.contacts, filePath);
        }
        public void CloseForm()
        {
            this.Close();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            dataGridView1.RowCount += 1;
        }
    }
    public class Contact
    {
        public Contact(string firsName, string lastName, string phoneNumber) 
        {
            FirstName = firsName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class FileManager
    {
        public List<Contact> contacts { get; set; }
        public FileManager() { }
        public void LoadTaskFromFile( string filePath)
        {
            contacts = new List<Contact>();
            Contact contact1 = new Contact("Витя", "Вавава", "4356457457");
            Contact contact2 = new Contact("asdfasd", "Вававasdfasdfа", "4dfasdf356457457");
            Contact contact3 = new Contact("asdf", "asВdfasdfавава", "4356457457asdfasdf");
            contacts.Add(contact1);
            contacts.Add(contact2);
            contacts.Add(contact3);
            try
            {
                List<string> lines = new List<string>();
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }

                    contacts.Clear();
                    foreach (string lin in lines)
                    {
                        string[] parts = lin.Split('#');
                        if (parts.Length == 3)
                        {
                            Contact contact = new Contact(parts[0], parts[1], parts[2]);
                            contacts.Add(contact);
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Ошибка при загрузке файла: {ex.Message}");
                return;
            }
        }
        public void SaveTaskToFile(List<Contact> contacts, string filePath)
        {
            try
            {
                List<string> lines = new List<string>();
                foreach (var contact in contacts)
                {
                    string line = $"{contact.FirstName}#{contact.LastName}#{contact.PhoneNumber}";
                    lines.Add(line);
                }

                File.WriteAllText(filePath, string.Join(Environment.NewLine, lines));
            }
            catch (IOException ex)
            {
                MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}");
            }
        }
    }
}
