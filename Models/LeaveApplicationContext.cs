﻿using Microsoft.EntityFrameworkCore;
namespace Practice.Models;
public partial class LeaveApplicationContext : DbContext
{
    public LeaveApplicationContext(DbContextOptions<LeaveApplicationContext> options)
        : base(options)
    {

    }
  public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<LeaveQuotum> LeaveQuota { get; set; }

    public virtual DbSet<LeaveStatus> LeaveStatuses { get; set; }

    public virtual DbSet<LeaveTable> LeaveTables { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<Profile> Profiles { get; set; }
    public virtual DbSet<MessageModel> MessagesModels { get; set; }
    public virtual DbSet<UserIdentity> Connections { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Server=DESKTOP-JJG787Q\\MSSQLSERVER01;Database=LeaveApplication;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Companyname)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("companyname");
            entity.Property(e => e.Department)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("department");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("lastname");
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("password");

            entity.HasOne(d => d.ManagerNavigation)
                .WithMany(p => p.Employees)
                .HasForeignKey(d => d.Manager)
                .HasConstraintName("FK_Employee_Manager");

        });

        modelBuilder.Entity<LeaveQuotum>(entity =>
        {
            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Emplid).HasColumnName("emplid");
            entity.Property(e => e.Remainingleave).HasColumnName("remainingleave");
            entity.Property(e => e.Totalleave).HasColumnName("totalleave");

            entity.HasOne(d => d.Empl).WithMany(p => p.LeaveQuota)
                .HasForeignKey(d => d.Emplid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LeaveQuota_Employee");
        });
        modelBuilder.Entity<LeaveStatus>(entity =>
        {
            entity.ToTable("LeaveStatus");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.FromDate)
                .HasColumnType("date")
                .HasColumnName("from_date");

            entity.Property(e => e.Leaveid).HasColumnName("leaveid");

            entity.Property(e => e.Leavetype)
                .HasMaxLength(30)
                .HasColumnName("leavetype");

            entity.Property(e => e.Reason)
                .HasMaxLength(30)
                .HasColumnName("reason");

            entity.Property(e => e.Status)
                .HasMaxLength(30)
                .HasColumnName("status");

            entity.Property(e => e.ToDate)
                .HasColumnType("date")
                .HasColumnName("to_date");

            entity.HasOne(d => d.Leave)
                .WithMany()
                .HasForeignKey(d => d.Leaveid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_LeaveStatus_LeaveTable");
        });

            modelBuilder.Entity<LeaveTable>(entity =>
          {
            entity.ToTable("LeaveTable");

            entity.Property(e => e.Leaveid)
                .HasColumnName("leaveid")
                .ValueGeneratedOnAdd();

            entity.Property(e => e.Employeeid)
                .HasColumnName("employeeid");

            entity.Property(e => e.Id)
                .HasColumnName("id");
        });

        modelBuilder.Entity<MessageModel>(entity =>
        {
            entity.ToTable("Message");

            entity.Property(e => e.senderid)
                .HasColumnName("senderid");
              

            entity.Property(e => e.receiverid)
                .HasColumnName("receiverid");
            entity.Property(e => e.Message)
               .HasColumnName("Message");

            entity.Property(e => e.ReadorNot)
               .HasColumnName("ReadorNot");


            entity.Property(e => e.timestamp)
               .HasColumnName("timestamp");

            entity.Property(e => e.id)
                .HasColumnName("id")
                  .ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.ToTable("EmployeeData");

            entity.Property(e => e.Emplid)
                .HasColumnName("emplid");
                

            entity.Property(e => e.File)
                .HasColumnName("documentfile");

            entity.Property(e => e.documentName)
                .HasColumnName("documentname");
            entity.Property(e => e.id)
                .HasColumnName("id");
        });

        modelBuilder.Entity<Profile>(entity =>
        {
            entity.ToTable("EmployeeProfile");

            entity.Property(e => e.Emplid)
                .HasColumnName("emplid");


            entity.Property(e => e.img)
                .HasColumnName("profile");

           
            entity.Property(e => e.id)
                .HasColumnName("id");
        });

        modelBuilder.Entity<UserIdentity>(entity =>
        {
            entity.ToTable("Connections");

            entity.Property(e => e.UserId)
                .HasColumnName("Userid");


            entity.Property(e => e.ConnectionId)
                .HasColumnName("ConnectionId");


            entity.Property(e => e.id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();
        });

         modelBuilder.Entity<Manager>(entity =>
        {
            entity.ToTable("Manager");

            entity.Property(e => e.Companyname)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("companyname");
            entity.Property(e => e.Department)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("department");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("lastname");
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
