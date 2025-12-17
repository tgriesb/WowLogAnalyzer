using System.Text.Json;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WowLogAnalyzer.Entities;
using WowLogAnalyzer.Serialization;

namespace WowLogAnalyzer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<CombatEvent> CombatEvents { get; set; } = null!;
        public DbSet<Character> Characters { get; set; } = null!;
        public DbSet<Guild> Guilds { get; set; } = null!;
        public DbSet<Log> Logs { get; set; } = null!;
        public DbSet<Encounter> Encounters { get; set; } = null!;
        public DbSet<Spell> Spells { get; set; } = null!;
        public DbSet<SpecUniqueSpell> SpecUniqueSpells { get; set; } = null!;
        public DbSet<CharacterEncounter> CharacterEncounters { get; set; } = null!;
        public DbSet<Spec> Specs { get; set; } = null!;
        public DbSet<UserSession> UserSessions { get; set; } = null!;
        public DbSet<RefreshToken> RefreshTokens { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserSession>()
                .HasOne(s => s.User)
                .WithMany(u => u.Sessions)
                .HasForeignKey(s => s.UserId);

            modelBuilder.Entity<RefreshToken>()
                .HasOne(rt => rt.UserSession)
                .WithMany(s => s.RefreshTokens)
                .HasForeignKey(rt => rt.UserSessionId);

            modelBuilder.Entity<RefreshToken>()
                .HasOne(rt => rt.ReplacedByToken)
                .WithOne()
                .HasForeignKey<RefreshToken>(rt => rt.ReplacedByTokenId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RefreshToken>()
                .HasIndex(rt => new { rt.TokenHash, rt.UserSessionId })
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(e => e.Email)
                .IsUnique();

            modelBuilder.Entity<CombatEvent>()
                .HasIndex(e => new { e.LogId, e.EventType, e.Timestamp })
                .HasDatabaseName("idx_combat_events_log_type_time");

            var converter = new ValueConverter<object, string>(
                v => EventDataJson.Serialize(v),
                v => EventDataJson.Deserialize(v)
            );

            modelBuilder.Entity<CombatEvent>(builder =>
            {
                builder.Property(e => e.EventData)
                    .HasColumnType("jsonb")
                    .HasConversion(converter);
            });

            modelBuilder.Entity<Log>()
                .HasMany(l => l.CombatEvents)
                .WithOne(e => e.Log)
                .HasForeignKey(e => e.LogId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Encounter>()
                    .HasOne(e => e.Log)
                    .WithMany()
                    .HasForeignKey(e => e.LogId)
                    .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
