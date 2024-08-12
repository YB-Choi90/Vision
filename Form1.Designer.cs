namespace BarcodeReader
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxFolder = new System.Windows.Forms.TextBox();
            this.buttonSetFolder = new System.Windows.Forms.Button();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.labelProcess = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxThreshold = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxAddThreshold = new System.Windows.Forms.TextBox();
            this.checkBoxInversion = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "이미지 폴더 :";
            // 
            // textBoxFolder
            // 
            this.textBoxFolder.Location = new System.Drawing.Point(100, 12);
            this.textBoxFolder.Name = "textBoxFolder";
            this.textBoxFolder.Size = new System.Drawing.Size(336, 21);
            this.textBoxFolder.TabIndex = 1;
            this.textBoxFolder.Text = "C:\\";
            // 
            // buttonSetFolder
            // 
            this.buttonSetFolder.Location = new System.Drawing.Point(442, 12);
            this.buttonSetFolder.Name = "buttonSetFolder";
            this.buttonSetFolder.Size = new System.Drawing.Size(63, 23);
            this.buttonSetFolder.TabIndex = 2;
            this.buttonSetFolder.Text = "...";
            this.buttonSetFolder.UseVisualStyleBackColor = true;
            this.buttonSetFolder.Click += new System.EventHandler(this.buttonSetPath_Click);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(12, 118);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.Size = new System.Drawing.Size(523, 398);
            this.textBoxLog.TabIndex = 3;
            // 
            // labelProcess
            // 
            this.labelProcess.AutoSize = true;
            this.labelProcess.Location = new System.Drawing.Point(404, 64);
            this.labelProcess.Name = "labelProcess";
            this.labelProcess.Size = new System.Drawing.Size(11, 12);
            this.labelProcess.TabIndex = 4;
            this.labelProcess.Text = "-";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(322, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 33);
            this.button1.TabIndex = 10;
            this.button1.Text = "Read";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxThreshold
            // 
            this.textBoxThreshold.Location = new System.Drawing.Point(121, 52);
            this.textBoxThreshold.Name = "textBoxThreshold";
            this.textBoxThreshold.Size = new System.Drawing.Size(75, 21);
            this.textBoxThreshold.TabIndex = 11;
            this.textBoxThreshold.Text = "50";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "Start threshold :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "Add threshold :";
            // 
            // textBoxAddThreshold
            // 
            this.textBoxAddThreshold.Location = new System.Drawing.Point(121, 79);
            this.textBoxAddThreshold.Name = "textBoxAddThreshold";
            this.textBoxAddThreshold.Size = new System.Drawing.Size(75, 21);
            this.textBoxAddThreshold.TabIndex = 13;
            this.textBoxAddThreshold.Text = "10";
            // 
            // checkBoxInversion
            // 
            this.checkBoxInversion.AutoSize = true;
            this.checkBoxInversion.Location = new System.Drawing.Point(214, 55);
            this.checkBoxInversion.Name = "checkBoxInversion";
            this.checkBoxInversion.Size = new System.Drawing.Size(75, 16);
            this.checkBoxInversion.TabIndex = 15;
            this.checkBoxInversion.Text = "Inversion";
            this.checkBoxInversion.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 528);
            this.Controls.Add(this.checkBoxInversion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxAddThreshold);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxThreshold);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelProcess);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.buttonSetFolder);
            this.Controls.Add(this.textBoxFolder);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Barcode";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxFolder;
        private System.Windows.Forms.Button buttonSetFolder;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Label labelProcess;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxThreshold;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxAddThreshold;
        private System.Windows.Forms.CheckBox checkBoxInversion;
    }
}

