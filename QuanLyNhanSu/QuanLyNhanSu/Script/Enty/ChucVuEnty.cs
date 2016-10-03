using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Script.Enty
{
    class ChucVuEnty
    {
        private string _MaCV;

        public string MaCV
        {
            get { return _MaCV; }
            set { _MaCV = value; }
        }
        private string _TenCV;

        public string TenCV
        {
            get { return _TenCV; }
            set { _TenCV = value; }
        }
        private string _MaPB;

        public string MaPB
        {
            get { return _MaPB; }
            set { _MaPB = value; }
        }
    }
}
