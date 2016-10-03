using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Script.Enty
{
    class LichLamViecEnTy
    {
        private string _MaLLV;

        public string MaLLV
        {
            get { return _MaLLV; }
            set { _MaLLV = value; }
        }
        private string _LLV;

        public string LLV
        {
            get { return _LLV; }
            set { _LLV = value; }
        }
        private string _TuNgay;

        public string TuNgay
        {
            get { return _TuNgay; }
            set { _TuNgay = value; }
        }
    }
}
