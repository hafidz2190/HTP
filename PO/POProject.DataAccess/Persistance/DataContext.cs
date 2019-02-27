using POProject.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace POProject.DataAccess.Persistance
{
  public class DataContext : DbContext, IDataContext
  {
    public DataContext() : base("HTPDatabase")
    {
      Database.Log = Console.WriteLine;
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Bank>().ToTable("BANK");
      modelBuilder.Entity<ExceptionPort>().ToTable("EXCEPTION_PORT");
      modelBuilder.Entity<JatuhTempo>().ToTable("JATUHTEMPO_PAJAK");
      modelBuilder.Entity<JenisPajak>().ToTable("USER_TARIF_PAJAK");
      modelBuilder.Entity<NopBaru>().ToTable("NOP_BARU");
      modelBuilder.Entity<SerialNote>().ToTable("SERIAL_NOTE");
      modelBuilder.Entity<UpdateVersion>().ToTable("UPDATE_VERSION");
      modelBuilder.Entity<UserApiUrl>().ToTable("USER_API_URL");
      modelBuilder.Entity<UserClient>().ToTable("USER_CLIENT");
      modelBuilder.Entity<UserNOP>().ToTable("USER_NOP");
      modelBuilder.Entity<UserSettingColumn>().ToTable("USER_SETTING_COLUMN");
      modelBuilder.Entity<UserSettingDatabase>().ToTable("USER_SETTING_DATABASE");
      modelBuilder.Entity<UserTempError>().ToTable("USER_TEMP_ERROR");
      modelBuilder.Entity<UserTempSetting>().ToTable("USER_TEMP_SETTING");
      modelBuilder.Entity<UserTransaction>().ToTable("USER_TRANSACTION");
      modelBuilder.Entity<UserTransactionDetail>().ToTable("USER_TRANSACTION_DETAIL");
      modelBuilder.Entity<UserXMLFile>().ToTable("USER_XML_FILE");
      modelBuilder.Entity<Year>().ToTable("YEAR");
      modelBuilder.Entity<SPTPD>().ToTable("SPTPD");
      modelBuilder.Entity<SPTPDDetail>().ToTable("SPTPD_DETAIL");
      modelBuilder.Entity<settingDBSource>().ToTable("USER_SOURCE_DB");
    }

    public DbSet<Bank> BANK { get; set; }

    public DbSet<ExceptionPort> EXCEPTION_PORT { get; set; }
    public DbSet<JatuhTempo> JATUHTEMPO_PAJAK { get; set; }
    public DbSet<JenisPajak> USER_TARIF_PAJAK { get; set; }
    public DbSet<NopBaru> NOP_BARU { get; set; }
    public DbSet<SerialNote> SERIAL_NOTE { get; set; }
    public DbSet<UpdateVersion> UPDATE_VERSION { get; set; }
    public DbSet<UserApiUrl> USER_API_URL { get; set; }
    public DbSet<UserClient> USER_CLIENT { get; set; }
    public DbSet<UserNOP> USER_NOP { get; set; }
    public DbSet<UserSettingColumn> USER_SETTING_COLUMN { get; set; }
    public DbSet<UserSettingDatabase> USER_SETTING_DATABASE { get; set; }
    public DbSet<UserTempError> USER_TEMP_ERROR { get; set; }
    public DbSet<UserTempSetting> USER_TEMP_SETTING { get; set; }
    public DbSet<UserTransaction> USER_TRANSACTION { get; set; }
    public DbSet<UserTransactionDetail> USER_TRANSACTION_DETAIL { get; set; }
    public DbSet<UserXMLFile> USER_XML_FILE { get; set; }
    public DbSet<Year> YEAR { get; set; }

    public DbContextTransaction BeginTransaction()
    {
      return Database.BeginTransaction();
    }

    void IDataContext.SaveChanges()
    {
      SaveChanges();
    }

    public IEnumerable<TEntity> SqlQuery<TEntity>(string sqlQuery, params object[] parameters) where TEntity : class
    {
      return Database.SqlQuery<TEntity>(sqlQuery, parameters);
    }
  }
}
