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
        #region Internal Variables

        //List of directories with files left to process
        private List<DirectoryInfo> directoriesToProcess = new List<DirectoryInfo>();

        //List of files within the current directory left to process
        private List<FileInfo> filesToProcess = new List<FileInfo>();

        //Directory currently being processed
        private DirectoryInfo currentDirectory;

        //File currently being processed
        private FileInfo currentFile;

        #endregion Internal Variables

        #region Page Actions

        #region Constructor

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region btnBrowse_Click
        /// <summary>
        /// Opens folder browser when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.ShowDialog();
            txtRoot.Text = folderDialog.SelectedPath;
        }
        #endregion btnBrowse_Click

        #region btnGo_Click
        /// <summary>
        /// Locks browsing and begins processing when clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGo_Click(object sender, EventArgs e)
        {
            //Setup the UI
            Start();

            //Load all files
            FindAllFileDirectories(new DirectoryInfo(txtRoot.Text));

            //Set the label so the user knows just how many directories have files
            lblTotalDirectories.Text = directoriesToProcess.Count().ToString();

            //Sort by name so the directories will appear in the order they would in Windows Explorer just in case they are added differently
            directoriesToProcess.OrderBy(directory => directory.FullName);

            //If there is no next file the user gave a directory with no files in it or with no subdirectories with files
            if (!NextFile())
            {
                MessageBox.Show("There are no files in the root directory or any sub-folders.", "No Files", MessageBoxButtons.OK);
                Finished();
                return;
            }

            //Setup the UI for the first file and go
            SetupFile();
        }
        #endregion btnGo_Click

        #region btnKeep_Click
        /// <summary>
        /// Moves on to the next file without renaming
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKeep_Click(object sender, EventArgs e)
        {
            //Increment counter
            lblNameKept.Text = Convert.ToString(Convert.ToInt32(lblNameKept.Text) + 1);

            //If there is another file set it up
            //Else finish
            if (NextFile())
                SetupFile();
            else
                Finished();
        }
        #endregion btnKeep_Click

        #region btnRename_Click
        /// <summary>
        /// Enables editting of filename for renaming
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRename_Click(object sender, EventArgs e)
        {
            //Disable the keep and rename buttons, make the name editable, enabled the accept and cancel rename buttons
            btnKeep.Enabled = btnRename.Enabled = false;
            txtFileName.ReadOnly = false;
            btnAccept.Enabled = btnCancel.Enabled = true;
        }
        #endregion btnRename_Click

        #region btnAccept_Click
        /// <summary>
        /// Accepts the new file name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            //If the filename is an empty string, yell at the user cause that's just stupid
            if (string.IsNullOrEmpty(txtFileName.Text))
            {
                MessageBox.Show("Please enter a valid file name.", "Invalid Filename", MessageBoxButtons.OK);
                return;
            }

            //Rename the file
            currentFile.MoveTo(Path.Combine(currentFile.DirectoryName, string.Concat(txtFileName.Text, currentFile.Extension)));

            //Increment counter
            lblNamesReplaced.Text = Convert.ToString(Convert.ToInt32(lblNamesReplaced.Text) + 1);

            //If there is another file set it up
            //Else finish
            if (NextFile())
                SetupFile();
            else
                Finished();
        }
        #endregion btnAccept_Click

        #region btnCancel_Click
        /// <summary>
        /// Reverts filename to original and gives user option to keep or rename again
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Revert back to initial state and reset the file name
            btnKeep.Enabled = btnRename.Enabled = true;
            txtFileName.ReadOnly = true;
            btnAccept.Enabled = btnCancel.Enabled = false;
            txtFileName.Text = currentFile.Name;
        }
        #endregion btnCancel_Click

        #endregion Page Actions

        #region Helper Methods

        #region Start
        /// <summary>
        /// Sets the form up for starting processing
        /// </summary>
        private void Start()
        {
            //Null out the current file and directory (in case we are running this multiple times)
            currentFile = null;
            currentDirectory = null;
            
            //Disable browsing and reset the counters
            btnBrowse.Enabled = btnGo.Enabled = false;
            lblDirectoriesCompleted.Text = lblNameKept.Text = lblNamesReplaced.Text = lblTotalDirectories.Text = lblTotalFiles.Text = "0";
        }
        #endregion Start

        #region Finished
        /// <summary>
        /// Sets the form back to its original state and notifies the user all files have been reached
        /// </summary>
        private void Finished()
        {
            //Revert to the initial state and inform user we have completed
            btnBrowse.Enabled = btnGo.Enabled = txtFileName.ReadOnly = true;
            btnAccept.Enabled = btnKeep.Enabled = btnRename.Enabled = btnCancel.Enabled = false;
            lblCurrentDirectory.Text = txtFileName.Text = lblFileExtension.Text = string.Empty;
            MessageBox.Show("All files have been chceked.", "Completed", MessageBoxButtons.OK);
        }
        #endregion Finished

        #region FindAllFileDirectories
        /// <summary>
        /// Recursively loops through all directories in the given directory and adds them to the list for processing if there are files present within
        /// </summary>
        /// <param name="dir">Current directory to check for files and subdirectories</param>
        private void FindAllFileDirectories(DirectoryInfo dir)
        {
            //If the directory has any files and it is not already in the list (not sure how this could happen) add it to the list of directories to be processed
            if (dir.GetFiles().Any() && !directoriesToProcess.Contains(dir))
                directoriesToProcess.Add(dir);

            //Call this method for all subdirectories
            DirectoryInfo[] newDirs = dir.GetDirectories();
            foreach (DirectoryInfo dirInfo in newDirs)
                FindAllFileDirectories(dirInfo);
        }
        #endregion FindAllFileDirectories

        #region NextDirectory
        /// <summary>
        /// Gets the next directory to be processed
        /// </summary>
        /// <returns>True if there is another directory, false if no more to process</returns>
        private bool NextDirectory()
        {
            //If the current directory is not null, increment the directories completed counter since we just finished one
            if (currentDirectory != null)
                lblDirectoriesCompleted.Text = Convert.ToString(Convert.ToInt32(lblDirectoriesCompleted.Text) + 1);

            //If we have more directories to process, set it up and return true
            //Else return false
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
        #endregion NextDirectory

        #region NextFile
        /// <summary>
        /// Gets the next file for processing, if no more in current directory, gets the next directory
        /// </summary>
        /// <returns>True if more files to process, false if completed</returns>
        private bool NextFile()
        {
            //If the current file is not null, increment the total files counter since we just finished with one
            if (currentFile != null)
                lblTotalFiles.Text = Convert.ToString(Convert.ToInt32(lblTotalFiles.Text) + 1);

            //If there are more files to process, set up the next file and return true
            //Else if we can load another directory, load its file
            //Else return false
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
        #endregion NextFile

        #region SetupFile
        /// <summary>
        /// Sets up the UI for the next file to process
        /// </summary>
        private void SetupFile()
        {
            //Set the textbox to be editable and put the current files name, set the extension label and put the edit buttons in the right states
            txtFileName.ReadOnly = true;
            txtFileName.Text = currentFile.Name.Remove(currentFile.Name.LastIndexOf(currentFile.Extension));
            lblFileExtension.Text = currentFile.Extension;
            btnAccept.Enabled = btnCancel.Enabled = false;
            btnKeep.Enabled = btnRename.Enabled = true;
        }
        #endregion SetupFile

        #endregion Helper Methods
    }
}
