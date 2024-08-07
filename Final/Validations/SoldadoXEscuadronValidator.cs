using FluentValidation;
using Practica_Final.Comandos;

namespace Practica_Final.Validations
{
    public class SoldadoXEscuadronValidator : AbstractValidator<NuevoSoldadoXEscuadron>
    {
        public SoldadoXEscuadronValidator()
        {
            RuleFor(a => a.IdEscuadron).NotEmpty().WithMessage("Debe ingresar un ID de un escuadron");
            RuleFor(a => a.IdSoldado).NotEmpty().WithMessage("Debe ingresar un ID de un soldado");
            RuleFor(a => a.Actividad).NotEmpty().WithMessage("Debe ingresar una actividad");
        }
    }
}
