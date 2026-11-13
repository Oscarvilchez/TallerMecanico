
using System.Diagnostics.CodeAnalysis;

namespace TallerMecanico.Api.Dominio
{
    public class Vehiculo
    {
        // 1. CAMPOS (Variables privadas)
        private string _placa = string.Empty;
        private string _marca = string.Empty;
        private string _modelo = string.Empty;
        private string _color = string.Empty;
        private int _anio;       
        private int _kilometraje;
                 
        // 2. CONSTRUCTORES
        public Vehiculo()
        {
        }
        [SetsRequiredMembers]
        public Vehiculo(string placa, string marca, string modelo, string color, int anio, int kilometraje, int clienteId)
        {
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            Color = color;
            Anio = anio;            
            Kilometraje = kilometraje;
            ClienteId = clienteId;

        }
        // 2. PROPIEDADES
        public required string Placa
        {
            get { return _placa; }
            set
            {
                if ((string.IsNullOrWhiteSpace(value)) || value.Length != 7 || value[3] != '-')
                {
                    throw new ArgumentException("Campo Placa Obligatorio");
                }
                _placa = value;
            }
        }
        public required string Marca
        {
            get { return _marca; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Campo Marca Obligatorio");
                }
                _marca = value;
            }
        }
        public required string Modelo
        {
            get { return _modelo; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Campo Modelo Obligatorio");
                }
                _modelo = value;
            }
        }
        public required string Color
        {
            get { return _color; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Campo Color Obligatorio");
                }
                _color = value;
            }
        }
        public required int Anio
        {
            get { return _anio; }
            set
            {
                if (value < 1996 || value > DateTime.Now.Year)
                {
                    throw new ArgumentException("El año del vehículo no puede ser menor a 1996 ni mayor al año actual.");
                }
                _anio = value;
            }
        }        
        public required int Kilometraje
        {
            get { return _kilometraje; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("El kilometraje no puede ser negativo.");
                }
                _kilometraje = value;
            }
        }
        public int Id { get; private set; }
        public int ClienteId { get;private set; } 
        public Cliente? Cliente { get; set; } 
    }
}
