using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using HuflitBigPrj.Authorization.Roles;
using HuflitBigPrj.Authorization.Users;
using HuflitBigPrj.Core.Models;
using HuflitBigPrj.MultiTenancy;

namespace HuflitBigPrj.EntityFramework
{
    public class HuflitBigPrjDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...
        public virtual DbSet<ChiTietHD> ChiTietHDs { get; set; }
        public virtual DbSet<ChiTietHDMH> ChiTietHDMHs { get; set; }
        public virtual DbSet<ChiTietPhieuChuyen> ChiTietPhieuChuyens { get; set; }
        public virtual DbSet<ChiTietPhieuNhapHang> ChiTietPhieuNhapHangs { get; set; }
        public virtual DbSet<HangHoa> HangHoas { get; set; }
        public virtual DbSet<HangTrongKho> HangTrongKhoes { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<HonDonMuaHang> HonDonMuaHangs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<KhoHang> KhoHangs { get; set; }
        public virtual DbSet<KiemKeKho> KiemKeKhoes { get; set; }
        public virtual DbSet<LoaiHang> LoaiHangs { get; set; }
        public virtual DbSet<LoaiHoaDon> LoaiHoaDons { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }
        public virtual DbSet<PhieuChuyenKho> PhieuChuyenKhoes { get; set; }
        public virtual DbSet<PhieuTraTien> PhieuTraTiens { get; set; }
        public virtual DbSet<PhieuYeuCauNhapHang> PhieuYeuCauNhapHangs { get; set; }
        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public HuflitBigPrjDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in HuflitBigPrjDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of HuflitBigPrjDbContext since ABP automatically handles it.
         */
        public HuflitBigPrjDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public HuflitBigPrjDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public HuflitBigPrjDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PhieuChuyenKho>()
                   .HasRequired(m => m.KhoHang)
                   .WithMany(t => t.PhieuChuyenKhoes)
                   .HasForeignKey(m => m.KhoHangID)
                   .WillCascadeOnDelete(false);

            modelBuilder.Entity<PhieuChuyenKho>()
                    .HasRequired(m => m.KhoHang1)
                    .WithMany(t => t.PhieuChuyenKhoes1)
                    .HasForeignKey(m => m.KhoHangID1)
                    .WillCascadeOnDelete(false);
        }
    }
}
