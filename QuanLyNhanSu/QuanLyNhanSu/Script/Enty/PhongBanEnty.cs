using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Script.Enty
{
    class PhongBanEnty
    {
        private string _MaPB;

        public string MaPB
        {
            get { return _MaPB; }
            set { _MaPB = value; }
        }
        private string _TenPB;

        public string TenPB
        {
            get { return _TenPB; }
            set { _TenPB = value; }
        }
        private string _MoTa;

        public string MoTa
        {
            get { return _MoTa; }
            set { _MoTa = value; }
        }
    }
}
