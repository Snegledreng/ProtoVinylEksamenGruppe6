﻿using ProtoVinylEksamenGruppe6.Model;
using System.Reflection;

namespace ProtoVinylEksamenGruppe6.Model
{
    public class Medie
    {
        //instansfelter
        //
        private int? _id;
        //
        private string? _titel;
        private string? _kunstner;
        private int _år;
        private string? _genre;
        private string? _stand;
        private int _pris;
        private string? _type;
        private string? _vinylType;
        private bool _reserveret;

        //properties
        //
        public int? Id { get { return _id; } set { _id = value; } }
        //
        public string? Titel { get { return _titel; } set { _titel = value; } }
        public string? Kunstner { get { return _kunstner; } set { _kunstner = value; } }
        public int År { get { return _år; } set { _år = value; } }
        public string? Genre { get { return _genre; } set { _genre = value; } }
        public string? Stand { get { return _stand; } set { _stand = value; } }
        public int Pris { get { return _pris; } set { _pris = value; } }
        public string? Type { get { return _type; } set { _type = value; } }
        public string? VinylType { get { return _vinylType; } set { _vinylType = value; } }
        public bool Reserveret { get { return _reserveret; } set { _reserveret = value; } }

        //konstruktør
        public Medie() { }


        //Bliver brugt til at sammenligne objekter til kurv
        public override bool Equals(object? obj)
        {
            return obj is Medie medie &&
                   _id == medie._id;
        }
    }
}