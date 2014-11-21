namespace File_Renamer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtRoot = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnKeep = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnRename = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTotalFiles = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNameKept = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNamesReplaced = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDirectoriesCompleted = new System.Windows.Forms.Label();
            this.lblTotalDirectories = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCurrentDirectory = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.lblFileExtension = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Root:";
            // 
            // txtRoot
            // 
            this.txtRoot.Location = new System.Drawing.Point(52, 10);
            this.txtRoot.Name = "txtRoot";
            this.txtRoot.ReadOnly = true;
            this.txtRoot.Size = new System.Drawing.Size(252, 20);
            this.txtRoot.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(310, 8);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(146, 36);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 3;
            this.btnGo.Text = "Go!";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Current File Name:";
            // 
            // btnKeep
            // 
            this.btnKeep.Enabled = false;
            this.btnKeep.Location = new System.Drawing.Point(16, 129);
            this.btnKeep.Name = "btnKeep";
            this.btnKeep.Size = new System.Drawing.Size(75, 23);
            this.btnKeep.TabIndex = 6;
            this.btnKeep.Text = "Keep Name";
            this.btnKeep.UseVisualStyleBackColor = true;
            this.btnKeep.Click += new System.EventHandler(this.btnKeep_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(124, 98);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(267, 20);
            this.txtFileName.TabIndex = 7;
            // 
            // btnRename
            // 
            this.btnRename.Enabled = false;
            this.btnRename.Location = new System.Drawing.Point(98, 129);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(75, 23);
            this.btnRename.TabIndex = 8;
            this.btnRename.Text = "Rename File";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Enabled = false;
            this.btnAccept.Location = new System.Drawing.Point(205, 129);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(86, 23);
            this.btnAccept.TabIndex = 9;
            this.btnAccept.Text = "Accept Name";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Total Files Hit:";
            // 
            // lblTotalFiles
            // 
            this.lblTotalFiles.AutoSize = true;
            this.lblTotalFiles.Location = new System.Drawing.Point(100, 182);
            this.lblTotalFiles.Name = "lblTotalFiles";
            this.lblTotalFiles.Size = new System.Drawing.Size(13, 13);
            this.lblTotalFiles.TabIndex = 11;
            this.lblTotalFiles.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Names Kept:";
            // 
            // lblNameKept
            // 
            this.lblNameKept.AutoSize = true;
            this.lblNameKept.Location = new System.Drawing.Point(142, 204);
            this.lblNameKept.Name = "lblNameKept";
            this.lblNameKept.Size = new System.Drawing.Size(13, 13);
            this.lblNameKept.TabIndex = 13;
            this.lblNameKept.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Names Replaced:";
            // 
            // lblNamesReplaced
            // 
            this.lblNamesReplaced.AutoSize = true;
            this.lblNamesReplaced.Location = new System.Drawing.Point(142, 221);
            this.lblNamesReplaced.Name = "lblNamesReplaced";
            this.lblNamesReplaced.Size = new System.Drawing.Size(13, 13);
            this.lblNamesReplaced.TabIndex = 15;
            this.lblNamesReplaced.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 270);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Directories Completed: ";
            // 
            // lblDirectoriesCompleted
            // 
            this.lblDirectoriesCompleted.AutoSize = true;
            this.lblDirectoriesCompleted.Location = new System.Drawing.Point(145, 270);
            this.lblDirectoriesCompleted.Name = "lblDirectoriesCompleted";
            this.lblDirectoriesCompleted.Size = new System.Drawing.Size(13, 13);
            this.lblDirectoriesCompleted.TabIndex = 17;
            this.lblDirectoriesCompleted.Text = "0";
            // 
            // lblTotalDirectories
            // 
            this.lblTotalDirectories.AutoSize = true;
            this.lblTotalDirectories.Location = new System.Drawing.Point(145, 252);
            this.lblTotalDirectories.Name = "lblTotalDirectories";
            this.lblTotalDirectories.Size = new System.Drawing.Size(13, 13);
            this.lblTotalDirectories.TabIndex = 19;
            this.lblTotalDirectories.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 252);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Total Directories:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Current Directory:";
            // 
            // lblCurrentDirectory
            // 
            this.lblCurrentDirectory.AutoSize = true;
            this.lblCurrentDirectory.Location = new System.Drawing.Point(112, 65);
            this.lblCurrentDirectory.Name = "lblCurrentDirectory";
            this.lblCurrentDirectory.Size = new System.Drawing.Size(0, 13);
            this.lblCurrentDirectory.TabIndex = 21;
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(298, 129);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 23);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel Rename";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(271, 159);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Current File Extenstion:";
            // 
            // lblFileExtension
            // 
            this.lblFileExtension.AutoSize = true;
            this.lblFileExtension.Location = new System.Drawing.Point(345, 176);
            this.lblFileExtension.Name = "lblFileExtension";
            this.lblFileExtension.Size = new System.Drawing.Size(0, 13);
            this.lblFileExtension.TabIndex = 24;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 293);
            this.Controls.Add(this.lblFileExtension);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblCurrentDirectory);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblTotalDirectories);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblDirectoriesCompleted);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblNamesReplaced);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblNameKept);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblTotalFiles);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.btnKeep);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtRoot);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRoot;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnKeep;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTotalFiles;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNameKept;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblNamesReplaced;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDirectoriesCompleted;
        private System.Windows.Forms.Label lblTotalDirectories;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblCurrentDirectory;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblFileExtension;
    }
}

