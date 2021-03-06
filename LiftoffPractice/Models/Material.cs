﻿using System;
namespace LiftoffPractice.Models
{
    public class Material
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string ArtistComposer { get; set; }
        public string KeyCenter { get; set; }
        public string Tempo { get; set; }
        public string TimeSig { get; set; }
        public string Description { get; set; }
        public int Mastery { get; set; }

        public int Id { get; set; }

        public Material()
        {
        }

        public Material(string name, string artistComposer, string keyCenter, string tempo, string timeSig, string description, int mastery)
        {
            Name = name;
            ArtistComposer = artistComposer;
            KeyCenter = keyCenter;
            Tempo = tempo;
            TimeSig = timeSig;
            Description = description;
            Mastery = mastery;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is Material material &&
                   Id == material.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
