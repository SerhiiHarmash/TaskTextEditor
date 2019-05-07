using System;
using System.IO;
using System.Windows.Forms;

namespace TaskTextEditor
{
    public partial class EditorForm : Form
    {
        private FileModel _selectedFile;
        private FileService _fileService;

        public EditorForm()
        {
            _fileService = new FileService();
            InitializeComponent();
        }

        public void SetFile(FileModel file)
        {
            _selectedFile = file;
            FileTitleLabel.Text = $"File Title: {file.Title}";
        }

        public void DownloadFile()
        {
            richTextBox.Text = _fileService.ReadFile(_selectedFile.File);
        }

        public void SaveFile()
        {
            if (_selectedFile != null || richTextBox.Text != "")
            {
                Save_Click(null, null);
            }
        }

        public void ClearFile()
        {
            _selectedFile = null;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            var saveForm = new SaveForm(this, _fileService, _selectedFile, richTextBox.Text);
            saveForm.Show();
            Enabled = false;
            saveForm.FormClosed += (sen, arg) =>
            {
                saveForm = null;
                Enabled = true;
            };   
        }

        private void Open_Click(object sender, EventArgs e)
        {
            var openForm = new OpenForm(this, _fileService);
            openForm.Show();
            Enabled = false;
            openForm.FormClosed += (sen, arg) =>
            {
                openForm = null;
                Enabled = true;
            };
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
            FileTitleLabel.Text = "File Title:";
            richTextBox.Text = "";
        }

     
    }
}
