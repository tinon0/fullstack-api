using FluentValidation;
using Practica_Final.Comandos;
using Practica_Final.DTO;

namespace Practica_Final.Validations
{
    public class SoldadoValidator : AbstractValidator<NuevoSoldado>
    {
        public SoldadoValidator()
        {
            RuleFor(a => a.Altura).NotEmpty().WithMessage("Falta ingresar la altura del soldado");
            RuleFor(a => a.Apellido).NotEmpty().WithMessage("Falta ingresar apellido del soldado");
            RuleFor(a => a.Localidad).NotEmpty().WithMessage("Falta ingresar la localidad del soldado");
            RuleFor(a => a.Peso).NotEmpty().WithMessage("Falta ingresar el peso del soldado");
            RuleFor(a => a.Nombre).NotEmpty().WithMessage("Falta ingresar nombre del soldado");
        }
    }
}
