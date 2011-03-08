namespace NotesApp.Views
{
  partial class RegistrationView
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
      if (disposing && (components != null)) {
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
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.CancelLink = new System.Windows.Forms.LinkLabel();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.UsernameBox = new System.Windows.Forms.TextBox();
      this.RegisterButton = new System.Windows.Forms.Button();
      this.PasswordBox = new System.Windows.Forms.TextBox();
      this.PasswordConfirmBox = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.tableLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.AutoSize = true;
      this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.tableLayoutPanel1.ColumnCount = 3;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
      this.tableLayoutPanel1.Controls.Add(this.CancelLink, 0, 3);
      this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
      this.tableLayoutPanel1.Controls.Add(this.UsernameBox, 1, 0);
      this.tableLayoutPanel1.Controls.Add(this.RegisterButton, 2, 3);
      this.tableLayoutPanel1.Controls.Add(this.PasswordBox, 1, 1);
      this.tableLayoutPanel1.Controls.Add(this.PasswordConfirmBox, 1, 2);
      this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
      this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 4;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
      this.tableLayoutPanel1.Size = new System.Drawing.Size(263, 107);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // CancelLink
      // 
      this.CancelLink.AutoSize = true;
      this.tableLayoutPanel1.SetColumnSpan(this.CancelLink, 2);
      this.CancelLink.Dock = System.Windows.Forms.DockStyle.Fill;
      this.CancelLink.Location = new System.Drawing.Point(3, 78);
      this.CancelLink.Name = "CancelLink";
      this.CancelLink.Size = new System.Drawing.Size(176, 29);
      this.CancelLink.TabIndex = 4;
      this.CancelLink.TabStop = true;
      this.CancelLink.Text = "Cancel";
      this.CancelLink.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label1.Location = new System.Drawing.Point(3, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(91, 26);
      this.label1.TabIndex = 8;
      this.label1.Text = "Username:";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label2.Location = new System.Drawing.Point(3, 26);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(91, 26);
      this.label2.TabIndex = 6;
      this.label2.Text = "Password:";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // UsernameBox
      // 
      this.tableLayoutPanel1.SetColumnSpan(this.UsernameBox, 2);
      this.UsernameBox.Location = new System.Drawing.Point(100, 3);
      this.UsernameBox.Name = "UsernameBox";
      this.UsernameBox.Size = new System.Drawing.Size(160, 20);
      this.UsernameBox.TabIndex = 0;
      // 
      // RegisterButton
      // 
      this.RegisterButton.Location = new System.Drawing.Point(185, 81);
      this.RegisterButton.Name = "RegisterButton";
      this.RegisterButton.Size = new System.Drawing.Size(75, 23);
      this.RegisterButton.TabIndex = 3;
      this.RegisterButton.Text = "Register";
      this.RegisterButton.UseVisualStyleBackColor = true;
      // 
      // PasswordBox
      // 
      this.tableLayoutPanel1.SetColumnSpan(this.PasswordBox, 2);
      this.PasswordBox.Location = new System.Drawing.Point(100, 29);
      this.PasswordBox.Name = "PasswordBox";
      this.PasswordBox.PasswordChar = '*';
      this.PasswordBox.Size = new System.Drawing.Size(160, 20);
      this.PasswordBox.TabIndex = 1;
      // 
      // PasswordConfirmBox
      // 
      this.tableLayoutPanel1.SetColumnSpan(this.PasswordConfirmBox, 2);
      this.PasswordConfirmBox.Location = new System.Drawing.Point(100, 55);
      this.PasswordConfirmBox.Name = "PasswordConfirmBox";
      this.PasswordConfirmBox.PasswordChar = '*';
      this.PasswordConfirmBox.Size = new System.Drawing.Size(160, 20);
      this.PasswordConfirmBox.TabIndex = 2;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.label4.Location = new System.Drawing.Point(3, 52);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(91, 26);
      this.label4.TabIndex = 10;
      this.label4.Text = "Password (again):";
      this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // RegistrationView
      // 
      this.AcceptButton = this.RegisterButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(263, 107);
      this.Controls.Add(this.tableLayoutPanel1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "RegistrationView";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Registration";
      this.tableLayoutPanel1.ResumeLayout(false);
      this.tableLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Label label2;
    public System.Windows.Forms.TextBox UsernameBox;
    public System.Windows.Forms.Button RegisterButton;
    public System.Windows.Forms.TextBox PasswordBox;
    public System.Windows.Forms.TextBox PasswordConfirmBox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label4;
    public System.Windows.Forms.LinkLabel CancelLink;
  }
}