﻿using System.ComponentModel.DataAnnotations;

namespace ApiTarefas.Dtos
{
    public class VeiculoDTO
    {
        [Required]
        [MinLength(4)]
        public string Marca { get; set; }

        [Required]
        [MinLength(5)]
        public string Modelo { get; set; }
        public int AnoFab { get; set; }
        public int AnoModelo { get; set; }
        public string Placa { get; set; }

    }
}
