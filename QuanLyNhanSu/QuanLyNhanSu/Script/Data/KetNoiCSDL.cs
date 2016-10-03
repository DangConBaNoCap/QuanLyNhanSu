using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace QuanLyNhanSu.Script.Data
{
    class KetNoiCSDL
    {
        public static SqlConnection connect;
        public static string sql = @"Data Source=KAGAMI\QUOCDUNG;Initial Catalog=QuanLyNhanSu;Integrated Security=True";

        public static bool MoKetNoi()
        {
            if (KetNoiCSDL.connect == null)
            {
                try
                {
                    KetNoiCSDL.connect = new SqlConnection(sql);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Không Thể Kết Nối Đến Cơ Sở Dữ Liệu\n", "Cảnh Báo");
                    return false;
                }

            }
            if (KetNoiCSDL.connect.State != ConnectionState.Open)
            {
                KetNoiCSDL.connect.Open();
            }
            return true;
        }

        public static void DongKetNoi()
        {
            try
            {
                if (KetNoiCSDL.connect != null)
                {
                    if (KetNoiCSDL.connect.State == ConnectionState.Open)
                        KetNoiCSDL.connect.Close();
                }
            }
            catch
            {
                MessageBox.Show("Không Thể Đóng Kết Nối", "Cảnh Báo");
            }
        }


        public void ThucThiCauLenhSQL(string strSQL)
        {
            try
            {
                MoKetNoi();
                SqlCommand cmd = new SqlCommand(strSQL, connect);
                cmd.ExecuteNonQuery();
                DongKetNoi();
            }
            catch (Exception e)
            {
                MessageBox.Show("Không Thể Thực Thi SQL, error: " + e.Message, "Cảnh Báo");
            }
        }

        public DataTable GetDataTable(string strSQl)
        {
            try
            {
                MoKetNoi();
                DataTable datatb = new DataTable();
                SqlDataAdapter sqlada = new SqlDataAdapter(strSQl, connect);
                sqlada.Fill(datatb);
                DongKetNoi();
                return datatb;
            }
            catch (Exception e)
            {
                MessageBox.Show("Không Thể Lấy Dữ Liệu, error: " + e.Message, "Cảnh Báo");
                return null;
            }
        }

        public string GetValue(string strSQL)
        {

            try
            {
                string kq = null;

                MoKetNoi();
                SqlCommand cmd = new SqlCommand(strSQL, connect);
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    kq = read[0].ToString();
                }
                DongKetNoi();

                return kq;
            }

            catch
            {
                return null;
            }

        }

        public SqlDataAdapter GetCmd(string strSQL)
        {
            //MoKetNoi();

            SqlDataAdapter sql = new SqlDataAdapter(strSQL, connect);
            SqlCommandBuilder cmd = new SqlCommandBuilder(sql);

            sql.InsertCommand = cmd.GetInsertCommand();
            sql.UpdateCommand = cmd.GetUpdateCommand();
            sql.DeleteCommand = cmd.GetDeleteCommand();

            return sql;
        }

        public string SinhMa(string table, string tiento)
        {
            DataTable tempTable = new DataTable();
            tempTable = GetDataTable("select * from " + table);

            string kq = "";

            if (tiento == "" && tempTable.Rows.Count > 0)
            {
                kq = (int.Parse(tempTable.Rows[tempTable.Rows.Count - 1][0].ToString()) + 1).ToString();
                return kq;
            }

            if (tempTable.Rows.Count > 0)
            {
                string tempStr = tempTable.Rows[tempTable.Rows.Count - 1][0].ToString();

                int i = Convert.ToInt32(tempStr.Substring(tiento.Length));
                i++;
                kq = tiento + i.ToString("00000000");
            }
            else kq = tiento + "00000001";

            return kq;
        }
        public string SinhMa(string table, string tiento, string matruoc)
        {
            string kq = "";
            if (matruoc == string.Empty) return SinhMa(table, tiento);
            else
            {

                int i = Convert.ToInt32(matruoc.Substring(tiento.Length));
                i++;
                kq = tiento + i.ToString("00000000");
            }
            return kq;
        }
        //public void NhatKi(string name, string task)
        //{
        //    string infoUser = GetValue("select name from tblLuuMK where num=1");
        //    ThucThiCauLenhSQL("insert into tblNhatKi (NKTen,NKTacVu,NKNgay,NKUser) values (N'" + name + "',N'" + task + "','" +
        //                string.Format("{0:yyyy/MM/dd HH:mm:ss}", DateTime.Now) + "',N'" + infoUser + "')");
        //}
    }
}
