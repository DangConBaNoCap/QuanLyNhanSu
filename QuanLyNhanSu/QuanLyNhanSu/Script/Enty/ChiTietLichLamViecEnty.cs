using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Script.Enty
{
    class ChiTietLichLamViecEnty
    {
        private string _ID;

        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _NgayTrongTuan;

        public string NgayTrongTuan
        {
            get { return _NgayTrongTuan; }
            set { _NgayTrongTuan = value; }
        }
        private string _MaLLV;

        public string MaLLV
        {
            get { return _MaLLV; }
            set { _MaLLV = value; }
        }
        private string _MaCLV;

        public string MaCLV
        {
            get { return _MaCLV; }
            set { _MaCLV = value; }
        }
    }
}
