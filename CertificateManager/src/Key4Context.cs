using System;
using System.Collections.Generic;
using CertificateManager.Models;
using Microsoft.EntityFrameworkCore;

namespace CertficateManager;

public partial class Key4Context : DbContext
{
    public Key4Context()
    {
    }

    public Key4Context(DbContextOptions<Key4Context> options)
        : base(options)
    {
    }

    public virtual DbSet<MetaData> MetaData { get; set; }

    public virtual DbSet<NssPrivate> NssPrivates { get; set; }

    // TODO: use connectionstring builder
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=key4.db;Mode=ReadOnly");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MetaData>(entity =>
        {
            entity.ToTable("metaData");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Item1).HasColumnName("item1");
            entity.Property(e => e.Item2).HasColumnName("item2");
        });

        modelBuilder.Entity<NssPrivate>(entity =>
        {
            entity.ToTable("nssPrivate");

            entity.HasIndex(e => e.A102, "ckaid");

            entity.HasIndex(e => e.A81, "issuer");

            entity.HasIndex(e => e.A3, "label");

            entity.HasIndex(e => e.A101, "subject");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.A0).HasColumnName("a0");
            entity.Property(e => e.A1).HasColumnName("a1");
            entity.Property(e => e.A10).HasColumnName("a10");
            entity.Property(e => e.A100).HasColumnName("a100");
            entity.Property(e => e.A101).HasColumnName("a101");
            entity.Property(e => e.A102).HasColumnName("a102");
            entity.Property(e => e.A103).HasColumnName("a103");
            entity.Property(e => e.A104).HasColumnName("a104");
            entity.Property(e => e.A105).HasColumnName("a105");
            entity.Property(e => e.A106).HasColumnName("a106");
            entity.Property(e => e.A107).HasColumnName("a107");
            entity.Property(e => e.A108).HasColumnName("a108");
            entity.Property(e => e.A109).HasColumnName("a109");
            entity.Property(e => e.A10a).HasColumnName("a10a");
            entity.Property(e => e.A10b).HasColumnName("a10b");
            entity.Property(e => e.A10c).HasColumnName("a10c");
            entity.Property(e => e.A11).HasColumnName("a11");
            entity.Property(e => e.A110).HasColumnName("a110");
            entity.Property(e => e.A111).HasColumnName("a111");
            entity.Property(e => e.A12).HasColumnName("a12");
            entity.Property(e => e.A120).HasColumnName("a120");
            entity.Property(e => e.A121).HasColumnName("a121");
            entity.Property(e => e.A122).HasColumnName("a122");
            entity.Property(e => e.A123).HasColumnName("a123");
            entity.Property(e => e.A124).HasColumnName("a124");
            entity.Property(e => e.A125).HasColumnName("a125");
            entity.Property(e => e.A126).HasColumnName("a126");
            entity.Property(e => e.A127).HasColumnName("a127");
            entity.Property(e => e.A128).HasColumnName("a128");
            entity.Property(e => e.A129).HasColumnName("a129");
            entity.Property(e => e.A130).HasColumnName("a130");
            entity.Property(e => e.A131).HasColumnName("a131");
            entity.Property(e => e.A132).HasColumnName("a132");
            entity.Property(e => e.A133).HasColumnName("a133");
            entity.Property(e => e.A134).HasColumnName("a134");
            entity.Property(e => e.A160).HasColumnName("a160");
            entity.Property(e => e.A161).HasColumnName("a161");
            entity.Property(e => e.A162).HasColumnName("a162");
            entity.Property(e => e.A163).HasColumnName("a163");
            entity.Property(e => e.A164).HasColumnName("a164");
            entity.Property(e => e.A165).HasColumnName("a165");
            entity.Property(e => e.A166).HasColumnName("a166");
            entity.Property(e => e.A170).HasColumnName("a170");
            entity.Property(e => e.A180).HasColumnName("a180");
            entity.Property(e => e.A181).HasColumnName("a181");
            entity.Property(e => e.A2).HasColumnName("a2");
            entity.Property(e => e.A200).HasColumnName("a200");
            entity.Property(e => e.A201).HasColumnName("a201");
            entity.Property(e => e.A202).HasColumnName("a202");
            entity.Property(e => e.A210).HasColumnName("a210");
            entity.Property(e => e.A3).HasColumnName("a3");
            entity.Property(e => e.A300).HasColumnName("a300");
            entity.Property(e => e.A301).HasColumnName("a301");
            entity.Property(e => e.A302).HasColumnName("a302");
            entity.Property(e => e.A400).HasColumnName("a400");
            entity.Property(e => e.A40000211).HasColumnName("a40000211");
            entity.Property(e => e.A40000212).HasColumnName("a40000212");
            entity.Property(e => e.A401).HasColumnName("a401");
            entity.Property(e => e.A402).HasColumnName("a402");
            entity.Property(e => e.A403).HasColumnName("a403");
            entity.Property(e => e.A404).HasColumnName("a404");
            entity.Property(e => e.A405).HasColumnName("a405");
            entity.Property(e => e.A406).HasColumnName("a406");
            entity.Property(e => e.A480).HasColumnName("a480");
            entity.Property(e => e.A481).HasColumnName("a481");
            entity.Property(e => e.A482).HasColumnName("a482");
            entity.Property(e => e.A500).HasColumnName("a500");
            entity.Property(e => e.A501).HasColumnName("a501");
            entity.Property(e => e.A502).HasColumnName("a502");
            entity.Property(e => e.A503).HasColumnName("a503");
            entity.Property(e => e.A80).HasColumnName("a80");
            entity.Property(e => e.A80000001).HasColumnName("a80000001");
            entity.Property(e => e.A81).HasColumnName("a81");
            entity.Property(e => e.A82).HasColumnName("a82");
            entity.Property(e => e.A83).HasColumnName("a83");
            entity.Property(e => e.A84).HasColumnName("a84");
            entity.Property(e => e.A85).HasColumnName("a85");
            entity.Property(e => e.A86).HasColumnName("a86");
            entity.Property(e => e.A87).HasColumnName("a87");
            entity.Property(e => e.A88).HasColumnName("a88");
            entity.Property(e => e.A89).HasColumnName("a89");
            entity.Property(e => e.A8a).HasColumnName("a8a");
            entity.Property(e => e.A8b).HasColumnName("a8b");
            entity.Property(e => e.A90).HasColumnName("a90");
            entity.Property(e => e.Ace534351).HasColumnName("ace534351");
            entity.Property(e => e.Ace534352).HasColumnName("ace534352");
            entity.Property(e => e.Ace534353).HasColumnName("ace534353");
            entity.Property(e => e.Ace534354).HasColumnName("ace534354");
            entity.Property(e => e.Ace534355).HasColumnName("ace534355");
            entity.Property(e => e.Ace534356).HasColumnName("ace534356");
            entity.Property(e => e.Ace534357).HasColumnName("ace534357");
            entity.Property(e => e.Ace534358).HasColumnName("ace534358");
            entity.Property(e => e.Ace534364).HasColumnName("ace534364");
            entity.Property(e => e.Ace534365).HasColumnName("ace534365");
            entity.Property(e => e.Ace534366).HasColumnName("ace534366");
            entity.Property(e => e.Ace534367).HasColumnName("ace534367");
            entity.Property(e => e.Ace534368).HasColumnName("ace534368");
            entity.Property(e => e.Ace534369).HasColumnName("ace534369");
            entity.Property(e => e.Ace534373).HasColumnName("ace534373");
            entity.Property(e => e.Ace534374).HasColumnName("ace534374");
            entity.Property(e => e.Ace536351).HasColumnName("ace536351");
            entity.Property(e => e.Ace536352).HasColumnName("ace536352");
            entity.Property(e => e.Ace536353).HasColumnName("ace536353");
            entity.Property(e => e.Ace536354).HasColumnName("ace536354");
            entity.Property(e => e.Ace536355).HasColumnName("ace536355");
            entity.Property(e => e.Ace536356).HasColumnName("ace536356");
            entity.Property(e => e.Ace536357).HasColumnName("ace536357");
            entity.Property(e => e.Ace536358).HasColumnName("ace536358");
            entity.Property(e => e.Ace536359).HasColumnName("ace536359");
            entity.Property(e => e.Ace53635a).HasColumnName("ace53635a");
            entity.Property(e => e.Ace53635b).HasColumnName("ace53635b");
            entity.Property(e => e.Ace53635c).HasColumnName("ace53635c");
            entity.Property(e => e.Ace53635d).HasColumnName("ace53635d");
            entity.Property(e => e.Ace53635e).HasColumnName("ace53635e");
            entity.Property(e => e.Ace53635f).HasColumnName("ace53635f");
            entity.Property(e => e.Ace536360).HasColumnName("ace536360");
            entity.Property(e => e.Ace5363b4).HasColumnName("ace5363b4");
            entity.Property(e => e.Ace5363b5).HasColumnName("ace5363b5");
            entity.Property(e => e.Ad5a0db00).HasColumnName("ad5a0db00");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
