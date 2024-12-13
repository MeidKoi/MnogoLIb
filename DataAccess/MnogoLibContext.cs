using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class MnogoLibContext : DbContext
    {
        public MnogoLibContext()
        {
        }

        public MnogoLibContext(DbContextOptions<MnogoLibContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<AuthorStatus> AuthorStatuses { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Chat> Chats { get; set; } = null!;
        public virtual DbSet<ChatUser> ChatUsers { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<CommentRate> CommentRates { get; set; } = null!;
        public virtual DbSet<File> Files { get; set; } = null!;
        public virtual DbSet<Genre> Genres { get; set; } = null!;
        public virtual DbSet<GroupMaterial> GroupMaterials { get; set; } = null!;
        public virtual DbSet<Material> Materials { get; set; } = null!;
        public virtual DbSet<MaterialFile> MaterialFiles { get; set; } = null!;
        public virtual DbSet<MaterialsUserStatus> MaterialsUserStatuses { get; set; } = null!;
        public virtual DbSet<MessageStatus> MessageStatuses { get; set; } = null!;
        public virtual DbSet<MessagesUser> MessagesUsers { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<PaymentUser> PaymentUsers { get; set; } = null!;
        public virtual DbSet<Rate> Rates { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserStatus> UserStatuses { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.IdAuthor)
                    .HasName("pk_Authors_id_author");

                entity.Property(e => e.IdAuthor).HasColumnName("id_author");

                entity.Property(e => e.NameAuthor)
                    .HasMaxLength(100)
                    .IsUnicode(true)
                    .HasColumnName("name_author");
            });

            modelBuilder.Entity<AuthorStatus>(entity =>
            {
                entity.HasKey(e => e.IdAuthorStatus)
                    .HasName("pk_Author_Status_id_author_status");

                entity.ToTable("Author_Status");

                entity.Property(e => e.IdAuthorStatus).HasColumnName("id_author_status");

                entity.Property(e => e.NameAuthorStatus)
                    .HasMaxLength(30)
                    .IsUnicode(true)
                    .HasColumnName("name_author_status");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory)
                    .HasName("pk_Categories_id_category");

                entity.Property(e => e.IdCategory).HasColumnName("id_category");

                entity.Property(e => e.NameCategory)
                    .HasMaxLength(50)
                    .IsUnicode(true)
                    .HasColumnName("name_category");
            });

            modelBuilder.Entity<Chat>(entity =>
            {
                entity.HasKey(e => e.IdChat)
                    .HasName("pk_Chat_id_chat");

                entity.ToTable("Chat");

                entity.Property(e => e.IdChat).HasColumnName("id_chat");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("created_time");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_time");

                entity.Property(e => e.IdOwner).HasColumnName("id_owner");

                entity.Property(e => e.LastUpdateBy).HasColumnName("last_update_by");

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("last_update_time");

                entity.Property(e => e.NameChat)
                    .HasMaxLength(50)
                    .IsUnicode(true)
                    .HasColumnName("name_chat");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.ChatDeletedByNavigations)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK__Chat__deleted_by__1CDC41A7");

                entity.HasOne(d => d.IdOwnerNavigation)
                    .WithMany(p => p.ChatIdOwnerNavigations)
                    .HasForeignKey(d => d.IdOwner)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Users_Chat_0");

                entity.HasOne(d => d.LastUpdateByNavigation)
                    .WithMany(p => p.ChatLastUpdateByNavigations)
                    .HasForeignKey(d => d.LastUpdateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Chat__last_updat__1BE81D6E");
            });

            modelBuilder.Entity<ChatUser>(entity =>
            {
                entity.HasKey(e => new { e.IdUser, e.IdChat });

                entity.ToTable("Chat_Users");

                entity.HasIndex(e => e.CreatedBy, "IX_Relationship25");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.IdChat).HasColumnName("id_chat");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("created_time");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_time");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ChatUserCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship25");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.ChatUserDeletedByNavigations)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK__Chat_User__delet__2B2A60FE");

                entity.HasOne(d => d.IdChatNavigation)
                    .WithMany(p => p.ChatUsers)
                    .HasForeignKey(d => d.IdChat)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship22");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.ChatUserIdUserNavigations)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship21");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.IdComment)
                    .HasName("pk_Comments_id_comment");

                entity.Property(e => e.IdComment).HasColumnName("id_comment");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("created_time");

                entity.Property(e => e.DeletedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_time");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("last_update_time");

                entity.Property(e => e.TextComment)
                    .HasMaxLength(250)
                    .IsUnicode(true)
                    .HasColumnName("text_comment");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Users_Comments_0");

                entity.HasMany(d => d.IdMaterials)
                    .WithMany(p => p.IdComments)
                    .UsingEntity<Dictionary<string, object>>(
                        "CommentMaterial",
                        l => l.HasOne<Material>().WithMany().HasForeignKey("IdMaterial").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_Materials_Comment_Material_2"),
                        r => r.HasOne<Comment>().WithMany().HasForeignKey("IdComment").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_Comments_Comment_Material_1"),
                        j =>
                        {
                            j.HasKey("IdComment", "IdMaterial").HasName("pk_Comment_Material_0");

                            j.ToTable("Comment_Material");

                            j.IndexerProperty<int>("IdComment").HasColumnName("id_comment");

                            j.IndexerProperty<int>("IdMaterial").HasColumnName("id_material");
                        });
            });

            modelBuilder.Entity<CommentRate>(entity =>
            {
                entity.HasKey(e => new { e.IdUser, e.IdComment });

                entity.ToTable("Comment_Rates");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.IdComment).HasColumnName("id_comment");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("created_time");

                entity.Property(e => e.DeletedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_time");

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("last_update_time");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.IdCommentNavigation)
                    .WithMany(p => p.CommentRates)
                    .HasForeignKey(d => d.IdComment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship24");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.CommentRates)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship23");
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.HasKey(e => e.IdFile)
                    .HasName("pk_Files_id_file");

                entity.Property(e => e.IdFile).HasColumnName("id_file");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("created_time");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_time");

                entity.Property(e => e.LastUpdateBy).HasColumnName("last_update_by");

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("last_update_time");

                entity.Property(e => e.NameFile)
                    .HasMaxLength(50)
                    .IsUnicode(true)
                    .HasColumnName("name_file");

                entity.Property(e => e.PathFile)
                    .HasMaxLength(300)
                    .IsUnicode(true)
                    .HasColumnName("path_file");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.FileCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Files__deleted_t__247D636F");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.FileDeletedByNavigations)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK__Files__deleted_b__2665ABE1");

                entity.HasOne(d => d.LastUpdateByNavigation)
                    .WithMany(p => p.FileLastUpdateByNavigations)
                    .HasForeignKey(d => d.LastUpdateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Files__last_upda__257187A8");
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasKey(e => e.IdGenre)
                    .HasName("pk_Genres_id_genre");

                entity.Property(e => e.IdGenre).HasColumnName("id_genre");

                entity.Property(e => e.NameGenre)
                    .HasMaxLength(30)
                    .IsUnicode(true)
                    .HasColumnName("name_genre");
            });

            modelBuilder.Entity<GroupMaterial>(entity =>
            {
                entity.HasKey(e => e.IdGroup);

                entity.ToTable("Group_Materials");

                entity.Property(e => e.IdGroup)
                    .HasColumnName("id_group");

                entity.Property(e => e.DescriptionGroup)
                    .HasMaxLength(1000)
                    .IsUnicode(true)
                    .HasColumnName("description_group");

                entity.Property(e => e.NameGroup)
                    .HasMaxLength(115)
                    .IsUnicode(true)
                    .HasColumnName("name_group");

                entity.HasMany(d => d.IdMaterials)
                    .WithMany(p => p.IdGroups)
                    .UsingEntity<Dictionary<string, object>>(
                        "RelatedMaterial",
                        l => l.HasOne<Material>().WithMany().HasForeignKey("IdMaterial").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Relationship30"),
                        r => r.HasOne<GroupMaterial>().WithMany().HasForeignKey("IdGroup").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("Relationship29"),
                        j =>
                        {
                            j.HasKey("IdGroup", "IdMaterial");

                            j.ToTable("Related_materials");

                            j.IndexerProperty<int>("IdGroup").HasColumnName("id_group");

                            j.IndexerProperty<int>("IdMaterial").HasColumnName("id_material");
                        });
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.HasKey(e => e.IdMaterial)
                    .HasName("pk_Materials_id_material");

                entity.HasIndex(e => e.FileIcon, "IX_Relationship26");

                entity.Property(e => e.IdMaterial).HasColumnName("id_material");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("created_time");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_time");

                entity.Property(e => e.DescriptionMaterial)
                    .HasMaxLength(1000)
                    .IsUnicode(true)
                    .HasColumnName("description_material");

                entity.Property(e => e.FileIcon).HasColumnName("file_icon");

                entity.Property(e => e.IdAuthor).HasColumnName("id_author");

                entity.Property(e => e.IdAuthorStatus).HasColumnName("id_author_status");

                entity.Property(e => e.IdCategory).HasColumnName("id_category");

                entity.Property(e => e.LastUpdateBy).HasColumnName("last_update_by");

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("last_update_time");

                entity.Property(e => e.NameMaterial)
                    .HasMaxLength(250)
                    .IsUnicode(true)
                    .HasColumnName("name_material");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.MaterialCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Materials__creat__0D99FE17");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.MaterialDeletedByNavigations)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK__Materials__delet__0F824689");

                entity.HasOne(d => d.FileIconNavigation)
                    .WithMany(p => p.Materials)
                    .HasForeignKey(d => d.FileIcon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship26");

                entity.HasOne(d => d.IdAuthorNavigation)
                    .WithMany(p => p.Materials)
                    .HasForeignKey(d => d.IdAuthor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Authors_Materials_1");

                entity.HasOne(d => d.IdAuthorStatusNavigation)
                    .WithMany(p => p.Materials)
                    .HasForeignKey(d => d.IdAuthorStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Author_Status_Materials_2");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Materials)
                    .HasForeignKey(d => d.IdCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Categories_Materials_0");

                entity.HasOne(d => d.LastUpdateByNavigation)
                    .WithMany(p => p.MaterialLastUpdateByNavigations)
                    .HasForeignKey(d => d.LastUpdateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Materials__last___0E8E2250");

                entity.HasMany(d => d.IdGenres)
                    .WithMany(p => p.IdMaterials)
                    .UsingEntity<Dictionary<string, object>>(
                        "MaterialsGenre",
                        l => l.HasOne<Genre>().WithMany().HasForeignKey("IdGenre").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_Genres_Materials_Genres_2"),
                        r => r.HasOne<Material>().WithMany().HasForeignKey("IdMaterial").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("fk_Materials_Materials_Genres_1"),
                        j =>
                        {
                            j.HasKey("IdMaterial", "IdGenre").HasName("pk_Materials_Genres_0");

                            j.ToTable("Materials_Genres");

                            j.IndexerProperty<int>("IdMaterial").HasColumnName("id_material");

                            j.IndexerProperty<int>("IdGenre").HasColumnName("id_genre");
                        });
            });

            modelBuilder.Entity<MaterialFile>(entity =>
            {
                entity.HasKey(e => new { e.IdMaterial, e.IdFile })
                    .HasName("pk_Material_File_0");

                entity.ToTable("Material_File");

                entity.Property(e => e.IdMaterial).HasColumnName("id_material");

                entity.Property(e => e.IdFile).HasColumnName("id_file");

                entity.Property(e => e.Chapter).HasColumnName("chapter");

                entity.Property(e => e.FrameNumber).HasColumnName("frame_number");

                entity.Property(e => e.Volume).HasColumnName("volume");

                entity.HasOne(d => d.IdFileNavigation)
                    .WithMany(p => p.MaterialFiles)
                    .HasForeignKey(d => d.IdFile)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Files_Material_File_2");

                entity.HasOne(d => d.IdMaterialNavigation)
                    .WithMany(p => p.MaterialFiles)
                    .HasForeignKey(d => d.IdMaterial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Materials_Material_File_1");
            });

            modelBuilder.Entity<MaterialsUserStatus>(entity =>
            {
                entity.HasKey(e => new { e.IdMaterial, e.IdUser, e.IdUserStatus })
                    .HasName("pk_Materials_User_Status_0");

                entity.ToTable("Materials_User_Status");

                entity.Property(e => e.IdMaterial).HasColumnName("id_material");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.IdUserStatus).HasColumnName("id_user_status");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("created_time");

                entity.Property(e => e.DeletedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_time");

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("last_update_time");

                entity.HasOne(d => d.IdMaterialNavigation)
                    .WithMany(p => p.MaterialsUserStatuses)
                    .HasForeignKey(d => d.IdMaterial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Materials_Materials_User_Status_2");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.MaterialsUserStatuses)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Users_Materials_User_Status_1");

                entity.HasOne(d => d.IdUserStatusNavigation)
                    .WithMany(p => p.MaterialsUserStatuses)
                    .HasForeignKey(d => d.IdUserStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_User_Status_Materials_User_Status_3");
            });

            modelBuilder.Entity<MessageStatus>(entity =>
            {
                entity.HasKey(e => e.IdMessageStatus)
                    .HasName("pk_Message_Status_id_message_status");

                entity.ToTable("Message_Status");

                entity.Property(e => e.IdMessageStatus).HasColumnName("id_message_status");

                entity.Property(e => e.NameMessageStatus)
                    .HasMaxLength(50)
                    .IsUnicode(true)
                    .HasColumnName("name_message_status");
            });

            modelBuilder.Entity<MessagesUser>(entity =>
            {
                entity.HasKey(e => e.IdMessage)
                    .HasName("pk_Messages_User_id_message");

                entity.ToTable("Messages_User");

                entity.Property(e => e.IdMessage).HasColumnName("id_message");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("created_time");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_time");

                entity.Property(e => e.DeliverDate)
                    .HasColumnType("datetime")
                    .HasColumnName("deliver_date");

                entity.Property(e => e.IdChat).HasColumnName("id_chat");

                entity.Property(e => e.IdMessageStatus).HasColumnName("id_message_status");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("last_update_time");

                entity.Property(e => e.TextMessage)
                    .HasMaxLength(500)
                    .IsUnicode(true)
                    .HasColumnName("text_message");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.MessagesUserDeletedByNavigations)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK__Messages___delet__21A0F6C4");

                entity.HasOne(d => d.IdChatNavigation)
                    .WithMany(p => p.MessagesUsers)
                    .HasForeignKey(d => d.IdChat)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Chat_Messages_User_1");

                entity.HasOne(d => d.IdMessageStatusNavigation)
                    .WithMany(p => p.MessagesUsers)
                    .HasForeignKey(d => d.IdMessageStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Message_Status_Messages_User_2");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.MessagesUserIdUserNavigations)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Users_Messages_User_0");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.IdPayment);

                entity.ToTable("Payment");

                entity.Property(e => e.IdPayment)
                    .HasColumnName("id_payment");

                entity.Property(e => e.CardNumber)
                    .HasMaxLength(16)
                    .IsUnicode(true)
                    .HasColumnName("card_number");

                entity.Property(e => e.Cvv)
                    .HasMaxLength(3)
                    .IsUnicode(true)
                    .HasColumnName("cvv")
                    .IsFixedLength();

                entity.Property(e => e.ExpressionDate)
                    .HasColumnType("date")
                    .HasColumnName("expression_date");
            });

            modelBuilder.Entity<PaymentUser>(entity =>
            {
                entity.HasKey(e => new { e.IdPayment, e.IdUser });

                entity.ToTable("Payment_Users");

                entity.Property(e => e.IdPayment).HasColumnName("id_payment");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.HasOne(d => d.IdPaymentNavigation)
                    .WithMany(p => p.PaymentUsers)
                    .HasForeignKey(d => d.IdPayment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship31");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.PaymentUsers)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship32");
            });

            modelBuilder.Entity<Rate>(entity =>
            {
                entity.HasKey(e => e.IdRate)
                    .HasName("pk_Rates_id_rate");

                entity.Property(e => e.IdRate).HasColumnName("id_rate");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("created_time");

                entity.Property(e => e.DeletedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_time");

                entity.Property(e => e.IdMaterial).HasColumnName("id_material");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("last_update_time");

                entity.Property(e => e.ValueRate).HasColumnName("value_rate");

                entity.HasOne(d => d.IdMaterialNavigation)
                    .WithMany(p => p.Rates)
                    .HasForeignKey(d => d.IdMaterial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Materials_Rates_1");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Rates)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Users_Rates_0");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                    .HasName("pk_Roles_id_role");

                entity.Property(e => e.IdRole).HasColumnName("id_role");

                entity.Property(e => e.NameRole)
                    .HasMaxLength(15)
                    .IsUnicode(true)
                    .HasColumnName("name_role");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("pk_Users_id_user");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("created_time");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.DeletedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_time");

                entity.Property(e => e.EmailUser)
                    .HasMaxLength(50)
                    .IsUnicode(true)
                    .HasColumnName("email_user");

                entity.Property(e => e.IdRole).HasColumnName("id_role");

                entity.Property(e => e.LastUpdateBy).HasColumnName("last_update_by");

                entity.Property(e => e.LastUpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("last_update_time");

                entity.Property(e => e.NicknameUser)
                    .HasMaxLength(50)
                    .IsUnicode(true)
                    .HasColumnName("nickname_user");

                entity.Property(e => e.PasswordUser)
                    .HasMaxLength(255)
                    .IsUnicode(true)
                    .HasColumnName("password_user");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Roles_Users_0");
            });

            modelBuilder.Entity<UserStatus>(entity =>
            {
                entity.HasKey(e => e.IdUserStatus)
                    .HasName("pk_User_Status_id_user_status");

                entity.ToTable("User_Status");

                entity.Property(e => e.IdUserStatus).HasColumnName("id_user_status");

                entity.Property(e => e.NameUserStatus)
                    .HasMaxLength(30)
                    .IsUnicode(true)
                    .HasColumnName("name_user_status");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}