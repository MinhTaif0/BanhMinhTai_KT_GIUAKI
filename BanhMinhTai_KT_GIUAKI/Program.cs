
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanhMinhTai_KT_GIUAKI
{
    class Program
    {
        public class GiangVien
        {
            public string Maso { get; set; }
            public string Hoten { get; set; }
            public int Namsinh { get; set; }
            public GiangVien()
            {
               
            }
            public GiangVien(string maso, string hoten, int namsinh)
            {
                Maso = maso;
                Hoten = hoten;
                Namsinh = namsinh;
            }
            public virtual void Nhap()
            {
                Console.Write("nhập mã số: ");
                Maso = Console.ReadLine();
                Console.Write("nhập họ tên: ");
                Hoten = Console.ReadLine();
                Console.Write("nhập năm sinh: ");
                Namsinh = int.Parse(Console.ReadLine());
            }
            public virtual int TinhLuong()
            {
                return 0;
            }
            public virtual void Xuat()
            {
                Console.WriteLine($"ma so: {Maso}, Ho ten: {Hoten}, nam sinh: {Namsinh}");
            }
        }
        public class GiangVienCH : GiangVien
        {
            public float Hesoluong { get; set; }
            public GiangVienCH () { }
            public GiangVienCH(string maso, string hoten, int namsinh, float hesoluong)
                : base(maso, hoten, namsinh)
            {
                Hesoluong = hesoluong;
            }
            public override void Nhap()
            {
                base.Nhap();
                Console.Write("nhap he so luong: ");
                Hesoluong = float.Parse(Console.ReadLine());
            }
            public override int TinhLuong()
            {
                return (int)(Hesoluong * 2340000);
            }
            public override void Xuat()
            {
                base.Xuat();
                Console.WriteLine($"he so luong: {Hesoluong}, Luong: {TinhLuong()}");
            }
        }
        public class GiangVienTG : GiangVien
        {
            public int Sotietday { get; set; }
            public GiangVienTG () { }
            public GiangVienTG (string maso, string hoten,int namsinh,int sotietday)
                : base(maso, hoten , namsinh )
            {
                Sotietday = sotietday;
            }
            public override void Nhap()
            {
                base.Nhap();
                Console.Write("nhap so tiet day: ");
                Sotietday = int.Parse(Console.ReadLine());
            }
            public override int TinhLuong()
            {
                return Sotietday * 120000;
            }
            public override void Xuat()
            {
                base.Xuat();
                Console.WriteLine($"so tiet day: {Sotietday }, Luong: {TinhLuong()}");
            }
        }
        public class QuanLyGV
        {
            private List<GiangVien> dsGV = new List<GiangVien>();

            public void NhapDS()
            {
                Console.Write("Nhap so luong giang vien: ");
                int n = int.Parse(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Chon loai giang vien (1 - Co huu, 2 - Thinh giang): ");
                    int loai = int.Parse(Console.ReadLine());
                    GiangVien gv;
                    if (loai == 1)
                    {
                        gv = new GiangVienCH();
                    }
                    else
                    {
                        gv = new GiangVienTG();
                    }
                    gv.Nhap();
                    dsGV.Add(gv);
                }
            }

            public void XuatDS()
            {
                foreach (var gv in dsGV)
                {
                    gv.Xuat();
                }
            }

            public int TinhTongLuong()
            {
                int tong = 0;
                foreach (var gv in dsGV)
                {
                    tong += gv.TinhLuong();
                }
                return tong;
            }
        }
        class Pro
        {
            static void Main(string[] args)
            {
                QuanLyGV ql = new QuanLyGV();
                while (true)
                {
                    Console.WriteLine("1. Nhap danh sach giang vien");
                    Console.WriteLine("2. Hien thi danh sach giang vien");
                    Console.WriteLine("3. Tinh tong luong");
                    Console.WriteLine("4. Thoat");
                    Console.Write("Chon chuc nang: ");
                    int chon = int.Parse(Console.ReadLine());
                    switch (chon)
                    {
                        case 1:
                            ql.NhapDS();
                            break;
                        case 2:
                            ql.XuatDS();
                            break;
                        case 3:
                            Console.WriteLine($"Tong luong: {ql.TinhTongLuong()}");
                            break;
                        case 4:
                            return;
                        default:
                            Console.WriteLine("Lua chon khong hop le");
                            break;
                    }
                }
            }
        }
    }
}
