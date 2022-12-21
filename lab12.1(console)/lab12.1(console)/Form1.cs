namespace lab12._1_console_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class Matrix
        {
            //���� ������
            double[][] DoubleArray;
            int n;
            int m;

            public Matrix(int rows, int cols)       //����������� �������
            {
                n = rows;
                m = cols;
                DoubleArray = new double[n][];
            }
            public void EnterElements(TextBox textBox1)     //���������� �������
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))       //��������, ���� ������ ������
                {
                    MessageBox.Show("������� �������� �������.", "������",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var sNums = new string[n, m];
                var arr1 = textBox1.Text.Split('\n');       //���������� ����� ��������� � textbox1
                if (arr1.Length != n)
                {
                    MessageBox.Show("����� ������� �� ������������� ����������!", "������",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                for (int i = 0; i < n; i++)
                {
                    var arr2 = arr1[i].Split(' ');
                    if (arr2.Length != m)
                    {
                        MessageBox.Show("����� ������� �� ������������� ����������!", "������",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    for (int j = 0; j < m; j++)
                    {
                        sNums[i, j] = arr2[j];
                    }
                }

                try
                {
                    for (int i = 0; i < n; i++)
                    {
                        DoubleArray[i] = new double[m];
                        for (int j = 0; j < m; j++)
                        {

                            DoubleArray[i][j] = double.Parse(sNums[i, j]);
                        }
                    }
                    MessageBox.Show("������ ��������", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (FormatException)
                {
                    MessageBox.Show("������������ ���� ������. ���������� �����", "������",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            public void PrintMatrix(TextBox textBox2)        //����� ������� �� �����
            {
                for (int i = 0; i < DoubleArray.Length; i++)
                {
                    for (int j = 0; j < DoubleArray[i].Length; j++)
                    {
                        textBox2.Text += DoubleArray[i][j] + "\t";
                    }
                    textBox2.Text += Environment.NewLine;
                }

            }
            public void Sort()      //���������� ������� (������������� �������� ������ ������ ������� � ������� ��������)
            {
                for (var i = 0; i < DoubleArray.Length; ++i)
                {
                    Array.Sort(DoubleArray[i]);
                    Array.Reverse(DoubleArray[i]);
                }
            }
            public int ElementCount        //������� ���������� ��������� � �������
            {
                get { return n * m; }       //�������� ��� ������ ���������� ���������� ������
            }

            public double ScalarMultiply        //���������� �� ������
            {
                set     //�������� ��� ������ �������� �� ���������� ���� ������
                {
                    double roundTo = Math.Pow(10, 1);
                    for (int i = 0; i < DoubleArray.Length; i++)
                    {
                        for (int j = 0; j < DoubleArray[i].Length; j++)
                        {
                            DoubleArray[i][j] = Math.Truncate((DoubleArray[i][j] += value) * roundTo) / roundTo;        //����������
                                                                                                                        //value - ������� ��������, ���������� ��������, ������� ������������� ��������
                        }

                    }
                }
            }

            public double this[int n, int m]        //��������� ���������� (��������� ���������� � ������ �� �������)
                                                    //this - �������� �����, ������������ ������ ��������
            {
                get { return DoubleArray[n][m]; }
            }

            public static Matrix operator ++(Matrix myNewClass)     //������������� �������� ������������� �������� ���� ��������� �� 1
                                                                    //���� �������� (myNewClass) �� ������� �������� ++
            {
                double roundTo = Math.Pow(10, 2);
                for (int i = 0; i < myNewClass.DoubleArray.Length; i++)
                {
                    for (int j = 0; j < myNewClass.DoubleArray[i].Length; j++)
                    {
                        myNewClass.DoubleArray[i][j] = Math.Truncate((myNewClass.DoubleArray[i][j] += 1) * roundTo) / roundTo;
                    }
                }
                return myNewClass;
            }

            public static Matrix operator --(Matrix myNewClass)     //������������� �������� ����������� �������� ���� ��������� �� 1
                                                                    //���� �������� (myNewClass) �� ������� �������� --
            {
                double roundTo = Math.Pow(10, 2);
                for (int i = 0; i < myNewClass.DoubleArray.Length; i++)
                {
                    for (int j = 0; j < myNewClass.DoubleArray[i].Length; j++)
                    {
                        myNewClass.DoubleArray[i][j] = Math.Truncate((myNewClass.DoubleArray[i][j] -= 1) * roundTo) / roundTo;
                    }
                }
                return myNewClass;
            }

            //��������� � ���������� ������ ���� �������� true, ���� ������ ������ ������� ������������ �� �����������,
            //����� false.
            public static bool operator true(Matrix myNewClass)     // ���������� �������� true � false
            {
                int flag = 0;
                for (int r = 0; r < myNewClass.DoubleArray.Length; r++)
                {
                    for (int i = 0; i < myNewClass.DoubleArray[r].Length; i++)
                    {
                        for (int j = 0; j < myNewClass.DoubleArray[r].Length - 1; j++)
                        {
                            if (myNewClass.DoubleArray[r][j] < myNewClass.DoubleArray[r][j + 1])
                            {
                                flag++;
                            }
                        }
                    }
                }
                if (flag == 0)
                    return true;        //true - ���� ������ ���������� �� �����������
                else return false;
            }

            //��������� � ���������� ������ ���� �������� true, ���� ������ ������ ������� ������������ �� �����������,
            //����� false.
            public static bool operator false(Matrix myNewClass)        // ���������� �������� true � false
            {
                int flag = 0;
                for (int r = 0; r < myNewClass.DoubleArray.GetLength(0); r++)
                {
                    for (int i = 0; i < myNewClass.DoubleArray.GetLength(1); i++)
                    {
                        for (int j = 0; j < myNewClass.DoubleArray.GetLength(1) - 1; j++)
                        {
                            if (myNewClass.DoubleArray[r][j] < myNewClass.DoubleArray[r][j + 1])
                            {
                                flag++;
                            }
                        }
                    }
                }
                if (flag != 0)
                    return false;
                else return true;

            }

            public static Matrix operator *(Matrix A, Matrix B)     //����������, ���������� ��� ������� ��������������� ������������
            {
                Matrix C = new Matrix(A.n, A.m);

                double roundTo = Math.Pow(10, 2);
                for (int i = 0; i < C.DoubleArray.Length; i++)
                {
                    C.DoubleArray[i] = new double[C.m];
                    for (int j = 0; j < C.DoubleArray[i].Length; j++)
                    {
                        for (int k = 0; k < C.DoubleArray[i].Length; k++)
                        {
                            C.DoubleArray[i][j] = Math.Truncate(((C.DoubleArray[i][j] += A[i, k] * B[k, j]) * roundTo) / roundTo);
                            //�������� ������ ����� ������� �� ������� ������
                        }

                    }
                }
                
                return C;
            }

            public static implicit operator Matrix(double[][] mx)       //�������������� � ��������� ������ (������� ��������������)
            {
                return new Matrix(mx);
            }

            public static explicit operator double[][](Matrix mx)       //�������������� � ����������� ������ (����� ��������������)
            {
                return mx.DoubleArray;
            }

            public Matrix(double[][] mx)        //���������� ���������� ������� ������ �� ��� ������������ ������������
            {
                DoubleArray = new double[mx.Length][];
                for (int i = 0; i < mx.Length; ++i)
                {
                    DoubleArray[i] = new double[mx[i].Length];
                    for (int j = 0; j < mx[i].Length; ++j)
                    {
                        DoubleArray[i][j] = mx[i][j];
                    }
                }
            }


        }


        private void button1_Click(object sender, EventArgs e)
        {
            int n = 0;
            int m = 0;

            try
            {

                if (numericUpDown1.Value <= 0)
                {
                    MessageBox.Show("������! ���������� ����� �� ����� ����� ������������� ��� ������� ��������!");
                    Environment.Exit(0);
                }
            }
            catch
            {
                MessageBox.Show("������! �������� ������ ����� ������!");
                Environment.Exit(0);
            }
            n = (int)numericUpDown1.Value;

            try
            {

                if (numericUpDown2.Value <= 0)
                {
                    MessageBox.Show("������! ���������� �������� �� ����� ����� ������������� ��� ������� ��������!");
                    Environment.Exit(0);
                }
            }
            catch
            {
                MessageBox.Show("������! �������� ������ ����� ������!");
                Environment.Exit(0);
            }
            m = (int)numericUpDown2.Value;

            Matrix newMatrix = new Matrix(n, m);        //�������� ����������
                                                        //����� ������� ������

            newMatrix.EnterElements(textBox1);
            newMatrix.PrintMatrix(textBox2);
            newMatrix.Sort();
            newMatrix.PrintMatrix(textBox3);

            textBox4.Text += $"���������� ��������� � �������: {newMatrix.ElementCount}";
            double scalar = 0;
            try
            {

                if (numericUpDown3.Value <= 0)
                {
                    MessageBox.Show("������! ������ �� ����� ����� ������������� ��� ������� ��������!");
                    Environment.Exit(0);
                }
            }
            catch
            {
                MessageBox.Show("������! �������� ������ ����� ������!");
            }
            scalar = (double)numericUpDown3.Value;
            newMatrix.ScalarMultiply = scalar;
            newMatrix.PrintMatrix(textBox5);

            textBox5.Text += "��� �������� ��������� �� ������";

            //����������
            int row = 0;
            int col = 0;

            try
            {
                if (numericUpDown6.Value < 0)
                {
                    MessageBox.Show("����� ������ �� ����������!", "������",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
            }
            catch
            {
                MessageBox.Show("������������ ������ ����� ������!", "������",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            row = (int)numericUpDown6.Value;

            try
            {
                if (numericUpDown7.Value < 0)
                {
                    MessageBox.Show("������ ������� �� ����������!", "������",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
            }
            catch
            {
                MessageBox.Show("������������ ������ ����� ������!", "������",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            col = (int)numericUpDown7.Value;

            try
            {
                textBox8.Text += $"������� ��� �������� [{row},{col}]: " + newMatrix[row, col];
            }
            catch (Exception)
            {
                MessageBox.Show("������! ������ �������� �� ����������!", "������",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //���������� �� 1
            newMatrix++;
            textBox9.Text += "��� �������� ��������� �� 1" + Environment.NewLine;
            textBox9.Text += Environment.NewLine;
            newMatrix.PrintMatrix(textBox9);
            textBox9.Text += Environment.NewLine;

            //���������� �� 1
            newMatrix--;
            textBox9.Text += "��� �������� ��������� �� 1" + Environment.NewLine;
            textBox9.Text += Environment.NewLine;
            newMatrix.PrintMatrix(textBox9);

            //true false
            if (newMatrix)
            {
                textBox10.Text += "������ ������� ����������� �� ����������.";
            }
            else
            {
                textBox10.Text += "������ ������� �� ����������� �� �����������.";
            }

            //���������
            int a = 0;
            int b = 0;

            try
            {
                if (numericUpDown4.Value <= 0)
                {
                    MessageBox.Show("���������� ����� �� ����� ����� ������������� ��� ������� ��������!", "������",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
            }
            catch
            {
                MessageBox.Show("�������� ������ ����� ������!", "������",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            a = (int)numericUpDown4.Value;

            
            try
            {
                if (numericUpDown5.Value <= 0)
                {
                    MessageBox.Show("���������� �������� �� ����� ����� ������������� ��� ������� ��������!", "������",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                }
            }
            catch
            {
                MessageBox.Show("�������� ������ ����� ������!", "������",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            b = (int)numericUpDown5.Value;

            Matrix B = new Matrix(a, b);        //�������� ����� �������

            if (n == a && m == b)
            {
                B.EnterElements(textBox6);
                newMatrix *= B;
                textBox7.Text += "������: " + Environment.NewLine;
                newMatrix.PrintMatrix(textBox7);
            }
            else
            {
                MessageBox.Show("������� ������ ������������", "������", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            Matrix array = newMatrix;
            textBox11.Text += "������ ��������������� � ���������" + Environment.NewLine;
            array.PrintMatrix(textBox11);

            Matrix array1 = (double[][])newMatrix;
            textBox12.Text += "������ ��������������� � �����������" + Environment.NewLine;
            array1.PrintMatrix(textBox12);



        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Clear();
            textBox2.Text = "";
            textBox2.Clear();
            textBox3.Text = "";
            textBox3.Clear();
            textBox4.Text = "";
            textBox4.Clear();
            textBox5.Text = "";
            textBox5.Clear();

        }
    }
}