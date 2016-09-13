namespace VScodeMarkdownExtensionLineBreaksPatch {
    partial class MainForm {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.execButton = new System.Windows.Forms.Button();
            this.vscodePathTextBox = new System.Windows.Forms.TextBox();
            this.logText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // execButton
            // 
            this.execButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.execButton.Location = new System.Drawing.Point(762, 80);
            this.execButton.Name = "execButton";
            this.execButton.Size = new System.Drawing.Size(151, 32);
            this.execButton.TabIndex = 0;
            this.execButton.Text = "Run";
            this.execButton.UseVisualStyleBackColor = true;
            this.execButton.Click += new System.EventHandler(this.execButton_Click);
            // 
            // vscodePathTextBox
            // 
            this.vscodePathTextBox.Location = new System.Drawing.Point(51, 49);
            this.vscodePathTextBox.Name = "vscodePathTextBox";
            this.vscodePathTextBox.Size = new System.Drawing.Size(761, 25);
            this.vscodePathTextBox.TabIndex = 1;
            // 
            // logText
            // 
            this.logText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.logText.Location = new System.Drawing.Point(51, 118);
            this.logText.Multiline = true;
            this.logText.Name = "logText";
            this.logText.ReadOnly = true;
            this.logText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logText.Size = new System.Drawing.Size(862, 181);
            this.logText.TabIndex = 2;
            this.logText.WordWrap = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 321);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(593, 72);
            this.label1.TabIndex = 3;
            this.label1.Text = "after this patch success, you can specify markdown-it\'s `breaks` \r\noption in sett" +
    "ings like following:\r\n\r\n    \"markdown.markdown-it-breaks\": true";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Found Path:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 426);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logText);
            this.Controls.Add(this.vscodePathTextBox);
            this.Controls.Add(this.execButton);
            this.Name = "MainForm";
            this.Text = "vscode-markdown patch";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button execButton;
        private System.Windows.Forms.TextBox vscodePathTextBox;
        private System.Windows.Forms.TextBox logText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

