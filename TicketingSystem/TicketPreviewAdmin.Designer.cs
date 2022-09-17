
namespace TicketingSystem
{
    partial class TicketPreviewAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TicketPreviewAdmin));
            this.cbPrio = new MaterialSkin.Controls.MaterialComboBox();
            this.cbIssue = new MaterialSkin.Controls.MaterialComboBox();
            this.cbStatus = new MaterialSkin.Controls.MaterialComboBox();
            this.txtID = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtName = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtRequestor = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtDescription = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.txtSubject = new MaterialSkin.Controls.MaterialTextBox2();
            this.lblPath = new System.Windows.Forms.Label();
            this.btnSave = new MaterialSkin.Controls.MaterialButton();
            this.btnTransfer = new MaterialSkin.Controls.MaterialButton();
            this.lblTag = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblLoc = new System.Windows.Forms.Label();
            this.btnOpen = new MaterialSkin.Controls.MaterialButton();
            this.txtPreventive = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            this.lblDowntime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelTransfer = new MaterialSkin.Controls.MaterialExpansionPanel();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.materialButton6 = new MaterialSkin.Controls.MaterialButton();
            this.materialButton5 = new MaterialSkin.Controls.MaterialButton();
            this.cbTechnician = new MaterialSkin.Controls.MaterialComboBox();
            this.cbTech = new MaterialSkin.Controls.MaterialComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbDepartment = new MaterialSkin.Controls.MaterialComboBox();
            this.txtRootCause = new MaterialSkin.Controls.MaterialTextBox2();
            this.dtDateRequired = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.cbCategory = new MaterialSkin.Controls.MaterialComboBox();
            this.panelTransfer.SuspendLayout();
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
            this.cbPrio.Location = new System.Drawing.Point(299, 240);
            this.cbPrio.MaxDropDownItems = 6;
            this.cbPrio.MouseState = MaterialSkin.MouseState.OUT;
            this.cbPrio.Name = "cbPrio";
            this.cbPrio.Size = new System.Drawing.Size(287, 49);
            this.cbPrio.StartIndex = 0;
            this.cbPrio.TabIndex = 17;
            this.cbPrio.MouseHover += new System.EventHandler(this.cbPrio_MouseHover);
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
            this.cbIssue.Location = new System.Drawing.Point(298, 185);
            this.cbIssue.MaxDropDownItems = 6;
            this.cbIssue.MouseState = MaterialSkin.MouseState.OUT;
            this.cbIssue.Name = "cbIssue";
            this.cbIssue.Size = new System.Drawing.Size(287, 49);
            this.cbIssue.StartIndex = 0;
            this.cbIssue.TabIndex = 15;
            // 
            // cbStatus
            // 
            this.cbStatus.AutoResize = false;
            this.cbStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbStatus.Depth = 0;
            this.cbStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbStatus.DropDownHeight = 260;
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.DropDownWidth = 121;
            this.cbStatus.Font = new System.Drawing.Font("Poppins", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Hint = "Status";
            this.cbStatus.IntegralHeight = false;
            this.cbStatus.ItemHeight = 43;
            this.cbStatus.Location = new System.Drawing.Point(5, 294);
            this.cbStatus.MaxDropDownItems = 6;
            this.cbStatus.MouseState = MaterialSkin.MouseState.OUT;
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(287, 49);
            this.cbStatus.StartIndex = 0;
            this.cbStatus.TabIndex = 18;
            this.cbStatus.Click += new System.EventHandler(this.cbStatus_Click);
            this.cbStatus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cbStatus_MouseDown);
            this.cbStatus.MouseHover += new System.EventHandler(this.cbStatus_MouseHover);
            // 
            // txtID
            // 
            this.txtID.AnimateReadOnly = false;
            this.txtID.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtID.Depth = 0;
            this.txtID.Font = new System.Drawing.Font("Poppins", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtID.HideSelection = true;
            this.txtID.Hint = "ID";
            this.txtID.LeadingIcon = null;
            this.txtID.Location = new System.Drawing.Point(6, 77);
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
            this.txtID.TabIndex = 19;
            this.txtID.TabStop = false;
            this.txtID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtID.TrailingIcon = null;
            this.txtID.UseSystemPasswordChar = false;
            this.txtID.Validated += new System.EventHandler(this.txtID_Validated);
            // 
            // txtName
            // 
            this.txtName.AnimateReadOnly = false;
            this.txtName.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtName.Depth = 0;
            this.txtName.Font = new System.Drawing.Font("Poppins", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtName.HideSelection = true;
            this.txtName.Hint = "Name";
            this.txtName.LeadingIcon = null;
            this.txtName.Location = new System.Drawing.Point(299, 77);
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
            this.txtName.Size = new System.Drawing.Size(286, 48);
            this.txtName.TabIndex = 20;
            this.txtName.TabStop = false;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtName.TrailingIcon = null;
            this.txtName.UseSystemPasswordChar = false;
            // 
            // txtRequestor
            // 
            this.txtRequestor.AnimateReadOnly = false;
            this.txtRequestor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtRequestor.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtRequestor.Depth = 0;
            this.txtRequestor.Font = new System.Drawing.Font("Poppins", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtRequestor.HideSelection = true;
            this.txtRequestor.Hint = "Requestor";
            this.txtRequestor.LeadingIcon = null;
            this.txtRequestor.Location = new System.Drawing.Point(299, 131);
            this.txtRequestor.MaxLength = 32767;
            this.txtRequestor.MouseState = MaterialSkin.MouseState.OUT;
            this.txtRequestor.Name = "txtRequestor";
            this.txtRequestor.PasswordChar = '\0';
            this.txtRequestor.PrefixSuffixText = null;
            this.txtRequestor.ReadOnly = false;
            this.txtRequestor.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRequestor.SelectedText = "";
            this.txtRequestor.SelectionLength = 0;
            this.txtRequestor.SelectionStart = 0;
            this.txtRequestor.ShortcutsEnabled = true;
            this.txtRequestor.Size = new System.Drawing.Size(286, 48);
            this.txtRequestor.TabIndex = 21;
            this.txtRequestor.TabStop = false;
            this.txtRequestor.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtRequestor.TrailingIcon = null;
            this.txtRequestor.UseSystemPasswordChar = false;
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
            this.txtDescription.Location = new System.Drawing.Point(6, 403);
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
            this.txtDescription.Size = new System.Drawing.Size(579, 220);
            this.txtDescription.TabIndex = 23;
            this.txtDescription.TabStop = false;
            this.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDescription.UseSystemPasswordChar = false;
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
            this.txtSubject.Location = new System.Drawing.Point(6, 349);
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
            this.txtSubject.Size = new System.Drawing.Size(287, 48);
            this.txtSubject.TabIndex = 22;
            this.txtSubject.TabStop = false;
            this.txtSubject.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtSubject.TrailingIcon = null;
            this.txtSubject.UseSystemPasswordChar = false;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.BackColor = System.Drawing.Color.Transparent;
            this.lblPath.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPath.Location = new System.Drawing.Point(591, 637);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(27, 34);
            this.lblPath.TabIndex = 25;
            this.lblPath.Text = "...";
            // 
            // btnSave
            // 
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSave.Depth = 0;
            this.btnSave.HighEmphasis = true;
            this.btnSave.Icon = null;
            this.btnSave.Location = new System.Drawing.Point(7, 632);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnSave.Size = new System.Drawing.Size(64, 36);
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "Save";
            this.btnSave.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSave.UseAccentColor = false;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // btnTransfer
            // 
            this.btnTransfer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTransfer.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnTransfer.Depth = 0;
            this.btnTransfer.HighEmphasis = true;
            this.btnTransfer.Icon = null;
            this.btnTransfer.Location = new System.Drawing.Point(79, 632);
            this.btnTransfer.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnTransfer.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnTransfer.Size = new System.Drawing.Size(85, 36);
            this.btnTransfer.TabIndex = 27;
            this.btnTransfer.Text = "Tansfer";
            this.btnTransfer.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnTransfer.UseAccentColor = false;
            this.btnTransfer.UseVisualStyleBackColor = true;
            this.btnTransfer.Click += new System.EventHandler(this.materialButton2_Click);
            // 
            // lblTag
            // 
            this.lblTag.AutoSize = true;
            this.lblTag.BackColor = System.Drawing.Color.Transparent;
            this.lblTag.Font = new System.Drawing.Font("Poppins", 13F);
            this.lblTag.ForeColor = System.Drawing.Color.White;
            this.lblTag.Location = new System.Drawing.Point(633, 33);
            this.lblTag.Name = "lblTag";
            this.lblTag.Size = new System.Drawing.Size(47, 31);
            this.lblTag.TabIndex = 30;
            this.lblTag.Text = "asd";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Poppins", 13F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(591, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 31);
            this.label2.TabIndex = 29;
            this.label2.Text = "Tag:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Poppins", 13F);
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(999, 33);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(80, 31);
            this.lblDate.TabIndex = 32;
            this.lblDate.Text = "dasdas";
            // 
            // lblLoc
            // 
            this.lblLoc.AutoSize = true;
            this.lblLoc.BackColor = System.Drawing.Color.Transparent;
            this.lblLoc.Font = new System.Drawing.Font("Poppins", 13F);
            this.lblLoc.ForeColor = System.Drawing.Color.White;
            this.lblLoc.Location = new System.Drawing.Point(903, 33);
            this.lblLoc.Name = "lblLoc";
            this.lblLoc.Size = new System.Drawing.Size(106, 31);
            this.lblLoc.TabIndex = 31;
            this.lblLoc.Text = "Date Filed:";
            // 
            // btnOpen
            // 
            this.btnOpen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnOpen.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnOpen.Depth = 0;
            this.btnOpen.HighEmphasis = true;
            this.btnOpen.Icon = null;
            this.btnOpen.Location = new System.Drawing.Point(172, 632);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnOpen.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnOpen.Size = new System.Drawing.Size(64, 36);
            this.btnOpen.TabIndex = 33;
            this.btnOpen.Text = "Open";
            this.btnOpen.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnOpen.UseAccentColor = false;
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.materialButton4_Click);
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
            this.txtPreventive.Hint = "Actions taken";
            this.txtPreventive.Location = new System.Drawing.Point(595, 77);
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
            this.txtPreventive.Size = new System.Drawing.Size(624, 186);
            this.txtPreventive.TabIndex = 35;
            this.txtPreventive.TabStop = false;
            this.txtPreventive.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPreventive.UseSystemPasswordChar = false;
            // 
            // lblDowntime
            // 
            this.lblDowntime.AutoSize = true;
            this.lblDowntime.BackColor = System.Drawing.Color.Transparent;
            this.lblDowntime.Font = new System.Drawing.Font("Poppins", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDowntime.ForeColor = System.Drawing.Color.White;
            this.lblDowntime.Location = new System.Drawing.Point(405, 33);
            this.lblDowntime.Name = "lblDowntime";
            this.lblDowntime.Size = new System.Drawing.Size(44, 30);
            this.lblDowntime.TabIndex = 37;
            this.lblDowntime.Text = "asd";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Poppins", 13F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(294, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 31);
            this.label3.TabIndex = 36;
            this.label3.Text = "Down time:";
            // 
            // panelTransfer
            // 
            this.panelTransfer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelTransfer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTransfer.CancelButtonText = "";
            this.panelTransfer.Controls.Add(this.materialCard1);
            this.panelTransfer.Controls.Add(this.materialButton6);
            this.panelTransfer.Controls.Add(this.materialButton5);
            this.panelTransfer.Controls.Add(this.cbTechnician);
            this.panelTransfer.Depth = 0;
            this.panelTransfer.Description = "Please select technician to transfer to:";
            this.panelTransfer.ExpandHeight = 200;
            this.panelTransfer.Font = new System.Drawing.Font("Poppins", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.panelTransfer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelTransfer.Location = new System.Drawing.Point(238, 269);
            this.panelTransfer.Margin = new System.Windows.Forms.Padding(3, 16, 3, 16);
            this.panelTransfer.MouseState = MaterialSkin.MouseState.HOVER;
            this.panelTransfer.Name = "panelTransfer";
            this.panelTransfer.Padding = new System.Windows.Forms.Padding(24, 64, 24, 16);
            this.panelTransfer.Size = new System.Drawing.Size(660, 200);
            this.panelTransfer.TabIndex = 38;
            this.panelTransfer.Title = "";
            this.panelTransfer.ValidationButtonText = "";
            this.panelTransfer.Visible = false;
            this.panelTransfer.Paint += new System.Windows.Forms.PaintEventHandler(this.materialExpansionPanel1_Paint);
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(438, 137);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(200, 46);
            this.materialCard1.TabIndex = 29;
            // 
            // materialButton6
            // 
            this.materialButton6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton6.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton6.Depth = 0;
            this.materialButton6.HighEmphasis = true;
            this.materialButton6.Icon = null;
            this.materialButton6.Location = new System.Drawing.Point(23, 147);
            this.materialButton6.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton6.Name = "materialButton6";
            this.materialButton6.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton6.Size = new System.Drawing.Size(77, 36);
            this.materialButton6.TabIndex = 28;
            this.materialButton6.Text = "Cancel";
            this.materialButton6.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.materialButton6.UseAccentColor = false;
            this.materialButton6.UseVisualStyleBackColor = true;
            this.materialButton6.Click += new System.EventHandler(this.materialButton6_Click);
            // 
            // materialButton5
            // 
            this.materialButton5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton5.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton5.Depth = 0;
            this.materialButton5.HighEmphasis = true;
            this.materialButton5.Icon = null;
            this.materialButton5.Location = new System.Drawing.Point(108, 147);
            this.materialButton5.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton5.Name = "materialButton5";
            this.materialButton5.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton5.Size = new System.Drawing.Size(94, 36);
            this.materialButton5.TabIndex = 27;
            this.materialButton5.Text = "Transfer";
            this.materialButton5.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton5.UseAccentColor = false;
            this.materialButton5.UseVisualStyleBackColor = true;
            this.materialButton5.Click += new System.EventHandler(this.materialButton5_Click);
            // 
            // cbTechnician
            // 
            this.cbTechnician.AutoResize = false;
            this.cbTechnician.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbTechnician.Depth = 0;
            this.cbTechnician.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbTechnician.DropDownHeight = 174;
            this.cbTechnician.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTechnician.DropDownWidth = 121;
            this.cbTechnician.Font = new System.Drawing.Font("Poppins", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbTechnician.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbTechnician.FormattingEnabled = true;
            this.cbTechnician.IntegralHeight = false;
            this.cbTechnician.ItemHeight = 43;
            this.cbTechnician.Location = new System.Drawing.Point(178, 55);
            this.cbTechnician.MaxDropDownItems = 4;
            this.cbTechnician.MouseState = MaterialSkin.MouseState.OUT;
            this.cbTechnician.Name = "cbTechnician";
            this.cbTechnician.Size = new System.Drawing.Size(471, 49);
            this.cbTechnician.StartIndex = 0;
            this.cbTechnician.TabIndex = 2;
            // 
            // cbTech
            // 
            this.cbTech.AutoResize = false;
            this.cbTech.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbTech.Depth = 0;
            this.cbTech.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbTech.DropDownHeight = 260;
            this.cbTech.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTech.DropDownWidth = 121;
            this.cbTech.Font = new System.Drawing.Font("Poppins", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbTech.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbTech.FormattingEnabled = true;
            this.cbTech.Hint = "Assign Technician";
            this.cbTech.IntegralHeight = false;
            this.cbTech.ItemHeight = 43;
            this.cbTech.Location = new System.Drawing.Point(298, 294);
            this.cbTech.MaxDropDownItems = 6;
            this.cbTech.MouseState = MaterialSkin.MouseState.OUT;
            this.cbTech.Name = "cbTech";
            this.cbTech.Size = new System.Drawing.Size(287, 49);
            this.cbTech.StartIndex = 0;
            this.cbTech.TabIndex = 39;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(595, 269);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(624, 354);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // cbDepartment
            // 
            this.cbDepartment.AutoResize = false;
            this.cbDepartment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cbDepartment.Depth = 0;
            this.cbDepartment.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbDepartment.DropDownHeight = 174;
            this.cbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDepartment.DropDownWidth = 121;
            this.cbDepartment.Font = new System.Drawing.Font("Poppins", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cbDepartment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cbDepartment.FormattingEnabled = true;
            this.cbDepartment.Hint = "Department";
            this.cbDepartment.IntegralHeight = false;
            this.cbDepartment.ItemHeight = 43;
            this.cbDepartment.Items.AddRange(new object[] {
            "",
            "CLEAN BULLE/NO SILVO",
            "CONVEX",
            "HMC",
            "INJECTION",
            "LAB IPP/MONOMER PREP",
            "LAB QUALITY",
            "MOLDS CONTROL",
            "PACKING",
            "POLYVALENT",
            "PRODUCTION TRAINING",
            "SEMI-FINISH/SAPPHIRE",
            "TINTING",
            "UNCOAT/COAT",
            "ACCOUNTING/FINANCE",
            "CIPE",
            "EXECUTIVE",
            "GENERAL & PRODUCTION MAINTENANCE",
            "HUMAN RESOURCE",
            "LOGISTICS",
            "MATERIAL CONTROL",
            "MIS",
            "PROCESS ENGINEERING",
            "PRODUCTIONN PLANNING",
            "PRODUCTIONN MANAGEMENT",
            "SAFETY",
            "STORE",
            "SDE",
            "NEW FLOWS & PROJECTS",
            "CUSTOMER SERVICE",
            "METROLOGY",
            "PRODUCT DISTRIBUTION",
            "PRODUCT QUALITY DEPARTMENT",
            "QUALITY DEPARTMENT",
            "REPACKING"});
            this.cbDepartment.Location = new System.Drawing.Point(6, 130);
            this.cbDepartment.MaxDropDownItems = 4;
            this.cbDepartment.MouseState = MaterialSkin.MouseState.OUT;
            this.cbDepartment.Name = "cbDepartment";
            this.cbDepartment.Size = new System.Drawing.Size(286, 49);
            this.cbDepartment.StartIndex = 0;
            this.cbDepartment.TabIndex = 40;
            // 
            // txtRootCause
            // 
            this.txtRootCause.AnimateReadOnly = false;
            this.txtRootCause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtRootCause.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtRootCause.Depth = 0;
            this.txtRootCause.Font = new System.Drawing.Font("Poppins", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtRootCause.HideSelection = true;
            this.txtRootCause.Hint = "Root Cause";
            this.txtRootCause.LeadingIcon = null;
            this.txtRootCause.Location = new System.Drawing.Point(298, 349);
            this.txtRootCause.MaxLength = 32767;
            this.txtRootCause.MouseState = MaterialSkin.MouseState.OUT;
            this.txtRootCause.Name = "txtRootCause";
            this.txtRootCause.PasswordChar = '\0';
            this.txtRootCause.PrefixSuffixText = null;
            this.txtRootCause.ReadOnly = false;
            this.txtRootCause.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRootCause.SelectedText = "";
            this.txtRootCause.SelectionLength = 0;
            this.txtRootCause.SelectionStart = 0;
            this.txtRootCause.ShortcutsEnabled = true;
            this.txtRootCause.Size = new System.Drawing.Size(287, 48);
            this.txtRootCause.TabIndex = 42;
            this.txtRootCause.TabStop = false;
            this.txtRootCause.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtRootCause.TrailingIcon = null;
            this.txtRootCause.UseSystemPasswordChar = false;
            // 
            // dtDateRequired
            // 
            this.dtDateRequired.Font = new System.Drawing.Font("Arial", 16.75F);
            this.dtDateRequired.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDateRequired.Location = new System.Drawing.Point(5, 255);
            this.dtDateRequired.Name = "dtDateRequired";
            this.dtDateRequired.Size = new System.Drawing.Size(287, 33);
            this.dtDateRequired.TabIndex = 43;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.DimGray;
            this.label15.Location = new System.Drawing.Point(6, 236);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(89, 16);
            this.label15.TabIndex = 44;
            this.label15.Text = "Date Required";
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
            this.cbCategory.Location = new System.Drawing.Point(5, 185);
            this.cbCategory.MaxDropDownItems = 6;
            this.cbCategory.MouseState = MaterialSkin.MouseState.OUT;
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(287, 49);
            this.cbCategory.StartIndex = 0;
            this.cbCategory.TabIndex = 45;
            // 
            // TicketPreviewAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 686);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.panelTransfer);
            this.Controls.Add(this.txtRootCause);
            this.Controls.Add(this.cbDepartment);
            this.Controls.Add(this.lblDowntime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPreventive);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblLoc);
            this.Controls.Add(this.lblTag);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.txtRequestor);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.cbPrio);
            this.Controls.Add(this.cbIssue);
            this.Controls.Add(this.cbTech);
            this.Controls.Add(this.dtDateRequired);
            this.Controls.Add(this.cbCategory);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TicketPreviewAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ticket Preview Admin";
            this.Load += new System.EventHandler(this.TicketPreviewAdmin_Load);
            this.panelTransfer.ResumeLayout(false);
            this.panelTransfer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialComboBox cbPrio;
        private MaterialSkin.Controls.MaterialComboBox cbIssue;
        private MaterialSkin.Controls.MaterialComboBox cbStatus;
        private MaterialSkin.Controls.MaterialTextBox2 txtID;
        private MaterialSkin.Controls.MaterialTextBox2 txtName;
        private MaterialSkin.Controls.MaterialTextBox2 txtRequestor;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 txtDescription;
        private MaterialSkin.Controls.MaterialTextBox2 txtSubject;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblPath;
        private MaterialSkin.Controls.MaterialButton btnSave;
        private MaterialSkin.Controls.MaterialButton btnTransfer;
        private System.Windows.Forms.Label lblTag;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblLoc;
        private MaterialSkin.Controls.MaterialButton btnOpen;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 txtPreventive;
        private System.Windows.Forms.Label lblDowntime;
        private System.Windows.Forms.Label label3;
        private MaterialSkin.Controls.MaterialExpansionPanel panelTransfer;
        private MaterialSkin.Controls.MaterialComboBox cbTechnician;
        private MaterialSkin.Controls.MaterialButton materialButton5;
        private MaterialSkin.Controls.MaterialButton materialButton6;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private MaterialSkin.Controls.MaterialComboBox cbTech;
        private MaterialSkin.Controls.MaterialComboBox cbDepartment;
        private MaterialSkin.Controls.MaterialTextBox2 txtRootCause;
        private System.Windows.Forms.DateTimePicker dtDateRequired;
        private System.Windows.Forms.Label label15;
        private MaterialSkin.Controls.MaterialComboBox cbCategory;
    }
}