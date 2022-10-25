using System.CodeDom;

namespace Exec_Fee
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			label5.Text = String.Empty;
			label6.Text = String.Empty;
			FormBorderStyle = FormBorderStyle.Fixed3D;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			int number;
			try
			{
				number = SetNumber();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return;
			}
			FeeCheck(GetGender(), number);

		}
		private int SetNumber()
		{
			TextBox txt = textBox1;
			string input = txt.Text;
			return GetInt(txt, input);
		}
		private int GetInt(TextBox txt, string input)
		{
			string value = txt.Text;
			bool Isint = int.TryParse(value, out int number);
			return Isint ? number : throw new Exception($"{input}必須要填值");
		}
		private string GetGender()
		{
			if (radioButton1.Checked) return "Male";
			else if (radioButton2.Checked) return "Female";
			else throw new Exception("沒有選擇性別");
		}
		private string FeeCheck(string gender, int age)
		{			
			if (gender == "Male")
			{
				if (age <= 3)
				{
					Result("Male", age);
					return label5.Text = "0";
				}
				else if (age > 3 && age < 70)
				{
					Result("Male", age);
					return label5.Text = "15";
				}
				else
				{
					Result("Male", age);
					return label5.Text = "2";
				}
			}
			else
			{
				if (age <= 3)
				{
					Result("Female", age);
					return label5.Text = "0";
				}
				else if (age > 3 && age < 60)
				{
					Result("Female", age);
					return label5.Text = "15";
				}
				else
				{
					Result("Female", age);
					return label5.Text = "3";
				}
			}
		}
		private string Result(string gender, int age)
		{
			if (gender == "Male")
			{
				if (age <= 3)
					return label6.Text = "男性：未達收費年齡";
				else if (age > 3 && age < 70)
					return label6.Text = "男性：全票收費";
				else
					return label6.Text = "男性：符合敬老票年齡";
			}
			else
			{
				if (age <= 3)
					return label6.Text = "女性：未達收費年齡";
				else if (age > 3 && age < 60)
					return label6.Text = "女性：全票收費";
				else
					return label6.Text = "女性：符合敬老票年齡";
			}
		}
	}
}