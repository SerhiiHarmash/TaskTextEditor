using System.Windows.Forms;

namespace TaskTextEditor
{
    public partial class SaveForm : Form
    {
        private readonly FileService _fileService;
        private readonly EditorForm _editorForm;
        private readonly string _text;
        private FileModel _file;

        public SaveForm(EditorForm editorForm, FileService fileService, FileModel file, string text)
        {
            InitializeComponent();
            _fileService = fileService;
            _editorForm = editorForm;
            _file = file;
            _text = text;
            TitleTB.Text = file?.Title;
        }

        private async void SaveBtn_Click(object sender, System.EventArgs e)
        {
            if (_text == null)
            {
                MessageBox.Show("Empty file",
                    "Save Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);

                return;
            }

            if (TitleTB.Text == null || TitleTB.Text == "")
            {
                MessageBox.Show("Write file name",
                    "Save Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);

                return;
            }

            if (_file == null)
            {
                _file = new FileModel() { Title = TitleTB.Text };
            }

            await _fileService.FileSave(_file, _text);
            Close();
            MessageBox.Show("file saved",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.None,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly);
        }

        private void CancelBtn_Click(object sender, System.EventArgs e)
        {
            _editorForm.ClearFile();
            Close();
        }
    }
}
