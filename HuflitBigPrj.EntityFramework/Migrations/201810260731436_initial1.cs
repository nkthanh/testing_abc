namespace HuflitBigPrj.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChiTietHDMH",
                c => new
                    {
                        maHDMH = c.Int(nullable: false),
                        maHang = c.Int(nullable: false),
                        soLuongMua = c.Int(nullable: false),
                        GiaTien = c.String(maxLength: 100),
                        ThanhTien = c.Double(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Id = c.Int(nullable: false),
                        HangHoa_IDHangHoa = c.Int(),
                        HonDonMuaHang_IDHoaDonMuaHang = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ChiTietHDMH_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => new { t.maHDMH, t.maHang })
                .ForeignKey("dbo.HangHoa", t => t.HangHoa_IDHangHoa)
                .ForeignKey("dbo.HonDonMuaHang", t => t.HonDonMuaHang_IDHoaDonMuaHang)
                .Index(t => t.HangHoa_IDHangHoa)
                .Index(t => t.HonDonMuaHang_IDHoaDonMuaHang);
            
            CreateTable(
                "dbo.HangHoa",
                c => new
                    {
                        IDHangHoa = c.Int(nullable: false, identity: true),
                        tenMatHang = c.String(nullable: false, maxLength: 100),
                        giaCa = c.Int(),
                        dangHoatDong = c.Boolean(),
                        tinhTrangHang = c.Boolean(),
                        id_loai = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Id = c.Int(nullable: false),
                        LoaiHang_IDLoaiHang = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_HangHoa_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.IDHangHoa)
                .ForeignKey("dbo.LoaiHang", t => t.LoaiHang_IDLoaiHang)
                .Index(t => t.LoaiHang_IDLoaiHang);
            
            CreateTable(
                "dbo.ChiTietHD",
                c => new
                    {
                        HDid = c.Int(nullable: false),
                        maHang = c.Int(nullable: false),
                        soLuong = c.Int(nullable: false),
                        giaSanPham = c.String(maxLength: 100),
                        thanhTien = c.Double(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Id = c.Int(nullable: false),
                        HangHoa_IDHangHoa = c.Int(),
                        HoaDon_IDHoaDon = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ChiTietHD_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => new { t.HDid, t.maHang })
                .ForeignKey("dbo.HangHoa", t => t.HangHoa_IDHangHoa)
                .ForeignKey("dbo.HoaDon", t => t.HoaDon_IDHoaDon)
                .Index(t => t.HangHoa_IDHangHoa)
                .Index(t => t.HoaDon_IDHoaDon);
            
            CreateTable(
                "dbo.HoaDon",
                c => new
                    {
                        IDHoaDon = c.Int(nullable: false, identity: true),
                        maHD = c.String(maxLength: 10),
                        ngaylapHD = c.DateTime(nullable: false),
                        tongtien = c.Double(nullable: false),
                        maNhanVien = c.Int(),
                        maKhachHang = c.Int(),
                        loaiHD = c.String(maxLength: 2),
                        tinhtrangHD = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Id = c.Int(nullable: false),
                        KhachHang_IDKhachHang = c.Int(),
                        NguoiDung_IDNguoiDung = c.Int(),
                        LoaiHoaDon_maLoai = c.String(maxLength: 2),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_HoaDon_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.IDHoaDon)
                .ForeignKey("dbo.KhachHang", t => t.KhachHang_IDKhachHang)
                .ForeignKey("dbo.NguoiDung", t => t.NguoiDung_IDNguoiDung)
                .ForeignKey("dbo.LoaiHoaDon", t => t.LoaiHoaDon_maLoai)
                .Index(t => t.KhachHang_IDKhachHang)
                .Index(t => t.NguoiDung_IDNguoiDung)
                .Index(t => t.LoaiHoaDon_maLoai);
            
            CreateTable(
                "dbo.KhachHang",
                c => new
                    {
                        IDKhachHang = c.Int(nullable: false, identity: true),
                        tenKhachHang = c.String(nullable: false, maxLength: 100),
                        diachi = c.String(maxLength: 100),
                        soDienThoai = c.String(maxLength: 11),
                        Email = c.String(maxLength: 100),
                        soTienConNo = c.Int(nullable: false),
                        dangHoatDong = c.Boolean(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Id = c.Int(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_KhachHang_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.IDKhachHang);
            
            CreateTable(
                "dbo.PhieuTraTien",
                c => new
                    {
                        IDPhieuTraTien = c.Int(nullable: false, identity: true),
                        ngayTraTien = c.DateTime(nullable: false),
                        SoTienTra = c.Int(nullable: false),
                        maKhach = c.Int(),
                        ghiChu = c.String(maxLength: 100),
                        maNVBH = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Id = c.Int(nullable: false),
                        KhachHang_IDKhachHang = c.Int(),
                        NguoiDung_IDNguoiDung = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_PhieuTraTien_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.IDPhieuTraTien)
                .ForeignKey("dbo.KhachHang", t => t.KhachHang_IDKhachHang)
                .ForeignKey("dbo.NguoiDung", t => t.NguoiDung_IDNguoiDung)
                .Index(t => t.KhachHang_IDKhachHang)
                .Index(t => t.NguoiDung_IDNguoiDung);
            
            CreateTable(
                "dbo.NguoiDung",
                c => new
                    {
                        IDNguoiDung = c.Int(nullable: false, identity: true),
                        tenDangNhap = c.String(nullable: false, maxLength: 100),
                        matKhauNguoiDung = c.String(nullable: false, maxLength: 100),
                        tenNguoiDung = c.String(nullable: false, maxLength: 100),
                        diaChi = c.String(maxLength: 100),
                        dangHoatDong = c.Boolean(),
                        quyen = c.Int(),
                        id_kho = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Id = c.Int(nullable: false),
                        KhoHang_IDKhoHang = c.Int(),
                        PhanQuyen_IDQuyen = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_NguoiDung_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.IDNguoiDung)
                .ForeignKey("dbo.KhoHang", t => t.KhoHang_IDKhoHang)
                .ForeignKey("dbo.PhanQuyen", t => t.PhanQuyen_IDQuyen)
                .Index(t => t.KhoHang_IDKhoHang)
                .Index(t => t.PhanQuyen_IDQuyen);
            
            CreateTable(
                "dbo.HonDonMuaHang",
                c => new
                    {
                        IDHoaDonMuaHang = c.Int(nullable: false, identity: true),
                        maHDMH = c.String(nullable: false, maxLength: 10),
                        ngayMuaHang = c.DateTime(nullable: false),
                        tongTien = c.Int(),
                        maNhanVien = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Id = c.Int(nullable: false),
                        NguoiDung_IDNguoiDung = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_HonDonMuaHang_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.IDHoaDonMuaHang)
                .ForeignKey("dbo.NguoiDung", t => t.NguoiDung_IDNguoiDung)
                .Index(t => t.NguoiDung_IDNguoiDung);
            
            CreateTable(
                "dbo.KhoHang",
                c => new
                    {
                        IDKhoHang = c.Int(nullable: false, identity: true),
                        diachi = c.String(nullable: false, maxLength: 100),
                        tenkho = c.String(nullable: false, maxLength: 100),
                        khoChinh = c.Boolean(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Id = c.Int(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_KhoHang_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.IDKhoHang);
            
            CreateTable(
                "dbo.HangTrongKho",
                c => new
                    {
                        maKho = c.Int(nullable: false),
                        maHang = c.Int(nullable: false),
                        soLuongSP = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Id = c.Int(nullable: false),
                        HangHoa_IDHangHoa = c.Int(),
                        KhoHang_IDKhoHang = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_HangTrongKho_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => new { t.maKho, t.maHang })
                .ForeignKey("dbo.HangHoa", t => t.HangHoa_IDHangHoa)
                .ForeignKey("dbo.KhoHang", t => t.KhoHang_IDKhoHang)
                .Index(t => t.HangHoa_IDHangHoa)
                .Index(t => t.KhoHang_IDKhoHang);
            
            CreateTable(
                "dbo.KiemKeKho",
                c => new
                    {
                        IDKiemKeKho = c.Int(nullable: false, identity: true),
                        ngayKiemKe = c.DateTime(),
                        MieuTa = c.String(maxLength: 500),
                        nguoiThucHien = c.Int(),
                        maKho = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Id = c.Int(nullable: false),
                        KhoHang_IDKhoHang = c.Int(),
                        NguoiDung_IDNguoiDung = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_KiemKeKho_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.IDKiemKeKho)
                .ForeignKey("dbo.KhoHang", t => t.KhoHang_IDKhoHang)
                .ForeignKey("dbo.NguoiDung", t => t.NguoiDung_IDNguoiDung)
                .Index(t => t.KhoHang_IDKhoHang)
                .Index(t => t.NguoiDung_IDNguoiDung);
            
            CreateTable(
                "dbo.PhieuChuyenKho",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IDPhieuChuyenKho = c.Int(nullable: false),
                        khoChuyen = c.Int(),
                        khoDen = c.Int(),
                        ngayChuyen = c.DateTime(nullable: false),
                        tongTien = c.Int(),
                        maNVBH = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        KhoHang_IDKhoHang = c.Int(),
                        KhoHang1_IDKhoHang = c.Int(),
                        NguoiDung_IDNguoiDung = c.Int(),
                        KhoHang_IDKhoHang1 = c.Int(),
                        KhoHang_IDKhoHang2 = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_PhieuChuyenKho_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KhoHang", t => t.KhoHang_IDKhoHang)
                .ForeignKey("dbo.KhoHang", t => t.KhoHang1_IDKhoHang)
                .ForeignKey("dbo.NguoiDung", t => t.NguoiDung_IDNguoiDung)
                .ForeignKey("dbo.KhoHang", t => t.KhoHang_IDKhoHang1)
                .ForeignKey("dbo.KhoHang", t => t.KhoHang_IDKhoHang2)
                .Index(t => t.KhoHang_IDKhoHang)
                .Index(t => t.KhoHang1_IDKhoHang)
                .Index(t => t.NguoiDung_IDNguoiDung)
                .Index(t => t.KhoHang_IDKhoHang1)
                .Index(t => t.KhoHang_IDKhoHang2);
            
            CreateTable(
                "dbo.ChiTietPhieuChuyen",
                c => new
                    {
                        maPhieu = c.Int(nullable: false),
                        maHang = c.Int(nullable: false),
                        soLuongHang = c.Int(nullable: false),
                        tongTien = c.String(maxLength: 100),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Id = c.Int(nullable: false),
                        HangHoa_IDHangHoa = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ChiTietPhieuChuyen_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => new { t.maPhieu, t.maHang })
                .ForeignKey("dbo.HangHoa", t => t.HangHoa_IDHangHoa)
                .ForeignKey("dbo.PhieuChuyenKho", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.HangHoa_IDHangHoa);
            
            CreateTable(
                "dbo.PhieuYeuCauNhapHang",
                c => new
                    {
                        IDPhieuYCNhapHang = c.Int(nullable: false, identity: true),
                        ngayLapPhieu = c.DateTime(),
                        maKho = c.Int(),
                        nguoiLapPhieu = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Id = c.Int(nullable: false),
                        KhoHang_IDKhoHang = c.Int(),
                        NguoiDung_IDNguoiDung = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_PhieuYeuCauNhapHang_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.IDPhieuYCNhapHang)
                .ForeignKey("dbo.KhoHang", t => t.KhoHang_IDKhoHang)
                .ForeignKey("dbo.NguoiDung", t => t.NguoiDung_IDNguoiDung)
                .Index(t => t.KhoHang_IDKhoHang)
                .Index(t => t.NguoiDung_IDNguoiDung);
            
            CreateTable(
                "dbo.ChiTietPhieuNhapHang",
                c => new
                    {
                        maPhieuNhap = c.Int(nullable: false),
                        maHang = c.Int(nullable: false),
                        giaHang = c.String(maxLength: 100),
                        soLuongHang = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Id = c.Int(nullable: false),
                        HangHoa_IDHangHoa = c.Int(),
                        PhieuYeuCauNhapHang_IDPhieuYCNhapHang = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ChiTietPhieuNhapHang_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => new { t.maPhieuNhap, t.maHang })
                .ForeignKey("dbo.HangHoa", t => t.HangHoa_IDHangHoa)
                .ForeignKey("dbo.PhieuYeuCauNhapHang", t => t.PhieuYeuCauNhapHang_IDPhieuYCNhapHang)
                .Index(t => t.HangHoa_IDHangHoa)
                .Index(t => t.PhieuYeuCauNhapHang_IDPhieuYCNhapHang);
            
            CreateTable(
                "dbo.PhanQuyen",
                c => new
                    {
                        IDQuyen = c.Int(nullable: false, identity: true),
                        ten_quyen = c.String(maxLength: 50),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Id = c.Int(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_PhanQuyen_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.IDQuyen);
            
            CreateTable(
                "dbo.LoaiHoaDon",
                c => new
                    {
                        maLoai = c.String(nullable: false, maxLength: 2),
                        TenLoaiHD = c.String(maxLength: 100),
                        moTa = c.String(maxLength: 100),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Id = c.Int(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_LoaiHoaDon_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.maLoai);
            
            CreateTable(
                "dbo.LoaiHang",
                c => new
                    {
                        IDLoaiHang = c.Int(nullable: false, identity: true),
                        tenLoai = c.String(maxLength: 100),
                        IsDeleted = c.Boolean(nullable: false),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(),
                        LastModificationTime = c.DateTime(),
                        LastModifierUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false),
                        CreatorUserId = c.Long(),
                        Id = c.Int(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_LoaiHang_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.IDLoaiHang);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HangHoa", "LoaiHang_IDLoaiHang", "dbo.LoaiHang");
            DropForeignKey("dbo.HoaDon", "LoaiHoaDon_maLoai", "dbo.LoaiHoaDon");
            DropForeignKey("dbo.PhieuTraTien", "NguoiDung_IDNguoiDung", "dbo.NguoiDung");
            DropForeignKey("dbo.NguoiDung", "PhanQuyen_IDQuyen", "dbo.PhanQuyen");
            DropForeignKey("dbo.PhieuYeuCauNhapHang", "NguoiDung_IDNguoiDung", "dbo.NguoiDung");
            DropForeignKey("dbo.PhieuYeuCauNhapHang", "KhoHang_IDKhoHang", "dbo.KhoHang");
            DropForeignKey("dbo.ChiTietPhieuNhapHang", "PhieuYeuCauNhapHang_IDPhieuYCNhapHang", "dbo.PhieuYeuCauNhapHang");
            DropForeignKey("dbo.ChiTietPhieuNhapHang", "HangHoa_IDHangHoa", "dbo.HangHoa");
            DropForeignKey("dbo.PhieuChuyenKho", "KhoHang_IDKhoHang2", "dbo.KhoHang");
            DropForeignKey("dbo.PhieuChuyenKho", "KhoHang_IDKhoHang1", "dbo.KhoHang");
            DropForeignKey("dbo.PhieuChuyenKho", "NguoiDung_IDNguoiDung", "dbo.NguoiDung");
            DropForeignKey("dbo.PhieuChuyenKho", "KhoHang1_IDKhoHang", "dbo.KhoHang");
            DropForeignKey("dbo.PhieuChuyenKho", "KhoHang_IDKhoHang", "dbo.KhoHang");
            DropForeignKey("dbo.ChiTietPhieuChuyen", "Id", "dbo.PhieuChuyenKho");
            DropForeignKey("dbo.ChiTietPhieuChuyen", "HangHoa_IDHangHoa", "dbo.HangHoa");
            DropForeignKey("dbo.NguoiDung", "KhoHang_IDKhoHang", "dbo.KhoHang");
            DropForeignKey("dbo.KiemKeKho", "NguoiDung_IDNguoiDung", "dbo.NguoiDung");
            DropForeignKey("dbo.KiemKeKho", "KhoHang_IDKhoHang", "dbo.KhoHang");
            DropForeignKey("dbo.HangTrongKho", "KhoHang_IDKhoHang", "dbo.KhoHang");
            DropForeignKey("dbo.HangTrongKho", "HangHoa_IDHangHoa", "dbo.HangHoa");
            DropForeignKey("dbo.HonDonMuaHang", "NguoiDung_IDNguoiDung", "dbo.NguoiDung");
            DropForeignKey("dbo.ChiTietHDMH", "HonDonMuaHang_IDHoaDonMuaHang", "dbo.HonDonMuaHang");
            DropForeignKey("dbo.HoaDon", "NguoiDung_IDNguoiDung", "dbo.NguoiDung");
            DropForeignKey("dbo.PhieuTraTien", "KhachHang_IDKhachHang", "dbo.KhachHang");
            DropForeignKey("dbo.HoaDon", "KhachHang_IDKhachHang", "dbo.KhachHang");
            DropForeignKey("dbo.ChiTietHD", "HoaDon_IDHoaDon", "dbo.HoaDon");
            DropForeignKey("dbo.ChiTietHD", "HangHoa_IDHangHoa", "dbo.HangHoa");
            DropForeignKey("dbo.ChiTietHDMH", "HangHoa_IDHangHoa", "dbo.HangHoa");
            DropIndex("dbo.ChiTietPhieuNhapHang", new[] { "PhieuYeuCauNhapHang_IDPhieuYCNhapHang" });
            DropIndex("dbo.ChiTietPhieuNhapHang", new[] { "HangHoa_IDHangHoa" });
            DropIndex("dbo.PhieuYeuCauNhapHang", new[] { "NguoiDung_IDNguoiDung" });
            DropIndex("dbo.PhieuYeuCauNhapHang", new[] { "KhoHang_IDKhoHang" });
            DropIndex("dbo.ChiTietPhieuChuyen", new[] { "HangHoa_IDHangHoa" });
            DropIndex("dbo.ChiTietPhieuChuyen", new[] { "Id" });
            DropIndex("dbo.PhieuChuyenKho", new[] { "KhoHang_IDKhoHang2" });
            DropIndex("dbo.PhieuChuyenKho", new[] { "KhoHang_IDKhoHang1" });
            DropIndex("dbo.PhieuChuyenKho", new[] { "NguoiDung_IDNguoiDung" });
            DropIndex("dbo.PhieuChuyenKho", new[] { "KhoHang1_IDKhoHang" });
            DropIndex("dbo.PhieuChuyenKho", new[] { "KhoHang_IDKhoHang" });
            DropIndex("dbo.KiemKeKho", new[] { "NguoiDung_IDNguoiDung" });
            DropIndex("dbo.KiemKeKho", new[] { "KhoHang_IDKhoHang" });
            DropIndex("dbo.HangTrongKho", new[] { "KhoHang_IDKhoHang" });
            DropIndex("dbo.HangTrongKho", new[] { "HangHoa_IDHangHoa" });
            DropIndex("dbo.HonDonMuaHang", new[] { "NguoiDung_IDNguoiDung" });
            DropIndex("dbo.NguoiDung", new[] { "PhanQuyen_IDQuyen" });
            DropIndex("dbo.NguoiDung", new[] { "KhoHang_IDKhoHang" });
            DropIndex("dbo.PhieuTraTien", new[] { "NguoiDung_IDNguoiDung" });
            DropIndex("dbo.PhieuTraTien", new[] { "KhachHang_IDKhachHang" });
            DropIndex("dbo.HoaDon", new[] { "LoaiHoaDon_maLoai" });
            DropIndex("dbo.HoaDon", new[] { "NguoiDung_IDNguoiDung" });
            DropIndex("dbo.HoaDon", new[] { "KhachHang_IDKhachHang" });
            DropIndex("dbo.ChiTietHD", new[] { "HoaDon_IDHoaDon" });
            DropIndex("dbo.ChiTietHD", new[] { "HangHoa_IDHangHoa" });
            DropIndex("dbo.HangHoa", new[] { "LoaiHang_IDLoaiHang" });
            DropIndex("dbo.ChiTietHDMH", new[] { "HonDonMuaHang_IDHoaDonMuaHang" });
            DropIndex("dbo.ChiTietHDMH", new[] { "HangHoa_IDHangHoa" });
            DropTable("dbo.LoaiHang",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_LoaiHang_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.LoaiHoaDon",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_LoaiHoaDon_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.PhanQuyen",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_PhanQuyen_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.ChiTietPhieuNhapHang",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ChiTietPhieuNhapHang_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.PhieuYeuCauNhapHang",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_PhieuYeuCauNhapHang_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.ChiTietPhieuChuyen",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ChiTietPhieuChuyen_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.PhieuChuyenKho",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_PhieuChuyenKho_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.KiemKeKho",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_KiemKeKho_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.HangTrongKho",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_HangTrongKho_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.KhoHang",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_KhoHang_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.HonDonMuaHang",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_HonDonMuaHang_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.NguoiDung",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_NguoiDung_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.PhieuTraTien",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_PhieuTraTien_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.KhachHang",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_KhachHang_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.HoaDon",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_HoaDon_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.ChiTietHD",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ChiTietHD_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.HangHoa",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_HangHoa_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.ChiTietHDMH",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ChiTietHDMH_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
