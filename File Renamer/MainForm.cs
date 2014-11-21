using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_Renamer
{
    public partial class MainForm : Form
    {
        private List<DirectoryInfo> directoriesToProcess = new List<DirectoryInfo>();
        private List<FileInfo> filesToProcess = new List<FileInfo>();
        private DirectoryInfo currentDirectory;
        private FileInfo currentFile;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.ShowDialog();
            txtRoot.Text = folderDialog.SelectedPath;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            Start();

            FindAllFileDirectories(new DirectoryInfo(txtRoot.Text));

            lblTotalDirectories.Text = directoriesToProcess.Count().ToString();

            directoriesToProcess.OrderBy(directory => directory.FullName);

            if (!NextFile())
            {
                MessageBox.Show("There are no files in the root directory or any sub-folders.", "No Files", MessageBoxButtons.OK);
                Finished();
                return;
            }

            SetupFile();
        }

        private void btnKeep_Click(object sender, EventArgs e)
        {
            lblNameKept.Text = Convert.ToString(Convert.ToInt32(lblNameKept.Text) + 1);

            if (NextFile())
                SetupFile();
            else
                Finished();
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            btnKeep.Enabled = btnRename.Enabled = false;
            txtFileName.ReadOnly = false;
            btnAccept.Enabled = btnCancel.Enabled = true;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFileName.Text))
            {
                MessageBox.Show("Please enter a valid file name.", "Invalid Filename", MessageBoxButtons.OK);
                return;
            }

            currentFile.MoveTo(Path.Combine(currentFile.DirectoryName, string.Concat(txtFileName.Text, currentFile.Extension)));

            lblNamesReplaced.Text = Convert.ToString(Convert.ToInt32(lblNamesReplaced.Text) + 1);

            if (NextFile())
                SetupFile();
            else
                Finished();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnKeep.Enabled = btnRename.Enabled = true;
            txtFileName.ReadOnly = true;
            btnAccept.Enabled = btnCancel.Enabled = false;
            txtFileName.Text = currentFile.Name;
        }

        private void Start()
        {
            currentFile = null;
            currentDirectory = null;
            btnBrowse.Enabled = btnGo.Enabled = false;
            lblDirectoriesCompleted.Text = lblNameKept.Text = lblNamesReplaced.Text = lblTotalDirectories.Text = lblTotalFiles.Text = "0";
        }

        private void Finished()
        {
            btnBrowse.Enabled = btnGo.Enabled = txtFileName.ReadOnly = true;
            btnAccept.Enabled = btnKeep.Enabled = btnRename.Enabled = btnCancel.Enabled = false;
            lblCurrentDirectory.Text = txtFileName.Text = lblFileExtension.Text = string.Empty;
            MessageBox.Show("All files have been chceked.", "Completed", MessageBoxButtons.OK);
        }

        private void FindAllFileDirectories(DirectoryInfo dir)
        {
            if (dir.GetFiles().Any() && !directoriesToProcess.Contains(dir))
                directoriesToProcess.Add(dir);

            DirectoryInfo[] newDirs = dir.GetDirectories();
            foreach (DirectoryInfo dirInfo in newDirs)
                FindAllFileDirectories(dirInfo);
        }

        private bool NextDirectory()
        {
            if (currentDirectory != null)
                lblDirectoriesCompleted.Text = Convert.ToString(Convert.ToInt32(lblDirectoriesCompleted.Text) + 1);

            if (directoriesToProcess.Any())
            {
                currentDirectory = directoriesToProcess.First();
                directoriesToProcess.Remove(currentDirectory);

                lblCurrentDirectory.Text = currentDirectory.FullName;

                filesToProcess.AddRange(currentDirectory.GetFiles());

                return true;
            }
            else
                return false;
        }

        private bool NextFile()
        {
            if (currentFile != null)
                lblTotalFiles.Text = Convert.ToString(Convert.ToInt32(lblTotalFiles.Text) + 1);

            if (filesToProcess.Any())
            {
                currentFile = filesToProcess.First();
                filesToProcess.Remove(currentFile);

                return true;
            }
            else if (NextDirectory())
            {
                currentFile = null;
                return NextFile();
            }
            else
                return false;
        }

        private void SetupFile()
        {
            txtFileName.ReadOnly = true;
            txtFileName.Text = currentFile.Name.Remove(currentFile.Name.LastIndexOf(currentFile.Extension));
            lblFileExtension.Text = currentFile.Extension;
            btnAccept.Enabled = btnCancel.Enabled = false;
            btnKeep.Enabled = btnRename.Enabled = true;
        }
    }
}
