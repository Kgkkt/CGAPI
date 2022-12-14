// <auto-generated />
using System;
using CGAPI.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CGAPI.Migrations
{
    [DbContext(typeof(CGDBContext))]
    partial class CGDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CGAPI.DB.Models.CG_GameElement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CG_ImageId")
                        .HasColumnType("int");

                    b.Property<int>("CG_PlaylistId")
                        .HasColumnType("int");

                    b.Property<int>("CG_SoundCorrectAnswerId")
                        .HasColumnType("int");

                    b.Property<int>("CG_SoundQuestionId")
                        .HasColumnType("int");

                    b.Property<int>("CG_SoundWrongAnswerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CG_ImageId");

                    b.HasIndex("CG_PlaylistId");

                    b.HasIndex("CG_SoundCorrectAnswerId");

                    b.HasIndex("CG_SoundQuestionId");

                    b.HasIndex("CG_SoundWrongAnswerId");

                    b.ToTable("CG_GameElements");
                });

            modelBuilder.Entity("CGAPI.DB.Models.CG_Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<byte[]>("Img")
                        .IsRequired()
                        .HasMaxLength(16000)
                        .HasColumnType("longblob");

                    b.HasKey("Id");

                    b.ToTable("CG_Images");
                });

            modelBuilder.Entity("CGAPI.DB.Models.CG_Playlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CGUserId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CGUserId");

                    b.ToTable("CG_Playlists");
                });

            modelBuilder.Entity("CGAPI.DB.Models.CG_Sound", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<byte[]>("Sound")
                        .IsRequired()
                        .HasMaxLength(16000)
                        .HasColumnType("longblob");

                    b.HasKey("Id");

                    b.ToTable("CG_Sounds");
                });

            modelBuilder.Entity("CGAPI.DB.Models.CG_Text", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.HasKey("Id");

                    b.ToTable("CG_Texts");
                });

            modelBuilder.Entity("CGAPI.DB.Models.CGUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("CGUsers");
                });

            modelBuilder.Entity("CGAPI.DB.Models.CG_GameElement", b =>
                {
                    b.HasOne("CGAPI.DB.Models.CG_Image", "CG_Image")
                        .WithMany()
                        .HasForeignKey("CG_ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CGAPI.DB.Models.CG_Playlist", "CG_Playlist")
                        .WithMany()
                        .HasForeignKey("CG_PlaylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CGAPI.DB.Models.CG_Sound", "CG_SoundCorrectAnswer")
                        .WithMany()
                        .HasForeignKey("CG_SoundCorrectAnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CGAPI.DB.Models.CG_Sound", "CG_SoundQuestion")
                        .WithMany()
                        .HasForeignKey("CG_SoundQuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CGAPI.DB.Models.CG_Sound", "CG_SoundWrongAnswer")
                        .WithMany()
                        .HasForeignKey("CG_SoundWrongAnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CG_Image");

                    b.Navigation("CG_Playlist");

                    b.Navigation("CG_SoundCorrectAnswer");

                    b.Navigation("CG_SoundQuestion");

                    b.Navigation("CG_SoundWrongAnswer");
                });

            modelBuilder.Entity("CGAPI.DB.Models.CG_Playlist", b =>
                {
                    b.HasOne("CGAPI.DB.Models.CGUser", "CGUser")
                        .WithMany("Playlists")
                        .HasForeignKey("CGUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CGUser");
                });

            modelBuilder.Entity("CGAPI.DB.Models.CGUser", b =>
                {
                    b.Navigation("Playlists");
                });
#pragma warning restore 612, 618
        }
    }
}
