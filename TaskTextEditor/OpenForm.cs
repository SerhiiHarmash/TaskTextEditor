using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskTextEditor.Models;

namespace TaskTextEditor
{
    public partial class OpenForm : Form
    {
        private readonly FileService _fileService;
        private List<FileOpenModel> _pickList;
        private readonly EditorForm _editorForm;

        public OpenForm(EditorForm editorForm, FileService fileService)
        {
            InitializeComponent();
            _fileService = fileService;
            _editorForm = editorForm;
        }

        private async void OpenForm_Load(object sender, EventArgs e)
        {
            _pickList = await _fileService.GetAllFilesForOpening();
            FileslistBox.DataSource = _pickList;
            FileslistBox.ValueMember = "Id";
            FileslistBox.DisplayMember = "Title";
        }

        private void FileTitleTB_TextChanged(object sender, EventArgs e)
        {
            if (FileTitleTB.Text == "" || FileTitleTB.Text == null)
            {
                FileslistBox.DataSource = _pickList;
            }
            else
            {
                FileslistBox.DataSource = _pickList?.Where(x => x.Title.Contains(FileTitleTB.Text)).ToList();
            }
        }

        private async void OpenBtn_Click(object sender, EventArgs e)
        {
             _editorForm.SaveFile();

            var fileId = (int)FileslistBox.SelectedValue;

            var file = await _fileService.GetFile(fileId);

            _editorForm.SetFile(file);
            _editorForm.DownloadFile();
            Close();
        }
    }
}
