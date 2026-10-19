using System;
using System.Collections.Generic;

namespace SistemPerpustakaan
{
    abstract class Item
    {
        private string judul;
        private int tahun;

        public string Judul
        {
            get { return judul; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    judul = "Tanpa Judul";
                else
                    judul = value;
            }
        }

        public int Tahun
        {
            get { return tahun; }
            set
            {
                if (value < 1000 || value > DateTime.Now.Year)
                    tahun = DateTime.Now.Year;
                else
                    tahun = value;
            }
        }

        public Item(string judul, int tahun)
        {
            Judul = judul;
            Tahun = tahun;
        }

        public virtual string Deskripsi()
        {
            return "Item: " + Judul + " (" + Tahun + ")";
        }

        public void InfoItem()
        {
            Console.WriteLine("Judul : " + Judul);
            Console.WriteLine("Tahun : " + Tahun);
        }
    }

    class Buku : Item
    {
        public string Penulis { get; set; }

        public Buku(string judul, int tahun, string penulis) : base(judul, tahun)
        {
            Penulis = penulis;
        }

        public override string Deskripsi()
        {
            return "Buku: " + Judul + " (" + Tahun + ") - Penulis: " + Penulis;
        }

        public void CekPenulis()
        {
            Console.WriteLine("Penulis buku ini adalah " + Penulis);
        }
    }

    class Majalah : Item
    {
        public int Edisi { get; set; }

        public Majalah(string judul, int tahun, int edisi) : base(judul, tahun)
        {
            Edisi = edisi;
        }

        public override string Deskripsi()
        {
            return "Majalah: " + Judul + " (" + Tahun + ") - Edisi ke-" + Edisi;
        }

        public void InfoEdisi()
        {
            Console.WriteLine("Majalah ini edisi ke-" + Edisi);
        }
    }

    class Novel : Buku
    {
        public Novel(string judul, int tahun, string penulis) : base(judul, tahun, penulis) { }

        public override string Deskripsi()
        {
            return "Novel: " + Judul + " (" + Tahun + ") - Penulis: " + Penulis;
        }

        public void BacaSinopsis()
        {
            Console.WriteLine("Membaca sinopsis novel \"" + Judul + "\"...");
        }
    }

    class Komik : Buku
    {
        public Komik(string judul, int tahun, string penulis) : base(judul, tahun, penulis) { }

        public override string Deskripsi()
        {
            return "Komik: " + Judul + " (" + Tahun + ") - Penulis: " + Penulis;
        }

        public void TampilkanIlustrasi()
        {
            Console.WriteLine("Menampilkan ilustrasi komik \"" + Judul + "\"...");
        }
    }

    class MajalahAnak : Majalah
    {
        public MajalahAnak(string judul, int tahun, int edisi) : base(judul, tahun, edisi) { }

        public override string Deskripsi()
        {
            return "Majalah Anak: " + Judul + " (" + Tahun + ") - Edisi ke-" + Edisi;
        }

        public void KategoriAnak()
        {
            Console.WriteLine("Kategori: bacaan untuk anak-anak.");
        }
    }

    class MajalahTeknologi : Majalah
    {
        public MajalahTeknologi(string judul, int tahun, int edisi) : base(judul, tahun, edisi) { }

        public override string Deskripsi()
        {
            return "Majalah Teknologi: " + Judul + " (" + Tahun + ") - Edisi ke-" + Edisi;
        }

        public void TopikTeknologi()
        {
            Console.WriteLine("Topik: berita gadget, AI, dan software terbaru.");
        }
    }

    class Perpustakaan
    {
        private List<Item> koleksi = new List<Item>();

        public void TambahItem(Item item)
        {
            koleksi.Add(item);
            Console.WriteLine("Berhasil menambahkan: " + item.Judul);
        }

        public void DaftarItem()
        {
            int nomor = 1;
            foreach (Item item in koleksi)
            {
                Console.WriteLine(nomor + ". " + item.Deskripsi());
                nomor++;
            }
        }

        public List<Item> AmbilKoleksi()
        {
            return koleksi;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Perpustakaan perpus = new Perpustakaan();

            Novel novel = new Novel("Laskar Pelangi", 2005, "Andrea Hirata");
            Komik komik = new Komik("Naruto", 1999, "Masashi Kishimoto");
            MajalahAnak majalahAnak = new MajalahAnak("Bobo", 2023, 12);
            MajalahTeknologi majalahTek = new MajalahTeknologi("Tech Today", 2024, 5);

            Console.WriteLine("=== MENAMBAH ITEM ===");
            perpus.TambahItem(novel);
            perpus.TambahItem(komik);
            perpus.TambahItem(majalahAnak);
            perpus.TambahItem(majalahTek);

            Console.WriteLine("\n=== DAFTAR ITEM PERPUSTAKAAN ===");
            perpus.DaftarItem();

            Console.WriteLine("\n=== POLYMORPHISM ===");
            Item item1 = novel;
            Item item2 = majalahTek;
            Console.WriteLine(item1.Deskripsi());
            Console.WriteLine(item2.Deskripsi());

            Console.WriteLine("\n=== METHOD KHUSUS ===");
            novel.BacaSinopsis();
            novel.CekPenulis();
            komik.TampilkanIlustrasi();
            majalahAnak.KategoriAnak();
            majalahAnak.InfoEdisi();
            majalahTek.TopikTeknologi();

            // ---------------------------------------------------------
            // Jawaban untuk pertanyaan dibawah
            // ---------------------------------------------------------
            Console.WriteLine("\n=== PERTANYAAN 1: Deskripsi() Novel & Majalah ===");
            Console.WriteLine(novel.Deskripsi());
            Console.WriteLine(majalahTek.Deskripsi());

            Console.WriteLine("\n=== PERTANYAAN 2: BacaSinopsis() Novel ===");
            novel.BacaSinopsis();

            Console.WriteLine("\n=== PERTANYAAN 3: Info lengkap Novel ===");
            Console.WriteLine("Judul   : " + novel.Judul);
            Console.WriteLine("Tahun   : " + novel.Tahun);
            Console.WriteLine("Penulis : " + novel.Penulis);

            Console.WriteLine("\n=== PERTANYAAN 4: TopikTeknologi() ===");
            majalahTek.TopikTeknologi();

            Console.WriteLine("\n=== PERTANYAAN 5: Variabel Item diisi Komik ===");
            Item itemKomik = new Komik("One Piece", 1997, "Eiichiro Oda");
            Console.WriteLine(itemKomik.Deskripsi());
            //itemKomik.TampilkanIlustrasi();  // ERROR: tipe Item tidak mengenal method ini
            ((Komik)itemKomik).TampilkanIlustrasi(); // bisa jika di-cast ke Komik
        }
    }
}