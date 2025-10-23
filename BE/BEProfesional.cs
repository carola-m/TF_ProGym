﻿using System;
using System.Collections.Generic;

namespace BE
{
    public class BEProfesional
    {
        public int Id { get; set; }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Especialidad { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public List<int> IdsActividadesPuedeDictar { get; set; } = new List<int>();

        public override string ToString()
        {
            return $"{Nombre} {Apellido} ({Especialidad})";
        }
    }
}