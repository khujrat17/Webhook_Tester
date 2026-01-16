using System.Drawing;
using System.Windows.Forms;

namespace WebHookTesting
{
    partial class Form1
    {
        private Panel pnlAccent;
        private Panel pnlHeader;
        private FlowLayoutPanel pnlTopRow;
        private Label lblTitle;
        private ComboBox cmbMethod;
        private TextBox txtUrl;
        private Button btnSend;
        private Button btnTheme;

        private SplitContainer splitContainer;
        private GroupBox grpRequest;
        private RichTextBox txtRequest;
        private GroupBox grpResponse;
        private RichTextBox txtResponse;

        private ProgressBar progressBar;
        private Label lblStatus;
        private Label lblStatusBadge;

        private void InitializeComponent()
        {
            pnlAccent = new Panel();
            pnlHeader = new Panel();
            pnlTopRow = new FlowLayoutPanel();
            lblTitle = new Label();
            cmbMethod = new ComboBox();
            txtUrl = new TextBox();
            btnSend = new Button();
            btnTheme = new Button();
            splitContainer = new SplitContainer();
            grpRequest = new GroupBox();
            txtRequest = new RichTextBox();
            grpResponse = new GroupBox();
            txtResponse = new RichTextBox();
            progressBar = new ProgressBar();
            lblStatus = new Label();
            lblStatusBadge = new Label();
            pnlHeader.SuspendLayout();
            pnlTopRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            grpRequest.SuspendLayout();
            grpResponse.SuspendLayout();
            SuspendLayout();
            // 
            // pnlAccent
            // 
            pnlAccent.BackColor = Color.FromArgb(0, 120, 215);
            pnlAccent.Dock = DockStyle.Top;
            pnlAccent.Location = new Point(0, 0);
            pnlAccent.Name = "pnlAccent";
            pnlAccent.Size = new Size(950, 4);
            pnlAccent.TabIndex = 5;
            // 
            // pnlHeader
            // 
            pnlHeader.Controls.Add(pnlTopRow);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(12);
            pnlHeader.Size = new Size(950, 70);
            pnlHeader.TabIndex = 4;
            // 
            // pnlTopRow
            // 
            pnlTopRow.Controls.Add(lblTitle);
            pnlTopRow.Controls.Add(cmbMethod);
            pnlTopRow.Controls.Add(txtUrl);
            pnlTopRow.Controls.Add(btnSend);
            pnlTopRow.Controls.Add(btnTheme);
            pnlTopRow.Dock = DockStyle.Fill;
            pnlTopRow.Location = new Point(12, 12);
            pnlTopRow.Name = "pnlTopRow";
            pnlTopRow.Padding = new Padding(0, 8, 0, 0);
            pnlTopRow.Size = new Size(926, 46);
            pnlTopRow.TabIndex = 0;
            pnlTopRow.WrapContents = false;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI Semibold", 12F);
            lblTitle.Location = new Point(3, 8);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(150, 23);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Webhook Tester";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbMethod
            // 
            cmbMethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMethod.Font = new Font("Segoe UI", 10F);
            cmbMethod.Items.AddRange(new object[] { "POST" });
            cmbMethod.Location = new Point(159, 11);
            cmbMethod.Name = "cmbMethod";
            cmbMethod.Size = new Size(80, 25);
            cmbMethod.TabIndex = 1;
            // 
            // txtUrl
            // 
            txtUrl.Font = new Font("Segoe UI", 10F);
            txtUrl.Location = new Point(245, 11);
            txtUrl.Name = "txtUrl";
            txtUrl.PlaceholderText = "Enter webhook URL...";
            txtUrl.Size = new Size(420, 25);
            txtUrl.TabIndex = 2;
            // 
            // btnSend
            // 
            btnSend.FlatAppearance.BorderSize = 0;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.Font = new Font("Segoe UI Semibold", 9F);
            btnSend.Location = new Point(671, 11);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(90, 32);
            btnSend.TabIndex = 3;
            btnSend.Text = "SEND";
            btnSend.Click += btnSend_Click;
            // 
            // btnTheme
            // 
            btnTheme.FlatAppearance.BorderSize = 0;
            btnTheme.FlatStyle = FlatStyle.Flat;
            btnTheme.Location = new Point(767, 11);
            btnTheme.Name = "btnTheme";
            btnTheme.Size = new Size(40, 32);
            btnTheme.TabIndex = 4;
            btnTheme.Text = "🌙";
            btnTheme.Click += btnTheme_Click;
            // 
            // splitContainer
            // 
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(0, 74);
            splitContainer.Name = "splitContainer";
            splitContainer.Orientation = Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(grpRequest);
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(grpResponse);
            splitContainer.Size = new Size(950, 525);
            splitContainer.SplitterDistance = 372;
            splitContainer.TabIndex = 0;
            // 
            // grpRequest
            // 
            grpRequest.Controls.Add(txtRequest);
            grpRequest.Dock = DockStyle.Fill;
            grpRequest.Font = new Font("Segoe UI Semibold", 9F);
            grpRequest.Location = new Point(0, 0);
            grpRequest.Name = "grpRequest";
            grpRequest.Size = new Size(950, 372);
            grpRequest.TabIndex = 0;
            grpRequest.TabStop = false;
            grpRequest.Text = "Request JSON";
            // 
            // txtRequest
            // 
            txtRequest.Dock = DockStyle.Fill;
            txtRequest.Font = new Font("Consolas", 11F);
            txtRequest.Location = new Point(3, 19);
            txtRequest.Name = "txtRequest";
            txtRequest.Size = new Size(944, 350);
            txtRequest.TabIndex = 0;
            txtRequest.Text = "{\n  \"message\": \"Hello Webhook\"\n}";
            // 
            // grpResponse
            // 
            grpResponse.Controls.Add(txtResponse);
            grpResponse.Dock = DockStyle.Fill;
            grpResponse.Font = new Font("Segoe UI Semibold", 9F);
            grpResponse.Location = new Point(0, 0);
            grpResponse.Name = "grpResponse";
            grpResponse.Size = new Size(950, 149);
            grpResponse.TabIndex = 0;
            grpResponse.TabStop = false;
            grpResponse.Text = "Response";
            // 
            // txtResponse
            // 
            txtResponse.Dock = DockStyle.Fill;
            txtResponse.Font = new Font("Consolas", 11F);
            txtResponse.Location = new Point(3, 19);
            txtResponse.Name = "txtResponse";
            txtResponse.ReadOnly = true;
            txtResponse.Size = new Size(944, 127);
            txtResponse.TabIndex = 0;
            txtResponse.Text = "";
            // 
            // progressBar
            // 
            progressBar.Dock = DockStyle.Bottom;
            progressBar.Location = new Point(0, 644);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(950, 6);
            progressBar.TabIndex = 3;
            // 
            // lblStatus
            // 
            lblStatus.Dock = DockStyle.Bottom;
            lblStatus.Location = new Point(0, 621);
            lblStatus.Name = "lblStatus";
            lblStatus.Padding = new Padding(6);
            lblStatus.Size = new Size(950, 23);
            lblStatus.TabIndex = 2;
            // 
            // lblStatusBadge
            // 
            lblStatusBadge.Dock = DockStyle.Bottom;
            lblStatusBadge.Location = new Point(0, 599);
            lblStatusBadge.Name = "lblStatusBadge";
            lblStatusBadge.Size = new Size(950, 22);
            lblStatusBadge.TabIndex = 1;
            lblStatusBadge.TextAlign = ContentAlignment.MiddleCenter;
            lblStatusBadge.Visible = false;
            // 
            // Form1
            // 
            ClientSize = new Size(950, 650);
            Controls.Add(splitContainer);
            Controls.Add(lblStatusBadge);
            Controls.Add(lblStatus);
            Controls.Add(progressBar);
            Controls.Add(pnlHeader);
            Controls.Add(pnlAccent);
            Name = "Form1";
            Text = "Webhook Tester";
            Load += Form1_Load;
            pnlHeader.ResumeLayout(false);
            pnlTopRow.ResumeLayout(false);
            pnlTopRow.PerformLayout();
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            grpRequest.ResumeLayout(false);
            grpResponse.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
