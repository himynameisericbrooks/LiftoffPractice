using System;
using System.Collections.Generic;
using LiftoffPractice.Models;

namespace LiftoffPractice.Data
{
    public class MaterialData
    {
        // store material
        private static Dictionary<int, Material> Materials = new Dictionary<int, Material>();

        // GetAll
        // retrieve the materials
        public static IEnumerable<Material> GetAll()
        {
            return Materials.Values;
        }

        // add materials
        public static void Add(Material newMaterial)
        {
            Materials.Add(newMaterial.Id, newMaterial);
        }

        // remove an material
        public static void Remove(int id)
        {
            Materials.Remove(id);
        }

        //GetById
        // retrieve a single material
        public static Material GetById(int id)
        {
            return Materials[id];
        }
    }
}
