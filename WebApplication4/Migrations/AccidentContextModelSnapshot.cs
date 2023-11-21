﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication4.Data;

#nullable disable

namespace WebApplication4.Migrations
{
    [DbContext(typeof(AccidentContext))]
    partial class AccidentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AccidentDeviationDetail", b =>
                {
                    b.Property<int>("AccidentsID")
                        .HasColumnType("int");

                    b.Property<int>("DeviationDetailsID")
                        .HasColumnType("int");

                    b.HasKey("AccidentsID", "DeviationDetailsID");

                    b.HasIndex("DeviationDetailsID");

                    b.ToTable("AccidentDeviationDetail");
                });

            modelBuilder.Entity("AccidentDirectMesure", b =>
                {
                    b.Property<int>("AccidentsID")
                        .HasColumnType("int");

                    b.Property<int>("DirectMesuresID")
                        .HasColumnType("int");

                    b.HasKey("AccidentsID", "DirectMesuresID");

                    b.HasIndex("DirectMesuresID");

                    b.ToTable("AccidentDirectMesure");
                });

            modelBuilder.Entity("AccidentFundamentaryCause", b =>
                {
                    b.Property<int>("AccidentsID")
                        .HasColumnType("int");

                    b.Property<int>("FundamentaryCausesID")
                        .HasColumnType("int");

                    b.HasKey("AccidentsID", "FundamentaryCausesID");

                    b.HasIndex("FundamentaryCausesID");

                    b.ToTable("AccidentFundamentaryCause");
                });

            modelBuilder.Entity("AccidentMaterialAgentDetail", b =>
                {
                    b.Property<int>("AccidentsID")
                        .HasColumnType("int");

                    b.Property<int>("MaterialAgentDetailsID")
                        .HasColumnType("int");

                    b.HasKey("AccidentsID", "MaterialAgentDetailsID");

                    b.HasIndex("MaterialAgentDetailsID");

                    b.ToTable("AccidentMaterialAgentDetail");
                });

            modelBuilder.Entity("AccidentProposedMesureDetail", b =>
                {
                    b.Property<int>("AccidentsID")
                        .HasColumnType("int");

                    b.Property<int>("ProposedMesureDetailsID")
                        .HasColumnType("int");

                    b.HasKey("AccidentsID", "ProposedMesureDetailsID");

                    b.HasIndex("ProposedMesureDetailsID");

                    b.ToTable("AccidentProposedMesureDetail");
                });

            modelBuilder.Entity("LesionSeatDetailVictimInformation", b =>
                {
                    b.Property<int>("LesionSeatDetailsID")
                        .HasColumnType("int");

                    b.Property<int>("VictimInformationID")
                        .HasColumnType("int");

                    b.HasKey("LesionSeatDetailsID", "VictimInformationID");

                    b.HasIndex("VictimInformationID");

                    b.ToTable("LesionSeatDetailVictimInformation");
                });

            modelBuilder.Entity("NatureLesionDetailVictimInformation", b =>
                {
                    b.Property<int>("NatureLesionDetailsID")
                        .HasColumnType("int");

                    b.Property<int>("VictimInformationID")
                        .HasColumnType("int");

                    b.HasKey("NatureLesionDetailsID", "VictimInformationID");

                    b.HasIndex("VictimInformationID");

                    b.ToTable("NatureLesionDetailVictimInformation");
                });

            modelBuilder.Entity("WebApplication4.Models.Accident", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("AccidentDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Gravity")
                        .HasColumnType("int");

                    b.Property<string>("LocationDetail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationID")
                        .HasColumnType("int");

                    b.Property<int>("Probability")
                        .HasColumnType("int");

                    b.Property<string>("Reaction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("LocationID");

                    b.ToTable("Accidents");
                });

            modelBuilder.Entity("WebApplication4.Models.Deviation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Deviations");
                });

            modelBuilder.Entity("WebApplication4.Models.DeviationDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<int>("DeviationID")
                        .HasColumnType("int");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("DeviationID");

                    b.ToTable("DeviationDetails");
                });

            modelBuilder.Entity("WebApplication4.Models.DirectMesure", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("DirectMesures");
                });

            modelBuilder.Entity("WebApplication4.Models.FundamentaryCause", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("FundamentaryCauses");
                });

            modelBuilder.Entity("WebApplication4.Models.LesionSeat", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("LesionSeats");
                });

            modelBuilder.Entity("WebApplication4.Models.LesionSeatDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LesionSeatID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("LesionSeatID");

                    b.ToTable("LesionSeatDetails");
                });

            modelBuilder.Entity("WebApplication4.Models.Location", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("WebApplication4.Models.MaterialAgent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("MaterialAgents");
                });

            modelBuilder.Entity("WebApplication4.Models.MaterialAgentDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaterialAgentID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MaterialAgentID");

                    b.ToTable("MaterialAgentDetails");
                });

            modelBuilder.Entity("WebApplication4.Models.NatureLesion", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("NatureLesions");
                });

            modelBuilder.Entity("WebApplication4.Models.NatureLesionDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NatureLesionID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("NatureLesionID");

                    b.ToTable("NatureLesionDetails");
                });

            modelBuilder.Entity("WebApplication4.Models.OutsideFirm", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("OutsideFirms");
                });

            modelBuilder.Entity("WebApplication4.Models.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OutsideFirmID")
                        .HasColumnType("int");

                    b.Property<int?>("Role")
                        .HasColumnType("int");

                    b.Property<string>("WorkingHours")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("employementType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("OutsideFirmID");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("WebApplication4.Models.ProposedMesure", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("ProposedMesures");
                });

            modelBuilder.Entity("WebApplication4.Models.ProposedMesureDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProposedMesureID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ProposedMesureID");

                    b.ToTable("ProposedMesureDetails");
                });

            modelBuilder.Entity("WebApplication4.Models.Protection", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Protections");
                });

            modelBuilder.Entity("WebApplication4.Models.Report", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("AccidentID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTimeCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AccidentID");

                    b.HasIndex("PersonID");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("WebApplication4.Models.VictimInformation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("AccidentID")
                        .HasColumnType("int");

                    b.Property<string>("ActivityDuringAccident")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateTimeWorkResumed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateTimeWorkStopped")
                        .HasColumnType("datetime2");

                    b.Property<int>("PersonID")
                        .HasColumnType("int");

                    b.Property<bool>("UsualFunction")
                        .HasColumnType("bit");

                    b.Property<bool>("WorkResumed")
                        .HasColumnType("bit");

                    b.Property<bool>("WorkStopped")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("AccidentID")
                        .IsUnique();

                    b.HasIndex("PersonID");

                    b.ToTable("VictimInformations");
                });

            modelBuilder.Entity("WebApplication4.Models.VictimProtectionAsset", b =>
                {
                    b.Property<int>("VictimInformationID")
                        .HasColumnType("int");

                    b.Property<int>("ProtectionID")
                        .HasColumnType("int");

                    b.Property<bool>("isNecessary")
                        .HasColumnType("bit");

                    b.HasKey("VictimInformationID", "ProtectionID");

                    b.HasIndex("ProtectionID");

                    b.ToTable("VictimProtectionAssets");
                });

            modelBuilder.Entity("AccidentDeviationDetail", b =>
                {
                    b.HasOne("WebApplication4.Models.Accident", null)
                        .WithMany()
                        .HasForeignKey("AccidentsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication4.Models.DeviationDetail", null)
                        .WithMany()
                        .HasForeignKey("DeviationDetailsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AccidentDirectMesure", b =>
                {
                    b.HasOne("WebApplication4.Models.Accident", null)
                        .WithMany()
                        .HasForeignKey("AccidentsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication4.Models.DirectMesure", null)
                        .WithMany()
                        .HasForeignKey("DirectMesuresID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AccidentFundamentaryCause", b =>
                {
                    b.HasOne("WebApplication4.Models.Accident", null)
                        .WithMany()
                        .HasForeignKey("AccidentsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication4.Models.FundamentaryCause", null)
                        .WithMany()
                        .HasForeignKey("FundamentaryCausesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AccidentMaterialAgentDetail", b =>
                {
                    b.HasOne("WebApplication4.Models.Accident", null)
                        .WithMany()
                        .HasForeignKey("AccidentsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication4.Models.MaterialAgentDetail", null)
                        .WithMany()
                        .HasForeignKey("MaterialAgentDetailsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AccidentProposedMesureDetail", b =>
                {
                    b.HasOne("WebApplication4.Models.Accident", null)
                        .WithMany()
                        .HasForeignKey("AccidentsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication4.Models.ProposedMesureDetail", null)
                        .WithMany()
                        .HasForeignKey("ProposedMesureDetailsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LesionSeatDetailVictimInformation", b =>
                {
                    b.HasOne("WebApplication4.Models.LesionSeatDetail", null)
                        .WithMany()
                        .HasForeignKey("LesionSeatDetailsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication4.Models.VictimInformation", null)
                        .WithMany()
                        .HasForeignKey("VictimInformationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NatureLesionDetailVictimInformation", b =>
                {
                    b.HasOne("WebApplication4.Models.NatureLesionDetail", null)
                        .WithMany()
                        .HasForeignKey("NatureLesionDetailsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication4.Models.VictimInformation", null)
                        .WithMany()
                        .HasForeignKey("VictimInformationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApplication4.Models.Accident", b =>
                {
                    b.HasOne("WebApplication4.Models.Location", "Location")
                        .WithMany("Accidents")
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("WebApplication4.Models.DeviationDetail", b =>
                {
                    b.HasOne("WebApplication4.Models.Deviation", "Deviation")
                        .WithMany("DeviationDetails")
                        .HasForeignKey("DeviationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deviation");
                });

            modelBuilder.Entity("WebApplication4.Models.LesionSeatDetail", b =>
                {
                    b.HasOne("WebApplication4.Models.LesionSeat", "LesionSeat")
                        .WithMany("LesionSeatDetails")
                        .HasForeignKey("LesionSeatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LesionSeat");
                });

            modelBuilder.Entity("WebApplication4.Models.MaterialAgentDetail", b =>
                {
                    b.HasOne("WebApplication4.Models.MaterialAgent", "MaterialAgent")
                        .WithMany("MaterialAgentDetails")
                        .HasForeignKey("MaterialAgentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MaterialAgent");
                });

            modelBuilder.Entity("WebApplication4.Models.NatureLesionDetail", b =>
                {
                    b.HasOne("WebApplication4.Models.NatureLesion", "NatureLesion")
                        .WithMany("NatureLesionDetail")
                        .HasForeignKey("NatureLesionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NatureLesion");
                });

            modelBuilder.Entity("WebApplication4.Models.Person", b =>
                {
                    b.HasOne("WebApplication4.Models.OutsideFirm", "OutsideFirm")
                        .WithMany("Persons")
                        .HasForeignKey("OutsideFirmID");

                    b.Navigation("OutsideFirm");
                });

            modelBuilder.Entity("WebApplication4.Models.ProposedMesureDetail", b =>
                {
                    b.HasOne("WebApplication4.Models.ProposedMesure", "ProposedMesure")
                        .WithMany("ProposedMesureDetails")
                        .HasForeignKey("ProposedMesureID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProposedMesure");
                });

            modelBuilder.Entity("WebApplication4.Models.Report", b =>
                {
                    b.HasOne("WebApplication4.Models.Accident", "Accident")
                        .WithMany("Reports")
                        .HasForeignKey("AccidentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication4.Models.Person", "Person")
                        .WithMany("Reports")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accident");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("WebApplication4.Models.VictimInformation", b =>
                {
                    b.HasOne("WebApplication4.Models.Accident", "Accident")
                        .WithOne("VictimInformation")
                        .HasForeignKey("WebApplication4.Models.VictimInformation", "AccidentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication4.Models.Person", "Person")
                        .WithMany("VictimInformations")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accident");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("WebApplication4.Models.VictimProtectionAsset", b =>
                {
                    b.HasOne("WebApplication4.Models.Protection", "Protection")
                        .WithMany("AccidentProtections")
                        .HasForeignKey("ProtectionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication4.Models.VictimInformation", "VictimInformation")
                        .WithMany("VictimProtectionAssets")
                        .HasForeignKey("VictimInformationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Protection");

                    b.Navigation("VictimInformation");
                });

            modelBuilder.Entity("WebApplication4.Models.Accident", b =>
                {
                    b.Navigation("Reports");

                    b.Navigation("VictimInformation");
                });

            modelBuilder.Entity("WebApplication4.Models.Deviation", b =>
                {
                    b.Navigation("DeviationDetails");
                });

            modelBuilder.Entity("WebApplication4.Models.LesionSeat", b =>
                {
                    b.Navigation("LesionSeatDetails");
                });

            modelBuilder.Entity("WebApplication4.Models.Location", b =>
                {
                    b.Navigation("Accidents");
                });

            modelBuilder.Entity("WebApplication4.Models.MaterialAgent", b =>
                {
                    b.Navigation("MaterialAgentDetails");
                });

            modelBuilder.Entity("WebApplication4.Models.NatureLesion", b =>
                {
                    b.Navigation("NatureLesionDetail");
                });

            modelBuilder.Entity("WebApplication4.Models.OutsideFirm", b =>
                {
                    b.Navigation("Persons");
                });

            modelBuilder.Entity("WebApplication4.Models.Person", b =>
                {
                    b.Navigation("Reports");

                    b.Navigation("VictimInformations");
                });

            modelBuilder.Entity("WebApplication4.Models.ProposedMesure", b =>
                {
                    b.Navigation("ProposedMesureDetails");
                });

            modelBuilder.Entity("WebApplication4.Models.Protection", b =>
                {
                    b.Navigation("AccidentProtections");
                });

            modelBuilder.Entity("WebApplication4.Models.VictimInformation", b =>
                {
                    b.Navigation("VictimProtectionAssets");
                });
#pragma warning restore 612, 618
        }
    }
}
