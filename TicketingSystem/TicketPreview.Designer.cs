
namespace TicketingSystem
{
    partial class TicketPreview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TicketPreview));
            this.cbPrio = new MaterialSkin.Controls.MaterialComboBox();
            this.txtDescription = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.txtName = new MaterialSkin.Controls.MaterialTextBox2();
            this.cbIssue = new MaterialSkin.Controls.MaterialComboBox();
            this.txtID = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtDepartment = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtSubject = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.materialButton2 = new MaterialSkin.Controls.MaterialButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lblStat = new System.Windows.Forms.Label();
            this.lblLoc = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.materialButton3 = new MaterialSkin.Controls.MaterialButton();
            this.lblPath = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTag = new System.Windows.Forms.Label();
            this.materialProgressBar1 = new MaterialSkin.Controls.MaterialProgressBar();
            this.txtPreventive = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.txtTech = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtRootcause = new MaterialSkin.Controls.MaterialTextBox2();
            this.materialButton4 = new MaterialSkin.Controls.MaterialButton();
            this.btnReopen = new MaterialSkin.Controls.MaterialButton();
            this.cbCategory = new MaterialSkin.Controls.MaterialComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dtDateRequired = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbPrio
            // 
            this.cbPrio.AutoResize = false;
            this.cbPrio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbPrio.Depth = 0;
            this.cbPrio.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbPrio.DropDownHeight = 260;
            this.cbPrio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrio.DropDownWidth = 121;
            this.cbPrio.Font = new System.Drawing.Font("Poppins", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbPrio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbPrio.FormattingEnabled = true;
            this.cbPrio.Hint = "Priority level";
            this.cbPrio.IntegralHeight = false;
            this.cbPrio.ItemHeight = 43;
            this.cbPrio.Location = new System.Drawing.Point(15, 188);
            this.cbPrio.MaxDropDownItems = 6;
            this.cbPrio.MouseState = MaterialSkin.MouseState.OUT;
            this.cbPrio.Name = "cbPrio";
            this.cbPrio.Size = new System.Drawing.Size(287, 49);
            this.cbPrio.StartIndex = 0;
            this.cbPrio.TabIndex = 4;
            // 
            // txtDescription
            // 
            this.txtDescription.AnimateReadOnly = false;
            this.txtDescription.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDescription.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDescription.Depth = 0;
            this.txtDescription.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.HideSelection = true;
            this.txtDescription.Hint = "Description";
            this.txtDescription.Location = new System.Drawing.Point(16, 299);
            this.txtDescription.MaxLength = 32767;
            this.txtDescription.MouseState = MaterialSkin.MouseState.OUT;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PasswordChar = '\0';
            this.txtDescription.ReadOnly = false;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDescription.SelectedText = "";
            this.txtDescription.SelectionLength = 0;
            this.txtDescription.SelectionStart = 0;
            this.txtDescription.ShortcutsEnabled = true;
            this.txtDescription.Size = new System.Drawing.Size(579, 298);
            this.txtDescription.TabIndex = 8;
            this.txtDescription.TabStop = false;
            this.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDescription.UseSystemPasswordChar = false;
            // 
            // txtName
            // 
            this.txtName.AnimateReadOnly = false;
            this.txtName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtName.Depth = 0;
            this.txtName.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtName.HideSelection = true;
            this.txtName.Hint = "Name";
            this.txtName.LeadingIcon = null;
            this.txtName.Location = new System.Drawing.Point(403, -57);
            this.txtName.MaxLength = 32767;
            this.txtName.MouseState = MaterialSkin.MouseState.OUT;
            this.txtName.Name = "txtName";
            this.txtName.PasswordChar = '\0';
            this.txtName.PrefixSuffixText = null;
            this.txtName.ReadOnly = false;
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtName.SelectedText = "";
            this.txtName.SelectionLength = 0;
            this.txtName.SelectionStart = 0;
            this.txtName.ShortcutsEnabled = true;
            this.txtName.Size = new System.Drawing.Size(287, 48);
            this.txtName.TabIndex = 9;
            this.txtName.TabStop = false;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtName.TrailingIcon = null;
            this.txtName.UseSystemPasswordChar = false;
            // 
            // cbIssue
            // 
            this.cbIssue.AutoResize = false;
            this.cbIssue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbIssue.Depth = 0;
            this.cbIssue.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbIssue.DropDownHeight = 260;
            this.cbIssue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIssue.DropDownWidth = 121;
            this.cbIssue.Font = new System.Drawing.Font("Poppins", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbIssue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbIssue.FormattingEnabled = true;
            this.cbIssue.Hint = "Issue type";
            this.cbIssue.IntegralHeight = false;
            this.cbIssue.ItemHeight = 43;
            this.cbIssue.Location = new System.Drawing.Point(15, 133);
            this.cbIssue.MaxDropDownItems = 6;
            this.cbIssue.MouseState = MaterialSkin.MouseState.OUT;
            this.cbIssue.Name = "cbIssue";
            this.cbIssue.Size = new System.Drawing.Size(287, 49);
            this.cbIssue.StartIndex = 0;
            this.cbIssue.TabIndex = 2;
            // 
            // txtID
            // 
            this.txtID.AnimateReadOnly = false;
            this.txtID.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtID.Depth = 0;
            this.txtID.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtID.HideSelection = true;
            this.txtID.Hint = "ID";
            this.txtID.LeadingIcon = null;
            this.txtID.Location = new System.Drawing.Point(111, -57);
            this.txtID.MaxLength = 32767;
            this.txtID.MouseState = MaterialSkin.MouseState.OUT;
            this.txtID.Name = "txtID";
            this.txtID.PasswordChar = '\0';
            this.txtID.PrefixSuffixText = null;
            this.txtID.ReadOnly = false;
            this.txtID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtID.SelectedText = "";
            this.txtID.SelectionLength = 0;
            this.txtID.SelectionStart = 0;
            this.txtID.ShortcutsEnabled = true;
            this.txtID.Size = new System.Drawing.Size(286, 48);
            this.txtID.TabIndex = 8;
            this.txtID.TabStop = false;
            this.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtID.TrailingIcon = null;
            this.txtID.UseSystemPasswordChar = false;
            // 
            // txtDepartment
            // 
            this.txtDepartment.AnimateReadOnly = false;
            this.txtDepartment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtDepartment.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDepartment.Depth = 0;
            this.txtDepartment.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtDepartment.HideSelection = true;
            this.txtDepartment.Hint = "Department";
            this.txtDepartment.LeadingIcon = null;
            this.txtDepartment.Location = new System.Drawing.Point(16, 79);
            this.txtDepartment.MaxLength = 32767;
            this.txtDepartment.MouseState = MaterialSkin.MouseState.OUT;
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.PasswordChar = '\0';
            this.txtDepartment.PrefixSuffixText = null;
            this.txtDepartment.ReadOnly = false;
            this.txtDepartment.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtDepartment.SelectedText = "";
            this.txtDepartment.SelectionLength = 0;
            this.txtDepartment.SelectionStart = 0;
            this.txtDepartment.ShortcutsEnabled = true;
            this.txtDepartment.Size = new System.Drawing.Size(286, 48);
            this.txtDepartment.TabIndex = 0;
            this.txtDepartment.TabStop = false;
            this.txtDepartment.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDepartment.TrailingIcon = null;
            this.txtDepartment.UseSystemPasswordChar = false;
            // 
            // txtSubject
            // 
            this.txtSubject.AnimateReadOnly = false;
            this.txtSubject.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtSubject.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtSubject.Depth = 0;
            this.txtSubject.Font = new System.Drawing.Font("Poppins", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtSubject.HideSelection = true;
            this.txtSubject.Hint = "Subject";
            this.txtSubject.LeadingIcon = null;
            this.txtSubject.Location = new System.Drawing.Point(16, 243);
            this.txtSubject.MaxLength = 32767;
            this.txtSubject.MouseState = MaterialSkin.MouseState.OUT;
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.PasswordChar = '\0';
            this.txtSubject.PrefixSuffixText = null;
            this.txtSubject.ReadOnly = false;
            this.txtSubject.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtSubject.SelectedText = "";
            this.txtSubject.SelectionLength = 0;
            this.txtSubject.SelectionStart = 0;
            this.txtSubject.ShortcutsEnabled = true;
            this.txtSubject.Size = new System.Drawing.Size(286, 48);
            this.txtSubject.TabIndex = 6;
            this.txtSubject.TabStop = false;
            this.txtSubject.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSubject.TrailingIcon = null;
            this.txtSubject.UseSystemPasswordChar = false;
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(16, 610);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(64, 36);
            this.materialButton1.TabIndex = 16;
            this.materialButton1.Text = "Save";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // materialButton2
            // 
            this.materialButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton2.Depth = 0;
            this.materialButton2.HighEmphasis = true;
            this.materialButton2.Icon = null;
            this.materialButton2.Location = new System.Drawing.Point(88, 610);
            this.materialButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton2.Name = "materialButton2";
            this.materialButton2.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton2.Size = new System.Drawing.Size(77, 36);
            this.materialButton2.TabIndex = 17;
            this.materialButton2.Text = "Cancel";
            this.materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.materialButton2.UseAccentColor = false;
            this.materialButton2.UseVisualStyleBackColor = true;
            this.materialButton2.Click += new System.EventHandler(this.materialButton2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Poppins", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(261, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 37);
            this.label1.TabIndex = 18;
            this.label1.Text = "Status:";
            // 
            // lblStat
            // 
            this.lblStat.AutoSize = true;
            this.lblStat.BackColor = System.Drawing.Color.Transparent;
            this.lblStat.Font = new System.Drawing.Font("Poppins", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStat.ForeColor = System.Drawing.Color.White;
            this.lblStat.Location = new System.Drawing.Point(340, 29);
            this.lblStat.Name = "lblStat";
            this.lblStat.Size = new System.Drawing.Size(56, 37);
            this.lblStat.TabIndex = 19;
            this.lblStat.Text = "asd";
            // 
            // lblLoc
            // 
            this.lblLoc.AutoSize = true;
            this.lblLoc.BackColor = System.Drawing.Color.Transparent;
            this.lblLoc.Font = new System.Drawing.Font("Poppins", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoc.ForeColor = System.Drawing.Color.White;
            this.lblLoc.Location = new System.Drawing.Point(495, 29);
            this.lblLoc.Name = "lblLoc";
            this.lblLoc.Size = new System.Drawing.Size(125, 37);
            this.lblLoc.TabIndex = 21;
            this.lblLoc.Text = "Date Filed:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Poppins", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(614, 29);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(95, 37);
            this.lblDate.TabIndex = 22;
            this.lblDate.Text = "dasdas";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(618, 243);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(583, 307);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // materialButton3
            // 
            this.materialButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton3.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton3.Depth = 0;
            this.materialButton3.HighEmphasis = true;
            this.materialButton3.Icon = null;
            this.materialButton3.Location = new System.Drawing.Point(618, 559);
            this.materialButton3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton3.Name = "materialButton3";
            this.materialButton3.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton3.Size = new System.Drawing.Size(114, 36);
            this.materialButton3.TabIndex = 23;
            this.materialButton3.Text = "Upload new";
            this.materialButton3.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton3.UseAccentColor = false;
            this.materialButton3.UseVisualStyleBackColor = true;
            this.materialButton3.Click += new System.EventHandler(this.materialButton3_Click);
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.BackColor = System.Drawing.Color.Transparent;
            this.lblPath.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPath.Location = new System.Drawing.Point(739, 574);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(25, 23);
            this.lblPath.TabIndex = 24;
            this.lblPath.Text = "...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Poppins", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(850, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 37);
            this.label2.TabIndex = 25;
            this.label2.Text = "Tag:";
            // 
            // lblTag
            // 
            this.lblTag.AutoSize = true;
            this.lblTag.BackColor = System.Drawing.Color.Transparent;
            this.lblTag.Font = new System.Drawing.Font("Poppins", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTag.ForeColor = System.Drawing.Color.White;
            this.lblTag.Location = new System.Drawing.Point(900, 29);
            this.lblTag.Name = "lblTag";
            this.lblTag.Size = new System.Drawing.Size(56, 37);
            this.lblTag.TabIndex = 26;
            this.lblTag.Text = "asd";
            // 
            // materialProgressBar1
            // 
            this.materialProgressBar1.Depth = 0;
            this.materialProgressBar1.Location = new System.Drawing.Point(618, 604);
            this.materialProgressBar1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialProgressBar1.Name = "materialProgressBar1";
            this.materialProgressBar1.Size = new System.Drawing.Size(583, 5);
            this.materialProgressBar1.TabIndex = 27;
            this.materialProgressBar1.Visible = false;
            // 
            // txtPreventive
            // 
            this.txtPreventive.AnimateReadOnly = false;
            this.txtPreventive.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtPreventive.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPreventive.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPreventive.Depth = 0;
            this.txtPreventive.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPreventive.HideSelection = true;
            this.txtPreventive.Hint = "Preventive actions taken";
            this.txtPreventive.Location = new System.Drawing.Point(618, 79);
            this.txtPreventive.MaxLength = 32767;
            this.txtPreventive.MouseState = MaterialSkin.MouseState.OUT;
            this.txtPreventive.Name = "txtPreventive";
            this.txtPreventive.PasswordChar = '\0';
            this.txtPreventive.ReadOnly = false;
            this.txtPreventive.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPreventive.SelectedText = "";
            this.txtPreventive.SelectionLength = 0;
            this.txtPreventive.SelectionStart = 0;
            this.txtPreventive.ShortcutsEnabled = true;
            this.txtPreventive.Size = new System.Drawing.Size(583, 158);
            this.txtPreventive.TabIndex = 9;
            this.txtPreventive.TabStop = false;
            this.txtPreventive.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPreventive.UseSystemPasswordChar = false;
            // 
            // txtTech
            // 
            this.txtTech.AnimateReadOnly = false;
            this.txtTech.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtTech.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtTech.Depth = 0;
            this.txtTech.Font = new System.Drawing.Font("Poppins", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtTech.HideSelection = true;
            this.txtTech.Hint = "Technician assigned";
            this.txtTech.LeadingIcon = null;
            this.txtTech.Location = new System.Drawing.Point(309, 189);
            this.txtTech.MaxLength = 32767;
            this.txtTech.MouseState = MaterialSkin.MouseState.OUT;
            this.txtTech.Name = "txtTech";
            this.txtTech.PasswordChar = '\0';
            this.txtTech.PrefixSuffixText = null;
            this.txtTech.ReadOnly = true;
            this.txtTech.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTech.SelectedText = "";
            this.txtTech.SelectionLength = 0;
            this.txtTech.SelectionStart = 0;
            this.txtTech.ShortcutsEnabled = true;
            this.txtTech.Size = new System.Drawing.Size(286, 48);
            this.txtTech.TabIndex = 5;
            this.txtTech.TabStop = false;
            this.txtTech.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtTech.TrailingIcon = null;
            this.txtTech.UseSystemPasswordChar = false;
            // 
            // txtRootcause
            // 
            this.txtRootcause.AnimateReadOnly = false;
            this.txtRootcause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtRootcause.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtRootcause.Depth = 0;
            this.txtRootcause.Font = new System.Drawing.Font("Poppins", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtRootcause.HideSelection = true;
            this.txtRootcause.Hint = "Root cause";
            this.txtRootcause.LeadingIcon = null;
            this.txtRootcause.Location = new System.Drawing.Point(309, 243);
            this.txtRootcause.MaxLength = 32767;
            this.txtRootcause.MouseState = MaterialSkin.MouseState.OUT;
            this.txtRootcause.Name = "txtRootcause";
            this.txtRootcause.PasswordChar = '\0';
            this.txtRootcause.PrefixSuffixText = null;
            this.txtRootcause.ReadOnly = false;
            this.txtRootcause.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRootcause.SelectedText = "";
            this.txtRootcause.SelectionLength = 0;
            this.txtRootcause.SelectionStart = 0;
            this.txtRootcause.ShortcutsEnabled = true;
            this.txtRootcause.Size = new System.Drawing.Size(286, 48);
            this.txtRootcause.TabIndex = 7;
            this.txtRootcause.TabStop = false;
            this.txtRootcause.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtRootcause.TrailingIcon = null;
            this.txtRootcause.UseSystemPasswordChar = false;
            // 
            // materialButton4
            // 
            this.materialButton4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton4.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton4.Depth = 0;
            this.materialButton4.HighEmphasis = true;
            this.materialButton4.Icon = null;
            this.materialButton4.Location = new System.Drawing.Point(173, 612);
            this.materialButton4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton4.Name = "materialButton4";
            this.materialButton4.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton4.Size = new System.Drawing.Size(149, 36);
            this.materialButton4.TabIndex = 39;
            this.materialButton4.Text = "Set as Approved";
            this.materialButton4.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton4.UseAccentColor = false;
            this.materialButton4.UseVisualStyleBackColor = true;
            this.materialButton4.Click += new System.EventHandler(this.materialButton4_Click);
            // 
            // btnReopen
            // 
            this.btnReopen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReopen.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnReopen.Depth = 0;
            this.btnReopen.HighEmphasis = true;
            this.btnReopen.Icon = null;
            this.btnReopen.Location = new System.Drawing.Point(330, 612);
            this.btnReopen.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnReopen.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnReopen.Name = "btnReopen";
            this.btnReopen.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnReopen.Size = new System.Drawing.Size(135, 36);
            this.btnReopen.TabIndex = 40;
            this.btnReopen.Text = "Re-open ticket";
            this.btnReopen.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnReopen.UseAccentColor = false;
            this.btnReopen.UseVisualStyleBackColor = true;
            this.btnReopen.Click += new System.EventHandler(this.materialButton5_Click);
            // 
            // cbCategory
            // 
            this.cbCategory.AutoResize = false;
            this.cbCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbCategory.Depth = 0;
            this.cbCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbCategory.DropDownHeight = 260;
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.DropDownWidth = 121;
            this.cbCategory.Font = new System.Drawing.Font("Poppins", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Hint = "Category";
            this.cbCategory.IntegralHeight = false;
            this.cbCategory.ItemHeight = 43;
            this.cbCategory.Items.AddRange(new object[] {
            "",
            "Hardware",
            "Software",
            "Network",
            "Other"});
            this.cbCategory.Location = new System.Drawing.Point(308, 79);
            this.cbCategory.MaxDropDownItems = 6;
            this.cbCategory.MouseState = MaterialSkin.MouseState.OUT;
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(286, 49);
            this.cbCategory.StartIndex = 0;
            this.cbCategory.TabIndex = 1;
            this.cbCategory.TextChanged += new System.EventHandler(this.cbCategory_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.DimGray;
            this.label15.Location = new System.Drawing.Point(310, 130);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 16);
            this.label15.TabIndex = 46;
            this.label15.Text = "Date Required";
            // 
            // dtDateRequired
            // 
            this.dtDateRequired.Font = new System.Drawing.Font("Arial", 16.75F);
            this.dtDateRequired.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDateRequired.Location = new System.Drawing.Point(309, 149);
            this.dtDateRequired.Name = "dtDateRequired";
            this.dtDateRequired.Size = new System.Drawing.Size(287, 33);
            this.dtDateRequired.TabIndex = 45;
            // 
            // TicketPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1225, 657);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.dtDateRequired);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.btnReopen);
            this.Controls.Add(this.materialButton4);
            this.Controls.Add(this.txtRootcause);
            this.Controls.Add(this.txtTech);
            this.Controls.Add(this.txtPreventive);
            this.Controls.Add(this.materialProgressBar1);
            this.Controls.Add(this.lblTag);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.materialButton3);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblLoc);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblStat);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.materialButton2);
            this.Controls.Add(this.materialButton1);
            this.Controls.Add(this.cbPrio);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.cbIssue);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.txtDepartment);
            this.Controls.Add(this.txtSubject);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TicketPreview";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "tick";
            this.Load += new System.EventHandler(this.TicketPreview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialComboBox cbPrio;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 txtDescription;
        private MaterialSkin.Controls.MaterialTextBox2 txtName;
        private MaterialSkin.Controls.MaterialComboBox cbIssue;
        private MaterialSkin.Controls.MaterialTextBox2 txtID;
        private MaterialSkin.Controls.MaterialTextBox2 txtDepartment;
        private MaterialSkin.Controls.MaterialTextBox2 txtSubject;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStat;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblLoc;
        private System.Windows.Forms.Label lblDate;
        private MaterialSkin.Controls.MaterialButton materialButton3;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTag;
        private MaterialSkin.Controls.MaterialProgressBar materialProgressBar1;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 txtPreventive;
        private MaterialSkin.Controls.MaterialTextBox2 txtTech;
        private MaterialSkin.Controls.MaterialTextBox2 txtRootcause;
        private MaterialSkin.Controls.MaterialButton materialButton4;
        private MaterialSkin.Controls.MaterialButton btnReopen;
        private MaterialSkin.Controls.MaterialComboBox cbCategory;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtDateRequired;
    }
}