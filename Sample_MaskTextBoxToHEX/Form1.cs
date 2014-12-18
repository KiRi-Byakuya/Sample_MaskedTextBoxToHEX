using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample_MaskTextBoxToHEX {
    public partial class Form1 : Form {
        
        public Form1() {
            InitializeComponent();
            // タイトル
            this.Text = "Sample_MaskedTextBoxToHEX";
            // フォーム 最小・最大化禁止
            this.MinimizeBox = this.MaximizeBox = false;
            // サイズ変更不可
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            // MaskTextBox 割り込み登録
            maskedTextBox1.KeyDown += new KeyEventHandler(this.MaskTextBox_KeyDown);
        }

        private void Form1_Load(object sender, EventArgs e) {

            // 配置：中央
            maskedTextBox1.TextAlign = HorizontalAlignment.Center;

            // マスク設定
            //maskedTextBox1.Mask = ">CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC CC";
            maskedTextBox1.Mask = ">AA AA AA AA AA AA AA AA AA AA AA AA AA AA AA AA";
            maskedTextBox1.Text = "00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00";

        }

        /// <summary>
        /// 入力文字制御(HEX)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaskTextBox_KeyDown(object sender, KeyEventArgs e) {

            bool keyPressCk = true;

            if ( ( 'A' <= e.KeyValue && e.KeyValue <= 'F' ) // A～F
             || ( '0' <= e.KeyValue && e.KeyValue <= '9' ) // 0～9 (キーボード)
             || ( ( int ) Keys.NumPad0 <= e.KeyValue && e.KeyValue <= ( int ) Keys.NumPad9 ) // 1～9(テンキー) 
             || ( ( int ) Keys.Left == e.KeyValue || ( int ) Keys.Right == e.KeyValue ) ) // ←→
            {
                keyPressCk = false;
            }

            // [KeyDown]後の[KeyPress]イベント
            e.SuppressKeyPress = keyPressCk; // true = 無効 / false = 許可
        }
    }
}
