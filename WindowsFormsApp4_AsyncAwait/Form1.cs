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

namespace WindowsFormsApp4_AsyncAwait
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "파일 열기";
            openFileDialog1.Filter = "텍스트 파일 (*.txt)|*.txt|모든 파일 (*.*)|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;

                try
                {
                    textBox1.Text = "파일 읽는 중...";
                    await Task.Delay(2000); //2초 딜레이

                    string tmp = await ReadFileAsync(filePath);  // 비동기 호출

                    textBox1.Text = tmp;

                }
                catch (IOException ex)
                {
                    MessageBox.Show($"파일 읽기 오류: {ex.Message}");
                }
            }
        }
        private async Task<string> ReadFileAsync(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                return await reader.ReadToEndAsync(); // 비동기로 전체 읽기
            }
        }

    }
}
