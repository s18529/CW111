using Cw11.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW11.Models
{
    public class s18529Context : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

        public s18529Context(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Doctor>(e =>
            {
                e.HasKey(k => k.IdDoctor).HasName("Doctor_key");
                e.Property(p => p.FirstName).HasMaxLength(100).IsRequired();
                e.Property(p => p.LastName).HasMaxLength(100).IsRequired();
                e.Property(p => p.Email).HasMaxLength(100).IsRequired();

                IEnumerable<Doctor> doctors = new List<Doctor>
                {
                    new Doctor{ FirstName = "Andzejr", LastName="Jezdaeassd", Email = "andderj@wp.pl", IdDoctor = 1},
                    new Doctor{ FirstName = "Filip", LastName="Hajzer", Email = "hajzio@wp.pl", IdDoctor = 2},
                    new Doctor{ FirstName = "Katarzynak", LastName="Krzak", Email = "kszuny@wp.pl", IdDoctor = 3}
                };
                e.HasData(doctors);
            });
            builder.Entity<Patient>(e =>
            {
                e.HasKey(k => k.IdPatient).HasName("Patient_key");
                e.Property(p => p.FirstName).HasMaxLength(100).IsRequired();
                e.Property(p => p.LastName).HasMaxLength(100).IsRequired();
                e.Property(p => p.BirthDate).IsRequired();

                IEnumerable<Patient> patients = new List<Patient>
                {
                    new Patient{ FirstName ="LaLa", LastName = "kosta", BirthDate = DateTime.Parse("20.08.1995"), IdPatient =1},
                    new Patient{ FirstName ="Koko", LastName = "Jambo", BirthDate = DateTime.Parse("10.07.1995"), IdPatient =2},
                    new Patient{ FirstName ="TuTu", LastName = "Mono", BirthDate = DateTime.Parse("22.10.1990"), IdPatient =3}
                };
                e.HasData(patients);
            });

            builder.Entity<Medicament>(e =>
            {
                e.HasKey(k => k.IdMedicament).HasName("Medicament_key");
                e.Property(p => p.Name).HasMaxLength(100).IsRequired();
                e.Property(p => p.Description).HasMaxLength(100).IsRequired();
                e.Property(p => p.Type).HasMaxLength(100).IsRequired();

                IEnumerable<Medicament> medicaments = new List<Medicament>
                {
                    new Medicament {Name = "Paracetamol", Description = "Przeciw bolowy", Type = " fajny", IdMedicament = 1},
                    new Medicament {Name = "Teraflu", Description = "Lek dla mezczyzn", Type = " uzyteczny", IdMedicament = 2},
                    new Medicament {Name = "Marihuana", Description = "Przeciw bolowy, mala ilosc THC", Type = "bardzo fajny", IdMedicament = 3},
                };

                e.HasData(medicaments);
            });
            builder.Entity<Prescription>(e =>
            {
                e.HasKey(k => k.IdPrescription).HasName("Prescription_key");
                e.Property(p => p.Date).IsRequired();
                e.Property(p => p.DueDate).IsRequired();

                e.HasOne(d => d.Doctor)
                .WithMany(d => d.Prescriptions)
                .HasForeignKey(d => d.IdDoctor)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Doctor_Prescription");

                e.HasOne(d => d.Patient)
                .WithMany(d => d.Prescriptions)
                .HasForeignKey(d => d.IdPatient)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Patient_Prescription");

                IEnumerable<Prescription> prescriptions = new List<Prescription>
                {
                    new Prescription{ DueDate = DateTime.Parse("03.02.2021"), Date =  DateTime.Parse("01.01.2021"), IdDoctor =2, IdPatient =2, IdPrescription =1},
                    new Prescription{ DueDate = DateTime.Parse("03.04.2021"), Date =  DateTime.Parse("01.02.2021"), IdDoctor =1, IdPatient =1, IdPrescription =2},
                    new Prescription{ DueDate = DateTime.Parse("08.02.2021"), Date =  DateTime.Parse("06.10.2020"), IdDoctor =2, IdPatient =3, IdPrescription =3},
                    new Prescription{ DueDate = DateTime.Parse("03.07.2021"), Date =  DateTime.Parse("05.08.2020"), IdDoctor =3, IdPatient =2, IdPrescription =4},
                };
                e.HasData(prescriptions);
            });
            builder.Entity<PrescriptionMedicament>(e =>
            {
                e.HasKey(k => k.IdMedicament).HasName("Medicament_Fkey");
                e.HasKey(k => k.IdPrescription).HasName("Prescription_Fkey");
                e.Property(p => p.Details).HasMaxLength(100).IsRequired();

                e.ToTable("Prescription_Medicament");

                e.HasOne(d => d.Medicament)
                .WithMany(d => d.PrescriptionMedicaments)
                .HasForeignKey(d => d.IdMedicament)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Medicament_Prescription");

                e.HasOne(d => d.Prescription)
                .WithMany(d => d.PrescriptionMedicaments)
                .HasForeignKey(d => d.IdPrescription)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Prescription_Medicaments");

                IEnumerable<PrescriptionMedicament> prescriptionMedicaments = new List<PrescriptionMedicament>
                {
                    new PrescriptionMedicament { Details="aaaaaa", Dose =2, IdMedicament =1, IdPrescription = 2},
                    new PrescriptionMedicament { Details="bbbbbbbbbbbb", Dose =3, IdMedicament =2, IdPrescription = 1},
                    new PrescriptionMedicament { Details="cccccc", Dose =1, IdMedicament =3, IdPrescription = 3},
                };
                e.HasData(prescriptionMedicaments);
            });

        }
    }
}
