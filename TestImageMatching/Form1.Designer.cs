namespace TestImageMatching
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.pbSrc = new System.Windows.Forms.PictureBox();
            this.pbTarget = new System.Windows.Forms.PictureBox();
            this.btnTMOne = new System.Windows.Forms.Button();
            this.btnTMSome = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbSrc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTarget)).BeginInit();
            this.SuspendLayout();
            // 
            // pbSrc
            // 
            this.pbSrc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSrc.Location = new System.Drawing.Point(4, 4);
            this.pbSrc.Name = "pbSrc";
            this.pbSrc.Size = new System.Drawing.Size(640, 360);
            this.pbSrc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSrc.TabIndex = 0;
            this.pbSrc.TabStop = false;
            this.pbSrc.Click += new System.EventHandler(this.pbSrc_Click);
            // 
            // pbTarget
            // 
            this.pbTarget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbTarget.Location = new System.Drawing.Point(648, 4);
            this.pbTarget.Margin = new System.Windows.Forms.Padding(2);
            this.pbTarget.Name = "pbTarget";
            this.pbTarget.Size = new System.Drawing.Size(128, 128);
            this.pbTarget.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTarget.TabIndex = 1;
            this.pbTarget.TabStop = false;
            this.pbTarget.Click += new System.EventHandler(this.pbTarget_Click);
            // 
            // btnTMOne
            // 
            this.btnTMOne.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnTMOne.Location = new System.Drawing.Point(648, 172);
            this.btnTMOne.Margin = new System.Windows.Forms.Padding(2);
            this.btnTMOne.Name = "btnTMOne";
            this.btnTMOne.Size = new System.Drawing.Size(128, 32);
            this.btnTMOne.TabIndex = 2;
            this.btnTMOne.Text = "1つ検索";
            this.btnTMOne.UseVisualStyleBackColor = true;
            this.btnTMOne.Click += new System.EventHandler(this.btnTMOne_Click);
            // 
            // btnTMSome
            // 
            this.btnTMSome.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnTMSome.Location = new System.Drawing.Point(648, 208);
            this.btnTMSome.Margin = new System.Windows.Forms.Padding(2);
            this.btnTMSome.Name = "btnTMSome";
            this.btnTMSome.Size = new System.Drawing.Size(128, 32);
            this.btnTMSome.TabIndex = 2;
            this.btnTMSome.Text = "複数検索";
            this.btnTMSome.UseVisualStyleBackColor = true;
            this.btnTMSome.Click += new System.EventHandler(this.btnTMSome_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button4.Location = new System.Drawing.Point(648, 244);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(128, 32);
            this.button4.TabIndex = 2;
            this.button4.Text = "button1";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button5.Location = new System.Drawing.Point(648, 280);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(128, 32);
            this.button5.TabIndex = 2;
            this.button5.Text = "button1";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnTest
            // 
            this.btnTest.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnTest.Location = new System.Drawing.Point(648, 316);
            this.btnTest.Margin = new System.Windows.Forms.Padding(2);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(128, 32);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "テスト";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox1.Location = new System.Drawing.Point(648, 136);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(128, 32);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "0.8";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 368);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnTMSome);
            this.Controls.Add(this.btnTMOne);
            this.Controls.Add(this.pbTarget);
            this.Controls.Add(this.pbSrc);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbSrc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTarget)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSrc;
        private System.Windows.Forms.PictureBox pbTarget;
        private System.Windows.Forms.Button btnTMOne;
        private System.Windows.Forms.Button btnTMSome;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.TextBox textBox1;
    }
}

