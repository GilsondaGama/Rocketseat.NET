using Petfolio.Communication.Responses;

namespace Petfolio.Application.UseCases.Pets.GetById;

public class GetPetByIdUseCase
{
    public ResponsePetJson Execute(int id)
    {
        return new ResponsePetJson
        {
            Id = id,
            Name = "Buddy",
            Type = Communication.Enums.PetType.Dog,
            BirthDay = new DateTime( year: 2020, month: 5, day: 4)
        };
    }

}
